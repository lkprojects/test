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

    public static class MislakaDataFlow
    {
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static MislakaFileName mislakaFileName;
        private static DAL.DAL Dal = new DAL.DAL("MislakaInterface");
        
        private static string incomingDir;
        private static string outgoingDir;
        private static string incomingDirHistory;
        private static string outgoingDirHistory;


        private static FileTypes Environment = (FileTypes)Enum.Parse(typeof(FileTypes), Dal.GetConfigParam("Environment")); // 1= Test, 2=Production

        public static void ProcessCycle()
        {

            // Checking if there are files to process ("Achzakot" or "Feedbacks")
            string MisparKovetz;
            incomingDir = Dal.GetConfigParam("MislakaIncomingFolder");
            outgoingDir = Dal.GetConfigParam("MislakaOutgoingFolder");
            incomingDirHistory = Dal.GetConfigParam("MislakaIncomingFolderHistory");
            outgoingDirHistory = Dal.GetConfigParam("MislakaOutgoingFolderHistory");

            log.Info("Start Process Cycle");

            ProduceEvents();

            //Read all incoming files
            foreach (string file in Directory.GetFiles(incomingDir))
            {
                string filename = file.Substring(file.LastIndexOf('\\') + 1);
                mislakaFileName = new MislakaFileName(filename);
                // Check that the file type matches the environment (test or production). If not - ignore the file.
                if (mislakaFileName.FileType == Environment)
                { 
                    // Check for "pre consulting" or holdings data.
                    if (mislakaFileName.Service == ServiceTypes.HOLDNG || mislakaFileName.Service == ServiceTypes.CONSLT)
                    {
                        // If it is "Achzakot" = Load Achzakot.
                        log.Info("Loading Achzakot file " + filename);
                        MisparKovetz = LoadAchzakot(file);

                        SendFeedback(MisparKovetz, file, true);
                    }
                    //If it is a feedback - process feedback
                    if (mislakaFileName.Service == ServiceTypes.FEDBKA || mislakaFileName.Service == ServiceTypes.FEDBKB)
                    {
                        LoadFeedback(file);
                    }
                }
            }
            log.Info("End Process Cycle");
        }

        /// <summary>
        /// Loads Achzakot file information and parses in into a "kovetz" object
        /// </summary>
        /// <param name="filename">XML file containing achzakot</param>
        /// <returns>MIPAR-KOVETZ node from the achzakot XML file</returns>
        private static string LoadAchzakot(string filename)
        {
            log.Info("Start Load Achzakot file " + filename);
            AchzakotInterface.Mimshak mimshak = new AchzakotInterface.Mimshak();
            Achzakot achzakotParser = new Achzakot();
            XmlSerializer serializer = new XmlSerializer(typeof(AchzakotInterface.Mimshak));
            Stream fs = File.OpenRead(filename);
            try
            {
                mimshak = serializer.Deserialize(fs) as AchzakotInterface.Mimshak;
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
            catch
            {
                log.Info("Load Achzakot failed for filename: " + filename);
                return null;
            }
            
        }
        /// <summary>
        /// Sends a success feedback file for a received file.
        /// </summary>
        private static void SendFeedback (string MisparHakovetz,
                                          string FileName, 
                                          bool   isSuccess)
        {
            log.Info("Start Send Success Feedback");
            Feedback handleFeedback = new Feedback();

            handleFeedback.ProduceFeedback(Environment, MisparHakovetz, FileName, isSuccess);

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(FeedbackInterface.Mimshak));
            string fileName = outgoingDir + "\\" + handleFeedback.MislakaFilename.GetMislakaFileName();
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
            writer.Serialize(file, handleFeedback.Mimshak);
            file.Close();
            handleFeedback.CreateFeedbackKovetzRecord(MisparHakovetz);

            log.Info("End Send Success Feedback - file:" + mislakaFileName.GetMislakaFileName());
        }

        /// <summary>
        /// Produce "9100" event which 
        /// </summary>
        public static void ProduceEvents()
        {
            log.Info("Start producing events");

            string fileName;
            Event handleEvents;
            MislakaFileName mislakaFileName;
            MislakaFileName YipuyKoachFileName;
            EventsInterface.Mimshak EventObj = new EventsInterface.Mimshak();


            int numerator = Dal.GetFileNumerator();
            Mutzar lakoachRec = new Mutzar();
            string Version = EventsInterface.MimshakKoteretKovetzMISPARGIRSATXML.Item001.ToString().Replace("Item","");

            WordTemplate template = new WordTemplate();

            // Get a list of clients for which to produce an events file.
            List<Client> clientList = Dal.GetClientsByStatus((int)ClientStatus.New);
            if (clientList.Count > 0)
            {
                mislakaFileName = new MislakaFileName("001" /*Mefitz to mislaka*/, Dal.GetConfigParam("MISPAR-MEZAHE-PONE"), ServiceTypes.EVENTS,
                                                      ProductTypes.NotRelevant, Version, DateTime.Now, numerator, Environment);
                // Read the client data 
                handleEvents = new Event(numerator, Environment);
                handleEvents.PrepareEventObject(clientList);
                fileName = outgoingDir + "\\" + mislakaFileName.GetMislakaFileName();
                handleEvents.SerializeToFile(fileName);

                int attNumerator = 1;
                foreach (Client client in clientList )
                {
                    YipuyKoachFileName = new MislakaFileName("001" /*Mefitz to mislaka*/, Dal.GetConfigParam("MISPAR-MEZAHE-PONE"), ServiceTypes.EVENTS,
                                                             ProductTypes.NotRelevant, Version, DateTime.Now, numerator, attNumerator, FileTypes.PDF);
                    fileName = outgoingDir + "\\" + YipuyKoachFileName.GetMislakaFileName();
                    template.FillAndSave(client.FirstName + " " + client.LastName, client.TeudatZehut, 
                                         client.AddressStreetName + " " + client.AddressStreetNumber + " " + client.AddressCity,
                                         Dal.GetConfigParam("YipuiKoachTemplateFile"),
                                         fileName);
                    attNumerator++;
                }

                handleEvents.SaveKovetzRecord(fileName, mislakaFileName);
                handleEvents.UpdateClientsRecords();
                log.Info("Finished producing " + clientList.Count.ToString() + " events in file " + fileName);
            }
            else
                log.Info("No events to process");
        }


        private static void LoadFeedback(string file)
        {
            // Read the XML file into "Mimshak" object
            log.Info("Start processing feedback file " + file);
            XmlSerializer serializer = new XmlSerializer(typeof(FeedbackInterface.Mimshak));
            Stream fs = File.OpenRead(file);
            Feedback feedback = new Feedback();
            try
            {
                feedback = new Feedback(serializer.Deserialize(fs) as FeedbackInterface.Mimshak);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                log.Error("Error found in desirializing Feedback", ex);
                fs.Close();
                return;
            }
            fs.Close();

            //Analyze the feedback object
            try
            {
                feedback.CreateFeedbackKovetzRecord(Common.RemovePath(file));
                AnalyzeFeedback(file, feedback.Mimshak);
                Dal.SaveChanges();
                log.Info("Finished processing feedback file " + file);
            }
           
            catch (Exception e)
            {
                log.Error("Error Found", e);
                return;
            }

        }

        private static void AnalyzeFeedback(string file, FeedbackInterface.Mimshak feedback)
        {
            for (int i = 0; i < feedback.GufHamimshak.Length; i++)
            {
                // Check for error on file level
                if (feedback.GufHamimshak[i].SugMashov.RAMATMASHOV == 1 && /*Ramat Mashov 1 = "file level"*/
                    feedback.GufHamimshak[i].SugMashov.MashovBeramatKovetz != null &&
                    feedback.GufHamimshak[i].SugMashov.MashovBeramatKovetz.KODSHGIHA > 0)
                {
                    Dal.ChangeClientStatusByFileNumber(feedback.GufHamimshak[i].SugMashov.MISPARHAKOVETZ,
                                                       ClientStatus.EventFeedbackFileError);

                    SendFeedback(feedback.KoteretKovetz.MISPARHAKOVETZ, Common.RemovePath(file), false);
                    break;
                }
                else if (feedback.GufHamimshak[i].SugMashov.RAMATMASHOV == 2) // Mashov on Records
                {
                     AnalyzeFeedbackRecords(file, 
                                            feedback.GufHamimshak[i].SugMashov.MISPARHAKOVETZ, 
                                            feedback.KoteretKovetz.NetuneiGoremSholech.MISPARZIHUISHOLECH, 
                                            feedback.GufHamimshak[i]);
                }
            }
        }

        private static void AnalyzeFeedbackRecords(string file, string misparHakovetz, string misparZihuySholeach, FeedbackInterface.MimshakYeshutGoremPoneLemislaka mimshakRec)
        {
            string MisparZehut = "";
            bool errorsFound = false;
            misparZihuySholeach = misparZihuySholeach.TrimStart('0');
            misparHakovetz = misparHakovetz.TrimStart('0');

            // Iterate over each record (client)
            for (int j = 0; j < mimshakRec.SugMashov.MashovBeramatReshuma.Length; j++)
            {
                // The 16 character from offset 27 holds the client TZ.
                MisparZehut = mimshakRec.SugMashov.MashovBeramatReshuma[j].MISPARMEZAHERESHUMA.Substring(26, 16).TrimStart('0');
                log.Info("Reading feedback of Client Id " + MisparZehut);
                // Check if received feedback from Mislaka "Mashov A"
                if (mimshakRec.SugMashov.SUGMASHOV == 1)
                {
                    // Check the record is not valid
                    if (mimshakRec.SugMashov.MashovBeramatReshuma[j].STATUSRESHUMA !=
                              FeedbackInterface.MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaSTATUSRESHUMA.Item1) // Status 1 = OK 
                    {
                        // Error in record from the Mislaka 
                        log.Error("Error from the clearing house with client ID " + MisparZehut + " - error status =" + mimshakRec.SugMashov.MashovBeramatReshuma[j].STATUSRESHUMA);
                        if (Dal.ChangeClientStatus(MisparZehut, ClientStatus.EventFeedbackRecordError))
                            if (!errorsFound)
                            {
                                SendFeedback(misparHakovetz, file, true);
                                errorsFound = true;
                            }
                    }
                    else // Success from Mislaka
                    {
                        log.Debug("Success status from the clearing house with client ID " + MisparZehut);
                        Dal.ChangeClientStatus(MisparZehut, ClientStatus.EventFeedbackSuccess);
                        // Need to ask if the feedback from mefitz to the error on record should be like "success".
                        //SendFeedback(misparHakovetz, file, true);
                    }
                }
                else // Received Mashov B - from Yatzran - there must be an error from the Yatzran
                {
                    // Check the record is not valid
                    if (mimshakRec.SugMashov.MashovBeramatReshuma[j].MaaneMiYazran[0] != null &&
                        mimshakRec.SugMashov.MashovBeramatReshuma[j].MaaneMiYazran[0].MAANEBERAMATRESHUMA > 1000)
                    {
                        log.Debug("Received an error from Yatzran. client ID " + MisparZehut + ". Record error=" + 
                                   mimshakRec.SugMashov.MashovBeramatReshuma[j].MaaneMiYazran[0].MAANEBERAMATRESHUMA);
                        // Error in record from the Yatzran (can't supply client data for some reason)
                        Dal.ChangeClientStatus(MisparZehut, ClientStatus.NoData);
                        // Need to ask if the feedback from Yatzran to the error on record should be like "success".
                        SendFeedback(misparHakovetz, file, true);
                        Dal.SetClientYatzran(misparZihuySholeach, MisparZehut, false);
                    }
                }
            }
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                