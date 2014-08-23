using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Globalization;

namespace MislakaInterface
{
    class Feedback
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const int SugMimshak = 20;

        private FeedbackInterface.Mimshak mimshak;
        private MislakaFileName mislakaFileName;

        public FeedbackInterface.Mimshak Mimshak
        {
            get { return mimshak; }
            set { mimshak = value; }
        }


        public MislakaFileName MislakaFilename
        {
            get { return mislakaFileName; }
            set { mislakaFileName = value; }
        }
        

        // constructor
        public Feedback(FeedbackInterface.Mimshak feedback)
        {
            mimshak = feedback;
        }
        public Feedback()
        {
            mimshak = new FeedbackInterface.Mimshak();
        }

        public void ProduceFeedback(FileTypes SvivatAvoda, string MisparHakovetz, string ShemHakovetz, bool isSuccess)
        {
            DAL.DAL Dal = new DAL.DAL("Events");
            int numerator = Dal.GetFileNumerator();
            mimshak.KoteretKovetz = new FeedbackInterface.MimshakKoteretKovetz();

            mimshak.KoteretKovetz.KODSVIVATAVODA = (int)SvivatAvoda;
            mimshak.KoteretKovetz.MISPARGIRSATXML = FeedbackInterface.MimshakKoteretKovetzMISPARGIRSATXML.Item001;
            mimshak.KoteretKovetz.MISPARHAKOVETZ = DateTime.Now.ToString("yyyyMMddhhmmss") + Dal.GetConfigParam("KOD-MEZAHE-YATZRAN").PadLeft(9, '0') + numerator.ToString("0000");
            mimshak.KoteretKovetz.MISPARSIDURI = numerator;
            mimshak.KoteretKovetz.SUGMIMSHAK = 6;
            mimshak.KoteretKovetz.TAARICHBITZUA = DateTime.Now.ToString("yyyyMMddhhmmss");
            FeedbackInterface.MimshakYeshutGoremPoneLemislaka[] GufHamimshak = new FeedbackInterface.MimshakYeshutGoremPoneLemislaka[1];

            GufHamimshak[0] = new FeedbackInterface.MimshakYeshutGoremPoneLemislaka();
            GufHamimshak[0].EMAILPONELEMISLAKA = Dal.GetConfigParam("E-MAIL-PONE-LEMISLAKA");
            GufHamimshak[0].MISPARCELLULARI = Dal.GetConfigParam("MISPAR-CELLULARI");
            GufHamimshak[0].MISPARMEZAHEMETAFEL = Dal.GetConfigParam("MISPAR-MEZAHE-METAFEL");
            GufHamimshak[0].MISPARMEZAHEPONE = Dal.GetConfigParam("MISPAR-MEZAHE-PONE");
            GufHamimshak[0].MISPARTELEPHONEKAVIPONELEMISLAKA = Dal.GetConfigParam("MISPAR-TELEPHONE-KAVI-PONE-LEMISLAKA");
            GufHamimshak[0].SHEMGOREMPONE = Dal.GetConfigParam("SHEM-GOREM-PONE");
            GufHamimshak[0].SHEMMISHPACHAPONELEMISLAKA = Dal.GetConfigParam("SHEM-MISHPACHA-PONE-LEMISLAKA");
            GufHamimshak[0].SHEMPRATIPONELEMISLAKA = Dal.GetConfigParam("SHEM-PRATI-PONE-LEMISLAKA");
            GufHamimshak[0].SUGKODMEZAHEPONE = Convert.ToInt32(Dal.GetConfigParam("SUG-KOD-MEZAHE-PONE"));
            GufHamimshak[0].SUGPONE = 3; // 3 = Mefitz.
            GufHamimshak[0].SugMashov = new FeedbackInterface.MimshakYeshutGoremPoneLemislakaSugMashov();
            GufHamimshak[0].SugMashov.MISPARHAKOVETZ = MisparHakovetz;
            GufHamimshak[0].SugMashov.RAMATMASHOV = 1; // 1 = File level, 2= Record level
            GufHamimshak[0].SugMashov.SHEMHAKOVETZ = ShemHakovetz;
            GufHamimshak[0].SugMashov.SUGMASHOV = 1; // 1 = Shlav Alef, 2 = Shlav Bet
            GufHamimshak[0].SugMashov.SUGMIMSHAKLEGABAVMUAVARHIZUNCHOZER = SugMimshak; // 1= Achzakot, = Trom Yeutz etc.

            if (!isSuccess)
            {
                GufHamimshak[0].SugMashov.MashovBeramatKovetz = new FeedbackInterface.MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatKovetz();
                GufHamimshak[0].SugMashov.MashovBeramatKovetz.KODSHGIHA = 5; // 5 = Received Successfully.
            }
            mimshak.GufHamimshak = GufHamimshak;

            mislakaFileName = new MislakaFileName("001" /*Mefitz to Mislaka*/,
                                                    Dal.GetConfigParam("MISPAR-MEZAHE-METAFEL"),
                                                    ServiceTypes.FEDBKA,
                                                    ProductTypes.NotRelevant,
                                                    Dal.GetConfigParam("VERSION"),
                                                    DateTime.Now, numerator,
                                                    SvivatAvoda
                                                    );
        }

        public FeedbackFile ParseFeedback()
        {
            log.Debug("Start parsing feedback file #" + mimshak.KoteretKovetz.MISPARHAKOVETZ);
            FeedbackFile feedbackFile = new FeedbackFile();

            feedbackFile.KOD_SVIVAT_AVODA = mimshak.KoteretKovetz.KODSVIVATAVODA;
            feedbackFile.MISPAR_GIRSAT_XML = mimshak.KoteretKovetz.MISPARGIRSATXML.ToString().Replace("Item", "");
            feedbackFile.MISPAR_HAKOVETZ = mimshak.KoteretKovetz.MISPARHAKOVETZ;
            feedbackFile.MISPAR_SIDURI = mimshak.KoteretKovetz.MISPARSIDURI;
            feedbackFile.SUG_MIMSHAK = mimshak.KoteretKovetz.SUGMIMSHAK;
            feedbackFile.TAARICH_BITZUA = Common.ConvertDatetime(mimshak.KoteretKovetz.TAARICHBITZUA);

            if (mimshak.KoteretKovetz.NetuneiGoremSholech != null)
            {
                feedbackFile.E_MAIL_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.EMAILISHKESHERSHOLECH;
                feedbackFile.KOD_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.KODSHOLECH;
                feedbackFile.MISPAR_CELLULARI_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.MISPARCELLULARIISHKESHERSHOLECH;
                feedbackFile.MISPAR_TELEPHONE_KAVI_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.MISPARTELEPHONEKAVIISHKESHERSHOLECH;
                feedbackFile.MISPAR_ZIHUI_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.MISPARZIHUISHOLECH;
                feedbackFile.SHEM_GOREM_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMGOREMSHOLECH;
                feedbackFile.SHEM_MISHPACHA_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMMISHPACHAISHKESHERSHOLECH;
                feedbackFile.SHEM_PRATI_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMPRATIISHKESHERSHOLECH;
                feedbackFile.SUG_MEZAHE_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.SUGMEZAHESHOLECH;
            }
 
            if (mimshak.KoteretKovetz.NetuneiGoremNimaan != null)
            {
                feedbackFile.KOD_NIMAAN = mimshak.KoteretKovetz.NetuneiGoremNimaan.KODNIMAAN;
                feedbackFile.MISPAR_ZIHUI_ETZEL_YATZRAN_NIMAAN = mimshak.KoteretKovetz.NetuneiGoremNimaan.MISPARZIHUIETZELYATZRANNIMAAN;
                feedbackFile.MISPAR_ZIHUI_NIMAAN = mimshak.KoteretKovetz.NetuneiGoremNimaan.MISPARZIHUIETZELYATZRANNIMAAN;
                feedbackFile.SUG_MEZAHE_NIMAAN = mimshak.KoteretKovetz.NetuneiGoremNimaan.SUGMEZAHENIMAAN;
            }
 

            GetGufHamimshak(feedbackFile.GoremPones, mimshak.GufHamimshak);
            log.Debug("End parsing feedback file #" + mimshak.KoteretKovetz.MISPARHAKOVETZ);
            return feedbackFile;
        }

        private void GetGufHamimshak(ICollection<GoremPone> collection, FeedbackInterface.MimshakYeshutGoremPoneLemislaka[] GoremPoneLemislaka)
        {
            GoremPone goremPone;
            for (int i = 0; i< GoremPoneLemislaka.Length; i++)
            {
                goremPone = new GoremPone();
                goremPone.E_MAIL_PONE_LEMISLAKA = GoremPoneLemislaka[i].EMAILPONELEMISLAKA;
                goremPone.MISPAR_CELLULARI = GoremPoneLemislaka[i].MISPARCELLULARI;
                goremPone.MISPAR_MEZAHE_METAFEL = GoremPoneLemislaka[i].MISPARMEZAHEMETAFEL;
                goremPone.MISPAR_MEZAHE_PONE = GoremPoneLemislaka[i].MISPARMEZAHEPONE;
                goremPone.MISPAR_TELEPHONE_KAVI_PONE_LEMISLAKA = GoremPoneLemislaka[i].MISPARTELEPHONEKAVIPONELEMISLAKA;
                goremPone.SHEM_GOREM_PONE = GoremPoneLemislaka[i].SHEMGOREMPONE;
                goremPone.SHEM_MISHPACHA_PONE_LEMISLAKA = GoremPoneLemislaka[i].SHEMMISHPACHAPONELEMISLAKA;
                goremPone.SHEM_PRATI_PONE_LEMISLAKA = GoremPoneLemislaka[i].SHEMPRATIPONELEMISLAKA;
                goremPone.SUG_KOD_MEZAHE_PONE = GoremPoneLemislaka[i].SUGKODMEZAHEPONE;
                goremPone.SUG_PONE = GoremPoneLemislaka[i].SUGPONE;
                goremPone.MISPAR_HAKOVETZ = GoremPoneLemislaka[i].SugMashov.MISPARHAKOVETZ;
                goremPone.RAMAT_MASHOV = GoremPoneLemislaka[i].SugMashov.RAMATMASHOV;
                goremPone.SHEM_HAKOVETZ = Common.RemovePath(GoremPoneLemislaka[i].SugMashov.SHEMHAKOVETZ);

                goremPone.SUG_MASHOV = GoremPoneLemislaka[i].SugMashov.SUGMASHOV;
                goremPone.SUG_MIMSHAK_LEGABAV_MUAVAR_HIZUN_CHOZER = GoremPoneLemislaka[i].SugMashov.SUGMIMSHAKLEGABAVMUAVARHIZUNCHOZER;
                if (GoremPoneLemislaka[i].SugMashov.MashovBeramatKovetz != null)
                    goremPone.KOD_SHGIHA = GoremPoneLemislaka[i].SugMashov.MashovBeramatKovetz.KODSHGIHA;
                GetFileErrorDetail(goremPone.FileErrorDetails, GoremPoneLemislaka[i].SugMashov.MashovBeramatKovetz);
                GetRequest(goremPone.Requests, GoremPoneLemislaka[i].SugMashov.MashovBeramatReshuma);
                collection.Add(goremPone);
            }
        }

        private void GetRequest(ICollection<Request> collection, FeedbackInterface.MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshuma[] MashovBeramatReshuma)
        {
            Request request;
            if (MashovBeramatReshuma != null)
            { 
                for (int i=0; i< MashovBeramatReshuma.Length;i++)
                {
                    request = new Request();
                    request.KOD_SHGIHA_BERAMAT_RESHUMA = MashovBeramatReshuma[i].KODSHGIHABERAMATRESHUMA;
                    request.MISPAR_MEZAHE_RESHUMA = MashovBeramatReshuma[i].MISPARMEZAHERESHUMA;
                    request.MISPAR_MISLAKA = MashovBeramatReshuma[i].MISPARMISLAKA;
                    request.STATUS_RESHUMA = Convert.ToInt32(MashovBeramatReshuma[i].STATUSRESHUMA.ToString().Replace("Item",""));
                    GetRequestPerYatzrans(request.RequestPerYatzrans, MashovBeramatReshuma[i].MaaneMiYazran);
                    GetRequestErrorDetails(request.RequestErrorDetails, MashovBeramatReshuma[i].PerutShgihaBeramatReshuma);
                    collection.Add(request);
                }
            }
        }

        private void GetRequestErrorDetails(ICollection<RequestErrorDetail> collection, 
                                            FeedbackInterface.MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaPerutShgihaBeramatReshuma[] PerutShgihaBeramatReshuma)
        {
            RequestErrorDetail requestErrorDetail; 
            if (PerutShgihaBeramatReshuma != null)
            { 
                for (int i=0; i< PerutShgihaBeramatReshuma.Length ;i++)
                {
                    requestErrorDetail = new RequestErrorDetail();
                    requestErrorDetail.PERUT_SHGIHA_BERAMAT_RESHUMA = PerutShgihaBeramatReshuma[i].PERUTSHGIHABERAMATRESHUMA;
                    collection.Add(requestErrorDetail);
                }
            }
        }

        private void GetRequestPerYatzrans(ICollection<RequestPerYatzran> collection,
                                           FeedbackInterface.MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaMaaneMiYazran[] MaaneMiYazran)
        {
            RequestPerYatzran requestPerYatzran;
            if (MaaneMiYazran != null)
            { 
                for (int i = 0; i < MaaneMiYazran.Length; i++)
                {
                    requestPerYatzran = new RequestPerYatzran();
                    requestPerYatzran.MAANE_BERAMAT_RESHUMA = MaaneMiYazran[i].MAANEBERAMATRESHUMA;
                    collection.Add(requestPerYatzran);
                }
            }
        }

        private void GetFileErrorDetail(ICollection<FileErrorDetail> collection, FeedbackInterface.MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatKovetz MashovBeramatKovetz)
        {
            FileErrorDetail fileErrorDetail;
            if (MashovBeramatKovetz.PerutShgihaBeramatKovetz != null)
            { 
                for (int i = 0; i < MashovBeramatKovetz.PerutShgihaBeramatKovetz.Length; i++)
                {
                    fileErrorDetail = new FileErrorDetail();
                    fileErrorDetail.PERUT_SHGIHA_BERAMAT_KOVETZ = MashovBeramatKovetz.PerutShgihaBeramatKovetz[i].PERUTSHGIHABERAMATKOVETZ;
                    collection.Add(fileErrorDetail);
                }
            }
        }

        public void CreateFeedbackKovetzRecord(string file)
        {
            Kovetz kovetz = new Kovetz();
            kovetz.MISPAR_GIRSAT_XML = mimshak.KoteretKovetz.MISPARGIRSATXML.ToString().Replace("Item","");
            kovetz.MISPAR_HAKOVETZ = mimshak.KoteretKovetz.MISPARHAKOVETZ;
            kovetz.KOD_SVIVAT_AVODA = mimshak.KoteretKovetz.KODSVIVATAVODA;
            kovetz.SUG_MIMSHAK = mimshak.KoteretKovetz.SUGMIMSHAK;
            kovetz.TAARICH_BITZUA = Common.ConvertDatetime(mimshak.KoteretKovetz.TAARICHBITZUA);
            kovetz.MISPAR_GIRSAT_XML = "001";
            kovetz.SHEM_SHOLEACH = "Feedback Success";
            kovetz.FileName = file;
            kovetz.MEZAHE_HAAVARA = mimshak.KoteretKovetz.MISPARHAKOVETZ;
            kovetz.Yatzran_SHEM_YATZRAN = "";
            kovetz.LoadDate = DateTime.Now;
            kovetz.KIVUN_MIMSHAK_XML = 5;
        }
    }
}
