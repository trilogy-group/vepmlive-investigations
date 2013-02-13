<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyWorkShell.ascx.cs" Inherits="EPMLiveWebParts.CONTROLTEMPLATES.MyWork.MyWorkShell" %>

<asp:Label runat="server" ID="ErrorLabel"></asp:Label>

<div id="EPMMyWorkShell">
	<%--<div id="EPMMyWorkSideNav">
		<div id="EPMMyWorkProfileImage">
			<a href="/_layouts/userdisp.aspx?ID=<%= UserId %>" target="_blank"><img src="<%= ProfileImageUrl %> "/></a>
			<a href="/_layouts/userdisp.aspx?ID=<%= UserId %>" target="_blank">
				<div id="EPMMyWorkUserName"><%= UserName %></div>
			</a>
		</div>
		<ul id="EPMMyWorkMenu">
			<li class="EPMMyWorkMenuItem EPMMyWorkMenuItemSelected" data-control="EPMAllWork" data-selected="true">All Work</li>
			<li class="EPMMyWorkMenuItem" data-control="EPMWorkingOn" data-selected="false">Working On</li>
		</ul>
	</div>
	<h2 id="EPMMyWorkTitle">All Work</h2>--%>
	<div id="EPMMyWorkContent">
		<asp:Panel ID="ControlPanel" runat="server"></asp:Panel>
	</div>
</div>

<script type="text/javascript">
	(function () {
		window.allWorkGridId = '<%= MyWorkParams.WebPartId %>';
		
//		var initialize = function () {
//			var grids = { EPMAllWork: { id: '<%= MyWorkParams.WebPartId %>', active: true }, EPMWorkingOn: { id: '<%= WorkingOnParams.GridId %>'} };
//			window.epmLiveWorkCenter.initialize('EPMMyWorkMenuItem', 'EPMMyWorkMenuItemSelected', 'EPMMyWorkTitle', grids);
//		};

//		ExecuteOrDelayUntilScriptLoaded(initialize, 'EPMLive.WorkCenter.js');
	})();
</script>