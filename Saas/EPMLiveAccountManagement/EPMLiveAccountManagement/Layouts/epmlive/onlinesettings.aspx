<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="onlinesettings.aspx.cs" Inherits="EPMLiveAccountManagement.Layouts.epmlive.onlinesettings" DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>


<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <wssuc:InputFormSection ID="InputFormSection3" Title="Disable Resource Requests"
		    Description=""
		    runat="server">
		    <Template_Description>
		        Check this box to allow users to add people to the resource pool without having to go through an approval process.
		    </Template_Description>
		    <Template_InputFormControls>
			    <wssuc:InputFormControl ID="InputFormControl3" LabelText="" runat="server">
				        <Template_Control>
				        <asp:CheckBox ID="chkDisableRes" runat="server" /> Disable Resource Requests
				        </Template_Control>
			    </wssuc:InputFormControl>
		    </Template_InputFormControls>
	    </wssuc:InputFormSection>

        <wssuc:ButtonSection ID="ButtonSection1" runat="server">
		    <Template_Buttons>
			    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
				    <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="Button1_Click" Text="Save Settings" id="Button1" accesskey="" Width="150"/>
			    </asp:PlaceHolder>
		    </Template_Buttons>
	    </wssuc:ButtonSection>
    </table>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Online Settings
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Online Settings
</asp:Content>
