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
        HttpContext.Current.Session["InFrame"] = "1";
        try
        {
            HttpContext.Current.Session["RepUrl"] = Request["RepUrl"];
        }
        catch
        {
        }

        HttpContext.Current.Session["webid"] = Request["webid"];

        AdHocSettings.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["IzendaLicenseKey"];
        AdHocSettings.CurrentUserTenantId = Request["webid"];
        HttpContext.Current.Session["Role"] = "Report Writers";

        SetupConnection();

        string rn = "";
        try
        {
            rn = Request["rn"];
        }
        catch
        {
        }

        ProcessLogin();

        if (LoggedIn && HttpContext.Current.Session["ConnectionString"] != null &&
            HttpContext.Current.Session["ConnectionString"].ToString() != "" && Request["Debug"] != "true")
        {

            string url = "ReportList.aspx";

            if (!string.IsNullOrEmpty(rn))
                url = "ReportViewer.aspx?rn=" + rn;

            if (HasAccess)
                Response.Redirect(url);

        }

        base.OnLoad(e);
    }

    private void SetupConnection()
    {
        HttpContext.Current.Session["StorageConnectionString"] =
            System.Configuration.ConfigurationManager.AppSettings["EPMLiveDB"].ToString();

        SqlConnection cn =
            new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["EPMLiveDB"].ToString());
        cn.Open();

        SqlCommand cmd =
            new SqlCommand(
                "SELECT Databaseserver, databasename,username,password from RPTDATABASES where SITEID=@siteid", cn);
        cmd.Parameters.AddWithValue("@siteid", Request["siteid"]);
        string rptcn = "";

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            rptcn = "server=" + dr.GetString(0) + ";database=" + dr.GetString(1) + ";Trusted_Connection=True";
        }
        else
        {
            Response.Write("No Reporting DB found");
        }
        dr.Close();

        if (rptcn != "")
        {
            cn = new SqlConnection(rptcn);
            cn.Open();

            cn.Close();

            HttpContext.Current.Session["ConnectionString"] = rptcn;
        }

        cn.Close();
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
                                      (LSTUserInformationList_1.Title = 'Administrators')) AND  LSTUserInformationList.name like @userid
                                      ORDER BY LSTUserInformationList_1.Title DESC", cn);
                cmd.Parameters.AddWithValue("@userid", "%|" + ndResult.FirstChild.NextSibling.InnerText);
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

    private string DecodeFrom64(string encodedData)
    {
        byte[] encodedDataAsBytes
            = System.Convert.FromBase64String(encodedData);

        string returnValue =
            System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);

        return returnValue;
    }

}