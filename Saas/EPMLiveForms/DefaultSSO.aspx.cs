using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Claims;
using Microsoft.SharePoint.Diagnostics;
using Microsoft.SharePoint.IdentityModel;
using Microsoft.SharePoint.IdentityModel.Pages;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class DefaultSSO : IdentityModelSignInPageBase
{

    protected override string LogPrefix {
        get {
            return "Claims Forms Sign-In: ";
        }
    }

    protected override string MobilePageUrl {
        get {
            int compatibilityLevel = this.SiteUrlCompatibilityLevel;
            string empty = string.Empty;
            SPContext context = SPContext.GetContext(HttpContext.Current);
            string str1 = SPRequestParameterUtility.GetValue<string>(this.Context.Request, "ReturnUrl");
            if (string.IsNullOrEmpty(str1))
                str1 = SPRequestParameterUtility.GetValue<string>(this.Context.Request, "Source");
            string str2;
            if (!string.IsNullOrEmpty(str1))
            {
                string str3 = "/";
                int length = str1.IndexOf("_layouts", StringComparison.OrdinalIgnoreCase);
                if (length > 0)
                    str3 = str1.Substring(0, length);
                str2 = str3 + GetLayoutsFolder(compatibilityLevel) + "/mobile/";
            }
            else
                str2 = context.Web == null ? "/" + GetLayoutsFolder(compatibilityLevel) + "/mobile/" : context.Web.Url + "/" + GetLayoutsFolder(compatibilityLevel) + "/mobile/";
            string components = HttpContext.Current.Request.Url.GetComponents(UriComponents.Query, UriFormat.SafeUnescaped);
            if (compatibilityLevel < 15)
                return str2 + "mbllogin.aspx" + (object)'?' + components;
            return str2 + "authn_form.aspx" + (object)'?' + components;
        }
    }
    internal static string GetLayoutsFolder(int compatibilityLevel)
    {
        string str = "_layouts";
        if (compatibilityLevel >= 15)
            str = str + "/" + (object)compatibilityLevel;
        return str;
    }
    protected virtual bool IsLoginControlInValidState(Login formsSignInControl)
    {
        if (formsSignInControl == null)
            throw new ArgumentNullException("formsSignInControl");
        bool flag1;
        bool flag2;
        if ((flag1 = string.IsNullOrEmpty(formsSignInControl.UserName)) || (flag1 = string.IsNullOrWhiteSpace(formsSignInControl.UserName.Trim())) || formsSignInControl.Password == null)
        {
            flag2 = false;
        }
        else
            flag2 = true;
        return flag2;
    }

    protected virtual SecurityToken GetSecurityToken(Login formsSignInControl)
    {
        if (formsSignInControl == null)
            throw new ArgumentNullException("formsSignInControl");
        SPIisSettings iisSettings = this.IisSettings;
        if (!iisSettings.UseClaimsAuthentication || !iisSettings.UseFormsClaimsAuthenticationProvider)
        {

            throw new InvalidOperationException();
        }
        SecurityToken securityToken;
        if (!this.IsLoginControlInValidState(formsSignInControl))
        {

            securityToken = (SecurityToken)null;
        }
        else
        {
            Uri appliesTo = this.AppliesTo;
            SPFormsAuthenticationProvider authenticationProvider = iisSettings.FormsClaimsAuthenticationProvider;
            string str = string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0}persistant security token for user '{1}' with membership provider '{2}' and role provider '{3}' with applies to '{4}' for request '{5}'.", formsSignInControl.RememberMeSet ? (object)string.Empty : (object)"non-", (object)formsSignInControl.UserName, (object)authenticationProvider.MembershipProvider, (object)authenticationProvider.RoleProvider, (object)appliesTo, (object)SPAlternateUrl.ContextUri);

            SPFormsAuthenticationOption options = SPFormsAuthenticationOption.None;
            if (formsSignInControl.RememberMeSet)
                options = SPFormsAuthenticationOption.PersistentSignInRequest;
            try
            {
                securityToken = SPSecurityContext.SecurityTokenForFormsAuthentication(appliesTo, authenticationProvider.MembershipProvider, authenticationProvider.RoleProvider, formsSignInControl.UserName, formsSignInControl.Password, options);

            }
            catch (Exception ex)
            {

                securityToken = (SecurityToken)null;
            }
        }
        return securityToken;
    }
    private SecurityToken GetSecurityToken(string username, string password, bool rememberMeSet)
    {

        SPIisSettings iisSettings = this.IisSettings;
        if (!iisSettings.UseClaimsAuthentication || !iisSettings.UseFormsClaimsAuthenticationProvider)
        {

            throw new InvalidOperationException();
        }
        SecurityToken securityToken;

        Uri appliesTo = this.AppliesTo;
        SPFormsAuthenticationProvider authenticationProvider = iisSettings.FormsClaimsAuthenticationProvider;
        string str = string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0}persistant security token for user '{1}' with membership provider '{2}' and role provider '{3}' with applies to '{4}' for request '{5}'.", rememberMeSet ? (object)string.Empty : (object)"non-", (object)username, (object)authenticationProvider.MembershipProvider, (object)authenticationProvider.RoleProvider, (object)appliesTo, (object)SPAlternateUrl.ContextUri);

        SPFormsAuthenticationOption options = SPFormsAuthenticationOption.None;
        if (rememberMeSet)
            options = SPFormsAuthenticationOption.PersistentSignInRequest;
        try
        {
            securityToken = SPSecurityContext.SecurityTokenForFormsAuthentication(appliesTo, authenticationProvider.MembershipProvider, authenticationProvider.RoleProvider, username, password, options);

        }
        catch (Exception ex)
        {

            securityToken = (SecurityToken)null;
        }

        return securityToken;
    }
    protected virtual SPSessionTokenWriteType GetSessionTokenWriteType(Login formsSignInControl)
    {
        if (formsSignInControl == null)
            throw new ArgumentNullException("formsSignInControl");
        SPSessionTokenWriteType sessionTokenWriteType = SPSessionTokenWriteType.WriteDefaultCookie;
        if (!SPSecurityTokenServiceManager.Local.UseSessionCookies && !formsSignInControl.RememberMeSet)
            sessionTokenWriteType = SPSessionTokenWriteType.WriteSessionCookie;
        return sessionTokenWriteType;
    }
    private SPSessionTokenWriteType GetSessionTokenWriteType(bool rememberMeSet)
    {

        SPSessionTokenWriteType sessionTokenWriteType = SPSessionTokenWriteType.WriteDefaultCookie;
        if (!SPSecurityTokenServiceManager.Local.UseSessionCookies && !rememberMeSet)
            sessionTokenWriteType = SPSessionTokenWriteType.WriteSessionCookie;
        return sessionTokenWriteType;
    }
    protected void AuthenticateEventHandler(object sender, AuthenticateEventArgs formAuthenticateEventArgs)
    {
        if (sender == null)
            throw new ArgumentNullException("sender");
        if (formAuthenticateEventArgs == null)
            throw new ArgumentNullException("formAuthenticateEventArgs");

        if (!IsLoginControlInValidState(signInControl) || !Membership.ValidateUser(signInControl.UserName, signInControl.Password))
        {
            formAuthenticateEventArgs.Authenticated = false;
            return;
        }
        ViewState["Username"] = signInControl.UserName;
        ViewState["Password"] = signInControl.Password;
        ViewState["Persist"] = signInControl.RememberMeSet;
        signInControl.Visible = false;
        tblSSO.Visible = true;
        InjectSSO();
    }
    private void InjectSSO()
    {

        string ssoString = (@"
            <script type='text/javascript' src='./easyXDM.min.js'>
            </script>
            <script type='text/javascript'>
            easyXDM.DomHelper.requiresJSON('./json2.js');
            var remote = new easyXDM.Rpc({
                local: './name.html',
                swf: 'REMOTE/Javascript/easyxdm.swf',
                remote: 'REMOTE/Logon.aspx',
                remoteHelper: 'REMOTE/Javascript/name.html'
            }, {
                remote: {
                    authenticateUser: {},
                    noOp: {}
                }
            });
            
            var loginUserName = 'USERNAME';
            var loginPassword = 'PASSWORD';
            remote.noOp();
            remote.authenticateUser(loginUserName, loginPassword, function(result){
                if (!result)
                {
                    " + btnFailure.ClientID + @".click();
                }
                else 
                {
                    " + btnSuccess.ClientID + @".click();
                }
            });
            </script>
            ").Replace("REMOTE", EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL")).Replace("USERNAME", signInControl.UserName).Replace("PASSWORD", signInControl.Password);

        ScriptManager.RegisterStartupScript(pnlUpdate, pnlUpdate.GetType(), "InitializeSSO", ssoString, false);
    }
    private void LoggingInEventHandler(object sender, LoginCancelEventArgs e)
    {
        Login login = sender as Login;
        if (login == null)
            throw new ArgumentException((string)null, "sender");

        login.UserName = login.UserName.Trim();
        if (login.UserName.Length > 249)
        {

            e.Cancel = true;
        }
        else if (string.IsNullOrEmpty(login.UserName))
        {

            e.Cancel = true;
        }
        else
        { }
    }

    protected virtual void LogSignInSuccess()
    {
    }

    protected virtual void LogSignInFailure()
    {
    }

    protected override void OnInit(EventArgs eventArgs)
    {
        try
        {
            this.SetThreadCultureFromRequestedWeb();
        }
        catch (Exception ex)
        {

        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        this.ClaimsFormsPageTitle.Text = SPHttpUtility.NoEncode((string)HttpContext.GetGlobalResourceObject("wss", "login_pagetitle", Thread.CurrentThread.CurrentUICulture));
        if (this.ClaimsFormsPageTitleInTitleArea != null)
            this.ClaimsFormsPageTitleInTitleArea.Text = SPHttpUtility.NoEncode((string)HttpContext.GetGlobalResourceObject("wss", "login_pagetitle", Thread.CurrentThread.CurrentUICulture));
        this.ClaimsFormsPageMessage.Text = SPHttpUtility.NoEncode((string)HttpContext.GetGlobalResourceObject("wss", "SSL_warning", Thread.CurrentThread.CurrentUICulture));
        this.signInControl.Focus();
        this.signInControl.LoggingIn += new LoginCancelEventHandler(this.LoggingInEventHandler);
        this.signInControl.Authenticate += new AuthenticateEventHandler(this.AuthenticateEventHandler);
        CheckBox control;
        if (!SPSecurityTokenServiceManager.Local.UseSessionCookies || (control = this.signInControl.FindControl("RememberMe") as CheckBox) == null)
            return;
        control.Enabled = false;
        control.Visible = false;
    }

    protected void btnSuccess_Click(object sender, EventArgs e)
    {
        bool flag = false;
        string username = (string)ViewState["Username"];
        string password = (string)ViewState["Password"];
        bool rememberMeSet = (bool)ViewState["Persist"];
        using (new SPMonitoredScope("FormsSignInPage.AuthenticateEventHandler: Retrieve security token and establish session."))
        {
            try
            {
                SecurityToken securityToken;
                if ((securityToken = this.GetSecurityToken(username, password, rememberMeSet)) == null)
                {

                    flag = false;
                }
                else
                {
                    try
                    {
                        SPSessionTokenWriteType sessionTokenWriteType = this.GetSessionTokenWriteType(rememberMeSet);
                        this.EstablishSessionWithToken(securityToken, sessionTokenWriteType);

                        flag = true;
                    }
                    catch (Exception)
                    {

                        flag = false;
                    }
                }
            }
            finally
            {
                if (flag)
                    this.LogSignInSuccess();
                else
                    this.LogSignInFailure();
            }
        }
        if (!flag)
            return;
        FormsAuthentication.RedirectFromLoginPage(username, rememberMeSet);
    }

    protected void btnFailure_Click(object sender, EventArgs e)
    {
        signInControl.Visible = true;
        tblSSO.Visible = false;
        ScriptManager.RegisterStartupScript(pnlUpdate, pnlUpdate.GetType(), "Reset Submit Button", "clickedit = false;", true);
    }
}