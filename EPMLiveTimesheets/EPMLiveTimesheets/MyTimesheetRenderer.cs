using System;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint;

namespace TimeSheets
{
    internal class MyTimesheetRenderer
    {
        private readonly HtmlTextWriter output;
        private readonly MyTimesheetProperties properties;

        internal MyTimesheetRenderer(HtmlTextWriter output, MyTimesheetProperties properties)
        {
            this.output = output;
            this.properties = properties;
        }

        internal void RenderStyles()
        {
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
        }

        internal void RenderVariablesInitScript()
        {
            var cultureInfo = new CultureInfo(1033);
            var culture = new CultureInfo(cultureInfo.Name, true);
            var localInfo = new CultureInfo(SPContext.Current.Web.Locale.LCID);

            output.WriteLine($@"
<script language=""javascript"">
    var TSObject{properties.FullGridId} = new Object();
    TSObject{properties.FullGridId}.canSave = true;
    TSObject{properties.FullGridId}.id = '{properties.FullGridId}';
    TSObject{properties.FullGridId}.Periods = '{properties.PeriodList}';
    TSObject{properties.FullGridId}.PeriodName = '{properties.PeriodName}';
    TSObject{properties.FullGridId}.PeriodId = {properties.PeriodId};
    TSObject{properties.FullGridId}.UserId = '{properties.UserId}';

    TSObject{properties.FullGridId}.DecimalSeparator='{localInfo.NumberFormat.NumberDecimalSeparator}';
    TSObject{properties.FullGridId}.GroupSeparator='{localInfo.NumberFormat.NumberGroupSeparator}';

    TSObject{properties.FullGridId}.IsCurPeriod = {properties.IsCurrentTimesheetPeriod.ToString().ToLower()};
    TSObject{properties.FullGridId}.CurPeriodId = {properties.CurrentPeriodId};
    TSObject{properties.FullGridId}.CurPeriodName = '{properties.CurrentPeriodName}';

    TSObject{properties.FullGridId}.PreviousPeriod = {properties.PreviousPeriodId};
    TSObject{properties.FullGridId}.NextPeriod = {properties.NextPeriodId};

    TSObject{properties.FullGridId}.TSURL = '{properties.CurrentUrl}';
    TSObject{properties.FullGridId}.Status = '{properties.Status}';
    TSObject{properties.FullGridId}.Locked = {properties.IsLocked.ToString().ToLower()};
    TSObject{properties.FullGridId}.DisableApprovals = {properties.Settings.DisableApprovals.ToString().ToLower()};
    TSObject{properties.FullGridId}.Delegates = '{properties.Delegates.Replace("'", @"`")}';
    TSObject{properties.FullGridId}.DelegateId = '{properties.DelegateId}';
    TSObject{properties.FullGridId}.Views = {properties.Views.ToJSON()};
    TSObject{properties.FullGridId}.CurrentView = '{properties.CurrentView}';
    TSObject{properties.FullGridId}.Qualifier = '{properties.Qualifier}';
    TSObject{properties.FullGridId}.CurrentViewId = '{properties.CurrentViewId}';
    TSObject{properties.FullGridId}.CanEditViews = {properties.CanEditViews.ToString().ToLower()};

    TSColType = {properties.ColumnType};
    TSNotes = {properties.Notes};
    TSTypeObject = {properties.TypeObject};
    TSCols = {properties.Columns};
    TSDCols = {properties.DataColumns};
    siteId = '{SPContext.Current.Web.ID}';
    siteUrl = '{properties.Url}';
    siteColUrl = '{properties.RelativeUrl}';
    periodId = '{properties.PeriodId}';
    GridType = '{properties.GridType}';

    curServerDate = (new Date()).getTime() - (new Date('{DateTime.Now.ToString("MMMM dd, yyyy H:mm:ss", culture)}')).getTime();

    TGSetEvent('OnRenderFinish', 'TS{properties.FullGridId}', TSRenderFinish);
    TGSetEvent('OnReady', 'TS{properties.FullGridId}', TSReady);
    TGSetEvent('OnLoaded', 'TS{properties.FullGridId}', TSOnLoaded);
</script>");
        }

        internal void RenderGrid()
        {
            if (properties.GridType == 0)
            {
                var listStyle = @"class=""ts-nav-list""";
                var statusListItem = $@"<li class=""nav-btn nav-text-wrapper"" style=""float:left;padding-right:20px;padding: 0px"">
                                        <div class=""nav-label"">Status:</div>
                                        <div class=""text"" id=""mytimesheetstatus"">{properties.Status}</div>
                                    </li>";
                var currentPeriodStyle = "padding: 0px; float:left";
                var dataParamFunction = "GetTimesheetGrid";
                var checkUrl = $@"Check_Url=""{properties.Url}/_vti_bin/WorkEngine.asmx"" Check_Timeout=""0"" Check_Method=""Soap"" Check_Function=""Execute"" Check_Namespace=""workengine.com"" Check_Param_Function=""timesheet_GetTimesheetUpdates"" Check_Param_Dataxml=""{properties.LayoutParam}"" Check_Interval=""0"" Check_Repeat=""0""";
                var uploadUrl = $@"Upload_Url=""{properties.Url}/_layouts/epmlive/savemytimesheet.aspx"" Upload_Type=""Body,Cfg"" Upload_Flags=""AllCols,Accepted"" Debug="""" SuppressMessage=""3""";

                RenderGrid(listStyle, statusListItem, currentPeriodStyle, dataParamFunction, checkUrl, uploadUrl);
            }
            else if (properties.GridType == 1)
            {
                var listStyle = @"style=""list-style-type: none;padding-top: 10px; margin:0px;padding: 0px; """;
                var statusListItem = string.Empty;
                var currentPeriodStyle = "float:left;padding: 0px;";
                var dataParamFunction = "GetTimesheetApprovalsGrid";
                var pageUrl = $@"Page_Url=""{properties.Url}/_layouts/15/epmlive/timesheetapprovalpage.aspx?Period={properties.PeriodId}"" SuppressMessage=""3""";

                RenderApprovalToolbar();
                RenderGrid(listStyle, statusListItem, currentPeriodStyle, dataParamFunction, pageUrl);
            }
        }

        private void RenderGrid(string listStyle, string statusListItem, string currentPeriodStyle, string dataParamFunction, string gridUrlOne, string gridUrlTwo = "")
        {
            output.WriteLine($@"
                <div id=""tsnav"" style=""display:none"">
                    <nav class=""navbar navbar-default navbar-static"" role=""navigation"">
                        <div>
                            <div class=""collapse navbar-collapse"">
                                <ul class=""nav navbar-nav"" {listStyle}>
                                    {statusListItem}
                                    <li class=""nav-btn nav-text-wrapper"" style=""{currentPeriodStyle}"">
                                        <div class=""nav-label"">Current Period:</div>");
            if (properties.PreviousPeriodId != 0)
            {
                output.WriteLine($@"
                <span class=""icon-arrow-left-17 icon"" onclick=""javascript:previousPeriodCommand('{properties.CurrentUrl}','{properties.PreviousPeriodId}','{properties.DelegateId}')""></span>
                ");
            }
            else
            {
                output.WriteLine(@"
                <span class=""icon-arrow-left-17 icon disabled""></span>
                ");
            }

            output.WriteLine($@"<div class=""nav-select"">{CreatePeriodsDropDown()} </div>");

            if (properties.NextPeriodId != 0)
            {
                output.WriteLine($@"
                <span class=""icon-arrow-right-17 icon"" onclick=""javascript:nextPeriodCommand('{properties.CurrentUrl}','{properties.NextPeriodId}','{properties.DelegateId}')""></span>
                ");
            }
            else
            {
                output.WriteLine(@"
                <span class=""icon-arrow-right-17 icon disabled""></span>
                ");
            }
            output.WriteLine($@"</li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </div>
            <div style=""height:300px;width:100%;overflow:hidden;display:inline-block"" id=""gridouter"">
                <div style=""width:100%;height:100%"">
                    <treegrid Data_Url=""{properties.Url}/_vti_bin/WorkEngine.asmx"" Data_Timeout=""0"" Data_Method=""Soap"" Data_Function=""Execute"" Data_Namespace=""workengine.com"" Data_Param_Function=""timesheet_{dataParamFunction}"" Data_Param_Dataxml=""{properties.DataParam}""
                              Layout_Url=""{properties.Url}/_vti_bin/WorkEngine.asmx"" Layout_Timeout=""0"" Layout_Method=""Soap"" Layout_Function=""Execute"" Layout_Namespace=""workengine.com"" Layout_Param_Function=""timesheet_GetTimesheetGridLayout"" Layout_Param_Dataxml=""{properties.LayoutParam}""
                              {gridUrlOne}
                              {gridUrlTwo}>
                    </treegrid>
                </div>
            </div>");
        }

        internal void RenderFooter()
        {
            output.WriteLine($@"<div align=""center"" id=""divMessage{properties.FullGridId}"" width=""100%"" class=""dialog""><img style=""vertical-align:middle;"" src=""/_layouts/images/gears_anv4.gif""/>&nbsp;<span id=""spnMessage{properties.FullGridId}"">Saving Timesheet...</span></div>");

            output.Write("<div id='NotesDiv' style='z-index:999;position: absolute; margin-left: 65px; display:none; width:150px;height:110px;border: 1px solid #666;background-color:#FFFFFF;cursor:pointer' onClick='stopProp(event);'><textarea id='txtNotes' style='z-index:999;width:140px;height:60px;border:0px;margin-bottom:5px;resize: none; outline: 0;' onkeyup='stopProp(event);' onclick='stopProp(event);' onkeypress='stopProp(event);'");
            if (properties.IsLocked)
            {
                output.Write(" disabled='disabled'");
            }

            output.Write("></textarea><br><input type=\"button\" value=\"OK\" onCLick=\"SaveNotes(event);stopProp(event);\" style=\"float:right\"></div>");

            output.WriteLine(@"<div id=""viewNameDiv"" style=""display:none;width:200;padding:10px"">

                View Name:<br />
                <input type=""text"" class=""ms-input"" name=""viewname"" id=""viewname""/><br /><br />
                <div><input type=""checkbox"" name=""chkViewDefault"" id=""chkViewDefault"" /> Default View </div><br /><br />
                <input type=""button"" value=""OK"" onclick=""validate()"" class=""ms-ButtonHeightWidth"" style=""width:100px"" target=""_self"" /> &nbsp;

                <input type=""button"" value=""Cancel"" onclick=""SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;"" class=""ms-ButtonHeightWidth"" style=""width:100px"" target=""_self"" />  

            </div>");
        }

        private string CreatePeriodsDropDown()
        {
            var htmlSelectBuilder = new StringBuilder("<select class=\"form-control\" onchange=\"changePeriodCommand('")
               .Append(properties.CurrentUrl)
               .Append("',this,'")
               .Append(properties.DelegateId)
               .Append("')\">");

            var periods = properties.PeriodList.Split(',');
            for (var i = 0; i < periods.Length; i++)
            {
                var period = periods[i].Split('|');
                if (period[1] != properties.PeriodName)
                {
                    htmlSelectBuilder.Append("<option value=" + period[0] + ">" + period[1] + "</option>");
                }
                else
                {
                    htmlSelectBuilder.Append("<option value=" + period[0] + " selected>" + period[1] + "</option>");
                }
            }
            htmlSelectBuilder.Append("</select>");

            return new HtmlString(htmlSelectBuilder.ToString()).ToHtmlString();
        }

        internal void RenderApprovalToolbar()
        {
            output.WriteLine($"<div id=\"actionmenu{properties.FullGridId}\" style=\"width:100%\"></div>");

            output.WriteLine(@"<script language=""javascript"">

            function loadMenu" + properties.FullGridId + @"()
            {
                    if(!LoadGenericMenu)
                        return;
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
                                            'function': function () { Approve('" + properties.FullGridId + @"'); }
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
                                            'function': function () { Unlock('" + properties.FullGridId + @"'); }
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
                                            'function': function () { Reject('" + properties.FullGridId + @"'); }
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
                                            'function': function () { EmailTSA('" + properties.FullGridId + @"'); }
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
                                                {'iconClass': '','text': 'View All','events': [{'eventName': 'click','function': function () { TMFilter('" + properties.FullGridId + @"',1); }}]},
                                                {'iconClass': '','text': 'View Unsubmitted','events': [{'eventName': 'click','function': function () { TMFilter('" + properties.FullGridId + @"',2); }}]},
                                                {'iconClass': '','text': 'View Unapproved','events': [{'eventName': 'click','function': function () { TMFilter('" + properties.FullGridId + @"',3); }}]}
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
                                                {'iconClass': '','text': 'Project Manager Approvals','events': [{'eventName': 'click','function': function () { OpenPMApprovals('" + properties.FullGridId + @"'); }}]},
                                                {'iconClass': '','text': 'Timesheet Manager Approvals','events': [{'eventName': 'click','function': function () { location.href=window.epmLive.currentWebUrl + '/_layouts/15/epmlive/mytimesheet.aspx?Approvals=true'; }}]}
                                            ]
                                        }
                                    ]
                                }
                            ]
                        }
                    ]

                epmLiveGenericToolBar.generateToolBar('actionmenu" + properties.FullGridId + @"', cfgs);
            }
        </script>");
        }

        internal void RenderScriptWithFunctions()
        {
            output.WriteLine(@"
<script language=""javascript"">

    function LoadTSGrid" + properties.FullGridId + "(){ LoadTSGrid('" + properties.FullGridId + @"');}
    SP.SOD.executeOrDelayUntilScriptLoaded(LoadTSGrid" + properties.FullGridId + @", 'EPMLive.js');
    initmb();

    function clickTab(){
        SelectRibbonTab('Ribbon.MyTimesheetTab', true);
    }

    function validate(){
        if(document.getElementById('viewname').value.replace(/^\\s+|\\s+$/, '') == ''){
            alert('Please enter a view name - view names cannot be blank.')
            return false;
        }
        else{
            SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, document.getElementById('viewname').value + '|' + document.getElementById('chkViewDefault').checked);
            return false;
        }
    }

    var viewNameDiv = document.getElementById(""viewNameDiv"");
</script>");
        }
    }
}
