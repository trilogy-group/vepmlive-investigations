(function($, _, $$, moment) {
    'use strict';

    var SocialEngine = function() {
        var SE = (function () {
            var $el= {
                root: $('#epm-social-stream')
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
                _time: $('script#_epm-se-time').html(),
                _threadIcon: $('script#_epm-se-thread-icon').html()
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

            var _configure = function () {
                configureMoment();
                
                $$.registerPartial('single-non-comment-thread', templates._singleNonCommentThread);
                $$.registerPartial('comment-thread', templates._commentThread);
                $$.registerPartial('general-thread', templates._generalThread);
                $$.registerPartial('thread-info', templates._threadInfo);
                $$.registerPartial('avatar', templates._avatar);
                $$.registerPartial('user', templates._user);
                $$.registerPartial('time', templates._time);
                $$.registerPartial('thread-icon', templates._threadIcon);

                _.subscribe('se.dataLoaded', function (data) {
                    _render(data);
                });
            };

            var _load = function (query) {
                var apiUrl = '/' + window.epmLive.currentWebUrl.slice(1) + '/_vti_bin/SocialEngine.svc/activities';

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
                    _.publish('se.dataLoaded', response);
                });
            };

            var _render = function (data) {
                for (var i = 0; i < data.days.length; i++) {
                    _.publish('se.dayLoaded', data.days[i], data);
                }
            };

            var entityManager = (function () {
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

            var userManager = (function () {
                var _getDisplayName = function(user) {
                    if (user.id === parseInt(window.epmLive.currentUserId)) return 'You';
                    return user.name.split(' ')[0];
                };
                
                var _getFullDisplayName = function (user) {
                    if (user.id === parseInt(window.epmLive.currentUserId)) return 'You';
                    return user.name;
                };
                
                return {
                    getDisplayName: _getDisplayName,
                    getFullDisplayName: _getFullDisplayName
                };
            })();

            var dayManager = (function () {
                var $days = $el.root.find('ul#epm-se-days');

                var render = function (day, data) {
                    day.domId = day.id.split('T')[0];

                    var $li = $days.find('li#epm-se-' + day.domId);

                    if ($li.length) {
                        _.publish('se.dayRendered', day, data, $li);
                    } else {
                        day.day = moment(day.id).calendar();

                        $days.append(templates.day(day));

                        _.publish('se.dayRendered', day, data, $days.find('li#epm-se-' + day.domId));
                    }
                };

                _.subscribe('se.dayLoaded', function (day, data) {
                    render(day, data);
                });
            })();

            var activityManager = (function() {
                var _getAction = function(activity) {
                    return activity.kind.toLowerCase();
                };

                var _getDisplayTime = function(activity) {
                    var date = moment(activity.time);

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

                var getIcon = function(activity) {
                    switch(activity.kind) {
                        case 'CREATED':
                            return 'icon-plus-2';
                        case 'UPDATED':
                            return 'icon-pencil';
                        default:
                            return null;
                    }
                };

                var getText = function(activity) {
                    switch(activity.kind) {
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
                    var activity = entityManager.getById(a, data.activities);

                    activity.text = getText(activity);
                    activity.icon = getIcon(activity);
                    activity.displayTime = _getDisplayTime(activity);
                    activity.user = entityManager.getById(activity.user, data.users);
                    activity.user.displayName = userManager.getFullDisplayName(activity.user);
                    activity.notComment = activity.kind !== 'COMMENTADDED';

                    return activity;
                };

                var render = function (activityThread, thread, data, $thread) {
                    for (var i = 0; i < activityThread.todaysActivities.length; i++) {
                        var ta = activityThread.todaysActivities[i];
                        var taDomId = 'ul.epm-se-todays-activities li#epm-se-' + ta;

                        var $taLi = $thread.find(taDomId);
                        if (!$taLi.length) {
                            var taActivity = buildActivity(ta, data);
                            $thread.find('ul.epm-se-todays-activities').append(templates.activity(taActivity));
                        }
                    }

                    for (var j = 0; j < activityThread.newerActivities.length; j++) {
                        var na = activityThread.newerActivities[j];
                        var naDomId = 'ul.epm-se-newer-activities li#epm-se-' + na;
                        
                        var $naLi = $thread.find(naDomId);
                        if (!$naLi.length) {
                            var naActivity = buildActivity(na, data);
                            $thread.find('ul.epm-se-newer-activities').append(templates.activity(naActivity));
                        }
                    }
                    
                    for (var k = 0; k < activityThread.newerActivities.length; k++) {
                        var pa = activityThread.newerActivities[k];
                        var paDomId = 'ul.epm-se-previous-activities li#epm-se-' + pa;

                        var $paLi = $thread.find(paDomId);
                        if (!$paLi.length) {
                            var paActivity = buildActivity(pa, data);
                            $thread.find('ul.epm-se-previous-activities').append(templates.activity(paActivity));
                        }
                    }
                };

                _.subscribe('se.threadRendered', function(activityThread, thread, data, $thread) {
                    render(activityThread, thread, data, $thread);
                });

                return {
                    getAction: _getAction,
                    getDisplayTime: _getDisplayTime
                };
            })();

            var threadManager = (function () {
                var buildThread = function (t, data) {
                    t.activity = entityManager.getById(t.activities[0], data.activities);
                    
                    t.isCommentThread = !t.list && !t.activity.itemId;
                    t.isSingleNonCommentThread = !t.isCommentThread && t.activities.length === 1 && t.activity.kind !== 'COMMENTADDED';

                    t.activity.action = activityManager.getAction(t.activity);
                    t.activity.displayTime = activityManager.getDisplayTime(t.activity);

                    t.user = entityManager.getById(t.activity.user, data.users);
                    t.user.displayName = t.isCommentThread ? userManager.getFullDisplayName(t.user) : userManager.getDisplayName(t.user);

                    t.web = entityManager.getById(t.web, data.webs);
                    t.web.isCurrentWorkspace = t.web.id.toLowerCase() === window.epmLive.currentWebId.toLowerCase();
                    
                    t.list = entityManager.getById(t.list, data.lists);
                    t.icon = t.list.icon || 'icon-square';

                    return t;
                };
                
                var renderThread = function (at, t, day, data, $day) {
                    var thread = t;
                    
                    thread.domId = 'ul li#epm-se-' + thread.id;

                    var $li = $day.find(thread.domId);
                    if ($li.length) {
                        _.publish('se.threadRendered', at, thread, data, $li);
                    } else {
                        thread = buildThread(thread, data);

                        $day.find('ul.epm-se-threads').append(templates.thread(thread));
                        
                        _.publish('se.threadRendered', at, thread, data, $day.find(thread.domId));
                    }
                };

                var render = function(day, data, $day) {
                    for (var i = 0; i < day.activityThreads.length; i++) {
                        var at = entityManager.getById(day.activityThreads[i], data.activityThreads);
                        var t = entityManager.getById(at.thread, data.threads);
                        
                        renderThread(at, t, day, data, $day);
                    }
                };

                _.subscribe('se.dayRendered', function (day, data, $day) {
                    render(day, data, $day);
                });
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