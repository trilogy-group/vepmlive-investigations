<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SocialStream.ascx.cs" Inherits="EPMLiveWebParts.CONTROLTEMPLATES.SocialStream" %>

<div id="epm-social-stream"></div>

<script type="text/x-handlebars" data-template-name="application">
    {{ outlet }}
</script>

<script type="text/x-handlebars" data-template-name="index">
    {{#each controller.days}}
        {{render 'day' this}}
    {{else}}
        You do not have any activities yet!
    {{/each}}
</script>

<script type="text/x-handlebars" data-template-name="day">
    <div class="header">
        <hr />
        <h1 {{bind-attr data-id='id'}}>{{day}}</h1>
    </div>
    {{render 'activity-threads' activityThreads}}
</script>

<script type="text/x-handlebars" data-template-name="activity-threads">
    {{#each}}
        {{render 'activity-thread' this}}
    {{/each}}
</script>

<script type="text/x-handlebars" data-template-name="activity-thread">
    {{#if singleActivityThread}}
        {{partial 'single-activity'}}
    {{else}}
        <div class="header">{{thread-info thread=thread classNames='thread-info'}}{{thread-icon icon=icon classNames='icon-wrap' tagName='span'}}</div>
        {{#if isComment}}
            {{comment-activity activity=firstActivity classNames='comment-activity' tagName='div'}}
        {{else}}
            {{render 'activities' generalActivities}}
            {{render 'activities' commentActivities}}
        {{/if}}
    {{/if}}
</script>

<script type="text/x-handlebars" data-template-name="activities">
    {{#each}}
        {{render 'activity' this}}
    {{/each}}
</script>

<script type="text/x-handlebars" data-template-name="activity">
    {{#if isComment}}
        {{comment-activity activity=this classNames='comment-activity'}}
    {{else}}
        <div class="general-activity">
            <span {{bind-attr class='icon'}}></span>
            <div class="activity-detail">
                <a {{bind-attr href='user.profileUrl'}} class="user" target="_blank">{{user.displayName}}</a> <div class="details">{{details}}</div>
            </div>
            <div class="activity-info">
                {{activity-time activity=this classNames='time-wrap' tagName='span'}}
            </div>
        </div>
    {{/if}}
</script>

<script type="text/x-handlebars" data-template-name="_single-activity">
    {{partial 'user'}} <div class="action">{{activityKind}}</div> 
    {{thread-info thread=thread classNames='thread-info'}} 
    {{#if firstActivity.isBulkOperation}}
        items
    {{/if}}
    {{partial 'activity-info'}}
</script>

<script type="text/x-handlebars" data-template-name="_user">
    <div class="user">
        {{user-avatar user=firstActivity.user classNames='avatar'}}
        {{user-info user=firstActivity.user classNames='info'}}
    </div>
</script>

<script type="text/x-handlebars" data-template-name="_activity-info">
    <div class="activity-info">
        {{activity-time activity=firstActivity classNames='time-wrap' tagName='span'}}
        {{thread-icon icon=icon classNames='icon-wrap' tagName='span'}}
    </div>
</script>

<script type="text/x-handlebars" data-template-name="components/comment-activity">
    <div class="user">
        {{user-avatar user=activity.user classNames='avatar'}}
    </div>
    <div class="activity-detail">
        <a {{bind-attr href='activity.user.profileUrl'}} class="user" target="_blank">{{activity.user.displayName}}</a>&nbsp;-&nbsp;{{{activity.comment}}}
    </div>
    <div class="activity-info">
        {{activity-time activity=activity classNames='time-wrap' tagName='span'}}
    </div>
</script>

<script type="text/x-handlebars" data-template-name="components/activity-time">
    <span class="date" {{action 'showDate' on='mouseEnter' target='view'}} data-toggle="tooltip" data-placement="top" {{bind-attr title='activity.fullDateTime'}}>{{activity.date}}</span>
</script>

<script type="text/x-handlebars" data-template-name="components/thread-icon">
    <span {{bind-attr class='icon'}}></span>
</script>

<script type="text/x-handlebars" data-template-name="components/thread-info">
    {{#if thread.web.isNotCurrentWorkspace}}
        <div class="workspace"><a {{bind-attr href='thread.web.url'}} target="_blank">{{thread.web.title}}</a></div>
    {{/if}}
    
    {{#if thread.hasList}}
        <div class="list">
            {{#if thread.web.isNotCurrentWorkspace}}
                <span>&nbsp;-&nbsp;</span>
            {{/if}}
            <a {{bind-attr href='thread.list.url'}} target="_blank">{{thread.list.name}}</a>
        </div>
    {{/if}}
    
    {{#if thread.hasItem}}
        <div class="item"><span>:&nbsp;</span><a {{bind-attr href='thread.activityUrl'}} target="_blank">{{thread.title}}</a></div>
    {{/if}}
</script>

<script type="text/x-handlebars" data-template-name="components/user-avatar">
    {{#if user.hasAvatar}}
        <img {{bind-attr src='user.avatar'}} />
    {{/if}}
</script>

<script type="text/x-handlebars" data-template-name="components/user-info">
    <a {{bind-attr href='user.profileUrl'}} class="user" target="_blank" {{action 'showName' on='mouseEnter'}} data-toggle="tooltip" data-placement="top" {{bind-attr title='user.name'}}>{{user.displayName}}</a>
</script>