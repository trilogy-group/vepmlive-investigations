using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EPMLiveCore.SalesforcePartnerService;
using EPMLiveIntegration;

namespace EPMLiveCore.Integrations.Salesforce
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
                    throw new Exception("Salesforce delete is not allowed.");
                }

                SfService sfService = GetSfService(webProps);

                if (!sfService.IsSyncEnabled())
                {
                    throw new Exception("All synchronizations are currently disabled.");
                }

                List<string> ids;
                Dictionary<string, string> idMap = BuildIdMap(items, out ids);

                int index = 0;

                foreach (DeleteResult deleteResult in sfService.DeleteObjectItemsById(ids.ToArray()))
                {
                    string sfId = deleteResult.id;
                    string spid;

                    try
                    {
                        spid = idMap[sfId];
                    }
                    catch
                    {
                        spid = items.Rows[index]["SPID"].ToString();
                    }

                    if (deleteResult.success)
                    {
                        transactionTable.AddRow(spid, sfId, TransactionType.DELETE);
                    }
                    else
                    {
                        transactionTable.AddRow(spid, sfId, TransactionType.FAILED);
                        if (deleteResult.errors.Any())
                        {
                            Error[] errors = deleteResult.errors;

                            for (int i = 0; i < errors.Count(); i++)
                            {
                                log.LogMessage(
                                    string.Format(
                                        "Could not delete record with Salesforce ID: {0}, SharePoint ID: {1}. Status code: {2}. Message: {3}. Fields: {4}",
                                        sfId, spid, errors[i].statusCode, errors[i].message,
                                        string.Join(",", errors[i].fields)), IntegrationLogType.Warning);
                            }
                        }
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
                SfService sfService = GetSfService(webProps);

                var ignoredFields = new[]
                    {
                        "IsDeleted", "CreatedDate", "LastModifiedDate",
                        "LastModifiedById", "SystemModstamp", "LastActivityDate",
                        sfService.AppNamespace + "__Additional_Assigned_To__c",
                        sfService.AppNamespace + "__FK__c"
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
                            DefaultListColumn =
                                GetMatchingListColumn(field.label, field.name, sfService.AppNamespace)
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
                SfService sfService = GetSfService(webProps);

                if (property.Equals("Object")) dictionary = sfService.GetIntegratableObjects();
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
                SfService sfService = GetSfService(webProps);
                sfService.GetObjectItemsById((string) webProps.Properties["Object"], itemId, items);
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
                SfService sfService = GetSfService(webProps);

                sfService.InstallIntegration(integrationKey, apiUrl, webProps.Title, webProps.FullURL,
                                             webProps.IntegrationId, (string) webProps.Properties["Object"],
                                             bool.Parse((string) webProps.Properties["AllowAddInt"]),
                                             bool.Parse((string) webProps.Properties["AllowAddList"]),
                                             bool.Parse((string) webProps.Properties["AllowDeleteInt"]));

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
                SfService sfService = GetSfService(webProps);
                sfService.GetObjectItems((string) webProps.Properties["Object"], items, lastSynch);
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
                SfService sfService = GetSfService(webProps);
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
                SfService sfService = GetSfService(webProps);
                sfService.EnsureEPMLiveAppInstalled();

                return true;
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return false;
        }

        public TransactionTable UpdateItems(WebProperties webProps, DataTable items, IntegrationLog log)
        {
            var transactionTable = new TransactionTable();

            try
            {
                SfService sfService = GetSfService(webProps);

                if (!sfService.IsSyncEnabled())
                {
                    throw new Exception("All synchronizations are currently disabled.");
                }

                List<string> ids;
                Dictionary<string, string> idMap = BuildIdMap(items, out ids);

                int index = 0;

                foreach (var result in sfService.UpsertItems((string) webProps.Properties["Object"], items))
                {
                    foreach (var pair in result)
                    {
                        SaveResult upsertResult = pair.Value;

                        string sfId = upsertResult.id;
                        string spid;

                        try
                        {
                            spid = idMap[sfId];
                        }
                        catch
                        {
                            spid = items.Rows[index]["SPID"].ToString();
                        }

                        if (upsertResult.success)
                        {
                            transactionTable.AddRow(spid, sfId,
                                                    pair.Key == UpsertKind.INSERT
                                                        ? TransactionType.INSERT
                                                        : TransactionType.UPDATE);
                        }
                        else
                        {
                            transactionTable.AddRow(spid, sfId, TransactionType.FAILED);
                            if (upsertResult.errors.Any())
                            {
                                Error[] errors = upsertResult.errors;

                                for (int i = 0; i < errors.Count(); i++)
                                {
                                    var error = errors[i];

                                    string fields = string.Empty;

                                    if (error.fields != null)
                                    {
                                        try
                                        {
                                            fields = "Fields: " + string.Join(",", error.fields) + ".";
                                        }
                                        catch { }
                                    }

                                    log.LogMessage(
                                        string.Format(
                                            "Could not insert / update record with Salesforce ID: {0}, SharePoint ID: {1}. Status code: {2}. Message: {3} {4}",
                                            sfId, spid, error.statusCode, error.message, fields), IntegrationLogType.Warning);
                                }
                            }
                        }
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

        private static void GetAuthParameters(WebProperties webProps, out string username, out string password,
                                              out string securityToken, out bool isSandbox)
        {
            username = webProps.Properties["Username"].ToString();
            if (string.IsNullOrEmpty(username)) throw new Exception("Please provide the username.");

            password = webProps.Properties["Password"].ToString();
            if (string.IsNullOrEmpty(password)) throw new Exception("Please provide the password.");

            securityToken = webProps.Properties["SecurityToken"].ToString();
            if (string.IsNullOrEmpty(securityToken)) throw new Exception("Please provide the security token.");

            try
            {
                isSandbox = bool.Parse(webProps.Properties["Sandbox"].ToString());
            }
            catch
            {
                isSandbox = false;
            }
        }

        private string GetMatchingListColumn(string displayName, string internalName, string appNamespace)
        {
            switch (internalName)
            {
                case "Id":
                    return "INTUID";
                case "Name":
                    return "Title";
            }

            if (internalName.Equals(appNamespace + "__EPM_Live_ID__c")) return "SPID";

            //@todo: setup matching columns.

            return displayName.Replace("%", "Percent").Replace(" ", string.Empty);
        }

        private static SfService GetSfService(WebProperties webProps)
        {
            string username;
            string password;
            string securityToken;
            bool isSandbox;

            GetAuthParameters(webProps, out username, out password, out securityToken, out isSandbox);

            return new SfService(username, password, securityToken, isSandbox);
        }

        private static Type TranslateFieldType(fieldType type)
        {
            switch (type)
            {
                case fieldType.@double:
                case fieldType.percent:
                    return typeof (double);
                case fieldType.@int:
                    return typeof (int);
                case fieldType.boolean:
                    return typeof (bool);
                case fieldType.currency:
                    return typeof (decimal);
                case fieldType.date:
                case fieldType.datetime:
                case fieldType.time:
                    return typeof (DateTime);
                default:
                    return typeof (string);
            }
        }

        #endregion Methods 
    }
}