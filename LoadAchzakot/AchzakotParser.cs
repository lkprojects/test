using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MislakaInterface
{
    public static class AchzakotParser
    {
        public static Mimshak mimshak { get; set; }

        private enum DataMode { Insert, Update };
        private static PensionsEntities dbCtx;
        private static DAL.DAL Dal;

        public static void ParseMutzar(PensionsEntities Context, int mutzar_num)
        {
            dbCtx = Context;
            Mutzar mutzar = new Mutzar();
            DataMode dataMode = DataMode.Insert;

            dbCtx.Configuration.LazyLoadingEnabled = false;
            string key = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.MISPARMISLAKA;
            mutzar = (from k in dbCtx.Mutzars
                      where k.MISPAR_MISLAKA == key
                      select k).FirstOrDefault();

            if (mutzar != null)
            {
                dbCtx.DeleteMutzar(mutzar.Mutzar_Id);
                dbCtx.SaveChanges();
            }
            else
                mutzar = new Mutzar();

            mutzar.KOD_MEZAHE_METAFEL = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.KODMEZAHEMETAFEL;
            mutzar.KOD_MEZAHE_YATZRAN = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.KODMEZAHEYATZRAN;
            mutzar.MISPAR_MISLAKA = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.MISPARMISLAKA;
            mutzar.SUG_MUTZAR_PENSIONI = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.SUGMUTZARPENSIONI;
            mutzar.Lakoach_E_MAIL = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.EMAIL;
            mutzar.Lakoach_ERETZ = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.ERETZ;
            mutzar.Lakoach_HEAROT = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.HEAROT;
            mutzar.Lakoach_MATZAV_MISHPACHTI = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MATZAVMISHPACHTI;
            mutzar.Lakoach_MIKUD = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MIKUD;
            mutzar.Lakoach_MIN = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MIN;
            mutzar.Lakoach_MISPAR_BAIT = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MISPARBAIT;
            mutzar.Lakoach_MISPAR_CELLULARI = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MISPARCELLULARI;
            mutzar.Lakoach_MISPAR_DIRA = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MISPARDIRA;
            mutzar.Lakoach_MISPAR_FAX = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MISPARFAX;
            mutzar.Lakoach_MISPAR_KNISA = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MISPARKNISA;
            mutzar.Lakoach_MISPAR_SHLUCHA = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MISPARSHLUCHA;
            mutzar.Lakoach_MISPAR_TELEPHONE_KAVI = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MISPARTELEPHONEKAVI;
            mutzar.Lakoach_MISPAR_YELADIM = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MISPARYELADIM;
            mutzar.Lakoach_MISPAR_ZIHUY_LAKOACH = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.MISPARZIHUYLAKOACH;
            mutzar.Lakoach_PTIRA = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.PTIRA;
            mutzar.Lakoach_SEMEL_YESHUV = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.SEMELYESHUV;
            mutzar.Lakoach_SHEM_MISHPACHA = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.SHEMMISHPACHA;
            mutzar.Lakoach_SHEM_MISHPACHA_KODEM = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.SHEMMISHPACHAKODEM;
            mutzar.Lakoach_SHEM_PRATI = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.SHEMPRATI;
            mutzar.Lakoach_SHEM_RECHOV = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.SHEMRECHOV;
            mutzar.Lakoach_SHEM_YISHUV = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.SHEMYISHUV;
            mutzar.Lakoach_SUG_MEZAHE_LAKOACH = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.SUGMEZAHELAKOACH;
            mutzar.Lakoach_TA_DOAR = mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.TADOAR;
            mutzar.Lakoach_TAARICH_LEYDA = Common.ConvertDate(mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.TAARICHLEYDA);
            mutzar.Lakoach_TAARICH_PTIRA = Common.ConvertDate(mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutLakoach.TAARICHPTIRA);
            
            
            if (mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutMaasik != null)
                ParseYeshutMaasik(mutzar, mimshak.Mutzarim[mutzar_num].NetuneiMutzar.YeshutMaasik);
            
            for (int i = 0; i < mimshak.Mutzarim[mutzar_num].HeshbonotOPolisot.Length; i++)
            {
                ParseHeshbonOPolisa(mutzar, mimshak.Mutzarim[mutzar_num].HeshbonotOPolisot[i]);
            }

            if (dataMode == DataMode.Insert)
                dbCtx.Mutzars.Add(mutzar);
        }

        private static void ParseYeshutMaasik(Mutzar mutzar, MimshakMutzarNetuneiMutzarYeshutMaasik[] mimshakYeshutMaasik)
        {
            YeshutMaasik yeshutMaasik;
            string key;
            for (int i = 0; i < mimshakYeshutMaasik.Length; i++)
            {
                yeshutMaasik = new YeshutMaasik();

                yeshutMaasik.E_MAIL = mimshakYeshutMaasik[i].EMAIL;
                yeshutMaasik.ERETZ = mimshakYeshutMaasik[i].ERETZ;
                yeshutMaasik.HEAROT = mimshakYeshutMaasik[i].HEAROT;
                yeshutMaasik.MIKUD = mimshakYeshutMaasik[i].MIKUD;
                yeshutMaasik.MISPAR_BAIT = mimshakYeshutMaasik[i].MISPARBAIT;
                yeshutMaasik.MISPAR_CELLULARI = mimshakYeshutMaasik[i].MISPARCELLULARI;
                yeshutMaasik.MISPAR_DIRA = mimshakYeshutMaasik[i].MISPARDIRA;
                yeshutMaasik.MISPAR_FAX = mimshakYeshutMaasik[i].MISPARFAX;
                yeshutMaasik.MISPAR_KNISA = mimshakYeshutMaasik[i].MISPARKNISA;
                yeshutMaasik.MISPAR_MEZAHE_MAASIK = mimshakYeshutMaasik[i].MISPARMEZAHEMAASIK;
                yeshutMaasik.MISPAR_SHLUCHA = mimshakYeshutMaasik[i].MISPARSHLUCHA;
                yeshutMaasik.MISPAR_TELEPHONE_KAVI = mimshakYeshutMaasik[i].MISPARTELEPHONEKAVI;
                yeshutMaasik.MISPAR_TIK_NIKUIIM = mimshakYeshutMaasik[i].MISPARTIKNIKUIIM;
                yeshutMaasik.MPR_MAASIK_BE_YATZRAN = mimshakYeshutMaasik[i].MPRMAASIKBEYATZRAN;
                yeshutMaasik.SEMEL_YESHUV = mimshakYeshutMaasik[i].SEMELYESHUV;
                yeshutMaasik.SHEM_MAASIK = mimshakYeshutMaasik[i].SHEMMAASIK;
                yeshutMaasik.SHEM_RECHOV = mimshakYeshutMaasik[i].SHEMRECHOV;
                yeshutMaasik.SHEM_YISHUV = mimshakYeshutMaasik[i].SHEMYISHUV;
                yeshutMaasik.SUG_MEZAHE_MAASIK = mimshakYeshutMaasik[i].SUGMEZAHEMAASIK;
                yeshutMaasik.TA_DOAR = mimshakYeshutMaasik[i].TADOAR;

                mutzar.YeshutMaasiks.Add(yeshutMaasik);
            }
        }

        private static void ParseIshKesherYeshutMaasik(YeshutMaasik yeshutMaasik, MimshakMutzarNetuneiMutzarYeshutMaasikIshKesherYeshutMaasik[] mimshakIshKesherYeshutMaasik)
        {
            IshKesherYeshutMaasik ishKesherYeshutMaasik;

            for (int j = 0; j < mimshakIshKesherYeshutMaasik.Length; j++)
            {
                ishKesherYeshutMaasik = new IshKesherYeshutMaasik();
                ishKesherYeshutMaasik.E_MAIL = mimshakIshKesherYeshutMaasik[j].EMAIL;
                ishKesherYeshutMaasik.HEAROT = mimshakIshKesherYeshutMaasik[j].HEAROT;
                ishKesherYeshutMaasik.MISPAR_CELLULARI = mimshakIshKesherYeshutMaasik[j].MISPARCELLULARI;
                ishKesherYeshutMaasik.MISPAR_FAX = mimshakIshKesherYeshutMaasik[j].MISPARFAX;
                ishKesherYeshutMaasik.MISPAR_TELEPHONE_KAVI = mimshakIshKesherYeshutMaasik[j].MISPARTELEPHONEKAVI;
                ishKesherYeshutMaasik.SHEM_MISHPACHA = mimshakIshKesherYeshutMaasik[j].SHEMMISHPACHA;
                ishKesherYeshutMaasik.SHEM_PRATI = mimshakIshKesherYeshutMaasik[j].SHEMPRATI;

                yeshutMaasik.IshKesherYeshutMaasiks.Add(ishKesherYeshutMaasik);
            }
        }

        private static void ParseHeshbonOPolisa(Mutzar mutzar, MimshakMutzarHeshbonOPolisa mimshakMutzarHeshbonOPolisa)
        {
            HeshbonOPolisa heshbonOPolisa = new HeshbonOPolisa();

            heshbonOPolisa.AmitOMevutach_KOD_ZIHUY_LAKOACH = mimshakMutzarHeshbonOPolisa.NetuneiAmitOmevutach.KODZIHUYLAKOACH;
            heshbonOPolisa.AmitOMevutach_MISPAR_ZIHUY = mimshakMutzarHeshbonOPolisa.NetuneiAmitOmevutach.MISPARZIHUY;
            heshbonOPolisa.ASMACHTA_MEKORIT = mimshakMutzarHeshbonOPolisa.ASMACHTAMEKORIT;
            if (mimshakMutzarHeshbonOPolisa.MaslulBituach != null)
            {
                heshbonOPolisa.MASLUL_BITUACH_BAKEREN_PENSIA = mimshakMutzarHeshbonOPolisa.MaslulBituach.MASLULBITUACHBAKERENPENSIA;
                heshbonOPolisa.SHEM_MASLUL_HABITUAH = mimshakMutzarHeshbonOPolisa.MaslulBituach.SHEMMASLULHABITUAH;
            }
            if (mimshakMutzarHeshbonOPolisa.PerutShiabudIkul != null)
            {
                heshbonOPolisa.ShiabudIkul_HUTAL_IKUL = mimshakMutzarHeshbonOPolisa.PerutShiabudIkul.HUTALIKUL;
                heshbonOPolisa.ShiabudIkul_HUTAL_SHIABUD = mimshakMutzarHeshbonOPolisa.PerutShiabudIkul.HUTALSHIABUD;
            }

            heshbonOPolisa.MISPAR_POLISA_O_HESHBON = mimshakMutzarHeshbonOPolisa.MISPARPOLISAOHESHBON;
            heshbonOPolisa.MPR_MEFITZ_BE_YATZRAN = mimshakMutzarHeshbonOPolisa.MPRMEFITZBEYATZRAN;
            heshbonOPolisa.PENSIA_VATIKA_O_HADASHA = mimshakMutzarHeshbonOPolisa.PENSIAVATIKAOHADASHA;
            heshbonOPolisa.STATUS_POLISA_O_CHESHBON = mimshakMutzarHeshbonOPolisa.STATUSPOLISAOCHESHBON;
            heshbonOPolisa.SUG_KEREN_PENSIA = mimshakMutzarHeshbonOPolisa.SUGKERENPENSIA;
            heshbonOPolisa.SUG_POLISA = mimshakMutzarHeshbonOPolisa.SUGPOLISA;
            heshbonOPolisa.SUG_TOCHNIT_O_CHESHBON = mimshakMutzarHeshbonOPolisa.SUGTOCHNITOCHESHBON;
            heshbonOPolisa.TAARICH_HITZTARFUT_MUTZAR = Common.ConvertDate(mimshakMutzarHeshbonOPolisa.TAARICHHITZTARFUTMUTZAR);
            heshbonOPolisa.TAARICH_HITZTARFUT_RISHON = Common.ConvertDate(mimshakMutzarHeshbonOPolisa.TAARICHHITZTARFUTRISHON);
            heshbonOPolisa.TAARICH_IDKUN_STATUS = Common.ConvertDate(mimshakMutzarHeshbonOPolisa.TAARICHIDKUNSTATUS);
            heshbonOPolisa.TAARICH_NECHONUT = Common.ConvertDate(mimshakMutzarHeshbonOPolisa.TAARICHNECHONUT);

            if (mimshakMutzarHeshbonOPolisa.KtovetLemishloach != null) 
            { 
                heshbonOPolisa.Mishloach_ERETZ = mimshakMutzarHeshbonOPolisa.KtovetLemishloach.ERETZ;
                heshbonOPolisa.Mishloach_MIKUD = mimshakMutzarHeshbonOPolisa.KtovetLemishloach.MIKUD;
                heshbonOPolisa.Mishloach_MISPAR_BAIT = mimshakMutzarHeshbonOPolisa.KtovetLemishloach.MISPARBAIT;
                heshbonOPolisa.Mishloach_MISPAR_DIRA = mimshakMutzarHeshbonOPolisa.KtovetLemishloach.MISPARDIRA;
                heshbonOPolisa.Mishloach_MISPAR_KNISA = mimshakMutzarHeshbonOPolisa.KtovetLemishloach.MISPARKNISA;
                heshbonOPolisa.Mishloach_SEMEL_YESHUV = mimshakMutzarHeshbonOPolisa.KtovetLemishloach.SEMELYESHUV;
                heshbonOPolisa.Mishloach_SHEM_RECHOV = mimshakMutzarHeshbonOPolisa.KtovetLemishloach.SHEMRECHOV;
                heshbonOPolisa.Mishloach_SHEM_YISHUV = mimshakMutzarHeshbonOPolisa.KtovetLemishloach.SHEMYISHUV;
                heshbonOPolisa.Mishloach_TA_DOAR = mimshakMutzarHeshbonOPolisa.KtovetLemishloach.TADOAR;
            }
            if (mimshakMutzarHeshbonOPolisa.Tsua != null)
            { 
                heshbonOPolisa.Tsua_ACHUZ_TSUA_BRUTO_CHS_2 = mimshakMutzarHeshbonOPolisa.Tsua.ACHUZTSUABRUTOCHS2;
                heshbonOPolisa.Tsua_SHEUR_TSUA_BRUTO_CHS_1 = mimshakMutzarHeshbonOPolisa.Tsua.SHEURTSUABRUTOCHS1;
                heshbonOPolisa.Tsua_SHEUR_TSUA_NETO = mimshakMutzarHeshbonOPolisa.Tsua.SHEURTSUANETO;
            }

            ParseSheerim(heshbonOPolisa, mimshakMutzarHeshbonOPolisa.NetuneiSheerim);
            ParseTvia(heshbonOPolisa, mimshakMutzarHeshbonOPolisa.PirteyTvia);
            ParseHalvaa(heshbonOPolisa, mimshakMutzarHeshbonOPolisa.Halvaa);
            ParseMitriyot(heshbonOPolisa, mimshakMutzarHeshbonOPolisa.PerutMitryot);
            ParseYitraLefiGilPrisha(heshbonOPolisa, mimshakMutzarHeshbonOPolisa.YitraLefiGilPrisha);
            ParseMeyupeKoach(heshbonOPolisa, mimshakMutzarHeshbonOPolisa.PerutMeyupeKoach);
            ParseKisuim(heshbonOPolisa, mimshakMutzarHeshbonOPolisa.Kisuim);

            ParseTaktziv(heshbonOPolisa, mimshakMutzarHeshbonOPolisa.PirteiTaktziv);
            mutzar.HeshbonOPolisas.Add(heshbonOPolisa);
        }

        private static void ParseTaktziv(HeshbonOPolisa heshbonOPolisa, MimshakMutzarHeshbonOPolisaPirteiTaktziv[] mimshakMutzarHeshbonOPolisaPirteiTaktziv)
        {
            PirteiTaktziv taktziv;

            
            for (int i = 0; i < mimshakMutzarHeshbonOPolisaPirteiTaktziv.Length; i++)
            {
                
                taktziv = new PirteiTaktziv();
                if (mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].ChovotPigurim.ChovPigur != null)
                {
                    taktziv.ChovPigur_KAYAM_CHOV_O_PIGUR = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].ChovotPigurim.ChovPigur.KAYAMCHOVOPIGUR;
                    taktziv.ChovPigur_KSAFIM_LO_MESHUYACHIM_MAASIK = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].ChovotPigurim.ChovPigur.KSAFIMLOMESHUYACHIMMAASIK;
                    taktziv.ChovPigur_MISPAR_CHODSHEI_PIGUR = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].ChovotPigurim.ChovPigur.MISPARCHODSHEIPIGUR;
                    taktziv.ChovPigur_SUG_HOV = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].ChovotPigurim.ChovPigur.SUGHOV;

                    taktziv.ChovPigur_TAARICH_TECHILAT_PIGUR = Common.ConvertDate(mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].ChovotPigurim.ChovPigur.TAARICHTECHILATPIGUR);
                    taktziv.ChovPigur_TOTAL_CHOVOT_O_PIGURIM = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].ChovotPigurim.ChovPigur.TOTALCHOVOTOPIGURIM;
                }
                if (mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia != null)
                {
                    taktziv.Gvia_ACHUZ_TAT_SHNATIYOT = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia.ACHUZTATSHNATIYOT;
                    taktziv.Gvia_CHODESH_YECHUS = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia.CHODESHYECHUS;
                    taktziv.Gvia_KOD_EMTZAEI_TASHLUM = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia.KODEMTZAEITASHLUM;
                    taktziv.Gvia_MISPAR_ZIHUY_MESHALEM = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia.MISPARZIHUYMESHALEM;
                    taktziv.Gvia_OFEN_HATZMADAT_GVIA = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia.OFENHATZMADATGVIA;
                    taktziv.Gvia_SHEM_MESHALEM = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia.SHEMMESHALEM;
                    taktziv.Gvia_SUG_TEUDA_MESHALEM = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia.SUGTEUDAMESHALEM;
                    taktziv.Gvia_TADIRUT_TASHLUM = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia.TADIRUTTASHLUM;
                    taktziv.Gvia_YOM_GVIYA_BECHODESH = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].NetuneiGvia.YOMGVIYABECHODESH;
                }
                if (mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiHaasaka != null)
                {
                    taktziv.Haasaka_KOD_CHISHUV_SACHAR_POLISA_O_HESHBON = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiHaasaka.KODCHISHUVSACHARPOLISAOHESHBON;
                    taktziv.Haasaka_KOD_OFEN_HATZMADA = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiHaasaka.KODOFENHATZMADA;
                    taktziv.Haasaka_SACHAR_POLISA = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiHaasaka.SACHARPOLISA;
                    taktziv.Haasaka_SEIF_14 = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiHaasaka.SEIF14;
                    taktziv.Haasaka_TAARICH_MASKORET = Common.ConvertDate(mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiHaasaka.TAARICHMASKORET);
                    taktziv.Haasaka_TAARICH_TCHILAT_TASHLUM = Common.ConvertDate(mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiHaasaka.TAARICHTCHILATTASHLUM);
                    taktziv.Haasaka_ZAKAUT_LELO_TNAI = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiHaasaka.ZAKAUTLELOTNAI;
                }
                if (mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].HafkadotShnatiyot != null)
                {

                    taktziv.HafkadotShnatiyot_TOTAL_HAFKADOT_MAAVID_TAGMULIM_SHANA_NOCHECHIT = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].HafkadotShnatiyot.TOTALHAFKADOTMAAVIDTAGMULIMSHANANOCHECHIT;
                    taktziv.HafkadotShnatiyot_TOTAL_HAFKADOT_OVED_TAGMULIM_SHANA_NOCHECHIT = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].HafkadotShnatiyot.TOTALHAFKADOTOVEDTAGMULIMSHANANOCHECHIT;
                    taktziv.HafkadotShnatiyot_TOTAL_HAFKADOT_PITZUIM_SHANA_NOCHECHIT = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].HafkadotShnatiyot.TOTALHAFKADOTPITZUIMSHANANOCHECHIT;
                }
                if (mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHotzaot.HotzaotBafoalLehodeshDivoach != null)
                {

                    taktziv.HotzaotBafoalLehodeshDivoach_SACH_DMEI_BITUAH_SHENIGBOO = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHotzaot.HotzaotBafoalLehodeshDivoach.SACHDMEIBITUAHSHENIGBOO;
                    taktziv.HotzaotBafoalLehodeshDivoach_SACH_DMEI_NIHUL_ACHERIM = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHotzaot.HotzaotBafoalLehodeshDivoach.SACHDMEINIHULACHERIM;
                    taktziv.HotzaotBafoalLehodeshDivoach_SHEUR_DMEI_NIHUL_HAFKADA = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHotzaot.HotzaotBafoalLehodeshDivoach.SHEURDMEINIHULHAFKADA;
                    taktziv.HotzaotBafoalLehodeshDivoach_SHEUR_DMEI_NIHUL_TZVIRA = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHotzaot.HotzaotBafoalLehodeshDivoach.SHEURDMEINIHULTZVIRA;
                    taktziv.HotzaotBafoalLehodeshDivoach_TOTAL_DMEI_NIHUL_HAFKADA = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHotzaot.HotzaotBafoalLehodeshDivoach.TOTALDMEINIHULHAFKADA;
                    taktziv.HotzaotBafoalLehodeshDivoach_TOTAL_DMEI_NIHUL_POLISA_O_HESHBON = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHotzaot.HotzaotBafoalLehodeshDivoach.TOTALDMEINIHULPOLISAOHESHBON;
                    taktziv.HotzaotBafoalLehodeshDivoach_TOTAL_DMEI_NIHUL_TZVIRA = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHotzaot.HotzaotBafoalLehodeshDivoach.TOTALDMEINIHULTZVIRA;
                }
                if (mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiOved != null)
                {

                    taktziv.Oved_MISPAR_BAAL_POLISA_SHEEINO_MEVUTAH = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiOved.MISPARBAALPOLISASHEEINOMEVUTAH;
                    taktziv.Oved_MPR_MAASIK_BE_YATZRAN = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiOved.MPRMAASIKBEYATZRAN;
                    taktziv.Oved_SHEM_BAAL_POLISA_SHEEINO_MEVUTAH = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiOved.SHEMBAALPOLISASHEEINOMEVUTAH;
                    taktziv.Oved_STATUS_MAASIK = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiOved.STATUSMAASIK;
                    taktziv.Oved_SUG_BAAL_HAPOLISA_SHE_EINO_HAMEVUTACH = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiOved.SUGBAALHAPOLISASHEEINOHAMEVUTACH;
                    taktziv.Oved_SUG_TOCHNIT_O_CHESHBON = mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiOved.SUGTOCHNITOCHESHBON;
                }
                ParseHafrashot(taktziv, mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHafrashotLePolisa);
                ParseDmeiNihul(taktziv, mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHotzaot.MivneDmeiNihul);
                ParseMasluleiHashkaa(taktziv, mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutMasluleiHashkaa);
                ParseHafkadaAchrona(taktziv, mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PirteiHafkadaAchrona);
                ParseHafkadotMetchilatShana(taktziv, mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].PerutHafkadotMetchilatShana);
                ParseItrot(taktziv, mimshakMutzarHeshbonOPolisaPirteiTaktziv[i].BlockItrot);
                heshbonOPolisa.PirteiTaktzivs.Add(taktziv);
            }
        }

        private static void ParseItrot(PirteiTaktziv taktziv, MimshakMutzarHeshbonOPolisaPirteiTaktzivYitrot[] mimshakYitrot)
        {
            Yitrot yitrot;
            if (mimshakYitrot != null)
            { 
                for (int i = 0; i < mimshakYitrot.Length; i++)
                {
                    yitrot = new Yitrot();
                    yitrot.TAARICH_ERECH_TZVIROT = Common.ConvertDate(mimshakYitrot[i].TAARICHERECHTZVIROT);
                    yitrot.ERECH_PIDION_MARKIV_PITZUIM_LEMAS_NOCHECHI = mimshakYitrot[i].YitrotShonot.ERECHPIDIONMARKIVPITZUIMLEMASNOCHECHI;
                    yitrot.ERECH_PIDION_PITZUIM_LEHON_MAAVIDIM_KODMIM = mimshakYitrot[i].YitrotShonot.ERECHPIDIONPITZUIMLEHONMAAVIDIMKODMIM;
                    yitrot.ERECH_PIDION_PITZUIM_LEKITZBA_MAAVIDIM_KODMIM = mimshakYitrot[i].YitrotShonot.ERECHPIDIONPITZUIMLEKITZBAMAAVIDIMKODMIM;
                    yitrot.ERECH_PIDION_PITZUIM_MAAVIDIM_KODMIM_RETZEF_ZEHUYUT = mimshakYitrot[i].YitrotShonot.ERECHPIDIONPITZUIMMAAVIDIMKODMIMRETZEFZEHUYUT;
                    yitrot.KAYAM_RETZEF_PITZUIM_KITZBA = mimshakYitrot[i].YitrotShonot.KAYAMRETZEFPITZUIMKITZBA;
                    yitrot.KAYAM_RETZEF_ZECHUYOT_PITZUIM = mimshakYitrot[i].YitrotShonot.KAYAMRETZEFZECHUYOTPITZUIM;
                    yitrot.MOED_NEZILUT_TAGMULIM = Common.ConvertDate(mimshakYitrot[i].YitrotShonot.MOEDNEZILUTTAGMULIM);
                    yitrot.TZVIRAT_PITZUIM_31_12_1999_LEKITZBA = mimshakYitrot[i].YitrotShonot.TZVIRATPITZUIM31121999LEKITZBA;
                    yitrot.TZVIRAT_PITZUIM_MAAVIDIM_KODMIM_BERETZEF_KITZBA = mimshakYitrot[i].YitrotShonot.TZVIRATPITZUIMMAAVIDIMKODMIMBERETZEFKITZBA;
                    yitrot.TZVIRAT_PITZUIM_MAAVIDIM_KODMIM_BERETZEF_ZECHUYOT = mimshakYitrot[i].YitrotShonot.TZVIRATPITZUIMMAAVIDIMKODMIMBERETZEFZECHUYOT;
                    yitrot.TZVIRAT_PITZUIM_PTURIM_MAAVIDIM_KODMIM = mimshakYitrot[i].YitrotShonot.TZVIRATPITZUIMPTURIMMAAVIDIMKODMIM;
                    yitrot.YITRAT_KASPEY_TAGMULIM = mimshakYitrot[i].YitrotShonot.YITRATKASPEYTAGMULIM;
                    ParseYitraLeTkufa(yitrot, mimshakYitrot[i].PerutYitraLeTkufa);
                    ParsePerutYitrot(yitrot, mimshakYitrot[i].PerutYitrot);
                    taktziv.Yitrots.Add(yitrot);
                }
            }
        }

        private static void ParsePerutYitrot(Yitrot yitrot, MimshakMutzarHeshbonOPolisaPirteiTaktzivYitrotPerutYitrot[] mimshakPerutYitrot)
        {
            PerutYitrot perutYitrot;
            if (mimshakPerutYitrot != null)
            {
                for (int i = 0; i < mimshakPerutYitrot.Length; i++)
                {
                    perutYitrot = new PerutYitrot(); 
                    perutYitrot.KOD_SUG_HAFRASHA = mimshakPerutYitrot[i].KODSUGHAFRASHA;
                    perutYitrot.KOD_SUG_ITRA = mimshakPerutYitrot[i].KODSUGITRA;
                    perutYitrot.TOTAL_CHISACHON_MTZBR = mimshakPerutYitrot[i].TOTALCHISACHONMTZBR;
                    perutYitrot.TOTAL_ERKEI_PIDION = mimshakPerutYitrot[i].TOTALERKEIPIDION;
                    yitrot.PerutYitrots.Add(perutYitrot);
                }
            }
        }

        private static void ParseYitraLeTkufa(Yitrot yitrot, MimshakMutzarHeshbonOPolisaPirteiTaktzivYitrotPerutYitraLeTkufa[] mimshakPerutYitraLeTkufa)
        {
            YitraLeTkufa yitraLeTkufa;
            if (mimshakPerutYitraLeTkufa != null)
            {
                for (int i = 0; i < mimshakPerutYitraLeTkufa.Length; i++)
                {
                    yitraLeTkufa = new YitraLeTkufa(); 
                    yitraLeTkufa.KOD_TECHULAT_SHICHVA = mimshakPerutYitraLeTkufa[i].KODTECHULATSHICHVA;
                    yitraLeTkufa.REKIV_ITRA_LETKUFA = mimshakPerutYitraLeTkufa[i].REKIVITRALETKUFA;
                    yitraLeTkufa.SACH_ITRA_LESHICHVA_BESHACH = mimshakPerutYitraLeTkufa[i].SACHITRALESHICHVABESHACH;
                    yitraLeTkufa.SUG_ITRA_LETKUFA = mimshakPerutYitraLeTkufa[i].SUGITRALETKUFA;
                    yitrot.YitraLeTkufas.Add(yitraLeTkufa);
                }
            }
        }

        private static void ParseHafkadotMetchilatShana(PirteiTaktziv taktziv, MimshakMutzarHeshbonOPolisaPirteiTaktzivPerutHafkadotMetchilatShana[] mimshakHafkadotMetchilatShana)
        {
            HafkadotMetchilatShana hafkadotMetchilatShana;
            if (mimshakHafkadotMetchilatShana != null)
            {
                for (int i = 0; i < mimshakHafkadotMetchilatShana.Length; i++)
                {
                    hafkadotMetchilatShana = new HafkadotMetchilatShana(); 
                    hafkadotMetchilatShana.CHODESH_SACHAR = Common.ConvertDateMonth(mimshakHafkadotMetchilatShana[i].CHODESHSACHAR);
                    hafkadotMetchilatShana.KOD_SUG_HAFKADA = mimshakHafkadotMetchilatShana[i].KODSUGHAFKADA;
                    hafkadotMetchilatShana.SCHUM_HAFKADA_SHESHULAM = mimshakHafkadotMetchilatShana[i].SCHUMHAFKADASHESHULAM;
                    hafkadotMetchilatShana.SUG_HAFRASHA = mimshakHafkadotMetchilatShana[i].SUGHAFRASHA;
                    hafkadotMetchilatShana.SUG_MAFKID = mimshakHafkadotMetchilatShana[i].SUGMAFKID;
                    hafkadotMetchilatShana.TAARICH_ERECH_HAFKADA = Common.ConvertDate(mimshakHafkadotMetchilatShana[i].TAARICHERECHHAFKADA);
                    hafkadotMetchilatShana.ZMAN_PERAON = Common.ConvertDateMonth(mimshakHafkadotMetchilatShana[i].ZMANPERAON);

                    taktziv.HafkadotMetchilatShanas.Add(hafkadotMetchilatShana);
                }
            }
        }

        private static void ParseHafkadaAchrona(PirteiTaktziv taktziv, MimshakMutzarHeshbonOPolisaPirteiTaktzivPerutPirteiHafkadaAchrona[] mimshakHafkadaAchrona)
        {
            HafkadaAchrona hafkadaAchrona;

            if (mimshakHafkadaAchrona != null)
            { 
                for (int i = 0; i < mimshakHafkadaAchrona.Length; i++)
                {
                    hafkadaAchrona = new HafkadaAchrona(); 
                    hafkadaAchrona.SUG_HAFKADA = mimshakHafkadaAchrona[i].SUGHAFKADA;
                    hafkadaAchrona.TAARICH_ERECH_HAFKADA = Common.ConvertDate(mimshakHafkadaAchrona[i].TAARICHERECHHAFKADA);
                    hafkadaAchrona.TAARICH_HAFKADA_ACHARON = Common.ConvertDate(mimshakHafkadaAchrona[i].TAARICHHAFKADAACHARON);
                    hafkadaAchrona.TOTAL_HAFKADA = mimshakHafkadaAchrona[i].TOTALHAFKADA;
                    hafkadaAchrona.TOTAL_HAFKADA_ACHRONA = mimshakHafkadaAchrona[i].TOTALHAFKADAACHRONA;
                    ParsePerutHafkadaAchrona(hafkadaAchrona, mimshakHafkadaAchrona[i].PerutHafkadaAchrona);
                    taktziv.HafkadaAchronas.Add(hafkadaAchrona);
                }
            }
        }

        private static void ParsePerutHafkadaAchrona(HafkadaAchrona hafkadaAchrona, MimshakMutzarHeshbonOPolisaPirteiTaktzivPerutPirteiHafkadaAchronaPerutHafkadaAchrona[] mimshakPerutHafkadaAchrona)
        {
            PerutHafkadaAchrona perutHafkadaAchrona;
            if (mimshakPerutHafkadaAchrona != null)
            { 
                for (int i = 0; i < mimshakPerutHafkadaAchrona.Length; i++)
                {
                    perutHafkadaAchrona = new PerutHafkadaAchrona(); 
                    perutHafkadaAchrona.CHODESH_SACHAR = mimshakPerutHafkadaAchrona[i].CHODESHSACHAR;
                    perutHafkadaAchrona.KOD_SUG_HAFKADA = mimshakPerutHafkadaAchrona[i].KODSUGHAFKADA;
                    perutHafkadaAchrona.SCHUM_HAFKADA_SHESHULAM = mimshakPerutHafkadaAchrona[i].SCHUMHAFKADASHESHULAM;
                    perutHafkadaAchrona.SUG_HAFRASHA = mimshakPerutHafkadaAchrona[i].SUGHAFRASHA;
                    perutHafkadaAchrona.SUG_MAFKID = mimshakPerutHafkadaAchrona[i].SUGMAFKID;
                    hafkadaAchrona.PerutHafkadaAchronas.Add(perutHafkadaAchrona);
                }
            }

        }

        private static void ParseMasluleiHashkaa(PirteiTaktziv taktziv, MimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa[] mimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa)
        {
            MasluleiHashkaa masluleiHashkaa;
            if (mimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa != null)
            { 
                for (int i = 0; i < mimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa.Length; i++)
                {
                    masluleiHashkaa = new MasluleiHashkaa(); 
                    masluleiHashkaa.ACHUZ_HAFKADA_LEHASHKAA = mimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa[i].ACHUZHAFKADALEHASHKAA;
                    masluleiHashkaa.KOD_MASLUL_HASHKAA = mimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa[i].KODMASLULHASHKAA;
                    masluleiHashkaa.KOD_SUG_HAFRASHA = mimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa[i].KODSUGHAFRASHA;
                    masluleiHashkaa.KOD_SUG_MASLUL = mimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa[i].KODSUGMASLUL;
                    masluleiHashkaa.SCHUM_TZVIRA_BAMASLUL = mimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa[i].SCHUMTZVIRABAMASLUL;
                    masluleiHashkaa.SHEM_MASLUL_HASHKAA = mimshakMutzarHeshbonOPolisaPirteiTaktzivPerutMasluleiHashkaa[i].SHEMMASLULHASHKAA;
                    taktziv.MasluleiHashkaas.Add(masluleiHashkaa);
                }
            }
        }

        private static void ParseDmeiNihul(PirteiTaktziv taktziv, MimshakMutzarHeshbonOPolisaPirteiTaktzivPerutHotzaotPerutMivneDmeiNihul[] mimshakDmeiNihul)
        {
            DmeiNihul dmeiNihul;
            if (mimshakDmeiNihul != null)
            {
                for (int i = 0; i < mimshakDmeiNihul.Length; i++)
                {
                    dmeiNihul = new DmeiNihul(); 
                    dmeiNihul.DMEI_NIHUL_ACHERIM = mimshakDmeiNihul[i].DMEINIHULACHERIM;
                    dmeiNihul.DMEI_NIHUL_ACHIDIM = mimshakDmeiNihul[i].DMEINIHULACHIDIM;
                    dmeiNihul.GOVA_DMEI_NIHUL_NIKBA_AL_PI_HOTZAOT_BAPOAL = mimshakDmeiNihul[i].GOVADMEINIHULNIKBAALPIHOTZAOTBAPOAL;
                    dmeiNihul.KAYEMET_HATAVA = mimshakDmeiNihul[i].KAYEMETHATAVA;
                    dmeiNihul.KOD_MASLUL_DMEI_NIHUL = mimshakDmeiNihul[i].KODMASLULDMEINIHUL;
                    dmeiNihul.KOD_MASLUL_HASHKAA_BAAL_DMEI_NIHUL_YECHUDIIM = mimshakDmeiNihul[i].KODMASLULHASHKAABAALDMEINIHULYECHUDIIM;
                    dmeiNihul.MEAFYENEI_MASLUL_DMEI_NIHUL = mimshakDmeiNihul[i].MEAFYENEIMASLULDMEINIHUL;
                    dmeiNihul.OFEN_HAFRASHA = mimshakDmeiNihul[i].OFENHAFRASHA;
                    dmeiNihul.SACH_DMEI_NIHUL_MASLUL = mimshakDmeiNihul[i].SACHDMEINIHULMASLUL;
                    dmeiNihul.SCHUM_MAX_DNHL_HAFKADA = mimshakDmeiNihul[i].SCHUMMAXDNHLHAFKADA;
                    dmeiNihul.SHEUR_DMEI_NIHUL = mimshakDmeiNihul[i].SHEURDMEINIHUL;
                    dmeiNihul.SUG_HOTZAA = mimshakDmeiNihul[i].SUGHOTZAA;
                    dmeiNihul.TAARICH_NECHONUT_SHEUR_DNHL = Common.ConvertDate(mimshakDmeiNihul[i].TAARICHNECHONUTSHEURDNHL);

                    taktziv.DmeiNihuls.Add(dmeiNihul);
                }
            }
        }

        private static void ParseHafrashot(PirteiTaktziv taktziv, MimshakMutzarHeshbonOPolisaPirteiTaktzivPerutHafrashotLePolisa[] mimshakHafrashotLePolisa)
        {
            HafrashotLePolisa hafrashot;
            if (mimshakHafrashotLePolisa != null)
            {
                for (int i = 0; i < mimshakHafrashotLePolisa.Length; i++)
                {
                    hafrashot = new HafrashotLePolisa(); 
                    hafrashot.ACHUZ_HAFRASHA = mimshakHafrashotLePolisa[i].ACHUZHAFRASHA;
                    hafrashot.SCHUM_HAFRASHA = mimshakHafrashotLePolisa[i].SCHUMHAFRASHA;
                    hafrashot.SUG_HAFRASHA = mimshakHafrashotLePolisa[i].SUGHAFRASHA;
                    hafrashot.SUG_HAMAFKID = mimshakHafrashotLePolisa[i].SUGHAMAFKID;
                    hafrashot.TAARICH_MADAD = Common.ConvertDate(mimshakHafrashotLePolisa[i].TAARICHMADAD);
                    taktziv.HafrashotLePolisas.Add(hafrashot);
                }
            }
        }

        private static void ParseKisuim(HeshbonOPolisa heshbonOPolisa, MimshakMutzarHeshbonOPolisaKisuim[] mimshakMutzarHeshbonOPolisaKisuim)
        {
            Kisui kisui;
            for (int i = 0; i < mimshakMutzarHeshbonOPolisaKisuim.Length; i++)
            {
                kisui = new Kisui();
                kisui.MISPAR_KISUI_BE_YATZRAN = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.MISPARKISUIBEYATZRAN;
                kisui.SHEM_KISUI_YATZRAN = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SHEMKISUIYATZRAN;
                kisui.SUG_KISUI_ETZEL_YATZRAN = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SUGKISUIETZELYATZRAN;

                if (mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia != null)
                { 
                    kisui.KerenPensia_AHUZ_PENSIYA_TZVURA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.AHUZPENSIYATZVURA;
                    kisui.KerenPensia_ALUT_KISUI_NECHUT = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.ALUTKISUINECHUT;
                    kisui.KerenPensia_ALUT_KISUI_PNS_SHRM_NECHE = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.ALUTKISUIPNSSHRMNECHE;
                    kisui.KerenPensia_ALUT_KISUY_SHEERIM = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.ALUTKISUYSHEERIM;
                    kisui.KerenPensia_GIL_PRISHA_LEPENSIYAT_ZIKNA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.GILPRISHALEPENSIYATZIKNA;
                    kisui.KerenPensia_HATAVA_BITUCHIT = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.HATAVABITUCHIT;
                    kisui.KerenPensia_KITZBAT_SHEERIM_LEALMAN_O_ALMANA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.KITZBATSHEERIMLEALMANOALMANA;
                    kisui.KerenPensia_KITZBAT_SHEERIM_LEHORE_NITMACH = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.KITZBATSHEERIMLEHORENITMACH;
                    kisui.KerenPensia_KITZBAT_SHEERIM_LEYATOM = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.KITZBATSHEERIMLEYATOM;
                    kisui.KerenPensia_MENAT_PENSIA_TZVURA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.MENATPENSIATZVURA;
                    kisui.KerenPensia_MISPAR_HODSHEI_HAVERUT_BEKEREN_HAPENSIYA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.MISPARHODSHEIHAVERUTBEKERENHAPENSIYA;
                    kisui.KerenPensia_SACH_PENSIAT_NECHUT = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.SACHARKOVEALENECHUTVESHEERIM;
                    kisui.KerenPensia_SACH_PENSIYAT_ALMAN_O_ALMANA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.SACHPENSIATNECHUT;
                    kisui.KerenPensia_SACHAR_KOVEA_LE_NECHUT_VE_SHEERIM = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.SACHPENSIYATALMANOALMANA;
                    kisui.KerenPensia_SHEUR_KISUY_NECHUT = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.SHEURKISUYNECHUT;
                    kisui.KerenPensia_SHIUR_KISUY_ALMAN_O_ALMANA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.SHIURKISUYALMANOALMANA;
                    kisui.KerenPensia_SHIUR_KISUY_HORE_NITMACH = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.SHIURKISUYHORENITMACH;
                    kisui.KerenPensia_SHIUR_KISUY_YATOM = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.SHIURKISUYYATOM;

                    kisui.KerenPensia_TAARICH_ERECH_LANENTUNIM = Common.ConvertDate(mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.TAARICHERECHLANENTUNIM);
                    kisui.KerenPensia_TAARICH_MASKORET_NECHUT_VE_SHEERIM = Common.ConvertDate(mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.TAARICHMASKORETNECHUTVESHEERIM);
                    kisui.KerenPensia_TAARICH_TCHILAT_HAVERUT = Common.ConvertDate(mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.KisuiBKerenPensia.TAARICHTCHILATHAVERUT);
                }
                if (mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar != null)
                { 
                    kisui.Mutzar_ACHUZ_ME_SCM_BTH_YESODI = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.ACHUZMESCMBTHYESODI;
                    kisui.Mutzar_ACHUZ_MESACHAR = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.ACHUZMESACHAR;
                    kisui.Mutzar_DMEI_BITUAH_LETASHLUM_BAPOAL = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.DMEIBITUAHLETASHLUMBAPOAL;
                    kisui.Mutzar_HACHRAGA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.HACHRAGA;
                    kisui.Mutzar_HANACHA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.HANACHA;
                    kisui.Mutzar_HATNAYA_LAHANACHA_DMEI_BITUAH = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.HATNAYALAHANACHADMEIBITUAH;
                    kisui.Mutzar_IND_CHITUM = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.INDCHITUM;
                    kisui.Mutzar_KOD_ISHUN = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.KODISHUN;
                    kisui.Mutzar_KOD_MIUTZAR_LAKISUY = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.KODMIUTZARLAKISUY;
                    kisui.Mutzar_MESHALEM_HAKISUY = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.MESHALEMHAKISUY;
                    kisui.Mutzar_OFEN_TASHLUM_SCHUM_BITUACH = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.OFENTASHLUMSCHUMBITUACH;
                    kisui.Mutzar_SCHUM_BITUACH = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.SCHUMBITUACH;
                    kisui.Mutzar_SUG_HACHRAGA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.SUGHACHRAGA;
                    kisui.Mutzar_SUG_MEVUTACH = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.SUGMEVUTACH;
                    kisui.Mutzar_TADIRUT_SHINUY_DMEI_HABITUAH_BESHANIM = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.TADIRUTSHINUYDMEIHABITUAHBESHANIM;
                    kisui.Mutzar_TKUFAT_ACHSHARA = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.TKUFATACHSHARA;
                    kisui.Mutzar_TKUFAT_HAMTANA_CHODASHIM = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.TKUFATHAMTANACHODASHIM;

                    kisui.Mutzar_TAARICH_CHITUM = Common.ConvertDate(mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.TAARICHCHITUM);
                    kisui.Mutzar_TAARICH_HAFSAKAT_TASHLUM = Common.ConvertDate(mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.TAARICHHAFSAKATTASHLUM);
                    kisui.Mutzar_TAARICH_IDKUN_HABA_SHEL_DMEI_HABITUAH = Common.ConvertDate(mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.TAARICHIDKUNHABASHELDMEIHABITUAH);
                    kisui.Mutzar_TAARICH_TCHILAT_KISUY = Common.ConvertDate(mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.TAARICHTCHILATKISUY);
                    kisui.Mutzar_TAARICH_TOM_KISUY = Common.ConvertDate(mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiKisuiBeMutzar.TAARICHTOMKISUY);
                }
                if (mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi != null)
                {
                    kisui.Yesodi_ACHUZ_HAKTZAA_LE_CHISACHON = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.ACHUZHAKTZAALECHISACHON;
                    kisui.Yesodi_IND_SCHUM_BITUAH_KOLEL_CHISACHON = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.INDSCHUMBITUAHKOLELCHISACHON;
                    kisui.Yesodi_KOD_MUTZAR_LEFI_KIDUD_ACHID_LAYESODI = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.KODMUTZARLEFIKIDUDACHIDLAYESODI;
                    kisui.Yesodi_MISPAR_MASKOROT = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.MISPARMASKOROT;
                    kisui.Yesodi_SCHUM_BITUACH_LEMASLUL = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.SCHUMBITUACHLEMASLUL;
                    kisui.Yesodi_SCHUM_BITUAH_LEMAVET = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.SCHUMBITUAHLEMAVET;
                    kisui.Yesodi_SUG_HATZMADA_SCHUM_BITUAH = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.SUGHATZMADASCHUMBITUAH;
                    kisui.Yesodi_SUG_MASLUL_LEBITUAH = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.SUGMASLULLEBITUAH;
                    kisui.Yesodi_TIKRAT_GAG_HATAM_LE_O_K_A = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.TIKRATGAGHATAMLEOKA;
                    kisui.Yesodi_TIKRAT_GAG_HATAM_LEMIKRE_MAVET = mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.SchumeiBituahYesodi.TIKRATGAGHATAMLEMIKREMAVET;
                }
                ParseMevutach(kisui, mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiMevutach);
                ParseTosafot(kisui, mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.PirteiTosafot);
                ParseMutav(kisui, mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.Mutav);
                ParseMiktsoaIsukTachviv(kisui, mimshakMutzarHeshbonOPolisaKisuim[i].ZihuiKisui.MiktsoaIsukTachviv);

                heshbonOPolisa.Kisuis.Add(kisui);
            }
        }

        private static void ParseMiktsoaIsukTachviv(Kisui kisui, MimshakMutzarHeshbonOPolisaKisuimZihuiKisuiMiktsoaIsukTachviv[] mimshakMutzarHeshbonOPolisaKisuimZihuiKisuiMiktsoaIsukTachviv)
        {
            Miktsoa_Isuk_Tachviv miktsoa_Isuk_Tachviv;
            if (mimshakMutzarHeshbonOPolisaKisuimZihuiKisuiMiktsoaIsukTachviv != null)
            { 
                for (int i = 0; i < mimshakMutzarHeshbonOPolisaKisuimZihuiKisuiMiktsoaIsukTachviv.Length; i++)
                {
                    miktsoa_Isuk_Tachviv = new Miktsoa_Isuk_Tachviv();
                    miktsoa_Isuk_Tachviv.KOD_MIKTZOA = mimshakMutzarHeshbonOPolisaKisuimZihuiKisuiMiktsoaIsukTachviv[i].KODMIKTZOA;
                    miktsoa_Isuk_Tachviv.TACHVIVIM_O_ISUKIM = mimshakMutzarHeshbonOPolisaKisuimZihuiKisuiMiktsoaIsukTachviv[i].TACHVIVIMOISUKIM;
                    miktsoa_Isuk_Tachviv.TCHUM_ISUK_CHADASH = mimshakMutzarHeshbonOPolisaKisuimZihuiKisuiMiktsoaIsukTachviv[i].TCHUMISUKCHADASH;
                    kisui.Miktsoa_Isuk_Tachviv.Add(miktsoa_Isuk_Tachviv);
                }
            }
        }

        private static void ParseMutav(Kisui kisui, MimshakMutzarHeshbonOPolisaKisuimZihuiKisuiMutav[] mimshakKisuiMutav)
        {
            Mutav mutav;
            if (mimshakKisuiMutav != null)
            {
                for (int i = 0; i < mimshakKisuiMutav.Length; i++)
                {
                    mutav = new Mutav();
                    mutav.ACHUZ_MUTAV = mimshakKisuiMutav[i].ACHUZMUTAV;
                    mutav.HAGDARAT_MUTAV = mimshakKisuiMutav[i].HAGDARATMUTAV;
                    mutav.KOD_ZIHUY_MUTAV = mimshakKisuiMutav[i].KODZIHUYMUTAV;
                    mutav.MAHUT_MUTAV = mimshakKisuiMutav[i].MAHUTMUTAV;
                    mutav.MISPAR_ZIHUY_MUTAV = mimshakKisuiMutav[i].MISPARZIHUYMUTAV;
                    mutav.SHEM_MISHPACHA_MUTAV = mimshakKisuiMutav[i].SHEMMISHPACHAMUTAV;
                    mutav.SHEM_PRATI_MUTAV = mimshakKisuiMutav[i].SHEMPRATIMUTAV;
                    mutav.SUG_ZIHUY_MUTAV = mimshakKisuiMutav[i].SUGZIHUYMUTAV;
                    mutav.SUG_ZIKA = mimshakKisuiMutav[i].SUGZIKA;

                    kisui.Mutavs.Add(mutav);
                }
            }
        }

        private static void ParseTosafot(Kisui kisui, MimshakMutzarHeshbonOPolisaKisuimZihuiKisuiPirteiTosafot[] mimshakKisuiPirteiTosafot)
        {
            Tosafot tosafot;
            if (mimshakKisuiPirteiTosafot != null) 
            {
                for (int i = 0; i < mimshakKisuiPirteiTosafot.Length; i++)
                {
                    tosafot = new Tosafot();
                    tosafot.KOD_SUG_TOSEFET = mimshakKisuiPirteiTosafot[i].KODSUGTOSEFET;
                    tosafot.SHEUR_TOSEFET = mimshakKisuiPirteiTosafot[i].SHEURTOSEFET;
                    tosafot.TOSEFET_TAARIF = mimshakKisuiPirteiTosafot[i].TOSEFETTAARIF;

                    tosafot.TAARICH_TOM_TOSEFET = Common.ConvertDate(mimshakKisuiPirteiTosafot[i].TAARICHTOMTOSEFET);

                    kisui.Tosafots.Add(tosafot);
                }
            }
        }

        private static void ParseMevutach(Kisui kisui, MimshakMutzarHeshbonOPolisaKisuimZihuiKisuiPirteiMevutach[] mimshakKisuiPirteiMevutach)
        {
            Mevutach mevutach;
            if (mimshakKisuiPirteiMevutach != null)
            { 
                for (int i = 0; i < mimshakKisuiPirteiMevutach.Length; i++)
                {
                    mevutach = new Mevutach(); 
                    mevutach.MISPAR_ZIHUY_LAKOACH = mimshakKisuiPirteiMevutach[i].MISPARZIHUYLAKOACH;
                    mevutach.SUG_TEUDA = mimshakKisuiPirteiMevutach[i].SUGTEUDA;
                    kisui.Mevutaches.Add(mevutach);
                }
            }
        }

        private static void ParseMeyupeKoach(HeshbonOPolisa heshbonOPolisa, MimshakMutzarHeshbonOPolisaPerutMeyupeKoach[] mimshakPerutMeyupeKoach)
        {
            MeyupeKoach meyupeKoach;
            if (mimshakPerutMeyupeKoach != null)
            { 
                for (int i = 0; i < mimshakPerutMeyupeKoach.Length; i++)
                {
                    meyupeKoach = new MeyupeKoach(); 
                    meyupeKoach.KAYAM_MEYUPE_KOACH = mimshakPerutMeyupeKoach[i].KAYAMMEYUPEKOACH;
                    meyupeKoach.MISPAR_ZIHUY = mimshakPerutMeyupeKoach[i].MISPARZIHUY;
                    meyupeKoach.SHEM_MEYUPE_KOACH = mimshakPerutMeyupeKoach[i].SHEMMEYUPEKOACH;
                    meyupeKoach.SUG_ZIHUY = mimshakPerutMeyupeKoach[i].SUGZIHUY;
                    heshbonOPolisa.MeyupeKoaches.Add(meyupeKoach);
                }
            }
        }

        private static void ParseYitraLefiGilPrisha(HeshbonOPolisa heshbonOPolisa, MimshakMutzarHeshbonOPolisaYitraLefiGilPrisha[] mimshakYitraLefiGilPrisha)
        {
            YitraLefiGilPrisha yitraLefiGilPrisha;
            if (mimshakYitraLefiGilPrisha != null)
            {
                for (int i = 0; i < mimshakYitraLefiGilPrisha.Length; i++)
                {
                    yitraLefiGilPrisha = new YitraLefiGilPrisha(); 
                    yitraLefiGilPrisha.GIL_PRISHA = mimshakYitraLefiGilPrisha[i].GILPRISHA;
                    yitraLefiGilPrisha.SHEUR_PNS_ZIKNA_TZFUYA = mimshakYitraLefiGilPrisha[i].SHEURPNSZIKNATZFUYA;
                    yitraLefiGilPrisha.TOTAL_CHISACHON_MITZTABER_TZAFUY = mimshakYitraLefiGilPrisha[i].TOTALCHISACHONMITZTABERTZAFUY;
                    yitraLefiGilPrisha.TZVIRAT_CHISACHON_CHAZUYA_LELO_PREMIYOT = mimshakYitraLefiGilPrisha[i].TZVIRATCHISACHONCHAZUYALELOPREMIYOT;
                    ParseKupot(yitraLefiGilPrisha, mimshakYitraLefiGilPrisha[i].Kupot);
                    heshbonOPolisa.YitraLefiGilPrishas.Add(yitraLefiGilPrisha);
                }
            }

        }

        private static void ParseKupot(YitraLefiGilPrisha yitraLefiGilPrisha, MimshakMutzarHeshbonOPolisaYitraLefiGilPrishaKupa[] mimshakYitraLefiGilPrishaKupa)
        {
            Kupa kupa;
            if (mimshakYitraLefiGilPrishaKupa != null)
            {
                for (int i = 0; i < mimshakYitraLefiGilPrishaKupa.Length; i++)
                {
                    kupa = new Kupa(); 
                    kupa.ACHUZ_TSUA_BATACHAZIT = mimshakYitraLefiGilPrishaKupa[i].ACHUZTSUABATACHAZIT;
                    kupa.KITZVAT_HODSHIT_TZFUYA = mimshakYitraLefiGilPrishaKupa[i].KITZVATHODSHITTZFUYA;
                    kupa.SCHUM_KITZVAT_ZIKNA = mimshakYitraLefiGilPrishaKupa[i].SCHUMKITZVATZIKNA;
                    kupa.SUG_KUPA = mimshakYitraLefiGilPrishaKupa[i].SUGKUPA;
                    kupa.TOTAL_ITRA_TZFUYA_MECHUSHAV_LEHON_IM_PREMIOT = mimshakYitraLefiGilPrishaKupa[i].TOTALITRATZFUYAMECHUSHAVLEHONIMPREMIOT;
                    kupa.TOTAL_SCHUM_MITZVTABER_TZFUY_LEGIL_PRISHA_MECHUSHAV_HAMEYOAD_LEKITZBA_LELO_PREMIYOT = mimshakYitraLefiGilPrishaKupa[i].TOTALSCHUMMITZVTABERTZFUYLEGILPRISHAMECHUSHAVHAMEYOADLEKITZBALELOPREMIYOT;
                    kupa.TOTAL_SCHUM_MTZBR_TZAFUY_LEGIL_PRISHA_MECHUSHAV_LEKITZBA_IM_PREMIYOT = mimshakYitraLefiGilPrishaKupa[i].TOTALSCHUMMTZBRTZAFUYLEGILPRISHAMECHUSHAVLEKITZBAIMPREMIYOT;
                    kupa.TZVIRAT_CHISACHON_TZFUYA_LEHON_LELO_PREMIYOT = mimshakYitraLefiGilPrishaKupa[i].TZVIRATCHISACHONTZFUYALEHONLELOPREMIYOT;
                    yitraLefiGilPrisha.Kupas.Add(kupa);
                }
            }
        }

        private static void ParseMitriyot(HeshbonOPolisa heshbonOPolisa, MimshakMutzarHeshbonOPolisaPerutMitryot[] mimshakPerutMitryot)
        {
            Mitryot mitriot;
            if (mimshakPerutMitryot != null)
            {
                for (int i = 0; i < mimshakPerutMitryot.Length; i++)
                {
                    mitriot = new Mitryot();
                    mitriot.ALUT_KISUI = mimshakPerutMitryot[i].ALUTKISUI;
                    mitriot.HAIM_NECHTAM_TOFES_HITZTARFUT = mimshakPerutMitryot[i].HAIMNECHTAMTOFESHITZTARFUT;
                    mitriot.KAYAM_KISUY_BITUCHI_COLECTIVI_LEAMITIM = mimshakPerutMitryot[i].KAYAMKISUYBITUCHICOLECTIVILEAMITIM;
                    mitriot.KOD_SUG_MUTZAR_BITUACH = mimshakPerutMitryot[i].KODSUGMUTZARBITUACH;
                    mitriot.MESHALEM_DMEI_HABITUAH = mimshakPerutMitryot[i].MESHALEMDMEIHABITUAH;
                    mitriot.SCHUM_BITUACH = mimshakPerutMitryot[i].SCHUMBITUACH;
                    mitriot.SHEM_MEVATACHAT = mimshakPerutMitryot[i].SHEMMEVATACHAT;
                    mitriot.TADIRUT_HATSHLUM = mimshakPerutMitryot[i].TADIRUTHATSHLUM;

                    mitriot.TAARICH_TCHILAT_HABITUACH = Common.ConvertDate(mimshakPerutMitryot[i].TAARICHTCHILATHABITUACH);
                    mitriot.TAARICH_TOM_TKUFAT_HABITUAH = Common.ConvertDate(mimshakPerutMitryot[i].TAARICHTOMTKUFATHABITUAH);

                    heshbonOPolisa.Mitryots.Add(mitriot);
                }
            }
        }

        private static void ParseHalvaa(HeshbonOPolisa heshbonOPolisa, MimshakMutzarHeshbonOPolisaHalvaa[] mimshakMutzarHeshbonOPolisaHalvaa)
        {
            Halvaa halvaa;
            if (mimshakMutzarHeshbonOPolisaHalvaa != null)
            {
                for (int i = 0; i < mimshakMutzarHeshbonOPolisaHalvaa.Length; i++)
                {
                    halvaa = new Halvaa(); 
                    halvaa.MISDAR_SIDURI_SHEL_HAHALVAA = mimshakMutzarHeshbonOPolisaHalvaa[i].MISDARSIDURISHELHAHALVAA;
                    halvaa.RIBIT = mimshakMutzarHeshbonOPolisaHalvaa[i].RIBIT;
                    halvaa.SCHUM_HALVAA = mimshakMutzarHeshbonOPolisaHalvaa[i].SCHUMHALVAA;
                    halvaa.SCHUM_HECHZER_TKUFATI = mimshakMutzarHeshbonOPolisaHalvaa[i].SCHUMHECHZERTKUFATI;
                    halvaa.SUG_HATZNMADA = mimshakMutzarHeshbonOPolisaHalvaa[i].SUGHATZNMADA;
                    halvaa.SUG_HECHZER = mimshakMutzarHeshbonOPolisaHalvaa[i].SUGHECHZER;
                    halvaa.SUG_RIBIT = mimshakMutzarHeshbonOPolisaHalvaa[i].SUGRIBIT;
                    halvaa.TADIRUT_HECHZER_HALVAA = mimshakMutzarHeshbonOPolisaHalvaa[i].TADIRUTHECHZERHALVAA;
                    halvaa.TKUFAT_HALVAA = mimshakMutzarHeshbonOPolisaHalvaa[i].TKUFATHALVAA;
                    halvaa.YESH_HALVAA_BAMUTZAR = mimshakMutzarHeshbonOPolisaHalvaa[i].YESHHALVAABAMUTZAR;
                    halvaa.YITRAT_HALVAA = mimshakMutzarHeshbonOPolisaHalvaa[i].YITRATHALVAA;

                    halvaa.TAARICH_KABALAT_HALVAA = Common.ConvertDate(mimshakMutzarHeshbonOPolisaHalvaa[i].TAARICHKABALATHALVAA);
                    halvaa.TAARICH_SIYUM_HALVAA = Common.ConvertDate(mimshakMutzarHeshbonOPolisaHalvaa[i].TAARICHSIYUMHALVAA);

                    heshbonOPolisa.Halvaas.Add(halvaa);
                }
            }
        }

        private static void ParseTvia(HeshbonOPolisa heshbonOPolisa, MimshakMutzarHeshbonOPolisaPirteyTvia[] mimshakPirteyTvia)
        {
            Tvia tvia;
            if (mimshakPirteyTvia != null)
            {
                for (int i = 0; i < mimshakPirteyTvia.Length; i++)
                {
                    tvia = new Tvia(); 
                    tvia.ACHUZ_MEUSHAR_O_K_A_SHICHRUR = mimshakPirteyTvia[i].ACHUZMEUSHAROKASHICHRUR;
                    tvia.ACHUZ_NECHUT = mimshakPirteyTvia[i].ACHUZNECHUT;
                    tvia.KOD_STATUS_TVIAA = mimshakPirteyTvia[i].KODSTATUSTVIAA;
                    tvia.MISPAR_KISUI_BE_YATZRAN = mimshakPirteyTvia[i].MISPARKISUIBEYATZRAN;
                    tvia.MISPAR_TVIA_BE_YATZRAN = mimshakPirteyTvia[i].MISPARTVIABEYATZRAN;
                    tvia.OFEN_TASHLUM = mimshakPirteyTvia[i].OFENTASHLUM;
                    tvia.SCHUM_TVIA_MEUSHAR = mimshakPirteyTvia[i].SCHUMTVIAMEUSHAR;
                    tvia.SHEM_KISUI_BE_YATZRAN = mimshakPirteyTvia[i].SHEMKISUIBEYATZRAN;
                    tvia.SUG_HATVIAA = mimshakPirteyTvia[i].SUGHATVIAA;

                    tvia.TAARICH_STATUS_TVIA = Common.ConvertDate(mimshakPirteyTvia[i].TAARICHSTATUSTVIA);
                    tvia.TAARICH_TECHILAT_TASHLUM = Common.ConvertDate(mimshakPirteyTvia[i].TAARICHTECHILATTASHLUM);

                    heshbonOPolisa.Tvias.Add(tvia);
                }
            }
        }

        private static void ParseSheerim(HeshbonOPolisa heshbonOPolisa, MimshakMutzarHeshbonOPolisaSheer[] mimshakMutzarHeshbonOPolisaSheer)
        {
            Sheer sheer;
            if (mimshakMutzarHeshbonOPolisaSheer != null)
            { 
                for (int i = 0; i < mimshakMutzarHeshbonOPolisaSheer.Length; i++)
                {
                    sheer = new Sheer(); 
                    sheer.KOD_ZIHUI_SHEERIM = mimshakMutzarHeshbonOPolisaSheer[i].KODZIHUISHEERIM;
                    sheer.MISPAR_ZIHUY_SHEERIM = mimshakMutzarHeshbonOPolisaSheer[i].MISPARZIHUYSHEERIM;
                    sheer.SHEM_MISHPACHA_SHEERIM = mimshakMutzarHeshbonOPolisaSheer[i].SHEMMISHPACHASHEERIM;
                    sheer.SHEM_PRATI_SHEERIM = mimshakMutzarHeshbonOPolisaSheer[i].SHEMPRATISHEERIM;
                    sheer.SUG_ZIKA = mimshakMutzarHeshbonOPolisaSheer[i].SUGZIKA;
                    heshbonOPolisa.Sheers.Add(sheer);
                }
            }
        }

        public static void ParseKovetz(PensionsEntities dbCtx)
        {
            Kovetz kovetz = new Kovetz();
            DataMode dataMode = DataMode.Insert;

            dbCtx.Configuration.LazyLoadingEnabled = false;
            kovetz = (from k in dbCtx.Kovetzs
                      where k.MISPAR_HAKOVETZ == mimshak.KoteretKovetz.MISPARHAKOVETZ
                      select k).FirstOrDefault();

            if (kovetz != null)
            {
                dbCtx.Entry(kovetz).State = System.Data.Entity.EntityState.Modified;
                dataMode = DataMode.Update;
            }
            
            kovetz.KIVUN_MIMSHAK_XML = mimshak.KoteretKovetz.KIVUNMIMSHAKXML;
            kovetz.KOD_MEZAHE_METAFEL = mimshak.KoteretKovetz.KODMEZAHEMETAFEL;
            kovetz.KOD_SHOLEACH = mimshak.KoteretKovetz.KODSHOLEACH;
            kovetz.KOD_SVIVAT_AVODA = mimshak.KoteretKovetz.KODSVIVATAVODA;
            kovetz.SHEM_METAFEL = mimshak.KoteretKovetz.SHEMMETAFEL;
            kovetz.MEZAHE_HAAVARA = mimshak.KoteretKovetz.MEZAHEHAAVARA;
            kovetz.KIVUN_MIMSHAK_XML = mimshak.KoteretKovetz.KIVUNMIMSHAKXML;
            kovetz.MISPAR_GIRSAT_XML = mimshak.KoteretKovetz.MISPARGIRSATXML.ToString().Substring(4, 3);
            kovetz.MISPAR_HAKOVETZ = mimshak.KoteretKovetz.MISPARHAKOVETZ;
            kovetz.Sgira_KAMUT_METAFELIM = mimshak.ReshumatSgira.KAMUTMETAFELIM;
            kovetz.Sgira_KAMUT_MUTZARIM = mimshak.ReshumatSgira.KAMUTMUTZARIM;
            kovetz.Sgira_KAMUT_POLISOT = mimshak.ReshumatSgira.KAMUTPOLISOT;
            kovetz.Sgira_KAMUT_YATZRANIM = mimshak.ReshumatSgira.KAMUTYATZRANIM;
            kovetz.Sgira_KAMUT_YESHUYOT_MAASIK = mimshak.ReshumatSgira.KAMUTYESHUYOTMAASIK;
            kovetz.Sgira_KAMUT_YESHUYOT_MEFITZ = mimshak.ReshumatSgira.KAMUTYESHUYOTMEFITZ;
            kovetz.Sgira_MISPAR_YESHUYUT_LAKOACH_BAKOVETZ = mimshak.ReshumatSgira.MISPARYESHUYUTLAKOACHBAKOVETZ;
            kovetz.SHEM_SHOLEACH = mimshak.KoteretKovetz.SHEMSHOLEACH;
            kovetz.SUG_MIMSHAK = mimshak.KoteretKovetz.SUGMIMSHAK;
            kovetz.TAARICH_BITZUA = Common.Common.ConvertDatetime(mimshak.KoteretKovetz.TAARICHBITZUA);
            kovetz.Yatzran_SHEM_YATZRAN = mimshak.YeshutYatzran.SHEMYATZRAN;
            kovetz.Yatzran_KOD_MEZAHE_YATZRAN = mimshak.YeshutYatzran.KODMEZAHEYATZRAN;


            IshKesherYeshutYatzran ishKesherYeshutYatzran;
            if (mimshak.YeshutYatzran.IshKesherYeshutYatzran != null && dataMode == DataMode.Insert)
            {
                for (int i = 0; i < mimshak.YeshutYatzran.IshKesherYeshutYatzran.Length; i++)
                {
                    ishKesherYeshutYatzran = new IshKesherYeshutYatzran();
                    ishKesherYeshutYatzran.E_MAIL = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].EMAIL;
                    ishKesherYeshutYatzran.ERETZ = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].ERETZ;
                    ishKesherYeshutYatzran.HEAROT = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].HEAROT;
                    ishKesherYeshutYatzran.MIKUD = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].MIKUD;
                    ishKesherYeshutYatzran.MISPAR_BAIT = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].MISPARBAIT;
                    ishKesherYeshutYatzran.MISPAR_CELLULARI = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].MISPARCELLULARI;
                    ishKesherYeshutYatzran.MISPAR_DIRA = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].MISPARDIRA;
                    ishKesherYeshutYatzran.MISPAR_FAX = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].MISPARFAX;
                    ishKesherYeshutYatzran.MISPAR_KNISA = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].MISPARKNISA;
                    ishKesherYeshutYatzran.MISPAR_SHLUCHA = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].MISPARSHLUCHA;
                    ishKesherYeshutYatzran.MISPAR_TELEPHONE_KAVI = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].MISPARTELEPHONEKAVI;
                    ishKesherYeshutYatzran.SEMEL_YESHUV = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].SEMELYESHUV;
                    ishKesherYeshutYatzran.SHEM_MISHPACHA = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].SHEMMISHPACHA;
                    ishKesherYeshutYatzran.SHEM_PRATI = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].SHEMPRATI;
                    ishKesherYeshutYatzran.SHEM_RECHOV = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].SHEMRECHOV;
                    ishKesherYeshutYatzran.SHEM_YISHUV = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].SHEMYISHUV;
                    ishKesherYeshutYatzran.TA_DOAR = mimshak.YeshutYatzran.IshKesherYeshutYatzran[i].TADOAR;

                    kovetz.IshKesherYeshutYatzrans.Add(ishKesherYeshutYatzran);
                }
            }

            YeshutMetafel yeshutMetafel;
            if (mimshak.YeshutMetafel != null)
            {
                for (int i = 0; i < mimshak.YeshutMetafel.Length; i++)
                {
                    // Check if the there is a Metafel that already exists
                    var x = kovetz.YeshutMetafels.Where(p => p.KOD_MEZAHE_METAFEL == mimshak.YeshutMetafel[i].KODMEZAHEMETAFEL);
                    if (x == null) // Metafel not exists - then add a new Metafel
                    {
                        yeshutMetafel = new YeshutMetafel();
                        yeshutMetafel.KOD_MEZAHE_METAFEL = mimshak.YeshutMetafel[i].KODMEZAHEMETAFEL;
                        yeshutMetafel.SHEM_METAFEL = mimshak.YeshutMetafel[i].SHEMMETAFEL;

                        IshKesherYeshutMetafel ishKesherYeshutMetafel;
                        if (mimshak.YeshutMetafel[i].IshKesherYeshutMetafel != null)
                        {
                            for (int j = 0; j < mimshak.YeshutMetafel[i].IshKesherYeshutMetafel.Length; j++)
                            {
                                ishKesherYeshutMetafel = new IshKesherYeshutMetafel();
                                ishKesherYeshutMetafel.E_MAIL = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].EMAIL;
                                ishKesherYeshutMetafel.ERETZ = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].ERETZ;
                                ishKesherYeshutMetafel.HEAROT = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].HEAROT;
                                ishKesherYeshutMetafel.MIKUD = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].MIKUD;
                                ishKesherYeshutMetafel.MISPAR_BAIT = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].MISPARBAIT;
                                ishKesherYeshutMetafel.MISPAR_CELLULARI = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].MISPARCELLULARI;
                                ishKesherYeshutMetafel.MISPAR_DIRA = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].MISPARDIRA;
                                ishKesherYeshutMetafel.MISPAR_FAX = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].MISPARFAX;
                                ishKesherYeshutMetafel.MISPAR_KNISA = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].MISPARKNISA;
                                ishKesherYeshutMetafel.MISPAR_SHLUCHA = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].MISPARSHLUCHA;
                                ishKesherYeshutMetafel.MISPAR_TELEPHONE_KAVI = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].MISPARTELEPHONEKAVI;
                                ishKesherYeshutMetafel.SEMEL_YESHUV = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].SEMELYESHUV;
                                ishKesherYeshutMetafel.SHEM_MISHPACHA = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].SHEMMISHPACHA;
                                ishKesherYeshutMetafel.SHEM_PRATI = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].SHEMPRATI;
                                ishKesherYeshutMetafel.SHEM_RECHOV = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].SHEMRECHOV;
                                ishKesherYeshutMetafel.SHEM_YISHUV = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].SHEMYISHUV;
                                ishKesherYeshutMetafel.TA_DOAR = mimshak.YeshutMetafel[i].IshKesherYeshutMetafel[j].TADOAR;
                                yeshutMetafel.IshKesherYeshutMetafels.Add(ishKesherYeshutMetafel);
                            }
                        }

                        kovetz.YeshutMetafels.Add(yeshutMetafel);
                    }
                }
            }
            if (dataMode == DataMode.Insert)
                dbCtx.Kovetzs.Add(kovetz);

            dbCtx.SaveChanges();
        }

    }
}
