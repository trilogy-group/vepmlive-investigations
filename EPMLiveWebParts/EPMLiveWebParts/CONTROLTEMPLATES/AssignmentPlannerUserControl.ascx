<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignmentPlannerUserControl.ascx.cs" Inherits="EPMLiveWebParts.AssignmentPlannerUserControl" %>
<asp:Panel ID="pnlGrid" runat="server">
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

        #s4-ribbonrow {
            height:140px !important
        }
    </style>

    <div id="epmLiveAssignmentPlanner" style="width:100%;height:100%;">
        <script type="text/javascript">
            function initializeAssignmentPlanner() {
                window.epmLive.assignmentPlanner.id('<%= WebPartId %>');
                window.epmLive.assignmentPlanner.userId = <%= SPWeb.CurrentUser.ID.ToString(CultureInfo.InvariantCulture) %>;
                window.epmLive.assignmentPlanner.views.userHasGlobalViewModificationPermission = <%= CurrentUserHasDesignerPermission.ToString(CultureInfo.InvariantCulture).ToLower() %>;
                window.epmLive.assignmentPlanner.autoFocus = <%= AutoFocus.ToString(CultureInfo.InvariantCulture).ToLower() %>;
                window.epmLive.assignmentPlanner.maxVScroll = <%= MaxVScroll %>;
                window.epmLive.assignmentPlanner.webpartQualifier = '<%= WebPartQualifier %>';

                window.TreeGrid('<treegrid Data_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Data_Timeout="0" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Function="AssignmentPlanner_GetGridData" Data_Param_Dataxml="<%= DataXml %>" Layout_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Layout_Timeout="0" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Function="AssignmentPlanner_GetGridLayout" Layout_Param_Dataxml="<%= LayoutXml %>" Export_Url="<%= WebUrl %>/_layouts/epmlive/PlannerExcelExport.aspx" <%= InDebugMode ? @"debug=""""" : string.Empty %>></treegrid>', 'epmLiveAssignmentPlanner');
            }

            SP.SOD.executeOrDelayUntilScriptLoaded(initializeAssignmentPlanner, "EPMLive.AssignmentPlanner.js");
        </script>
    </div>
    <script id="APSaveView-<%= WebPartId %>" type="text/html">
        <div style="padding:10px;">
          Name: <input id="APSaveView-Name-<%= WebPartId %>" type="text" /><br />
          <input id="APSaveView-Default-<%= WebPartId %>" type="checkbox" />Default View<br />
          <input id="APSaveView-Personal-<%= WebPartId %>" type="checkbox" <%= !CurrentUserHasDesignerPermission ? "checked=\"yes\" disabled" : string.Empty %> />Personal View<br /><br />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, epmLive.assignmentPlanner.views.save({name: $($(this).parent().find('input')[0]).val(), isdefault: $($(this).parent().find('input')[1]).is(':checked'), ispersonal: $($(this).parent().find('input')[2]).is(':checked')})); return false;" value="OK" style="float:left;width:90px;margin-right:5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float:left;width:90px;" />
        </div>
    </script>
    <script id="APRenameView-<%= WebPartId %>" type="text/html">
        <div style="padding:10px;">
          Current name: <b><span id="APRenameView-CurrentName-<%= WebPartId %>"></span></b><br /><br />
          New name: <input id="APRenameView-NewName-<%= WebPartId %>" type="text" /><br /><br />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, epmLive.assignmentPlanner.views.rename($($(this).parent().find('input')[0]).val())); return false;" value="OK" style="float:left;width:90px;margin-right:5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float:left;width:90px;" />
        </div>
    </script>
    <script id="APOpenModel-<%= WebPartId %>" type="text/html">
        <div style="padding:10px;">
          Select Model:
          <select id="APOpenModel-ModelList-<%= WebPartId %>" style="display: block;margin-top: 5px;margin-bottom: 5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, epmLive.assignmentPlanner.models.open($($(this).parent().find('select')[0]).val())); return false;" value="OK" style="float:left;width:90px;margin-right:5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float:left;width:90px;" />
        </div>
    </script>
</asp:Panel>
<asp:Panel ID="pnlError" runat="server" Visible="False">
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Panel>
