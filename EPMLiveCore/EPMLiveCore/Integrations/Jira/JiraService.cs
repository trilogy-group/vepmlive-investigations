using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;

namespace EPMLiveCore.Integrations.Jira
{
    public class JiraService : IDisposable
    {
        private RestClient restClient;
        private JsonSerializerSettings jsonSerializerSettings;

        #region Constructor

        public JiraService(string serverUrl, string userName, string password)
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
                restRequest.Resource = GetRestRequestResourceByJiraType(JiraType.Login);
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

        public void InstallWebhook(string objectName, string integrationKey, string apiUrl)
        {
            try
            {
                apiUrl = apiUrl.ToLower().Replace("integration.asmx", "postitemsimple.aspx");

                JiraType jiraType = (JiraType)Enum.Parse(typeof(JiraType), objectName);
                switch (jiraType)
                {
                    case JiraType.Issues:

                        Dictionary<string, object> payLoad = new Dictionary<string, object>();
                        payLoad.Add("name", integrationKey);
                        payLoad.Add("url", string.Format("{0}?integrationkey={1}&id=${2}", apiUrl, integrationKey, "{issue.key}"));
                        payLoad.Add("events", new string[] { "jira:issue_created", "jira:issue_updated", "jira:issue_deleted" });
                        payLoad.Add("jqlFilter", "");
                        payLoad.Add("excludeIssueDetails", false);

                        var request = new RestRequest()
                        {
                            Resource = GetRestRequestResourceByJiraType(JiraType.Webhooks),
                            RequestFormat = DataFormat.Json,
                            JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                            Method = Method.POST
                        };

                        request.AddBody(payLoad);
                        Execute(request);
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
        public void RemoveWebhook(string objectName, string serverUrl, string integrationKey)
        {
            try
            {

                JiraType jiraType = (JiraType)Enum.Parse(typeof(JiraType), objectName);
                switch (jiraType)
                {
                    case JiraType.Issues:
                        Int64 webhookId = 0;

                        var request = new RestRequest();
                        request.Resource = GetRestRequestResourceByJiraType(JiraType.Webhooks);
                        request.Method = Method.GET;

                        var response = restClient.Execute(request);

                        var jsonWebhooks = JValue.Parse(response.Content);

                        foreach (JObject jsonWebhook in jsonWebhooks)
                        {
                            if (Convert.ToString(jsonWebhook["name"]) == integrationKey)
                            {
                                webhookId = Convert.ToInt64(Convert.ToString(jsonWebhook["self"]).Replace(serverUrl, "").Replace(GetRestRequestResourceByJiraType(JiraType.Webhooks), "").Replace("/", ""));
                                request = new RestRequest();
                                request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Webhooks), webhookId);
                                request.Method = Method.DELETE;
                                Execute(request);
                            }
                        }
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
        public void GetObjectItem(string objectName, DataTable items, string itemId, Boolean isOnlyColumns)
        {
            try
            {

                JiraType jiraType = (JiraType)Enum.Parse(typeof(JiraType), objectName);
                switch (jiraType)
                {
                    case JiraType.Projects:
                        GetProject(items, itemId, isOnlyColumns);
                        break;
                    case JiraType.Components:
                        GetComponent(items, itemId, isOnlyColumns);
                        break;
                    case JiraType.Versions:
                        GetVersion(items, itemId, isOnlyColumns);
                        break;
                    case JiraType.Issues:
                        GetIssue(items, itemId, isOnlyColumns);
                        break;
                    case JiraType.Webhooks:
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

                JiraType jiraType = (JiraType)Enum.Parse(typeof(JiraType), objectName);
                switch (jiraType)
                {
                    case JiraType.Projects:
                        GetProjects(items, isOnlyColumns);
                        break;
                    case JiraType.Components:
                        DataTable projectsForComponents = new DataTable();
                        GetProjects(projectsForComponents, false);
                        foreach (DataRow project in projectsForComponents.Rows)
                        {
                            GetProjectComponents(items, Convert.ToInt64(project["id"]), isOnlyColumns);
                        }
                        break;
                    case JiraType.Versions:
                        DataTable projectsForVersions = new DataTable();
                        GetProjects(projectsForVersions, false);
                        foreach (DataRow project in projectsForVersions.Rows)
                        {
                            GetProjectVersions(items, Convert.ToInt64(project["id"]), isOnlyColumns);
                        }
                        break;
                    case JiraType.Issues:
                        GetIssuesByLastSyncDateTime(items, lastSyncDateTime, isOnlyColumns);
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
        public void CreateObjectItem(string objectName, DataRow Item, DataColumnCollection dataColumns)
        {
            try
            {

                JiraType jiraType = (JiraType)Enum.Parse(typeof(JiraType), objectName);
                switch (jiraType)
                {
                    case JiraType.Components:
                        CreateComponent(GetJson(Item, JiraType.Components, dataColumns));
                        break;
                    case JiraType.Versions:
                        CreateVersion(GetJson(Item, JiraType.Versions, dataColumns));
                        break;
                    case JiraType.Issues:
                        CreateIssue(GetJson(Item, JiraType.Issues, dataColumns));
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
        public void UpdateObjectItem(string objectName, DataRow Item, Int64 itemId, DataColumnCollection dataColumns)
        {
            try
            {

                JiraType jiraType = (JiraType)Enum.Parse(typeof(JiraType), objectName);
                switch (jiraType)
                {
                    case JiraType.Components:
                        UpdateComponent(GetJson(Item, JiraType.Components, dataColumns), itemId);
                        break;
                    case JiraType.Versions:
                        UpdateVersion(GetJson(Item, JiraType.Versions, dataColumns), itemId);
                        break;
                    case JiraType.Issues:
                        UpdateIssue(GetJson(Item, JiraType.Issues, dataColumns), itemId);
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

                JiraType jiraType = (JiraType)Enum.Parse(typeof(JiraType), objectName);
                switch (jiraType)
                {
                    case JiraType.Components:
                        DeleteComponent(itemId);
                        break;
                    case JiraType.Versions:
                        DeleteVersion(itemId);
                        break;
                    case JiraType.Issues:
                        DeleteIssue(itemId);
                        break;
                    case JiraType.Webhooks:
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
        #endregion

        #region Private

        private void CreateVersion(JObject payLoad)
        {
            var request = new RestRequest()
            {
                Resource = GetRestRequestResourceByJiraType(JiraType.Versions),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.POST
            };
            request.AddBody(payLoad);
            Execute(request);
        }
        private void CreateComponent(JObject payLoad)
        {
            var request = new RestRequest()
            {
                Resource = GetRestRequestResourceByJiraType(JiraType.Components),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.POST
            };
            request.AddBody(payLoad);
            Execute(request);
        }
        private void CreateIssue(JObject payLoad)
        {
            var request = new RestRequest()
            {
                Resource = GetRestRequestResourceByJiraType(JiraType.Issues),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.POST
            };
            request.AddBody(payLoad);
            Execute(request);
        }

        private void UpdateVersion(JObject payLoad, Int64 itemId)
        {
            var request = new RestRequest()
            {
                Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Versions), itemId),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.PUT
            };
            request.AddBody(payLoad);
            Execute(request);
        }
        private void UpdateComponent(JObject payLoad, Int64 itemId)
        {
            var request = new RestRequest()
            {
                Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Components), itemId),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.PUT
            };
            request.AddBody(payLoad);
            Execute(request);
        }
        private void UpdateIssue(JObject payLoad, Int64 itemId)
        {
            var request = new RestRequest()
            {
                Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Issues), itemId),
                RequestFormat = DataFormat.Json,
                JsonSerializer = new CustomJsonConverter { ContentType = "application/json" },
                Method = Method.PUT
            };
            request.AddBody(payLoad);
            Execute(request);
        }

        private void GetProjects(DataTable items, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = GetRestRequestResourceByJiraType(JiraType.Projects);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            var jsonProjects = JValue.Parse(response.Content);

            foreach (var jsonProject in jsonProjects)
            {
                FillDataTableFromJson(items, (JObject)jsonProject, isOnlyColumns);
            }

        }
        private void GetProject(DataTable items, string projectId, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Projects), projectId);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            var jsonProject = JValue.Parse(response.Content);

            FillDataTableFromJson(items, (JObject)jsonProject, isOnlyColumns);
        }
        private void GetVersion(DataTable items, string versionId, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Versions), versionId);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            var jsonVersion = JValue.Parse(response.Content);

            FillDataTableFromJson(items, (JObject)jsonVersion, isOnlyColumns);
        }
        private void GetProjectVersions(DataTable items, Int64 projectId, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}/versions", GetRestRequestResourceByJiraType(JiraType.Projects), projectId);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            var jsonVersions = JValue.Parse(response.Content);

            foreach (var jsonVersion in jsonVersions)
            {
                FillDataTableFromJson(items, (JObject)jsonVersion, isOnlyColumns);
            }
        }
        private void GetComponent(DataTable items, string componentId, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Components), componentId);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            var jsonComponent = JValue.Parse(response.Content);

            FillDataTableFromJson(items, (JObject)jsonComponent, isOnlyColumns);
        }
        private void GetProjectComponents(DataTable items, Int64 projectId, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}/components", GetRestRequestResourceByJiraType(JiraType.Projects), projectId);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            var jsonComponents = JValue.Parse(response.Content);

            foreach (var jsonComponent in jsonComponents)
            {
                FillDataTableFromJson(items, (JObject)jsonComponent, isOnlyColumns);
            }
        }
        private void GetIssue(DataTable items, string issueId, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Issues), issueId);
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            var jsonIssue = JObject.Parse(response.Content);
            FillDataTableFromJson(items, (JObject)jsonIssue, isOnlyColumns);

        }
        private void GetIssuesByLastSyncDateTime(DataTable items, DateTime lastSyncDateTime, Boolean isOnlyColumns)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}?jql=updateddate >= \"{1}\"", GetRestRequestResourceByJiraType(JiraType.Search), lastSyncDateTime.ToString("yyyy/MM/dd HH:mm"));
            request.Method = Method.GET;

            var response = restClient.Execute(request);

            var jsonIssues = JObject.Parse(response.Content)["issues"];

            foreach (var jsonIssue in jsonIssues)
            {
                FillDataTableFromJson(items, (JObject)jsonIssue, isOnlyColumns);
            }
        }


        private void DeleteVersion(Int64 versionId)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Versions), versionId);
            request.Method = Method.DELETE;
            Execute(request);
        }
        private void DeleteComponent(Int64 componentId)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Components), componentId);
            request.Method = Method.DELETE;
            Execute(request);
        }
        private void DeleteIssue(Int64 issueId)
        {
            var request = new RestRequest();
            request.Resource = string.Format("{0}/{1}", GetRestRequestResourceByJiraType(JiraType.Issues), issueId);
            request.Method = Method.DELETE;
            Execute(request);
        }

        private void Execute(RestRequest request)
        {
            var response = restClient.Execute(request);

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

        }
        private string GetRestRequestResourceByJiraType(JiraType jiraType)
        {
            switch (jiraType)
            {
                case JiraType.Login:
                    return "/rest/auth/1/session";
                case JiraType.Users:
                    return "";
                case JiraType.Projects:
                    return "/rest/api/2/project";
                case JiraType.Components:
                    return "/rest/api/2/component";
                case JiraType.Versions:
                    return "/rest/api/2/version";
                case JiraType.Issues:
                    return "rest/api/2/issue";
                case JiraType.Search:
                    return "rest/api/2/search";
                case JiraType.Webhooks:
                    return "/rest/webhooks/1.0/webhook";
                default:
                    return "";
            }
        }
        private JObject GetJson(DataRow dataRow, JiraType jiraType, DataColumnCollection dataColumns)
        {
            JsonSerializer json = new JsonSerializer();
            StringWriter sw = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(sw);

            switch (jiraType)
            {
                case JiraType.Components:
                case JiraType.Versions:
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
                    break;
                case JiraType.Issues:
                    writer.WriteStartObject();

                    var dataColumnsList = (from dc in dataColumns.Cast<DataColumn>()
                                           select dc).OrderBy(c => c.ColumnName);

                    Boolean subColumnStart = false;

                    foreach (DataColumn column in dataColumnsList)
                    {
                        if (column.ColumnName.Equals("SPID"))
                            continue;

                        if (dataRow[column] != null && !string.IsNullOrEmpty(Convert.ToString(dataRow[column])))
                        {
                            if (column.ColumnName.Contains("|"))
                            {
                                string[] subColumnsArray = column.ColumnName.Split('|');

                                if (!subColumnStart)
                                {
                                    writer.WritePropertyName(subColumnsArray[0]);
                                    writer.WriteStartObject();
                                    subColumnStart = true;
                                }
                                if (subColumnsArray.Count() == 3)
                                {
                                    writer.WritePropertyName(subColumnsArray[1]);
                                    writer.WriteStartObject();
                                    writer.WritePropertyName(subColumnsArray[2]);
                                    json.Serialize(writer, dataRow[column]);
                                    writer.WriteEndObject();
                                }
                                else
                                {
                                    writer.WritePropertyName(subColumnsArray[1]);
                                    json.Serialize(writer, dataRow[column]);
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
                    break;
                default:
                    break;
            }
            return JObject.Parse(sw.ToString());
        }
        private void FillDataTableFromJson(DataTable items, JObject jsonObject, Boolean isOnlyColumns)
        {
            if (jsonObject.GetValue("errorMessages") != null) { return; }

            GetColumns(items, jsonObject);

            if (isOnlyColumns) { return; }

            DataRow dataRow = items.NewRow();
            foreach (JProperty property in jsonObject.Properties())
            {
                if (property.Value.GetType() == typeof(JObject))
                {
                    foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                    {
                        if (subProperty.Value.GetType() == typeof(JObject))
                        {
                            foreach (JProperty idProperty in ((JObject)subProperty.Value).Properties())
                            {
                                if (idProperty.Name.Equals("id"))
                                {
                                    if (items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "id")))
                                    {
                                        dataRow[(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "id"))] = idProperty.Value;
                                    }
                                }
                            }
                        }
                        else if (subProperty.Value.GetType() == typeof(JValue))
                        {
                            if (items.Columns.Contains(string.Format("{0}|{1}", property.Name, subProperty.Name)))
                            {
                                dataRow[string.Format("{0}|{1}", property.Name, subProperty.Name)] = subProperty.Value;
                            }
                        }
                    }
                }
                else
                {
                    if (property.Value.GetType() == typeof(JValue))
                    {
                        if (items.Columns.Contains(property.Name))
                        {
                            dataRow[property.Name] = property.Value;
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
                if (property.Value.GetType() == typeof(JObject))
                {
                    foreach (JProperty subProperty in ((JObject)property.Value).Properties())
                    {
                        if (subProperty.Value.GetType() == typeof(JObject))
                        {
                            foreach (JProperty idProperty in ((JObject)subProperty.Value).Properties())
                            {
                                if (idProperty.Name.Equals("id"))
                                {
                                    if (!items.Columns.Contains(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "id")))
                                    {
                                        items.Columns.Add(string.Format("{0}|{1}|{2}", property.Name, subProperty.Name, "id"));
                                    }
                                }
                            }
                        }
                        else if (subProperty.Value.GetType() == typeof(JValue))
                        {
                            if (!items.Columns.Contains(string.Format("{0}|{1}", property.Name, subProperty.Name)))
                            {
                                items.Columns.Add(string.Format("{0}|{1}", property.Name, subProperty.Name));
                            }
                        }
                    }
                }
                else
                {
                    if (property.Value.GetType() == typeof(JValue))
                    {
                        if (!items.Columns.Contains(property.Name))
                        {
                            items.Columns.Add(property.Name);
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
