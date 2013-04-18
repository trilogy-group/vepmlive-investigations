/// <reference path="/_layouts/epmlive/jQueryLibrary/jquery-1.5.1.min.js" />
$(function () {
    if (userHasPerm == 'True') {
        $('.newCommentInputBox').css('display', '');
        $('#tbCommentInput').focus();
    }
    else {
        $('.newCommentInputBox').css('display', 'none');
        alert("You can't make comments because your permission level is lower than \"Contribute\".");
    }
});

var loadingHtml = "<div id=\"divLoadingIcon\" style=\"width:100%; vertical-align: middle; white-space: nowrap; background-color: rgb(255, 255, 255);padding-top:10px;padding-bottom:20px;\">" +
                    "<IMG style=\"margin-left:230px; margin-right:10px; vertical-align: middle\" title=\"Working...\" alt=\"Working...\" src=\"/_layouts/images/progress-circle-24.gif\">" +
                    "<SPAN style=\"TEXT-ALIGN: center; WHITE-SPACE: nowrap; COLOR: black; VERTICAL-ALIGN: middle; OVERFLOW: hidden;font-family:Verdana;font-size:12px;color:#686868;\">Working...</SPAN>" +
                  "</div>";


function QueuePopulateIMNRC(emailAddress, element) {
    setTimeout("IMNRC('" + emailAddress + "', document.getElementById('" + element.id + "'));", 100);
}

function EnterEditMode(commentItemId) {
    var commentVal = $('#divComment_' + commentItemId).html();

    var editBox = $('#divCommentEdit_Model')
            .clone()
            .attr('id', 'divCommentEdit_' + commentItemId)
            .css('display', '')
            .wrap('<div></div>')
            .parent()
            .html();

    var targetCommentBoxId = '#commentItem_' + commentItemId;

    $(targetCommentBoxId).after(editBox);
    $(targetCommentBoxId).css('display', 'none');

    $('#divCommentEdit_' + commentItemId)
            .find('#socialCommentInputBox_Model')
            .attr('id', 'socialCommentInputBox_' + commentItemId)
            .html(commentVal);

    $('#divCommentEdit_' + commentItemId)
            .find('#editCommentPost_Model')
            .attr('id', 'editCommentPost_' + commentItemId)
            .click(function () {
                //                var postItemId = $(this).attr('id');
                //                postItemId = postItemId.substring(postItemId.indexOf('_') + 1);
                $('#hdnCommentItemId').val(commentItemId);
                ajaxPost('UpdateComment');
            });

    $('#divCommentEdit_' + commentItemId)
            .find('#editCommentCancel_Model')
            .attr('id', 'editCommentCancel_' + commentItemId)
            .click(function () {
                //                var cancelItemId = $(this).attr('id');
                //                cancelItemId = cancelItemId.substring(cancelItemId.indexOf('_') + 1);
                $(targetCommentBoxId).css('display', '');
                $('#divCommentEdit_' + commentItemId).remove();
            });
}

var xmlhttp = false;
if (navigator.appName == "Microsoft Internet Explorer") {
    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
}
else {
    xmlhttp = new XMLHttpRequest();
}

function ajaxPost(command) {
    switch (command) {
        case "CreateComment":
            notifyId = SP.UI.Notify.addNotification('Creating comment...', true);
            setTimeout('SP.UI.Notify.removeNotification(notifyId)', 300);
            $('#commentItem_PlaceHolder').after(loadingHtml);
            $('#postBtn').removeClass('epmliveButton-emphasize');
            $('#postBtn').addClass('epmliveButton-disabled')
            $('#postBtn').attr('disabled', true);
            break;
        case "ReadComment":
            notifyId = SP.UI.Notify.addNotification('Reading comment...', true);
            setTimeout('SP.UI.Notify.removeNotification(notifyId)', 300);
            break;
        case "DeleteComment":
            notifyId = SP.UI.Notify.addNotification('Deleting comment...', true);
            setTimeout('SP.UI.Notify.removeNotification(notifyId)', 300);
            break;
        case "UpdateComment":
            notifyId = SP.UI.Notify.addNotification('Updating comment...', true);
            setTimeout('SP.UI.Notify.removeNotification(notifyId)', 300);
            break;
        default:
            break;
    }

    var qsItemId = $('#hdnItemId').val();
    var qsListId = $('#hdnListId').val();
    var qsCommentItemId = $('#hdnCommentItemId').val();
    var qsUserId = $('#hdnUserId').val();

    //    var withBRs = $('#brText').html();
    //    var textWithBreaks = withBRs.replace(/\<br\>/gi, '\r');
    //    $('#area').text(textWithBreaks);

    var qsComment = $('#tbCommentInput').html();
    // clear text box
    $('#tbCommentInput').html("");
    // reset box sizes
    var commentDivHeight = $('#tbCommentInput').height();
    var subDivHeight = $('.commentsContainer').height();
    if (commentDivHeight > 72) {
        var diff = (commentDivHeight - 72);
        $('.commentsContainer').height(300 - diff);
    }
    else {
        $('.commentsContainer').height(300);
    }

    var newContentBoxId = '#socialCommentInputBox_' + qsCommentItemId;
    var qsNewComment = "";
    var qsNewCommentHTML = "";
    if ($(newContentBoxId)) {
        qsNewComment = $(newContentBoxId).html();
    }


    xmlhttp.open("POST", curWebUrl, true);
    xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            // evaluate Json object that comes back from web service
            var oJson = eval('(' + UnescapeHTMLtoXML(xmlhttp.responseText) + ')');

            switch (command) {
                case "CreateComment":
                    if (oJson.Result.Status == "1") {
                        alert(oJson.Result.Error.Text);
                        $('#divLoadingIcon').fadeOut('slow');
                        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', SP.UI.DialogResult.OK, '');
                    }
                    else {
                        var commentItemId = oJson.Result.Comments.CommentItem.Comment.itemId;
                        var newCommentBox = $('#commentItem_Model')
                                            .clone()
                                            .attr('id', 'commentItem_' + commentItemId)
                                            .wrap('<div></div>')
                                            .parent()
                                            .html();


                        $('#commentItem_PlaceHolder').after(newCommentBox);
                        $('#commentItem_' + commentItemId).find('#divComment_Model').attr('id', 'divComment_' + commentItemId);
                        $('#commentItem_' + commentItemId).find('#divComment_' + commentItemId).html(qsComment);

                        $('#commentItem_' + commentItemId).find('#lnkUserProfile').attr('href', userProfileUrl);
                        $('#commentItem_' + commentItemId).find('#lnkUserProfile').text(currentUserLoginName);
                        $('#commentItem_' + commentItemId).find('#spanCreatedDate').text(oJson.Result.Comments.CommentItem.Comment.createdDate);

                        $('#commentItem_' + commentItemId).find('#imgUserProfile').attr('id', 'imgUserProfile_' + commentItemId);
                        $('#commentItem_' + commentItemId).find('#imgUserProfile_' + commentItemId).attr('src', userPictureUrl);

                        $('#commentItem_' + commentItemId).find('#btnCommentItemEdit_Model').attr('id', 'btnCommentItemEdit_' + commentItemId);
                        $('#commentItem_' + commentItemId).find('#btnCommentItemDelete_Model').attr('id', 'btnCommentItemDelete_' + commentItemId);

                        $('#commentItem_' + commentItemId).find('#commentAvailBubble_Model').attr('onload', 'QueuePopulateIMNRC(\'' + userEmail + '\',this);');

                        //                        var newComment = commentModel.replace(/##commentItem_Model##/g, 'commentItem_' + commentItemId)
                        //                                                                             .replace(/##divComment_Model##/g, 'divComment_' + commentItemId)
                        //                                                                             .replace(/##qsComment##/g, qsComment)
                        //                                                                             .replace(/##lnkUserProfileHref##/g, userProfileUrl)
                        //                                                                             .replace(/##lnkUserProfileText##/g, currentUserLoginName)
                        //                                                                             .replace(/##Created_Date##/g, oJson.Result.Comments.CommentItem.Comment.createdDate)
                        //                                                                             .replace(/##imgUserProfile##/g, 'imgUserProfile_' + commentItemId)
                        //                                                                             .replace(/##imgUserProfileSrc##/g, userPictureUrl)
                        //                                                                             .replace(/##btnCommentItemEdit_Model##/g, 'btnCommentItemEdit_' + commentItemId)
                        //                                                                             .replace(/##btnCommentItemDelete_Model##/g, 'btnCommentItemDelete_' + commentItemId)
                        //                                                                             .replace(/##commentAvailBubble_ModelOnLoad##/g, 'QueuePopulateIMNRC(\'' + userEmail + '\',this);');

                        $('#divLoadingIcon').fadeOut('slow', function () {
                            $('#commentItem_' + commentItemId).fadeIn('slow');
                        });

                        var btnPostId = '#btnCommentItemEdit_' + commentItemId;
                        $(btnPostId).click(function () {
                            $('#hdnCommentItemId').val(commentItemId);
                            EnterEditMode(commentItemId);
                            return false;
                        });

                        var btnDeleteId = '#btnCommentItemDelete_' + commentItemId;
                        $(btnDeleteId).click(function () {
                            $('#hdnCommentItemId').val(commentItemId);
                            ajaxPost('DeleteComment');
                            return false;
                        });

                        $('#postBtn').removeClass('epmliveButton-disabled');
                        $('#postBtn').addClass('epmliveButton-emphasize');
                        $('#postBtn').attr('disabled', false);
                    }
                    break;
                case "DeleteComment":
                    if (oJson.Result.Status == "1") {
                        alert("Error");
                    }
                    else {
                        var commentItemId2 = '#commentItem_' + $('#hdnCommentItemId').val();
                        $(commentItemId2).remove();
                    }
                    break;
                case "UpdateComment":
                    if (oJson.Result.Status == "1") {
                        alert("Error");
                    }
                    else {
                        var divOrigCommentId = '#commentItem_' + $('#hdnCommentItemId').val();
                        $(divOrigCommentId).css('display', '');
                        $(divOrigCommentId).find('#divComment_' + $('#hdnCommentItemId').val()).html(qsNewComment);
                        var divCommentId = '#divCommentEdit_' + $('#hdnCommentItemId').val();
                        $(divCommentId).remove();
                    }
                    break
                default:
                    break;
            }
        }
    };

    xmlhttp.send("command=" + command +
                        "&comment=" + qsComment +
    //"&commenthtml=" + qsCommentHTML +
                        "&newcomment=" + qsNewComment +
    //"&newcommenthtml=" + qsNewCommentHTML +
                        "&itemId=" + qsItemId +
                        "&listId=" + qsListId +
                        "&commentItemId=" + qsCommentItemId +
                        "&userId=" + qsUserId);

    // clear text box
    $('#tbCommentInput').html("");
}

function ItemCreatedSuccessfully() {
}

function ItemEditedSuccessfully() {
}

function ItemDeletedSuccessfully() {
}

function UnescapeHTMLtoXML(escapedHTML) {
    var d = document.createElement("div");
    d.innerHTML = escapedHTML;
    if (!d.innerText) {
        return d.textContent;
    } else {
        return d.innerText;
    }
}