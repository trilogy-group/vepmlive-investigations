using System.Data;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin.Jobs
{
    public class SnapshotJob : BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            var epmdata = new EPMData(site.ID);

            epmdata.SnapshotLists(base.JobUid, site.ID, data);

            DataTable dt = epmdata.GetSnapshotResults(base.JobUid);

            foreach (DataRow dr in dt.Rows)
            {
                sErrors += "Processing List (" + dr["ListName"] + ")";
                if (dr["level"].ToString() == "2")
                {
                    sErrors += " Failed: " + dr["ShortMessage"];
                    bErrors = true;
                }
                else
                    sErrors += " Success";

                sErrors += "<br>";
            }
        }
    }
}