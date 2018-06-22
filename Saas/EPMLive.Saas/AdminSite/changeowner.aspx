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
            height: 24px;
            cursor: pointer;
        }

        .form-row {
            padding: 5px 0 5px 0;
        }

        .form-field-caption {
            padding-bottom: 2px;
        }

        #changeOwnersActions {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlMain" runat="Server">        
            <b><font size="-1">Warning: This does not change any permissions in SharePoint</font></b><br />
            <div>
                <div id="accountPrimaryOwner" class="form-row">
                    <div class="form-field-caption">Primary owner: </div>
                    <asp:DropDownList ID="ddlOwner" runat="server"></asp:DropDownList>
                </div>
                <div id="accountSecondaryOwner" class="form-row">
                    <div class="form-field-caption">Secondary owner: </div>
                    <asp:DropDownList ID="secondaryOwner" runat="server"></asp:DropDownList>
                </div>
                <div id="changeOwnersActions" class="form-row">
                    <asp:Button ID="btnReset" runat="server" Text="Change Owners" OnClick="btnReset_Click" CssClass="button" style="width:100px"/>
                    <input type="button" value="Cancel" onclick="Javascript:parent.closereset();" class="button"/>
                </div>
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
