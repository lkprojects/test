using DAL;
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
            dbCtx.Configuration.LazyLoadingEnabled = true;

            /*
Halvaa
Kupa
MeyupeKoach
Mitryot
Kisui
HeshbonOPolisa
Sheer
Tvia
YitraLefiGilPrisha
Mevutach
Mutav
DmeiNihul
HafkadaAchrona
Tosafot
HafkadotMetchilatShana
HafrashotLePolisa
MasluleiHashkaa
PerutHafkadaAchrona
PerutYitrot
YitraLeTkufa
Yitrot
Maasik
Customer
GoremPone
HeshbonKovetz
PirteiTaktziv

                                ( from h in dbCtx.HeshbonOPolisas.Include("PirteiTaktziv.Yitrot.PerutYitrot")

             */
            List<HeshbonOPolisa> polisas = 
                   ( from h in dbCtx.HeshbonOPolisas
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
    
    }
}
