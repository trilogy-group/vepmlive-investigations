using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using EPMLiveCore.Infrastructure.Logging;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    public partial class synchperiods : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            try
            {
                web.Site.CatchAccessDeniedException = false;
                web.AllowUnsafeUpdates = true;
                SPList list = web.Lists["EPMLivePeriods"];

                ArrayList arrPeriods = new ArrayList();
                foreach (SPListItem li in list.Items)
                {
                    arrPeriods.Add(li.Title);
                }

                string url = web.ServerRelativeUrl;

                //string[] periods = new string[arrPeriods.Count];
                //int counter = 0;
                //foreach (string p in arrPeriods)
                //{
                //    periods[counter++] = p;
                //}

                addWebPeriods(web, arrPeriods, web.Url);
            }
            catch { }
        }

        private void addWebPeriods(SPWeb web, ArrayList periods, string url)
        {
            try
            {
                web.AllowUnsafeUpdates = true;

                if (CoreFunctions.getConfigSetting(web, "EPMLiveTimePhasedURL").ToLower() == url.ToLower())
                {
                    SPList list = web.Lists["EPMLiveTimePhased"];
                    foreach (string period in periods)
                    {
                        try
                        {
                            SPField f = list.Fields.GetFieldByInternalName(period.Replace(" ", "_x0020_"));
                        }
                        catch
                        {
                            list.Fields.Add(period, SPFieldType.Number, false);
                        }
                    }

                    ArrayList arrDelFields = new ArrayList();

                    foreach (SPField f in list.Fields)
                    {
                        if (!f.Hidden && !f.Sealed && f.Type == SPFieldType.Number)
                        {
                            string fName = f.InternalName.Replace("_x0020_", " ");
                            if (!periods.Contains(fName))
                                arrDelFields.Add(fName);
                        }
                    }

                    foreach (string fName in arrDelFields)
                    {
                        list.Fields.GetFieldByInternalName(fName.Replace(" ", "_x0020_")).Delete();
                    }
                    //f.Delete();
                }
            }
            catch { }
            foreach (SPWeb w in web.Webs)
            {
                try
                {
                    addWebPeriods(w, periods, url);
                }
                catch(Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                finally { if (w != null) w.Dispose(); }
            }
        }

    }
}