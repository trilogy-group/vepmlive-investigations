<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="linksite.aspx.cs" Inherits="AdminSite.linksite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

<table >
    <tr>
        <td>Site Title: </td>
        <td><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Site URL: </td>
        <td><asp:TextBox ID="txtURL" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Site GUID: </td>
        <td><asp:TextBox ID="txtGUID" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnLink" Text="Link" runat="server" onclick="btnLink_Click" CssClass="searchbutton"/></td>
    </tr>
</table>

</asp:Content>
