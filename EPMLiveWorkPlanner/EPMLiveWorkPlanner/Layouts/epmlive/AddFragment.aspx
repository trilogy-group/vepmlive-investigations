<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.AddFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script language="javascript" type="text/javascript">
        function closeAddFragmentPopup() {
            window.frameElement.commonModalDialogClose(1, 1);
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <center>
    <table>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblFragmentName" Text="Fragment Name: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFragments" runat="server"></asp:DropDownList>
            </td>
        </tr>
    </table>

    <br />

    <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click" />
    <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="javascript:return closeAddFragmentPopup();" />

    </center>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Add Fragment
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Add Fragment
</asp:Content>
