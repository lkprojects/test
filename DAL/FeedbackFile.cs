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
    
    public partial class FeedbackFile
    {
        public FeedbackFile()
        {
            this.GoremPones = new HashSet<GoremPone>();
        }
    
        public int FeedbackFile_ID { get; set; }
        public Nullable<int> SUG_MIMSHAK { get; set; }
        public string MISPAR_GIRSAT_XML { get; set; }
        public Nullable<System.DateTime> TAARICH_BITZUA { get; set; }
        public Nullable<int> KOD_SVIVAT_AVODA { get; set; }
        public string MISPAR_HAKOVETZ { get; set; }
        public Nullable<int> MISPAR_SIDURI { get; set; }
        public Nullable<int> KOD_SHOLECH { get; set; }
        public Nullable<int> SUG_MEZAHE_SHOLECH { get; set; }
        public string MISPAR_ZIHUI_SHOLECH { get; set; }
        public string SHEM_GOREM_SHOLECH { get; set; }
        public string SHEM_PRATI_ISH_KESHER_SHOLECH { get; set; }
        public string SHEM_MISHPACHA_ISH_KESHER_SHOLECH { get; set; }
        public string MISPAR_TELEPHONE_KAVI_ISH_KESHER_SHOLECH { get; set; }
        public string E_MAIL_ISH_KESHER_SHOLECH { get; set; }
        public string MISPAR_CELLULARI_ISH_KESHER_SHOLECH { get; set; }
        public Nullable<int> KOD_NIMAAN { get; set; }
        public Nullable<int> SUG_MEZAHE_NIMAAN { get; set; }
        public string MISPAR_ZIHUI_NIMAAN { get; set; }
        public string MISPAR_ZIHUI_ETZEL_YATZRAN_NIMAAN { get; set; }
    
        public virtual ICollection<GoremPone> GoremPones { get; set; }
    }
}
