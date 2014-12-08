﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
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
                }               
            });

            //window.upland_insight = {
            //    id: '<%= UplandInsightId %>',
            //    user: {
            //        id: window.epmLive.currentUserLoginName,
            //        name: window.epmLive.currentUserName
            //    }
            //};

            //if(window.upland_insight.id) {
            //    (function () {
            //        var e = document.createElement('script');
            //        e.type = 'text/javascript';
            //        e.async = true;
            //        e.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 's3.amazonaws.com/cdn.upland/upland.insight.js';
            //        var s = document.getElementsByTagName('script')[0];
            //        s.parentNode.insertBefore(e, s);
            //    })();
            //}
        }

        ExecuteOrDelayUntilScriptLoaded(onJqueryLoaded, 'jquery.min.js');
    })();
</SharePoint:ScriptBlock>