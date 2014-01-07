<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ManageFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script type="text/javascript">

        function closeManageFragmentPopup(message) {
            if (message != null) {
                alert(message);
            }
            window.frameElement.commonModalDialogClose(1, 1);
        }

        function validateCheckBoxes() {
            var isValid = false;
            if ($("#<%= gridFragments.ClientID %> input:checked").length == 1) {
                isValid = true;
            }

            if (!isValid) {
                alert("Please select atleast one fragment.");
                return false;
            }
            else {
                var btn = confirm("Are you sure you want to delete selected fragment(s)");
                if (btn == true)
                    return true;
                else
                    return false;
            }
        }

    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table width="100%" align="center">
        <tr>
            <td colspan="2">
                <asp:GridView ID="gridFragments" Width="100%" AutoGenerateColumns="false" CellPadding="5" runat="server"
                    AllowPaging="true" AllowSorting="true" OnPageIndexChanging="gridFragments_PageIndexChanging"
                    EmptyDataText="No planner fragment exists!" GridLines="Both" BorderWidth="1">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input id="chkSelect" type="checkbox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Fragment Name" DataField="Title" />
                        <asp:BoundField HeaderText="Scope" DataField="FragmentType" />
                        <asp:BoundField HeaderText="Created By" DataField="Author" />

                    </Columns>
                    <HeaderStyle BackColor="#0090ca" Font-Bold="true" ForeColor="White" />
                </asp:GridView>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td align="center">
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="javascript: return validateCheckBoxes();" />
                <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="javascript:return closeManageFragmentPopup();" />
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Manage Fragment
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Manage Fragment
</asp:Content>
