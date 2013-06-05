<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateNewWorkspace.aspx.cs"
    Inherits="EPMLiveCore.CreateNewWorkspace" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <%--external css--%>
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid.css" />
    <link rel="STYLESHEET" type="text/css" href="dhtml/xgrid/dhtmlxgrid_skins.css" />
    <link rel="Stylesheet" type="text/css" href="CreateNewWorkspace.css" />
    <!--[if IE]>
    <style type="text/css">
        .rightDivBtnCreate, .rightDivBtnMoreLessOpt, .rightDivBtnMoreInfo
        {
            width: auto !important;
            padding: 0em 0.3em 0.3em !important;
            float: left;
        }
    </style>
    <![endif]-->
    <%--external javascript--%>
    <script>        _css_prefix = "DHTML/xgrid/"; _js_prefix = "DHTML/xgrid/"; </script>
    <script src="DHTML/xgrid/dhtmlxcommon.js"></script>
    <script src="DHTML/xgrid/dhtmlxgrid.js"></script>
    <script src="DHTML/xgrid/dhtmlxgridcell.js"></script>
    <script src="DHTML/xtreegrid/dhtmlxtreegrid.js"></script>
    
    <script src="newapp.js"></script>
    <script type="text/javascript" src="jQueryLibrary/jquery-1.5.2.js"></script>
    <script src="javascripts/libraries/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="jQueryLibrary/jquery.sharepoint-json.js"></script>
    <script type="text/javascript" src="jQueryLibrary/xml2json.js"></script>
    <script src="javascripts/libraries/jquery.placeholder.min.js" type="text/javascript"></script>
    <script src="javascripts/libraries/slimScroll.js" type="text/javascript"></script>
    <script type="text/javascript">

        var siteHostName = '<%=_siteHostName %>';
        var rootSiteUrl = '<%=_siteUrl %>';
        var currentWebRelativeUrl = '<%=_currentWebRelativeUrl %>';
        var sourceWebId = '<%=_sourceWebId %>';
        var workengineSvcUrl = '<%=_workengineSvcUrl %>';
        var urlBoxId = '<%=txtURL.ClientID %>';
        var listUid = '<%=_lstGuid %>';
        var parentWebUrl = '<%=_parentWebUrl %>';
        var parentWebGuid_B = '<%=_parentWebGuid_B %>';
        var qsTemplateType = '<%=_templateType %>';
        var qsSolutionType = '<%=_solutionType %>';
        var solutionStoreProxyUrl = '<%=_solutionStoreServiceProxyUrl %>';
        var onlineFilterPnlId = '<%=pnlEPMLiveFilterBy.ClientID %>';
        var tempGalPnlId = '<%=pnlFilterBy.ClientID %>';
        var solGalPanlId = '<%=pnlSolGalFilterBy.ClientID %>';
        var includeContentClientId = '<%=_includeContentClientId %>';
        var moreInfoUrlClientId = '<%=_moreInfoUrlClientId %>';
        var featuresList = '<%=_featuresList %>';
        var newItemName = '<%=_newItemName %>';
        var newItemNameLwrCs = '<%=_newItemNameLwrCs %>';
        var hasCreateSubSitePerm = '<%=_hasCreateSubSitePerm %>';
        var defaultCreateNew = '<%=_defaultCreateNewOpt %>';
        var isOnlineTempsLoaded = 'false';
        var moreInfoUrl = '<%=_moreInfoUrl %>';
        var smallParentUrl = '<%=_smallParentUrl %>';
        var nav = '<%=_nav %>';
        var perms = '<%=_perms %>';
        var copyFrom = '<%=_copyFrom %>';
        var rListName = '<%=_rListName %>';
        var reqListName = '<%=_reqListName %>';
        var doNotDelRequest = '<%=_doNotDelRequest %>';
        var tempGalRedirect = '<%=_tempGalRedirect %>';
        var currentWebUrl = '<%=_curWebUrl %>';
        var compLevels = '<%=_compLevels %>';
        var listName = '<%=_listName %>';
        var redirectURL = '';
        var createFromLiveTemp = '<%=_createFromLiveTemp %>';
        var includeContent = '';
    </script>
    <script type="text/javascript" src="CreateNewWorkspace.js"></script>
    <div id="OuterContainer">
        <%--left div--%>
        <div class="divLeft" style="display: none">
            <div class="divWorkSpaceType">
                <%--<div class="titleWorkspaceType"></div>--%>
                <asp:Panel runat="server" ID="pnlWorkspaceType" CssClass="linkPanel">
                </asp:Panel>
            </div>
            <div class="divCreateNewWorkspaceFrom">
                <div class="titleCreateNewWorkspaceFrom">
                    Browse From:</div>
                <asp:Panel runat="server" ID="pnlCreateNewWorkspaceFrom" CssClass="linkPanel">
                </asp:Panel>
            </div>
            <%--filters from local template gallery--%>
            <div class="divFilterBy divFilter" style="display: none">
                <div class="titleFilterBy">
                    Filter By:</div>
                <asp:Panel runat="server" ID="pnlFilterBy" CssClass="linkPanel">
                    <div id="divLocalTempGalFilterLoadingGif">
                        <img src="/_layouts/15/images/gears_anv4.gif" style="vertical-align: middle" />
                        <span id="span1">Loading...</span>
                    </div>
                </asp:Panel>
            </div>
            <%--filters from online solution store--%>
            <div class="divEPMLiveTempFilters divFilter" style="display: none">
                <div class="titleFilterBy">
                    Filter By:</div>
                <asp:Panel runat="server" ID="pnlEPMLiveFilterBy" CssClass="linkPanel">
                    <div id="divOnlineSolStoreFilterLoadingGif">
                        <img src="/_layouts/15/images/gears_anv4.gif" style="vertical-align: middle" />
                        <span id="span2">Loading...</span>
                    </div>
                </asp:Panel>
            </div>
            <%--filters from Sharepoint Solution Gallery--%>
            <div class="divSolGalFilters divFilter" style="display: none">
                <div class="titleFilterBy">
                    Filter By:</div>
                <asp:Panel runat="server" ID="pnlSolGalFilterBy" CssClass="linkPanel">
                    <div id="divSPSolGalFilterLoadingGif">
                        <img src="/_layouts/15/images/gears_anv4.gif" style="vertical-align: middle" />
                        <span id="span3">Loading...</span>
                    </div>
                </asp:Panel>
            </div>
            <%--free search left panel--%>
            <div id="divfreeSearchFilter" class="divEPMLiveTempFilters divFilter" style="display: none;padding: 20px 10px 0px 10px;overflow:hidden;">
                <span id="txtFreeSearch" style="display: none"></span>
                <div class="divDivider">
                </div>
                <a id="lnkBackToAllItems" href="#" style="display: none">Back to All Items...</a>
            </div>
        </div>
        <%--center div--%>
        <div class="divCenter">
            <div class="txtAvailableTemplates" style="width: 100%; text-align: left; margin-bottom: 2px; display: none; border-bottom: 1px solid #999999;">
                <b>Available Templates</b>
            </div>
            <%--loading gif for loading EPMLive.com templates--%>
            <div id="divLoad_LoadingOnlineTemps" style="width: 100%; text-align: center;">
                <img src="/_layouts/15/images/gears_anv4.gif" style="vertical-align: middle" />
                Loading templates...
            </div>
            <div id="divOnlineTempsHolder" class="divOnlineTempsHolder" style="display: none">
                <%--this is where template divs get inserted--%>
            </div>
            <div id="divTemplatesHolder" class="divTemplatesHolder" style="display: none">
                <%--this is where template divs get inserted--%>
            </div>
            <div id="divSolGalTempsHolder" class="divSolGalTempsHolder" style="display: none">
                <%--this is where template divs get inserted--%>
            </div>
            <div id="divEmptyGalleryHTML" class="divEmptyGalleryHTML" style="display: none">
                <%--place html content here to display in the case of empty template gallery--%>
            </div>
            <%--more options page html--%>
            <div id="divMoreOptContainer" class="divMoreOptContainer" style="display: none">
                <table border="0" cellspacing="0" cellpadding="0" class="ms-propertysheet">
                    <wssuc:InputFormSection ID="Inputformsection1" Title="Enter Workspace URL" Description="Type a title and url for your new site. The title will be displayed on each page in the site."
                        runat="server" width="10">
                        <Template_InputFormControls>
                            <%--<img src="/_layouts/images/blank.gif" width="600px" height="1" />--%>
                            <wssuc:InputFormControl ID="InputFormControl1" LabelText="URL" runat="server">
                                <Template_Control>
                                    <span id="spanParentSiteUrl">
                                        <%=this._baseURL%></span><br />
                                    <asp:TextBox Title="URL" class="ms-input inputSearch" ID="txtURL" Columns="25" Name="txtURL"
                                        Text="" runat="server" MaxLength="255" />
                                    <div style="clear: both; height: 1em">
                                    </div>
                                    <a id="lnkChangeUrlPopup" href="#" onclick="return false;">Change Parent Site</a>
                                    <%--<div id="htmlGrdChangeParentUrl" style="width: 600; height: 300; display:none">
                                </div>--%>
                                    <asp:Panel ID="pnlURL" runat="server" Visible="false">
                                        <font color="red">Please enter a URL.</font></asp:Panel>
                                    <asp:Panel ID="pnlURLBad" runat="server" Visible="false">
                                        <font color="red">URL must contain only letters and numbers.</font></asp:Panel>
                                    <asp:Panel ID="pnlNotExist" runat="server" Visible="false">
                                        <font color="red">That site does not exist.</font></asp:Panel>
                                </Template_Control>
                            </wssuc:InputFormControl>
                        </Template_InputFormControls>
                    </wssuc:InputFormSection>
                    <wssuc:InputFormSection ID="InputformsectionTopNavInheritance" Title="Navigation Inheritance"
                        Description="Specify whether this site shares the same top link bar as the parent. This setting may also determine the starting element of the breadcrumb."
                        runat="server" width="10">
                        <Template_InputFormControls>
                            <%--<img src="/_layouts/images/blank.gif" width="600" height="1" />--%>
                            <wssuc:InputFormControl ID="InputFormControl2" LabelText="" runat="server">
                                <Template_LabelText>
                                    <img src="/_layouts/images/topnav.gif" align="left" />
                                    Use the top link bar from the parent site?
                                </Template_LabelText>
                                <Template_Control>
                                    <%--<asp:RadioButton ID="rdoTopLinkYes" Text="Yes" Checked="true" GroupName="TopLink" />
                                    <asp:RadioButton ID="rdoTopLinkNo" runat="server" Text="No" GroupName="TopLink" />--%>
                                    <input type="radio" name="rdoTopLink" value="Yes" />Yes
                                    <input type="radio" name="rdoTopLink" value="No" />No
                                </Template_Control>
                            </wssuc:InputFormControl>
                        </Template_InputFormControls>
                    </wssuc:InputFormSection>
                    <wssuc:InputFormSection ID="InputformsectionPermission" Title="<%$Resources:wss,newsbweb_idInputTitleContent%>"
                        Description="<%$Resources:wss,newsbweb_idInputDescriptionContent%>" runat="server"
                        width="10">
                        <Template_InputFormControls>
                            <wssuc:InputFormControl ID="InputFormControl3" LabelText="<%$Resources:wss,newsbweb_idInputLabelPermissions%>"
                                SmallIndent="true" runat="server">
                                <Template_Control>
                                    <table border="0" width="100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" width="1px">
                                                <%--<asp:RadioButton ID="rdoInherit" runat="server" GroupName="perms" />--%>
                                                <input type="radio" name="perms" />
                                            </td>
                                            <td width="1px">
                                                <img src="/_layouts/images/blank.gif" width="1" height="1" alt="">
                                            </td>
                                            <td nowrap class="ms-authoringcontrols">
                                                <%--<SharePoint:EncodedLiteral ID="EncodedLiteral2" runat="server" Text="<%$Resources:wss,newsbweb_usesameperm%>"
                                                    EncodeMethod='HtmlEncode' />--%>
                                                <SharePoint:EncodedLiteral ID="EncodedLiteral2" runat="server" Text="Inherit parent site permission"
                                                    EncodeMethod='HtmlEncode' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="1px">
                                                <%--<asp:RadioButton ID="rdoUnique" runat="server" GroupName="perms" Checked="true" />--%>
                                                <input type="radio" name="perms" />
                                            </td>
                                            <td width="1px">
                                                <%--<img src="/_layouts/images/blank.gif" width="600px" height="1" alt="">--%>
                                            </td>
                                            <td nowrap class="ms-authoringcontrols">
                                                <SharePoint:EncodedLiteral ID="EncodedLiteral3" runat="server" Text="<%$Resources:wss,newsbweb_useuniqueperm%>"
                                                    EncodeMethod='HtmlEncode' />
                                            </td>
                                        </tr>
                                    </table>
                                </Template_Control>
                            </wssuc:InputFormControl>
                        </Template_InputFormControls>
                    </wssuc:InputFormSection>
                    <wssuc:InputFormSection ID="InputformsectionIncludeContent" Title="Include content"
                        Description="Specify whether this site inherits content from site it was created from."
                        runat="server" width="10">
                        <Template_InputFormControls>
                            <%--<img src="/_layouts/images/blank.gif" width="600" height="1" />--%>
                            <wssuc:InputFormControl ID="InputFormControl4" LabelText="" runat="server">
                                <Template_LabelText>
                                    Inherit content from parent site?
                                </Template_LabelText>
                                <Template_Control>
                                    <input type="radio" name="rdoIncludeContent" value="Yes" />Yes
                                    <input type="radio" name="rdoIncludeContent" value="No" />No
                                </Template_Control>
                            </wssuc:InputFormControl>
                        </Template_InputFormControls>
                    </wssuc:InputFormSection>
                </table>
            </div>
            <%--existing workspace--%>
            <div id="divExistingWorkspaceContainer" class="divExistingWorkspaceContainer" style="display: none">
                <h3 class="ms-standardheader ms-inputformheader">
                    Select Workspace
                </h3>
                <div style="width: 100%" id="loadinggrid" align="center">
                    <img src="/_layouts/15/images/gears_anv4.gif" style="vertical-align: middle;" />
                    Loading Workspaces...
                </div>
                <div style="overflow-y: auto">
                    <div id="htmlGrdExistingWorkspace" style="width: 600; height: 300; display: none;">
                    </div>
                </div>
            </div>
        </div>
        <%--right div--%>
        <div class="divRight" style="display: none">
            <%--seach box--%>
            <div class="divSearchBox">
                <input id="tbFreeSearch" class="inputSearch search-query" type="text" style="width: 150px;
                    margin-left: 0.3em;margin-top:8px;margin-right:5px;margin-bottom:5px;" placeholder="Search..." />
                <%--<img id="imgBtnFreeSearch" src="/_layouts/epmlive/images/Magnifier24x24.png" style="margin-bottom: -5px" />--%>
            </div>
            <div style="width: 100%; height: 1em">
            </div>
            <div class="txtExistingWorkspaceHeading" style="display: none">
                Existing Workspace
            </div>
            <div class="txtExistingWorkspaceUrl">
            </div>
            <div class="imgTemplateIcon">
                <image class="templateImage" id="rightDivTemplateImage" />
            </div>
            <div class="divDivider" style="height: 10px">
            </div>
            <div class="txtTemplateTitle">
            </div>
            <div class="txtTemplateType">
            </div>
            <div class="txtTemplateCategory">
            </div>
            <div class="divDivider">
            </div>
            <div class="txtDescription">
            </div>
            <div style="width: 100%; height: 0.3em">
            </div>
            <div class="divMoreInfoLink">
                <a id="aMoreInfo" href="#">more...</a>
            </div>
            <div style="width: 100%; height: 2em">
            </div>
            <div class="divWorkspaceNameTitle">
                <span id="spanWorkspaceTitle"></span>
            </div>
            <div style="width: 100%; height: 0.3em">
            </div>
            <div class="divNewWorkspaceName">
                <input type="text" class="tbNewWorkSpaceName inputSearch" id="tbNewWorkSpaceName"
                    value="<%=_requestProjectName %>" />
            </div>
            <div class="newWorkSpaceBtnSection">
                <input type="button" id="btnCreate" class="ms-ButtonHeightWidth rightDivBtnCreate btn"
                    value="Create" />
                <input type="button" style="margin-left: 0.2em;" id="btnMoreLessOpt" class="ms-ButtonHeightWidth rightDivBtnMoreLessOpt btn"
                    value="More Options" />
                <input type="button" style="margin-left: 0.2em;" id="btnMoreInfo" class="ms-ButtonHeightWidth rightDivBtnMoreInfo btn"
                    value="More Info" />
            </div>
        </div>
        <div class="divSalesInfo" style="display: none">
        </div>
        <%--template's html templates--%>
        <div class="divTemplateHolder ms-create-listitem-a" id="divTemplateHolder" style="display: none">
            <image class="templateImage" id="templateImage" />
            <div class="divTemplateTitle" id="divTemplateTitle">
            </div>
            <input type="hidden" id="templateId" name="templateId" />
            <input type="hidden" id="templateTitle" name="templateTitle" />
            <input type="hidden" id="templateType" name="templateType" />
            <input type="hidden" id="templateCategories" name="templateCategories" />
            <input type="hidden" id="templateDescription" name="templateDescription" />
            <input type="hidden" id="templateMoreInfo" name="templateMoreInfo" />
            <input type="hidden" id="templateImageUrl" name="templateImageUrl" />
            <input type="hidden" id="templateInternalName" name="templateInternalName" />
        </div>
        <%--online template's html templates--%>
        <div class="divOnlineTempHolder ms-create-listitem-a" id="divOnlineTempHolder" style="display: none">
            <image class="templateImage" id="templateImage" />
            <div class="divOnlineTempTitle" id="divOnlineTempTitle">
            </div>
            <input type="hidden" id="templateId" name="templateId" />
            <input type="hidden" id="templateTitle" name="templateTitle" />
            <input type="hidden" id="templateType" name="templateType" />
            <input type="hidden" id="templateCategories" name="templateCategories" />
            <input type="hidden" id="templateDescription" name="templateDescription" />
            <input type="hidden" id="templateMoreInfo" name="templateMoreInfo" />
            <input type="hidden" id="templateSalesInfo" name="templateSalesInfo" />
            <input type="hidden" id="templateImageUrl" name="templateImageUrl" />
            <input type="hidden" id="templateIncludeContent" name="templateIncludeContent" />
            <input type="hidden" id="templateLevels" name="templateLevels" />
            <input type="hidden" id="templateOnlineFolder" name="templateOnlineFolder" />
        </div>
        <%--hidden controls--%>
        <input type="hidden" id="hdnParentWebUrl" />
        <input type="hidden" id="hdnTargetWebUrl" />
        <%--stores filter template type--%>
        <input type="hidden" id="hdnTemplateType" />
        <%--stores filter template category--%>
        <input type="hidden" id="hdnTemplateCategory" />
        <input type="hidden" id="hdnIsNewWorkSpace" value="true" />
        <input type="hidden" id="hdnCreateNewFrom" />
        <input type="hidden" id="hdnTemplateId" />
        <input type="hidden" id="hdnSelectedWorkspace" />
        <input type="hidden" id="hdnSiteName" value="" />
        <input type="hidden" id="hdnSiteUrl" value="" />
        <input type="hidden" id="hdnOnlineSolFolder" />
        <input type="hidden" id="hdnTemplateInternalName" />
        <%--stores selected temp categories--%>
        <input type="hidden" id="hdnSelectTempCategories" />
        <%--stores selected temp types--%>
        <input type="hidden" id="hdnSelectTempTypes" />
    </div>
    <script language="javascript">
        // initialize existing workspace grid
        (function ($$, $) {
            grdExistingWorkSpace = new dhtmlXGridObject('htmlGrdExistingWorkspace');

            grdExistingWorkSpace.setImagePath("dhtml/xgrid/imgs/");
            grdExistingWorkSpace.setSkin("modern");

            grdExistingWorkSpace.setImageSize(1, 1);
            grdExistingWorkSpace.attachEvent("onXLE", $$.createWorkspaceClearLoader);
            grdExistingWorkSpace.attachEvent("onRowSelect", $$.grdExistingWorkSpaceChange);
            grdExistingWorkSpace.enableAutoHeigth(true);
            grdExistingWorkSpace.init();
        })(window.epmLiveCreateWorkspace = window.epmLiveCreateWorkspace, window.jQuery);

    </script>
    <%--loading gif--%>
    <div id="divLoad_CreateWorkspace" style="display: none; width: 100%; text-align: center;">
        <img src="/_layouts/15/images/gears_anv4.gif" style="vertical-align: middle" />
        <span id="spanMainLoading">Creating project...</span>
    </div>
    <div id="div_loading_msg" style="display: none; width: 100%; text-align: center;">
        <%--<span>The <span id="spanTxtProjName"></span> is currently being created. This
            may take a moment.</span>--%>
        <span>This may take a few minutes – we’re doing some pretty fancy stuff here but rest
            assured that when we’re finished, you’ll be ready to rock and roll!</span>
    </div>
    <%--filter links model--%>
    <li id="filterLinks_model" class="ms-create-listitem" style="display: none">
        <div>
            <a id="lnkOnlineTemps" class="sameColorLink" href="#"></a>
        </div>
    </li>
    <script type="text/javascript">
        $('input[placeholder], textarea[placeholder]').placeholder();
        </script>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
</asp:Content>
