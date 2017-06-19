<%@ Assembly Name="Microsoft.SharePoint.IdentityModel, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"%> <%@ Page Language="C#" Inherits="Microsoft.SharePoint.IdentityModel.Pages.FormsSignInPage" MasterPageFile="~/_layouts/15/errorv15.master"       %> <%@ Import Namespace="Microsoft.SharePoint.WebControls" %> <%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Import Namespace="Microsoft.SharePoint" %> <%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral runat="server"  EncodeMethod="HtmlEncode" Id="ClaimsFormsPageTitle" />
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
 <div id="SslWarning" style="color:red;display:none">
 <SharePoint:EncodedLiteral runat="server"  EncodeMethod="HtmlEncode" Id="ClaimsFormsPageMessage" />
 </div>
  <script language="javascript" >
	if (document.location.protocol != 'https:')
	{
		var SslWarning = document.getElementById('SslWarning');
		SslWarning.style.display = '';
	}
  </script>
 <asp:login id="signInControl" FailureText="<%$Resources:wss,login_pageFailureText%>" runat="server" width="100%">
	<layouttemplate>
		<asp:label id="FailureText" class="ms-error" runat="server"/>
		<table width="100%">
		<tr>
			<td nowrap="nowrap"><SharePoint:EncodedLiteral runat="server" text="<%$Resources:wss,login_pageUserName%>" EncodeMethod='HtmlEncode'/></td>
			<td width="100%"><asp:textbox id="UserName" autocomplete="off" runat="server" class="ms-inputuserfield" width="99%" /></td>
		</tr>
		<tr>
			<td nowrap="nowrap"><SharePoint:EncodedLiteral runat="server" text="<%$Resources:wss,login_pagePassword%>" EncodeMethod='HtmlEncode'/></td>
			<td width="100%"><asp:textbox id="password" TextMode="Password" autocomplete="off" runat="server" class="ms-inputuserfield" width="99%"/></td>
		</tr>
		<tr>
			<td colspan="2" align="right"><asp:button id="login" commandname="Login" text="<%$Resources:wss,login_pagetitle%>" runat="server" /></td>
		</tr>
		<tr>
			<td colspan="2"><asp:checkbox id="RememberMe" text="<%$SPHtmlEncodedResources:wss,login_pageRememberMe%>" runat="server" /></td>
		</tr>
		</table>
	</layouttemplate>
 </asp:login>
</asp:Content>
