<%@ Control Language="C#"  AutoEventWireup="false"%>
<%@Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@Import Namespace="Microsoft.SharePoint" %>
<%@Register TagPrefix="SharePoint" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.WebControls"%>
<%@Register TagPrefix="SPHttpUtility" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.Utilities"%>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" src="~/_controltemplates/ToolBarButton.ascx" %>

<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<SharePoint:RenderingTemplate ID="TSViewToolBar" runat="server">
	<Template>
		<wssuc:ToolBar CssClass="ms-menutoolbar" EnableViewState="false" id="toolBarTbl" ButtonSeparator="<img src='/_layouts/images/blank.gif' alt=''>" RightButtonSeparator="&nbsp;&nbsp;" runat="server">
			<Template_Buttons>
				<SharePoint:NewMenu ID="NewMenu1" AccessKey="<%$Resources:wss,tb_NewMenu_AK%>" runat="server" />
				<SharePoint:ActionsMenu ID="ActionsMenu1" AccessKey="<%$Resources:wss,tb_ActionsMenu_AK%>" runat="server" />
				<SharePoint:SettingsMenu ID="SettingsMenu1" AccessKey="<%$Resources:wss,tb_SettingsMenu_AK%>" runat="server" />
				
				<td class=ms-separator><img src='/_layouts/images/blank.gif' alt=''></td>
				
				<asp:Panel runat="server" id="pnlFilter"><td class="ms-toolbar" nowrap="true"><div class="ms-buttoninactivehover" onmouseover="this.className='ms-buttonactivehover'" onmouseout="this.className='ms-buttoninactivehover'"><asp:Label id="lblFilter" runat="server"/><img align='absmiddle' alt="" src="/_layouts/epmlive/images/gridfilter.gif" style='border-width:0px;'>&nbsp;<asp:Label id="lblFilterText" runat="server" Text="Show Filters"/></a></div></td></asp:Panel>

			</Template_Buttons>
			<Template_RightButtons>

			        
				  <SharePoint:PagingButton ID="PagingButton1" runat="server"/>
				  <SharePoint:ListViewSelector ID="ListViewSelector1" runat="server"/>
				  
			</Template_RightButtons>
		</wssuc:ToolBar>
	</Template>
</SharePoint:RenderingTemplate>

<SharePoint:RenderingTemplate ID="ToolbarTSMenu" runat="server">
	<Template>
		<SharePoint:FeatureMenuTemplate runat="server"
			FeatureScope="Site"
			Location="Microsoft.SharePoint.StandardMenu"
			GroupId="TimesheetMenu"
			UseShortId="true"
			>
			<SharePoint:SubMenuTemplate ID="AddWork" Text="Add Timesheet Item" runat="Server" ImageUrl="/_layouts/epmlive/images/addtime.gif" Sequence="100" Description="Add work to report time to.">
			    <SharePoint:MenuItemTemplate
				ID="MyWork"
				ImageUrl="/_layouts/epmlive/images/tswork.gif"
				MenuGroupId="200"
				Sequence="200"
				UseShortId="true"
				runat="server" Text="Work" Description="Add work from your sites"/>
				<SharePoint:MenuItemTemplate
				ID="NonWork"
				ImageUrl="/_layouts/images/menudatasheet.gif"
				MenuGroupId="200"
				Sequence="202"
				UseShortId="true"
				runat="server" Text="Non Work" Description="Add other non work."/>
				<SharePoint:MenuItemTemplate
				ID="SearchWork"
				ImageUrl="/_layouts/epmlive/images/tssearch.gif"
				MenuGroupId="200"
				Sequence="203"
				UseShortId="true"
				runat="server" Text="Search For Work" Description="Search for work throughout the system."/>
				<SharePoint:MenuItemTemplate
				ID="AutoAdd"
				ImageUrl="/_layouts/epmlive/images/tsauto.gif"
				MenuGroupId="200"
				Sequence="204"
				UseShortId="true"
				runat="server" Text="Auto-Add Work" Description="Add work to timesheet that you are assigned and is currently in progress."/>
			</SharePoint:SubMenuTemplate>
			<SharePoint:MenuItemTemplate
				ID="SaveTimeSheet"
				ImageUrl="/_layouts/images/save.gif"
				MenuGroupId="210"
				Sequence="210"
				UseShortId="true"
				runat="server" Text="Save Timesheet" Description="Save timesheet for later review."/>
			<SharePoint:MenuItemTemplate
				ID="SubmitTimesheet"
				ImageUrl="/_layouts/epmlive/images/submittime.gif"
				MenuGroupId="210"
				Sequence="211"
				UseShortId="true"
				runat="server" Text="Submit Timesheet" Description="Submit timesheet to timesheet approver."/>
			<SharePoint:MenuItemTemplate
				ID="UnsubmitTimesheet"
				ImageUrl="/_layouts/epmlive/images/unsubmittime.gif"
				MenuGroupId="210"
				Sequence="212"
				UseShortId="true"
				Visible="false"
				runat="server" Text="Un-submit Timesheet" Description="Un-Submit timesheet for modification."/>
			<SharePoint:MenuItemTemplate
				ID="DeleteItem"
				ImageUrl="/_layouts/epmlive/images/deletetime.gif"
				MenuGroupId="210"
				Sequence="213"
				UseShortId="true"
				runat="server" Text="Remove Timesheet Item" Description="Remove an item from the timesheet."/>
				
				<SharePoint:SubMenuTemplate ID="Delegates" Text="Other Timesheets" runat="Server" ImageUrl="/_layouts/epmlive/images/tsdelegates.gif" Sequence="214" Description="Select timesheets for users you are the delegate for." Visible="False">
		            <SharePoint:MenuItemTemplate
				        ID="MyTimesheet"
				        MenuGroupId="370"
				        Sequence="1"
				        UseShortId="true"
				        runat="server" Text="My Timesheet"/>
		        </SharePoint:SubMenuTemplate>
		</SharePoint:FeatureMenuTemplate>
		
	</Template>
</SharePoint:RenderingTemplate>

<SharePoint:RenderingTemplate ID="ToolbarPMMenu" runat="server">
	<Template>
		<SharePoint:FeatureMenuTemplate ID="FeatureMenuTemplate1" runat="server"
			FeatureScope="Site"
			Location="Microsoft.SharePoint.StandardMenu"
			GroupId="TimesheetMenu"
			UseShortId="true"
			>
			<SharePoint:MenuItemTemplate
				ID="ApproveItems"
				ImageUrl="/_layouts/epmlive/images/approvetime.gif"
				MenuGroupId="210"
				Sequence="211"
				UseShortId="true"
				runat="server" Text="Approve Items" Description=""/>
			<SharePoint:MenuItemTemplate
				ID="RejectItems"
				ImageUrl="/_layouts/epmlive/images/rejecttime.gif"
				MenuGroupId="210"
				Sequence="212"
				UseShortId="true"
				Visible="true"
				runat="server" Text="Reject Items" Description=""/>
		</SharePoint:FeatureMenuTemplate>
	</Template>
</SharePoint:RenderingTemplate>


<SharePoint:RenderingTemplate ID="ApprovalMenu" runat="server">
	<Template>
		<SharePoint:FeatureMenuTemplate ID="FeatureMenuTemplate1" runat="server"
			FeatureScope="Site"
			Location="Microsoft.SharePoint.StandardMenu"
			GroupId="TimesheetMenu"
			UseShortId="true"
			>
			<SharePoint:MenuItemTemplate
				ID="ApproveItems"
				ImageUrl="/_layouts/epmlive/images/approvetime.gif"
				MenuGroupId="210"
				Sequence="211"
				UseShortId="true"
				runat="server" Text="Approve/Lock Selected Items" Description="Approve and lock the timesheet(s) to prevent future modification."/>
			<SharePoint:MenuItemTemplate
				ID="UnlockItems"
				ImageUrl="/_layouts/epmlive/images/unlocktime.gif"
				MenuGroupId="210"
				Sequence="212"
				UseShortId="true"
				Visible="true"
				runat="server" Text="Unlock Selected Items" Description="Unlock approved timesheets to allow users to modify them."/>
			<SharePoint:MenuItemTemplate
				ID="RejectItems"
				ImageUrl="/_layouts/epmlive/images/rejecttime.gif"
				MenuGroupId="210"
				Sequence="213"
				UseShortId="true"
				Visible="true"
				runat="server" Text="Reject Selected Items" Description="Reject and unlock the timesheet(s) so users can modify them."/>
			<SharePoint:SubMenuTemplate ID="SendEmail" Text="Send Email" runat="Server" ImageUrl="/_layouts/images/msg32.gif" Sequence="214" Description="Send an email to timesheet users.">
			    <SharePoint:MenuItemTemplate
				    ID="UnsubmittedTime"
				    MenuGroupId="210"
				    Sequence="300"
				    UseShortId="true"
				    Visible="true"
				    runat="server" Text="Unsubmitted Timesheet" Description="Send an email to all users that have saved and unsubmitted time."/>
			<SharePoint:MenuItemTemplate
				    ID="AllUsers"
				    MenuGroupId="210"
				    Sequence="301"
				    UseShortId="true"
				    Visible="true"
				    runat="server" Text="All Users" Description="Send an email to all users."/>
				<SharePoint:MenuItemTemplate
				    ID="SelectedUsers"
				    MenuGroupId="210"
				    Sequence="302"
				    UseShortId="true"
				    Visible="true"
				    runat="server" Text="Selected Users" Description="Send an email to all selected users."/>
			</SharePoint:SubMenuTemplate>
		</SharePoint:FeatureMenuTemplate>
	</Template>
</SharePoint:RenderingTemplate>