function initializeAnalytics() {
    (function (a, $$, $) {
        var favoritesData =
            "<Data>" +
                "<Param key=\"SiteId\">" + $$.currentSiteId + "</Param>" +
                "<Param key=\"WebId\">" + $$.currentWebId + "</Param>" +
                "<Param key=\"ListId\">" + $$.currentListId + "</Param>" +
                "<Param key=\"ListIconClass\">" + $$.currentListIcon + "</Param>" +
                "<Param key=\"ItemId\">" + $$.currentItemID + "</Param>" +
                "<Param key=\"FString\">" + $$.currentUrl + "</Param>" +
                "<Param key=\"Type\">1</Param>" +
                "<Param key=\"UserId\">" + $$.currentUserId + "</Param>" +
                "<Param key=\"PageTitle\">" + $$.pageName + "</Param>" +
                "</Data>";

        // frequent
        // recent

        function loadFavoriteStatus() {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'LoadFavoriteStatus', Dataxml: '" + favoritesData + "' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        var resp = $$.parseJson(response.d);
                        var result = resp.Result;
                        if ($$.responseIsSuccess(result) && result['#text'] === 'false') {
                            $('#favoritesStar').fadeIn(1000);
                        } else if ($$.responseIsSuccess(result) && result['#text'] === 'true') {
                            $('#favoritesStar').addClass('icon-star-active');
                            $('#favoritesStar').fadeIn(1000);
                        }


                        $("#favoritesStar").click(function () {
                            //$(this).toggleClass('icon-star-active');

                            if (!$(this).hasClass('icon-star-active')) {
                                var options = {
                                    url: epmLive.currentWebUrl + '/_layouts/epmlive/AddFavorite.aspx?' +
                                        'listid=' + epmLive.currentListId + '&itemid=' + epmLive.currentItemID + '&currentUrl=' + epmLive.currentUrl + '&userid=' + epmLive.currentUserId,
                                    height: 150,
                                    width: 400,
                                    allowMaximize: false,
                                    autoResize: false,
                                    dialogReturnValueCallback: function (result, returnVal) {
                                        if (result === 1) {
                                            $('#favoritesStar').addClass('icon-star-active');
                                            SP.UI.Notify.addNotification('New favorite added', false);
                                        }
                                    }
                                };

                                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
                            } else {

                                if (confirm('Unfavorite?')) {
                                    $.ajax({
                                        type: 'POST',
                                        url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                                        data: "{ Function: 'RemoveFavorites', Dataxml: '" + favoritesData + "' }",
                                        contentType: 'application/json; charset=utf-8',
                                        dataType: 'json',
                                        success: function (response) {
                                            if (response.d) {
                                                var resp = epmLive.parseJson(response.d);
                                                var result = resp.Result;

                                                if (epmLive.responseIsSuccess(result)) {
                                                    $('#favoritesStar').removeClass('icon-star-active');
                                                    SP.UI.Notify.addNotification('Favorite removed', false);
                                                    
                                                } else {
                                                    //onError(response);
                                                }
                                            } else {
                                                //onError(response);
                                            }
                                        },
                                        error: function (response) {
                                            //onError(response);
                                        }
                                    });
                                }
                            }

                        });
                    }
                },
                error: function (response) {
                    //onError(response);
                }
            });
        }

        loadFavoriteStatus();

    })(window.Analytics = window.Analytics || {}, window.epmLive, window.jQuery);
}
ExecuteOrDelayUntilScriptLoaded(initializeAnalytics, 'EPMLive.js');