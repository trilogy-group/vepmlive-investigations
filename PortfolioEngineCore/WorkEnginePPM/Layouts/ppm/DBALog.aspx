<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBALog.aspx.cs" Inherits="WorkEnginePPM.DBALog" DynamicMasterPageFile="~masterurl/default.master" %>
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
            <div style="display:none;">
                <asp:Button ID="btnRefresh" runat="server" Text="Button" OnClick="btnRefresh_Click" />
                <asp:Button ID="btnPrevious" runat="server" Text="Button" OnClick="btnPrevious_Click" />
                <asp:Button ID="btnNext" runat="server" Text="Button" OnClick="btnNext_Click" />
                <asp:TextBox ID="idPage" runat="server"></asp:TextBox>
                <asp:TextBox ID="idRowsPerPageCount" runat="server"></asp:TextBox>
                <asp:TextBox ID="idSelectedGuid" runat="server"></asp:TextBox>
                <asp:TextBox ID="idSelectedValue" runat="server"></asp:TextBox>
            </div>
            <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
            <div id="idToolbarDiv"></div>
            <dg1:DGridUserControl id="dgrid1" runat="server" />
        </div>
    </div>
<script type="text/javascript">
    var toolbarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", id: "btnPrevious", name: "PREV", img: "formatmap16x16_2.png", style: "top: -36px; left: -186px;", tooltip: "go to previous page", onclick: "return toolbar_event('btnPrevious');" },
            { type: "button", id: "btnRefresh", name: "REFRESH", img: "refresh.png", tooltip: "Refresh and go to first page", onclick: "return toolbar_event('btnRefresh');" },
            { type: "button", id: "btnNext", name: "NEXT", img: "formatmap16x16_2.png", style: "top: -18px; left: -248px;", tooltip: "go to next page", onclick: "return toolbar_event('btnNext');" }
        ]
    };

    var toolbar = new Toolbar(toolbarData);
    var dgrid1 = window.<%=dgrid1.UID%>;
    var dgrid1_selectedRow = 0;

    function dgrid1_OnRowSelect(rowid, cellindex) {
        dgrid1_selectedRow = rowid;
    };

    var OnLoad = function (event) {
        toolbar.Render();
        OnResize();
        dgrid1.addEventListener("onRowSelect", dgrid1_OnRowSelect);
    };

    function OnResize(event) {
        var top = dgrid1.GetTop();
        var newHeight = document.documentElement.clientHeight - top - 15;
        dgrid1.SetHeight(newHeight);
        var newWidth = document.documentElement.clientWidth - 9;
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
            case "btnRefresh":
                <%= Page.ClientScript.GetPostBackEventReference(btnRefresh, String.Empty) %>;
                break;
            case "btnNext":
                <%= Page.ClientScript.GetPostBackEventReference(btnNext, String.Empty) %>;
                break;
            case "btnPrevious":
                <%= Page.ClientScript.GetPostBackEventReference(btnPrevious, String.Empty) %>;
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
