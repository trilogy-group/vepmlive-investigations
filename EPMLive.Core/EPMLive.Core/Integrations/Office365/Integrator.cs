using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using EPMLiveCore.Integrations.Office365.Infrastructure;
using EPMLiveIntegration;
using Microsoft.SharePoint.Client;

namespace EPMLiveCore.Integrations.Office365
{
    public class Integrator : IIntegrator
    {
        #region Methods (14) 

        // Public Methods (9) 

        public TransactionTable DeleteItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                if (!bool.Parse((string) webProps.Properties["AllowDeleteInt"]))
                {
                    throw new Exception("Office 365 delete is not allowed.");
                }

                O365Service o365Service = GetO365Service(webProps);

                List<string> ids;
                Dictionary<string, string> idMap = BuildIdMap(items, out ids);

                int index = 0;

                foreach (
                    O365Result result in
                        o365Service.DeleteListItemsById(ids.ToArray(), (string) webProps.Properties["List"]))
                {
                    string o365Id = result.ItemId.ToString();
                    string spid;

                    try
                    {
                        spid = idMap[o365Id];
                    }
                    catch
                    {
                        spid = items.Rows[index]["SPID"].ToString();
                    }

                    if (result.Success)
                    {
                        transactionTable.AddRow(spid, o365Id, TransactionType.DELETE);
                    }
                    else
                    {
                        transactionTable.AddRow(spid, o365Id, TransactionType.FAILED);
                        log.LogMessage(string.Format(
                            "Could not delete record with Office 365 ID: {0}, SharePoint ID: {1}. Message: {2}",
                            o365Id, spid, result.Error), IntegrationLogType.Warning);
                    }

                    index++;
                }
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, IntegrationLogType.Error);
            }

            return transactionTable;
        }

        public List<ColumnProperty> GetColumns(WebProperties webProps, IntegrationLog log, string listName)
        {
            var columnProperties = new List<ColumnProperty>();

            try
            {
                O365Service o365Service = GetO365Service(webProps);

                var ignoredFields = new[]
                {
                    "AppAuthor", "AppEditor", "Attachments", "DocIcon",
                    "ItemChildCount", "FolderChildCount", "_UIVersionString"
                };

                columnProperties.AddRange(
                    from field in o365Service.GetListFields(webProps.Properties["List"].ToString())
                    let internalName = field.InternalName
                    where !ignoredFields.Contains(internalName) &&
                          !internalName.StartsWith("LinkTitle") && !internalName.EndsWith("NoMenu")
                    orderby field.Title
                    select new ColumnProperty
                    {
                        ColumnName = internalName,
                        DiplayName = field.Title,
                        type = TranslateFieldType(field.FieldTypeKind),
                        DefaultListColumn = GetMatchingListColumn(internalName)
                    });
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, IntegrationLogType.Error);
            }

            return columnProperties;
        }

        public Dictionary<string, string> GetDropDownValues(WebProperties webProps, IntegrationLog log, string property,
            string parentPropertyValue)
        {
            var dictionary = new Dictionary<string, string>();

            try
            {
                O365Service o365Service = GetO365Service(webProps);

                if (property.Equals("List")) dictionary = o365Service.GetIntegratableLists();
                else if (property.Equals("UserMapType")) return new Dictionary<string, string> {{"Email", "Email"}};

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
                O365Service o365Service = GetO365Service(webProps);
                o365Service.GetListItemsById((string) webProps.Properties["List"], itemId, items);
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, e.Message.StartsWith("No records found")
                    ? IntegrationLogType.Warning
                    : IntegrationLogType.Error);
            }

            return items;
        }

        public bool InstallIntegration(WebProperties webProps, IntegrationLog log, out string message,
            string integrationKey,
            string apiUrl)
        {
            message = string.Empty;

            try
            {
                O365Service o365Service = GetO365Service(webProps);

                o365Service.InstallIntegration(webProps.IntegrationId, integrationKey, apiUrl, webProps.Title,
                    webProps.FullURL, webProps.EnabledFeatures,
                    (string) webProps.Properties["List"],
                    bool.Parse((string) webProps.Properties["AllowAddInt"]),
                    bool.Parse((string) webProps.Properties["AllowAddList"]),
                    bool.Parse((string) webProps.Properties["AllowDeleteInt"]));

                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return false;
        }

        public DataTable PullData(WebProperties webProps, IntegrationLog log, DataTable items, DateTime lastSynchDate)
        {
            try
            {
                O365Service o365Service = GetO365Service(webProps);
                o365Service.GetListItems((string) webProps.Properties["List"], items, lastSynchDate);
            }
            catch (Exception e)
            {
                log.LogMessage("Scheduled Pull. " + e.Message, e.Message.StartsWith("No records found")
                    ? IntegrationLogType.Warning
                    : IntegrationLogType.Error);
            }

            return items;
        }

        public bool RemoveIntegration(WebProperties webProps, IntegrationLog log, out string message,
            string integrationKey)
        {
            message = string.Empty;

            try
            {
                O365Service o365Service = GetO365Service(webProps);
                o365Service.UninstallIntegration(integrationKey, webProps.IntegrationId);

                return true;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("List 'EPMLiveIntegrations' does not exist")) return true;
                message = e.Message;
            }

            return false;
        }

        public bool TestConnection(WebProperties webProps, IntegrationLog log, out string message)
        {
            message = string.Empty;

            try
            {
                O365Service o365Service = GetO365Service(webProps);
                if (!o365Service.EnsureEPMLiveAppInstalled())
                {
                    log.LogMessage(
                        "Please make sure that you have installed the EPM Live app in your Office 365 environment.",
                        IntegrationLogType.Error);

                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
                log.LogMessage(message, IntegrationLogType.Error);

                return false;
            }
        }

        public TransactionTable UpdateItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                O365Service o365Service = GetO365Service(webProps);

                List<string> ids;
                Dictionary<string, string> idMap = BuildIdMap(items, out ids);

                int index = 0;

                foreach (
                    O365Result result in
                        o365Service.UpsertItems((string) webProps.Properties["List"], webProps.IntegrationId, items))
                {
                    string o365Id = result.ItemId.ToString();

                    string spId;

                    try
                    {
                        spId = idMap[o365Id];
                    }
                    catch
                    {
                        spId = items.Rows[index]["SPID"].ToString();
                    }

                    if (result.Success)
                    {
                        transactionTable.AddRow(spId, o365Id, result.TransactionType);
                    }
                    else
                    {
                        transactionTable.AddRow(spId, o365Id, TransactionType.FAILED);

                        log.LogMessage(string.Format(
                            "Could not insert / update record with Office 365 ID: {0}, SharePoint ID: {1}. Message: {2}",
                            o365Id, spId, result.Error), IntegrationLogType.Warning);
                    }

                    index++;
                }
            }
            catch (Exception e)
            {
                log.LogMessage(e.Message, IntegrationLogType.Error);
            }

            return transactionTable;
        }

        // Private Methods (5) 

        private static Dictionary<string, string> BuildIdMap(DataTable items, out List<string> ids)
        {
            var idMap = new Dictionary<string, string>();
            ids = new List<string>();

            foreach (DataRow dataRow in items.Rows)
            {
                object oId = dataRow["ID"];

                if (oId == null || oId == DBNull.Value) continue;

                string id = oId.ToString();
                if (ids.Contains(id)) continue;

                ids.Add(id);
                idMap.Add(id, dataRow["SPID"].ToString());
            }

            return idMap;
        }

        private static void GetAuthParameters(WebProperties webProps, out string username, out SecureString password,
            out string siteUrl)
        {
            username = webProps.Properties["Username"].ToString();
            if (string.IsNullOrEmpty(username)) throw new Exception("Please provide the username.");

            string pwd = webProps.Properties["Password"].ToString();
            if (string.IsNullOrEmpty(pwd)) throw new Exception("Please provide the password.");

            password = pwd.ToSecureString();

            siteUrl = webProps.Properties["SiteUrl"].ToString();
            if (string.IsNullOrEmpty(siteUrl)) throw new Exception("Please provide the Office 365 site url.");

            Uri uri;
            if (!Uri.TryCreate(siteUrl, UriKind.RelativeOrAbsolute, out uri))
            {
                throw new Exception(siteUrl + " is not a valid url.");
            }
        }

        private string GetMatchingListColumn(string internalName)
        {
            return internalName.Equals("ID") ? "INTUID" : internalName;
        }

        private O365Service GetO365Service(WebProperties webProps)
        {
            string username;
            SecureString password;
            string siteUrl;

            GetAuthParameters(webProps, out username, out password, out siteUrl);

            return new O365Service(username, password, siteUrl);
        }

        private Type TranslateFieldType(FieldType fieldType)
        {
            switch (fieldType)
            {
                case FieldType.Boolean:
                    return typeof (bool);
                case FieldType.Counter:
                case FieldType.Integer:
                    return typeof (int);
                case FieldType.Currency:
                case FieldType.Number:
                    return typeof (decimal);
                case FieldType.DateTime:
                    return typeof (DateTime);
                case FieldType.Guid:
                    return typeof (Guid);
                default:
                    return typeof (string);
            }
        }

        #endregion Methods 
    }
}