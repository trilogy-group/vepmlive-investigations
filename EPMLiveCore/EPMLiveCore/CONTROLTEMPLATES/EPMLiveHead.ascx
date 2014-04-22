<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EPMLiveHead.ascx.cs" Inherits="EPMLiveCore.CONTROLTEMPLATES.EPMLiveHead" %>

<!--[if lt IE 9]>
    <link href='/_layouts/15/epmlive/stylesheets/uplandv5.master.min.css?v=<%= EPMLiveVersion %>' rel='stylesheet' type='text/css'>
    <SharePoint:ScriptBlock runat="server">
        (function() {
            WebFontConfig = {
                custom: {
                    families: ['Open Sans Light', 'Open Sans Regular', 'Open Sans Semi Bold'],
                    urls: ['/_layouts/15/epmlive/stylesheets/masterpages/opensans.ie.min.css']
                }
            };
        })();
    </SharePoint:ScriptBlock>
    <SharePoint:StyleBlock runat="server">
        #s4-ribbonrow {
            overflow: hidden !important;
            height: 90px;
            display: block;
        }
    </SharePoint:StyleBlock>
<![endif]-->
        
<!--[if !IE]><!-->
    <SharePoint:StyleBlock runat="server">
        .epm-nav-icon {
            top: 4px;
        }
    </SharePoint:StyleBlock>

    <link href='/_layouts/15/epmlive/stylesheets/uplandv5.master.min.css?v=<%= EPMLiveVersion %>' rel='stylesheet' type='text/css'>
<!--<![endif]-->

<Sharepoint:StyleBlock runat="server">
    span.ms-welcome-root > span.ms-core-menu-arrow:before,
    span.ms-welcome-hover > span.ms-core-menu-arrow:before {
        content: "\e005";
    }
</Sharepoint:StyleBlock>

<script src="/_layouts/15/IE55UP.JS"></script>

<SharePoint:ScriptBlock runat="server">
    window.epmLive = window.epmLive || {};
    
    window.epmLive.rootWebId = '<%= RootWebId %>';
    window.epmLive.currentSiteId = '<%= SiteId %>';
    window.epmLive.currentSiteUrl = '<%= SiteUrl %>';
    window.epmLive.currentWebId = '<%= WebId %>';
    window.epmLive.currentWebUrl = '<%= WebUrl %>';
    window.epmLive.currentWebFullUrl = '<%= WebFullUrl %>';
    window.epmLive.currentListId = '<%= ListId %>';
    window.epmLive.currentListIcon = '<%= ListIconClass %>';
    window.epmLive.currentListTitle = '<%= ListTitle %>';
    window.epmLive.currentListViewTitle = '<%= ListViewTitle %>';
    window.epmLive.currentListViewUrl = '<%= ListViewUrl %>';
    window.epmLive.currentFileIsNull = '<%= CurrentFileIsNull %>';
    window.epmLive.currentFileTitle = '<%=CurrentFileTitle %>';
    window.epmLive.currentItemID = '<%= ItemId %>';
    window.epmLive.currentItemTitle = '<%= ItemTitle %>';
    window.epmLive.currentUserId = '<%= CurrentUserId %>';
    window.epmLive.currentUrl = '<%= CurrentUrl %>';
    window.epmLive.fileVersion = '<%= EPMLiveVersion %>';
    window.epmLive.debugMode = <%= DebugMode.ToString().ToLower() %>;
</SharePoint:ScriptBlock>