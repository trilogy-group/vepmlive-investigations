using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;
using EPMLiveReportsAdmin;
using System.Threading;
using EPMLiveCore.API;
using System.Collections;

namespace EPMLiveCore.Jobs
{
    public class SecurityUpdate
    {
        string safeGroupTitle = string.Empty;

        public void execute(SPSite site, SPWeb web, Guid listId, int itemId, int userid, string data)
        {
            SPList list = null;
            SPListItem li = null;
            GridGanttSettings settings = null;
            List<string> cNewGrps = null;
            List<string> fields = null;
            SPUser orignalUser = null;
            EnhancedLookupConfigValuesHelper valueHelper = null;
            SPList lookupPrntList = null;
            GridGanttSettings prntListSettings = null;
            SPFieldLookupValue lookupVal = null;
            SPListItem targetItem = null;
            try
            {
                list = web.Lists[listId];
                li = list.GetItemById(itemId);
                settings = new GridGanttSettings(list);
                cNewGrps = new List<string>();
                bool isSecure = false;
                try
                {
                    isSecure = settings.BuildTeamSecurity;
                }
                catch { }

                orignalUser = web.AllUsers.GetByID(userid);

                string safeTitle = !string.IsNullOrEmpty(li.Title) ? GetSafeGroupTitle(li.Title) : string.Empty;

                if (string.IsNullOrEmpty(safeTitle) && list.BaseTemplate == SPListTemplateType.DocumentLibrary)
                    safeTitle = GetSafeGroupTitle(li.Name); //Assign Name instead of Title - This should perticularly happen with Document libraries.

                if (isSecure)
                {
                    if (!li.HasUniqueRoleAssignments)
                    {
                        web.AllowUnsafeUpdates = true;
                        safeGroupTitle = safeTitle;

                        safeTitle = GetIdenticalGroupName(site.ID, web.ID, safeTitle, 0);

                        // step 1 perform actions related to "parent item"
                        // ===============================================
                        Dictionary<string, SPRoleType> pNewGrps = null;
                        try
                        {
                            pNewGrps = AddBasicSecurityGroups(web, safeTitle, orignalUser, li);

                            li.BreakRoleInheritance(false);

                            foreach (KeyValuePair<string, SPRoleType> group in pNewGrps)
                            {
                                SPGroup g = web.SiteGroups[group.Key];
                                AddNewItemLvlPerm(li, web, group.Value, g);
                                g = null;
                            }

                            AddBuildTeamSecurityGroups(web, settings, li);

                        }
                        catch { }
                        finally
                        {
                            pNewGrps = null;
                        }
                    }
                }


                // step 2 perform actions related to "child item"
                // ====================================
                // find lookups that has security enabled
                string lookupSettings = settings.Lookups;
                //string rawValue = "Region^dropdown^none^none^xxx|State^autocomplete^Region^Region^xxx|City^autocomplete^State^State^xxx";                    
                valueHelper = new EnhancedLookupConfigValuesHelper(lookupSettings);

                if (valueHelper == null)
                {
                    return;
                }

                fields = valueHelper.GetSecuredFields();

                bool bHasLookup = false;

                foreach (string fld in fields)
                {
                    SPFieldLookup lookup = null;
                    try
                    {
                        lookup = list.Fields.GetFieldByInternalName(fld) as SPFieldLookup;
                    }
                    catch { }

                    if (lookup == null)
                    {
                        continue;
                    }

                    lookupPrntList = web.Lists[new Guid(lookup.LookupList)];
                    prntListSettings = new GridGanttSettings(lookupPrntList);
                    string sVal = string.Empty;
                    try
                    {
                        sVal = li[fld].ToString();
                    }
                    catch { }
                    if (!string.IsNullOrEmpty(sVal))
                    {
                        bHasLookup = true;
                        break;
                    }

                }
                if (bHasLookup)
                {
                    // has security fields
                    if (fields.Count > 0)
                    {
                        // if the list is not a security list itself
                        if (isSecure)
                        {
                            li.BreakRoleInheritance(false);
                        }

                        foreach (string fld in fields)
                        {
                            SPFieldLookup lookup = null;
                            try
                            {
                                lookup = list.Fields.GetFieldByInternalName(fld) as SPFieldLookup;
                            }
                            catch { }

                            if (lookup == null)
                            {
                                continue;
                            }

                            lookupPrntList = web.Lists[new Guid(lookup.LookupList)];
                            prntListSettings = new GridGanttSettings(lookupPrntList);
                            bool isEnableSecurity = false;
                            bool isParentSecure = false;
                            try
                            {
                                isParentSecure = prntListSettings.BuildTeamSecurity;
                            }
                            catch { }

                            string[] LookupArray = settings.Lookups.Split('|');
                            string[] sLookupInfo = null;
                            Hashtable hshLookups = new Hashtable();
                            foreach (string sLookup in LookupArray)
                            {
                                if (sLookup != "")
                                {
                                    sLookupInfo = sLookup.Split('^');
                                    hshLookups.Add(sLookupInfo[0], sLookupInfo);
                                }
                            }
                            try
                            {
                                if (sLookupInfo != null && sLookupInfo[4].ToLower() == "true")
                                    isEnableSecurity = true;
                                else
                                    isEnableSecurity = false;
                            }
                            catch { isEnableSecurity = false; }

                            // skip fields with empty lookup values
                            string sVal = string.Empty;
                            try { sVal = li[fld].ToString(); }
                            catch { }
                            if (string.IsNullOrEmpty(sVal)) { continue; }

                            lookupVal = new SPFieldLookupValue(sVal.ToString());
                            targetItem = lookupPrntList.GetItemById(lookupVal.LookupId);
                            if (!targetItem.HasUniqueRoleAssignments)
                            {
                                continue;
                            }
                            else
                            {
                                //EPML-4422: When a project is not using unique security, and a child list like tasks is set to Inherit security from the project lookup, It sets the task to unique, but does not add any groups. It should not get set to Unique.
                                if (!isSecure && isParentSecure && isEnableSecurity)
                                {
                                    web.AllowUnsafeUpdates = true;
                                    li.BreakRoleInheritance(false);
                                }
                            }

                            SPRoleAssignmentCollection raCol = targetItem.RoleAssignments;
                            string itemMemberGrp = "Member";
                            foreach (SPRoleAssignment ra in raCol)
                            {
                                // add their groups to this item but change permission lvl
                                if (ra.Member.Name.Contains(itemMemberGrp))
                                {
                                    SPRoleAssignment newRa = new SPRoleAssignment(ra.Member);
                                    SPRoleDefinition newDef = web.RoleDefinitions.GetByType(SPRoleType.Contributor);
                                    newRa.RoleDefinitionBindings.Add(newDef);
                                    li.RoleAssignments.Add(newRa);
                                }
                                else
                                {
                                    li.RoleAssignments.Add(ra);
                                }

                                cNewGrps.Add(ra.Member.Name);
                            }

                        }
                    }
                }
                ProcessSecurity(site, list, li, userid);

                // we wait until all groups have been created to createworkspace
                // only if there isn't a current process creating ws 
                WorkspaceTimerjobAgent.QueueWorkspaceJobOnHoldForSecurity(site.ID, web.ID, list.ID, li.ID);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                list = null;
                li = null;
                lookupPrntList = null;
                prntListSettings = null;
                settings = null;
                cNewGrps = null;
                fields = null;
                orignalUser = null;
                valueHelper = null;
                lookupVal = null;
                targetItem = null;
                fields = null;
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }

        private string GetIdenticalGroupName(Guid siteId, Guid webId, string safeTitle, Int32 uniqueGroupIndex)
        {
            string uniqueGroupName = safeTitle;
            string groupTitle = string.Format("'{0} Owner','{0} Member', '{0} Visitor'", uniqueGroupName);
            string qryGroupExists = "SELECT ID FROM LSTUserInformationList WHERE Title IN (" + groupTitle + ") AND ContentType = 'SharePointGroup'  AND WebId = '" + Convert.ToString(webId) + "'";
            ReportData _dao = null;
            try
            {
                _dao = new ReportData(siteId);
                using (SqlConnection cn = _dao.GetClientReportingConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(qryGroupExists, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                //Ooopppsss! Group already exists! Let's try with Incremental Group Search in LSTUserInformationList table!
                                Convert.ToInt32(uniqueGroupIndex++);
                                groupTitle = string.Format("{0}{1}", safeGroupTitle, Convert.ToInt32(uniqueGroupIndex));
                                uniqueGroupName = GetIdenticalGroupName(siteId, webId, groupTitle, Convert.ToInt32(uniqueGroupIndex));
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                groupTitle = null;
                qryGroupExists = null;
                if (_dao != null)
                    _dao.Dispose();
            }
            return uniqueGroupName;
        }

        private void ProcessSecurity(SPSite site, SPList list, SPListItem li, int userid)
        {

            ReportData _dao = null;
            try
            {
                _dao = new ReportData(site.ID);
                using (SqlConnection cn = _dao.GetClientReportingConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE RPTITEMGROUPS where siteid=@siteid and listid=@listid and itemid=@itemid", cn))
                    {
                        cmd.Parameters.AddWithValue("@siteid", site.ID);
                        cmd.Parameters.AddWithValue("@listid", list.ID);
                        cmd.Parameters.AddWithValue("@itemid", li.ID);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (SPRoleAssignment ra in li.RoleAssignments)
                    {
                        int type = 0;
                        if (ra.Member.GetType() == typeof(SPGroup))
                        {
                            type = 1;
                        }
                        if ((ra.RoleDefinitionBindings[0].BasePermissions & SPBasePermissions.ViewListItems) == SPBasePermissions.ViewListItems)
                        {
                            using (SqlCommand cmd1 = new SqlCommand("INSERT INTO RPTITEMGROUPS (SITEID, LISTID, ITEMID, GROUPID, SECTYPE) VALUES (@siteid, @listid, @itemid, @groupid, @sectype)", cn))
                            {
                                cmd1.Parameters.AddWithValue("@siteid", site.ID);
                                cmd1.Parameters.AddWithValue("@listid", list.ID);
                                cmd1.Parameters.AddWithValue("@itemid", li.ID);
                                cmd1.Parameters.AddWithValue("@groupid", ra.Member.ID);
                                cmd1.Parameters.AddWithValue("@sectype", type);
                                cmd1.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM RPTGROUPUSER where SITEID=@siteid and GROUPID=@groupid and USERID=@userid", cn))
                            {
                                cmd2.Parameters.AddWithValue("@siteid", site.ID);
                                cmd2.Parameters.AddWithValue("@groupid", ra.Member.ID);
                                cmd2.Parameters.AddWithValue("@userid", userid);
                                using (SqlDataReader dr = cmd2.ExecuteReader())
                                {
                                    bool found = false;
                                    if (dr.Read())
                                    {
                                        found = true;
                                    }
                                    dr.Close();

                                    if (!found)
                                    {
                                        using (SqlCommand cmd3 = new SqlCommand("INSERT INTO RPTGROUPUSER (SITEID, GROUPID, USERID) VALUES (@siteid, @groupid, @userid)", cn))
                                        {
                                            cmd3.Parameters.AddWithValue("@siteid", site.ID);
                                            cmd3.Parameters.AddWithValue("@groupid", ra.Member.ID);
                                            cmd3.Parameters.AddWithValue("@userid", userid);
                                            cmd3.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    using (SqlCommand cmd4 = new SqlCommand("INSERT INTO RPTITEMGROUPS (SITEID, LISTID, ITEMID, GROUPID, SECTYPE) VALUES (@siteid, @listid, @itemid, @groupid, @sectype)", cn))
                    {
                        cmd4.Parameters.AddWithValue("@siteid", site.ID);
                        cmd4.Parameters.AddWithValue("@listid", list.ID);
                        cmd4.Parameters.AddWithValue("@itemid", li.ID);
                        cmd4.Parameters.AddWithValue("@groupid", 999999);
                        cmd4.Parameters.AddWithValue("@sectype", 1);
                        cmd4.ExecuteNonQuery();
                    }
                }
            }
            catch { }
            finally
            {
                if (_dao != null)
                    _dao.Dispose();
            }
        }

        public Dictionary<string, SPRoleType> AddBasicSecurityGroups(SPWeb ew, string safeTitle, SPUser owner, SPListItem eI)
        {
            ew.AllowUnsafeUpdates = true;
            Dictionary<string, SPRoleType> pNewGroups = new Dictionary<string, SPRoleType>();
            string[] grps = new[] { "Owner", "Member", "Visitor" };
            SPGroup ownerGrp = null;
            //SPListItem eI = ew.Lists[base.ListUid].GetItemById(base.ItemID);
            var spUInfoList = ew.Site.RootWeb.Lists["User Information List"];
            foreach (string grp in grps)
            {
                string finalName = string.Empty;
                try
                {
                    finalName = CoreFunctions.AddGroup(ew, safeTitle, grp, ew.CurrentUser, ew.CurrentUser, string.Empty);
                    spUInfoList.Items.GetItemById(ew.SiteGroups[finalName].ID).SystemUpdate();
                    ew.Update();
                    Thread.Sleep(1000);
                }
                catch { }

                SPGroup finalGrp = ew.SiteGroups[finalName];
                SPRoleType rType;
                switch (grp)
                {
                    case "Owner":
                        ownerGrp = finalGrp;
                        rType = SPRoleType.Administrator;
                        finalGrp.Owner = owner;
                        finalGrp.AddUser(owner);
                        finalGrp.Update();
                        ew.Update();
                        break;
                    default:
                        rType = SPRoleType.Reader;
                        finalGrp.Owner = ownerGrp;
                        finalGrp.Update();
                        ew.Update();
                        break;
                }
                Thread.Sleep(500);
                //AddNewItemLvlPerm(eI, ew, rType, finalGrp);
                pNewGroups.Add(finalGrp.Name, rType);
            }
            return pNewGroups;
        }

        public void AddBuildTeamSecurityGroups(SPWeb ew, GridGanttSettings settings, SPListItem eI)
        {
            string teamPerm = string.Empty;

            try
            {
                teamPerm = settings.BuildTeamPermissions;
            }
            catch { }
            if (!string.IsNullOrEmpty(teamPerm))
            {
                string[] strOuter = settings.BuildTeamPermissions.Split(new string[] { "|~|" }, StringSplitOptions.None);
                //SPListItem eI = ew.Lists[base.ListUid].GetItemById(base.ItemID);

                foreach (string strInner in strOuter)
                {
                    string[] strInnerMost = strInner.Split('~');
                    SPGroup g = null;
                    SPRoleDefinition r = null;

                    try
                    {
                        g = ew.SiteGroups.GetByID(Convert.ToInt32(strInnerMost[0]));
                        r = ew.RoleDefinitions.GetById(Convert.ToInt32(strInnerMost[1]));
                    }
                    catch { }
                    if (g != null && r != null)
                    {
                        if (r.Type != SPRoleType.Guest)
                        {
                            SPRoleAssignment assign = new SPRoleAssignment(g);
                            assign.RoleDefinitionBindings.Add(r);
                            AddNewItemLvlPerm(eI, ew, assign);

                            //Adding users with Full Control permission levels to Owners group.
                            if (r.Type == SPRoleType.Administrator) //Full Control Permission Level
                            {
                                //Add users to Owners group.
                                SPUserCollection groupUsers = g.Users;

                                foreach (SPRoleAssignment role in eI.RoleAssignments)
                                {
                                    try
                                    {
                                        if (role.Member.GetType() == typeof(SPGroup))
                                        {
                                            SPGroup group = (SPGroup)role.Member;
                                            if (group.Name.EndsWith("Owner"))
                                            {
                                                try
                                                {
                                                    foreach (SPUser user in groupUsers)
                                                    {
                                                        group.AddUser(user);
                                                    }
                                                    group.Update();
                                                }
                                                catch { }
                                            }
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                        else
                        {
                            // create our custom limited access role
                            SPRoleDefinition roleDef = new SPRoleDefinition();

                            try
                            {
                                roleDef = ew.RoleDefinitions["Limited Access Permission"];
                            }
                            catch (SPException)
                            {
                                ew.AllowUnsafeUpdates = true;
                                // give it a name and description
                                roleDef.Name = "Limited Access Permission";
                                roleDef.Description = "Identical to standard Limited Access rights. Used to provide access to parent objects of uniquely permissioned content";
                                // apply the base permissions required
                                roleDef.BasePermissions = SPBasePermissions.ViewFormPages | SPBasePermissions.Open | SPBasePermissions.BrowseUserInfo | SPBasePermissions.UseClientIntegration | SPBasePermissions.UseRemoteAPIs;
                                // add it to the web
                                ew.RoleDefinitions.Add(roleDef);
                                ew.Update();
                            }

                            try
                            {
                                SPRoleAssignment assign = new SPRoleAssignment(g);
                                assign.RoleDefinitionBindings.Add(roleDef);
                                AddNewItemLvlPerm(eI, ew, assign);
                            }
                            catch { }
                        }
                    }
                }
            }

            //return createdGrps;
        }

        public void AddNewItemLvlPerm(SPListItem item, SPWeb oWeb, SPRoleType roleType, SPPrincipal principal)
        {
            SPRoleDefinition role = oWeb.RoleDefinitions.GetByType(roleType);
            SPRoleAssignment assign = new SPRoleAssignment(principal);
            assign.RoleDefinitionBindings.Add(role);
            item.RoleAssignments.Add(assign);
        }

        public void AddNewItemLvlPerm(SPListItem item, SPWeb oWeb, SPRoleAssignment assign)
        {
            item.RoleAssignments.Add(assign);
        }

        private string GetSafeGroupTitle(string grpName)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(grpName))
            {
                result = grpName;
                result = CoreFunctions.GetSafeGroupTitle(grpName);
            }

            return result;
        }

    }
}
