using System;
using System.Data;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class editpersonal : LayoutsPageBase
    {

        protected string strState;

        protected void Page_Load(object sender, EventArgs e)
        {

            string username = EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName);
            SPUser user = SPContext.Current.Web.CurrentUser;

            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();

                SqlCommand cmd = new SqlCommand("select * from users where username like @username", cn);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFirstName.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["address1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["address2"].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0]["city"].ToString();
                    txtZip.Text = ds.Tables[0].Rows[0]["zip"].ToString();
                    xregion.Text = ds.Tables[0].Rows[0]["region"].ToString();
                    strState = ds.Tables[0].Rows[0]["state"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                    txtFax.Text = ds.Tables[0].Rows[0]["fax"].ToString();
                    hdnCountry.Value = ds.Tables[0].Rows[0]["country"].ToString();
                }

                cn.Close();

                Page.RegisterStartupScript("postit", "<script language=\"javascript\">elementchange();</script>");
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            
            ServicePointManager.ServerCertificateValidationCallback += delegate(object ssender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };

            string username = EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName);

            SPUser user = SPContext.Current.Web.CurrentUser;

            SqlConnection cn = new SqlConnection(Settings.getConnectionString());
            cn.Open();

            string sql = "UPDATE [users] set phone=@phone, fax=@fax, address1=@address1, address2=@address2, ";
            sql = sql + "city=@city, state=@state, zip=@zip, country=@country, region=@region, firstname=@firstname, lastname=@lastname where [username] like @username";
            SqlCommand cmd = new SqlCommand(sql, cn);

            string state = "";
            string country = "";
            string region = "";
            try
            {
                state = Request["State"].ToString();
            }
            catch { };
            try
            {
                country = Request["MSCountry"].ToString();
            }
            catch { };
            try
            {
                region = Request["Region"].ToString();
            }
            catch { };

            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@address1", txtAddress1.Text);
            cmd.Parameters.AddWithValue("@address2", txtAddress2.Text);
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@zip", txtZip.Text);
            cmd.Parameters.AddWithValue("@country", country);
            cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
            cmd.Parameters.AddWithValue("@region", xregion.Text);
            cmd.Parameters.AddWithValue("@fax", txtFax.Text);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.ExecuteNonQuery();

            cn.Close();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                accounts.Service accts = new accounts.Service();
                accts.UseDefaultCredentials = true;
                accts.changeName(txtFirstName.Text, txtLastName.Text);
            });

            user.Name = txtFirstName.Text + " " + txtLastName.Text;
            user.Update();

            Page.RegisterStartupScript("postit", "<script language=\"javascript\">close();</script>");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.RegisterStartupScript("postit", "<script language=\"javascript\">close();</script>");
        }
    }
}
