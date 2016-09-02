<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.Calendar" %>

<html>
    <head>
        <title>Calendar</title>
    </head>
    <body>
        <form id="EpmLiveCalCtrlForm" runat="server">
            <SharePoint:DateTimeControl ID="DateTimeControl" runat="server" />
        </form>
    </body>
</html>