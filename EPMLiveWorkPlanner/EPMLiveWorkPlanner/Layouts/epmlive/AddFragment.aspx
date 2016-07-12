<%@ Assembly Name="EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.AddFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

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

            $('.row-select').on('click', 'tbody tr', function (event) {
                $(".row-select").find("tr.highlight").removeClass('highlight');
                $(".row-select").find("input:radio:checked").each(function () {
                    $(this).prop('checked', false);
                });
                $(this).addClass('highlight');
                $(this).find("#rdoSelect").prop('checked', true);
            });
        });

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
                //var btn = confirm("Are you sure you want to import selected fragment?");
                //if (btn == true) {
                    $("#divIFLoading").show();
                    return true;
                //}
                //else
                //    return false;
            }
        }

        function closeAddFragmentPopup(message) {
            if (message != null) {
                if (!message.startsWith('Error')) {
                    window.parent.Grids.WorkPlannerGrid.ReloadBody(HideProjectFolder);
                    HideProjectFolder();
                    window.frameElement.commonModalDialogClose(1, message);
                }
                else {
                    window.frameElement.commonModalDialogClose(-1, message);
                }
            }
            else
            {
                window.frameElement.commonModalDialogClose(0, 1);
            }
        }

        function HideProjectFolder() {
            window.parent.Grids.WorkPlannerGrid.SetAttribute(window.parent.Grids.WorkPlannerGrid.GetRowById("0"), "Title", "HtmlPrefix", "", 1, 0);
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div class="modal-body">
        <input type="text" placeholder="Search..." style="border: none;" id="Text1" onkeyup="Filter(this,1);" class="form-control" />
        <div class="manageFragmentContainer">
            <asp:GridView ID="gridMyFragments" AutoGenerateColumns="false" runat="server" Width="100%"
                AllowPaging="false" BackColor="White" GridLines="None" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3"
                CssClass="myfragments row-select" ClientIDMode="Static" ShowHeader="false">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="6%">
                        <ItemTemplate>
                            <asp:RadioButton ID="rdoSelect" CssClass="hdnRadio" runat="server" ClientIDMode="Static" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Title" DataField="Title" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblScope" runat="server" Text="(private)" ForeColor="#a8a8a8" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Created By" DataField="Author" Visible="false" ItemStyle-Width="0%" />
                </Columns>
            </asp:GridView>
            <asp:GridView ID="gridPublicFragments" AutoGenerateColumns="false" runat="server" Width="100%"
                AllowPaging="false" BackColor="White" GridLines="None" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="0px" CellPadding="3"
                CaptionAlign="Left" CssClass="myfragments row-select" ClientIDMode="Static" ShowHeader="false">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="6%">
                        <ItemTemplate>
                            <asp:RadioButton ID="rdoSelect" runat="server" CssClass="hdnRadio" ClientIDMode="Static" />
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
            </asp:GridView>

        </div>
    </div>
    <div id="divIFLoading" style="left: 31%; top: 50%; position: absolute; flex-align: center;">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../images/GEARS_ANv4.GIF" alt="Inserting Fragment..." style="vertical-align: middle;" /><br />
                    <h4 class="ms-standardheader">Inserting Fragment...</h4>
                    <br />
                </td>
            </tr>
        </table>
    </div>

    <div class="modal-footer Buttons">
        <asp:Button ID="btnClose" runat="server" Text="Cancel" OnClientClick="javascript:return closeAddFragmentPopup();" />
        <asp:Button ID="btnImport" runat="server" Text="Insert" OnClick="btnImport_Click" OnClientClick="javascript:return validateRadioButtonSelection();" />
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
