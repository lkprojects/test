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
    
    public partial class Mevutach
    {
        public int Mevutach_Id { get; set; }
        public int Kisui_Id { get; set; }
        public int SUG_TEUDA { get; set; }
        public string MISPAR_ZIHUY_LAKOACH { get; set; }
    
        public virtual Kisui Kisui { get; set; }
    }
}
