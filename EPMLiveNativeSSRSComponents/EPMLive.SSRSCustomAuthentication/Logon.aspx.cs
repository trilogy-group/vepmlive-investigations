using EPMLive.SSRSCustomAuthentication.AuthenticationProvider;
using System;
using System.Web.Security;
using System.Web.UI;

namespace EPMLive.SSRSCustomAuthentication
{
    public partial class Logon : Page
    {
        IAuthenticationProvider authenticationProvider;

        public Logon()
        {
            authenticationProvider = new ADAuthenticationProvider();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text.Trim();
            var password = txtPassword.Text.Trim();
            var error = string.Empty;

            var passwordVerified = authenticationProvider.VerifyPassword(userName, password, out error);

            if (passwordVerified)
            {
                FormsAuthentication.RedirectFromLoginPage(userName, false);
            }            
            else
            {
                pnlError.Visible = true;
                txtPassword.Text = "";
                txtUserName.Text = "";
            }
        }
    }
}