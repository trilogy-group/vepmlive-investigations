using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.SharePoint.Administration;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    /// <summary>
    /// Details about the local Social Sites Installation.
    /// </summary>
    [DataContract, Serializable]    
    internal class SocialSitesInstance
    {
        #region Properties
        [DataMember]
        internal string Version { get; set; }
        [DataMember]
        internal string SqlFarmConfiguration { get; set; }
        // Configuration Options, Modules Installed, Service Applications
        #endregion

        #region Constants
        private const string TypeNamePrefix = "NewsGator";
        #endregion

        #region Constructors
        internal SocialSitesInstance()
        {
            this.Initialize();
        }
        #endregion

        #region Private Methods
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void Initialize()
        {
            var socialSitesServiceApplicationType = ServiceApplications.SocialServiceApplication.ServiceApplicationType;

            if (socialSitesServiceApplicationType != null)
            {
                foreach (var svc in LocalFarm.Get().Services)
                {
                    foreach (var serviceApp in svc.Applications)
                    {
                        if (serviceApp.GetType() == socialSitesServiceApplicationType)
                        {
                            var db = new Database();
                            var connStr = Utilities.Reflection.GetPropertyValue(socialSitesServiceApplicationType, serviceApp, "DatabaseConnection").ToString();
                            try
                            {
                                this.Version = db.GetDatabaseVersion(connStr);
                            }
                            catch
                            {
                                this.Version = null;
                            }
                            try
                            {
                                var sqlFarmConfiguration = db.GetFarmConfiguration(connStr);
                                if (sqlFarmConfiguration != null)
                                {
                                    using (var writer = new StringWriter(CultureInfo.InvariantCulture))
                                    {
                                        sqlFarmConfiguration.WriteXml(writer);
                                        this.SqlFarmConfiguration = writer.ToString();
                                    }
                                }
                            }
                            catch
                            {
                                this.SqlFarmConfiguration = null;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
