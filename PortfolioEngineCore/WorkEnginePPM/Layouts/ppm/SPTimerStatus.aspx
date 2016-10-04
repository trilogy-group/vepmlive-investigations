<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SPTimerStatus.aspx.cs" Inherits="WorkEnginePPM.SPTimerStatus" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
	<link id="pageStyles" href="styles/page.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table width="100%">
        <tr id="idWorkspaceArea">
	        <td style="width:100%; vertical-align:top;">
            <div>
                <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                <asp:Panel runat="server" ID="pnlMain">
                    <table width="100%" cellspacing="0">
                        <!--<tr>
                            <td width="450" class="controlcell">
                                <b>Connected URL</b><br />
                            </td>
                            <td class="controlcell">
                        
                                <asp:Label ID="lblUrl" runat="server"></asp:Label>
                        
                            </td>
                        </tr>-->
                        <tr>
                            <td width="450" class="controlcell">
                                <b>Settings</b><br />
                                Select the scheduled time you would like the synchronization process to run.
                            </td>
                            <td class="controlcell">
                                <asp:DropDownList ID="ddlTime" runat="server">
                                    <asp:ListItem Enabled ="true" Selected ="true" Value ="-1" Text ="Disabled"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="0" Text ="12:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="1" Text ="1:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="2" Text ="2:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="3" Text ="3:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="4" Text ="4:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="5" Text ="5:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="6" Text ="6:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="7" Text ="7:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="8" Text ="8:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="9" Text ="9:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="10" Text ="10:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="11" Text ="11:00 AM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="12" Text ="12:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="13" Text ="1:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="14" Text ="2:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="15" Text ="3:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="16" Text ="4:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="17" Text ="5:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="18" Text ="6:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="19" Text ="7:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="20" Text ="8:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="21" Text ="9:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="22" Text ="10:00 PM"></asp:ListItem>
                                    <asp:ListItem Enabled ="true" Selected ="false" Value ="23" Text ="11:00 PM"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
<%--                            <td width="450" class="controlcell">
                                <b>Status</b><br />
                                &nbsp;&nbsp;<a href="SPTimerStatus.aspx">Refresh</a>
                        
                            </td>--%>
                            <td class="controlcell">
                                Status:<br />
                                    &nbsp;&nbsp;<asp:Label ID="lblStatus" runat="server" ></asp:Label><br />
                                    <br />
                                Last Run:<br />
                                    &nbsp;&nbsp;<asp:Label ID="lblLastRun" runat="server" ></asp:Label><br />
                                    <br />
                                Last Run Result:<br />
                                    &nbsp;&nbsp;<asp:Label ID="lblLastRunResult" runat="server" ></asp:Label><br />
                                    <br />
                                Log:<br />
                                    &nbsp;&nbsp;<a href="SPViewLog.aspx">View Log</a>
                                    <br />
                            </td>
                        </tr>
                        <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnRunNow" runat="server" Text="Run Synch Now" 
                                CssClass="button" onclick="btnRunNow_Click"/>&nbsp;
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" 
                                onclick="btnSave_Click"/>&nbsp;
                        </td>
                    </tr>
                    </table>
                </asp:Panel>
                <!--<asp:Panel runat="server" ID="pnlNoUrl">
                    The Integration URL has not been set. <a href="SPIntegration.aspx">Click here</a> to set.
                </asp:Panel>-->
            </div>
            </td>
        </tr>
    </table></asp:Content>

	<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Timer Status
    </asp:Content>

    <asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Timer Status
    </asp:Content>