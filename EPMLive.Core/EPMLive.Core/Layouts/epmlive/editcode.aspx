<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.editcode"%>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Outline Code</title>
    <link rel="stylesheet" type="text/css" href="/_layouts/1033/styles/core.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:Label runat="server" ID="lblError" ForeColor="red" Visible="false"></asp:Label>
    <br />
        <table>
            <tr>
                <td class="ms-sectionheader" nowrap>Field Name:</td>
                <td style="width: 223px">
                    <asp:TextBox ID="txtName" runat="server" CssClass="ms-input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="ms-sectionheader" nowrap>Display Name:</td>
                <td style="width: 223px">
                    <asp:TextBox ID="txtDisplayName" runat="server" CssClass="ms-input"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="ms-sectionheader" nowrap>Code Type:</td>
                <td style="width: 223px">
                    <asp:DropDownList ID="ddlCodeType" runat="server" CssClass="ms-input">
                        <asp:ListItem Value="Project" Text="Project"></asp:ListItem>
                        <asp:ListItem Value="Task" Text="Task"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="width: 223px"><asp:Button ID="btnSubmit" runat="server" Text="Save Outline Code" OnClick="btnSubmit_Click" /></td>
            </tr>
        </table> 
    </div>
    </form>
</body>
</html>
