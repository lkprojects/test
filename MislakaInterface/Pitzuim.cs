using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MislakaInterface
{
    class Pitzuim
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private MimshakPitzuin mimshak { get; set; }
        private DAL.DAL Dal = new DAL.DAL();

        private enum DataMode { Insert, Update };

        public void Parse(MimshakPitzuin mimshak_in, string filename)
        {
            log.Info("Start Parsing Achzakot file #" + mimshak_in.KoteretKovetz.MISPARHAKOVETZ);

            mimshak = mimshak_in;
            Kovetz kovetz;
            DataMode dataMode = DataMode.Insert;

            kovetz = Dal.GetKovetzByNumber(mimshak.KoteretKovetz.MISPARHAKOVETZ);
            if (kovetz != null)
            {
                dataMode = DataMode.Update;
            }

            kovetz = new Kovetz();

//            mimshak.KoteretKovetz.MISPARSIDURI
            kovetz.KOD_SVIVAT_AVODA = mimshak.KoteretKovetz.KODSVIVATAVODA;
            kovetz.MISPAR_GIRSAT_XML = mimshak.KoteretKovetz.MISPARGIRSATXML.ToString().Substring(4, 3);
            kovetz.MISPAR_HAKOVETZ = mimshak.KoteretKovetz.MISPARHAKOVETZ;
            kovetz.SUG_MIMSHAK = mimshak.KoteretKovetz.SUGMIMSHAK;
            kovetz.TAARICH_BITZUA = Common.ConvertDatetime(mimshak.KoteretKovetz.TAARICHBITZUA);


            //kovetz.KIVUN_MIMSHAK_XML = mimshak.KoteretKovetz.KIVUNMIMSHAKXML;
            //kovetz.KOD_MEZAHE_METAFEL = mimshak.KoteretKovetz.KODMEZAHEMETAFEL;
            //kovetz.KOD_SHOLEACH = mimshak.KoteretKovetz.KODSHOLEACH;
            //kovetz.SHEM_METAFEL = mimshak.KoteretKovetz.SHEMMETAFEL;
            //kovetz.MEZAHE_HAAVARA = mimshak.KoteretKovetz.MEZAHEHAAVARA;
            //kovetz.KIVUN_MIMSHAK_XML = mimshak.KoteretKovetz.KIVUNMIMSHAKXML;
            //kovetz.Sgira_KAMUT_METAFELIM = mimshak.ReshumatSgira.KAMUTMETAFELIM;
            //kovetz.Sgira_KAMUT_MUTZARIM = mimshak.ReshumatSgira.KAMUTMUTZARIM;
            //kovetz.Sgira_KAMUT_POLISOT = mimshak.ReshumatSgira.KAMUTPOLISOT;
            //kovetz.Sgira_KAMUT_YATZRANIM = mimshak.ReshumatSgira.KAMUTYATZRANIM;
            //kovetz.Sgira_KAMUT_YESHUYOT_MAASIK = mimshak.ReshumatSgira.KAMUTYESHUYOTMAASIK;
            //kovetz.Sgira_KAMUT_YESHUYOT_MEFITZ = mimshak.ReshumatSgira.KAMUTYESHUYOTMEFITZ;
            //kovetz.Sgira_MISPAR_YESHUYUT_LAKOACH_BAKOVETZ = mimshak.ReshumatSgira.MISPARYESHUYUTLAKOACHBAKOVETZ;
            //kovetz.SHEM_SHOLEACH = mimshak.KoteretKovetz.SHEMSHOLEACH;
            //kovetz.Yatzran_SHEM_YATZRAN = mimshak.YeshutYatzran.SHEMYATZRAN;
            //kovetz.Yatzran_KOD_MEZAHE_YATZRAN = mimshak.YeshutYatzran.KODMEZAHEYATZRAN;
            kovetz.LoadDate = DateTime.Now;
            kovetz.FileName = filename;

            kovetz.KOD_SHOLEACH = mimshak.KoteretKovetz.NetuneiGoremSholech.KODSHOLECH;
            kovetz.Yatzran_KOD_MEZAHE_YATZRAN = mimshak.KoteretKovetz.NetuneiGoremSholech.KODSHOLECH;
            kovetz.Yatzran_SHEM_YATZRAN = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMGOREMSHOLECH;
            kovetz.SHEM_SHOLEACH = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMGOREMSHOLECH;
            IshKesherYeshutYatzran Ish = new IshKesherYeshutYatzran();
            Ish.E_MAIL = mimshak.KoteretKovetz.NetuneiGoremSholech.EMAILISHKESHERSHOLECH;
            Ish.MISPAR_CELLULARI=  mimshak.KoteretKovetz.NetuneiGoremSholech.MISPARCELLULARIISHKESHERSHOLECH;
            Ish.MISPAR_TELEPHONE_KAVI = mimshak.KoteretKovetz.NetuneiGoremSholech.MISPARTELEPHONEKAVIISHKESHERSHOLECH;
            Ish.SHEM_MISHPACHA = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMMISHPACHAISHKESHERSHOLECH;
            Ish.SHEM_PRATI = mimshak.KoteretKovetz.NetuneiGoremSholech.SHEMPRATIISHKESHERSHOLECH;

            kovetz.IshKesherYeshutYatzrans.Add(Ish);


        }
    }
}
