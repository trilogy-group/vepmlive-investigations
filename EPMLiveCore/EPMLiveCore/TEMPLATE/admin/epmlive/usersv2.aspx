<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usersv2.aspx.cs" Inherits="EPMLiveCore.Layouts.EPMLiveCore.usersv2" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">

    Feature: <%=sFeature %>
    <br /><br />
    <b>Usage: </b><asp:Label ID="lblUsage" runat="server" Text="Label"></asp:Label> / <asp:Label ID="lblMaxUsers" runat="server" Text="Label"></asp:Label>
    <SharePoint:SPGridView runat="server"
	 ID="GvItems"
	 AutoGenerateColumns="false"
	 style="width:200px">
    <Columns>
	    <SharePoint:SPMenuField HeaderText="User" TextFields="username" MenuTemplateId="PropertyNameListMenu" TokenNameAndValueFields="NAME=encusername"  ></SharePoint:SPMenuField>
	 </Columns>
	 <AlternatingRowStyle CssClass="ms-alternating" />
	 </SharePoint:SPGridView>
    <br />
    <asp:Label ID="lblConnError" runat="server" Text="" ForeColor="Red" Visible ="false" ></asp:Label>

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Manage Users
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Manage Users
</asp:Content>
