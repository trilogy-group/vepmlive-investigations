using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EPMLiveCore.Layouts.epmlive.reporting.izenda
{
    public partial class edit : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnFullName.Value = Request["name"];

            if (!IsPostBack)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id)))
                    {
                        sqlConnection.Open();

                        using (var sqlCommand = new SqlCommand(
                            "SELECT Xml FROM IzendaAdHocReports where TenantID=@siteid and name=@name",
                            sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@siteid", Web.ID);
                            sqlCommand.Parameters.AddWithValue("@name", hdnFullName.Value);

                            using (var dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    if (hdnFullName.Value.Contains("\\"))
                                    {
                                        var sName = hdnFullName.Value.Split('\\');
                                        txtName.Text = sName[1];
                                        txtCategory.Text = sName[0];
                                    }
                                    else
                                    {
                                        txtName.Text = hdnFullName.Value;
                                    }
                                    txtXml.Text = dataReader.GetString(0);
                                }
                            }
                        }
                    }
                });
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id)))
                {
                    sqlConnection.Open();
                    var newName = txtName.Text;
                    if (txtCategory.Text != "")
                    {
                        newName = string.Format("{0}\\{1}", txtCategory.Text, newName);
                    }

                    var sqlCommand = new SqlCommand(
                        "UPDATE IzendaAdHocReports set Name=@newname, xml=@xml,ModifiedDate=GETDATE() where TenantID=@siteid and name=@name",
                        sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@siteid", Web.ID);
                    sqlCommand.Parameters.AddWithValue("@name", hdnFullName.Value);
                    sqlCommand.Parameters.AddWithValue("@xml", txtXml.Text);
                    sqlCommand.Parameters.AddWithValue("@newname", newName);

                    sqlCommand.ExecuteNonQuery();
                }
            });
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/reporting/izenda/manage.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/reporting/izenda/manage.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
        }
    }
}
