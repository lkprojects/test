using DAL;
using LoadAchzakot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Events
{
    class Program
    {
        private static DAL.DAL DALobj = new DAL.DAL("Events");
        private static Mutzar lakoachRec;
        private static Client clientRec;
        private static int numerator;

        static void Main(string[] args)
        {

            var dbCtx = new PensionsEntities();
            MimshakEruim EventObj = new MimshakEruim();
            string fileName;
            HandleEvents handleEvents;

            string val = DALobj.GetConfigParam("Test");
            numerator = DALobj.GetFileNumerator();

            string misparZihuy = DALobj.StartProcessEvent();
            lakoachRec = new Mutzar();
            clientRec = new Client();

            while (misparZihuy != "")
            {
                //string val = ConfigQuery.SingleOrDefault(p => p.AppName == "Events" && p.ParamName == "Test").ParamValue;
                
                // Read the client data 
                //lakoachRec = dbCtx.Mutzars.SingleOrDefault(p => p.Lakoach_MISPAR_ZIHUY_LAKOACH == misparZihuy);
                clientRec = dbCtx.Clients.SingleOrDefault(p => p.TeudatZehut == misparZihuy);

                handleEvents = new HandleEvents();
                EventObj = handleEvents.PrepareEventObject(clientRec, numerator);

                // Write the events to a file
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(MimshakEruim));
                fileName = "C:\\Pensions Project\\Files\\test" + numerator.ToString("0000") + ".xml";
                System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
                writer.Serialize(file, EventObj);
                file.Close();
                
                // Set the status of the event to "dequeued".
                DALobj.DequeueEvent(misparZihuy);

                //Get the next mispar zihuy from the queue
                misparZihuy = DALobj.StartProcessEvent();
            }

        }

    }
}
