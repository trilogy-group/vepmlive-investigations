<%@ Assembly Name="EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ManageFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <link href="styles/icomoon-style.css" rel='stylesheet' type='text/css' />
    <link href="styles/fragments.css" rel='stylesheet' type='text/css' type='text/css' rel='stylesheet' />
    <link href='http://www.uplandux.com/styleguide/css/bootstrap.css' type='text/css' rel='stylesheet' />
    <script type="text/javascript" src="javascripts/Fragment.js"></script>
    <script type="text/javascript">


        function closeManageFragmentPopup(message) {
            if (message != null) {
                alert(message);
            }
            window.frameElement.commonModalDialogClose(1, 1);
        }

        function ConfirmationBox(fragment) {
            var result = confirm('Are you sure you want to delete ' + fragment + ' ?');
            if (result) {
                $("#divIFLoading").show();
                return true;
            }
            else {
                return false;
            }
        }

        function refreshControl() {
            $("#divIFLoading").show();
        }

        $(function () {

            $('.row-select').on('click', 'tbody tr', function (event) {
                $(".row-select").find("tr.highlight").removeClass('highlight');
                $(this).addClass('highlight');
            });

        });

    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
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
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="<div class='icon-wrapper'><span class='icon-pencil modal-icon'></span></div>" OnClientClick="javascript:refreshControl()" OnClick="lnkEdit_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="<div style='float:left' class='icon-wrapper'><img src='../images/SAVE.GIF'></div>" OnClientClick="javascript:refreshControl()" OnClick="lnkUpdate_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" Text="<div style='float:left' class='icon-wrapper'><img src='../images/Cancelled.GIF'></div>" OnClientClick="javascript:refreshControl()" OnClick="lnkCancel_Click"></asp:LinkButton>
                        </EditItemTemplate>
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
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="<div class='icon-wrapper'><span class='icon-pencil modal-icon'></span></div>" OnClientClick="javascript:refreshControl()" OnClick="lnkEdit_Click"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="<div style='float:left' class='icon-wrapper'><img src='../images/SAVE.GIF'></div>" OnClientClick="javascript:refreshControl()" OnClick="lnkUpdate_Click"></asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server" Text="<div style='float:left' class='icon-wrapper'><img src='../images/Cancelled.GIF'></div>" OnClientClick="javascript:refreshControl()" OnClick="lnkCancel_Click"></asp:LinkButton>
                        </EditItemTemplate>
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
    <div id="divIFLoading">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../images/GEARS_ANv4.GIF" alt="Deleting Fragment..." style="vertical-align: middle;" /><br />
                </td>
            </tr>

        </table>
    </div>
    <div class="modal-footer Buttons">
        <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="javascript:return closeManageFragmentPopup();" />
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Manage Fragment
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Manage Fragment
</asp:Content>
