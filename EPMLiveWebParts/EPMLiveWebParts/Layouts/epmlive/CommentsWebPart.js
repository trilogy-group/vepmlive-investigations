/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" />

function GetData() {
    (function ($$, $, undefined) {
        var loadingDiv = "<div class=\"workingNewComment\" id=\"divWorkingNewComment\">" +
                                    "<IMG style=\"VERTICAL-ALIGN: middle; margin-left:40%;\" title=\"Loading...\" alt=\"Loading...\" src=\"/_layouts/images/progress-circle-24.gif\">&nbsp;" +
                                    "<SPAN style=\"TEXT-ALIGN: center; WHITE-SPACE: nowrap; COLOR: black; VERTICAL-ALIGN: middle; OVERFLOW: hidden;font-family:Verdana;font-size:12px;color:#686868;\">Loading...</SPAN>" +
                                    "</div>";
        var loadedItemIds = '';
        var commentDivider = '<div class=\"commentDivider\"></div><div style="height:12px;"></div>';
        var CommentTemp =
             '<div id="divCommentItem##itemId##" style="">' +
                '<table class="ms-socialCommentItem customCommentItem" id="commentItem_##itemId##">' +
                    '<tbody>' +
                        '<tr>' +
                            '<td class="socialcomment-image" vAlign="left" rowSpan="2">' +
                                '<img alt="User Photo" style="width:45px;height:45px" src="##userPicUrl##">' +
                            '</td>' +
                            '<td class="socialcomment-IMPawn" rowSpan="2" align="left">' +
                                '<span class="ms-imnSpan">' +
	                                '<a class="ms-imnlink ms-spimn-presenceLink" onclick="IMNImageOnClick(event); return false;" href="#">' +
		                                '<span class="ms-spimn-presenceWrapper ms-imnImg ms-spimn-imgSize-10x10"><img id="imn0,type=sip" sip="##userEmail##" src="/_layouts/15/images/spimn.png" showofflinepawn="1" class="ms-spimn-img ms-spimn-presence-disconnected-10x10x32" name="imnmark" alt="No presence information" title="">' +
		                                '</span>' +
	                                '</a>' +
                                '</span>' +

                            '</td>' +
                            '<td class="socialcomment-top" vAlign="left">' +
                                '<div>' +
                                    '<span class="socialcomment-username">' +
                                        '<a href="##userProfileUrl##" target="_blank"><b>##userName##</b></a>' +
                                    '</span>' +
                                    '<div style="clear:both;"></div>' +
                                    '<div id="divComment_##itemId##" class="commentWebpart-socialcomment-contents-TRC" style="color:black">##comment##</div>' +
                                    '<div style="clear:both;"></div>' +
                                    '<div style="margin-bottom:10px" ><span style="text-align:left;color:#707070;">##createdDate## on <a target="_blank" href="##listDispUrl##?ID=##itemId##">##itemTitle##</a> in <a target="_blank" href="##listUrl##">##listName##</a> list.</span></div>' +
                                '</div>' +
                            '</td>' +
                        '</tr>' +
                    '</tbody>' +
                '</table>' +
            '</div>';

        var PublicCommentTemp =
             '<div id="divPublicCommentItem##itemId##" style="">' +
                '<table class="ms-socialCommentItem customCommentItem" id="publicCommentItem_##itemId##">' +
                    '<tbody>' +
                        '<tr>' +
                            '<td class="socialcomment-image" vAlign="left" rowSpan="2">' +
                                '<img alt="User Photo" style="width:45px;height:45px" src="##userPicUrl##">' +
                            '</td>' +
                            '<td class="socialcomment-IMPawn" rowSpan="2" align="left">' +
                                '<span class="ms-imnSpan">' +
	                                '<a class="ms-imnlink ms-spimn-presenceLink" onclick="IMNImageOnClick(event); return false;" href="#">' +
		                                '<span class="ms-spimn-presenceWrapper ms-imnImg ms-spimn-imgSize-10x10"><img id="imn0,type=sip" sip="##userEmail##" src="/_layouts/15/images/spimn.png" showofflinepawn="1" class="ms-spimn-img ms-spimn-presence-disconnected-10x10x32" name="imnmark" alt="No presence information" title="">' +
		                                '</span>' +
	                                '</a>' +
                                '</span>' +

                            '</td>' +
                            '<td class="socialcomment-top" vAlign="left">' +
                                '<div>' +
                                    '<span class="socialcomment-username">' +
                                        '<a href="##userProfileUrl##" target="_blank"><b>##userName##</b></a>' +
                                    '</span>' +
                                    '<div style="clear:both;"></div>' +
                                    '<div id="divPublicComment_##itemId##" class="commentWebpart-socialcomment-contents-TRC" style="color:black">##comment##</div>' +
                                    '<div style="clear:both;"></div>' +
                                    '<div style="margin-bottom:10px" ><span style="text-align:left;color:#707070;">##createdDate## on <a target="_blank" href="##workspaceUrl##">##workspaceTitle##</a>.</span></div>' +
                                '</div>' +
                            '</td>' +
                        '</tr>' +
                    '</tbody>' +
                '</table>' +
            '</div>';
        // the notch
        //        '<div style="margin-left:60px" class="callout border-callout" id="callout_##listId##_##itemId##">' +
        //            '<b class="border-notch notch"></b>' +
        //                '<b class="notch"></b>' +
        //            '</div>';

        var SubCommentTemp =
            '<div class=\"subitem\" item=\"##listId##_##itemId##\" isExtra=\"##isExtra##\">' +
                '<table class="ms-socialCommentItem customCommentItem" id="commentItem_##itemId##">' +
                    '<tbody>' +
                        '<tr>' +
                            '<td class="socialcomment-image" vAlign="left" rowSpan="2">' +
                                '<img alt="User Photo" style="width:32px;height:32px" src="##userPicUrl##">' +
                            '</td>' +
                            '<td class="socialcomment-IMPawn" rowSpan="2" align="left">' +
                                '<span class="ms-imnSpan">' +
	                                '<a class="ms-imnlink ms-spimn-presenceLink" onclick="IMNImageOnClick(event); return false;" href="#">' +
		                                '<span class="ms-spimn-presenceWrapper ms-imnImg ms-spimn-imgSize-10x10"><img id="imn0,type=sip" sip="##userEmail##" src="/_layouts/15/images/spimn.png" showofflinepawn="1" class="ms-spimn-img ms-spimn-presence-disconnected-10x10x32" name="imnmark" alt="No presence information" title="">' +
		                                '</span>' +
	                                '</a>' +
                                '</span>' +
                            '</td>' +
                            '<td class="socialcomment-top" vAlign="left">' +
                                '<div>' +
                                    '<span class="socialcomment-username">' +
                                        '<a href="##userProfileUrl##" target="_parent"><b>##userName##</b></a>' +
                                    '</span>' +
                                    '<div style="clear:both;"></div>' +
                                    '<div id="divComment_##itemId##" class="commentWebpart-socialcomment-contents-TRC" style="color:black">##comment##</div>' +
                                    '<div style="clear:both;"></div>' +
                                    '<div><span style="text-align:left;color:#707070;">##createdDate##</span></div>' +
                                '</div>' +
                            '</td>' +
                        '</tr>' +
                    '</tbody>' +
                '</table>' +
            '</div>' +
            '<div style=\"clear:both\"></div>';

        var HiddenSubCommentTemp =
            '<div class=\"subitem\" item=\"##listId##_##itemId##\" style="" isExtra=\"##isExtra##\">' +
                '<table class="ms-socialCommentItem customCommentItem" id="commentItem_##itemId##">' +
                    '<tbody>' +
                        '<tr>' +
                            '<td class="socialcomment-image" vAlign="left" rowSpan="2">' +
                                '<img alt="User Photo" style="width:32px;height:32px" src="##userPicUrl##">' +
                            '</td>' +
                            '<td class="socialcomment-IMPawn" rowSpan="2" align="left">' +
                                //'<div id="DataFrameManager_ctl02_socomIM_0" class="socialcomment-IMPawn">' +
                                //    '<span>' +
                                //        '<img border="0" id="commentAvailBubble##itemId##" alt="Status indicator" src="/_layouts/images/imnhdr.gif" width="12" onload="IMNRC(\'##userEmail##\');" height="12" ShowOfflinePawn="1">' +
                                //    '</span>' +
                                //'</div>' +
                                '<span class="ms-imnSpan">' +
	                                '<a class="ms-imnlink ms-spimn-presenceLink" onclick="IMNImageOnClick(event); return false;" href="#">' +
		                                '<span class="ms-spimn-presenceWrapper ms-imnImg ms-spimn-imgSize-10x10"><img id="imn0,type=sip" sip="##userEmail##" src="/_layouts/15/images/spimn.png" showofflinepawn="1" class="ms-spimn-img ms-spimn-presence-disconnected-10x10x32" name="imnmark" alt="No presence information" title="">' +
		                                '</span>' +
	                                '</a>' +
                                '</span>' +
                            '</td>' +
                            '<td class="socialcomment-top" vAlign="left">' +
                                '<div>' +
                                    '<span class="socialcomment-username">' +
                                        '<a href="##userProfileUrl##" target="_parent"><b>##userName##</b></a>' +
                                    '</span>' +
                                    '<div style="clear:both;"></div>' +
                                    '<div id="divComment_##itemId##" class="commentWebpart-socialcomment-contents-TRC" style="color:black">##comment##</div>' +
                                    '<div style="clear:both;"></div>' +
                                    '<div><span style="text-align:left;color:#707070;">##createdDate##</span></div>' +
                                '</div>' +
                            '</td>' +
                        '</tr>' +
                    '</tbody>' +
                '</table>' +
            '</div>' +
            '<div style=\"clear:both\"></div>';
        var newCommentTemp =
        // this is always at the end
            '<div id="newItemAnchor_##listId##_##itemId##">' +
            '</div>' +
            '<div style=\"clear:both\"></div>' +
            '<div style=\"padding-top: 8px; padding-left: 5px;\">' +
                '<a class=\'newCommentReply\' id=\'aNewCommentReply##itemId##\' href=\'#\'>reply</a>' +
                '<div class="inputSearch tbComment epmliveinput" style="display:none;width: 95%;background:white;" id="tbCommentInput##itemId##" class="ms-socialCommentInputBox ms-rtestate-write tbCommentInput" contenteditable="true" disableribboncommands="True">' +
                    '<span style="color:gray">Write a reply...</span>' +
                '</div>' +
                '<div style="height: 25px; margin-right: 5px; float: left; margin-top: 3px;display:none">' +
                    '<a class="btn-primary btn btn-small" style="margin-left:0px !important; font-size: 10px !important;" href="#" id="btnNewComment##itemId##" onclick="window.commentsWebPart.AddComment(\'##listId##\', \'##itemId##\', $(\'#tbCommentInput##itemId##\').html(), \'newItemAnchor_##listId##_##itemId##\');" >Comment</a>' +
                '</div>' +
            '</div>' +
            '<div style=\"clear:both\"></div>';
       
        var newPubCommentTemp =
        // this is always at the end
            '<div id="newItemAnchor_##listId##_##itemId##">' +
            '</div>' +
            '<div style=\"clear:both\"></div>' +
            '<div style=\"padding-top: 8px; padding-left: 5px;\">' +
                '<a class=\'newCommentReply\' id=\'aNewCommentReply##itemId##\' href=\'#\'>reply</a>' +
                '<div class="inputSearch tbComment epmliveinput" style="display:none;width: 95%;background:white;" id="tbCommentInput##itemId##" class="ms-socialCommentInputBox ms-rtestate-write tbCommentInput" contenteditable="true" disableribboncommands="True">' +
                    '<span style="color:gray">Write a reply...</span>' +
                '</div>' +
                '<div style="height: 25px; margin-right: 5px; float: left; margin-top: 3px;display:none">' +
                    '<a class="btn-primary btn btn-small" style="margin-left:0px !important; font-size: 10px !important;" href="#" id="btnNewComment##itemId##" onclick="window.commentsWebPart.AddComment(\'##pubComListId##\', \'##pubComItemId##\', $(\'#tbCommentInput##itemId##\').html(), \'newItemAnchor_##listId##_##itemId##\');" >Comment</a>' +
                '</div>' +
            '</div>' +
            '<div style=\"clear:both\"></div>';

        function BeginGetMyCommentsByNotification() {

            $.ajax({
                type: 'POST',
                url: curWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'GetNotifications', Dataxml: '<Notifications Status=\"ALL\" Limit=\"0\" FirstPage=\"0\" LastPage=\"0\" FirstLoad=\"true\"/>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',

                success: function (response) {
                    if (response.d) {
                        var responseJson = window.epmLive.parseJson(response.d);

                        if (window.epmLive.responseIsSuccess(responseJson.Result)) {
                            var data = '<Data>';
                            data += '<Param key="NumThreads">' + numThreads + '</Param>';
                            if (responseJson.Result.Notifications) {
                                data += '<Param key="ItemIds">';
                                var notifications;
                                if (responseJson.Result.Notifications.Notification) {
                                    if (!responseJson.Result.Notifications.Notification.length) {
                                        notifications = [responseJson.Result.Notifications.Notification];
                                    } else {
                                        notifications = responseJson.Result.Notifications.Notification;
                                    }
                                    for (var i in notifications) {
                                        if (notifications[i]['@Type'] == '3') {
                                            data += (notifications[i]['@ListId'] + '.' + notifications[i]['@ItemId'] + ',');
                                        }
                                    }
                                }
                                data += '</Param>';
                            }
                            data += '</Data>';

                            GetMyCommentsByDate(data);

                        } else {
                            window.epmLive.logFailure(responseJson.Result);
                        }
                    } else {
                        window.epmLive.log('response.d: ' + response.d);
                    }
                },

                error: function (error) {
                    window.epmLive.log(error);
                }
            });
        }

        function BeginGetMoreCommentsByNotification() {

            $.ajax({
                type: 'POST',
                url: curWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'GetNotifications', Dataxml: '<Notifications Status=\"ALL\" Limit=\"0\" FirstPage=\"0\" LastPage=\"0\" FirstLoad=\"true\"/>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',

                success: function (response) {
                    if (response.d) {
                        var responseJson = window.epmLive.parseJson(response.d);

                        if (window.epmLive.responseIsSuccess(responseJson.Result)) {
                            var data = '<Data>';
                            data += '<Param key="NumThreads">' + numThreads + '</Param>';
                            data += '<Param key="LoadedItemIds">' + loadedItemIds + '</Param>';
                            if (responseJson.Result.Notifications) {
                                data += '<Param key="ItemIds">';
                                var notifications;
                                if (!responseJson.Result.Notifications.Notification.length) {
                                    notifications = [responseJson.Result.Notifications.Notification];
                                }
                                else {
                                    notifications = responseJson.Result.Notifications.Notification;
                                }
                                for (var i in notifications) {
                                    if (notifications[i]['@Type'] == '3') {
                                        data += (notifications[i]['@ListId'] + '.' + notifications[i]['@ItemId'] + ',');
                                    }
                                }
                                data += '</Param>';
                            }
                            data += '</Data>';

                            GetMyNextCommentsByDate(data);

                        } else {
                            window.epmLive.logFailure(responseJson.Result);
                        }
                    } else {
                        window.epmLive.log('response.d: ' + response.d);
                    }
                },

                error: function (error) {
                    window.epmLive.log(error);
                }
            });
        }

        function GetMyNextCommentsByDate(dataXml) {

            $.ajax({
                type: 'POST',
                url: curWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'GetMyCommentsByDate', Dataxml: '" + dataXml + "' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',

                success: function (response) {
                    $('#divLoader_CommentsWebPart').css('display', 'none');

                    if (response.d) {
                        var responseJson = window.epmLive.parseJson(response.d);

                        if (window.epmLive.responseIsSuccess(responseJson.Result)) {
                            // remember what items has been loaded
                            loadedItemIds += ',' + responseJson.Result.Comments.LoadedIds;

                            if (responseJson.Result.Comments && responseJson.Result.Comments.CommentItem) {
                                var comments;
                                if (!responseJson.Result.Comments.CommentItem.length) {
                                    comments = [responseJson.Result.Comments.CommentItem];
                                }
                                else {
                                    comments = responseJson.Result.Comments.CommentItem;
                                }
                                var headingSpacePlaced;
                                var hasComments = false;
                                for (var i in comments) {
                                    headingSpacePlaced = false;
                                    var currentComments;
                                    if (comments[i].Comment) {
                                        if (!comments[i].Comment.length) {
                                            currentComments = [comments[i].Comment];
                                        }
                                        else {
                                            currentComments = comments[i].Comment;
                                        }
                                    }

                                    for (var j in currentComments) {

                                        var oComment = currentComments[j];
                                        if (parseInt(j) === 0) {
                                            if (!headingSpacePlaced) {
                                                $('#commentsWebPartMainContainer').append('<div style="clear:both;height:10px;"></div>');
                                            } else {
                                                $('#commentsWebPartMainContainer').append(commentDivider);
                                            }
                                            headingSpacePlaced = true;
                                            var commentItem;
                                            if (oComment['@itemTitle']) {
                                                commentItem = CommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                       .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                       .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                       .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                       .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                       .replace(/##createdDate##/g, oComment['@createdDate'])
                                                                       .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                       .replace(/##itemTitle##/g, oComment['@itemTitle'])
                                                                       .replace(/##listName##/g, oComment['@listName'])
                                                                       .replace(/##listUrl##/g, oComment['@listUrl'])
                                                                       .replace(/##listDispUrl##/g, oComment['@listDispUrl'])
                                                                       .replace(/##listId##/g, oComment['@listId']);
                                            } else {
                                                commentItem = PublicCommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                       .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                       .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                       .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                       .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                       .replace(/##createdDate##/g, oComment['@createdDate'])
                                                                       .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                       .replace(/##workspaceUrl##/g, curWebUrl)
                                                                       .replace(/##workspaceTitle##/g, curWebTitle);
                                            }
                                            hasComments = true;

                                            $('#commentsWebPartMainContainer').append(commentItem);

                                            $('#commentsWebPartMainContainer').append(
                                                '<div style="clear:both;margin-top:3px"/>' +
                                                '<div style="margin-left:60px" class="callout border-callout" id="callout_' + oComment['@listId'] + '_' + oComment['@itemId'] + '">' +
                                                    '<b class="border-notch notch"></b>' +
                                                    '<b class="notch"></b>' +
                                                '</div>');

                                            if (currentComments.length > parseInt(maxComments)) {
                                                var showAllButton = '<div style=\"margin-top: 5px;padding-left:5px;border-bottom:1px solid #c5d9e8;padding:3px;\">' +
                                                                        '<a id=\"lnkshowAll_##listId##_##itemId##" href="#" onclick="window.commentsWebPart.ShowAllComments($(this));">Show All</a>' +
                                                                    '</div>';

                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(
                                                showAllButton.replace(/##itemId##/g, oComment['@itemId'])
                                                             .replace(/##listId##/g, oComment['@listId'])
                                                );
                                            }

                                            // add new comment box
                                            if (parseInt(j) === currentComments.length - 1) {
                                                var newCommentBox;
                                                newCommentBox = newCommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                   .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                   .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                   .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                   .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                   .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                   .replace(/##itemTitle##/g, oComment['@itemTitle'])
                                                                   .replace(/##listName##/g, oComment['@listName'])
                                                                   .replace(/##listUrl##/g, oComment['@listUrl'])
                                                                   .replace(/##listDispUrl##/g, oComment['@listDispUrl'])
                                                                   .replace(/##listId##/g, oComment['@listId']);

                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(newCommentBox);
                                            }
                                        }
                                        else {

                                            var commentItem;
                                            var isExtra = (parseInt(j) < (currentComments.length - parseInt(maxComments))) ? true : false;
                                            commentItem = SubCommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                   .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                   .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                   .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                   .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                   .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                   .replace(/##itemTitle##/g, oComment['@itemTitle'])
                                                                   .replace(/##listName##/g, oComment['@listName'])
                                                                   .replace(/##listUrl##/g, oComment['@listUrl'])
                                                                   .replace(/##listDispUrl##/g, oComment['@listDispUrl'])
                                                                   .replace(/##listId##/g, oComment['@listId'])
                                                                   .replace(/##createdDate##/g, oComment['@createdDate']);
                                            if (isExtra) {
                                                var c = $(commentItem).css('display', 'none');
                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(c);
                                            }
                                            else {
                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(commentItem);
                                            }

                                            if (parseInt(j) === currentComments.length - 1) {
                                                var newCommentBox;
                                                newCommentBox = newCommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                   .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                   .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                   .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                   .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                   .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                   .replace(/##itemTitle##/g, oComment['@itemTitle'])
                                                                   .replace(/##listName##/g, oComment['@listName'])
                                                                   .replace(/##listUrl##/g, oComment['@listUrl'])
                                                                   .replace(/##listDispUrl##/g, oComment['@listDispUrl'])
                                                                   .replace(/##listId##/g, oComment['@listId']);

                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(newCommentBox);
                                            }
                                        }

                                        $('#aNewCommentReply' + oComment['@itemId']).click(function (e) {
                                            var id = $(this).attr('id').replace('aNewCommentReply', '');
                                            $('#tbCommentInput' + id).css('display', '');
                                            $('#btnNewComment' + id).parent().css('display', '');
                                            $(this).css('display', 'none');
                                            if ($('#commentsWebPartMainContainer').scrollTop() > ($('#commentsWebPartMainContainer').height() + $(document).height())) {
                                                $('#commentsWebPartMainContainer').scrollTop($('#commentsWebPartMainContainer').scrollTop() + 150);
                                            }
                                            $('#tbCommentInput' + id).focus();
                                        });

                                        $('#tbCommentInput' + oComment['@itemId']).focus(function () {
                                            if ($$.UnescapeHTML($(this).html()) === 'Write a reply...') {
                                                $(this).empty();
                                            }
                                        });

                                        $('#tbCommentInput' + oComment['@itemId']).blur(function (e) {
                                            return true;
                                        });

                                        $('#tbCommentInput' + oComment['@itemId']).change(function () {
                                            var $this = $(this), minHeight = $this.height(), lineHeight = $this.css('lineHeight');
                                            var shadow = $('<div class="inputSearch"></div>').css({ position: 'absolute', top: -10000, left: -10000, width: $this.width(), fontSize: $this.css('fontSize'), fontFamily: $this.css('fontFamily'), lineHeight: $this.css('lineHeight'), resize: 'none' }).appendTo(document.body);

                                            if ($(this).text() !== 'Write a reply...') {
                                                var val = $(this).text().replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/&/g, '&amp;').replace(/\n/g, '<br/>');
                                                shadow.html(val);
                                                $(this).css('height', Math.max(shadow.height(), minHeight));
                                            }
                                        });

                                        $('#tbCommentInput' + oComment['@itemId']).keyup(function (e) {
                                            var id = $(this).attr('id').replace('tbCommentInput', '');
                                            var $this = $(this), minHeight = $this.height(), lineHeight = $this.css('lineHeight');
                                            var shadow = $('<div class="inputSearch"></div>').css({ position: 'absolute', top: -10000, left: -10000, width: $this.width(), fontSize: $this.css('fontSize'), fontFamily: $this.css('fontFamily'), lineHeight: $this.css('lineHeight'), resize: 'none' }).appendTo(document.body);

                                            if ($(this).text() !== 'Write a reply...') {
                                                var val = $(this).text().replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/&/g, '&amp;').replace(/\n/g, '<br/>');
                                                shadow.html(val);
                                                if (e.keyCode != 8 && e.keyCode != 46) {
                                                    $(this).css('height', Math.max(shadow.height(), minHeight));
                                                }
                                                else {
                                                    var minH = Math.min(shadow.height(), minHeight);
                                                    if (minH <= 0) {
                                                        minH = 15;
                                                    }
                                                    $(this).css('height', Math.min(shadow.height(), minH));
                                                }
                                            }

                                            var value = $(this).text();

                                            if (value.length > 0) {
                                                $('#btnNewComment' + id).removeClass('btn-disabled');
                                            }
                                            else {
                                                $('#btnNewComment' + id).addClass('btn-disabled');
                                            }
                                        });

                                    }

                                }
                            }

                        } else {
                            window.epmLive.logFailure(responseJson.Result);
                        }
                    } else {
                        window.epmLive.log('response.d: ' + response.d);
                    }

                    //                    $.getScript('/_layouts/epmlive/TextBoxAutoGrow.js', function () {
                    //                        $('.tbComment').autogrow();
                    //                    });

                },
                error: function (error) {
                    window.epmLive.log(error);
                }
            });
        }

        function GetMyCommentsByDate(dataXml) {

            $.ajax({
                type: 'POST',
                url: curWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'GetMyCommentsByDate', Dataxml: '" + dataXml + "' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',

                success: function (response) {
                    $('#divLoader_CommentsWebPart').css('display', 'none');
                    if (response.d) {
                        var responseJson = window.epmLive.parseJson(response.d);

                        if (window.epmLive.responseIsSuccess(responseJson.Result)) {
                            // remember what items has been loaded
                            loadedItemIds = responseJson.Result.Comments.LoadedIds;

                            if (responseJson.Result.Comments && responseJson.Result.Comments.CommentItem) {
                                var comments;
                                if (!responseJson.Result.Comments.CommentItem.length) {
                                    comments = [responseJson.Result.Comments.CommentItem];
                                }
                                else {
                                    comments = responseJson.Result.Comments.CommentItem;
                                }
                                var headingSpacePlaced;
                                var hasComments = false;
                                for (var i in comments) {
                                    headingSpacePlaced = false;
                                    var currentComments = null;
                                    if (comments[i].Comment) {
                                        if (!comments[i].Comment.length) {
                                            currentComments = [comments[i].Comment];
                                        }
                                        else {
                                            currentComments = comments[i].Comment;
                                        }
                                    }

                                    for (var j in currentComments) {
                                        var oComment = currentComments[j];
                                        if (parseInt(j) === 0) {
                                            if (!headingSpacePlaced) {
                                                $('#commentsWebPartMainContainer').append('<div style="clear:both;height:10px;"></div>');
                                            } else {
                                                $('#commentsWebPartMainContainer').append(commentDivider);
                                            }
                                            headingSpacePlaced = true;


                                            var commentItem;
                                            if (oComment['@itemTitle']) {
                                                commentItem = CommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                       .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                       .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                       .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                       .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                       .replace(/##createdDate##/g, oComment['@createdDate'])
                                                                       .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                       .replace(/##itemTitle##/g, oComment['@itemTitle'])
                                                                       .replace(/##listName##/g, oComment['@listName'])
                                                                       .replace(/##listUrl##/g, oComment['@listUrl'])
                                                                       .replace(/##listDispUrl##/g, oComment['@listDispUrl'])
                                                                       .replace(/##listId##/g, oComment['@listId']);
                                            } else {
                                                commentItem = PublicCommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                       .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                       .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                       .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                       .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                       .replace(/##createdDate##/g, oComment['@createdDate'])
                                                                       .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                       .replace(/##workspaceUrl##/g, curWebUrl)
                                                                       .replace(/##workspaceTitle##/g, curWebTitle);
                                            }
                                            hasComments = true;

                                            $('#commentsWebPartMainContainer').append(commentItem);

                                            $('#commentsWebPartMainContainer').append(
                                                '<div style="margin-left:60px" class="callout border-callout" id="callout_' + oComment['@listId'] + '_' + oComment['@itemId'] + '">' +
                                                    '<b class="border-notch notch"></b>' +
                                                    '<b class="notch"></b>' +
                                                '</div>');

                                            if (currentComments.length > parseInt(maxComments)) {
                                                var showAllButton = '<div style=\"margin-top: 5px;padding-left:5px;border-bottom:1px solid #c5d9e8;padding:3px;\">' +
                                                                        '<a id=\"lnkshowAll_##listId##_##itemId##" href="#" onclick="window.commentsWebPart.ShowAllComments($(this));">Show All</a>' +
                                                                    '</div>';

                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(
                                                showAllButton.replace(/##itemId##/g, oComment['@itemId'])
                                                             .replace(/##listId##/g, oComment['@listId'])
                                                );
                                            }

                                            // add new comment box
                                            if (parseInt(j) === currentComments.length - 1) {
                                                var newCommentBox;
                                                newCommentBox = newCommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                   .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                   .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                   .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                   .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                   .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                   .replace(/##itemTitle##/g, oComment['@itemTitle'])
                                                                   .replace(/##listName##/g, oComment['@listName'])
                                                                   .replace(/##listUrl##/g, oComment['@listUrl'])
                                                                   .replace(/##listDispUrl##/g, oComment['@listDispUrl'])
                                                                   .replace(/##listId##/g, oComment['@listId']);

                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(newCommentBox);
                                            }
                                        }
                                        else {

                                            var commentItem;
                                            var isExtra = (parseInt(j) < (currentComments.length - parseInt(maxComments))) ? true : false;
                                            commentItem = SubCommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                   .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                   .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                   .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                   .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                   .replace(/##createdDate##/g, oComment['@createdDate'])
                                                                   .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                   .replace(/##itemTitle##/g, oComment['@itemTitle'])
                                                                   .replace(/##listName##/g, oComment['@listName'])
                                                                   .replace(/##listUrl##/g, oComment['@listUrl'])
                                                                   .replace(/##listDispUrl##/g, oComment['@listDispUrl'])
                                                                   .replace(/##listId##/g, oComment['@listId'])
                                                                   .replace(/##isExtra##/g, isExtra);
                                            if (isExtra) {
                                                var c = $(commentItem).css('display', 'none');
                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(c);
                                            }
                                            else {
                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(commentItem);
                                            }

                                            if (parseInt(j) === currentComments.length - 1) {
                                                var newCommentBox;
                                                newCommentBox = newCommentTemp.replace(/##itemId##/g, oComment['@itemId'])
                                                                   .replace(/##userPicUrl##/g, oComment.UserInfo.UserPic['#cdata'])
                                                                   .replace(/##userEmail##/g, oComment.UserInfo.UserEmail['#cdata'])
                                                                   .replace(/##userProfileUrl##/g, oComment.UserInfo.UserProfileUrl['#cdata'])
                                                                   .replace(/##userName##/g, oComment.UserInfo.UserName['#cdata'])
                                                                   .replace(/##comment##/g, $$.xmlUnescape(oComment['#cdata']))
                                                                   .replace(/##itemTitle##/g, oComment['@itemTitle'])
                                                                   .replace(/##listName##/g, oComment['@listName'])
                                                                   .replace(/##listUrl##/g, oComment['@listUrl'])
                                                                   .replace(/##listDispUrl##/g, oComment['@listDispUrl'])
                                                                   .replace(/##listId##/g, oComment['@listId']);

                                                $('#callout_' + oComment['@listId'] + '_' + oComment['@itemId']).append(newCommentBox);
                                            }
                                        }


                                        //                                        $('#tbCommentInput' + oComment['@itemId']).mouseenter(function () {
                                        //                                            if ($$.UnescapeHTML($(this).html()) === 'Write a reply...') {
                                        //                                                $(this).empty();
                                        //                                            }
                                        //                                        });

                                        //                                        $('#tbCommentInput' + oComment['@itemId']).mouseout(function () {
                                        //                                            if (!$(this).is(':focus')) {
                                        //                                                if ($$.UnescapeHTML($(this).html()) === undefined || $$.UnescapeHTML($(this).html()) === '') {
                                        //                                                    $(this).append($('<span style="color:gray">Write a reply...</span>'));
                                        //                                                }
                                        //                                            }
                                        //                                        });

                                        $('#tbCommentInput' + oComment['@itemId']).focus(function () {
                                            //                                            var id = $(this).attr('id').replace('tbCommentInput', '');
                                            //                                            var newCommentBtnId = 'btnNewComment' + id;
                                            //                                            $('#' + newCommentBtnId).parent().css('display', '');

                                            if ($$.UnescapeHTML($(this).html()) === 'Write a reply...') {
                                                $(this).empty();
                                            }
                                        });


                                        $('#aNewCommentReply' + oComment['@itemId']).click(function (e) {
                                            var id = $(this).attr('id').replace('aNewCommentReply', '');
                                            $('#tbCommentInput' + id).css('display', '');
                                            $('#btnNewComment' + id).parent().css('display', '');
                                            $(this).css('display', 'none');
                                            if ($('#commentsWebPartMainContainer').scrollTop() > ($('#commentsWebPartMainContainer').height() + $(document).height())) {
                                                $('#commentsWebPartMainContainer').scrollTop($('#commentsWebPartMainContainer').scrollTop() + 150);
                                            }
                                            $('#tbCommentInput' + id).focus();
                                        });

                                        $('#tbCommentInput' + oComment['@itemId']).blur(function (e) {
                                            //                                            var id = $(this).attr('id').replace('tbCommentInput', '');
                                            //                                            var newTarget = e.originalEvent.explicitOriginalTarget || document.activeElement;
                                            //                                            var newCommentBtnId = 'btnNewComment' + id;

                                            //                                            if (newTarget.id != newCommentBtnId) {
                                            //                                                $('#' + newCommentBtnId).parent().css('display', 'none');
                                            //                                                $(this).css('display', 'none');
                                            //                                                $('#aNewCommentReply' + id).css('display', '');
                                            //                                            }
                                            //                                            if ($$.UnescapeHTML($(this).html()) === undefined || $$.UnescapeHTML($(this).html()) === '') {
                                            //                                                $(this).append($('<span style="color:gray">Write a reply...</span>'));
                                            //                                            }

                                            return true;
                                        });

                                        $('#tbCommentInput' + oComment['@itemId']).change(function () {
                                            var $this = $(this), minHeight = $this.height(), lineHeight = $this.css('lineHeight');
                                            var shadow = $('<div class="inputSearch"></div>').css({ position: 'absolute', top: -10000, left: -10000, width: $this.width(), fontSize: $this.css('fontSize'), fontFamily: $this.css('fontFamily'), lineHeight: $this.css('lineHeight'), resize: 'none' }).appendTo(document.body);

                                            if ($(this).text() !== 'Write a reply...') {
                                                var val = $(this).html(); //.replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/&/g, '&amp;').replace(/\n/g, '<br/>');
                                                shadow.html(val);
                                                $(this).css('height', Math.max(shadow.height(), minHeight));
                                            }
                                        });

                                        $('#tbCommentInput' + oComment['@itemId']).keyup(function (e) {
                                            var id = $(this).attr('id').replace('tbCommentInput', '');
                                            var $this = $(this), minHeight = $this.height(), lineHeight = $this.css('lineHeight');
                                            var shadow = $('<div class="inputSearch"></div>').css({ position: 'absolute', top: -10000, left: -10000, width: $this.width(), fontSize: $this.css('fontSize'), fontFamily: $this.css('fontFamily'), lineHeight: $this.css('lineHeight'), resize: 'none' }).appendTo(document.body);

                                            if ($(this).text() !== 'Write a reply...') {
                                                var val = $(this).html(); //.replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/&/g, '&amp;').replace(/\n/g, '<br/>');
                                                shadow.html(val);
                                                if (e.keyCode != 8 && e.keyCode != 46) {
                                                    $(this).css('height', Math.max(shadow.height(), minHeight));
                                                }
                                                else {
                                                    var minH = Math.min(shadow.height(), minHeight);
                                                    if (minH <= 0) {
                                                        minH = 15;
                                                    }
                                                    $(this).css('height', minH);
                                                }
                                            }

                                            var value = $(this).text();
                                            if (value.length > 0) {
                                                $('#btnNewComment' + id).removeClass('btn-disabled');
                                            }
                                            else {
                                                $('#btnNewComment' + id).addClass('btn-disabled');
                                            }
                                        });


                                    }

                                }
                            }
                            else {
                                $('#divNoCommentIndicator').css('display', '');
                            }
                        } else {
                            window.epmLive.logFailure(responseJson.Result);
                        }
                    } else {
                        window.epmLive.log('response.d: ' + response.d);
                    }

                    if (!hasComments) {
                        $('#divNoCommentIndicator').css('display', '');
                    }
                    else {
                        $.getScript('/_layouts/epmlive/slimScroll.js', function () {
                            //$('#commentsWebPartMainContainer').slimScroll({ height: '300px', size: '10px', wheelStep: 5 });
                        }, true);

                        $.getScript('/_layouts/epmlive/javascripts/libraries/jquery.endless-scroll.js', function () {
                            $('#commentsWebPartMainContainer').endlessScroll({
                                callback:
                                function () {
                                    BeginGetMoreCommentsByNotification();
                                }
                            });
                        }, true);

                        //                        $.getScript('/_layouts/epmlive/TextBoxAutoGrow.js', function () {
                        //                            $('.tbComment').autogrow();
                        //                        });
                    }
                },
                error: function (error) {
                    window.epmLive.log(error);
                }
            });
        }

        $$.AddComment = function (listId, itemId, comment, containerId) {
            //<Data>
            // <Param key="ListId">someguid</Param>
            // <Param key="ItemId">12</Param>
            // <Param key="Comment">abcabac</Param>
            // </Data>
            $('#tbCommentInput' + itemId).css('display', 'none');
            $('#btnNewComment' + itemId).parent().css('display', 'none');
            //$('#' + containerId).before(loadingDiv);

            if (comment !== undefined) {
                var orginalComment = comment;

                var dataXml = '<Data><Param key="ListId">' + listId + '</Param><Param key="ItemId">' + itemId + '</Param><Param key="Comment"><![CDATA[' + comment + ']]></Param></Data>';

                $.ajax({
                    type: 'POST',
                    url: curWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'CreateComment', Dataxml: '" + dataXml + "' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response.d) {
                            var responseJson = window.epmLive.parseJson(response.d);
                            if (window.epmLive.responseIsSuccess(responseJson.Result)) {

                                var commentItem = HiddenSubCommentTemp
                                    .replace(/##itemId##/g, itemId)
                                    .replace(/##userPicUrl##/g, userPicUrl)
                                    .replace(/##userEmail##/g, userEmail)
                                    .replace(/##userProfileUrl##/g, userProfileUrl)
                                    .replace(/##userName##/g, userName)
                                    .replace(/##createdDate##/g, responseJson.Result.Comments.CommentItem.Comment['@createdDate'])
                                    .replace(/##comment##/g, orginalComment)
                                    .replace(/##itemTitle##/g, responseJson.Result.Comments.CommentItem.Comment['@itemTitle'])
                                    .replace(/##listName##/g, responseJson.Result.Comments.CommentItem.Comment['@listName']);

                                $('#' + containerId).before(commentItem);
                                //$('#divWorkingNewComment').fadeOut('slow', function () {
                                //    $('.subitem:last').fadeIn('slow', function () {
                                //        $('#divWorkingNewComment').remove();
                                //    });
                                //});
                            }
                        }

                        $('#tbCommentInput' + itemId).empty().html('<span style="color:gray">Write a reply...</span>');

                        $('#aNewCommentReply' + itemId).css('display', '');

                    },
                    error: function (e) {
                        alert('Failed to add new comment. ' + e.message);
                        $('#tbCommentInput' + itemId).empty();
                        $('#tbCommentInput' + itemId).css('display', 'none');
                        $('#btnNewComment' + itemId).parent().css('display', 'none');
                        $('#aNewCommentReply' + itemId).css('display', '');
                    }
                });
            } else {
                $('#btnNewComment' + itemId).parent().css('display', 'none');
            }
        };

        $$.AddPublicComment = function (comment) {
            //<Data>
            // <Param key="ListId">someguid</Param>
            // <Param key="ItemId">12</Param>
            // <Param key="Comment">abcabac</Param>
            // </Data>
            $('#divLoaderPublic_CommentsWebPart').css('display', '');

            if (comment !== undefined) {
                var orginalComment = comment;

                var dataXml = '<Data><Param key="Comment"><![CDATA[' + comment + ']]></Param></Data>';

                $.ajax({
                    type: 'POST',
                    url: curWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'CreatePublicComment', Dataxml: '" + dataXml + "' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {

                        $('#inputPublicComment').empty();
                        $('#inputPublicComment').html("<span style=\"color:gray\">" + sPubComTxt + "</span>");

                        if (response.d) {
                            var responseJson = window.epmLive.parseJson(response.d);
                            if (window.epmLive.responseIsSuccess(responseJson.Result)) {

                                var publicCommentItem = PublicCommentTemp.replace(/##itemId##/g, responseJson.Result.Comments.CommentItem['@itemId'])
                                                                  .replace(/##userPicUrl##/g, userPicUrl)
                                                                  .replace(/##userEmail##/g, userEmail)
                                                                  .replace(/##userProfileUrl##/g, userProfileUrl)
                                                                  .replace(/##userName##/g, userName)
                                                                  .replace(/##createdDate##/g, responseJson.Result.Comments.CommentItem.Comment['@createdDate'])
                                                                  .replace(/##comment##/g, orginalComment)
                                                                  .replace(/##workspaceUrl##/g, curWebUrl)
                                                                  .replace(/##workspaceTitle##/g, curWebTitle);

                                if ($('#commentsWebPartMainContainer').find('.customCommentItem').length > 0) {
                                    $($('#commentsWebPartMainContainer').find('.customCommentItem')[0]).before(publicCommentItem);
                                    $('#divPublicCommentItem' + responseJson.Result.Comments.CommentItem['@itemId']).after(
                                                '<div style="clear:both;margin-top:3px"/>' +
                                                '<div style="margin-left:60px" class="callout border-callout" id="callout_' + responseJson.Result.Comments.CommentItem.Comment['@listId'] + '_' + responseJson.Result.Comments.CommentItem['@itemId'] + '">' +
                                                    '<b class="border-notch notch"></b>' +
                                                    '<b class="notch"></b>' +
                                                '</div>' +
                                                '<div style="height: 10px; clear: both;"/>');
                                    var newCommentBox;
                                    newCommentBox = newPubCommentTemp.replace(/##itemId##/g, responseJson.Result.Comments.CommentItem['@itemId'])
                                                       .replace(/##userPicUrl##/g, userPicUrl)
                                                       .replace(/##userEmail##/g, userEmail)
                                                       .replace(/##userProfileUrl##/g, userProfileUrl)
                                                       .replace(/##userName##/g, userName)
                                                       .replace(/##comment##/g, orginalComment)
                                                       .replace(/##itemTitle##/g, responseJson.Result.Comments.CommentItem.Comment['@itemTitle'])
                                                       .replace(/##listName##/g, responseJson.Result.Comments.CommentItem.Comment['@listName'])
                                                       .replace(/##listUrl##/g, responseJson.Result.Comments.CommentItem.Comment['@listUrl'])
                                                       .replace(/##listDispUrl##/g, responseJson.Result.Comments.CommentItem.Comment['@listDispUrl'])
                                                       .replace(/##listId##/g, responseJson.Result.Comments.CommentItem.Comment['@listId'])
                                                       .replace(/##pubComItemId##/g, responseJson.Result.Comments.PublicCommentItem['@itemId'])
                                                       .replace(/##pubComListId##/g, responseJson.Result.Comments.PublicCommentItem['@listId']);
                                                       
                                    $('#callout_' + responseJson.Result.Comments.CommentItem.Comment['@listId'] + '_' + responseJson.Result.Comments.CommentItem['@itemId']).append(newCommentBox);
                                } else {
                                    $('#commentsWebPartMainContainer').append(publicCommentItem);
                                    $('#commentsWebPartMainContainer').append(
                                                '<div style="clear:both;margin-top:3px"/>' +
                                                '<div style="margin-left:60px" class="callout border-callout" id="callout_' + responseJson.Result.Comments.CommentItem.Comment['@listId'] + '_' + responseJson.Result.Comments.CommentItem['@itemId'] + '">' +
                                                    '<b class="border-notch notch"></b>' +
                                                    '<b class="notch"></b>' +
                                                '</div>');
                                    var newCommentBox;
                                    newCommentBox = newPubCommentTemp.replace(/##itemId##/g, responseJson.Result.Comments.CommentItem['@itemId'])
                                                       .replace(/##userPicUrl##/g, userPicUrl)
                                                       .replace(/##userEmail##/g, userEmail)
                                                       .replace(/##userProfileUrl##/g, userProfileUrl)
                                                       .replace(/##userName##/g, userName)
                                                       .replace(/##comment##/g, orginalComment)
                                                       .replace(/##itemTitle##/g, responseJson.Result.Comments.CommentItem.Comment['@itemTitle'])
                                                       .replace(/##listName##/g, responseJson.Result.Comments.CommentItem.Comment['@listName'])
                                                       .replace(/##listUrl##/g, responseJson.Result.Comments.CommentItem.Comment['@listUrl'])
                                                       .replace(/##listDispUrl##/g, responseJson.Result.Comments.CommentItem.Comment['@listDispUrl'])
                                                       .replace(/##listId##/g, responseJson.Result.Comments.CommentItem.Comment['@listId'])
                                                       .replace(/##pubComItemId##/g, responseJson.Result.Comments.PublicCommentItem['@itemId'])
                                                       .replace(/##pubComListId##/g, responseJson.Result.Comments.PublicCommentItem['@listId']);

                                    $('#callout_' + responseJson.Result.Comments.CommentItem.Comment['@listId'] + '_' + responseJson.Result.Comments.CommentItem['@itemId']).append(newCommentBox);
                                }

                                var iid = responseJson.Result.Comments.CommentItem['@itemId'];
                                $('#aNewCommentReply' + iid).click(function (e) {
                                    var id = $(this).attr('id').replace('aNewCommentReply', '');
                                    $('#tbCommentInput' + id).css('display', '');
                                    $('#btnNewComment' + id).parent().css('display', '');
                                    $(this).css('display', 'none');
                                    if ($('#commentsWebPartMainContainer').scrollTop() > ($('#commentsWebPartMainContainer').height() + $(document).height())) {
                                        $('#commentsWebPartMainContainer').scrollTop($('#commentsWebPartMainContainer').scrollTop() + 150);
                                    }
                                    $('#tbCommentInput' + id).focus();
                                });

                                $('#tbCommentInput' + iid).focus(function () {
                                    if ($$.UnescapeHTML($(this).html()) === 'Write a reply...') {
                                        $(this).empty();
                                    }
                                });

                                $('#tbCommentInput' + iid).blur(function (e) {
                                    return true;
                                });

                                $('#tbCommentInput' + iid).change(function () {
                                    var $this = $(this), minHeight = $this.height(), lineHeight = $this.css('lineHeight');
                                    var shadow = $('<div class="inputSearch"></div>').css({ position: 'absolute', top: -10000, left: -10000, width: $this.width(), fontSize: $this.css('fontSize'), fontFamily: $this.css('fontFamily'), lineHeight: $this.css('lineHeight'), resize: 'none' }).appendTo(document.body);

                                    if ($(this).text() !== 'Write a reply...') {
                                        var val = $(this).text().replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/&/g, '&amp;').replace(/\n/g, '<br/>');
                                        shadow.html(val);
                                        $(this).css('height', Math.max(shadow.height(), minHeight));
                                    }
                                });

                                $('#tbCommentInput' + iid).keyup(function (e) {
                                    var id = $(this).attr('id').replace('tbCommentInput', '');
                                    var $this = $(this), minHeight = $this.height(), lineHeight = $this.css('lineHeight');
                                    var shadow = $('<div class="inputSearch"></div>').css({ position: 'absolute', top: -10000, left: -10000, width: $this.width(), fontSize: $this.css('fontSize'), fontFamily: $this.css('fontFamily'), lineHeight: $this.css('lineHeight'), resize: 'none' }).appendTo(document.body);

                                    if ($(this).text() !== 'Write a reply...') {
                                        var val = $(this).text().replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/&/g, '&amp;').replace(/\n/g, '<br/>');
                                        shadow.html(val);
                                        if (e.keyCode != 8 && e.keyCode != 46) {
                                            $(this).css('height', Math.max(shadow.height(), minHeight));
                                        }
                                        else {
                                            var minH = Math.min(shadow.height(), minHeight);
                                            if (minH <= 0) {
                                                minH = 15;
                                            }
                                            $(this).css('height', Math.min(shadow.height(), minH));
                                        }
                                    }

                                    var value = $(this).text();

                                    if (value.length > 0) {

                                        $('#btnNewComment' + id).removeClass('btn-disabled');

                                    }
                                    else {
                                      
                                        $('#btnNewComment' + id).addClass('btn-disabled');
                                    }
                                });
                            }
                        }


                    },
                    error: function (e) {
                        alert('Failed to add new comment. ' + e.message);
                        $('#divLoaderPublic_CommentsWebPart').FadeOut('slow');
                    }
                });
            } else {

            }
        };

        $$.ShowAllComments = function (element) {
            if (element.text() == "Show All") {
                var ctrlId = element.attr('id');
                var ctrlSuffix = ctrlId.substr(ctrlId.indexOf('_') + 1);
                $('div[item="' + ctrlSuffix + '"]').each(function () {
                    if ($(this).attr('isExtra') == 'true') {
                        $(this).css('display', '');
                    }
                });
                element.text('Hide Extra');
            } else {
                var ctrlId = element.attr('id');
                var ctrlSuffix = ctrlId.substr(ctrlId.indexOf('_') + 1);
                $('div[item="' + ctrlSuffix + '"]').each(function () {
                    if ($(this).attr('isExtra') == 'true') {
                        $(this).css('display', 'none');
                    }
                });
                element.text('Show All');
            }
        };

        $$.UnescapeHTML = function (escapedHTML) {
            var d = document.createElement("div");
            d.innerHTML = escapedHTML;
            if (!d.innerText) {
                return d.textContent;
            } else {
                return d.innerText;
            }
        };

        $$.htmlEscape = function (str) {
            return str.replace(/&/g, '&amp;')
                .replace(/"/g, '&quot;')
                .replace(/'/g, '&#39;')
                .replace(/</g, '&lt;')
                .replace(/>/g, '&gt;');
        };

        $$.xmlUnescape = function (str) {
            return str.replace(/#quot#/g, '"')
                .replace(/#amp#/g, '&')
                .replace(/#apos#/g, '\'')
                .replace(/#lt#/g, '<')
                .replace(/#gt#/g, '>');
        };

        $$.xmlEscape = function (str) {
            return str.replace(/'/g, '&quot;')
                .replace(/"/g, '&quot;');
        };

        //$('#divLoader_CommentsWebPart').css('margin-left', '45%').css('display', '');
        BeginGetMyCommentsByNotification();

        $(function () {
            $('#btnGeneralPost').click(function () {
                var publicComment = $('#inputPublicComment').html();
                publicComment = $$.xmlEscape(publicComment);
                if (publicComment) {
                    $$.AddPublicComment(publicComment);
                }
            });

            $("#inputPublicComment").focus(function () {
                if ($$.UnescapeHTML($(this).html()) === sPubComTxt) {
                    $(this).empty();
                }
            });

            $('#inputPublicComment').html("<span style=\"color:gray\">" + sPubComTxt + "</span>");
        });

    })(window.commentsWebPart = window.commentsWebPart || {}, jQuery);
}

ExecuteOrDelayUntilScriptLoaded(GetData, "EPMLive.js");