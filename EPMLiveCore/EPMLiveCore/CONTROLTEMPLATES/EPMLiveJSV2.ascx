<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EPMLiveJSV2.ascx.cs" Inherits="EPMLiveCore.CONTROLTEMPLATES.EPMLiveJSV2" %>

<SharePoint:ScriptBlock runat="server">
    (function () {
        function onJqueryLoaded() {
            $.getScript = function (url, callback, cache) {
                $.ajax({
                    type: 'GET',
                    url: url,
                    success: callback,
                    dataType: 'script',
                    cache: cache
                });
            };

            $.getScript('<%= WebUrl %>/_layouts/15/epmlive/javascripts/libraries/knockout-2.2.1.js?v=<%= EPMFileVersion %>', function() {
                $.getScript('<%= WebUrl %>/_layouts/15/epmlive/javascripts/epmlive<%= DebugMode ? ".min" : string.Empty %>.js?v=<%= EPMFileVersion %>', function() {
                    epmLive.rootWebId = '<%= RootWebId %>';
                    epmLive.currentSiteId = '<%= SiteId %>';
                    epmLive.currentSiteUrl = '<%= SiteUrl %>';
                    epmLive.currentWebId = '<%= WebId %>';
                    epmLive.currentWebUrl = '<%= WebUrl %>';
                    epmLive.currentWebFullUrl = '<%= WebFullUrl %>';
                    epmLive.currentListId = '<%= ListId %>';
                    epmLive.currentListIcon = '<%= ListIconClass %>';
                    epmLive.currentListTitle = '<%= ListTitle %>';
                    epmLive.currentListViewTitle = '<%= ListViewTitle %>';
                    epmLive.currentListViewUrl = '<%= ListViewUrl %>';
                    epmLive.currentFileIsNull = '<%= CurrentFileIsNull %>';
                    epmLive.currentFileTitle = '<%=CurrentFileTitle %>';
                    epmLive.currentItemID = '<%= ItemId %>';
                    epmLive.currentItemTitle = '<%= ItemTitle %>';
                    epmLive.currentUserId = '<%= CurrentUserId %>';
                    epmLive.currentUrl = '<%= CurrentUrl %>';
                    epmLive.fileVersion = '<%= EPMFileVersion %>';
                    epmLive.debugMode = <%= DebugMode.ToString().ToLower() %>;
                    window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs('EPMLive.js');
                }, !window.isIE8);
            }, !window.isIE8);
            
            $(function () {
                var walkmeId = '<%= WalkMeId %>';
                if (walkmeId){
                    var walkme = document.createElement('script');
                    walkme.type = 'text/javascript';
                    walkme.async = true;
                    walkme.src = '<%= Scheme %>://d3b3ehuo35wzeh.cloudfront.net/users/<%= WalkMeId %>/walkme_<%= WalkMeId %>_https.js';
                    var s = document.getElementsByTagName('script')[0];
                    s.parentNode.insertBefore(walkme, s);
                };
            });
        }

        ExecuteOrDelayUntilScriptLoaded(onJqueryLoaded, 'jquery.min.js');
    })();
</SharePoint:ScriptBlock>