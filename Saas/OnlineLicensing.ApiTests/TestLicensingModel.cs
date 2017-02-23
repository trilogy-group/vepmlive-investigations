using System.Data.Entity;
using EPMLive.OnlineLicensing.Api.Data;

namespace EPMLive.OnlineLicensing.ApiTests
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
            OrderHistories = new TestDbSet<OrderHistory>();
            OrderDetailHistories = new TestDbSet<OrderDetailHistory>();
        }
        public DbSet<DetailType> DetailTypes { get; set; }
        public DbSet<LicenseDetail> LicenseDetails { get; set; }
        public DbSet<LicenseProduct> LicenseProducts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderDetailHistory> OrderDetailHistories { get; set; }
        public void MarkAsModified<TEntity>(TEntity item) where TEntity : class, new()
        {
        }

        public void MarkAsDeleted<TEntity>(TEntity item) where TEntity : class, new()
        {
            //
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        {
            //
        }
    }
}
