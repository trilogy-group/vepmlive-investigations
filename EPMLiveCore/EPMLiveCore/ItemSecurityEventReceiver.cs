using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Threading;
using System.Data.SqlClient;
using EPMLiveReportsAdmin;
using System.Collections;

namespace EPMLiveCore
{
    public class ItemSecurityEventReceiver : SPItemEventReceiver
    {
        


        public override void ItemAdded(SPItemEventProperties properties)
        {
            AddTimerJob(properties);
        }

        

        public override void ItemUpdated(SPItemEventProperties properties)
        {
            if(System.Diagnostics.Process.GetCurrentProcess().ProcessName != "TimerService")
                AddTimerJob(properties);
        }

        private void AddTimerJob(SPItemEventProperties properties)
        {
            Guid tj = API.Timer.AddTimerJob(properties.SiteId, properties.Web.ID, properties.ListId, properties.ListItemId, "UpdateSecurity", 11, "", "", 0, 99, "");
            API.Timer.Enqueue(tj, 0, properties.OpenSite());
        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            base.ItemDeleted(properties);

            SPListItem _listItem = properties.ListItem;

            List<SPGroup> grps = new List<SPGroup>();
            foreach(SPRoleAssignment ra in _listItem.RoleAssignments)
            {
                if (ra.Member is SPGroup && ra.Member.Name.Contains(_listItem.Title))
                {
                    grps.Add(ra.Member as SPGroup);
                }
            }

            if (_listItem.HasUniqueRoleAssignments)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite es = new SPSite(properties.WebUrl))
                    {
                        using (SPWeb ew = es.OpenWeb())
                        {
                            ew.AllowUnsafeUpdates = true;
                            foreach (SPGroup g in grps)
                            {
                                ew.SiteGroups.Remove(g.Name);
                            }
                            ew.Update();
                        }
                    }
                });
            }
            
        }

    }
}
