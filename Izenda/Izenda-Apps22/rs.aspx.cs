public partial class rs : Izenda.AdHoc.ResponseServer
{
    protected override void OnPreInit(System.EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["sitecollectiontitle"]))
        {
            ASP.global_asax.CustomAdHocConfig.sitecollectionname = Request.QueryString["sitecollectiontitle"];
        }
        ASP.global_asax.CustomAdHocConfig.InitializeReporting();
    }

    override protected void OnInit(System.EventArgs e)
    {
        if (System.Web.HttpContext.Current.Request.RawUrl.Contains("rs.aspx?copy="))
            System.Web.HttpContext.Current.Response.End();
    }
}
