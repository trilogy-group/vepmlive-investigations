<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstallNav.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.applications.InstallNav" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<link href="Applications.css" rel="stylesheet" type="text/css" />

<script language="javascript">

    function GoToStore() {
        parent.location.href = "http://market.epmlive.com/?Source=<%=sFullWebUrl %>";
    }
    function GoToApp() {
        parent.location.href = "../ChangeApp.aspx?appid=<%=Request["appid"] %>";
    }
    
    try {
        $('body', window.parent.document).scrollTop(0);
    } catch (e) {
    }
</script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <h3>Installation Results: <strong style="color:#376594;"><%=ApplicationName %></strong></h3>

    <HR style="COLOR: #cccccc">
    <%=sbOutput.ToString()%>
    <br /><br />

    <a class="btn btn-success btn-large" href="javascript:void(0);" id="installbutton2" onclick="GoToApp();">Go To Community</a>&nbsp;
    <a class="btn btn-success btn-large" href="javascript:void(0);" id="A1" onclick="GoToStore();">Go To Store</a>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">

    Application Install

</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >

    Application Install

</asp:Content>
