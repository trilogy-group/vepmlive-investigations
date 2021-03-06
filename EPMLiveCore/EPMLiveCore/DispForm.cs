﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EPMLiveCore.API.ProjectArchiver;
using EPMLiveCore.ListDefinitions;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public class DispForm : WebControl
    {
        private const string ListFormEditActionsGroupId = "Ribbon.ListForm.Edit.Actions";
        private const string ArchiveProjectActionId = ListFormEditActionsGroupId + ".ArchiveProject";
        private const string ArchiveProjectActionTitle = "Archive Project";
        private const string RestoreProjectActionId = ListFormEditActionsGroupId + ".RestoreProject";
        private const string RestoreProjectActionTitle = "Restore Project";
        private const string ArchivedColumn = ProjectArchiverService.ArchivedColumn;

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            SPWeb web = SPContext.Current.Web;

            string editURL = SPContext.Current.List.Forms[PAGETYPE.PAGE_EDITFORM].Url;
            editURL = ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/" + editURL;
            string extraParams = "";

            GridGanttSettings gSettings = API.ListCommands.GetGridGanttSettings(SPContext.Current.List);

            writer.WriteLine("<script>");
            writer.WriteLine("WEWebId = '" + SPContext.Current.Web.ID + "';");
            writer.WriteLine("WEListId = '" + SPContext.Current.List.ID + "';");
            writer.WriteLine("WEItemId = '" + SPContext.Current.ListItem.ID + "';");
            //writer.WriteLine("WETitle = \"" + title.Replace("\"", "&quot;") + "\";");
            writer.WriteLine("WETitle = \"" + HttpUtility.JavaScriptStringEncode(SPContext.Current.ListItem.Title) + "\";");
            writer.WriteLine("WEWebUrl = '" + ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "';");
            writer.WriteLine("WEWebId = '" + web.ID + "';");
            writer.WriteLine("WEEditForm = '" + editURL + "';");
            writer.WriteLine("WEExtraParams = '" + extraParams.Trim('&') + "';");
            writer.WriteLine("WESource = '" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()).Replace("+", "%20") + "';");
            writer.WriteLine("WEUseTeam = " + gSettings.BuildTeam.ToString().ToLower() + ";");
            writer.WriteLine("WEDLG = '" + Page.Request["IsDlg"] + "';");
            writer.WriteLine("</script>");
        }

        private void RegisterArchiveRestoreFormButtons(SPWeb web, SPList list, SPListItem item, SPRibbon ribbon)
        {
            var archiveRestoreFeatureIsEnabled = AllowArchiveRestoreProjectForList(list);
            var archiveProjectButtonVisible = archiveRestoreFeatureIsEnabled
                                              && (item[ArchivedColumn] == null || (bool)item[ArchivedColumn] == false);
            var restoreProjectButtonVisible = archiveRestoreFeatureIsEnabled && !archiveProjectButtonVisible;

            var ribbonExtensions = new XmlDocument();

            if (archiveProjectButtonVisible)
            {
                // add archive button if project is active 
                ribbonExtensions.LoadXml($@"<Button
                    Id=""{ArchiveProjectActionId}""
                    Sequence=""900""
                    Command=""{ArchiveProjectActionId}""
                    Image16by16=""/_layouts/15/{web.Language}/images/formatmap16x16.png"" Image16by16Top=""-181"" Image16by16Left=""-181""
                    Image32by32=""/_layouts/15/{web.Language}/images/formatmap32x32.png"" Image32by32Top=""-305"" Image32by32Left=""-203""
                    LabelText=""{ArchiveProjectActionTitle}""
                    TemplateAlias=""o2""/>");
                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                    $"{ListFormEditActionsGroupId}.Controls._children");
            }
            else if (restoreProjectButtonVisible)
            {
                // add restore button if project is archived
                ribbonExtensions.LoadXml($@"<Button
                    Id=""{RestoreProjectActionId}""
                    Sequence=""900""
                    Command=""{RestoreProjectActionId}""
                    Image16by16=""/_layouts/15/{web.Language}/images/formatmap16x16.png"" Image16by16Top=""-181"" Image16by16Left=""-181""
                    Image32by32=""/_layouts/15/{web.Language}/images/formatmap32x32.png"" Image32by32Top=""-65"" Image32by32Left=""-33""
                    LabelText=""{RestoreProjectActionTitle}""
                    TemplateAlias=""o2""/>");
                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                    $"{ListFormEditActionsGroupId}.Controls._children");
            }
        }

        private bool AllowArchiveRestoreProjectForList(SPList list)
        {
            var isProjectCenter = (int)list.BaseTemplate == (int)EPMLiveLists.ProjectCenter;
            var result = isProjectCenter && list.Fields.ContainsField(ArchivedColumn);
            return result;
        }

        protected override void OnPreRender(System.EventArgs e)
        {
            SPWeb Web = SPContext.Current.Web;
            SPList List = SPContext.Current.List;
            SPListItem ListItem = SPContext.Current.ListItem;

            CssRegistration.Register("/_layouts/epmlive/modal/modal.css");
            ScriptLink.Register(Page, "/_layouts/epmlive/modal/modal.js", false);


            SPRibbon ribbon = SPRibbon.GetCurrent(this.Page);

            RegisterArchiveRestoreFormButtons(Web, List, ListItem, ribbon);

            ribbon.TrimById("Ribbon.ListForm.Display.Manage.EditItem");

            XmlDocument ribbonExtensions = new XmlDocument();


            if (NavigationService.LPPFEPermissionCheck(List, SPBasePermissions.EditListItems))
            {
                ribbonExtensions.LoadXml(@"<Button
                    Id=""Ribbon.ListForm.Display.Manage.EditItem2""
                    Sequence=""10""
                    Command=""Ribbon.ListForm.Display.Manage.EditItem2""
                    Image16by16=""/_layouts/" + Web.Language + @"/images/formatmap16x16.png"" Image16by16Top=""-128"" Image16by16Left=""-224""
                    Image32by32=""/_layouts/" + Web.Language + @"/images/formatmap32x32.png"" Image32by32Top=""-128"" Image32by32Left=""-96""
                    LabelText=""Edit Item""
                    TemplateAlias=""o1""/>");

                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
            }

            if (!NavigationService.LPPFEPermissionCheck(List, SPBasePermissions.DeleteListItems))
            {
                ribbon.TrimById("Ribbon.ListForm.Display.Manage.DeleteItem");
            }

            EPMLiveCore.GridGanttSettings gSettings = API.ListCommands.GetGridGanttSettings(List);

            ArrayList arrAssoc = API.ListCommands.GetAssociatedLists(List);

            if (gSettings.AssociatedItems)
            {
                StringBuilder sbLists = new StringBuilder();

                foreach (EPMLiveCore.API.AssociatedListInfo ali in arrAssoc)
                {
                    //sbLists.Append("<Button Id=\"Ribbon.ListForm.Display.Manage.LinkedItemsButton\" Sequence=\"20\" Command=\"");
                    sbLists.Append("<Button Sequence=\"20\" Command=\"");
                    sbLists.Append("Ribbon.ListForm.Display.Associated.LinkedItemsButton");
                    sbLists.Append("\" Id=\"Ribbon.ListForm.Display.Associated.");
                    sbLists.Append(HttpUtility.HtmlEncode(ali.Title));
                    sbLists.Append(".");
                    sbLists.Append(ali.LinkedField);
                    sbLists.Append("\" LabelText=\"");
                    sbLists.Append(HttpUtility.HtmlEncode(ali.Title));
                    sbLists.Append("\" TemplateAlias=\"o1\" Image16by16=\"");
                    sbLists.Append(ali.icon);
                    sbLists.Append("\"/>");
                }


                if (sbLists.Length > 0)
                {

                    StringBuilder sbLinkedItems = new StringBuilder();

                    sbLinkedItems.Append("<Group Id=\"Ribbon.ListForm.Display.Associated\" Sequence=\"41\" Command=\"Ribbon.ListForm.Display.Associated.LinkedItems\" Description=\"\" Title=\"Associated Items\" Template=\"Ribbon.Templates.Flexible2\">");
                    sbLinkedItems.Append("<Controls Id=\"Ribbon.ListForm.Display.Associated.Controls\">");

                    sbLinkedItems.Append(sbLists);

                    sbLinkedItems.Append("</Controls>");
                    sbLinkedItems.Append("</Group>");

                    ribbonExtensions = new XmlDocument();
                    ribbonExtensions.LoadXml(sbLinkedItems.ToString());
                    ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Groups._children");

                    ribbonExtensions = new XmlDocument();
                    ribbonExtensions.LoadXml("<MaxSize Id=\"Ribbon.ListForm.Display.Associated.MaxSize\" Sequence=\"10\" GroupId=\"Ribbon.ListForm.Display.Associated\" Size=\"MediumMedium\" />");
                    ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Scaling._children");




                    //StringBuilder sbLinkedItems = new StringBuilder();
                    //sbLinkedItems.Append("<FlyoutAnchor Id=\"Ribbon.ListForm.Display.Manage.LinkedItems\" Sequence=\"39\" Command=\"");
                    //sbLinkedItems.Append("Ribbon.ListForm.Display.Manage.LinkedItems");
                    //sbLinkedItems.Append("\" Image32by32=\"/_layouts/epmlive/images/linkeditems.gif\" LabelText=\"Associated Items\" TemplateAlias=\"o1\">");
                    //sbLinkedItems.Append("<Menu Id=\"Ribbon.List.EPMLive.LinkedItems.Menu\">");
                    //sbLinkedItems.Append("<MenuSection Id=\"Ribbon.List.EPMLive.LinkedItems.Menu.Scope\" Sequence=\"10\" DisplayMode=\"Menu16\">");
                    //sbLinkedItems.Append("<Controls Id=\"Ribbon.List.EPMLive.LinkedItems.Menu.Scope.Controls\">");
                    //sbLinkedItems.Append(sbLists);
                    //sbLinkedItems.Append("</Controls>");
                    //sbLinkedItems.Append("</MenuSection>");
                    //sbLinkedItems.Append("</Menu>");
                    //sbLinkedItems.Append("</FlyoutAnchor>");


                    //ribbonExtensions.LoadXml(sbLinkedItems.ToString());

                    //ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                    //"Ribbon.ListForm.Display.Manage.Controls._children");
                }
            }
            //======================Planner==================

            API.ListPlannerProps p = API.ListCommands.GetListPlannerInfo(List);

            if (p.PlannerV2Menu != "")
            {
                ribbonExtensions.LoadXml(p.PlannerV2Menu.Replace("EPMLivePlanner", "Ribbon.ListForm.Display.Manage.EPMLivePlanner").Replace("TaskPlanner", "Ribbon.ListForm.Display.Manage.TaskPlanner"));

                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.ListForm.Display.Manage.Controls._children");


                //if(bPlanner == 1)
                //{
                //    EPMLiveWorkPlanner.WorkPlannerAPI.PlannerProps props = EPMLiveWorkPlanner.WorkPlannerAPI.getSettings(Web, sPlannerID);
                //    bUseTeam = props.bUseTeam;
                //    ribbonExtensions.LoadXml("<Button Id=\"Ribbon.ListItem.EPMLive.BuildTeam\" Sequence=\"41\" Command=\"Ribbon.ListForm.Display.Manage.BuildTeam\" LabelText=\"Build Team\" TemplateAlias=\"o1\" Image32by32=\"/_layouts/epmlive/images/editteam32.gif\"/>");

                //    ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
                //}
            }

            //=====================Create Workspace===========

            if (gSettings.EnableRequests)
            {
                string childitem = "";
                try
                {
                    childitem = ListItem["WorkspaceUrl"].ToString();
                }
                catch { }

                if ((ListItem.ModerationInformation == null || ListItem.ModerationInformation.Status == SPModerationStatusType.Approved) && childitem == "")
                {
                    ribbonExtensions = new XmlDocument();
                    ribbonExtensions.LoadXml("<Button Id=\"Ribbon.ListItem.EPMLive.CreateWorkspace\" Sequence=\"50\" Command=\"Ribbon.ListForm.Display.Manage.CreateWorkspace\" LabelText=\"Create Workspace\" TemplateAlias=\"o2\" Image16by16=\"_layouts/images/epmlivelogosmall.gif\"/>");
                    ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
                }
            }

            //=====================Favorite

            if (Web.Features[new Guid("046f0200-30e5-4545-b00f-c8c73aef9f0e")] != null)
            {
                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml("<Button Id=\"Ribbon.ListItem.EPMLive.FavoriteStatus\" Sequence=\"100\" Command=\"Ribbon.ListForm.Display.Actions.Favorite\" LabelText=\"Favorite\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/star32.png\" Image16by16=\"_layouts/epmlive/images/star16.png\"/>");
                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Actions.Controls._children");

                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml("<Button Id=\"Ribbon.ListItem.EPMLive.FavoriteStatus\" Sequence=\"100\" Command=\"Ribbon.ListForm.Display.Actions.Favorite\" LabelText=\"Favorite\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/star32.png\" Image16by16=\"_layouts/epmlive/images/star16.png\"/>");
                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Edit.Actions.Controls._children");

                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml("<Button Id=\"Ribbon.ListItem.EPMLive.FavoriteStatus\" Sequence=\"100\" Command=\"Ribbon.ListForm.Display.Actions.Favorite\" LabelText=\"Favorite\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/star32.png\" Image16by16=\"_layouts/epmlive/images/star16.png\"/>");
                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.DocLibListForm.Edit.Actions.Controls._children");
            }

            EPMLiveCore.API.RibbonProperties rp = (EPMLiveCore.API.RibbonProperties)EPMLiveCore.Infrastructure.CacheStore.Current.Get("GR-" + Web.CurrentUser.ID, "GridSettings-" + List.ID, () =>
            {
                return EPMLiveCore.API.ListCommands.GetRibbonProps(List);
            }).Value;

            //=====================Build Team===========

            try
            {
                if (rp.bBuildTeam)
                {
                    ribbonExtensions = new XmlDocument();
                    ribbonExtensions.LoadXml("<Button Id=\"Ribbon.ListItem.EPMLive.BuildTeam\" Sequence=\"50\" Command=\"Ribbon.ListForm.Display.Manage.BuildTeam\" LabelText=\"Edit Team\" TemplateAlias=\"o2\" Image16by16=\"_layouts/epmlive/images/buildteam16.gif\"/>");
                    ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
                }
            }
            catch { }
            //==========Go To Workspace=================

            string workspaceurl = "";
            try
            {
                workspaceurl = ListItem["WorkspaceUrl"].ToString();
            }
            catch { }

            if (workspaceurl != "")
            {
                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml("<Button Id=\"Ribbon.ListItem.EPMLive.GoToWorkspace\" Sequence=\"55\" Command=\"Ribbon.ListForm.Display.Manage.GoToWorkspace\" LabelText=\"Go To Workspace\" TemplateAlias=\"o1\" Image32by32=\"_layouts/images/spgraphic.gif\" Image32by32Top=\"7\" Image32by32Left=\"4\"/>");
                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
            }

            //================EPK===================



            if (rp.aEPKButtons.Contains("costs"))
            {
                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml(@"<Button
                    Id=""Ribbon.ListItem.Manage.EPKCosts""
                    Sequence=""101""
                    Command=""Ribbon.ListForm.Display.Manage.EPKCost""
                    Image32by32=""/_layouts/epmlive/images/editcosts.png""
                    LabelText=""Edit Costs""
                    TemplateAlias=""o1""
                    />");

                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
            }

            if (rp.aEPKButtons.Contains("resplan"))
            {
                if (rp.aEPKActivex.Contains("resplan"))
                {
                    ribbonExtensions = new XmlDocument();
                    ribbonExtensions.LoadXml(@"<Button
                        Id=""Ribbon.ListItem.Manage.EPKResourcePlanner""
                        Sequence=""103""
                        Command=""Ribbon.ListForm.Display.Manage.EPKRP""
                        Image32by32=""/_layouts/epmlive/images/ribbon32.png"" Image32by32Top=""-65""
                        LabelText=""Edit Resource Plan""
                        TemplateAlias=""o1""
                        />");

                    ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
                }
                else
                {
                    ribbonExtensions = new XmlDocument();
                    ribbonExtensions.LoadXml(@"<Button
                        Id=""Ribbon.ListItem.Manage.EPKResourcePlanner""
                        Sequence=""103""
                        Command=""Ribbon.ListForm.Display.Manage.EPKRPM""
                        Image16by16=""/_layouts/1033/images/formatmap16x16.png"" Image16by16Top=""-64"" Image16by16Left=""-128""
                        LabelText=""Resource Planner""
                        TemplateAlias=""o2""
                        />");

                    ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
                }
            }

            API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);
            string Errors = "";

            int seq = 130;

            var commands = new List<IRibbonCommand>();

            List<EPMLiveIntegration.IntegrationControl> ics = core.GetItemButtons(ListItem.ParentList.ID, ListItem, out Errors);
            foreach (EPMLiveIntegration.IntegrationControl ic in ics)
            {

                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml(@"<Button
                        Id=""EPMINT." + ic.Control + @"." + (int)ic.Window + @"""
                        Sequence=""" + (seq++).ToString() + @"""
                        Command=""Ribbon.ListForm.Display.Manage.EPMINT""
                        Image32by32=""/_layouts/15/images/" + ic.Image + @"""
                        LabelText=""" + ic.Title + @"""
                        TemplateAlias=""o1""
                        />");

                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");

            }




            //===============================================



            // register the command at the ribbon. Include the callback to the server     // to generate the xml
            //commands.Add(new SPRibbonCommand("Ribbon.ListForm.Display.Manage.EditItem2", "alert('test');", "true"));

            var manager = new SPRibbonScriptManager();

            var methodInfo = typeof(SPRibbonScriptManager).GetMethod("RegisterInitializeFunction", BindingFlags.Instance | BindingFlags.NonPublic);



            methodInfo.Invoke(manager, new object[] { Page, "InitPageComponent", "/_layouts/epmlive/WEDispFormPageComponent.js", false, "WEDispFormPageComponent.PageComponent.initialize()" });


            manager.RegisterGetCommandsFunction(Page, "getGlobalCommands", commands);
            manager.RegisterCommandEnabledFunction(Page, "commandEnabled", commands);
            manager.RegisterHandleCommandFunction(Page, "handleCommand", commands);
        }
    }
}
