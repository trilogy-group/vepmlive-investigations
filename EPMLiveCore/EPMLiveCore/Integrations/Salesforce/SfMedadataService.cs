using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using EPMLiveCore.Properties;
using EPMLiveCore.SalesforceApexService;
using EPMLiveCore.SalesforceMetadataService;
using EPMLiveCore.SalesforcePartnerService;
using SessionHeader = EPMLiveCore.SalesforcePartnerService.SessionHeader;

namespace EPMLiveCore.Integrations.Salesforce
{
    internal class SfMedadataService : IDisposable
    {
        #region Fields (10) 

        private const int API_VERSION = 26;
        private const string APP_NAME = "EPMLive";
        private const string EXT_ID_FIELD = "__EPM_Live_ID__c";
        private const string REMOTE_SITE_NAME_PREFIX = "EPMLINT";
        private const string TRIGGER_NAME = "EPMLiveIntegrationTrigger";
        private readonly ApexService _apexService;
        private readonly string _appNamespace;
        private readonly LoginResult _loginResult;
        private readonly MetadataService _metadataService;
        private readonly SforceService _sforceService;

        #endregion Fields 

        #region Constructors (2) 

        internal SfMedadataService(string username, string password, string securityToken, string appNamespace)
        {
            _appNamespace = appNamespace;
            _sforceService = new SforceService();
            _loginResult = _sforceService.login(username, password + securityToken);

            _sforceService.Url = _loginResult.serverUrl;
            _sforceService.SessionHeaderValue = new SessionHeader {sessionId = _loginResult.sessionId};

            _metadataService = new MetadataService
                {
                    Url = _loginResult.metadataServerUrl,
                    SessionHeaderValue = new SalesforceMetadataService.SessionHeader
                        {
                            sessionId = _loginResult.sessionId
                        }
                };

            _apexService = new ApexService
                {
                    Url = _loginResult.serverUrl.Replace("/u/", "/s/"),
                    SessionHeaderValue = new SalesforceApexService.SessionHeader
                        {
                            sessionId = _loginResult.sessionId
                        }
                };
        }

        ~SfMedadataService()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Methods (14) 

        // Public Methods (1) 

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected Methods (1) 

        protected void Dispose(bool disposing)
        {
            if (!disposing) return;

            try
            {
                _metadataService.Dispose();
            }
            catch
            {
            }

            try
            {
                _sforceService.Dispose();
            }
            catch
            {
            }

            try
            {
                _apexService.Dispose();
            }
            catch
            {
            }
        }

        // Private Methods (3) 

        private bool IsEPMLiveAppInstalled()
        {
            return
                QueryMetadata("CustomApplication")
                    .Any(fp => fp.fullName.Equals(_appNamespace + "__" + APP_NAME) || fp.fullName.Equals(APP_NAME));
        }

        private static void ProcessTriggerInstallationResults(CompileAndTestResult result, string triggerName)
        {
            if (result.success) return;

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Could not create " + triggerName);

            foreach (CompileTriggerResult triggerResult in result.triggers)
            {
                stringBuilder.AppendLine(triggerResult.problem);
            }

            throw new Exception(stringBuilder.ToString());
        }

        private IEnumerable<FileProperties> QueryMetadata(string metadataType)
        {
            return _metadataService.listMetadata(new[] {new ListMetadataQuery {type = metadataType}}, API_VERSION) ??
                   new FileProperties[] {};
        }

        // Internal Methods (9) 

        internal void ConfigureRemoteSite(string apiUrl)
        {
            var uri = new Uri(apiUrl);
            apiUrl = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

            string remoteSiteSettingName = REMOTE_SITE_NAME_PREFIX + "_" + apiUrl.Md5();

            if (QueryMetadata("RemoteSiteSetting").Any(fp => fp.fullName.Equals(remoteSiteSettingName))) return;

            AsyncResult asyncResult = _metadataService.create(new Metadata[]
                {
                    new RemoteSiteSetting
                        {
                            description = "Allow EPM Live app to call EPM Live Integration service.",
                            disableProtocolSecurity = false,
                            isActive = true,
                            url = apiUrl,
                            fullName = remoteSiteSettingName
                        }
                })[0];

            while (!asyncResult.done)
            {
                Thread.Sleep(1000);
                asyncResult = _metadataService.checkStatus(new[] {asyncResult.id})[0];
            }

            if (asyncResult.state != AsyncRequestState.Completed)
            {
                throw new Exception(asyncResult.message);
            }
        }

        internal DeleteResult[] DeleteItems(string[] ids)
        {
            return _sforceService.delete(ids);
        }

        internal void EnsureEPMLiveAppInstalled()
        {
            if (!IsEPMLiveAppInstalled())
            {
                throw new Exception("EPM Live app is not installed.");
            }
        }

        internal IEnumerable<sObject> ExecuteQuery(string query)
        {
            var items = new List<sObject>();
            bool done = false;

            QueryResult queryResult = _sforceService.query(query);

            if (queryResult.size > 0)
            {
                while (!done)
                {
                    items.AddRange(queryResult.records);

                    if (queryResult.done)
                    {
                        done = true;
                    }
                    else
                    {
                        queryResult = _sforceService.queryMore(queryResult.queryLocator);
                    }
                }
            }
            else
            {
                throw new Exception("No records found. Query: " + query);
            }

            return items;
        }

        internal Field[] GetFields(string sObjectType)
        {
            return _sforceService.describeSObject(sObjectType).fields;
        }

        internal DescribeGlobalSObjectResult[] GetObjects()
        {
            DescribeGlobalResult describeGlobalResult = _sforceService.describeGlobal();
            return describeGlobalResult.sobjects;
        }

        internal void InstallTrigger(string objectName)
        {
            if (objectName.Contains(_appNamespace + "__")) return;

            UninstallTrigger(objectName);

            string triggerName = objectName.Replace("__c", "_custom") + "_" + TRIGGER_NAME;
            string triggerBody =
                new Dictionary<string, string>
                    {
                        {"{TRIGGER_NAME}", triggerName},
                        {"{TRIGGER_OBJECT}", objectName},
                        {"{APP_NAMESPACE}", _appNamespace},
                        {"{TIMESTAMP}", DateTime.Now.ToUniversalTime().ToString("r")}
                    }.Aggregate(Resources.SFIntTrigger, (c, p) => c.Replace(p.Key, p.Value));

            CompileAndTestResult result = _apexService.compileAndTest(new CompileAndTestRequest
                {
                    triggers = new[] {triggerBody},
                    checkOnly = true
                });

            ProcessTriggerInstallationResults(result, triggerName);

            result = _apexService.compileAndTest(new CompileAndTestRequest {triggers = new[] {triggerBody}});

            ProcessTriggerInstallationResults(result, triggerName);
        }

        internal void UninstallTrigger(string objectName)
        {
            if (objectName.Contains(_appNamespace + "__")) return;

            objectName = objectName.Replace("__c", "_custom");

            string triggerName = objectName + "_" + TRIGGER_NAME;

            try
            {
                string query = string.Format("SELECT Id FROM ApexTrigger WHERE Name = '{0}'", triggerName);
                sObject[] triggers = ExecuteQuery(query).ToArray();

                DeleteItems(new[] {triggers.First().Id});
            }
            catch
            {
            }
        }

        internal Dictionary<UpsertKind, SaveResult> UpsertItems(string objectName, DataTable items, bool hasEpmLiveId)
        {
            var objectsToInsert = new List<sObject>();
            var objectsToUpdate = new List<sObject>();

            foreach (DataRow dataRow in items.Rows)
            {
                var sObject = new sObject {type = objectName};

                object oId = dataRow["ID"];
                if (oId != null && oId != DBNull.Value)
                {
                    sObject.Id = oId.ToString();
                }

                var fieldsToNull = new List<string>();
                var xmlElements = new List<XmlElement>();

                var xmlDocument = new XmlDocument();

                if (hasEpmLiveId)
                {
                    XmlElement spIdElement = xmlDocument.CreateElement(_appNamespace + EXT_ID_FIELD);
                    spIdElement.InnerText = dataRow["SPID"].ToString();

                    xmlElements.Add(spIdElement);
                }

                foreach (DataColumn dataColumn in items.Columns)
                {
                    string columnName = dataColumn.ColumnName;

                    if (columnName.ToLower().Equals("id") ||
                        columnName.Equals("SPID") ||
                        columnName.Equals(_appNamespace + EXT_ID_FIELD))
                    {
                        continue;
                    }

                    object oValue = dataRow[dataColumn];
                    if (oValue == null || oValue == DBNull.Value)
                    {
                        fieldsToNull.Add(columnName);
                        continue;
                    }

                    string sValue = oValue.ToString();

                    if (string.IsNullOrEmpty(sValue))
                    {
                        fieldsToNull.Add(columnName);
                        continue;
                    }

                    XmlElement xmlElement = xmlDocument.CreateElement(columnName);
                    xmlElement.InnerText = sValue;

                    xmlElements.Add(xmlElement);
                }

                sObject.Any = xmlElements.ToArray();
                sObject.fieldsToNull = fieldsToNull.ToArray();

                if (string.IsNullOrEmpty(sObject.Id))
                {
                    objectsToInsert.Add(sObject);
                }
                else
                {
                    objectsToUpdate.Add(sObject);
                }
            }

            var upsertResults = new Dictionary<UpsertKind, SaveResult>();

            if (objectsToInsert.Count > 0)
            {
                foreach (SaveResult saveResult in _sforceService.create(objectsToInsert.ToArray()))
                {
                    upsertResults.Add(UpsertKind.INSERT, saveResult);
                }
            }

            if (objectsToUpdate.Count > 0)
            {
                foreach (SaveResult saveResult in _sforceService.update(objectsToUpdate.ToArray()))
                {
                    upsertResults.Add(UpsertKind.UPDATE, saveResult);
                }
            }

            return upsertResults;
        }

        #endregion Methods 
    }

    internal enum UpsertKind
    {
        INSERT,
        UPDATE
    }
}