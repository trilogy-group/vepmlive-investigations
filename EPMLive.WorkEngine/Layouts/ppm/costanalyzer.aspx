﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="costanalyzer.aspx.cs" Inherits="WorkEnginePPM.CostAnalyzerASPX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/Model.ascx" %>
<%@ Reference Control="/_layouts/ppm/CostAnalyzer.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

<asp:PlaceHolder runat="server" ID="PlaceHolder1" />
<script type="text/javascript">
    function Page_OnResize() {

        try {
            if (typeof (costtypeanalyzer) != "undefined") {
                costtypeanalyzer.SetSize(document.documentElement.clientWidth, document.documentElement.clientHeight);
            }
        }
        catch (e) { }

         try {
             if (typeof (model) != "undefined") {
                 model.SetSize(document.documentElement.clientWidth, document.documentElement.clientHeight);
             }
        }
        catch (e) { }
    }

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("resize", Page_OnResize, true);
    }
    else { // e.g. IE
        window.attachEvent("onresize", Page_OnResize);
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Cost Analyzer
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Cost Analyzer
</asp:Content>