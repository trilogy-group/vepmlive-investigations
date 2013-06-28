<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Queuemanager_NAX.aspx.cs" Inherits="WorkEnginePPM.Queuemanager_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="styles/dialognew.css" />
<link rel="stylesheet" type="text/css" href="tools/toolbar.css" />
<script src="tools/toolbar.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_admin.css" />
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcontainer.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.js" type="text/javascript"></script>
<style type="text/css">
.ms-cui-tabBody {
    border-bottom: 0 !important;
}
BODY #s4-workspace {
    height: 100% !important;
}
html, body {
    width: 100%;
    height: 100%;
    margin: 0px;
    overflow: hidden;
}
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div style="display: block;" >
    <div style="display:none;">
        <asp:Button ID="btnRefresh" runat="server" Text="Button" OnClick="btnRefresh_Click" />
        <asp:Button ID="btnPrevious" runat="server" Text="Button" OnClick="btnPrevious_Click" />
        <asp:Button ID="btnNext" runat="server" Text="Button" OnClick="btnNext_Click" />
        <asp:TextBox ID="idPage" runat="server"></asp:TextBox>
        <asp:TextBox ID="idRowsPerPageCount" runat="server"></asp:TextBox>
    </div>
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <div id="idToolbarDiv"></div>
    <dg1:DGridUserControl id="dgrid1" runat="server" />
</div>
<script type="text/javascript">
    var shortDlgHeight = 200;
    var tallDlgHeight = 350;
    var toobarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", id: "btnTest", name: "TEST", img: "formatmap16x16_2.png", style: "top: -254px; left: -270px;", tooltip: "Test", onclick: "return toolbar_event('btnTest');" },
            { type: "button", id: "btnPrevious", name: "PREV", img: "formatmap16x16_2.png", style: "top: -36px; left: -186px;", tooltip: "go to previous page", onclick: "return toolbar_event('btnPrevious');" },
            { type: "button", id: "btnRefresh", name: "REFRESH", img: "refresh.png", tooltip: "Refresh and go to first page", onclick: "return toolbar_event('btnRefresh');" },
            { type: "button", id: "btnNext", name: "NEXT", img: "formatmap16x16_2.png", style: "top: -18px; left: -248px;", tooltip: "go to next page", onclick: "return toolbar_event('btnNext');" },
            { type: "button", id: "btnCheck", name: "CHECK", img: "heart.gif", tooltip: "Check QueueManager Status", onclick: "return toolbar_event('btnCheck');" }
        ]
    };

    var toolbar = new Toolbar(toobarData);
    
    var dgrid1 = window.<%=dgrid1.UID%>;
    var dgrid1_selectedRow = 0;
    var OnLoad = function (event) {
        toolbar.Render();
        dgrid1.addEventListener("onRowSelect", dgrid1_OnRowSelect);
        OnResize();
    };
    
    function dgrid1_OnRowSelect(rowid, cellindex) {
        dgrid1_selectedRow = rowid;
        toolbar.enableItem("btnModify");
        toolbar.enableItem("btnDelete");
    };
    var OnResize = function (event) {
        var top = dgrid1.GetTop();
        var newHeight = document.documentElement.clientHeight - top - 5;
        dgrid1.SetHeight(newHeight);
        var newWidth = document.documentElement.clientWidth - 5;
        dgrid1.SetWidth(newWidth);
    };
    
//    function  DisplayDialog (left, top, width, height, title, idWindow, idAttachObj, bModal, bResize) {
//        return jsf_displayDialog(thiswins, left, top, width, height, title, idWindow, idAttachObj, bModal, bResize);
//    };
//    
//    function  SetDialogHeight(idWindow, newHeight) {
//        var dimension = thiswins.window(idWindow).getDimension();
//        thiswins.window(idWindow).setDimension(dimension[0], newHeight);
//    };

//    function CloseDialog (idWindow) {
//        jsf_closeDialog(thiswins, idWindow)
//    };

    function SendRequest(sXML) {
         sURL = "./QueueManager.ashx";
         return jsf_sendRequest(sURL, sXML);
    };

    function toolbar_event(event) {
        var sRowId = "";
        switch (event) {
            case "btnCheck":
                var sRequest = '<request function="QueueManagerRequest" context="CheckQMStatus"><data></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                    alert(json.reply.QMStatus.HeartbeatInfo);
                }
                break;
            case "btnTest":
                var sRequest = '<request function="QueueManagerRequest" context="QueueTestJob"><data></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                    //__doPostBack('', '');
                    <%= Page.ClientScript.GetPostBackEventReference(btnRefresh, String.Empty) %>;
                }
                break;
            //case "btnRefresh":
            //    __doPostBack('', '');
            //    break;
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
        return false;
    };

    var thiswins = new dhtmlXWindows();
    thiswins.setImagePath("/_layouts/ppm/images/");
    thiswins.setSkin("dhx_web");

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
Queue Manager
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Queue Manager
</asp:Content>
