using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal class PersonalizationManager
    {
        #region Fields (1) 

        private readonly SPWeb _spWeb;

        #endregion Fields 

        #region Enums (1) 

        private enum Errors
        {
            GetPersonalization = 5030,
            SetPersonalization = 5040,
            InvalidId = 5050,
            InvalidSiteId,
            InvalidWebId,
            InvalidListId,
            InvalidItemId,
            InvalidFK,
            KeyRequired,
            RequestXmlRequired,
            ValueElementRequired
        }

        #endregion Enums 

        #region Constructors (1) 

        public PersonalizationManager(SPWeb spWeb)
        {
            _spWeb = spWeb;
        }

        #endregion Constructors 

        #region Methods (5) 

        // Public Methods (2) 

        public string GetPersonalization(string data)
        {
            try
            {
                var resultXml = new XElement("Personalizations");

                var parameters = new Dictionary<string, object>();
                GetParameters(data, parameters, false);

                BuildResponse(GetPersonalization(parameters), resultXml);

                return resultXml.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.GetPersonalization, e.Message);
            }
        }

        public string SetPersonalization(string data)
        {
            try
            {
                var resultXml = new XElement("Personalizations");

                var parameters = new Dictionary<string, object>();
                GetParameters(data, parameters, true);
                bool DaysAgoEnabled;
                int DaysAgo;
                bool DaysAfterEnabled;
                int DaysAfter;
                string query;

                var dictionary = parameters.Where(p => !p.Key.Equals("@Value")).ToDictionary(p => p.Key, p => p.Value);
                DataTable dataTable = GetPersonalization(dictionary);

                if (dataTable.Rows.Count > 0)
                {
                    object value = parameters["@Value"];

                    parameters.Clear();
                    parameters.Add("@Id", dataTable.Rows[0]["Id"]);
                    parameters.Add("@Value", value);

                    query = @"UPDATE dbo.PERSONALIZATIONS SET Value = @Value WHERE Id = @Id";
                }
                else
                {
                    parameters.Add("@UserId", _spWeb.CurrentUser.ID.ToString(CultureInfo.InvariantCulture));

                    query = string.Format(@"INSERT INTO dbo.PERSONALIZATIONS ({0}) VALUES ({1})",
                                          string.Join(",",
                                                      parameters.Select(
                                                          p => string.Format("[{0}]", p.Key.Replace("@", string.Empty)))
                                                                .ToArray()), string.Join(",", parameters.Keys.ToArray()));
                }

                var queryExecutor = new QueryExecutor(_spWeb);
                queryExecutor.ExecuteEpmLiveNonQuery(query, parameters);

                if (parameters["@Value"] != null)
                {
                    string[] paramArray = parameters["@Value"].ToString().Split('|');
                    DaysAgoEnabled = Convert.ToBoolean(paramArray[0]);
                    DaysAgo = Convert.ToInt32(paramArray[1]);
                    DaysAfterEnabled = Convert.ToBoolean(paramArray[2]);
                    DaysAfter = Convert.ToInt32(paramArray[3]);

                    var from = new DateTime(1900, 1, 1, 0, 0, 0);
                    var to = new DateTime(9998, 12, 31, 23, 59, 59);
                    DateTime today = DateTime.Now.Date;

                    if (DaysAgoEnabled)
                    {
                        from = today.AddDays(-DaysAgo);
                    }

                    if (DaysAfterEnabled)
                    {
                        to = today.AddDays(DaysAfter).AddHours(23).AddMinutes(59).AddSeconds(59);
                    }

                    resultXml.Add(new XAttribute("FromDate", from.ToString("yyyy-MM-dd HH:mm:ss")));
                    resultXml.Add(new XAttribute("ToDate", to.ToString("yyyy-MM-dd HH:mm:ss")));
                }

                return resultXml.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException((int) Errors.SetPersonalization, e.Message);
            }
        }

        // Private Methods (3) 

        private static void BuildResponse(DataTable dataTable, XElement resultXml)
        {
            if (dataTable == null) return;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var personalizationElement = new XElement("Personalization");

                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    string columnName = dataColumn.ColumnName;
                    string value = (dataRow[dataColumn] ?? string.Empty).ToString();

                    if (columnName.Equals("Value"))
                    {
                        personalizationElement.Add(new XCData(value));
                    }
                    else
                    {
                        personalizationElement.Add(new XAttribute(columnName, value));
                    }
                }

                resultXml.Add(personalizationElement);
            }
        }

        private static void GetParameters(string data, IDictionary<string, object> parameters, bool includeValue)
        {
            if (includeValue)
            {
                if (string.IsNullOrEmpty(data))
                {
                    throw new APIException((int) Errors.RequestXmlRequired, "No request XML found.");
                }

                XDocument requextXml = XDocument.Parse(data);

                if (requextXml.Root != null)
                {
                    XElement valueElement = requextXml.Root.Element("Value");
                    if (valueElement == null)
                    {
                        throw new APIException((int) Errors.ValueElementRequired, "Cannot find the Value element.");
                    }

                    parameters.Add("@Value", valueElement.Value);
                }
            }

            if (string.IsNullOrEmpty(data)) return;

            XDocument requestXml = XDocument.Parse(data);

            if (requestXml.Root == null) return;

            XAttribute keyAttribute = requestXml.Root.Attribute("Key");
            if (keyAttribute == null)
            {
                throw new APIException((int) Errors.KeyRequired, "Cannot find the Key for the personalization.");
            }

            parameters.Add("@Key", keyAttribute.Value);

            XElement filtersElement = requestXml.Root.Element("Filters");
            if (filtersElement == null) return;

            foreach (XElement filter in filtersElement.Elements("Filter"))
            {
                string value = filter.Value;
                if (string.IsNullOrEmpty(value)) continue;

                XAttribute filterKeyAttribute = filter.Attribute("Key");
                if (filterKeyAttribute == null) continue;

                string key = filterKeyAttribute.Value.ToLower();
                if (parameters.ContainsKey(key)) continue;

                object val = null;

                switch (key)
                {
                    case "id":
                        key = "@Id";
                        try
                        {
                            val = new Guid(value);
                        }
                        catch
                        {
                            throw new APIException((int) Errors.InvalidId,
                                                   value + " is not a properly formatted Id.");
                        }
                        break;
                    case "siteid":
                        key = "@SiteId";
                        try
                        {
                            val = new Guid(value);
                        }
                        catch
                        {
                            throw new APIException((int) Errors.InvalidSiteId,
                                                   value + " is not a properly formatted Site Id.");
                        }
                        break;
                    case "webid":
                        key = "@WebId";
                        try
                        {
                            val = new Guid(value);
                        }
                        catch
                        {
                            throw new APIException((int) Errors.InvalidWebId,
                                                   value + " is not a properly formatted Web Id.");
                        }
                        break;
                    case "listid":
                        key = "@ListId";
                        try
                        {
                            val = new Guid(value);
                        }
                        catch
                        {
                            throw new APIException((int) Errors.InvalidListId,
                                                   value + " is not a properly formatted List Id.");
                        }
                        break;
                    case "itemid":
                        key = "@ItemId";
                        try
                        {
                            val = int.Parse(value);
                        }
                        catch
                        {
                            throw new APIException((int) Errors.InvalidItemId,
                                                   value + " is not a properly formatted Item Id.");
                        }
                        break;
                    case "fk":
                        key = "@FK";
                        try
                        {
                            val = new Guid(value);
                        }
                        catch
                        {
                            throw new APIException((int) Errors.InvalidFK,
                                                   value + " is not a properly formatted FK.");
                        }
                        break;
                }

                if (val != null && !parameters.ContainsKey(key))
                {
                    parameters.Add(key, val);
                }
            }
        }

        private DataTable GetPersonalization(Dictionary<string, object> parameters)
        {
            string query;

            if (parameters.Any())
            {
                const string sql = @"SELECT * FROM dbo.PERSONALIZATIONS WHERE [UserId] = @UserId AND ({0})";
                query = string.Format(sql,
                                      string.Join(" AND ",
                                                  parameters.Select(pair => pair.Key)
                                                            .Select(
                                                                k =>
                                                                string.Format(@"[{0}] = {1}",
                                                                              k.Replace("@", string.Empty), k))
                                                            .ToArray()));
            }
            else
            {
                query = @"SELECT * FROM dbo.PERSONALIZATIONS WHERE [UserId] = @UserId";
            }

            parameters.Add("@UserId", _spWeb.CurrentUser.ID.ToString(CultureInfo.InvariantCulture));

            return new QueryExecutor(_spWeb).ExecuteEpmLiveQuery(query, parameters);
        }

        #endregion Methods 
    }
}