<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectDate.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.epmlive.SelectDate" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <link rel="stylesheet" type="text/css" href="dhtml/calendar/dhtmlxcalendar.css">
    <script src="dhtml/calendar/dhtmlxcommon.js"></script>
    <script src="dhtml/calendar/dhtmlxcalendar.js"></script>
    <script>window.dhx_globalImgPath = "dhtml/calendar/imgs/";</script> 

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    Select Date:<br />
    <div id="objId"><br />
    <script>

        var mCal = new dhtmlxCalendarObject("objId", true);
        mCal.setSkin("yahoolike");
        mCal.draw();
        mCal.setDate(parent.curTempDate);
    </script>
    <br />
    <input type="button" value="OK" onclick="parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, mCal.getDate()); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" /> &nbsp;
    <input type="button" value="Cancel" onclick="parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" class="ms-ButtonHeightWidth" style="width:100px" target="_self" />  

    

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
