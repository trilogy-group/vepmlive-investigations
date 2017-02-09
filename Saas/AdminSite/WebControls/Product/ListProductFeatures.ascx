<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListProductFeatures.ascx.cs" Inherits="AdminSite.WebControls.Product.ListProductFeatures" %>
<%@ Import Namespace="OnlineLicensing.Api.Data" %>

<asp:GridView ID="grdProductFeatures" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
    <FooterStyle BackColor="#CCCC99" />
    <RowStyle BackColor="#F7F7DE" />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:TemplateField HeaderText="Feature">
            <ItemTemplate>
                <%# ((LICENSEDETAIL)Container.DataItem).DETAILTYPE.detail_name %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="External User?">
            <ItemTemplate>
                <%# ActiveToYesNo(((LICENSEDETAIL)Container.DataItem).DETAILTYPE.externalusers ?? false) %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <%# CheckIfDeletable(((LICENSEDETAIL)Container.DataItem).DETAILTYPE.detail_name,string.Format("addproductfeature.aspx?id={0}&fid={1}&del=1",((LICENSEDETAIL)Container.DataItem).product_id,((LICENSEDETAIL)Container.DataItem).license_detail_id), ()=>true) %>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        <div class="info-box">
            <br />
            No Features found for current product, please <a href="addproductfeature.aspx?id=<%= Request["id"] %>">[Add a Feature]</a><br />
        </div>
    </EmptyDataTemplate>
</asp:GridView>
