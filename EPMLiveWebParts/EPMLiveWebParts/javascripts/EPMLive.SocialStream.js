(function($, $$, _, moment) {
    'use strict';

    var SocialEngine = function() {
        var SE = (function () {
            var se = {
                pagination: {
                    isLoading: false,
                    firstTimeLoad: true,
                    page: 1,
                    limit: 10,
                    activityLimit: 1,
                    commentLimit: 2
                },
                apiUrl: '/' + window.epmLive.currentWebUrl.slice(1) + '/_vti_bin/SocialEngine.svc'
            };
            
            var $el = {
                root: $('#epm-social-stream'),
                content: $(document.getElementById('s4-workspace')),
                pagination: $('#epm-social-stream div#epm-se-pagination span'),
                noActivity: $('#epm-social-stream div#epm-se-no-activity'),
                threads: $('#epm-social-stream ul#epm-se-threads')
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
                _objectInfo: _.compile($('script#_epm-se-object-info-template').html())
            };

            var helpers = (function () {
                function getLocalTime(time) {
                    if (window.epmLive.currentUserTimeZone) {
                        try {
                            return moment.tz(time, window.epmLive.currentUserTimeZone.olsonName);
                        } catch (e) {
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
                        comments.sort(function (c1, c2) {
                            if (c1 && c2) {
                                return c1.time > c2.time;
                            }

                            return true;
                        });
                    }
                };

                return {
                    getFriendlyTime: _getFriendlyTime,
                    getLongTime: _getLongTime,
                    getUserFriendlyName: _getUserFriendlyName,
                    getUserProfileUrl: _getUserProfileUrl,
                    sortComments: _sortComments
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

                var _showTooltip = function($ele) {
                    $ele.tooltip('show');
                };

                var _showOlder = function($ele) {
                    var kind = $ele.data('kind');

                    var apiUrl = se.apiUrl + '/thread/' + $ele.data('threadid') + '/' + kind + '?offset=' + $ele.data('offset');

                    $ele.parent().find('ul.epm-se-older-' + kind).show();
                    $ele.remove();

                    $.getJSON(apiUrl).then(function (response) {
                        if (response.threads[0][kind].length) {
                            $$.publish('se.older' + kind + 'Loaded', response);
                        }
                    });
                };

                return {
                    navigate: _navigate,
                    showTooltip: _showTooltip,
                    showOlder: _showOlder
                };
            })();

            var entityManager = (function () {
                var _getById = function (id, entities) {
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

            var threadManager = (function () {
                function build(thread, data) {
                    var baseTime = '1986-11-06T13:03:00';
                    
                    var activity = { time: baseTime };
                    var comment = { time: baseTime };
                    
                    if (thread.activities.length) {
                        activity = thread.activities[0];
                    }
                    
                    if (thread.comments.length) {
                        comment = thread.comments[0];
                    }

                    if (activity.time === baseTime && comment.time === baseTime) {
                        return false;
                    }

                    var actionActivity;

                    if (activity.time > comment.time) {
                        actionActivity = activity;

                    } else {
                        actionActivity = comment;
                    }
                    
                    thread.user = entityManager.getById(actionActivity.userId, data.users);
                    
                    if (thread.kind === 'Workspace') {
                        thread.icon = 'icon-tree-2';
                    } else {
                        thread.list = entityManager.getById(thread.listId, data.lists);
                        thread.list.icon = thread.list.icon || 'icon-square';
                        thread.icon = thread.list.icon;
                        
                        if (window.epmLive.currentWebId !== thread.webId) {
                            activity.web = entityManager.getById(thread.webId, data.webs);
                        }
                    }

                    thread.hasMoreActivities = thread.totalActivities > se.pagination.activityLimit;
                    thread.hasMoreComments = thread.totalComments > se.pagination.commentLimit;
                    thread.hasComments = thread.totalComments > 0;

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
                            $el.threads.append(templates.thread(thread));
                            $$.publish('se.threadRendered', thread, $el.threads.find(selector), data);
                        }
                    } else {
                        $$.publish('se.threadRendered', thread, $thread, data);
                    }
                };
                
                return {
                    render:_render
                };
            })();

            var activityManager = (function () {
                function buildFirstActivity(activity, thread, data) {
                    if (thread.comments.length) {
                        var comment = thread.comments[0];

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

                    var selector = 'ul.epm-se-activities li#epm-se-activity-' + activity.id;

                    var $activity = $thread.find(selector);

                    if (!$activity.length) {
                        if (activity = buildFirstActivity(activity, thread, data)) {
                            $thread.find('ul.epm-se-activities').append(templates.activity(activity));
                            $$.publish('se.firstActivityRendered', activity, $thread.find(selector), data);
                        }
                    } else {
                        $$.publish('se.firstActivityRendered', activity, $activity, data);
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
                                    $$.publish('se.olderActivityRendered', activity, $thread.find(selector), data);
                                }
                            } else {
                                $$.publish('se.olderActivityRendered', activity, $activity, data);
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

                var _setIconAndAction = function (activity, thread) {
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

                    return activity;
                };
                
                var _setUser = function (activity, data) {
                    activity.user = entityManager.getById(activity.userId, data.users);
                    activity.user.friendlyName = helpers.getUserFriendlyName(activity.user);
                    activity.user.profileUrl = helpers.getUserProfileUrl(activity.user);

                    return activity;
                };
                
                var _setTime = function (activity) {
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

                        if (!comment.length) {
                            if (comment = build(comment, thread, data)) {
                                $thread.find(isOlder ? 'ul.epm-se-older-comments' : 'ul.epm-se-comments').append(templates.comment(comment));

                                $$.publish('se.commentRendered', comment, $thread.find(selector), data);
                            }
                        } else {
                            $$.publish('se.commentRendered', comment, $comment, data);
                        }
                    }
                }

                var _render = function(thread, $thread, data) {
                    renderComments(thread, $thread, data);
                };
                
                var _renderOlder = function (data) {
                    var thread = data.threads[0];
                    var $thread = $('li#epm-se-thread-' + thread.id);
                    renderComments(thread, $thread, data, true);
                };

                return {
                    render: _render,
                    renderOlder: _renderOlder
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
            }

            function render(data) {
                for (var i = 0; i < data.threads.length; i++) {
                    $$.publish('se.threadLoaded', data.threads[i], data);
                }
            }

            function attachEvents() {
                $$.subscribe('se.dataLoaded', function (data) {
                    render(data);
                });
                
                $$.subscribe('se.threadLoaded', function (thread, data) {
                    threadManager.render(thread, data);
                });
                
                $$.subscribe('se.threadRendered', function (thread, $thread, data) {
                    activityManager.render(thread, $thread, data);
                    commentManager.render(thread, $thread, data);
                });
                
                $$.subscribe('se.olderactivitiesLoaded', function (data) {
                    activityManager.renderOlder(data);
                });
                
                $$.subscribe('se.oldercommentsLoaded', function (data) {
                    commentManager.renderOlder(data);
                });
                
                $el.root.on('mouseenter', '.epm-se-has-tooltip', function () {
                    actions.showTooltip($(this));
                });
                
                $el.root.on('click', 'a.epm-se-link', function (event) {
                    actions.navigate($(this), event);
                });

                $el.root.on('click', '.epm-show-older', function() {
                    actions.showOlder($(this));
                });
            }

            var _configure = function () {
                configureMoment();
                configureUI();
                attachEvents();
            };

            var _load = function (query) {
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

                apiUrl += params.join('&');

                $.getJSON(apiUrl).then(function (response) {
                    $el.pagination.hide();

                    if (response.threads.length) {
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