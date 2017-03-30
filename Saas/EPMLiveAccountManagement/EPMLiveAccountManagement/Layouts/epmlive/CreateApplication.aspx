<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" Src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateApplication.aspx.cs"
    Inherits="NewSiteCollectionWebPart.Layouts.NewSiteCollectionWebPart.CreateApplication"
    DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div id="OuterContainer">
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
        <script src="DHTML/xgrid/dhtmlxcommon.js"></script>
        <script type="text/javascript" src="jQueryLibrary/jquery-1.5.2.js"></script>
        <script src="javascripts/libraries/jquery-ui.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="jQueryLibrary/jquery.sharepoint-json.js"></script>
        <script type="text/javascript" src="jQueryLibrary/xml2json.js"></script>
        <script type="text/javascript">
            var qsTemplateType = '<%=_templateType %>';
            var qsSolutionType = '<%=_solutionType %>';
            var solutionStoreProxyUrl = '<%=_solutionStoreServiceProxyUrl %>';
            var isOnlineTempsLoaded = 'false';
            var onlineFilterPnlId = '<%=pnlEPMLiveFilterBy.ClientID %>';
            var moreInfoUrl = '<%=_moreInfoUrl %>';
            var urlBoxId = '<%=txtURL.ClientID %>';
            var contractLevel = '<%=_contractLevel %>';
        </script>
        <script type="text/javascript" src="CreateApplication.js"></script>
        <script src="javascripts/libraries/jquery.placeholder.min.js" type="text/javascript"></script>
        
        <script src="javascripts/libraries/slimScroll.js" type="text/javascript"></script>
        <script language="javascript">

            function createSite() {
                // hide whole page
                $('#OuterContainer').css('display', 'none');
                $('body').css('cursor', 'wait');

                // change loading text
                $('#spanMainLoading').html('Creating Application...');
                //$('#spanTxtProjName').text($('#tbNewWorkSpaceName').val().trim() + ' workspace');

                // display loading icon
                $('#divLoad_CreateWorkspace').css('display', 'block');
                $('#div_loading_msg').css('display', 'block');

                var siteurl = document.getElementById('<%=txtURL.ClientID %>').value;
                siteurl = siteurl.trim().replace(/[^a-zA-Z 0-9]+/g, '');

                var sitetitle = document.getElementById('tbNewWorkSpaceName').value;
                var template = $('#hdnOnlineSolFolder').val();
                var description = document.getElementById('<%=tbDescription.ClientID %>').value;
                var accountid = document.getElementById('<%=ddlAccount.ClientID %>').value;

                var postData = "siteurl=" + siteurl + "&sitetitle=" + sitetitle + "&template=" + template + "&description=" + description + "&account=" + accountid;

                dhtmlxAjax.post("createsite2.aspx", postData, createSiteCallback);
            };

            function createSiteCallback(loader) {
                var retVal = loader.xmlDoc.responseText.trim();
                // unhide page
                $('#OuterContainer').css('display', 'none');
                $('body').css('cursor', 'auto');
                // hide loading icon
                //$('#divLoad_CreateWorkspace').css('display', 'none');
                $('#div_loading_msg').css('display', 'none');

                if (retVal.indexOf("Success") == 0) {
                    $('#spanMainLoading').html("You are now being redirected...");
                   // $('#spanMainLoading').css('display', '');
                    $('#div_loading_msg').css('display', 'none');

                    var vals = retVal.split(',');
                    var siteurl = vals[1];
                    window.parent.location.href = siteurl;

                }
                else {
                    alert(retVal);
                }

            };

            function addAccount() {
                function NewItemCallback(dialogResult, returnValue) {

                }

                var options = { url: "<%=_weburl %>/_layouts/epmlive/addaccount.aspx?src=newsite", width: 400, dialogReturnValueCallback: NewItemCallback };

                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
            }

            
        </script>
        <%--left div--%>
        <div class="divLeft" style="display: none">
            <%--categories from online solution store--%>
            <div class="divEPMLiveTempFilters divFilter" style="display: none">
                <div class="titleFilterBy">
                    Categories:</div>
                <asp:Panel runat="server" ID="pnlEPMLiveFilterBy" CssClass="linkPanel">
                    <div id="divOnlineSolStoreFilterLoadingGif">
                        <img src="/_layouts/images/gears_anv4.gif" style="vertical-align: middle" />
                        <span id="span2">Loading...</span>
                    </div>
                </asp:Panel>
            </div>
            <%--free search left panel--%>
            <div id="divfreeSearchFilter" class="divEPMLiveTempFilters divFilter" style="display: none;padding: 20px 10px 0px 10px;overflow:hidden;">
                <span id="txtFreeSearch"></span>
                <div class="divDivider">
                </div>
                <a id="lnkBackToAllItems" href="#" >Back to All Items...</a>
            </div>
        </div>
        <%--center div--%>
        <div class="divCenter">
            <div class="txtAvailableTemplates" style="width: 100%; text-align: left; margin-bottom: 2px; display: none; border-bottom: 1px solid #999999;">
                <b>Available Templates</b>
            </div>
            <%--loading gif for loading EPMLive.com templates--%>
            <div id="divLoad_LoadingOnlineTemps" style="width: 100%; text-align: center;">
                <img src="/_layouts/images/gears_anv4.gif" style="vertical-align: middle" />
                Loading templates...
            </div>
            <div id="divOnlineTempsHolder" class="divOnlineTempsHolder" style="display: none">
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
                                    <asp:TextBox Title="URL" class="ms-input" ID="txtURL" Columns="25" Name="txtURL"
                                        Text="" runat="server" MaxLength="255" />
                                    <div style="clear: both; height: 1em">
                                    </div>
                                    <%--<div id="htmlGrdChangeParentUrl" style="width: 600; height: 300; display:none">
                                </div>--%>
                                </Template_Control>
                            </wssuc:InputFormControl>
                        </Template_InputFormControls>
                    </wssuc:InputFormSection>
                    <wssuc:InputFormSection ID="Inputformsection2" Title="Select Account" Description="Select the account you would like to associate this site with"
                        runat="server" width="10">
                        <Template_InputFormControls>
                            <%--<img src="/_layouts/images/blank.gif" width="600px" height="1" />--%>
                            <wssuc:InputFormControl ID="InputFormControl2" LabelText="Account" runat="server">
                                <Template_Control>
                                    <asp:DropDownList ID="ddlAccount" runat="server">
                                    </asp:DropDownList>
                                    <div style="clear: both; height: 1em">
                                        <a id="lnkCreateAccount" href="#" onclick="addAccount()">[Create New Account]</a>
                                </Template_Control>
                            </wssuc:InputFormControl>
                        </Template_InputFormControls>
                    </wssuc:InputFormSection>
                    <wssuc:InputFormSection ID="Inputformsection3" Title="Enter Description" Description="Please provide a description for your application "
                        runat="server" width="10">
                        <Template_InputFormControls>
                            <%--<img src="/_layouts/images/blank.gif" width="600px" height="1" />--%>
                            <wssuc:InputFormControl ID="InputFormControl3" LabelText="Description" runat="server">
                                <Template_Control>
                                    <asp:TextBox runat="server" TextMode="MultiLine" ID="tbDescription"></asp:TextBox>
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
                    <img src="/_layouts/images/gears_anv4.gif" style="vertical-align: middle;" />
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
                <%--<img id="img1" src="/_layouts/epmlive/images/Magnifier24x24.png" style="margin-bottom: -5px" /> --%><input id="tbFreeSearch" class="inputSearch search-query" type="text" style="width: 150px;margin-left: 0.3em;"
                    class="form-search" placeholder="Search..." />

            </div>
            <div class="divDivider">
            </div>
            <div class="txtExistingWorkspaceHeading" style="display: none">
                Existing Workspace
            </div>
            <div class="txtExistingWorkspaceUrl">
            </div>
            <div class="imgTemplateIcon">
                <image class="templateImage" id="rightDivTemplateImage" />
            </div>
            <div class="divDivider" style="height: 10px; display: block">
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
                <span id="spanWorkspaceTitle">Application Name</span>
            </div>
            <div style="width: 100%; height: 0.3em">
            </div>
            <div class="divNewWorkspaceName">
                <input type="text" class="tbNewWorkSpaceName inputSearch" id="tbNewWorkSpaceName"
                    value="<%=_requestProjectName %>" />
            </div>
            <div class="newWorkSpaceBtnSection">
                <input type="button" id="btnCreate" class="ms-ButtonHeightWidth rightDivBtnCreate btn"
                    value="Create" onclick="createSite()" />
                <input type="button" style="margin-left: 0.2em;" id="btnMoreLessOpt" class="ms-ButtonHeightWidth rightDivBtnMoreLessOpt btn"
                    value="More Options" />
                <input type="button" style="margin-left: 0.2em;" id="btnMoreInfo" class="ms-ButtonHeightWidth rightDivBtnMoreInfo"
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
    <%--loading gif--%>
    <div id="divLoad_CreateWorkspace" style="display: none; width: 100%; text-align: center;margin-top:250px !important;">
        <img src="/_layouts/images/gears_anv4.gif" style="vertical-align: middle" />
        <span id="spanMainLoading">Creating project...</span>
    </div>
    <div id="div_loading_msg" style="display: none; width: 100%; text-align: center;margin-top:20px !important;">
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
    Application Page
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
    My Application Page
</asp:Content>
