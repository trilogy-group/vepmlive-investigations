using System;
using System.Web.Services;
using System.Xml;
using System.Data.SqlClient;
using System.Web.Script.Services;

namespace BillingSite.appstore
{
    /// <summary>
    /// Summary description for AppStore
    /// </summary>
    [WebService(Namespace = "http://epmlive.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AppStore : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)] 
        public string AddStoreInformation(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string name = doc.FirstChild.SelectSingleNode("Name").InnerText;
                string email = doc.FirstChild.SelectSingleNode("Email").InnerText;
                string title = doc.FirstChild.SelectSingleNode("Title").InnerText;
                string appid = doc.FirstChild.SelectSingleNode("AppID").InnerText;
                string source = doc.FirstChild.SelectSingleNode("Source").InnerText;
                string sourceurl = doc.FirstChild.SelectSingleNode("SourceUrl").InnerText;

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmliveaccounts"].ConnectionString);
                cn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO APPSTOREINFORMATION (FullName,EMail,Title,APP_ID,source,sourceurl) VALUES (@name,@email,@title,@appid,@source,@sourceurl)", cn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@appid", appid);
                cmd.Parameters.AddWithValue("@source", source);
                cmd.Parameters.AddWithValue("@sourceurl", sourceurl);
                cmd.ExecuteNonQuery();

                cn.Close();

                return "Success";
            }
            catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
