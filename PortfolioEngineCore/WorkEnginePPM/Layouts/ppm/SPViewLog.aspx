<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SPViewLog.aspx.cs" Inherits="WorkEnginePPM.SPViewLog" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
	<link id="pageStyles" href="styles/page.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table width="100%">
        <tr id="idWorkspaceArea">
	        <td style="width:100%; vertical-align:top;">
            <div>
                <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                <asp:Panel runat="server" ID="pnlMain" CssClass="controlcell">
                    <b>Status:</b><br />
                        &nbsp;&nbsp;<asp:Label ID="lblStatus" runat="server" ></asp:Label><br />
                        <br />
                    <b>Last Run:</b><br />
                        &nbsp;&nbsp;<asp:Label ID="lblLastRun" runat="server" ></asp:Label><br />
                        <br />
                    <b>Last Run Result:</b><br />
                        &nbsp;&nbsp;<asp:Label ID="lblLastRunResult" runat="server" ></asp:Label><br />
                        <br />
                    <b>Log:</b><br />
                        <asp:Label ID="lblLog" runat="server" ></asp:Label><br />
                    
                </asp:Panel>
                <!--<asp:Panel runat="server" ID="pnlNoUrl">
                    The Integration URL has not been set. <a href="SPIntegration.aspx">Click here</a> to set.
                </asp:Panel>-->
            </div>
            </td>
        </tr>
    </table></asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
View Log
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
View Log
</asp:Content>
