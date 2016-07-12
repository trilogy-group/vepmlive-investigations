<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstallDataSyncEvents.aspx.cs" Inherits="WorkEnginePPM.Layouts.ppm.Admin.InstallDataSyncEvents" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Button ID="InstallButton" runat="server" Text="Add Events" OnClick="InstallButtonOnClick" />
    <asp:Button ID="UnInstallButton" runat="server" Text="Remove Events" OnClick="UnInstallButtonOnClick" />
    <asp:Button ID="SyncListsButton" runat="server" Text="Sync Lists" OnClick="SyncListsButtonOnClick" />
    <hr/>
    <asp:Panel ID="DataSyncPanel" Visible="False" runat="server">
        <div><b>Data Sync event installer log:</b></div>
        <pre><asp:Literal ID="DataSyncLog" runat="server"></asp:Literal></pre>
    </asp:Panel>
    <asp:Panel ID="ResourceManagementPanel" Visible="False" runat="server">
        <div><b>Resource Management event installer log:</b></div>
        <pre><asp:Literal ID="ResourceManagementLog" runat="server"></asp:Literal></pre>
    </asp:Panel>
    <asp:Panel ID="ListSyncPanel" Visible="False" runat="server">
        <div><b>Sync List log:</b></div>
        <pre><asp:Literal ID="SyncListLog" runat="server"></asp:Literal></pre>
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Install Data Sync Events
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Install Data Sync Events
</asp:Content>