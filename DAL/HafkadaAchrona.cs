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
    
    public partial class HafkadaAchrona
    {
        public HafkadaAchrona()
        {
            this.PerutHafkadaAchronas = new HashSet<PerutHafkadaAchrona>();
        }
    
        public int HafkadaAchrona_Id { get; set; }
        public int PirteiTaktziv_Id { get; set; }
        public Nullable<System.DateTime> TAARICH_HAFKADA_ACHARON { get; set; }
        public Nullable<decimal> TOTAL_HAFKADA { get; set; }
        public Nullable<System.DateTime> TAARICH_ERECH_HAFKADA { get; set; }
        public Nullable<int> SUG_HAFKADA { get; set; }
        public Nullable<decimal> TOTAL_HAFKADA_ACHRONA { get; set; }
    
        public virtual PirteiTaktziv PirteiTaktziv { get; set; }
        public virtual ICollection<PerutHafkadaAchrona> PerutHafkadaAchronas { get; set; }
    }
}
