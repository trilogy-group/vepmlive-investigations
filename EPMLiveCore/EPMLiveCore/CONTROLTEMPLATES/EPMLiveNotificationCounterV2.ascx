<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EPMLiveNotificationCounterV2.ascx.cs" Inherits="EPMLiveCore.CONTROLTEMPLATES.EPMLiveNotificationCounterV2" %>

<div id="EPMLiveNotificationCounterProfilePic">
    <img id="EPMLiveProfilePic" src="<%= PrifilePicUrl %>"/>
    <div id="EPMLiveNotificationCounter" data-bind="style: { background: epmLiveNotifications.notificationCounterColor(), fontWeight: epmLiveNotifications.notificationCounterFontWeight() }">
        <span id="EPMLiveNotificationCount" data-bind="text: epmLiveNotifications.totalNewNotifications() > 99 ? '99+' : epmLiveNotifications.totalNewNotifications()">&nbsp;</span>
    </div>
</div>

<SharePoint:ScriptBlock runat="server">
    (function() {
        var img = document.getElementById('EPMLiveProfilePic');
        img.onerror = function() {
            this.style.display = 'none';
        };
    })();
</SharePoint:ScriptBlock>