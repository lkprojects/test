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

    public class MislakaDataFlow
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
                    if (mislakaFileName.Service == ServiceTypes.HOLDNG || mislakaFileName.Service == ServiceTypes.CONSLT)
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
                    if (mislakaFileName.Service == ServiceTypes.FEDBKA || mislakaFileName.Service == ServiceTypes.FEDBKB)
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
        
        public MislakaDataFlow (FileTypes SvivatAvoda)
        {
            svivatAvoda = SvivatAvoda;
        }

        public MislakaDataFlow()
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
            HandleEvents handleEvents;
            MislakaFileName mislakaFileName;
            Events.Mimshak EventObj = new Events.Mimshak();

            int numerator = Dal.GetFileNumerator();
            Mutzar lakoachRec = new Mutzar();
            string Version = Events.MimshakKoteretKovetzMISPARGIRSATXML.Item001.ToString().Replace("Item","");

            // Get Mispar Zihuy and change the status from "New" to "Start event"
            Client client = Dal.GetClientByStatus((int)ClientStatus.New);
            while (client != null)
            {
                mislakaFileName = new MislakaFileName("001" /*Mefitz to mislaka*/, client.TeudatZehut, ServiceTypes.EVENTS, 
                                                      ProductTypes.NotRelevant, Version, DateTime.Now, numerator, svivatAvoda);
                log.Info("Producing event for client - TZ #" + client.TeudatZehut);

                // Read the client data 
                handleEvents = new HandleEvents();
                EventObj = handleEvents.PrepareEventObject(client, numerator);

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
                Kovetz kovetz = new Kovetz();
                kovetz.MISPAR_GIRSAT_XML = EventObj.KoteretKovetz.MISPARGIRSATXML.ToString();
                kovetz.MISPAR_HAKOVETZ = EventObj.KoteretKovetz.MISPARHAKOVETZ;
                kovetz.KOD_SVIVAT_AVODA = EventObj.KoteretKovetz.KODSVIVATAVODA;
                kovetz.SUG_MIMSHAK = EventObj.KoteretKovetz.SUGMIMSHAK;
                kovetz.TAARICH_BITZUA = Common.ConvertDatetime(EventObj.KoteretKovetz.TAARICHBITZUA);
                kovetz.MISPAR_GIRSAT_XML = "001";
                kovetz.SHEM_SHOLEACH = "Events 9100";
                kovetz.FileName = fileName;
                kovetz.MEZAHE_HAAVARA = mislakaFileName.GetMislakaFileName();
                kovetz.Yatzran_SHEM_YATZRAN = "All";
                kovetz.LoadDate = DateTime.Now;
                kovetz.KIVUN_MIMSHAK_XML = 5;

                Dal.Add(kovetz);
                Dal.SaveChanges();
                Dal.ChangeClientStatus(client.TeudatZehut, (int)ClientStatus.New, (int)ClientStatus.SentEvent, kovetz.Kovetz_Id);
                log.Info("Finished producing event successfully for client - TZ #" + client.TeudatZehut);
                // Get the next Client TZ.
                client = Dal.GetClientByStatus((int)ClientStatus.New);
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
                //ChangeStatus 
                feedbackFile = feedback.ParseFeedback();
                Dal.SaveFeedback(feedbackFile);

                Kovetz kovetz = new Kovetz();
                kovetz.MISPAR_GIRSAT_XML = feedback.Mimshak.KoteretKovetz.MISPARGIRSATXML.ToString().Replace("Item","");
                kovetz.MISPAR_HAKOVETZ = feedback.Mimshak.KoteretKovetz.MISPARHAKOVETZ;
                kovetz.KOD_SVIVAT_AVODA = feedback.Mimshak.KoteretKovetz.KODSVIVATAVODA;
                kovetz.SUG_MIMSHAK = feedback.Mimshak.KoteretKovetz.SUGMIMSHAK;
                kovetz.TAARICH_BITZUA = Common.ConvertDatetime(feedback.Mimshak.KoteretKovetz.TAARICHBITZUA);
                kovetz.MISPAR_GIRSAT_XML = "001";
                kovetz.SHEM_SHOLEACH = "Feedback";
                kovetz.FileName = file;
                kovetz.MEZAHE_HAAVARA = mislakaFileName.GetMislakaFileName();
                kovetz.Yatzran_SHEM_YATZRAN = feedback.Mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMGOREMSHOLECH;
                kovetz.LoadDate = DateTime.Now;
                kovetz.KIVUN_MIMSHAK_XML = 5;
                Dal.Add(kovetz);
                Dal.SaveChanges();

                for (int i = 0; i < feedback.Mimshak.GufHamimshak.Length; i++)
                {
                    Dal.ChangeClientStatusByFileNumber(feedback.Mimshak.GufHamimshak[i].SugMashov.MISPARHAKOVETZ,
                                                        (int)ClientStatus.EndFeedback1);
                }
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                