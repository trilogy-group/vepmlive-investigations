<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBAResources.aspx.cs" Inherits="WorkEnginePPM.DBAResources" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="styles/form.css" />
<link rel="stylesheet" type="text/css" href="styles/dialognew.css" />
<link rel="stylesheet" type="text/css" href="tools/toolbar.css" />
<script src="tools/toolbar.js" type="text/javascript"></script>

<style type="text/css">
    .ms-dialog .ms-bodyareacell {
    padding: 0 !important;
}
</style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
	<div style="margin-top:5px;margin-bottom:5px;padding-left:3px;padding-right:3px;">
<div style="display: block;" >
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <div id="idToolbarDiv"></div>
    <dg1:DGridUserControl id="dgrid1" runat="server" />
</div>    </div>
<script type="text/javascript">
    var toobarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", id: "btnDelete", name: "DELETE ITEM", img: "formatmap16x16_2.png", style: "top: -270px; left: -270px;", tooltip: "Delete",  onclick: "return toolbar_event('btnDelete');", disabled: true },
            { type: "button", id: "btnRefresh", name: "REFRESH", img: "refresh.png", tooltip: "Refresh", onclick: "return toolbar_event('btnRefresh');" }
        ]
    };
    var toolbar = new Toolbar(toobarData);
    var dgrid1 = window.<%=dgrid1.UID%>;
    var dgrid1_selectedRow = 0;

    function dgrid1_OnRowSelect(rowid, cellindex) {
        dgrid1_selectedRow = rowid;
        if (rowid != null && rowid > 0) {
            toolbar.enableItem("btnDelete");
        }
        else {
            toolbar.disableItem("btnDelete");
        }
    };

    var OnLoad = function (event) {
        toolbar.Render();
        OnResize();
        dgrid1.addEventListener("onRowSelect", dgrid1_OnRowSelect);
        //window.setTimeout("window.<%=dgrid1.UID%>.autoSizeColumns();", 100);
    };

    function OnResize(event) {
        var lefttop = dgrid1.GetLeftTopPositions();
        var newHeight = document.documentElement.clientHeight - lefttop[1] - 8;
        dgrid1.SetHeight(newHeight);
        var newWidth = document.documentElement.clientWidth - lefttop[0] - 8;
        dgrid1.SetWidth(newWidth);
    };

    function SendRequest(sXML) {
         sURL = "./DBAdmin.ashx";
         return jsf_sendRequest(sURL, sXML);
    };

    function toolbar_event(event) {
        var sMode = "";
        var sDlgTitle = "";
        if (toolbar.isItemDisabled(event) == true)
            return;
        var sRowId = dgrid1_selectedRow;
        switch (event) {
            case "btnDelete":
                var sb = new StringBuilder();
                sb.append('<request function="DBAdminRequest" context="CanDeleteRes">');
                sb.append('<data');
                sb.append(' WRES_ID="' + dgrid1_selectedRow + '"');
                sb.append('/>');
                sb.append('</request>'); 
                var sRequest = sb.toString();
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var warning = "";
                if (json.reply.warning != null)
                    warning = "\nWARNING :\n" + json.reply.warning.message;

                var resname = dgrid1.GetCellValue(dgrid1_selectedRow, "RES_NAME");
                var b = window.confirm("You are about to delete resource " + resname + warning + "\n\nAre you sure?");
                if (b) {
                    var sb = new StringBuilder();
                    sb.append('<request function="DBAdminRequest" context="DeleteRes">');
                    sb.append('<data');
                    sb.append(' WRES_ID="' + dgrid1_selectedRow + '"');
                    sb.append('/>');
                    sb.append('</request>'); 
                    var sRequest = sb.toString();
                    var jsonString = SendRequest(sRequest);
                    var json = JSON_ConvertString(jsonString);
                    if (json.reply != null) {
                        if (jsf_alertError(json.reply.error) == true)
                            return false;
                    }
                    // if deleted  then remove row from grid
                    var sRowId = dgrid1_selectedRow;
                    dgrid1.deleteRow(sRowId);
                    dgrid1_OnRowSelect(null);
                }
                break;
            case "btnRefresh":
                __doPostBack('', '');
                break;
        }
    };

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
        window.addEventListener("resize", OnResize, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
        window.attachEvent("onresize", OnResize);
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
<%=RPETitle %>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
<%=RPETitle %>
</asp:Content>
