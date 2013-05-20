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
            //if(System.Diagnostics.Process.GetCurrentProcess().ProcessName != "TimerService")
            AddTimerJob(properties);
        }

        private void AddTimerJob(SPItemEventProperties properties)
        {

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                base.EventFiringEnabled = false;
                GridGanttSettings settings = new GridGanttSettings(properties.List);



                bool isSecure = false;
                try
                {
                    isSecure = settings.BuildTeamSecurity;
                }
                catch { }


                int priority = 1;
                if (isSecure)
                    priority = 0;

                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(properties.Web.Site.WebApplication.Id));
                cn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO ITEMSEC (SITE_ID, WEB_ID, LIST_ID, ITEM_ID, USER_ID, priority) VALUES (@siteid, @webid, @listid, @itemid, @userid, @priority)", cn);
                cmd.Parameters.AddWithValue("@siteid", properties.SiteId);
                cmd.Parameters.AddWithValue("@webid", properties.Web.ID);
                cmd.Parameters.AddWithValue("@listid", properties.ListId);
                cmd.Parameters.AddWithValue("@itemid", properties.ListItemId);
                cmd.Parameters.AddWithValue("@userid", properties.CurrentUserId);
                cmd.Parameters.AddWithValue("@priority", priority);
                cmd.ExecuteNonQuery();

                cn.Close();



                SPUser orignalUser = properties.Web.AllUsers.GetByID(properties.CurrentUserId);

                if (isSecure)
                {
                    SPListItem li = properties.ListItem;

                    string safeTitle = !string.IsNullOrEmpty(li.Title) ? GetSafeGroupTitle(li.Title) : string.Empty;

                    properties.Web.AllowUnsafeUpdates = true;

                    SPFieldLookup assignedTo = null;
                    try
                    {
                        assignedTo = properties.List.Fields.GetFieldByInternalName("AssignedTo") as SPFieldLookup;
                    }
                    catch { }

                    object assignedToFv = null;
                    string sAssignedTo = string.Empty;
                    try
                    {
                        assignedToFv = li["AssignedTo"];
                    }
                    catch { }
                    if (assignedToFv != null)
                    {
                        sAssignedTo = assignedToFv.ToString();
                    }

                    SPFieldUserValueCollection uCol = new SPFieldUserValueCollection();

                    if (!string.IsNullOrEmpty(sAssignedTo))
                    {
                        uCol = new SPFieldUserValueCollection(properties.Web, sAssignedTo);
                    }

                    if (assignedTo != null)
                    {
                        if (assignedTo.AllowMultipleValues)
                        {
                            uCol.Add(new SPFieldUserValue(properties.Web, orignalUser.ID, orignalUser.LoginName));
                            li["AssignedTo"] = uCol;
                        }
                        else
                        {
                            li["AssignedTo"] = new SPFieldUserValue(properties.Web, orignalUser.ID, orignalUser.LoginName);
                        }

                        try
                        {
                            li.SystemUpdate();
                        }
                        catch (Exception e)
                        {
                        }

                    }
                }
                base.EventFiringEnabled = true;
            });

        }

        private string GetSafeGroupTitle(string grpName)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(grpName))
            {
                result = grpName;
                result = result.Replace("\"", "")
                           .Replace("/", "")
                           .Replace("\\", "")
                           .Replace("[", "")
                           .Replace("]", "")
                           .Replace(":", "")
                           .Replace("|", "")
                           .Replace("<", "")
                           .Replace(">", "")
                           .Replace("+", "")
                           .Replace("=", "")
                           .Replace(";", "")
                           .Replace(",", "")
                           .Replace("?", "")
                           .Replace("*", "")
                           .Replace("'", "")
                           .Replace("@", "");
            }

            return result;
        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            base.ItemDeleted(properties);

            SPListItem _listItem = properties.ListItem;

            List<SPGroup> grps = new List<SPGroup>();
            foreach (SPRoleAssignment ra in _listItem.RoleAssignments)
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
