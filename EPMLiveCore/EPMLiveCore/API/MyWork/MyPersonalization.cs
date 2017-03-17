using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public class MyPersonalization
    {
        #region Methods (6) 

        // Private Methods (4) 

        /// <summary>
        /// Gets the personalizations.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <param name="username">The username.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="siteId">The site id.</param>
        /// <param name="siteUrl">The site URL.</param>
        /// <returns></returns>
        private static Dictionary<string, string[]> GetPersonalizations(string[] keys, string username, int itemId,
                                                                        Guid listId, Guid webId, Guid siteId,
                                                                        string siteUrl)
        {
            try
            {
                var personalizations = new Dictionary<string, string[]>();

                using (var spSite = new SPSite(siteUrl))
                {
                    using (
                        var sqlConnection =
                            new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        string queryString =
                            @"
                            SELECT Id, [Key], Value FROM PERSONALIZATIONS 
                            WHERE ({0}) AND UserId = @username AND ItemId = @itemId AND ListId = @listId AND WebId = @webId AND SiteId = @siteId";

                        string keyQuery = string.Empty;
                        for (int i = 0; i < keys.Count(); i++)
                        {
                            keyQuery += string.Format("[Key] = '{0}'", keys[i].Replace("'", "''"));
                            if (i != keys.Count() - 1) keyQuery += " OR ";
                        }

                        queryString = string.Format(queryString, keyQuery);

                        using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@username", username);
                            sqlCommand.Parameters.AddWithValue("@itemId", itemId);
                            sqlCommand.Parameters.AddWithValue("@listId", listId);
                            sqlCommand.Parameters.AddWithValue("@webId", webId);
                            sqlCommand.Parameters.AddWithValue("@siteId", siteId);

                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(() =>
                                                                         {
                                                                             sqlConnection.Open();

                                                                             SqlDataReader sqlDataReader =
                                                                                 sqlCommand.ExecuteReader();
                                                                             while (sqlDataReader.Read())
                                                                             {
                                                                                 string key =
                                                                                     sqlDataReader[1].ToString();
                                                                                 if (personalizations.ContainsKey(key))
                                                                                     continue;

                                                                                 personalizations.Add(key,
                                                                                                      new[]
                                                                                                          {
                                                                                                              sqlDataReader
                                                                                                                  [0].
                                                                                                                  ToString
                                                                                                                  (),
                                                                                                              sqlDataReader
                                                                                                                  [2].
                                                                                                                  ToString
                                                                                                                  ()
                                                                                                          });
                                                                             }
                                                                         });
                            }
                            catch (SqlException sqlException)
                            {
                                throw new APIException(5007, sqlException.Message);
                            }
                            finally
                            {
                                sqlConnection.Close();
                            }
                        }
                    }
                }

                return personalizations;
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(5006, e.Message);
            }
        }

        /// <summary>
        /// Processes the get my personalization params.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="keys">The keys.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="siteId">The site id.</param>
        /// <param name="siteUrl">The site URL.</param>
        private static void ProcessGetMyPersonalizationParams(string data, ref string[] keys, ref int itemId,
                                                              ref Guid listId, ref Guid webId, ref Guid siteId,
                                                              ref string siteUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(data)) throw new APIException(5002, "No parameters specified.");

                XDocument xDocument = XDocument.Parse(data);

                if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("MyPersonalization")))
                    throw new APIException(5003, "Cannot find element: MyPersonalization");

                XElement element = xDocument.Element("MyPersonalization");

                if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Keys")))
                    throw new APIException(5004, "Cannot find element: Keys");

                try
                {
                    Utils.ValidateItemListWebAndSite(element);
                }
                catch (Exception ex)
                {
                    throw new APIException(5005, ex.Message);
                }

                XElement xElement = xDocument.Element("MyPersonalization");

                keys = xElement.Element("Keys").Value.Split(',');
                itemId = int.Parse(xElement.Element("Item").Attribute("ID").Value);
                listId = new Guid(xElement.Element("List").Attribute("ID").Value);
                webId = new Guid(xElement.Element("Web").Attribute("ID").Value);
                siteId = new Guid(xElement.Element("Site").Attribute("ID").Value);
                siteUrl = xElement.Element("Site").Attribute("URL").Value;
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(5001, e.Message);
            }
        }

        /// <summary>
        /// Processes the set my personalization params.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="keyValuePair">The key value pair.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="siteId">The site id.</param>
        /// <param name="siteUrl">The site URL.</param>
        private static void ProcessSetMyPersonalizationParams(string data, ref Dictionary<string, string> keyValuePair,
                                                              ref int itemId,
                                                              ref Guid listId, ref Guid webId, ref Guid siteId,
                                                              ref string siteUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(data)) throw new Exception("No parameters specified.");

                XDocument xDocument = XDocument.Parse(data);

                if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("MyPersonalization")))
                    throw new APIException(5022, "Cannot find element: MyPersonalization");

                XElement element = xDocument.Element("MyPersonalization");

                try
                {
                    Utils.ValidateItemListWebAndSite(element);
                }
                catch (Exception ex)
                {
                    throw new APIException(5023, ex.Message);
                }

                if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Personalizations")))
                    throw new APIException(5024, "Cannot find element: Personalizations");

                if (
                    !element.Element("Personalizations").Descendants().ToList().Exists(
                        e => e.Name.LocalName.Equals("Personalization")))
                    throw new APIException(5025, "Cannot find element: Personalization");

                XElement xElement = xDocument.Element("MyPersonalization");

                itemId = int.Parse(xElement.Element("Item").Attribute("ID").Value);
                listId = new Guid(xElement.Element("List").Attribute("ID").Value);
                webId = new Guid(xElement.Element("Web").Attribute("ID").Value);
                siteId = new Guid(xElement.Element("Site").Attribute("ID").Value);
                siteUrl = xElement.Element("Site").Attribute("URL").Value;

                foreach (XElement personalization in xElement.Element("Personalizations").Elements("Personalization"))
                {
                    if (!personalization.Attributes().ToList().Exists(a => a.Name.LocalName.Equals("Key")))
                        throw new APIException(5026, "Cannot find attribute Key for element Personalization");
                    if (!personalization.Attributes().ToList().Exists(a => a.Name.LocalName.Equals("Value")))
                        throw new APIException(5027, "Cannot find attribute Value for element Personalization");

                    keyValuePair.Add(personalization.Attribute("Key").Value, personalization.Attribute("Value").Value);
                }
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(5021, e.Message);
            }
        }

        /// <summary>
        /// Sets the personalizations.
        /// </summary>
        /// <param name="keyValuePair">The key value pair.</param>
        /// <param name="username">The username.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="siteId">The site id.</param>
        /// <param name="siteUrl">The site URL.</param>
        public static void SetPersonalizations(Dictionary<string, string> keyValuePair, string username, int itemId,
                                                Guid listId, Guid webId, Guid siteId, string siteUrl)
        {
            try
            {
                using (var spSite = new SPSite(siteUrl))
                {
                    using (
                        var sqlConnection =
                            new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        Dictionary<string, string[]> personalizations = GetPersonalizations(
                            keyValuePair.Keys.ToArray(), username, itemId, listId, webId, siteId, siteUrl);

                        foreach (var valuePair in keyValuePair)
                        {
                            string queryString = personalizations.ContainsKey(valuePair.Key)
                                                     ? @"
                                UPDATE PERSONALIZATIONS SET Value = @value WHERE [Key] = @key AND UserId = @username 
                                AND ItemId = @itemId AND ListId = @listId AND WebId = @webId AND SiteId = @siteId"
                                                     : @"
                                INSERT INTO PERSONALIZATIONS ([Key], Value, UserId, ItemID, ListID, WebID, SiteID) 
                                VALUES (@key, @value, @username, @itemId, @listId, @webId, @siteId)";

                            using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@key", valuePair.Key);
                                sqlCommand.Parameters.AddWithValue("@value", valuePair.Value);
                                sqlCommand.Parameters.AddWithValue("@username", username);
                                sqlCommand.Parameters.AddWithValue("@itemId", itemId);
                                sqlCommand.Parameters.AddWithValue("@listId", listId);
                                sqlCommand.Parameters.AddWithValue("@webId", webId);
                                sqlCommand.Parameters.AddWithValue("@siteId", siteId);


                                try
                                {
                                    SPSecurity.RunWithElevatedPrivileges(() =>
                                                                             {
                                                                                 sqlConnection.Open();
                                                                                 sqlCommand.ExecuteNonQuery();
                                                                             });
                                }
                                catch (SqlException sqlException)
                                {
                                    throw new APIException(2029, sqlException.Message);
                                }
                                finally
                                {
                                    sqlConnection.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(5028, e.Message);
            }
        }

        /// <summary>
        /// Gets the value for one specific  
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetPersonalizationValue(string key, SPWeb oWeb, SPList oList)
        {
            var result = "";

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var cn = new SqlConnection(CoreFunctions.getConnectionString(oWeb.Site.WebApplication.Id)))
                {
                    cn.Open();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT VALUE FROM PERSONALIZATIONS where userid=@userid and [key]=@key and listid=@listid", cn);
                        cmd.Parameters.AddWithValue("@userid", oWeb.CurrentUser.ID.ToString());
                        cmd.Parameters.AddWithValue("@key", key);
                        cmd.Parameters.AddWithValue("@listid", oList.ID);
                        cmd.ExecuteNonQuery();

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                result = dr.GetString(0);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new APIException(7000, exception.Message, exception);
                    }
                }
            });

            return result;
        }

        /// <summary>
        /// Update personalization values given the keys
        /// </summary>
        /// <param name="keyValuePair"></param>
        /// <param name="userId"></param>
        /// <param name="listId"></param>
        /// <param name="webId"></param>
        /// <param name="siteId"></param>
        /// <param name="siteUrl"></param>
        internal static void UpdatePersonalizationValue(Dictionary<string, string> keyValuePair, string userId, Guid listId, Guid webId, Guid siteId, string siteUrl)
        {
            foreach (var item in keyValuePair)
            {
                using (var spSite = new SPSite(siteUrl))
                {
                    using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        try
                        {
                            var query = @"UPDATE PERSONALIZATIONS SET Value = @value WHERE [Key] = @key AND UserId = @userId AND ListId = @listId AND WebId = @webId AND SiteId = @siteId";

                            using (var sqlCommand = new SqlCommand(query, sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@key", item.Key);
                                sqlCommand.Parameters.AddWithValue("@value", item.Value);
                                sqlCommand.Parameters.AddWithValue("@userId", userId);
                                sqlCommand.Parameters.AddWithValue("@listId", listId);
                                sqlCommand.Parameters.AddWithValue("@webId", webId);
                                sqlCommand.Parameters.AddWithValue("@siteId", siteId);

                                SPSecurity.RunWithElevatedPrivileges(() =>
                                {
                                    sqlConnection.Open();
                                    sqlCommand.ExecuteNonQuery();
                                });
                            }
                        }

                        catch (Exception exception)
                        {
                            throw new APIException(7000, exception.Message, exception);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Delete a personalization entry
        /// </summary>
        /// <param name="key"></param>
        /// <param name="userId"></param>
        /// <param name="listId"></param>
        /// <param name="webId"></param>
        /// <param name="siteId"></param>
        /// <param name="siteUrl"></param>
        internal static void DeletePersonalization(string key, string userId, Guid listId, Guid webId, Guid siteId, string siteUrl)
        {
            using (var spSite = new SPSite(siteUrl))
            {
                using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                {
                    try
                    {
                        var query = @"DELETE FROM PERSONALIZATIONS WHERE [Key] = @key AND UserId = @userId AND ListId = @listId AND WebId = @webId AND SiteId = @siteId";

                        using (var sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@key", key);
                            sqlCommand.Parameters.AddWithValue("@userId", userId);
                            sqlCommand.Parameters.AddWithValue("@listId", listId);
                            sqlCommand.Parameters.AddWithValue("@webId", webId);
                            sqlCommand.Parameters.AddWithValue("@siteId", siteId);

                            SPSecurity.RunWithElevatedPrivileges(() =>
                            {
                                sqlConnection.Open();
                                sqlCommand.ExecuteNonQuery();
                            });
                        }
                    }

                    catch (Exception exception)
                    {
                        throw new APIException(7000, exception.Message, exception);
                    }
                }
            }
        }

        // Internal Methods (2) 

        /// <summary>
        /// Gets my personalization.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyPersonalization(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyPersonalization"));

                string username = SPContext.Current.Web.CurrentUser.LoginName;
                var keys = new string[] { };
                int itemId = 0;
                var listId = new Guid();
                var webId = new Guid();
                var siteId = new Guid();
                string siteUrl = string.Empty;

                ProcessGetMyPersonalizationParams(data, ref keys, ref itemId, ref listId, ref webId, ref siteId,
                                                  ref siteUrl);

                Dictionary<string, string[]> personalizations = GetPersonalizations(keys, username, itemId, listId,
                                                                                    webId, siteId, siteUrl);

                if (personalizations.Count() > 0)
                {
                    result.Element("MyPersonalization").Add(new XElement("Personalizations"));
                    XElement xElement = result.Element("MyPersonalization").Element("Personalizations");

                    xElement.Add(new XAttribute("Username", username));
                    xElement.Add(new XAttribute("ItemID", itemId));
                    xElement.Add(new XAttribute("ListID", listId));
                    xElement.Add(new XAttribute("WebID", webId));
                    xElement.Add(new XAttribute("SiteID", siteId));
                    xElement.Add(new XAttribute("SiteURL", siteUrl));

                    foreach (var personalization in personalizations)
                    {
                        var element = new XElement("Personalization");

                        element.Add(new XAttribute("ID", personalization.Value[0]));
                        element.Add(new XAttribute("Key", personalization.Key));
                        element.Add(new XAttribute("Value", personalization.Value[1]));

                        xElement.Add(element);
                    }
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(5000, e.Message);
            }
        }

        /// <summary>
        /// Sets my personalization.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string SetMyPersonalization(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("MyPersonalization"));

                string username = SPContext.Current.Web.CurrentUser.LoginName;
                var keyValuePair = new Dictionary<string, string>();
                int itemId = 0;
                var listId = new Guid();
                var webId = new Guid();
                var siteId = new Guid();
                string siteUrl = string.Empty;

                ProcessSetMyPersonalizationParams(data, ref keyValuePair, ref itemId, ref listId, ref webId, ref siteId,
                                                  ref siteUrl);

                SetPersonalizations(keyValuePair, username, itemId, listId, webId, siteId, siteUrl);

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(5020, e.Message);
            }
        }

        #endregion Methods 
    }
}