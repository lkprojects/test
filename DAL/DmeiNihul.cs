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
    
    public partial class DmeiNihul
    {
        public int DmeiNihul_Id { get; set; }
        public int PirteiTaktziv_Id { get; set; }
        public int GOVA_DMEI_NIHUL_NIKBA_AL_PI_HOTZAOT_BAPOAL { get; set; }
        public Nullable<int> SUG_HOTZAA { get; set; }
        public string KOD_MASLUL_DMEI_NIHUL { get; set; }
        public Nullable<int> MEAFYENEI_MASLUL_DMEI_NIHUL { get; set; }
        public Nullable<decimal> SHEUR_DMEI_NIHUL { get; set; }
        public Nullable<System.DateTime> TAARICH_NECHONUT_SHEUR_DNHL { get; set; }
        public Nullable<int> DMEI_NIHUL_ACHIDIM { get; set; }
        public string KOD_MASLUL_HASHKAA_BAAL_DMEI_NIHUL_YECHUDIIM { get; set; }
        public Nullable<int> OFEN_HAFRASHA { get; set; }
        public Nullable<decimal> SCHUM_MAX_DNHL_HAFKADA { get; set; }
        public Nullable<decimal> SACH_DMEI_NIHUL_MASLUL { get; set; }
        public Nullable<decimal> DMEI_NIHUL_ACHERIM { get; set; }
        public Nullable<int> KAYEMET_HATAVA { get; set; }
    
        public virtual PirteiTaktziv PirteiTaktziv { get; set; }
    }
}
