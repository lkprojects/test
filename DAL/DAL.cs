﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public enum ClientStatus { New = 1, EventSent, EventFeedbackSuccess, EventFeedbackFileError, EventFeedbackRecordError, DataLoaded, NoData};
    
    public class DAL
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Config[] configArray;
        private Entities dbCtx = new Entities();
        public Config[] ConfigArray { get { return configArray; } }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DAL()
        {
            log4net.Config.XmlConfigurator.Configure();
            dbCtx = new Entities();
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


        public void SaveYatzran (Yatzran yatzran)
        {
            Yatzran yatzran_check = new Yatzran();
            yatzran_check = 
                    (from ya in dbCtx.Yatzrans
                     where ya.KOD_MEZAHE_YATZRAN == yatzran.KOD_MEZAHE_YATZRAN
                     select ya).FirstOrDefault();
            if (yatzran_check == null)
            {
                dbCtx.Yatzrans.Add(yatzran);
            }
            
        }

        public bool CheckMetafel (int? KodMezaheMetafel)
        {
            if (KodMezaheMetafel == null)
                return false;

            int kod =
                (from m in dbCtx.Metafels
                 where m.KOD_MEZAHE_METAFEL == KodMezaheMetafel
                 select m.KOD_MEZAHE_METAFEL).FirstOrDefault();

            if (kod > 0)
                return true;
            else
                return false;
        }

        public void SaveIshKesherYatzran(IshKesherYatzran ishKesherYatzran)
        {
            IshKesherYatzran ishKesherYatzran_check =
                    (from ya in dbCtx.IshKesherYatzrans
                     where ya.SHEM_PRATI == ishKesherYatzran.SHEM_PRATI &&
                           ya.SHEM_MISHPACHA == ishKesherYatzran.SHEM_MISHPACHA
                     select ya).FirstOrDefault();

            if (ishKesherYatzran_check != null)
            {
                dbCtx.IshKesherYatzrans.Remove(ishKesherYatzran_check);
            }

            dbCtx.IshKesherYatzrans.Add(ishKesherYatzran);
        }


        public List<Client> GetClientsByStatus(int status)
        {
            List<Client> clients = (from c in dbCtx.Clients
                                    where c.LastStatus == status
                                    select c).ToList<Client>();

            return clients;
        }

        public Client GetClient(string misparZihuy)
        {
            misparZihuy = misparZihuy.TrimStart('0');
            Client client = (from c in dbCtx.Clients
                             where c.TeudatZehut.Contains(misparZihuy)
                             select c).FirstOrDefault();
            return client;
        }

        public bool ChangeClientStatus(string MisparZihuy, ClientStatus ToStatus)
        {
            Client client = new Client();
            MisparZihuy = MisparZihuy.Trim('0');
            client = (from c in dbCtx.Clients
                      where c.TeudatZehut == MisparZihuy
                      select c).FirstOrDefault();
            if (client != null)
            {
                client.ModifyDate = DateTime.Now;
                client.LastStatus = (byte)ToStatus;
                dbCtx.Entry(client).State = EntityState.Modified;
                dbCtx.Entry(client).Reload();
                return true;
            }
            else
            {
                log.Error("Can't find a client with identification ID: " + MisparZihuy);
                return false;
            }
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
            catch (OptimisticConcurrencyException oex)
            {
 //               dbCtx.Entry(heshbonOPolisa).Reload();
//                dbCtx.SaveChanges();
                ObjectStateEntry entry = oex.StateEntries[0];

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
            catch (DbUpdateException ex)
            {
                string rs = ex.Message;
                if (ex.InnerException.InnerException != null)
                    rs += "\n" + ex.InnerException.InnerException.ToString();
                Console.WriteLine(rs);
                log.Error(rs);

                // throw new Exception(rs);
            }
        }

        //public void DeleteMutzar (int MutzarId)
        //{
        //    try
        //    {
        //        dbCtx.DeleteMutzar(MutzarId);
        //    }
        //    catch (Exception ex)
        //    {
                
        //    }
        //}
        
        public void GetDatabaseValues(object entity)
        {
            dbCtx.Entry(entity).GetDatabaseValues();
        }

        //public void DeleteKovetz(int KovetzId)
        //{
        //    try
        //    {
        //        dbCtx.DeleteMutzar(KovetzId);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public bool CheckIfFileExists(string MisparKovetz)
        {
            int? id = dbCtx.Kovetzs.SingleOrDefault(p => p.MISPAR_HAKOVETZ == MisparKovetz).Kovetz_Id;
            if (id != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Changes the status of all the clients that are referenced in the file with the given file identifier.
        /// </summary>
        /// <param name="FileIdentifier">The number that uniquely identifies the file (Mispar Kovetz)</param>
        /// <param name="NewStatus">The new status for the clients referenced in the file.</param>
        public void ChangeClientStatusByFileNumber (string FileIdentifier, ClientStatus NewStatus)
        {
            dbCtx.ChangeClientStatusByFileNumber(FileIdentifier, (int)NewStatus);
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

        //public Mutzar GetMutzarByNumber(int sug, string misparZihuy, int KodMezaheYatzran, int? KodMezaheMetafel)
        //{
        //    Mutzar mutzar = new Mutzar();
        //    dbCtx.Configuration.LazyLoadingEnabled = false;
            
        //    mutzar = (from k in dbCtx.Mutzars
        //              where k.Lakoach_MISPAR_ZIHUY_LAKOACH == misparZihuy &&
        //                    k.SUG_MUTZAR_PENSIONI == sug &&
        //                    k.KOD_MEZAHE_YATZRAN == KodMezaheYatzran &&
        //                    k.KOD_MEZAHE_METAFEL == KodMezaheMetafel
        //              select k).FirstOrDefault();

        //    return mutzar;
        //}
        
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

        //public void Add(Mutzar mutzar)
        //{
        //    dbCtx.Mutzars.Add(mutzar);
        //}

        public void UpdateClients(List<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                dbCtx.Entry(clients[i]).State = EntityState.Modified;
                dbCtx.Entry(clients[i]).Reload();
            }
        }
        public void UpdateClient(Client client)
        {
            dbCtx.Entry(client).State = EntityState.Modified;
            //dbCtx.Entry(client).Reload();

        }


        public void SetClientYatzran(string kodYatzran, string MisparZihuy, bool? hasData)
        {
            MisparZihuy = MisparZihuy.TrimStart('0');

            // Check if the Client-Yatzran correlation already exists
            ClientYatzran clientYatzran =  
                (from cy in dbCtx.ClientYatzrans
                 join c in dbCtx.Clients on cy.Client_Id equals c.Client_Id
                 where c.TeudatZehut.Contains(MisparZihuy) && cy.KodYatzran == kodYatzran
                 select cy).FirstOrDefault();
            
            // If record does not exist - add a new client-Yatran correlation
            if (clientYatzran == null)
            {
                // Get the client id that matches the "Teudat Zehut"
                int clientId =
                    (from c in dbCtx.Clients
                     where c.TeudatZehut.Contains(MisparZihuy)
                     select c.Client_Id).FirstOrDefault();
                if (clientId > 0)
                {
                    clientYatzran = new ClientYatzran();
                    clientYatzran.KodYatzran = kodYatzran;
                    clientYatzran.Client_Id = clientId;
                    clientYatzran.HasData = hasData;
                    dbCtx.ClientYatzrans.Add(clientYatzran);
                }
            }
            // If record does exists - change the "hasData" indicator if necessary
            else if (clientYatzran.HasData != hasData)
            {
                clientYatzran.HasData = hasData;
                dbCtx.Entry(clientYatzran).State = EntityState.Modified;
                dbCtx.Entry(clientYatzran).Reload();
            }
        }


        public void SaveIshKesherMetafel(IshKesherMetafel ishKesherMetafel)
        {
            IshKesherMetafel IshKesherMetafel_check =
                    (from m in dbCtx.IshKesherMetafels
                     where m.SHEM_PRATI == ishKesherMetafel.SHEM_PRATI &&
                           m.SHEM_MISHPACHA == ishKesherMetafel.SHEM_MISHPACHA
                     select m).FirstOrDefault();

            if (IshKesherMetafel_check != null)
            {
                dbCtx.IshKesherMetafels.Remove(IshKesherMetafel_check);
            }

            dbCtx.IshKesherMetafels.Add(ishKesherMetafel);
        }

        public void SaveMetafel(Metafel metafel)
        {
            Metafel metafel_check = new Metafel();
            metafel_check =
                    (from m in dbCtx.Metafels
                     where m.KOD_MEZAHE_METAFEL == metafel.KOD_MEZAHE_METAFEL
                     select m).FirstOrDefault();
            if (metafel_check == null)
            {
                dbCtx.Metafels.Add(metafel);
            }
        }

        public void SaveCustomer(ref Customer customer)
        {
            int SugMezaheLakoach = customer.SUG_MEZAHE_LAKOACH;
            string MisparZihuyLakoach = customer.MISPAR_ZIHUY_LAKOACH;
            int? sugMutzarPensioni = customer.SUG_MUTZAR_PENSIONI;
            int? kodMezaheYatzran = customer.KOD_MEZAHE_YATZRAN;
            int? kodMezaheMetafel = customer.KOD_MEZAHE_METAFEL;

            Customer Customer_check =
                (from c in dbCtx.Customers
                 where    c.SUG_MEZAHE_LAKOACH == SugMezaheLakoach 
                       && c.MISPAR_ZIHUY_LAKOACH == MisparZihuyLakoach
//                     && c.SUG_MUTZAR_PENSIONI == sugMutzarPensioni 
                       && c.KOD_MEZAHE_YATZRAN == kodMezaheYatzran
//                     && c.KOD_MEZAHE_METAFEL == kodMezaheMetafel
                 select c).FirstOrDefault();

            if (Customer_check == null)
            {
                dbCtx.Customers.Add(customer);
                dbCtx.SaveChanges();
                dbCtx.Entry(customer).GetDatabaseValues();

            }
            else
            {
                customer.Customer_Id = Customer_check.Customer_Id;

                Customer_check.SHEM_PRATI = customer.SHEM_PRATI;
                Customer_check.SHEM_MISHPACHA_KODEM = customer.SHEM_MISHPACHA_KODEM;
                Customer_check.SHEM_MISHPACHA =  customer.SHEM_MISHPACHA;
                Customer_check.MIN = customer.MIN;
                Customer_check.TAARICH_LEYDA = customer.TAARICH_LEYDA;
                Customer_check.PTIRA = customer.PTIRA;
                Customer_check.TAARICH_PTIRA = customer.TAARICH_PTIRA;
                Customer_check.MATZAV_MISHPACHTI = customer.MATZAV_MISHPACHTI;
                Customer_check.ERETZ = customer.ERETZ;
                Customer_check.SHEM_YISHUV = customer.SHEM_YISHUV;
                Customer_check.SEMEL_YESHUV = customer.SEMEL_YESHUV;
                Customer_check.SHEM_RECHOV = customer.SHEM_RECHOV;
                Customer_check.MISPAR_BAIT = customer.MISPAR_BAIT;
                Customer_check.MISPAR_KNISA = customer.MISPAR_KNISA;
                Customer_check.MISPAR_DIRA = customer.MISPAR_DIRA;
                Customer_check.MIKUD = customer.MIKUD;
                Customer_check.TA_DOAR = customer.TA_DOAR;
                Customer_check.MISPAR_TELEPHONE_KAVI = customer.MISPAR_TELEPHONE_KAVI;
                Customer_check.MISPAR_SHLUCHA = customer.MISPAR_SHLUCHA;
                Customer_check.MISPAR_CELLULARI = customer.MISPAR_CELLULARI;
                Customer_check.MISPAR_FAX = customer.MISPAR_FAX;
                Customer_check.E_MAIL = customer.E_MAIL;
                Customer_check.HEAROT = customer.HEAROT;
                Customer_check.MISPAR_YELADIM = customer.MISPAR_YELADIM;

                dbCtx.Entry(Customer_check).State = EntityState.Modified;
            }
        }

        public int SaveMaasik(Maasik maasik)
        {
            Maasik maasik_check =
                    (from m in dbCtx.Maasiks
                     where m.MISPAR_MEZAHE_MAASIK == maasik.MISPAR_MEZAHE_MAASIK &&
                           m.SUG_MEZAHE_MAASIK == maasik.SUG_MEZAHE_MAASIK
                     select m).FirstOrDefault();
            if (maasik_check != null)
            {
                maasik_check.MPR_MAASIK_BE_YATZRAN = maasik.MPR_MAASIK_BE_YATZRAN;
                maasik_check.MISPAR_TIK_NIKUIIM = maasik.MISPAR_TIK_NIKUIIM;
                maasik_check.SHEM_MAASIK = maasik.SHEM_MAASIK;
                maasik_check.ERETZ = maasik.ERETZ;
                maasik_check.SHEM_YISHUV = maasik.SHEM_YISHUV;
                maasik_check.SEMEL_YESHUV = maasik.SEMEL_YESHUV;
                maasik_check.SHEM_RECHOV = maasik.SHEM_RECHOV;
                maasik_check.MISPAR_BAIT = maasik.MISPAR_BAIT;
                maasik_check.MISPAR_KNISA = maasik.MISPAR_KNISA;
                maasik_check.MISPAR_DIRA = maasik.MISPAR_DIRA;
                maasik_check.MIKUD = maasik.MIKUD;
                maasik_check.TA_DOAR = maasik.TA_DOAR;
                maasik_check.MISPAR_TELEPHONE_KAVI = maasik.MISPAR_TELEPHONE_KAVI;
                maasik_check.MISPAR_SHLUCHA = maasik.MISPAR_SHLUCHA;
                maasik_check.MISPAR_CELLULARI = maasik.MISPAR_CELLULARI;
                maasik_check.MISPAR_FAX = maasik.MISPAR_FAX;
                maasik_check.E_MAIL = maasik.E_MAIL;
                maasik_check.HEAROT = maasik.HEAROT;

                dbCtx.Entry(maasik_check).State = EntityState.Modified;
                return maasik_check.Maasik_Id;
            }
            else
            {
                dbCtx.Maasiks.Add(maasik);
                dbCtx.SaveChanges();
                dbCtx.Entry(maasik).GetDatabaseValues();
                return maasik.Maasik_Id;
            }
            
        }

        public void SaveHeshbonOPolisa(HeshbonOPolisa heshbonOPolisa)
        {
            int heshbonOPolisa_Id;
            heshbonOPolisa_Id =
                    (from m in dbCtx.HeshbonOPolisas
                     where m.MISPAR_POLISA_O_HESHBON == heshbonOPolisa.MISPAR_POLISA_O_HESHBON &&
                           m.TAARICH_HITZTARFUT_MUTZAR == heshbonOPolisa.TAARICH_HITZTARFUT_MUTZAR
                     select m.HeshbonOPolisa_Id).FirstOrDefault();

            if (heshbonOPolisa_Id > 0)
                   dbCtx.DeleteHeshbonOPolisa(heshbonOPolisa_Id);            
        }

        public void Add(Customer customer)
        {
            dbCtx.Customers.Add(customer);
        }

        protected void Dispose()
        {
            dbCtx.Dispose();
        }

    }
}
