using System.Configuration;
using System.Data.Entity.Core.EntityClient;

namespace EPMLive.OnlineLicensing.Api.Data
{
    public class ConnectionHelper
    {
        /// <summary>
        /// Create a <see cref="LicensingModel"/> instance using default connection string: "epmlive"
        /// </summary>
        /// <returns></returns>
        public static LicensingModel CreateLicensingModel()
        {
            return CreateLicensingModel(ConfigurationManager.ConnectionStrings["epmlive"].ConnectionString);
        }

        /// <summary>
        /// Create a <see cref="LicensingModel"/> instance using a specified connection string
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static LicensingModel CreateLicensingModel(string connectionString)
        {
            var ecsBuilder = new EntityConnectionStringBuilder
            {
                ProviderConnectionString = connectionString,
                Metadata = @"res://*/Data.LicensingModel.csdl|res://*/Data.LicensingModel.ssdl|res://*/Data.LicensingModel.msl",
                Provider = "System.Data.SqlClient"
            };
            var md = new LicensingModel(ecsBuilder.ToString());
            return md;
        }
    }
}
