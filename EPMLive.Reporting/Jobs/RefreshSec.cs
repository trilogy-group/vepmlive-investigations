using EPMLiveCore.API;
using Microsoft.SharePoint;
using EPMLiveCore.ReportHelper;

namespace EPMLiveReportsAdmin.Jobs
{
    public class RefreshSec : BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            EPMData epmdata = null;
            try
            {
                epmdata = new EPMData(site.ID);

                ProcessSecurity.ProcessSecurityGroups(site, epmdata.GetClientReportingConnection, data);
            }
            catch { }
            finally
            {
                if (epmdata != null)
                    epmdata.Dispose();
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }
    }
}