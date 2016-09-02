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
    public class AppsListEvents : SPItemEventReceiver
    {
       /// <summary>
       /// An item was deleted.
       /// </summary>
       public override void ItemDeleting(SPItemEventProperties properties)
       {
           try
           {
               string file = System.IO.Path.GetFileName(properties.ListItem["HomePage"].ToString());

               properties.Web.GetFile(file).Delete();

           }catch{}

           try
           {
               SPField fTopNav = properties.List.Fields.GetFieldByInternalName("TopNav");
               EPMLiveCore.API.Applications.RemoveCommunityNav(properties.ListItem, properties.Web, fTopNav);
           }
           catch { }

           try
           {
               SPField fQuickLaunch = properties.List.Fields.GetFieldByInternalName("QuickLaunch");
               EPMLiveCore.API.Applications.RemoveCommunityNav(properties.ListItem, properties.Web, fQuickLaunch);
           }
           catch { }
       }


    }
}
