function initializeAnalytics() {
    (function (a, $$, $) {

        //====== FAVORITES ========================
        a.isItem = function() {
            var bItem = ($$.currentItemID !== "-1" &&
                !$$.currentListViewUrl &&
                ($$.currentUrl.indexOf('NewForm.aspx') !== -1 ||
                $$.currentUrl.indexOf('EditForm.aspx') !== -1 ||
                $$.currentUrl.indexOf('DispForm.aspx') !== -1 ||
                $$.currentUrl.indexOf('fd_Item_New.aspx') !== -1 ||
                $$.currentUrl.indexOf('fd_Item_Edit.aspx') !== -1 ||
                $$.currentUrl.indexOf('fd_Item_Display.aspx') !== -1))
                ? true : false;

            return bItem;
        };
       
        a.favoritesData =
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
                "<Param key=\"PageTitle\">" + escape($$.pageName) + "</Param>" +
                "<Param key=\"IsItem\">" + a.isItem().toString() + "</Param>" +
                "</Data>";
        function loadFavoriteStatus() {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'LoadFavoriteStatus', Dataxml: '" + a.favoritesData + "' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        var resp = $$.parseJson(response.d);
                        var result = resp.Result;
                        if ($$.responseIsSuccess(result) && result['#text'] === 'false') {
                            // is item
                            if (a.isItem()) {
                                // do nothing
                                // is page or non item
                            } else {
                                window.setTimeout(function () {
                                    if (!$('#favoritesStar').hasClass('icon-star')) {
                                        $('#favoritesStar').addClass('icon-star');
                                    }

                                    if (!$('#favoritesStar').hasClass('icon-star-disabled')) {
                                        $('#favoritesStar').addClass('icon-star-disabled');
                                    }

                                    $('#favoritesStar').fadeIn(1000);
                                }, 100);

                            }
                        } else if ($$.responseIsSuccess(result) && result['#text'] === 'true') {
                            // is item
                            if (a.isItem()) {
                                // load different src
                                $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').fadeOut(function () {
                                    $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').load(function () { $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').fadeIn(); });
                                    $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').attr("src", "_layouts/epmlive/images/star-filled32.png");
                                });
                                // is page or non item
                            } else {
                                window.setTimeout(function () {
                                    if (!$('#favoritesStar').hasClass('icon-star')) {
                                        $('#favoritesStar').addClass('icon-star');
                                    }

                                    if (!$('#favoritesStar').hasClass('icon-star-active')) {
                                        $('#favoritesStar').addClass('icon-star-active');
                                    }

                                    $('#favoritesStar').fadeIn(1000);
                                }, 100);
                            }
                        }

                        // register event for favorite star 
                        // on a non-item page
                        // code for ribbon button is in WEDispFormPageComponent.js
                        $("#favoritesStar").click(function () {
                            if (!$(this).hasClass('icon-star-active')) {
                                var viewDiv = document.createElement('div');
                                viewDiv.innerHTML = document.getElementById('fav_Add_DivTemp').innerHTML;

                                var options = {
                                    html: viewDiv,
                                    height: 90,
                                    width: 250,
                                    title: "Add Favorite",
                                    dialogReturnValueCallback: function (diagResult, retVal) {
                                        if (diagResult === 1) {
                                            a.addPageFav(retVal);
                                        }
                                    }
                                };

                                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);

                                var myVar = setInterval(function () { setFocus(); }, 200);
                                function setFocus() {
                                    if ($('.ms-dlgFrameContainer').find('#favTitle').length > 0 && !$('.ms-dlgFrameContainer').find('#favTitle').is(':focus')) {
                                        if ($$.currentListTitle && $$.currentListViewTitle) {
                                            $('.ms-dlgFrameContainer').find('#favTitle').focus().val($$.currentListTitle + '-' + $$.currentListViewTitle);
                                        } else {
                                            $('.ms-dlgFrameContainer').find('#favTitle').focus().val($$.currentFileTitle);
                                        }
                                        clearInterval(myVar);
                                    }
                                }
                            } else {
                                a.removePageFav();
                            }
                        });
                    }
                },
                error: function (response) {
                    //onError(response);
                }
            });
        }

        a.addPageFav = function (title) {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'AddFavorites', Dataxml: '" +
                    "<Data>" +
                    "<Param key=\"SiteId\">" + $$.currentSiteId + "</Param>" +
                    "<Param key=\"WebId\">" + $$.currentWebId + "</Param>" +
                    "<Param key=\"ListId\">" + $$.currentListId + "</Param>" +
                    "<Param key=\"ListViewUrl\">" + $$.currentListViewUrl + "</Param>" +
                    "<Param key=\"ListIconClass\">icon-file-5</Param>" +
                    "<Param key=\"ItemId\">" + $$.currentItemID + "</Param>" +
                    "<Param key=\"FString\">" + $$.currentUrl + "</Param>" +
                    "<Param key=\"UserId\">" + $$.currentUserId + "</Param>" +
                    "<Param key=\"Title\">" + escape(title) + "</Param>" +
                    "<Param key=\"FileIsNull\">" + $$.currentFileIsNull + "</Param>" +
                    "<Param key=\"IsItem\">False</Param>" +
                    "</Data>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        var resp = epmLive.parseJson(response.d);
                        var result = resp.Result;

                        if (epmLive.responseIsSuccess(result) && result['#text']) {
                            //onSuccess(result);
                            $('#favoritesStar').addClass('icon-star-active');

                            toastr.options = {
                                "closeButton": false,
                                "debug": false,
                                "positionClass": "toast-top-right",
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            };

                            toastr.success("A new item has been added to your favorites list.");

                            var sa = result['#text'].split(',');
                            // asynchronously update nav
                            // 0 is page, 1 is item
                            var favKindInt = 0;
                            //if ($$.currentItemID != '-1' && $$.currentFileIsNull == 'True') {
                            //    favKindInt = 1;
                            //}
                            if (window.location.href.indexOf("IsDlg=1") != -1 || window.location.href.indexOf("isdlg=1") != -1) {
                                window.parent.epmLiveNavigation.registerLink({
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
                            }
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
        };

        a.addItemFav = function (title) {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'AddFavorites', Dataxml: '" +
                    "<Data>" +
                    "<Param key=\"SiteId\">" + epmLive.currentSiteId + "</Param>" +
                    "<Param key=\"WebId\">" + epmLive.currentWebId + "</Param>" +
                    "<Param key=\"ListId\">" + epmLive.currentListId + "</Param>" +
                    "<Param key=\"ListViewUrl\">" + epmLive.currentListViewUrl + "</Param>" +
                    "<Param key=\"ListIconClass\">" + epmLive.currentListIcon + "</Param>" +
                    "<Param key=\"ItemId\">" + epmLive.currentItemID + "</Param>" +
                    "<Param key=\"FString\">" + epmLive.currentUrl + "</Param>" +
                    "<Param key=\"UserId\">" + epmLive.currentUserId + "</Param>" +
                    "<Param key=\"Title\">" + escape(title) + "</Param>" +
                    "<Param key=\"FileIsNull\">" + epmLive.currentFileIsNull + "</Param>" +
                    "<Param key=\"IsItem\">True</Param>" +
                    "</Data>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        var resp = epmLive.parseJson(response.d);
                        var result = resp.Result;

                        if (epmLive.responseIsSuccess(result) && result['#text']) {
                            //onSuccess(result);
                            if ($('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').attr('src') === '_layouts/epmlive/images/star32.png') {
                                $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').fadeOut(function () {
                                    $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').load(function () { $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').fadeIn(); });
                                    $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').attr("src", "_layouts/epmlive/images/star-filled32.png");
                                });
                            }

                            toastr.options = {
                                "closeButton": false,
                                "debug": false,
                                "positionClass": "toast-top-right",
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            };

                            toastr.success("A new item has been added to your favorites list.");

                            var sa = result['#text'].split(',');
                            // asynchronously update nav
                            // 0 is page, 1 is item
                            var favKindInt = 1;

                            if (window.location.href.indexOf("IsDlg=1") != -1 || window.location.href.indexOf("isdlg=1") != -1) {
                                window.parent.epmLiveNavigation.registerLink({
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
                            }

                            
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
        };

        a.addItemFavFromGrid = function (title, webid, listid, id) {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'AddFavorites', Dataxml: '" +
                    "<Data>" +
                    "<Param key=\"SiteId\">" + epmLive.currentSiteId + "</Param>" +
                    "<Param key=\"WebId\">" + webid + "</Param>" +
                    "<Param key=\"ListId\">" + listid + "</Param>" +
                    "<Param key=\"ListIconClass\">" + epmLive.currentListIcon + "</Param>" +
                    "<Param key=\"ItemId\">" + id + "</Param>" +
                    "<Param key=\"UserId\">" + epmLive.currentUserId + "</Param>" +
                    "<Param key=\"Title\">" + escape(title) + "</Param>" +
                    "<Param key=\"FileIsNull\">" + epmLive.currentFileIsNull + "</Param>" +
                    "<Param key=\"IsItem\">True</Param>" +
                    "</Data>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        var resp = epmLive.parseJson(response.d);
                        var result = resp.Result;

                        if (epmLive.responseIsSuccess(result) && result['#text']) {

                            toastr.options = {
                                "closeButton": false,
                                "debug": false,
                                "positionClass": "toast-top-right",
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            };

                            toastr.success("A new item has been added to your favorites list.");

                            var sa = result['#text'].split(',');
                            // asynchronously update nav
                            // 0 is page, 1 is item
                            var favKindInt = 1;
                            if (window.location.href.indexOf("IsDlg=1") != -1 || window.location.href.indexOf("isdlg=1") != -1) {
                                window.parent.epmLiveNavigation.registerLink({
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
                            }
                          
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
        };

        a.removePageFav = function () {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'RemoveFavorites', Dataxml: '" +
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
                        "<Param key=\"PageTitle\">" + escape($$.pageName) + "</Param>" +
                        "<Param key=\"IsItem\">False</Param>" +
                    "</Data>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        var resp = epmLive.parseJson(response.d);
                        var result = resp.Result;

                        if (epmLive.responseIsSuccess(result) && result['#text']) {
                            $('#favoritesStar').removeClass('icon-star-active');

                            toastr.options = {
                                "closeButton": false,
                                "debug": false,
                                "positionClass": "toast-top-right",
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            };

                            toastr.success("An existing item has been removed from your favorites list.");

                            var sa = result['#text'].split(',');
                            // asynchronously update nav
                            if (window.location.href.indexOf("IsDlg=1") != -1 || window.location.href.indexOf("isdlg=1") != -1) {
                                window.parent.epmLiveNavigation.removeLink({
                                    kind: 0, // 0 - FA, 1 - RI, 2 - FW, 3 - WS
                                    id: sa[0],
                                    //webId: use webid for type 3 removal,
                                });
                            } else {
                                window.epmLiveNavigation.removeLink({
                                    kind: 0, // 0 - FA, 1 - RI, 2 - FW, 3 - WS
                                    id: sa[0],
                                    //webId: use webid for type 3 removal,
                                });
                            }
                           

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
        };

        a.removeItemFav = function () {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'RemoveFavorites', Dataxml: '" +
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
                        "<Param key=\"PageTitle\">" + escape($$.pageName) + "</Param>" +
                        "<Param key=\"IsItem\">True</Param>" +
                    "</Data>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        var resp = epmLive.parseJson(response.d);
                        var result = resp.Result;

                        if (epmLive.responseIsSuccess(result) && result['#text']) {
                            if ($('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').attr('src') === '_layouts/epmlive/images/star-filled32.png') {
                                $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').fadeOut(function () {
                                    $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').load(function () { $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').fadeIn(); });
                                    $('a[id="Ribbon.ListItem.EPMLive.FavoriteStatus-Large"]').find('img').attr("src", "_layouts/epmlive/images/star32.png");
                                });
                            }

                            toastr.options = {
                                "closeButton": false,
                                "debug": false,
                                "positionClass": "toast-top-right",
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            };

                            toastr.success("An existing item has been removed from your favorites list.");

                            var sa = result['#text'].split(',');
                            if (window.location.href.indexOf("IsDlg=1") != -1 || window.location.href.indexOf("isdlg=1") != -1) {
                                // asynchronously update nav
                                window.parent.epmLiveNavigation.removeLink({
                                    kind: 0, // 0 - FA, 1 - RI, 2 - FW, 3 - WS
                                    id: sa[0],
                                    //webId: use webid for type 3 removal,
                                });
                            } else {
                                // asynchronously update nav
                                window.epmLiveNavigation.removeLink({
                                    kind: 0, // 0 - FA, 1 - RI, 2 - FW, 3 - WS
                                    id: sa[0],
                                    //webId: use webid for type 3 removal,
                                });
                            }
                           

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
        };

        a.removeItemFavFromGrid = function (webid, listid, itemid) {
            // missing id from grid, add it explicitly

            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'RemoveFavorites', Dataxml: '" +
                        "<Data>" +
                        "<Param key=\"SiteId\">" + epmLive.currentSiteId + "</Param>" +
                        "<Param key=\"WebId\">" + webid + "</Param>" +
                        "<Param key=\"ListId\">" + listid + "</Param>" +
                        "<Param key=\"ListViewUrl\"></Param>" +
                        "<Param key=\"ListIconClass\">" + epmLive.currentListIcon + "</Param>" +
                        "<Param key=\"ItemId\">" + itemid + "</Param>" +
                        "<Param key=\"UserId\">" + epmLive.currentUserId + "</Param>" +
                        "<Param key=\"Title\">" + escape(epmLive.currentListTitle) + "</Param>" +
                        "<Param key=\"FileIsNull\">" + epmLive.currentFileIsNull + "</Param>" +
                        "<Param key=\"IsItem\">True</Param>" +
                        "</Data>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    if (response.d) {
                        var resp = epmLive.parseJson(response.d);
                        var result = resp.Result;

                        if (epmLive.responseIsSuccess(result) && result['#text']) {
                            toastr.options = {
                                "closeButton": false,
                                "debug": false,
                                "positionClass": "toast-top-right",
                                "onclick": null,
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            };

                            toastr.success("An existing item has been removed from your favorites list.");

                            var sa = result['#text'].split(',');
                            if (window.location.href.indexOf("IsDlg=1") != -1 || window.location.href.indexOf("isdlg=1") != -1) {
                                // asynchronously update nav
                                window.parent.epmLiveNavigation.removeLink({
                                    kind: 0, // 0 - FA, 1 - RI, 2 - FW, 3 - WS
                                    id: sa[0],
                                    //webId: use webid for type 3 removal,
                                });
                            } else {
                                // asynchronously update nav
                                window.epmLiveNavigation.removeLink({
                                    kind: 0, // 0 - FA, 1 - RI, 2 - FW, 3 - WS
                                    id: sa[0],
                                    //webId: use webid for type 3 removal,
                                });
                            }

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
        };
        loadFavoriteStatus();
        //====== FREQUENT ======================
        a.frequentData =
            "<Data>" +
                "<Param key=\"SiteId\">" + $$.currentSiteId + "</Param>" +
                "<Param key=\"WebId\">" + $$.currentWebId + "</Param>" +
                "<Param key=\"ListId\">" + $$.currentListId + "</Param>" +
                "<Param key=\"ListIconClass\">" + $$.currentListIcon + "</Param>" +
                "<Param key=\"Title\">" + escape($$.currentListTitle) + "</Param>" +
                "<Param key=\"Type\">3</Param>" +
                "<Param key=\"UserId\">" + $$.currentUserId + "</Param>" +
            "</Data>";

        function countFrequentApps() {

            var sPrevList = '';
            if ($.cookie('FrequentApp_CurrentList')) {
                sPrevList = $.cookie('FrequentApp_CurrentList');
            }
            var sCurrentList = $$.currentListTitle;
            if ($$.currentListViewUrl && sCurrentList && (sPrevList != sCurrentList)) {
                // set the cookie
                var date = new Date();
                var minutes = 30;
                date.setTime(date.getTime() + (minutes * 60 * 1000));
                $.cookie("FrequentApp_CurrentList", sCurrentList, { expires: date, path: '/' });
                // add frequent app
                $.ajax({
                    type: 'POST',
                    url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'CreateFrequentApp', Dataxml: '" + a.frequentData + "' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response.d) {

                        }
                    },
                    error: function (response) {
                        alert(response);
                    }
                });
            }

        }

        countFrequentApps();

        //====== RECENT ========================
        var RecentData =
            "<Data>" +
                "<Param key=\"SiteId\">" + $$.currentSiteId + "</Param>" +
                "<Param key=\"WebId\">" + $$.currentWebId + "</Param>" +
                "<Param key=\"ListId\">" + $$.currentListId + "</Param>" +
                "<Param key=\"ItemId\">" + $$.currentItemID + "</Param>" +
                "<Param key=\"ListIconClass\">" + $$.currentListIcon + "</Param>" +
                "<Param key=\"Title\">" + escape($$.currentItemTitle) + "</Param>" +
                "<Param key=\"Type\">2</Param>" +
                "<Param key=\"UserId\">" + $$.currentUserId + "</Param>" +
            "</Data>";

        function countRecentItem() {
            if (!$$.currentListViewUrl && $$.currentItemID != '-1' && $$.currentFileIsNull == 'True' && $$.currentItemTitle.trim() != 'New Item') {
                // add recent item
                $.ajax({
                    type: 'POST',
                    url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'CreateRecentItem', Dataxml: '" + RecentData + "' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response.d) {

                        }
                    },
                    error: function (response) {
                        alert(response);
                    }
                });
            }

        }

        countRecentItem();

        //====== HELPER FUNCTIONS =============

        a.turnOnFav = function () {
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

        a.getAddFavDynamicValue = function (ele) {
            return $($(ele).parent().parent().find('#favTitle').get(0)).val();
        };

        a.getAddFavItemFromGridDynamicValue = function (ele) {
            return $($(ele).parent().parent().find('#favItemTitle').get(0)).val();
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