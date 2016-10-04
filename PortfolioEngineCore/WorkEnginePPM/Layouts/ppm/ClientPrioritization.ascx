<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientPrioritization.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.ClientPrioritizationControl" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:ScriptManagerProxy ID="sm1" runat="server">
    <Services>
    </Services>
</asp:ScriptManagerProxy>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/skins/dhtmlxlayout_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcontainer.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.css"/>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtoolbar/skins/dhtmlxtoolbar_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxtoolbar.js" type="text/javascript"></script>

<script src="/_layouts/epmlive/TreeGrid/GridE.js" type="text/javascript"></script>

<script src="/_layouts/ppm/ClientPrioritization.ascx.js" type="text/javascript"></script>
<script src="/_layouts/ppm/general.js" type="text/javascript"></script>

<div id="<%=ClientID%>mainDiv">
<div id="toolbarDataObjectDiv"></div>
<div id="gridDiv_1"></div>
<div id="<%=ClientID%>layoutDiv" style="position: relative; width: 100%; height: 500px;"></div>
</div>
<script type="text/javascript">
    //<%=ID%> = new ClientPrioritization('<%=ID%>', '<%=ClientID%>', '<%=URL%>', '<%=Webservice%>');
    clientprioritization = new ClientPrioritization('clientprioritization', '<%=ClientID%>', '<%=URL%>', '<%=Webservice%>');
</script>
