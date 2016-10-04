<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmallParentUrlDialog.aspx.cs"
    Inherits="EPMLiveCore.SmallParentUrlDialog" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid.css" />
    <%--START external css and javascript links--%>
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid_skins.css" />
    <script>        _css_prefix = "DHTML/xgrid/"; _js_prefix = "DHTML/xgrid/"; </script>
    <script src="DHTML/xgrid/dhtmlxcommon.js"></script>
    <script src="DHTML/xgrid/dhtmlxgrid.js"></script>
    <script src="DHTML/xgrid/dhtmlxgridcell.js"></script>
    <script src="DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
    <script type="text/javascript" src="jQueryLibrary/jquery-1.5.2.js"></script>
    <%--END external css and javascript links--%>
    <%--START actual page content--%>
    <div id="outerContainer" style="overflow: hidden">
        <div style="position: relative; height: 250px; overflow-y: auto;">
            <div style="width: 450px" id="loadinggrid" align="center">
                <img src="../images/GEARS_ANv4.GIF" style="vertical-align: middle;" />
                Loading Workspaces...
            </div>
            <div id="htmlGrdAlternateParentSites" style="width: 450px; height: 400px; 
                display: none">
            </div>
        </div>
        <div style="clear: both; height: 2em">
        </div>
        <div style="position: relative">
            <input type="button" id="btnSelect" class="ms-ButtonHeightWidth" style="float: left;
                width: auto !important;" value="Select" />
            <span style="display: block; width: 0.5em; float: left;"></span>
            <input type="button" id="btnCancel" class="ms-ButtonHeightWidth" style="float: left;
                width: auto !important; margin-left: 0.2em;" value="Cancel" />
        </div>
        <input type="hidden" id="hdnSelectedWorkspaceUrl" />
    </div>
    <%--END actual page content--%>
    <%--START inline javascript--%>
    <script language="javascript">

        var grdChangeParentUrl;
        grdChangeParentUrl = new dhtmlXGridObject('htmlGrdAlternateParentSites');
        grdChangeParentUrl.setImagePath("dhtml/xgrid/imgs/");
        grdChangeParentUrl.setSkin("modern");

        grdChangeParentUrl.setImageSize(1, 1);
        grdChangeParentUrl.attachEvent("onXLE", clearLoader);
        grdChangeParentUrl.attachEvent("onRowSelect", grdAlternateParentSitesChange);
        grdChangeParentUrl.enableAutoHeight(true);
        grdChangeParentUrl.init();

        //        grdChangeParentUrl.setColWidth(0, "30px");
        //        grdChangeParentUrl.setColWidth(1, "30px");

        function clearLoader(id) {
            document.getElementById("htmlGrdAlternateParentSites").style.display = "";
            document.getElementById("loadinggrid").style.display = "none";
            grdChangeParentUrl.cellWidthType = 'px';
            grdChangeParentUrl.setColWidth(0, '160');
            grdChangeParentUrl.setColWidth(1, '280');
            //grdChangeParentUrl.enableAutoWidth(true);
        }

        function grdAlternateParentSitesChange(url) {
            $("#hdnSelectedWorkspaceUrl").val(url);
        }

        $(function () {

            grdChangeParentUrl.loadXML("getworkspacexml.aspx?sitecreate=1");

            $('#btnSelect').click(function () {
                if (!$("#hdnSelectedWorkspaceUrl").val().trim().length) {
                    SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', -1, '');
                }
                else {
                    SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', 1, $("#hdnSelectedWorkspaceUrl").val());
                }
            });

            $('#btnCancel').click(function () {
                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', -1, '');
            });

        });

    </script>
    <%--END of inline script--%>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Application Page
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    My Application Page
</asp:Content>
