<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pri_ComponentsForm.aspx.cs" Inherits="WorkEnginePPM.Pri_ComponentsForm" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script type="text/javascript">
    function clientBtnClose_Click() {
        if (SP.UI.DialogResult)
            SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel, '');
    }
</script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table width="100%">
        <tr id="idWorkspaceArea">
	        <td>
                <table style="width:100%; vertical-align:top;">
                    <tr style="width:100%; vertical-align:top;">
                     <td style="width:50%; text-align:left; vertical-align:middle; background-color:White; ">
                        <asp:Label ID="lblMode" runat="server" Text="Mode" Font-Bold="true"></asp:Label>
                     </td>
                     <td style="width:50%; text-align:right; vertical-align:bottom; background-color:White; ">
                        <asp:Button id="btnSave" style="vertical-align:bottom;" runat="server" Text="Save" CssClass="button" OnClick="btnSave_Click" />
                        <asp:Button id="btnClose" style="vertical-align:bottom;" runat="server" Text="Close" CssClass="button" OnClientClick="clientBtnClose_Click()" />
                     </td>
                    </tr>
                </table>
	        </td>
        </tr>
        <tr>
            <td style="width:100%; vertical-align:top;">
            <div>
                <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                <asp:Panel ID="pnlMain" runat="server" Visible="true">
                <table width="100%" cellspacing="0" class="controlcell">
                    <tr>
                        <td style="height:1px;" width="250" class="topcell"></td>
                        <td style="height:1px;" class="topcell"></td>
                    </tr>
                    <tr>
                        <td width="250" class="descriptioncell" colspan = "2">
                            Select the components of the Prioritization Scenario(s) from the available Custom Fields
                        </td>
                    </tr>
                    <tr>
                        <td class="controlcell">
                            <table cellspacing="0" cellpadding="5">
                                <tr>
                                    <td><asp:ListBox ID="lstFields" runat="server" Height="150" Width="160" 
                                            SelectionMode="Multiple"></asp:ListBox> </td>
                                    <td align="center">
                                        <asp:Button ID="AddButton" runat="server" Text="Add >" onclick="AddButton_Click" CssClass="button"/><br /><br />
                                        <asp:Button ID="RemoveButton" runat="server" Text="< Remove"  CssClass="button" onclick="RemoveButton_Click" />
                                    </td>
                                    <td><asp:ListBox ID="lstComponents" runat="server" Height="150" Width="160" 
                                            SelectionMode="Multiple"></asp:ListBox> </td>
                                    <td align="center">
                                        <asp:Button ID="UpButton" runat="server" Text="Move Up" onclick="UpButton_Click" CssClass="button"/><br /><br />
                                        <asp:Button ID="DownButton" runat="server" Text="Move Down"  CssClass="button" onclick="DownButton_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </div>
            </td>
	    </tr>
	</table>


</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Prioritization Components
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Prioritization Components
</asp:Content>
