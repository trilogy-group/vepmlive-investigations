using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using System.Collections;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveCore.API
{
    public class AssociatedListInfo
    {
        public Guid ListId = Guid.Empty;
        public string Title = "";
        public string LinkedField = "";
        public string icon = "";
    }

    public class RibbonProperties
    {
        public bool bBuildTeam = false;
        public bool bDisableProject = false;
        public bool bDisablePlan = false;
        public ArrayList aEPKButtons = new ArrayList();
        public ArrayList aEPKActivex = new ArrayList();
    }

    public class ListPlannerProps
    {
        public string PlannerV2CurPlanner = "";
        public string PlannerV2Menu = "";
    }

    public class ListCommands
    {

        public static ListPlannerProps GetListPlannerInfo(SPList list)
        {
            ListPlannerProps props = (ListPlannerProps)EPMLiveCore.Infrastructure.CacheStore.Current.Get("LPP", "GridSettings-" + list.ID.ToString(), () =>
            {
                return iGetListPlannerInfo(list);
            }).Value;

            return props;
        }

        private static ListPlannerProps iGetListPlannerInfo(SPList list)
        {
            ListPlannerProps b = new ListPlannerProps();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                using (SPSite site = new SPSite(list.ParentWeb.Site.ID))
                {
                    using (SPWeb w = site.OpenWeb(list.ParentWeb.ID))
                    {

                        try
                        {

                            if (site.Features[new Guid("e6df7606-1541-4bf1-a810-e8e9b11819e3")] != null)
                            {
                                System.Collections.Generic.Dictionary<string, EPMLiveCore.PlannerDefinition> pList = EPMLiveCore.CoreFunctions.GetPlannerList(w, null);

                                int bPlanner = 0;

                                foreach (System.Collections.Generic.KeyValuePair<string, EPMLiveCore.PlannerDefinition> de in pList)
                                {
                                    string id = (string)de.Key;
                                    EPMLiveCore.PlannerDefinition p = (EPMLiveCore.PlannerDefinition)de.Value;

                                    if (String.Equals(p.commandPrefix, list.Title, StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        bPlanner = 1;
                                        break;
                                    }
                                    if (String.Equals(p.command, list.Title, StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        b.PlannerV2CurPlanner = id;
                                        bPlanner = 2;
                                        break;
                                    }
                                }

                                if (bPlanner == 1)
                                {
                                    b.PlannerV2Menu = "<Button Id=\"Ribbon.ListItem.EPMLive.Planner\" Sequence=\"33\" Command=\"EPMLivePlanner\" LabelText=\"Edit Plan\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/planner32.png\"/>";
                                }

                                else if (bPlanner == 2)
                                {
                                    b.PlannerV2Menu = "<Button Id=\"Ribbon.ListItem.EPMLive.Planner\" Sequence=\"33\" Command=\"TaskPlanner\" LabelText=\"Edit Plan\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/planner32.png\"/>";
                                }
                            }
                        }
                        catch { }
                    }
                }
            });

            return b;
        }

        public static GridGanttSettings GetGridGanttSettings(SPList list)
        {
            GridGanttSettings gSettings = (EPMLiveCore.GridGanttSettings)EPMLiveCore.Infrastructure.CacheStore.Current.Get("GGS", "GridSettings-" + list.ID.ToString(), () =>
            {
                return new EPMLiveCore.GridGanttSettings(list);
            }).Value;

            return gSettings;
        }

        public static  RibbonProperties GetRibbonProps(SPList list)
        {
            RibbonProperties rp = new RibbonProperties();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {

                        GridGanttSettings gSettings = GetGridGanttSettings(list);

                        string pubPC = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePublisherProjectCenter", false);
                        string pubTC = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLivePublisherTaskCenter", false);
                        bool foundmpp = false;

                        try
                        {
                            SPDocumentLibrary lib = (SPDocumentLibrary)web.Lists["Project Schedules"];
                            if (lib != null)
                            {
                                if (lib.ContentTypesEnabled)
                                {
                                    foreach (SPContentType ct in lib.ContentTypes)
                                    {
                                        string template = ct.DocumentTemplateUrl;
                                        if (template.Substring(template.Length - 3, 3) == "mpp")
                                        {
                                            foundmpp = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    string template = lib.DocumentTemplateUrl;
                                    if (template.Substring(template.Length - 3, 3) == "mpp")
                                    {
                                        foundmpp = true;
                                    }
                                }
                            }
                        }
                        catch { }

                        if (gSettings.BuildTeam && list.Fields.GetFieldByInternalName("AssignedTo") != null)
                        {
                            if (list.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                            {
                                rp.bBuildTeam = true;
                            }
                        }

                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePublishing"), out rp.bDisableProject);
                        bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveDisablePlanners"), out rp.bDisablePlan);

                        if (site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null)
                        {
                            ArrayList arr = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPKLists").ToLower().Split(','));
                            if (arr.Contains(list.Title.ToLower()))
                            {
                                string menus = "";
                                menus = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPK" + list.Title.Replace(" ", "") + "_menus");
                                if (menus == "")
                                    menus = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPKMenus");

                                rp.aEPKButtons = new ArrayList(menus.Split('|'));

                                string noactivex = "";
                                noactivex = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPK" + list.Title.Replace(" ", "") + "_nonactivexs");
                                if (noactivex == "")
                                    noactivex = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "epknonactivexs");

                                rp.aEPKActivex = new ArrayList(noactivex.Split('|'));
                            }
                        }
                    }
                }
            });
            return rp;

        }


        public static ArrayList GetAssociatedLists(SPList list)
        {
            return (ArrayList)EPMLiveCore.Infrastructure.CacheStore.Current.Get("GAI", "GridSettings-" + list.ID.ToString(), () =>
            {
                return iGetAssociatedLists(list);
            }).Value;
        }

        private static ArrayList iGetAssociatedLists(SPList list)
        {
            ArrayList a = new ArrayList();

            foreach (SPList cList in list.ParentWeb.Lists)
            {
                try
                {
                    foreach (SPField field in cList.Fields)
                    {
                        if (field.Type == SPFieldType.Lookup)
                        {
                            SPFieldLookup fl = (SPFieldLookup)field;

                            if (fl.LookupList.ToLower() == "{" + list.ID.ToString().ToLower() + "}")
                            {


                                EPMLiveCore.GridGanttSettings gSets = (EPMLiveCore.GridGanttSettings)EPMLiveCore.Infrastructure.CacheStore.Current.Get("GGS", "GridSettings-" + cList.ID.ToString(), () =>
                                {
                                    return new EPMLiveCore.GridGanttSettings(cList);
                                }).Value;

                                if (gSets.AssociatedItems)
                                {
                                    AssociatedListInfo lInfo = new AssociatedListInfo();

                                    lInfo.icon = cList.ImageUrl;
                                    lInfo.LinkedField = field.InternalName;
                                    lInfo.ListId = cList.ID;
                                    lInfo.Title = cList.Title;

                                    a.Add(lInfo);
                                }
                                break;
                            }
                        }
                    }
                }
                catch { }
            }

            return a;
        }

        public static bool EnableTeamFeatures(SPList list)
        {
            bool success = true;
            success = TryAddField(list, "AssignedTo", SPFieldType.User, "Assigned To", false);
            return success;
        }

        public static void EnableTimesheets(SPList list, SPWeb web)
        {
            TryAddField(list, "Timesheet", SPFieldType.Boolean, "Timesheet", false);
            TryAddField(list, "TimesheetHours", SPFieldType.Number, "Timesheet Hours", false);

            SPField field = list.Fields.GetFieldByInternalName("TimesheetHours");
            field.ShowInEditForm = false;
            field.ShowInNewForm = false;
            field.Hidden = false;
            field.Update();

            field = list.Fields.GetFieldByInternalName("Timesheet");
            field.Hidden = false;
            field.Update();

            try
            {
                SPContentType defaultContentType = list.ContentTypes["Item"];
                {
                    if (field != null)
                    {
                        SPFieldLink fld = new SPFieldLink(field);
                        if (fld != null)
                        {
                            if (defaultContentType.FieldLinks[fld.Id] == null)
                            {
                                defaultContentType.FieldLinks.Delete(fld.Name);
                                defaultContentType.Update();
                                defaultContentType.FieldLinks.Add(fld);
                                defaultContentType.Update();
                                list.Update();
                            }
                        }
                    }
                }
            }
            catch { }

            try
            {
                SPWeb rootWeb = web.Site.RootWeb;

                ArrayList lists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "EPMLiveTSLists").Replace("\r\n", "\n").Split('\n')); ;

                if(!lists.Contains(list.Title))
                {
                    lists.Add(list.Title);

                    EPMLiveCore.CoreFunctions.setConfigSetting(rootWeb, "EPMLiveTSLists", String.Join("\n", (string[])lists.ToArray(typeof(string))).Replace("\n", "\r\n"));
                }
            }
            catch { }
        }

        public static void DisableTimesheets(SPList list, SPWeb web)
        {
            TryHideField(list, "Timesheet");
            TryHideField(list, "TimesheetHours");

            try
            {
                SPWeb rootWeb = web.Site.RootWeb;

                ArrayList lists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "EPMLiveTSLists").Replace("\r\n", "\n").Split('\n')); ;

                if(lists.Contains(list.Title))
                {
                    lists.Remove(list.Title);

                    EPMLiveCore.CoreFunctions.setConfigSetting(rootWeb, "EPMLiveTSLists", String.Join("\n", (string[])lists.ToArray(typeof(string))).Replace("\n", "\r\n"));
                }
            }
            catch { }
        }

        private static bool TryDeleteField(SPList list, string InternalName)
        {
            SPField field = null;
            try
            {
                field = list.Fields.GetFieldByInternalName(InternalName);
            }
            catch { }

            if(field != null)
            {
                try
                {
                    if(field.Sealed)
                    {
                        field.Sealed = false;
                        field.Update();
                    }
                    field.Delete();
                    list.Update();
                    return true;
                }
                catch { return false; }
            }
            else
                return true;
        }

        private static bool TryHideField(SPList list, string InternalName)
        {
            SPField field = null;
            try
            {
                field = list.Fields.GetFieldByInternalName(InternalName);
            }
            catch { }

            if(field != null)
            {
                try
                {
                    if(field.Sealed)
                    {
                        field.Sealed = false;
                        field.Update();
                    }
                    field.Hidden = true;
                    field.Update();
                    list.Update();
                    return true;
                }
                catch { return false; }
            }
            else
                return true;
        }

        private static bool TryAddField(SPList list, string InternalName, SPFieldType type, string Title, bool Hidden)
        {
            SPField field = null;
            try
            {
                field = list.Fields.GetFieldByInternalName(InternalName);
            }
            catch { }

            if(field == null)
            {
                try
                {
                    string sField = list.Fields.Add(InternalName, type, false);
                    field = list.Fields.GetFieldByInternalName(InternalName);
                    field.Title = Title;
                    field.Hidden = Hidden;
                    field.Update();
                    return true;
                }
                catch { return false; }
            }
            else
                return true;
        }

        public static void InstallListsViewsWebparts(SPList spList)
        {
            if (spList.BaseTemplate == SPListTemplateType.DocumentLibrary) return;

            var oWeb = spList.ParentWeb;

            foreach (SPView oView in spList.Views)
            {
                SPFile oViewFile = oWeb.GetFile(oView.Url);

                if (oViewFile.Exists)
                {
                    SPLimitedWebPartManager oViewWebManager =
                        oViewFile.GetLimitedWebPartManager(
                            System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                    bool bHasGrid = false;

                    try
                    {
                        foreach (WebPart wp in oViewWebManager.WebParts)
                        {
                            if (wp.GetType().ToString() == "EPMLiveWebParts.GridListView")
                            {
                                bHasGrid = true;
                                break;
                            }
                        }

                        if (!bHasGrid)
                        {
                            EPMLiveWebParts.GridListView gv = new EPMLiveWebParts.GridListView();
                            oViewWebManager.AddWebPart(gv, "Main", 0);
                        }
                    }
                    catch { }
                }
            }
        }

        public static void MapListToReporting(SPList oList)
        {
            bool reportingV2Enabled = false;
            try
            {
                reportingV2Enabled = Convert.ToBoolean(CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "reportingV2"));
            }
            catch { }

            var rb = new EPMLiveReportsAdmin.ReportBiz(oList.ParentWeb.Site.ID, oList.ParentWeb.ID, reportingV2Enabled);
            EPMLiveReportsAdmin.ListBiz lb = rb.GetListBiz(oList.ID);

            if (string.IsNullOrEmpty(lb.ListName))
            {
                rb.CreateListBiz(oList.ID);
            }
        }

        public static void SaveIconToReporting(SPList list)
        {
            try
            {
                var settings = new GridGanttSettings(list);

                var queryExecutor = new QueryExecutor(list.ParentWeb);
                queryExecutor.ExecuteReportingDBNonQuery(
                    @"INSERT INTO ReportListIds (Id, ListIcon) VALUES (@Id, @Icon)", new Dictionary<string, object>
                    {
                        {"@Id", list.ID},
                        {"@Icon", settings.ListIcon}
                    });
            }
            catch { }
        }

        public static void EnableFancyForms(SPList list)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                SPWeb web = list.ParentWeb;
                web.AllowUnsafeUpdates = true;

                bool isFancyFormWpExist = false;
                var rootFolder = list.RootFolder;

                var dispFormUrl = string.Format("{0}/{1}/DispForm.aspx", web.ServerRelativeUrl, rootFolder.Url);
                var dispForm = web.GetFile(dispFormUrl);

                SPLimitedWebPartManager wpm;

                if (dispForm != null)
                {
                    //Delete webparts from existing list
                    wpm = dispForm.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
                    if (wpm.WebParts != null)
                    {
                        for (int i = 0; i < wpm.WebParts.Count; i++)
                        {
                            try
                            {
                                if ((!string.IsNullOrEmpty(wpm.WebParts[i].Title)) && (wpm.WebParts[i].Title.Equals("Fancy Display Form", StringComparison.InvariantCultureIgnoreCase)) && !isFancyFormWpExist)
                                {
                                    isFancyFormWpExist = true;
                                    wpm.WebParts[i].AllowHide = false;
                                    wpm.WebParts[i].Hidden = false;
                                    wpm.SaveChanges(wpm.WebParts[i]);
                                }
                                else if (wpm.WebParts[i].ToString() == "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart" ||
                                        wpm.WebParts[i].ToString() == "Microsoft.SharePoint.WebPartPages.ListFormWebPart" ||
                                        wpm.WebParts[i].ToString() == "Microsoft.SharePoint.WebPartPages.ListViewWebPart" ||
                                        wpm.WebParts[i].ToString() == "Microsoft.SharePoint.WebPartPages.DataFormWebPart")
                                {
                                    wpm.WebParts[i].AllowHide = true;
                                    wpm.WebParts[i].Hidden = true;
                                    wpm.SaveChanges(wpm.WebParts[i]);
                                }
                            }
                            catch { }
                        }
                    }
                }
                else
                {
                    dispForm = rootFolder.Files.Add(dispFormUrl, SPTemplateFileType.FormPage);
                }

                if (isFancyFormWpExist) return;

                wpm = dispForm.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                var fancyDispFormWebPart = new EPMLiveWebParts.FancyDisplayForm();
                fancyDispFormWebPart.Title = "Fancy Display Form";
                fancyDispFormWebPart.ChromeState = System.Web.UI.WebControls.WebParts.PartChromeState.Normal;
                fancyDispFormWebPart.ChromeType = System.Web.UI.WebControls.WebParts.PartChromeType.None;
                fancyDispFormWebPart.AllowHide = false;
                fancyDispFormWebPart.Hidden = false;
                fancyDispFormWebPart.Visible = true;

                wpm.AddWebPart(fancyDispFormWebPart, "Main", 0);
            });
        }
    }
}
