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
    public class DepartmentEvent : SPItemEventReceiver
    {
       /// <summary>
       /// An item is being added.
       /// </summary>
       public override void ItemAdding(SPItemEventProperties properties)
       {

           processItem(properties);

       }

       /// <summary>
       /// An item is being updated.
       /// </summary>
       public override void ItemUpdating(SPItemEventProperties properties)
       {

           processItem(properties);

       }


       private void processItem(SPItemEventProperties properties)
       {

           try
           {
               if(properties.List.Fields.ContainsFieldWithInternalName("DisplayName") && properties.List.Fields.ContainsFieldWithInternalName("RBS"))
               {
                   string title = GetProperty(properties, "Title");
                   string parent = GetProperty(properties, "RBS");

                   if(title != "")
                   {
                       if(parent != "" && parent != "0")
                       {
                           SPFieldLookupValue lv = new SPFieldLookupValue(parent);

                           SPListItem liParent = properties.List.GetItemById(lv.LookupId);

                           properties.AfterProperties["DisplayName"] = liParent[properties.List.Fields.GetFieldByInternalName("DisplayName").Id].ToString() + "." + title;
                       }
                       else
                       {
                           properties.AfterProperties["DisplayName"] = title;
                       }
                   }
                   
               }
           }
           catch { }

       }

       private string GetProperty(SPItemEventProperties properties, string property)
       {
           try
           {
               if(properties.AfterProperties[property] != null)
                   return properties.AfterProperties[property].ToString();
               else
                   return properties.ListItem[properties.List.Fields.GetFieldByInternalName("Title").Id].ToString();
           }
           catch { }
           return "";
       }

    }
}
