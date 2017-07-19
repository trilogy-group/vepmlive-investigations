public partial class ReportDesigner : System.Web.UI.Page {
  protected override void OnPreInit(System.EventArgs e) {
        string sitecollectiontitle = string.Empty;
        if (!string.IsNullOrEmpty(Request.QueryString["sitecollectiontitle"]))
        {
            sitecollectiontitle = Request.QueryString["sitecollectiontitle"];

        }
        ASP.global_asax.CustomAdHocConfig config = new ASP.global_asax.CustomAdHocConfig(sitecollectiontitle);
        config.InitializeReporting();
    }
}
