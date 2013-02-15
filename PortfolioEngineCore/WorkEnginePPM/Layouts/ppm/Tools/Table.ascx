<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Table.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.Table" %>

<link id="tableStyles" href="/_layouts/ppm/tools/table.css" type="text/css" rel="stylesheet" />

<script src="/_layouts/ppm/tools/table.ascx.js" type="text/javascript"></script>

<div id="idTableDiv" style="overflow: scroll;">
<table id="idTable" class="grid" style="width: 100%;">
	<asp:placeholder runat="server" id="idTableBody" />
</table>
</div>
<script type="text/javascript">
    <%=ID%> = new Table('<%=ID%>', '<%=ClientID%>');
</script>
