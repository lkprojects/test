using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Models.Business
{
    public class ClientBL
    {
        private Repository _repository;

        public ClientBL()
        {
            _repository = new Repository();
        }

        public ClientBL(Repository repository)
        {
            _repository = repository;
        }

        public void AddClient(DAL.Client client)
        {
            _repository.AddClient(client);
            _repository.SaveChanges();

        }
    }
}