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
    
    public partial class Client
    {
        public int Client_Id { get; set; }
        public byte LastStatus { get; set; }
        public string LastFileNumber { get; set; }
        public string LastRecordNumber { get; set; }
        public Nullable<int> LastKodEirua { get; set; }
        public string TeudatZehut { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string AddressStreetName { get; set; }
        public string AddressStreetNumber { get; set; }
        public string AddressCity { get; set; }
        public Nullable<byte> MaritalStatus { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<byte> Gender { get; set; }
        public System.DateTime InsertDate { get; set; }
        public System.DateTime ModifyDate { get; set; }
    }
}
