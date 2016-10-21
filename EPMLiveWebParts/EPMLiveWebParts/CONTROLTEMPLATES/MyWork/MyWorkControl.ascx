<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyWorkControl.ascx.cs" Inherits="EPMLiveWebParts.CONTROLTEMPLATES.MyWork.MyWorkControl" %>
<script>
    setTimeout(function () {
        var element = document.getElementById('Ribbon.Read-title').firstChild;
        fireEvent(element, "click")
    }, 1000)

    function fireEvent(element, event) {
        if (document.createEventObject) {
            // dispatch for IE
            var evt = document.createEventObject();
            element.fireEvent('on' + event, evt)
        }
        else {
            // dispatch for firefox + others
            var evt = document.createEvent("HTMLEvents");
            evt.initEvent(event, true, true); // event type,bubbling,cancelable
            !element.dispatchEvent(evt);
        }
        setTimeout(function () {
            window.SelectRibbonTab('Ribbon.MyWorkTab', true);
        }, 3000);
    }

</script>
<div id="EPMAllWork">
    <div id="MWG_Loader_<%= WebPartId %>" class="epmlive-loader"></div>

    <SharePoint:ScriptBlock runat="server">
        if (window.epmLiveMasterPageVersion >= 5.5) {
            function initializeEPMLoaderV2() {
                $(function() {
                    $('#MWG_Loader_<%= WebPartId %>').hide();

                    var url = (document.location.href + '').toLowerCase().replace('%20','').replace(' ','');
                    if (url.indexOf('mywork.aspx') !== -1) {

                        function showLoading() {
                            EPM.UI.Loader.current().startLoading({ id: 'WebPart<%= Qualifier %>', page: true, coverRibbon: true });
                        }

                        SP.SOD.executeOrDelayUntilScriptLoaded(showLoading, 'EPM.UI');
                    } else {
                        EPM.UI.Loader.current().startLoading({ id: 'WebPart<%= Qualifier %>' });
                    }
                });
            }

            SP.SOD.executeOrDelayUntilScriptLoaded(initializeEPMLoaderV2, 'jquery.min.js');
        } else {
            function initializeEPMLoader() {
                $(function() {
                    var url = (document.location.href + '').toLowerCase();
                    if (url.indexOf('mywork.aspx') !== -1 || url.indexOf('my%20work.aspx') !== -1) {

                        function showLoading() {
                            window.myWorkLoader = SP.UI.ModalDialog.showWaitScreenWithNoClose(SP.Res.dialogLoading15);
                        }

                        SP.SOD.executeOrDelayUntilScriptLoaded(showLoading, "sp.js");
                    } else {
                        var loader = $('#MWG_Loader_<%= WebPartId %>');
                        var div = $('#WebPart<%= Qualifier %>');

                        loader.css('top', (div.height() - loader.height()) / 2);
                        loader.css('left', (div.width() - loader.width()) / 2);

                        loader.show();
                    }
                });
            }

            SP.SOD.executeOrDelayUntilScriptLoaded(initializeEPMLoader, 'jquery.min.js');
        }
    </SharePoint:ScriptBlock>

    <div id="MWG_Header" style="overflow: hidden; display: <%= ShowToolbar ? "block" : "none" %>">
        <div id="MWG_Pivot">
            <div id="MWG_Pivot_Active" class="mwg-menuitem selected" data-filter="active">Active</div>
            <div id="MWG_Pivot_Completed" class="mwg-menuitem" data-filter="completed">Completed</div>
            <div id="MWG_Pivot_Selector" class="mwg-menuitem selector">...</div>
            <div id="MWG_PivotMenu_wrap" class="mwg-menuitem">
                <div id="MWG_PivotMenu">
                    <ul>
                        <li class="mwg-mi-clear" data-filter="clear">Clear Filter</li>
                        <li class="mwg-smi">
                            <span>Work Types</span>
                            <div class="mwg-submenu-wrap">
                                <div class="mwg-submenu">
                                    <ul id="MWG_WorkType_Menu"></ul>
                                </div>
                            </div>
                        </li>
                        <li class="mwg-smi">
                            <span>Created By</span>
                            <div class="mwg-submenu-wrap">
                                <div class="mwg-submenu">
                                    <ul id="MWG_CreatedBy_Menu"></ul>
                                </div>
                            </div>
                        </li>
                        <li class="mwg-smi">
                            <span>Priority</span>
                            <div class="mwg-submenu-wrap">
                                <div class="mwg-submenu">
                                    <ul id="MWG_Priority_Menu"></ul>
                                </div>
                            </div>
                        </li>
                        <li class="mwg-smi">
                            <span>Status</span>
                            <div class="mwg-submenu-wrap">
                                <div class="mwg-submenu">
                                    <ul id="MWG_Status_Menu"></ul>
                                </div>
                            </div>
                        </li>
                        <li class="mwg-smi">
                            <span>Flag</span>
                            <div class="mwg-submenu-wrap">
                                <div class="mwg-submenu">
                                    <ul id="MWG_Flag_Menu"></ul>
                                </div>
                            </div>
                        </li>
                        <li class="mwg-smi">
                            <span>Due</span>
                            <div class="mwg-submenu-wrap">
                                <div class="mwg-submenu">
                                    <ul id="MWG_Due_Menu"></ul>
                                </div>
                            </div>
                        </li>
                    </ul>
                    <div id="MWG_PivotClose">Close</div>
                </div>
            </div>
            <div id="MWG_Pivot_Search" class="mwg-menuitem">
                <input id="MWG_Search" type="text" />
            </div>
        </div>
    </div>


    <%--<div>
        Title<br />
        <input type="text" id="Ribbon_MyWork_Actions_Search" class="ms-cui-tb mwg-watermark" style="width: 100px;">
    </div>--%>

    <div id="EPMMyWorkGrid" style="width: 100%; height: 800px;">

        <SharePoint:ScriptBlock runat="server">
            $(function () {
                var loadMyWorkGrid = function () {
                    window.TreeGrid('<treegrid data_url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" data_timeout="180" data_repeat="2" data_method="Soap" data_function="Execute" data_namespace="workengine.com" data_param_function="GetMyWorkGridData" data_param_dataxml="<%= NonCompleteQuery.Replace(Environment.NewLine, string.Empty) %>" layout_url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" layout_timeout="180" layout_method="Soap" layout_function="Execute" layout_namespace="workengine.com" layout_param_function="GetMyWorkGridLayout" layout_param_dataxml="<%= NonCompleteQuery.Replace(Environment.NewLine, string.Empty) %>" suppressmessage="3" <%= DebugTag %>></treegrid>', 'EPMMyWorkGrid');
                };

                ExecuteOrDelayUntilScriptLoaded(loadMyWorkGrid, 'EPMLive.js');

                TGSetEvent("OnLoaded", "<%=WebPartId %>", MyWorkOnLoaded);
            });
        </SharePoint:ScriptBlock>

    </div>

    <div id="MWG_SaveRowHtml" style="display: none;">
        <div class="MWG_SaveRow" onclick="saveRow('gridId','rowId')">&nbsp;</div>
        <div class="MWG_CancelRowEdit" onclick="cancelRowEdit('gridId','rowId')">&nbsp;</div>
    </div>

    <div id="MWG_SaveView" style="display: none;">
        <div style="width: 225px; padding: 10px;">
            Name:&nbsp;
        <input id="MWG_ViewName" type="text" />
            <br />
            <input id="MWG_DefaultView" type="checkbox" />
            Default View<br />
            <input id="MWG_PersonalView" type="checkbox" <%= UserHasDesignerPermission ? string.Empty : @"checked=""checked""" %> />
            Personal View<br />
            <br />
            <input type="button" style="float: left; width: 90px; margin-right: 5px;" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, MyWorkGrid.getSavingViewInfo(this)); return false;" class="ms-ButtonHeightWidth" target="_self" />
            <input type="button" style="float: left; width: 90px;" value="Cancel" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-ButtonHeightWidth" target="_self" />
        </div>
    </div>

    <div id="MWG_RenameView" style="display: none;">
        <div style="width: 250px; padding: 10px;">
            Current Name:&nbsp;<span id="MWG_CurrentView"></span>
            <br />
            <br />
            <div style="float: left;">New Name:&nbsp;</div>
            <input id="MWG_ViewNewName" type="text" style="float: left;" />
            <br />
            <br />
            <br />
            <input type="button" style="float: left; width: 90px; margin-right: 5px;" value="OK" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, this.parentNode.children[4].value); return false;" class="ms-ButtonHeightWidth" target="_self" />
            <input type="button" style="float: left; width: 90px;" value="Cancel" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-ButtonHeightWidth" target="_self" />
        </div>
    </div>

    <SharePoint:ScriptBlock runat="server">
        var siteUrl = '<%= WebUrl %>', mwWebPartHeight = <%= !string.IsNullOrEmpty(WebPartHeight) ? WebPartHeight : "0" %>, allowGlobalViewCreation = <%= UserHasDesignerPermission ? "true" : "false" %>, myWorkWebPartSelectionCheckBox = 'SelectionCbx<%= WebPartPageComponentId %>', masterView = '<%= DefaultGlobalView %>', nonCompleteQuery = '<%= NonCompleteQuery.Replace(Environment.NewLine, string.Empty) %>', completeQuery = '<%= CompleteQuery.Replace(Environment.NewLine, string.Empty) %>', newItemLists = [<%= NewItemButtonLists %>], myWorkWebPartId = '<%= WebPartId %>', myWorkWebPartQualifier = '<%= Qualifier %>', selectMyWorkWebPart = <%= TotalWebPartCount == 1 ? "true" : "false" %>, userId = <%= UserId %>, requestedView = '<%= RequestedView != null ? Convert.ToBase64String(Encoding.ASCII.GetBytes(RequestedView)) : string.Empty %>', requestedViewType = '<%= RequestedViewType != null ? Convert.ToBase64String(Encoding.ASCII.GetBytes(RequestedViewType)) : string.Empty %>', currentWebId = '<%= WebId %>', workFilters = { daysAgoEnabled: <%= DaysAgoEnabled.ToString().ToLower() %>, daysAgo: <%= DaysAgo %>, daysAfterEnabled: <%= DaysAfterEnabled.ToString().ToLower() %>, daysAfter: <%= DaysAfter %> }, mwNewItemIndicator = { enabled: <%= IsNewItemIndicatorEnabled.ToString().ToLower() %>, days: <%= NewItemIndicatorDays %> };
        var epmLiveMyWork = window.epmLiveMyWork || {};
        epmLiveMyWork.regionalSettings = {
            decimalSeparator: '<%= DecimalSeparator %>',
            groupSeparator: '<%= GroupSeparator %>'
        };
    </SharePoint:ScriptBlock>

</div>
