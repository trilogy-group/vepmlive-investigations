using System;
using System.Web;
using System.Web.UI;

namespace EPMLiveWebParts
{
    public partial class VfData : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisablePageCaching();

            var trace = false;
            if (Request["Trace"] != null)
                trace = true;

            var chart = new EpmChart(Request);

            chart.DataBindChart();

            Response.Clear();
            
            if(trace)
                Response.Write(chart.TraceOutput);

            Response.Write(chart.GetXaml());
        }

        private void DisablePageCaching()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "no-cache");
            Response.Cache.SetNoStore();
        }
    }
}