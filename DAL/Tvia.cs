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
    
    public partial class Tvia
    {
        public int Tvia_Id { get; set; }
        public int HeshbonOPolisa_Id { get; set; }
        public int YESH_TVIA { get; set; }
        public Nullable<int> MISPAR_TVIA_BE_YATZRAN { get; set; }
        public string MISPAR_KISUI_BE_YATZRAN { get; set; }
        public string SHEM_KISUI_BE_YATZRAN { get; set; }
        public Nullable<int> SUG_HATVIAA { get; set; }
        public Nullable<int> OFEN_TASHLUM { get; set; }
        public Nullable<int> KOD_STATUS_TVIAA { get; set; }
        public Nullable<System.DateTime> TAARICH_STATUS_TVIA { get; set; }
        public Nullable<System.DateTime> TAARICH_TECHILAT_TASHLUM { get; set; }
        public Nullable<decimal> ACHUZ_MEUSHAR_O_K_A_SHICHRUR { get; set; }
        public Nullable<decimal> SCHUM_TVIA_MEUSHAR { get; set; }
        public Nullable<decimal> ACHUZ_NECHUT { get; set; }
    
        public virtual HeshbonOPolisa HeshbonOPolisa { get; set; }
    }
}
