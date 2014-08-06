﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PensionsEntities : DbContext
    {
        public PensionsEntities()
            : base("name=PensionsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Halvaa> Halvaas { get; set; }
        public virtual DbSet<HeshbonOPolisa> HeshbonOPolisas { get; set; }
        public virtual DbSet<Kupa> Kupas { get; set; }
        public virtual DbSet<MeyupeKoach> MeyupeKoaches { get; set; }
        public virtual DbSet<Mitryot> Mitryots { get; set; }
        public virtual DbSet<Sheer> Sheers { get; set; }
        public virtual DbSet<Tvia> Tvias { get; set; }
        public virtual DbSet<YitraLefiGilPrisha> YitraLefiGilPrishas { get; set; }
        public virtual DbSet<Kisui> Kisuis { get; set; }
        public virtual DbSet<Mevutach> Mevutaches { get; set; }
        public virtual DbSet<Miktsoa_Isuk_Tachviv> Miktsoa_Isuk_Tachviv { get; set; }
        public virtual DbSet<Mutav> Mutavs { get; set; }
        public virtual DbSet<Tosafot> Tosafots { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventHistory> EventHistories { get; set; }
        public virtual DbSet<EventsQueue> EventsQueues { get; set; }
        public virtual DbSet<LUT> LUTs { get; set; }
        public virtual DbSet<DmeiNihul> DmeiNihuls { get; set; }
        public virtual DbSet<HafkadaAchrona> HafkadaAchronas { get; set; }
        public virtual DbSet<HafkadotMetchilatShana> HafkadotMetchilatShanas { get; set; }
        public virtual DbSet<HafrashotLePolisa> HafrashotLePolisas { get; set; }
        public virtual DbSet<MasluleiHashkaa> MasluleiHashkaas { get; set; }
        public virtual DbSet<PerutHafkadaAchrona> PerutHafkadaAchronas { get; set; }
        public virtual DbSet<PerutYitrot> PerutYitrots { get; set; }
        public virtual DbSet<PirteiTaktziv> PirteiTaktzivs { get; set; }
        public virtual DbSet<YitraLeTkufa> YitraLeTkufas { get; set; }
        public virtual DbSet<Yitrot> Yitrots { get; set; }
        public virtual DbSet<FeedbackFile> FeedbackFiles { get; set; }
        public virtual DbSet<FileErrorDetail> FileErrorDetails { get; set; }
        public virtual DbSet<GoremPone> GoremPones { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestErrorDetail> RequestErrorDetails { get; set; }
        public virtual DbSet<RequestPerYatzran> RequestPerYatzrans { get; set; }
        public virtual DbSet<IshKesherYeshutMetafel> IshKesherYeshutMetafels { get; set; }
        public virtual DbSet<IshKesherYeshutYatzran> IshKesherYeshutYatzrans { get; set; }
        public virtual DbSet<Kovetz> Kovetzs { get; set; }
        public virtual DbSet<YeshutMetafel> YeshutMetafels { get; set; }
        public virtual DbSet<IshKesherYeshutMaasik> IshKesherYeshutMaasiks { get; set; }
        public virtual DbSet<Mutzar> Mutzars { get; set; }
        public virtual DbSet<YeshutMaasik> YeshutMaasiks { get; set; }
        public virtual DbSet<EventsHistory> EventsHistories { get; set; }
        public virtual DbSet<MutzarKovetz> MutzarKovetzs { get; set; }
    
        public virtual int DeleteMutzar(Nullable<int> mutzar_Id)
        {
            var mutzar_IdParameter = mutzar_Id.HasValue ?
                new ObjectParameter("Mutzar_Id", mutzar_Id) :
                new ObjectParameter("Mutzar_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteMutzar", mutzar_IdParameter);
        }
    
        public virtual int DequeueEvent(string mISPAR_ZIHUY)
        {
            var mISPAR_ZIHUYParameter = mISPAR_ZIHUY != null ?
                new ObjectParameter("MISPAR_ZIHUY", mISPAR_ZIHUY) :
                new ObjectParameter("MISPAR_ZIHUY", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DequeueEvent", mISPAR_ZIHUYParameter);
        }
    
        public virtual int GetFileNumerator(ObjectParameter numerator)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetFileNumerator", numerator);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertKovetzTest()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertKovetzTest");
        }
    
        public virtual int ChangeClientStatus(ObjectParameter mISPAR_ZIHUY, Nullable<int> fromStatus, Nullable<int> toStatus)
        {
            var fromStatusParameter = fromStatus.HasValue ?
                new ObjectParameter("FromStatus", fromStatus) :
                new ObjectParameter("FromStatus", typeof(int));
    
            var toStatusParameter = toStatus.HasValue ?
                new ObjectParameter("ToStatus", toStatus) :
                new ObjectParameter("ToStatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangeClientStatus", mISPAR_ZIHUY, fromStatusParameter, toStatusParameter);
        }
    
        public virtual int DeleteKovetz(Nullable<int> kovetz_Id)
        {
            var kovetz_IdParameter = kovetz_Id.HasValue ?
                new ObjectParameter("Kovetz_Id", kovetz_Id) :
                new ObjectParameter("Kovetz_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteKovetz", kovetz_IdParameter);
        }
    }
}
