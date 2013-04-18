<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemplateVersoning.ascx.cs" Inherits="EPMLiveCore.ControlTemplates.TemplateVersoning" %>

<% if (!UseLiveTemplates) { %>

<script id="EPMLiveTemplateVersoningSavePrompt" type="text/html">
<div style="padding:10px;">
    Are you sure you want to save this template and replace the existing template with this new template?<br/><br/>

    <input id="EpmLiveTemplateVersoningSaveButton" type="button" target="_self" class="ms-ButtonHeightWidth" onclick="window.epmLiveTemplateVersoning.saveTemplate(); return false;" value="Save Template" style="float:left;width:90px;margin-right:5px;">

    <input id="EpmLiveTemplateVersoningCancelButton" type="button" target="_self" class="ms-ButtonHeightWidth" onclick="SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', SP.UI.DialogResult.cancel); return false;" value="Close" style="float:left;width:90px;">

    <div id="EpmLiveTemplateVersoningSaveStatus" style="color:#0072BC;font-size:15px;font-weight:bold;margin-left:10px;height: 24px;line-height: 24px;">
        <img src="/_layouts/images/progress-circle-24.gif" style="display: none;float:left;margin: 0 5px;" id="EpmLiveTemplateVersoningSaveStatusProgress"/>
        <span id="EpmLiveTemplateVersoningSaveStatusMessage" style="margin: 0 5px;"></span>
    </div>
</div>
</script>

<script src="<%= SiteUrl %>/_layouts/epmlive/javascripts/EPMLive.TemplateVersoning.js" type="text/javascript"> </script>

<% } %>
