using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;

namespace TimeSheets
{
    internal class TimesheetSettings
    {
        public bool AllowUnassigned = true;
        public bool AllowNotes = false;
        public string FlagField = "Flag15";
        public string DayDef = "";
        public bool UseCurrentData = true;
        public string NonWorkList = "Non Work";
        public ArrayList Lists = new ArrayList();
        public String TimesheetHoursField = "Number15";
        public bool DisableApprovals = false;
        public bool ShowLiveHours = false;
        public bool AllowStopWatch = false;
        public ArrayList TimesheetFields = new ArrayList();

        public TimesheetSettings(SPWeb oWeb)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate(){

                using(SPSite site = new SPSite (oWeb.Site.ID))
                {
                    SPWeb rweb = site.RootWeb;
                    try
                    {
                        AllowUnassigned = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSAllowUnassigned"));
                    }
                    catch { }
                    try
                    {
                        AllowNotes = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSAllowNotes"));
                    }
                    catch { } 
                    try
                    {
                        AllowStopWatch = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSAllowStopWatch"));
                    }
                    catch { }

                    FlagField = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSFlag");
                    Lists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSLists").Replace("\r\n","\r").Split("\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

                    DayDef = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveDaySettings");

                    try
                    {
                        UseCurrentData = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSUseCurrent"));
                    }
                    catch { }

                    NonWorkList = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSNonWork");

                    TimesheetHoursField = EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSTimesheetHours");

                    try
                    {
                        DisableApprovals = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSDisableApprovals"));
                    }
                    catch { }
                    try
                    {
                        ShowLiveHours = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSLiveHours"));
                    }
                    catch { }

                    TimesheetFields = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSMyFields").Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                }


            });
        }

    }
}
