<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListLookupConfig.aspx.cs" Inherits="EPMLiveCore.Layouts.epmlive.ListLookupConfig" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    <SharePoint:SPGridView runat="server"
	    ID="gvPlans"
	    AutoGenerateColumns="false"
	    width="600"
	    AllowSorting="True"
	    AllowPaging="True"
	    PageSize="10">
        <Columns>
	        <SharePoint:SPMenuField HeaderText="Field" TextFields="displayname" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="NAME=internalname" ></SharePoint:SPMenuField>
	        <SharePoint:SPBoundField DataField="enabled" HeaderText="Enabled"></SharePoint:SPBoundField>
	        <SharePoint:SPBoundField DataField="style" HeaderText="Style"></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="cascading" HeaderText="Cascading"></SharePoint:SPBoundField>
            <SharePoint:SPBoundField DataField="security" HeaderText="Security"></SharePoint:SPBoundField>
	    </Columns>
	    <AlternatingRowStyle CssClass="ms-alternating" />
	</SharePoint:SPGridView><br />
    <a href="../listedit.aspx?List=<%=Request["List"] %>">Back to list settings</a>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Lookup Configuration
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Lookup Configuration
</asp:Content>
