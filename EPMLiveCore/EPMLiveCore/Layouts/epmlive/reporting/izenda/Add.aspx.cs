using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EPMLiveCore.Layouts.epmlive.reporting.izenda
{
    public partial class Add : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            bool bFound = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id));
                cn.Open();
                string newname = txtName.Text;
                if (txtCategory.Text != "")
                    newname = txtCategory.Text + "\\" + newname;


                SqlCommand cmd = new SqlCommand("SELECT * FROM IzendaAdHocReports where TenantID=@siteid and name=@name", cn);
                cmd.Parameters.AddWithValue("@siteid", Web.Site.ID);
                cmd.Parameters.AddWithValue("@name", newname);
                SqlDataReader dr = cmd.ExecuteReader();

                

                if (dr.Read())
                    bFound = true;

                dr.Close();

                if (!bFound)
                {
                    cmd = new SqlCommand("INSERT INTO IzendaAdHocReports (Name,TenantID,CreatedDate,ModifiedDate,Xml) VALUES (@name,@siteid,GETDATE(),GETDATE(),@xml)", cn);
                    cmd.Parameters.AddWithValue("@siteid", Web.Site.ID);
                    cmd.Parameters.AddWithValue("@name", newname);
                    cmd.Parameters.AddWithValue("@xml", txtXml.Text);
                    cmd.ExecuteNonQuery();
                }
                else
                {

                }
                cn.Close();
            });

            if(!bFound)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/reporting/izenda/manage.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);

        }
    }
}
