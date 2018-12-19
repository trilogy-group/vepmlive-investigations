using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Collections;
using System.Globalization;
using Microsoft.SharePoint;
using TimeSheets.Models;
using EPMLiveCore.API;

namespace TimeSheets
{
    public class AllocationNotificationJob : BaseJob
    {

        public void execute(SPSite site, string data)
        {
            WebAppId = site.WebApplication.Id;
            try
            {
                using (SqlConnection cn = CreateConnection())
                {

                    TimesheetAPI.CheckNonTeamMemberAllocation(site.RootWeb, base.TSUID.ToString(), cn.ConnectionString, data);

                    if (sErrors != "")
                        bErrors = true;

                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors = "Error: " + ex.Message;
            }
            finally
            {                
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }

       
    }
}
