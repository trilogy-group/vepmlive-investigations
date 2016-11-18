<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="addorder.aspx.cs" Inherits="AdminSite.addorder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<h3>Import Order</h3>
    <asp:Panel ID="pnlProcess" runat="server" Visible="False">
        <asp:Label ID="lblProcess" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlOrder" runat="server" >
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
                <asp:BoundField DataField="ordernumber" HeaderText="Order Number" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Import Order">
                    <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" 
                         CommandArgument='<%# Eval("order_id") %>'
                         CommandName="use" runat="server">Import Order</asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="pnlNoOrders" runat="server" Visible="false">
        <b>No order were found for the linked account:</b><br /><br />
        <ul>
            <li>An order exists in CRM for the linked account</li>
            <li>The order is of "Online" type</li>
            <li>The order is not already in use in the system</li>
        </ul>
        <a href="editaccount.aspx?account_id=<%=Request["account_id"] %>&tab=3">[Return To Account]</a>
    </asp:Panel>

</asp:Content>
