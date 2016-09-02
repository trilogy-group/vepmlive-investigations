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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="econns.aspx.cs" Inherits="EPMLiveEnterprise.Layouts.epmlive.econns" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine for Project Server Connection String
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine for Project Server Connection String
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to configure the WorkEngine for Project Server Connection String
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<table>
	<wssuc:InputFormSection Title="Published Database Connection String"
		Description=""
		runat="server">
		<Template_Description>
		    This connection string is used when connecting to the Project Server Published Database
		</Template_Description>
		<Template_InputFormControls>
			<wssuc:InputFormControl LabelText="Connection String" runat="server">
				 <Template_Control>
				    <asp:TextBox ID="txtPublished" runat="server" TextMode="MultiLine" Width="350" Height="100" />
				    <br />
				    <img src="blank.gif" width="400" height="1"/>
				 </Template_Control>
			</wssuc:InputFormControl>
		</Template_InputFormControls>
	</wssuc:InputFormSection>
    <wssuc:ButtonSection runat="server">
		<Template_Buttons>
			<asp:PlaceHolder ID="PlaceHolder1" runat="server">
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Connection String" id="Button1" accesskey="" Width="150"/>
			</asp:PlaceHolder>
		</Template_Buttons>
	</wssuc:ButtonSection>
    <wssawc:FormDigest ID="FormDigest1" runat="server" />
    </table>
</asp:Content>