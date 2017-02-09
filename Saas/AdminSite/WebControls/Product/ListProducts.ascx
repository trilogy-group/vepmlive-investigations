<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListProducts.ascx.cs" Inherits="AdminSite.WebControls.Product.ListProducts" %>

<asp:GridView ID="grdProducts" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" >
    <FooterStyle BackColor="#CCCC99" />
    <RowStyle BackColor="#F7F7DE" />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="sku" HeaderText="SKU">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="name" HeaderText="Name">
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Active?">
            <ItemTemplate>
                <%# ActiveToYesNo(Container.DataItem) %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <a href ='addproduct.aspx?id=<%# Eval("product_id") %>&edit=1'>Edit</a> <%# CheckIfDeletable(Container.DataItem) %>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
