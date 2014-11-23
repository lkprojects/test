using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Web.Mvc;

namespace WebSite.Models.Business
{
    public class PolisaBL
    {
        private Repository _repository;

        public PolisaBL()
        {
            _repository = new Repository();
        }

        public PolisaBL(Repository repository)
        {
            _repository = repository;
        }

        public List<HeshbonOPolisa> GetPolisas(DAL.Client client)
        {
            
            List<HeshbonOPolisa> polisaList = _repository.GetPolisas(client.TeudatZehut);
            return polisaList;
        }

        public List<DepositsReport_Result> GetDeposits(string id, string AccountNumber, DateTime FromDate, DateTime ToDate)
        {
            DepositsReport_Result depositsReport_Result = new DepositsReport_Result();
            return _repository.DepositsReport(id, AccountNumber, FromDate, ToDate);
           
        }


    }
}
