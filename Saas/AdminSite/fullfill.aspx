<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="fullfill.aspx.cs" Inherits="AdminSite.fullfill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <h3>Fill Invoice</h3>

    <asp:Panel ID="pnlProcess" runat="server" Visible="False">
        <asp:Label ID="lblProcess" runat="server"></asp:Label>
        <br /><br /><br />
        <b>Results:</b>
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView1_RowCommand">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Product" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="typename" HeaderText="Type" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="dbqty" HeaderText="Item Quantity" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ordqty" HeaderText="Order Quantity" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
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
                <asp:BoundField DataField="invoicenumber" HeaderText="Invoice Number" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Fill">
                    <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" 
                         CommandArgument='<%# Eval("invoice_id") %>'
                         CommandName="use" runat="server">Fill Invoice</asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remove">
                    <ItemTemplate>
                       <asp:LinkButton ID="LinkButton2" 
                         CommandArgument='<%# Eval("invoice_id") %>'
                         CommandName="remove" runat="server">Remove</asp:LinkButton>
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
