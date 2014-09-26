﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebSite.Models
{
    public class Repository : DAL.DAL
    {
        private Entities dbCtx = new Entities();
        
        public List<HeshbonOPolisa> GetPolisas(string TeudatZehut)
        {
            List<HeshbonOPolisa> polisas = 
                   ( from h in dbCtx.HeshbonOPolisas
                    where h.MISPAR_ZIHUY_LAKOACH == TeudatZehut
                     select h).ToList<HeshbonOPolisa>();

            return polisas;
        }
        
        public HeshbonOPolisa GetPolisa(Client client)
        {
            HeshbonOPolisa p = null;
            p = (from h in dbCtx.HeshbonOPolisas
                 where h.MISPAR_ZIHUY_LAKOACH == client.TeudatZehut
                 select h).SingleOrDefault();

            return p;
        }

    
    }
}
