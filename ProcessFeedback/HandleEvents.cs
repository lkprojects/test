using DAL;
using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HandleEvents
{
    private DAL.DAL DALobj;
    private Client clientRec;
    private Events.Mimshak EventObj = new Events.Mimshak();

    private int numerator;

    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }
    

    private MimshakEruim mimshak;
    public MimshakEruim Mimshak
    {
        get { return mimshak; }
        set { mimshak = value; }
    }
        
    // constructor
    public HandleEvents(MimshakEruim eruim, int fileNumerator)
    {
        mimshak = eruim;
        numerator = fileNumerator;
    }
    public HandleEvents()
    {
    }

    public MimshakEruim PrepareEventObject(Client clientRec, int fileNumerator)
    {
        numerator = fileNumerator;
        PrepareEventObject(clientRec);
        return EventObj;
    }

    public MimshakEruim PrepareEventObject(Client clientRec)
    {
        EventObj = new MimshakEruim();
        SetKoteretKovetz(EventObj.KoteretKovetz, numerator);
        EventObj.GufHamimshak = new MimshakYeshutGoremPoneLemislaka[100];
        SetGufMimshak(EventObj.GufHamimshak);
        SetReshumatSgira(EventObj.ReshumatSgira);
        return EventObj;
    }

    private void SetReshumatSgira(MimshakReshumatSgira ReshumatSgira)
    {
        ReshumatSgira = new MimshakReshumatSgira();
        ReshumatSgira.MISPARBAKASHOT = 1;
        ReshumatSgira.MISPARYESHUYUTLAKOACHBAKOVETZ = 1;
    }

    private void SetGufMimshak(MimshakYeshutGoremPoneLemislaka[] mimshakYeshutGoremPoneLemislaka)
    {
        int i = 0;
        mimshakYeshutGoremPoneLemislaka[i] = new MimshakYeshutGoremPoneLemislaka();
        mimshakYeshutGoremPoneLemislaka[i].EMAILPONELEMISLAKA = DALobj.GetConfigParam("E-MAIL-PONE-LEMISLAKA");
        mimshakYeshutGoremPoneLemislaka[i].MISPARCELLULARI = DALobj.GetConfigParam("MISPAR-CELLULARI");
        mimshakYeshutGoremPoneLemislaka[i].MISPARMEZAHEMETAFEL = DALobj.GetConfigParam("MISPAR-MEZAHE-METAFEL");
        mimshakYeshutGoremPoneLemislaka[i].MISPARMEZAHEPONE = DALobj.GetConfigParam("MISPAR-MEZAHE-PONE");
        mimshakYeshutGoremPoneLemislaka[i].MISPARTELEPHONEKAVIPONELEMISLAKA = DALobj.GetConfigParam("MISPAR-TELEPHONE-KAVI-PONE-LEMISLAKA");
        mimshakYeshutGoremPoneLemislaka[i].SHEMGOREMPONE = DALobj.GetConfigParam("SHEM-GOREM-PONE");
        mimshakYeshutGoremPoneLemislaka[i].SHEMMISHPACHAPONELEMISLAKA = DALobj.GetConfigParam("SHEM-MISHPACHA-PONE-LEMISLAKA");
        mimshakYeshutGoremPoneLemislaka[i].SHEMPRATIPONELEMISLAKA = DALobj.GetConfigParam("SHEM-PRATI-PONE-LEMISLAKA");
        mimshakYeshutGoremPoneLemislaka[i].SUGKODMEZAHEPONE = Convert.ToInt32(DALobj.GetConfigParam("SUG-KOD-MEZAHE-PONE"));
        mimshakYeshutGoremPoneLemislaka[i].SUGPONE = Convert.ToInt32(DALobj.GetConfigParam("SUG-PONE"));
        mimshakYeshutGoremPoneLemislaka[i].YeshutLakoachMeidaBsisi = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisi[100];
        SetLakoach(mimshakYeshutGoremPoneLemislaka[i].YeshutLakoachMeidaBsisi);
    }

    private void SetLakoach(MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisi[] Lakoach)
    {
        int i = 0;
        Lakoach[i] = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisi();

        // Need to retrieve Lakoach information from the DB into lakoachRec
        Lakoach[i].KODMEDINA = "0"; // What is this?
        Lakoach[i].MISPARMEZAHELAKOACH = clientRec.TeudatZehut;

        //Lakoach[i].SHEMMAASIK = lakoachRec.YeshutMaasiks.Last().SHEM_MAASIK; // Get latest employer.
        Lakoach[i].SHEMMISHPACHALAKOACH = clientRec.LastName;
        Lakoach[i].SHEMPRATILAKOACH = clientRec.FirstName;
        Lakoach[i].SUGMEZAHELAKOACH = 3; // Identify by "teudat zehut".
        Lakoach[i].SUGLAKOACH = 1; // 1= Amit/Mevutach ;  2= Maasik
        Lakoach[i].Eirua = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEirua[100];
        SetEirua(Lakoach[i].Eirua);
    }

    private void SetEirua(MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEirua[] Eirua)
    {
        int i = 0;
        int fileNumber = 123;
        Eirua[i] = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEirua();
        Eirua[i].KodEirua = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEiruaKodEirua();

        Eirua[i].KodEirua.KODEIRUA = 9100; // Request for information from ALL the Mosdi'im.
        Eirua[i].KodEirua.MISPARMEZAHERESHUMA = fileNumber.ToString("000000000000000000000000000") +
                                                clientRec.TeudatZehut.PadLeft(16, '0') +
                                                "0000000000000000" + // Will have the employee in case the event is 9300.
                                                Eirua[i].KodEirua.KODEIRUA.ToString("0000") +
                                                numerator.ToString("0000");

        Eirua[i].KodEirua.MISPARMISLAKA = "00000000-0000-0000-0000-000000000000";
        Eirua[i].KodEirua.MISPARMISLAKALPNIIYACHOZORET = "00000000-0000-0000-0000-000000000000";
        Eirua[i].KodEirua.OFENHAAVARATMEIDAMIMISLLAKALELAKOACH = 1;
        //Eirua[i].KodEirua.RESERVAMISLAKA
        //Eirua[i].KodEirua.TAARICHNECHONUTMEIDA
        //Eirua[i].KodEirua.ASMACHTAMISLAKA
        Eirua[i].KodEirua.mismachim = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEiruaKodEiruaMismachim();
        Eirua[i].KodEirua.mismachim.mismachimNilvimBeramatEirua = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEiruaKodEiruaMismachimMismachimNilvimBeramatEirua();
        Eirua[i].KodEirua.mismachim.mismachimNilvimBeramatEirua.KOLMISMACHIMTZURFU = 1; // 1= Yes ; 2= No
        Eirua[i].KodEirua.mismachim.mismachimNilvimBeramatEirua.TFASIMDRUSHIMCHATUMIM = 1;  // 1= Yes ; 2= No

        Eirua[i].KodEirua.Mutzar = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEiruaKodEiruaMutzar();
        Eirua[i].KodEirua.Mutzar.NetuneiMutzar = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEiruaKodEiruaMutzarNetuneiMutzar();
        Eirua[i].KodEirua.Mutzar.NetuneiMutzar.KODMEZAHEYATZRAN = DALobj.GetConfigParam("KOD-MEZAHE-YATZRAN");
        //Eirua[i].KodEirua.Mutzar.NetuneiMutzar.SUGMUTZARPENSIONI


        //Eirua[i].KodEirua.Mutzar.NetuneiMutzar.BakashaLekabalatMeidaPitzuim
        Eirua[i].KodEirua.YipuiKoach = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEiruaKodEiruaYipuiKoach();
        Eirua[i].KodEirua.YipuiKoach.BakashatMefitzLeinianYipuiKoach = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEiruaKodEiruaYipuiKoachBakashatMefitzLeinianYipuiKoach();
        Eirua[i].KodEirua.YipuiKoach.BakashatMefitzLeinianYipuiKoach.TZURAFMISMACHYIPUIKOACH = 1; // 1= Yes ; 2= No
        // Eirua[i].KodEirua.YipuiKoach.BakashatMefitzLeinianYipuiKoach.KODZIHUIYIPUIKOACHBEMISLAKA =  DALobj.GetConfigParam("KOD-ZIHUI-YIPUI-KOACH-BEMISLAKA");
        Eirua[i].KodEirua.YipuiKoach.BakashatMefitzLeinianYipuiKoach.MISMACHZIHUI = 1; // 1= Yes ; 2= No (Does the Yipuy Koach done with a secured site?)

        // Sug bakashat Mefitz Leeniany Ipui Koach
        // 1 = הרשאה חד פעמית לבעל רישיון לקבל מידע אודות כל המוצרים הפנסיונים של לקוח למעט אלו המוחרגים במפורש בבלוק מוצר מוחרג
        // 2 = הרשאה מתמשכת לבעל רישיון לקבלת מידע והעברת בקשות לביצוע פעולות בכל המוצרים הפנסיונים שברשות הלקוח למעט אלו המוחרגים במפורש בבלוק מוצר מוחרג
        // 3 = "הרשאה מתמשכת לבעל רישיון לקבלת מידע והעברת בקשות לביצוע פעולות במוצרים המפורטים בבלוק "הרשאה ברמת מוצר
        Eirua[i].KodEirua.YipuiKoach.BakashatMefitzLeinianYipuiKoach.SUGBAKASHATMEFITZLEEINIANYIPUIKOACH = 1;

        Eirua[i].KodEirua.YipuiKoach.BakashatMefitzLeinianYipuiKoach.KAYAMMUTZARMUCHRAG = 2; // 1= Yes ; 2= No
        Eirua[i].KodEirua.YipuiKoach.BakashatMefitzLeinianYipuiKoach.TAARICHCHTIMALAKOACH = clientRec.InsertDate.ToString("yyyyMMdd");


    }

    private void SetKoteretKovetz(MimshakKoteretKovetz koteret, int numerator)
    {
        koteret = new MimshakKoteretKovetz();
        koteret.SUGMIMSHAK = 6;
        koteret.KODSVIVATAVODA = Convert.ToInt32(DALobj.GetConfigParam("KOD-SVIVAT-AVODA"));
        numerator = numerator % 10000;
        koteret.MISPARHAKOVETZ = DateTime.Now.ToString("yyyyMMddHHmmss") + DALobj.GetConfigParam("MISPAR-ZIHUI-SHOLECH") + numerator.ToString("0000");
        koteret.MISPARSIDURI = numerator;
        koteret.TAARICHBITZUA = DateTime.Now.ToString("yyyyMMddHHmmss");

        koteret.NetuneiGoremSholech = new MimshakKoteretKovetzNetuneiGoremSholech();
        koteret.NetuneiGoremSholech.EMAILISHKESHERSHOLECH = DALobj.GetConfigParam("E-MAIL-ISH-KESHER-SHOLECH");
        koteret.NetuneiGoremSholech.KODSHOLECH = Convert.ToInt32(DALobj.GetConfigParam("KOD-SHOLECH"));
        koteret.NetuneiGoremSholech.MISPARCELLULARIISHKESHERSHOLECH = DALobj.GetConfigParam("MISPAR-CELLULARI-ISH-KESHER-SHOLECH");
        koteret.NetuneiGoremSholech.MISPARTELEPHONEKAVIISHKESHERSHOLECH = DALobj.GetConfigParam("MISPAR-TELEPHONE-KAVI-ISH-KESHER-SHOLECH");
        koteret.NetuneiGoremSholech.MISPARZIHUISHOLECH = DALobj.GetConfigParam("MISPAR-ZIHUI-SHOLECH");
        koteret.NetuneiGoremSholech.SHEMGOREMSHOLECH = DALobj.GetConfigParam("SHEM-GOREM-SHOLECH");
        koteret.NetuneiGoremSholech.SHEMMISHPACHAISHKESHERSHOLECH = DALobj.GetConfigParam("SHEM-MISHPACHA-ISH-KESHER-SHOLECH");
        koteret.NetuneiGoremSholech.SHEMPRATIISHKESHERSHOLECH = DALobj.GetConfigParam("SHEM-PRATI-ISH-KESHER-SHOLECH");
        koteret.NetuneiGoremSholech.SUGMEZAHESHOLECH = Convert.ToInt32(DALobj.GetConfigParam("SUG-MEZAHE-SHOLECH"));

        koteret.NetuneiGoremNimaan = new MimshakKoteretKovetzNetuneiGoremNimaan();
        koteret.NetuneiGoremNimaan.KODNIMAAN = Convert.ToInt32(DALobj.GetConfigParam("KOD-NIMAAN"));
        koteret.NetuneiGoremNimaan.MISPARZIHUIETZELYATZRANNIMAAN = DALobj.GetConfigParam("MISPAR-ZIHUI-ETZEL-YATZRAN-NIMAAN");
        koteret.NetuneiGoremNimaan.MISPARZIHUINIMAAN = DALobj.GetConfigParam("MISPAR-ZIHUI-NIMAAN");
        koteret.NetuneiGoremNimaan.SUGMEZAHENIMAAN = Convert.ToInt32(DALobj.GetConfigParam("SUG-MEZAHE-NIMAAN"));

    }
}
