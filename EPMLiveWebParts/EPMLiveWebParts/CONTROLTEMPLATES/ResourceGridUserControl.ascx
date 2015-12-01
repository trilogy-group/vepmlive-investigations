<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="EPMLiveCore" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResourceGridUserControl.ascx.cs" Inherits="EPMLiveWebParts.ResourceGridUserControl" %>

<asp:Panel ID="pnlGrid" runat="server">
    <SharePoint:StyleBlock runat="server">
        input[type=text]::-ms-clear {
            display: none !important;
        }
        
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
            text-align:center;
        }
        
        .EPMLiveResourceGridPicture > img {
            padding: 1px;
            border: 1px solid #eeeeee;
            background-color: #ffffff;
            height:25px;
            width:25px;
            margin-top:3px;
        }

        .HideCol0ProfilePic {
           padding-bottom: 0px;
           padding-top: 0px;
        }
        
        .EPMLiveResourceGridPanelHovered {
            background-color: #E6F2FB !important;
            background-image: url(/_layouts/15/epmlive/treegrid/resourcegrid/blackcheck.png) !important;
            background-position: center center !important;
            background-repeat: no-repeat !important;
            cursor: pointer;
            cursor: hand;
        }
        
        .EPMLiveResourceGridPanelHoveredSelected {
            background-image:url(/_layouts/15/epmlive/treegrid/resourcegrid/whitecheck.png) !important;
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
        
        .s4-wpTopTable {
            border: none !important;
        }

        .ms-webpartPage-root {
         border-spacing: 0px !important;
     }
       .ms-webpartzone-cell {
         margin: 0px !important;
     }

    </SharePoint:StyleBlock>
    <div id="test"></div>
    <div id="ResourceGridLoader" class="ms-dlgContent" tabindex="-1" style="z-index: 1505; display: none; width: 367px; height: 146px; left: 775.5px; top: 269px;">
        <div class="ms-dlgBorder" style="width: 365px; height: 144px;">
            <input type="button" value="Wrap focus to the end of the dialog" class="ms-accessible">
            <div class="ms-hidden">
                <span id="dlgTitleBtns" class="ms-dlgTitleBtns">
                    <a class="ms-dlgCloseBtn" title="Maximize" href="javascript:;">
                        <span style="padding: 8px; height: 16px; width: 16px; display: inline-block">
                            <span class="s4-clust" style="height: 16px; width: 16px; position: relative; display: inline-block; overflow: hidden;">
                                <img class="ms-dlgCloseBtnImg" style="left: -0px !important; top: -661px !important; position: absolute;" alt="Maximize" src="/_layouts/15/images/fgimg.png?rev=23">
                            </span>
                        </span>
                    </a>
                </span>
                <h1 title="Dialog" class="ms-dlgTitleText ms-accentText ms-dlg-heading" id="dialogTitleSpan" style="width: 0px;">Dialog</h1>
            </div>
            <div class="ms-dlgFrameContainer">
                <div style="width: 327px; height: 133px;">
                    <div style="padding: 39px 0px 30px;">
                        <div class="ms-dlgLoadingTextDiv ms-alignCenter">
                            <span style="padding-top: 6px; padding-right: 10px;">
                                <img src="/_layouts/15/images/gears_anv4.gif?rev=23" title="This animation indicates the operation is in progress. Click to remove this animated image.">
                            </span>
                            <span class="ms-core-pageTitle ms-accentText">Working on it...</span>
                        </div>
                        <div class="ms-textXLarge ms-alignCenter"></div>
                    </div>
                </div>
            </div>
            <input type="button" value="Wrap focus to the beginning of the dialog" class="ms-accessible">
        </div>
    </div>

    <div class="callout border-callout">
        <input id="EPMLiveResourceGridSelector" type="text" />
        <b class="border-notch notch"></b>
        <b class="notch"></b>
    </div>
    <div id="EPMResourceGrid" class="rg-clear-fix" style="width: 100%; height: 500px;">
        <SharePoint:ScriptBlock runat="server">
            fixedRibbon=false;
                function initializeResourceGridWP() {
            if (window.epmLiveMasterPageVersion >= 5.5) {
                    function showLoadingV2() {
                        var url = document.location.href.toLowerCase();
                        if (url.indexOf('resource%20pool.aspx') !== -1 || url.indexOf('_layouts') !== -1) {
                            EPM.UI.Loader.current().startLoading({ id: 'WebPart<%= WebPartQualifier %>', page: true, coverRibbon: true });
                        } else {
                            EPM.UI.Loader.current().startLoading({ id: 'WebPart<%= WebPartQualifier %>' });
                        }
                    }

                    SP.SOD.executeOrDelayUntilScriptLoaded(showLoadingV2, 'EPM.UI');
                } else {
                    if (document.location.href.toLowerCase().indexOf('resource.aspx') !== -1) {

                        function showLoading() {
                            epmLiveResourceGrid.loader = SP.UI.ModalDialog.showWaitScreenWithNoClose(SP.Res.dialogLoading15);
                        }

                        SP.SOD.executeOrDelayUntilScriptLoaded(showLoading, "sp.js");
                    } else {
                        var loader = $('#ResourceGridLoader');
                        var div = $('#WebPart<%= WebPartQualifier %>');

                        loader.css('top', (div.height() - loader.height()) / 2);
                        loader.css('left', (div.width() - loader.width()) / 2);

                        loader.show();
                    }
                }

                $.getScript('<%= WebUrl %>/_layouts/epmlive/javascripts/libraries/jquery.watermark.js', function() {
                    epmLiveResourceGrid.views.userHasGlobalViewModificationPermission = <%= CurrentUserHasDesignerPermission.ToString(CultureInfo.InvariantCulture).ToLower() %>;
                    epmLiveResourceGrid.autoFocus = <%= AutoFocus.ToString(CultureInfo.InvariantCulture).ToLower() %>;
                    epmLiveResourceGrid.webpartQualifier = '<%= WebPartQualifier %>';
                    epmLiveResourceGrid.webpartHeight = '<%= WebPartHeight.Replace("px",string.Empty).Replace("height:",string.Empty) %>';
                    epmLiveResourceGrid.maxVScroll = <%= MaxVScroll %>;
                    epmLiveResourceGrid.pfeInstalled = <%= PFEInstalled.ToString(CultureInfo.InvariantCulture).ToLower() %>;
                    epmLiveResourceGrid.reports.wcReportId = '<%= WcReportId %>';
                    epmLiveResourceGrid.userIsSiteAdmin = <%= SPContext.Current.Web.CurrentUser.IsSiteAdmin.ToString().ToLower() %>;
                    epmLiveResourceGrid.ribbonBehavior = <%=RibbonBehavior %>;
                    epmLiveResourceGrid.IsRootWeb = <%= SPContext.Current.Web.IsRootWeb.ToString().ToLower() %>;
                    epmLiveResourceGrid.WebId='<%=_reqWebId%>';
                    epmLiveResourceGrid.ListId='<%=_reqListId%>';
                    epmLiveResourceGrid.ItemId='<%=_reqId%>';
                    epmLiveResourceGrid.LaunchInForm=<%=LaunchInForm.ToString().ToLower()%>;
                    epmLiveResourceGrid.UserHaveResourceCenterPermission = <%= CurrentUserHaveResourceCenterPermission().ToString(CultureInfo.InvariantCulture).ToLower() %>;

                    window.TreeGrid('<treegrid data_url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" data_timeout="0" data_method="Soap" data_function="Execute" data_namespace="workengine.com" data_param_function="GetResourcePoolDataGrid" data_param_dataxml="<%= DataXml %>" layout_url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" layout_timeout="0" layout_method="Soap" layout_function="Execute" layout_namespace="workengine.com" layout_param_function="GetResourcePoolLayoutGrid" layout_param_dataxml="<%= LayoutXml %>" suppressmessage="3" <%= DebugTag %>></treegrid>', 'EPMResourceGrid');
                }, true);

                window.epmLiveResourceGrid.actions.getNewFormUrl = epmLive.currentWebFullUrl + '/' + '<%=NewFormUrl %>';
            }

            SP.SOD.executeOrDelayUntilScriptLoaded(initializeResourceGridWP, "EPMLive.ResourceGrid.js");
        </SharePoint:ScriptBlock>
    </div>
    <script id="RWPSaveView-<%= WebPartId %>" type="text/html">
        <div style="padding: 10px;">
            Name:
            <input id="RWPSaveView-Name-<%= WebPartId %>" type="text" /><br />
            <input id="RWPSaveView-Default-<%= WebPartId %>" type="checkbox" />Default View<br />
            <input id="RWPSaveView-Personal-<%= WebPartId %>" type="checkbox" <%= !CurrentUserHasDesignerPermission ? "checked=\"yes\" disabled" : string.Empty %> />Personal View<br />
            <br />
            <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, epmLiveResourceGrid.views.save({ name: $($(this).parent().find('input')[0]).val(), isdefault: $($(this).parent().find('input')[1]).is(':checked'), ispersonal: $($(this).parent().find('input')[2]).is(':checked') })); return false;" value="OK" style="float: left; width: 90px; margin-right: 5px;" />
            <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float: left; width: 90px;" />
        </div>
    </script>
    <script id="RWPRenameView-<%= WebPartId %>" type="text/html">
        <div style="padding: 10px;">
            Current name: <b><span id="RWPRenameView-CurrentName-<%= WebPartId %>"></span></b>
            <br />
            <br />
            New name:
            <input id="RWPRenameView-NewName-<%= WebPartId %>" type="text" /><br />
            <br />
            <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, epmLiveResourceGrid.views.rename($($(this).parent().find('input')[0]).val())); return false;" value="OK" style="float: left; width: 90px; margin-right: 5px;" />
            <input class="ms-ButtonHeightWidth" type="button" onclick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;" value="Cancel" style="float: left; width: 90px;" />
        </div>
    </script>
</asp:Panel>

<asp:Panel ID="pnlError" runat="server" Visible="False">
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Panel>
