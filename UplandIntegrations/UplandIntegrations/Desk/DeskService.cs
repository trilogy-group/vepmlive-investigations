using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using UplandIntegrations.Jira;

namespace UplandIntegrations.Desk
{
    public class DeskService : IDisposable
    {
        private RestClient restClient;
        private JsonSerializerSettings jsonSerializerSettings;

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

                Dictionary<string, object> payLoad = new Dictionary<string, object>();
                payLoad.Add("name", integrationKey);
                payLoad.Add("description", string.Format("integration url for {0}", objectName.ToLower()));
                payLoad.Add("enabled", true);
                payLoad.Add("markup", string.Format("{0}?integrationkey={1}&id={{{2}.id}}", apiUrl, integrationKey, objectName.ToLower()));

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
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string CreateObjectItem(string objectName, DataRow Item, DataColumnCollection dataColumns)
        {
            try
            {
                string objectId = null;
                //var request = new RestRequest()
                //{
                //    Resource = string.Format("{0}&sysparm_action=insert", GetRestRequestResourceByDeskType(objectName)),
                //    RequestFormat = DataFormat.Json,
                //    JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                //    Method = Method.POST
                //};
                //request.AddBody(GetJson(Item, objectName, dataColumns));
                //RestResponse response = Execute(request);
                //if (response != null && !string.IsNullOrEmpty(response.Content))
                //{
                //    var jsonObjectData = JValue.Parse(response.Content)["records"];
                //    objectId = Convert.ToString(((JObject)jsonObjectData[0]).GetValue("sys_id"));
                //}
                return objectId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateObjectItem(string objectName, DataRow Item, string itemId, DataColumnCollection dataColumns)
        {
            try
            {
                //var request = new RestRequest()
                //{
                //    Resource = string.Format("{0}&sysparm_action=update&sysparm_sys_id={1}", GetRestRequestResourceByDeskType(objectName), itemId),
                //    RequestFormat = DataFormat.Json,
                //    JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                //    Method = Method.POST
                //};
                //request.AddBody(GetJson(Item, objectName, dataColumns));
                //Execute(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteObjectItem(string objectName, string itemId)
        {
            try
            {
                //var request = new RestRequest();
                //request.Resource = string.Format("{0}&sysparm_action=deleteRecord&sysparm_sys_id={1}", GetRestRequestResourceByDeskType(objectName), itemId);
                //request.Method = Method.POST;
                //Execute(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetViewUrlResourceByDeskType(string objectName)
        {
            return string.Format("nav_to.do?uri={0}.do?", objectName.Replace(" ", "_").ToLower());
        }

        #endregion

        #region Private

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
            var request = new RestRequest();
            request.Resource = string.Format("{0}/search?q=updated_at>={1}", GetRestRequestResourceByDeskType(DeskType.Companies), lastSyncDateTime.ToString("yyyy-M-dd"));
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }

            var jsonData = JValue.Parse(response.Content);

            var jsonObjects = jsonData["_embedded"]["entries"];
            foreach (var jsonObject in jsonObjects)
            {
                FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
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
            var request = new RestRequest();
            request.Resource = string.Format("{0}/search?q=updated_at>={1}", GetRestRequestResourceByDeskType(DeskType.Customers), lastSyncDateTime.ToString("yyyy-M-dd"));
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("message") != null)
            {
                throw new Exception(jsonResponseData.GetValue("message").ToString());
            }

            var jsonData = JValue.Parse(response.Content);

            var jsonObjects = jsonData["_embedded"]["entries"];
            foreach (var jsonObject in jsonObjects)
            {
                FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
            }
        }

        private void GetCase(DataTable items, string id, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByDeskType(DeskType.Cases), id);
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
            Int32 pageSize = 100;
            Double totalRecords = 0;
            Double noOfPages = 0;

            var request = new RestRequest();
            request.Resource = string.Format("{0}/search?page=1&per_page={1}&q=updated_at>={2}", GetRestRequestResourceByDeskType(DeskType.Cases), pageSize, lastSyncDateTime.ToString("yyyy-M-dd"));
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

            //for (int pageCount = 2; pageCount <= noOfPages; pageCount++)
            //{
            //    var requestSub = new RestRequest();
            //    requestSub.Resource = string.Format("{0}/search?page={1}&per_page={2}&q=updated_at>={3}", GetRestRequestResourceByDeskType(DeskType.Cases), pageCount, pageSize, lastSyncDateTime.ToString("yyyy-M-dd"));
            //    requestSub.Method = Method.GET;

            //    var responseSub = restClient.Execute(requestSub);

            //    JObject jsonResponseDataSub = (JObject)JValue.Parse(responseSub.Content);
            //    if (jsonResponseDataSub.GetValue("message") != null)
            //    {
            //        throw new Exception(jsonResponseDataSub.GetValue("message").ToString());
            //    }

            //    var jsonDataSub = JValue.Parse(responseSub.Content);

            //    var jsonObjectsSub = jsonDataSub["_embedded"]["entries"];
            //    foreach (var jsonObject in jsonObjectsSub)
            //    {
            //        FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
            //    }

            //}

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
                case DeskType.Integration_URLs:
                    return "api/v2/integration_urls";
                default:
                    return "";
            }
        }
        private JObject GetJson(DataRow dataRow, string objectName, DataColumnCollection dataColumns)
        {
            JsonSerializer json = new JsonSerializer();
            StringWriter sw = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(sw);

            writer.WriteStartObject();
            foreach (DataColumn column in dataColumns)
            {
                if (column.ColumnName.Equals("SPID"))
                    continue;

                if (dataRow[column] != null && !string.IsNullOrEmpty(Convert.ToString(dataRow[column])))
                {
                    writer.WritePropertyName(column.ColumnName);
                    json.Serialize(writer, dataRow[column]);
                }
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
                else if (property.Value.GetType() == typeof(JArray))
                {
                    JArray propertyJArray = JArray.Parse(property.Value.ToString());
                    if (propertyJArray != null && propertyJArray.Count > 0 && propertyJArray[0].GetType() == typeof(JValue))
                    {
                        foreach (JValue propertyJValue in propertyJArray)
                        {
                            if (items.Columns.Contains(string.Format("{0}|{1}", property.Name, "0")))
                            {
                                string dataRowPreviousValue = Convert.ToString(dataRow[string.Format("{0}|{1}", property.Name, "0")]);
                                if (string.IsNullOrEmpty(dataRowPreviousValue))
                                {
                                    dataRow[string.Format("{0}|{1}", property.Name, "0")] = propertyJValue.Value;
                                }
                                else
                                {
                                    dataRow[string.Format("{0}|{1}", property.Name, "0")] = string.Format("{0},{1}", dataRowPreviousValue, propertyJValue.Value);
                                }
                            }
                        }
                    }
                    else if (propertyJArray != null && propertyJArray.Count > 0 && propertyJArray[0].GetType() == typeof(JObject))
                    {
                        Int32 arrayObjectCount = 0;
                        foreach (JObject propertyJValue in propertyJArray)
                        {
                            foreach (JProperty subProperty in propertyJValue.Properties())
                            {
                                if (items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, arrayObjectCount, subProperty.Name)))
                                {
                                    dataRow[string.Format("{0}|{1}|{2}", property.Name, arrayObjectCount, subProperty.Name)] = subProperty.Value;
                                }
                            }
                            arrayObjectCount++;
                        }
                    }
                }
                else if (property.Value.GetType() == typeof(JObject))
                {
                    foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                    {
                        if (subProperty.Value.GetType() == typeof(JValue))
                        {
                            if (items.Columns.Contains(string.Format("{0}|{1}", property.Name, subProperty.Name)))
                            {
                                dataRow[(string.Format("{0}|{1}", property.Name, subProperty.Name, "id"))] = subProperty.Value;
                            }
                        }
                        else if (subProperty.Value.GetType() == typeof(JObject))
                        {
                            foreach (JProperty subSubProperty in ((JObject)subProperty.Value).Properties())
                            {
                                if (items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, subSubProperty.Name)))
                                {
                                    dataRow[(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, subSubProperty.Name))] = subSubProperty.Value;
                                }
                            }
                        }
                    }
                }
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
                else if (property.Value.GetType() == typeof(JArray))
                {
                    JArray propertyJArray = JArray.Parse(property.Value.ToString());
                    if (propertyJArray != null && propertyJArray.Count > 0 && propertyJArray[0].GetType() == typeof(JValue))
                    {
                        foreach (JValue propertyJValue in propertyJArray)
                        {
                            if (!items.Columns.Contains(string.Format("{0}|{1}", property.Name, "0")))
                            {
                                items.Columns.Add(string.Format("{0}|{1}", property.Name, "0"));
                            }
                        }
                    }
                    else if (propertyJArray != null && propertyJArray.Count > 0 && propertyJArray[0].GetType() == typeof(JObject))
                    {
                        Int32 arrayObjectCount = 0;
                        foreach (JObject propertyJValue in propertyJArray)
                        {
                            foreach (JProperty subProperty in propertyJValue.Properties())
                            {
                                if (!items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, arrayObjectCount, subProperty.Name)))
                                {
                                    items.Columns.Add(string.Format("{0}|{1}|{2}", property.Name, arrayObjectCount, subProperty.Name));
                                }
                            }
                            arrayObjectCount++;
                        }
                    }
                }
                else if (property.Value.GetType() == typeof(JObject))
                {
                    foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                    {
                        if (subProperty.Value.GetType() == typeof(JValue))
                        {
                            if (!items.Columns.Contains(string.Format("{0}|{1}", property.Name, subProperty.Name)))
                            {
                                items.Columns.Add(string.Format("{0}|{1}", property.Name, subProperty.Name));
                            }
                        }
                        else if (subProperty.Value.GetType() == typeof(JObject))
                        {
                            foreach (JProperty subSubProperty in ((JObject)subProperty.Value).Properties())
                            {
                                if (!items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, subSubProperty.Name)))
                                {
                                    items.Columns.Add(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, subSubProperty.Name));
                                }
                            }
                        }
                    }
                }
            }
            //StringBuilder stringBuilder = new StringBuilder();
            //foreach (DataColumn col in items.Columns)
            //{
            //    stringBuilder.Append(string.Format("{0},", col));
            //}
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
