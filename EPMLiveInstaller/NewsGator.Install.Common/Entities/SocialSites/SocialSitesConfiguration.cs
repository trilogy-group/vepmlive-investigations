using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using Microsoft.SharePoint;
using NewsGator.Install.Common.Entities.SharePoint;
using NewsGator.Install.Resources;
using NewsGator.Install.Common.Utilities;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    /// <summary>
    /// Details about the local SharePoint and Social Sites Installation.
    /// </summary>
    [DataContract]
    internal class SocialSitesConfiguration
    {
        #region Constants
        private const string ExportXmlFileNameFormat = "NewsGatorConfiguration_{0}.xml";
        #endregion

        #region Properties
        [DataMember]
        internal SocialSitesInstance SocialSitesInstance { get; set; }
        [DataMember]
        internal SharePointInstance SharePointInstance { get; set; }
        [DataMember]
        internal DateTime Generated { get; set; }
        #endregion

        #region Constructor
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal SocialSitesConfiguration()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                this.Initialize();
            });
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal SocialSitesConfiguration(string sourceXml)
        {
            this.Initialize(sourceXml);
        }
        #endregion

        #region Public Methods
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal string SerializeToXmlString()
        {
            return Serializer.Serialize(this);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal void SaveXml(string path, bool compress = true)
        {
            if (string.IsNullOrEmpty(path))
                return;

            if (!path.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                path = path + "\\";

            if (!Directory.Exists(path))
                throw new FileNotFoundException(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.DirectoryDoesNotExist, path));

            var filePath = Path.Combine(path, string.Format(System.Globalization.CultureInfo.InvariantCulture, ExportXmlFileNameFormat, DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture).Replace(":", "_")));            
            File.WriteAllText(filePath, SerializeToXmlString(), Encoding.UTF8);

            if (compress)
                Files.CompressFile(filePath, true);
        }
        #endregion

        #region Private Methods
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        private void Initialize()
        {
            this.Generated = DateTime.UtcNow;
            this.SocialSitesInstance = new SocialSitesInstance();
            this.SharePointInstance = new SharePointInstance();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        private void Initialize(string sourceXml)
        {                       
            SocialSitesConfiguration configuration = null;

            try
            {
                configuration = (SocialSitesConfiguration)Serializer.Deserialize(sourceXml, this.GetType());
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.UnableToParseConfiguration, exception.ToString()));
            }

            this.Generated = configuration.Generated;
            this.SharePointInstance = configuration.SharePointInstance;
            this.SocialSitesInstance = configuration.SocialSitesInstance;
        }
        #endregion
    }
}
