<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ManageFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script language="javascript" type="text/javascript">


        function closeManageFragmentPopup() {
            window.frameElement.commonModalDialogClose(1, 1);
        }

        function validateCheckBoxes() {
            var isValid = false;
            var gridView = document.getElementById('<%= gridFragments.ClientID %>');

            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');
                if (inputs != null && (inputs[0] != null || inputs[0] != undefined)) {
                    if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                            isValid = true;
                            alert(isValid);
                        }
                    }
                }
            }

            if (isValid) {
                var btn = confirm("Are you sure you want to delete selected fragment(s)?");
                alert(btn);
                if (btn == true)
                    return true;
                else
                    return false;
            }
            else {
                alert("Please select atleast one fragment.");
                return false;
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div align="center">
        <table align="center">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gridFragments" AutoGenerateColumns="false" CellPadding="5" runat="server" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="gridFragments_PageIndexChanging" EmptyDataText="No planner fragment exists!">
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
                        <HeaderStyle BackColor="#0090ca" BorderWidth="1" Font-Bold="true" ForeColor="White" BorderColor="Black" />
                    </asp:GridView>
                </td>
                <td></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="javascript: return validateCheckBoxes();" />
        <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="javascript:return closeManageFragmentPopup();" />
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Manage Fragment
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Manage Fragment
</asp:Content>
