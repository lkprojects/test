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
    
    public partial class HafrashotLePolisa
    {
        public int HafrashotLePolisa_Id { get; set; }
        public int PirteiTaktziv_Id { get; set; }
        public Nullable<int> SUG_HAMAFKID { get; set; }
        public Nullable<int> SUG_HAFRASHA { get; set; }
        public Nullable<decimal> ACHUZ_HAFRASHA { get; set; }
        public Nullable<decimal> SCHUM_HAFRASHA { get; set; }
        public Nullable<System.DateTime> TAARICH_MADAD { get; set; }
    
        public virtual PirteiTaktziv PirteiTaktziv { get; set; }
    }
}
