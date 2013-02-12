<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.Manage" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <script src="../DHTML/dhtmlxajax.js" type="text/javascript"></script>

    <script language="javascript">

        function Del(id) {

            if (confirm('Are you sure you want to delete that Applicaton?')) 
            {

                var result = dhtmlxAjax.postSync("proxy.aspx", "Action=DeleteApp&ID=" + id);

                var resp = eval("({" + result.xmlDoc.responseText + "})");

                if (resp.Status != "Success") {
                    alert(resp.Status + ": " + resp.Message);
                }
                else {
                    location.href = "manage.aspx";
                }

            }
        }

        function Edit(id)
        {

            var url = "<%=sWebUrl %>/lists/installed%20applications/editform.aspx?isdlg=1&ID=" + id;

            var options = { url: url, width: 700, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.UI.ModalDialog.RefreshPage(dialogResult) } };

            SP.UI.ModalDialog.showModalDialog(options);

        }

        function NewApplication(id) {

            var url = "<%=sWebUrl %>/_layouts/epmlive/applications/addcommunity.aspx";

            var options = { url: url, width: 600, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.UI.ModalDialog.RefreshPage(dialogResult) } };

            SP.UI.ModalDialog.showModalDialog(options);

        }

        function EditQL(id) {

            var url = "<%=sWebUrl %>/_layouts/epmlive/customquiklnch.aspx?isdlg=1&AppID=" + id;

            var options = { url: url, width: 800, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.UI.ModalDialog.RefreshPage(dialogResult) } };

            SP.UI.ModalDialog.showModalDialog(options);

        }

        function EditTN(id) {

            var url = "<%=sWebUrl %>/_layouts/epmlive/customtopnav.aspx?isdlg=1&AppID=" + id;

            var options = { url: url, width: 800, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.UI.ModalDialog.RefreshPage(dialogResult) } };

            SP.UI.ModalDialog.showModalDialog(options);

        }

        function ManageApps(id) {

            var url = "<%=sWebUrl %>/_layouts/epmlive/applications/ManageApps.aspx?isdlg=1&AppID=" + id;

            var options = { url: url, width: 800, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.UI.ModalDialog.RefreshPage(dialogResult) } };

            SP.UI.ModalDialog.showModalDialog(options);

        }

    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView_RowDataBound"  OnRowCommand="GridView_RowCommand" CellPadding="6">
                    <Columns>
                        <asp:BoundField DataField="Icon" HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="80" ItemStyle-Wrap="false"/>
                        <asp:BoundField DataField="Title" HeaderText="Community" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="100%"/>
                        <asp:BoundField DataField="Default" HeaderText="Default" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="80"/>
                        <asp:BoundField DataField="Visible" HeaderText="Visible" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="80"/>
                        <asp:TemplateField HeaderText="Action" ItemStyle-VerticalAlign="top" ItemStyle-Wrap="false">
                            <ItemTemplate>
                    
                                <asp:LinkButton ID="LinkButton2" 
                                    CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Edit" runat="server" OnClientClick='<%# EditButton(Eval("ID")) %>'>
                                    Edit</asp:LinkButton><br />

                                <asp:LinkButton ID="LinkButton3" 
                                    CommandArgument='<%# Eval("ID") %>'
                                    CommandName="QL" runat="server" OnClientClick='<%# QLButton(Eval("ID")) %>'>
                                    QuickLaunch</asp:LinkButton><br />

                                <asp:LinkButton ID="LinkButton4" 
                                    CommandArgument='<%# Eval("ID") %>'
                                    CommandName="TN" runat="server" OnClientClick='<%# TNButton(Eval("ID")) %>'>
                                    TopNav</asp:LinkButton><br />

                                

                                <asp:LinkButton ID="LinkButton1" 
                                    CommandArgument='<%# Eval("ID") %>'
                                    CommandName="Del" runat="server" OnClientClick='<%# DelButton(Eval("ID")) %>'>
                                    Delete</asp:LinkButton><br />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="White" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif" Font-Size="13px" BorderStyle="None" ForeColor="#333333" CssClass="itemidborder" />
                    <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left" Font-Size="13px"  CssClass="itemidborder" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif"/>
                </asp:GridView>
            </td>
        </tr>
        <TR>
            <TD style="PADDING-BOTTOM: 1px" class=ms-addnew><SPAN style="POSITION: relative; WIDTH: 10px; DISPLAY: inline-block; HEIGHT: 10px; OVERFLOW: hidden" class=s4-clust><IMG style="POSITION: absolute; TOP: -128px !important; LEFT: 0px !important" alt="" src="/_layouts/images/fgimg.png"></SPAN>&nbsp;<A id=A3 class=ms-addnew onclick="NewApplication();" href="#" target=_self>Create Community</A></TD>
        </TR>
        <TR>
            <TD class=ms-partline colSpan=2><IMG alt="" src="/_layouts/images/blank.gif" width=1 height=1></TD>
        </TR>

    </table>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
My Communities
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Communities
</asp:Content>
