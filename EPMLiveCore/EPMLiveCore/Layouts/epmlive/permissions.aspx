<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="permissions.aspx.cs" Inherits="EPMLiveCore.permissions" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Site Permissions: Add Users
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Site Permissions: Add Users
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    For each user, select the appropriate group permissions for this site.
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
<script language="javascript">
    function chk(chkid, ddlid) {
        var chk = document.getElementById(chkid);
        var divDDL = document.getElementById(ddlid);
        if (chk.checked)
            divDDL.style.display = "";
        else
            divDDL.style.display = "none";
    }
</script>
<table border="0" cellpadding="5" cellspacing="0" style="border:  1px solid #303030" align="center">
    <tr>
        <td bgcolor="#D6E8FF">
            <asp:GridView ID="GvSelect" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" DataKeyNames="LoginName">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top" Visible="false">
                    <ItemTemplate>
                        <asp:CheckBox id="chkChange" runat="server" Checked='<%# Eval("Email").ToString() != "" %>'></asp:CheckBox>
                     </ItemTemplate>
                      </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                    <asp:BoundField DataField="email" HeaderText="E-Mail" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                    <asp:TemplateField ItemStyle-VerticalAlign="top" HeaderText="Group" ItemStyle-Width="200">
                     <ItemTemplate>
                        <asp:DropDownList ID="ddlGroup" runat="server" Visible="true" ></asp:DropDownList>
                     </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="loginname" HeaderText="E-Mail" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small"/>
                <EditRowStyle BackColor="#999999" Font-Size="X-Small" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" Font-Size="X-Small"/>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Size="X-Small"/>
                <HeaderStyle BackColor="#c9c9c9" Font-Bold="True" ForeColor="Black" Font-Size="X-Small"/>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="X-Small"/>
            </asp:GridView><br />
            <asp:Label ID="LblNoUsers" runat="server" Text="Everyone in the Site Collection User Account Pool has been added as members to this workspace.<br>To add another account, click the &quot;add account&quot; link below.<br><br>" Visible="false" Font-Size="XX-Small"></asp:Label> 
        </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#90B9F1" style="border-top-style: solid; border-width: 1px">
            <table width="100%"> 
                <tr>
                    <td align="left"><asp:Button ID="btnRefresh" runat="server" text="Refresh List" OnClick="btnRefresh_Click" Visible="false"/></td>
                    <td align="right"><asp:Button ID="btnSubmit" runat="server" text="Add Users" OnClick="btnSubmit_Click"/> <asp:Button ID="btnCancel" runat="server" text="Cancel" OnClick="btnCancel_Click"/></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>
