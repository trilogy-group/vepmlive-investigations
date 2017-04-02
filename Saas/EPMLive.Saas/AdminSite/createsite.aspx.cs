using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class createsite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                cn.Open();

                SqlCommand cmd = new SqlCommand("SELECT firstname + ' ' + lastname as name, username, email, uid from users where epmliveadmin = 1 order by firstname", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    ddlUser.Items.Add(new ListItem(dr.GetString(0) + " (" + dr.GetString(2) + ")", dr.GetString(1) + "|" + dr.GetString(2) + "|" + dr.GetString(0) + "|" + dr.GetGuid(3).ToString()));
                }



                cn.Close();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                cn.Open();

                SqlCommand cmd = new SqlCommand("SELECT email from vwaccountinfo where account_id=@id", cn);
                cmd.Parameters.AddWithValue("@id", Request["account_id"]);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    string email = dr.GetString(0);
                    dr.Close();

                    accountsSvc.Service accts = new accountsSvc.Service();
                    accts.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["username"].ToString(), System.Configuration.ConfigurationManager.AppSettings["password"].ToString(), System.Configuration.ConfigurationManager.AppSettings["domain"].ToString());
                    string sError = "";
                    if(ddlUser.SelectedValue != "")
                    {
                        accts.createSiteAddUser(txtSiteName.Text, txtSiteUrl.Text, email, ddlTemplate.SelectedValue, ddlTemplate.SelectedValue, ddlUser.SelectedValue, out sError);
                        if(sError != "")
                        {
                            cmd = new SqlCommand("insert into account_users (user_id,account_id) VALUES (@user_id,@account_id)", cn);
                            cmd.Parameters.AddWithValue("@user_id", ddlUser.SelectedValue.Split('|')[3]);
                            cmd.Parameters.AddWithValue("@account_id", Request["account_id"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                        accts.createSite(txtSiteName.Text, txtSiteUrl.Text, email, ddlTemplate.SelectedValue, ddlTemplate.SelectedValue, out sError);

                    pnlProcess.Visible = true;
                    pnlInfo.Visible = false;

                    if(sError != "")
                    {
                        lblProcess.Text = sError;
                    }
                    else
                    {
                        lblProcess.Text = "Success";
                    }



                }

                cn.Close();

            }
            catch(Exception exception)
            {
                pnlProcess.Visible = true;
                pnlInfo.Visible = false;

                lblProcess.Text = "Exception: " + exception.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("editaccount.aspx?account_id=" + Request["account_id"] + "&tab=2");
        }
    }
}