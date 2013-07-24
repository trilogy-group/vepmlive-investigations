<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="epm" TagName="EPMLiveJS" Src="~/_controltemplates/EPMLiveJS.ascx" %>
<%@ Register TagPrefix="epm" Namespace="EPMLiveCore" Assembly="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="EPMLiveCore.Comments" DynamicMasterPageFile="~masterurl/default.master"%>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <%--STYLE LINKS--%>
    <link href="<%= SPContext.Current.Web.Url %>/_layouts/EPMLive/SocialData.css" rel="Stylesheet" type="text/css" />
    <link href="<%= SPContext.Current.Web.Url %>/_layouts/EPMLive/Comments.UI.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        <!--
        html,body{
	        height:100%;
        }
        img
        {
            border: none;
        }
        .trcDlgMain {width:100%;}
        -->
        
        .epmliveinput
        {
            padding: 2px 5px;
            background-color: rgba(255, 255, 255, 0.85);
            border: 1px solid #ABABAB;
            color: #444444;
            font-family:"Segoe UI","Segoe",Tahoma,Helvetica,Arial,sans-serif;
            font-size:13px;
            vertical-align: middle;
            outline: none;
             resize: none;
    
        }

        .epmliveinput:hover
        {
            border-color:#92C0E0;
        }

        .epmliveinput:focus
        {
        border-color:#2A8DD4;
        }


        .epmliveButton
        {
            min-width: 6em;
            padding: 7px 10px;
            border: 1px solid #ABABAB;
            background-color: #FDFDFD;
            background-color: #FDFDFD;
            margin-left: 10px;
            font-family: "Segoe UI","Segoe",Tahoma,Helvetica,Arial,sans-serif;
            font-size: 12px;
            color: #444;
        }

        .epmliveButton-disabled
        {
        background-color: #FDFDFD !important;
            border-color: #E1E1E1 !important;
            color: #B1B1B1 !important;
            cursor:default !important;
        }

        .epmliveButton:hover
        {
        border-color: #92C0E0;
        background-color: #E6F2FA;
            cursor:pointer;
        }

        .epmliveButton:active
        {
        border-color: #2A8DD4;
        background-color: #92C0E0;
        cursor:pointer;
        }

        .epmliveButton-emphasize
        {
        border-color: #0067B0 !important;
        background-color: #0072C6 !important;
        color: white !important;
        }

        .epmliveButton-emphasize:hover
        {
        background-color: #0067B0 !important;
            border-color: #004D85 !important;
        }


        .epmliveButtonDisabled
        {
            background-color: #FDFDFD;
            border-color: #E1E1E1;
            color: #B1B1B1;
            cursor:default;
            min-width: 6em;
            padding: 7px 10px;
            border: 1px solid #ABABAB;
            margin-left: 10px;
            font-family: "Segoe UI","Segoe",Tahoma,Helvetica,Arial,sans-serif;
            font-size: 11px;
            border-color: #E1E1E1;        
        }

    </style>
    <%--SCRIPT LINKS--%>
    <epm:epmlivejs id="EPMLiveJS1" runat="server"></epm:epmlivejs>
    <script type="text/javascript" src="<%= SPContext.Current.Web.Url %>/_layouts/EPMLive/jQueryLibrary/jquery-1.5.2.js"></script>
    <script type="text/javascript" src="<%= SPContext.Current.Web.Url %>/_layouts/EPMLive/LMR.Comments.UI.js"></script>
    <script type="text/javascript">
        var curWebUrl = "<%=_webUrl %>";
        var userPictureUrl = "<%=_userPictureUrl %>";
        var userEmail = "<%=_userEmail %>";
        var currentUserLoginName = "<%=_currentUserLoginName %>";
        var userProfileUrl = "<%=_userProfileUrl %>";
        var notifyId = ' ';
        var userHasPerm = "<%=_hasPerm %>";
        var itemTitle = "<%=_itemTitle %>";
        var authorid = "<%=_authorId %>";
        var assigneeids = "<%=_assigneeIds %>";

        var hdnItemId = "<%=hdnItemId.ClientID %>";
        var hdnCommentItemId = "<%=hdnCommentItemId.ClientID %>";
        var hdnListId = "<%=hdnListId.ClientID %>";
        var hdnUserId = "<%=hdnUserId.ClientID %>";
       

        $(function () {

            $("#tbCommentInput").bind('paste', function () {
                var value = $(this).text();
                if (value.length > 0) {
                    $('#postBtn').removeClass('epmliveButton-disabled');
                    $('#postBtn').addClass('epmliveButton-emphasize');
                }
                else {
                    $('#postBtn').removeClass('epmliveButton-emphasize');
                    $('#postBtn').addClass('epmliveButton-disabled');
                }
            });


            $('#tbCommentInput').keyup(function () {
                var value = $(this).text();
                if (value.length > 0) {
                    $('#postBtn').removeClass('epmliveButton-disabled');
                    $('#postBtn').addClass('epmliveButton-emphasize');
                }
                else {
                    $('#postBtn').removeClass('epmliveButton-emphasize');
                    $('#postBtn').addClass('epmliveButton-disabled');
                }

                var commentDivHeight = $('#tbCommentInput').height();

                var subDivHeight = $('.commentsContainer').height();
                if (commentDivHeight > 72) {
                    var diff = (commentDivHeight - 72);
                    $('.commentsContainer').height(230 - diff);
                }
                else {
                    $('.commentsContainer').height(230);
                }

            });



        });
    </script>
    
    <div id="notificationArea" class="s4-noti">
    </div>
    <div class="newCommentInputBox" style="margin-bottom: 10px">
        <table id="s4-mainarea" class="trcDlgMain ms-socialDataRibbonContents" cellpadding="0"
            cellspacing="0" style="padding-bottom: 0px; padding-left: 8px; padding-right: 8px;
            height: 60px; vertical-align: top; padding-top: 12px; background-color: White">
            <tbody>
                <tr>
                    <td>
                        <span>To:</span>
                    </td>
                    <td>
                        <span id="spanCommenters" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>CC:</span>
                    </td>
                    <td>
                        <epm:CommentCCPeopleEditor ID="CCPeopleEditor" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; height: 22px;" colspan="2">
                        <div style="width: 98%; overflow-y: auto; min-height:72px;max-height:250px; overflow:auto;" id="tbCommentInput" class="ms-rtestate-write epmliveinput"
                            contenteditable="true" disableribboncommands="True">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; height: 25px; padding: 0px 8px 0px 8px;" colspan="2">
                        <div style="width: 100%; padding" class="ms-socialCommentLoading">
                            <input id="postBtn" class="epmliveButton epmliveButton-disabled" style="margin-top: 5px;" title="Post" onclick="javaScript: if ($('#tbCommentInput').text().length > 0) { ajaxPost('CreateComment'); };"
                                value="Post" type="button" />
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <%--this is a model table for 'edit' comment box--%>
    <div class="socialcomment-edit" id="divCommentEdit_Model" style="width: 100%; display: none;">
        <table style="width: 100%;">
            <tbody>
                <tr>
                    <td>
                        <div class="ms-socialCommentInputBox ms-rtestate-write customCommentItem" style="width: 100% !important;
                            min-height: 4em;" id="socialCommentInputBox_Model" contenteditable="true">
                            comment</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="ms-errorinl" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ms-socialCommentLoading" style="width: 100%;">
                            <div style="padding-bottom: 3px; padding-left: 3px; padding-right: 3px; padding-top: 3px;">
                                <input title="Post" id="editCommentPost_Model" type="button" value="Post" />
                                <span class="separator">&nbsp;</span>
                                <input title="Cancel" id="editCommentCancel_Model" type="button" value="Cancel" />
                            </div>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <%--this is a model table for creating 'new' comment rows--%>
    <div class="ms-socialCommentItem customCommentItem" id="commentItem_Model" style="width: 100%;
        display: none;">
        <table style="width: 100%">
            <tbody>
                <tr>
                    <td class="socialcomment-image" valign="left" rowspan="2">
                        <img id="imgUserProfile" style="width: 32px; height: 32px" alt="User Photo" src="" />
                    </td>
                    <td class="socialcomment-IMPawn" rowspan="2" align="left">
                       <%-- <div id="DataFrameManager_ctl02_socomIM_0" class="socialcomment-IMPawn">
                            <span>
                                <img id="commentAvailBubble_Model" alt="Status indicator" src="/_layouts/images/imnhdr.gif"
                                    width="12" onload="QueuePopulateIMNRC('',this);" height="12" showofflinepawn="1" />
                            </span>
                        </div>--%>
                        <span class="ms-imnSpan">   
                            <a href="#" onclick="IMNImageOnClick(event);return false;" class="ms-imnlink ms-spimn-presenceLink" >    
                                <span class="ms-spimn-presenceWrapper ms-imnImg ms-spimn-imgSize-10x10">
                                    <img name="imnmark" title="" ShowOfflinePawn="1" class="ms-spimn-img ms-spimn-presence-disconnected-10x10x32" src="/_layouts/15/images/spimn.png?rev=23" alt="User Presence" sip="" />   
                                </span>  
                            </a>
                        </span>
                    </td>
                    <td class="socialcomment-top" valign="left">
                        <span class="socialcomment-username"><a id="lnkUserProfile" href="#" target="_parent">
                        </a></span><span id="spanCreatedDate" class="socialcomment-time">Created_Date</span>
                    </td>
                    <td class="socialcomment-top socialcomment-cmdlink" valign="right">
                        <span class="socialcomment-cmdlink"><a id="btnCommentItemEdit_Model" href="#">Edit</a><span
                            class="separator">&nbsp;|&nbsp;</span><a id="btnCommentItemDelete_Model" href="#">Delete</a>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="socialcomment-bottom" valign="left" colspan="3">
                        <div id="divComment_Model" class="socialcomment-contents-TRC">
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="clear: both; width: 100%"></div>
    <div>
        <asp:Panel CssClass="commentsContainer" ID="pnlCommentsContainer" runat="server">
        </asp:Panel>
    </div>
    <input type="hidden" id="hdnItemId" runat="server" value="" />
    <input type="hidden" id="hdnListId" runat="server" value="" />
    <input type="hidden" id="hdnCommentItemId" runat="server" value="" />
    <input type="hidden" id="hdnUserId" runat="server" value="" />
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Comments for Item: "<%=_itemTitle %>" on List: <%=_listTitle %>
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >

</asp:Content>


   
    