<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCalendar.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.EditCalendarControl" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<style type="text/css">
    .style1
    {
        height: 20px;
    }
</style>
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

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcontainer.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.js" type="text/javascript"></script>

<script src="/_layouts/epmlive/TreeGrid/GridE.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ribbon/ribbon.css" />
<script src="/_layouts/ppm/ribbon/ribbon.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/EditCalendar.ascx.css" />
<script src="/_layouts/ppm/EditCalendar.ascx.js?ver=<%=FileVersion%>"" type="text/javascript"></script>
<script src="/_layouts/ppm/general.js" type="text/javascript"></script>
<div id="idCreateNewCal" style="display:none; font-family:Tahoma">
    <table style="margin:5px;">
        <tr>
            <td>Calendar Name:<br />
            <input id="idTxtCalName" type="text" value=" " style="width:16em; text-align:left;" />
            </td>
         </tr>
         <tr>
            <td>Calendar Description:<br />
            <input id="idTxtCalDesc" type="text" value=" " style="width:16em; text-align:left;" />
            </td>
        </tr>
        <tr style="text-align:right;">
            <td><input type="button" value="OK" onclick="dialogEvent('NewCal_OK');" style="width:7em;" /></td>
            <td><input type="button" value="Cancel" onclick="dialogEvent('NewCal_Cancel');" style="width:7em;" /></td>
        </tr>
    </table>
</div>
<div id="idPeriodTabDiv" class="epm_ribbon_row"  style="display:none;"></div>
<div id="idFTETabDiv" class="epm_ribbon_row" style="display:none;"></div>
<div id="gridDiv_Periods" style="width:100%;height:100%;overflow:auto;"></div>
<div id="gridDiv_FTES" style="width:100%;overflow:auto;"></div>
<div id="toolbarDataObjectDiv"></div>
<div id="<%=ClientID%>mainDiv">
<div id="<%=ClientID%>layoutDiv" 
        style="position: relative; width: 100%; height: 650px; top: 0px; left: 0px;"></div>
</div>
<script type="text/javascript">
    function dialogEvent(action) { editcalendar.externalEvent(action); }
 

    var params = {};
    params.ClientID = '<%=ClientID%>';
    params.URL = '<%=URL%>';
    params.Webservice = '<%=Webservice%>';
    editcalendar = new EditCalendar('editcalendar', params);
</script>
