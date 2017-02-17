<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InactiveLicenses.ascx.cs" Inherits="AdminSite.WebControls.Licensing.InactiveLicenses" %>
<br />
<br />
<b>Inactive Licenses</b>
<br />
<br />
<asp:GridView Width="96%" RowStyle-HorizontalAlign="Left" ID="grdInactiveLicenses" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px">
    <Columns>
        <asp:BoundField DataField="product" HeaderText="Product">
            <ItemStyle HorizontalAlign="left" />
        </asp:BoundField>
        <asp:BoundField DataField="features" HeaderText="Features" HtmlEncode="false">
            <ItemStyle HorizontalAlign="left" />
        </asp:BoundField>
        <asp:BoundField DataField="expirationdate" HeaderText="Expiration Date">
            <ItemStyle HorizontalAlign="left" />
        </asp:BoundField>
         <asp:BoundField DataField="reasonText" HeaderText="Reason">
            <ItemStyle HorizontalAlign="left" />
        </asp:BoundField>
         <asp:BoundField DataField="comment" HeaderText="Comment">
            <ItemStyle HorizontalAlign="left" />
        </asp:BoundField>
    </Columns>
    <EmptyDataTemplate>
        <div class="info-box">
            <br />
            No inactive licenses were found.
        </div>
    </EmptyDataTemplate>
    <FooterStyle BackColor="#CCCC99" />
    <RowStyle BackColor="#F7F7DE" HorizontalAlign="Center" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" />
</asp:GridView>

