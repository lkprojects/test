using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data.Entity;
namespace DAL
{
    public enum ClientStatus { New = 1, EventSent, EventFeedbackSuccess, EventFeedbackFileError, EventFeedbackRecordError, DataLoaded, NoData};
    
    public class DAL
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Config[] configArray;
        private PensionsEntities dbCtx = new PensionsEntities();
        public Config[] ConfigArray { get { return configArray; } }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DAL()
        {
            log4net.Config.XmlConfigurator.Configure();
            dbCtx = new PensionsEntities();
        }

        /// <summary>
        /// Constructor with configuration parameters loading 
        /// </summary>
        /// <param name="appName"></param>
        public DAL (string appName)
        {
            //IQueryable<Config> ConfigQuery;
            try
            {
                var ConfigQuery = from config in dbCtx.Configs
                                  where config.AppName == appName
                                  select config;
                configArray = ConfigQuery.ToArray<Config>();

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
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException);
            }

        }

        public Client GetClientByStatus(int status)
        {
            Client client = new Client();
            
            client = (from c in dbCtx.Clients
                      where c.Status == status
                      select c).FirstOrDefault();

            return client;
        }

        public Client GetClient(string misparZihuy)
        {
            return dbCtx.Clients.SingleOrDefault(p => p.TeudatZehut == misparZihuy);
        }

        public void ChangeClientStatus(string MisparZihuy, ClientStatus ToStatus)
        {
            Client client = new Client();

            client = (from c in dbCtx.Clients
                      where c.TeudatZehut == MisparZihuy
                      select c).FirstOrDefault();
            client.ModifyDate = DateTime.Now;
            client.Status = (byte)ToStatus;
            dbCtx.Entry(client).State = EntityState.Modified;

        }

        public void DequeueEvent(string misparZihuy)
        {
            dbCtx.DequeueEvent(misparZihuy);
        }
        
        public void SaveChanges ()
        {
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
                    foreach (var ve in eve.ValidationErrors)
                    {
                        rs += "\n" + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                    Console.WriteLine(rs);
                    log.Error(rs);
                }
                // throw new Exception(rs);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string rs = ex.Message;
                rs += "\n" + ex.InnerException.InnerException.ToString();
                Console.WriteLine(rs);
                log.Error(rs);

                // throw new Exception(rs);
            }
        }

        public void DeleteMutzar (int MutzarId)
        {
            try
            {
                dbCtx.DeleteMutzar(MutzarId);
            }
            catch (Exception ex)
            {
                
            }
        }
        
        public void GetDatabaseValues(object entity)
        {
            dbCtx.Entry(entity).GetDatabaseValues();
        }

        public void DeleteKovetz(int KovetzId)
        {
            try
            {
                dbCtx.DeleteMutzar(KovetzId);
            }
            catch (Exception ex)
            {

            }
        }

        public bool CheckIfFileExists(string MisparKovetz)
        {
            int? id = dbCtx.Kovetzs.SingleOrDefault(p => p.MISPAR_HAKOVETZ == MisparKovetz).Kovetz_Id;
            if (id != null)
                return true;
            else
                return false;
        }

        public void ChangeClientStatusByFileNumber (string MisparKovetz, int NewStatus)
        {
            dbCtx.ChangeClientStatusByFileNumber(MisparKovetz, NewStatus);
        }

        public void SaveFeedback(FeedbackFile feedback)
        {
            dbCtx.FeedbackFiles.Add(feedback);
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

        public string GetConfigParam(string paramName)
        {
            try 
            {
                string value;
                value = configArray.SingleOrDefault(p => p.ParamName == paramName).ParamValue;
                return value;
            }
            catch (Exception ex)
            {
                log.Error("Error getting configuration parameter", ex);
                return null;
            }
        }

        public Mutzar GetMutzarByNumber(int sug, string misparZihuy, int KodMezaheYatzran, int? KodMezaheMetafel)
        {
            Mutzar mutzar = new Mutzar();
            dbCtx.Configuration.LazyLoadingEnabled = false;
            
            mutzar = (from k in dbCtx.Mutzars
                      where k.Lakoach_MISPAR_ZIHUY_LAKOACH == misparZihuy &&
                            k.SUG_MUTZAR_PENSIONI == sug &&
                            k.KOD_MEZAHE_YATZRAN == KodMezaheYatzran &&
                            k.KOD_MEZAHE_METAFEL == KodMezaheMetafel
                      select k).FirstOrDefault();

            return mutzar;
        }
        
        public Kovetz GetKovetzByNumber (string key)
        {
            Kovetz kovetz = new Kovetz();

            kovetz = (from k in dbCtx.Kovetzs
                      where k.MISPAR_HAKOVETZ == key
                      select k).FirstOrDefault();
            return kovetz;
        }

        public int GetFileNumerator()
        {
            var outputParameter = new ObjectParameter("numerator", typeof(int));
            dbCtx.GetFileNumerator(outputParameter);
            return (int)outputParameter.Value;

        }

        public void Add(Kovetz kovetz)
        {
            dbCtx.Kovetzs.Add(kovetz);
        }

        public void Add(Mutzar mutzar)
        {
            dbCtx.Mutzars.Add(mutzar);
        }

        public void UpdateClientStatus(Client client, byte status)
        {
            client.Status = status;
            dbCtx.Entry(client).State = EntityState.Modified;
        }

        public void SetClientYatzran(string MisparKovetz, string Yatzran, bool DataExists)
        {
            int? id = dbCtx.ClientYatzrans.SingleOrDefault(p => p. == MisparKovetz).Kovetz_Id;
            if (id != null)

            ClientYatzran clientYatzran = new(clientYatzran);
        }
    }
}
