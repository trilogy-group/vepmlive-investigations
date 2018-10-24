using System;
using System.Data.SqlClient;
using System.Diagnostics;
using EPMLiveCore;
using Microsoft.Office.Project.Server.Events;
using Microsoft.Office.Project.Server.Library;
using Microsoft.SharePoint;

namespace EPMLiveEnterprise
{
    public class OnPublish : ProjectEventReceiver
    {
        public override void OnPublished(PSContextInfo contextInfo, ProjectPostPublishEventArgs e)
        {
            if (contextInfo == null)
            {
                throw new ArgumentNullException(nameof(contextInfo));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            using (var myLog = new EventLog("EPM Live", ".", "EPM Live Publisher"))
            {
                myLog.MaximumKilobytes = 32768;

                using (var mySite = new SPSite(contextInfo.SiteGuid))
                {
                    var act = new Act(mySite.RootWeb);                    
                    int iAct = act.CheckFeatureLicense(ActFeature.ProjectServer);
                    if (iAct == 0)
                    {
                        using (var publisher = new Publisher(contextInfo, e))
                        {
                            publisher.doPublish();
                        }
                    }
                    else
                    {
                        using (var connection = new SqlConnection(CoreFunctions.getConnectionString(mySite.WebApplication.Id)))
                        {
                            using (var command = new SqlCommand("update publishercheck set webguid=@webguid,logtext=@logtext, checkbit=0,status=@status,percentcomplete=0,laststatusdate=getdate() where projectguid=@projectguid", connection))
                            {
                                command.Parameters.AddWithValue("@projectguid", e.ProjectGuid);
                                command.Parameters.AddWithValue("@webguid", mySite.OpenWeb().ID);
                                command.Parameters.AddWithValue("@status", 3);
                                command.Parameters.AddWithValue("@logtext", $"Activation Error: {act.translateStatus(iAct)}");
                            }
                        }
                    }
                }
            }
        }
    }
}