<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<%@ Page Language="C#" 
    DynamicMasterPageFile="~masterurl/default.master" 
    AutoEventWireup="true" 
    Inherits="EPMLiveSynch.ViewLogEntryPage" 
    CodeBehind="viewlogentry.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral ID="lt1" runat="server" text="View Log Entry" EncodeMethod='HtmlEncode'/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
	<asp:Label ID="lblTitle" runat="server" Text="View Log Entry"></asp:Label>
	<asp:Label ID="lblLogDateTime" Visible="false" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="PlaceHolderMain" runat="server">   
    <asp:Label ID="lblLogEntry" Height="100%" Width="100%" runat="server" Text=""></asp:Label>
    <wssuc:ButtonSection runat="server">
        <Template_Buttons>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            <asp:Button ID="btnShowAllItems" runat="server" Text="Show All Items" OnClick="btnShowAllItems_Click" CssClass="ms-ButtonHeightWidth" style="width:150px"></asp:Button>
            </asp:PlaceHolder>
        </Template_Buttons>
    </wssuc:ButtonSection>
</asp:Content>
