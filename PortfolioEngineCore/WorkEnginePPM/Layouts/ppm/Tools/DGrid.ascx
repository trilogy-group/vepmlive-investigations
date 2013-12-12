<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DGrid.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.DGrid" %>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid_skins.css"/>
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xgrid/skins/dhtmlxgrid_dhx_dgrid.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/calendar/skins/dhtmlxcalendar_dhx_skyblue.css" />

<script src="/_layouts/epmlive/dhtml/xgrid/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xgrid/dhtmlxgridcell.js" type="text/javascript"></script>
<script type="text/css" src="/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.js"></script>
<script type="text/css" src="/_layouts/epmlive/dhtml/xgrid/excells/dhtmlxgrid_excell_dhxcalendar.js"></script>



<script src="/_layouts/ppm/tools/dgrid.ascx.js" type="text/javascript"></script>

<asp:HiddenField ID="hiddenTableData" runat="server"></asp:HiddenField>
<asp:HiddenField ID="hiddenColumnData" runat="server"></asp:HiddenField>
<div style="margin-left:2px; margin-right:4px;" id="<%=ClientID%>_dgrid_div" >
<div id="<%=ClientID%>_grid_div" style="width:inherit; height:500px;"></div>
</div>
<script type="text/javascript">
    try {
        var params = {};
        params.ClientID = '<%=ClientID%>';
        params.dgrid_div = "<%=ClientID%>_dgrid_div";
        params.grid_div = "<%=ClientID%>_grid_div";
        params.ImagePath = "/_layouts/epmlive/dhtml/xgrid/imgs/";
        params.Skin = "dhx_skyblue";
        params.Data = document.getElementById('<%=hiddenTableData.ClientID%>').value;
        params.Columns = document.getElementById('<%=hiddenColumnData.ClientID%>').value;
        window["<%=UID%>"] = new DGrid(params);
        document.getElementById('<%=hiddenTableData.ClientID%>').value = "";
        document.getElementById('<%=hiddenColumnData.ClientID%>').value = "";
    }
    catch (e) {
        alert("DGrid ascx Initialization : " + e.toString());
    }

</script>
