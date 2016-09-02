using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace EPMLiveCore
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class IntegrateEvents : SPItemEventReceiver
    {
       /// <summary>
       /// An item is being deleted.
       /// </summary>
       public override void ItemDeleting(SPItemEventProperties properties)
       {
           SPSecurity.RunWithElevatedPrivileges(delegate()
           {
               API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(properties.SiteId, properties.Web.ID);

               core.SubmitDeleteListEvent(properties.ListItem, properties.AfterProperties);
           });
       }

       /// <summary>
       /// An item was added.
       /// </summary>
       public override void ItemAdded(SPItemEventProperties properties)
       {
           SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(properties.SiteId, properties.Web.ID);

                core.SubmitListEvent(properties.ListItem, 1, properties.AfterProperties);
            });
       }

       /// <summary>
       /// An item was updated.
       /// </summary>
       public override void ItemUpdated(SPItemEventProperties properties)
       {
           SPSecurity.RunWithElevatedPrivileges(delegate()
           {
               API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(properties.SiteId, properties.Web.ID);

               core.SubmitListEvent(properties.ListItem, 1, properties.AfterProperties);
           });
       }


    }
}
