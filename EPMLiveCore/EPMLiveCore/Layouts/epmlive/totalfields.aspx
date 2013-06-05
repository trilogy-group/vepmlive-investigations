<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 


<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="totalfields.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.totalfields" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Total Field Settings
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Total Field Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to determine how to summarize or total the fields in this List. 
    These settings are only relevant when using this List in conjunction with EPM Live Web Parts such as the Grid Web Part.
    When using these settings, they will override the "Totals" settings within each view.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <wssuc:InputFormSection ID="InputFormSection1" Title="Field Rollups"
		Description=""
		runat="server">
		<Template_Description>
		    
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="" runat="server" id="inputForm">
				 <Template_Control>
                    <asp:Panel ID="pnlFields" runat="server"></asp:Panel>
                    <img src="../images/blank.gif" border="0" width="300" height="10">
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	<wssuc:ButtonSection ID="ButtonSection1" runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save" id="Button1" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
    <wssawc:FormDigest ID="FormDigest1" runat="server" />
    <img src="/_layouts/images/blank.gif" width="600" height="1" />
</asp:Content>