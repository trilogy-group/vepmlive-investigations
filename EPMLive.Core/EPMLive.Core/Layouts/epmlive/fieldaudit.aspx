<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.fieldaudit" MasterPageFile="~/_layouts/application.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	Field Audit
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	Field Audit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to determine the field types of lists this list is rolling up from.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">

        <asp:DataGrid runat="server"
	 ID="GvItems"
	 AutoGenerateColumns="true" 
	 width="100%" ItemStyle-CssClass="ms-vb2" 
	  HeaderStyle-Wrap="false"
	  ItemStyle-Wrap="false"
	  AlternatingItemStyle-Wrap ="false"
	 AlternatingItemStyle-CssClass="ms-alternating" 
	 HeaderStyle-CssClass="ms-viewheadertr"
	 HeaderStyle-BackColor="gainsboro"
	  HeaderStyle-Font-Bold="true"
	   CellPadding="4"
	 CssClass="ms-vb2">
	 </Asp:DataGrid>
	 
</asp:Content>