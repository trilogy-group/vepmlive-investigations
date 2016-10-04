<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Table.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.Table" %>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xgrid/skins/dhtmlxgrid_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xgrid/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xgrid/dhtmlxgridcell.js" type="text/javascript"></script>

<link id="tableStyles" href="/_layouts/ppm/tools/table.css" type="text/css" rel="stylesheet" />

<script src="/_layouts/ppm/tools/table.ascx.js" type="text/javascript"></script>

<div id="idTableDiv" style="overflow: scroll;">
<div id="gridbox" style="width:100%;height:400px"></div>
<table id="idTable" class="grid" style="width: 100%;">
	<asp:placeholder runat="server" id="idTableBody" />
</table>
</div>
<script type="text/javascript">
    <%=ID%> = new Table('<%=ID%>', '<%=ClientID%>');
    var OnLoad = function (event) {
        var mygrid = new dhtmlXGridObject('gridbox');
        mygrid.setImagePath("/_layouts/epmlive/dhtml/xgrid/imgs/"); //path to images required by grid
        //	    mygrid.setHeader("Column A, Column B");//set column names
        //	    mygrid.setInitWidths("100,250");//set column width in px
        //	    mygrid.setColAlign("right,left");//set column values align
        //	    mygrid.setColTypes("ro,ed");//set column types
        //	    mygrid.setColSorting("int,str");//set sorting
        //	    mygrid.init();//initialize grid
        //
        mygrid.setSkin("dhx_skyblue"); //set grid skin
        mygrid.parse('<%=TableData%>');
        //mygrid.loadXML("../common/grid.xml"); //load data
    };
    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
    }
</script>
