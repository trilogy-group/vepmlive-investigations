<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changeowner.aspx.cs" Inherits="AdminSite.changeowner" %>

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
        <asp:Panel ID="pnlMain" runat="Server">
        
            <b><font size="-1">Warning: This does not change any permissions in SharePoint</font></b><br /><br />
            <div>
                Reset to: <asp:DropDownList ID="ddlOwner" runat="server"></asp:DropDownList>
                <asp:Button ID="btnReset" runat="server" Text="Change Owner" OnClick="btnReset_Click" CssClass="button" style="width:100px"/>
                <input type="button" value="Cancel" onclick="Javascript:parent.closereset();" class="button"/>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlMessage" runat="server" Visible="false">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <input type="button" value="Close" onclick="Javascript:parent.location.href=parent.location.href;" class="button"/>
        </asp:Panel>
    </form>
</body>
</html>
