using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Threading;
using System.ComponentModel;
using System.Collections;

namespace EPMLiveCore
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class AssignedToEvent : SPItemEventReceiver
    {

        
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            processItem(properties, false);
        }


       /// <summary>
       /// An item is being added.
       /// </summary>
       public override void ItemAdded(SPItemEventProperties properties)
       {
           processItem(properties, true);
       }

       /// <summary>
       /// An item is being updated.
       /// </summary>
       public override void ItemUpdated(SPItemEventProperties properties)
       {
           
       }

       private void processItem(SPItemEventProperties properties, bool isAdd)
       {
           //BackgroundWorker bw = new BackgroundWorker();
           //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
           //bw.RunWorkerAsync(properties);
           if (properties.ListItemId == 0)
           {
               return;
           }

           Hashtable hshProps = new Hashtable();

           using(SPSite site = new SPSite(properties.SiteId))
           {
               using(SPWeb web = site.OpenWeb(properties.Web.ID))
               {
                   SPList list = web.Lists[properties.ListId];
                   SPListItem li = list.GetItemById(properties.ListItemId);
                   SPUser user = web.SiteUsers.GetByID(properties.CurrentUserId);

                   hshProps.Add("StartDate", getFieldVal("StartDate", properties, list));
                   hshProps.Add("DueDate", getFieldVal("DueDate", properties, list));
                   hshProps.Add("Priority", getFieldVal("Priority", properties, list));
                   hshProps.Add("Status", getFieldVal("Status", properties, list));
                   hshProps.Add("Body", getFieldVal("Body", properties, list));
                   hshProps.Add("Project", getFieldVal("Project", properties, list));

                   ArrayList curUsers = new ArrayList();
                   ArrayList newUsers = new ArrayList();

                   try
                   {
                       SPField f = list.Fields.GetFieldByInternalName("AssignedTo");
                       SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(list.ParentWeb, li[f.Id].ToString());
                       foreach(SPFieldUserValue uv in uvc)
                       {
                           if(uv.User != null)
                           {
                               curUsers.Add(uv.LookupId.ToString());
                           }
                       }
                   }
                   catch { }

                   if(isAdd)
                       newUsers = curUsers;

                   try
                   {
                       int newUser = 0;

                       if(int.TryParse(properties.AfterProperties["AssignedTo"].ToString(), out newUser))
                       {
                           if(!curUsers.Contains(newUser.ToString()))
                               newUsers.Add(newUser.ToString());
                       }
                       else{

                           SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(list.ParentWeb, properties.AfterProperties["AssignedTo"].ToString());
                           foreach(SPFieldUserValue uv in uvc)
                           {
                               if(uv.User != null && !curUsers.Contains(uv.LookupId.ToString()))
                                   newUsers.Add(uv.LookupId.ToString());
                           }
                       }
                   }
                   catch { }

                   hshProps.Add("ListName", properties.ListTitle);

                   if(newUsers.Count > 0)
                   {
                        if(user.Name != "System Account")
                            API.APIEmail.QueueItemMessage(4, false, hshProps, (string[])newUsers.ToArray(typeof(string)), null, false, true, li, user, true);
                        else
                            API.APIEmail.QueueItemMessage(4, false, hshProps, (string[])newUsers.ToArray(typeof(string)), null, true, true, li, user, true);
                   }
                   //else if(curUsers.Count == 0)
                   //{
                   //    API.APIEmail.ClearNotificationItem(4, li);
                   //}
               }
           }
       }

       private string getFieldVal(string field, SPItemEventProperties properties, SPList list)
        {
            try
            {
                SPField f = list.Fields.GetFieldByInternalName(field);
                string val = properties.AfterProperties[field].ToString();

                if(f.Type == SPFieldType.DateTime)
                {
                    val = val.Replace("T", " ").Replace("Z", "");
                }

                if(val == "")
                    return "";

                switch(f.Type)
                {
                    case SPFieldType.DateTime:
                        try
                        {
                            val = f.GetFieldValue(val).ToString();
                            DateTime dt = DateTime.Parse(val);

                            SPFieldDateTime dtF = (SPFieldDateTime)f;
                            if(dtF.DisplayFormat == SPDateTimeFieldFormatType.DateOnly)
                                return dt.ToShortDateString();
                            else
                                return dt.ToString();
                        }catch{}
                        return "";
                    case SPFieldType.Lookup:
                        if (val != "")
                        {
                            if (val.Contains(";#"))
                            {
                                return f.GetFieldValueAsText(val);
                            }
                            else
                            {
                                SPList lookupList = properties.Web.Lists[new Guid(((SPFieldLookup)f).LookupList)];
                                SPListItem lookupItem = lookupList.GetItemById(int.Parse(val));
                                return lookupItem[((SPFieldLookup)f).LookupField].ToString();
                            }
                        }
                        return "";
                    default:
                        return f.GetFieldValue(val).ToString();
                };
            }
            catch { }
            return "";
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            SPItemEventProperties properties = (SPItemEventProperties)e.Argument;

            
       }
    }
}
