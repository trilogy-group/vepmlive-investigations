<%@ Assembly Name="EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveEnterprise.addfield" %> 

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add Field</title>
</head>
<body>
    <form id="form1" runat="server">
    <div><font face="arial" size="-1">
        <b>Choose 1 or more fields:</b><br />
        <asp:ListBox ID="ListBox1" runat="server" Height="180px" Width="240px" SelectionMode="Multiple"></asp:ListBox><br />
        <asp:Button ID="Button1" runat="server" Text="Add Fields" OnClick="Button1_Click" />
        </font>
        </div>
        
    </form>
</body>
</html>
