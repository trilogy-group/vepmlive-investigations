using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.SharePoint;
using System.Data.SqlClient;

namespace EPMLiveEnterprise
{
    public class OnPublish : Microsoft.Office.Project.Server.Events.ProjectEventReceiver
    {

        public override void OnPublished(Microsoft.Office.Project.Server.Library.PSContextInfo contextInfo, Microsoft.Office.Project.Server.Events.ProjectPostPublishEventArgs e)
        {
            EventLog myLog = new EventLog("EPM Live", ".", "EPM Live Publisher");
            myLog.MaximumKilobytes = 32768;

            SPSite mySite = new SPSite(contextInfo.SiteGuid);

            EPMLiveCore.Act act = new EPMLiveCore.Act(mySite.RootWeb);
            int iAct = act.CheckFeatureLicense(EPMLiveCore.ActFeature.ProjectServer);
            if(iAct == 0)
            {
                //switch (EPMLiveCore.CoreFunctions.getFeatureLicenseStatus(4))
                //{
                //    case -1:
                //        myLog.WriteEntry("Unable to retrieve activation status.", EventLogEntryType.Warning, 500);
                //        return;
                //    case 1:
                //        myLog.WriteEntry("Enterprise feature not activated.", EventLogEntryType.Warning, 500);
                //        return;
                //    case 2:
                //        myLog.WriteEntry("Too many users activated for the Enterprise feature.", EventLogEntryType.Warning, 500);
                //        return;
                //};
                Publisher pub = new Publisher(contextInfo, e);
                pub.doPublish();
            }
            else
            {
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(mySite.WebApplication.Id));

                SqlCommand cmd = new SqlCommand("update publishercheck set webguid=@webguid,logtext=@logtext, checkbit=0,status=@status,percentcomplete=0,laststatusdate=getdate() where projectguid=@projectguid", cn);
                cmd.Parameters.AddWithValue("@projectguid", e.ProjectGuid);
                cmd.Parameters.AddWithValue("@webguid", mySite.OpenWeb().ID);
                cmd.Parameters.AddWithValue("@status", 3);
                cmd.Parameters.AddWithValue("@logtext", "Activation Error: " + act.translateStatus(iAct));

                cn.Close();
            }
        }

        

    }
}
