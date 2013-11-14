using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class redirect : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string username = CoreFunctions.GetJustUsername(SPContext.Current.Web.CurrentUser.LoginName);
                Guid gAuth = Guid.NewGuid();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("spAddAuth", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@authid", gAuth);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", SPContext.Current.Web.CurrentUser.Email);
                    cmd.ExecuteNonQuery();


                    cn.Close();

                });

                string b64 = EncodeTo64(CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "epmliveapiurl") + "/integration.asmx`" + gAuth);

                string reportsurl = CoreFunctions.getFarmSetting("UplandAnalyticsUrl");

                string url = "";

                if (reportsurl == "https://reports.epmlive.com")
                {
                    url = "https://reports.epmlive.com/?dbid=" + SPContext.Current.Site.WebApplication.Id + "&siteid=" + SPContext.Current.Site.ID + "&webid=" + SPContext.Current.Web.ID + "&authid=" + b64;
                }
                else
                    url = reportsurl;

                if (url != "")
                {
                    string rn = "";
                    try { rn = Request["rn"].ToString(); }
                    catch { }

                    if (rn != "")
                        url += "&rn=" + rn;

                    Response.Redirect(url + "&InFrame=1&RepUrl=" + System.Web.HttpUtility.UrlEncode(SPContext.Current.Web.Url + "/_layouts/epmlive/reporting/izenda/reporting.aspx"));
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes

                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }
    }
}
