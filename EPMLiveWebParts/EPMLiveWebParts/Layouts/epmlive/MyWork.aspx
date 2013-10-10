<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWork.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.MyWork" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="EPMLive" Namespace="EPMLiveWebParts" Assembly="EPMLiveWebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <SharePoint:StyleBlock runat="server">
        .ms-WPBorder {
            border:none;
        }
    </SharePoint:StyleBlock>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <EPMLive:MyWorkWebPart runat="server" __MarkupType="xmlmarkup" WebPart="true" __WebPartId="{B130AD40-A4E8-408D-B59F-E1FB30A36044}" >
        <WebPart xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/WebPart/v2">
            <Title>My Work</Title>
            <FrameType>Default</FrameType>
            <Description />
            <IsIncluded>true</IsIncluded>
            <ZoneID>Header</ZoneID>
            <PartOrder>2</PartOrder>
            <FrameState>Normal</FrameState>
            <Height />
            <Width />
            <AllowRemove>true</AllowRemove>
            <AllowZoneChange>true</AllowZoneChange>
            <AllowMinimize>true</AllowMinimize>
            <AllowConnect>true</AllowConnect>
            <AllowEdit>true</AllowEdit>
            <AllowHide>true</AllowHide>
            <IsVisible>true</IsVisible>
            <DetailLink />
            <HelpLink />
            <HelpMode>Modeless</HelpMode>
            <Dir>Default</Dir>
            <PartImageSmall />
            <MissingAssembly>Cannot import this Web Part.</MissingAssembly>
            <PartImageLarge>/_layouts/images/wpepmlive.gif</PartImageLarge>
            <IsIncludedFilter />
            <ExportControlledProperties>true</ExportControlledProperties>
            <ConnectionID>00000000-0000-0000-0000-000000000000</ConnectionID>
            <ID>g_790ccaa2_6ae3_4990_84cc_f85160655fd7</ID>
            <AllowEditToggle xmlns="MyWork">false</AllowEditToggle>
            <CrossSiteUrls xmlns="MyWork" />
            <DefaultGlobalView xmlns="MyWork" />
            <DefaultToEditMode xmlns="MyWork">false</DefaultToEditMode>
            <DueDayFilter xmlns="MyWork" />
            <HideNewButton xmlns="MyWork">false</HideNewButton>
            <MyWorkSelectedLists xmlns="MyWork" />
            <NewItemIndicator xmlns="MyWork" />
            <PerformanceMode xmlns="MyWork">false</PerformanceMode>
            <SelectedFields xmlns="MyWork" />
            <SelectedLists xmlns="MyWork" />
            <ShowToolbar xmlns="MyWork">false</ShowToolbar>
            <UseCentralizedSettings xmlns="MyWork">true</UseCentralizedSettings>
        </WebPart>
    </EPMLive:MyWorkWebPart>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    My Work
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
    My Work
</asp:Content>