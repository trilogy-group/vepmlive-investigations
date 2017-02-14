using System;
using System.Data.Entity;
using EPMLive.OnlineLicensing.Api.Data;

namespace OnlineLicensing.ApiTests
{
    /// <summary>
    /// 
    /// </summary>
    public class TestLicensingModel : ILicensingModel
    {
        public TestLicensingModel()
        {
            DetailTypes = new TestDbSet<DetailType>();
            LicenseDetails = new TestDbSet<LicenseDetail>();
            LicenseProducts = new TestDbSet<LicenseProduct>();
            Orders = new TestDbSet<Order>();
            OrderDetails = new TestDbSet<OrderDetail>();
            Accounts = new TestDbSet<Account>();
            VwAccountOrders = new TestDbSet<VwAccountOrder>();

        }
        public DbSet<DetailType> DetailTypes { get; set; }
        public DbSet<LicenseDetail> LicenseDetails { get; set; }
        public DbSet<LicenseProduct> LicenseProducts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<VwAccountOrder> VwAccountOrders { get; set; }
        public void MarkAsModified<TEntity>(TEntity item) where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        public void MarkAsDeleted<TEntity>(TEntity item) where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //
        }
    }
}
