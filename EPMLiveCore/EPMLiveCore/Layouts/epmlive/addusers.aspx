<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addusers.aspx.cs" Inherits="EPMLiveCore.addusers" DynamicMasterPageFile="~masterurl/default.master" %>


<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
Site Permissions: Add Users
</asp:Content>
<asp:Content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
Site Permissions: Add Users
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
Use this page to select which users you would like to add to your site.
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css" />
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid_skins.css" />
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.css" />
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/dhtml/xmenu/dhtmlxmenu.css" />
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/dhtml/xmenu/context.css" />
    <link rel="STYLESHEET" type="text/css" href="/_layouts/epmlive/dhtml/xcombo/dhtmlxcombo.css" />


    <asp:PlaceHolder id="phToolbar" runat="server"></asp:PlaceHolder>
    
    <div id="myGrid999" style="width:100%;height:500px;display:none;overflow:hidden"></div>
    <div width="100%" id="loadingmyGrid999" align="center">
        <img src="/_layouts/images/GEARS_AN.GIF" style="vertical-align: middle;"/> Loading Resources...
    </div>

    <input type="hidden" visible="true" id="resourceList" name="resourceList" value="" />
        
</asp:Content>