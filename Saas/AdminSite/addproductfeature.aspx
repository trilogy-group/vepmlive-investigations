<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="addproductfeature.aspx.cs" Inherits="AdminSite.addproductfeature" %>
<%@ Register TagPrefix="prod" TagName="AddProductFeature" Src="~/WebControls/Product/AddProductFeature.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <prod:AddProductFeature runat="server" />
</asp:Content>
