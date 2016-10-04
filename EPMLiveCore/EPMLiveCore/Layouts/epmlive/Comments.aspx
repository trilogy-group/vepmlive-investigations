<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="epm" Namespace="EPMLiveCore" Assembly="EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="EPMLiveCore.Comments" DynamicMasterPageFile="~masterurl/default.master"%>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <link href="Comments.UI.css" rel="stylesheet" />
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
    </script>
    
    <div id="notificationArea" class="s4-noti">
    </div>
    <div class="newCommentInputBox">
        <table class="commentsTable" >
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
                        <div id="tbCommentInput" class="epmliveinput" contenteditable="true" disableribboncommands="True">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="width: 100%;">
                            <input id="postBtn" class="epmliveButton epmliveButton-disabled" title="Post" value="Post" type="button" />
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <%--this is a model table for 'edit' comment box--%>
    <div class="socialcomment-edit" id="divCommentEdit_Model" >
        <table style="width: 100%;">
            <tbody>
                <tr>
                    <td>
                        <div class="epmliveinput ms-rtestate-write customCommentItem" id="socialCommentInputBox_Model" contenteditable="true">
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
    <div class="ms-socialCommentItem customCommentItem" id="commentItem_Model" >
        <table style="width: 100%">
            <tbody>
                <tr>
                    <td class="socialcomment-image" valign="left" rowspan="2">
                        <img id="imgUserProfile" style="width: 32px; height: 32px" alt="User Photo" src="" />
                    </td>
                    <td class="socialcomment-IMPawn" rowspan="2" align="left">
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
        <asp:Panel CssClass="commentsContainer" ID="pnlCommentsContainer" runat="server" Width="96%">
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


   
    