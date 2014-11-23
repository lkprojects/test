using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;


namespace WebSite.Models
{
    public class Repository : DAL.DAL
    {
        private Entities dbCtx = new Entities();

        public List<HeshbonOPolisa> GetPolisas(string TeudatZehut)
        {
            dbCtx.Configuration.LazyLoadingEnabled = true;

            List<HeshbonOPolisa> polisas =
                   (from h in dbCtx.HeshbonOPolisas
                    join c in dbCtx.Customers on h.Customer_Id equals c.Customer_Id
                    where c.MISPAR_ZIHUY_LAKOACH == TeudatZehut
                    orderby h.STATUS_POLISA_O_CHESHBON, h.Customer.SUG_MUTZAR_PENSIONI
                    select h).ToList<HeshbonOPolisa>();

            dbCtx.Configuration.LazyLoadingEnabled = true;

            return polisas;
        }

        public HeshbonOPolisa GetPolisa(Client client)
        {
            HeshbonOPolisa p = null;
            p = (from h in dbCtx.HeshbonOPolisas
                 join c in dbCtx.Customers on h.Customer_Id equals c.Customer_Id
                 where c.MISPAR_ZIHUY_LAKOACH == client.TeudatZehut
                 select h).SingleOrDefault();

            return p;
        }


        public List<LUT> GetLUT()
        {
            List<LUT> lut = null;
            lut = (from l in dbCtx.LUTs
                   select l).ToList<LUT>();

            return lut;
        }

        public void AddClient(DAL.Client client)
        {
            dbCtx.Clients.Add(client);
        }

        public List<DepositsReport_Result> DepositsReport(string identificationNumber, string AccountNumber, DateTime FromDate, DateTime ToDate)
        {
            return dbCtx.DepositsReport(identificationNumber, AccountNumber, FromDate, ToDate).ToList();
        }
    }
}