using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace TimeSheets
{
    public class ApprovalJob: BaseJob
    {

        public void execute(SPSite site, string data)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                if(cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
            });

            bool liveHours = false;

            bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSLiveHours"), out liveHours);

            //string[] tsuids = data.Split(',');

            //foreach(string tsuidData in tsuids)
            {
                SqlCommand cmd = new SqlCommand("update TSTIMESHEET set approval_status=1,approval_notes=@notes,approval_date=GETDATE() where ts_uid=@ts_uid", cn);
                cmd.Parameters.AddWithValue("@ts_uid", base.TSUID);
                cmd.Parameters.AddWithValue("@notes", data);

                cmd.ExecuteNonQuery();

                //if (actualWork != "")
                //{
                if(!liveHours)
                    sErrors += SharedFunctions.processActualWork(cn, TSUID.ToString(), site, true, true);
                //}
            }

            if(sErrors != "")
                bErrors = true;
        }



    }
}
