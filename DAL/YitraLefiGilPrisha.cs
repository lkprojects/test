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
    
    public partial class YitraLefiGilPrisha
    {
        public YitraLefiGilPrisha()
        {
            this.Kupas = new HashSet<Kupa>();
        }
    
        public int YitraLefiGilPrisha_Id { get; set; }
        public Nullable<int> HeshbonOPolisa_Id { get; set; }
        public Nullable<decimal> GIL_PRISHA { get; set; }
        public Nullable<decimal> TOTAL_CHISACHON_MITZTABER_TZAFUY { get; set; }
        public Nullable<decimal> TZVIRAT_CHISACHON_CHAZUYA_LELO_PREMIYOT { get; set; }
        public Nullable<decimal> SHEUR_PNS_ZIKNA_TZFUYA { get; set; }
    
        public virtual HeshbonOPolisa HeshbonOPolisa { get; set; }
        public virtual ICollection<Kupa> Kupas { get; set; }
    }
}
