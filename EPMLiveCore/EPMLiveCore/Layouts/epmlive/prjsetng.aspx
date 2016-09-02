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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prjsetng.aspx.cs" Inherits="EPMLiveCore.prjsetng" DynamicMasterPageFile="~masterurl/default.master" %>
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
<script language="javascript">

function TestURL() {
    ULSFJS: ;
    try {
        var siteLogoUrl = (document.getElementById("<%= TxtSiteLogoUrl.ClientID %>"));
        if (siteLogoUrl != null) {
            open(siteLogoUrl.value);
        }
    }
    catch (e)
	{ }
}

</script>
   <table class=propertysheet border="0" width="100%" cellspacing="0" cellpadding="0" id="diidProjectPageOverview">
 <wssuc:InputFormSection Title="<%$Resources:wss,prjsetng_titledesc_title%>"
			Description="<%$Resources:wss,prjsetng_titledesc_description%>"
			runat="server">
	   <Template_InputFormControls>
			<wssuc:InputFormControl LabelText="<%$Resources:wss,prjsetng_title_label%>" runat="server">
				 <Template_Control>
			<wssawc:InputFormTextBox Title="<%$Resources:wss,prjsetng_TxtTitle_Title%>" class="ms-input"  ID="TxtWebTitle" Columns="40" Runat="server" MaxLength=255 />
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="<%$Resources:wss,multipages_description%>" runat="server">
				 <Template_Control>
			<wssawc:InputFormTextBox Title="<%$Resources:wss,prjsetng_TxtDescription_Title%>" class="ms-input"  ID="TxtWebDescription" Runat="server" TextMode="MultiLine" Columns="40" Rows="3"/>
				 </Template_Control>
			</wssuc:InputFormControl>
	   </Template_InputFormControls>
 </wssuc:InputFormSection>
 <wssuc:InputFormSection Title="<%$Resources:wss,prjsetng_logotitledesc_title%>" runat="server">
	   <Template_Description>
		   <SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="<%$Resources:wss,prjsetng_logotitledesc_description%>" EncodeMethod='HtmlEncode'/>
		   <SharePoint:EncodedLiteral ID="EncodedLiteral2" runat="server" text="<%$Resources:wss,prjsetng_logotitledesc_description_note%>" EncodeMethod='HtmlEncode'/>
	   </Template_Description>
	   <Template_InputFormControls>
			<wssuc:InputFormControl LabelText="<%$Resources:wss,prjsetng_logourl_label%>" runat="server">
				 <Template_Control>
					<wssawc:InputFormTextBox Title="<%$Resources:wss,prjsetng_logourl_tooltip%>" class="ms-input"  ID="TxtSiteLogoUrl" Columns="40" Runat="server" MaxLength=512  Direction="LeftToRight"/>
					
					<br/>
					<a href="javascript:TestURL()"><SharePoint:EncodedLiteral ID="EncodedLiteral3" runat="server" text="<%$Resources:wss,prjsetng_clicktotest%>" EncodeMethod='HtmlEncode'/></a>
					<br/>
				 </Template_Control>
			</wssuc:InputFormControl>
			<wssuc:InputFormControl LabelText="<%$Resources:wss,prjsetng_logourl_description%>" runat="server">
				 <Template_Control>
			<wssawc:InputFormTextBox Title="<%$Resources:wss,prjsetng_logourlDescription_Title%>" class="ms-input"  ID="TxtLogoUrlDescription" Runat="server" TextMode="MultiLine" Columns="40" Rows="3"/>
				 </Template_Control>
			</wssuc:InputFormControl>
	   </Template_InputFormControls>
 </wssuc:InputFormSection>

 <wssuc:ButtonSection runat="server">
	   <Template_Buttons>
		  <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnUpdateWeb_Click" Text="<%$Resources:wss,multipages_okbutton_text%>" id="BtnCreate" accesskey="<%$Resources:wss,okbutton_accesskey%>"/>
	   </Template_Buttons>
</wssuc:ButtonSection>
 </table>
</asp:Content>