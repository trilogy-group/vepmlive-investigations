(function ($, $$, _, moment) {
    'use strict';

    var SocialEngine = function () {
        var SE = (function () {
            var baseUrl = window.epmLive.currentWebUrl.slice(1);

            var se = {
                apiUrl: '/' + baseUrl + '/_vti_bin/SocialEngine.svc',
                ui: {
                    classes: {
                        active: 'epm-se-active'
                    }
                }
            };

            var $el = {
                logs: $('#epm-se-logs div#epm-se-log-list ul'),
                logList: $('#epm-se-logs div#epm-se-log-list'),
                details: $('#epm-se-logs div#epm-se-log-details'),
                message: $('#epm-se-logs div.epm-se-message')
            };

            var templates = {
                log: _.compile($('script#epm-se-log-template').html()),
                details: _.compile($('script#epm-se-log-details-template').html())
            };

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
            
            function attachEvents() {
                $$.subscribe('se.logsLoaded', logManager.render);
                
                $$.subscribe('se.logRendered', function($log, log, isFirst) {
                    $log.click(function() {
                        logManager.showDetails($(this), log);
                    });

                    if (isFirst) $log.click();
                });

                $('html').keydown(function (e) {
                    e.preventDefault();
                    
                    if (e.which === 38) logManager.navigate('up');
                    else if (e.which === 40) logManager.navigate('down');
                });
            }

            var logManager = (function () {
                function build(log) {
                    switch (log.kind) {
                        case 'Info':
                            log.icon = 'icon-info-2';
                            break;
                        case 'Error':
                            log.icon = 'icon-warning-2';
                            break;
                    }

                    var userId = log.user;
                    var user = null;
                    
                    for (var i = 0; i < se.data.users.length; i++) {
                        var u = se.data.users[i];
                        if (u.id === userId) {
                            user = u;
                            break;
                        }
                    }

                    log.user = user;

                    var webId = log.web;
                    var web = null;

                    for (var j = 0; j < se.data.webs.length; j++) {
                        var w = se.data.webs[j];
                        if (w.id === webId) {
                            web = w;
                            break;
                        }
                    }

                    log.web = web;

                    log.details = log.details.trim();
                    log.stackTrace = log.stackTrace.trim();

                    return log;
                }
                
                var _render = function() {
                    for (var i = 0; i < se.data.collection.length; i++) {
                        var log = se.data.collection[i];
                        log = build(log);

                        $el.logs.append(templates.log(log));
                        $$.publish('se.logRendered', $el.logs.find('li#epm-se-log-' + log.id), log, i === 0);
                    }
                };

                var _showDetails = function ($log, log) {
                    $log.parent().find('li').removeClass(se.ui.classes.active);
                    $log.addClass(se.ui.classes.active);
                    $el.details.html(templates.details(log));

                    $el.details.find('pre').each(function(i, e) {
                        hljs.highlightBlock(e);
                    });
                };

                var _navigate = function(direction) {
                    var $active = $($el.logs.find('li.' + se.ui.classes.active).get(0));

                    var index = $active.index();
                    
                    if (direction === 'up' && index === 0) return;
                    if (direction === 'down' && index === se.data.collection.length - 1) return;

                    if (direction === 'up') index--;
                    else index++;

                    var $selected = $($el.logs.find('li').get(index));
                    
                    $selected.click();
                    $el.logList.scrollTop($selected.position().top);
                };

                return {
                    render: _render,
                    showDetails: _showDetails,
                    navigate: _navigate
                };
            })();

            var _configure = function () {
                configureMoment();
                attachEvents();
            };

            var _loadLogs = function () {
                $.get(se.apiUrl + '/logs?v=' + new Date().getTime()).then(function(response) {
                    if (!response || response.error) {
                        try {
                            $el.message.text(response.error.message);
                            $el.message.show();
                        } catch (e) { }
                        
                        return;
                    }

                    se.data = response;
                    $$.publish('se.logsLoaded');
                });
            };

            return {
                configure: _configure,
                loadLogs: _loadLogs
            };
        })();

        SE.configure();
        SE.loadLogs();
    };

    var loadSocialEngine = function () {
        if (window.epmLive) {
            SocialEngine();
        } else {
            window.setTimeout(function () {
                loadSocialEngine();
            }, 1);
        }
    };

    $(function () {
        loadSocialEngine();
    });
})(jQuery, amplify, Handlebars, moment);