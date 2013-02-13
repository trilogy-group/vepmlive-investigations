using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EPMLiveCore.Layouts.EPMLiveCore
{
    public partial class emailmanager : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmails.Visible = false;

            pnlEdit.Visible = true;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {

                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(WebApplicationSelector1.CurrentItem.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select subject,body from emailtemplates where emailid = @emailid", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@emailid", gvEmails.Rows[e.NewEditIndex].Cells[0].Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    hdnId.Value = gvEmails.Rows[e.NewEditIndex].Cells[0].Text;

                    if(dr.Read())
                    {
                        txtSubject.Text = dr.GetString(0);
                        txtBody.Text = dr.GetString(1);
                    }
                    dr.Close();

                    cn.Close();
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            });
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {

                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(WebApplicationSelector1.CurrentItem.Id));
                    cn.Open();


                    SqlCommand cmd = new SqlCommand("update emailtemplates set subject=@subject, body=@body where emailid=@emailid", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
                    cmd.Parameters.AddWithValue("@body", txtBody.Text);
                    cmd.Parameters.AddWithValue("@emailid", hdnId.Value);

                    cmd.ExecuteNonQuery();

                    cn.Close();

                    Response.Redirect("emailmanager.aspx");
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            });

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("emailmanager.aspx");
        }

        protected void WebApplicationSelector1_ContextChange(object sender, EventArgs e)
        {
            loadTemplates();
        }

        private void loadTemplates()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {

                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(WebApplicationSelector1.CurrentItem.Id));
                    cn.Open();

                    DataSet ds;
                    SqlCommand cmdGetSites;
                    SqlDataAdapter da;

                    cmdGetSites = new SqlCommand("select emailid,title,subject from emailtemplates order by emailid", cn);
                    cmdGetSites.CommandType = CommandType.Text;

                    da = new SqlDataAdapter(cmdGetSites);
                    ds = new DataSet();
                    da.Fill(ds);

                    gvEmails.DataSource = ds.Tables[0];
                    gvEmails.DataBind();

                    cn.Close();
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            });
        }
    }
}
