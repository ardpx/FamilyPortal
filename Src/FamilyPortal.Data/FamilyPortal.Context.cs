﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FamilyPortal.Data
{
    using FamilyPortal.DomainModels.Entities;
    using FamilyPortal.DomainModels.InternalObjects;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class FamilyPortalEntities : DbContext, IFamilyPortalEntities
    {
        public FamilyPortalEntities()
            : base("name=FamilyPortalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<stock_insight> stock_insights { get; set; }
        public DbSet<stock_trade_day> stock_trade_days { get; set; }
        public DbSet<stock_trade_pair> stock_trade_pairs { get; set; }
        public DbSet<stock_trade> stock_trades { get; set; }
    }
}