<%@ Assembly Name="EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ManageFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/_layouts/epmlive/ManageFragments.css" />
    <script type="text/javascript" src="/_layouts/epmlive/javascripts/ManageFragmentsExpand.js"></script>
    <script type="text/javascript">

        $(function () {
            $("#fragment h3.expand").toggler();
            $("#fragment").expandAll({
                trigger: "h3.expand",
                ref: "h3.expand",
                showMethod: "slideDown",
                hideMethod: "slideUp"
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
                if (btn == true)
                    return true;
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

    <div id="wrapper">
        <div id="content">
            <div id="fragment" class="demo">
                <h3 class="expand">My Fragments</h3>
                <div class="collapse shown">
                    <asp:GridView ID="gridMyFragments" Width="100%" AutoGenerateColumns="false" CellPadding="5" runat="server"
                        AllowPaging="false" AllowSorting="true" ShowHeader="true"
                        EmptyDataText="No Records Found!" GridLines="None" BorderWidth="0">
                        <Columns>
                            <asp:TemplateField>
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
                            <asp:BoundField HeaderText="Scope" DataField="FragmentType" Visible="false" />
                            <asp:BoundField HeaderText="Created By" DataField="Author" Visible="false" />

                        </Columns>
                        <HeaderStyle BackColor="#0090CA" Font-Bold="true" ForeColor="White" />
                    </asp:GridView>
                </div>
                <br />
                <h3 class="expand">Public Fragments</h3>
                <div class="collapse">
                    <asp:GridView ID="gridPublicFragments" Width="100%" AutoGenerateColumns="false" CellPadding="50" runat="server"
                        AllowPaging="false" AllowSorting="true" ShowHeader="true"
                        EmptyDataText="No Records Found!" GridLines="None" BorderWidth="0">
                        <Columns>
                            <asp:TemplateField>
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
                            <asp:BoundField HeaderText="Scope" DataField="FragmentType" Visible="false" />
                            <asp:BoundField HeaderText="Created By" DataField="Author" />
                        </Columns>
                        <HeaderStyle BackColor="#0090CA" Font-Bold="true" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
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
