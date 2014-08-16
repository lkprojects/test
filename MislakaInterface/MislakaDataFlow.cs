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
        private static DAL.DAL Dal = new DAL.DAL("MislakaInterface");
        private FileTypes svivatAvoda;
        private string incomingDir;
        private string outgoingDir;

        private FileTypes Environment = (FileTypes)Enum.Parse(typeof(FileTypes), Dal.GetConfigParam("SVIVAT-AVODA")); // 1= Test, 2=Production

        public void ProcessCycle()
        {
            // Checking if there are files to process ("Achzakot" or "Feedbacks")
            string MisparKovetz;
            incomingDir = Dal.GetConfigParam("MislakaIncomingFolder");
            outgoingDir = Dal.GetConfigParam("MislakaOutgoingFolder");

            log.Info("Start Process Cycle");

            ProduceEvents();

            //Read all incoming files
            foreach (string file in Directory.GetFiles(incomingDir))
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
                            SendFeedback(MisparKovetz, file, 20 /*Feedback type*/, true);
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

            achzakotParser.ParseKovetz(mimshak, filename);

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
        private void SendFeedback(string MisparHakovetz,
                                  string FileName, 
                                  int    SugMimshak,
                                  bool   isSuccess)
        {
            log.Info("Start Send Success Feedback");
            HandleFeedback handleFeedback = new HandleFeedback();

            handleFeedback.ProduceFeedback(svivatAvoda, MisparHakovetz, FileName, isSuccess);
            
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Feedback.Mimshak));
            string fileName = outgoingDir + "\\" + handleFeedback.MislakaFilename.GetMislakaFileName();
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
            writer.Serialize(file, handleFeedback.Mimshak);
            file.Close();
            handleFeedback.CreateFeedbackKovetzRecord(fileName, MisparHakovetz);

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

            // Get a list of clients for which to produce an events file.
            List<Client> clientList = Dal.GetClientsByStatus((int)ClientStatus.New);
            if (clientList.Count > 0)
            {
                mislakaFileName = new MislakaFileName("001" /*Mefitz to mislaka*/, Dal.GetConfigParam("MISPAR-MEZAHE-PONE"), ServiceTypes.EVENTS,
                                                      ProductTypes.NotRelevant, Version, DateTime.Now, numerator, svivatAvoda);

                // Read the client data 
                handleEvents = new HandleEvents(numerator);
                handleEvents.PrepareEventObject(clientList);
                fileName = outgoingDir + "\\" + mislakaFileName.GetMislakaFileName();
                handleEvents.SerializeToFile(fileName);

                handleEvents.SaveKovetzRecord(fileName, mislakaFileName);
                Dal.Add(handleEvents.FileRecord);
                Dal.UpdateClients(handleEvents.ClientList);
                Dal.SaveChanges();


                //Dal.ChangeClientStatus(client.TeudatZehut, (int)ClientStatus.New, (int)ClientStatus.SentEvent, kovetz.Kovetz_Id);
                // Get the next Client TZ.
            }
            log.Info("Finished producing events");

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
            HandleFeedback feedback = new HandleFeedback();
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
            //FeedbackFile feedbackFile = new FeedbackFile();
            //MislakaFileName mislakaFileName;
            try
            {
                // feedbackFile = feedback.ParseFeedback();

                feedback.CreateFeedbackKovetzRecord(file, feedback.Mimshak.KoteretKovetz.MISPARHAKOVETZ);
                // Check if there is NO DATA from the Yatzran.
                //Dal.SaveChanges();
                //Dal.SaveFeedback(feedbackFile);
                AnalyzeFeedback(file, feedback.Mimshak);

                log.Info("Finished processing feedback file " + file);
            }
           
            catch (Exception e)
            {
                log.Error("Error Found", e);
                return;
            }

        }

        private void AnalyzeFeedback(string file, Feedback.Mimshak feedback)
        {
            for (int i = 0; i < feedback.GufHamimshak.Length; i++)
            {
                // Check for error on file level
                if (feedback.GufHamimshak[i].SugMashov.RAMATMASHOV == 1 &&
                    feedback.GufHamimshak[i].SugMashov.MashovBeramatKovetz.KODSHGIHA != null)
                {
                    Dal.ChangeClientStatusByFileNumber(feedback.GufHamimshak[i].SugMashov.MISPARHAKOVETZ,
                                                       ClientStatus.EventFeedbackFileError);

                    SendFeedback(feedback.KoteretKovetz.MISPARHAKOVETZ, Common.RemovePath(file), feedback.KoteretKovetz.SUGMIMSHAK, false);
                }
                else if (feedback.GufHamimshak[i].SugMashov.RAMATMASHOV == 2) // Mashov on Records
                {
                     AnalyzeFeedbackRecords(file, 
                                            feedback.KoteretKovetz.NetuneiGoremSholech.MISPARZIHUISHOLECH, 
                                            feedback.GufHamimshak[i].SugMashov.MISPARHAKOVETZ, feedback.GufHamimshak[i]);
                }
            }
        }

        private void AnalyzeFeedbackRecords(string file, string misparHakovetz, string misparZihuySholeach, Feedback.MimshakYeshutGoremPoneLemislaka mimshakRec)
        {
            string MisparZehut = "";
            // Iterate over each record (client)
            for (int j = 0; j < mimshakRec.SugMashov.MashovBeramatReshuma.Length; j++)
            {
                // The 16 character from offset 27 holds the client TZ.
                MisparZehut = mimshakRec.SugMashov.MashovBeramatReshuma[j].MISPARMEZAHERESHUMA.Substring(27, 16);
                // Check if received feedback from Mislaka "Mashov A"
                if (mimshakRec.SugMashov.SUGMASHOV == 1)
                {
                    // Check the record is not valid
                    if (mimshakRec.SugMashov.MashovBeramatReshuma[j].STATUSRESHUMA !=
                              Feedback.MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaSTATUSRESHUMA.Item1) // Status 1 = OK 
                    {
                        // Error in record from the Mislaka 
                        Dal.ChangeClientStatus(MisparZehut, ClientStatus.EventFeedbackRecordError);
                        // Need to ask if the feedback from mefitz to the error on record should be like "success".
                        SendFeedback(misparHakovetz, file, 20, true);
                    }
                    else // Success from Mislaka
                    {
                        Dal.ChangeClientStatus(MisparZehut, ClientStatus.EventFeedbackSuccess);
                        // Need to ask if the feedback from mefitz to the error on record should be like "success".
                        SendFeedback(misparHakovetz, file, 20, true);
                        Dal.SetClientYatzran(MisparZehut, misparZihuySholeach, true);
                    }
                }
                else // Received Mashov B - from Yatzran - there must be an error from the Yatzran
                {
                    // Check the record is not valid
                    if (mimshakRec.SugMashov.MashovBeramatReshuma[j].MaaneMiYazran[0].MAANEBERAMATRESHUMA != null)
                    {
                        // Error in record from the Yatzran (can't supply client data for some reason)
                        Dal.ChangeClientStatus(MisparZehut, ClientStatus.NoData);
                        // Need to ask if the feedback from Yatzran to the error on record should be like "success".
                        SendFeedback(misparHakovetz, file, 20, true);
                        Dal.SetClientYatzran(MisparZehut, misparZihuySholeach, false);
                    }
                }
            }
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                