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
    
    public partial class Customer
    {
        public Customer()
        {
            this.HeshbonOPolisas = new HashSet<HeshbonOPolisa>();
        }
    
        public int Customer_Id { get; set; }
        public string MISPAR_ZIHUY_LAKOACH { get; set; }
        public int SUG_MEZAHE_LAKOACH { get; set; }
        public Nullable<int> KOD_MEZAHE_YATZRAN { get; set; }
        public Nullable<int> KOD_MEZAHE_METAFEL { get; set; }
        public Nullable<int> SUG_MUTZAR_PENSIONI { get; set; }
        public string SHEM_PRATI { get; set; }
        public string SHEM_MISHPACHA_KODEM { get; set; }
        public string SHEM_MISHPACHA { get; set; }
        public int MIN { get; set; }
        public Nullable<System.DateTime> TAARICH_LEYDA { get; set; }
        public int PTIRA { get; set; }
        public Nullable<System.DateTime> TAARICH_PTIRA { get; set; }
        public int MATZAV_MISHPACHTI { get; set; }
        public string ERETZ { get; set; }
        public string SHEM_YISHUV { get; set; }
        public Nullable<int> SEMEL_YESHUV { get; set; }
        public string SHEM_RECHOV { get; set; }
        public string MISPAR_BAIT { get; set; }
        public string MISPAR_KNISA { get; set; }
        public Nullable<int> MISPAR_DIRA { get; set; }
        public Nullable<int> MIKUD { get; set; }
        public Nullable<int> TA_DOAR { get; set; }
        public string MISPAR_TELEPHONE_KAVI { get; set; }
        public string MISPAR_SHLUCHA { get; set; }
        public string MISPAR_CELLULARI { get; set; }
        public string MISPAR_FAX { get; set; }
        public string E_MAIL { get; set; }
        public string HEAROT { get; set; }
        public Nullable<int> MISPAR_YELADIM { get; set; }
    
        public virtual Metafel Metafel { get; set; }
        public virtual ICollection<HeshbonOPolisa> HeshbonOPolisas { get; set; }
        public virtual Yatzran Yatzran { get; set; }
    }
}
