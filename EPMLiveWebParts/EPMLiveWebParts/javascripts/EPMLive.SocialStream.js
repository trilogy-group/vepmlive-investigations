(function($, _, $$, moment) {
    'use strict';

    var SocialEngine = function() {
        var SE = (function() {
            var $el = {
                root: $('#epm-social-stream'),
                content: $(document.getElementById('s4-workspace')),
                pagination: $('#epm-social-stream div#epm-se-pagination span'),
                noActivity: $('#epm-social-stream div#epm-se-no-activity')
            };

            var templates = {
                day: $$.compile($('script#epm-se-day-template').html()),
                thread: $$.compile($('script#epm-se-thread-template').html()),
                activity: $$.compile($('script#epm-se-activity-template').html()),
                _singleNonCommentThread: $('script#_epm-se-single-non-comment-thread').html(),
                _commentThread: $('script#_epm-se-comment-thread').html(),
                _generalThread: $('script#_epm-se-general-thread').html(),
                _threadInfo: $('script#_epm-se-thread-info').html(),
                _avatar: $('script#_epm-se-avatar').html(),
                _user: $('script#_epm-se-user').html(),
                _userPlain: $('script#_epm-se-user-plain').html(),
                _time: $('script#_epm-se-time').html(),
                _threadIcon: $('script#_epm-se-thread-icon').html(),
                _commentBox: $('script#_epm-se-comment-box').html()
            };

            var config = {
                apiUrl: '/' + window.epmLive.currentWebUrl.slice(1) + '/_vti_bin/SocialEngine.svc',
                pagination: {
                    limit: 10,
                    offset: null,
                    isLoading: false
                },
                ui: {
                    selectors: {
                        newer: 'ul.epm-se-newer-activities',
                        older: 'ul.epm-se-older-activities',
                        showNewer: 'div.epm-se-show-newer',
                        showOlder: 'div.epm-se-show-older',
                        day: 'div.epm-se-header h1',
                        commentBox: 'div.epm-se-comment-input'
                    }
                },
                moreActivityRequests: [],
                threadsWithAllActivities: [],
                firstTimeLoad: true
            };

            var configureMoment = function() {
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
            };

            var configureUI = function() {
                $$.registerPartial('single-non-comment-thread', templates._singleNonCommentThread);
                $$.registerPartial('comment-thread', templates._commentThread);
                $$.registerPartial('general-thread', templates._generalThread);
                $$.registerPartial('thread-info', templates._threadInfo);
                $$.registerPartial('avatar', templates._avatar);
                $$.registerPartial('user', templates._user);
                $$.registerPartial('user-plain', templates._userPlain);
                $$.registerPartial('time', templates._time);
                $$.registerPartial('thread-icon', templates._threadIcon);
                $$.registerPartial('comment-box', templates._commentBox);
            };

            var attachEvents = function() {
                _.subscribe('se.dataLoaded', function(data) {
                    render(data);
                });

                _.subscribe('se.dayLoaded', function(day, data) {
                    dayManager.render(day, data);
                });

                _.subscribe('se.dayRendered', function(day, data, $day) {
                    threadManager.render(day, data, $day);
                });

                _.subscribe('se.threadRendered', function(activityThread, thread, data, $thread) {
                    activityManager.render(activityThread, thread, data, $thread);
                });
                
                _.subscribe('se.threadRendered', function (activityThread, thread, data, $thread) {
                    //commentManager.configureBox($thread);
                });

                $el.root.on('mouseenter', '.epm-se-has-tooltip', function() {
                    actions.showTooltip($(this));
                });

                $el.content.scroll(function() {
                    actions.paginate();
                });

                var linkables = ['a.epm-se-link-list', 'a.epm-se-link-item', 'a.epm-se-link-user'];
                for (var i = 0; i < linkables.length; i++) {
                    $el.root.on('click', linkables[i], function (event) {
                        actions.navigate($(this));
                        event.preventDefault();
                    });
                }
                
                var loadables = [config.ui.selectors.showOlder, config.ui.selectors.showNewer];
                for (var j = 0; j < loadables.length; j++) {
                    $el.root.on('click', loadables[j], function () {
                        actions.loadMore($(this));
                    });
                }
            };

            var _configure = function() {
                configureMoment();
                configureUI();
                attachEvents();
            };

            var _load = function (query) {
                config.pagination.isLoading = true;

                var apiUrl = config.apiUrl + '/activities';

                if (query) {
                    apiUrl += '?';

                    var params = [];

                    for (var p in query) {
                        if (query.hasOwnProperty(p)) {
                            params.push(p + '=' + query[p]);
                        }
                    }

                    apiUrl += params.join('&');
                }

                $.getJSON(apiUrl).then(function (response) {
                    $el.pagination.hide();
                    
                    _.publish('se.dataLoaded', response);
                    
                    config.pagination.offset = response.meta.offset;
                    config.pagination.isLoading = false;
                    
                    if (config.firstTimeLoad && response.activities.length === 0) {
                        $el.noActivity.fadeIn('fast');
                    }

                    config.firstTimeLoad = false;
                });
            };

            var loadMore = function(query, elements) {
                elements.loader.text('loading...');
                
                var apiUrl = config.apiUrl + '/thread/' + query.threadId + '?';

                var params = [];

                for (var p in query) {
                    if (query.hasOwnProperty(p)) {
                        if (p !== 'threadId') params.push(p + '=' + query[p]);
                    }
                }

                apiUrl += params.join('&');

                $.getJSON(apiUrl).then(function (response) {
                    activityManager.addMore(response, elements.list, query.maxDate ? 'older' : 'newer');

                    elements.loader.fadeOut('fast').remove();
                    elements.list.fadeIn('fast');
                });
            };

            var render = function(data) {
                for (var i = 0; i < data.days.length; i++) {
                    _.publish('se.dayLoaded', data.days[i], data);
                }
            };

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

            var userManager = (function() {
                var _getDisplayName = function(user) {
                    if (user.id === parseInt(window.epmLive.currentUserId)) return 'You';
                    return user.name.split(' ')[0];
                };

                var _getFullDisplayName = function(user) {
                    if (user.id === parseInt(window.epmLive.currentUserId)) return 'You';
                    return user.name;
                };

                var _getUrl = function(user) {
                    return window.epmLive.currentWebUrl + '/_layouts/15/userdisp.aspx?ID=' + user.id;
                };

                return {
                    getDisplayName: _getDisplayName,
                    getFullDisplayName: _getFullDisplayName,
                    getUrl: _getUrl
                };
            })();

            var dayManager = (function() {
                var $days = $el.root.find('ul#epm-se-days');

                var _renderDays = function(day, data) {
                    day.domId = day.id.split('T')[0];

                    var $li = $days.find('li#epm-se-' + day.domId);

                    if ($li.length) {
                        _.publish('se.dayRendered', day, data, $li);
                    } else {
                        day.day = actions.getLocalTime(day.id).calendar();

                        $days.append(templates.day(day));

                        _.publish('se.dayRendered', day, data, $days.find('li#epm-se-' + day.domId));
                    }
                };
                return {
                    render: _renderDays
                };
            })();

            var activityManager = (function() {
                var _getAction = function (activity) {
                    if (activity.kind === 'BULKOPERATION') {
                        return 'updated ' + eval('(' + activity.metaData + ')').totalActivities;
                    }
                    
                    return activity.kind.toLowerCase();
                };

                var _getDisplayTime = function(activity) {
                    var date = actions.getLocalTime(activity.time);

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

                var _getLongTime = function(activity) {
                    return actions.getLocalTime(activity.time).format('LLLL');
                };

                var getIcon = function(activity) {
                    switch (activity.kind) {
                        case 'CREATED':
                            return 'icon-plus-2';
                        case 'UPDATED':
                            return 'icon-pencil';
                        default:
                            return null;
                    }
                };

                var getText = function(activity) {
                    switch (activity.kind) {
                        case 'CREATED':
                            return 'created this item';
                        case 'UPDATED':
                            return 'made an update';
                        case 'COMMENTADDED':
                            return eval('(' + activity.metaData + ')').comment;
                        default:
                            return null;
                    }
                };

                var buildActivity = function(a, data) {
                    var activity = a;
                    if (!activity.id) activity = entityManager.getById(a, data.activities);

                    activity.text = getText(activity);
                    activity.icon = getIcon(activity);
                    activity.displayTime = _getDisplayTime(activity);
                    activity.user = entityManager.getById(activity.user, data.users);
                    activity.user.displayName = userManager.getFullDisplayName(activity.user);
                    activity.user.url = userManager.getUrl(activity.user);
                    activity.longDateTime = _getLongTime(activity);
                    activity.notComment = activity.kind !== 'COMMENTADDED';

                    return activity;
                };

                var _addMore = function (data, $ul, kind) {
                    var $parent = $ul.parent();
                    
                    for (var i = 0; i < data.activities.length; i++) {
                        var a = data.activities[i];

                        if (!$parent.find('li#epm-se-' + a.id).length) {
                            var activity = buildActivity(a, data);

                            if (kind === 'older') {
                                $ul.prepend(templates.activity(activity)).fadeIn('fast');
                            } else {
                                $ul.append(templates.activity(activity)).fadeIn('fast');
                            }
                        }
                    }
                };

                var _renderActivities = function (activityThread, thread, data, $thread) {
                    var hasOlder = false;
                    var hasNewer = false;

                    var taHtml = '';
                    var paHtml = '';

                    var $ta = $thread.find('ul.epm-se-todays-activities');
                    var $pa = $thread.find(config.ui.selectors.older);

                    for (var i = 0; i < activityThread.todaysActivities.length; i++) {
                        var ta = activityThread.todaysActivities[i];
                        var taDomId = 'ul.epm-se-todays-activities li#epm-se-' + ta;

                        var $taLi = $thread.find(taDomId);
                        if (!$taLi.length) {
                            var taActivity = buildActivity(ta, data);
                            taHtml += templates.activity(taActivity);
                        }
                    }

                    for (var k = 0; k < activityThread.previousActivities.length; k++) {
                        hasOlder = true;

                        var pa = activityThread.previousActivities[k];
                        var paDomId = 'ul.epm-se-previous-activities li#epm-se-' + pa;

                        var $paLi = $thread.find(paDomId);
                        if (!$paLi.length) {
                            var paActivity = buildActivity(pa, data);
                            paHtml += templates.activity(paActivity);
                        }
                    }

                    for (var j = 0; j < activityThread.newerActivities.length; j++) {
                        hasNewer = true;
                        
                        var na = activityThread.newerActivities[j];
                        var naDomId = 'ul.epm-se-newer-activities li#epm-se-' + na;

                        var $naLi = $thread.find(naDomId);
                        if (!$naLi.length) {
                            var naActivity = buildActivity(na, data);
                            $thread.find(config.ui.selectors.newer).append(templates.activity(naActivity));
                        }
                    }

                    if (config.firstTimeLoad) {
                        $ta.append(taHtml).fadeIn('fast');
                        $pa.append(paHtml);
                    } else {
                        $ta.prepend(taHtml).fadeIn('fast');
                        $pa.prepend(paHtml);
                    }

                    if (hasOlder) $thread.find(config.ui.selectors.showOlder).fadeIn('fast');
                    if (hasNewer) $thread.find(config.ui.selectors.showNewer).fadeIn('fast');
                };

                return {
                    render: _renderActivities,
                    getAction: _getAction,
                    getDisplayTime: _getDisplayTime,
                    getLongTime: _getLongTime,
                    addMore: _addMore
                };
            })();

            var threadManager = (function() {
                var buildThread = function(t, data) {
                    t.activity = entityManager.getById(t.activities[0], data.activities);

                    t.isCommentThread = !t.list && !t.activity.itemId;
                    t.isSingleNonCommentThread = !t.isCommentThread && t.activities.length === 1 && t.activity.kind !== 'COMMENTADDED';
                    t.isBulkOperationThread = t.activity.kind === 'BULKOPERATION';

                    t.activity.action = activityManager.getAction(t.activity);
                    t.activity.displayTime = activityManager.getDisplayTime(t.activity);
                    t.activity.longDateTime = activityManager.getLongTime(t.activity);

                    t.user = entityManager.getById(t.activity.user, data.users);
                    t.user.displayName = t.isCommentThread ? userManager.getFullDisplayName(t.user) : userManager.getDisplayName(t.user);
                    t.user.url = userManager.getUrl(t.user);

                    t.web = entityManager.getById(t.web, data.webs);
                    t.web.isCurrentWorkspace = t.web.id.toLowerCase() === window.epmLive.currentWebId.toLowerCase();

                    t.list = entityManager.getById(t.list, data.lists);
                    t.icon = t.list.icon || 'icon-square';

                    return t;
                };

                var renderThread = function(at, t, day, data, $day) {
                    var thread = t;

                    thread.domId = 'ul li#epm-se-' + thread.id;

                    var $li = $day.find(thread.domId);
                    if ($li.length) {
                        _.publish('se.threadRendered', at, thread, data, $li);
                    } else {
                        thread = buildThread(thread, data);

                        $day.find('ul.epm-se-threads').append(templates.thread(thread)).fadeIn('fast');

                        _.publish('se.threadRendered', at, thread, data, $day.find(thread.domId));
                    }
                };

                var _renderThreads = function(day, data, $day) {
                    for (var i = 0; i < day.activityThreads.length; i++) {
                        var at = entityManager.getById(day.activityThreads[i], data.activityThreads);
                        var t = entityManager.getById(at.thread, data.threads);

                        renderThread(at, t, day, data, $day);
                    }
                };

                return {
                    render: _renderThreads
                };
            })();

            var actions = (function() {
                var _showTooltip = function($ele) {
                    $ele.tooltip('show');
                };

                var _navigate = function($ele) {
                    OpenCreateWebPageDialog($ele.data('url'));
                };

                var _paginate = function () {
                    if ($('#epm-social-stream div#epm-se-pagination').offset().top < $(window).height()) {
                        var settings = config.pagination;

                        if (settings.isLoading) return;
                        if (!settings.offset) return;
                        
                        $el.pagination.show();

                        _load({
                            limit: settings.limit,
                            offset: settings.offset
                        });
                    }
                };

                var _loadMoreActivities = function ($ele) {
                    var threadId = $ele.data('threadid');
                    var selectors = config.ui.selectors;

                    var action = $ele.data('action');
                    var $parent = $ele.parent();
                    var date = $parent.parent().parent().data('date');
                    var $ul;

                    var query = { threadId: threadId };
                    
                    if (action === 'newer') {
                        $ul = $parent.find(selectors.newer);
                        query.minDate = moment(date).add('days', 1).format('YYYY-MM-DDT00:00:00');
                    } else {
                        $ul = $parent.find(selectors.older);
                        query.maxDate = date;
                    }

                    loadMore(query, {
                        list: $ul,
                        loader: $ele
                    });
                };

                var _getLocalTime = function(dateTime) {
                    if (window.epmLive.currentUserTimeZone) {
                        try {
                            return moment.tz(dateTime, window.epmLive.currentUserTimeZone.olsonName);
                        } catch (e) {
                            if (window.epmLive.debugMode) {
                                console.log(e.message);
                            }
                        }
                    }

                    return dateTime;
                };

                return {
                    showTooltip: _showTooltip,
                    navigate: _navigate,
                    paginate: _paginate,
                    loadMore: _loadMoreActivities,
                    getLocalTime:_getLocalTime
                };
            })();

            return {
                configure: _configure,
                load: _load
            };
        })();

        SE.configure();
        SE.load({ limit: 20 });
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