<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewkeyinfo.aspx.cs" Inherits="AdminSite.viewkeyinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="1" cellspacing="2">
            <tr>
                <td width="100" bgcolor="#c9c9c9"><b>Version:</b></td>
                <td><asp:Label ID="lblVersion" runat="Server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Company:</td>
                <td><asp:Label ID="lblCompany" runat="Server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Features:</td>
                <td><asp:Label ID="lblFeatures" runat="Server"></asp:Label></td>
            </tr>
            <tr style="display:<%=disp%>">
                <td width="100" bgcolor="#c9c9c9">User Count:</td>
                <td><asp:Label ID="lblUsers" runat="Server"></asp:Label></td>
            </tr>
		    <tr style="display:<%=disp%>">
                <td width="100" bgcolor="#c9c9c9">Server Count:</td>
                <td><asp:Label ID="lblServers" runat="Server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Purchase Date:</td>
                <td><asp:Label ID="lblPurchase" runat="Server"></asp:Label></td>
            </tr>
            <tr>
                <td width="100" bgcolor="#c9c9c9">Expiration Date:</td>
                <td><asp:Label ID="lblExpiration" runat="Server"></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

