<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addmember.aspx.cs" Inherits="EPMLiveAccountManagement.addmember" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="Add Site Members" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Add Site Members
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
<asp:Panel ID="Panel4" runat="server" Visible="true">
    The users in the list below are users in the User Accounts Pool for this Site Collection that have not already been given access to this site.  To add users to your site, select their names and choose their security group in the list below and then click the Submit button.
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
<tablE border="0" cellpadding="5" cellspacing="0" style="border:  1px solid #303030" align="center">
    <tr>
        <td bgcolor="#D6E8FF">
            <asp:GridView ID="gvSelect" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" 
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="top">
                    <ItemTemplate>
                        <asp:CheckBox id="chkChange" runat="server"></asp:CheckBox>
                     </ItemTemplate>
                      </asp:TemplateField>
                    <asp:BoundField DataField="name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                    <asp:BoundField DataField="email" HeaderText="E-Mail" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                    <asp:TemplateField ItemStyle-VerticalAlign="top" HeaderText="Group" ItemStyle-Width="200">
                     <ItemTemplate>
                        <div id='<%# Eval("email") %>' style="display:none;"><asp:DropDownList ID="ddlGroup" runat="server" Visible="true" ></asp:DropDownList></div>
                     </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="username" HeaderText="E-Mail" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top"/>
                </Columns>
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="X-Small"/>
                <EditRowStyle BackColor="#999999" Font-Size="X-Small" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" Font-Size="X-Small"/>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Size="X-Small"/>
                <HeaderStyle BackColor="#c9c9c9" Font-Bold="True" ForeColor="Black" Font-Size="X-Small"/>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="X-Small"/>
            </asp:GridView><br />
            <asp:Label ID="lblNoUsers" runat="server" Text="Everyone in the Site Collection User Account Pool has been added as members to this workspace.<br>To add another account, click the &quot;add account&quot; link below.<br><br>" Visible="false" Font-Size="XX-Small"></asp:Label> 
            <asp:Label id="hlLink" runat="server" Text="Add Account" ForeColor="000000" Font-Size="XX-Small" Font-Underline="true"/>
        </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#90B9F1" style="border-top-style: solid; border-width: 1px">
            <table width="100%"> 
                <tr>
                    <td align="left"><asp:Button ID="btnRefresh" runat="server" text="Refresh List" OnClick="btnRefresh_Click"/></td>
                    <td align="right"><asp:Button ID="btnSubmit" runat="server" text="Submit" OnClick="btnSubmit_Click"/> <asp:Button ID="btnCancel" runat="server" text="Cancel" OnClick="btnCancel_Click"/></td>
                </tr>
            </table>
        </td>
    </tr>
</tablE>
</asp:Content>