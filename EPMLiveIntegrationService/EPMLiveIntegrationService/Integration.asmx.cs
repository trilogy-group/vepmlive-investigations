using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
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
        /// <summary>
        /// Used for TfsIntegration Events
        /// </summary>
        /// <param name="eventXml"></param>
        /// <param name="tfsIdentityXml"></param>
        [WebMethod]
        [SoapDocumentMethod(Action = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify", RequestNamespace = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03")]
        public string Notify(string eventXml, string tfsIdentityXml)
        {
            string ret = "";
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
                            Int64 ID;
                            if (xmlNode != null && Int64.TryParse(xmlNode.SelectSingleNode("NewValue").InnerText, out ID) && !string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Request["IntegrationKey"])))
                            {
                                SPFarm farm = SPFarm.Local;
                                SPWebService service = farm.Services.GetValue<SPWebService>("");
                                foreach (SPWebApplication webapp in service.WebApplications)
                                {
                                    if (webapp.Name == System.Configuration.ConfigurationManager.AppSettings["WebApplication"])
                                    {
                                        ret = iPostSimple(webapp, Convert.ToString(HttpContext.Current.Request["IntegrationKey"]), Convert.ToString(ID));
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

            string ret = "";
            UserInfo ui = new UserInfo();
            ui.bValidAuth = false;
            //try
            {
                SPFarm farm = SPFarm.Local;
                //Get all SharePoint Web services 
                SPWebService service = farm.Services.GetValue<SPWebService>("");

                foreach (SPWebApplication webapp in service.WebApplications)
                {
                    if (webapp.Name == System.Configuration.ConfigurationManager.AppSettings["WebApplication"])
                    {
                        ui = iCheckAuth(webapp, AuthCode);
                    }
                }
            }
            //catch(Exception ex)
            {

            }
            return ui;
        }

        [WebMethod]
        public string PostItemSimple(string IntegrationKey, string ID)
        {
            string ret = "";

            try
            {
                SPFarm farm = SPFarm.Local;
                //Get all SharePoint Web services 
                SPWebService service = farm.Services.GetValue<SPWebService>("");

                foreach (SPWebApplication webapp in service.WebApplications)
                {
                    if (webapp.Name == System.Configuration.ConfigurationManager.AppSettings["WebApplication"])
                    {
                        ret = iPostSimple(webapp, IntegrationKey, ID);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ret = "<Error>" + ex.Message + "</Error>";
            }
            return ret;
        }

        [WebMethod]
        public string AddUpdateItem(string IntegrationKey, string XML)
        {
            string ret = "";

            try
            {
                SPFarm farm = SPFarm.Local;
                //Get all SharePoint Web services 
                SPWebService service = farm.Services.GetValue<SPWebService>("");

                foreach (SPWebApplication webapp in service.WebApplications)
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
                ret = "<Error>" + ex.Message + "</Error>";
            }
            return ret;
        }

        [WebMethod]
        public string DeleteItem(string IntegrationKey, string ID)
        {
            string ret = "";

            try
            {
                SPFarm farm = SPFarm.Local;
                //Get all SharePoint Web services 
                SPWebService service = farm.Services.GetValue<SPWebService>("");

                foreach (SPWebApplication webapp in service.WebApplications)
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
                ret = "<Error>" + ex.Message + "</Error>";
            }
            return ret;
        }

        private UserInfo iCheckAuth(SPWebApplication webapp, string AuthCode)
        {
            UserInfo ui = new UserInfo();
            ui.bValidAuth = false;
            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(webapp.Id));
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT username,email from INT_AUTH WHERE     (AUTH_ID = @authid) AND (DATEDIFF(mi, datetime, GETDATE()) < 2)", cn);
            cmd.Parameters.AddWithValue("@authid", AuthCode);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                ui.bValidAuth = true;
                ui.username = dr.GetString(0);
                ui.email = dr.GetString(1);

            }
            dr.Close();
            cmd = new SqlCommand("DELETE from INT_AUTH WHERE     (AUTH_ID = @authid)", cn);
            cmd.Parameters.AddWithValue("@authid", AuthCode);
            cmd.ExecuteNonQuery();
            cn.Close();


            return ui;
        }

        private bool iAuthenticate(string IntegrationKey, out string ret, out DataSet dsIntegration, SqlConnection cn)
        {
            Guid intlistid = Guid.Empty;
            int attempts = 0;
            dsIntegration = new DataSet();
            string ip = HttpContext.Current.Request.UserHostAddress;

            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM INT_IP where IP=@ip and DTLOGGED > DATEADD (d , -1 , GETDATE() )", cn);
            cmd.Parameters.AddWithValue("@ip", ip);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            attempts = dr.GetInt32(0);
            dr.Close();

            if (attempts < 5)
            {
                cmd = new SqlCommand("SELECT * FROM INT_LISTS where int_key=@intkey and LIVEINCOMING=1", cn);
                cmd.Parameters.AddWithValue("@intkey", IntegrationKey);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsIntegration);

                if (dsIntegration.Tables[0].Rows.Count > 0)
                {
                    ret = "";
                    return true;
                }
                else
                {
                    ret = "<Error>Invalid Key</Error>";

                    cmd = new SqlCommand("SELECT * FROM INT_IP where IP=@ip and DTLOGGED > DATEADD (d , -1 , GETDATE() ) and intkey=@intkey", cn);
                    cmd.Parameters.AddWithValue("@ip", ip);
                    cmd.Parameters.AddWithValue("@intkey", IntegrationKey);

                    bool found = false;

                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        found = true;
                    dr.Close();

                    if (!found)
                    {
                        cmd = new SqlCommand("INSERT INTO INT_IP (IP,intkey) VALUES (@ip,@intkey)", cn);
                        cmd.Parameters.AddWithValue("@ip", ip);
                        cmd.Parameters.AddWithValue("@intkey", IntegrationKey);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                ret = "<Error>Too Many Attempts</Error>";
            }
            return false;
        }

        private bool iCheckXml(XmlDocument doc, out string sError)
        {
            sError = "";

            try
            {

                if (doc.FirstChild.Name == "Items")
                {
                    XmlNode ndItem = doc.FirstChild.SelectSingleNode("Item");
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
            string ret = "";
            try
            {
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(webapp.Id));
                cn.Open();

                DataSet dsIntegration = new DataSet();

                if (iAuthenticate(IntegrationKey, out ret, out dsIntegration, cn))
                {
                    if (dsIntegration.Tables[0].Rows[0]["MODULE_ID"].ToString() == "a0950b9b-3525-40b8-a456-6403156dc49c")
                    {
                        string sError = "";

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(XML);

                        if (iCheckXml(doc, out sError))
                        {
                            string idCol = "";

                            SqlCommand cmd = new SqlCommand("SELECT [VALUE] FROM INT_PROPS WHERE INT_LIST_ID=@intlistid and [PROPERTY]='IDColumn'", cn);
                            cmd.Parameters.AddWithValue("@intlistid", dsIntegration.Tables[0].Rows[0]["INT_LIST_ID"].ToString());
                            SqlDataReader r = cmd.ExecuteReader();
                            if (r.Read())
                            {
                                idCol = r.GetString(0);
                            }
                            r.Close();

                            if (idCol != "")
                            {
                                XmlNode ndItems = doc.SelectSingleNode("Items");

                                foreach (XmlNode ndItem in ndItems.SelectNodes("Item"))
                                {
                                    string ID = "";

                                    try
                                    {
                                        ID = ndItem.SelectSingleNode("Fields/Field[@Name='" + idCol + "']").InnerText;
                                    }
                                    catch { }

                                    if (ID != "")
                                    {
                                        cmd = new SqlCommand("INSERT INTO INT_EVENTS (LIST_ID, INTITEM_ID, COL_ID, STATUS, DIRECTION, TYPE, DATA) VALUES (@listid, @intitemid, @colid, 0, 2, 1, @data)", cn);
                                        cmd.Parameters.AddWithValue("@listid", dsIntegration.Tables[0].Rows[0]["LIST_ID"].ToString());
                                        cmd.Parameters.AddWithValue("@intitemid", ID);
                                        cmd.Parameters.AddWithValue("@colid", dsIntegration.Tables[0].Rows[0]["INT_COLID"].ToString());
                                        cmd.Parameters.AddWithValue("@data", ndItem.OuterXml);
                                        cmd.ExecuteNonQuery();
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

                cn.Close();

                //ret = "<Success/>";

            }
            catch (Exception ex)
            {
                ret = "<Error>" + ex.Message + "</Error>";
            }
            return ret;
        }

        private string iPostSimple(SPWebApplication webapp, string IntegrationKey, string ID)
        {
            string ret = "";
            try
            {
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(webapp.Id));
                cn.Open();

                DataSet dsIntegration = new DataSet();

                if (iAuthenticate(IntegrationKey, out ret, out dsIntegration, cn))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO INT_EVENTS (LIST_ID, INTITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @intitemid, @colid, 0, 2, 1)", cn);
                    cmd.Parameters.AddWithValue("@listid", dsIntegration.Tables[0].Rows[0]["LIST_ID"].ToString());
                    cmd.Parameters.AddWithValue("@intitemid", ID);
                    cmd.Parameters.AddWithValue("@colid", dsIntegration.Tables[0].Rows[0]["INT_COLID"].ToString());
                    cmd.ExecuteNonQuery();

                    ret = "<Success/>";
                }

                cn.Close();

                //ret = "<Success/>";

            }
            catch (Exception ex)
            {
                ret = "<Error>" + ex.Message + "</Error>";
            }
            return ret;
        }

        private string iDeleteItem(SPWebApplication webapp, string IntegrationKey, string ID)
        {
            string ret = "";
            try
            {
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(webapp.Id));
                cn.Open();

                DataSet dsIntegration = new DataSet();

                if (iAuthenticate(IntegrationKey, out ret, out dsIntegration, cn))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO INT_EVENTS (LIST_ID, INTITEM_ID, COL_ID, STATUS, DIRECTION, TYPE) VALUES (@listid, @intitemid, @colid, 0, 2, 2)", cn);
                    cmd.Parameters.AddWithValue("@listid", dsIntegration.Tables[0].Rows[0]["LIST_ID"].ToString());
                    cmd.Parameters.AddWithValue("@intitemid", ID);
                    cmd.Parameters.AddWithValue("@colid", dsIntegration.Tables[0].Rows[0]["INT_COLID"].ToString());
                    cmd.ExecuteNonQuery();

                    ret = "<Success/>";
                }

                cn.Close();

                //ret = "<Success/>";

            }
            catch (Exception ex)
            {
                ret = "<Error>" + ex.Message + "</Error>";
            }
            return ret;
        }
    }
}