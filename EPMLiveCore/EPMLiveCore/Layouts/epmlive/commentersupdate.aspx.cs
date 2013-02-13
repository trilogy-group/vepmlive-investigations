using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace EPMLiveCore
{
    public partial class commentersupdate : LayoutsPageBase
    {
        string users;
        string listid;
        string itemid;
        string webUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool hasError = false;
            users = Request["users"];
            listid = Request["listid"];
            itemid = Request["itemid"];
            webUrl = Request["weburl"];

            SPSecurity.RunWithElevatedPrivileges(delegate
               {
                   using (SPSite es = new SPSite(webUrl))
                   {
                       using (SPWeb ew = es.OpenWeb())
                       {
                           ew.AllowUnsafeUpdates = true;
                           List<int> newIds = new List<int>();
                           SPList l = ew.Lists[new Guid(listid)];
                           SPListItem item = l.GetItemById(int.Parse(itemid));
                           newIds = GetMatchingUserIds(users);
                           if (newIds.Count > 0)
                           {
                               try
                               {
                                   item["Commenters"] = string.Join(",", Array.ConvertAll(newIds.ToArray(), x => x.ToString()));
                                   item.SystemUpdate();
                               }
                               catch (Exception ex)
                               {
                                   hasError = true;
                               }
                           }
                           else
                           {
                               try
                               {
                                   item["Commenters"] = string.Empty;
                                   item.SystemUpdate();
                               }
                               catch (Exception ex)
                               {
                                   hasError = true;
                               }
                           }
                       }
                   }
               });

            if (hasError)
            {
                Response.Output.WriteLine("failed");
            }
            else
            {
                Response.Output.WriteLine("success");
            }

        }

        private List<int> GetMatchingUserIds(string sUsers)
        {
            string[] saUsers = sUsers.Split(';');
            List<int> userIds = new List<int>();
            SPSecurity.RunWithElevatedPrivileges(delegate
               {
                   using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                   {
                       using (SPWeb ew = es.OpenWeb())
                       {
                           foreach (string u in saUsers)
                           {
                               foreach (SPUser user in ew.AllUsers)
                               {
                                   if (user.Name.Trim().ToLower().Equals(u.Trim().ToLower(), StringComparison.CurrentCultureIgnoreCase))
                                   {
                                       if (!userIds.Contains(user.ID))
                                       {
                                           userIds.Add(user.ID);
                                       }
                                       break;
                                   }
                               }
                           }
                       }
                   }
               });

            return userIds;
        }
    }


}
