<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.addperiod"%>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add Period</title>
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/core.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label runat="server" ID="lblError" ForeColor="red" Visible="false"></asp:Label>
    <br />
        <table>
            <tr>
                <td class="ms-sectionheader">Period Name:</td>
                <td style="width: 223px">
                    <asp:TextBox ID="txtName" runat="server" CssClass="ms-input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" class="ms-sectionheader">Start Date:</td>
                <td style="width: 223px">
                <SharePoint:DateTimeControl ID="calStart" runat="server" DateOnly="True" >
                    <asp:TextBox ID="calStart2Date" runat="server" CssClass="ms-input" MaxLength="45"></asp:TextBox>
                </SharePoint:DateTimeControl>
                </td>
            </tr>
            <tr>
                <td valign="top" class="ms-sectionheader">End Date:</td>
                <td style="width: 223px">
                <SharePoint:DateTimeControl ID="calEnd" runat="server" DateOnly="True" >
                    <asp:TextBox ID="calEnd2Date" runat="server" CssClass="ms-input" MaxLength="45"></asp:TextBox>
                </SharePoint:DateTimeControl>
                </td>
            </tr>
            <tr>
                <td class="ms-sectionheader">Capacity:</td>
                <td style="width: 223px">
                    <asp:TextBox ID="txtCapacity" runat="server" CssClass="ms-input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="width: 223px"><asp:Button ID="btnSubmit" runat="server" Text="Add Period" OnClick="btnSubmit_Click" /></td>
            </tr>
        </table> 
    </div>
    </form>
</body>
</html>
