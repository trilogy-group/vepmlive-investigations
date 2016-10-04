<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regionalsetng.aspx.cs" Inherits="EPMLiveCore.regionalsetng" DynamicMasterPageFile="~masterurl/default.master" %>
<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Settings
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this section to configure the settings for this site.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
  

  <table border="0" width="100%" cellspacing="0" cellpadding="0" id="diidProjectPageOverview">

 <wssuc:InputFormSection Title="<%$Resources:wss,regionalsetng_locale_title%>"
			Description="<%$Resources:wss,regionalsetng_locale_description%>"
			runat="server">
	   <Template_InputFormControls>
			<wssuc:InputFormControl LabelText="<%$Resources:wss,regionalsetng_locale_label%>" LabelAssociatedControlID="DdlwebLCID" runat="server">
				 <Template_Control>
				   <asp:DropDownList ID="DdlwebLCID" OnSelectedIndexChanged="DdlWebLCIDIndex_Changed" AutoPostBack="true" Runat="server"/>
				 </Template_Control>
			</wssuc:InputFormControl>
	   </Template_InputFormControls>
 </wssuc:InputFormSection>

 <wssuc:InputFormSection Title="<%$Resources:wss,regionalsetng_timezone_title%>"
			Description="<%$Resources:wss,regionalsetng_timezone_description%>"
			runat="server">
	   <Template_InputFormControls>
		 <wssuc:InputFormControl LabelText="<%$Resources:wss,regionalsetng_timezone_label%>" LabelAssociatedControlID="DdlwebTimeZone" runat="server">
			 <Template_Control>
			  <asp:DropDownList ID="DdlwebTimeZone" Runat="server"/>
			 </Template_Control>
		 </wssuc:InputFormControl>
	   </Template_InputFormControls>
 </wssuc:InputFormSection>
 
 <wssuc:InputFormSection Title="<%$Resources:wss,regionalsetng_workweek_title%>"
			Description="<%$Resources:wss,regionalsetng_workweek_description%>"
			runat="server">
	   <Template_InputFormControls>
		 <wssuc:InputFormControl runat="server">
			 <Template_Control>
			 <asp:CheckBoxList id="ChkListWeeklyMultiDays"
						CssClass="ms-input"
						RepeatColumns="7"
						RepeatDirection="Horizontal"
						runat="server">
				<asp:ListItem Text="<%$Resources:wss,regionalsetng_DOW_SUN_STR%>" Value="su" />
				<asp:ListItem Text="<%$Resources:wss,regionalsetng_DOW_MON_STR%>" Value="mo" />
				<asp:ListItem Text="<%$Resources:wss,regionalsetng_DOW_TUE_STR%>" Value="tu" />
				<asp:ListItem Text="<%$Resources:wss,regionalsetng_DOW_WED_STR%>" Value="we" />
				<asp:ListItem Text="<%$Resources:wss,regionalsetng_DOW_THU_STR%>" Value="th" />
				<asp:ListItem Text="<%$Resources:wss,regionalsetng_DOW_FRI_STR%>" Value="fr" />
				<asp:ListItem Text="<%$Resources:wss,regionalsetng_DOW_SAT_STR%>" Value="sa" />
			 </asp:CheckBoxList>
			 </Template_Control>
		 </wssuc:InputFormControl>
		 <wssuc:InputFormControl runat="server">
			 <Template_Control>
				<table border="0" cellspacing="1">
				<tr>
					<td>&#160;</td>
					<td nowrap="nowrap">
							 <asp:Label id="FirstDayOfWeekLabel" Text="<%$Resources:wss,regionalsetng_label_firstdayofweek%>" AssociatedControlID="DdlFirstDayOfWeek" CssClass="ms-input" runat="server" />
					</td>
					<td>&#160;</td>
					<td>
							 <asp:DropDownList ID="DdlFirstDayOfWeek"  Runat="server">
								 <asp:ListItem Selected Value="0" text="<%$Resources:wss,regionalsetng_DOW_SUNDAY_STR%>" />
								 <asp:ListItem Value="1" text="<%$Resources:wss,regionalsetng_DOW_MONDAY_STR%>" />
								 <asp:ListItem Value="2" text="<%$Resources:wss,regionalsetng_DOW_TUESDAY_STR%>" />
								 <asp:ListItem Value="3" text="<%$Resources:wss,regionalsetng_DOW_WEDNESDAY_STR%>" />
								 <asp:ListItem Value="4" text="<%$Resources:wss,regionalsetng_DOW_THURSDAY_STR%>" />
								 <asp:ListItem Value="5" text="<%$Resources:wss,regionalsetng_DOW_FRIDAY_STR%>" />
								 <asp:ListItem Value="6" text="<%$Resources:wss,regionalsetng_DOW_SATURDAY_STR%>" />
							 </asp:DropDownList>
					 </td>
					<td>&#160;</td>
					<td nowrap="nowrap">
							 <asp:Label id="StartTimeLabel" Text="<%$Resources:wss,regionalsetng_label_starttime%>" AssociatedControlID="DdlStartTime" CssClass="ms-input" runat="server" />
					</td>
					<td>&#160;</td>
					<td>
							 <asp:DropDownList ID="DdlStartTime"  Runat="server"/>
							 </asp:DropDownList>
					 </td>
				</tr>
				<tr>
					<td>&#160;</td>
					<td nowrap="nowrap">
							 <asp:Label id="FirstWeekOfYearLabel" Text="<%$Resources:wss,regionalsetng_label_firstweekofyear%>" AssociatedControlID="DdlFirstWeekOfYear" CssClass="ms-input" runat="server" />
					</td>
					<td>&#160;</td>
					<td>
							<asp:DropDownList ID="DdlFirstWeekOfYear"  Runat="server">
								<asp:ListItem Selected Value="0" text="<%$Resources:wss,regionalsetng_WOY_JAN1_STR%>" />
								<asp:ListItem Value="1" text="<%$Resources:wss,regionalsetng_WOY_FULL_STR%>" />
								<asp:ListItem Value="2" text="<%$Resources:wss,regionalsetng_WOY_FOURDAY_STR%>" />
							</asp:DropDownList>
					 </td>
					<td>&#160;</td>
					<td nowrap="nowrap">
							 <asp:Label id="EndTimeLabel" Text="<%$Resources:wss,regionalsetng_label_endtime%>" AssociatedControlID="DdlEndTime" CssClass="ms-input" runat="server" />
					</td>
					<td>&#160;</td>
					<td>
							<asp:DropDownList ID="DdlEndTime"  Runat="server"/>
							</asp:DropDownList>
					 </td>
				</tr>
				</table>
			 </Template_Control>
		 </wssuc:InputFormControl>
	   </Template_InputFormControls>
 </wssuc:InputFormSection>
<!--TimeFormat-->
<asp:PlaceHolder ID="PanelTimeFormat" Runat="server">
 <wssuc:InputFormSection Title="<%$Resources:wss,regionalsetng_timeformat_title%>"
			Description="<%$Resources:wss,regionalsetng_timeformat_description%>"
			runat="server">
	   <Template_InputFormControls>
		 <wssuc:InputFormControl LabelText="<%$Resources:wss,regionalsetng_timeformat_label%>" LabelAssociatedControlID="DdlTimeFormat" runat="server">
			 <Template_Control>
				<asp:DropDownList ID="DdlTimeFormat"  Runat="server">
					 <asp:ListItem Value="0" text="<%$Resources:wss,regionalsetng_12hour%>" />
					 <asp:ListItem Value="1" text="<%$Resources:wss,regionalsetng_24hour%>" />
				</asp:DropDownList>
			 </Template_Control>
		 </wssuc:InputFormControl>
	   </Template_InputFormControls>
 </wssuc:InputFormSection>
</asp:PlaceHolder>
<!-- Extension Section using DelegateControl -->
<SharePoint:DelegateControl runat="server" ID="RegionalSettingsExtensionsDelegate" ControlId="RegionalSettingsExtensions" />
 <wssuc:ButtonSection runat="server" ShowStandardCancelButton="false">
		<Template_Buttons>
			<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnUpdateRegionalSettings_Click" Text="<%$Resources:wss,multipages_okbutton_text%>" id="BtnUpdateRegionalSettings" accesskey="<%$Resources:wss,okbutton_accesskey%>"/>
			<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="CancelButtonClick" Text="<%$Resources:wss,multipages_cancelbutton_text%>" id="BtnCancel" accesskey="<%$Resources:wss,cancelbutton_accesskey%>"/>
		</Template_Buttons>
 </wssuc:ButtonSection>
	   <span id="idSpace" class="ms-SpaceBetButtons"></span>
	 <input id="onetidCmd" type="Hidden" name="Cmd" value="UPDATEPROJECT" />
	 <input type="Hidden" name="NextUsing" value='_layouts/settings.aspx' />
</table>
</asp:Content>