using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Data;

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
                //if (actualWork != "")
                //{
                if (!liveHours)
                {
                    sErrors = SharedFunctions.processActualWork(cn, TSUID.ToString(), site, true, true);
                }
                //}
            }

            if(sErrors != "")
                bErrors = true;
        }

        


    }
}
