using DAL;
using Events;
using MislakaInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HandleEvents
{
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    private DAL.DAL DALobj = new DAL.DAL("Events");
    private List<Client> clientList = new List<Client>();
    private Events.Mimshak mimshakEvent = new Events.Mimshak();
    private Kovetz fileRecord = new Kovetz();

    public Kovetz FileRecord 
    {
        get { return fileRecord; }
    }

    private int kodEirua;

    private int numerator;

    public Events.Mimshak MimshakEvent
    {
        get { return mimshakEvent; }
        set { mimshakEvent = value; }
    }

    public List<Client> ClientList
    {
        get { return clientList; }
        set { clientList = value; }
    }


    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }


    private Events.Mimshak mimshak;
    public Events.Mimshak Mimshak
    {
        get { return mimshak; }
        set { mimshak = value; }
    }
        
    // constructor
    public HandleEvents(int fileNumerator)
    {
        numerator = fileNumerator;
    }

    // constructor
    public HandleEvents(Events.Mimshak eruim, int fileNumerator)
    {
        mimshak = eruim;
        numerator = fileNumerator;
    }

    public void PrepareEventObject(List<Client> clientList)
    {
        this.clientList = clientList;
        mimshakEvent = new Events.Mimshak();
        mimshakEvent.KoteretKovetz = new MimshakKoteretKovetz();
        SetKoteretKovetz(mimshakEvent.KoteretKovetz);
        mimshakEvent.GufHamimshak = new MimshakYeshutGoremPoneLemislaka[100];
        SetGufMimshak(mimshakEvent.GufHamimshak);
        SetReshumatSgira(mimshakEvent.ReshumatSgira);
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
        for (int i = 0; i < clientList.Count; i++)
        {
            
            Lakoach[i] = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisi();

            // Need to retrieve Lakoach information from the DB into lakoachRec
            Lakoach[i].KODMEDINA = "0"; // What is this?
            Lakoach[i].MISPARMEZAHELAKOACH = clientList[i].TeudatZehut;
            log.Info("Producing event for client - TZ #" + clientList[i].TeudatZehut);

            //Lakoach[i].SHEMMAASIK = lakoachRec.YeshutMaasiks.Last().SHEM_MAASIK; // Get latest employer.
            Lakoach[i].SHEMMISHPACHALAKOACH = clientList[i].LastName;
            Lakoach[i].SHEMPRATILAKOACH = clientList[i].FirstName;
            Lakoach[i].SUGMEZAHELAKOACH = 3; // Identify by "teudat zehut".
            Lakoach[i].SUGLAKOACH = 1; // 1= Amit/Mevutach ;  2= Maasik
            Lakoach[i].Eirua = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEirua[100];
            SetEirua(Lakoach[i].Eirua, i);
        }
    }

    private void SetEirua(MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEirua[] Eirua, int clientNo)
    {
        int i = 0;
        string fileNumber = DateTime.Now.ToString("yyyyMMddHHmmss") + DALobj.GetConfigParam("MISPAR-ZIHUI-SHOLECH").PadLeft(9,'0') + numerator.ToString("0000");
        Eirua[i] = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEirua();
        Eirua[i].KodEirua = new MimshakYeshutGoremPoneLemislakaYeshutLakoachMeidaBsisiEiruaKodEirua();

        Eirua[i].KodEirua.KODEIRUA = (int)clientList[clientNo].LastKodEirua;
        Eirua[i].KodEirua.MISPARMEZAHERESHUMA = fileNumber +
                                                clientList[clientNo].TeudatZehut.PadLeft(16, '0') +
                                                "0000000000000000" + // Will have the employee in case the event is 9300.
                                                Eirua[i].KodEirua.KODEIRUA.ToString("0000") +
                                                clientNo.ToString("0000");
        clientList[clientNo].LastStatus = (byte)ClientStatus.EventSent;
        clientList[clientNo].LastRecordNumber = Eirua[i].KodEirua.MISPARMEZAHERESHUMA;
        log.Debug(clientList[clientNo].LastStatus.ToString());
        log.Debug(clientList[clientNo].LastRecordNumber);

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
        Eirua[i].KodEirua.YipuiKoach.BakashatMefitzLeinianYipuiKoach.TAARICHCHTIMALAKOACH = clientList[clientNo].InsertDate.ToString("yyyyMMdd");


    }

    private void SetKoteretKovetz(MimshakKoteretKovetz koteret)
    {
        koteret.SUGMIMSHAK = 6;
        koteret.KODSVIVATAVODA = Convert.ToInt32(DALobj.GetConfigParam("KOD-SVIVAT-AVODA"));
        numerator = numerator % 10000;
        koteret.MISPARHAKOVETZ = DateTime.Now.ToString("yyyyMMddHHmmss") + DALobj.GetConfigParam("MISPAR-ZIHUI-SHOLECH").PadLeft(9, '0') + numerator.ToString("0000");
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

    internal void SerializeToFile(string fileName)
    {

        // Write the events to a file
        System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Events.Mimshak));
        System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
        try
        {
            writer.Serialize(file, mimshakEvent);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.InnerException.Message);
            log.Error(ex.InnerException.Message, ex);
            file.Close();
            return;
        }
        file.Close();
    }

    internal void SaveKovetzRecord(string fileName, MislakaFileName mislakaFileName)
    {
        fileRecord.MISPAR_GIRSAT_XML = mimshakEvent.KoteretKovetz.MISPARGIRSATXML.ToString();
        fileRecord.MISPAR_HAKOVETZ = mimshakEvent.KoteretKovetz.MISPARHAKOVETZ;
        fileRecord.KOD_SVIVAT_AVODA = mimshakEvent.KoteretKovetz.KODSVIVATAVODA;
        fileRecord.SUG_MIMSHAK = mimshakEvent.KoteretKovetz.SUGMIMSHAK;
        fileRecord.TAARICH_BITZUA = Common.ConvertDatetime(mimshakEvent.KoteretKovetz.TAARICHBITZUA);
        fileRecord.MISPAR_GIRSAT_XML = "001";
        fileRecord.SHEM_SHOLEACH = "Events 9100";
        fileRecord.FileName = fileName;
        fileRecord.MEZAHE_HAAVARA = mislakaFileName.GetMislakaFileName();
        fileRecord.Yatzran_SHEM_YATZRAN = "All";
        fileRecord.LoadDate = DateTime.Now;
        fileRecord.KIVUN_MIMSHAK_XML = 5;

        for (int i=0; i< clientList.Count ;i++)
        {
            clientList[i].LastFileNumber = fileRecord.MISPAR_HAKOVETZ;
        }
    }
}
