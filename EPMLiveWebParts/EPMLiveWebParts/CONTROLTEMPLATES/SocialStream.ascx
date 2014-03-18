<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SocialStream.ascx.cs" Inherits="EPMLiveWebParts.CONTROLTEMPLATES.SocialStream" %>

<div id="epm-social-stream"></div>

<script type="text/x-handlebars" data-template-name="application">
    {{ outlet }}
</script>

<script type="text/x-handlebars" data-template-name="index">
    {{#each controller.days}}
        {{render 'day' this}}
    {{/each}}
</script>

<script type="text/x-handlebars" data-template-name="day">
    <div class="header">
        <hr />
        <h1>{{day}}</h1>
    </div>
    {{render 'threads' threads}}
</script>

<script type="text/x-handlebars" data-template-name="threads">
    {{#each}}
        {{render 'thread' this}}
    {{/each}}
</script>

<script type="text/x-handlebars" data-template-name="thread">
    {{#if singleActivityThread}}
        {{partial 'single-activity'}}
    {{else}}
        {{#if isComment}}
            {{partial 'single-comment-thread'}}
        {{else}}
            {{render 'activities' activities}}
        {{/if}}
    {{/if}}
</script>

<script type="text/x-handlebars" data-template-name="activities">
    {{#each}}
        {{render 'activity' this}}
    {{/each}}
</script>

<script type="text/x-handlebars" data-template-name="activity">
    {{time}}
</script>

<script type="text/x-handlebars" data-template-name="_single-comment-thread">
    <div class="header">{{thread-info thread=this classNames='thread-info'}}</div>
    <div class="user">
        {{user-avatar user=firstActivity.user classNames='avatar'}}
    </div>
    {{partial 'activity-info'}}
</script>

<script type="text/x-handlebars" data-template-name="_single-activity">
    {{partial 'user'}} <div class="action">{{firstActivity.kind}}</div> {{thread-info thread=this classNames='thread-info'}} {{partial 'activity-info'}}

</script>

<script type="text/x-handlebars" data-template-name="_user">
    <div class="user">
        {{user-avatar user=firstActivity.user classNames='avatar'}}
        {{user-info user=firstActivity.user classNames='info'}}
    </div>
</script>

<script type="text/x-handlebars" data-template-name="_activity-info">
    <div class="activity-info">
        <span class="date" {{action 'showDate' on='mouseEnter' target='view'}} data-toggle="tooltip" data-placement="top" {{bind-attr title='firstActivity.fullDateTime'}}>{{firstActivity.date}}</span>
    </div>
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