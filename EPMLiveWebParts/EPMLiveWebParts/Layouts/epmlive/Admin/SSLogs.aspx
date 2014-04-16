<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSLogs.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.Admin.SSLogs" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div id="epm-se-logs">
        <div class="epm-se-message"></div>
        <div id="epm-se-log-list">
            <ul></ul>
        </div>
        <div id="epm-se-log-details"></div>
    </div>
    
    <script id="epm-se-log-template" type="text/x-handlebars-template">
        <li id="epm-se-log-{{id}}"><span class="epm-se-icon {{icon}}"></span>{{message}}</li>    
    </script>
    
    <script id="epm-se-log-details-template" type="text/x-handlebars-template">
        <div class="epm-se-header"><span class="epm-se-icon {{icon}}"></span><h1>{{message}}</h1></div>
        <div class="epm-se-details">
            <table>
                <tr><td class="epm-se-title">ID</td><td>{{id}}</td></tr>
                <tr><td class="epm-se-title">Kind</td><td>{{kind}}</td></tr>
                <tr><td class="epm-se-title">Time</td><td>{{friendlyTime}}</td></tr>
                <tr><td class="epm-se-title">User</td><td>{{user.displayName}} [{{user.name}}]</td></tr>
                <tr class="epm-se-seperator"><td class="epm-se-title">Web</td><td><a href="{{web.url}}" target="_blank">{{web.title}}</a></td></tr>
                <tr class="epm-se-seperator epm-se-raw"><td class="epm-se-title">Details</td><td><pre>{{details}}</pre></td></tr>
                <tr class="epm-se-seperator epm-se-raw"><td class="epm-se-title">Trace</td><td><pre>{{stackTrace}}</pre></td></tr>
            </table>
        </div>
    </script>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Social Stream Logs
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Social Stream Logs
</asp:Content>
