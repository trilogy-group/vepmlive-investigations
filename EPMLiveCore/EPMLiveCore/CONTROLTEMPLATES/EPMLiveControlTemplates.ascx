<%@Control Language="C#" AutoEventWireup="false" %>
<%@Assembly Name="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@Register TagPrefix="SharePoint" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.WebControls"%>
<%@Register TagPrefix="SPHttpUtility" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.Utilities"%>
<%@Register TagPrefix="EPMLive" Assembly="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" namespace="EPMLiveCore"%>

<%@ Register TagPrefix="wssuc" TagName="ToolBar" src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" src="~/_controltemplates/ToolBarButton.ascx" %>

<SharePoint:RenderingTemplate id="UserField" runat="server" >
	<Template>
		<input type="hidden" runat="server" id="HiddenUserFieldValue"/>
		<EPMLive:WEPeopleEditor id="UserField" runat="server"
			ValidatorEnabled="true"
			/>
	</Template>
</SharePoint:RenderingTemplate>
<SharePoint:RenderingTemplate ID="ViewSelector" runat="server">
	<Template>
		<table border=0 cellpadding=0 cellspacing=0 style='margin-right: 4px'>
		<tr>
		   <td nowrap class="ms-listheaderlabel"><SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="<%$Resources:wss,view_selector_view%>" EncodeMethod='HtmlEncode'/>&nbsp;</td>
		   <td nowrap class="ms-viewselector" id="onetViewSelector" onmouseover="this.className='ms-viewselectorhover'" onmouseout="this.className='ms-viewselector'" runat="server">
				<EPMLive:ViewPermissionSelectorMenu MenuAlignment="Right" AlignToParent="true" runat="server" id="ViewSelectorMenu" />
			</td>
		</tr>
		</table>
	</Template>
</SharePoint:RenderingTemplate>
<SharePoint:RenderingTemplate ID="ListForm" runat="server" >
	<Template>
		<SPAN id='part1'>
			<SharePoint:InformationBar runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbltop" RightButtonSeparator="&nbsp;" runat="server">
					<Template_RightButtons>
						<SharePoint:NextPageButton runat="server"/>
						<SharePoint:SaveButton runat="server"/>
						<SharePoint:GoBackButton runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			<SharePoint:FormToolBar runat="server"/>
			<TABLE class="ms-formtable" style="margin-top: 8px;" border=0 cellpadding=0 cellspacing=0 width=100%>
			<SharePoint:ChangeContentType runat="server"/>
			<SharePoint:FolderFormFields runat="server"/>
			<EPMLive:ListDisplaySettingIterator runat="server"/>
			<SharePoint:ApprovalStatus runat="server"/>
			<SharePoint:FormComponent TemplateName="AttachmentRows" runat="server"/>
			</TABLE>
			<table cellpadding=0 cellspacing=0 width=100%><tr><td class="ms-formline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td></tr></table>
			<TABLE cellpadding=0 cellspacing=0 width=100% style="padding-top: 7px"><tr><td width=100%>
			<SharePoint:ItemHiddenVersion runat="server"/>
			<SharePoint:ParentInformationField runat="server"/>
			<SharePoint:InitContentType runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbl" RightButtonSeparator="&nbsp;" runat="server">
					<Template_Buttons>
						<SharePoint:CreatedModifiedInfo runat="server"/>
					</Template_Buttons>
					<Template_RightButtons>
						<SharePoint:SaveButton runat="server"/>
						<SharePoint:GoBackButton runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			</td></tr></TABLE>
		</SPAN>
		<SharePoint:AttachmentUpload runat="server"/>
	</Template>
</SharePoint:RenderingTemplate>
<SharePoint:RenderingTemplate ID="TaskForm" runat="server" >
	<Template>
		<SPAN id='part1'>
			<SharePoint:InformationBar ID="InformationBar1" runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbltop" RightButtonSeparator="&nbsp;" runat="server">
					<Template_RightButtons>
						<SharePoint:NextPageButton runat="server"/>
						<SharePoint:SaveButton runat="server"/>
						<SharePoint:GoBackButton runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			<SharePoint:FormToolBar ID="FormToolBar1" runat="server"/>
			<TABLE class="ms-formtable" style="margin-top: 8px;" border=0 cellpadding=0 cellspacing=0 width=100%>
			<SharePoint:ChangeContentType ID="ChangeContentType1" runat="server"/>
			<SharePoint:FolderFormFields ID="FolderFormFields1" runat="server"/>
			<EPMLive:ListDisplaySettingIterator ID="ListDisplaySettingIterator1" runat="server"/>
			<SharePoint:ApprovalStatus ID="ApprovalStatus1" runat="server"/>
			<SharePoint:FormComponent ID="FormComponent1" TemplateName="AttachmentRows" runat="server"/>
			</TABLE>
			<table cellpadding=0 cellspacing=0 width=100%><tr><td class="ms-formline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td></tr></table>
			<TABLE cellpadding=0 cellspacing=0 width=100% style="padding-top: 7px"><tr><td width=100%>
			<SharePoint:ItemHiddenVersion ID="ItemHiddenVersion1" runat="server"/>
			<SharePoint:ParentInformationField ID="ParentInformationField1" runat="server"/>
			<SharePoint:InitContentType ID="InitContentType1" runat="server"/>
			<wssuc:ToolBar CssClass="ms-formtoolbar" id="toolBarTbl" RightButtonSeparator="&nbsp;" runat="server">
					<Template_Buttons>
						<SharePoint:CreatedModifiedInfo runat="server"/>
					</Template_Buttons>
					<Template_RightButtons>
						<SharePoint:SaveButton runat="server"/>
						<SharePoint:GoBackButton runat="server"/>
					</Template_RightButtons>
			</wssuc:ToolBar>
			</td></tr></TABLE>
		</SPAN>
		<SharePoint:AttachmentUpload ID="AttachmentUpload1" runat="server"/>
	</Template>
</SharePoint:RenderingTemplate>