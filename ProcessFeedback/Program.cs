using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Feedback
{
    class Program
    {
        private static DAL.DAL Dal = new DAL.DAL();

        static void Main(string[] args)
        {
            string filename;
            // Read the XML file into "Mimshak" object
            if (args.Length == 0)
            {
                Console.Write("Enter \"Feedback\" XML File name (with path): ");
                filename = Console.ReadLine();
            }
            else
            {
                filename = args[0];
            }
            filename = @"C:\Pensions Project\Files\IncomingFeedbackSample.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Mimshak));
            Stream fs = File.OpenRead(filename);
            
            HandleFeedback feedback = new HandleFeedback(serializer.Deserialize(fs) as Mimshak);
            fs.Close();
            FeedbackFile feedbackFile = feedback.ParseFeedback();

            Dal.SaveFeedback(feedbackFile);
            
        }
    }

}
