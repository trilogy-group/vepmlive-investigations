using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class PlannerAdmin : LayoutsPageBase
    {
        protected string settingsurl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            Guid lWeb = web.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    using(SPWeb w = site.OpenWeb(web.ID))
                    {
                        lWeb = EPMLiveCore.CoreFunctions.getLockedWeb(web);
                    }
                }
            });
            

            if(lWeb != web.ID)
            {
                using(SPWeb w = web.Site.OpenWeb(lWeb))
                {
                    pnlAdmin.Visible = true;
                    hlAdmin.NavigateUrl = ((w.ServerRelativeUrl =="/") ? "" : w.ServerRelativeUrl) + "/_layouts/epmlive/planneradmin.aspx";
                    pnlMain.Visible = false;
                }
            }
            else
            {
                MenuTemplate propertyNameListMenu = new MenuTemplate();

                propertyNameListMenu.ID = "PropertyNameListMenu";

                MenuItemTemplate testMenu = new MenuItemTemplate("Edit Planner", "/_layouts/images/edit.gif");

                testMenu.ClientOnClickNavigateUrl = "editplanner.aspx?name=%NAME%";

                propertyNameListMenu.Controls.Add(testMenu);

                MenuItemTemplate testMenu2 = new MenuItemTemplate("Delete Planner", "/_layouts/images/delete.gif");

                testMenu2.ClientOnClickScript = "DeletePlanner('%NAME%');";


                propertyNameListMenu.Controls.Add(testMenu2);

                this.Controls.Add(propertyNameListMenu);

                if(!String.IsNullOrEmpty(Request["Delete"]))
                {
                    DeletePlanner(web);
                }

                string planners = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlannerPlanners");

                DataTable dt = new DataTable();
                dt.Columns.Add("planname");
                dt.Columns.Add("planinternalname");
                dt.Columns.Add("projectlist");
                dt.Columns.Add("tasklist");

                foreach(string planner in planners.Split(','))
                {
                    if(!String.IsNullOrEmpty(planner))
                    {
                        string[] sPlanner = planner.Split('|');
                        string tc = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "TaskCenter");
                        string pc = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlanner" + sPlanner[0] + "ProjectCenter");

                        dt.Rows.Add(new string[] { sPlanner[1], sPlanner[0], pc, tc });
                    }
                }

                gvPlans.DataSource = dt;
                gvPlans.DataBind();
                //EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWorkPlannerFields", wps.ToString());
                //EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWPProjectCenter", ddlProjectCenter.SelectedValue);
                //EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWPTaskCenter", ddlTaskCenter.SelectedValue);
                //EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWPEnable", chkEnableWP.Checked.ToString());
                //EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWPUseResPool", chkWPResPool.Checked.ToString());
            }

            if(!String.IsNullOrEmpty(Request["Source"]))
            {
                settingsurl = Request["Source"];
            }
            else
            {
                settingsurl = "settings.aspx";
            }
        }

        protected void DeletePlanner(SPWeb web)
        {
            string planners = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLivePlannerPlanners");
            web.AllowUnsafeUpdates = true;
            string newPlanners = "";

            foreach(string planner in planners.Split(','))
            {
                if(!String.IsNullOrEmpty(planner))
                {
                    string[] sPlanner = planner.Split('|');
                    if(sPlanner[0] == Request["delete"])
                    {
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + Request["delete"] + "Fields", "");
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + Request["delete"] + "ProjectCenter", "");
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + Request["delete"] + "TaskCenter", "");
                        EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlanner" + Request["delete"] + "UseFolders", "");
                    }
                    else
                    {
                        newPlanners += "," + planner;
                    }
                }
            }
            
            EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLivePlannerPlanners", newPlanners.Trim(','));
            
            string url = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;

            Response.Redirect(url + "/_layouts/epmlive/planneradmin.aspx");
        }
    }
}
