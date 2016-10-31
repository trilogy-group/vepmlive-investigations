<%@ Page Title="" Language="C#" MasterPageFile="~/Signup.Master" AutoEventWireup="true" CodeBehind="onlinepricingtool.aspx.cs" Inherits="BillingSite.sales.onlinepricingtool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

Select Product: <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="true" >
    <asp:ListItem Text="WorkEngine" Value="adc217cc-ed78-4066-8743-5297148859c4"></asp:ListItem>
    <asp:ListItem Text="PortfolioEngine" Value="a7ddc49d-1a28-4443-8ba1-fa907b0bbea1"></asp:ListItem>
</asp:DropDownList>
<br /><br />
Select Version: <asp:DropDownList ID="ddlVersion" runat="server" 
        AutoPostBack="true">
    <asp:ListItem Text="Standard" Value="Standard"></asp:ListItem>
    <asp:ListItem Text="Professional" Value="Professional"></asp:ListItem>
    <asp:ListItem Text="Ultimate" Value="Ultimate"></asp:ListItem>
</asp:DropDownList>
<br /><br />
Select Contract Terms: <asp:DropDownList id="ddlContract" runat="server" AutoPostBack="true">
    <asp:ListItem Text="Yearly with Yearly Payment" Value=".9"></asp:ListItem>
    <asp:ListItem Text="Yearly Contract" Value="1"></asp:ListItem>
    <asp:ListItem Text="Quarterly Contract" Value="1.1111111111111"></asp:ListItem>
    <asp:ListItem Text="Monthly Contract" Value="1.25"></asp:ListItem>
</asp:DropDownList>
<br /><br />
Select Billing Cycle: <asp:DropDownList id="ddlBilling" runat="server" AutoPostBack="true">
    <asp:ListItem Text="Yearly" Value="12"></asp:ListItem>
    <asp:ListItem Text="Quarterly" Value="3"></asp:ListItem>
    <asp:ListItem Text="Monthly" Value="1"></asp:ListItem>
</asp:DropDownList>
<br /><br />

User Count (Leave Blank for Full Table): <asp:TextBox ID="txtUsers" runat="server" AutoPostBack="true"></asp:TextBox>
<br /><br />
<asp:Button ID="btnMain" Text="Calculate" runat="server" /><br />
<br /><br />
<font style="line-height:16px; padding-top:10px;">
<asp:Label ID="lblOutput" runat="server"></asp:Label>
</font>


</asp:Content>

<asp:Content ID="pPageDescription" ContentPlaceHolderID="pPageDescription" runat="server" >

This tool can be used to determine pricing for our online solution.

</asp:Content>

<asp:Content ID="pPageTitle" ContentPlaceHolderID="pPageTitle" runat="server">
EPM Live Pricing
</asp:Content>