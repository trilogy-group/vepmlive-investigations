public partial class rs : Izenda.AdHoc.ResponseServer
{
  protected override void OnPreInit(System.EventArgs e)
  {
        ASP.global_asax.CustomAdHocConfig customAdHocConfig = new ASP.global_asax.CustomAdHocConfig();
        customAdHocConfig.InitializeReporting();
    }

  override protected void OnInit(System.EventArgs e)
  {
    if (System.Web.HttpContext.Current.Request.RawUrl.Contains("rs.aspx?copy="))
      System.Web.HttpContext.Current.Response.End();
  }
}
