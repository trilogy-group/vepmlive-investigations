<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="EPMLiveCore.Comments" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html id="Html1" dir="<%$Resources:wss, multipages_direction_dir_value%>" runat="server">
<head>
    <title>Comments for Item: "<%=_itemTitle %>" on List: <%=_listTitle %></title>
    <meta http-equiv="Content-Style-Type" content="text/css">
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
    </style>
    <SharePoint:ScriptLink ID="ScriptLink1" Localizable="true" Name="init.js" runat="server"
        Defer="false" />
    <SharePoint:ScriptLink ID="ScriptLink2" Localizable="true" Name="core.js" runat="server"
        Defer="false" />
    <link href="<%= SPContext.Current.Web.Url %>/_layouts/EPMLive/SocialData.css" rel="Stylesheet" type="text/css" />
    <link href="<%= SPContext.Current.Web.Url %>/_layouts/EPMLive/Comments.UI.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        var curWebUrl = "<%=_webUrl %>";
        var userPictureUrl = "<%=_userPictureUrl %>";
        var userEmail = "<%=_userEmail %>";
        var currentUserLoginName = "<%=_currentUserLoginName %>";
        var userProfileUrl = "<%=_userProfileUrl %>";
        var notifyId = ' ';
        var userHasPerm = "<%=_hasPerm %>";
        var itemTitle = "<%=_itemTitle %>";
    </script>
    <script type="text/javascript" src="<%= SPContext.Current.Web.Url %>/_layouts/EPMLive/jQueryLibrary/jquery-1.5.2.js"></script>
    <script type="text/javascript" src="<%= SPContext.Current.Web.Url %>/_layouts/EPMLive/LMR.Comments.UI.js"></script>
    
</head>
<body style="margin: 0px; width: 100%;" onload="javascript:if (typeof(_spBodyOnLoadWrapper) != 'undefined') _spBodyOnLoadWrapper();">
    <form id="Form1" runat="server" style="100%">
    <SharePoint:FormDigest ID="FormDigest1" runat="server" />
    <script type="text/jscript">
        function ULS0CX() { var o = new Object; o.ULSTeamName = "SharePoint Portal Server"; o.ULSFileName = "Comments.aspx"; return o; }

        function DisableOnEditableRegionFocus() {
            ULS0CX: ;
            RTE.CanvasEvents.onEditableRegionFocus = function (sender, args) { };
        }
        ExecuteOrDelayUntilScriptLoaded(DisableOnEditableRegionFocus, "sp.ui.rte.js");
        
    </script>
    <SharePoint:CssLink ID="CssLink1" runat="server" />
    <div id="notificationArea" class="s4-noti">
    </div>
    <div class="newCommentInputBox" style="margin-bottom: 10px">
        <table id="s4-mainarea" class="trcDlgMain ms-socialDataRibbonContents" cellpadding="0"
            cellspacing="0" style="padding-bottom: 0px; padding-left: 8px; padding-right: 8px;
            height: 60px; vertical-align: top; padding-top: 12px; background-color: White">
            <tbody>
                <tr>
                    <td style="vertical-align: top; height: 22px;">
                        <div style="height: 72px; width: 100%; overflow-y: auto;" id="tbCommentInput" class="ms-socialCommentInputBox ms-rtestate-write" 
                            contenteditable="true" disableribboncommands="True">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; height: 25px; padding: 0px 8px 0px 8px;">
                        <div style="width: 100%; padding" class="ms-socialCommentLoading">
                            <input id="postBtn" style="margin-top: 5px;" title="Post" onclick="javaScript:if ($('#tbCommentInput').text().length > 0){ajaxPost('CreateComment');};"
                                value="Post" type="button" />
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <%--this is a model table for 'edit' comment box--%>
    <div class="socialcomment-edit" id="divCommentEdit_Model" style="width:100%;display:none;">
        <table style="width:100%;">
            <tbody>
                <tr>
                    <td>
                        <div class="ms-socialCommentInputBox ms-rtestate-write customCommentItem" style="width:100% !important; min-height:4em;" id="socialCommentInputBox_Model" contentEditable="true" >comment</div>                    
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
                            <div style="padding-bottom: 3px; padding-left: 3px; padding-right: 3px; padding-top: 3px;" >
                                <input title="Post" id="editCommentPost_Model" type="button" value="Post"/>
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
    <div class="ms-socialCommentItem customCommentItem" id="commentItem_Model" style="width:100%;display:none;">
        <table style="width:100%">
            <tbody>
                <tr>
                    <td class="socialcomment-image" vAlign="left" rowSpan="2">
                        <img id="imgUserProfile" style="width:32px;height:32px" alt="User Photo" src="" />
                    </td>
                    <td class="socialcomment-IMPawn" rowSpan="2" align="left">
                        <div id="DataFrameManager_ctl02_socomIM_0" class="socialcomment-IMPawn">
                            <span>
                                <img id="commentAvailBubble_Model" alt="Status indicator" src="/_layouts/images/imnhdr.gif" width="12" onload="QueuePopulateIMNRC('',this);" height="12" ShowOfflinePawn="1" />
                            </span>
                        </div>
                    </td>
                    <td class="socialcomment-top" vAlign="left">
                        <span class="socialcomment-username">
                            <a id="lnkUserProfile" href="#" target="_parent"></a>
                        </span>
                        <span id="spanCreatedDate" class="socialcomment-time">Created_Date</span>
                    </td>
                    <td class="socialcomment-top socialcomment-cmdlink" vAlign="right">
                        <span class="socialcomment-cmdlink">
                            <a id="btnCommentItemEdit_Model" href="#">Edit</a><span class="separator">&nbsp;|&nbsp;</span><a id="btnCommentItemDelete_Model" href="#">Delete</a> 
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="socialcomment-bottom" vAlign="left" colSpan="3">
                        <div id="divComment_Model" class="socialcomment-contents-TRC"></div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <div style="clear:both;width:100%"></div>

    <div>
        <asp:Panel CssClass="commentsContainer" ID="pnlCommentsContainer" runat="server">
        </asp:Panel>
    </div>
    <input type="hidden" id="hdnItemId" runat="server" value="" />
    <input type="hidden" id="hdnListId" runat="server" value="" />
    <input type="hidden" id="hdnCommentItemId" runat="server" value="" />
    <input type="hidden" id="hdnUserId" runat="server" value="" />
    </form>
</body>
</html>
