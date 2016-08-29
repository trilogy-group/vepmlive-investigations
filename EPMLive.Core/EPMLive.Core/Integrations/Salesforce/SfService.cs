using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.Integrations.Salesforce
{
    internal class SfService : IDisposable
    {
        #region Fields (8) 

        private const string INTEGRATION_SERVICE_URL = "integration/v2/";
        private readonly string _additionalAssignedToField;
        private readonly string _appNamespace;
        private readonly string _password;
        private readonly SalesforceAuthResponse _salesforceAuthResponse;
        private readonly string _securityToken;
        private readonly SfMedadataService _sfMedadataService;
        private readonly string _username;

        #endregion Fields 

        #region Constructors (2) 

        internal SfService(string username, string password, string securityToken, bool isSandbox)
        {
            _username = username;
            _password = password;
            _securityToken = securityToken;
            _appNamespace = "EPMLive";
            _additionalAssignedToField = _appNamespace + "__Additional_Assigned_To__c";

            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;

            var collection = new NameValueCollection
                {
                    {"grant_type", "password"},
                    {
                        "client_id",
                        "3MVG9A2kN3Bn17hvG..HNHs0Kg3H6jFJkE33U0ftCFshofixUXXN4n4ZrK8Pq0hSnwtYnMDDkYPGf1zG.cVPx"
                    },
                    {"client_secret", "6940409853544103961"},
                    {"username", _username},
                    {"password", _password + _securityToken}
                };

            using (var webClient = new WebClient
                {
                    BaseAddress =
                        string.Format("https://{0}.salesforce.com/services/oauth2/token", (isSandbox ? "test" : "login"))
                })
            {
                byte[] bytes = webClient.UploadValues(string.Empty, "POST", collection);

                var serializer = new DataContractJsonSerializer(typeof (SalesforceAuthResponse));
                _salesforceAuthResponse = serializer.ReadObject(new MemoryStream(bytes)) as SalesforceAuthResponse;
            }

            // Validating "ModifyAllData" permission. Use of the Metadata API requires a user with the ModifyAllData permission.
            _sfMedadataService = new SfMedadataService(_username, _password, _securityToken, _appNamespace, isSandbox);
        }

        ~SfService()
        {
            Dispose(false);
        }

        #endregion Constructors 

        #region Properties (1) 

        internal string AppNamespace
        {
            get { return _appNamespace; }
        }

        #endregion Properties 

        #region Methods (17) 

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
                _sfMedadataService.Dispose();
            }
            catch
            {
            }
        }

        // Private Methods (5) 

        private void FillItemsTable(string objectName, DataTable items, IEnumerable<sObject> resultItems,
                                    List<string> fields)
        {
            Field[] objFields = _sfMedadataService.GetFields(objectName);

            foreach (sObject sObject in resultItems)
            {
                DataRow dataRow = items.NewRow();

                foreach (
                    string columnName in from DataColumn dataColumn in items.Columns select dataColumn.ColumnName)
                {
                    if (columnName.ToLower().Equals("id"))
                    {
                        dataRow[columnName] = sObject.Id;
                    }
                    else
                    {
                        string name = columnName;
                        foreach (XmlElement xmlElement in sObject.Any.Where(e => e.LocalName.Equals(name)))
                        {
                            dataRow[columnName] = xmlElement.InnerText;
                        }
                    }
                }

                items.Rows.Add(dataRow);
            }

            IEnumerable<string> userFields = from objField in objFields
                                             where
                                                 fields.Contains(objField.name) &&
                                                 objField.type == fieldType.reference &&
                                                 objField.referenceTo.Contains("User")
                                             select objField.name;

            var userIds = new List<string>();
            var userCols = new List<string>();

            foreach (DataRow dataRow in items.Rows)
            {
                foreach (string field in userFields as string[] ?? userFields.ToArray())
                {
                    string id = dataRow[field].ToString();
                    if (string.IsNullOrEmpty(id)) continue;

                    if (!userCols.Contains(field)) userCols.Add(field);

                    string sId = "'" + id + "'";
                    if (!userIds.Contains(sId)) userIds.Add(sId);
                }
            }

            if (userIds.Count <= 0) return;

            string query = string.Format(@"SELECT Id, Email FROM User WHERE Id IN ({0})",
                                         string.Join(",", userIds.ToArray()));
            IEnumerable<sObject> sfUsers = _sfMedadataService.ExecuteQuery(query);

            foreach (sObject sObject in sfUsers)
            {
                foreach (DataRow dataRow in items.Rows)
                {
                    DataRow row = dataRow;
                    sObject o = sObject;

                    foreach (string col in userCols.Where(col => row[col].ToString().Equals(o.Id)))
                    {
                        dataRow[col] = sObject.Any[1].InnerText;
                    }
                }
            }
        }

        private void FillObjectFields(DataTable items, List<string> fields)
        {
            foreach (
                string col in
                    items.Columns.Cast<DataColumn>()
                         .Select(c => c.ColumnName)
                         .Where(c => !c.ToLower().Equals("id") && !fields.Contains(c)))
            {
                fields.Add(col);
            }
        }

        private bool LookupItemExists(string itemId, string objectName)
        {
            try
            {
                _sfMedadataService.ExecuteQuery(string.Format(@"SELECT Id FROM {0} WHERE Id = '{1}' LIMIT 1", objectName,
                                                              itemId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private SalesforceServiceResponse MakeRequest(string serviceUrl, string method,
                                                      Dictionary<string, object> parameters)
        {
            SalesforceServiceResponse response;

            string data = string.Empty;

            if (parameters != null && parameters.Count > 0)
            {
                var paramList = new List<string>();
                foreach (string param in parameters.Select(p => p.Value is string
                                                                    ? string.Format(@"""{0}"":""{1}""", p.Key, p.Value)
                                                                    : string.Format(@"""{0}"":{1}", p.Key,
                                                                                    p.Value.ToString().ToLower()))
                                                   .Where(param => !paramList.Contains(param)))
                {
                    paramList.Add(param);
                }

                data = "{" + string.Join(",", paramList.ToArray()) + "}";
            }

            string address =
                new Uri(
                    new Uri(new Uri(new Uri(_salesforceAuthResponse.InstanceUrl), "/services/apexrest/"),
                            _appNamespace + "/"), serviceUrl).AbsoluteUri;
            using (var webClient = new WebClient {BaseAddress = address})
            {
                webClient.Headers.Add("Content-Type", "application/json");
                webClient.Headers.Add("Authorization", "OAuth " + _salesforceAuthResponse.AccessToken);
                var serializer = new DataContractJsonSerializer(typeof (SalesforceServiceResponse));

                if (method.Equals("GET"))
                {
                    response =
                        serializer.ReadObject(
                            new MemoryStream(Encoding.Default.GetBytes(webClient.DownloadString(string.Empty)))) as
                        SalesforceServiceResponse;
                }
                else
                {
                    response =
                        serializer.ReadObject(
                            new MemoryStream(
                                Encoding.Default.GetBytes(webClient.UploadString(string.Empty, method, data)))) as
                        SalesforceServiceResponse;
                }
            }

            return response;
        }

        private bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain,
                                               SslPolicyErrors sslpolicyerrors)
        {
            return true;
        }

        // Internal Methods (10) 

        internal DeleteResult[] DeleteObjectItemsById(string[] ids)
        {
            return _sfMedadataService.DeleteItems(ids);
        }

        internal void EnsureEPMLiveAppInstalled()
        {
            _sfMedadataService.EnsureEPMLiveAppInstalled();
        }

        internal Dictionary<string, string> GetIntegratableObjects()
        {
            var dictionary = new SortedDictionary<string, string>();

            var ignoredObjects = new[]
                {
                    "IntegrationLog__c", "Integration__c", "ObjectCreationRequest__c", "ObjectTriggerRule__c",
                    "ObjectTrigger__c", "PendingSynchronization__c"
                };

            foreach (DescribeGlobalSObjectResult sObject in _sfMedadataService.GetObjects())
            {
                string name = sObject.name;
                string label = sObject.label;

                if (name.StartsWith(_appNamespace))
                {
                    label += " (EPM Live)";
                }

                if (!ignoredObjects.Contains(name.Replace(_appNamespace + "__", string.Empty)))
                {
                    dictionary.Add(name, label);
                }
            }

            return dictionary.OrderBy(o => o.Value).ToDictionary(o => o.Key, o => o.Value);
        }

        internal Field[] GetObjectFields(string obj)
        {
            return _sfMedadataService.GetFields(obj);
        }

        internal void GetObjectItems(string objectName, DataTable items, DateTime lastSyncDateTime)
        {
            var fields = new List<string>();
            FillObjectFields(items, fields);

            lastSyncDateTime = DateTime.SpecifyKind(lastSyncDateTime.ToUniversalTime(), DateTimeKind.Utc);

            string query =
                string.Format(
                    @"SELECT Id,{0} FROM {1} WHERE CreatedDate > {2} OR LastModifiedDate > {2} OR SystemModstamp > {2}",
                    string.Join(",", fields.ToArray()), objectName,
                    lastSyncDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff+0000"));

            IEnumerable<sObject> resultItems = _sfMedadataService.ExecuteQuery(query);

            FillItemsTable(objectName, items, resultItems, fields);
        }

        internal void GetObjectItemsById(string objectName, string itemIds, DataTable items)
        {
            var fields = new List<string>();
            FillObjectFields(items, fields);

            var idlist = new List<string>();
            foreach (
                string sId in itemIds.Split(',').Select(id => "'" + id + "'").Where(sId => !idlist.Contains(sId)))
            {
                idlist.Add(sId);
            }

            string query = string.Format(@"SELECT Id,{0} FROM {1} WHERE Id IN ({2})",
                                         string.Join(",", fields.ToArray()), objectName,
                                         string.Join(",", idlist.ToArray()));

            IEnumerable<sObject> resultItems = _sfMedadataService.ExecuteQuery(query);

            FillItemsTable(objectName, items, resultItems, fields);
        }

        internal void InstallIntegration(string integrationKey, string apiUrl, string webName, string webUrl,
                                         Guid integrationId, string objectName, bool incomingEnabled,
                                         bool outgoingEnabled, bool allowDeletion)
        {
            _sfMedadataService.InstallTrigger(objectName);
            _sfMedadataService.ConfigureRemoteSite(apiUrl);

            var parameters = new Dictionary<string, object>
                {
                    {"key", integrationKey},
                    {"intId", integrationId.ToString()},
                    {"objectName", objectName},
                    {"apiUrl", apiUrl},
                    {"webName", webName},
                    {"webUrl", webUrl},
                    {"incomingEnabled", incomingEnabled},
                    {"outgoingEnabled", outgoingEnabled},
                    {"allowDeletion", allowDeletion}
                };

            SalesforceServiceResponse response = MakeRequest(INTEGRATION_SERVICE_URL, "POST", parameters);

            if (!response.Success)
            {
                throw new Exception(response.Message);
            }
        }

        internal bool IsSyncEnabled()
        {
            SalesforceServiceResponse response = MakeRequest(INTEGRATION_SERVICE_URL + "syncstatus", "GET", null);

            if (!response.Success)
            {
                throw new Exception(response.Message);
            }

            return response.Message.Equals("Online");
        }

        internal void UninstallIntegration(string integrationKey, string objectName)
        {
            _sfMedadataService.UninstallTrigger(objectName);

            SalesforceServiceResponse response = MakeRequest(INTEGRATION_SERVICE_URL + integrationKey, "DELETE", null);

            if (!response.Success)
            {
                throw new Exception(response.Message);
            }
        }

        internal List<Dictionary<UpsertKind, SaveResult>> UpsertItems(string objectName, DataTable items)
        {
            var fields = new List<string>();
            FillObjectFields(items, fields);

            var userFields = new List<string>();
            var lookupFields = new List<string>();
            var percentFields = new List<string>();
            var dateFields = new List<string>();
            var timeFields = new List<string>();

            var lookupFieldObjects = new Dictionary<string, string>();

            Field[] objFields = _sfMedadataService.GetFields(objectName);
            foreach (Field objField in objFields)
            {
                string fieldName = objField.name;
                DataColumnCollection dataColumnCollection = items.Columns;
                if (!dataColumnCollection.Contains(fieldName)) continue;

                switch (objField.type)
                {
                    case fieldType.reference:
                        if (objField.referenceTo.Contains("User"))
                        {
                            userFields.Add(fieldName);
                        }
                        else
                        {
                            lookupFields.Add(fieldName);
                            if (!lookupFieldObjects.ContainsKey(fieldName))
                            {
                                lookupFieldObjects.Add(fieldName, objField.referenceTo[0]);
                            }
                        }
                        break;
                    case fieldType.percent:
                        percentFields.Add(fieldName);
                        break;
                    case fieldType.date:
                        dateFields.Add(fieldName);
                        break;
                    case fieldType.time:
                        timeFields.Add(fieldName);
                        break;
                }
            }

            var userEmailIdMap = new Dictionary<string, string>();
            var userEmailNameMap = new Dictionary<string, string>();

            var emailList = new List<string>();
            foreach (DataRow dataRow in items.Rows)
            {
                foreach (string userField in userFields)
                {
                    object o = dataRow[userField];
                    if (o == null || o == DBNull.Value) continue;

                    if (string.IsNullOrEmpty(o.ToString())) continue;

                    string[] emails = o.ToString().Split(',');
                    foreach (string sEmail in emails.Select(email => "'" + email + "'")
                                                    .Where(sEmail => !emailList.Contains(sEmail)))
                    {
                        emailList.Add(sEmail);
                    }

                    dataRow[userField] = emails[0];

                    if (emails.Count() <= 1) continue;

                    if (!items.Columns.Contains(_additionalAssignedToField))
                    {
                        items.Columns.Add(_additionalAssignedToField, typeof (string));
                    }

                    string[] additionalUsers = (emails.Select(e => e)).Skip(1).ToArray();
                    dataRow[_additionalAssignedToField] = string.Join(",", additionalUsers);
                }
            }

            string userEmail = string.Empty;

            if (emailList.Count > 0)
            {
                try
                {
                    IEnumerable<sObject> sfUsers =
                        _sfMedadataService.ExecuteQuery(
                            string.Format(
                                "SELECT Id, Email, Name, Username FROM User WHERE Email IN ({0}) OR Username = '{1}'",
                                string.Join(",", emailList.ToArray()), _username));

                    foreach (sObject sObject in sfUsers)
                    {
                        string email = sObject.Any[1].InnerText;
                        if (userEmailIdMap.ContainsKey(email)) continue;

                        userEmailIdMap.Add(email, sObject.Id);
                        userEmailNameMap.Add(email, sObject.Any[2].InnerText);

                        if (sObject.Any[3].InnerText.Equals(_username))
                        {
                            userEmail = email;
                        }
                    }
                }
                catch
                {
                }
            }

            foreach (DataRow dataRow in items.Rows)
            {
                foreach (string userField in userFields)
                {
                    object value = null;

                    object oEmail = dataRow[userField];
                    if (oEmail != null && oEmail != DBNull.Value)
                    {
                        string email = oEmail.ToString();
                        if (userEmailIdMap.ContainsKey(email))
                        {
                            value = userEmailIdMap[email];
                        }
                        else if (userField.ToLower().Equals("ownerid"))
                        {
                            try
                            {
                                value = userEmailIdMap[userEmail];
                            }
                            catch
                            {
                            }
                        }
                    }

                    dataRow[userField] = value;
                }

                if (items.Columns.Contains(_additionalAssignedToField))
                {
                    foreach (var p in userEmailNameMap)
                    {
                        dataRow[_additionalAssignedToField] =
                            dataRow[_additionalAssignedToField].ToString().Replace(p.Key, p.Value);
                    }
                }

                foreach (string lookupField in lookupFields)
                {
                    object oValue = dataRow[lookupField];
                    if (oValue != null && oValue != DBNull.Value)
                    {
                        if (oValue.ToString().Contains(";#")) dataRow[lookupField] = null;
                    }

                    oValue = dataRow[lookupField];

                    if (oValue != null && oValue != DBNull.Value)
                    {
                        if (!LookupItemExists(oValue.ToString(), lookupFieldObjects[lookupField]))
                        {
                            dataRow[lookupField] = null;
                        }
                    }
                }

                foreach (string percentField in percentFields)
                {
                    object oValue = dataRow[percentField];
                    if (oValue == null || oValue == DBNull.Value) continue;

                    double dValue;
                    if (double.TryParse(oValue.ToString(), out dValue))
                    {
                        dataRow[percentField] = dValue/100;
                    }
                }

                foreach (string dateField in dateFields)
                {
                    object oValue = dataRow[dateField];
                    if (oValue == null || oValue == DBNull.Value) continue;

                    DateTime dtValue;
                    if (DateTime.TryParse(oValue.ToString(), out dtValue))
                    {
                        dataRow[dateField] = dtValue.ToString("yyyy-MM-dd");
                    }
                }

                foreach (string timeField in timeFields)
                {
                    object oValue = dataRow[timeField];
                    if (oValue == null || oValue == DBNull.Value) continue;

                    DateTime dtValue;
                    if (DateTime.TryParse(oValue.ToString(), out dtValue))
                    {
                        dataRow[timeField] = dtValue.ToString("HH:mm:ss");
                    }
                }
            }

            Field extIdField = objFields.FirstOrDefault(f => f.name.Equals(_appNamespace + "__EPM_Live_ID__c"));

            return _sfMedadataService.UpsertItems(objectName, items, extIdField != null);
        }

        #endregion Methods 
    }
}