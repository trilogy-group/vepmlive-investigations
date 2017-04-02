<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="manageproducts.aspx.cs" Inherits="AdminSite.manageproducts" %>

<%@ Register TagPrefix="prod" TagName="ListProducts" Src="WebControls/Product/ListProducts.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <h3>License Products</h3><br/>
    <prod:ListProducts runat="server" />
    <br/><br/>
    <a href="addproduct.aspx">[New Product]</a>
</asp:Content>
