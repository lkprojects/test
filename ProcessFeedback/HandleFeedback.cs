using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Globalization;

namespace Feedback
{
    class HandleFeedback
    {
        private Mimshak mimshak;
        public Mimshak Mimshak
        {
            get { return mimshak; }
            set { mimshak = value; }
        }
        
        // constructor
        public HandleFeedback(Mimshak feedback)
        {
            mimshak = feedback;
        }
        public HandleFeedback()
        {
        }

        public void ProduceSuccessFeedback( feedbackFile)
        {
            
        }


        public FeedbackFile ParseFeedback()
        {
            FeedbackFile feedbackFile = new FeedbackFile();
            feedbackFile.E_MAIL_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.EMAILISHKESHERSHOLECH;
            feedbackFile.KOD_NIMAAN = mimshak.KoteretKovetz.NetuneiGoremNimaan.KODNIMAAN;
            feedbackFile.KOD_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.KODSHOLECH;
            feedbackFile.KOD_SVIVAT_AVODA = mimshak.KoteretKovetz.KODSVIVATAVODA;

            feedbackFile.MISPAR_CELLULARI_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.MISPARCELLULARIISHKESHERSHOLECH;

            feedbackFile.MISPAR_GIRSAT_XML = mimshak.KoteretKovetz.MISPARGIRSATXML.ToString().Replace("Item", "");
            feedbackFile.MISPAR_HAKOVETZ = mimshak.KoteretKovetz.MISPARHAKOVETZ;
            feedbackFile.MISPAR_SIDURI = mimshak.KoteretKovetz.MISPARSIDURI;
            feedbackFile.MISPAR_TELEPHONE_KAVI_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.MISPARTELEPHONEKAVIISHKESHERSHOLECH;
            feedbackFile.MISPAR_ZIHUI_ETZEL_YATZRAN_NIMAAN = mimshak.KoteretKovetz.NetuneiGoremNimaan.MISPARZIHUIETZELYATZRANNIMAAN;
            feedbackFile.MISPAR_ZIHUI_NIMAAN = mimshak.KoteretKovetz.NetuneiGoremNimaan.MISPARZIHUIETZELYATZRANNIMAAN;
            feedbackFile.MISPAR_ZIHUI_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.MISPARZIHUISHOLECH;
            feedbackFile.SHEM_GOREM_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMGOREMSHOLECH;
            feedbackFile.SHEM_MISHPACHA_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMMISHPACHAISHKESHERSHOLECH;
            feedbackFile.SHEM_PRATI_ISH_KESHER_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMPRATIISHKESHERSHOLECH;
            feedbackFile.SUG_MEZAHE_NIMAAN = mimshak.KoteretKovetz.NetuneiGoremNimaan.SUGMEZAHENIMAAN;
            feedbackFile.SUG_MEZAHE_SHOLECH = mimshak.KoteretKovetz.NetuneiGoremSholech.SUGMEZAHESHOLECH;
            feedbackFile.SUG_MIMSHAK = mimshak.KoteretKovetz.SUGMIMSHAK;
            feedbackFile.TAARICH_BITZUA = ConvertDatetime(mimshak.KoteretKovetz.TAARICHBITZUA);

            GetGufHamimshak(feedbackFile.GoremPones, mimshak.GufHamimshak);
            return feedbackFile;
        }

        private void GetGufHamimshak(ICollection<GoremPone> collection, MimshakYeshutGoremPoneLemislaka[] GoremPoneLemislaka)
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
                goremPone.SHEM_HAKOVETZ = GoremPoneLemislaka[i].SugMashov.SHEMHAKOVETZ;
                goremPone.SUG_MASHOV = GoremPoneLemislaka[i].SugMashov.SUGMASHOV;
                goremPone.SUG_MIMSHAK_LEGABAV_MUAVAR_HIZUN_CHOZER = GoremPoneLemislaka[i].SugMashov.SUGMIMSHAKLEGABAVMUAVARHIZUNCHOZER;
                if (GoremPoneLemislaka[i].SugMashov.MashovBeramatKovetz != null)
                    goremPone.KOD_SHGIHA = GoremPoneLemislaka[i].SugMashov.MashovBeramatKovetz.KODSHGIHA;
                GetFileErrorDetail(goremPone.FileErrorDetails, GoremPoneLemislaka[i].SugMashov.MashovBeramatKovetz);
                GetRequest(goremPone.Requests, GoremPoneLemislaka[i].SugMashov.MashovBeramatReshuma);
                collection.Add(goremPone);
            }
        }

        private void GetRequest(ICollection<Request> collection, MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshuma[] MashovBeramatReshuma)
        {
            Request request;
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

        private void GetRequestErrorDetails(ICollection<RequestErrorDetail> collection, MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaPerutShgihaBeramatReshuma[] PerutShgihaBeramatReshuma)
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


        private void GetRequestPerYatzrans(ICollection<RequestPerYatzran> collection, MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatReshumaMaaneMiYazran[] MaaneMiYazran)
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

        private void GetFileErrorDetail(ICollection<FileErrorDetail> collection, MimshakYeshutGoremPoneLemislakaSugMashovMashovBeramatKovetz MashovBeramatKovetz)
        {
            FileErrorDetail fileErrorDetail;
            if (MashovBeramatKovetz != null)
            { 
                for (int i = 0; i < MashovBeramatKovetz.PerutShgihaBeramatKovetz.Length; i++)
                {
                    fileErrorDetail = new FileErrorDetail();
                    fileErrorDetail.PERUT_SHGIHA_BERAMAT_KOVETZ = MashovBeramatKovetz.PerutShgihaBeramatKovetz[i].PERUTSHGIHABERAMATKOVETZ;
                    collection.Add(fileErrorDetail);
                }
            }
        }

        private static DateTime? ConvertDate(string str)
        {
            DateTime date;
            if (DateTime.TryParseExact(str, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else
                return null;
        }

        private static DateTime? ConvertDatetime(string str)
        {
            DateTime date;
            if (DateTime.TryParseExact(str, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else
                return null;
        }

        private static DateTime? ConvertDateMonth(string str)
        {
            DateTime date;
            str += "01"; // Adding the 1st day of the month
            if (DateTime.TryParseExact(str, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;
            else
                return null;
        }

    }
}
