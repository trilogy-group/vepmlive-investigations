using System;
using System.Data.Entity;

namespace EPMLive.OnlineLicensing.Api.Data
{
    public interface ILicensingModel : IDisposable
    {
        DbSet<DetailType> DetailTypes { get; set; }
        DbSet<LicenseDetail> LicenseDetails { get; set; }
        DbSet<LicenseProduct> LicenseProducts { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<OrderHistory> OrderHistories { get; set; }
        DbSet<OrderDetailHistory> OrderDetailHistories { get; set; }

        void MarkAsModified<TEntity>(TEntity item) where TEntity : class, new();
        void MarkAsDeleted<TEntity>(TEntity item) where TEntity : class, new();
        int SaveChanges();
    }
}
