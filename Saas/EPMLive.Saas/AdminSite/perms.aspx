<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="perms.aspx.cs" Inherits="AdminSite.perms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<table cellpadding="5" width="100%">
        <tr>
            <td>
                <asp:Panel ID="pnlMain" runat="server">
                <asp:GridView ID="GridView1" runat="server" Width="100%" BorderStyle="None" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" ShowHeader="True"/>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" />
                    <HeaderStyle Wrap="True" BackColor="#6B696B" Font-Bold="True" Font-Names="Verdana,Arial" Font-Size="Smaller" ForeColor="White" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                </asp:Panel>
                <asp:Panel ID="pnlEdit" runat="server" Visible="false" Width="100%">
                    <asp:HiddenField ID="hdnUserId" runat="server" />
                    Editing: <asp:Label runat="server" ID="lblUsername"></asp:Label>
                    <br /><br />
                    <asp:Label ID="lblEditPerms" runat="server"></asp:Label>
                    <br /><br />
                    <asp:Button ID ="btnSave" CssClass="searchbutton" runat="server" OnClick="btnSave_Click" text="Save"/> <asp:Button ID ="btnCancel" CssClass="searchbutton" runat="server" OnClick="btnCancel_Click" text="Cancel"/>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
