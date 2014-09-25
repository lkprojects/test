//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class HeshbonOPolisa
    {
        public HeshbonOPolisa()
        {
            this.Halvaas = new HashSet<Halvaa>();
            this.HeshbonKovetzs = new HashSet<HeshbonKovetz>();
            this.Kisuis = new HashSet<Kisui>();
            this.MeyupeKoaches = new HashSet<MeyupeKoach>();
            this.Mitryots = new HashSet<Mitryot>();
            this.PirteiTaktzivs = new HashSet<PirteiTaktziv>();
            this.Sheers = new HashSet<Sheer>();
            this.Tvias = new HashSet<Tvia>();
            this.YitraLefiGilPrishas = new HashSet<YitraLefiGilPrisha>();
        }
    
        public int HeshbonOPolisa_Id { get; set; }
        public int KOD_MEZAHE_YATZRAN { get; set; }
        public Nullable<int> KOD_MEZAHE_METAFEL { get; set; }
        public int SUG_MUTZAR_PENSIONI { get; set; }
        public string MISPAR_ZIHUY_LAKOACH { get; set; }
        public int SUG_MEZAHE_LAKOACH { get; set; }
        public string MISPAR_MISLAKA { get; set; }
        public string ASMACHTA_MEKORIT { get; set; }
        public string MISPAR_POLISA_O_HESHBON { get; set; }
        public string MPR_MEFITZ_BE_YATZRAN { get; set; }
        public Nullable<System.DateTime> TAARICH_NECHONUT { get; set; }
        public Nullable<System.DateTime> TAARICH_HITZTARFUT_MUTZAR { get; set; }
        public Nullable<System.DateTime> TAARICH_HITZTARFUT_RISHON { get; set; }
        public Nullable<int> SUG_KEREN_PENSIA { get; set; }
        public Nullable<int> PENSIA_VATIKA_O_HADASHA { get; set; }
        public Nullable<System.DateTime> TAARICH_IDKUN_STATUS { get; set; }
        public int STATUS_POLISA_O_CHESHBON { get; set; }
        public int SUG_POLISA { get; set; }
        public int SUG_TOCHNIT_O_CHESHBON { get; set; }
        public string MASLUL_BITUACH_BAKEREN_PENSIA { get; set; }
        public string SHEM_MASLUL_HABITUAH { get; set; }
        public int ShiabudIkul_HUTAL_SHIABUD { get; set; }
        public int ShiabudIkul_HUTAL_IKUL { get; set; }
        public string AmitOMevutach_MISPAR_ZIHUY { get; set; }
        public Nullable<decimal> Tsua_SHEUR_TSUA_NETO { get; set; }
        public Nullable<decimal> Tsua_SHEUR_TSUA_BRUTO_CHS_1 { get; set; }
        public Nullable<decimal> Tsua_ACHUZ_TSUA_BRUTO_CHS_2 { get; set; }
        public string Mishloach_ERETZ { get; set; }
        public string Mishloach_SHEM_YISHUV { get; set; }
        public Nullable<int> Mishloach_SEMEL_YESHUV { get; set; }
        public string Mishloach_SHEM_RECHOV { get; set; }
        public string Mishloach_MISPAR_BAIT { get; set; }
        public string Mishloach_MISPAR_KNISA { get; set; }
        public Nullable<int> Mishloach_MISPAR_DIRA { get; set; }
        public Nullable<int> Mishloach_MIKUD { get; set; }
        public Nullable<int> Mishloach_TA_DOAR { get; set; }
    
        public virtual Yatzran Yatzran { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Halvaa> Halvaas { get; set; }
        public virtual ICollection<HeshbonKovetz> HeshbonKovetzs { get; set; }
        public virtual Metafel Metafel { get; set; }
        public virtual ICollection<Kisui> Kisuis { get; set; }
        public virtual ICollection<MeyupeKoach> MeyupeKoaches { get; set; }
        public virtual ICollection<Mitryot> Mitryots { get; set; }
        public virtual ICollection<PirteiTaktziv> PirteiTaktzivs { get; set; }
        public virtual ICollection<Sheer> Sheers { get; set; }
        public virtual ICollection<Tvia> Tvias { get; set; }
        public virtual ICollection<YitraLefiGilPrisha> YitraLefiGilPrishas { get; set; }
    }
}
