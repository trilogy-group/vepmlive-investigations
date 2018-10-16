using System;
using System.Data.SqlClient;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive.reporting.izenda
{
    public partial class Add : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var bFound = false;
            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id)))
                    {
                        sqlConnection.Open();
                        var nameText = txtName.Text;

                        if (!string.IsNullOrWhiteSpace(txtCategory.Text))
                        {
                            nameText = $"{txtCategory.Text}\\{nameText}";
                        }

                        using (var sqlCommand = new SqlCommand("SELECT * FROM IzendaAdHocReports where TenantID=@siteid and name=@name", sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@siteid", Web.ID);
                            sqlCommand.Parameters.AddWithValue("@name", nameText);

                            using (var dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    bFound = true;
                                }
                            }
                        }

                        if (!bFound)
                        {
                            using (var sqlCommand = new SqlCommand(
                                "INSERT INTO IzendaAdHocReports (Name,TenantID,CreatedDate,ModifiedDate,Xml) VALUES (@name,@siteid,GETDATE(),GETDATE(),@xml)",
                                sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@siteid", Web.ID.ToString().ToLower());
                                sqlCommand.Parameters.AddWithValue("@name", nameText);
                                sqlCommand.Parameters.AddWithValue("@xml", txtXml.Text);
                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }
                });

            if (!bFound)
            {
                SPUtility.Redirect("epmlive/reporting/izenda/manage.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/reporting/izenda/manage.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
        }
    }
}
