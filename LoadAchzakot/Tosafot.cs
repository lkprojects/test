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
    
    public partial class Tosafot
    {
        public int Tosafot_Id { get; set; }
        public int Kisui_Id { get; set; }
        public int TOSEFET_TAARIF { get; set; }
        public Nullable<int> KOD_SUG_TOSEFET { get; set; }
        public Nullable<decimal> SHEUR_TOSEFET { get; set; }
        public Nullable<System.DateTime> TAARICH_TOM_TOSEFET { get; set; }
    
        public virtual Kisui Kisui { get; set; }
    }
}
