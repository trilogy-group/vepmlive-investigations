<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="EPMLiveCore" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignmentPlanner.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.AssignmentPlanner" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <style type="text/css">
        div.AP_Comment, div.AP_CommentDisabled, div.AP_CommentRead {
            width:20px;
            height:20px;
            background-image:url('<%= WebUrl %>/_layouts/epmlive/images/mywork/comment-green.png');
            background-repeat:no-repeat;
            background-position: center 1px;
            color:#fff;
            font-size:8px;
            font-weight:600;
            line-height:20px;
            text-align:center;
        }
        
        div.AP_CommentRead {
            background-image:url('<%= WebUrl %>/_layouts/epmlive/images/mywork/comment.png');
        }
        
        div.AP_CommentDisabled {
            background-image:none;
        }
        
        img.AP_Flag {
            cursor: pointer;
        }
        
        .GSGanttResource {
            display: none !important;
        }
        
        #EPMSplashContainer {
            background-image: url('<%= WebUrl %>/_layouts/epmlive/modal/overlay.png');
            bottom: 0;
            display: <%= SplashDisplay %>;
            left: 0;
            position: absolute;
            right: 0;
            top: 0;
            z-index: 99999999;
        }
        
        div#EPMSplash {
            background-image:url('<%= WebUrl %>/_layouts/epmlive/images/plannersplash.png');
            border: 2px solid #FFFFFF;
            color: #FFFFFF;
            font-family: Segoe UI Light,Verdana;
            height: 300px;
            left: 50%;
            margin-left: -225px;
            margin-top: -150px;
            position: absolute;
            top: 50%;
            width: 450px;
            z-index: 999999999;
        }
        
        #EPMSplash > h1 {
            font-size: 25px;
            left: 195px;
            letter-spacing: 0.5px;
            position: absolute;
            top: 30px;
            color: #ffffff !important;
        }
        
        #EPMSplash > span {
            bottom: 15px;
            font-size: 12px;
            letter-spacing: 1px;
            position: absolute;
            right: 15px;
        }
    </style>
    
    <script type="text/javascript">
        function initializeEPMSplash() {
            $(function () {
                var element = $('#s4-workspace');

                try {
                    var ele = $('.ms-dlgContent');
                    if (ele.length > 0) {
                        element = ele;
                    } else {
                        ele = $('.ms-dialog');

                        if (ele.length > 0) {
                            element = ele;
                        }
                    }
                } catch (e) {
                }

                element.append('<div id="EPMSplashContainer"><div id="EPMSplash"><h1 id="EPMSplashTitle">Assignment Planner</h1><span id="EPMSplashStatus">Initializing . . .</span></div></div>');
            });
        }

        SP.SOD.executeOrDelayUntilScriptLoaded(initializeEPMSplash, "jquery.min.js");

        function initializeAssignmentPlannerRibbon() {
            $('#EPMSplashStatus').text('Initializing Ribbon . . .');

            function addCustomPageComponent() {
                var customPageComponent = new ContextualTabWebPart.CustomPageComponent();

                var ribbonPageManager = window.SP.Ribbon.PageManager.get_instance();
                ribbonPageManager.addPageComponent(customPageComponent);
                ribbonPageManager.get_focusManager().requestFocusForComponent(customPageComponent);
            }

            function registerCustomPageComponent() {
                window.SP.SOD.registerSod("EPMLive.AssignmentPlanner.ContextualTabPageComponent.js", "/_layouts/epmlive/javascripts/EPMLive.AssignmentPlanner.ContextualTabPageComponent.js");
                window.SP.SOD.executeFunc("EPMLive.AssignmentPlanner.ContextualTabPageComponent.js", "ContextualWebPart.CustomPageComponent", addCustomPageComponent);
            }

            window.SP.SOD.executeOrDelayUntilScriptLoaded(registerCustomPageComponent, "sp.ribbon.js");
        }

        SP.SOD.executeOrDelayUntilScriptLoaded(initializeAssignmentPlannerRibbon, "EPMLive.AssignmentPlanner.Init.js");
    </script>

    <script id="APSaveView-<%= GridId %>" type="text/html">
        <div style="padding:10px;">
          Name: <input id="APSaveView-Name-<%= GridId %>" type="text" /><br />
          <input id="APSaveView-Default-<%= GridId %>" type="checkbox" />Default View<br />
          <input id="APSaveView-Personal-<%= GridId %>" type="checkbox" <%= !CurrentUserHasDesignerPermission ? "checked=\"yes\" disabled" : string.Empty %> />Personal View<br /><br />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, {name: $($(this).parent().find('input')[0]).val(), isdefault: $($(this).parent().find('input')[1]).is(':checked'), ispersonal: $($(this).parent().find('input')[2]).is(':checked')}); return false;" value="OK" style="float:left;width:90px;margin-right:5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float:left;width:90px;" />
        </div>
    </script>

    <script id="APRenameView-<%= GridId %>" type="text/html">
        <div style="padding:10px;">
          Current name: <b><span id="APRenameView-CurrentName-<%= GridId %>"></span></b><br /><br />
          New name: <input id="APRenameView-NewName-<%= GridId %>" type="text" /><br /><br />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, $($(this).parent().find('input')[0]).val()); return false;" value="OK" style="float:left;width:90px;margin-right:5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float:left;width:90px;" />
        </div>
    </script>

    <script id="APOpenModel-<%= GridId %>" type="text/html">
        <div style="padding:10px;">
          Select Model:
          <select id="APOpenModel-ModelList-<%= GridId %>" style="display: block;margin-top: 5px;margin-bottom: 5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, $($(this).parent().find('select')[0]).val()); return false;" value="OK" style="float:left;width:90px;margin-right:5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float:left;width:90px;" />
        </div>
    </script>
    
    <script id="APCalendar-<%= GridId %>" type="text/html">
        <div style="padding:10px;">
          <div style="display: block; overflow:hidden;">
              <input class="ms-ButtonHeightWidth" type="button" onclick="var newDate = $('#EpmLiveCalendarFrame').contents().find('#DateTimeControl_DateTimeControlDate').val(); SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, {type: '{0}', date: newDate}); return false;" value="OK" style="float:left;width:90px;margin-right:5px;" />
              <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float:left;width:90px;" />
          </div>
          <div style="display: block;">
              <iframe id="EpmLiveCalendarFrame" src="<%= WebUrl %>/_layouts/epmlive/calendar.aspx?datetime={1}&dateonly=true" style="border:none;height:210px;width:200px;display:block;"></iframe>
          </div>
        </div>
    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Panel ID="pnlGrid" runat="server">
        <div id="EpmLiveAssignmentPlannerGrid" style="width:100%;height:800px;">
            <script type="text/javascript">
                function initializeAssignmentPlanner() {
                    $('#EPMSplashStatus').text('Initializing Assignment Planner . . .');
                    
                    window.epmLiveAssignmentPlanner.id = '<%= GridId %>';
                    window.epmLiveAssignmentPlanner.startDate = '<%= StartDate %>';
                    window.epmLiveAssignmentPlanner.dueDate = '<%= DueDate %>';
                    window.epmLiveAssignmentPlanner.forceHeight = true;
                    window.epmLiveAssignmentPlanner.userId = <%= SPWeb.CurrentUser.ID.ToString(CultureInfo.InvariantCulture) %>;
                    window.epmLiveAssignmentPlanner.views.userHasGlobalViewModificationPermission = <%= CurrentUserHasDesignerPermission.ToString(CultureInfo.InvariantCulture).ToLower() %>;

                    window.TreeGrid('<treegrid Data_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Data_Timeout="0" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Function="AssignmentPlanner_GetGridData" Data_Param_Dataxml="<%= DataXml %>" Layout_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Layout_Timeout="0" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Function="AssignmentPlanner_GetGridLayout" Layout_Param_Dataxml="<%= LayoutXml %>" Export_Url="<%= WebUrl %>/_layouts/epmlive/PlannerExcelExport.aspx" SuppressMessage="3" <%= DebugTag %>></treegrid>', 'EpmLiveAssignmentPlannerGrid');
                    
                    window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("EPMLive.AssignmentPlanner.Init.js");
                    
                    $('#EPMSplashStatus').text('Loading data . . .');
                }

                SP.SOD.executeOrDelayUntilScriptLoaded(initializeAssignmentPlanner, "EPMLive.AssignmentPlanner.js");
            </script>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Visible="False">
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Assignment Planner
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Assignment Planner
</asp:Content>
