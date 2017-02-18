<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deletelicense.aspx.cs" Inherits="AdminSite.deletelicense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Revoke License</title>
    <link href="style/licensesManagement.css" rel="stylesheet" />
</head>
<body>
    <form id="deleteLicenseForm" runat="server">
    <div>
        <h3>Confirm that you want to revoke this license.</h3>
        <textarea rows="5" id="txaComments" runat="server" placeholder="describe the reason for revoke..."/>
    </div>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Revoke"  />
        <asp:Button id="Button2" runat="server" Text="Cancel" OnClientClick="parent.CloseDeleteLicenseModal()"/>
    </form>
</body>
</html>
