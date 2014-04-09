(function($, $$, _, moment) {
    'use strict';

    var SocialEngine = function() {
        var SE = (function() {
            var baseUrl = window.epmLive.currentWebUrl.slice(1);

            var se = {
                pagination: null,
                ui: {
                    selectors: {
                        comments: 'div.epm-se-comments',
                        commentBox: 'div.epm-se-comment-input',
                        latestComments: 'ul.epm-se-latest-comments'
                    },
                    classes: {
                        placeholder: 'epm-se-placeholder',
                        expanded: 'epm-se-expanded',
                        active: 'epm-se-active',
                        hidden: 'epm-se-hidden',
                        overlay: 'epm-se-overlay',
                        disabled: 'epm-se-disabled'
                    }
                },
                apiUrl: '/' + baseUrl + '/_vti_bin/SocialEngine.svc',
                commentServiceUrl: '/' + baseUrl + '/_layouts/15/epmlive/CommentsProxy.aspx',
                statusUpdateServiceUrl: '/' + baseUrl + '/_vti_bin/WorkEngine.asmx/Execute',
            };

            var $el = {
                root: $('#epm-social-stream'),
                content: $(document.getElementById('s4-workspace')),
                pagination: $('#epm-social-stream div#epm-se-pagination span'),
                noActivity: $('#epm-social-stream div#epm-se-no-activity'),
                threads: $('#epm-social-stream ul#epm-se-threads'),
                statusUpdateBox: $('#epm-social-stream div#epm-se-status-update-box'),
            };

            var templates = {
                thread: _.compile($('script#epm-se-thread-template').html()),
                activity: _.compile($('script#epm-se-activity-template').html()),
                comment: _.compile($('script#epm-se-comment-template').html()),
                _userAvatar: _.compile($('script#_epm-se-user-avatar-template').html()),
                _threadIcon: _.compile($('script#_epm-se-thread-icon-template').html()),
                _threadTitle: _.compile($('script#_epm-se-thread-title-template').html()),
                _threadInfo: _.compile($('script#_epm-se-thread-info-template').html()),
                _activityIcon: _.compile($('script#_epm-se-activity-icon-template').html()),
                _userInfo: _.compile($('script#_epm-se-user-info-template').html()),
                _activityInfo: _.compile($('script#_epm-se-activity-info-template').html()),
                _activityTime: _.compile($('script#_epm-se-activity-time-template').html()),
                _objectInfo: _.compile($('script#_epm-se-object-info-template').html()),
                _commentBox: _.compile($('script#_epm-se-comment-box-template').html())
            };

            var helpers = (function() {

                function getLocalTime(time) {
                    if (window.epmLive.currentUserTimeZone) {
                        try {
                            return moment.tz(time, window.epmLive.currentUserTimeZone.olsonName);
                        } catch(e) {
                            if (window.epmLive.debugMode) {
                                console.log(e.message);
                            }
                        }
                    }

                    return time;
                }

                var _getFriendlyTime = function(time, isLocalTime) {
                    var date = isLocalTime ? time : getLocalTime(time);

                    moment.lang('en', {
                        calendar: {
                            lastDay: '[Yesterday]  MMM D',
                            sameDay: '[Today] MMM D',
                            nextDay: '[Tomorrow] MMM D',
                            lastWeek: '[Last] ddd MMM D',
                            nextWeek: 'ddd MMM D',
                            sameElse: 'MMMM D YYYY'
                        }
                    });

                    date = date.calendar();

                    configureMoment();

                    return date;
                };

                var _getLongTime = function(time) {
                    return getLocalTime(time).format('LLLL');
                };

                var _getUserFriendlyName = function(user) {
                    return parseInt(window.epmLive.currentUserId) === user.id ? 'You' : user.displayName;
                };

                var _getUserProfileUrl = function(user) {
                    return window.epmLive.currentWebUrl + '/_layouts/15/userdisp.aspx?ID=' + user.id;
                };

                var _sortComments = function(comments) {
                    if (comments.length) {
                        comments.sort(function(c1, c2) {
                            if (c1 && c2) {
                                return c1.time > c2.time;
                            }

                            return true;
                        });
                    }
                };

                var _resetpagination = function() {
                    se.pagination = {
                        isLoading: false,
                        firstTimeLoad: true,
                        page: 1,
                        limit: 10,
                        activityLimit: 1,
                        commentLimit: 2
                    };
                };

                var _startLoader = function() {
                    var seId = $el.root.get(0).id;

                    window.EPM.UI.Loader.current().startLoading({ id: seId });
                    se.loaderStarted = true;

                    var loader = $('#' + seId + '_epm_loader');
                    loader.css('margin-left', '-10px');
                    loader.width(loader.width() + 10);
                    loader.css('height', '100%');
                };

                var _stopLoader = function() {
                    $el.statusUpdateBox.show();
                    window.EPM.UI.Loader.current().stopLoading($el.root.get(0).id);
                    se.loaderStarted = false;
                };

                return {
                    getFriendlyTime: _getFriendlyTime,
                    getLongTime: _getLongTime,
                    getUserFriendlyName: _getUserFriendlyName,
                    getUserProfileUrl: _getUserProfileUrl,
                    sortComments: _sortComments,
                    resetPagination: _resetpagination,
                    startLoader: _startLoader,
                    stopLoader: _stopLoader
                };
            })();

            var actions = (function() {
                var _navigate = function($a, event) {
                    var kind = $a.data('kind');

                    if (kind !== 'Workspace') {
                        event.preventDefault();
                        OpenCreateWebPageDialog($a.attr('href'));
                    }
                };

                var _showOlder = function($ele) {
                    var kind = $ele.data('kind');

                    var apiUrl = se.apiUrl + '/thread/' + $ele.data('threadid') + '/' + kind + '?offset=' + $ele.data('offset') + '&v=' + new Date().getTime();

                    $ele.parent().find('ul.epm-se-older-' + kind).show();
                    $ele.remove();

                    $.getJSON(apiUrl).then(function(response) {
                        if (response.threads[0][kind].length) {
                            $$.publish('se.older' + kind + 'Loaded', response);
                        }
                    });
                };

                var _paginate = function() {
                    if ($('#epm-social-stream div#epm-se-pagination').offset().top < $(window).height()) {
                        if (se.pagination.isLoading) return;
                        if (se.pagination.page === 0) return;

                        $el.pagination.show();

                        _load();
                    }
                };

                return {
                    navigate: _navigate,
                    showOlder: _showOlder,
                    paginate: _paginate
                };
            })();

            var entityManager = (function() {
                var _getById = function(id, entities) {
                    for (var i = 0; i < entities.length; i++) {
                        var e = entities[i];
                        if (e.id === id) {
                            var entity = {};

                            for (var p in e) {
                                if (e.hasOwnProperty(p)) {
                                    entity[p] = e[p];
                                }
                            }

                            return entity;
                        }
                    }

                    return null;
                };

                return {
                    getById: _getById
                };
            })();

            var threadManager = (function() {

                function build(thread, data) {
                    var baseTime = '1986-11-06T13:03:00';

                    var activity = { time: baseTime };
                    var comment = { time: baseTime };

                    if (thread.activities.length) {
                        activity = thread.activities[0];
                    }

                    if (thread.comments.length) {
                        comment = thread.comments[thread.comments.length - 1];
                    }

                    if (activity.time === baseTime && comment.time === baseTime) {
                        return false;
                    }

                    var commentActivity = false;
                    var actionActivity;

                    if (activity.time > comment.time) {
                        actionActivity = activity;

                    } else {
                        actionActivity = comment;
                        commentActivity = true;
                    }

                    thread.user = entityManager.getById(actionActivity.userId, data.users);

                    if (thread.kind === 'Workspace') {
                        thread.icon = 'icon-tree-2';
                    } else if (thread.kind === 'StatusUpdate') {
                        thread.icon = 'icon-bubble-12';
                        thread.url = null;
                    } else {
                        thread.list = entityManager.getById(thread.listId, data.lists);
                        thread.list.icon = thread.list.icon || 'icon-square';
                        thread.icon = thread.list.icon;

                        if (window.epmLive.currentWebId !== thread.webId) {
                            activity.web = entityManager.getById(thread.webId, data.webs);
                        }
                    }

                    if (commentActivity) thread.hasMoreActivities = thread.totalActivities >= se.pagination.activityLimit;
                    else thread.hasMoreActivities = thread.totalActivities > se.pagination.activityLimit;

                    thread.hasMoreComments = thread.totalComments > se.pagination.commentLimit;
                    thread.commentsHidden = thread.totalComments > 0 ? '' : 'epm-se-hidden';

                    if (thread.activities.length) thread.earliestActivityTime = thread.activities[thread.activities.length - 1].time;
                    if (thread.comments.length) thread.earliestCommentTime = thread.comments[0].time;

                    return thread;
                }

                var _render = function(thread, data) {
                    var selector = 'li#epm-se-thread-' + thread.id;

                    var $thread = $el.threads.find(selector);

                    if (!$thread.length) {
                        helpers.sortComments(thread.comments);

                        if (thread = build(thread, data)) {
                            if (data.newStatusUpdate) $el.threads.prepend(templates.thread(thread));
                            else $el.threads.append(templates.thread(thread));
                            $$.publish('se.threadRendered', thread, $el.threads.find(selector), data);
                        }
                    } else {
                        $$.publish('se.threadRendered', thread, $thread, data);
                    }
                };

                return {
                    render: _render
                };
            })();

            var activityManager = (function() {

                function buildFirstActivity(activity, thread, data) {
                    if (thread.comments.length) {
                        var comment = thread.comments[thread.comments.length - 1];

                        if (comment.time > activity.time) {
                            activity = comment;
                            activity.icon = 'icon-bubble-12';
                            activity.action = 'made a comment';
                        }
                    }

                    if (!activity.icon) {
                        activity = _setIconAndAction(activity, thread);
                    }

                    activity = _setUser(activity, data);
                    activity = _setTime(activity);

                    return activity;
                }

                function build(activity, thread, data) {
                    activity = _setIconAndAction(activity, thread);
                    activity = _setUser(activity, data);
                    activity = _setTime(activity);

                    return activity;
                }

                function renderFirstActivity(thread, $thread, data) {
                    var activity = thread.activities[0];

                    if (activity) {
                        var selector = 'ul.epm-se-activities li#epm-se-activity-' + activity.id;

                        var $activity = $thread.find(selector);

                        if (!$activity.length) {
                            if (activity = buildFirstActivity(activity, thread, data)) {
                                $thread.find('ul.epm-se-activities').append(templates.activity(activity));
                            }
                        }
                    }
                }

                function renderOlderActivities(thread, $thread, data) {
                    for (var i = 0; i < thread.activities.length; i++) {
                        var activity = thread.activities[i];

                        var selector = 'ul.epm-se-activities li#epm-se-activity-' + activity.id;
                        var $activity = $thread.find(selector);

                        if (!$activity.length) {
                            selector = 'ul.epm-se-older-activities li#epm-se-activity-' + activity.id;
                            $activity = $thread.find(selector);

                            if (!$activity.length) {
                                if (activity = build(activity, thread, data)) {
                                    $thread.find('ul.epm-se-older-activities').append(templates.activity(activity));
                                }
                            }
                        }
                    }
                }

                var _render = function(thread, $thread, data) {
                    renderFirstActivity(thread, $thread, data);
                    renderOlderActivities(thread, $thread, data);
                };

                var _renderOlder = function(data) {
                    var thread = data.threads[0];
                    var $thread = $('li#epm-se-thread-' + thread.id);
                    renderOlderActivities(thread, $thread, data);
                };

                var _setIconAndAction = function(activity, thread) {
                    if (thread.kind === 'StatusUpdate') {
                        activity.icon = 'icon-bubble-12';
                        activity.action = 'made a comment';
                    } else {
                        var object = (thread.kind === 'ListItem' ? 'item' : thread.kind).toLowerCase();

                        switch (activity.kind) {
                        case 'Created':
                            activity.icon = 'icon-plus-2';
                            activity.action = 'created this ' + object;
                            break;
                        case 'Updated':
                            activity.icon = 'icon-pencil';
                            activity.action = 'made an update';
                            break;
                        }
                    }

                    return activity;
                };

                var _setUser = function(activity, data) {
                    activity.user = entityManager.getById(activity.userId, data.users);
                    activity.user.friendlyName = helpers.getUserFriendlyName(activity.user);
                    activity.user.profileUrl = helpers.getUserProfileUrl(activity.user);

                    return activity;
                };

                var _setTime = function(activity) {
                    activity.friendlyTime = helpers.getFriendlyTime(activity.time);
                    activity.longTime = helpers.getLongTime(activity.time);

                    return activity;
                };

                return {
                    render: _render,
                    renderOlder: _renderOlder,
                    setIconAndAction: _setIconAndAction,
                    setUser: _setUser,
                    setTime: _setTime
                };
            })();

            var commentManager = (function() {

                function build(comment, thread, data) {
                    comment = activityManager.setIconAndAction(comment, thread);
                    comment = activityManager.setUser(comment, data);
                    comment = activityManager.setTime(comment);

                    comment.text = eval('(' + comment.data + ')').comment;

                    return comment;
                }

                function renderComments(thread, $thread, data, isOlder) {
                    helpers.sortComments(thread.comments);

                    for (var i = 0; i < thread.comments.length; i++) {
                        var comment = thread.comments[i];

                        var selector = 'ul.epm-se-comments li#epm-se-comment-' + comment.id;
                        var $comment = $thread.find(selector);

                        if (!$comment.length) {
                            if (comment = build(comment, thread, data)) {
                                $thread.find(isOlder ? 'ul.epm-se-older-comments' : 'ul.epm-se-comments').append(templates.comment(comment));
                            }
                        }
                    }
                }

                function addPlaceholder(settings) {
                    settings.input.addClass(se.ui.classes.placeholder);
                    settings.input.html(settings.placeholder);
                }

                function removePlaceholder(settings) {
                    settings.input.removeClass(se.ui.classes.placeholder);
                    settings.input.html('');
                }

                function closeCommentBox(settings) {
                    settings.input.removeClass(se.ui.classes.expanded);
                    settings.button.hide();
                    settings.button.removeClass(se.ui.classes.active);
                }

                function addNewStatusUpdate(data) {
                    var userId = parseInt(window.epmLive.currentUserId);
                    var webId = window.epmLive.currentWebId;

                    var payload = {
                        lists: [],
                        threads: [{
                            activities: [{
                                data: null,
                                id: new Date().getTime(),
                                isBulkOperation: false,
                                key: new Date().getTime(),
                                kind: 'Created',
                                time: new Date().toUTCString(),
                                userId: userId
                            }],
                            comments: [],
                            id: new Date().getTime(),
                            kind: 'StatusUpdate',
                            title: data.text,
                            totalActivities: 1,
                            totalComments: 0,
                            webId: webId
                        }],
                        users: [{
                            displayName: window.epmLive.currentUserDisplayName,
                            id: userId,
                            picture: window.epmLive.currentUserAvatar
                        }],
                        webs: [{
                            id: webId,
                            url: window.epmLive.currentWebUrl
                        }],
                        newStatusUpdate: true
                    };

                    $$.publish('se.dataLoaded', payload);
                }

                function addComment(data) {
                    var time = moment().tz(window.epmLive.currentUserTimeZone.olsonName);

                    var comment = {
                        id: new Date().getTime(),
                        text: data.text,
                        friendlyTime: helpers.getFriendlyTime(time, true),
                        longTime: time.format('LLLL'),
                        user: {
                            friendlyName: 'You',
                            picture: window.epmLive.currentUserAvatar,
                            profileUrl: window.epmLive.currentWebUrl + '/_layouts/15/userdisp.aspx?ID=' + window.epmLive.currentUserId
                        }
                    };

                    if (data.$thread) {
                        data.$thread.find(se.ui.selectors.latestComments).append(templates.comment(comment));
                        data.$thread.find(se.ui.selectors.comments).removeClass(se.ui.classes.hidden);
                    } else {
                       addNewStatusUpdate(data);
                    }
                }

                function postComment(data) {
                    var itemId = 0;
                    var listId = null;

                    if (data.thread) {
                        itemId = data.thread.itemId;
                    }

                    if (itemId !== 0) {
                        listId = data.thread.listId;
                    } else {
                        itemId = null;
                    }

                    if (data.thread) {
                        $.post(se.commentServiceUrl, {
                            command: 'CreateComment',
                            comment: data.text,
                            newcomment: null,
                            itemId: itemId,
                            listId: listId,
                            userId: window.epmLive.currentUserId,
                            commentItemId: itemId,
                            kind: data.thread.kind,
                            suid: data.thread.activities[0].key
                        }).then(function(response) {
                            if (window.epmLive.debugMode) console.log(response);
                        });
                    } else {
                        var comment = data.text.replace(/'/g, '&apos;').replace(/"/g, '&quot;');

                        $.ajax({
                            url: se.statusUpdateServiceUrl,
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            data: "{ Function: 'CreatePublicComment', Dataxml: '<Data><Param key=\"Comment\"><![CDATA[" + comment + "]]></Param></Data>' }"
                        }).then(function(response) {
                            if (response.d) {
                                var code = response.d.match(/<Result Status="(\d)">/);
                                if (code.length && 0 === parseInt(code[1])) {
                                    window.setTimeout(function() {
                                        helpers.resetPagination();
                                        _load(null, true);
                                    }, 500);
                                }
                            }
                            if (window.epmLive.debugMode) console.log(response);
                        });
                    }
                }
                
                function addOverlay(settings) {
                    var height = settings.$thread.height() + 10;

                    var $overlay = $('<div></div>');
                    $overlay.addClass(se.ui.classes.overlay);
                    $overlay.height(height);
                    $overlay.css('margin-top', '-' + height + 'px');

                    settings.$thread.append($overlay);
                }

                function attahEvents(settings) {
                    settings.input.focus(function() {
                        if ($(this).html() === settings.placeholder) removePlaceholder(settings);
                        settings.input.addClass(se.ui.classes.expanded);
                        settings.button.show();
                    });

                    settings.input.blur(function() {
                        var html = $(this).html();
                        if (html === '' || html === '<br>') addPlaceholder(settings);

                        if (se.lastClickedElement.id !== settings.button.get(0).id) closeCommentBox(settings);
                    });

                    settings.input.keyup(function() {
                        var html = $(this).html();
                        if (html !== '' && html !== '<br>' && html !== settings.placeholder) {
                            settings.button.addClass(se.ui.classes.active);
                        } else {
                            settings.button.removeClass(se.ui.classes.active);
                        }
                    });

                    settings.button.click(function(event) {
                        event.preventDefault();

                        if (!$(this).hasClass(se.ui.classes.active)) return;

                        var data = {
                            text: $.trim(settings.input.html()),
                            thread: settings.thread,
                            $thread: settings.$thread
                        };

                        if (data.text.length === 0) return;

                        addComment(data);

                        addPlaceholder(settings);
                        closeCommentBox(settings);

                        postComment(data);
                    });

                    $el.root.mousedown(function(event) {
                        se.lastClickedElement = event.target;
                    });

                    $('body').tooltip({
                        selector: 'span.epm-se-has-tooltip',
                        delay: { show: 500, hide: 100 }
                    });
                }

                var _render = function(thread, $thread, data) {
                    renderComments(thread, $thread, data);
                };

                var _renderOlder = function(data) {
                    var thread = data.threads[0];
                    var $thread = $('li#epm-se-thread-' + thread.id);
                    renderComments(thread, $thread, data, true);
                };

                var _configureBox = function(settings) {
                    settings.input = settings.element.find(se.ui.selectors.commentBox);
                    settings.button = settings.element.find('button');

                    addPlaceholder(settings);
                    if (!settings.disabled) attahEvents(settings);
                    else {
                        settings.input.attr('contenteditable', false);
                        settings.$thread.addClass(se.ui.classes.disabled);
                        addOverlay(settings);
                    }
                };

                return {
                    render: _render,
                    renderOlder: _renderOlder,
                    configureBox: _configureBox
                };
            })();

            function configureMoment() {
                moment.lang('en', {
                    calendar: {
                        lastDay: '[Yesterday -]  MMMM D',
                        sameDay: '[Today -] MMMM D',
                        nextDay: '[Tomorrow -] MMMM D',
                        lastWeek: '[Last] dddd [-] MMMM D',
                        nextWeek: 'dddd [-] MMMM D',
                        sameElse: 'MMMM D YYYY'
                    }
                });
            }

            function configureUI() {
                _.registerPartial('user-avatar', templates._userAvatar);
                _.registerPartial('thread-icon', templates._threadIcon);
                _.registerPartial('thread-title', templates._threadTitle);
                _.registerPartial('thread-info', templates._threadInfo);
                _.registerPartial('activity-icon', templates._activityIcon);
                _.registerPartial('user-info', templates._userInfo);
                _.registerPartial('activity-info', templates._activityInfo);
                _.registerPartial('activity-time', templates._activityTime);
                _.registerPartial('object-info', templates._objectInfo);
                _.registerPartial('comment-box', templates._commentBox);

                commentManager.configureBox({
                    element: $el.statusUpdateBox,
                    placeholder: 'Share something...'
                });
            }

            function render(data) {
                for (var i = 0; i < data.threads.length; i++) {
                    $$.publish('se.threadLoaded', data.threads[i], data);
                }
            }

            function attachEvents() {
                $$.subscribe('se.dataLoaded', function(data) {
                    render(data);
                });

                $$.subscribe('se.threadLoaded', function(thread, data) {
                    threadManager.render(thread, data);
                });

                $$.subscribe('se.threadRendered', function(thread, $thread, data) {
                    activityManager.render(thread, $thread, data);
                    commentManager.render(thread, $thread, data);
                    commentManager.configureBox({
                        element: $thread.parent().find("div.epm-se-comment-box[data-threadId='" + thread.id + "']"),
                        placeholder: 'Add a comment...',
                        thread: thread,
                        $thread: $thread,
                        disabled: data.newStatusUpdate
                    });
                });

                $$.subscribe('se.olderactivitiesLoaded', function(data) {
                    activityManager.renderOlder(data);
                });

                $$.subscribe('se.oldercommentsLoaded', function(data) {
                    commentManager.renderOlder(data);
                });

                $el.root.on('click', 'a.epm-se-link', function(event) {
                    actions.navigate($(this), event);
                });

                $el.root.on('click', '.epm-show-older', function() {
                    actions.showOlder($(this));
                });

                $el.content.scroll(function() {
                    actions.paginate();
                });
            }

            var _configure = function() {
                helpers.startLoader();
                helpers.resetPagination();

                configureMoment();
                configureUI();
                attachEvents();
            };

            var _load = function(query, isReload, tries) {
                if (se.pagination.page === 0) return;
                if (tries > 5) {
                    $el.pagination.hide();
                    se.pagination.page = 0;
                    se.pagination.isLoading = false;
                    $el.noActivity.fadeIn('fast');

                    return;
                }

                tries = tries || 0;

                query = query || {
                    page: se.pagination.page,
                    limit: se.pagination.limit,
                    activityLimit: se.pagination.activityLimit,
                    commentLimit: se.pagination.commentLimit
                };

                se.pagination.isLoading = true;

                var apiUrl = se.apiUrl + '/activities?';

                var params = [];

                for (var p in query) {
                    if (query.hasOwnProperty(p)) {
                        params.push(p + '=' + query[p]);
                    }
                }

                apiUrl += params.join('&') + '&v=' + new Date().getTime();

                $.getJSON(apiUrl).success(function(response) {
                    if (response.error) {
                        window.setTimeout(function() {
                            _load(query, isReload, ++tries);
                        });

                        return;
                    }

                    $el.pagination.hide();

                    if (response.threads.length) {
                        if (isReload) $el.threads.html('');
                        $$.publish('se.dataLoaded', response);
                        se.pagination.page++;
                    } else {
                        se.pagination.page = 0;
                    }

                    se.pagination.isLoading = false;

                    if (se.pagination.firstTimeLoad && response.threads.length === 0) {
                        $el.noActivity.fadeIn('fast');
                    }

                    se.pagination.firstTimeLoad = false;

                    if (se.loaderStarted) {
                        helpers.stopLoader();
                    }
                }).error(function(response) {
                    if (window.epmLive.debugMode) {
                        console.log(response);
                    }

                    window.setTimeout(function() {
                        _load(query, isReload, ++tries);
                    });
                });
            };

            return {
                configure: _configure,
                load: _load
            };
        })();

        SE.configure();
        SE.load();
    };

    var loadSocialEngine = function() {
        if (window.epmLive) {
            SocialEngine();
        } else {
            window.setTimeout(function() {
                loadSocialEngine();
            }, 1);
        }
    };

    $(function() {
        loadSocialEngine();
    });
})(jQuery, amplify, Handlebars, moment);