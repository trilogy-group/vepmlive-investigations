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

       /// <summary>
       /// An item is being Deleted.
       /// </summary>
       public override void ItemDeleted(SPItemEventProperties properties)
       {
           try
           {
               if (properties.List.Fields.ContainsFieldWithInternalName("DisplayName") && properties.List.Fields.ContainsFieldWithInternalName("RBS"))
               {
                   SPWeb web = properties.Web;
                   SPList lstDept = web.Lists.TryGetList(properties.ListTitle);
                   SPQuery deptquery = new SPQuery();
                   deptquery.Query = "<Where><Eq><FieldRef Name='RBS' LookupId='TRUE'/><Value Type='Lookup'>" + properties.ListItemId + "</Value></Eq></Where>";                   
                   SPListItemCollection DepartmentListItems = lstDept.GetItems(deptquery);

                   foreach (SPListItem deptItem in DepartmentListItems)
                   {
                       try
                       {
                           deptItem["RBS"] = null;
                           deptItem["Managers"] = new SPFieldLookupValue(Convert.ToString(deptItem["Managers"]));
                           deptItem["Title"] = deptItem.Title;
                           deptItem.Update();
                       }
                       catch { }
                   }
               }
           }
           catch (Exception ex)
           {
               properties.Cancel = true;
               properties.ErrorMessage = ex.Message;
               properties.Status = SPEventReceiverStatus.CancelWithError;
           }
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
