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
        {{render 'activities' activities}}
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

<script type="text/x-handlebars" data-template-name="_single-activity">
    {{partial 'user'}}<div class="title">{{title}}</div>
</script>

<script type="text/x-handlebars" data-template-name="_user">
    <div class="avatar">
        {{#if firstActivity.user.hasAvatar}}
        <img {{bind-attr src='firstActivity.user.avatar'}} />
        {{/if}}
    </div>
</script>

<%--

<script type="text/x-handlebars" data-template-name="_threads">
    {{#each day in controller}}
        <div class="date">{{ date }}</div>
        {{#each thread in threads}}
            <div class="thread">
                <div class="head">{{ title }}</div>
                <div class="activities">{{ partial "activities" }}</div>
            </div>
        {{/each}}
    {{/each}}
</script>

<script type="text/x-handlebars" data-template-name="_activities">
    {{#each activity in activities}}
        <div class="activity">{{ title }}</div>
    {{/each}}
</script>--%>