public partial class ReportViewer : System.Web.UI.Page {
  protected override void OnPreInit(System.EventArgs e) {
        ASP.global_asax.CustomAdHocConfig customAdHocConfig = new ASP.global_asax.CustomAdHocConfig();
        customAdHocConfig.InitializeReporting();
    }
}

