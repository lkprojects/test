using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using WebSite.Models.Business;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;

namespace WebSite.Controllers
{
    public class DepositsController : Controller
    {
        private PolisaBL polisaBL = new PolisaBL();

        // GET: HafkadotMetchilatShanas
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDeposits(string FromDate, string ToDate)
        {

            string AccountNumber = (string)RouteData.Values["id"];
            if (AccountNumber == null || AccountNumber == "")
                AccountNumber = "0";

            DateTime FromDateConv = DateTime.ParseExact("19000101", "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime ToDateConv = DateTime.Now;

            if (FromDate != null && FromDate != "")
                FromDateConv = DateTime.ParseExact(FromDate, "yyyy/MM", CultureInfo.InvariantCulture); 
            if (ToDate != null && ToDate != "")
                ToDateConv = DateTime.ParseExact(ToDate, "yyyy/MM", CultureInfo.InvariantCulture); 

            string id = "24416422";

            List<DepositsReport_Result> deposits;
            DepositsReport_Result depositsReport_Result = new DepositsReport_Result();

            deposits = polisaBL.GetDeposits(id, AccountNumber, FromDateConv, ToDateConv);

            var dbResult = deposits.ToList();
            var dep = (from deposit in dbResult
                             select new
                             {
                                 deposit.DepositMonth,
                                 deposit.EmployeeDisabilityInsurance,
                                 deposit.EmployeeEducationFund,
                                 deposit.EmployeeMisc,
                                 deposit.EmployeeRemuneration,
                                 deposit.EmployeeTotal,
                                 deposit.EmployerCompensations,
                                 deposit.EmployerDisabilityInsurance,
                                 deposit.EmployerEducationFund,
                                 deposit.EmployerMisc,
                                 deposit.EmployerRemuneration,
                                 deposit.EmployerTotal,
                                 deposit.Total
                             });
            return (Json(dep, JsonRequestBehavior.AllowGet));
        }

        //public JsonResult GetDepositDates(string FromDate, string ToDate)
        //{
        //}
        
    }
}
