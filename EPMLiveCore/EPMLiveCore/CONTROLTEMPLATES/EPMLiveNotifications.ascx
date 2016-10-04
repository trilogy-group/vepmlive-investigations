<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EPMLiveNotifications.ascx.cs" Inherits="EPMLiveCore.ControlTemplates.EPMLiveNotifications" %>
<%@ Import Namespace="Microsoft.SharePoint" %>

<div id="EPMLiveNotificationsWrap" data-bind="slideUpDown: epmLiveNotifications.showNotifications(), slideDuration: 200">
    <div id="EPMLiveNotifications">
        <div id="EPMLiveNotificationMessages" data-bind="template: 'notificationMessagesTemplate', slideUpDown: epmLiveNotifications.activeView() === 'notification', slideDuration: 200"></div>
        <div data-bind="template: { name: 'notificationMessageTemplate', data: epmLiveNotifications.activeNotification(), afterRender: epmLiveNotifications.postNotificationMessageDisplay }, slideUpDown: epmLiveNotifications.activeView() === 'message', slideDuration: 200"></div>
    </div>
</div>

<script type="text/html" id="notificationMessagesTemplate">
    <div class="EPMLiveNotificationsHeader" data-bind="visible: epmLiveNotifications.notifications().length === 0">
        <h2>You do not have any notifications</h2>
    </div>
    <div id="EPMLiveNotificationSystemWrap" data-bind="visible: epmLiveNotifications.totalSystemNotifications() > 0">
        <div class="EPMLiveNotificationsHeader">
            <h2>System Notifications</h2>
        </div>
        <div id="EPMLiveNotificationSystem" class="EPMLiveNotificationFixed">
            <div data-bind="template: { name: 'newNotificationTemplate', foreach: epmLiveNotifications.newSystemNotifications }"></div>
            <div data-bind="template: { name: 'oldNotificationTemplate', foreach: epmLiveNotifications.oldSystemNotifications }"></div>
        </div>
    </div>
    <div id="EPMLiveNotificationGeneralWrap" data-bind="visible: epmLiveNotifications.totalGeneralNotifications() > 0">
        <div class="EPMLiveNotificationsHeader EPMLiveNotificationTopBorder">
            <h2>General Notifications</h2>
        </div>
        <div id="EPMLiveNotificationGeneral" class="EPMLiveNotificationFixed">
            <div data-bind="template: { name: 'newNotificationTemplate', foreach: epmLiveNotifications.newGeneralNotifications }"></div>
            <div data-bind="template: { name: 'oldNotificationTemplate', foreach: epmLiveNotifications.oldGeneralNotifications }"></div>
        </div>
    </div>
</script>

<script type="text/html" id="newNotificationTemplate">
    <div id="EPMLiveNotification-${id()}" class="EPMLiveNotificationMessage EPMLiveNotification-NewMessage" data-bind="template: { name: 'notificationTemplate', data: $data }, click: function() { epmLiveNotifications.viewMessage(id()) }"></div>
</script>

<script type="text/html" id="oldNotificationTemplate">
    <div id="EPMLiveNotification-${id()}" class="EPMLiveNotificationMessage" data-bind="template: { name: 'notificationTemplate', data: $data }, click: function() { epmLiveNotifications.viewMessage(id()) }"></div>
</script>

<script type="text/html" id="notificationTemplate">
    <div class="EPMLiveNotificationThumbnail"><img data-bind="src: creatorthumbnail(), alignmiddle: true, attr: { alt: creatorname() }" /></div>
    <div class="EPMLiveNotificationDetails">
        <div class="EPMLiveNotificationTitle">${title()}</div>
        <div class="EPMLiveNotificationType" data-bind="style: { 'background': epmLiveNotifications.messageTypeImage(type()) }">&nbsp;</div>
        <abbr data-bind="template: { name: 'notificationMessageInfoTemplate', data: $data, afterRender: epmLiveNotifications.postMessageInfoRender }"></abbr>
    </div>
</script>

<script type="text/html" id="notificationMessageTemplate">
    <div class="EPMLiveNotificationsHeader">
        <div class="EPMLiveNotificationThumbnail"><img data-bind="src: creatorthumbnail(), alignmiddle: true, maxDimension: 50, attr: { alt: creatorname() }" /></div>
        <div class="EPMLiveNotificationsHeaderWrap">
            <h2 class="EPMLiveNotificationsH30">${title()}</h2>
            <h6 class="EPMLiveNotificationsH20" data-bind="template: { name: 'notificationMessageInfoTemplate', data: $data, afterRender: epmLiveNotifications.postMessageInfoRender }"></h6>
        </div>
    </div>
    <div class="EPMLiveNotificationDesc" data-bind="html: message()"></div>
    <div class="EPMLiveNotificationDescFooter">
        <span class="EPMLiveNotificationDescFooterLink">
            <span data-bind="click: function() { epmLiveNotifications.viewNotifications() }" style="position: relative; font-size: 15px; top: -0.55px;">«</span>
            <span data-bind="click: function() { epmLiveNotifications.viewNotifications() }">Back</span>
        </span>
    </div>
</script>

<script type="text/html" id="notificationMessageInfoTemplate">
    <span data-bind="text: epmLive.getFriendlyDateTime(createdat(), createdatdatestring())"></span> - by 
    {{if createdby() !== 0}}
        <a class="EPMLiveNotificationCreatorLink" href="<%= SiteUrl %>/_layouts/userdisp.aspx?ID=${createdby()}" target="_blank">${creatorname()}</a>
    {{else}}
        ${creatorname()}
    {{/if}}
</script>
