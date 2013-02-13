<%@ Control Language="C#"  AutoEventWireup="false"%>
<%@Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@Import Namespace="Microsoft.SharePoint" %>
<%@Register TagPrefix="SharePoint" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.WebControls"%>
<%@Register TagPrefix="SPHttpUtility" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.Utilities"%>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" src="~/_controltemplates/ToolBarButton.ascx" %>

<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<SharePoint:RenderingTemplate ID="GridViewToolBar" runat="server">
	<Template>
		<wssuc:ToolBar CssClass="ms-menutoolbar" EnableViewState="false" id="toolBarTbl" ButtonSeparator="<img src='/_layouts/images/blank.gif' alt=''>" RightButtonSeparator="&nbsp;&nbsp;" runat="server">
			<Template_Buttons>
				<SharePoint:NewMenu ID="NewMenu1" AccessKey="<%$Resources:wss,tb_NewMenu_AK%>" runat="server" />
				<SharePoint:ActionsMenu ID="ActionsMenu1" AccessKey="<%$Resources:wss,tb_ActionsMenu_AK%>" runat="server" />
				<SharePoint:SettingsMenu ID="SettingsMenu1" AccessKey="<%$Resources:wss,tb_SettingsMenu_AK%>" runat="server" />
			</Template_Buttons>
			<Template_RightButtons>

			        
				  <SharePoint:PagingButton ID="PagingButton1" runat="server"/>
				  <SharePoint:ListViewSelector ID="ListViewSelector1" runat="server"/>
				  
			</Template_RightButtons>
		</wssuc:ToolBar>
	</Template>
</SharePoint:RenderingTemplate>d	