using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveAccountManagement
{
    class EPMLiveAccInfo : WebControl
    {
        protected override void CreateChildControls()
        {
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback +=
                //delegate(
                //    object sender,
                //    X509Certificate certificate,
                //    X509Chain chain,
                //    SslPolicyErrors sslPolicyErrors)
                //{
                //    return true;
                //};

                //SPSite site = SPContext.Current.Site;
                SPWeb web = SPContext.Current.Web;
                //SqlConnection cn = null;
                //SPSecurity.RunWithElevatedPrivileges(delegate()
                //{
                //    cn = new SqlConnection(Settings.getConnectionString());
                //    cn.Open();
                //});

                //SqlCommand cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@siteid", site.ID);
                //cmd.Parameters.AddWithValue("@contractLevel", Settings.getContractLevel());
                //SqlDataReader dr = cmd.ExecuteReader();
                //string owneruname = "";
                //if(dr.Read())
                //{
                //    owneruname = dr.GetString(13);
                //}
                //dr.Close();



                //cn.Close();

                //if(owneruname.ToLower() == EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower())
                //{
                    string url = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;

                    MenuItemTemplate menu = new MenuItemTemplate();
                    menu.Text = "EPM Live Account Settings";
                    menu.Description = "Modify and view your account and billing information";
                    menu.Sequence = 10;
                    menu.ImageUrl = "/_layouts/images/epmlivelogo.GIF";
                    //menu.ClientOnClickNavigateUrl;// =  + "/_layouts/epmlive/workplanner.aspx?Planner=" + sPlanner[0] + "&source=" + HttpUtility.UrlEncode(HttpContext.Current.Request.ServerVariables["URL"]);
                    menu.ClientOnClickScript = "SP.UI.ModalDialog.showModalDialog({url: '" + url + "/_layouts/epmlive/manageaccount.aspx',width: 800,height: 600});";
                    Controls.Add(menu);
                //}
            }
            catch { }
        }
    }
}
