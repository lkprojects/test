using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MislakaInterface
{

    public class MislakaFileHandler
    {
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MislakaFileName mislakaFileName;
        private DAL.DAL Dal = new DAL.DAL("MislakaInterface");
        private FileTypes svivatAvoda;
        private string directory;

        public void ProcessCycle()
        {
            // Checking if there are files to process ("Achzakot" or "Feedbacks")
            string MisparKovetz;
            directory = Dal.GetConfigParam("MislakaFolder");

            log.Info("Start Process Cycle");

            FileTypes fileType = (FileTypes)Enum.Parse(typeof(FileTypes), Dal.GetConfigParam("SVIVAT-AVODA")); // 1= Test, 2=Production
            ProduceEvents();

            //Read all incoming files
            foreach (string file in Directory.GetFiles(directory))
            {
                string filename = file.Substring(file.LastIndexOf('\\') + 1);
                mislakaFileName = new MislakaFileName(filename);
                if (mislakaFileName != null)
                {
                    if (mislakaFileName.Service == ServiceTypes.HOLDNG ||
                        mislakaFileName.Service == ServiceTypes.CONSLT)
                    {
                        // If it is "Achzakot" = Load Achzakot.
                        log.Info("Loading Achzakot file " + filename);
                        MisparKovetz = LoadAchzakot(file);

                        // Update the status
                        if (MisparKovetz != null)
                        {
                            SendSuccessFeedback(directory, MisparKovetz, file, 20 /*Feedback type*/);
                        }
                        else
                            SendErrorFeedback(); // Error status
                    }
                    //If it is a feedback - process feedback
                    if (mislakaFileName.Service == ServiceTypes.FEDBKA ||
                        mislakaFileName.Service == ServiceTypes.FEDBKB)
                    {
                        LoadFeedback(file);
                        //update status
                    }
                }
                else
                {
                    SendErrorFeedback(); // Error feedback
                }
            }
            log.Info("End Process Cycle");

        }
        
        public MislakaFileHandler (FileTypes SvivatAvoda)
        {
            svivatAvoda = SvivatAvoda;
        }

        public MislakaFileHandler()
        {
            svivatAvoda = FileTypes.TST;
        }

        /// <summary>
        /// Loads Achzakot file information and parses in into a "kovetz" object
        /// </summary>
        /// <param name="filename">XML file containing achzakot</param>
        /// <returns>MIPAR-KOVETZ node from the achzakot XML file</returns>
        private string LoadAchzakot(string filename)
        {
            log.Info("Start Load Achzakot file " + filename);
            Achzakot.Mimshak mimshak = new Achzakot.Mimshak();
            HandleAchzakot achzakotParser = new HandleAchzakot();
            XmlSerializer serializer = new XmlSerializer(typeof(Achzakot.Mimshak));
            Stream fs = File.OpenRead(filename);
            try
            {
                mimshak = serializer.Deserialize(fs) as Achzakot.Mimshak;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                log.Error(ex.InnerException.Message, ex);
                fs.Close();
                return null;
            }
            fs.Close();

            achzakotParser.ParseKovetz(mimshak);

            try
            {
                achzakotParser.SaveChanges();
                log.Info("End Load Achzakot file " + filename);

                return mimshak.KoteretKovetz.MISPARHAKOVETZ;
            }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    string rs = "";
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);

                        foreach (var ve in eve.ValidationErrors)
                        {
                            rs += "\n" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                        }
                        Console.WriteLine(rs);
                        log.Error(rs, e);
                    }
                    return null;
                    // throw new Exception(rs);
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    string rs = ex.Message;
                    rs += "\n" + ex.InnerException.InnerException.ToString();
                    Console.WriteLine(rs);
                    log.Error(rs, ex);

                    return null;
                    // throw new Exception(rs);

                }
                catch (Exception e)
                {
                    log.Error("Error Found", e);
                    return null;
                }

        }
        /// <summary>
        /// Sends a success feedback file for a received file.
        /// </summary>
        /// <param name="SvivatAvoda">1=Test; 2=Production</param>
        /// <param name="MisparHakovetz">As defined inside the XML of the file received</param>
        /// <param name="ShemHakovetz">The file name that was receieved</param>
        /// <param name="SugMimshak">1=Achzakot, 2=Trom Yeutz, 3=Achzakot+Trom Yeutz etc.</param>
        private void SendSuccessFeedback(string MislakaFolder, 
                                         string MisparHakovetz,
                                         string FileName, 
                                         int    SugMimshak)
        {
            log.Info("Start Send Success Feedback");
            Feedback.Mimshak mimshak = new Feedback.Mimshak();
            MislakaFileName mislakaFileName;
            HandleFeedback handleFeedback = new HandleFeedback(mimshak);

            mislakaFileName = handleFeedback.ProduceSuccessFeedback(svivatAvoda, MisparHakovetz, FileName, SugMimshak, mimshak);
            
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Feedback.Mimshak));
            string fileName = MislakaFolder + "\\" + mislakaFileName.GetMislakaFileName();
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
            writer.Serialize(file, mimshak);
            file.Close();
            log.Info("End Send Success Feedback - file:" + mislakaFileName.GetMislakaFileName());
        }

        /// <summary>
        /// Produce "9100" event which 
        /// </summary>
        public void ProduceEvents()
        {
            log.Info("Start producing events");

            string fileName;
            Client clientRec;
            HandleEvents handleEvents;
            MislakaFileName mislakaFileName;
            Events.Mimshak EventObj = new Events.Mimshak();

            int numerator = Dal.GetFileNumerator();
            Mutzar lakoachRec = new Mutzar();
            string Version = Events.MimshakKoteretKovetzMISPARGIRSATXML.Item001.ToString().Replace("Item","");

            // Get Mispar Zihuy and change the status from "New" to "Start event"
            string misparZihuy = Dal.ChangeClientStatus("0", (int)ClientStatus.New, (int)ClientStatus.StartEvent);
            while (misparZihuy != "")
            {
                mislakaFileName = new MislakaFileName("001" /*Mefitz to mislaka*/, misparZihuy, ServiceTypes.EVENTS, 
                                                      ProductTypes.NotRelevant, Version, DateTime.Now, numerator, svivatAvoda);
                clientRec = Dal.GetClient(misparZihuy);
                log.Info("Producing event for client - TZ #" + clientRec.TeudatZehut);

                // Read the client data 
                handleEvents = new HandleEvents();
                EventObj = handleEvents.PrepareEventObject(clientRec, numerator);

                // Write the events to a file
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Events.Mimshak));
                fileName = directory + "\\" + mislakaFileName.GetMislakaFileName();
                System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
                try 
                {
                    writer.Serialize(file, EventObj);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    log.Error(ex.InnerException.Message, ex);
                    file.Close();
                    return;
                }
                file.Close();

                // Set the status of the event to "dequeued".
                Dal.ChangeClientStatus(misparZihuy, (int)ClientStatus.StartEvent, (int)ClientStatus.SentEvent);
                log.Info("Finished producing event for client - TZ #" + clientRec.TeudatZehut);
                // Get the next Client TZ.
                misparZihuy = Dal.ChangeClientStatus("0", (int)ClientStatus.New, (int)ClientStatus.StartEvent);
            }
        }
      
        private void SendErrorFeedback()
        {
            throw new NotImplementedException();
        }

        private void LoadFeedback(string file)
        {
            // Read the XML file into "Mimshak" object
            log.Info("Start processing feedback file " + file);
            XmlSerializer serializer = new XmlSerializer(typeof(Feedback.Mimshak));
            Stream fs = File.OpenRead(file);
            HandleFeedback feedback;
            try
            {
                feedback = new HandleFeedback(serializer.Deserialize(fs) as Feedback.Mimshak);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                log.Error("Error found in desirializing Feedback", ex);
                fs.Close();
                return;
            }
            fs.Close();
            FeedbackFile feedbackFile;
            try
            {
                ChangeStatus 
                feedbackFile = feedback.ParseFeedback();

                Dal.SaveFeedback(feedbackFile);
                ChangeStatus 
                log.Info("Finished processing feedback file " + file);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                string rs = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        rs += "\n" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                    Console.WriteLine(rs);
                    log.Error(rs, e);
                }
                return;
                // throw new Exception(rs);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string rs = ex.Message;
                rs += "\n" + ex.InnerException.InnerException.ToString();
                Console.WriteLine(rs);
                log.Error(rs, ex);
                return;

            }
            catch (Exception e)
            {
                log.Error("Error Found", e);
                return;
            }

        }

    }
}
