using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using Izenda.AdHoc;

public partial class MasterPage1 : MasterPage
{
    public string sitecollectionid = "";
    protected override void OnInit(EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["sitecollectionid"]))
        {
            sitecollectionid = Request.QueryString["sitecollectionid"];

        }
        else if (Request.UrlReferrer.Query.Contains("sitecollectionid"))
        {
            sitecollectionid = Request.UrlReferrer.Query.Substring(Request.UrlReferrer.Query.IndexOf("=") + 1);

        }
        if (HttpContext.Current == null || HttpContext.Current.Session == null)
            return;
        Utility.CheckLimitations(true);
        HttpSessionState session = HttpContext.Current.Session;
        

        if (!String.IsNullOrEmpty(AdHocSettings.ApplicationHeaderImageUrl))
            rightLogo.Src = AdHocSettings.ApplicationHeaderImageUrl;
        if (!AdHocSettings.ShowDesignLinks)
        {
            string script = "<script type=\"text/javascript\" language=\"javascript\">";
            script += "try { $(document).ready(function() {$('.designer-only').hide(); });}catch(e){}";
            script += " try{ jq$(document).ready(function() {jq$('.designer-only').hide(); });}catch(e){} ";
            script += "</script>";
            Page.Header.Controls.Add(new LiteralControl(script));
        }
        AdHocSettings.ShowSettingsButtonForNonAdmins = false;


    }
}
