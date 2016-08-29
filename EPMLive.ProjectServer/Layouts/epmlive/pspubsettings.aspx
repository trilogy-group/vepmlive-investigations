<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pspubsettings.aspx.cs" Inherits="EPMLiveEnterprise.Layouts.epmlive.pspubsettings" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    

    <asp:Label ID="lblError" runat="server" ForeColor="red"></asp:Label>
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">

    <wssuc:InputFormSection Title="Publish Type"
		Description=""
		runat="server">
		<Template_Description>
		    Select which publishing type you would like to use:
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Publish Type" runat="server">
				 <Template_Control>
				    <asp:DropDownList ID="ddlPubType" runat="server">
                        <asp:ListItem Text="Not Set" Value=""></asp:ListItem>
				        <asp:ListItem Text="Assignment Based" Value="1"></asp:ListItem>
				        <asp:ListItem Text="Task Based" Value="2"></asp:ListItem>
				        <asp:ListItem Text="Task Based w/o Assignment" Value="3"></asp:ListItem>
                    </asp:DropDownList>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
	
    <wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Configuration" id="Button1" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
	</table>
    <wssawc:FormDigest ID="FormDigest1" runat="server" />
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine for Project Server Configuration
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine for Project Server Configuration
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to configure the options that will be used with WorkEngine for Project Server
</asp:Content>