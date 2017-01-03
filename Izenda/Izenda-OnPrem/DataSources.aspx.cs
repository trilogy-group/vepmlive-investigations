using System;
using System.Configuration;
using ASP;
using Izenda.AdHoc;

public partial class DataSources : System.Web.UI.Page
{
  protected void Page_PreInit(object sender, EventArgs e)
  {
    string lk = ConfigurationManager.AppSettings["IzendaLicenseKey"];
    string cs = ConfigurationManager.AppSettings["ConnectionString"];
    if (lk == null || lk.ToLower().StartsWith("insert_") || cs == null || cs.ToLower().StartsWith("insert_")) {
      if (!Request.Url.ToString().ToLower().Contains("settings.aspx")) {
        Response.Redirect("Settings.aspx");
        return;
      }
    }
    if (lk != null && !lk.ToLower().StartsWith("insert_") && cs != null && !cs.ToLower().StartsWith("insert_"))
      global_asax.CustomAdHocConfig.InitializeReporting(Session);
    if (Request.Url.ToString().ToLower().Contains("reportlist.aspx")) {
      ReportInfo[] ri = AdHocSettings.AdHocConfig.ListReports();
      if (ri.Length <= 0)
        Response.Redirect("ReportDesigner.aspx");
      return;
    }
  }

}