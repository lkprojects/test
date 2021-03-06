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
    
    public partial class Kisui
    {
        public Kisui()
        {
            this.Mevutaches = new HashSet<Mevutach>();
            this.Miktsoa_Isuk_Tachviv = new HashSet<Miktsoa_Isuk_Tachviv>();
            this.Mutavs = new HashSet<Mutav>();
            this.Tosafots = new HashSet<Tosafot>();
        }
    
        public int Kisui_Id { get; set; }
        public Nullable<int> HeshbonOPolisa_Id { get; set; }
        public string MISPAR_KISUI_BE_YATZRAN { get; set; }
        public string SHEM_KISUI_YATZRAN { get; set; }
        public Nullable<int> SUG_KISUI_ETZEL_YATZRAN { get; set; }
        public string Mutzar_KOD_MIUTZAR_LAKISUY { get; set; }
        public Nullable<int> Mutzar_SUG_MEVUTACH { get; set; }
        public Nullable<System.DateTime> Mutzar_TAARICH_TCHILAT_KISUY { get; set; }
        public Nullable<System.DateTime> Mutzar_TAARICH_TOM_KISUY { get; set; }
        public Nullable<System.DateTime> Mutzar_TAARICH_HAFSAKAT_TASHLUM { get; set; }
        public Nullable<decimal> Mutzar_ACHUZ_ME_SCM_BTH_YESODI { get; set; }
        public Nullable<decimal> Mutzar_ACHUZ_MESACHAR { get; set; }
        public Nullable<int> Mutzar_OFEN_TASHLUM_SCHUM_BITUACH { get; set; }
        public Nullable<decimal> Mutzar_SCHUM_BITUACH { get; set; }
        public Nullable<int> Mutzar_MESHALEM_HAKISUY { get; set; }
        public Nullable<int> Mutzar_KOD_ISHUN { get; set; }
        public Nullable<int> Mutzar_IND_CHITUM { get; set; }
        public Nullable<System.DateTime> Mutzar_TAARICH_CHITUM { get; set; }
        public Nullable<int> Mutzar_HACHRAGA { get; set; }
        public Nullable<int> Mutzar_SUG_HACHRAGA { get; set; }
        public Nullable<int> Mutzar_TKUFAT_ACHSHARA { get; set; }
        public Nullable<int> Mutzar_TKUFAT_HAMTANA_CHODASHIM { get; set; }
        public Nullable<int> Mutzar_HANACHA { get; set; }
        public Nullable<int> Mutzar_HATNAYA_LAHANACHA_DMEI_BITUAH { get; set; }
        public Nullable<decimal> Mutzar_DMEI_BITUAH_LETASHLUM_BAPOAL { get; set; }
        public Nullable<int> Mutzar_TADIRUT_SHINUY_DMEI_HABITUAH_BESHANIM { get; set; }
        public Nullable<System.DateTime> Mutzar_TAARICH_IDKUN_HABA_SHEL_DMEI_HABITUAH { get; set; }
        public Nullable<decimal> KerenPensia_ALUT_KISUI_NECHUT { get; set; }
        public Nullable<decimal> KerenPensia_ALUT_KISUI_PNS_SHRM_NECHE { get; set; }
        public Nullable<decimal> KerenPensia_SHEUR_KISUY_NECHUT { get; set; }
        public Nullable<decimal> KerenPensia_SACHAR_KOVEA_LE_NECHUT_VE_SHEERIM { get; set; }
        public Nullable<System.DateTime> KerenPensia_TAARICH_MASKORET_NECHUT_VE_SHEERIM { get; set; }
        public Nullable<decimal> KerenPensia_SACH_PENSIAT_NECHUT { get; set; }
        public Nullable<decimal> KerenPensia_ALUT_KISUY_SHEERIM { get; set; }
        public Nullable<decimal> KerenPensia_SHIUR_KISUY_YATOM { get; set; }
        public Nullable<decimal> KerenPensia_KITZBAT_SHEERIM_LEALMAN_O_ALMANA { get; set; }
        public Nullable<decimal> KerenPensia_KITZBAT_SHEERIM_LEYATOM { get; set; }
        public Nullable<decimal> KerenPensia_KITZBAT_SHEERIM_LEHORE_NITMACH { get; set; }
        public Nullable<decimal> KerenPensia_SHIUR_KISUY_ALMAN_O_ALMANA { get; set; }
        public Nullable<decimal> KerenPensia_SHIUR_KISUY_HORE_NITMACH { get; set; }
        public Nullable<decimal> KerenPensia_GIL_PRISHA_LEPENSIYAT_ZIKNA { get; set; }
        public Nullable<decimal> KerenPensia_SACH_PENSIYAT_ALMAN_O_ALMANA { get; set; }
        public Nullable<int> KerenPensia_MISPAR_HODSHEI_HAVERUT_BEKEREN_HAPENSIYA { get; set; }
        public Nullable<decimal> KerenPensia_MENAT_PENSIA_TZVURA { get; set; }
        public Nullable<decimal> KerenPensia_AHUZ_PENSIYA_TZVURA { get; set; }
        public Nullable<System.DateTime> KerenPensia_TAARICH_TCHILAT_HAVERUT { get; set; }
        public Nullable<System.DateTime> KerenPensia_TAARICH_ERECH_LANENTUNIM { get; set; }
        public Nullable<int> KerenPensia_HATAVA_BITUCHIT { get; set; }
        public string Yesodi_KOD_MUTZAR_LEFI_KIDUD_ACHID_LAYESODI { get; set; }
        public Nullable<int> Yesodi_SUG_HATZMADA_SCHUM_BITUAH { get; set; }
        public Nullable<int> Yesodi_SUG_MASLUL_LEBITUAH { get; set; }
        public Nullable<int> Yesodi_IND_SCHUM_BITUAH_KOLEL_CHISACHON { get; set; }
        public Nullable<decimal> Yesodi_SCHUM_BITUACH_LEMASLUL { get; set; }
        public Nullable<int> Yesodi_MISPAR_MASKOROT { get; set; }
        public Nullable<decimal> Yesodi_ACHUZ_HAKTZAA_LE_CHISACHON { get; set; }
        public Nullable<decimal> Yesodi_TIKRAT_GAG_HATAM_LEMIKRE_MAVET { get; set; }
        public Nullable<decimal> Yesodi_TIKRAT_GAG_HATAM_LE_O_K_A { get; set; }
        public Nullable<decimal> Yesodi_SCHUM_BITUAH_LEMAVET { get; set; }
    
        public virtual ICollection<Mevutach> Mevutaches { get; set; }
        public virtual ICollection<Miktsoa_Isuk_Tachviv> Miktsoa_Isuk_Tachviv { get; set; }
        public virtual ICollection<Mutav> Mutavs { get; set; }
        public virtual ICollection<Tosafot> Tosafots { get; set; }
        public virtual HeshbonOPolisa HeshbonOPolisa { get; set; }
    }
}
