<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="AdminSite.reports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>EPM Live Reports</title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem Text="--Select Report--" Value=""></asp:ListItem>
    <asp:ListItem Text="Publisher Trials" Value="0"></asp:ListItem>
    <asp:ListItem Text="Publisher Purchases" Value="1"></asp:ListItem>
    <asp:ListItem Text="EPM Live Trials" Value="2"></asp:ListItem>
    <asp:ListItem Text="Online Orders" Value="3"></asp:ListItem>
    <asp:ListItem Text="Toolkit V1" Value="4"></asp:ListItem>
    <asp:ListItem Text="Toolkit V2" Value="5"></asp:ListItem>
    <asp:ListItem Text="Online Trial Signups" Value="6"></asp:ListItem>
    <asp:ListItem Text="Newsletter Signups" Value="7"></asp:ListItem>
    <asp:ListItem Text="Active User Email Addresses" Value="8"></asp:ListItem>
    <asp:ListItem Text="Webinar Signups" Value="9"></asp:ListItem>
    </asp:DropDownList>
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Export To Excel</asp:LinkButton>
    
    <asp:DataGrid ID="gv2" runat="server" Height="1px">
    </asp:DataGrid>
            
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle HorizontalAlign="Left" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</div>
    </form>
</body>
</html>