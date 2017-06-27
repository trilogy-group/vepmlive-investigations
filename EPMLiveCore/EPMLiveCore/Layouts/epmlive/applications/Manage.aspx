<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.Manage" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:content id="PageHead" contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">
    <script src="../DHTML/xgrid/dhtmlxcommon.js" type="text/javascript"></script>
    <script type="text/javascript">

       
        function Del(id) {
            if (confirm('Are you sure you want to delete that Applicaton?')) {

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

        function Edit(id) {
            var url = "<%=sWebUrl %>/lists/installed%20applications/editform.aspx?isdlg=1&ID=" + id;

            var options = { url: url, width: 700, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult); } };

            SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }

        function NewApplication(id) {

            var url = "<%=sWebUrl %>/_layouts/epmlive/applications/addcommunity.aspx";

            var options = { url: url, width: 600, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult); } };

            SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }

        function EditQL(id) {

            var url = "<%=sWebUrl %>/_layouts/epmlive/customquiklnch.aspx?isdlg=1&AppID=" + id;

            var options = { url: url, width: 800, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult); } };

            SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }

        function EditTN(id) {

            var url = "<%=sWebUrl %>/_layouts/epmlive/customtopnav.aspx?isdlg=1&AppID=" + id;

            var options = { url: url, width: 800, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult); } };

            SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }

        function ManageApps(id) {

            var url = "<%=sWebUrl %>/_layouts/epmlive/applications/ManageApps.aspx?isdlg=1&AppID=" + id;

            var options = { url: url, width: 800, showClose: true, dialogReturnValueCallback: function (dialogResult) { SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.RefreshPage', dialogResult); } };

            SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }

    </script>

</asp:content>

<asp:content id="Main" contentplaceholderid="PlaceHolderMain" runat="server">

    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="GridView1" AllowSorting="false" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView_RowDataBound" OnRowCommand="GridView_RowCommand" OnPreRender="GridView_PreRender" CellPadding="6">
                    <Columns>
                        <asp:BoundField DataField="Icon" HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="80" ItemStyle-Wrap="false" />
                        <asp:BoundField DataField="Title" HeaderText="Community" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="100%" />
                         <asp:TemplateField HeaderText="Position" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="top" HeaderStyle-Width="45px">
                                <ItemTemplate>
                                     <asp:DropDownList OnSelectedIndexChanged="ddlOrder_SelectedIndexChanged" AutoPostBack="true" ID="ddlOrder" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField="Visible" HeaderText="Visible" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="top" HtmlEncode="false" ItemStyle-Width="80" />
                        <asp:TemplateField HeaderText="Action" ItemStyle-VerticalAlign="top" ItemStyle-Wrap="false">
                            <ItemTemplate>

                                <asp:LinkButton ID="LinkButton2" 
                                    CommandArgument='<%# Eval("ID") %>'
                                    CommandName="EditRow" runat="server">
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

                                <input type="hidden" class="sortOrder" value='<%# Eval("QuickLaunchOrder") %>' />
                                <input type="hidden" class="itemId" value='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    <RowStyle BackColor="White" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif" Font-Size="13px" BorderStyle="None" ForeColor="#333333" CssClass="itemidborder" />
                    <HeaderStyle Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left" Font-Size="13px" CssClass="itemidborder" Font-Names="Helvetica Neue, Helvetica, Arial, sans-serif" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 1px; font-size: small !important;" class="ms-addnew"><span style="position: relative; width: 10px; display: inline-block; height: 10px; overflow: hidden" class="s4-clust">
                <img style="position: absolute; top: -128px !important; left: 0px !important" alt="" src="/_layouts/images/fgimg.png" />
            </span>&nbsp;<a id="A3" class="ms-addnew" onclick="NewApplication();" href="#" target="_self">Create Community</a>

            &nbsp; &nbsp;
                <img style="position: relative;height: 15px; padding-top: 10px;" alt="" src="/_layouts/images/save32x32.png" />
                            <asp:LinkButton Text="Save Communities Order" runat="server" class="ms-addnew" ID="lnkSaveOrder" OnClick="lnkSaveOrder_OnClicked"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="ms-partline" colspan="2">
                <img alt="" src="/_layouts/images/blank.gif" width="1" height="1" /></td>
        </tr>

    </table>

</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
    My Communities
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
    My Communities
</asp:content>