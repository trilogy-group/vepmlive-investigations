<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdminSite.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

   <h1>Search Online Accounts</h1>
    Select Column: 
    <asp:DropDownList ID="ddlColumn" runat="server" class="searchfield">
        <asp:ListItem Selected="True" Value="firstName">First Name</asp:ListItem>
        <asp:ListItem Value="lastName">Last Name</asp:ListItem>
        <asp:ListItem>Company</asp:ListItem>
        <asp:ListItem Value="Email">Email</asp:ListItem>
        <asp:ListItem Value="account_ref">Account #</asp:ListItem>
        <asp:ListItem Value="accountdescription">Account Name</asp:ListItem>
    </asp:DropDownList> 
    Search For:
    <asp:TextBox ID="txtSearch" runat="server" class="searchfield"></asp:TextBox> 
    <asp:Button ID="Button1" runat="server" Text="Search" class="searchbutton" OnClick="Button1_Click" />
    <br /><br />
    <b><asp:Label ID="lblResults" runat="server"></asp:Label></b><br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView1_RowCommand">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Name" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="email" HeaderText="Email" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Company" HeaderText="Company" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="AccountDescription" HeaderText="Account Name" >
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="View">
                <ItemTemplate>
                   <asp:LinkButton ID="LinkButton1" 
                     CommandArgument='<%# Eval("account_id") %>' 
                     CommandName="view" runat="server">
                     View/Edit</asp:LinkButton>
                 </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
