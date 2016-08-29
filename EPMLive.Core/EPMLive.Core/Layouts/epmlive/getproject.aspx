<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.getproject" %> 

<html>
<form runat="server" >
    <table border="0" width="200" cellspacing="0" >
    <tr>
        <td align="center" class="ms-vb2" >
            <font class="ms-descriptiontext">Select Template:</font>
        </td>
    </tr>
    <tr>
        <td align="center" class="ms-vb2" >
            <asp:DropDownList id="ddlTemplates" runat="server">
            </asp:DropDownList>
            <asp:Button id="btnOk" runat="server" text="Ok" OnClick="btnOk_Click" CssClass="ms-ButtonHeightWidth" />
        </td>
    </tr>
    </table>
    <input type="hidden" name="projectname" id="projectname" value="<% Response.Write(projectname); %>" />
</form>
</html>