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

namespace EPMLiveSynch.Layouts.epmlive
{
    public partial class templates : LayoutsPageBase
    {
        public string strTitle;
        public string strTemplate;
        protected SPGridView gvLists;
        protected ListBox lstTemplates;
        protected DropDownList ddlLists;
        private SPWeb currWeb;
        protected string sMaxListSyncDate = "";
        private char[] chrPipeSeparator = new char[] { '|' };
        protected SPGridView gvSites;
        protected Button btnSave;
        private string[] arrTemplates;
        protected string sSiteUrl;

        protected string siteid;
        protected string webid;

        protected Panel pnlAct;
        protected Panel pnlMain;
        protected Label lblAct;

        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);

            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if (activation != 0)
            {
                pnlMain.Visible = false;
                pnlAct.Visible = true;
                lblAct.Text = act.translateStatus(activation);
                return;
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            try
            {
                string sLists = "";
                using (currWeb = SPContext.Current.Web)
                {
                    if (currWeb.CurrentUser.IsSiteAdmin)
                    {
                        sSiteUrl = (currWeb.ServerRelativeUrl == "/") ? "" : currWeb.ServerRelativeUrl;
                        siteid = currWeb.Site.ID.ToString();
                        webid = currWeb.ID.ToString();
                        //if (!IsPostBack)
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                if (currWeb.Properties.ContainsKey("EPMLiveSynchLists"))
                                {
                                    sLists = currWeb.Properties["EPMLiveSynchLists"];
                                }
                            });

                            ddlLists.Items.Clear();
                            foreach (SPList lst in currWeb.Lists)
                            {
                                if (!lst.Hidden)
                                {
                                    ListItem li = new ListItem(lst.Title, lst.ID.ToString());
                                    if (!sLists.Contains(lst.ID.ToString()))
                                    {
                                        ddlLists.Items.Add(li);
                                    }
                                }
                            }

                            SPList liTemplate = currWeb.Lists.TryGetList("Template Gallery");
                            if(liTemplate != null)
                                pnlTemplates.Visible = false;

                            if (Request["TrnxType"] != null && Request["TrnxType"].ToString() == "clear")
                            {
                                // clear Template ID property 
                                currWeb.AllowUnsafeUpdates = true;

                                currWeb.Properties["EPMLiveTemplateID"] = ""; // clear
                                currWeb.Properties.Update();

                                currWeb.AllowUnsafeUpdates = false;

                                Response.Redirect(currWeb.Url + "/_layouts/epmlive/setsitetemplate.aspx");
                            }
                            else if (Request["TrnxType"] != null && Request["TrnxType"].ToString() == "set")
                            {
                                if (Request["TemplateID"] != null && Request["TemplateID"].ToString().Trim() != "")
                                {
                                    // update Template ID property 
                                    currWeb.AllowUnsafeUpdates = true;

                                    currWeb.Properties["EPMLiveTemplateID"] = Request["TemplateID"].ToString(); // overwrite with new ID
                                    currWeb.Properties.Update();

                                    currWeb.AllowUnsafeUpdates = false;

                                    Response.Redirect(currWeb.Url + "/_layouts/epmlive/setsitetemplate.aspx");
                                }
                            }
                            else if (Request["TrnxType"] != null && Request["TrnxType"].ToString() == "add")
                            {
                                if (Request["List"] != null && Request["List"].ToString().Trim().Length != 0)
                                {
                                    AddList(Request["List"].ToString());
                                    Response.Redirect(currWeb.Url + "/_layouts/epmlive/templates.aspx");
                                }
                                else if (Request["TemplateID"] != null && Request["TemplateID"].ToString().Trim() != "")
                                {
                                    using (SPSite site = SPContext.Current.Site)
                                    {
                                        // add Template ID property 
                                        Guid webGUID = new Guid(Request["TemplateID"].ToString());
                                        using (SPWeb oSelectedWeb = site.AllWebs[webGUID])
                                        {
                                            if (currWeb.ID != oSelectedWeb.ID)
                                            {
                                                oSelectedWeb.AllowUnsafeUpdates = true;

                                                string sGUID = System.Guid.NewGuid().ToString();
                                                if (!oSelectedWeb.Properties.ContainsKey("EPMLiveTemplateID"))
                                                {
                                                    oSelectedWeb.Properties.Add("EPMLiveTemplateID", sGUID);
                                                }
                                                else
                                                {
                                                    oSelectedWeb.Properties["EPMLiveTemplateID"] = sGUID;
                                                }
                                                oSelectedWeb.Properties.Update();

                                                using (SPWeb rootWeb = site.RootWeb)
                                                {
                                                    AddAsSynchedTemplate(rootWeb, Request["TemplateID"].ToString());
                                                }

                                                //SPFeature oFT = null;
                                                //try
                                                //{
                                                //    oFT = oSelectedWeb.Features[new Guid("dfb82bdd-a86c-4314-a0f2-654526c7814e")];
                                                //}
                                                //catch { }
                                                //if (oFT == null)
                                                //{
                                                //    try
                                                //    {
                                                //        oSelectedWeb.Features.Add(new Guid("dfb82bdd-a86c-4314-a0f2-654526c7814e"));
                                                //    }
                                                //    catch { }
                                                //}

                                                oSelectedWeb.AllowUnsafeUpdates = false;
                                            }
                                        }
                                    }

                                    Response.Redirect(currWeb.Url + "/_layouts/epmlive/templates.aspx");
                                }
                            }
                            else if (Request["TrnxType"] != null && Request["TrnxType"].ToString() == "delete")
                            {
                                if (Request["List"] != null && Request["List"].ToString().Trim() != "")
                                {
                                    SPSecurity.RunWithElevatedPrivileges(delegate()
                                    {
                                        DeleteList("|" + Request["List"].ToString());
                                    });
                                }
                                else if (Request["Template"] != null && Request["Template"].ToString().Trim() != "")
                                {
                                    SPSecurity.RunWithElevatedPrivileges(delegate()
                                    {
                                        RemoveTemplate(Request["Template"].ToString());
                                    });
                                }
                                Response.Redirect(currWeb.Url + "/_layouts/epmlive/templates.aspx");
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect(currWeb.Url + "/_layouts/AccessDenied.aspx");
                    }

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        loadListGrid(sLists, currWeb.Site);
                        loadTemplateListBox();
                    });
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        public void AddAsSynchedTemplate(SPWeb rootWeb, string sTemplateID)
        {
            try
            {
                if (rootWeb.Properties.ContainsKey("EPMLiveSiteTemplateIDs"))
                {
                    string sIDs = rootWeb.Properties["EPMLiveSiteTemplateIDs"];
                    rootWeb.AllowUnsafeUpdates = true;
                    rootWeb.Properties["EPMLiveSiteTemplateIDs"] = sIDs + "|" + sTemplateID;
                    rootWeb.Properties.Update();
                    rootWeb.AllowUnsafeUpdates = false;
                }
                else
                {
                    rootWeb.AllowUnsafeUpdates = true;
                    rootWeb.Properties.Add("EPMLiveSiteTemplateIDs", sTemplateID);
                    rootWeb.Properties.Update();
                    rootWeb.AllowUnsafeUpdates = false;
                }
            }
            catch { }
        }

        private void loadListGrid(string sLists, SPSite site)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ListName");
            dt.Columns.Add("EditLink");
            dt.Columns.Add("SyncOptions");
            dt.Columns.Add("DeleteLink");
            dt.Columns.Add("SyncLink");
            dt.Columns.Add("LastSync");
            dt.Columns.Add("Status");
            dt.Columns.Add("Results");
            dt.Columns.Add("ListGuid");
            dt.Columns.Add("Percent");

            int cntFields = 0;
            string[] arrLists = sLists.Split(chrPipeSeparator, StringSplitOptions.RemoveEmptyEntries);

            SqlConnection cn = new SqlConnection();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                cn.ConnectionString = EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id);
                cn.Open();
            });

            foreach (string sListID in arrLists)
            {
                string sListName = "";
                string sListGuid = "";
                string sListEditPageURL = "";
                try
                {
                    SPList lst = currWeb.Lists[new Guid(sListID)];
                    sListName = lst.Title;
                    sListGuid = lst.ID.ToString();
                }
                catch { }
                if (sListGuid.Length != 0)
                {
                    sListEditPageURL = currWeb.Url + "/_layouts/ListEdit.aspx?List={" + sListGuid + "}&Source=" + currWeb.Url + "/_layouts/epmlive/templates.aspx";


                    string sSiteGuid = "";
                    sSiteGuid = currWeb.Site.ID.ToString();
                    string sServerRelativeUrl = currWeb.ServerRelativeUrl;
                    //if (currWeb.ServerRelativeUrl.Trim() == "/")
                    //{
                    //    sServerRelativeUrl = "";
                    //}
                    //else
                    //{
                    //    sServerRelativeUrl = currWeb.ServerRelativeUrl;
                    //}


                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Select timerjobuid,runtime,percentComplete,status,dtfinished,result From vwQueueTimerLog Where listguid=@listguid and jobtype=4";
                    cmd.Parameters.AddWithValue("@listguid", sListGuid);
                    cmd.Connection = cn;
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();

                    string sImg = "";
                    string sLogTime = "";
                    string sLogResult = "";
                    string percent = "0";

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(3))
                        {
                            if (rdr.GetInt32(3) == 0)
                            {
                                sLogResult = "Queued";
                            }
                            else if (rdr.GetInt32(3) == 1)
                            {
                                sLogResult = "Processing";
                                percent = rdr.GetInt32(2).ToString("##0");
                            }
                            else if (!rdr.IsDBNull(5))
                            {
                                sLogResult = rdr.GetString(5);
                                if (sLogResult == "No Errors")
                                    sImg = "<img src=\"/_layouts/images/green.gif\" alt=\"\" >";
                                else
                                    sImg = "<img src=\"/_layouts/images/yellow.gif\" alt=\"\" >";
                            }
                            else
                            {
                                sLogResult = "No Results";
                            }
                        }

                        if (!rdr.IsDBNull(4))
                            sLogTime = rdr.GetDateTime(4).ToString();
                    }

                    rdr.Close();

                    dt.Rows.Add(new string[] { sListName, sListEditPageURL, "", "", "", sLogTime, sImg, sLogResult, sListGuid, percent });
                    cntFields++;




                    ////bool processing = false;



                    ////if (rdr.Read())
                    ////{
                    ////    if (rdr.GetInt32(0) == 0)
                    ////    {
                    ////        processing = true;
                    ////        sLogResult = "Queued";
                    ////    }
                    ////    else if (rdr.GetInt32(0) == 1)
                    ////    {
                    ////        processing = true;
                    ////        sLogResult = "Processing";
                    ////    }
                    ////    percent = rdr.GetInt32(1).ToString("##0");
                    ////    if (!rdr.IsDBNull(2))
                    ////    {
                    ////        sLogTime = rdr.GetDateTime(2).ToString();
                    ////    }
                    ////}
                    ////rdr.Close();

                    ////if (!processing)
                    ////{
                    ////    cmd = new SqlCommand();
                    ////    cmd.CommandText = "Select result From epmlive_log Where listguid=@listguid and log_type=4";
                    ////    cmd.Parameters.AddWithValue("@listguid", sListGuid);
                    ////    cmd.Connection = cn;
                    ////    rdr = cmd.ExecuteReader();
                    ////    if (rdr.Read())
                    ////    {
                    ////        sLogResult = rdr.GetString(0);
                    ////        if (sLogResult.Contains("No Errors"))
                    ////        {
                    ////            sImg = "<img src=\"/_layouts/images/green.gif\" alt=\"\" >";
                    ////        }
                    ////        else
                    ////        {
                    ////            sImg = "<img src=\"/_layouts/images/yellow.gif\" alt=\"\" >";
                    ////        }
                    ////    }
                    ////    rdr.Close();
                    ////}





                    /*
                    if (rdr.Read())
                    {
                        sLogResult = rdr.GetString(0);
                        sLogTime = rdr.GetDateTime(1).ToLocalTime().ToString();
                        if(!rdr.IsDBNull(2))
                            percent = rdr.GetDouble(2).ToString("##0");
                    }
                    rdr.Close();

                    //if (sLastResults.Length > 0 && sLastResults.IndexOf("Log time:") > 0)
                    //{
                    //    sLogResult = sLastResults.Substring(0, sLastResults.IndexOf("Log time:") - 2);
                    //    sLogTime = sLastResults.Substring(sLastResults.IndexOf("Log time:") + 10);
                    DateTime dtLogTime;
                    if (DateTime.TryParse(sLogTime, out dtLogTime))
                    {
                        if (sMaxListSyncDate == "")
                        {
                            sMaxListSyncDate = dtLogTime.ToString();
                        }
                        else
                        {
                            DateTime dtMaxListSyncDate;
                            if (DateTime.TryParse(sLogTime, out dtLogTime) && DateTime.TryParse(sMaxListSyncDate, out dtMaxListSyncDate))
                            {
                                if (dtLogTime.CompareTo(dtMaxListSyncDate) > 0)
                                {
                                    sMaxListSyncDate = dtLogTime.ToShortDateString() + " " + dtLogTime.ToLongTimeString();
                                }
                            }
                        }
                    }
                    //}

                    
                    
                    if (sLogResult.Contains("Success") || sLogResult == "" || sLogResult.Contains("Processing"))
                    {
                        sImg = "<img src=\"/_layouts/images/green.gif\" alt=\"\" >";
                    }
                    else
                    {
                        sImg = "<img src=\"/_layouts/images/yellow.gif\" alt=\"\" >";
                    }
                    */

                    DateTime dtLogTime;
                    if (DateTime.TryParse(sLogTime, out dtLogTime))
                    {
                        if (sMaxListSyncDate == "")
                        {
                            sMaxListSyncDate = dtLogTime.ToString();
                        }
                        else
                        {
                            DateTime dtMaxListSyncDate;
                            if (DateTime.TryParse(sLogTime, out dtLogTime) && DateTime.TryParse(sMaxListSyncDate, out dtMaxListSyncDate))
                            {
                                if (dtLogTime.CompareTo(dtMaxListSyncDate) > 0)
                                {
                                    sMaxListSyncDate = dtLogTime.ToShortDateString() + " " + dtLogTime.ToLongTimeString();
                                }
                            }
                        }
                    }

                }

            }


            cn.Close();

            //if (cntFields > 0) gvLists.PageSize = cntFields;
            gvLists.DataSource = dt;
            gvLists.DataBind();

        }

        private void loadTemplateListBox()
        {
            try
            {
                using (SPSite site = SPContext.Current.Site)
                {
                    using (SPWeb rootWeb = site.RootWeb)
                    {
                        int iCnt = 0;
                        SPWebTemplateCollection oWebTmpltCol = currWeb.GetAvailableWebTemplates((uint)currWeb.Locale.LCID);
                        foreach (SPWebTemplate otmplt in oWebTmpltCol)
                        {
                            //SPWeb web = site.AllWebs[otmplt.Title];
                            //if (!web.Properties.ContainsKey("EPMLiveTemplateID"))
                            {

                                lstTemplates.Items.Add(otmplt.Title);
                                iCnt++;
                            }
                        }
                        lstTemplates.Height = 16 * iCnt;
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }

        protected void gvLists_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string sSiteGuid = "";
                    sSiteGuid = currWeb.Site.ID.ToString();

                    string sServerRelativeUrl = currWeb.ServerRelativeUrl;
                    //if (currWeb.ServerRelativeUrl.Trim() == "/")
                    //{
                    //    sServerRelativeUrl = "";
                    //}
                    //else
                    //{
                    //    sServerRelativeUrl = currWeb.ServerRelativeUrl;
                    //}
                    string sListName = DataBinder.Eval(e.Row.DataItem, "ListName").ToString();
                    string sListGuid = DataBinder.Eval(e.Row.DataItem, "ListGuid").ToString();
                    string sListEditURL = DataBinder.Eval(e.Row.DataItem, "EditLink").ToString();
                    string sLastSync = DataBinder.Eval(e.Row.DataItem, "LastSync").ToString();
                    string sStatus = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                    string sResults = DataBinder.Eval(e.Row.DataItem, "Results").ToString();
                    string sPercent = DataBinder.Eval(e.Row.DataItem, "Percent").ToString();
                    if (sResults != "Processing" && sResults != "Queued")
                    {
                        e.Row.Cells[1].Text = System.Web.HttpUtility.HtmlDecode("<a href=\"" + sListEditURL + "\" target='_blank'>Edit List</a>");
                        e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[2].Text = System.Web.HttpUtility.HtmlDecode("<a href=\"editfields.aspx?List={" + sListGuid + "} \" >Sync Options</a>");
                        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[3].Text = System.Web.HttpUtility.HtmlDecode("<a href=\"#\" onclick=\"delList('" + sListName + "');return false\" >Remove</a>");
                        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[4].Text = System.Web.HttpUtility.HtmlDecode("<a href=\"#\" onclick=\"syncList('" + sListName + "','" + sListGuid + "');return false\" >Synchronize</a>");
                        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                    }
                    else
                    {
                        e.Row.Cells[1].Text = "";
                    }

                    e.Row.Cells[6].Text = System.Web.HttpUtility.HtmlDecode(sStatus);
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                    if (sResults == "Processing")
                        e.Row.Cells[7].Text = System.Web.HttpUtility.HtmlDecode("Processing (" + sPercent + "%)");
                    else if (sResults == "Queued")
                        e.Row.Cells[7].Text = sResults;
                    else
                        e.Row.Cells[7].Text = System.Web.HttpUtility.HtmlDecode("<a href=\"" + currWeb.Url + "/_layouts/epmlive/viewlogentry.aspx?logaction=synchlist&logsource=" + sListGuid + "\" >" + sResults + "</a>");
                    e.Row.Cells[7].Width = new Unit(500);
                }
            }
            catch { }
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
                chkAllowSync.Attributes.Add("onclick", "Javascript:noteChange('" + sSiteID + "','allow sync', this.id, this.value);");

                DropDownList ddlSyncTemplate = (DropDownList)e.Row.FindControl("ddlSyncTemplate");
                string sSyncTemplate = DataBinder.Eval(e.Row.DataItem, "SyncTemplate").ToString();
                string[] sSyncTemplateNameIDPair = sSyncTemplate.Split('|');
                string sSyncTemplateName = "";
                string sSyncTemplateID = "";
                if (sSyncTemplateNameIDPair.Length > 1)
                {
                    sSyncTemplateName = sSyncTemplateNameIDPair[0];
                    sSyncTemplateID = sSyncTemplateNameIDPair[1];
                    ListItem liSyncTemplate = new ListItem(sSyncTemplateName, sSyncTemplateID);
                    ddlSyncTemplate.Items.Add(liSyncTemplate);
                }
                foreach (string sTemplateNameIDPair in arrTemplates)
                {
                    string[] sTemplateNameIDPairItems = sTemplateNameIDPair.Split('`');
                    if (sTemplateNameIDPairItems.Length > 1)
                    {
                        if (sTemplateNameIDPairItems[0] != sSyncTemplateName && sTemplateNameIDPairItems[1] != sSyncTemplateID)
                        {
                            ListItem li = new ListItem(sTemplateNameIDPairItems[0], sTemplateNameIDPairItems[1]);
                            ddlSyncTemplate.Items.Add(li);
                        }
                    }
                }
                ddlSyncTemplate.Attributes.Add("onchange", "Javascript:noteChange('" + sSiteID + "','set template', this.id, this.value);");
            }
        }

        public void AddList(string sListID)
        {
            try
            {
                using (SPWeb currWeb = SPContext.Current.Web)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        currWeb.AllowUnsafeUpdates = true;
                        if (currWeb.Properties.ContainsKey("EPMLiveSynchLists"))
                        {
                            // property exists already
                            string sCurrLists = currWeb.Properties["EPMLiveSynchLists"];
                            // check if newly added list already is already in it
                            if (!sCurrLists.Contains(sListID))
                            {
                                // update it
                                string sNewVal = currWeb.Properties["EPMLiveSynchLists"] + "|" + sListID;
                                currWeb.Properties["EPMLiveSynchLists"] = sNewVal;
                            }
                        }
                        else
                        {
                            // property doesn't exist -> add it if there is value to set
                            currWeb.Properties.Add("EPMLiveSynchLists", "|" + sListID);
                        }
                        string sListName = currWeb.Lists[new Guid(sListID)].Title;
                        if (currWeb.Properties.ContainsKey("EPMLiveSyncAltListName-" + sListName))
                        {
                            currWeb.Properties["EPMLiveSyncAltListName-" + sListName] = sListName;
                        }
                        else
                        {
                            currWeb.Properties.Add("EPMLiveSyncAltListName-" + sListName, sListName);
                        }

                        currWeb.Properties.Update();
                        currWeb.AllowUnsafeUpdates = false;
                    });
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteList(string sList)
        {
            try
            {
                using (SPWeb currWeb = SPContext.Current.Web)
                {
                    currWeb.AllowUnsafeUpdates = true;
                    string sSynchLists = currWeb.Properties["EPMLiveSynchLists"];
                    SPList oList = currWeb.Lists[sList.Replace("|", "")];
                    string sListID = oList.ID.ToString();
                    string sListName = oList.Title;
                    string sListURL = System.IO.Path.GetDirectoryName(oList.DefaultView.ServerRelativeUrl);
                    if (sSynchLists.Contains(sListID))
                    {
                        int iStart = sSynchLists.IndexOf(sListID);
                        int iPipeLocation = sSynchLists.IndexOf(chrPipeSeparator[0], sSynchLists.IndexOf(sListID));
                        string sNewVal;
                        if (iPipeLocation > 0 && iPipeLocation < (sSynchLists.Length - (sListID.Length))) // has more
                        {
                            sNewVal = sSynchLists.Remove(sSynchLists.IndexOf(sListID), sSynchLists.Substring(sSynchLists.IndexOf(sListID), iPipeLocation - sSynchLists.IndexOf(sListID)).Length);
                        }
                        else // first or last one
                        {
                            sNewVal = sSynchLists.Remove(sSynchLists.IndexOf(sListID)); // remove to the end
                        }
                        currWeb.Properties["EPMLiveSynchLists"] = sNewVal;

                        if (currWeb.Properties.ContainsKey("EPMLiveSyncCreateNew-" + sListURL))
                        {
                            currWeb.Properties["EPMLiveSyncCreateNew-" + sListURL] = null;
                        }
                        if (currWeb.Properties.ContainsKey("EPMLiveSyncAltListName-" + sListURL))
                        {
                            currWeb.Properties["EPMLiveSyncAltListName-" + sListURL] = null;
                        }
                        if (currWeb.Properties.ContainsKey("EPMLiveSyncDescriptionAndNavSettings-" + sListURL))
                        {
                            currWeb.Properties["EPMLiveSyncDescriptionAndNavSettings-" + sListURL] = null;
                        }
                        if (currWeb.Properties.ContainsKey("EPMLiveSyncVersioningSettings-" + sListURL))
                        {
                            currWeb.Properties["EPMLiveSyncVersioningSettings-" + sListURL] = null;
                        }
                        if (currWeb.Properties.ContainsKey("EPMLiveSyncAdvancedSettings-" + sListURL))
                        {
                            currWeb.Properties["EPMLiveSyncAdvancedSettings-" + sListURL] = null;
                        }
                        if (currWeb.Properties.ContainsKey("EPMLiveSyncPermissionsAndMgmtSettings-" + sListURL))
                        {
                            currWeb.Properties["EPMLiveSyncPermissionsAndMgmtSettings-" + sListURL] = null;
                        }
                        if (currWeb.Properties.ContainsKey("EPMLiveSyncGeneralSettings-" + sListURL))
                        {
                            currWeb.Properties["EPMLiveSyncGeneralSettings-" + sListURL] = null;
                        }
                        if (currWeb.Properties.ContainsKey("EPMLiveSyncTotalSettings-" + sListURL))
                        {
                            currWeb.Properties["EPMLiveSyncTotalSettings-" + sListURL] = null;
                        }
                        if (currWeb.Properties.ContainsKey("EPMLiveSyncEditableFieldsSettings-" + sListURL))
                        {
                            currWeb.Properties["EPMLiveSyncEditableFieldsSettings-" + sListURL] = null;
                        }
                        currWeb.Properties.Update();
                        currWeb.Update();
                    }

                    sList = sList.Substring(1); // take out pipe prefix
                    unsealSynchedLists(currWeb, sList);

                    LogHelper logHlpr = new LogHelper();
                    logHlpr.CurrWeb = currWeb;
                    logHlpr.Action = "synchlist";
                    string sServerRelativeUrl = "";
                    if (currWeb.ServerRelativeUrl.Trim() == "/")
                    {
                        sServerRelativeUrl = "";
                    }
                    else
                    {
                        sServerRelativeUrl = currWeb.ServerRelativeUrl;
                    }
                    logHlpr.Source = sServerRelativeUrl + "/Lists/" + sList;
                    string sLastResults = logHlpr.DeleteLastResult();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void RemoveTemplate(string sTemplate)
        {
            SPWeb web = null;
            try
            {
                using (SPSite site = SPContext.Current.Site)
                {
                    web = site.AllWebs[sTemplate];
                }
            }
            catch (Exception ex)
            {
            }

            if (web != null)
            {
                string sWebId = web.ID.ToString();
                using (SPWeb rootWeb = SPContext.Current.Site.RootWeb)
                {
                    if (rootWeb.Properties.ContainsKey("EPMLiveSiteTemplateIDs"))
                    {
                        string sIDs = rootWeb.Properties["EPMLiveSiteTemplateIDs"];
                        rootWeb.AllowUnsafeUpdates = true;

                        if (sIDs.Contains(sWebId))
                        {
                            int iPipeLocation = sIDs.IndexOf("|" + sWebId);
                            if (iPipeLocation > 0 && iPipeLocation < (sIDs.Length - (sWebId.Length))) // has more
                            {
                                sIDs = sIDs.Replace("|" + sWebId, "");
                            }
                            else
                            {
                                sIDs = "";
                            }
                            rootWeb.Properties["EPMLiveSiteTemplateIDs"] = sIDs;
                            rootWeb.Properties.Update();

                            //SPFeature oFT = null;
                            //try
                            //{
                            //    oFT = web.Features[new Guid("dfb82bdd-a86c-4314-a0f2-654526c7814e")];
                            //}
                            //catch { }
                            //if (oFT == null)
                            //{
                            //    try
                            //    {
                            //        web.Features.Remove(new Guid("dfb82bdd-a86c-4314-a0f2-654526c7814e"));
                            //    }
                            //    catch { }
                            //}
                        }

                        LogHelper logHlpr = new LogHelper();
                        logHlpr.Action = "synchtemplate";
                        logHlpr.Source = web.ServerRelativeUrl;
                        string sLastResults = logHlpr.DeleteLastResult();

                        rootWeb.Properties.Update();
                        rootWeb.AllowUnsafeUpdates = false;
                    }
                }
                if (web.Properties.ContainsKey("EPMLiveTemplateID"))
                {
                    web.AllowUnsafeUpdates = true;
                    web.Properties.Remove("EPMLiveTemplateID");
                    web.Properties.Update();
                    web.AllowUnsafeUpdates = false;
                }

                web.Close();
                web.Dispose();
            }
        }

        //public void DeleteTemplate(string sTemplate)
        //{
        //    try
        //    {
        //        using (SPSite site = SPContext.Current.Site)
        //        {
        //            using (SPWeb web = site.AllWebs[sTemplate])
        //            {
        //                web.AllowUnsafeUpdates = true;
        //                web.Delete();
        //            }
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //    }
        //}

        public void unsealSynchedLists(SPWeb oFromWeb, string sListName)
        {
            foreach (SPWeb subWeb in oFromWeb.Site.AllWebs)
            {
                if (oFromWeb.ID != subWeb.ID)
                {
                    try
                    {
                        if (subWeb.Properties.ContainsKey("EPMLiveAllowListSynch"))
                        {
                            bool bAllowListSynch = bool.Parse(subWeb.Properties["EPMLiveAllowListSynch"]);
                            if (bAllowListSynch)
                            {
                                unsealList(subWeb, oFromWeb.Lists[sListName], subWeb.Lists[sListName]);
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
                subWeb.Close();
                subWeb.Dispose();
            }
        }

        private void unsealList(SPWeb oWeb, SPList oTemplateList, SPList oSubList)
        {
            try
            {
                if (oWeb != null && oSubList != null)
                {
                    oWeb.AllowUnsafeUpdates = true;
                    string[] arrFlds = new string[oSubList.Fields.Count];
                    int iCnt = 0;
                    foreach (SPField fld in oSubList.Fields)
                    {
                        if (fld.Type != SPFieldType.Attachments && fld.InternalName != "Order" && fld.Type != SPFieldType.File && fld.InternalName != "MetaInfo")
                        {
                            arrFlds[iCnt] = fld.Title;
                            iCnt++;
                        }
                    }

                    for (int i = 0; i < iCnt + 1; i++)
                    {
                        try
                        {
                            SPField fld = oSubList.Fields[arrFlds[i]];
                            if (fld != null)
                            {
                                try
                                {
                                    if (fld.Sealed) fld.Sealed = false;
                                    fld.AllowDeletion = true;
                                    fld.Update();
                                }
                                catch (Exception ex) { }
                            }
                        }
                        catch (Exception e) { }
                    }
                    oWeb.Update();
                    oWeb.AllowUnsafeUpdates = false;
                }
            }
            catch (Exception exc)
            {
            }
        }

    }
}
