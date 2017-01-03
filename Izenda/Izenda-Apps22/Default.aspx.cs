using System;
using System.Net;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Izenda.AdHoc;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

public partial class _Default : System.Web.UI.Page
{

	private bool LoggedIn = false;
	private bool HasAccess = false;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        if (Request["InFrame"] != "")
            HttpContext.Current.Session["InFrame"] = Request["InFrame"];
        else
            HttpContext.Current.Session["InFrame"] = "1";
        try
        {
            HttpContext.Current.Session["RepUrl"] = Request["RepUrl"];
        }
        catch
        {
        }

        //if (AdHocSettings.CurrentUserTenantId == null || AdHocSettings.CurrentUserTenantId == "")
        {
            AdHocSettings.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["IzendaLicenseKey"];
            //AdHocSettings.AdHocConfig.InvalidateFilteredCaches();

            SqlConnection cn =
                new SqlConnection(
                    System.Configuration.ConfigurationManager.ConnectionStrings["platform"].ConnectionString);
            cn.Open();
            HttpContext.Current.Session["StorageConnectionString"] = "";
            HttpContext.Current.Session["ConnectionString"] = "";
            HttpContext.Current.Session["siteid"] = Request["siteid"];

            if (String.IsNullOrEmpty(Request["webid"]))
                HttpContext.Current.Session["webid"] = Request["siteid"];
            else
                HttpContext.Current.Session["webid"] = Request["webid"];

            if (!string.IsNullOrEmpty(Request["reinit"]))
            {
            }
            else if (!string.IsNullOrEmpty(Request["dbid"]))
            {
                ProcessDBId(cn);
            }
            else if (!string.IsNullOrEmpty(Request["siteid"]))
            {
                //AdHocSettings.CurrentUserTenantId = Request["siteid"];
                ProcessSiteId(cn);
                //AdHocSettings.SqlServerConnectionString = HttpContext.Current.Session["ConnectionString"].ToString();
            }

            cn.Close();
        }

        ProcessLogin();
        string rn = "";
        try
        {
            rn = Request["rn"];
        }
        catch
        {
        }

        if (HttpContext.Current.Session["ConnectionString"] != null &&
            HttpContext.Current.Session["ConnectionString"].ToString() != "" && Request["Debug"] != "true")
        {
            string url = "ReportList.aspx";

            if (!string.IsNullOrEmpty(rn))
                url = "ReportViewer.aspx?rn=" + rn;

            if (!LoggedIn)
                Response.Redirect("Login.aspx?ReturnUrl=https://reports.epmlive.com/" + url);
            else if (HasAccess)
                Response.Redirect(url);
        }
        base.OnLoad(e);
    }


    private string DecodeFrom64(string encodedData)
    {
        byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
        string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

        return returnValue;
    }

    private void ProcessLogin()
    {
        if (Request["authid"] != null && Request["authid"] != "")
        {
            string[] authinfo = DecodeFrom64(Request["authid"]).Split('`');

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(@"
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <CheckAuth xmlns=""http://epmlive.com/"">
                      <AuthCode>" + authinfo[1] + @"</AuthCode>
                    </CheckAuth>
                  </soap:Body>
                </soap:Envelope>");

            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(authinfo[0]);

            webRequest.Headers.Add("SOAPAction: http://epmlive.com/CheckAuth");
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            Stream webStream = webRequest.GetRequestStream();
            xmlDoc.Save(webStream);
            webStream.Close();
            WebResponse webResponse = webRequest.GetResponse();
            webStream = webResponse.GetResponseStream();

            XmlDocument xmlResponse = new XmlDocument();

            XmlTextReader xmlReader = new XmlTextReader(webStream);
            xmlResponse.Load(xmlReader);
            webStream.Close();

            XmlNode ndResult = xmlResponse.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild;

            if (ndResult.FirstChild.InnerText.ToLower() == "true")
            {
                LoggedIn = true;
                bool validuser = false;
                SqlConnection cn = new SqlConnection(HttpContext.Current.Session["ConnectionString"].ToString());
                cn.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT     TOP (100) PERCENT LSTUserInformationList_1.Title
                        FROM         dbo.LSTUserInformationList INNER JOIN
                        dbo.RPTGROUPUSER ON dbo.LSTUserInformationList.ID = dbo.RPTGROUPUSER.USERID INNER JOIN
                        dbo.LSTUserInformationList AS LSTUserInformationList_1 ON dbo.RPTGROUPUSER.GROUPID = LSTUserInformationList_1.ID
                        WHERE     ((LSTUserInformationList_1.Title = 'Report Writers') OR
                        (LSTUserInformationList_1.Title = 'Report Viewers') OR
                        (LSTUserInformationList_1.Title = 'Administrators')) AND  LSTUserInformationList.name=@userid
                        ORDER BY LSTUserInformationList_1.Title DESC", cn);
                cmd.Parameters.AddWithValue("@userid",
                    HttpContext.Current.Session["Domain"].ToString() + ndResult.FirstChild.NextSibling.InnerText);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    validuser = true;
                    String sRole = dr.GetString(0);
                    if (sRole == "Administrators")
                        sRole = "Report Writers";

                    HttpContext.Current.Session["Role"] = sRole;
                }
                dr.Close();
                cn.Close();
                if (validuser)
                {
                    HasAccess = true;
                    HttpContext.Current.Session["UserName"] = ndResult.FirstChild.NextSibling.InnerText;
                    Izenda.AdHoc.AdHocSettings.AdHocConfig.PostLogin();
                }
                else
                {
                    Response.Write("You do not have access to view reports.");
                }
            }
        }
    }


    private void ProcessSiteId(SqlConnection cnPlatform)
    {
        SqlCommand cmd = new SqlCommand("SELECT SITE_TYPE,ConnectionString,Domain FROM SITES where SITE_ID=@dbid",
            cnPlatform);
        cmd.Parameters.AddWithValue("@dbid", Request["siteid"]);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            HttpContext.Current.Session["ConnectionString"] = dr.GetString(1);
            HttpContext.Current.Session["LoginType"] = dr.GetInt32(0);
            HttpContext.Current.Session["Domain"] = dr.GetString(2);
            HttpContext.Current.Session["StorageConnectionString"] =
                System.Configuration.ConfigurationManager.ConnectionStrings["platform"].ConnectionString;
        }
        else
        {
            Response.Write("Could not find site reporting info");
        }
        dr.Close();
    }


    private void ProcessDBId(SqlConnection cnPlatform)
    {
        try
        {
            SqlCommand cmd =
                new SqlCommand(
                    "SELECT CONNECTIONSTRING,username,password, SITE_TYPE,Domain FROM CONFIGDATABASES where DATABASE_ID=@dbid",
                    cnPlatform);
            cmd.Parameters.AddWithValue("@dbid", Request["dbid"]);

            string sqlConn = "";
            string username = "";
            string password = "";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sqlConn = dr.GetString(0);
                username = dr.GetString(1);
                password = dr.GetString(2);
                HttpContext.Current.Session["LoginType"] = dr.GetInt32(3);
                HttpContext.Current.Session["Domain"] = dr.GetString(4);
            }
            else
            {
                dr.Close();
                ProcessSiteId(cnPlatform);
            }
            dr.Close();

            if (sqlConn == "")
                return;

            if (sqlConn != "")
            {
                HttpContext.Current.Session["StorageConnectionString"] = sqlConn;

                SqlConnection cn = new SqlConnection(sqlConn);
                cn.Open();

                cmd = new SqlCommand("SELECT Databaseserver, databasename from RPTDATABASES where SITEID=@siteid", cn);
                cmd.Parameters.AddWithValue("@siteid", Request["siteid"]);
                string rptcn = "";

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    rptcn = "server=" + dr.GetString(0) + ";database=" + dr.GetString(1) + ";User ID=" + username +
                            ";Password=" + password;

                }
                else
                {
                    Response.Write("No Reporting DB found");
                }
                dr.Close();

                if (rptcn != "")
                {
                    cn = new SqlConnection(sqlConn);
                    cn.Open();

                    /*cmd = new SqlCommand("select * from sys.tables where name = 'IzendaAdHocReports'", cn);
                    bool found = false;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        found = true;
                    dr.Close();

                    if (!found)
                    {
                        cmd = new SqlCommand(@"CREATE TABLE [dbo].[IzendaAdHocReports](
	                                                    [Name] [nvarchar](255) NULL,
	                                                    [Xml] [ntext] NULL,
	                                                    [CreatedDate] [datetime] NULL,
	                                                    [ModifiedDate] [datetime] NULL,
	                                                    [TenantID] [nvarchar](255) NULL,
	                                                    [Thumbnail] [varbinary](max) NULL
                                                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]", cn);
                        cmd.ExecuteNonQuery();

                    }*/
                    cn.Close();
                    HttpContext.Current.Session["ConnectionString"] = rptcn;
                }
                cn.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }
    }
}