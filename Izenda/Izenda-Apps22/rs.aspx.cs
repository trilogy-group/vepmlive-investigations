public partial class rs : Izenda.AdHoc.ResponseServer
{
    protected override void OnPreInit(System.EventArgs e)
    {
        string sitecollectiontitle = string.Empty;
        if (!string.IsNullOrEmpty(Request.QueryString["sitecollectiontitle"]))
        {
            sitecollectiontitle = Request.QueryString["sitecollectiontitle"];

        }
        ASP.global_asax.CustomAdHocConfig config = new ASP.global_asax.CustomAdHocConfig(sitecollectiontitle);
        config.InitializeReporting();
    }

    override protected void OnInit(System.EventArgs e)
    {
        if (System.Web.HttpContext.Current.Request.RawUrl.Contains("rs.aspx?copy="))
            System.Web.HttpContext.Current.Response.End();
    }
}
