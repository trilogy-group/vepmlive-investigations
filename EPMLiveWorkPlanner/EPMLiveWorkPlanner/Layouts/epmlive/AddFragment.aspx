<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.AddFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link rel="stylesheet" type="text/css" href="/_layouts/epmlive/ManageFragments.css" />
    <script type="text/javascript" src="/_layouts/epmlive/javascripts/ManageFragmentsExpand.js"></script>
    <script type="text/javascript" src="/_layouts/epmlive/WorkPlanner.js"></script>
    <script type="text/javascript" src="modal/modal.js"></script>

    <script type="text/javascript">
        $(function () {

            var hdnSelectedRowID = document.getElementById('<%=hdnSelectedRowID.ClientID%>');
            var hdnNewRowID = document.getElementById('<%=hdnNewRowID.ClientID%>');
            var hdnPlanXml = document.getElementById('<%=hdnPlanXml.ClientID%>');

            if (window.parent.Grids.WorkPlannerGrid.FRow != null) {
                hdnSelectedRowID.value = window.parent.Grids.WorkPlannerGrid.FRow.id;
            }

            hdnNewRowID.value = window.parent.Grids.WorkPlannerGrid.GenerateId();
            hdnPlanXml.value = window.parent.Grids.WorkPlannerGrid.GetXmlData();

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

        function validateRadioButtonSelection() {
            var isValid = false;

            if ($("#<%= gridMyFragments.ClientID %> input:checked").length == 1) {
                isValid = true;
            }

            if ($("#<%= gridPublicFragments.ClientID %> input:checked").length == 1) {
                isValid = true;
            }

            if (!isValid) {
                alert("Please select atleast one fragment to import.");
                return false;
            }
            else {
                var btn = confirm("Are you sure you want to import selected fragment?");
                if (btn == true)
                    return true;
                else
                    return false;
            }
        }

        function RadioCheck(rb) {
            var gv = document.getElementById("<%=gridMyFragments.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }

            var gv = document.getElementById("<%=gridPublicFragments.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }

        function closeAddFragmentPopup(message) {
            if (message != null) {
                if (!message.startsWith('Error')) {
                    window.parent.Grids.WorkPlannerGrid.ReloadBody(HideProjectFolder);
                    HideProjectFolder();
                    alert(message);
                }
                else {
                    alert(message);
                }
            }
            window.frameElement.commonModalDialogClose(1, 1);
        }

        function HideProjectFolder() {
            window.parent.Grids.WorkPlannerGrid.SetAttribute(window.parent.Grids.WorkPlannerGrid.GetRowById("0"), "Title", "HtmlPrefix", "", 1, 0);
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
                        AllowPaging="false" AllowSorting="true" ShowHeader="true" SelectedRowStyle-BackColor="Highlight"
                        EmptyDataText="No Records Found!" GridLines="None" BorderWidth="0">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rdoSelect" runat="server" onclick="RadioCheck(this);" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField HeaderText="Title" DataField="Title" ItemStyle-Width="90%" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField HeaderText="Scope" DataField="FragmentType" Visible="false" ItemStyle-Width="0%" />
                            <asp:BoundField HeaderText="Created By" DataField="Author" Visible="false" ItemStyle-Width="0%" />

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
                            <asp:TemplateField ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:RadioButton ID="rdoSelect" runat="server" onclick="RadioCheck(this);" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Title" DataField="Title" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="90%" />
                            <asp:BoundField HeaderText="Scope" DataField="FragmentType" Visible="false" ItemStyle-Width="0%" />
                            <asp:BoundField HeaderText="Created By" DataField="Author" Visible="false" ItemStyle-Width="0%" />
                        </Columns>
                        <HeaderStyle BackColor="#0090CA" Font-Bold="true" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <br />
    <div class="Buttons">
        <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click" OnClientClick="javascript: return validateRadioButtonSelection();" />
        <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="javascript:return closeAddFragmentPopup();" />
    </div>

    <asp:HiddenField ID="hdnSelectedRowID" runat="server" />
    <asp:HiddenField ID="hdnNewRowID" runat="server" />
    <asp:HiddenField ID="hdnPlanXml" runat="server" />

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Insert Fragment
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Insert Fragment
</asp:Content>
