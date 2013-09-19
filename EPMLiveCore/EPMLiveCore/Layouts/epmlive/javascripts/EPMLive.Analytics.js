function initializeAnalytics() {
    (function (a, $$, $) {

        //====== FAVORITES ========================
        var favoritesData =
            "<Data>" +
                "<Param key=\"SiteId\">" + $$.currentSiteId + "</Param>" +
                "<Param key=\"WebId\">" + $$.currentWebId + "</Param>" +
                "<Param key=\"ListId\">" + $$.currentListId + "</Param>" +
                "<Param key=\"ListIconClass\">" + $$.currentListIcon + "</Param>" +
                "<Param key=\"ListView\">" + $$.currentListViewUrl + "</Param>" +
                "<Param key=\"ItemId\">" + $$.currentItemID + "</Param>" +
                "<Param key=\"FileIsNull\">" + $$.currentFileIsNull + "</Param>" +
                "<Param key=\"FString\">" + $$.currentUrl + "</Param>" +
                "<Param key=\"Type\">1</Param>" +
                "<Param key=\"UserId\">" + $$.currentUserId + "</Param>" +
                "<Param key=\"PageTitle\">" + $$.pageName + "</Param>" +
                "</Data>";
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
                            if (!$(this).hasClass('icon-star-active')) {
                                var viewDiv = document.createElement('div');
                                viewDiv.innerHTML = document.getElementById('fav_Add_DivTemp').innerHTML;

                                var options = {
                                    html: viewDiv,
                                    height: 110,
                                    width: 265,
                                    title: "Add Favorite",
                                    dialogReturnValueCallback: function (diagResult, retVal) {
                                        if (diagResult === 1) {
                                            add(retVal);
                                        }
                                    }
                                };

                                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
                            } else {
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

                                            if (epmLive.responseIsSuccess(result) && result['#text']) {
                                                $('#favoritesStar').removeClass('icon-star-active');
                                                //SP.UI.Notify.addNotification('Favorite removed', false);
                                                $.pnotify({
                                                    title: 'Favorite Removed',
                                                    text: 'An existing item has been removed from your favorites list.',
                                                    type: 'success',
                                                    styling: 'jqueryui'
                                                });

                                                var sa = result['#text'].split(',');
                                                // asynchronously update nav
                                                window.epmLiveNavigation.removeLink({
                                                    kind: 0, // 0 - FA, 1 - RI, 2 - FW, 3 - WS
                                                    id: sa[0],
                                                    //webId: use webid for type 3 removal,
                                                });

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

                        });
                    }
                },
                error: function (response) {
                    //onError(response);
                }
            });
        }
        function add(title) {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'AddFavorites', Dataxml: '" +
                    "<Data>" +
                    "<Param key=\"SiteId\">" + $$.currentSiteId + "</Param>" +
                    "<Param key=\"WebId\">" + $$.currentWebId + "</Param>" +
                    "<Param key=\"ListId\">" + $$.currentListId + "</Param>" +
                    "<Param key=\"ListViewUrl\">" + $$.currentListViewUrl + "</Param>" +
                    "<Param key=\"ListIconClass\">" + $$.currentListIcon + "</Param>" +
                    "<Param key=\"ItemId\">" + $$.currentItemID + "</Param>" +
                    "<Param key=\"FString\">" + $$.currentUrl + "</Param>" +
                    "<Param key=\"UserId\">" + $$.currentUserId + "</Param>" +
                    "<Param key=\"Title\">" + title + "</Param>" +
                    "<Param key=\"FileIsNull\">" + $$.currentFileIsNull + "</Param>" +
                    "</Data>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function(response) {
                    if (response.d) {
                        var resp = epmLive.parseJson(response.d);
                        var result = resp.Result;

                        if (epmLive.responseIsSuccess(result) && result['#text']) {
                            //onSuccess(result);
                            $('#favoritesStar').addClass('icon-star-active');
                            //SP.UI.Notify.addNotification('New favorite added', false);
                            
                            $.pnotify({
                                title: 'New Favorite Added',
                                text: 'A new item has been added to your favorites list.',
                                type: 'success',
                                styling: 'jqueryui'
                            });
                            
                            var sa = result['#text'].split(',');
                            // asynchronously update nav
                            // 0 is page, 1 is item
                            var favKindInt = 0;
                            if ($$.currentItemID != '-1' && $$.currentFileIsNull == 'True') {
                                favKindInt = 1;
                            }
                            window.epmLiveNavigation.registerLink({
                                kind: favKindInt, // 0 - FA, 1 - RI, 2 - FW, 3 - WS
                                id: sa[0],
                                title: sa[6],
                                url: sa[9],
                                cssClass: sa[7],
                                siteId: sa[1],
                                webId: sa[2],
                                listId: sa[3],
                                itemId: sa[4],
                                external: false 
                            });
                        } else {
                            //onError(response);
                        }
                    } else {
                        //onError(response);
                    }
                },
                error: function(response) {
                    //onError(response);
                }
            });
        }
        loadFavoriteStatus();
        //====== FREQUENT ======================
        var frequentData =
            "<Data>" +
                "<Param key=\"SiteId\">" + $$.currentSiteId + "</Param>" +
                "<Param key=\"WebId\">" + $$.currentWebId + "</Param>" +
                "<Param key=\"ListId\">" + $$.currentListId + "</Param>" +
                "<Param key=\"ListIconClass\">" + $$.currentListIcon + "</Param>" +
                "<Param key=\"ListTitle\">" + $$.currentListTitle + "</Param>" +
                "<Param key=\"Type\">3</Param>" +
                "<Param key=\"UserId\">" + $$.currentUserId + "</Param>" +
            "</Data>";
        
        function countFrequentApps() {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'LoadFavoriteStatus', Dataxml: '" + frequentData + "' }",
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
                        
                        
                    }
                },
                error: function (response) {
                    //onError(response);
                }
            });
        }
        
        countFrequentApps();
        
        //====== RECENT ========================

        //====== HELPER FUNCTIONS =============

        a.turnOnFav = function() {
            if (!$('#favoritesStar').hasClass('icon-star-active')) {
                $('#favoritesStar').addClass('icon-star-active');
            }
        };

        a.turnOffFav = function (data) {
            // a page
            if (data.itemid === '') {
                if (removeSource(data.url) == removeSource($$.currentUrl)) {
                    if ($('#favoritesStar').hasClass('icon-star-active')) {
                        $('#favoritesStar').removeClass('icon-star-active');
                    }
                }
                // an item
            } else {
                
            }
        };
        
        function removeSource(url) {
            var retVal = url;
            if (url.indexOf('Source') != -1) {
                var sRemove = '';
                var sa = url.split('?');
                var sa2 = sa[1].split('&');
                for (var i in sa2) {
                    if (sa2[i].split('=')[0].toLowerCase() === "source") {
                        sRemove = sa2;
                        break;
                    } 
                }
                
                if (sRemove) {
                    retVal = retVal.replace(sRemove, '');
                }
            }
            return retVal;
        }

    })(window.Analytics = window.Analytics || {}, window.epmLive, window.jQuery);
}
ExecuteOrDelayUntilScriptLoaded(initializeAnalytics, 'EPMLive.js');