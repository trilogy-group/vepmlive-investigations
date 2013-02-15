<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDatabases.aspx.cs" Inherits="EPMLiveReportsAdmin.Layouts.EPMLive.ReportDatabases" DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="~/_controltemplates/ToolBarButton.ascx" %>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    EPM Live Reporting
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    Mapped Sites
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    This is a list of sites that are currently dynamically mapped to a reporting database.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    
    
    <wssuc:ToolBar id="Toolbar" runat="server">
        <template_buttons>
		<wssuc:ToolBarButton runat="server"
			id="AddMapping"
			Text="Add Mapping"
			ToolTip=""
    		OnClick="AddMapping_Click"
			ImageUrl="/_layouts/images/newitem.gif"
			Padding="2px"
			AccessKey="V" />			
	</template_buttons>
        <template_rightbuttons>
        <SharePoint:WebApplicationSelector ID="WebApplicationSelector1" runat="server" AllowChange="true" OnContextChange="WebApplicationSelector1_ContextChange" />
	</template_rightbuttons>
    </wssuc:ToolBar>
    
       <SharePoint:MenuTemplate ID="mtEventMenu" runat="server"> 
      <SharePoint:MenuItemTemplate ID="MenuItemTemplate2" runat="server"
           Text="Delete" ImageUrl="/_layouts/images/delete.gif"         
           ClientOnClickPostBackConfirmation="Are you sure you want to delete this item?"
           ClientOnClickNavigateUrl="ReportDatabases.aspx?DeleteID=%ID%&WebAppId=%WebAppId%"    
           Title="Delete">
      </SharePoint:MenuItemTemplate>
  </SharePoint:MenuTemplate>
    
    <SharePoint:SPGridView ID="GridView1" runat="server" 
        AutoGenerateColumns="false"
        HeaderStyle-CssClass="ms-vh2-nofilter ms-vh2-gridview"
         >
        <Columns>
            <SharePoint:SPMenuField
                  HeaderText="Site Collection"
                  TextFields="Url"
                  MenuTemplateId="mtEventMenu"   
                  ToolTipFields="Url"
                  NavigateUrlFields="Url"
                  NavigateUrlFormat="{0}"     
                  TokenNameAndValueFields="ID=SiteId,WebAppId=WebApplicationId"
            />
               
            <SharePoint:SPBoundField DataField="SiteId" HeaderText="SiteId" Visible="false" />
            <SharePoint:SPBoundField DataField="WebApplicationId" HeaderText="WebApplicationId" Visible="false" />
            <SharePoint:SPBoundField DataField="DatabaseServer" HeaderText="DatabaseServer" />
            <SharePoint:SPBoundField DataField="DatabaseName" HeaderText="DatabaseName" />
            <%--<SharePoint:SPBoundField DataField="Version" HeaderText="Version" />--%>
        </Columns>
    </SharePoint:SPGridView>
    <asp:Label runat="server" ID="message" Visible="false" CssClass="ms-descriptiontext"></asp:Label>
</asp:Content>

