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

                    using (var connection = new SqlConnection(CoreFunctions.getConnectionString(WebApplicationSelector1.CurrentItem.Id)))
                    {
                        connection.Open();

                        using (var cmd = new SqlCommand("select subject,body from emailtemplates where emailid = @emailid", connection))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@emailid", gvEmails.Rows[e.NewEditIndex].Cells[0].Text);
                            using (var dataReader = cmd.ExecuteReader())
                            {
                                hdnId.Value = gvEmails.Rows[e.NewEditIndex].Cells[0].Text;

                                if (dataReader.Read())
                                {
                                    txtSubject.Text = dataReader.GetString(0);
                                    txtBody.Text = dataReader.GetString(1);
                                }
                            }
                        }
                    }
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

                    using (var connection = new SqlConnection(CoreFunctions.getConnectionString(WebApplicationSelector1.CurrentItem.Id)))
                    {
                        connection.Open();


                        using (var cmd = new SqlCommand("update emailtemplates set subject=@subject, body=@body where emailid=@emailid", connection))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
                            cmd.Parameters.AddWithValue("@body", txtBody.Text);
                            cmd.Parameters.AddWithValue("@emailid", hdnId.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }

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

                    using (var connection = new SqlConnection(CoreFunctions.getConnectionString(WebApplicationSelector1.CurrentItem.Id)))
                    {
                        connection.Open();

                        using (var cmdGetSites = new SqlCommand("select emailid,title,subject from emailtemplates order by emailid", connection))
                        {
                            cmdGetSites.CommandType = CommandType.Text;

                            using (var adapter = new SqlDataAdapter(cmdGetSites))
                            {
                                var dataSet = new DataSet();
                                adapter.Fill(dataSet);

                                gvEmails.DataSource = dataSet.Tables[0];
                                gvEmails.DataBind();
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            });
        }
    }
}
