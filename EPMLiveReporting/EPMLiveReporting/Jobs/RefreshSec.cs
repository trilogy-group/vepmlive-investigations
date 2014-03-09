using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin.Jobs
{
    public class RefreshSec : BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            try
            {
                var epmdata = new EPMData(site.ID);

                ProcessSecurity.ProcessSecurityGroups(site, epmdata.GetClientReportingConnection, data);
            }
            catch { }
        }
    }
}