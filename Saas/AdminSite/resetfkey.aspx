<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetfkey.aspx.cs" Inherits="AdminSite.resetfkey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style>
        input.button
        {
            background: #605D58;
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
        Reset to: <asp:TextBox ID="txtActivations" runat="Server" Width="39px" Text="1"/> / <%=strLic %>
        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="button"/>
        <input type="button" value="Cancel" onclick="Javascript:parent.closereset();" class="button"/>
    </div>
    </form>
</body>
</html>

