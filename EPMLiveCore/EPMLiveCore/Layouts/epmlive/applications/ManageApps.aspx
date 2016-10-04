<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageApps.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.ManageApps" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <script src="../DHTML/xgrid/dhtmlxcommon.js" type="text/javascript"></script>

    <script language="javascript">

        function Uninstall(id) {
            if (confirm('Are you sure you want to Uninstall that Applicaton?')) {
                var surl = "uninstallcheck.aspx?isdlg=1&appID=" + id;

                var options = { url: surl, width: 700, showClose: false, dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult) } };

                SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);


            }
        }

        function InstallApplication() {
            //location.href = "appstore.aspx";

            window.open("http://market.epmlive.com/?Source=<%=sFullWebUrl%>");
        }

        function InstallApplicationTemp() {
            location.href = "apps.aspx";
        }

    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView2_RowDataBound"  CellPadding="6">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Application" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="100%"/>
                        <asp:BoundField DataField="Version" HeaderText="Version" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="80"/>
                        <asp:BoundField DataField="InstallDate" HeaderText="Install Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="80"/>
                        <asp:BoundField DataField="InstalledBy" HeaderText="Installed By" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="250" ItemStyle-Wrap="false"/>

                        <asp:TemplateField HeaderText="Action" ItemStyle-VerticalAlign="top" ItemStyle-Wrap="false">
                            <ItemTemplate>

                                <asp:LinkButton ID="LinkButton5" 
                                    CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Uninstall" runat="server" OnClientClick='<%# UnInstButton(Eval("ID")) %>'>
                                    Uninstall</asp:LinkButton><br />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="White" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif" Font-Size="13px" BorderStyle="None" ForeColor="#333333" CssClass="itemidborder" />
                    <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left" Font-Size="13px"  CssClass="itemidborder" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif"/>
                </asp:GridView>
            
<TABLE id=Hero-WPQ2 border=0 cellSpacing=0 cellPadding=0 width="100%">
    <TBODY>
        <TR>
            <TD style="PADDING-BOTTOM: 1px" class=ms-addnew><SPAN style="POSITION: relative; WIDTH: 10px; DISPLAY: inline-block; HEIGHT: 10px; OVERFLOW: hidden" class=s4-clust><IMG style="POSITION: absolute; TOP: -128px !important; LEFT: 0px !important" alt="" src="/_layouts/images/fgimg.png"></SPAN>&nbsp;<A id=A1 class=ms-addnew onclick="InstallApplication();" href="#" target=_self>Install Application</A></TD>
        </TR>
        <TR>
            <TD><IMG alt="" src="/_layouts/images/blank.gif" width=1 height=5></TD>
        </TR>
    </TBODY>
</TABLE>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
My Applications
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Applications
</asp:Content>
