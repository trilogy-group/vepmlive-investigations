<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="linkaccount.aspx.cs" Inherits="AdminSite.linkaccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Panel ID="pnlAccounts" runat="server">
    
        <b>You may link to the following accounts:</b><br />
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
                <asp:BoundField DataField="contact" HeaderText="Primary Contact" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Use">
                    <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" 
                         CommandArgument='<%# Eval("account_id") %>'  Enabled='<%# Eval("enabled") %>'
                         CommandName="use" runat="server">
                         <%# Eval("use") %></asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </asp:Panel>
    <asp:Panel ID="pnlNoAccounts" runat="server" Visible=false>
        <b>No accounts were found that can be used. Verify the following:</b><br /><br />
        <ul>
            <li>An account must exist with a valid primary contact</li>
            <li>The account must not already be linked</li>
            <li>The primary contact must have an email that matches this account (<%=strEmail %>)</li>
        </ul>
    </asp:Panel>
</asp:Content>
