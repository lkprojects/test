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
    
    public partial class Mitryot
    {
        public int Mitryot_Id { get; set; }
        public int HeshbonOPolisa_Id { get; set; }
        public Nullable<int> KAYAM_KISUY_BITUCHI_COLECTIVI_LEAMITIM { get; set; }
        public string SHEM_MEVATACHAT { get; set; }
        public Nullable<System.DateTime> TAARICH_TCHILAT_HABITUACH { get; set; }
        public Nullable<System.DateTime> TAARICH_TOM_TKUFAT_HABITUAH { get; set; }
        public Nullable<int> KOD_SUG_MUTZAR_BITUACH { get; set; }
        public Nullable<decimal> SCHUM_BITUACH { get; set; }
        public Nullable<decimal> ALUT_KISUI { get; set; }
        public Nullable<int> MESHALEM_DMEI_HABITUAH { get; set; }
        public Nullable<int> TADIRUT_HATSHLUM { get; set; }
        public Nullable<int> HAIM_NECHTAM_TOFES_HITZTARFUT { get; set; }
    
        public virtual HeshbonOPolisa HeshbonOPolisa { get; set; }
    }
}
