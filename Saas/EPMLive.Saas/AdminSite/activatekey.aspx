<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="activatekey.aspx.cs" Inherits="AdminSite.activatekey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
            input.button
            { background: #605D58; 
              border: 0px; 
              padding: 1px;
              color: #FFF;
              width: 64px;
              cursor: pointer;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlMain" runat="server">
            Farm Guid: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Activate" 
                onclick="Button1_Click"/>
        </asp:Panel>

        <asp:Panel ID="pnl2" runat="server" Visible="false">
        <asp:TextBox ID="lbl2" runat="server" Width="480px"></asp:TextBox><br /><br />
        <a href="#" onclick="parent.closereset();">Close</a>
        </asp:Panel>
    </div>
    </form>
    
</body>
</html>
