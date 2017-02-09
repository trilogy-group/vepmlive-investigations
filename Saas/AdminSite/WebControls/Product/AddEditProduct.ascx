<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditProduct.ascx.cs" Inherits="AdminSite.WebControls.Product.AddEditProduct" %>


<table>
        <tr>
            <td colspan="2">

                <asp:panel id="pnlForm" name="pnlForm" runat="server">
        <table border="0" cellpadding="1" cellspacing="2" style="margin: 10px">
        <tr>
            <td width="100" bgcolor="#c9c9c9" nowrap><strong>Product #:</strong></td>
            <td>
                <asp:label id="lblProductId" runat="server"></asp:label>
            </td>
        </tr>
        <tr>
            <td width="100" bgcolor="#c9c9c9" nowrap>SKU #:</td>
            <td>
                <asp:textbox id="txtSKU" runat="server" width="100"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td width="100" bgcolor="#c9c9c9" nowrap>Name:</td>
            <td>
                <asp:textbox id="txtName" runat="server" width="200"></asp:textbox>
            </td>
        </tr>
            <tr>
            <td width="100" bgcolor="#c9c9c9" nowrap>Active:</td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" />
            </td>
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