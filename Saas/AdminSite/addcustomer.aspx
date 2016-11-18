<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="addcustomer.aspx.cs" Inherits="AdminSite.addcustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

<table>
    <tr>
        <td>First Name:</td>
        <td><asp:TextBox ID="txtFirst" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Last Name:</td>
        <td><asp:TextBox ID="txtLast" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>E-Mail:</td>
        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><asp:Label ID="lblEmail" runat="server" Visible="false" Text="That email already exists" ForeColor="red"></asp:Label></td>
    </tr>
     <tr>
        <td>Company:</td>
        <td><asp:TextBox ID="txtCompany" runat="server"></asp:TextBox><br /><asp:Label ID="lblCompany" runat="server" Visible="false" Text="That company already exists" ForeColor="red"></asp:Label></td>
    </tr>
    <tr>
        <td>Title:</td>
        <td><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Address1:</td>
        <td><asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Address2:</td>
        <td><asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>City:</td>
        <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>State:</td>
        <td><asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Zip:</td>
        <td><asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Country:</td>
        <td><asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Phone:</td>
        <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button runat="server" OnClick="Button1_Click" ID="Button1" Text="Add " CssClass="searchbutton"/></td>
    </tr>
</table>
</asp:Content>
