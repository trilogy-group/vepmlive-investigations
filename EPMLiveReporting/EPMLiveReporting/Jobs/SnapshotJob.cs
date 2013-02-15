using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace EPMLiveReportsAdmin.Jobs
{
    public class SnapshotJob : EPMLiveCore.API.BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            EPMLiveReportsAdmin.EPMData epmdata = new EPMLiveReportsAdmin.EPMData(site.ID);

            epmdata.SnapshotLists(base.JobUid, site.ID, data);

            DataTable dt = epmdata.GetSnapshotResults(base.JobUid);

            foreach(DataRow dr in dt.Rows)
            {
                sErrors += "Processing List (" + dr["ListName"].ToString() + ")";
                if(dr["level"].ToString() == "2")
                {
                    sErrors += " Failed: " + dr["ShortMessage"].ToString();
                    bErrors = true;
                }
                else
                    sErrors += " Success";

                sErrors += "<br>";
            }
        }
    }
}
