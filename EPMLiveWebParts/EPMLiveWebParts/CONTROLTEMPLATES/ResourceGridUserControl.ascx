<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="EPMLiveCore" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResourceGridUserControl.ascx.cs" Inherits="EPMLiveWebParts.ResourceGridUserControl" %>

<asp:Panel ID="pnlGrid" runat="server">
    <style type="text/css">
        .rg-clear-fix:after {
            content: ".";
            display: block;
            clear: both;
            visibility: hidden;
            line-height: 0;
            height: 0;
        }

        .rg-clear-fix {
            zoom: 1;
        }
        
        .callout {
            position: relative;
            margin: 18px 0;
            padding: 18px 20px;
            background-color: #eef4f9;
            /* easy rounded corners for modern browsers */
            -moz-border-radius: 6px;
            -webkit-border-radius: 6px;
            border-radius: 6px;
            width: 220px;
            z-index: 10000;
            display: none;
            position: fixed;
        }
        
        .callout .notch {
            position: absolute;
            top: -10px;
            left: 20px;
            margin: 0;
            border-top: 0;
            border-left: 10px solid transparent;
            border-right: 10px solid transparent;
            border-bottom: 10px solid #eef4f9;
            padding: 0;
            width: 0;
            height: 0;
            /* ie6 height fix */
            font-size: 0;
            line-height: 0;
             /* ie6 transparent fix */
            _border-right-color: pink;
            _border-left-color: pink;
            _filter: chroma(color=pink);
        }

        .border-callout { border: 1px solid #c5d9e8; padding: 17px 19px; }
        
        .border-callout .border-notch { border-bottom-color: #c5d9e8; top: -11px; }
        
        .watermark {
            font-size: 13px !important;
            top: 6px !important;
        }
        
        #EPMLiveResourceGridSelector {
            padding: 2px 5px;
            background-color: rgba(255, 255, 255, 0.85);
            border: 1px solid #ABABAB;
            color: #444444;
            color: inherit;
            font-family:"Segoe UI","Segoe",Tahoma,Helvetica,Arial,sans-serif;
            font-size:13px;
            vertical-align: middle;
            outline: none;
            width: 205px;
        }
        
        #EPMLiveResourceGridSelector:hover {
            border-color:#92C0E0;
        }

        #EPMLiveResourceGridSelector:focus {
            border-color:#92C0E0;
        }
        
        .EPMLiveResourceGridGroup {
            border-bottom: 1px solid #ABABAB;
        }
        
        .EPMLiveResourceGridGroupTitle {
            padding-top: 14px;
            font-weight: bold;
            font-weight: bold;
            height: 22px;
            padding-bottom: 3px;
        }
        
        .EPMLiveResourceGridGroupTitle > a {
            color: #444444 !important;
            text-decoration: none !important;
        }
        
        .EPMLiveResourceGridGroupPrefix {
            color: #777777;
        }
        
        .EPMLiveResourceGridGroupPostfix {
            font-weight: normal;
        }
        
        .EPMLiveResourceGridPicture {
            width:100%;
            padding: 2.5px;
            text-align:center;
        }
        
        .EPMLiveResourceGridPicture > img {
            padding: 2.5px;
            border: 1px solid #CCCCCC;
            background-color: #ffffff;
        }
        
        .EPMLiveResourceGridPanelHovered {
            background-color: #E6F2FB !important;
            background-image: url(<%= WebUrl %>/_layouts/epmlive/treegrid/resourcegrid/blackcheck.png) !important;
            background-position: center center !important;
            background-repeat: no-repeat !important;
            cursor: pointer;
            cursor: hand;
        }
        
        .EPMLiveResourceGridPanelHoveredSelected {
            background-image:url(<%= WebUrl %>/_layouts/epmlive/treegrid/resourcegrid/whitecheck.png) !important;
            background-position: center center !important;
            background-color: #0072C6 !important;
            border-right-color: rgba(156, 206, 240, 0.5) !important;
            cursor: pointer;
            cursor: hand;
        }
        
        .ui-corner-all, .ui-corner-bottom, .ui-corner-right, .ui-corner-br {
            border-bottom-right-radius: 0;
        }
        
        .ui-corner-all, .ui-corner-bottom, .ui-corner-left, .ui-corner-bl {
            border-bottom-left-radius: 0;
        }
        
        .ui-corner-all, .ui-corner-top, .ui-corner-right, .ui-corner-tr {
            border-top-right-radius: 0;
        }
        
        .ui-corner-all, .ui-corner-top, .ui-corner-left, .ui-corner-tl {
            border-top-left-radius: 0;
        }
        
        .ui-menu-item {
            padding: 1px 5px 3px;
            white-space: nowrap;
            border: 1px solid transparent;
            cursor: pointer;
            margin: 0;
            font-family: "Segoe UI","Segoe",Tahoma,Helvetica,Arial,sans-serif;
            font-size: 13px;
            color: #444444;
        }
        
        .ui-state-hover {
            border: none !important;
            background: none !important;
            background-color: #E6F2FB !important;
            color: #444444 !important;
            margin: 0;
        }
        
        .ui-autocomplete {
            max-height: 400px; 
            overflow-y: auto; 
            overflow-x: hidden;
        }
    </style>
    
    <div id="EPMLoader" style="display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; border: 1px solid #ebeef2; white-space: nowrap; position: absolute; background-color: rgb(255, 255, 255);">
        <img style="margin: 30px 10px; vertical-align: middle" title="Loading..." alt="Loading..." src="<%= WebUrl %>/_layouts/IMAGES/PROGRESS-CIRCLE-24.GIF"/>
        <span style="text-align: center; margin: 30px 10px; white-space: nowrap; color: black; vertical-align: middle; overflow: hidden; font-family:Verdana; font-size:12px; color:#686868;">Loading...</span>
    </div>
    
    <script type="text/javascript">
        function initializeEPMLoader() {
            $(function () {
                var loader = $('#EPMLoader');
                var win = $(window);

                loader.css('top', ((win.height() - loader.height()) / 2) - 100);
                loader.css('left', (win.width() - loader.width()) / 2);

                loader.show();
            });
        }

        SP.SOD.executeOrDelayUntilScriptLoaded(initializeEPMLoader, "jquery.min.js");
    </script>
    
    <div class="callout border-callout">
        <input id="EPMLiveResourceGridSelector" type="text"/>
        <b class="border-notch notch"></b>
        <b class="notch"></b>
    </div>
    
    <div id="EPMResourceGrid" class="rg-clear-fix" style="width:100%;height:800px;">
         <script type="text/javascript">
             function initializeResourceGridWP() {
                 $.getScript('<%= WebUrl %>/_layouts/epmlive/javascripts/libraries/jquery.watermark.js', function() {
                     epmLiveResourceGrid.views.userHasGlobalViewModificationPermission = <%= CurrentUserHasDesignerPermission.ToString(CultureInfo.InvariantCulture).ToLower() %>;
                     epmLiveResourceGrid.autoFocus = <%= AutoFocus.ToString(CultureInfo.InvariantCulture).ToLower() %>;
                     epmLiveResourceGrid.webpartQualifier = '<%= WebPartQualifier %>';
                     epmLiveResourceGrid.webpartHeight = '<%= WebPartHeight.Replace("px",string.Empty).Replace("height:",string.Empty) %>';
                     epmLiveResourceGrid.maxVScroll = <%= MaxVScroll %>;
                     epmLiveResourceGrid.pfeInstalled = <%= PFEInstalled.ToString(CultureInfo.InvariantCulture).ToLower() %>;
                     epmLiveResourceGrid.reports.wcReportId = '<%= WcReportId %>';
                     epmLiveResourceGrid.userIsSiteAdmin = <%= SPContext.Current.Web.CurrentUser.IsSiteAdmin.ToString().ToLower() %>;

                     window.TreeGrid('<treegrid Data_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Data_Timeout="0" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Function="GetResourcePoolDataGrid" Data_Param_Dataxml="<%= DataXml %>" Layout_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Layout_Timeout="0" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Function="GetResourcePoolLayoutGrid" Layout_Param_Dataxml="<%= LayoutXml %>" SuppressMessage="3" <%= DebugTag %>></treegrid>', 'EPMResourceGrid');
                 }, true);
             }

             SP.SOD.executeOrDelayUntilScriptLoaded(initializeResourceGridWP, "EPMLive.ResourceGrid.js");
         </script>
    </div>

    <script id="RWPSaveView-<%= WebPartId %>" type="text/html">
        <div style="padding:10px;">
          Name: <input id="RWPSaveView-Name-<%= WebPartId %>" type="text" /><br />
          <input id="RWPSaveView-Default-<%= WebPartId %>" type="checkbox" />Default View<br />
          <input id="RWPSaveView-Personal-<%= WebPartId %>" type="checkbox" <%= !CurrentUserHasDesignerPermission ? "checked=\"yes\" disabled" : string.Empty %> />Personal View<br /><br />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, epmLiveResourceGrid.views.save({name: $($(this).parent().find('input')[0]).val(), isdefault: $($(this).parent().find('input')[1]).is(':checked'), ispersonal: $($(this).parent().find('input')[2]).is(':checked')})); return false;" value="OK" style="float:left;width:90px;margin-right:5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float:left;width:90px;" />
        </div>
    </script>
    <script id="RWPRenameView-<%= WebPartId %>" type="text/html">
        <div style="padding:10px;">
          Current name: <b><span id="RWPRenameView-CurrentName-<%= WebPartId %>"></span></b><br /><br />
          New name: <input id="RWPRenameView-NewName-<%= WebPartId %>" type="text" /><br /><br />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, epmLiveResourceGrid.views.rename($($(this).parent().find('input')[0]).val())); return false;" value="OK" style="float:left;width:90px;margin-right:5px;" />
          <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float:left;width:90px;" />
        </div>
    </script>
</asp:Panel>
<asp:Panel ID="pnlError" runat="server" Visible="False">
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Panel>