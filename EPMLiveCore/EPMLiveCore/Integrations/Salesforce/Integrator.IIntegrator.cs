using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using EPMLiveIntegration;

namespace EPMLiveCore.Integrations.Salesforce
{
    public partial class Integrator : IIntegrator
    {
        public List<ColumnProperty> GetColumns(WebProperties webProps, IntegrationLog log, string listName)
        {
            if (webProps == null)
            {
                throw new ArgumentNullException(nameof(webProps));
            }
            var columnProperties = new List<ColumnProperty>();

            try
            {
                var sfService = GetSfService(webProps);

                var ignoredFields = new[]
                {
                    "IsDeleted",
                    "CreatedDate",
                    "LastModifiedDate",
                    "LastModifiedById",
                    "SystemModstamp",
                    "LastActivityDate",
                    $"{sfService.AppNamespace}__Additional_Assigned_To__c",
                    $"{sfService.AppNamespace}__FK__c"
                };

                columnProperties.AddRange(
                    from field in sfService.GetObjectFields(webProps.Properties["Object"].ToString())
                    where !ignoredFields.Contains(field.name)
                    orderby field.name
                    select new ColumnProperty
                    {
                        ColumnName = field.name,
                        DiplayName = field.label,
                        type = TranslateFieldType(field.type),
                        DefaultListColumn = GetMatchingListColumn(field.label, field.name, sfService.AppNamespace)
                    });
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                log.LogMessage(ex.Message, IntegrationLogType.Error);
            }

            return columnProperties;
        }

        public Dictionary<string, string> GetDropDownValues(
            WebProperties webProps,
            IntegrationLog log,
            string property,
            string parentPropertyValue)
        {
            var dictionary = new Dictionary<string, string>();

            try
            {
                var sfService = GetSfService(webProps);

                if (property.Equals("Object"))
                {
                    dictionary = sfService.GetIntegratableObjects();
                }
                else if (property.Equals("UserMapType"))
                {
                    return new Dictionary<string, string>
                    {
                        { "Email", "Email" }
                    };
                }

                throw new Exception("Invalid property: " + property);
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, IntegrationLogType.Error);
            }

            return dictionary;
        }

        public DataTable GetItem(WebProperties webProps, IntegrationLog log, string itemId, DataTable items)
        {
            try
            {
                var sfService = GetSfService(webProps);
                sfService.GetObjectItemsById((string)webProps.Properties["Object"], itemId, items);
            }
            catch (Exception e)
            {
                log.LogMessage(
                    e.Message,
                    e.Message.StartsWith("No records found")
                        ? IntegrationLogType.Warning
                        : IntegrationLogType.Error);
            }

            return items;
        }

        public bool InstallIntegration(
            WebProperties webProps,
            IntegrationLog log,
            out string message,
            string integrationKey,
            string apiUrl)
        {
            message = string.Empty;

            try
            {
                var sfService = GetSfService(webProps);

                sfService.InstallIntegration(
                    integrationKey,
                    apiUrl,
                    webProps.Title,
                    webProps.FullURL,
                    webProps.IntegrationId,
                    (string)webProps.Properties["Object"],
                    bool.Parse((string)webProps.Properties["AllowAddInt"]),
                    bool.Parse((string)webProps.Properties["AllowAddList"]),
                    bool.Parse((string)webProps.Properties["AllowDeleteInt"]));
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
            return true;
        }

        public DataTable PullData(WebProperties webProps, IntegrationLog log, DataTable items, DateTime lastSynch)
        {
            try
            {
                var sfService = GetSfService(webProps);
                sfService.GetObjectItems((string)webProps.Properties["Object"], items, lastSynch);
            }
            catch (Exception e)
            {
                log.LogMessage(
                    $"Scheduled Pull. {e.Message}",
                    e.Message.StartsWith("No records found")
                        ? IntegrationLogType.Warning
                        : IntegrationLogType.Error);
            }

            return items;
        }

        public bool RemoveIntegration(
            WebProperties webProps,
            IntegrationLog log,
            out string message,
            string integrationKey)
        {
            message = string.Empty;

            try
            {
                var sfService = GetSfService(webProps);
                sfService.UninstallIntegration(integrationKey, webProps.Properties["Object"].ToString());
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return true;
        }

        public bool TestConnection(WebProperties webProps, IntegrationLog log, out string message)
        {
            message = string.Empty;

            try
            {
                var sfService = GetSfService(webProps);
                sfService.EnsureEPMLiveAppInstalled();

                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return false;
        }
    }
}