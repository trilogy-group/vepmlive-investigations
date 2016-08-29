using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace EPMLiveCore.EPMLiveTaskCenterEvent
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EPMLiveTaskCenterEvent : SPItemEventReceiver
    {
       /// <summary>
       /// An item is being updated.
       /// </summary>
       public override void ItemUpdating(SPItemEventProperties properties)
       {
           try
           {

               if ((string)properties.AfterProperties["Status"] != (string)properties.ListItem["Status"])
               {
                   if ((string)properties.AfterProperties["Status"] == "Completed")
                   {
                       properties.AfterProperties["PercentComplete"] = "1";
                   }
                   else if ((string)properties.AfterProperties["Status"] == "In Progress")
                   {
                       if ((string)properties.AfterProperties["PercentComplete"] == "0" || (string)properties.AfterProperties["PercentComplete"] == "1" || Convert.ToString(properties.AfterProperties["PercentComplete"]) == "")
                       {
                           properties.AfterProperties["PercentComplete"] = "0.5";
                       }
                   }
                   else if ((string)properties.AfterProperties["Status"] == "Not Started")
                   {
                       properties.AfterProperties["PercentComplete"] = "0";
                   }
               }
               else if ((string)properties.AfterProperties["PercentComplete"] != Convert.ToString(properties.ListItem["PercentComplete"]))
               {
                   if ((string)properties.AfterProperties["PercentComplete"] == "0")
                   {
                       properties.AfterProperties["Status"] = "Not Started";
                   }
                   else if (float.Parse((string)properties.AfterProperties["PercentComplete"]) > 0.00 & float.Parse((string)properties.AfterProperties["PercentComplete"]) < 1.00)
                   {
                       properties.AfterProperties["Status"] = "In Progress";
                   }
                   else if ((string)properties.AfterProperties["PercentComplete"] == "1")
                   {
                       properties.AfterProperties["Status"] = "Completed";
                   }
               }

           }
           catch { }
       }
    }
}
