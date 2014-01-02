<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.DeleteFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script language="javascript" type="text/javascript">
        function closeWindow() {
            window.close(); return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <center>
    <table>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gridFragments" AutoGenerateColumns="false" CellPadding="5" runat="server" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="gridFragments_PageIndexChanging" EmptyDataText="No planner fragment exists!">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input id="chkSelect" type="checkbox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="Fragment Name" DataField="Title" />
                    <asp:BoundField HeaderText="Scope" DataField="PlannerType" />
                    <asp:BoundField HeaderText="Created By" DataField="Author" />

                    </Columns>
                    <HeaderStyle BackColor="#df5015" BorderWidth="1" Font-Bold="true" ForeColor="White" BorderColor="Black" />
                </asp:GridView>
            </td>
            <td>
            </td>
        </tr>
        </table>
        <br />

            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <input id="btnClose" type="button" value="Close" onclick="javascript: return closeWindow();" />
        
        </center>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Delete Fragment
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Delete Fragment
</asp:Content>
