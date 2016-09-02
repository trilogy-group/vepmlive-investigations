<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cleanupwarning.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.cleanupwarning" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <p>
                    Warning: This function is used to clean up list report data by completely deleting and readding list information to the database. This process can take a considerable amount of time to complete and should only be done if absolutely necessary.<br /><br />
                    If your intention was to refresh the timesheet, portfolio, and group security information cancel out of this dialog and click 'Refresh Schedule' under the 'Settings' link.
                </p>
            </td>
        </tr>
        <wssuc:ButtonSection id="ButtonSection1" runat="server" ShowStandardCancelButton="false">
            <Template_buttons>
                <asp:Button runat="server" UseSubmitBehavior="false" class="ms-ButtonHeightWidth" Text="Cleanup" OnClientClick=" parent.SP.UI.ModalDialog.commonModalDialogClose(1, 'cleanup'); return false; " />
                <asp:Button runat="server" UseSubmitBehavior="false" class="ms-ButtonHeightWidth" Text="Cancel" OnClientClick=" parent.SP.UI.ModalDialog.commonModalDialogClose(0, 'cancel'); return false; " />
            </Template_buttons>
        </wssuc:ButtonSection>
    </table>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">

</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >

</asp:Content>