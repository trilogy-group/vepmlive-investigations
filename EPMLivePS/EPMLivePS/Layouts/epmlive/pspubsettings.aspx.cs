using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EPMLiveEnterprise.Layouts.epmlive
{
    public partial class pspubsettings : LayoutsPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SPSite site = SPContext.Current.Site;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select pubType,weburl from publishercheck where projectguid=@projectguid", cn);
                    cmd.Parameters.AddWithValue("@projectguid", Request["ProjectUid"]);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        ddlPubType.SelectedValue = dr.GetInt32(0).ToString();
                    }
                    else
                    {
                        ddlPubType.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLivePub-Type");
                    }

                    dr.Close();

                    cn.Close();

                    try
                    {
                        string[] locks = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "epmlivepub-lock").Split(',');
                        if (locks[0] == "1")
                        {
                            ddlPubType.Enabled = false;
                            ddlPubType.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLivePub-Type");
                        }
                    }
                    catch { }
                    
                });
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "close", "<script language=\"javascript\">SP.UI.ModalDialog.commonModalDialogClose();</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                cn.Open();

                SqlCommand cmd = new SqlCommand("select pubType,weburl from publishercheck where projectguid=@projectguid", cn);
                cmd.Parameters.AddWithValue("@projectguid", Request["ProjectUid"]);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();

                    cmd = new SqlCommand("UPDATE publishercheck set pubtype=@pubtype where projectguid=@projectguid", cn);
                    cmd.Parameters.AddWithValue("@projectguid", Request["ProjectUid"]);
                    cmd.Parameters.AddWithValue("@pubtype", ddlPubType.SelectedValue);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    dr.Close();
                    cmd = new SqlCommand("INSERT INTO publishercheck (projectguid,checkbit,pubType,weburl, projectname) VALUES (@projectguid,1,@pubtype,@weburl,@projectname)", cn);
                    cmd.Parameters.AddWithValue("@projectguid", Request["ProjectUid"]);
                    cmd.Parameters.AddWithValue("@pubtype", ddlPubType.SelectedValue);
                    cmd.Parameters.AddWithValue("@weburl", "");
                    cmd.Parameters.AddWithValue("@projectname", Request["ProjName"]);
                    cmd.ExecuteNonQuery();
                }

                cn.Close();
            });

            btnCancel_Click(sender, e);
        }

        
    }
}
