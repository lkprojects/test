﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

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

        public List<HeshbonOPolisa> GetPolisas(Client client)
        {
            
            List<HeshbonOPolisa> polisaList = _repository.GetPolisas(client.TeudatZehut);
            return polisaList;
        }
    }
}