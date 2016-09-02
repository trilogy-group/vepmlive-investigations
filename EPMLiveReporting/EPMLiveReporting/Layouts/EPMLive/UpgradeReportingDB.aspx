<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpgradeReportingDB.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.UpgradeReportingDB" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <style type="text/css">
        .padding10 { padding: 10px; }

        .button-green:hover {
            background: #71BF31;
            border: 1px solid #60BA16;
            filter: none;
        }

        .button-green {
            background: #6CC325 1px;
            background: #6CC325 1px;
            background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
            background: -o-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
            background: -ms-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
            border: 1px solid #6ABD3D;
            color: white;
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#9FD870', endColorstr='#6CC325', GradientType=0);
            font-weight: bold;
        }

        .button {
            -khtml-border-radius: 5px;
            -moz-border-radius: 5px;
            -ms-border-radius: 5px;
            -o-border-radius: 5px;
            -webkit-border-radius: 5px;
            cursor: pointer;
            display: inline-block;
            font-family: arial, sans-serif !important;
            font-size: 18px;
            font-weight: normal;
            line-height: 24px;
            margin-bottom: 4px;
            padding: 8px 10px 1px 10px;
            text-align: center;
            text-decoration: none !important;
            text-shadow: none;
            white-space: nowrap;
        }

        .button {
            color: #FFFFFF !important;
            font-size: 16px !important;
            padding: 8px 15px;
        }

        .button-green-disabled {
            background: #6CC325 1px;
            background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
            background: -o-linear-gradient(top, #9FD870 1px, #6CC325 1px, #6ABD3C 100%);
            background: #6CC325 1px;
            background: -webkit-linear-gradient(top, #9FD870 1px, #98DB62 1px, #6ABD3C 100%);
            border: 1px solid #6ABD3D;
            color: white;
            cursor: default;
            filter: alpha(opacity=50);
            opacity: .5;
        }

        .upgradeheader {
            font-family: Segoe UI Light, Segoe, Helvetica;
            font-size: 24px;
            padding-bottom: 20px;
        }

        .upgradetext {
            font-family: Segoe UI Light, Segoe, Helvetica;
            font-size: 14px;
        }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div style="padding: 20px; width: 600px;">
        <div class="upgradeheader"><asp:Literal ID="TitleLiteral" runat="server">Upgrade Reporting Database</asp:Literal></div>
        <asp:Label ID="NotConfiguredLabel" Visible="False" CssClass="upgradetext" runat="server">There is no reporting database set up for this Site Collection.</asp:Label>
        <asp:Label ID="ConfiguredLabel" Visible="True" CssClass="upgradetext" runat="server">Click the button below to upgrade the reporting database for this Site Collection.</asp:Label>
        <br />
        <div style="padding-top: 10px;">
            <asp:Button ID="UpgradeButton" runat="server" Text="Upgrade Now" OnClick="UpgradeButtonOnClick" CssClass="button button-green" />
        </div>
        <div>
            <asp:Label ID="MessageLabel" CssClass="padding10 upgradetext" runat="server" Font-Bold="True"></asp:Label>
            <asp:Panel ID="MessagePanel" CssClass="padding10 upgradetext" runat="server">
            </asp:Panel>		
        </div>
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Upgrade Reporting Database
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    Upgrade Reporting Database
</asp:Content>