//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoadAchzakot
{
    using System;
    using System.Collections.Generic;
    
    public partial class IshKesherYeshutMetafel
    {
        public int IshKesherYeshutMetafel_Id { get; set; }
        public int YeshutMetafel_Id { get; set; }
        public string SHEM_PRATI { get; set; }
        public string SHEM_MISHPACHA { get; set; }
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
    
        public virtual YeshutMetafel YeshutMetafel { get; set; }
    }
}