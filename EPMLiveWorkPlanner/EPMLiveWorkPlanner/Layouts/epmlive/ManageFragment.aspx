<%@ Assembly Name="EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ManageFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:content id="PageHead" contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript">

        function OpenPopupToEditFragment(itemid) {
            var options = {
                url: "SaveFragment.aspx?ID=" + itemid, height: 200, width: 300, showMaximized: false, dialogReturnValueCallback: function (dialogResult, returnValue) {
                    if (dialogResult == 1) {
                        toastr.options = {
                            "closeButton": false,
                            "debug": false,
                            "positionClass": "toast-top-right",
                            "onclick": null,
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "extendedTimeOut": "1000",
                            "showEasing": "swing",
                            "hideEasing": "linear",
                            "showMethod": "fadeIn",
                            "hideMethod": "fadeOut"
                        };
                        window.parent.toastr.success(returnValue);
                        refreshFragments();
                    }
                }
            };
            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }

        function refreshFragments() {
            location.reload(false);
        }

        function showDeleteToastr(result, message) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "positionClass": "toast-top-right",
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };

            if (result == 1) {
                window.parent.toastr.success(message);
            }
            else if (result == -1) {
                window.parent.toastr.error(message);
            }
        }

        function closeManageFragmentPopup(message) {
            if (message != null) {
                window.frameElement.commonModalDialogClose(1, message);
            }
            else {
                window.frameElement.commonModalDialogClose(0, 1);
            }
        }

        function ConfirmationBox(fragment) {
            var result = confirm('Are you sure you want to delete ' + fragment + ' ?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }

        $(function () {
            $('.row-select').on('click', 'tbody tr', function (event) {
                $(".row-select").find("tr.highlight").removeClass('highlight');
                $(this).addClass('highlight');
            });
        });

    </script>
</asp:content>

<asp:content id="Main" contentplaceholderid="PlaceHolderMain" runat="server">
    <div class="modal-body">
        <input type="text" placeholder="Search..." style="border: none;" id="Text1" onkeyup="Filter(this,0);" class="form-control" />
        <div class="manageFragmentContainer row-select">
            <asp:GridView ID="gridMyFragments" AutoGenerateColumns="false" runat="server" Width="100%"
                AllowPaging="false" BackColor="White" GridLines="None" BorderColor="#eeeeee" BorderStyle="Solid" BorderWidth="0px" CellPadding="3"
                OnRowDataBound="grid_RowDataBound" CssClass="myfragments" ClientIDMode="Static" ShowHeader="false">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblScope" runat="server" Text="(private)" ForeColor="#a8a8a8" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkPrivate" runat="server" Checked="<%#_isPrivate%>" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Created By" DataField="Author" Visible="false" ItemStyle-Width="0%" />
                    <asp:TemplateField ItemStyle-Width="15%">
                        <ItemTemplate>
                                                        <a href="#" onclick="javascript:OpenPopupToEditFragment(<%# Eval("ID") %>);"><div class='icon-wrapper'><span class='icon-pencil modal-icon'></span></div></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkdelete" runat="server" Text="<div class='icon-wrapper'><span class='icon-close-5 modal-icon'></span></div>" OnClick="lnkdelete_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:GridView ID="gridPublicFragments" AutoGenerateColumns="false" runat="server" Width="100%" ShowHeader="false"
                AllowPaging="false" BackColor="White" GridLines="None" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3"
                CaptionAlign="Left" OnRowDataBound="grid_RowDataBound" ClientIDMode="Static" CssClass="myfragments">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblScope" runat="server" Text="" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkPrivate" runat="server" Checked="<%#_isPrivate%>" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Created By" DataField="Author" Visible="false" ItemStyle-Width="0%" />
                    <asp:TemplateField ItemStyle-Width="15%">
                        <ItemTemplate>
                              <a href="#" onclick="javascript:OpenPopupToEditFragment(<%# Eval("ID") %>);"><div class='icon-wrapper'><span class='icon-pencil modal-icon'></span></div></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkdelete" runat="server" Text="<div class='icon-wrapper'><span class='icon-close-5 modal-icon'></span></div>" OnClick="lnkdelete_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <%--<div id="divIFLoading">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../images/GEARS_ANv4.GIF" alt="Deleting Fragment..." style="vertical-align: middle;" /><br />
                </td>
            </tr>

        </table>
    </div>--%>
    <div class="modal-footer Buttons">
        <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="javascript:return closeManageFragmentPopup();" />
    </div>
</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
    Manage Fragments
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
    Manage Fragments
</asp:content>
