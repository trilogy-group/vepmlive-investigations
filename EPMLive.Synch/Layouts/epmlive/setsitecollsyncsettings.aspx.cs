using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace EPMLiveSynch.Layouts.epmlive
{
    public partial class setsitecollsyncsettings : LayoutsPageBase
    {
        public string strTitle;
        public string strTemplate;
        private SPWeb currWeb;
        protected string sMaxListSyncDate = "";
        private char[] chrPipeSeparator = new char[] { '|' };
        protected SPGridView gvSites;
        protected Button btnSave;
        private string[] arrTemplates;

        public struct ParseInfo
        {
            public string info;
            public Guid siteid;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            try
            {
                if (!IsPostBack)
                {
                    using (SPSite site = SPContext.Current.Site)
                    {
                        using (currWeb = SPContext.Current.Web)
                        {
                            string sLists = "";
                            if (currWeb.Properties.ContainsKey("EPMLiveSynchLists"))
                            {
                                sLists = currWeb.Properties["EPMLiveSynchLists"];
                            }
                            loadSiteCollectionSyncSettingsGrid(site);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        private void loadSiteCollectionSyncSettingsGrid(SPSite site)
        {
            string sGridData = "";
            string sIDs = "";

            if (site.RootWeb.Properties["EPMLiveSiteTemplateIDs"] != null) sIDs = site.RootWeb.Properties["EPMLiveSiteTemplateIDs"].ToString();
            string sTemplatesList = GetTemplateList(site);
            arrTemplates = sTemplatesList.Split('|');

            sGridData = buildSiteCollSyncSettingsData(site, sGridData, sIDs);
            BindSiteListToGrid(sGridData);
        }

        public string GetTemplateList(SPSite site)
        {
            string sTemplatesList = "";
            try
            {
                foreach (SPWeb subWeb in site.AllWebs)
                {
                    if (subWeb.Properties.ContainsKey("EPMLiveTemplateID"))
                    {
                        string sIDs = subWeb.Site.RootWeb.Properties["EPMLiveSiteTemplateIDs"];
                        if (sIDs != null && sIDs.Contains(subWeb.ID.ToString()))
                        {
                            sTemplatesList += "|" + subWeb.Title + "`" + subWeb.ID.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return sTemplatesList;
        }

        private string buildSiteCollSyncSettingsData(SPSite site, string sGridData, string sEPMLiveSiteTemplateIDs)
        {

            foreach (SPWeb subWeb in site.AllWebs)
            {
                try
                {
                    //if (!sEPMLiveSiteTemplateIDs.Contains(subWeb.ID.ToString()))
                    {
                        sGridData += "\t" + subWeb.Title + " (" + subWeb.Url + ")";
                        if (subWeb.Properties.ContainsKey("EPMLiveAllowListSynch"))
                        {
                            bool bIsBool;
                            bool.TryParse(subWeb.Properties["EPMLiveAllowListSynch"], out bIsBool);
                            if (bIsBool)
                            {
                                bool bAllowListSynch = bool.Parse(subWeb.Properties["EPMLiveAllowListSynch"]);
                                sGridData += "`" + bAllowListSynch;
                            }
                            else
                            {
                                sGridData += "`false";
                            }
                        }
                        else
                        {
                            sGridData += "`false";
                        }
                        string sSetTemplate = "";
                        sSetTemplate = "";// GetSetSiteTemplate(subWeb);
                        sGridData += "`" + sSetTemplate;
                        sGridData += "`" + subWeb.ID.ToString();
                    }
                }
                catch { }

                //sGridData = buildSiteCollSyncSettingsData(subWeb, sGridData, sEPMLiveSiteTemplateIDs);
                subWeb.Dispose();
            }
            return sGridData;
        }

        public string GetSetSiteTemplate(SPWeb web)
        {
            string sTemplateName = "No template set.";
            try
            {
                if (web.Properties.ContainsKey("EPMLiveTemplateID"))
                {
                    string sChildSiteTemplateID = web.Properties["EPMLiveTemplateID"].ToString();
                    using (SPSite site = SPContext.Current.Site)
                    {
                        string sTemplateID;
                        foreach (SPWeb subWeb in site.AllWebs)
                        {
                            try
                            {
                                if (subWeb.Properties.ContainsKey("EPMLiveTemplateID"))
                                {
                                    string sIDCheck = subWeb.Properties["EPMLiveTemplateID"].ToString();
                                    if (sChildSiteTemplateID == sIDCheck && web.ID.ToString() != subWeb.ID.ToString())
                                    {
                                        sTemplateID = subWeb.ID.ToString();
                                        string sIDs = web.Site.RootWeb.Properties["EPMLiveSiteTemplateIDs"];
                                        if (sIDs != null && sIDs.Contains(sTemplateID))
                                        {
                                            sTemplateName = subWeb.Title + "|" + subWeb.ID.ToString();
                                            break;
                                        }
                                    }
                                }
                            }
                            catch { }
                            subWeb.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return sTemplateName;
        }

        protected void gvSites_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string sSiteID = DataBinder.Eval(e.Row.DataItem, "SiteID").ToString();

                CheckBox chkAllowSync = (CheckBox)e.Row.FindControl("chkAllowSync");
                string sAllowSync = DataBinder.Eval(e.Row.DataItem, "AllowSync").ToString();
                if (sAllowSync.Trim().ToUpper() == "TRUE")
                {
                    chkAllowSync.Checked = true;
                }
                else
                {
                    chkAllowSync.Checked = false;
                }
                chkAllowSync.Attributes.Add("onclick", "Javascript:noteChange('" + sSiteID + "','allow sync', this.id, this.checked);");

                //<asp:TemplateField headertext="Template" HeaderStyle-HorizontalAlign="center" ControlStyle-Width="300px" >            
                //    <ItemTemplate>
                //        <asp:DropDownList ID="ddlSyncTemplate" runat="server" Width="300px" Style="overflow:hidden" ReadOnly="true" BackColor="Transparent" BorderStyle="None" BorderWidth="0" ></asp:DropDownList>              
                //    </ItemTemplate>        
                //</asp:TemplateField>
                //DropDownList ddlSyncTemplate = (DropDownList)e.Row.FindControl("ddlSyncTemplate");
                //string sSyncTemplate = DataBinder.Eval(e.Row.DataItem, "SyncTemplate").ToString();
                //string[] sSyncTemplateNameIDPair = sSyncTemplate.Split('|');
                //string sSyncTemplateName = "";
                //string sSyncTemplateID = "";
                //if (sSyncTemplateNameIDPair.Length > 1)
                //{
                //    sSyncTemplateName = sSyncTemplateNameIDPair[0];
                //    sSyncTemplateID = sSyncTemplateNameIDPair[1];
                //    ListItem liSyncTemplate = new ListItem(sSyncTemplateName, sSyncTemplateID);
                //    ddlSyncTemplate.Items.Add(liSyncTemplate);
                //}
                //foreach (string sTemplateNameIDPair in arrTemplates)
                //{
                //    string[] sTemplateNameIDPairItems = sTemplateNameIDPair.Split('`');
                //    if (sTemplateNameIDPairItems.Length > 1)
                //    {
                //        if (sTemplateNameIDPairItems[0] != sSyncTemplateName && sTemplateNameIDPairItems[1] != sSyncTemplateID)
                //        {
                //            ListItem li = new ListItem(sTemplateNameIDPairItems[0], sTemplateNameIDPairItems[1]);
                //            ddlSyncTemplate.Items.Add(li);
                //        }
                //    }
                //}
                //ddlSyncTemplate.Attributes.Add("onchange", "Javascript:noteChange('" + sSiteID + "','set template', this.id, this.value);");
            }
        }

        protected void gvSites_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSites.PageIndex = e.NewPageIndex;
            gvSites.DataBind();
        }

        private void BindSiteListToGrid(string sSites)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Site");
            dt.Columns.Add("AllowSync");
            dt.Columns.Add("SyncTemplate");
            dt.Columns.Add("SiteID");
            dt.Columns.Add("RNum");

            string[] arrRow = sSites.Split('\t');
            int rnumCnt = 2; // when rendered, GridView row item count starts at 2
            foreach (string sRow in arrRow)
            {
                if (sRow.Trim() != "")
                {
                    string sSite = "";
                    string sAllowSync = "";
                    string sSyncTemplate = "";
                    string sSiteID = "";

                    string[] sRowItems = sRow.Split('`');
                    if (sRowItems.Length > 0)
                    {
                        sSite = sRowItems[0];
                    }
                    if (sRowItems.Length > 1)
                    {
                        sAllowSync = sRowItems[1];
                    }
                    if (sRowItems.Length > 2)
                    {
                        sSyncTemplate = sRowItems[2];
                    }
                    if (sRowItems.Length > 3)
                    {
                        sSiteID = sRowItems[3];
                    }

                    dt.Rows.Add(new string[] { sSite, sAllowSync, sSyncTemplate, sSiteID, rnumCnt.ToString() });
                    rnumCnt++;
                }
            }
            gvSites.PageIndexChanging += new GridViewPageEventHandler(gvSites_PageIndexChanging);
            gvSites.PagerTemplate = null;
            gvSites.DataSource = dt;
            gvSites.DataBind();

        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ParseInfo info = (ParseInfo)e.Argument;

            string[] arrChangedSettings = info.info.Split('`');

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(info.siteid))
                {
                    for(int i = 0; i < arrChangedSettings.Length; i++)
                    {
                        try
                        {
                            string sSiteID = "";
                            string sChangeType = "";
                            string sCtlVal = "";

                            string[] arrSiteSettings = arrChangedSettings[i].Split(',');
                            if(arrSiteSettings.Length > 0)
                            {
                                sSiteID = arrSiteSettings[0];
                            }
                            if(arrSiteSettings.Length > 1)
                            {
                                sChangeType = arrSiteSettings[1];
                            }
                            if(arrSiteSettings.Length > 2)
                            {
                                sCtlVal = arrSiteSettings[2];
                            }

                            try
                            {
                                Guid siteID = new Guid(sSiteID);
                                using(SPWeb web = site.AllWebs[siteID])
                                {
                                    web.AllowUnsafeUpdates = true;
                                    if(sChangeType == "allow sync")
                                    {
                                        if(web.Properties.ContainsKey("EPMLiveAllowListSynch"))
                                        {
                                            web.Properties["EPMLiveAllowListSynch"] = sCtlVal;
                                        }
                                        else
                                        {
                                            web.Properties.Add("EPMLiveAllowListSynch", sCtlVal);
                                        }
                                    }

                                    //if (sChangeType == "set template")
                                    //{
                                    //    try
                                    //    {
                                    //        Guid tmpltID = new Guid(sCtlVal);
                                    //        using (SPWeb oTmplt = site.AllWebs[tmpltID])
                                    //        {
                                    //            if (oTmplt.Properties.ContainsKey("EPMLiveTemplateID"))
                                    //            {
                                    //                if (web.Properties.ContainsKey("EPMLiveTemplateID"))
                                    //                {
                                    //                    web.Properties["EPMLiveTemplateID"] = oTmplt.Properties["EPMLiveTemplateID"];
                                    //                }
                                    //                else
                                    //                {
                                    //                    web.Properties.Add("EPMLiveTemplateID", oTmplt.Properties["EPMLiveTemplateID"]);
                                    //                }
                                    //            }
                                    //        }
                                    //    }
                                    //    catch { }
                                    //}
                                    web.Properties.Update();
                                    web.AllowUnsafeUpdates = false;
                                }
                            }
                            catch { }
                        }
                        catch { }
                    }
                }
            });
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(SPContext.Current.Web.CurrentUser.IsSiteAdmin)
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = false;
                bw.WorkerSupportsCancellation = false;

                bw.DoWork += bw_DoWork;

                ParseInfo info = new ParseInfo();
                info.info = Request["hdnChangedSettings"];
                info.siteid = SPContext.Current.Site.ID;

                bw.RunWorkerAsync(info);
            }
            else
            {
                Response.Redirect(SPContext.Current.Web.Url + "/_layouts/AccessDenied.aspx");
            }
            
            Response.Redirect(SPContext.Current.Web.Url + "/_layouts/epmlive/templates.aspx");
        }


    }
}
