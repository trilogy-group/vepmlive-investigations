using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace EPMLiveAccountManagement.SiteCollectionList
{
    [ToolboxItemAttribute(false)]
    public class SiteCollectionList : WebPart
    {
        protected override void CreateChildControls()
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            SPUser user = SPContext.Current.Web.CurrentUser;
            SPWeb web = SPContext.Current.Web;

            string username = EPMLiveCore.CoreFunctions.GetRealUserName(user.LoginName);

            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());

                cn.Open();

            });
            SqlCommand cmd;
            SqlDataReader dr;

            if(Settings.getContractLevel() != "3")
            {
                cmd = new SqlCommand("SP_CanCreateSites", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@USERNAME", username);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    if(dr.GetInt32(0) == 1)
                    {
                        writer.WriteLine("<script language=\"javascript\">");
                        writer.WriteLine("function NewApp(){");
                        writer.WriteLine("var options = { title:'Create Application', url:'" + ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_layouts/epmlive/CreateApplication.aspx?type=sitecollection', width:800, height:600 }; SP.UI.ModalDialog.showModalDialog(options);");
                        writer.WriteLine("}");
                        writer.WriteLine("</script>");

                        //" +  + @"/_layouts/epmlive/newsitecollection.aspx

                        writer.WriteLine(@"<table class=""ms-menutoolbar"" cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""height:25px"" >
                        <tr>
                            <td class=""ms-toolbar"" nowrap=""true"" >
                                <table height=""100%"" border=""0"" cellspacing=""0"" onmouseover=""MMU_EcbTableMouseOverOut(this, true)"" hoverActive=""ms-splitbuttonhover"" hoverInactive=""ms-splitbutton"" downArrowTitle=""Open Menu"">
                                    <tr>
                                        <td valign=""middle"" class=""ms-splitbuttontext"">
                                            <a href = ""Javascript:NewApp();"">Create Application</a>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                    ");
                    }
                }
                dr.Close();
            }

            writer.WriteLine("<table>");

            int counter = 0;
            string url = "";

            cmd = new SqlCommand("select siteguid from vw2010SitesIOwn where username=@username", cn);
            cmd.Parameters.AddWithValue("@username", username);
            dr = cmd.ExecuteReader();

            writer.WriteLine("<tr><td class=\"ms-decriptiontext\"><b>Applications I Own</b></td></tr>");

            ArrayList arrSites = new ArrayList();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                while (dr.Read())
                {
                    try
                    {

                        SPSite site = new SPSite(dr.GetGuid(0), user.UserToken);
                        site.CatchAccessDeniedException = false;
                        if(site.ServerRelativeUrl != "/" && site.ServerRelativeUrl != "/home")
                        {
                            if(site.OpenWeb().DoesUserHavePermissions(SPBasePermissions.ViewListItems))
                            {
                                if(!arrSites.Contains(site.ID))
                                    arrSites.Add(site.ID);

                                url = site.Url;

                                counter++;
                                writer.WriteLine("<tr><td class=\"ms-vb2\" style=\"padding-left:10px;\"> <img src=\"/_layouts/images/SharePointFoundation16.png\"><font class=\"ms-vb\"> <a class=\"ms-vb\" href=\"" + site.Url + "\" target=\"_blank\">" + site.RootWeb.Title + "</a> - " + site.RootWeb.Description + "</td></tr>");
                            }
                        }
                    }
                    catch { }
                }

                dr.Close();

                cmd = new SqlCommand("select siteguid from vw2010SitesIAmIn where username=@username", cn);
                cmd.Parameters.AddWithValue("@username", username);
                dr = cmd.ExecuteReader();
                writer.WriteLine("<tr><td class=\"ms-decriptiontext\"><b>Applications I Am a Member Of</b></td></tr>");
                while (dr.Read())
                {

                    try
                    {
                        SPSite site = new SPSite(dr.GetGuid(0), user.UserToken);
                        site.CatchAccessDeniedException = false;
                        if(site.ServerRelativeUrl != "/" && site.ServerRelativeUrl != "/home")
                        {
                            if(site.OpenWeb().DoesUserHavePermissions(SPBasePermissions.ViewListItems) && !arrSites.Contains(site.ID))
                            {
                                url = site.Url;

                                counter++;
                                writer.WriteLine("<tr><td class=\"ms-vb2\" style=\"padding-left:10px;\"> <img src=\"/_layouts/images/SharePointFoundation16.png\"><font class=\"ms-vb\"> <a class=\"ms-vb\" href=\"" + site.Url + "\" target=\"_blank\">" + site.RootWeb.Title + "</a> - " + site.RootWeb.Description + "</td></tr>");
                            }
                        }
                    }
                    catch { }
                }
                dr.Close();
            });
            cn.Close();

            //if(counter == 1 && url != "")
            //    Page.Response.Redirect(url);

            writer.WriteLine("</table>");

        }
    }
}
