using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts
{
    public partial class UpdateWebPart : System.Web.UI.Page
    {
        protected string data;

        private string sChartTitle { get; set; }
        private string sChartType { get; set; }
        private string sPropChartSelectedPaletteName { get; set; }
        private string sPropChartSelectedListAndViewName { get; set; }
        private string sPropChartSelectedViewTitle { get; set; }
        private string sPropChartSelectedListTitle { get; set; }
        private string sPropChartXaxisField { get; set; }
        private string sPropChartXaxisFieldLabel { get; set; }
        private string sPropChartYaxisField { get; set; }
        private string sPropChartYaxisFieldLabel { get; set; }
        private string sPropChartZaxisField { get; set; }
        private string sPropChartZaxisFieldLabel { get; set; }
        private string sPropBubbleChartGroupBy { get; set; }
        private string sPropYaxisFormat { get; set; }
        private string sPropLegendPosition { get; set; }
        private string sPropChartShowSeriesLabels { get; set; }
        private string sPropChartShowLegend { get; set; }
        private string sPropChartShowGridlines { get; set; }
        private string sPropChartAggregationType { get; set; }
        private string sWpPagePath { get; set; }
        private string sWpId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetParams();
            try
            {
                SaveChartProperties();
                data = "Success";
            }
            catch (Exception ex)
            {
                data = "Failed. Error Message : " + ex.Message;
            }
        }

        private void SaveChartProperties()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite SiteCollection = new SPSite(sWpPagePath))
                {
                    // get the web in this context
                    using (SPWeb myWeb = SiteCollection.OpenWeb())
                    {
                        myWeb.AllowUnsafeUpdates = true;
                        string path = string.Empty;
                        path = sWpPagePath.Replace(myWeb.Url + "/", "");
                        SPFile page = myWeb.GetFile(path);
                        // Hide/display another webpart.
                        Microsoft.SharePoint.WebPartPages.SPLimitedWebPartManager mgr = null;

                        mgr = page.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                        foreach (System.Web.UI.WebControls.WebParts.WebPart myWebPart in mgr.WebParts)
                        {
                            // If this is the webpart we want to modify...
                            if (myWebPart.ID == sWpId)
                            {
                                // Change Properties
                                ReportingChart.ReportingChart rc = (ReportingChart.ReportingChart)myWebPart;

                                // save properties
                                rc.PropChartSelectedListTitle = sPropChartSelectedListTitle;
                                rc.PropChartSelectedViewTitle = sPropChartSelectedViewTitle;
                                rc.PropChartType = (ReportingChart.ChartType)Enum.Parse(typeof(ReportingChart.ChartType), sChartType);
                                rc.PropChartAggregationType = sPropChartAggregationType;
                                rc.PropChartXaxisField = sPropChartXaxisField;
                                rc.PropChartYaxisField = sPropChartYaxisField;
                                rc.PropYaxisFormat = sPropYaxisFormat;
                                rc.PropChartZaxisField = sPropChartZaxisField;
                                rc.PropBubbleChartGroupBy = sPropBubbleChartGroupBy;

                                rc.PropChartTitle = sChartTitle;
                                rc.PropChartSelectedPaletteName = sPropChartSelectedPaletteName;
                                rc.PropChartShowSeriesLabels = bool.Parse(sPropChartShowSeriesLabels);
                                rc.PropChartShowGridlines = bool.Parse(sPropChartShowGridlines);
                                rc.PropChartShowLegend = bool.Parse(sPropChartShowLegend);
                                rc.PropChartLegendPosition = sPropLegendPosition;
                                mgr.SaveChanges(myWebPart);
                                break;
                            }
                        }
                    }
                }
            });
        }

        private void GetParams()
        {
            try
            {
                sChartTitle = Request["sChartTitle"];
            }
            catch { }

            try
            {
                sChartType = Request["sChartType"];
            }
            catch { }

            try
            {
                sPropChartSelectedPaletteName = Request["sPropChartSelectedPaletteName"];
            }
            catch { }

            try
            {
                sPropChartSelectedListAndViewName = Request["sPropChartSelectedListAndViewName"];
            }
            catch { }

            try
            {
                sPropChartSelectedViewTitle = Request["sPropChartSelectedViewTitle"];
            }
            catch { }

            try
            {
                sPropChartSelectedListTitle = Request["sPropChartSelectedListTitle"];
            }
            catch { }

            try
            {
                sPropChartXaxisField = Request["sPropChartXaxisField"];
            }
            catch { }

            try
            {
                sPropChartXaxisFieldLabel = Request["sPropChartXaxisFieldLabel"];
            }
            catch { }

            try
            {
                sPropChartYaxisField = Request["sPropChartYaxisField"];
            }
            catch { }

            try
            {
                sPropChartYaxisFieldLabel = Request["sPropChartYaxisFieldLabel"];
            }
            catch { }

            try
            {
                sPropChartZaxisField = Request["sPropChartZaxisField"];
            }
            catch { }

            try
            {
                sPropChartZaxisFieldLabel = Request["sPropChartZaxisFieldLabel"];
            }
            catch { }

            try
            {
                sPropBubbleChartGroupBy = Request["sPropBubbleChartGroupBy"];
            }
            catch { }

            try
            {
                sPropYaxisFormat = Request["sPropYaxisFormat"];
            }
            catch { }

            try
            {
                sPropLegendPosition = Request["sPropLegendPosition"];
            }
            catch { }

            try
            {
                sPropChartShowSeriesLabels = Request["sPropChartShowSeriesLabels"];
            }
            catch { }

            try
            {
                sPropChartShowLegend = Request["sPropChartShowLegend"];
            }
            catch { }

            try
            {
                sPropChartShowGridlines = Request["sPropChartShowGridlines"];
            }
            catch { }

            try
            {
                sPropChartAggregationType = Request["sPropChartAggregationType"];
            }
            catch { }

            try
            {
                sWpPagePath = Request["sWpPagePath"];
            }
            catch { }

            try
            {
                sWpId = Request["sWpId"];
            }
            catch { }
        }

    }
}
