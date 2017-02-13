using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        DbSet<VwAccountOrder> VwAccountOrders { get; set; }

        void MarkAsModified<TEntity>(TEntity item) where TEntity : class, new();
        void MarkAsDeleted<TEntity>(TEntity item) where TEntity : class, new();
        int SaveChanges();
    }
}
