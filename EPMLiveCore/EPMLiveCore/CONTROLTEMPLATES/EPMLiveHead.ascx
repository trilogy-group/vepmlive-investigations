﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EPMLiveHead.ascx.cs" Inherits="EPMLiveCore.CONTROLTEMPLATES.EPMLiveHead" %>

<!--[if lt IE 9]>
    <SharePoint:ScriptBlock runat="server">
        (function() {
            WebFontConfig = {
                custom: {
                    families: ['Open Sans Light', 'Open Sans Regular', 'Open Sans Semi Bold'],
                    urls: ['/_layouts/15/epmlive/stylesheets/masterpages/opensans.ie.min.css']
                }
            };

            var styles = [];

            var url = (window.location.href + '').toLowerCase();
            if (url.indexOf('isdlg') === -1) {
                styles.push('masterpages/upland.icons');
                styles.push('libraries/jquery-ui');
            } else {
                if (url.indexOf('/ppm/') === -1) {
                    styles.push('libraries/jquery-ui');
                }
            }

            var head = document.getElementsByTagName('head')[0];

            for (var i = 0; i < styles.length; i++) {
                var style = document.createElement('link');

                style.type = 'text/css';
                style.rel = 'stylesheet';
                style.href = '/_layouts/15/epmlive/stylesheets/' + styles[i] + '.min.css?v=<%= EPMLiveVersion %>';

                head.appendChild(style);
            }
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

<!--[if IE 9]>
    <link href='/_layouts/15/epmlive/stylesheets/masterpages/opensans.min.css?v=<%= EPMLiveVersion %>' rel='stylesheet' type='text/css'>
    <link href='/_layouts/15/epmlive/stylesheets/masterpages/upland.icons.min.css?v=<%= EPMLiveVersion %>' rel='stylesheet' type='text/css'>
    
    <SharePoint:ScriptBlock runat="server">
        (function() {
            var styles = [];

            var url = (window.location.href + '').toLowerCase();
            if (url.indexOf('isdlg') === -1) {
                styles.push('libraries/jquery-ui');
            } else {
                if (url.indexOf('/ppm/') === -1) {
                    styles.push('libraries/jquery-ui');
                }
            }

            var head = document.getElementsByTagName('head')[0];

            for (var i = 0; i < styles.length; i++) {
                var style = document.createElement('link');

                style.type = 'text/css';
                style.rel = 'stylesheet';
                style.href = '/_layouts/15/epmlive/stylesheets/' + styles[i] + '.min.css?v=<%= EPMLiveVersion %>';

                head.appendChild(style);
            }
        })();
    </SharePoint:ScriptBlock>
<![endif]-->
        
<!--[if !IE]><!-->

    <SharePoint:StyleBlock runat="server">
        .epm-nav-icon {
            top: 4px;
        }
    </SharePoint:StyleBlock>

    <link href='/_layouts/15/epmlive/stylesheets/masterpages/opensans.min.css?v=<%= EPMLiveVersion %>' rel='stylesheet' type='text/css'>
    <link href='/_layouts/15/epmlive/stylesheets/masterpages/upland.icons.min.css?v=<%= EPMLiveVersion %>' rel='stylesheet' type='text/css'>
    <link href="/_layouts/15/epmlive/stylesheets/libraries/jquery-ui.css?v=<%= EPMLiveVersion %>" rel="stylesheet" type="text/css" />
<!--<![endif]-->

<Sharepoint:StyleBlock runat="server">
    span.ms-welcome-root > span.ms-core-menu-arrow:before,
    span.ms-welcome-hover > span.ms-core-menu-arrow:before {
        content: "\e005";
    }
</Sharepoint:StyleBlock>
        
<link href="/_layouts/15/epmlive/stylesheets/masterpages/UplandV5.min.css?v=<%= EPMLiveVersion %>" rel="stylesheet" type="text/css" />
<script src="/_layouts/15/epmlive/javascripts/masterpages/UplandV5.min.js?v=<%= EPMLiveVersion %>" type="text/javascript"> </script>

<script src="/_layouts/15/epmlive/javascripts/libraries/tooltip.min.js?v=<%= EPMLiveVersion %>" type="text/javascript"> </script>
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