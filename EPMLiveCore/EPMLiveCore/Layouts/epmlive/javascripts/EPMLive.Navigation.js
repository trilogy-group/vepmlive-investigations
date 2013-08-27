(function () {
    'use strict';

    function initializeNavigation() {
        $(function () {
            var $ = window.jQuery;

            var $$ = (function () {
                var _currentWebUrl = function() {
                    return window.epmLiveNavigation.currentWebUrl;
                };

                var _parseJson = function(xml) {
                    return eval('(' + window.xml2json($.parseXML(xml), "") + ')');
                };

                var _responseIsSuccess = function(response) {
                    return response['@Status'] == 0;
                };

                return {
                    currentWebUrl: _currentWebUrl,
                    parseJson: _parseJson,
                    responseIsSuccess: _responseIsSuccess
                };
            })();

            var base64Service = (function () {
                var keyStr = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';
                
                var _decode = function(input) {
                    var output = '';
                    var chr1, chr2, chr3 = '';
                    var enc1, enc2, enc3, enc4 = '';
                    var i = 0;

                    var base64Test = /[^A-Za-z0-9\+\/\=]/g;
                    if (base64Test.exec(input)) {
                        console.log('There were invalid base64 characters in the input text.\nValid base64 characters are A-Z, a-z, 0-9, "+", "/",and "="\nExpect errors in decoding.');
                    }
                    
                    input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

                    do {
                        enc1 = keyStr.indexOf(input.charAt(i++));
                        enc2 = keyStr.indexOf(input.charAt(i++));
                        enc3 = keyStr.indexOf(input.charAt(i++));
                        enc4 = keyStr.indexOf(input.charAt(i++));

                        chr1 = (enc1 << 2) | (enc2 >> 4);
                        chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
                        chr3 = ((enc3 & 3) << 6) | enc4;

                        output = output + String.fromCharCode(chr1);

                        if (enc3 != 64) {
                            output = output + String.fromCharCode(chr2);
                        }
                        
                        if (enc4 != 64) {
                            output = output + String.fromCharCode(chr3);
                        }

                        chr1 = chr2 = chr3 = '';
                        enc1 = enc2 = enc3 = enc4 = '';

                    } while (i < input.length);

                    return unescape(output);
                };
                
                return {
                    decode: _decode
                };
            })();

            var epmLiveService = (function () {
                var _execute = function (method, data, onSuccess, onError) {
                    var webUrl = $$.currentWebUrl();
                    
                    if (webUrl) {
                        $.ajax({
                            type: 'POST',
                            url: webUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                            data: "{ Function: '" + method + "', Dataxml: '" + data + "' }",
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function(response) {
                                if (response.d) {
                                    var resp = $$.parseJson(response.d);
                                    var result = resp.Result;

                                    if ($$.responseIsSuccess(result)) {
                                        onSuccess(result);
                                    } else {
                                        onError(response);
                                    }
                                } else {
                                    onError(response);
                                }
                            },
                            error: function(response) {
                                onError(response);
                            }
                        });
                    } else {
                        window.setTimeout(function() {
                            _execute(method, data, onSuccess, onError);
                        }, 1);
                    }
                };

                return {
                    execute: _execute
                };
            })();

            var epmLiveNavigation = (function () {
                var animSpeed = 300;
                var nodeClass = 'epm-nav-node';
                var hoverClass = 'epm-nav-node-hover';
                var openedClass = 'epm-nav-node-opened';
                var selectedClass = 'epm-nav-node-selected';
                var expandedClass = 'epm-nav-node-expanded';
                var collapsedClass = 'epm-nav-node-collapsed';

                var selectedTlNodeCookie = 'epmnav-selected-tlnode';
                var selectedLinkCookie = 'epmnav-selected-link';
                var expandStateCookie = 'epmnav-expand-state';
                var pinStateCookie = 'epmnav-pin-state';
                var cookieOptions = { expires: 365, path: '/' };

                var $sn = $('#epm-nav-sub');

                var tlNodes = [];

                var navNode = function (el) {
                    var categories = {};

                    var _el = el;
                    var _$el = $(el);
                    var _$sm = $('#epm-nav-sub-' + _$el.data('id'));

                    var _id = _el.id;
                    var _provider = _$el.data('linkprovider');

                    var _selected = function () {
                        return _$el.parent().hasClass(selectedClass);
                    };

                    var isOpened = function () {
                        return _$el.parent().hasClass(openedClass);
                    };

                    var _select = function (select) {
                        if (select) {
                            _$el.parent().addClass(selectedClass);
                        } else {
                            _$el.parent().removeClass(selectedClass);
                        }
                    };

                    var _close = function () {
                        _$sm.hide();
                        _$el.parent().removeClass(openedClass);
                    };

                    var _closeNav = function () {
                        if ($sn.is(':visible')) {
                            $sn.hide('slide', { direction: 'left' }, animSpeed);
                        }

                        _close();
                    };

                    var _registerLink = function(link) {
                        if (link.seprator) {
                            registerSeprator(link.category);
                        } else if (link.url.toLowerCase() === 'header') {
                            registerCategory(link.category);
                            registerHeader(link);
                        } else {
                            registerCategory(link.category);
                            registerLink(link);
                        }
                    };

                    var registerHeader = function (link) {
                        var category = link.category;

                        if (!category) {
                            category = '__STATIC__';
                        }
                        
                        var li = '<li class="epm-nav-sub-header">' + link.title + '</li>';
                        
                        categories[category].$el.append(li);

                        li = '<li class="epm-nav-sub-header-bottom"></li>';
                        
                        categories[category].$el.append(li);
                    };

                    var registerLink = function (link) {
                        var category = link.category;

                        if (!category) {
                            category = '__STATIC__';
                        }

                        var icon = '';
                        
                        if (link.cssClass) {
                            icon = '<span class="epm-nav-icon ' + link.cssClass + '"></span>';
                        }

                        var html = '<li id="' + link.id + '" class="epm-nav-node" style="display:none;">' + icon + '<a id="epm-nav-link-' + link.id + '" href="' + link.url + '" alt="' + link.title + '" data-siteid="' + link.siteId + '" data-webid="' + link.webId + '" data-listid="' + link.listId + '" data-itemid="' + link.itemId + '">' + link.title + '</a></li>';

                        categories[category].$el.append(html);

                        if (link.external) {
                            $('#epm-nav-link-' + link.id).attr('target', '_blank');
                        }

                        if (link.visible) {
                            $('#' + link.id).show();
                        }
                    };

                    var registerSeprator = function (category) {
                        var seprator = '<div class="epm-nav-sub-sep"></div>';

                        if (category) {
                            $('#' + calculateCatId(category)).append(seprator);
                        } else {
                            _$sm.append(seprator);
                        }
                    };

                    var registerCategory = function (category) {
                        if (!category) {
                            category = '__STATIC__';
                        }

                        if (!categories[category]) {
                            var id = calculateCatId(category);
                            var defaultCssClass = 'epm-nav-node-expanded';

                            if (category === '__STATIC__') {
                                defaultCssClass = 'epm-nav-node-static';
                            }

                            if (category !== '__STATIC__') {
                                _$sm.append('<div id="' + id + '" class="epm-nav-node epm-nav-node-root epm-nav-cat"><span class="' + defaultCssClass + '">&nbsp;</span><span class="epm-nav-cat-title" alt="' + category + '">' + category + '</span></div>');
                            }

                            _$sm.append('<ul id="' + id + '-links" class="epm-nav-links ' + defaultCssClass + '"></ul>');

                            categories[category] = {
                                id: id,
                                $el: $('#' + id + '-links')
                            };
                        }
                    };

                    var calculateCatId = function (category) {
                        return _$sm.get(0).id + '-' + category.toLowerCase().replace(/ /g, '-').replace(/_/g, '').replace(/[^\w-]+/g, '').replace(/--/g, '-');
                    };

                    var showNode = function () {
                        _$sm.fadeIn(300);
                        _$el.parent().addClass(openedClass);
                    };

                    var openMenu = function () {
                        showNode();

                        if (!$sn.is(':visible')) {
                            $sn.show('slide', { direction: 'left' }, animSpeed);
                        }
                    };

                    _$el.click(function () {
                        if (_selected()) {
                            if (isOpened() && $.cookie(pinStateCookie) === 'unpinned') {
                                _closeNav();
                            } else {
                                openMenu();
                            }
                        } else {
                            for (var n in tlNodes) {
                                var nde = tlNodes[n];

                                if (nde.id !== _id) {
                                    if (nde.selected()) {
                                        nde.select(false);
                                        nde.close();
                                    }
                                }
                            }

                            _select(true);
                            openMenu();

                            $.cookie(selectedTlNodeCookie, _id, cookieOptions);
                        }
                    });

                    return {
                        id: _id,
                        provider: _provider,
                        selected: _selected,
                        select: _select,
                        close: _close,
                        closeNav: _closeNav,
                        registerLink: _registerLink,
                        el: _el,
                        $el: _$el,
                        $menu: _$sm
                    };
                };

                function hideMenu() {
                    for (var n = 0; n < tlNodes.length; n++) {
                        var node = tlNodes[n];
                        if (node.selected()) {
                            node.closeNav();
                            break;
                        }
                    }
                }

                function changePinState(state) {
                    var elements = ['s4-ribbonrow', 's4-workspace'];
                    for (var e in elements) {
                        var $e = $('#' + elements[e]);
                        $e.removeClass('epm-nav-pinned');
                        $e.removeClass('epm-nav-unpinned');
                        $e.addClass('epm-nav-' + state);
                    }

                    var $pin = $('#epm-nav-pin');
                    $pin.removeClass('epm-nav-pin-pinned');
                    $pin.removeClass('epm-nav-pin-unpinned');
                    $pin.addClass('epm-nav-pin-' + state);

                    if (state === 'unpinned') {
                        hideMenu();
                    }

                    $sn.data('pinstate', state);
                    $.cookie(pinStateCookie, state, cookieOptions);
                }

                function togglePinned() {
                    if ($sn.data('pinstate') === 'pinned') {
                        changePinState('unpinned');
                    } else {
                        changePinState('pinned');
                    }
                }

                function getSelectedSubLevelNode() {
                    return ($.cookie(selectedTlNodeCookie) || 'epm-nav-top-ql').replace('epm-nav-top-', 'epm-nav-sub-');
                }

                function getLinkNodes(menu) {
                    return $('#' + menu).find('.epm-nav-sub-menu').find('div[id^=E]');
                }

                function selectLink() {
                    var link = $.parseJSON($.cookie(selectedLinkCookie));
                    if (link) {
                        var index = link.index;
                        var uri = link.uri;
                        if (window.location.href.indexOf(uri) !== -1) {
                            var $menu = $('#' + getSelectedSubLevelNode());

                            if (!index || index === -1) {
                                $menu.find('a[href="' + uri + '"]:first').parents('table').addClass(selectedClass);
                            } else {
                                var $nodes = getLinkNodes($menu.parent().attr('id'));
                                for (var i = 0; i < $nodes.length; i++) {
                                    if (i === index) {
                                        $($nodes[i]).find('a[href="' + uri + '"]:first').parents('table').addClass(selectedClass);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                function saveLinkState($nav) {
                    var data = {};

                    $nav.find('.epm-nav-cat').each(function () {
                        var $cat = $(this);
                        data[$cat.text()] = $($cat.find('span')[0]).hasClass(expandedClass);
                    });

                    saveExpandState($nav.get(0).id, data);
                }

                function saveExpandState(nodeId, data) {
                    var state = $.parseJSON($.cookie(expandStateCookie)) || {};
                    state[nodeId] = data;
                    $.cookie(expandStateCookie, JSON.stringify(state), cookieOptions);
                }

                function expandNodes(provider) {
                    var expandState = $.parseJSON($.cookie(expandStateCookie));

                    if (expandState) {
                        var selectedNode = getSelectedSubLevelNode();

                        if (provider) {
                            for (var m = 0; m < tlNodes.length; m++) {
                                var tlNode = tlNodes[m];

                                if (tlNode.provider === provider) {
                                    selectedNode = tlNode.id.replace('epm-nav-top-', 'epm-nav-sub-');
                                    break;
                                }
                            }
                        }

                        var snExpandStatus = expandState[selectedNode];
                        if (snExpandStatus) {
                            if (selectedNode === 'epm-nav-sub-ql') {
                                var nodes = getLinkNodes('epm-nav-sub-ql');

                                for (var i = 0; i < nodes.length; i++) {
                                    var node = nodes[i];
                                    var nodeId = node.id.replace('Nodes', '');

                                    if (snExpandStatus[$('#' + nodeId.replace('EPMLiveNavn', 'EPMLiveNavt')).text()]) {
                                        TreeView_ToggleNode(window.EPMLiveNav_Data, 0, document.getElementById(nodeId), ' ', document.getElementById(node.id));
                                    }
                                }
                            } else {
                                var $cats = $('#' + selectedNode).find('.epm-nav-cat');

                                if (selectedNode === 'epm-nav-sub-settings') {
                                    $cats.each(function () {
                                        collapseLinks($(this));
                                    });
                                }

                                $cats.each(function () {
                                    var $cat = $(this);
                                    var key = $cat.text();
                                    var expand = snExpandStatus[key];

                                    if ($($cat.find('span')[0]).hasClass(expandedClass)) {
                                        if (!expand) {
                                            collapseLinks($cat);
                                        }
                                    } else {
                                        if (expand) {
                                            expandLinks($cat);
                                        }
                                    }
                                });
                            }
                        }
                    }
                }

                function expandLinks($cat) {
                    var catId = $cat.get(0).id;

                    var $span = $($cat.find('span')[0]);
                    var $ul = $('#' + catId + '-links');

                    $span.removeClass(collapsedClass);
                    $span.addClass(expandedClass);
                    $ul.removeClass(collapsedClass);
                    $ul.addClass(expandedClass);
                }

                function collapseLinks($cat) {
                    var catId = $cat.get(0).id;

                    var $span = $($cat.find('span')[0]);
                    var $ul = $('#' + catId + '-links');

                    $span.removeClass(expandedClass);
                    $span.addClass(collapsedClass);
                    $ul.removeClass(expandedClass);
                    $ul.addClass(collapsedClass);
                }

                function registerLinkEvents() {
                    $('.epm-nav-cat').click(function () {
                        var $cat = $(this);
                        var $span = $($cat.find('span')[0]);

                        if ($span.hasClass(collapsedClass)) {
                            expandLinks($cat);
                        } else {
                            collapseLinks($cat);
                        }

                        saveLinkState($cat.parent());
                    });
                }

                function registerEvents() {
                    var hoverNode = window.TreeView_HoverNode;
                    var unhoverNode = window.TreeView_UnhoverNode;
                    var toggleNode = window.TreeView_ToggleNode;

                    window.TreeView_HoverNode = function (data, el) {
                        var node = $(el);

                        if (node.hasClass(nodeClass)) {
                            node.parent().parent().parent().addClass(hoverClass);
                        } else {
                            hoverNode(data, el);
                        }
                    };

                    window.TreeView_UnhoverNode = function (el) {
                        var node = $(el);

                        if (node.hasClass(nodeClass)) {
                            $(el).parent().parent().parent().removeClass(hoverClass);
                        } else {
                            unhoverNode(el);
                        }
                    };

                    window.TreeView_ToggleNode = function (data, x, elNav, y, elNodes) {
                        var cookieData = null;

                        var cdt = $.parseJSON($.cookie(expandStateCookie));
                        if (cdt) {
                            cdt = $.parseJSON($.cookie(expandStateCookie))['epm-nav-sub-ql'];
                            if (cdt) {
                                cookieData = cdt;
                            }
                        }

                        var d = cookieData || {};
                        var nodeId = null;

                        var parents = $(elNav).parents('div');
                        for (var i = 0; i < parents.length; i++) {
                            var p = parents[i];
                            var $p = $(p);

                            if ($p.hasClass('epm-nav-sub')) {
                                nodeId = p.id;
                                var nodes = getLinkNodes(nodeId);
                                for (var j = 0; j < nodes.length; j++) {
                                    var n = nodes[j];
                                    var state = $(n).is(':visible');

                                    var nId = (n.id).replace('Nodes', '');

                                    if (nId === elNav.id) {
                                        state = !state;
                                    }

                                    d[$('#' + nId.replace('EPMLiveNavn', 'EPMLiveNavt')).text()] = state;
                                }

                                break;
                            }
                        }

                        saveExpandState(nodeId, d);
                        toggleNode(data, x, elNav, y, elNodes);
                    };

                    var clickables = ['suiteBar', 's4-ribbonrow', 's4-workspace'];
                    for (var c in clickables) {
                        $('#' + clickables[c]).click(function () {
                            if ($sn.data('pinstate') === 'unpinned') {
                                hideMenu();
                            }
                        });
                    }

                    var $pin = $('#epm-nav-pin');

                    $pin.click(function () {
                        togglePinned();
                    });

                    $sn.hover(function () {
                        $pin.show();
                    }, function () {
                        $pin.hide();
                    });

                    $sn.slimScroll({
                        height: $sn.height(),
                        width: $sn.width()
                    });

                    var $ss = $('#epm-nav').find('.slimScrollDiv');
                    var $sb = $ss.find('.slimScrollBar');

                    $ss.css('position', 'absolute');
                    $ss.css('left', '50px');
                    $sn.css('left', '0');
                    $sb.css('z-index', 1001);

                    $(window).resize(function () {
                        var height = $('#epm-nav-top').height();
                        $ss.height(height);
                        $sn.height(height);
                    });

                    $('a.epm-nav-node').click(function () {
                        var index = -1;

                        var $link = $(this);
                        var parent = $link.parents('div')[0];
                        var $siblings = $(parent).siblings('div');

                        if ($siblings) {
                            var $nodes = getLinkNodes($($siblings[0]).parent().parent().attr('id'));

                            for (var i = 0; i < $nodes.length; i++) {
                                var s = $nodes[i];
                                if (s.id === parent.id) {
                                    index = i;
                                }
                            }
                        }

                        $.cookie(selectedLinkCookie, JSON.stringify({ index: index, uri: $link.attr('href') }), cookieOptions);
                    });
                }

                function registerProviderLinks(response) {
                    var webUrl = $$.currentWebUrl;
                    var page = webUrl + window.location.href.split(webUrl)[1];

                    for (var providerName in response.Nodes) {
                        var navLink = response.Nodes[providerName].NavLink;
                        
                        if (!navLink.length) {
                            navLink = [navLink];
                        }
                        
                        for (var nl in navLink) {
                            var link = navLink[nl];

                            for (var j = 0; j < tlNodes.length; j++) {
                                var tlNode = tlNodes[j];
                                if (tlNode.provider === providerName) {
                                    tlNode.registerLink({
                                        id: link['@Id'],
                                        title: link['@Title'],
                                        url: (link['#cdata'] || '').replace(/{page}/g, page),
                                        category: link['@Category'],
                                        cssClass: link['@CssClass'],
                                        order: parseInt(link['@Order']),
                                        siteId: link['@SiteId'],
                                        webId: link['@WebId'],
                                        listId: link['@ListId'],
                                        itemId: link['@ItemId'],
                                        external: link['@Exernal'] === 'True',
                                        visible: link['@Visible'] === 'True',
                                        seprator: link['@Separator'] === 'True'
                                    });
                                }
                            }
                        }

                        expandNodes(providerName);

                        window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs('EPMLiveNavigation_' + providerName);
                    }
                }

                function loadLinks() {
                    var providers = [];

                    for (var i = 0; i < tlNodes.length; i++) {
                        var node = tlNodes[i];

                        if (!node.selected()) {
                            var provider = node.provider;
                            if (provider) {
                                providers.push(provider);
                            }
                        }
                    }

                    if (providers.length > 0) {
                        epmLiveService.execute('GetNavigationLinks', providers.join(), function (response) {
                            registerProviderLinks(response);
                            registerLinkEvents();
                        }, function (response) {
                            console.log(response);
                        });
                    }
                }
                
                function registerStaticProviderLinks() {
                    var links = null;
                    
                    if (window.epmLiveNavigation) {
                        links = window.epmLiveNavigation.staticProvider;
                    }

                    if (links) {
                        registerProviderLinks($$.parseJson(base64Service.decode(links)));
                    } else {
                        window.setTimeout(function() {
                            registerStaticProviderLinks();
                        }, 1);
                    }
                }
                
                function registerTopLevelNodes() {
                    $('#epm-nav-top').find("[data-role='top-nav-node']").each(function () {
                        tlNodes.push(new navNode(this));
                    });
                }

                var _init = function () {
                    registerTopLevelNodes();
                    registerStaticProviderLinks();
                    changePinState($.cookie(pinStateCookie) || 'pinned');
                    expandNodes();
                    selectLink();
                    registerEvents();

                    ExecuteOrDelayUntilScriptLoaded(loadLinks, 'EPMLive.js');
                };

                return {
                    init: _init
                };
            })();

            epmLiveNavigation.init();

            var manageFavorites = function() {
                var $ul = $('#epm-nav-sub-favorites-static-links');

                var resetOrder = function() {
                    var orders = [];

                    var lo = 0;
                    $ul.find('.epm-nav-node').each(function() {
                        orders.push($(this).get(0).id + ':' + (++lo));
                    });

                    if (orders.length) {
                        epmLiveService.execute('ReorderFavorites', orders.join(), function(response) {
                        }, function(response) {
                            console.log(response);
                        });
                    }
                };

                $ul.find('.epm-nav-node').each(function() {
                    var $li = $(this);
                    $li.prepend('<span class="epm-nav-dragger">&nbsp;</span>');

                    $li.hover(function() {
                        $($(this).find('.epm-nav-dragger').get(0)).css('visibility', 'visible');
                    }, function() {
                        $($(this).find('.epm-nav-dragger').get(0)).css('visibility', 'hidden');
                    });
                });

                $ul.sortable({
                    placeholder: 'epm-nav-drag-placeholder',
                    update: function(event, ui) {
                        resetOrder();
                    }
                });

                $ul.disableSelection();
            };

            ExecuteOrDelayUntilScriptLoaded(manageFavorites, 'EPMLiveNavigation_Favorites');
        });
    }

    function onJqueryLoaded() {
        ExecuteOrDelayUntilScriptLoaded(initializeNavigation, 'EPMLiveNavigation');
    }

    ExecuteOrDelayUntilScriptLoaded(onJqueryLoaded, 'jquery.min.js');
})();