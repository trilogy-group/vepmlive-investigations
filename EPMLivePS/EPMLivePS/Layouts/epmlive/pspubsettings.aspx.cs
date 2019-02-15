using System;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

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
                    using (var connection = new SqlConnection(
                        EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id)))
                    {
                        connection.Open();

                        using (var command = new SqlCommand(
                            "select pubType,weburl from publishercheck where projectguid=@projectguid",
                            connection))
                        {
                            command.Parameters.AddWithValue("@projectguid", Request["ProjectUid"]);
                            using (var reader = command.ExecuteReader())
                            {
                                ddlPubType.SelectedValue = reader.Read()
                                    ? reader.GetInt32(0).ToString()
                                    : EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLivePub-Type");
                            }
                        }
                    }

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
                using (var connection =
                    new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id)))
                {
                    connection.Open();

                    bool read;
                    using (var command = new SqlCommand(
                            "select pubType,weburl from publishercheck where projectguid=@projectguid",
                            connection))
                    {
                        command.Parameters.AddWithValue("@projectguid", Request["ProjectUid"]);
                        using (var reader = command.ExecuteReader())
                        {
                            read = reader.Read();
                        }
                    }

                    if (read)
                    {
                        using (var command = new SqlCommand(
                            "UPDATE publishercheck set pubtype=@pubtype where projectguid=@projectguid",
                            connection))
                        {
                            command.Parameters.AddWithValue("@projectguid", Request["ProjectUid"]);
                            command.Parameters.AddWithValue("@pubtype", ddlPubType.SelectedValue);
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (var command = new SqlCommand(
                            "INSERT INTO publishercheck (projectguid,checkbit,pubType,weburl, projectname) " +
                            "VALUES (@projectguid,1,@pubtype,@weburl,@projectname)",
                            connection))
                        {
                            command.Parameters.AddWithValue("@projectguid", Request["ProjectUid"]);
                            command.Parameters.AddWithValue("@pubtype", ddlPubType.SelectedValue);
                            command.Parameters.AddWithValue("@weburl", "");
                            command.Parameters.AddWithValue("@projectname", Request["ProjName"]);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            });

            btnCancel_Click(sender, e);
        }

        
    }
}
