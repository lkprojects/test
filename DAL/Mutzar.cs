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
    
    public partial class Mutzar
    {
        public Mutzar()
        {
            this.HeshbonOPolisas = new HashSet<HeshbonOPolisa>();
            this.YeshutMaasiks = new HashSet<YeshutMaasik>();
            this.MutzarKovetzs = new HashSet<MutzarKovetz>();
        }
    
        public int Mutzar_Id { get; set; }
        public int KOD_MEZAHE_YATZRAN { get; set; }
        public Nullable<int> KOD_MEZAHE_METAFEL { get; set; }
        public int SUG_MUTZAR_PENSIONI { get; set; }
        public string MISPAR_MISLAKA { get; set; }
        public int Lakoach_SUG_MEZAHE_LAKOACH { get; set; }
        public string Lakoach_MISPAR_ZIHUY_LAKOACH { get; set; }
        public string Lakoach_SHEM_PRATI { get; set; }
        public string Lakoach_SHEM_MISHPACHA_KODEM { get; set; }
        public string Lakoach_SHEM_MISHPACHA { get; set; }
        public int Lakoach_MIN { get; set; }
        public Nullable<System.DateTime> Lakoach_TAARICH_LEYDA { get; set; }
        public int Lakoach_PTIRA { get; set; }
        public Nullable<System.DateTime> Lakoach_TAARICH_PTIRA { get; set; }
        public int Lakoach_MATZAV_MISHPACHTI { get; set; }
        public string Lakoach_ERETZ { get; set; }
        public string Lakoach_SHEM_YISHUV { get; set; }
        public Nullable<int> Lakoach_SEMEL_YESHUV { get; set; }
        public string Lakoach_SHEM_RECHOV { get; set; }
        public string Lakoach_MISPAR_BAIT { get; set; }
        public string Lakoach_MISPAR_KNISA { get; set; }
        public Nullable<int> Lakoach_MISPAR_DIRA { get; set; }
        public Nullable<int> Lakoach_MIKUD { get; set; }
        public Nullable<int> Lakoach_TA_DOAR { get; set; }
        public string Lakoach_MISPAR_TELEPHONE_KAVI { get; set; }
        public string Lakoach_MISPAR_SHLUCHA { get; set; }
        public string Lakoach_MISPAR_CELLULARI { get; set; }
        public string Lakoach_MISPAR_FAX { get; set; }
        public string Lakoach_E_MAIL { get; set; }
        public string Lakoach_HEAROT { get; set; }
        public Nullable<int> Lakoach_MISPAR_YELADIM { get; set; }
    
        public virtual ICollection<HeshbonOPolisa> HeshbonOPolisas { get; set; }
        public virtual ICollection<YeshutMaasik> YeshutMaasiks { get; set; }
        public virtual ICollection<MutzarKovetz> MutzarKovetzs { get; set; }
    }
}
