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
    
    public partial class MasluleiHashkaa
    {
        public int MasluleiHashkaa_Id { get; set; }
        public int PirteiTaktziv_Id { get; set; }
        public Nullable<int> KOD_SUG_MASLUL { get; set; }
        public Nullable<int> KOD_SUG_HAFRASHA { get; set; }
        public Nullable<decimal> ACHUZ_HAFKADA_LEHASHKAA { get; set; }
        public Nullable<decimal> SCHUM_TZVIRA_BAMASLUL { get; set; }
        public string SHEM_MASLUL_HASHKAA { get; set; }
        public string KOD_MASLUL_HASHKAA { get; set; }
    
        public virtual PirteiTaktziv PirteiTaktziv { get; set; }
    }
}
