<%@ Assembly Name="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%> 
<%@ Page Language="C#" Inherits="EPMLiveCore.ListDisplayPage" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="~/_controltemplates/ToolBarButton.ascx" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ID="Content4" ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
		<SharePoint:FormattedStringWithListType ID="FormattedStringWithListType2" runat="server"
		String="Editable Fields:" LowerCase="false" /><%SPHttpUtility.HtmlEncode(CurrentList.Title, Response.Output);%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
	<SharePoint:FormattedStringWithListType ID="FormattedStringWithListType1" runat="server"
		String="Editable Fields:" LowerCase="false" />
	<a id=onetidListHlink HREF=<% SPHttpUtility.AddQuote(SPHttpUtility.UrlPathEncode(CurrentList.DefaultViewUrl,true),Response.Output);%>><%SPHttpUtility.HtmlEncode(CurrentList.Title, Response.Output);%></a>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <%= RenderPage() %>
    <div style="float:right;margin-top:10px;">
        <asp:Button ID="OK" runat="server" OnClientClick="javascript:ComputeFields();" Text="OK" OnClick="SaveCustomDisplay" CssClass="ms-ButtonHeightWidth" />
        <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="ms-ButtonHeightWidth" />
    </div>    
</asp:Content>
