﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPMLive.OnlineLicensing.Api.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class LicensingModel : DbContext
    {
        public LicensingModel()
            : base("name=LicensingModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LicenseDetail> LicenseDetails { get; set; }
        public virtual DbSet<LicenseProduct> LicenseProducts { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<VwActiveOrder> VwActiveOrders { get; set; }
        public virtual DbSet<ContractLevelTitle> ContractLevelTitles { get; set; }
        public virtual DbSet<ContractLevel> ContractLevels { get; set; }
        public virtual DbSet<DetailType> DetailTypes { get; set; }
        public virtual DbSet<OrderDetailHistory> OrderDetailHistories { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
    }
}
