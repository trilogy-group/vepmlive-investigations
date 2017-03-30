<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProductFeature.ascx.cs" Inherits="AdminSite.WebControls.Product.AddProductFeature" %>

<table>
        <tr>
            <td colspan="2">
                <asp:panel id="pnlForm" name="pnlForm" runat="server">
        <table border="0" cellpadding="1" cellspacing="2" style="margin: 10px">
        <tr>
            <td width="100" bgcolor="#c9c9c9" nowrap>Name:</td>
            <td><asp:DropDownList ID="ddlDetailType" runat="server">
            </asp:DropDownList></td>
        </tr>        
    </table>
    </asp:panel>

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <asp:button id="btnSave" runat="server" text="Save" onclick="btnSave_Click" cssclass="searchbutton" />
                <asp:button id="btnCancel" runat="server" text="Cancel" onclick="btnCancel_Click" cssclass="searchbutton" />
            </td>
            
        </tr>
        <tr>
            <td colspan="2">
                <asp:label runat="server" id="lblMessage"></asp:label>
            </td>
        </tr>
    </table>
