using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using UplandIntegrations.Utils;

namespace UplandIntegrations.Desk
{
    public class DeskService : IDisposable
    {
        private RestClient restClient;
        private JsonSerializerSettings jsonSerializerSettings;
        private string[] mainProps = { "custom_fields", "message", "_links", "_embedded" };
        private string[] linkProps = { "self", "customer", "assigned_user", "assigned_group" };
        private string[] embeddedProps = { "assigned_user" };

        #region Constructor

        public DeskService(string serverUrl, string userName, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(serverUrl))
                {
                    throw new Exception("Please provide the serverurl");
                }
                if (string.IsNullOrEmpty(userName))
                {
                    throw new Exception("Please provide the username");
                }
                if (string.IsNullOrEmpty(password))
                {
                    throw new Exception("Please provide the password");
                }

                jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;


                restClient = new RestClient(serverUrl)
                {
                    Authenticator = new HttpBasicAuthenticator(userName, password)
                };

                RestRequest restRequest = new RestRequest();
                restRequest.Resource = serverUrl;
                restRequest.AddParameter(new Parameter()
                {
                    Name = "username",
                    Value = userName,
                    Type = ParameterType.GetOrPost
                });
                restRequest.AddParameter(new Parameter()
                {
                    Name = "password",
                    Value = password,
                    Type = ParameterType.GetOrPost
                });
                restRequest.Method = Method.POST;

                var response = restClient.Execute(restRequest);

                if (response.ResponseStatus != ResponseStatus.Completed || response.ErrorException != null || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(string.Format("RestSharp response status: {0} - HTTP response: {1} - {2} {3} {4}", response.ResponseStatus, response.StatusCode, response.StatusDescription, response.Content, response.ErrorMessage));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Public

        public void InstallWebhook(string objectName, string integrationKey, string userName, string password, string apiUrl)
        {
            try
            {
                apiUrl = apiUrl.ToLower().Replace("integration.asmx", "postitemsimple.aspx");
                string objectId = string.Empty;

                DeskType deskType = (DeskType)Enum.Parse(typeof(DeskType), objectName);
                switch (deskType)
                {
                    case DeskType.Companies:
                        objectId = "{{company.id}}";
                        break;
                    case DeskType.Customers:
                        objectId = "{{customer.id}}";
                        break;
                    case DeskType.Cases:
                        objectId = "{{case.id}}";
                        break;
                    case DeskType.Users:
                        objectId = "{{user.id}}";
                        break;
                    default:
                        break;
                }

                if (!string.IsNullOrEmpty(objectId))
                {
                    Dictionary<string, object> payLoad = new Dictionary<string, object>();
                    payLoad.Add("name", integrationKey);
                    payLoad.Add("description", "integration url for epmlive");
                    payLoad.Add("enabled", true);
                    payLoad.Add("markup", string.Format("{0}?integrationkey={1}&id={2}", apiUrl, integrationKey, objectId));

                    var request = new RestRequest()
                    {
                        Resource = GetRestRequestResourceByDeskType(DeskType.Integration_URLs),
                        RequestFormat = DataFormat.Json,
                        JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                        Method = Method.POST
                    };

                    request.AddBody(payLoad);
                    Execute(request);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RemoveWebhook(string objectName, string serverUrl, string integrationKey)
        {
            try
            {

                Int64 integrationUrlId = 0;

                var request = new RestRequest();
                request.Resource = GetRestRequestResourceByDeskType(DeskType.Integration_URLs);
                request.Method = Method.GET;

                var response = restClient.Execute(request);

                var jsonWebhooks = JValue.Parse(response.Content)["_embedded"]["entries"];

                foreach (JObject jsonWebhook in jsonWebhooks)
                {
                    if (Convert.ToString(jsonWebhook["name"]) == integrationKey)
                    {
                        integrationUrlId = Convert.ToInt64(Convert.ToString(jsonWebhook["_links"]["self"]["href"]).Replace(serverUrl, "").Replace(GetRestRequestResourceByDeskType(DeskType.Integration_URLs), "").Replace("/", ""));
                        request = new RestRequest();
                        request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByDeskType(DeskType.Integration_URLs), integrationUrlId);
                        request.Method = Method.DELETE;
                        Execute(request);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetObjectItem(string objectName, DataTable items, string itemId, Boolean isOnlyColumns)
        {
            try
            {

                DeskType deskType = (DeskType)Enum.Parse(typeof(DeskType), objectName);
                switch (deskType)
                {
                    case DeskType.Companies:
                        GetCompany(items, itemId, isOnlyColumns);
                        break;
                    case DeskType.Customers:
                        GetCustomer(items, itemId, isOnlyColumns);
                        break;
                    case DeskType.Cases:
                        GetCase(items, itemId, isOnlyColumns);
                        break;
                    case DeskType.Users:
                        GetUser(items, itemId, isOnlyColumns);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetObjectItems(string objectName, DataTable items, DateTime lastSyncDateTime, Boolean isOnlyColumns)
        {
            try
            {
                DeskType deskType = (DeskType)Enum.Parse(typeof(DeskType), objectName);
                switch (deskType)
                {
                    case DeskType.Companies:
                        GetCompaniesByLastSyncDateTime(items, lastSyncDateTime, isOnlyColumns);
                        break;
                    case DeskType.Customers:
                        GetCustomersByLastSyncDateTime(items, lastSyncDateTime, isOnlyColumns);
                        break;
                    case DeskType.Cases:
                        GetCasesByLastSyncDateTime(items, lastSyncDateTime, isOnlyColumns);
                        break;
                    case DeskType.Users:
                        GetUsers(items, isOnlyColumns);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int64 CreateObjectItem(string objectName, DataRow Item, DataColumnCollection dataColumns)
        {
            try
            {
                DeskType deskType = (DeskType)Enum.Parse(typeof(DeskType), objectName);
                switch (deskType)
                {
                    case DeskType.Companies:
                        return CreateCompany(GetJson(Item, DeskType.Companies, dataColumns));
                    case DeskType.Customers:
                        return CreateCustomer(GetJson(Item, DeskType.Customers, dataColumns));
                    case DeskType.Cases:
                        if (dataColumns.Contains("_embedded|assigned_user|email"))
                        {
                            Item["_links|assigned_user|id"] = GetUserIdByEmail(Item["_embedded|assigned_user|email"].ToString());
                        }
                        return CreateCase(GetJson(Item, DeskType.Cases, dataColumns));
                    default:
                        break;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateObjectItem(string objectName, DataRow Item, Int64 itemId, DataColumnCollection dataColumns)
        {
            try
            {
                DeskType deskType = (DeskType)Enum.Parse(typeof(DeskType), objectName);
                switch (deskType)
                {
                    case DeskType.Companies:
                        UpdateCompany(GetJson(Item, DeskType.Companies, dataColumns), itemId);
                        break;
                    case DeskType.Customers:
                        UpdateCustomer(GetJson(Item, DeskType.Customers, dataColumns), itemId);
                        break;
                    case DeskType.Cases:
                        if (dataColumns.Contains("_embedded|assigned_user|email"))
                        {
                            Item["_links|assigned_user|id"] = GetUserIdByEmail(Item["_embedded|assigned_user|email"].ToString());
                        }
                        UpdateCase(GetJson(Item, DeskType.Cases, dataColumns), itemId);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteObjectItem(string objectName, Int64 itemId)
        {
            try
            {
                DeskType deskType = (DeskType)Enum.Parse(typeof(DeskType), objectName);
                switch (deskType)
                {
                    case DeskType.Cases:
                        DeleteCase(itemId);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetViewUrlResourceByDeskType(string objectName)
        {
            DeskType deskType = (DeskType)Enum.Parse(typeof(DeskType), objectName);
            switch (deskType)
            {
                case DeskType.Cases:
                    return "agent/case";
                default:
                    return "";
            }
        }

        #endregion

        #region Private

        private Int64 CreateCompany(JObject payLoad)
        {
            Int64 companyId = 0;
            var request = new RestRequest()
            {
                Resource = GetRestRequestResourceByDeskType(DeskType.Companies),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.POST
            };
            request.AddBody(payLoad);
            RestResponse response = Execute(request);
            if (response != null && !string.IsNullOrEmpty(response.Content))
            {
                var jsonObjectData = JValue.Parse(response.Content);
                companyId = Convert.ToInt64(Convert.ToString(jsonObjectData["_links"]["self"]["href"]).Replace(GetRestRequestResourceByDeskType(DeskType.Companies), "").Replace("/", ""));
            }
            return companyId;
        }
        private Int64 CreateCustomer(JObject payLoad)
        {
            Int64 customerId = 0;
            var request = new RestRequest()
            {
                Resource = GetRestRequestResourceByDeskType(DeskType.Customers),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.POST
            };
            request.AddBody(payLoad);
            RestResponse response = Execute(request);
            if (response != null && !string.IsNullOrEmpty(response.Content))
            {
                var jsonObjectData = JValue.Parse(response.Content);
                customerId = Convert.ToInt64(Convert.ToString(jsonObjectData["_links"]["self"]["href"]).Replace(GetRestRequestResourceByDeskType(DeskType.Customers), "").Replace("/", ""));
            }
            return customerId;
        }
        private Int64 CreateCase(JObject payLoad)
        {
            Int64 caseId = 0;

            var request = new RestRequest()
            {
                Resource = GetRestRequestResourceByDeskType(DeskType.Cases),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.POST
            };
            request.AddBody(payLoad);
            RestResponse response = Execute(request);
            if (response != null && !string.IsNullOrEmpty(response.Content))
            {
                var jsonObjectData = JValue.Parse(response.Content);
                caseId = Convert.ToInt64(Convert.ToString(jsonObjectData["_links"]["self"]["href"]).Replace(GetRestRequestResourceByDeskType(DeskType.Cases), "").Replace("/", ""));
            }
            return caseId;
        }

        private void UpdateCompany(JObject payLoad, Int64 itemId)
        {
            var request = new RestRequest()
            {
                Resource = string.Format("{0}/{1}", GetRestRequestResourceByDeskType(DeskType.Companies), itemId),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.PATCH
            };
            request.AddBody(payLoad);
            Execute(request);
        }
        private void UpdateCustomer(JObject payLoad, Int64 itemId)
        {
            var request = new RestRequest()
            {
                Resource = string.Format("{0}/{1}", GetRestRequestResourceByDeskType(DeskType.Customers), itemId),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.PATCH
            };
            request.AddBody(payLoad);
            Execute(request);
        }
        private void UpdateCase(JObject payLoad, Int64 itemId)
        {
            var request = new RestRequest()
            {
                Resource = string.Format("{0}/{1}", GetRestRequestResourceByDeskType(DeskType.Cases), itemId),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.PATCH
            };
            request.AddBody(payLoad);
            Execute(request);
        }

        private void DeleteCase(Int64 caseId)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByDeskType(DeskType.Cases), caseId);
            request.Method = Method.DELETE;
            Execute(request);
        }

        private Int64 GetUserIdByEmail(string email)
        {
            DataTable users = new DataTable();
            GetUsers(users, false);
            DataRow[] selectedRows = users.Select(string.Format("email = '{0}'", email));
            if (selectedRows != null)
            {
                return Convert.ToInt64(selectedRows[0]["_links|self|id"]);
            }
            else
            {
                return 0;
            }
        }
        private void GetUser(DataTable items, string id, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByDeskType(DeskType.Users), id);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }

            var jsonObjects = JValue.Parse(response.Content);

            FillDataTableFromJson(items, (JObject)jsonObjects, isOnlyColumns);
        }
        private void GetUsers(DataTable items, Boolean isOnlyColumns)
        {
            Int32 pageSize = 50;
            Int32 pageCount = 1;
            Double totalRecords = 0;
            Double noOfPages = 0;

            var request = new RestRequest();
            request.Resource = string.Format("{0}?page={1}&per_page={2}", GetRestRequestResourceByDeskType(DeskType.Users), pageCount, pageSize);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }


            var jsonData = JValue.Parse(response.Content);

            totalRecords = Convert.ToDouble(jsonData["total_entries"].ToString());
            noOfPages = Math.Ceiling(totalRecords / pageSize);

            var jsonObjects = jsonData["_embedded"]["entries"];
            foreach (var jsonObject in jsonObjects)
            {
                FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
            }

            for (pageCount = 2; pageCount <= noOfPages; pageCount++)
            {
                var requestSub = new RestRequest();
                requestSub.Resource = string.Format("{0}?page={1}&per_page={2}", GetRestRequestResourceByDeskType(DeskType.Users), pageCount, pageSize);
                requestSub.Method = Method.GET;

                var responseSub = restClient.Execute(requestSub);

                JObject jsonResponseDataSub = (JObject)JValue.Parse(responseSub.Content);
                if (jsonResponseDataSub.GetValue("message") != null)
                {
                    throw new Exception(jsonResponseDataSub.GetValue("message").ToString());
                }

                var jsonDataSub = JValue.Parse(responseSub.Content);

                var jsonObjectsSub = jsonDataSub["_embedded"]["entries"];
                foreach (var jsonObject in jsonObjectsSub)
                {
                    FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
                }

            }
        }

        private void GetCompany(DataTable items, string id, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByDeskType(DeskType.Companies), id);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }

            var jsonObjects = JValue.Parse(response.Content);

            FillDataTableFromJson(items, (JObject)jsonObjects, isOnlyColumns);
        }
        private void GetCompaniesByLastSyncDateTime(DataTable items, DateTime lastSyncDateTime, Boolean isOnlyColumns)
        {
            Int32 pageSize = 50;
            Int32 pageCount = 1;
            Double totalRecords = 0;
            Double noOfPages = 0;

            var request = new RestRequest();
            request.Resource = string.Format("{0}?page={1}&per_page={2}", GetRestRequestResourceByDeskType(DeskType.Companies), pageCount, pageSize);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }


            var jsonData = JValue.Parse(response.Content);

            totalRecords = Convert.ToDouble(jsonData["total_entries"].ToString());
            noOfPages = Math.Ceiling(totalRecords / pageSize);

            var jsonObjects = jsonData["_embedded"]["entries"];
            foreach (var jsonObject in jsonObjects)
            {
                FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
            }

            for (pageCount = 2; pageCount <= noOfPages; pageCount++)
            {
                var requestSub = new RestRequest();
                requestSub.Resource = string.Format("{0}/search?page={1}&per_page={2}&since_updated_at={3}", GetRestRequestResourceByDeskType(DeskType.Companies), pageCount, pageSize, ConvertToUnixTimestamp(lastSyncDateTime));
                requestSub.Method = Method.GET;

                var responseSub = restClient.Execute(requestSub);

                JObject jsonResponseDataSub = (JObject)JValue.Parse(responseSub.Content);
                if (jsonResponseDataSub.GetValue("message") != null)
                {
                    throw new Exception(jsonResponseDataSub.GetValue("message").ToString());
                }

                var jsonDataSub = JValue.Parse(responseSub.Content);

                var jsonObjectsSub = jsonDataSub["_embedded"]["entries"];
                foreach (var jsonObject in jsonObjectsSub)
                {
                    FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
                }

            }
        }

        private void GetCustomer(DataTable items, string id, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByDeskType(DeskType.Customers), id);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }

            var jsonObjects = JValue.Parse(response.Content);

            FillDataTableFromJson(items, (JObject)jsonObjects, isOnlyColumns);
        }
        private void GetCustomersByLastSyncDateTime(DataTable items, DateTime lastSyncDateTime, Boolean isOnlyColumns)
        {
            Int32 pageSize = 50;
            Int32 pageCount = 1;
            Double totalRecords = 0;
            Double noOfPages = 0;

            var request = new RestRequest();
            request.Resource = string.Format("{0}/search?page={1}&per_page={2}&since_updated_at={3}", GetRestRequestResourceByDeskType(DeskType.Customers), pageCount, pageSize, ConvertToUnixTimestamp(lastSyncDateTime));
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }


            var jsonData = JValue.Parse(response.Content);

            totalRecords = Convert.ToDouble(jsonData["total_entries"].ToString());
            noOfPages = Math.Ceiling(totalRecords / pageSize);

            var jsonObjects = jsonData["_embedded"]["entries"];
            foreach (var jsonObject in jsonObjects)
            {
                FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
            }

            for (pageCount = 2; pageCount <= noOfPages; pageCount++)
            {
                var requestSub = new RestRequest();
                requestSub.Resource = string.Format("{0}/search?page={1}&per_page={2}&since_updated_at={3}", GetRestRequestResourceByDeskType(DeskType.Customers), pageCount, pageSize, ConvertToUnixTimestamp(lastSyncDateTime));
                requestSub.Method = Method.GET;

                var responseSub = restClient.Execute(requestSub);

                JObject jsonResponseDataSub = (JObject)JValue.Parse(responseSub.Content);
                if (jsonResponseDataSub.GetValue("message") != null)
                {
                    throw new Exception(jsonResponseDataSub.GetValue("message").ToString());
                }

                var jsonDataSub = JValue.Parse(responseSub.Content);

                var jsonObjectsSub = jsonDataSub["_embedded"]["entries"];
                foreach (var jsonObject in jsonObjectsSub)
                {
                    FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
                }

            }


        }

        private void GetCase(DataTable items, string id, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}?embed=assigned_user", GetRestRequestResourceByDeskType(DeskType.Cases), id);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }

            var jsonObjects = JValue.Parse(response.Content);

            FillDataTableFromJson(items, (JObject)jsonObjects, isOnlyColumns);
        }
        private void GetCasesByLastSyncDateTime(DataTable items, DateTime lastSyncDateTime, Boolean isOnlyColumns)
        {
            Int32 pageSize = 50;
            Int32 pageCount = 1;
            Double totalRecords = 0;
            Double noOfPages = 0;

            var request = new RestRequest();
            request.Resource = string.Format("{0}/search?page={1}&per_page={2}&since_updated_at={3}&embed=assigned_user", GetRestRequestResourceByDeskType(DeskType.Cases), pageCount, pageSize, ConvertToUnixTimestamp(lastSyncDateTime));
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }


            var jsonData = JValue.Parse(response.Content);

            totalRecords = Convert.ToDouble(jsonData["total_entries"].ToString());
            noOfPages = Math.Ceiling(totalRecords / pageSize);

            var jsonObjects = jsonData["_embedded"]["entries"];
            foreach (var jsonObject in jsonObjects)
            {
                FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
            }

            for (pageCount = 2; pageCount <= noOfPages; pageCount++)
            {
                var requestSub = new RestRequest();
                requestSub.Resource = string.Format("{0}/search?page={1}&per_page={2}&since_updated_at={3}&embed=assigned_user", GetRestRequestResourceByDeskType(DeskType.Cases), pageCount, pageSize, ConvertToUnixTimestamp(lastSyncDateTime));
                requestSub.Method = Method.GET;

                var responseSub = restClient.Execute(requestSub);

                JObject jsonResponseDataSub = (JObject)JValue.Parse(responseSub.Content);
                if (jsonResponseDataSub.GetValue("message") != null)
                {
                    throw new Exception(jsonResponseDataSub.GetValue("message").ToString());
                }

                var jsonDataSub = JValue.Parse(responseSub.Content);

                var jsonObjectsSub = jsonDataSub["_embedded"]["entries"];
                foreach (var jsonObject in jsonObjectsSub)
                {
                    FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
                }

            }

        }

        private RestResponse Execute(RestRequest request)
        {
            var response = restClient.Execute(request);

            if (request.Method != Method.DELETE)
            {
                JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
                if (jsonResponseData.GetValue("message") != null)
                {
                    throw new Exception(jsonResponseData.GetValue("message").ToString());
                }
            }

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception(string.Format("RestSharp response status: {0} - HTTP response: {1} - {2} {3} {4}", response.ResponseStatus, response.StatusCode, response.StatusDescription, response.Content, response.ErrorMessage));
            }

            switch (request.Method)
            {
                case Method.DELETE:
                    if (response.StatusCode != HttpStatusCode.NoContent)
                    {
                        throw new Exception(string.Format("RestSharp response status: {0} - HTTP response: {1} - {2} {3} {4}", response.ResponseStatus, response.StatusCode, response.StatusDescription, response.Content, response.ErrorMessage));
                    }
                    break;
                case Method.POST:
                    if (response.StatusCode != HttpStatusCode.Created)
                    {
                        throw new Exception(string.Format("RestSharp response status: {0} - HTTP response: {1} - {2} {3} {4}", response.ResponseStatus, response.StatusCode, response.StatusDescription, response.Content, response.ErrorMessage));
                    }
                    break;
                case Method.PUT:
                    if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                    {
                    }
                    else
                    {
                        throw new Exception(string.Format("RestSharp response status: {0} - HTTP response: {1} - {2} {3} {4}", response.ResponseStatus, response.StatusCode, response.StatusDescription, response.Content, response.ErrorMessage));
                    }
                    break;
                default:
                    break;
            }

            return (RestResponse)response;
        }
        private string GetRestRequestResourceByDeskType(DeskType deskType)
        {
            switch (deskType)
            {
                case DeskType.Companies:
                    return "api/v2/companies";
                case DeskType.Customers:
                    return "api/v2/customers";
                case DeskType.Cases:
                    return "api/v2/cases";
                case DeskType.Users:
                    return "api/v2/users";
                case DeskType.Integration_URLs:
                    return "api/v2/integration_urls";
                default:
                    return "";
            }
        }
        private JObject GetJson(DataRow dataRow, DeskType deskType, DataColumnCollection dataColumns)
        {
            JsonSerializer json = new JsonSerializer();
            StringWriter sw = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(sw);

            writer.WriteStartObject();

            var dataColumnsList = (from dc in dataColumns.Cast<DataColumn>()
                                   select dc).OrderBy(c => c.ColumnName);

            Boolean subColumnStart = false;
            string subColumnsArrayColumnName = "";

            foreach (DataColumn column in dataColumnsList)
            {
                if (column.ColumnName.Equals("SPID"))
                    continue;

                if (dataRow[column] != null && !string.IsNullOrEmpty(Convert.ToString(dataRow[column])))
                {
                    if (column.ColumnName.Contains("|"))
                    {
                        string[] subColumnsArray = column.ColumnName.Split('|');

                        if (mainProps.Contains(subColumnsArray[0]))
                        {

                            if (subColumnsArrayColumnName != subColumnsArray[0])
                            {
                                if (subColumnStart)
                                {
                                    writer.WriteEndObject();
                                    subColumnStart = false;
                                }
                                subColumnsArrayColumnName = subColumnsArray[0];
                            }

                            if (!subColumnStart)
                            {
                                writer.WritePropertyName(subColumnsArray[0]);
                                writer.WriteStartObject();
                                subColumnStart = true;
                            }

                            if (subColumnsArray.Count() == 2) // For custom_fields, message
                            {
                                writer.WritePropertyName(subColumnsArray[1]);
                                json.Serialize(writer, dataRow[column]);
                            }
                            else if (subColumnsArray.Count() == 3) // For _links
                            {
                                writer.WritePropertyName(subColumnsArray[1]);
                                writer.WriteStartObject();

                                writer.WritePropertyName("href");
                                json.Serialize(writer, string.Format("{0}/{1}", GetDeskObjectHref(subColumnsArray[1]), dataRow[column]));
                                writer.WritePropertyName("class");
                                json.Serialize(writer, GetDeskObjectClass(subColumnsArray[1]));
                                writer.WriteEndObject();

                            }
                            else
                            {
                                writer.WritePropertyName(subColumnsArray[0]);
                                json.Serialize(writer, dataRow[column]);
                            }

                        }

                    }
                    else
                    {
                        if (subColumnStart)
                        {
                            writer.WriteEndObject();
                            subColumnStart = false;
                        }
                        writer.WritePropertyName(column.ColumnName);
                        json.Serialize(writer, dataRow[column]);
                    }
                }
            }
            if (subColumnStart)
            {
                writer.WriteEndObject();
                subColumnStart = false;
            }

            writer.WriteEndObject();
            writer.QuoteChar = '"';

            return JObject.Parse(sw.ToString());
        }
        private void FillDataTableFromJson(DataTable items, JObject jsonObject, Boolean isOnlyColumns)
        {
            if (jsonObject.GetValue("message") != null) { return; }

            GetColumns(items, jsonObject);

            if (isOnlyColumns) { return; }

            DataRow dataRow = items.NewRow();
            foreach (JProperty property in jsonObject.Properties())
            {
                if (property.Value.GetType() == typeof(JValue))
                {
                    if (items.Columns.Contains(property.Name))
                    {
                        dataRow[property.Name] = property.Value;
                    }
                }
                else if (mainProps.Contains(property.Name) && property.Value.GetType() == typeof(JObject))
                {
                    switch (property.Name)
                    {
                        case "_links":
                            foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                            {
                                if (linkProps.Contains(subProperty.Name) && subProperty.Value.GetType() == typeof(JObject))
                                {
                                    if (items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "id")))
                                    {
                                        string href = subProperty.Value["href"].ToString();
                                        Int32 lIndxOf = href.LastIndexOf('/');
                                        if (!string.IsNullOrEmpty(href))
                                        {
                                            href = href.Substring(lIndxOf + 1, href.Length - lIndxOf - 1);
                                            dataRow[(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "id"))] = href;
                                        }
                                    }
                                }
                            }
                            break;
                        case "_embedded":
                            foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                            {
                                if (embeddedProps.Contains(subProperty.Name) && subProperty.Value.GetType() == typeof(JObject))
                                {
                                    if (items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "email")))
                                    {
                                        dataRow[(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "email"))] = subProperty.Value["email"].ToString();
                                    }
                                }
                            }
                            break;
                        default:
                            foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                            {
                                if (subProperty.Value.GetType() == typeof(JValue))
                                {
                                    if (items.Columns.Contains(string.Format("{0}|{1}", property.Name, subProperty.Name)))
                                    {
                                        dataRow[(string.Format("{0}|{1}", property.Name, subProperty.Name))] = subProperty.Value;
                                    }
                                }
                            }
                            break;
                    }

                }

                //else if (property.Value.GetType() == typeof(JArray))
                //{
                //    JArray propertyJArray = JArray.Parse(property.Value.ToString());
                //    if (propertyJArray != null && propertyJArray.Count > 0 && propertyJArray[0].GetType() == typeof(JValue))
                //    {
                //        foreach (JValue propertyJValue in propertyJArray)
                //        {
                //            if (items.Columns.Contains(string.Format("{0}|{1}", property.Name, "0")))
                //            {
                //                string dataRowPreviousValue = Convert.ToString(dataRow[string.Format("{0}|{1}", property.Name, "0")]);
                //                if (string.IsNullOrEmpty(dataRowPreviousValue))
                //                {
                //                    dataRow[string.Format("{0}|{1}", property.Name, "0")] = propertyJValue.Value;
                //                }
                //                else
                //                {
                //                    dataRow[string.Format("{0}|{1}", property.Name, "0")] = string.Format("{0},{1}", dataRowPreviousValue, propertyJValue.Value);
                //                }
                //            }
                //        }
                //    }
                //    else if (propertyJArray != null && propertyJArray.Count > 0 && propertyJArray[0].GetType() == typeof(JObject))
                //    {
                //        Int32 arrayObjectCount = 0;
                //        foreach (JObject propertyJValue in propertyJArray)
                //        {
                //            foreach (JProperty subProperty in propertyJValue.Properties())
                //            {
                //                if (items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, arrayObjectCount, subProperty.Name)))
                //                {
                //                    dataRow[string.Format("{0}|{1}|{2}", property.Name, arrayObjectCount, subProperty.Name)] = subProperty.Value;
                //                }
                //            }
                //            arrayObjectCount++;
                //        }
                //    }
                //}
                //else if (property.Value.GetType() == typeof(JObject))
                //{
                //    foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                //    {
                //        if (subProperty.Value.GetType() == typeof(JValue))
                //        {
                //            if (items.Columns.Contains(string.Format("{0}|{1}", property.Name, subProperty.Name)))
                //            {
                //                dataRow[(string.Format("{0}|{1}", property.Name, subProperty.Name, "id"))] = subProperty.Value;
                //            }
                //        }
                //        else if (subProperty.Value.GetType() == typeof(JObject))
                //        {
                //            foreach (JProperty subSubProperty in ((JObject)subProperty.Value).Properties())
                //            {
                //                if (items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, subSubProperty.Name)))
                //                {
                //                    dataRow[(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, subSubProperty.Name))] = subSubProperty.Value;
                //                }
                //            }
                //        }
                //    }
                //}
            }
            items.Rows.Add(dataRow);

        }
        private void GetColumns(DataTable items, JObject jsonObject)
        {
            foreach (JProperty property in jsonObject.Properties())
            {
                if (property.Value.GetType() == typeof(JValue))
                {
                    if (!items.Columns.Contains(property.Name))
                    {
                        items.Columns.Add(property.Name);
                    }
                }
                else if (mainProps.Contains(property.Name) && property.Value.GetType() == typeof(JObject))
                {
                    switch (property.Name)
                    {
                        case "_links":
                            foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                            {
                                if (linkProps.Contains(subProperty.Name) && subProperty.Value.GetType() == typeof(JObject))
                                {
                                    if (!items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "id")))
                                    {
                                        items.Columns.Add(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "id"));
                                    }
                                }
                            }
                            break;
                        case "_embedded":
                            foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                            {
                                if (embeddedProps.Contains(subProperty.Name) && subProperty.Value.GetType() == typeof(JObject))
                                {
                                    if (!items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "email")))
                                    {
                                        items.Columns.Add(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "email"));
                                    }
                                }
                            }
                            break;
                        default:
                            foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                            {
                                if (subProperty.Value.GetType() == typeof(JValue))
                                {
                                    if (!items.Columns.Contains(string.Format("{0}|{1}", property.Name, subProperty.Name)))
                                    {
                                        items.Columns.Add(string.Format("{0}|{1}", property.Name, subProperty.Name));
                                    }
                                }
                            }
                            break;
                    }

                }
                //else if (property.Value.GetType() == typeof(JArray))
                //{
                //    JArray propertyJArray = JArray.Parse(property.Value.ToString());
                //    if (propertyJArray != null && propertyJArray.Count > 0 && propertyJArray[0].GetType() == typeof(JValue))
                //    {
                //        foreach (JValue propertyJValue in propertyJArray)
                //        {
                //            if (!items.Columns.Contains(string.Format("{0}|{1}", property.Name, "0")))
                //            {
                //                items.Columns.Add(string.Format("{0}|{1}", property.Name, "0"));
                //            }
                //        }
                //    }
                //    else if (propertyJArray != null && propertyJArray.Count > 0 && propertyJArray[0].GetType() == typeof(JObject))
                //    {
                //        Int32 arrayObjectCount = 0;
                //        foreach (JObject propertyJValue in propertyJArray)
                //        {
                //            foreach (JProperty subProperty in propertyJValue.Properties())
                //            {
                //                if (!items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, arrayObjectCount, subProperty.Name)))
                //                {
                //                    items.Columns.Add(string.Format("{0}|{1}|{2}", property.Name, arrayObjectCount, subProperty.Name));
                //                }
                //            }
                //            arrayObjectCount++;
                //        }
                //    }
                //}
                //else if (property.Value.GetType() == typeof(JObject))
                //{
                //    foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                //    {
                //        if (subProperty.Value.GetType() == typeof(JValue))
                //        {
                //            if (!items.Columns.Contains(string.Format("{0}|{1}", property.Name, subProperty.Name)))
                //            {
                //                items.Columns.Add(string.Format("{0}|{1}", property.Name, subProperty.Name));
                //            }
                //        }
                //        else if (subProperty.Value.GetType() == typeof(JObject))
                //        {
                //            foreach (JProperty subSubProperty in ((JObject)subProperty.Value).Properties())
                //            {
                //                if (!items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, subSubProperty.Name)))
                //                {
                //                    items.Columns.Add(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, subSubProperty.Name));
                //                }
                //            }
                //        }
                //    }
                //}
            }
            //StringBuilder stringBuilder = new StringBuilder();
            //foreach (DataColumn col in items.Columns)
            //{
            //    stringBuilder.Append(string.Format("{0},", col));
            //}
        }
        private string GetDeskObjectHref(string objName)
        {
            switch (objName)
            {
                case "customer":
                    return "/api/v2/customers";
                case "assigned_user":
                    return "/api/v2/users";
                case "assigned_group":
                    return "/api/v2/groups";
                case "company":
                    return "/api/v2/companies";
                default:
                    return "";
            }
        }
        private string GetDeskObjectClass(string objName)
        {
            switch (objName)
            {
                case "customer":
                    return "customer";
                case "assigned_user":
                    return "user";
                case "assigned_group":
                    return "group";
                case "company":
                    return "company";
                default:
                    return "";
            }
        }
        private double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }
        #endregion

        #region Interface

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
