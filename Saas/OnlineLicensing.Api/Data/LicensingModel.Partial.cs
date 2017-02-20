using System.Data.Entity;

namespace EPMLive.OnlineLicensing.Api.Data
{
    public partial class LicensingModel : ILicensingModel
    {
        public LicensingModel(string connectionString) : base(connectionString)
        {
            
        }

        public void MarkAsModified<TEntity>(TEntity item) where TEntity : class, new()
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsDeleted<TEntity>(TEntity item) where TEntity : class, new()
        {
            Entry(item).State = EntityState.Deleted;
        }
    }
}
