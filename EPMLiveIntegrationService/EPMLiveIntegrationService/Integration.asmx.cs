using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Web.Services.Protocols;

namespace EPMLiveIntegrationService
{
    public struct UserInfo
    {
        public bool bValidAuth;
        public string username;
        public string email;
    }

    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://epmlive.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Integration : System.Web.Services.WebService
    {
        public const string ModuleId = "a0950b9b-3525-40b8-a456-6403156dc49c";
        /// <summary>
        /// Used for TfsIntegration Events
        /// </summary>
        /// <param name="eventXml"></param>
        /// <param name="tfsIdentityXml"></param>
        [WebMethod]
        [SoapDocumentMethod(Action = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify", RequestNamespace = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03")]
        public string Notify(string eventXml, string tfsIdentityXml)
        {
            var ret = string.Empty;
            XmlDocument xmlDocument;
            XmlNode xmlNode;
            try
            {
                if (!string.IsNullOrEmpty(eventXml))
                {
                    xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(eventXml);

                    switch (xmlDocument.DocumentElement.Name)
                    {
                        case "WorkItemChangedEvent":
                            xmlNode = xmlDocument.SelectSingleNode("WorkItemChangedEvent/CoreFields/IntegerFields/Field");
                            var xmlNodeToCheckDelete = xmlDocument.SelectSingleNode("WorkItemChangedEvent/CoreFields/BooleanFields/Field");
                            long ID;
                            bool isDeleted = false;
                            if (xmlNode != null && Int64.TryParse(xmlNode.SelectSingleNode("NewValue").InnerText, out ID) && !string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Request["IntegrationKey"])))
                            {
                                if (xmlNodeToCheckDelete != null)
                                {
                                    bool.TryParse(xmlNodeToCheckDelete.SelectSingleNode("NewValue").InnerText, out isDeleted);
                                }

                                var farm = SPFarm.Local;
                                var service = farm.Services.GetValue<SPWebService>(string.Empty);
                                foreach (var webapp in service.WebApplications)
                                {
                                    if (webapp.Name == System.Configuration.ConfigurationManager.AppSettings["WebApplication"])
                                    {
                                        ret = iPostSimple(webapp, Convert.ToString(HttpContext.Current.Request["IntegrationKey"]), Convert.ToString(ID), isDeleted ? "2" : "1");
                                        break;
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ret = "<Error>" + ex.Message + "</Error>";
            }
            finally
            {
                xmlDocument = null;
                xmlNode = null;
            }
            return ret;
        }


        [WebMethod]
        public UserInfo CheckAuth(string AuthCode)
        {
            var ui = new UserInfo {bValidAuth = false};

            var farm = SPFarm.Local;
            //Get all SharePoint Web services 
            var service = farm.Services.GetValue<SPWebService>(string.Empty);

            foreach (var webapp in service.WebApplications)
            {
                if (webapp.Name == System.Configuration.ConfigurationManager.AppSettings["WebApplication"])
                {
                    ui = iCheckAuth(webapp, AuthCode);
                }
            }

            return ui;
        }

        [WebMethod]
        public string PostItemSimple(string IntegrationKey, string ID)
        {
            string ret = string.Empty;

            try
            {
                var farm = SPFarm.Local;
                //Get all SharePoint Web services 
                var service = farm.Services.GetValue<SPWebService>(string.Empty);

                foreach (var webapp in service.WebApplications)
                {
                    if (webapp.Name == System.Configuration.ConfigurationManager.AppSettings["WebApplication"])
                    {
                        ret = iPostSimple(webapp, IntegrationKey, ID, "1");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ret = $"<Error>{ex.Message}</Error>";
            }
            return ret;
        }

        [WebMethod]
        public string AddUpdateItem(string IntegrationKey, string XML)
        {
            var ret = string.Empty;

            try
            {
                var farm = SPFarm.Local;
                //Get all SharePoint Web services 
                var service = farm.Services.GetValue<SPWebService>(string.Empty);

                foreach (var webapp in service.WebApplications)
                {
                    if (webapp.Name == System.Configuration.ConfigurationManager.AppSettings["WebApplication"])
                    {
                        ret = iPostComplex(webapp, IntegrationKey, XML);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ret = $"<Error>{ex.Message}</Error>";
            }
            return ret;
        }

        [WebMethod]
        public string DeleteItem(string IntegrationKey, string ID)
        {
            var ret = string.Empty;

            try
            {
                var farm = SPFarm.Local;
                //Get all SharePoint Web services 
                var service = farm.Services.GetValue<SPWebService>(string.Empty);

                foreach (var webapp in service.WebApplications)
                {
                    if (webapp.Name == System.Configuration.ConfigurationManager.AppSettings["WebApplication"])
                    {
                        ret = iDeleteItem(webapp, IntegrationKey, ID);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ret = $"<Error>{ex.Message}</Error>";
            }
            return ret;
        }

        private UserInfo iCheckAuth(SPWebApplication webapp, string AuthCode)
        {
            var ui = new UserInfo {bValidAuth = false};
            using (var connection = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(webapp.Id)))
            {
                connection.Open();

                var sql = "SELECT username,email from INT_AUTH WHERE     (AUTH_ID = @authid) AND (DATEDIFF(mi, datetime, GETDATE()) < 2)";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@authid", AuthCode);
                    using (var dr = command.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ui.bValidAuth = true;
                            ui.username = dr.GetString(0);
                            ui.email = dr.GetString(1);
                        }
                    }
                }

                using (var command = new SqlCommand("DELETE from INT_AUTH WHERE     (AUTH_ID = @authid)", connection))
                {
                    command.Parameters.AddWithValue("@authid", AuthCode);
                    command.ExecuteNonQuery();
                }
            }

            return ui;
        }

        private bool iAuthenticate(string IntegrationKey, out string ret, out DataSet dsIntegration, SqlConnection connection)
        {
            var attempts = 0;

            dsIntegration = new DataSet();
            var ip = HttpContext.Current.Request.UserHostAddress;

            using (var command = new SqlCommand("SELECT count(*) FROM INT_IP where IP=@ip and DTLOGGED > DATEADD (d , -1 , GETDATE() )", connection))
            {
                command.Parameters.AddWithValue("@ip", ip);
                var dataReader = command.ExecuteReader();
                dataReader.Read();
                attempts = dataReader.GetInt32(0);
                dataReader.Close();
            }

            if (attempts < 5)
            {
                using (var command = new SqlCommand("SELECT * FROM INT_LISTS where int_key=@intkey and LIVEINCOMING=1", connection))
                {
                    command.Parameters.AddWithValue("@intkey", IntegrationKey);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dsIntegration);
                    }
                }

                if (GetRowsCount(dsIntegration) > 0)
                {
                    ret = string.Empty;
                    return true;
                }

                ret = "<Error>Invalid Key</Error>";
                var found = false;
                var sql = "SELECT * FROM INT_IP where IP=@ip and DTLOGGED > DATEADD (d , -1 , GETDATE() ) and intkey=@intkey";
                using (var commmand = new SqlCommand(sql, connection))
                {
                    commmand.Parameters.AddWithValue("@ip", ip);
                    commmand.Parameters.AddWithValue("@intkey", IntegrationKey);

                    using (var reader = commmand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            found = true;
                        }
                    }
                }

                if (!found)
                {
                    using (var commmand = new SqlCommand("INSERT INTO INT_IP (IP,intkey) VALUES (@ip,@intkey)", connection))
                    {
                        commmand.Parameters.AddWithValue("@ip", ip);
                        commmand.Parameters.AddWithValue("@intkey", IntegrationKey);
                        commmand.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                ret = "<Error>Too Many Attempts</Error>";
            }
            return false;
        }

        public static int GetRowsCount(DataSet dataSet, int tableIndex =0)
        {
            return dataSet.Tables.Count > tableIndex
                ? dataSet.Tables[tableIndex].Rows.Count
                : 0;
        }

        public static string GetRowValue(DataSet dataSet, string key, int tableIndex = 0, int rowIndex = 0)
        {
            var rows = dataSet.Tables.Count > tableIndex
                ? dataSet.Tables[tableIndex].Rows
                : null;
            if (rows == null)
            {
                return string.Empty;
            }

            return rows.Count > rowIndex
                ? rows[rowIndex][key].ToString()
                : string.Empty;
        }

        public static bool iCheckXml(XmlDocument doc, out string sError)
        {
            sError = string.Empty;

            try
            {
                if (doc.FirstChild.Name == "Items")
                {
                    var ndItem = doc.FirstChild.SelectSingleNode("Item");
                    if (ndItem != null)
                    {
                        return true;
                    }
                    else
                    {
                        sError = "'Items' node must contain one or more 'Item' nodes";
                        return false;
                    }
                }
                else
                {
                    sError = "First node must be of name 'Items'";
                    return false;
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
        }

        private string iPostComplex(SPWebApplication webapp, string IntegrationKey, string XML)
        {
            string ret;
            try
            {
                using (var connection = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(webapp.Id)))
                {
                    connection.Open();

                    DataSet dsIntegration = new DataSet();

                    if (iAuthenticate(IntegrationKey, out ret, out dsIntegration, connection))
                    {
                        if (GetRowValue(dsIntegration, "MODULE_ID") == ModuleId)
                        {
                            string sError;

                            var doc = new XmlDocument();
                            doc.LoadXml(XML);

                            if (iCheckXml(doc, out sError))
                            {
                                var idCol = string.Empty;

                                var sql = "SELECT [VALUE] FROM INT_PROPS WHERE INT_LIST_ID=@intlistid and [PROPERTY]='IDColumn'";
                                using (var command = new SqlCommand(sql, connection))
                                {
                                    command.Parameters.AddWithValue("@intlistid", GetRowValue(dsIntegration, "INT_LIST_ID"));
                                    using (var dataReader = command.ExecuteReader())
                                    {
                                        if (dataReader.Read())
                                        {
                                            idCol = dataReader.GetString(0);
                                        }
                                    }
                                }

                                if (idCol != string.Empty)
                                {
                                    var ndItems = doc.SelectSingleNode("Items");

                                    foreach (XmlNode ndItem in ndItems.SelectNodes("Item"))
                                    {
                                        string ID = string.Empty;

                                        try
                                        {
                                            ID = ndItem.SelectSingleNode("Fields/Field[@Name='" + idCol + "']").InnerText;
                                        }
                                        catch (Exception ex)
                                        {
                                            Debug.WriteLine(ex);
                                        }

                                        if (ID != string.Empty)
                                        {
                                            sql = "INSERT INTO INT_EVENTS (LIST_ID, INTITEM_ID, COL_ID, STATUS, DIRECTION, TYPE, DATA) VALUES (@listid, @intitemid, @colid, 0, 2, 1, @data)";
                                            using (var command = new SqlCommand(sql, connection))
                                            {
                                                command.Parameters.AddWithValue("@listid", GetRowValue(dsIntegration, "LIST_ID"));
                                                command.Parameters.AddWithValue("@intitemid", ID);
                                                command.Parameters.AddWithValue("@colid", GetRowValue(dsIntegration, "INT_COLID"));
                                                command.Parameters.AddWithValue("@data", ndItem.OuterXml);
                                                command.ExecuteNonQuery();
                                            }
                                        }
                                    }

                                    ret = "<Success/>";
                                }
                                else
                                {
                                    ret = "<Error>ID Column not specified in settings</Error>";
                                }
                            }
                            else
                            {
                                ret = "<Error>" + sError + "</Error>";
                            }
                        }
                        else
                        {
                            ret = "<Error>That integration key is not a generic integration</Error>";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ret = "<Error>" + ex.Message + "</Error>";
            }
            return ret;
        }

        private string iPostSimple(SPWebApplication webapp, string IntegrationKey, string ID, string type)
        {
            string ret;
            try
            {
                using (var connection = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(webapp.Id)))
                {
                    connection.Open();

                    var dsIntegration = new DataSet();

                    if (iAuthenticate(IntegrationKey, out ret, out dsIntegration, connection))
                    {
                        var sql = "INSERT INTO INT_EVENTS (LIST_ID, INTITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @intitemid, @colid, 0, 2, @type)";
                        using (var command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@listid", GetRowValue(dsIntegration, "LIST_ID"));
                            command.Parameters.AddWithValue("@intitemid", ID);
                            command.Parameters.AddWithValue("@colid", GetRowValue(dsIntegration, "INT_COLID"));
                            command.Parameters.AddWithValue("@type", type);
                            command.ExecuteNonQuery();
                        }

                        ret = "<Success/>";
                    }
                }

            }
            catch (Exception ex)
            {
                ret = $"<Error>{ex.Message}</Error>";
            }
            return ret;
        }

        private string iDeleteItem(SPWebApplication webapp, string IntegrationKey, string ID)
        {
            string ret;
            try
            {
                using (var connection = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(webapp.Id)))
                {
                    connection.Open();

                    var dsIntegration = new DataSet();

                    if (iAuthenticate(IntegrationKey, out ret, out dsIntegration, connection))
                    {
                        var sql = "INSERT INTO INT_EVENTS (LIST_ID, INTITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @intitemid, @colid, 0, 2, 2)";
                        using (var command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@listid", GetRowValue(dsIntegration, "LIST_ID"));
                            command.Parameters.AddWithValue("@intitemid", ID);
                            command.Parameters.AddWithValue("@colid", GetRowValue(dsIntegration, "INT_COLID"));
                            command.ExecuteNonQuery();
                        }

                        ret = "<Success/>";
                    }
                }
            }
            catch (Exception ex)
            {
                ret = "<Error>" + ex.Message + "</Error>";
            }
            return ret;
        }
    }
}