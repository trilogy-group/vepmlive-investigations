using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class EditList : LayoutsPageBase
    {
        private DataTable dtFields = new DataTable();
        protected ArrayList arrMenus = new ArrayList();
        protected ArrayList arrNonActiveXs = new ArrayList();
        protected string sListName = "";



        protected void Button1_Click(object sender, EventArgs e)
        {

            SPList oList = Web.Lists[new Guid(Request["List"])];

            string sName = oList.Title.Replace(" ", "");

            if (chkEnable.Checked)
            {

                StringBuilder sb = new StringBuilder();
                foreach (GridViewRow gvr in gvWEToPFE.Rows)
                {
                    if (gvr.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList ddl = (DropDownList)gvr.Cells[1].FindControl("ddlSPField");
                        if (ddl.SelectedValue != "")
                        {
                            sb.Append("|");
                            sb.Append(gvr.Cells[2].Text);
                            sb.Append(",");
                            sb.Append(ddl.SelectedValue);
                            sb.Append(",");
                            sb.Append(2);
                        }
                    }
                }

                foreach (GridViewRow gvr in gvPFEtoWE.Rows)
                {
                    if (gvr.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList ddl = (DropDownList)gvr.Cells[1].FindControl("ddlSPField");
                        if (ddl.SelectedValue != "")
                        {
                            sb.Append("|");
                            sb.Append(gvr.Cells[2].Text);
                            sb.Append(",");
                            sb.Append(ddl.SelectedValue);
                            sb.Append(",");
                            sb.Append(1);
                        }
                    }
                }

                string sWorkLists = "";

                foreach (ListItem li in chkWorkLists.Items)
                {
                    if (li.Selected)
                    {
                        sWorkLists += "|" + li.Value;
                    }
                }

                string snonactivex = "";
                try
                {
                    snonactivex = Request["nonactivexs"].ToString();
                }catch{}

                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_worklists", sWorkLists.Trim('|'));
                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_fields", sb.ToString().Trim('|'));
                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_menus", Request["ribbons"].Replace(",", "|"));
                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_nonactivexs", snonactivex.Replace(",", "|"));
                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_costview", dllCostView.SelectedValue);

                if (oList != null)
                {
                    Guid job = EPMLiveCore.API.Timer.AddTimerJob(Web.Site.ID, Web.ID, oList.ID, "Install Work Events", 80, "", "", 0, 9, "");
                    EPMLiveCore.API.Timer.Enqueue(job, 0, Web.Site);
                }

                try
                {
                    ArrayList arrLists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "epklists").Split(','));

                    try
                    {
                        if (!arrLists.Contains(oList.Title))
                            arrLists.Add(oList.Title);
                    }
                    catch { }

                    EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epklists", String.Join(",", (string[])arrLists.ToArray(typeof(string))));
                }
                catch { }

                
            }
            else
            {
                ArrayList arrLists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "epklists").Split(','));

                try
                {
                    arrLists.Remove(oList.Title);
                }
                catch { }



                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_worklists", "");
                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_fields", "");
                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_menus", "");
                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_nonactivexs", "");
                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epk" + sName + "_costview", "");

                EPMLiveCore.CoreFunctions.setConfigSetting(Web.Site.RootWeb, "epklists", String.Join(",", (string[])arrLists.ToArray(typeof(string))));
            }

            EPMLiveCore.Infrastructure.CacheStore.Current.RemoveCategory("GridSettings-" + oList.ID);

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("listedit.aspx?List=" + Request["List"], Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);

            
        }

        public override string PageToRedirectOnCancel
        {
            get
            {
                return ((Web.ServerRelativeUrl == "/") ? "" : Web.ServerRelativeUrl) + "/_layouts/listedit.aspx?List=" + Request["List"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //string sName = "";
                //if(!string.IsNullOrEmpty(Request["name"]))
                //    sName = Request["name"];
                SPList list = Web.Lists[new Guid(Request["List"])];

                sListName = list.Title;

                if(!IsPostBack)
                {
                    using(var site = new SPSite(Web.Site.ID))
                    {
                        SPWeb rootWeb = site.RootWeb;

                        string username = ConfigFunctions.GetCleanUsername(Web);

                        dtFields.Columns.Add("internalname");
                        dtFields.Columns.Add("displayname");
                        dtFields.Rows.Add(new object[] { "", "--- Select Field ---" });

                        if(list != null)
                        {
                            foreach(SPField field in list.Fields)
                            {
                                if(field.Reorderable && !field.Hidden)
                                {
                                    dtFields.Rows.Add(new object[] { field.InternalName, field.Title });
                                }
                            }
                        }

                        ArrayList arrLists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epklists").Split(','));

                        if(arrLists.Contains(sListName))
                            chkEnable.Checked = true;

                        string basePath = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                        string ppmId = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                        string ppmCompany = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                        string ppmDbConn = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

                        PortfolioEngineCore.WEIntegration.WEIntegration we = new PortfolioEngineCore.WEIntegration.WEIntegration(basePath, username, ppmId, ppmCompany, ppmDbConn, false);

                        gvPFEtoWE.DataSource = loadPFEFields(1, rootWeb, we);
                        gvPFEtoWE.DataBind();
                        gvPFEtoWE.Columns[2].Visible = false;


                        gvWEToPFE.DataSource = loadPFEFields(2, rootWeb, we);
                        gvWEToPFE.DataBind();
                        gvWEToPFE.Columns[2].Visible = false;

                        string menus = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epk" + sListName.Replace(" ", "") + "_menus");

                        if(menus == "")
                        {
                            menus = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkmenus");
                        }

                        arrMenus = new ArrayList(menus.Split('|'));


                        string nonactive = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epk" + sListName.Replace(" ", "") + "_nonactivexs");

                        if(nonactive == "")
                        {
                            nonactive = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epknonactivexs");
                        }

                        arrNonActiveXs = new ArrayList(nonactive.Split('|'));

                        dllCostView.DataSource = we.GetPfeCostViews();
                        dllCostView.DataValueField = "costViewId";
                        dllCostView.DataTextField = "costView";
                        dllCostView.DataBind();

                        try
                        {
                            dllCostView.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epk" + sListName.Replace(" ", "") + "_costview");
                        }
                        catch { }

                        LoadWorkLists(rootWeb, list);
                    }


                }
                else
                {
                    if(Request["ribbons"] != null)
                        arrMenus = new ArrayList(Request["ribbons"].Split(','));
                    if(Request["nonactivexs"] != null)
                        arrNonActiveXs = new ArrayList(Request["nonactivexs"].Split(','));
                }

                if(chkEnable.Checked)
                {
                    sectionFieldMapping.Visible = true;
                    sectionTotalFields.Visible = true;
                    sectionControls.Visible = true;
                    sectionCostView.Visible = true;
                    sectionWorkLists.Visible = true;
                }
                else
                {
                    sectionFieldMapping.Visible = false;
                    sectionTotalFields.Visible = false;
                    sectionControls.Visible = false;
                    sectionCostView.Visible = false;
                    sectionWorkLists.Visible = false;
                }
            }
            catch(Exception ex) {
                pnlMain.Visible = false;
                lblError.Text = "Error: " + ex.Message;
            }
        }

        private void LoadWorkLists(SPWeb rootWeb, SPList oProjectList)
        {

            ArrayList worklists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epk" + sListName.Replace(" ", "") + "_worklists").Split('|'));

            
            if(oProjectList != null)
            {
                foreach(SPList oList in rootWeb.Lists)
                {
                    if(!oList.Hidden)
                    {
                        EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(oList);
                        if(gSettings.EnableWorkList)
                        {
                            foreach(SPField field in oList.Fields)
                            {
                                if(field.Type == SPFieldType.Lookup)
                                {
                                    SPFieldLookup lp = (SPFieldLookup)field;
                                    try
                                    {
                                        if(new Guid(lp.LookupList) == oProjectList.ID)
                                        {
                                            ListItem li = new ListItem();
                                            li.Text = oList.Title;
                                            li.Value = oList.Title;
                                            if(worklists.Contains(oList.Title))
                                                li.Selected = true;
                                            chkWorkLists.Items.Add(li);
                                            break;
                                        }
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }

            }
        }

        private DataTable loadPFEFields(int type, SPWeb rootWeb, PortfolioEngineCore.WEIntegration.WEIntegration we)
        {
            DataTable dt = we.GetPfeFields(type);
            dt.Columns.Add("spField");
            //TODO: set mapped field;

            string fields = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epk" + sListName.Replace(" ", "") + "_fields");

            if(fields == "")
            {
                fields = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkportfoliofields");
            }

            string []sFields = fields.Split('|');

            foreach(string sField in sFields)
            {
                try
                {
                    string[] sFieldInfo = sField.Split(',');
                    if(sFieldInfo[2] == type.ToString())
                    {
                        DataRow[] drs = dt.Select("epkFieldId = '" + sFieldInfo[0] + "'");
                        if(drs.Length > 0)
                        {
                            drs[0]["spField"] = sFieldInfo[1];
                        }
                    }
                }
                catch { }
            }

            return dt;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.Cells[1].FindControl("ddlSPField");
                ddl.DataSource = dtFields.DefaultView;
                ddl.DataTextField = "displayname";
                ddl.DataValueField = "internalname";
                ddl.DataBind();

                string sField = ((DataRowView)e.Row.DataItem).Row["spField"].ToString();
                if(sField != "")
                {
                    ddl.SelectedValue = sField;
                }
            }
        }
    }
}
