<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="addemail.aspx.cs" Inherits="AdminSite.addemail" %>
<h1>Add E-Mail Template</h1>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" text="Save" CssClass="searchbutton"/><br /><br />
            Subject: <asp:TextBox ID="txtSubject" runat="server" Columns="100"></asp:TextBox><br />
            From E-Mail: <asp:TextBox ID="txtMailFrom" runat="server" Columns="100"></asp:TextBox><br />
            From Name: <asp:TextBox ID="txtMailFromName" runat="server" Columns="100"></asp:TextBox><br />
            <asp:TextBox ID="text" runat="server" TextMode="multiLine" Rows="30" Columns="100"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmit2" runat="server" OnClick="btnSubmit_Click" text="Save" CssClass="searchbutton"/><br />
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
</asp:Content>
