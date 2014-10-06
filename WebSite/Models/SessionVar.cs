using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite
{
    [Serializable]
    public sealed class SessionVar
    {
        #region Singleton

        private const string SESSION_SINGLETON_NAME = "Singleton_502E69E5-668B-E011-951F-00155DF26207";

        private SessionVar()
        {

        }

        public static SessionVar Current
        {
            get
            {
                if (HttpContext.Current.Session[SESSION_SINGLETON_NAME] == null)
                {
                    HttpContext.Current.Session[SESSION_SINGLETON_NAME] = new SessionVar();
                }

                return HttpContext.Current.Session[SESSION_SINGLETON_NAME] as SessionVar;
            }
        }

        #endregion

        public WebSite.Models.LUT Lut { get; set; }
        public List<DAL.HeshbonOPolisa> AccountData { get; set; }

    }
}