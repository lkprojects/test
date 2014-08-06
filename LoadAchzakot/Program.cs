using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LoadAchzakot
{
    class Program
    {
        protected static Mimshak mimshak = new Mimshak();
        static void Main(string[] args)
        {
            string filename;
            // Read the XML file into "Mimshak" object
            if (args.Length == 0)
            {
                Console.Write("Enter \"Achzakot\" XML File name (with path): ");
                filename = Console.ReadLine();
            }
            else
            {
                filename = args[0];
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Mimshak));
            Stream fs = File.OpenRead(filename);
            try
            {
                mimshak = serializer.Deserialize(fs) as Mimshak;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            fs.Close();

            var dbCtx = new PensionsEntities();
            AchzakotParser.mimshak = mimshak;

            AchzakotParser.ParseKovetz(dbCtx);
            for (int i = 0; i < mimshak.Mutzarim.Length; i++)
            {
                AchzakotParser.ParseMutzar(dbCtx, i);
            }
            try
            {
                dbCtx.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                string rs = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    rs = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    Console.WriteLine(rs);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        rs += "<br />" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                    Console.WriteLine(rs);
                }
                // throw new Exception(rs);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string rs = ex.Message;
                rs += "\n" + ex.InnerException.InnerException.ToString();
                Console.WriteLine(rs);

                // throw new Exception(rs);

            }
        }

    }
}

