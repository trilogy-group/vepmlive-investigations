<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleteweb.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.deleteweb" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script type="text/javascript">
// <![CDATA[
    function ULS2x2() { var o = new Object; o.ULSTeamName = "Microsoft SharePoint Foundation"; o.ULSFileName = "deleteweb.aspx"; return o; }
    function _spBodyOnLoad() {
        ULS2x2: ;
        try {
            document.getElementById("BtnCancel").focus();
        }
        catch (e) { }
    }
    function confirmDelete() {
        ULS2x2: ;
        return confirm("<SharePoint:EncodedLiteral runat='server' text='<%$Resources:wss,deleteweb_confirmation%>' EncodeMethod='EcmaScriptStringLiteralEncode'/>");
    }
// ]]>
	</script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<table border="0" cellspacing="0" cellpadding="0" width="100%" class="ms-propertysheet ms-v4propertysheetspacing">
	<tr>
	 <td class="ms-descriptiontext">
	  <b><SharePoint:EncodedLiteral ID="EncodedLiteral4" runat="server" text="<%$Resources:wss,deleteweb_warning%>" EncodeMethod='HtmlEncode'/></b>
	 </td>
	</tr>
	<tr>
	 <td height="2"><img src="/_layouts/images/blank.gif" width='1' height='2' alt="" /></td>
	</tr>
	<tr>
	 <td class="ms-descriptiontext">
	  <SharePoint:EncodedLiteral ID="EncodedLiteral5" runat="server" text="<%$Resources:wss,deleteweb_deletefollowingweb%>" EncodeMethod='HtmlEncode'/>
	  <asp:Label dir="ltr" id="LabelWebUrl" runat="server"/>
	 </td>
	</tr>
	<tr>
	 <td class="ms-descriptiontext"><img src="/_layouts/images/blank.gif" width='1' height='10' alt="" /></td>
	</tr>
	<tr>
	 <td class="ms-descriptiontext">
		<SharePoint:EncodedLiteral ID="EncodedLiteral6" runat="server" text="<%$Resources:wss,deleteweb_destroycontent%>" EncodeMethod='HtmlEncode'/>
	 </td>
	</tr>
	<tr>
	 <td class="ms-descriptiontext"><img src="/_layouts/images/blank.gif" width='1' height='10' alt="" /></td>
	</tr>
	<tr>
	 <td class="ms-descriptiontext">
	  <ul>
	   <li>
		<SharePoint:EncodedLiteral ID="EncodedLiteral7" runat="server" text="<%$Resources:wss,deleteweb_idTextDoclib%>" EncodeMethod='HtmlEncode'/>
	   </li>
	   <li>
		<SharePoint:EncodedLiteral ID="EncodedLiteral8" runat="server" text="<%$Resources:wss,deleteweb_idTextList%>" EncodeMethod='HtmlEncode'/>
	   </li>
	   <li>
		<SharePoint:EncodedLiteral ID="EncodedLiteral9" runat="server" text="<%$Resources:wss,deleteweb_idTextWeb%>" EncodeMethod='HtmlEncode'/>
	   </li>
	   <li>
		<SharePoint:EncodedLiteral ID="EncodedLiteral10" runat="server" text="<%$Resources:wss,deleteweb_idTextSecurity%>" EncodeMethod='HtmlEncode'/>
	   </li>
	   <asp:PlaceHolder id="PanelGroupsToDelete" runat="server" Visible="False">
		   <li>
			<SharePoint:EncodedLiteral ID="EncodedLiteral11" runat="server" text="<%$Resources:wss,deleteweb_idTextGroups%>" EncodeMethod='HtmlEncode'/> <asp:Label id="LabelGroupsToDelete" runat="server"/>
		   </li>
	   </asp:PlaceHolder>
	   <asp:PlaceHolder id="PanelRootWeb" runat="server" Visible="False">
	   <li><SharePoint:EncodedLiteral ID="EncodedLiteral12" runat="server" text="<%$Resources:wss,deleteweb_idSubwebsContentInfo%>" EncodeMethod='HtmlEncode'/></li>
	   </asp:PlaceHolder>
	  </ul>
	 </td>
	</tr>
	<tr>
	 <td class="ms-descriptiontext">
	  <b><SharePoint:EncodedLiteral ID="EncodedLiteral13" runat="server" text="<%$Resources:wss,deleteweb_tocontinue%>" EncodeMethod='HtmlEncode'/></b>
	 </td>
	</tr>
   <asp:PlaceHolder id="PanelGradualDeleteWarning" runat="server" Visible="False">
		<tr>
		 <td class="ms-descriptiontext"><img src="/_layouts/images/blank.gif" width='1' height='10' alt="" /></td>
		</tr>
		<tr>
		 <td class="ms-descriptiontext">
		  <SharePoint:EncodedLiteral ID="EncodedLiteral14" runat="server" text="<%$Resources:wss,deleteweb_gradualwarning%>" EncodeMethod='HtmlEncodeAllowSimpleTextFormatting'/>
		 </td>
		</tr>
   </asp:PlaceHolder>
	<tr>
	 <td class="ms-descriptiontext"><img src="/_layouts/images/blank.gif" width='1' height='10' alt="" /></td>
	</tr>
   </table>
   <table border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet" width="100%">
		<wssuc:ButtonSection runat="server">
			<Template_Buttons>
				<asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" OnClick="BtnDelete_Click" Text="<%$Resources:wss,deleteweb_delete%>" id="BtnDelete" OnClientClick='if (!confirmDelete()) return false;' accesskey="<%$Resources:wss,deleteweb_delete_accesskey%>"/>
			</Template_Buttons>
		</wssuc:ButtonSection>
   </table>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="<%$Resources:wss,deleteweb_pagetitle%>" EncodeMethod='HtmlEncode'/>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    <a href="settings.aspx"><SharePoint:EncodedLiteral ID="EncodedLiteral2" runat="server" text="<%$Resources:wss,settings_pagetitle%>" EncodeMethod="HtmlEncode"/></a>&#32;<SharePoint:ClusteredDirectionalSeparatorArrow ID="ClusteredDirectionalSeparatorArrow1" runat="server" /> <SharePoint:EncodedLiteral ID="EncodedLiteral3" runat="server" text="<%$Resources:wss,deleteweb_pagetitle%>" EncodeMethod='HtmlEncode'/>
</asp:Content>
