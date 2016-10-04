<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="EPMLiveCore.settings" DynamicMasterPageFile="~masterurl/default.master" %>
<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Settings
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this section to configure the settings for this site.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">
  <style>
    .ms-linksection-level1 TD
    {
        padding-bottom: 0px !important;
    }
  </style>
  <%=data %>

</asp:Content>

<asp:Content ID="Additional" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

<style> 
 
h3 {    
    color: #595959;
    font-size: 11pt;
    font-weight: normal;
    margin: 0;
    padding: 0;
}
 
 
 
.setting ul
{
  list-style:none;
  margin-top:1px;
  padding-left:0px;
}
 
.setting li a
{
	color: #0072BC;
    text-decoration: none;
    padding:0px;
    font-family:Verdana;
    font-size:12px;
	line-height:16px;
}
 
.setting a:hover {background:#ffffff; text-decoration:none;} /*BG color is a must for IE6*/
 
a.settingtooltip span 
{
display:none; 
padding:2px 3px; 
margin-left:30px; 
width:300px;
line-height:20px;
}
 
a.settingtooltip:hover span
{
display:inline;
padding: 10px; 
position:absolute; 
background:#F9F9F9; 
border:1px solid #cccccc; 
color:#6c6c6c;
}
 
</style>

</asp:Content>