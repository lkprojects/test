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
    
    public partial class Sheer
    {
        public int Sheer_Id { get; set; }
        public int HeshbonOPolisa_Id { get; set; }
        public Nullable<int> SUG_ZIKA { get; set; }
        public Nullable<int> KOD_ZIHUI_SHEERIM { get; set; }
        public string MISPAR_ZIHUY_SHEERIM { get; set; }
        public string SHEM_PRATI_SHEERIM { get; set; }
        public string SHEM_MISHPACHA_SHEERIM { get; set; }
    
        public virtual HeshbonOPolisa HeshbonOPolisa { get; set; }
    }
}
