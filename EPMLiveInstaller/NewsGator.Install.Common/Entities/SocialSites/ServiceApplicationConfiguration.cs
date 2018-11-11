using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using NewsGator.Install.Resources;
using System.Runtime.Serialization;
using NewsGator.Install.Common.Utilities;
using NewsGator.Install.Common.Entities.SocialSites;
using NewsGator.Install.Common.Entities.Flags;

namespace NewsGator.Install.Common.Entities.SocialSites
{
    [DataContract]
	internal class ServiceApplicationConfiguration
	{
        [DataMember]
		internal ServiceApplicationType ServiceApplicationType { get; set; }
        [DataMember]
        internal string DatabaseName { get; set; }
        [DataMember]
        internal string DatabaseServer { get; set; }
        [DataMember]
        internal string DatabaseFailoverServer { get; set; }
        [DataMember]
        internal string ReportDatabaseName { get; set; }
        [DataMember]
        internal string ReportDatabaseServer { get; set; }
        [DataMember]
        internal string ReportDatabaseFailoverServer { get; set; }
        [DataMember]
        internal string ApplicationPoolName { get; set; }
        [DataMember]
        internal string ApplicationPoolUsername { get; set; }
        [DataMember]
        internal string ApplicationPoolPassword { get; set; }
        [DataMember]
        internal string LicenseKey { get; set; }
        [DataMember]
        internal string EmailListLocation { get; set; }
        [DataMember]
        internal string VideoEncodingInputFolder { get; set; }
        [DataMember]
        internal string VideoEncodingOutputFolder { get; set; }
        [DataMember]
        internal string VideoStreamingServerFolder { get; set; }
        [DataMember]
        internal string VideoUploadFolder { get; set; }
		[SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string VideoStreamingServerUrlDefaultZone { get; set; }
		[SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string VideoStreamingServerUrlIntranetZone { get; set; }
		[SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string VideoStreamingServerUrlInternetZone { get; set; }
		[SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string VideoStreamingServerUrlCustomZone { get; set; }
		[SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        [DataMember]
        internal string VideoStreamingServerUrlExtranetZone { get; set; }
        [DataMember]
        internal string LearningGlobalKnowledgeBase { get; set; }

		private const string _fileName = "tempconfig.ngapp";
		private static string _getFilePath()
		{
			var executionPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ServiceApplicationConfiguration)).Location);
            //var executionPath = System.IO.Path.GetTempPath();
			if (executionPath.Contains("file:\\"))
				executionPath = executionPath.Replace("file:\\", "");
			if (!executionPath.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
				executionPath += "\\";

			return executionPath + _fileName;
		}

		internal void SaveToXml()
		{
			var filePath = _getFilePath();
            File.WriteAllText(filePath, Serializer.Serialize(this), UTF8Encoding.UTF8);               
		}

		internal void LoadFromXml()
		{
			ServiceApplicationConfiguration configuration = null;

			try
			{
				var filePath = _getFilePath();
				var input = File.ReadAllText(filePath, UTF8Encoding.UTF8);
                configuration = (ServiceApplicationConfiguration)Serializer.Deserialize(input, this.GetType());

				try
				{
					File.SetAttributes(filePath, FileAttributes.Normal);
					File.Delete(filePath);
				}
				catch (IOException)
				{
					Thread.Sleep(100);
					File.SetAttributes(filePath, FileAttributes.Normal);
					File.Delete(filePath);
				}
			}
			catch (Exception exception)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Exceptions.UnableToParseConfiguration, exception.ToString()));
			}

			this.ApplicationPoolName = configuration.ApplicationPoolName;
			this.ApplicationPoolPassword = configuration.ApplicationPoolPassword;
			this.ApplicationPoolUsername = configuration.ApplicationPoolUsername;
			this.DatabaseFailoverServer = configuration.DatabaseFailoverServer;
			this.DatabaseName = configuration.DatabaseName;
			this.DatabaseServer = configuration.DatabaseServer;
			this.EmailListLocation = configuration.EmailListLocation;
			this.LearningGlobalKnowledgeBase = configuration.LearningGlobalKnowledgeBase;
			this.LicenseKey = configuration.LicenseKey;
			this.ReportDatabaseFailoverServer = configuration.ReportDatabaseFailoverServer;
			this.ReportDatabaseName = configuration.ReportDatabaseName;
			this.ReportDatabaseServer = configuration.ReportDatabaseServer;
			this.ServiceApplicationType = configuration.ServiceApplicationType;
			this.VideoEncodingInputFolder = configuration.VideoEncodingInputFolder;
			this.VideoEncodingOutputFolder = configuration.VideoEncodingOutputFolder;
			this.VideoStreamingServerFolder = configuration.VideoStreamingServerFolder;
			this.VideoStreamingServerUrlCustomZone = configuration.VideoStreamingServerUrlCustomZone;
			this.VideoStreamingServerUrlDefaultZone = configuration.VideoStreamingServerUrlDefaultZone;
			this.VideoStreamingServerUrlInternetZone = configuration.VideoStreamingServerUrlInternetZone;
			this.VideoStreamingServerUrlIntranetZone = configuration.VideoStreamingServerUrlIntranetZone;
			this.VideoStreamingServerUrlExtranetZone = configuration.VideoStreamingServerUrlExtranetZone;
			this.VideoUploadFolder = configuration.VideoUploadFolder;
		}
	}
}
