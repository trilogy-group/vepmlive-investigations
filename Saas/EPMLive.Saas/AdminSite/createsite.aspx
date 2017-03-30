<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="createsite.aspx.cs" Inherits="AdminSite.createsite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<h3>Create Site</h3>
    <asp:Panel ID="pnlProcess" runat="server" Visible="false">
        <asp:Label id="lblProcess" runat="server"></asp:Label><br /><br />
        <a href="editaccount.aspx?account_id=<%=Request["account_id"] %>&tab=2">Return To Account</a>
    </asp:Panel>
   
    <asp:Panel ID="pnlInfo" runat="Server" Visible="True">
        <table border="0" cellpadding="1" cellspacing="2" style="margin: 10px">
            <tr>
                <td width="100" bgcolor="#c9c9c9">Site Name:</td>
                <td><asp:TextBox ID="txtSiteName" runat="server" CssClass="searchfield"/></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Site Url:</td>
                <td><asp:TextBox ID="txtSiteUrl" runat="server" CssClass="searchfield"/></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Template:</td>
                <td>
                    <asp:DropDownList ID="ddlTemplate" runat="server" >
                        <asp:ListItem Text="EPM Live Project Management Application" Value="EPM Live Project Management Application"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Add Site Admin:</td>
                <td>
                    <asp:DropDownList ID="ddlUser" runat="server" >
                        <asp:ListItem Text ="--Select User If Needed--" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2"><br /><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="searchbutton"/> 
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="searchbutton"/> </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
