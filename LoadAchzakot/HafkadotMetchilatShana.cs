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
    
    public partial class HafkadotMetchilatShana
    {
        public int HafkadotMetchilatShana_Id { get; set; }
        public int PirteiTaktziv_Id { get; set; }
        public Nullable<System.DateTime> TAARICH_ERECH_HAFKADA { get; set; }
        public Nullable<int> KOD_SUG_HAFKADA { get; set; }
        public Nullable<int> SUG_HAFRASHA { get; set; }
        public Nullable<int> SUG_MAFKID { get; set; }
        public Nullable<decimal> SCHUM_HAFKADA_SHESHULAM { get; set; }
        public Nullable<System.DateTime> CHODESH_SACHAR { get; set; }
        public Nullable<System.DateTime> ZMAN_PERAON { get; set; }
    
        public virtual PirteiTaktziv PirteiTaktziv { get; set; }
    }
}
