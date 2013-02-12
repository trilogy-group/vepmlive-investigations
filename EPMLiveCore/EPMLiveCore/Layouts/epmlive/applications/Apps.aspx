<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apps.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.Apps" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

<script language="javascript">
    function Install(id) {
        var url = "installfromstore.aspx?isdlg=1&appID=" + id;

        location.href = url;
    }
</script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

   <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView_RowDataBound" CellPadding="6">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="100%" ItemStyle-Wrap="false" ItemStyle-CssClass="itemtd"/>
            <asp:TemplateField HeaderText="Action" ItemStyle-VerticalAlign="top" ItemStyle-Wrap="false" ItemStyle-Width="80">
                <ItemTemplate>
                    
                    <asp:LinkButton ID="LinkButton2" 
                        CommandArgument='<%# Eval("ID") %>'
                        CommandName="Edit" runat="server" OnClientClick='<%# InstallButton(Eval("ID")) %>'>
                        Install</asp:LinkButton><br />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="White" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif" Font-Size="13px" BorderStyle="None" ForeColor="#333333" CssClass="itemidborder" />
        <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left" Font-Size="13px"  CssClass="itemidborder" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif"/>
    </asp:GridView>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
