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
    
    public partial class PerutHafkadaAchrona
    {
        public int PerutHafkadaAchrona_Id { get; set; }
        public int HafkadaAchrona_Id { get; set; }
        public Nullable<int> KOD_SUG_HAFKADA { get; set; }
        public Nullable<int> SUG_HAFRASHA { get; set; }
        public Nullable<int> SUG_MAFKID { get; set; }
        public Nullable<decimal> SCHUM_HAFKADA_SHESHULAM { get; set; }
        public Nullable<System.DateTime> CHODESH_SACHAR { get; set; }
    
        public virtual HafkadaAchrona HafkadaAchrona { get; set; }
    }
}
