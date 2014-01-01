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
using UplandIntegrations.Utils;

namespace UplandIntegrations.ServiceNow
{
    public class ServiceNowService : IDisposable
    {
        private RestClient restClient;
        private JsonSerializerSettings jsonSerializerSettings;

        #region Constructor

        public ServiceNowService(string serverUrl, string userName, string password)
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
                string objectId = null;

                apiUrl = apiUrl.ToLower().Replace("integration.asmx", "postitemsimple.aspx");

                var request = new RestRequest()
                {
                    Resource = string.Format("sys_soap_message.do?JSONv2&sysparm_action=insert"),
                    RequestFormat = DataFormat.Json,
                    JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                    Method = Method.POST
                };

                Dictionary<string, object> payLoad = new Dictionary<string, object>();
                payLoad.Add("wsdl", string.Format("{0}?integrationkey={1}", apiUrl, integrationKey));
                payLoad.Add("download_wsdl", "false");
                payLoad.Add("description", string.Format("{0}-{1}", objectName.Replace(" ", "_").ToLower(), integrationKey));
                payLoad.Add("name", string.Format("{0}-{1}", objectName.Replace(" ", "_").ToLower(), integrationKey));
                payLoad.Add("use_basic_auth", "true");
                payLoad.Add("basic_auth_user", userName);
                payLoad.Add("basic_auth_password", password);
                payLoad.Add("envelope", "");

                request.AddBody(payLoad);
                RestResponse response = Execute(request);
                if (response != null && !string.IsNullOrEmpty(response.Content))
                {
                    var jsonObjectData = JValue.Parse(response.Content)["records"];
                    objectId = Convert.ToString(((JObject)jsonObjectData[0]).GetValue("sys_id"));
                    if (!string.IsNullOrEmpty(objectId))
                    {
                        request = new RestRequest()
                        {
                            Resource = string.Format("sys_soap_message_function.do?JSONv2&sysparm_action=insert"),
                            RequestFormat = DataFormat.Json,
                            JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                            Method = Method.POST
                        };

                        payLoad = new Dictionary<string, object>();
                        payLoad.Add("soap_message", objectId);
                        payLoad.Add("basic_auth_user", userName);
                        payLoad.Add("use_basic_auth", "true");
                        payLoad.Add("basic_auth_password", password);
                        payLoad.Add("function_name", "insert");
                        payLoad.Add("soap_action", string.Format("{0}/u_{1}/insert", restClient.BaseUrl, objectName.Replace(" ", "_").ToLower()));
                        payLoad.Add("soap_endpoint", string.Format("{0}?integrationkey={1}", apiUrl, integrationKey));
                        payLoad.Add("envelope", "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:u='" + string.Format("{0}?integrationkey={1}", apiUrl, integrationKey) + "'><soapenv:Header/><soapenv:Body><u:deleteRecord><sys_id>${sys_id}</sys_id></u:deleteRecord></soapenv:Body></soapenv:Envelope>");


                        request.AddBody(payLoad);
                        response = Execute(request);

                        request = new RestRequest()
                        {
                            Resource = string.Format("sys_soap_message_function.do?JSONv2&sysparm_action=insert"),
                            RequestFormat = DataFormat.Json,
                            JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                            Method = Method.POST
                        };

                        payLoad = new Dictionary<string, object>();
                        payLoad.Add("soap_message", objectId);
                        payLoad.Add("basic_auth_user", userName);
                        payLoad.Add("use_basic_auth", "true");
                        payLoad.Add("basic_auth_password", password);
                        payLoad.Add("function_name", "update");
                        payLoad.Add("soap_action", string.Format("{0}/u_{1}/update", restClient.BaseUrl, objectName.Replace(" ", "_").ToLower()));
                        payLoad.Add("soap_endpoint", string.Format("{0}?integrationkey={1}", apiUrl, integrationKey));
                        payLoad.Add("envelope", "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:u='" + string.Format("{0}?integrationkey={1}", apiUrl, integrationKey) + "'><soapenv:Header/><soapenv:Body><u:deleteRecord><sys_id>${sys_id}</sys_id></u:deleteRecord></soapenv:Body></soapenv:Envelope>");

                        request.AddBody(payLoad);
                        response = Execute(request);

                        request = new RestRequest()
                        {
                            Resource = string.Format("sys_soap_message_function.do?JSONv2&sysparm_action=insert"),
                            RequestFormat = DataFormat.Json,
                            JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                            Method = Method.POST
                        };

                        payLoad = new Dictionary<string, object>();
                        payLoad.Add("soap_message", objectId);
                        payLoad.Add("basic_auth_user", userName);
                        payLoad.Add("use_basic_auth", "true");
                        payLoad.Add("basic_auth_password", password);
                        payLoad.Add("function_name", "deleteRecord");
                        payLoad.Add("soap_action", string.Format("{0}/u_{1}/deleteRecord", restClient.BaseUrl, objectName.Replace(" ", "_").ToLower()));
                        payLoad.Add("soap_endpoint", string.Format("{0}?integrationkey={1}", apiUrl, integrationKey));
                        payLoad.Add("envelope", "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:u='" + string.Format("{0}?integrationkey={1}", apiUrl, integrationKey) + "'><soapenv:Header/><soapenv:Body><u:deleteRecord><sys_id>${sys_id}</sys_id></u:deleteRecord></soapenv:Body></soapenv:Envelope>");

                        request.AddBody(payLoad);
                        response = Execute(request);




                    }
                    else
                    {
                        throw new Exception("Problem in creating integration with servicenow. Please contact administrator.");
                    }


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
                var request = new RestRequest();
                request.Resource = string.Format("sys_soap_message.do?JSONv2&sysparm_action=deleteMultiple&&sysparm_query=name={0}", string.Format("{0}-{1}", objectName.Replace(" ", "_").ToLower(), integrationKey));
                request.Method = Method.POST;
                Execute(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetSystemTables(DataTable items, Boolean isOnlyColumns)
        {
            try
            {
                var request = new RestRequest();
                request.Resource = "sys_db_object_list.do?JSONv2&sysparm_action=getRecords&sysparm_query=GOTOsuper_class.label=Task";
                request.Method = Method.GET;

                var response = restClient.Execute(request);

                JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
                if (jsonResponseData.GetValue("error") != null)
                {
                    throw new Exception(jsonResponseData.GetValue("error").ToString());
                }

                var jsonObjects = JValue.Parse(response.Content)["records"];

                foreach (var jsonObject in jsonObjects)
                {
                    FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
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
                var request = new RestRequest();
                request.Resource = string.Format("{0}&sysparm_action=get&sysparm_sys_id={1}", GetRestRequestResourceByServiceNowType(objectName), itemId);
                request.Method = Method.GET;

                var response = restClient.Execute(request);

                JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
                if (jsonResponseData.GetValue("error") != null)
                {
                    throw new Exception(jsonResponseData.GetValue("error").ToString());
                }

                var jsonObjects = JValue.Parse(response.Content)["records"];

                FillDataTableFromJson(items, (JObject)jsonObjects[0], isOnlyColumns);

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
                var request = new RestRequest();
                request.Resource = string.Format("{0}&sysparm_action=getRecords&sysparm_query=sys_updated_on>={1}", GetRestRequestResourceByServiceNowType(objectName), lastSyncDateTime.ToString("yyyy-MM-dd"));
                request.Method = Method.GET;

                var response = restClient.Execute(request);

                JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
                if (jsonResponseData.GetValue("error") != null)
                {
                    throw new Exception(jsonResponseData.GetValue("error").ToString());
                }

                var jsonObjects = JValue.Parse(response.Content)["records"];

                foreach (var jsonObject in jsonObjects)
                {
                    FillDataTableFromJson(items, (JObject)jsonObject, isOnlyColumns);
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
                var request = new RestRequest()
                {
                    Resource = string.Format("{0}&sysparm_action=insert", GetRestRequestResourceByServiceNowType(objectName)),
                    RequestFormat = DataFormat.Json,
                    JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                    Method = Method.POST
                };
                request.AddBody(GetJson(Item, objectName, dataColumns));
                RestResponse response = Execute(request);
                if (response != null && !string.IsNullOrEmpty(response.Content))
                {
                    var jsonObjectData = JValue.Parse(response.Content)["records"];
                    objectId = Convert.ToString(((JObject)jsonObjectData[0]).GetValue("sys_id"));
                }
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

                var request = new RestRequest()
                {
                    Resource = string.Format("{0}&sysparm_action=update&sysparm_sys_id={1}", GetRestRequestResourceByServiceNowType(objectName), itemId),
                    RequestFormat = DataFormat.Json,
                    JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                    Method = Method.POST
                };
                request.AddBody(GetJson(Item, objectName, dataColumns));
                Execute(request);
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
                var request = new RestRequest();
                request.Resource = string.Format("{0}&sysparm_action=deleteRecord&sysparm_sys_id={1}", GetRestRequestResourceByServiceNowType(objectName), itemId);
                request.Method = Method.POST;
                Execute(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetViewUrlResourceByServiceNowType(string objectName)
        {
            return string.Format("nav_to.do?uri={0}.do?", objectName.Replace(" ", "_").ToLower());
        }

        #endregion

        #region Private

        private RestResponse Execute(RestRequest request)
        {
            var response = restClient.Execute(request);

            JObject jsonResponseData = (JObject)JValue.Parse(response.Content);
            if (jsonResponseData.GetValue("error") != null)
            {
                throw new Exception(jsonResponseData.GetValue("error").ToString());
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
                    if (response.StatusCode != HttpStatusCode.OK)
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
        private string GetRestRequestResourceByServiceNowType(string objectName)
        {
            return string.Format("{0}.do?JSONv2", objectName.Replace(" ", "_").ToLower());
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
            if (jsonObject.GetValue("error") != null) { return; }

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
