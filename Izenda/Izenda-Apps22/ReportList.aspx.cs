public partial class ReportList : System.Web.UI.Page
{
    protected override void OnPreInit(System.EventArgs e)
    {
        string sitecollectionid = string.Empty;
        if (!string.IsNullOrEmpty(Request.QueryString["sitecollectionid"]))
        {
            sitecollectionid = Request.QueryString["sitecollectionid"];

        }
        else if (Request.UrlReferrer.Query.Contains("sitecollectionid"))
        {
            sitecollectionid = Request.UrlReferrer.Query.Substring(Request.UrlReferrer.Query.IndexOf("=") + 1);
            
        }
        ASP.global_asax.CustomAdHocConfig config = new ASP.global_asax.CustomAdHocConfig(sitecollectionid);
        config.InitializeReporting();
    }
}
