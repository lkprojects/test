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
    
    public partial class Halvaa
    {
        public int Halvaa_Id { get; set; }
        public int HeshbonOPolisa_Id { get; set; }
        public int YESH_HALVAA_BAMUTZAR { get; set; }
        public string MISDAR_SIDURI_SHEL_HAHALVAA { get; set; }
        public Nullable<decimal> SCHUM_HALVAA { get; set; }
        public Nullable<System.DateTime> TAARICH_KABALAT_HALVAA { get; set; }
        public Nullable<System.DateTime> TAARICH_SIYUM_HALVAA { get; set; }
        public Nullable<decimal> YITRAT_HALVAA { get; set; }
        public Nullable<int> TKUFAT_HALVAA { get; set; }
        public Nullable<decimal> RIBIT { get; set; }
        public Nullable<int> SUG_RIBIT { get; set; }
        public Nullable<int> SUG_HATZNMADA { get; set; }
        public Nullable<int> TADIRUT_HECHZER_HALVAA { get; set; }
        public Nullable<int> SUG_HECHZER { get; set; }
        public Nullable<decimal> SCHUM_HECHZER_TKUFATI { get; set; }
    
        public virtual HeshbonOPolisa HeshbonOPolisa { get; set; }
    }
}