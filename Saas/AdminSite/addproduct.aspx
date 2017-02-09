<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="AdminSite.addproduct" %>

<%@ Register TagPrefix="prod" TagName="AddEditProduct" Src="~/WebControls/Product/AddEditProduct.ascx" %>
<%@ Register TagPrefix="prod" TagName="ListProductFeatures" Src="~/WebControls/Product/ListProductFeatures.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <link rel="STYLESHEET" type="text/css" href="dhtmlxtab/dhtmlxtabbar.css">
    <script src="dhtmlxtab/dhtmlxcommon.js"></script>
    <script src="dhtmlxtab/dhtmlxtabbar.js"></script>
    <script src="dhtmlxtab/dhtmlxtabbar_start.js"></script>
    <h3>Product Detail</h3>
    <div id="a_tabbar" class="dhtmlxTabBar" select="a<%=CurrentTab %>" imgpath="dhtmlxtab/imgs/" style="width: 100%; height: 500px;" skincolors="#FCFBFC,#F4F3EE">
        <div id="a1" name="Product Information" width="140px">
            <prod:AddEditProduct runat="server" />
        </div>
        <div id="a2" name="Product Features" width="140px">
            <div <%= EnableForEditOnly() %>>
            <prod:ListProductFeatures runat="server" />
            <br/><br/>
            <a href="addproductfeature.aspx?id=<%= Request["id"] %>">[Add Feature]</a>

            </div>
        </div>
    </div>
</asp:Content>
