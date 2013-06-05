<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateGalleryRedirect.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.TemplateGalleryRedirect" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Panel ID="pnlAdmin" runat="server" Visible="false" Width="100%">
        Template Gallery configuration is being configured at another site.<br /><br />
        <asp:HyperLink Text="Click Here" NavigateUrl="" runat="server" ID="hlAdmin"></asp:HyperLink> to go there now.
    </asp:Panel>
    <asp:Panel ID="pnlMain" runat="server" Visible="true" Width="100%">
        The Template Gallery List does not exist at the configuration site level.  The Template Gallery may be missing because it was deleted or your site was upgraded from an earlier version.

        Please visit the EPM Live Knowledge Base for information on how to restore or create your Template Gallery.  <a href="http://kb.epmlive.com">http://kb.epmlive.com</a>
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Template Gallery
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Template Gallery
</asp:Content>
