<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBAdmin_NAX.aspx.cs" Inherits="WorkEnginePPM.DBAdmin_NAX" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/skins/dhtmlxlayout_dhx_skyblue.css" />

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.css"/>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar_start.js" type="text/javascript"></script>


<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ribbon/ribbon2.css" />
<script src="/_layouts/ppm/ribbon/ribbon2.js" type="text/javascript"></script>

<style type="text/css">
    .dhx_tabbar_row { background-color:#eeeeee !important;}
</style>
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<script src="general.js" type="text/javascript"></script>
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
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <div id="mainDiv" style="width:500px;height:500px;" >
        <div id="a_tabbar"></div>
    </div>
</div>
<script type="text/javascript">
    var tabbar = null;
    var OnLoad = function (event) {
        tabbar = new dhtmlXTabBar("a_tabbar", "top");
        tabbar.setHrefMode("iframes-on-demand");
        tabbar.setImagePath("/_layouts/epmlive/dhtml/xtab/imgs/");
        tabbar.addTab("a1", "Tables", "100px");
        tabbar.addTab("a2", "PIs", "100px");
        tabbar.addTab("a3", "Resources", "100px");
        tabbar.setContentHref("a1", "DBATables.aspx?IsDlg=1");
        tabbar.setContentHref("a2", "DBAPIs.aspx?IsDlg=1");
        tabbar.setContentHref("a3", "DBAResources.aspx?IsDlg=1");
        tabbar.enableAutoReSize();
        tabbar.setStyle("winDflt");
        tabbar.setSkinColors("#EEEEEE", "#FFFFFF");
        //tabbar.forceLoad("a1");
        tabbar.setTabActive('a1');
        OnResize();
    };

    var OnResize = function (event) {
        var width = document.documentElement.clientWidth - 3;
        var divMain = document.getElementById("mainDiv");
        var d = findAbsolutePosition(divMain);
        var height = document.documentElement.clientHeight - d[1];
        if (width != null && height != null && width > 400 && height > 300) {
            //window.setTimeout("tabbar.setSize(" + width + "," + height + ");", 100);
            tabbar.setSize(width, height);
            tabbar.normalize(null, false);
        }
    };

    function findAbsolutePosition (obj) {
        var curleftx = 0;
        var curtopy = 0;
        if (obj.offsetParent) {
            do {
                curleftx += obj.offsetLeft;
                curtopy += obj.offsetTop;
            } while (obj = obj.offsetParent);
        }
        return [curleftx, curtopy];
    };

    function HandleEvent(eventName)
    {
        switch (eventName) {
            case "ddlCostTypes_OnChange":
                break;
            case "btnPost_onclick":
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
DBAdmin
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
DBAdmin
</asp:Content>
