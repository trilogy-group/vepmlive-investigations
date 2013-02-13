<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.adminviewqueue" MasterPageFile="~/_admin/admin.master"%> 

<%@ Register TagPrefix="wssuc" TagName="ButtonSection" src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register Tagprefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	WorkEngine Queue Details
</asp:Content>
<asp:content ID="Content1" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
	WorkEngine Queue Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageDescription" runat="server">
    Use this page to manage your WorkEngine Queue Details.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderId="PlaceHolderMain" runat="server">


<b>Job Name: </b><asp:Label ID="lblJobName" runat="server" Text=""></asp:Label><br />
<b>Web: </b><asp:Label ID="lblWeb" runat="server" Text=""></asp:Label><br />
<b>List: </b><asp:Label ID="lblList" runat="server" Text=""></asp:Label><br />
<b>Job Type: </b><asp:Label ID="lblJobType" runat="server" Text=""></asp:Label><br />
<b>Status: </b><asp:Label ID="lblStatus" runat="server" Text=""></asp:Label><br />
<b>Finished: </b><asp:Label ID="lblFinished" runat="server" Text=""></asp:Label><br />
<b>Queue Wait: </b><asp:Label ID="lblWait" runat="server" Text=""></asp:Label><br />
<b>Job Length: </b><asp:Label ID="lblJobLength" runat="server" Text=""></asp:Label><br />

<br />
<b>Messages: </b><br /><asp:Label ID="lblErrors" runat="server" Text=""></asp:Label><br /><br />

</asp:Content>