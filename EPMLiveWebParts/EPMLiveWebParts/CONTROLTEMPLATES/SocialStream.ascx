<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SocialStream.ascx.cs" Inherits="EPMLiveWebParts.CONTROLTEMPLATES.SocialStream" %>

<div id="epm-social-stream">
    <ul id="epm-se-days"></ul>
</div>

<script id="epm-se-day-template" type="text/x-handlebars-template">
    <li id="epm-se-{{domId}}" class="epm-se-day">
        <div class="epm-se-header">
            <hr />
            <h1 data-date="{{id}}">{{day}}</h1>
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
            <hr />
            <ul class="epm-se-newer-activities"></ul>
            <ul class="epm-se-todays-activities"></ul>
            <ul class="epm-se-older-activities"></ul>
        {{/if}}
    </li>
</script>

<script id="epm-se-activity-template" type="text/x-handlebars-template">
    <li id="epm-se-{{id}}" class="epm-se-activity clearfix">
        {{#if notComment}}
            <div class="epm-se-activity-icon"><span class="epm-se-activity-icon {{icon}}"></span></div>
            <div class="epm-se-user-info">{{> user}}&nbsp;</div>
            <div class="epm-se-activity-text">{{{text}}}</div>
        {{else}}
            <div class="epm-se-user-info">{{> avatar}}</div>
            <div class="epm-se-activity-text">{{> user}}&nbsp;-&nbsp;{{{text}}}</div>
        {{/if}}
        <div class="epm-se-activity-info"><span data-time="{{time}}" class="epm-se-activity-time">{{displayTime}}</span></div>
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
        <div class="epm-se-user-info"><a data-id="{{user.id}}" class="epm-se-link-user">{{user.displayName}}</a></div>
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
        <a href="{{web.url}}" target="_blank">{{web.title}}</a>:&nbsp;
    {{/unless}}
    <a data-webId="{{web.id}}" data-listId="{{list.id}}" class="epm-se-link-list">{{list.name}}</a>&nbsp;-&nbsp;
    <a data-webId="{{web.id}}" data-listId="{{list.id}}" data-itemId="{{itemId}}" class="epm-se-link-item"><h2>{{title}}</h2></a>
</script>

<script id="_epm-se-avatar" type="text/x-handlebars-template">
    <div class="epm-se-user-avatar">
        {{#if user.avatar}}
            <img src="{{user.avatar}}" />
        {{/if}}
    </div>
</script>

<script id="_epm-se-user" type="text/x-handlebars-template">
    <a data-id="{{user.id}}" data-name="{{user.name}}" class="epm-se-link-user">{{user.displayName}}</a>
</script>

<script id="_epm-se-time" type="text/x-handlebars-template">
    <span data-time="{{activity.time}}" class="epm-se-activity-time">{{activity.displayTime}}</span>
</script>

<script id="_epm-se-thread-icon" type="text/x-handlebars-template">
    <span class="epm-se-thread-icon {{icon}}"></span>
</script>