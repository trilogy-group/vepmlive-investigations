public partial class ReportViewer : System.Web.UI.Page {
  protected override void OnPreInit(System.EventArgs e) {
        if (!string.IsNullOrEmpty(Request.QueryString["sitecollectionurl"]))
        {
            ASP.global_asax.CustomAdHocConfig.sitecollectionname = Request.QueryString["sitecollectionurl"];
        }
        ASP.global_asax.CustomAdHocConfig.InitializeReporting();
  }
}

