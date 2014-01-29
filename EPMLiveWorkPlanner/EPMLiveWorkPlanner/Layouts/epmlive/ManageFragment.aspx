<%@ Assembly Name="EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ManageFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <style type="text/css">
        .manageFragmentContainer {
            width: 98%;
            border: 1px solid black;
        }

            .manageFragmentContainer .header {
                background-color: #0090CA;
                color: White;
                cursor: pointer;
                font-size: 12px;
                font-weight: bold;
                padding: 5px;
            }

            .manageFragmentContainer .content {
                display: block;
                width: 100%;
            }

        #divIFLoading {
            position: fixed;
            top: 50%;
            left: 50%;
            margin-top: -30px;
            margin-left: -80px;
            border: 2px solid black;
            border-radius: 5px;
            background-color: #ffffff;
            z-index: 11;
            font-size: 12px;
            display: none;
        }

        .Buttons {
            bottom: 5px;
            position: fixed;
            text-align: right;
            width: 98%;
        }
    </style>

    <script type="text/javascript">

        $(function () {
            $(".manageFragmentContainer .header").click(function () {
                $header = $(this);
                $content = $header.next();
                $content.slideToggle(500, function () { });
            });
        });

        function Filter(Obj) {
            var searchString = Obj.value.toUpperCase();

            $("#<%=gridMyFragments.ClientID%> tr:has(td)").each(function () {
                var gridRowVal = $(this).find("td:eq(1)").text().toUpperCase();
                if (gridRowVal.indexOf(searchString) != -1) {
                    $(this).show();
                }
                else {
                    $(this).hide();
                }
            });

            $("#<%=gridPublicFragments.ClientID%> tr:has(td)").each(function () {
                var gridRowVal = $(this).find("td:eq(1)").text().toUpperCase();
                if (gridRowVal.indexOf(searchString) != -1) {
                    $(this).show();
                }
                else {
                    $(this).hide();
                }
            });
        }

        function closeManageFragmentPopup(message) {
            if (message != null) {
                alert(message);
            }
            window.frameElement.commonModalDialogClose(1, 1);
        }

        function validateCheckBoxes() {
            var isValid = false;

            if ($("#<%= gridMyFragments.ClientID %> input:checked").length == 1) {
                isValid = true;
            }

            if ($("#<%= gridPublicFragments.ClientID %> input:checked").length == 1) {
                isValid = true;
            }

            if (!isValid) {
                alert("Please select atleast one fragment to delete.");
                return false;
            }
            else {
                var btn = confirm("Are you sure you want to delete selected fragment(s)?");
                if (btn == true) {
                    $("#divIFLoading").show();
                    return true;
                }
                else
                    return false;
            }
        }

    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <div class="SearchDiv">
        <asp:Label ID="lblSearch" runat="server" Text="Title: " />
        <input type="text" onkeyup="Filter(this);" id="Text1" class="SmallTextBox" runat="server" />
    </div>

    <br />
    <div class="manageFragmentContainer">
        <div class="header">
            <span>My Fragments</span>
        </div>
        <div class="content">
            <asp:GridView ID="gridMyFragments" AutoGenerateColumns="false" runat="server" Width="100%"
                AllowPaging="false" BackColor="White" GridLines="None" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3"
                EmptyDataText="No Records Found!">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="6%">
                        <ItemTemplate>
                            <input id="chkSelect" type="checkbox" runat="server" class="CheckBoxStyle" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Title" DataField="Title" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderText="Scope" DataField="FragmentType" Visible="false" ItemStyle-Width="0%" />
                    <asp:BoundField HeaderText="Created By" DataField="Author" Visible="false" ItemStyle-Width="0%" />

                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#dcdcdc" HorizontalAlign="Left" Font-Bold="True" ForeColor="Black" Font-Size="12px" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000000" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#dcdcdc" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
    </div>
    <br />
    <div class="manageFragmentContainer">
        <div class="header">
            <span>Public Fragments</span>
        </div>
        <div class="content" style="display: none">
            <asp:GridView ID="gridPublicFragments" AutoGenerateColumns="false" runat="server" Width="100%"
                AllowPaging="false" BackColor="White" GridLines="None" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3"
                EmptyDataText="No Records Found!" CaptionAlign="Left">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="6%">
                        <ItemTemplate>
                            <input id="chkSelect" type="checkbox" runat="server" class="CheckBoxStyle" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Title" DataField="Title" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField HeaderText="Scope" DataField="FragmentType" Visible="false" ItemStyle-Width="0%" />
                    <asp:BoundField HeaderText="Created By" DataField="Author" ItemStyle-Width="0%" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#dcdcdc" HorizontalAlign="Left" Font-Bold="True" ForeColor="Black" Font-Size="12px" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000000" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#dcdcdc" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
    </div>

    <div id="divIFLoading">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../images/GEARS_ANv4.GIF" alt="Inserting Fragment..." style="vertical-align: middle;" /><br />
                    <h3 class="ms-standardheader" id="dlgNormalText">Deleting Fragment(s)...</h3>
                </td>
            </tr>

        </table>
    </div>

    <br />

    <div class="Buttons">
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
