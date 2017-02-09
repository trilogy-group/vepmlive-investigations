<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="AdminSite.addproduct" %>
<%@ Register TagPrefix="prod" TagName="AddEditProduct" Src="~/WebControls/Product/AddEditProduct.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <h3>Product Detail</h3>
     <div id="a_tabbar" class="dhtmlxTabBar" select="a<%=CurrentTab %>" imgpath="dhtmlxtab/imgs/" style="width: 100%; height: 500px;" skincolors="#FCFBFC,#F4F3EE">
        <div id="a1">
            <prod:AddEditProduct runat="server" />
        </div>
        <div id="a2">
            
        </div>
    </div>
    

</asp:Content>
