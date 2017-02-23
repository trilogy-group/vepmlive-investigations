using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.DirectoryServices;


namespace AdminSite
{
    public partial class edituser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
  
                ddlCountry.Attributes.Add("onchange", "javascript:checkCountry()");


                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                DataSet ds;
                SqlCommand cmdGetSites;
                SqlDataAdapter da;

                cmdGetSites = new SqlCommand("SELECT     * FROM         dbo.USERS WHERE dbo.Users.uid like '" + Request["uid"] + "'", cn);
                cmdGetSites.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);



                DataRow dr = ds.Tables[0].Rows[0];

                lblPassword.Text = dr["temppassword"].ToString();
                lblUsername.Text = dr["username"].ToString();
                txtEditEmail.Text = dr["email"].ToString();
                hdnEmail.Value = dr["email"].ToString();
                txtEditCompany.Text = dr["company"].ToString();
                txtEditDepartment.Text = dr["department"].ToString();
                txtEditFirstName.Text = dr["firstName"].ToString();
                hdnFirstName.Value = dr["firstName"].ToString();
                txtEditLastName.Text = dr["lastName"].ToString();
                hdnLastName.Value = dr["lastName"].ToString();
                txtEditPhone.Text = dr["phone"].ToString();
                txtEditTitle.Text = dr["title"].ToString();
                txtAddress1.Text = dr["Address1"].ToString();
                txtAddress2.Text = dr["Address1"].ToString();
                txtCity.Text = dr["city"].ToString();
                txtZip.Text = dr["zip"].ToString();
                txtAddress1.Text = dr["Address1"].ToString();
                ddlCountry.SelectedValue = dr["Country"].ToString();
                ddlState.SelectedValue = dr["State"].ToString();

                cmdGetSites = new SqlCommand("SELECT * from vwSitesIAmIn where uid='" + Request["uid"] + "'", cn);
                cmdGetSites.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);

                gvSites.DataSource = ds;
                gvSites.DataBind();

                cmdGetSites = new SqlCommand("SELECT * from vwUserAccounts where user_id='" + Request["uid"] + "'", cn);
                cmdGetSites.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);

                cn.Close();

                gvAccounts.DataSource = ds;
                gvAccounts.DataBind();

                cn.Close();
            }
        }

        private void fillGrid()
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                pnlEditFailure.Visible = false;

                if(hdnEmail.Value != txtEditEmail.Text || hdnFirstName.Value != txtEditFirstName.Text || hdnLastName.Value != txtEditLastName.Text)
                {

                    IdentityImpersonation identityImpersonate = new IdentityImpersonation();

                    if(identityImpersonate.impersonateValidUser())
                    {
                        DirectoryEntry entry = new DirectoryEntry();
                        entry.Path = System.Configuration.ConfigurationManager.AppSettings["LDAP"].ToString();

                        DirectorySearcher search = new DirectorySearcher(entry);
                        search.Filter = "(SAMAccountName=" + lblUsername.Text.Substring(lblUsername.Text.IndexOf('\\') + 1) + ")";

                        SearchResult result = search.FindOne();
                        DirectoryEntry user = new DirectoryEntry(result.Path);

                        user.Properties["displayname"].Value = txtEditFirstName.Text + " " + txtEditLastName.Text;
                        user.Properties["givenname"].Value = txtEditFirstName.Text;
                        user.Properties["mail"].Value = txtEditEmail.Text;
                        user.Properties["sn"].Value = txtEditLastName.Text;

                        user.CommitChanges();

                        identityImpersonate.undoImpersonation();
                    }
                    else
                    {
                        pnlEditFailure.Visible = true;

                        lblError.Text = "Unable to impersonate";

                        return;
                    }
                }

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                cn.Open();

                SqlCommand cmdUpdateUser;

                cmdUpdateUser = new SqlCommand("UPDATE USERS set firstName=@first, lastName=@last, company=@company, title=@title, department=@department,phone=@phone,email=@email,address1=@address1,address2=@address2,country=@country,state=@state,city=@city,zip=@zip WHERE uid like '" + Request["uid"] + "'", cn);
                cmdUpdateUser.CommandType = CommandType.Text;
                cmdUpdateUser.Parameters.AddWithValue("@first", txtEditFirstName.Text);
                cmdUpdateUser.Parameters.AddWithValue("@last", txtEditLastName.Text);
                cmdUpdateUser.Parameters.AddWithValue("@company", txtEditCompany.Text);
                cmdUpdateUser.Parameters.AddWithValue("@email", txtEditEmail.Text);
                cmdUpdateUser.Parameters.AddWithValue("@title", txtEditTitle.Text);
                cmdUpdateUser.Parameters.AddWithValue("@department", txtEditDepartment.Text);
                cmdUpdateUser.Parameters.AddWithValue("@phone", txtEditPhone.Text);

                cmdUpdateUser.Parameters.AddWithValue("@address1", txtAddress1.Text);
                cmdUpdateUser.Parameters.AddWithValue("@address2", txtAddress2.Text);
                cmdUpdateUser.Parameters.AddWithValue("@country", ddlCountry.SelectedValue);

                if(ddlCountry.SelectedValue == "US")
                    cmdUpdateUser.Parameters.AddWithValue("@state", ddlState.SelectedValue);
                else if(ddlCountry.SelectedValue == "CA")
                    cmdUpdateUser.Parameters.AddWithValue("@state", ddlProvince.SelectedValue);
                else
                    cmdUpdateUser.Parameters.AddWithValue("@state", DBNull.Value);

                cmdUpdateUser.Parameters.AddWithValue("@city", txtCity.Text);
                cmdUpdateUser.Parameters.AddWithValue("@zip", txtZip.Text);

                cmdUpdateUser.ExecuteNonQuery();

                cn.Close();

                pnlEditSuccess.Visible = true;
            }
            catch(Exception ex)
            {
                pnlEditFailure.Visible = true;
                lblError.Text = ex.Message.ToString() + "<br>" + ex.StackTrace;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void gvAccounts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "view")
            {
                Response.Redirect("editaccount.aspx?account_id=" + e.CommandArgument);
            }
        }
    }
}