<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="expired.aspx.cs" Inherits="EPMLiveAccountManagement.expired" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Account Expired" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Account Expired"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
    <asp:Panel ID="pnlTrial" runat="server" Visible="false">
		<table cellpadding="10" cellspacing="10" border="0" width="100%">
	<tr>
		<td align="left" width="100%">You have been redirected to this page for one of the following reasons:</td>
	</tr>
	<tr>
		<td align="left"><ul>
		<li>There are no users purchased for this account.</li>
		<li>The users purchased for this account do not match this environment or level.  This could happen if the users that were purchased for this account were purchased in the 2007 environment instead of in the 2010 environment.</li>
		</ul>
		</td>
	</tr>
	<tr>
		<td align="left"><a href="#" onclick="SP.UI.ModalDialog.showModalDialog({url: '<%=siteUrl %>/_layouts/epmlive/manageaccount.aspx',width: 800,height: 600});">Click here to manage your accounts.</a>
		</td>
	</tr>
	

	</table>

       
    </asp:Panel>
    <asp:Panel ID="pnlAccounts" runat="server" Visible="false">
        <p align="center">
        You have been redirected to this page because the number of Active Accounts in your EPM Live environment exceeds the number of Accounts that you have purchased. 
        <br /><br />

        <a href="http://www.workengine.com/Applications/SitePages/BuyNow.aspx?account_ref=<%=account_ref %>&quantity=<%=quantity %>&version=<%=version %>&level=<%=level %>" target="_blank"><img src="images/buymore.gif" border="0" /></a>
<br /><br />
        <a href="#" onclick="SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog',{url: '<%=siteUrl %>/_layouts/epmlive/manageaccount.aspx',width: 800,height: 600});">Click here</a> to manage your Accounts
        </p>
    </asp:Panel>
</asp:Content>
