<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SocialStream.ascx.cs" Inherits="EPMLiveWebParts.CONTROLTEMPLATES.SocialStream" %>

<SharePoint:ScriptBlock runat="server">
    (function() {
        'use strict';
        
        window.epmLive = window.epmLive || {};
        window.epmLive.currentUserTimeZone = <%= CurrentUserTimeZone %>;
    })();
</SharePoint:ScriptBlock>

<div id="epm-social-stream">
    <ul id="epm-se-days"></ul>
    <div id="epm-se-no-activity">Get to work! Once you start working in the system, items will appear here in the stream.</div>
    <div id="epm-se-pagination"><span>Loading more...</span></div>
</div>

<script id="epm-se-day-template" type="text/x-handlebars-template">
    <li id="epm-se-{{domId}}" class="epm-se-day" data-date="{{id}}">
        <div class="epm-se-header">
            <hr />
            <h1>{{day}}</h1>
        </div>
        <ul class="epm-se-threads"></ul>
    </li>
</script>

<script id="epm-se-thread-template" type="text/x-handlebars-template">
    <li id="epm-se-{{id}}" class="epm-se-thread clearfix">
        {{#if isSingleNonCommentThread}}
            {{> single-non-comment-thread}}
        {{else}}
            {{#if isCommentThread}}
                {{> comment-thread}}
            {{else}}
                {{> general-thread}}
            {{/if}}
            <div class="epm-se-show-older" data-threadId="{{id}}" data-action="older"><span class="icon-arrow-down-16"></span>show older activities</div>
            <ul class="epm-se-older-activities"></ul>
            <ul class="epm-se-todays-activities"></ul>
            <div class="epm-se-show-newer" data-threadId="{{id}}" data-action="newer"><span class="icon-arrow-down-16"></span>show newer activities</div>
            <ul class="epm-se-newer-activities"></ul>
        {{/if}}
    </li>
    {{> comment-box}}
</script>

<script id="epm-se-activity-template" type="text/x-handlebars-template">
    <li id="epm-se-{{id}}" class="epm-se-activity clearfix">
        {{#if notComment}}
            <div class="epm-se-activity-icon"><span class="epm-se-activity-icon {{icon}}"></span></div>
            <div class="epm-se-user-info">{{> user-plain}}&nbsp;</div>
            <div class="epm-se-activity-text">{{{text}}}</div>
        {{else}}
            <div class="epm-se-user-info">{{> avatar}}</div>
            <div class="epm-se-activity-text">{{> user-plain}}&nbsp;-&nbsp;{{{text}}}</div>
        {{/if}}
        <div class="epm-se-activity-info">
            <span class="epm-se-activity-time epm-se-has-tooltip" title="{{longDateTime}}" data-placement="top" data-toggle="tooltip">{{displayTime}}</span>
        </div>
    </li>
</script>

<script id="_epm-se-single-non-comment-thread" type="text/x-handlebars-template">
    <div class="epm-se-header epm-se-single-non-comment-thread">
        <div class="epm-se-user-info">{{> avatar}}{{> user}}</div>
        <div class="epm-se-thread-info">
            <span class="epm-se-action">{{activity.action}}</span>
            {{> thread-info}}
        </div>
        <div class="epm-se-activity-info">{{> time}}{{> thread-icon}}</div>
    </div>
</script>

<script id="_epm-se-comment-thread" type="text/x-handlebars-template">
    <div class="epm-se-header epm-se-comment-thread">
        <div class="epm-se-user-info"><a data-url="{{user.url}}" class="epm-se-link-user" href="{{user.url}}" target="_blank">{{user.displayName}}</a></div>
        <div class="epm-se-thread-info">made a comment...</div>
        <div class="epm-se-activity-info"><span class="epm-se-thread-icon icon-bubble-12"></span></div>
    </div>
</script>

<script id="_epm-se-general-thread" type="text/x-handlebars-template">
    <div class="epm-se-header epm-se-general-thread">
        <div class="epm-se-thread-info">{{> thread-info}}</div>
        <div class="epm-se-activity-info">{{> thread-icon}}</div>
    </div>
</script>

<script id="_epm-se-thread-info" type="text/x-handlebars-template">
    {{#unless web.isCurrentWorkspace}}
        <a href="{{web.url}}" href="{{web.url}}" target="_blank">{{web.title}}</a>:&nbsp;
    {{/unless}}
    <a data-url="{{list.url}}" class="epm-se-link-list" href="{{list.url}}" target="_blank">{{list.name}}</a>
    {{#unless isBulkOperationThread}}
        &nbsp;-&nbsp;
    {{else}}
        &nbsp;items
    {{/unless}}
    <a data-url="{{url}}" class="epm-se-link-item" href="{{url}}" target="_blank"><h2>{{title}}</h2></a>
</script>

<script id="_epm-se-avatar" type="text/x-handlebars-template">
    <div class="epm-se-user-avatar">
        {{#if user.avatar}}
            <img src="{{user.avatar}}" />
        {{/if}}
    </div>
</script>

<script id="_epm-se-user" type="text/x-handlebars-template">
    <a data-url="{{user.url}}" class="epm-se-link-user epm-se-has-tooltip" title="{{user.name}}" data-placement="top" data-toggle="tooltip" href="{{user.url}}" target="_blank">{{user.displayName}}</a>
</script>

<script id="_epm-se-user-plain" type="text/x-handlebars-template">
    <a data-url="{{user.url}}" class="epm-se-link-user" href="{{user.url}}" target="_blank">{{user.displayName}}</a>
</script>

<script id="_epm-se-time" type="text/x-handlebars-template">
    <span class="epm-se-activity-time epm-se-has-tooltip" title="{{activity.longDateTime}}" data-placement="top" data-toggle="tooltip">{{activity.displayTime}}</span>
</script>

<script id="_epm-se-thread-icon" type="text/x-handlebars-template">
    <span class="epm-se-thread-icon {{icon}}"></span>
</script>

<script id="_epm-se-comment-box" type="text/x-handlebars-template">
    <div data-threadId="{{id}}" class="epm-se-comment-box clearfix">
        <div class="epm-se-comment-input" contenteditable="true"></div>
        <button class="epm-se-comment-post">Post</button>
    </div>
</script>