using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Xml;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TimeSheets
{
    [ToolboxData("<{0}:MyTimesheet runat=server></{0}:MyTimesheet>")]
    [Guid("8A88ACAE-8991-4EBD-8D39-DA39769FBA88")]
    [XmlRoot(Namespace = "MyTimesheet")]
    public class MyTimesheet : Microsoft.SharePoint.WebPartPages.WebPart, IWebPartPageComponentProvider
    {
        private const string InitialTabId = "Ribbon.MyTimesheetTab";
        string sFullGridId;
        private string sDataParam = "";
        private string sLayoutParam = "";
        private string sPeriodId = "";
        private string sPeriodName = "";
        private string sPeriodList = "";
        private int TSColType = 1;
        private string TSNotes = "false";
        private string TSTypeObject = "";
        private string TSCols = "";
        private string TSDCols = "";
        private bool bIsCurrentTimesheetPeriod = false;
        private int iCurPeriodId = 0;
        private string sCurPeriodName = "";
        private bool bTsLocked = false;
        private string sStatus = "Unsubmitted";
        private string sDelegates = "";
        private string sUserId = "";
        private string sCurrentDelegate = "";
        private int iEditable = 1;
        private TimesheetSettings settings;

        private int iNextPeriod = 0;
        private int iPreviousPeriod = 0;

        EPMLiveCore.API.ViewManager views;
        private string sCurrentView = "";
        private string sCurrentViewId = "";
        private EPMLiveCore.Act act;
        int activation = 0;
        bool bHasPeriods = false;
        bool bCanEditViews = false;


        private EPMLiveCore.TimeDebug tb;

        int GridType = 0;

        protected override void CreateChildControls()
        {
            tb.AddTimer();
            act = new EPMLiveCore.Act(SPContext.Current.Web);
            activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.Timesheets);

            if (activation != 0)
                return;

            if (SPContext.Current.ViewContext.View != null)
            {
                try
                {
                    typeof(ListTitleViewSelectorMenu).GetField("m_wpSingleInit", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Page.FindControl("ctl00$PlaceHolderPageTitleInTitleArea$ctl01$ctl00").Controls[1], true);
                }
                catch { }
                try
                {
                    typeof(ListTitleViewSelectorMenu).GetField("m_wpSingle", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Page.FindControl("ctl00$PlaceHolderPageTitleInTitleArea$ctl01$ctl00").Controls[1], true);
                }
                catch { }
            }

            try
            {
                sPeriodId = Page.Request["NewPeriod"].ToString();
            }
            catch { }
            try
            {
                sUserId = Page.Request["Delegate"].ToString();
            }
            catch { }

            ///

            SPWeb web = SPContext.Current.Web;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                settings = new TimesheetSettings(web);

                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                cn.Open();

                SqlCommand cmd = new SqlCommand("spTSGetPeriodsForSite", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@siteid", web.Site.ID);

                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                DataTable dtPeriods = ds.Tables[0];

                DataRow[] drCur = dtPeriods.Select("CurPeriod='1'");
                if (drCur.Length > 0)
                {
                    iCurPeriodId = int.Parse(drCur[0]["period_id"].ToString());
                    sCurPeriodName = ((DateTime)drCur[0]["period_start"]).ToShortDateString() + " - " + ((DateTime)drCur[0]["period_end"]).ToShortDateString();
                }
                if (dtPeriods.Rows.Count > 0)
                {
                    if (sPeriodId == "")
                    {
                        DataRow[] dr = dtPeriods.Select("CurPeriod='1'");
                        if (dr.Length > 0)
                        {
                            sPeriodId = dr[0]["period_id"].ToString();
                            sPeriodName = ((DateTime)dr[0]["period_start"]).ToShortDateString() + " - " + ((DateTime)dr[0]["period_end"]).ToShortDateString();
                            bIsCurrentTimesheetPeriod = true;
                        }
                        else
                        {
                            sPeriodId = dtPeriods.Rows[dtPeriods.Rows.Count - 1]["period_id"].ToString();
                            sPeriodName = ((DateTime)dtPeriods.Rows[dtPeriods.Rows.Count - 1]["period_start"]).ToShortDateString() + " - " + ((DateTime)dtPeriods.Rows[dtPeriods.Rows.Count - 1]["period_end"]).ToShortDateString();
                        }
                    }
                    else
                    {
                        DataRow[] dr = ds.Tables[0].Select("period_id='" + sPeriodId + "'");
                        if (dr.Length > 0)
                        {
                            sPeriodName = ((DateTime)dr[0]["period_start"]).ToShortDateString() + " - " + ((DateTime)dr[0]["period_end"]).ToShortDateString();
                            try
                            {
                                if (dr[0]["curPeriod"].ToString() == "1")
                                    bIsCurrentTimesheetPeriod = true;
                            }
                            catch { }
                        }
                        else
                        {
                            DataRow[] dr2 = ds.Tables[0].Select("CurPeriod='1'");
                            if (dr2.Length > 0)
                            {
                                sPeriodId = dr2[0]["period_id"].ToString();
                                sPeriodName = ((DateTime)dr2[0]["period_start"]).ToShortDateString() + " - " + ((DateTime)dr2[0]["period_end"]).ToShortDateString();
                                bIsCurrentTimesheetPeriod = true;
                            }
                            else
                            {
                                sPeriodId = dtPeriods.Rows[dtPeriods.Rows.Count - 1]["period_id"].ToString();
                                sPeriodName = ((DateTime)dtPeriods.Rows[dtPeriods.Rows.Count - 1]["period_start"]).ToShortDateString() + " - " + ((DateTime)dtPeriods.Rows[dtPeriods.Rows.Count - 1]["period_end"]).ToShortDateString();
                            }
                        }
                    }

                    string itmpprev = "";
                    bool bNext = false;

                    foreach (DataRow dr in dtPeriods.Rows)
                    {
                        sPeriodList += "," + dr["period_id"].ToString() + "|" + ((DateTime)dr["period_start"]).ToShortDateString() + " - " + ((DateTime)dr["period_end"]).ToShortDateString();

                        if (bNext)
                        {
                            bNext = false;

                            iNextPeriod = int.Parse(dr["period_id"].ToString());
                        }

                        if (dr["period_id"].ToString() == sPeriodId)
                        {
                            if (itmpprev != "")
                                iPreviousPeriod = int.Parse(itmpprev);
                            bNext = true;
                        }

                        itmpprev = dr["period_id"].ToString();
                    }

                    sPeriodList = sPeriodList.Trim(',');

                    TSNotes = settings.AllowNotes.ToString().ToLower();


                    cmd = new SqlCommand("SELECT TSTYPE_ID, TSTYPE_NAME FROM TSTYPE where SITE_UID=@siteid", cn);
                    cmd.Parameters.AddWithValue("@siteid", web.Site.ID);

                    SqlDataReader drTypes = cmd.ExecuteReader();
                    while (drTypes.Read())
                    {
                        int id = drTypes.GetInt32(0);

                        TSColType = 2;

                        TSTypeObject += ",T" + id + ": '" + drTypes.GetString(1) + "'";

                    }
                    drTypes.Close();


                    TSTypeObject = "{" + TSTypeObject.Trim(',') + "}";

                    ArrayList arrPeriods = TimesheetAPI.GetPeriodDaysArray(cn, settings, web, sPeriodId);

                    foreach (DateTime dtStart in arrPeriods)
                    {
                        TSCols += "\"P" + dtStart.Ticks + "\": true,";
                    }

                    foreach (DateTime dtStart in arrPeriods)
                    {
                        TSDCols += "\"P" + dtStart.Ticks + "\": \"" + settings.DayDef.Split('|')[(int)dtStart.DayOfWeek * 3 + 1] + "|" + settings.DayDef.Split('|')[(int)dtStart.DayOfWeek * 3 + 2] + "\",";
                    }

                    TSCols = "{" + TSCols.Trim(',') + "}";
                    TSDCols = "{" + TSDCols.Trim(',') + "}";

                    if (GridType == 0)
                    {
                        SPUser user = TimesheetAPI.GetUser(web, sUserId);

                        cmd = new SqlCommand("SELECT submitted, approval_status, locked FROM TSTIMESHEET where SITE_UID=@siteid and period_id=@period and username=@username", cn);
                        cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                        cmd.Parameters.AddWithValue("@period", sPeriodId);
                        cmd.Parameters.AddWithValue("@username", user.LoginName);

                        SqlDataReader drTS = cmd.ExecuteReader();
                        if (drTS.Read())
                        {
                            //Locked
                            if (drTS.GetBoolean(2))
                                bTsLocked = true;

                            //Submitted
                            if (drTS.GetBoolean(0))
                            {
                                if (drTS.GetInt32(1) == 1)
                                {
                                    sStatus = "Approved";
                                    if (!settings.DisableApprovals)
                                        bTsLocked = true;
                                }
                                else if (drTS.GetInt32(1) == 2)
                                {
                                    sStatus = "Rejected";
                                }
                                else
                                    sStatus = "Submitted";
                            }
                        }
                        drTS.Close();
                    }
                    else
                    {
                        bTsLocked = true;
                    }


                    cn.Close();

                    bHasPeriods = true;
                }
            });



            sDataParam = "<Param GridId=\"" + sFullGridId + "\" Period=\"" + sPeriodId + "\" UserId=\"" + sUserId + "\"/>";
            sLayoutParam = "<Param GridId=\"" + sFullGridId + "\" Period=\"" + sPeriodId + "\" UserId=\"" + sUserId + "\" Editable=\"" + iEditable + "\" GridType=\"" + GridType + "\"/>";

            sDataParam = System.Web.HttpUtility.HtmlEncode(System.Web.HttpUtility.HtmlEncode(sDataParam));
            sLayoutParam = System.Web.HttpUtility.HtmlEncode(System.Web.HttpUtility.HtmlEncode(sLayoutParam));
            ///


            DataTable dtTsDelegates = EPMLiveCore.API.APITeam.GetResourcePool("<Resources FilterField=\"TimesheetDelegates\" FilterFieldValue=\"" + web.CurrentUser.Name + "\" ><Columns>SimpleColumns</Columns></Resources>", web);

            foreach (DataRow dr in dtTsDelegates.Rows)
            {
                if (sUserId == dr["SPID"].ToString())
                    sCurrentDelegate = dr["Title"].ToString();

                sDelegates += dr["SPID"].ToString() + "|" + dr["Title"].ToString() + "^";
            }

            sDelegates = sDelegates.Trim('^');

            string serviceUrl = ((SPContext.Current.Web.ServerRelativeUrl == "/")
                                     ? ""
                                     : SPContext.Current.Web.ServerRelativeUrl) + "/_vti_bin/Workengine.asmx";

            ScriptManager scriptManager = ScriptManager.GetCurrent(Page);

            if (scriptManager != null) scriptManager.Services.Add(new ServiceReference(serviceUrl));
            else
            {
                scriptManager = new ScriptManager();
                scriptManager.Services.Add(new ServiceReference(serviceUrl));

                Page.Form.Controls.Add(scriptManager);
            }

            views = TimesheetAPI.GetViews(web);

            tb.StopTimer();

        }

        protected override void OnInit(EventArgs e)
        {
            tb = new EPMLiveCore.TimeDebug("Timesheet", Page.Request["debug"]);
            if (Page.Request["Approvals"] == "true")
            {
                GridType = 1;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            sFullGridId = this.ZoneIndex + this.ZoneID;
        }

        private void RenderApprovalToolbar(HtmlTextWriter output)
        {

            output.WriteLine("<div id=\"actionmenu" + sFullGridId + "\" style=\"width:100%\"></div>");

            output.WriteLine(@"<script language=""javascript"">

            function loadMenu" + sFullGridId + @"()
            {
                    var cfgs = 
                    [
                        {
                            'placement': 'left',
                            'content': 
                            [
                                {
                                    'controlId': 'btnApprove',
                                    'controlType': 'button',
                                    'iconClass': 'icon-checkmark-circle-2',
                                    'title': 'Approve',
                                    'events': [
                                        {
                                            'eventName': 'click',
                                            'function': function () { Approve('" + sFullGridId + @"'); }
                                        }
                                    ]
                                },
                                {
                                    'controlId': 'btnUnlock',
                                    'controlType': 'button',
                                    'iconClass': 'icon-unlocked-2',
                                    'title': 'Unlock',
                                    'events': [
                                        {
                                            'eventName': 'click',
                                            'function': function () { Unlock('" + sFullGridId + @"'); }
                                        }
                                    ]
                                },
                                {
                                    'controlId': 'btnReject',
                                    'controlType': 'button',
                                    'iconClass': 'icon-cancel-circle-2',
                                    'title': 'Reject',
                                    'events': [
                                        {
                                            'eventName': 'click',
                                            'function': function () { Reject('" + sFullGridId + @"'); }
                                        }
                                    ]
                                },
                                {
                                    'controlId': 'btnEmail',
                                    'controlType': 'button',
                                    'iconClass': 'icon-envelop',
                                    'title': 'Email Selected',
                                    'events': [
                                        {
                                            'eventName': 'click',
                                            'function': function () { EmailTSA('" + sFullGridId + @"'); }
                                        }
                                    ]
                                }
                            ]
                        },
                        {
                            'placement': 'right',
                            'content': 
                            [
                                {
                                    'controlId': 'ddlFilterControl',
                                    'controlType': 'dropdown',
                                    'title': 'none',
                                    'iconClass': 'icon-filter',
                                    'sections': 
                                    [
                                        {
                                            'heading': 'none',
                                            'options': [
                                                {'iconClass': '','text': 'View All','events': [{'eventName': 'click','function': function () { TMFilter('" + sFullGridId + @"',1); }}]},
                                                {'iconClass': '','text': 'View Unsubmitted','events': [{'eventName': 'click','function': function () { TMFilter('" + sFullGridId + @"',2); }}]},
                                                {'iconClass': '','text': 'View Unapproved','events': [{'eventName': 'click','function': function () { TMFilter('" + sFullGridId + @"',3); }}]}
                                            ]
                                        }
                                    ]
                                },
                                {
                                    'controlId': 'ddlViewControl',
                                    'controlType': 'dropdown',
                                    'title': 'View: ',
                                    'value': 'Timesheet Approvals',
                                    'iconClass': 'none',
                                    'sections': 
                                    [
                                        {
                                            'heading': 'none',
                                            'options': [
                                                {'iconClass': '','text': 'My Timesheet','events': [{'eventName': 'click','function': function () { location.href=window.epmLive.currentWebUrl + '/_layouts/15/epmlive/mytimesheet.aspx'; }}]}
                                            ]
                                        },
                                        {
                                            'heading': 'none',
                                            'options': [
                                                {'iconClass': '','text': 'Project Manager Approvals','events': [{'eventName': 'click','function': function () { OpenPMApprovals('" + sFullGridId + @"'); }}]},
                                                {'iconClass': '','text': 'Timesheet Manager Approvals','events': [{'eventName': 'click','function': function () { location.href=window.epmLive.currentWebUrl + '/_layouts/15/epmlive/mytimesheet.aspx?Approvals=true'; }}]}
                                            ]
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                    
                epmLiveGenericToolBar.generateToolBar('actionmenu" + sFullGridId + @"', cfgs);
            }          
        </script>");

        }

        private string GetViews()
        {
            string sViews = "";
            foreach (KeyValuePair<string, Dictionary<string, string>> key in views.Views)
            {
                if (key.Key == "Default View" && views.Views.Count == 1)
                {
                    sViews = "{'iconClass': '','text': 'My Timesheet','events': [{'eventName': 'click','function': function () { location.href=window.epmLive.currentWebUrl + '/_layouts/15/epmlive/mytimesheet.aspx?Approvals=true'; }}]}";
                }
            }
            return sViews;
        }


        protected override void RenderWebPart(HtmlTextWriter output)
        {
            tb.AddTimer();



            if (SPContext.Current.ViewContext.View != null)
            {
                foreach (System.Web.UI.WebControls.WebParts.WebPart wp in WebPartManager.WebParts)
                {
                    try
                    {
                        if (wp.ToString() == "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart" || wp.ToString() == "Microsoft.SharePoint.WebPartPages.ListViewWebPart")
                        {
                            wp.Visible = false;
                        }
                    }
                    catch { }
                }
            }

            if (activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            if (!bHasPeriods)
            {
                output.WriteLine("There are no periods setup for this TimeSheet. Please contact your system administrator");
                return;
            }

            output.WriteLine(@"<style>
                .GMBodyRight
                {
	                border-right: 1px solid #DDD!important;	
                }
                .GMBodyRight .GMCell
                {
	                border-left: 1px solid #DDD!important;
	                border-bottom: 1px solid #DDD!important;
                    overflow: visible;
                }

                .GMCellHeader, .GMCellHeaderPanel, .GMCell, .GMCellPanel
                {
                    border-bottom: 1px solid #DDD!important;
                }
                .Totals 
                {
                    font-weight: bold;
                }
                .GMFootRight
                {
                    border-left: 2px solid #ccc
                }
                .GMFootRight .GMCell
                {
	                border-left: 1px solid #DDD!important;
	                border-bottom: 1px solid #DDD!important;
                }
                .HideCol0StopWatch
                {
	                background-position: 0px center !important;
                }
                .TSBold 
                {
                    font-weight: bold !important;
                }
                .GMPx0xx 
                {
                background: none;
                opacity: 1;
                }
                #ddlFilterControl .caret {display:none;}
                </style>");

            string sUserId = "";

            if (!string.IsNullOrEmpty(Page.Request["Delegate"]))
            {
                SPUser user = TimesheetAPI.GetUser(SPContext.Current.Web, Page.Request["Delegate"]);
                sUserId = user.ID.ToString();
            }

            bCanEditViews = SPContext.Current.Web.DoesUserHavePermissions(SPBasePermissions.ManageWeb);

            string url = SPContext.Current.Web.Url;
            if (url == "/") url = "";

            string curUrl = Page.Request.RawUrl.ToString();

            if (curUrl.Contains("?"))
                curUrl = curUrl.Substring(0, curUrl.IndexOf("?") + 1);

            foreach (string key in Page.Request.QueryString.AllKeys)
            {
                if (key.ToString().ToLower() != "newperiod" && key.ToString().ToLower() != "delegate")
                {
                    curUrl += key + "=" + Page.Request.QueryString[key] + "&";
                }
            }

            int counter = 0;

            foreach (KeyValuePair<string, Dictionary<string, string>> key in views.Views)
            {
                try
                {

                    if (key.Value["Default"].ToLower() == "true")
                    {
                        sCurrentView = key.Key;
                        sCurrentViewId = "V" + counter;
                    }
                }
                catch { }
                counter++;
            }

            curUrl = curUrl.Trim('&').Trim('?');
            System.Globalization.CultureInfo cInfo = new System.Globalization.CultureInfo(1033);
            IFormatProvider culture = new System.Globalization.CultureInfo(cInfo.Name, true);
            output.WriteLine(@"<script language=""javascript"">
                                    var TSObject" + sFullGridId + @" = new Object();
                                    TSObject" + sFullGridId + @".canSave = true;
                                    TSObject" + sFullGridId + @".id = '" + sFullGridId + @"';
                                    TSObject" + sFullGridId + @".Periods = '" + sPeriodList + @"';
                                    TSObject" + sFullGridId + @".PeriodName = '" + sPeriodName + @"';
                                    TSObject" + sFullGridId + @".PeriodId = " + sPeriodId + @";
                                    TSObject" + sFullGridId + @".UserId = '" + sUserId + @"';
                                    TSObject" + sFullGridId + @".IsCurPeriod = " + bIsCurrentTimesheetPeriod.ToString().ToLower() + @";
                                    TSObject" + sFullGridId + @".CurPeriodId = " + iCurPeriodId + @";
                                    TSObject" + sFullGridId + @".CurPeriodName = '" + sCurPeriodName + @"';

                                    TSObject" + sFullGridId + @".PreviousPeriod = " + iPreviousPeriod + @";
                                    TSObject" + sFullGridId + @".NextPeriod = " + iNextPeriod + @";

                                    TSObject" + sFullGridId + @".TSURL = '" + curUrl + @"';
                                    TSObject" + sFullGridId + @".Status = '" + sStatus + @"';
                                    TSObject" + sFullGridId + @".Locked = " + bTsLocked.ToString().ToLower() + @";
                                    TSObject" + sFullGridId + @".DisableApprovals = " + settings.DisableApprovals.ToString().ToLower() + @";
                                    TSObject" + sFullGridId + @".Delegates = '" + sDelegates + @"';
                                    TSObject" + sFullGridId + @".DelegateId = '" + Page.Request["Delegate"] + @"';
                                    TSObject" + sFullGridId + @".Views = " + views.ToJSON() + @";
                                    TSObject" + sFullGridId + @".CurrentView = '" + sCurrentView + @"';
                                    TSObject" + sFullGridId + @".Qualifier = '" + Qualifier + @"';
                                    TSObject" + sFullGridId + @".CurrentViewId = '" + sCurrentViewId + @"';
                                    TSObject" + sFullGridId + @".CanEditViews = " + bCanEditViews.ToString().ToLower() + @";                                    

                                    TSColType = " + TSColType + @";
                                    TSNotes = " + TSNotes + @";
                                    TSTypeObject = " + TSTypeObject + @";
                                    TSCols = " + TSCols + @";
                                    TSDCols = " + TSDCols + @";
                                    siteId = '" + SPContext.Current.Web.ID + @"';
                                    siteUrl = '" + url + @"';
                                    siteColUrl = '" + SPContext.Current.Site.ServerRelativeUrl + @"';
                                    periodId = '" + sPeriodId + @"';
                                    GridType = '" + GridType + @"';

                                    curServerDate = (new Date()).getTime() - (new Date('" + DateTime.Now.ToString("MMMM dd, yyyy H:mm:ss", culture) + @"')).getTime();

                                    TGSetEvent('OnRenderFinish', 'TS" + sFullGridId + @"', TSRenderFinish);
                                    TGSetEvent('OnReady', 'TS" + sFullGridId + @"', TSReady);
                            </script>
                            ");


            //output.WriteLine(@"<div align=""center"" id=""TSLoader" + sFullGridId + @""" width=""100%""><img style=""vertical-align:middle;"" src=""/_layouts/images/gears_anv4.gif""/>&nbsp;Loading Items...</div>");

            StringBuilder sb = new StringBuilder("<select class=\"form-control\" onchange=\"changePeriodCommand('" + curUrl + "',this,'" + Page.Request["Delegate"] + "')\">");

            var arrPeriods = sPeriodList.Split(',');
            for (var i = 0; i < arrPeriods.Length; i++)
            {
                var arrPeriod = arrPeriods[i].Split('|');
                if (arrPeriod[1] != sPeriodName)
                {
                    sb.Append("<option value=" + arrPeriod[0] + ">" + arrPeriod[1] + "</option>");
                }
                else
                {
                    sb.Append("<option value=" + arrPeriod[0] + " selected>" + arrPeriod[1] + "</option>");
                }
            }
            sb.Append("</select>");

            var str = new HtmlString(sb.ToString());




            if (GridType == 0)
            {


                output.WriteLine(@"
                <div id=""tsnav"" style=""display:none"">
                    <nav class=""navbar navbar-default navbar-static"" role=""navigation"">
                        <div>
                            <div class=""collapse navbar-collapse"">
                                <ul class=""nav navbar-nav"" class=""ts-nav-list"">
                                    <li class=""nav-btn nav-text-wrapper"" style=""float:left;padding-right:20px;padding: 0px"">
                                        <div class=""nav-label"">Status:</div>
                                            <div class=""text"" id=""mytimesheetstatus"">" + sStatus + @"</div>
                                    </li>
                                    <li class=""nav-btn nav-text-wrapper"" style=""padding: 0px; float:left"">
                                        <div class=""nav-label"">Current Period:
                                        </div>");
                if (iPreviousPeriod != 0)
                {
                    output.WriteLine(@"
                <span class=""icon-arrow-left-17 icon"" onclick=""javascript:previousPeriodCommand('" + curUrl + "','" + iPreviousPeriod + "','" + Page.Request["Delegate"] + @"')""></span>                
                ");
                }
                else
                {
                    output.WriteLine(@"
                <span class=""icon-arrow-left-17 icon disabled""></span>                
                ");
                }

                output.WriteLine(@"<div class=""nav-select"">" + str.ToHtmlString() + @" </div>");


                if (iNextPeriod != 0)
                {
                    output.WriteLine(@"
                <span class=""icon-arrow-right-17 icon"" onclick=""javascript:nextPeriodCommand('" + curUrl + "','" + iNextPeriod + "','" + Page.Request["Delegate"] + @"')""></span>                
                ");
                }
                else
                {
                    output.WriteLine(@"
                <span class=""icon-arrow-right-17 icon disabled""></span>                
                ");
                }
                output.WriteLine(@"</li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>");
                output.Write("<div style=\"height:300px;width:100%;overflow:hidden;display:inline-block\" id=\"gridouter\">");
                output.WriteLine("<div style=\"width:100%;height:100%\">");
                output.WriteLine(@"<treegrid Data_Url=""" + url + @"/_vti_bin/WorkEngine.asmx"" Data_Timeout=""0"" Data_Method=""Soap"" Data_Function=""Execute"" Data_Namespace=""workengine.com"" Data_Param_Function=""timesheet_GetTimesheetGrid"" Data_Param_Dataxml=""" + sDataParam + @""" 
                                Layout_Url=""" + url + @"/_vti_bin/WorkEngine.asmx"" Layout_Timeout=""0"" Layout_Method=""Soap"" Layout_Function=""Execute"" Layout_Namespace=""workengine.com"" Layout_Param_Function=""timesheet_GetTimesheetGridLayout"" Layout_Param_Dataxml=""" + sLayoutParam + @""" 
                                Check_Url=""" + url + @"/_vti_bin/WorkEngine.asmx"" Check_Timeout=""0"" Check_Method=""Soap"" Check_Function=""Execute"" Check_Namespace=""workengine.com"" Check_Param_Function=""timesheet_GetTimesheetUpdates"" Check_Param_Dataxml=""" + sLayoutParam + @""" Check_Interval=""0"" Check_Repeat=""0""
                                Upload_Url=""" + url + @"/_layouts/epmlive/savemytimesheet.aspx"" Upload_Type=""Body,Cfg"" Upload_Flags=""AllCols,Accepted"" Debug="""" SuppressMessage=""3""></treegrid>");
                output.WriteLine("</div>");
                output.WriteLine("</div>");

            }
            else if (GridType == 1)
            {
                RenderApprovalToolbar(output);

                output.WriteLine(@"
                <div id=""tsnav"" style=""display:none"">
                    <nav class=""navbar navbar-default navbar-static"" role=""navigation"">
                        <div>
                            <div class=""collapse navbar-collapse"">
                                <ul class=""nav navbar-nav"" style=""list-style-type: none;padding-top: 10px; margin:0px;padding: 0px; "">
                                    <li class=""nav-btn nav-text-wrapper"" style=""float:left;padding: 0px; "">
                                        <div class=""nav-label"">Current Period:
                                        </div>");
                if (iPreviousPeriod != 0)
                {
                    output.WriteLine(@"
                <span class=""icon-arrow-left-17 icon"" onclick=""javascript:previousPeriodCommand('" + curUrl + "','" + iPreviousPeriod + "','" + Page.Request["Delegate"] + @"')""></span>                
                ");
                }
                else
                {
                    output.WriteLine(@"
                <span class=""icon-arrow-left-17 icon disabled""></span>                
                ");
                }

                output.WriteLine(@"<div class=""nav-select"">" + str.ToHtmlString() + @" </div>");


                if (iNextPeriod != 0)
                {
                    output.WriteLine(@"
                <span class=""icon-arrow-right-17 icon"" onclick=""javascript:nextPeriodCommand('" + curUrl + "','" + iNextPeriod + "','" + Page.Request["Delegate"] + @"')""></span>                
                ");
                }
                else
                {
                    output.WriteLine(@"
                <span class=""icon-arrow-right-17 icon disabled""></span>                
                ");
                }
                output.WriteLine(@"</li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>");
                output.Write("<div style=\"height:300px;width:100%;overflow:hidden;display:inline-block\" id=\"gridouter\">");
                output.WriteLine("<div style=\"width:100%;height:100%\">");
                output.WriteLine(@"<treegrid Data_Url=""" + url + @"/_vti_bin/WorkEngine.asmx"" Data_Timeout=""0"" Data_Method=""Soap"" Data_Function=""Execute"" Data_Namespace=""workengine.com"" Data_Param_Function=""timesheet_GetTimesheetApprovalsGrid"" Data_Param_Dataxml=""" + sDataParam + @""" 
                                Layout_Url=""" + url + @"/_vti_bin/WorkEngine.asmx"" Layout_Timeout=""0"" Layout_Method=""Soap"" Layout_Function=""Execute"" Layout_Namespace=""workengine.com"" Layout_Param_Function=""timesheet_GetTimesheetGridLayout"" Layout_Param_Dataxml=""" + sLayoutParam + @""" 
                                Page_Url=""" + url + @"/_layouts/15/epmlive/timesheetapprovalpage.aspx?Period=" + sPeriodId + @""" SuppressMessage=""3""
                                 ></treegrid>");
                output.WriteLine("</div>");
                output.WriteLine("</div>");
            }



            output.WriteLine(@"<div align=""center"" id=""divMessage" + sFullGridId + @""" width=""100%"" class=""dialog""><img style=""vertical-align:middle;"" src=""/_layouts/images/gears_anv4.gif""/>&nbsp;<span id=""spnMessage" + sFullGridId + @""">Saving Timesheet...</span></div>");

            output.Write("<div id='NotesDiv' style='z-index:999;position: absolute; margin-left: 65px; display:none; width:150px;height:110px;border: 1px solid #666;background-color:#FFFFFF;cursor:pointer' onClick='stopProp(event);'><textarea id='txtNotes' style='z-index:999;width:140px;height:60px;border:0px;margin-bottom:5px;resize: none; outline: 0;' onkeyup='stopProp(event);' onclick='stopProp(event);' onkeypress='stopProp(event);'");
            if(bTsLocked)
                output.Write(" disabled='disabled'");

            output.Write("></textarea><br><input type=\"button\" value=\"OK\" onCLick=\"SaveNotes(event);stopProp(event);\" style=\"float:right\"></div>");

            output.WriteLine(@"<div id=""viewNameDiv"" style=""display:none;width:200;padding:10px"">

                View Name:<br />
                <input type=""text"" class=""ms-input"" name=""viewname"" id=""viewname""/><br /><br />
                <div><input type=""checkbox"" name=""chkViewDefault"" id=""chkViewDefault"" /> Default View </div><br /><br />
                <input type=""button"" value=""OK"" onclick=""SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, document.getElementById('viewname').value + '|' + document.getElementById('chkViewDefault').checked); return false;"" class=""ms-ButtonHeightWidth"" style=""width:100px"" target=""_self"" /> &nbsp;

               <input type=""button"" value=""Cancel"" onclick=""SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;"" class=""ms-ButtonHeightWidth"" style=""width:100px"" target=""_self"" />  
    
            </div>");


            output.WriteLine(@"<script language=""javascript"">");

            output.WriteLine("function LoadTSGrid" + sFullGridId + "(){ LoadTSGrid('" + sFullGridId + "');}");

            output.WriteLine("SP.SOD.executeOrDelayUntilScriptLoaded(LoadTSGrid" + sFullGridId + ", 'EPMLive.js');");

            output.WriteLine("initmb();");

            output.WriteLine("function clickTab(){");
            output.WriteLine("SelectRibbonTab('Ribbon.MyTimesheetTab', true);");
            //output.WriteLine("var wp = document.getElementById('MSOZoneCell_WebPart" + this.Qualifier + "');");
            //output.WriteLine("fireEvent(wp, 'mouseup');");
            output.WriteLine("}");

            //output.Write("SP.SOD.executeOrDelayUntilScriptLoaded(clickTab, \"MyTimesheetContextualTabPageComponent.js\");");
            output.WriteLine(@"var viewNameDiv = document.getElementById(""viewNameDiv"");");
            output.WriteLine("</script>");

            tb.StopTimer();
            tb.WriteTimers(output);
        }

        protected override void OnPreRender(EventArgs e)
        {
            tb.AddTimer();
            if (bHasPeriods)
            {
                if (GridType == 0)
                {
                    AddContextualTab();

                    ClientScriptManager clientScriptManager = Page.ClientScript;
                    clientScriptManager.RegisterClientScriptBlock(GetType(), "MyTimesheet", DelayScript.Replace("{webPartPageComponentId}", SPRibbon.GetWebPartPageComponentId(this)).Replace("{TSOBJECT}", "TSObject" + sFullGridId));
                }
                CssRegistration.Register("/_layouts/epmlive/MyTimesheet.css");
                CssRegistration.Register("/_layouts/epmlive/modal/modal.css");

                ScriptLink.Register(Page, "/_layouts/epmlive/modal/modal.js", false);
                ScriptLink.Register(Page, "/_layouts/epmlive/dhtml/xgrid/dhtmlxcommon.js", false);

                EPMLiveCore.Infrastructure.EPMLiveScriptManager.RegisterScript(Page, new[]
                {
                    "/treegrid/GridE", "MyTimesheet"
                });

                //ScriptLink.Register(Page, "/_layouts/epmlive/MyTimesheet.js", false);

                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            }
            base.OnPreRender(e);
            tb.StopTimer();
        }

        private void AddContextualTab()
        {
            SPRibbon spRibbon = SPRibbon.GetCurrent(Page);

            if (spRibbon == null) return;

            var ribbonExtensions = new XmlDocument();

            ribbonExtensions.LoadXml(Properties.Resources.txtMyTimesheet_Ribbon.Replace("{title}", DisplayTitle).Replace("#language#", SPContext.Current.Web.Language.ToString()));
            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ContextualTabs._children");

            ribbonExtensions.LoadXml(Properties.Resources.txtMyTimesheet_Template);
            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");


            //            ribbonExtensions = new XmlDocument();
            //            ribbonExtensions.LoadXml(@"<Label
            //						Id=""Ribbon.Timesheet.ActionsGroup.StatusLabel2""
            //						Sequence=""11""
            //						Command=""Ribbon.MyTimesheet.StatusLabel1""
            //						LabelText=""" + sStatus + @"""
            //                        Image16by16=""/_layouts/epmlive/images/tss_" + sStatus + @".png""
            //						TemplateAlias=""oM""
            //						/> ");
            //            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.MyTimesheet.ActionsGroup.Controls._children");


            if (sDelegates == "")
            {
                spRibbon.TrimById("Ribbon.MyTimesheet.DelegateGroup");
            }


            if (sCurrentDelegate != "")
            {
                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml(@"<Label
						Id=""Ribbon.Timesheet.DelegateGroup.CurrentDelegateLabel1""
						Sequence=""20""
						Command=""Ribbon.MyTimesheet.CurrentDelegate""
						LabelText=""Current Delegate:""
						TemplateAlias=""oM""
						/> ");
                spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.MyTimesheet.DelegateGroup.Controls._children");


                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml(@"<Label
						Id=""Ribbon.Timesheet.DelegateGroup.CurrentDelegateLabel2""
						Sequence=""20""
						Command=""Ribbon.MyTimesheet.CurrentDelegate""
						LabelText=""" + sCurrentDelegate + @"""
						TemplateAlias=""oM""
						/> ");
                spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.MyTimesheet.DelegateGroup.Controls._children");
            }

            bool bDisable = BApprovalDisabled();
            

            if(bDisable)
                spRibbon.TrimById("Ribbon.MyTimesheet.Approvals.TM");
        }

        private bool BApprovalDisabled()
        {
            bool bDisabled = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSDisableApprovals"),out bDisabled);
                }
            });

            return bDisabled;
        }

        public string DelayScript
        {
            get
            {
                if (GridType == 0)
                    return Properties.Resources.txtMyTimesheet_DelayScript;
                else
                    return "";
            }
        }

        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {
                if (GridType == 0)
                {
                    var webPartContextualInfo = new WebPartContextualInfo();
                    var webPartRibbonContextualGroup = new WebPartRibbonContextualGroup();
                    var webPartRibbonTab = new WebPartRibbonTab();

                    webPartRibbonContextualGroup.Id = "Ribbon.MyTimesheetContextualTabGroup";
                    webPartRibbonContextualGroup.Command = "MyTimesheetContextualTab.EnableContextualGroup";
                    webPartRibbonContextualGroup.VisibilityContext = "MyTimesheetContextualTab.CustomVisibilityContext";

                    webPartRibbonTab.Id = InitialTabId;
                    webPartRibbonTab.VisibilityContext = "MyTimesheetContextualTab.CustomVisibilityContext";

                    webPartContextualInfo.ContextualGroups.Add(webPartRibbonContextualGroup);
                    webPartContextualInfo.Tabs.Add(webPartRibbonTab);


                    var webPartRibbonTab2 = new WebPartRibbonTab();
                    webPartRibbonTab2.Id = "Ribbon.MyTimesheetViewsTab";
                    webPartRibbonTab2.VisibilityContext = "MyTimesheetContextualTab.CustomVisibilityContext";
                    webPartContextualInfo.Tabs.Add(webPartRibbonTab2);

                    webPartContextualInfo.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                    return webPartContextualInfo;
                }
                else
                    return null;
            }
        }
    }
}
