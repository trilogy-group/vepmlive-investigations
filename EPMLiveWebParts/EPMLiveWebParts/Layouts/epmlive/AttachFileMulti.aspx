<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttachFileMulti.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.AttachFileMulti" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <style type="text/css">
        .errorLabel {
            color: red;
        }
    </style>
    <script type="text/javascript">
        function closePopup(returnValue) {
            if (returnValue == 1)
                SP.SOD.execute('SP.UI.dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', 1, '');
            else
                SP.SOD.execute('SP.UI.dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', 0, '');
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:FileUpload ID="fileUploadControl" runat="server" multiple />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" CssClass="errorLabel" EnableViewState="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_click" />
                    &nbsp;
                    <input id="btnCancel" type="button" value="Cancel" onclick="closePopup(0);" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Attach File(s)
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Attach File(s)
</asp:Content>
