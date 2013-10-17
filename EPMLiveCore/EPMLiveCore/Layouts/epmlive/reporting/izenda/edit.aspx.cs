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
                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT Xml FROM IzendaAdHocReports where TenantID=@siteid and name=@name", cn);
                    cmd.Parameters.AddWithValue("@siteid", Web.ID);
                    cmd.Parameters.AddWithValue("@name", hdnFullName.Value);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        if (hdnFullName.Value.Contains("\\"))
                        {
                            string[] sName = hdnFullName.Value.Split('\\');
                            txtName.Text = sName[1];
                            txtCategory.Text = sName[0];
                        }
                        else
                        {
                            txtName.Text = hdnFullName.Value;
                        }
                        txtXml.Text = dr.GetString(0);
                    }

                    cn.Close();
                });
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id));
                cn.Open();
                string newname = txtName.Text;
                if (txtCategory.Text != "")
                    newname = txtCategory.Text + "\\" + newname;

                SqlCommand cmd = new SqlCommand("UPDATE IzendaAdHocReports set Name=@newname, xml=@xml,ModifiedDate=GETDATE() where TenantID=@siteid and name=@name", cn);
                cmd.Parameters.AddWithValue("@siteid", Web.ID);
                cmd.Parameters.AddWithValue("@name", hdnFullName.Value);
                cmd.Parameters.AddWithValue("@xml", txtXml.Text);
                cmd.Parameters.AddWithValue("@newname", newname);

                cmd.ExecuteNonQuery();

                cn.Close();
            });
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/reporting/izenda/manage.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/reporting/izenda/manage.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
        }
    }
}
