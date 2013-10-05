function initializeEPMLiveNotifications() {
    $.getScript('/_layouts/epmlive/javascripts/libraries/jquery.timeago.js', function() {
        $.getScript('/_layouts/epmlive/javascripts/libraries/jquery.endless-scroll.js', function() {
            $.getScript('/_layouts/epmlive/javascripts/libraries/slimScroll.js', function() {
                (function() {
                    var $ = window.jQuery;
                    var $$ = window.epmLive;
                    var console;

                    var firstLoad = true;

                    try {
                        console = window.console;
                    } catch(e) {
                        if (!window.console)
                            console = {
                                log: function() {
                                }
                            };
                    }

                    try {
                        var oldNotificationsLoaded = false;

                        var n = window.epmLiveNotifications;

                        n.messageTypeImageCollection = {
                            0: 'system',
                            1: 'system',
                            3: 'comment',
                            4: 'assigned-to',
                            5: 'pending-project-update',
                            12: 'resources',
                            13: 'resources'
                        };

                        n.queryInterval = 30000;

                        n.init();

                        ko.applyBindings(n, document.getElementById('EPMLiveNotificationsWrap'));
                        ko.applyBindings(n, document.getElementById('EPMLiveNotificationCounter'));
                        ko.applyBindings(n, document.getElementById('EPMLiveNotificationCount'));

                        function updateNotifications(result, type) {
                            if (!result) return;

                            var notifications;

                            if (!result.length) {
                                notifications = [result];
                            } else {
                                notifications = result;
                            }

                            var limit = n.notificationQueryLimit();
                            var length = notifications.length;

                            if (!firstLoad && type === 'NEW') {
                                if (length > limit) {
                                    length = limit;

                                    var aNoti = [];

                                    for (var x = 0; x < n.notifications().length; x++) {
                                        aNoti.push(n.notifications()[x]);
                                    }

                                    for (x = 0; x < aNoti.length; x++) {
                                        n.notifications.remove(aNoti[x]);
                                    }

                                    aNoti = [];

                                    for (x = 0; x < n.invisibleNotifications().length; x++) {
                                        aNoti.push(n.invisibleNotifications()[x]);
                                    }

                                    for (x = 0; x < aNoti.length; x++) {
                                        n.invisibleNotifications.remove(aNoti[x]);
                                    }
                                }
                            }

                            for (var i = 0; i < length; i++) {
                                var nf = notifications[i];

                                var notification = {};

                                for (var no in nf) {
                                    if (nf.hasOwnProperty(no)) {
                                        try {
                                            var key = no.replace(/@/, '').toLowerCase();
                                            var value = nf[no];

                                            if (key !== 'createdatdatestring') {
                                                if (!$$.isGuid(value)) {
                                                    if (value['#cdata']) {
                                                        value = value['#cdata'];
                                                    } else if (value === 'true') {
                                                        value = true;
                                                    } else if (value === 'false') {
                                                        value = false;
                                                    } else {
                                                        if (value.indexOf(' ') === -1) {
                                                            var number = parseInt(value);
                                                            if (!isNaN(number)) {
                                                                value = number;
                                                            }
                                                        } else {
                                                            var date = Date.parse(value);
                                                            if (!isNaN(date)) {
                                                                value = new Date(value);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            notification[key] = ko.observable(value);
                                        } catch(ex) {
                                        } 
                                    }
                                }

                                n.registerNotification(notification);
                            }

                            if (!firstLoad && type === 'NEW') {
                                if ($('#EPMLiveNotificationCount').text() !== (notifications.length + '')) {
                                    n.totalNewNotifications(notifications.length);

                                    var color = '#D0D0D0';

                                    if (!$('#EPMLiveNotificationsWrap').is(':visible')) {
                                        if (n.newSystemNotifications().length > 0) {
                                            color = '#89CE00';
                                        } else if (n.newGeneralNotifications().length > 0) {
                                            color = '#26C6F4';
                                        } else {
                                            color = '#547194';
                                        }
                                    }

                                    $("#EPMLiveNotificationCounter").css('background', color);
                                }
                            }

                            n.firstTimeLoad = false;

                            if (!oldNotificationsLoaded) {
                                var notificationDisplayLimit = n.notificationDisplayLimit;

                                n.notificationDisplayLimit = 5;
                                n.retrieveMoreNotifications('GENERAL', 'OLD');
                                n.notificationDisplayLimit = notificationDisplayLimit;

                                oldNotificationsLoaded = true;
                            }
                        }

                        function getNotifications(status, limit, firstPage, lastPage) {
                            if (status !== 'ALL' && status !== 'NEW' && status !== 'OLD') {
                                status = 'ALL';
                            }

                            if (!limit) {
                                limit = 0;
                            }

                            if (!firstPage) {
                                firstPage = 0;
                            }

                            if (!lastPage) {
                                lastPage = 0;
                            }

                            var dataXml = '<Notifications Status="' + status + '" Limit="' + limit + '" FirstPage="' + firstPage + '" LastPage="' + lastPage + '" FirstLoad="' + firstLoad + '"/>';

                            $.ajax({
                                type: 'POST',
                                url: $$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                                data: "{ Function: 'GetNotifications', Dataxml: '" + dataXml + "' }",
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',

                                success: function (response) {
                                    if (response.d) {
                                        var responseJson = $$.parseJson(response.d);

                                        if ($$.responseIsSuccess(responseJson.Result)) {
                                            if (responseJson.Result.Notifications) {
                                                updateNotifications(responseJson.Result.Notifications.Notification, status);

                                                if (firstLoad) {
                                                    firstLoad = false;
                                                    n.totalNewNotifications(responseJson.Result.Notifications['@TotalNew']);
                                                }
                                            }
                                        } else {
                                            $$.logFailure(responseJson.Result);
                                        }
                                    } else {
                                        $$.log('response.d: ' + response.d);
                                    }
                                },

                                error: function (error) {
                                    $$.log(error);
                                }
                            });

                            if (status === 'NEW' || status === 'ALL') {
                                setTimeout(function() {
                                    getNotifications('NEW');
                                }, n.queryInterval);
                            }
                        }

                        n.retrieveMoreNotifications = function(type, status) {
                            if (!n.getMoreNotifications(type, status)) {
                                getNotifications(status, n.notificationQueryLimit(), n.notificationFirstPage(), n.notificationLastPage());
                                n.notificationFirstPage(n.notificationLastPage());
                            }
                        };

                        getNotifications('ALL');
                    } catch(e) {
                        $$.log(e);
                    }
                }());
            }, !window.isIE8);
        }, !window.isIE8);
    }, !window.isIE8);
}

ExecuteOrDelayUntilScriptLoaded(initializeEPMLiveNotifications, 'EPMLive.js');