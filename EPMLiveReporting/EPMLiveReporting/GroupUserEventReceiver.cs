using EPMLiveCore.Jobs.SSRS;
using Microsoft.SharePoint;
using System.Diagnostics;

namespace EPMLiveReportsAdmin
{
    public class GroupUserEventReceiver : SPSecurityEventReceiver
    {
        public override void GroupUserAdded(SPSecurityEventProperties properties)
        {
            base.GroupUserAdded(properties);
            var group = properties.Web.Groups.GetByID(properties.GroupId);
            if (group.Name == "Report Viewers" || group.Name == "Administrators")
            {
                var addedUser = properties.Web.AllUsers.GetByID(properties.GroupUserId);
                var extendedList = properties.Web.SiteUserInfoList.Items.GetItemById(addedUser.ID);
                extendedList["Synchronized"] = false;
                extendedList.Update();
                SSRSSyncQueueAgent.EnequePFEJobSingleSiteCollection(properties.Web.Site.WebApplication, properties.Web.Site);
            }
        }

        public override void GroupUserDeleted(SPSecurityEventProperties properties)
        {
            base.GroupUserDeleted(properties);
            var group = properties.Web.Groups.GetByID(properties.GroupId);
            if (group.Name == "Report Viewers" || group.Name == "Administrators")
            {
                var removedUser = properties.Web.AllUsers.GetByID(properties.GroupUserId);
                var syncJob = new SyncJob();
                syncJob.execute(properties.Web.Site, properties.Web, $"removerole~{removedUser.LoginName}~{group.Name}");
            }
        }
    }
}