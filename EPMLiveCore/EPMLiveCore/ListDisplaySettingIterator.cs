using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Linq;
using System.Globalization;
using System.Xml;

namespace EPMLiveCore
{
    public class ListDisplaySettingIterator : ListFieldIterator
    {
        private Dictionary<string, Dictionary<string, string>> fieldProperties = null;
        private SPList list = null;
        private SPControlMode mode = 0;
        private SortedList arrwpFields = new SortedList();
        private bool isResList = false;
        private bool isOnline = false;
        private string lookupField = string.Empty;
        private string lookupValue = string.Empty;

        private Dictionary<string, string> dControls = new Dictionary<string, string>();

        int max = 0;
        int count = 0;
        float width = 0;
        string barcolor = "";
        string ownerusername = "";
        string ownername = "";
        Guid accountid;
        bool isWorkList = true;
        int billingtype = 0;

        GenericEntityEditor picker;

        private bool isFeatureActivated = false;

        private bool DisplayFormRedirect = false;

        private bool bUseTeam = false;

        private int ActivationType = 0;

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (isFeatureActivated)
            {

                if (base.ControlMode == SPControlMode.Edit)
                {
                    SPRibbon ribbon = SPRibbon.GetCurrent(this.Page);

                    ribbon.TrimById("Ribbon.ListForm.Edit.Commit.Publish");
                }
                else if (base.ControlMode == SPControlMode.Display)
                {
                    CssRegistration.Register("/_layouts/epmlive/modal/modal.css");
                    ScriptLink.Register(Page, "/_layouts/epmlive/modal/modal.js", false);


                    SPRibbon ribbon = SPRibbon.GetCurrent(this.Page);

                    ribbon.TrimById("Ribbon.ListForm.Display.Manage.EditItem");

                    XmlDocument ribbonExtensions = new XmlDocument();

                    //WorkPlanner Tab
                    ribbonExtensions.LoadXml(@"<Button
                    Id=""Ribbon.ListForm.Display.Manage.EditItem2""
                    Sequence=""10""
                    Command=""Ribbon.ListForm.Display.Manage.EditItem2""
                    Image16by16=""/_layouts/" + Web.Language + @"/images/formatmap16x16.png"" Image16by16Top=""-128"" Image16by16Left=""-224""
                    Image32by32=""/_layouts/" + Web.Language + @"/images/formatmap32x32.png"" Image32by32Top=""-128"" Image32by32Left=""-96""
                    LabelText=""Edit Item""
                    TemplateAlias=""o1""/>");

                    ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                    "Ribbon.ListForm.Display.Manage.Controls._children");


                    EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

                    if (gSettings.AssociatedItems)
                    {
                        //=======================Lists==================================
                        StringBuilder sbLists = new StringBuilder();
                        SPUser user = SPContext.Current.Web.CurrentUser;
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using (SPSite es = new SPSite(SPContext.Current.Web.Url))
                            {
                                using (SPWeb ew = es.OpenWeb())
                                {
                                    foreach (SPList cList in ew.Lists)
                                    {
                                        if (!cList.DoesUserHavePermissions(user, SPBasePermissions.ViewListItems))
                                        {
                                            continue;
                                        }

                                        foreach (SPField field in cList.Fields)
                                        {
                                            if (field.Type == SPFieldType.Lookup)
                                            {
                                                SPFieldLookup fl = (SPFieldLookup)field;

                                                if (fl.LookupList.ToLower() == "{" + base.List.ID.ToString().ToLower() + "}")
                                                {
                                                    EPMLiveCore.GridGanttSettings gSets = new EPMLiveCore.GridGanttSettings(cList);

                                                    if (gSets.AssociatedItems)
                                                    {
                                                        //sbLists.Append("<Button Id=\"Ribbon.ListForm.Display.Manage.LinkedItemsButton\" Sequence=\"20\" Command=\"");
                                                        sbLists.Append("<Button Sequence=\"20\" Command=\"");
                                                        sbLists.Append("Ribbon.ListForm.Display.Associated.LinkedItemsButton");
                                                        sbLists.Append("\" Id=\"Ribbon.ListForm.Display.Associated.");
                                                        sbLists.Append(HttpUtility.HtmlEncode(cList.Title));
                                                        sbLists.Append(".");
                                                        sbLists.Append(field.InternalName);
                                                        sbLists.Append("\" LabelText=\"");
                                                        sbLists.Append(HttpUtility.HtmlEncode(cList.Title));
                                                        sbLists.Append("\" TemplateAlias=\"o1\" Image16by16=\"");
                                                        sbLists.Append(cList.ImageUrl);
                                                        sbLists.Append("\"/>");
                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        });

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
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {

                        using (SPSite site = new SPSite(Web.Site.ID))
                        {
                            using (SPWeb w = site.OpenWeb(Web.ID))
                            {
                                System.Collections.Generic.Dictionary<string, EPMLiveCore.PlannerDefinition> pList = EPMLiveCore.CoreFunctions.GetPlannerList(Web, ListItem);

                                int bPlanner = 0;
                                string PlannerV2Menu = "";
                                string sPlannerID = "";
                                foreach (System.Collections.Generic.KeyValuePair<string, EPMLiveCore.PlannerDefinition> de in pList)
                                {
                                    string id = (string)de.Key;
                                    EPMLiveCore.PlannerDefinition p = (EPMLiveCore.PlannerDefinition)de.Value;

                                    if (String.Equals(p.command, "ListEPMLivePlanner", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        bPlanner = 1;
                                        break;
                                    }
                                    else if (String.Equals(p.command, "ListEPMLiveTaskPlanner", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        bPlanner = 2;
                                        break;
                                    }
                                }

                                if (bPlanner == 1)
                                {
                                    PlannerV2Menu = "<Button Id=\"Ribbon.ListItem.EPMLive.Planner\" Sequence=\"40\" Command=\"Ribbon.ListForm.Display.Manage.EPMLivePlanner\" LabelText=\"Edit Plan\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/planner32.png\"/>";
                                }

                                else if (bPlanner == 2)
                                {
                                    PlannerV2Menu = "<Button Id=\"Ribbon.ListItem.EPMLive.Planner\" Sequence=\"40\" Command=\"Ribbon.ListForm.Display.Manage.TaskPlanner\" LabelText=\"Edit Plan\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/planner32.png\"/>";
                                }

                                if (PlannerV2Menu != "")
                                {
                                    ribbonExtensions.LoadXml(PlannerV2Menu);

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


                            }
                        }
                    });

                    //=====================Create Workspace===========

                    if (gSettings.EnableRequests)
                    {
                        string childitem = "";
                        try
                        {
                            childitem = ListItem["ChildItem"].ToString();
                        }
                        catch { }

                        if ((ListItem.ModerationInformation == null || ListItem.ModerationInformation.Status == SPModerationStatusType.Approved) && childitem == "")
                        {
                            ribbonExtensions = new XmlDocument();
                            ribbonExtensions.LoadXml("<Button Id=\"Ribbon.ListItem.EPMLive.CreateWorkspace\" Sequence=\"50\" Command=\"Ribbon.ListForm.Display.Manage.CreateWorkspace\" LabelText=\"Create Workspace\" TemplateAlias=\"o1\" Image32by32=\"_layouts/images/epmlivelogo.gif\"/>");
                            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
                        }
                    }


                    //=====================Build Team===========

                    try
                    {
                        if (gSettings.BuildTeam && list.Fields.GetFieldByInternalName("AssignedTo") != null)
                        {
                            if (ListItem.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                            {
                                ribbonExtensions = new XmlDocument();
                                ribbonExtensions.LoadXml("<Button Id=\"Ribbon.ListItem.EPMLive.BuildTeam\" Sequence=\"50\" Command=\"Ribbon.ListForm.Display.Manage.BuildTeam\" LabelText=\"Edit Team\" TemplateAlias=\"o1\" Image32by32=\"_layouts/epmlive/images/buildteam.gif\"/>");
                                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListForm.Display.Manage.Controls._children");
                            }
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

                    if (Web.Site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null)
                    {
                        ArrayList arr = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "EPKLists").ToLower().Split(','));
                        if(arr.Contains(list.Title.ToLower()))
                        {
                            string menus = "";
                            menus = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "EPK" + list.Title.Replace(" ", "") + "_menus");
                            if(menus == "")
                                menus = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "EPKMenus");

                            ArrayList arrButtons = new ArrayList(menus.Split('|'));

                            string noactivex = "";
                            noactivex = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "EPK" + list.Title.Replace(" ", "") + "_nonactivexs");
                            if(noactivex == "")
                                noactivex = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "epknonactivexs");

                            ArrayList arrActivex = new ArrayList(menus.Split('|'));

                            if(arrButtons.Contains("costs"))
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

                            if(arrButtons.Contains("resplan"))
                            {
                                if(arrActivex.Contains("resplan"))
                                {
                                    ribbonExtensions = new XmlDocument();
                                    ribbonExtensions.LoadXml(@"<Button
                                Id=""Ribbon.ListItem.Manage.EPKResourcePlanner""
                                Sequence=""103""
                                Command=""Ribbon.ListForm.Display.Manage.EPKRP""
                                Image32by32=""/_layouts/1033/images/formatmap32x32.png"" Image32by32Top=""-352"" Image32by32Left=""-288""
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
                        }
                    }
                    //===============================================

                    var commands = new List<IRibbonCommand>();

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

        private void FindSaveButtons(Control Parent, ref ArrayList Controls)
        {
            foreach (Control child in Parent.Controls)
            {
                if (child.GetType().ToString() == "Microsoft.SharePoint.WebControls.SaveButton")
                {
                    Controls.Add(child);
                }

                FindSaveButtons(child, ref Controls);
            }
        }

        protected void CustomHandler(object sender, EventArgs e)
        {
            if (SaveButton.SaveItem(SPContext.Current, false, ""))
            {
                RedirectUrl = String.Concat(List.ParentWeb.ServerRelativeUrl, "/", List.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url, @"?ID=", ListItem.ID, @"&Source=", ListItem.ParentList.DefaultViewUrl);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            Guid siteid = SPContext.Current.Site.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(siteid))
                {
                    if (site.Features[new Guid("e97da3cd-4c42-44cd-ba51-2bfbb2c397cb")] != null || site.WebApplication.Features[new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")] != null)
                        isFeatureActivated = true;
                }
            });

            base.OnInit(e);



            if (isFeatureActivated)
            {

                try
                {
                    try
                    {
                        list = SPContext.Current.List;
                    }
                    catch { }

                    GridGanttSettings gSettings = new GridGanttSettings(list);

                    DisplayFormRedirect = gSettings.DisplayFormRedirect;

                    if(DisplayFormRedirect && ControlMode == SPControlMode.New)
                    {
                        SPContext.Current.FormContext.OnSaveHandler += new EventHandler(CustomHandler);
                    }
                    else if(!string.IsNullOrEmpty(Page.Request["Source"]))
                        RedirectUrl = Page.Request["Source"];
                    //string strDisplay = CoreFunctions.getListSetting(List, "DisplaySettings");
                    //string[] strGeneral = CoreFunctions.getListSetting(List, "GeneralSettings").Split('\n');
                    if (gSettings.DisplaySettings != "")
                        fieldProperties = ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);

                    try
                    {
                        isWorkList = gSettings.EnableWorkList;
                    }
                    catch { }

                    if (isWorkList)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "WorkEngineStatusing", "<script type=\"text/javascript\" src=\"/_layouts/epmlive/WorkEngineStatusing.js\">");
                    }


                    if (list == null)
                    {
                        list = SPContext.Current.Web.Lists[new Guid(Page.Request["ListId"])];
                    }

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite rsite = new SPSite(SPContext.Current.Site.ID))
                        {
                            using (SPWeb web = rsite.OpenWeb(SPContext.Current.Web.ID))
                            {
                                arrwpFields = EPMLiveWorkPlanner.PlannerCore.getWorkPlannerStatusFields(web, list.Title);
                            }
                        }
                        try
                        {
                            if (list.Title == "Resources")
                            {
                                isResList = true;
                                SPSite site1 = SPContext.Current.Site;
                                if (site1.WebApplication.Features[new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")] != null)
                                {
                                    isOnline = true;

                                    try
                                    {
                                        SqlConnection cn = null;
                                        SPSecurity.RunWithElevatedPrivileges(delegate()
                                        {
                                            MethodInfo m;

                                            Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                                            Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.Settings", true, true);
                                            m = thisClass.GetMethod("getConnectionString");
                                            string sConn = (string)m.Invoke(null, new object[] { });

                                            cn = new SqlConnection(sConn);
                                            cn.Open();
                                        });

                                        SqlCommand cmd = new SqlCommand("2012SP_GetActivationInfo", cn);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                        cmd.Parameters.AddWithValue("@username", "");

                                        DataSet ds = new DataSet();
                                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                                        da.Fill(ds);

                                        try
                                        {
                                            ActivationType = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                                        }catch{}

                                        if(ActivationType != 3)
                                        {
                                            cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                            cmd.Parameters.AddWithValue("@contractLevel", CoreFunctions.getContractLevel());

                                            SqlDataReader dr = cmd.ExecuteReader();

                                            if(dr.Read())
                                            {
                                                max = dr.GetInt32(0);
                                                count = dr.GetInt32(1);
                                                width = (count * 100) / max;

                                                barcolor = "";

                                                if(width > 100)
                                                    width = 100;

                                                if((max - count) <= 1)
                                                    barcolor = "FF0000";
                                                else if((max - count) < 5)
                                                    barcolor = "FFFF00";
                                                else
                                                    barcolor = "009900";

                                                ownerusername = dr.GetString(13);
                                                ownername = dr.GetString(5);

                                                accountid = dr.GetGuid(2);

                                                billingtype = dr.GetInt32(11);
                                            }
                                            dr.Close();
                                        }
                                        else
                                        {
                                            cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
                                            cmd.Parameters.AddWithValue("@contractLevel", CoreFunctions.getContractLevel());

                                            SqlDataReader dr = cmd.ExecuteReader();

                                            if(dr.Read())
                                            {
                                                ownerusername = dr.GetString(13);
                                                ownername = dr.GetString(5);
                                            }
                                            dr.Close();
                                        }
                                        cn.Close();
                                    }
                                    catch
                                    {
                                        max = 0;
                                    }
                                }
                            }
                        }
                        catch { }
                    });


                    if (SPContext.Current.FormContext.FormMode != SPControlMode.Invalid)
                    {
                        mode = SPContext.Current.FormContext.FormMode;
                    }
                    else
                    {
                        try
                        {
                            mode = (SPControlMode)int.Parse(Page.Request["mode"]);
                        }
                        catch { }
                    }

                }
                catch { }

                if (mode == SPControlMode.New)
                {
                    if (!string.IsNullOrEmpty(Page.Request["LookupField"]))
                    {
                        lookupField = Page.Request["LookupField"];
                    }

                    if (!string.IsNullOrEmpty(Page.Request["LookupValue"]))
                    {
                        lookupValue = Page.Request["LookupValue"];
                    }
                }
            }
        }

        public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
        {
            if (isFeatureActivated)
            {




                if (base.ControlMode == SPControlMode.Display)
                {
                    string editURL = base.List.Forms[PAGETYPE.PAGE_EDITFORM].Url;
                    editURL = ((base.Web.ServerRelativeUrl == "/") ? "" : base.Web.ServerRelativeUrl) + "/" + editURL;
                    string extraParams = "";

                    if (!string.IsNullOrEmpty(Page.Request["IsDlg"]))
                    {
                        extraParams += "&isDlg=" + Page.Request["IsDlg"];
                    }



                    writer.WriteLine("<script language=\"javascript\">");
                    writer.WriteLine("WETitle = \"" + base.ListItem.Title.Replace("\"", "&quot;") + "\";");
                    writer.WriteLine("WEWebUrl = '" + ((base.Web.ServerRelativeUrl == "/") ? "" : base.Web.ServerRelativeUrl) + "';");
                    writer.WriteLine("WEWebId = '" + Web.ID + "';");
                    writer.WriteLine("WEEditForm = '" + editURL + "';");
                    writer.WriteLine("WEExtraParams = '" + extraParams.Trim('&') + "';");
                    writer.WriteLine("WEListId = '" + base.ListId + "';");
                    writer.WriteLine("WEItemId = '" + base.ItemId + "';");
                    writer.WriteLine("WESource = '" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()) + "';");
                    writer.WriteLine("WEUseTeam = " + bUseTeam.ToString().ToLower() + ";");
                    writer.WriteLine("WEDLG = '" + Page.Request["IsDlg"] + "';");
                    writer.WriteLine("</script>");


                    //writer.WriteLine("<script language=\"javascript\">");
                    //writer.WriteLine("initmb();");
                    //writer.WriteLine("</script>");
                }
                //base.RenderControl(writer);
                //if(arrwpFields.Count > 0)
                //    writer.Write("<tr><td colspan='2'><font color=\"#007C17\">*</font> indicates a status field set by the administrator</td></tr>");
                bool outofusers = false;

                #region Online

                bool disablerequests = false;
                try
                {
                    disablerequests = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web, "OnlineDisableResReq"));
                }
                catch { }
                bool isadmin = SPContext.Current.Web.CurrentUser.IsSiteAdmin;
                if(isOnline && isResList)
                {
                    if (!isadmin && !disablerequests)
                    {
                        writer.Write(@"<tr><td colspan='2'>
                        <table cellpadding=""5"" id=""divuCount"" cellspacing=""0"" width=""100%"" bgcolor=""#FFFF76"" style=""border-left-style:solid;border-left-width:1px;border-right: 1px solid #C0C0C0;border-top-style: solid;border-top-width: 1px;border-bottom: 1px solid #C0C0C0;"">
                        <tr>
                        <td>Once you fill out this form the resource will be requested and must be approved by an administrator before the user can login.</td>
                        </tr>
                        </table><br>
                        </td></tr>");
                    }
                    else
                    {
                        if(ActivationType != 3)
                        {
                            if (count >= max && max != -1 && billingtype != 2)
                            {
                                if (EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower() == ownerusername.ToLower())
                                {
                                    writer.Write(@"<tr><td colspan='2'><table cellpadding=""5"" id=""divuCount"" cellspacing=""0"" width=""100%"" bgcolor=""#FFFF76"" style=""border-left-style:solid;border-left-width:1px;border-right: 1px solid #C0C0C0;border-top-style: solid;border-top-width: 1px;border-bottom: 1px solid #C0C0C0;"">
                                    <tr>
                                    <td>You cannot create a new user that has login access because your account limit of " + max + @" has been reached.  Purchasing additional accounts is easy, just click <a href=""" + ((SPContext.Current.Web.ServerRelativeUrl == "/") ? "" : SPContext.Current.Web.ServerRelativeUrl) + @"/_layouts/epmlive/purchase.aspx?accountid=" + accountid + @""">Purchase Accounts</a>.</tr>
                                    </table><br></td></tr>");
                                }
                                else
                                {
                                    writer.Write(@"<tr><td colspan='2'>
                                    <table cellpadding=""5"" id=""divuCount"" cellspacing=""0"" width=""100%"" bgcolor=""#FFFF76"" style=""border-left-style:solid;border-left-width:1px;border-right: 1px solid #C0C0C0;border-top-style: solid;border-top-width: 1px;border-bottom: 1px solid #C0C0C0;"">
                                    <tr>
                                    <td>The account limit of " + max + @" has been reached.  Until the Account Owner (" + ownername + @")
                                    purchases additional accounts, creating user accounts with login access
                                    will be in the form of ""requests"", which you can approve once the owner purchases additional accounts.</td>
                                    </tr>
                                    </table><br>
                                    </td></tr>");
                                }
                                /*writer.Write("<tr><td colspan='2'><table style=\"border:  1px solid #800000\" width=\"400\" id=\"divuCount\">");
                                writer.Write("   <tr>");
                                writer.Write("       <td class=\"ms-toolbar\">");
                                writer.Write("           <strong>User Usage: " + count + " out of " + max + "</strong>");
                                writer.Write("       </td>");
                                writer.Write("   </tr>");
                                writer.Write("   <tr>");
                                writer.Write("       <td class=\"ms-toolbar\" style=\"border:  1px solid #c9c9c9\">");
                                writer.Write("           <table width=\"" + width + "%\" bgcolor=\"#" + barcolor + "\">");
                                writer.Write("               <tr>");
                                writer.Write("                   <td><img src=\"/_layouts/images/blank.gif\" height=\"5\"/></td>");
                                writer.Write("               </tr>");
                                writer.Write("           </table>");
                                writer.Write("       </td>");
                                writer.Write("   </tr>");
                                writer.Write("  </Table><br></td></tr>");*/
                            }
                            else
                            {
                                if (max != -1 && billingtype != 2)
                                {
                                    writer.Write("<tr><td colspan='2'><div id=\"divuCount\">User usage: " + count + " of " + max + "</div></td></tr>");
                                }
                            }
                        }
                    }

                }
                #endregion

                #region processControls
                foreach (System.Web.UI.Control tc in base.Controls)
                {
                    try
                    {
                        if (((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.Type == SPFieldType.Calculated)
                        {
                            //tc.RenderControl(writer);
                            tc.Controls[0].RenderControl(writer);
                            for (int i = 0; i < tc.Controls[1].Controls[0].Controls.Count; i++)
                            {
                                if (tc.Controls[1].Controls[0].Controls[i].GetType().ToString() == "Microsoft.SharePoint.WebControls.FormField")
                                {
                                    string val = ((Microsoft.SharePoint.WebControls.FormField)tc.Controls[1].Controls[0].Controls[i]).ItemFieldValue.ToString();
                                    string sVal = "";
                                    try
                                    {
                                        sVal = ((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.GetFieldValueAsHtml(val);
                                    }
                                    catch { }
                                    if (sVal.ToLower().Contains(".gif") || sVal.ToLower().Contains(".jpg"))
                                        writer.Write("<img src=\"" + SPContext.Current.Web.Url + "/_layouts/images/" + sVal + "\">");
                                    else if (sVal == "")
                                        writer.Write("&nbsp;");
                                    else
                                        writer.Write(sVal);
                                }
                                else
                                    tc.Controls[1].Controls[0].Controls[i].RenderControl(writer);
                            }
                            tc.Controls[2].RenderControl(writer);
                        }
                        else if (((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.Type == SPFieldType.Lookup)
                        {
                            tc.Controls[0].RenderControl(writer);

                            for (int i = 0; i < tc.Controls[1].Controls[0].Controls.Count; i++)
                            {
                                if (tc.Controls[1].Controls[0].Controls[i].GetType().ToString() == "Microsoft.SharePoint.WebControls.FormField")
                                {
                                    // NOTE: tc.Controls[1].Controls[0].Controls[i].Controls[0] is the lookup field,
                                    // so we are clearing the lookup field's child control and inserting our own
                                    foreach (Control c in tc.Controls[1].Controls[0].Controls[i].Controls[0].Controls)
                                    {
                                        if (c is DropDownList)
                                        {
                                            string sVal = ((DropDownList)c).SelectedValue;
                                            SPFieldLookup lookup = ((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field as SPFieldLookup;
                                            //tc.Controls[1].Controls[0].Controls[i].Controls[0].Controls.Add(picker);
                                            //tc.Controls[1].Controls[0].Controls[i].Controls[0].Controls.Add(new TextBox());
                                            break;
                                        }
                                    }
                                }

                                tc.Controls[1].Controls[0].Controls[i].RenderControl(writer);
                            }

                            for (int j = 2; j < tc.Controls.Count; j++)
                            {
                                tc.Controls[j].RenderControl(writer);
                            }

                        }
                        else if (arrwpFields.Contains(((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.InternalName) && (bool)arrwpFields[((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.InternalName])
                        {
                            tc.Controls[0].RenderControl(writer);
                            for (int i = 0; i < tc.Controls[1].Controls[0].Controls.Count; i++)
                            {
                                if (tc.Controls[1].Controls[0].Controls[i].GetType().ToString() == "Microsoft.SharePoint.WebControls.FieldLabel")
                                {
                                    writer.Write(((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.Title + " <font color=\"#007C17\">*</font>");
                                    if (((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.Required)
                                        writer.Write(" <font class=\"ms-formvalidation\">*</font>");
                                }
                                else
                                    tc.Controls[1].Controls[0].Controls[i].RenderControl(writer);
                            }
                            tc.Controls[2].RenderControl(writer);
                        }
                        else
                        {

                            try
                            {
                                if (((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.Type == SPFieldType.Choice)
                                    dControls.Add(((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.InternalName, tc.Controls[1].Controls[0].Controls[9].Controls[0].Controls[0].ClientID);
                                else
                                    dControls.Add(((Microsoft.SharePoint.WebControls.FieldLabel)tc.Controls[1].Controls[0].Controls[1]).Field.InternalName, tc.Controls[1].Controls[0].Controls[9].Controls[0].Controls[0].Controls[1].ClientID);
                            }
                            catch { }

                            tc.RenderControl(writer);
                        }
                    }
                    catch
                    {
                        tc.RenderControl(writer);
                    }
                }
                #endregion

                #region worklist
                if (isWorkList)
                {
                    string pctControl = "";
                    string compControl = "";
                    string statusControl = "";

                    try
                    {
                        pctControl = dControls["PercentComplete"];
                    }
                    catch { }
                    try
                    {
                        compControl = dControls["Complete"];
                    }
                    catch { }
                    try
                    {
                        statusControl = dControls["Status"];
                    }
                    catch { }

                    writer.WriteLine("<script language=\"javascript\">");
                    writer.WriteLine("InitStatusingControls('" + compControl + "', '" + pctControl + "', '" + statusControl + "');");
                    writer.WriteLine("AddFormEvents();");
                    writer.WriteLine("</script>");
                }
                #endregion

                #region ResList
                if (isResList)
                {
                    try
                    {
                        writer.WriteLine("<script language=\"javascript\">");
                        writer.WriteLine("function cleanupfields(){");
                        try
                        {
                            if (outofusers)
                            {

                            }
                            else
                            {
                                if (dControls.ContainsKey("CanLogin"))
                                {
                                    writer.WriteLine("  try{");
                                    try
                                    {
                                        writer.WriteLine("      if(document.getElementById('" + dControls["CanLogin"] + "').checked){");
                                        try
                                        {
                                            writer.WriteLine("          try{document.getElementById('" + dControls["Generic"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                        }
                                        catch { }
                                        try
                                        {
                                            writer.WriteLine("          try{document.getElementById('" + dControls["Generic"] + "').checked = false;}catch(e){}");
                                        }
                                        catch { }
                                        try
                                        {
                                            writer.WriteLine("          try{document.getElementById('" + dControls["Permissions"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                        }
                                        catch { }
                                        try
                                        {
                                            writer.WriteLine("          try{document.getElementById('" + dControls["ResourceLevel"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                        }
                                        catch { }
                                        writer.WriteLine("      try{document.getElementById('divRequest').parentNode.parentNode.style.display='';}catch(e){}");
                                        writer.WriteLine("      try{document.getElementById('divuCount').parentNode.parentNode.style.display='';}catch(e){}");
                                        writer.WriteLine("      }else{");
                                        try
                                        {
                                            writer.WriteLine("          try{document.getElementById('" + dControls["Generic"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                        }
                                        catch { }
                                        try
                                        {
                                            writer.WriteLine("          try{document.getElementById('" + dControls["Permissions"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                        }
                                        catch { }
                                        try
                                        {
                                            writer.WriteLine("          try{document.getElementById('" + dControls["ResourceLevel"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                        }
                                        catch { }
                                        writer.WriteLine("      try{document.getElementById('divRequest').parentNode.parentNode.style.display='none';}catch(e){}");
                                        //writer.WriteLine("      try{document.getElementById('divuCount').parentNode.parentNode.style.display='none';}catch(e){}");
                                        writer.WriteLine("      }");
                                    }
                                    catch { }
                                    writer.WriteLine("  }catch(e){}");
                                }
                            }

                            if (dControls.ContainsKey("Generic"))
                            {
                                writer.WriteLine("  if(document.getElementById('" + dControls["Generic"] + "').checked){");
                                try
                                {
                                    writer.WriteLine("      try{document.getElementById('" + dControls["FirstName"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                }
                                catch { }
                                try
                                {
                                    writer.WriteLine("      try{document.getElementById('" + dControls["LastName"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                }
                                catch { }
                                try
                                {
                                    writer.WriteLine("      try{document.getElementById('" + dControls["Email"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                }
                                catch { }

                                try
                                {
                                    writer.WriteLine("      try{document.getElementById('" + dControls["SharePointAccount"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                }
                                catch { }

                                if (dControls.ContainsKey("FirstName"))
                                {
                                    try
                                    {
                                        writer.WriteLine("      try{document.getElementById('" + dControls["Title"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                    }
                                    catch { }
                                }
                                if (dControls.ContainsKey("Permissions"))
                                {
                                    try
                                    {
                                        writer.WriteLine("          try{document.getElementById('" + dControls["Permissions"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                    }
                                    catch { }
                                }
                                try
                                {
                                    writer.WriteLine("          try{document.getElementById('" + dControls["ResourceLevel"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                }
                                catch { }
                                if (dControls.ContainsKey("CanLogin"))
                                {
                                    try
                                    {
                                        writer.WriteLine("          try{document.getElementById('" + dControls["CanLogin"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                    }
                                    catch { }
                                }
                                writer.WriteLine("  }else{");
                                try
                                {
                                    writer.WriteLine("      try{document.getElementById('" + dControls["FirstName"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                }
                                catch { }
                                try
                                {
                                    writer.WriteLine("      try{document.getElementById('" + dControls["LastName"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                }
                                catch { }
                                try
                                {
                                    writer.WriteLine("      try{document.getElementById('" + dControls["Email"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                }
                                catch { }
                                if (dControls.ContainsKey("FirstName"))
                                {
                                    try
                                    {
                                        writer.WriteLine("      try{document.getElementById('" + dControls["Title"] + "').parentNode.parentNode.parentNode.style.display='none';}catch(e){}");
                                    }
                                    catch { }
                                }
                                try
                                {
                                    writer.WriteLine("      try{document.getElementById('" + dControls["SharePointAccount"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                }
                                catch { }
                                if (dControls.ContainsKey("Permissions"))
                                {
                                    try
                                    {
                                        writer.WriteLine("          try{document.getElementById('" + dControls["Permissions"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                    }
                                    catch { }
                                }
                                try
                                {
                                    writer.WriteLine("          try{document.getElementById('" + dControls["ResourceLevel"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                }
                                catch { }
                                if (dControls.ContainsKey("CanLogin"))
                                {
                                    try
                                    {
                                        writer.WriteLine("          try{document.getElementById('" + dControls["CanLogin"] + "').parentNode.parentNode.parentNode.style.display='';}catch(e){}");
                                    }
                                    catch { }
                                }
                                writer.WriteLine("  }");
                            }
                        }
                        catch { }
                        writer.WriteLine("}");

                        try
                        {
                            writer.WriteLine("document.getElementById('" + dControls["Generic"] + "').onclick = function() {cleanupfields();};");
                        }
                        catch { }
                        try
                        {
                            writer.WriteLine("document.getElementById('" + dControls["CanLogin"] + "').onclick = function() {cleanupfields();};");
                        }
                        catch { }

                        writer.WriteLine("cleanupfields();");

                        if (isOnline)
                        {
                            if(dControls.ContainsKey("Generic"))
                            {
                                writer.WriteLine("function PreSaveAction(){");
                                writer.WriteLine("  if(!document.getElementById('" + dControls["Generic"] + "').checked){");
                                writer.WriteLine("      var f = document.getElementById('" + dControls["FirstName"] + "').value;");
                                writer.WriteLine("      var l = document.getElementById('" + dControls["LastName"] + "').value;");
                                writer.WriteLine("      var e = document.getElementById('" + dControls["Email"] + "').value;");
                                writer.WriteLine("      if(f == \"\" || l == \"\" || e == \"\"){");
                                writer.WriteLine("          alert('You must enter a First Name, Last Name, and Email');return false;");
                                writer.WriteLine("      }else{return true;}");
                                writer.WriteLine("  }else{");
                                writer.WriteLine("      var f = document.getElementById('" + dControls["Title"] + "').value;");
                                writer.WriteLine("      if(f == \"\"){");
                                writer.WriteLine("          alert('You must enter a Display Name');return false;");
                                writer.WriteLine("      }else{return true;}");
                                writer.WriteLine("  }");
                                writer.WriteLine("}");
                            }
                        }

                        writer.WriteLine("</script>");

                    }
                    catch { }
                }

                #endregion
            }
            else
                base.RenderControl(writer);
        }

        protected override void CreateChildControls()
        {
            if (isFeatureActivated)
            {



                try
                {
                    for (int i = 0; i < Fields.Count; i++)
                    {
                        SPField field = Fields[i];
                        if (arrwpFields.Contains(field.InternalName) && mode == SPControlMode.Edit)
                        {
                            if ((bool)arrwpFields[field.InternalName])
                            {
                                TemplateContainer child = new TemplateContainer();
                                Controls.Add(child);

                                SetFieldName(child, field.InternalName);
                                SetControlMode(child, mode);

                                ControlTemplate.InstantiateIn(child);
                            }
                        }
                        else if (!IsFieldExcluded(field))
                        {

                            string editable = "";
                            try
                            {
                                editable = fieldProperties[field.InternalName]["Editable"];
                                editable = editable.Split(";".ToCharArray())[0].ToLower();
                            }
                            catch { }

                            if ((editable == "never" || editable == "where" || field.Type == SPFieldType.Calculated) && mode != SPControlMode.New)
                            {
                                if (editable == "where" && EditableFieldDisplay.canEdit(field, fieldProperties, this.ListItem))
                                {
                                    TemplateContainer child = new TemplateContainer();
                                    Controls.Add(child);

                                    SetFieldName(child, field.InternalName);
                                    SetControlMode(child, mode);

                                    ControlTemplate.InstantiateIn(child);
                                }
                                else
                                {
                                    TemplateContainer child = new TemplateContainer();
                                    Controls.Add(child);

                                    SetFieldName(child, field.InternalName);
                                    SetControlMode(child, SPControlMode.Display);

                                    ControlTemplate.InstantiateIn(child);
                                }
                            }
                            else
                            {
                                TemplateContainer child = new TemplateContainer();
                                Controls.Add(child);

                                SetFieldName(child, field.InternalName);
                                SetControlMode(child, mode);

                                ControlTemplate.InstantiateIn(child);
                            }
                        }
                    }
                }
                catch { }
                // prepopulate lookup fields with query string values
                InsertLookupValueByQueryString();
                // Add EPMLive custom entity picker control to 
                // lookup fields

                AddEntityPickersToLookups();
            }
            else
                base.CreateChildControls();
        }

        private void InsertLookupValueByQueryString()
        {
            if (mode == SPControlMode.New)
            {
                // assume single lookup
                bool valIsMulti = false;
                List<int> ids = new List<int>();
                if (!string.IsNullOrEmpty(this.lookupValue))
                {
                    valIsMulti = (this.lookupValue.IndexOf(',') != -1);
                    if (valIsMulti)
                    {
                        string[] sIds = this.lookupValue.Split(',');
                        foreach (string s in sIds)
                        {
                            if (!string.IsNullOrEmpty(s.Trim()))
                            {
                                ids.Add(int.Parse(s));
                            }
                        }
                    }
                }

                List<FormField> formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
                List<FormField> modCandidates = new List<FormField>();
                foreach (FormField fld in formFields)
                {
                    if (!string.IsNullOrEmpty(lookupField) && fld.Field.InternalName.Equals(lookupField))
                    {
                        modCandidates.Add(fld);
                    }
                }

                for (int index = 0; index < modCandidates.Count; index++)
                {
                    SPField spFld = modCandidates[index].Field;
                    SPFieldLookup lookupFld = modCandidates[index].Field as SPFieldLookup;
                    bool isMulti = lookupFld.AllowMultipleValues;

                    // insert single value to single lookup field
                    if (!isMulti && !valIsMulti)
                    {
                        int itemID = int.Parse(lookupValue.Trim());
                        SPFieldLookupValue lookupVal = new SPFieldLookupValue(itemID, GetLookupItemValue(lookupFld, itemID));
                        this.ListItem[spFld.Id] = lookupVal;
                    }
                    // insert multi lookup value to multi lookup field
                    else if (isMulti && valIsMulti)
                    {
                        SPFieldLookupValueCollection lookupValCol = new SPFieldLookupValueCollection();
                        foreach (int itemID in ids)
                        {
                            SPFieldLookupValue lookupVal = new SPFieldLookupValue(itemID, GetLookupItemValue(lookupFld, itemID));
                            lookupValCol.Add(lookupVal);
                        }
                        this.ListItem[spFld.Id] = lookupValCol;
                    }
                }
            }
        }

        private string GetLookupItemValue(SPFieldLookup lookupFld, int lookupItemID)
        {
            string result = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(lookupFld.LookupWebId))
                    {
                        SPList targetList = ew.Lists[new Guid(lookupFld.LookupList)];
                        SPListItem targetItem = targetList.GetItemById(lookupItemID);
                        result = targetItem[targetList.Fields.GetFieldByInternalName(lookupFld.LookupField).Id].ToString();
                    }
                }
            });

            return result;
        }

        private SPFieldLookupValueCollection GetQueryStringLookupVal(FormField currentFld)
        {
            if (string.IsNullOrEmpty(lookupField) || !currentFld.Field.InternalName.Equals(lookupField))
            {
                return null;
            }

            SPFieldLookupValueCollection result = new SPFieldLookupValueCollection();
            // assume single lookup
            bool valIsMulti = false;
            List<int> ids = new List<int>();
            if (!string.IsNullOrEmpty(this.lookupValue))
            {
                valIsMulti = this.lookupValue.Contains(',');
                if (valIsMulti)
                {
                    string[] sIds = this.lookupValue.Split(',');
                    foreach (string s in sIds)
                    {
                        if (!string.IsNullOrEmpty(s.Trim()))
                        {
                            ids.Add(int.Parse(s));
                        }
                    }
                }
            }

            List<FormField> formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
            List<FormField> modCandidates = new List<FormField>() { currentFld };

            for (int index = 0; index < modCandidates.Count; index++)
            {
                SPField spFld = modCandidates[index].Field;
                SPFieldLookup lookupFld = modCandidates[index].Field as SPFieldLookup;
                bool isMulti = lookupFld.AllowMultipleValues;

                // insert single value to single lookup field
                if (!isMulti && !valIsMulti)
                {
                    int itemId;
                    if (int.TryParse(lookupValue.Trim(), out itemId))
                    {
                        result.Add(new SPFieldLookupValue(itemId, GetLookupItemValue(lookupFld, itemId)));
                    }
                }
                // insert multi lookup value to multi lookup field
                else if (isMulti && valIsMulti)
                {
                    foreach (int id in ids)
                    {
                        result.Add(new SPFieldLookupValue(id, GetLookupItemValue(lookupFld, id)));
                    }
                }
            }

            return result;
        }

        private void AddEntityPickersToLookups()
        {
            if (mode == SPControlMode.New || mode == SPControlMode.Edit)
            {
                // this represents a comma separated list of lookup field internal names to modify
                EnhancedLookupConfigValuesHelper valueHelper = null;
                string unprocessedModCandidates = string.Empty;
                GridGanttSettings gSettings = new GridGanttSettings(this.list);

                try
                {
                    string rawValue = gSettings.Lookups;
                    //string rawValue = "Region^dropdown^none^none^xxx|State^autocomplete^Region^Region^xxx|City^autocomplete^State^State^xxx";                    
                    valueHelper = new EnhancedLookupConfigValuesHelper(rawValue);
                }
                catch { }

                if (valueHelper == null)
                {
                    return;
                }

                List<FormField> formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
                foreach (FormField fld in formFields)
                {
                    bool isEnhanced = valueHelper.ContainsKey(fld.Field.InternalName);
                    bool isParent = valueHelper.IsParentField(fld.Field.InternalName);

                    if (!isEnhanced && !isParent)
                    {
                        continue;
                    }

                    LookupConfigData lookupData = valueHelper.GetFieldData(fld.Field.InternalName);

                    if (isParent && !isEnhanced)
                    {
                        SPFieldLookup lookupFld = fld.Field as SPFieldLookup;
                        Control renderedControl = GetControl(fld);
                        if (!lookupFld.AllowMultipleValues)
                        {
                            CascadingLookupRenderControl ctrl = new CascadingLookupRenderControl();
                            if (lookupData == null)
                            {
                                lookupData = new LookupConfigData();
                                lookupData.IsParent = true;
                            }
                            ctrl.LookupData = lookupData;
                            ctrl.LookupField = lookupFld;

                            string customValue =
                            "<Data>" +
                            "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                            "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                            "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                            "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                            "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                            "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                            "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                            "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                            "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                            "<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
                            GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                            "</Data>";

                            ctrl.CustomProperty = customValue;
                            renderedControl.Parent.Controls.Add(ctrl);
                        }
                    }
                    else if (isParent && isEnhanced)
                    {
                        if (lookupData.Type == "2")
                        {
                            #region INSERT EPMLIVE GENERIC PICKER CONTROL

                            picker = new GenericEntityEditor();
                            SPFieldLookup lookupFld = fld.Field as SPFieldLookup;
                            picker.MultiSelect = lookupFld.AllowMultipleValues;

                            string customValue =
                                "<Data>" +
                                "<Param key=\"SPFieldType\"></Param>" +
                                "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                                "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                                "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                                "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                                "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                                "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                                "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                                "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                                GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                                "<Param key=\"Field\">" + lookupData.Field + "</Param>" +
                                "<Param key=\"ControlType\">" + lookupData.Type + "</Param>" +
                                "<Param key=\"Parent\">" + lookupData.Parent + "</Param>" +
                                "<Param key=\"ParentListField\">" + lookupData.ParentListField + "</Param>" +
                                "<Param key=\"Required\">" + lookupFld.Required.ToString() + "</Param>" +
                                "</Data>";

                            SPFieldLookupValueCollection lookupValCol = null;

                            if (mode == SPControlMode.New)
                            {
                                lookupValCol = GetQueryStringLookupVal(fld);
                            }
                            else
                            {
                                try
                                {
                                    lookupValCol = new SPFieldLookupValueCollection(this.ListItem[lookupFld.Id].ToString());
                                }
                                catch { }
                            }

                            if (lookupValCol != null && lookupValCol.Count > 0)
                            {
                                ArrayList alItems = new ArrayList();
                                PickerEntity entity;
                                foreach (SPFieldLookupValue v in lookupValCol)
                                {
                                    entity = new PickerEntity();
                                    entity.Key = v.LookupId.ToString();
                                    entity.DisplayText = v.LookupValue;
                                    entity.IsResolved = true;
                                    alItems.Add(entity);
                                }
                                picker.UpdateEntities(alItems);
                            }

                            picker.CustomProperty = customValue;
                            Control renderedControl = GetControl(fld);
                            renderedControl.Parent.Controls.Add(picker);

                            #endregion
                        }
                        else if (lookupData.Type == "1")
                        {
                            #region INSERT MODIFIED SP CONTROL

                            SPFieldLookup lookupFld = fld.Field as SPFieldLookup;
                            Control renderedControl = GetControl(fld);
                            if (!lookupFld.AllowMultipleValues)
                            {
                                CascadingLookupRenderControl cclrCtrl = new CascadingLookupRenderControl();
                                cclrCtrl.LookupData = lookupData;
                                cclrCtrl.LookupField = lookupFld;

                                string customValue =
                                "<Data>" +
                                "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                                "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                                "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                                "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                                "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                                "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                                "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                                "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                                "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                                "<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
                                GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                                "</Data>";

                                cclrCtrl.CustomProperty = customValue;
                                renderedControl.Parent.Controls.Add(cclrCtrl);
                            }

                            #endregion
                        }
                    }
                    else if (!isParent && isEnhanced)
                    {
                        if (lookupData.Type == "2")
                        {
                            #region INSERT EPMLIVE GENERIC PICKER CONTROL

                            picker = new GenericEntityEditor();
                            SPFieldLookup lookupFld = fld.Field as SPFieldLookup;
                            picker.MultiSelect = lookupFld.AllowMultipleValues;

                            string customValue =
                                "<Data>" +
                                "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                                "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                                "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                                "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                                "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                                "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                                "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                                "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                                "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                                GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                                "<Param key=\"Field\">" + lookupData.Field + "</Param>" +
                                "<Param key=\"ControlType\">" + lookupData.Type + "</Param>" +
                                "<Param key=\"Parent\">" + lookupData.Parent + "</Param>" +
                                "<Param key=\"ParentListField\">" + lookupData.ParentListField + "</Param>" +
                                "<Param key=\"Required\">" + lookupFld.Required.ToString() + "</Param>" +
                                "</Data>";

                            SPFieldLookupValueCollection lookupValCol = null;

                            if (mode == SPControlMode.New)
                            {
                                lookupValCol = GetQueryStringLookupVal(fld);
                            }
                            else
                            {
                                try
                                {
                                    lookupValCol = new SPFieldLookupValueCollection(this.ListItem[lookupFld.Id].ToString());
                                }
                                catch { }
                            }

                            if (lookupValCol != null && lookupValCol.Count > 0)
                            {
                                ArrayList alItems = new ArrayList();
                                PickerEntity entity;
                                foreach (SPFieldLookupValue v in lookupValCol)
                                {
                                    entity = new PickerEntity();
                                    entity.Key = v.LookupId.ToString();
                                    entity.DisplayText = v.LookupValue;
                                    entity.IsResolved = true;
                                    alItems.Add(entity);
                                }
                                picker.UpdateEntities(alItems);
                            }

                            picker.CustomProperty = customValue;
                            Control renderedControl = GetControl(fld);
                            renderedControl.Parent.Controls.Add(picker);

                            #endregion
                        }
                        else if (lookupData.Type == "1")
                        {
                            #region INSERT MODIFIED SP CONTROL

                            SPFieldLookup lookupFld = fld.Field as SPFieldLookup;
                            Control renderedControl = GetControl(fld);
                            if (!lookupFld.AllowMultipleValues)
                            {
                                CascadingLookupRenderControl cclrCtrl = new CascadingLookupRenderControl();
                                cclrCtrl.LookupData = lookupData;
                                cclrCtrl.LookupField = lookupFld;

                                string customValue =
                                "<Data>" +
                                "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                                "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                                "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                                "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                                "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                                "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                                "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                                "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                                "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                                "<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
                                GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                                "</Data>";

                                cclrCtrl.CustomProperty = customValue;
                                renderedControl.Parent.Controls.Add(cclrCtrl);
                            }
                            else
                            {
                                CascadingMultiLookupRenderControl cclrCtrl = new CascadingMultiLookupRenderControl();
                                cclrCtrl.LookupData = lookupData;
                                cclrCtrl.LookupField = lookupFld;

                                string customValue =
                                "<Data>" +
                                "<Param key=\"SPFieldType\">SPFieldUser</Param>" +
                                "<Param key=\"ParentWebID\">" + lookupFld.ParentList.ParentWeb.ID.ToString() + "</Param>" +
                                "<Param key=\"LookupWebID\">" + lookupFld.LookupWebId.ToString() + "</Param>" +
                                "<Param key=\"LookupListID\">" + lookupFld.LookupList + "</Param>" +
                                "<Param key=\"LookupFieldInternalName\">" + lookupFld.LookupField + "</Param>" +
                                "<Param key=\"LookupFieldID\">" + lookupFld.Id + "</Param>" +
                                "<Param key=\"IsMultiSelect\">" + lookupFld.AllowMultipleValues.ToString() + "</Param>" +
                                "<Param key=\"ListID\">" + this.ListId.ToString() + "</Param>" +
                                "<Param key=\"ItemID\">" + this.ItemId.ToString() + "</Param>" +
                                "<Param key=\"Required\">" + lookupFld.Required + "</Param>" +
                                GenerateControlDataForLookupField(fld, lookupFld.AllowMultipleValues) +
                                "</Data>";

                                cclrCtrl.CustomProperty = customValue;
                                renderedControl.Parent.Controls.Add(cclrCtrl);
                            }

                            #endregion
                        }
                    }


                }
            }
        }

        private string GenerateControlDataForLookupField(FormField sourceFld, bool isMulti)
        {
            StringBuilder sbResult = new StringBuilder();
            // in the case of multi select
            // we need the ids of four controls
            // to post back data
            if (isMulti)
            {
                // need control id for the addbutton, removeButton, selectCandidate, selectResult controls
                sbResult.Append("<Param key=\"SelectCandidateID\">" + sourceFld.Controls[0].Controls[0].Controls[3].ClientID.ToString() + "</Param>" +
                                "<Param key=\"AddButtonID\">" + sourceFld.Controls[0].Controls[0].Controls[5].ClientID.ToString() + "</Param>" +
                                "<Param key=\"RemoveButtonID\">" + sourceFld.Controls[0].Controls[0].Controls[7].ClientID.ToString() + "</Param>" +
                                "<Param key=\"SelectResultID\">" + sourceFld.Controls[0].Controls[0].Controls[9].ClientID.ToString() + "</Param>");

            }
            // in the case of a single select
            // we just need the input or the dropdown
            // controls id to post back data
            else
            {
                sbResult.Append("<Param key=\"SourceDropDownID\">" + sourceFld.Controls[0].Controls[0].ClientID.ToString() + "</Param>");
                sbResult.Append("<Param key=\"SourceControlID\">" + sourceFld.Controls[0].Controls[1].ClientID.ToString() + "</Param>");
            }

            return sbResult.ToString();
        }

        private static Control GetControl(FieldMetadata formField)
        {
            return formField.FindControlRecursive(x => x.GetType() == GetChildControlBasedOnFieldType(formField.Field.FieldRenderingControl));
        }

        private static Type GetChildControlBasedOnFieldType(object field)
        {
            if (field.GetType().Equals(typeof(MultipleLookupField)))
            {
                return typeof(MultipleLookupField);
            }

            if (field.GetType().Equals(typeof(LookupField)))
            {
                return typeof(LookupField);
            }

            return null;
        }

        private static void SetFieldName(TemplateContainer child, string fieldName)
        {
            try
            {
                PropertyInfo property = child.GetType().GetProperty("FieldName", BindingFlags.NonPublic | BindingFlags.Instance);
                property.SetValue(child, fieldName, null);
            }
            catch (Exception) { }
        }

        private static void SetControlMode(TemplateContainer child, SPControlMode controlMode)
        {
            try
            {
                PropertyInfo property = child.GetType().GetProperty("ControlMode", BindingFlags.NonPublic | BindingFlags.Instance);
                property.SetValue(child, controlMode, null);
            }
            catch (Exception) { }
        }

        protected override bool IsFieldExcluded(SPField field)
        {
            if (isFeatureActivated)
            {
                if (isResList)
                {
                    try
                    {
                        switch (field.InternalName)
                        {
                            case "ResourceLevel":
                                if(Web.CurrentUser.IsSiteAdmin || EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower() == ownerusername.ToLower())
                                {
                                    Act act = new Act(Web);
                                    int actType = 0;

                                    ArrayList Levels = act.GetLevelsFromSite(out actType, "");

                                    if(actType > 2)
                                    {
                                        return false;
                                    }
                                    return true;
                                }
                                else
                                    return true;
                            case "Permissions":
                                if (this.mode != SPControlMode.New)
                                {

                                    string generic = "";
                                    try
                                    {
                                        generic = this.ListItem["Generic"].ToString();
                                    }
                                    catch { }
                                    if (generic == "False")
                                        return false;
                                    else
                                        return true;
                                    
                                }
                                return false;
                            case "Title":
                                if (this.mode == SPControlMode.Edit)
                                {
                                    try
                                    {
                                        if (!bool.Parse(this.ListItem["Generic"].ToString()))
                                            return true;
                                    }
                                    catch { }
                                }
                                return false;
                            case "FirstName":
                            case "LastName":
                                if (this.mode == SPControlMode.New)
                                {
                                    return false;
                                }
                                else
                                {
                                    try
                                    {
                                        if (bool.Parse(this.ListItem["Generic"].ToString()))
                                            return true;
                                    }
                                    catch { }
                                }
                                return false;
                            case "Email":
                                if (this.mode == SPControlMode.New)
                                    return false;
                                else
                                    return true;
                            case "CanLogin":
                                return true;
                            case "Generic":
                                if (this.mode == SPControlMode.New)
                                    return false;
                                else
                                    return true;
                            case "Approved":
                                if(field.ParentList.Fields.ContainsFieldWithInternalName("ResourceLevel"))
                                    return true;
                                else
                                {
                                    string approved = "No";
                                    try
                                    {
                                        approved = this.ListItem["Approved"].ToString();
                                    }
                                    catch { }
                                    if(SPContext.Current.Web.UserIsSiteAdmin && approved == "False" && this.mode != SPControlMode.New)
                                        return false;
                                    else
                                        return true;
                                }
                            default:
                                if (isOnline)
                                {
                                    switch (field.InternalName)
                                    {
                                        case "SharePointAccount":
                                            return true;
                                    }
                                }
                                if (!isOnline)
                                {
                                    switch (field.InternalName)
                                    {
                                        case "CanLogin":
                                        case "Email":
                                            return true;
                                    }
                                }
                                break;
                        }
                    }
                    catch { }
                }
                //SPFeature listDisplaySettingFeature = SPContext.Current.Site.Features[new Guid("2EACB61B-4379-46ec-94FA-38B793FDBDD5")];

                //if ((listDisplaySettingFeature != null) && (listDisplaySettingFeature.Definition.Status == Microsoft.SharePoint.Administration.SPObjectStatus.Online))

                {
                    if (fieldProperties != null)
                    {
                        //Dictionary<string, Dictionary<string, string>> fieldProperties = null;
                        //fieldProperties = ListDisplayUtils.ConvertFromString(list.ParentWeb.Properties[String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(list.DefaultView.Url))]);
                        string displaySettings = string.Empty;

                        if (!fieldProperties.ContainsKey(field.InternalName))
                            return base.IsFieldExcluded(field);
                        else
                        {
                            switch (mode)
                            {
                                case SPControlMode.Display:
                                    displaySettings = fieldProperties[field.InternalName]["Display"];
                                    if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                                    {
                                        string where = displaySettings.Split(";".ToCharArray())[1];
                                        string conditionField = "";
                                        string condition = "";
                                        string group = "";
                                        string valueCondition = "";
                                        if (where.Equals("[Me]"))
                                        {
                                            condition = displaySettings.Split(";".ToCharArray())[2];
                                            group = displaySettings.Split(";".ToCharArray())[3];
                                        }
                                        else // [Fielthi
                                        {
                                            conditionField = displaySettings.Split(";".ToCharArray())[2];
                                            condition = displaySettings.Split(";".ToCharArray())[3];
                                            valueCondition = displaySettings.Split(";".ToCharArray())[4];
                                        }
                                        return !EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, this.ListItem);
                                    }
                                    else
                                    {
                                        return base.IsFieldExcluded(field);
                                    }
                                case SPControlMode.Edit:
                                    if (!fieldProperties[field.InternalName].ContainsKey("Edit"))
                                        return base.IsFieldExcluded(field);
                                    displaySettings = fieldProperties[field.InternalName]["Edit"];
                                    if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                                    {
                                        string where = displaySettings.Split(";".ToCharArray())[1];
                                        string conditionField = "";
                                        string condition = "";
                                        string group = "";
                                        string valueCondition = "";
                                        if (where.Equals("[Me]"))
                                        {
                                            condition = displaySettings.Split(";".ToCharArray())[2];
                                            group = displaySettings.Split(";".ToCharArray())[3];
                                        }
                                        else // [Field]
                                        {
                                            conditionField = displaySettings.Split(";".ToCharArray())[2];
                                            condition = displaySettings.Split(";".ToCharArray())[3];
                                            valueCondition = displaySettings.Split(";".ToCharArray())[4];
                                        }
                                        return !EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, this.ListItem);
                                    }
                                    else
                                    {
                                        if (field.Type == SPFieldType.Calculated && displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("always"))
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            return base.IsFieldExcluded(field);
                                        }
                                    }
                                case SPControlMode.New:
                                    if (!fieldProperties[field.InternalName].ContainsKey("New"))
                                        return base.IsFieldExcluded(field);
                                    else
                                    {
                                        displaySettings = fieldProperties[field.InternalName]["New"];
                                        if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                                        {
                                            string where = displaySettings.Split(";".ToCharArray())[1];
                                            string conditionField = "";
                                            string condition = "";
                                            string group = "";
                                            string valueCondition = "";
                                            if (where.Equals("[Me]"))
                                            {
                                                condition = displaySettings.Split(";".ToCharArray())[2];
                                                group = displaySettings.Split(";".ToCharArray())[3];
                                            }
                                            else // [Field]
                                            {
                                                conditionField = displaySettings.Split(";".ToCharArray())[2];
                                                condition = displaySettings.Split(";".ToCharArray())[3];
                                                valueCondition = displaySettings.Split(";".ToCharArray())[4];
                                            }
                                            return !EditableFieldDisplay.RenderField(field, where, conditionField, condition, group, valueCondition, this.ListItem);
                                        }
                                        else
                                        {
                                            return base.IsFieldExcluded(field);
                                        }
                                    }
                                default:
                                    return base.IsFieldExcluded(field);
                            }
                        }
                    }
                    else
                        return base.IsFieldExcluded(field);
                }
                //else
                //{
                //    return base.IsFieldExcluded(field);
                //}
            }
            else
                return base.IsFieldExcluded(field);
        }
    }

    public static class ControlExtensions
    {
        public static Control FindControlRecursive(this Control control, Func<Control, bool> evaluate)
        {
            if (evaluate.Invoke(control))
            {
                return control;
            }

            foreach (Control childControl in control.Controls)
            {
                Control foundControl = FindControlRecursive(childControl, evaluate);
                if (foundControl != null)
                {
                    return foundControl;
                }
            }

            return null;
        }
    }

    public static class ControlCollectionExtensions
    {
        public static void AddAfter(this ControlCollection collection, Control after, Control control)
        {
            int indexFound = -1;
            int currentIndex = 0;
            foreach (Control controlToEvaluate in collection)
            {
                if (controlToEvaluate == after)
                {
                    indexFound = currentIndex;
                    break;
                }

                currentIndex = currentIndex + 1;
            }

            if (indexFound == -1)
            {
                throw new ArgumentOutOfRangeException("control", "Control not found");
            }

            collection.AddAt(indexFound + 1, control);
        }
    }

    public static class ListFieldIteratorExtensions
    {
        public static List<FormField> GetFormFieldByType(this ListFieldIterator listFieldIterator, Type fieldType)
        {
            return GetFormField(listFieldIterator, GetFormFields(listFieldIterator), fieldType);
        }

        public static List<FormField> GetFormField(this ListFieldIterator listFieldITerator, List<FormField> formFields, Type fieldType)
        {
            List<FormField> fields = (from form in formFields
                                      where form.Field.GetType().Equals(fieldType)
                                      select form).ToList<FormField>();

            if (fields == null)
            {
                throw new Exception("Could not find form field type: " + fieldType.ToString());
            }

            return fields;
        }

        public static List<FormField> GetFormFields(this ListFieldIterator listFieldIterator)
        {
            if (listFieldIterator == null)
            {
                return null;
            }

            return FindFieldFormControls(listFieldIterator);
        }

        private static List<FormField> FindFieldFormControls(System.Web.UI.Control root)
        {
            List<FormField> baseFieldControls = new List<FormField>();

            foreach (System.Web.UI.Control control in root.Controls)
            {
                if (control is FormField && control.Visible)
                {
                    FormField formField = control as FormField;
                    if (formField.Field.FieldValueType == typeof(DateTime))
                    {
                        //HandleDateField(formField);
                    }

                    baseFieldControls.Add(formField);
                }
                else
                {
                    baseFieldControls.AddRange(FindFieldFormControls(control));
                }
            }

            return baseFieldControls;
        }

        private static void HandleDateField(FormField formField)
        {
            if (formField.ControlMode == SPControlMode.Display)
            {
                return;
            }

            Control dateFieldControl = formField.Controls[0];
            if (dateFieldControl.Controls.Count > 0)
            {
                DateTimeControl dateTimeControl = (DateTimeControl)dateFieldControl.Controls[0].Controls[1];
                TextBox dateTimeTextBox = dateTimeControl.Controls[0] as TextBox;
                if (dateTimeTextBox != null)
                {
                    if (!string.IsNullOrEmpty(dateTimeTextBox.Text))
                    {
                        formField.Value = DateTime.Parse(dateTimeTextBox.Text, CultureInfo.CurrentCulture);
                    }
                }
            }
        }

    }
}
