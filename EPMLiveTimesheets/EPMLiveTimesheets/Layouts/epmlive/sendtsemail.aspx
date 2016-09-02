<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendtsemail.aspx.cs" Inherits="TimeSheets.sendtsemail" DynamicMasterPageFile="~masterurl/default.master" %>



<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Send E-mail" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="Send E-Mail"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to send email to Timesheet users.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<asp:HiddenField ID="hdnEmails" runat="server" />
<asp:HiddenField ID="hdnNames" runat="server" />

<asp:Panel ID="pnlMain" runat="server">
<table border="0">
    <tr>
        <td class="ms-descriptiontext"><b>Subject:</b></td>
    </tr>
    <tr>
        <td class="ms-descriptiontext"> <asp:TextBox ID="txtSubject" runat="server" CssClass="ms-input" Width="300" Text="Message from timesheet approver: "></asp:TextBox></td>
    </tr>
    <tr>
        <td class="ms-descriptiontext"><b>Body:</b></td>
    </tr>
    <tr>
        <td class="ms-descriptiontext"><asp:TextBox ID="txtBody" TextMode="MultiLine" runat="server" CssClass="ms-input" Height="200" Width="500"></asp:TextBox><br />Note: A link to this site will be appended to the email.</td>
    </tr>
    <tr>
        <td align="right"><asp:Button ID="btnSend" runat="server" Text="Send E-mail"  CssClass="ms-input" OnClick="btnSend_Click" /> <asp:Button ID="btnCancel" CssClass="ms-input" runat="server" Text="Cancel" OnClientClick="javascript:SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', 0, '')"/></td>
    </tr>
</table>
<b>The following users will receive this email:</b><br />
<%=strUsers %>
</asp:Panel>
<asp:Panel ID="pnlSent" runat="server" Visible="false">
E-mail results:<br />
<%=strSent %>
<br /><br />
<a href="#" onclick="javascript:SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', 0, '')">Close</a>
</asp:Panel>
<asp:Panel ID="pnlNone" runat="server" Visible="false">
Based off the selection, there are no users available for emailing.
</asp:Panel>
</asp:Content>