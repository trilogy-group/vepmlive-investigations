using System.Data;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using System.Text;

namespace EPMLiveReportsAdmin.Jobs
{
    public class SnapshotJob : BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            EPMData epmdata = null;
            DataTable dt = null;
            StringBuilder sbErrors = null;
            try
            {
                sbErrors = new StringBuilder();
                epmdata = new EPMData(site.ID);

                epmdata.SnapshotLists(base.JobUid, site.ID, data);

                dt = epmdata.GetSnapshotResults(base.JobUid);

                foreach (DataRow dr in dt.Rows)
                {
                    sbErrors.Append("Processing List (" + dr["ListName"] + ")");
                    if (dr["level"].ToString() == "2")
                    {
                        sbErrors.Append(" Failed: " + dr["ShortMessage"]);
                        bErrors = true;
                    }
                    else
                        sbErrors.Append(" Success");

                    sbErrors.Append("<br>");
                }
            }
            finally
            {
                sErrors = sbErrors.ToString();
                sbErrors = null;
                if (dt != null)
                    dt.Dispose();
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