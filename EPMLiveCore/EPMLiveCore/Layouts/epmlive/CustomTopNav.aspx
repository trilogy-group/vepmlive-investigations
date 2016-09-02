<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBar" Src="~/_controltemplates/ToolBar.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ToolBarButton" Src="~/_controltemplates/ToolBarButton.ascx" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomTopNav.aspx.cs" Inherits="EPMLiveCore.CustomTopNav"
    DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
 <script language="javascript">
// <![CDATA[
function ULSPvL(){var o=new Object;o.ULSTeamName="Microsoft SharePoint Foundation";o.ULSFileName="epmlive/TopNav.aspx";return o;}
  var L_InheritWarning_TEXT = "<SharePoint:EncodedLiteral runat='server' text='<%$Resources:wss,topnav_InheritWarning_TEXT%>' EncodeMethod='EcmaScriptStringLiteralEncode'/>";
  function submitOperation(operation)
  {ULSPvL:;
	  document.getElementById(<%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(hdnOperation.ClientID),Response.Output);%>).value = operation;
	  document.forms.<%SPHttpUtility.NoEncode(Form.ClientID,Response.Output);%>.submit();
  }
  function inheritTopNav()
  {ULSPvL:;
	  var warningText = L_InheritWarning_TEXT;
	  if (confirm(warningText))
		 submitOperation("topnavInherit");
  }
  function uniqueTopNav()
  {ULSPvL:;
	  submitOperation("topnavUnique");
  }
// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderMain" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%" class="ms-v4propertysheetspacing">
        <tr>
            <td>
                <wssuc:ToolBar ID="onetidNavNodesTB" runat="server">
                    <Template_Buttons>
                        <wssuc:ToolBarButton runat="server" 
                            Text="<%$Resources:wss,topnav_newlink%>" 
                            ID="idNewNavNode"
                            ToolTip="<%$Resources:wss,topnav_newlink%>" 
                            NavigateUrl="customnewnav.aspx?nodetype=topnav"
                            ImageUrl="/_layouts/images/newitem.gif"
                            AccessKey="N" />
                        <wssuc:ToolBarButton runat="server" 
                            Text="<%$Resources:wss,quiklnch_newcat%>" 
                            ID="idNewCatNode"
                            ToolTip="<%$Resources:wss,quiklnch_newcat%>" 
                            NavigateUrl="customnewnav.aspx?parentid=1002&nodetype=topnav&isheading=true"
                            ImageUrl="/_layouts/images/newitem.gif" 
                            AccessKey="G" />
                        <wssuc:ToolBarButton runat="server" 
                            ID="BtnReorderNavNodes" 
                            Text="<%$Resources:wss,topnav_changeorder%>"
                            ToolTip="<%$Resources:wss,topnav_changeorder%>" 
                            NavigateUrl="customtnreord.aspx" 
                            ImageUrl="/_layouts/images/reorder.gif"
                            AccessKey="O" />
                        <wssuc:ToolBarButton runat="server"
						    id="BtnInheritTopNav"
						    Text="<%$Resources:wss,topnav_inherit%>"
						    ToolTip="<%$Resources:wss,topnav_inherit%>"
						    NavigateUrl="javascript:inheritTopNav()"
						    ImageUrl="/_layouts/images/edit.gif"
						    AccessKey="I"/>
		                <wssuc:ToolBarButton runat="server"
						    id="BtnUniqueTopNav"
						    Text="<%$Resources:wss,topnav_unique%>"
						    ToolTip="<%$Resources:wss,topnav_unique%>"
						    NavigateUrl="javascript:uniqueTopNav()"
						    ImageUrl="/_layouts/images/delete.gif"
						    AccessKey="C"/>
                    </Template_Buttons>
                </wssuc:ToolBar>
            </td>
        </tr>
        <tr>
            <td rowspan="1" height="5">
                <img src="/_layouts/images/blank.gif" width='1' height='1' alt="" />
            </td>
        </tr>
        <tr>
            <td class="ms-descriptiontext ms-naveditor">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" id="onetidRptrTable">
                    <%  foreach( object item in _alLinkData)
                        {
                            Triplet triplet = (Triplet)(item);
                            if ((bool)triplet.Third == false)
                            { %>
                    <tr>
                        <td class="ms-vb2" width="20">
                            <img src="/_layouts/images/blank.gif" width='20' height='1' alt="" />
                        </td>
                        <td class="ms-vb2" width="20">
                            <% if (_appId != -1){ %>
                                <a onclick='<%  SPHttpUtility.HtmlUrlAttributeEncode((string) triplet.Second, Response.Output); %>'>
                            <%} else { %>
                                <a href='<%  SPHttpUtility.HtmlUrlAttributeEncode((string) triplet.Second, Response.Output); %>'>
                            <%} %>
                                <img border="0" alt="<SharePoint:EncodedLiteral runat='server' text='<%$Resources:wss,multipages_edit%>' EncodeMethod='HtmlEncode'/> <% SPHttpUtility.HtmlEncode((string)triplet.First, Response.Output); %>"
                                    src="/_layouts/images/edititem.gif"></a>
                        </td>
                        <td class="ms-vb2">
                            <% SPHttpUtility.HtmlEncode((string)triplet.First, Response.Output); %>
                        </td>
                    </tr>
                    <%  }
                else
                { %>
                    <tr>
                        <td class="ms-gb" width="20">
                            <% if (_appId != -1){ %>
                                <a onclick='<%  SPHttpUtility.HtmlUrlAttributeEncode((string) triplet.Second, Response.Output); %>'>
                            <%} else { %>
                                <a href='<%  SPHttpUtility.HtmlUrlAttributeEncode((string) triplet.Second, Response.Output); %>'>
                            <%} %>  
                                <img border="0" alt="<SharePoint:EncodedLiteral runat='server' text='<%$Resources:wss,multipages_edit%>' EncodeMethod='HtmlEncode'/> <% SPHttpUtility.HtmlEncode((string)triplet.First, Response.Output); %>"
                                    src="/_layouts/images/edititem.gif"></a>
                        </td>
                        <td colspan="2" class="ms-gb">
                            <b>
                                <h3 class="ms-standardheader">
                                    <% SPHttpUtility.HtmlEncode((string)triplet.First, Response.Output); %></h3>
                            </b>
                        </td>
                    </tr>
                    <%  }
            } %>
                </table>
            </td>
        </tr>
        <tr>
            <td rowspan="1" height="10">
                <img src="/_layouts/images/blank.gif" width='1' height='1' alt="" />
            </td>
        </tr>
        <tr>
            <td class="ms-sectionline" height="1">
                <img src="/_layouts/images/blank.gif" width='1' height='1' alt="" />
            </td>
        </tr>
    </table>
    <SharePoint:FormDigest ID="FormDigest1" runat="server" />
    <input type="hidden" name="hdnOperation" id="hdnOperation" value="" runat="server">
</asp:Content>
<%@ Register TagPrefix="wssuc" TagName="TopNavBar" Src="~/_controltemplates/TopNavBar.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderTopNavBar" runat="server">
    
            <wssuc:TopNavBar id="IdTopNavBar" runat="server" Version="4" ShouldUseExtra="true" />
      
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderHorizontalNav" runat="server" />
<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderSearchArea" runat="server" />
<asp:Content ID="Content5" ContentPlaceHolderID="PlaceHolderTitleBreadcrumb" runat="server">
    <SharePoint:UIVersionedContent ID="UIVersionedContent1" UIVersion="3" runat="server">
        <contenttemplate>
	<asp:SiteMapPath
		SiteMapProvider="SPXmlContentMapProvider"
		id="ContentMap"
		SkipLinkText=""
		NodeStyle-CssClass="ms-sitemapdirectional"
		RootNodeStyle-CssClass="s4-die"
		PathSeparator="&#160;&gt; "
		PathSeparatorStyle-CssClass = "s4-bcsep"
		runat="server" />
  </contenttemplate>
    </SharePoint:UIVersionedContent>
    <SharePoint:UIVersionedContent ID="UIVersionedContent2" UIVersion="4" runat="server">
        <contenttemplate>
	<SharePoint:ListSiteMapPath
		runat="server"
		SiteMapProviders="SPSiteMapProvider,SPXmlContentMapProvider"
		RenderCurrentNodeAsLink="false"
		PathSeparator=""
		CssClass="s4-breadcrumb"
		NodeStyle-CssClass="s4-breadcrumbNode"
		CurrentNodeStyle-CssClass="s4-breadcrumbCurrentNode"
		RootNodeStyle-CssClass="s4-breadcrumbRootNode"
		HideInteriorRootNodes="true"
		SkipLinkText="" />
  </contenttemplate>
    </SharePoint:UIVersionedContent>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    <SharePoint:EncodedLiteral ID="EncodedLiteral3" runat="server" Text="<%$Resources:wss,topnav_pagetitle%>"
        EncodeMethod='HtmlEncode' />
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    <a href="settings.aspx">
        <SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" Text="<%$Resources:wss,settings_pagetitle%>"
            EncodeMethod="HtmlEncode" /></a>&#32;<SharePoint:ClusteredDirectionalSeparatorArrow
                ID="ClusteredDirectionalSeparatorArrow1" runat="server" />
    <SharePoint:EncodedLiteral ID="EncodedLiteral2" runat="server" Text="<%$Resources:wss,topnav_pagetitle%>"
        EncodeMethod='HtmlEncode' />
</asp:Content>
