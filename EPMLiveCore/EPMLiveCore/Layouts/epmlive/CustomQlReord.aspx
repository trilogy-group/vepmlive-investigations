<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.Navigation" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssawc" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomQlReord.aspx.cs" Inherits="EPMLiveCore.CustomQlReord"
    DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    <SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" Text="<%$Resources:wss,quiklnch_pagetitle%>"
        EncodeMethod='HtmlEncode' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script language="JavaScript">
// <![CDATA[
        function ULSIPM() { var o = new Object; o.ULSTeamName = "Microsoft SharePoint Foundation"; o.ULSFileName = "QLReord.aspx"; return o; }
        var strItem = "Item";
        var strItemOrder = "ItemOrder";
        function Reorder(tableId, itemIndex, value, numItems) {
            ULSIPM: ;
            var itemObj = document.getElementById(strItemOrder + tableId + itemIndex);
            var oldPos = itemObj.value;
            var newPos = value.substring(0, value.indexOf('_'));
            var parentId = value.substring(value.indexOf('_') + 1);
            itemObj.value = newPos;
            document.getElementById("MovedItems").value +=
		parentId + "," + oldPos + "," + newPos + ";"
            if (newPos != oldPos) {
                var iInc = Number(newPos) > Number(oldPos) ? -1 : 1;
                var iMin = Math.min(newPos, oldPos);
                var iMax = Math.max(newPos, oldPos);
                var iPrevIndex = newPos > oldPos ? newPos : newPos - 1;
                for (var i = 0; i < numItems; i++) {
                    if (i != itemIndex) {
                        var iSelect = document.getElementById(strItem + tableId + i);
                        if (iSelect.selectedIndex >= iMin && iSelect.selectedIndex <= iMax) {
                            iSelect.selectedIndex += iInc;
                            var iItemObj = document.getElementById(strItemOrder + tableId + i);
                            var val = Number(iItemObj.value);
                            iItemObj.value = val + iInc;
                        }
                    }
                }
            }
            if (browseris.ie5up && browseris.win) {
                document.getElementById("ItemTable" + tableId).moveRow(Number(oldPos), Number(newPos));
            }
        }
// ]]>
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    <a href="settings.aspx">
        <SharePoint:EncodedLiteral ID="EncodedLiteral2" runat="server" Text="<%$Resources:wss,settings_pagetitle%>"
            EncodeMethod="HtmlEncode" /></a>&#32;<SharePoint:ClusteredDirectionalSeparatorArrow
                ID="ClusteredDirectionalSeparatorArrow1" runat="server" />
    <SharePoint:EncodedLiteral ID="EncodedLiteral3" runat="server" Text="<%$Resources:wss,quiklnch_pagetitle%>"
        EncodeMethod='HtmlEncode' />
    &#32;<SharePoint:ClusteredDirectionalSeparatorArrow ID="ClusteredDirectionalSeparatorArrow2"
        runat="server" />
    <SharePoint:EncodedLiteral ID="EncodedLiteral4" runat="server" Text="<%$Resources:wss,quiklnchreord_pagetitle%>"
        EncodeMethod='HtmlEncode' />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageDescription" runat="server">
    <SharePoint:EncodedLiteral ID="EncodedLiteral5" runat="server" Text="<%$Resources:wss,tnreord_ql_description%>"
        EncodeMethod='HtmlEncode' />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td rowspan='1' height='5'>
                <img src="/_layouts/images/blank.gif" width='1' height='1' alt="" />
            </td>
        </tr>
        <tr>
            <td class="ms-descriptiontext" style="padding-left: 3px;">
                <table class="ms-authoringControls" cellspacing="0" border="0" width="100%" id="ItemTable"
                    cols="3">
                    <%
                        if ((_spNavCollQuickLaunch != null) && (_spNavCollQuickLaunch.Count > 0))
                        {
                            SPNavigationNode spNode = null;
                            SPNavigationNode spNodeChild = null;
                            string strParentId;
                            int j = 0;
                            for (int ix = 0; ix < _spNavCollQuickLaunch.Count; ix++)
                            {
                                spNode = _spNavCollQuickLaunch[ix];
                                strParentId = spNode.ParentId.ToString();
                    %>
                    <tr>
                        <td colspan="3">
                            <table class="ms-authoringControls" cellspacing="0" border="0" width="100%" cols="3">
                                <tr>
                                    <td width="40">
                                        <input type="hidden" id='ItemOrder<%SPHttpUtility.NoEncode(ix, Response.Output);%>'
                                            name='ItemOrder<%SPHttpUtility.NoEncode(ix, Response.Output);%>' value='<%SPHttpUtility.NoEncode(ix, Response.Output);%> '>
                                        <select title='<%SPHttpUtility.HtmlEncode(spNode.Title, Response.Output);%>' id='Item<%SPHttpUtility.NoEncode(ix, Response.Output);%>'
                                            name='Item<%SPHttpUtility.NoEncode(ix, Response.Output);%>' onchange='Reorder("",
									<%SPHttpUtility.NoEncode(ix, Response.Output);%>,
									this.value,
									<%SPHttpUtility.NoEncode(_spNavCollQuickLaunch.Count,Response.Output);%> );'>
                                            <% for (j = 0; j < _spNavCollQuickLaunch.Count; j++)
                                               {
                                                   SPHttpUtility.NoEncode("<option value=\"", Response.Output);
                                                   SPHttpUtility.NoEncode(j, Response.Output);
                                                   SPHttpUtility.NoEncode("_", Response.Output);
                                                   SPHttpUtility.NoEncode(strParentId, Response.Output);
                                                   SPHttpUtility.NoEncode("\"", Response.Output);
                                                   if (ix == j)
                                                       SPHttpUtility.NoEncode(" selected=\"true\"", Response.Output);
                                                   SPHttpUtility.NoEncode(">", Response.Output);
                                                   SPHttpUtility.NoEncode(j + 1, Response.Output);
                                                   SPHttpUtility.NoEncode("</option>", Response.Output);
                                               }
                                            %>
                                        </select>
                                    </td>
                                    <td colspan="2">
                                        <% SPHttpUtility.HtmlEncode(spNode.Title, Response.Output); %>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <table class="ms-authoringControls" style="margin-top: 5px; margin-bottom: 5px;"
                                            cellspacing="0" border="0" width="100%" id="ItemTable<%SPHttpUtility.NoEncode(spNode.Id.ToString(), Response.Output);%>"
                                            cols="3">
                                            <%
                                                for (int jx = 0; jx < spNode.Children.Count; jx++)
                                                {
                                                    spNodeChild = spNode.Children[jx];
                                                    strParentId = spNodeChild.ParentId.ToString();
                                            %>
                                            <tr>
                                                <td width="40">
                                                    <img src="/_layouts/images/blank.gif" width='40' height='1' alt="" />
                                                </td>
                                                <td width="40">
                                                    <input type="hidden" id='ItemOrder<%SPHttpUtility.NoEncode(strParentId, Response.Output);%><%SPHttpUtility.NoEncode(jx, Response.Output);%>'
                                                        name='ItemOrder<%SPHttpUtility.NoEncode(strParentId, Response.Output);%><%SPHttpUtility.NoEncode(jx, Response.Output);%>'
                                                        value='<%SPHttpUtility.NoEncode(jx, Response.Output);%> '>
                                                    <select title='<%SPHttpUtility.HtmlEncode(spNodeChild.Title, Response.Output);%>'
                                                        id='Item<%SPHttpUtility.NoEncode(strParentId, Response.Output);%><%SPHttpUtility.NoEncode(jx, Response.Output);%>'
                                                        name='Item<%SPHttpUtility.NoEncode(strParentId, Response.Output);%><%SPHttpUtility.NoEncode(jx, Response.Output);%>'
                                                        onchange='Reorder("<%SPHttpUtility.NoEncode(strParentId, Response.Output);%>",
									<%SPHttpUtility.NoEncode(jx, Response.Output);%>,
									this.value,
									<%SPHttpUtility.NoEncode(spNode.Children.Count,Response.Output);%>);'>
                                                        <% for (j = 0; j < spNode.Children.Count; j++)
                                                           {
                                                               SPHttpUtility.NoEncode("<option value=\"", Response.Output);
                                                               SPHttpUtility.NoEncode(j, Response.Output);
                                                               SPHttpUtility.NoEncode("_", Response.Output);
                                                               SPHttpUtility.NoEncode(strParentId, Response.Output);
                                                               SPHttpUtility.NoEncode("\"", Response.Output);
                                                               if (jx == j)
                                                                   SPHttpUtility.NoEncode(" selected=\"true\"", Response.Output);
                                                               SPHttpUtility.NoEncode(">", Response.Output);
                                                               SPHttpUtility.NoEncode(j + 1, Response.Output);
                                                               SPHttpUtility.NoEncode("</option>", Response.Output);
                                                           }
                                                        %>
                                                    </select>
                                                </td>
                                                <td>
                                                    <% SPHttpUtility.HtmlEncode(spNodeChild.Title, Response.Output); %>
                                                </td>
                                            </tr>
                                            <%
                                                }
                                            %>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ms-sectionline" style="padding: 0px;" height="1" colspan="3">
                                        <img src="/_layouts/images/blank.gif" width='1' height='1' alt="" />
                                    </td>
                                </tr>
                            </table>
                    </tr>
                    <%
}
                    %>
                </table>
                <input type="hidden" id="MovedItems" name="MovedItems" value="">
                <%
                    }
                %>
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
        <wssuc:ButtonSection ShowSectionLine="false" runat="server" ShowStandardCancelButton="false" >
            <Template_Buttons>
                <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth"
                    OnClick="OnSubmit" Text="<%$Resources:wss,multipages_okbutton_text%>" ID="BtnOk"
                    AccessKey="<%$Resources:wss,okbutton_accesskey%>" />
                <asp:Button UseSubmitBehavior="false" runat="server" class="ms-ButtonHeightWidth"
                    Text="Cancel" ID="BtnCancel" CausesValidation="false" />
            </Template_Buttons>
        </wssuc:ButtonSection>
    </table>
    <SharePoint:FormDigest ID="FormDigest1" runat="server" />
    <script type="text/javascript">
        var asyncNavActionsUrl = '<%=_async_nav_actions_url %>';
        var actionMoveNode = '<%=_actionMoveNode %>';
        var nodeType = '<%=_nodeType %>';
        var appId = '<%=_appId %>';

        function AsyncMoveNode() {
            var moveInfos = document.getElementById("MovedItems").value;

            var postData = {
                action: actionMoveNode,
                nodetype: nodeType,
                appid: appId,
                moveinfos: moveInfos
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
<asp:Content ID="Content6" ContentPlaceHolderID="PlaceHolderTopNavBar" runat="server">
    <wssuc:TopNavBar ID="IdTopNavBar" runat="server" Version="4" ShouldUseExtra="true" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="PlaceHolderHorizontalNav" runat="server" />
<asp:Content ID="Content8" ContentPlaceHolderID="PlaceHolderSearchArea" runat="server" />
<asp:Content ID="Content9" ContentPlaceHolderID="PlaceHolderTitleBreadcrumb" runat="server">
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
