<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%--<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/CustomTopLink/CustomButtonSection.ascx" %>--%>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomNewNav.aspx.cs" Inherits="EPMLiveCore.CustomNewNav"
    DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
 <script type="text/javascript">
// <![CDATA[
function ULSs18(){var o=new Object;o.ULSTeamName="Microsoft SharePoint Foundation";o.ULSFileName="NewNav.aspx";return o;}
function _spBodyOnLoad()
{ULSs18:;
	try
	{
		document.getElementById(<%SPHttpUtility.AddQuote(SPHttpUtility.NoEncode(txtUrl.ClientID),Response.Output);%>).focus();
	}
	catch (e)
	{
	}
}
function DeleteNodeConfirmation()
{ULSs18:;
	return confirm("<SharePoint:EncodedLiteral runat='server' text='<%$Resources:wss,newnav_deletenodewarning%>' EncodeMethod='EcmaScriptStringLiteralEncode'/>");
}
// ]]>
    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<table border="0" width="100%" cellspacing="0" cellpadding="0" class="ms-descriptiontext">
        <wssuc:InputFormSection runat="server" Title="<%$Resources:wss,nav_url%>">
            <template_inputformcontrols>
		<wssuc:InputFormControl runat="server" LabelText="<%$Resources:wss,navedit_address%>">
			<Template_Control>
			<wssawc:InputFormTextBox title="<%$Resources:wss,nav_url%>" class="ms-long" maxlength="255" ID="txtUrl" Direction="LeftToRight" Runat="server" />
			<wssawc:InputFormRequiredFieldValidator ID="txtUrlValidator" ControlToValidate="txtUrl" Display="Dynamic" Runat="server"/>
			<wssawc:InputFormRequiredFieldValidator ID="txtUrlValidatorHttp" ControlToValidate="txtUrl" Display="Dynamic" Runat="server"/>
			</Template_Control>
		</wssuc:InputFormControl>
		<wssuc:InputFormControl runat="server" LabelText="<%$Resources:wss,navedit_description%>">
			<Template_Control>
			<wssawc:InputFormTextBox title="<%$Resources:wss,lstsetng_desc_title%>" class="ms-long" maxlength="255" ID="txtTitle" Runat="server" />
			</Template_Control>
		</wssuc:InputFormControl>
	</template_inputformcontrols>
        </wssuc:InputFormSection>
        <wssuc:InputFormSection runat="server" id="CategorySection" Title="<%$Resources:wss,nav_cat%>">
            <template_inputformcontrols>
		<wssuc:InputFormControl runat="server">
			<Template_Control>
				<asp:DropDownList ID="ddlNavigationHeadings" ToolTip="<%$Resources:wss,nav_cat%>" runat="server"/>
			</Template_Control>
		</wssuc:InputFormControl>
	</template_inputformcontrols>
        </wssuc:InputFormSection>       
<%--start wssuc:ButtonSection--%>
        <tr>
            <td height="2px" class="ms-sectionline" colspan="2">
                <img src="/_layouts/images/blank.gif" width='1' height='1' alt="" />
            </td>
        </tr>
        <tr>
            <td height="10px" class="ms-descriptiontext" colspan="2">
                <img src="/_layouts/images/blank.gif" width='1' height='10' alt="" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <colgroup>
                        <col width="99%" />
                        <col width="1%" />
                    </colgroup>
                    <tr>
                        <td>
                            &#160;
                        </td>
                        <td nowrap="nowrap">                                  
                            <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" Text="OK" id="BtnOk" />            
                            <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth" Text="Cancel" id="BtnCancel" CausesValidation="false" />                           
                        </td>
                    </tr>
                </table>
            </td>
        </tr>       
<%--end wssuc:ButtonSection--%>    
    </table>
    <%--<script type="text/javascript" src="jQueryLibrary/jquery-1.6.2.min.js"></script>--%>
    <script type="text/javascript">
        var webUrl = '<%=_webUrl %>';
        var asyncNavActionsUrl = '<%=_async_nav_actions_url %>';
        var action = '<%=_createAction %>';
        var nodeType = '<%=_nodeType %>';
        var tbTextClientId = '<%=txtTitle.ClientID %>';
        var tbUrlClientId = '<%=txtUrl.ClientID %>';
        var appId = '<%=_appId %>';
        var ddlNavigationHeadingsClientId = '<%=ddlNavigationHeadings.ClientID %>';
        var origUserId = '<%=_origUserId %>';

        function AsyncAddHeading() {
            var title = $('#' + tbTextClientId).val();
            var url = $('#' + tbUrlClientId).val();
            var headingNodeId = $('#' + ddlNavigationHeadingsClientId).val();

            if (title == '') {
                title = url;
            }

            var postData = {
                action: action,
                title: title,
                url: url,
                nodetype: nodeType,
                headingnodeid: headingNodeId,
                appid: appId,
                origUserId: origUserId
            };

            $.post(webUrl + asyncNavActionsUrl, postData, function (data) {
                if (data.indexOf('success') != -1) {
                    SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', '1', '');
                    return false;
                }
                else {
                    alert(data);
                    return false;
                }
            });
        }


    </script>
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

<asp:Content ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    <SharePoint:EncodedLiteral ID="NewLink" Text="<%$Resources:wss,topnav_newlink%>"
        EncodeMethod="HtmlEncode" runat="server" />
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    <a href="settings.aspx">
        <SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" Text="<%$Resources:wss,settings_pagetitle%>"
            EncodeMethod="HtmlEncode" /></a>&#32;<SharePoint:ClusteredDirectionalSeparatorArrow ID="ClusteredDirectionalSeparatorArrow1"
                runat="server" />
    <%
        if (_parentNode == null || _parentNode.Id == 1025)
        {
    %>
    <SharePoint:EncodedLiteral ID="EncodedLiteral2" runat="server" Text="<%$Resources:wss,quiklnch_pagetitle%>"
        EncodeMethod='HtmlEncode' />
    &#32;<SharePoint:ClusteredDirectionalSeparatorArrow ID="ClusteredDirectionalSeparatorArrow2" runat="server" />
    <%
        }
    else
    {
    %>
    <SharePoint:EncodedLiteral ID="EncodedLiteral3" runat="server" Text="<%$Resources:wss,topnav_pagetitle%>"
        EncodeMethod='HtmlEncode' />
    &#32;<SharePoint:ClusteredDirectionalSeparatorArrow ID="ClusteredDirectionalSeparatorArrow3" runat="server" />
    <%
        }
    %>
    <SharePoint:EncodedLiteral ID="NewLinkInTitleArea" Text="<%$Resources:wss,topnav_newlink%>"
        EncodeMethod="HtmlEncode" runat="server" />
</asp:Content>
