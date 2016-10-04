<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveFragment.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.SaveFragment" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <script type="text/javascript">

        $(function () {
            var xDataXml = window.parent.Grids.WorkPlannerGrid.GetXmlData();
            var hdnTaskFragmentXml = document.getElementById('<%=hdnTaskFragmentXml.ClientID%>');
            hdnTaskFragmentXml.value = xDataXml;
        });

        function closeSaveFragmentPopup(message) {
            if (message != null) {
                window.frameElement.commonModalDialogClose(1, message);
            }
            else {
                window.frameElement.commonModalDialogClose(0, 1);
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowSummary="false"></asp:ValidationSummary>
    <table width="100%">
        <tr>
            <td style="width: 100px">
                <asp:Label runat="server" ID="lblFragmentName" Text="Title: "></asp:Label>
            </td>
            <td style="width: 200px">
                <asp:TextBox runat="server" ID="txtFragmentName" Text="" TabIndex="0" Width="200px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="fragmentNameValidate" runat="server" Display="Dynamic" ErrorMessage="Please enter fragment name" ForeColor="Red" ControlToValidate="txtFragmentName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblDescription" Text="Description: "></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDescription" Text="" Rows="3" TextMode="MultiLine" Width="200px" MaxLength="500"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblScope" Text="Private: "></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkPrivate" runat="server" Checked="true" />
            </td>
        </tr>
        <tr align="right">
            <td></td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="javascript:return closeSaveFragmentPopup();" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnTaskFragmentXml" runat="server" />
    <%-- <div id="divIFLoading">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../images/GEARS_ANv4.GIF" alt="Inserting Fragment..." style="vertical-align: middle;" /><br />
                </td>
            </tr>
        </table>
    </div>--%>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Save Fragment
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Save Fragment
</asp:Content>
