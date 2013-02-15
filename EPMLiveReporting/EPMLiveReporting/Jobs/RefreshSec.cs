using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace EPMLiveReportsAdmin.Jobs
{
    public class RefreshSec : EPMLiveCore.API.BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            try
            {
                EPMLiveReportsAdmin.EPMData epmdata = new EPMLiveReportsAdmin.EPMData(site.ID);

                ProcessSecurity.ProcessSecurityGroups(site, epmdata.GetClientReportingConnection, data);
            }
            catch { }
        }
    }
}
