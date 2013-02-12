<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EPMLiveStatusbar.ascx.cs" Inherits="EPMLiveCore.ControlTemplates.EPMLiveStatusbar" %>

<link href="<%= SiteUrl %>/_layouts/epmlive/stylesheets/statusbar.css" rel="stylesheet" type="text/css" />
<div id="EPMLiveStatusbar" data-bind="visible: (collection().length > 0) && epmLive.getUrlParamByName('IsDlg') !== '1', template: { name: 'EPMLiveStatusbarTemplate', foreach: collection() }"></div>

<script type="text/html" id="EPMLiveStatusbarTemplate">
    <div class="EPMLiveStatusbar ${cssClass()}" data-bind="template: { name: 'EPMLiveStatuTemplate', foreach: collection() }"></div>
</script>

<script type="text/html" id="EPMLiveStatuTemplate">
    <span class="EPMLiveStatus EPMLiveStatus-${align()}">{{if title()}}<b>${title()}: </b>{{/if}}{{if icon()}}<img src="${icon()}" align="absmiddle"/> {{/if}}<span data-bind="html: message()"></span></span>
</script>