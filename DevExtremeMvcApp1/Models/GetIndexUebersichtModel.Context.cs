﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevExtremeMvcApp1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FuhrparkContextEntities : DbContext
    {
        public FuhrparkContextEntities()
            : base("name=FuhrparkContextEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<uebersicht_daten> uebersicht_daten { get; set; }
    
        public virtual ObjectResult<GetIndexUebersicht_Result> GetIndexUebersicht()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetIndexUebersicht_Result>("GetIndexUebersicht");
        }

        public System.Data.Entity.DbSet<DevExtremeMvcApp1.Models.GetIndexUebersicht_Result> GetIndexUebersicht_Result { get; set; }
    }
}
