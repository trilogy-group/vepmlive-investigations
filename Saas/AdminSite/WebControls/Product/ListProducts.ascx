<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListProducts.ascx.cs" Inherits="AdminSite.WebControls.Product.ListProducts" %>
<%@ Import Namespace="EPMLive.OnlineLicensing.Api.Data" %>

<asp:GridView ID="grdProducts" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
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
                <%# ActiveToYesNo(((LicenseProduct)Container.DataItem).active) %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <a href='addproduct.aspx?id=<%# Eval("product_id") %>&edit=1'>Edit</a> <%# CheckIfDeletable(((LicenseProduct)Container.DataItem).name,string.Format("addproduct.aspx?id={0}&del=1",((LicenseProduct)Container.DataItem).product_id), ()=> ((LicenseProduct)Container.DataItem).CanBeDeleted) %>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
