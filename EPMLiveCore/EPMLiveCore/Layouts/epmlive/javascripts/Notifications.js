/// <version>4.3.7192012</version>
/// <reference path="EPMLive.Notifications.js" />
/// <reference path="libraries/knockout-1.2.1.debug.js" />
/// <reference path="libraries/jquery.endless-scroll.js" />
/// <reference path="EPMLive.js" />

function initializeEPMLiveNotifications() {
    $.getScript('/_layouts/epmlive/javascripts/libraries/jquery.timeago.js', function () {
        $.getScript('/_layouts/epmlive/javascripts/libraries/jquery.endless-scroll.js', function () {
            $.getScript('/_layouts/epmlive/javascripts/libraries/slimScroll.js', function () {
                $.getScript('/_layouts/epmlive/javascripts/EPMLive.Notifications.js', function () {
                    (function () {
                        var $ = window.jQuery;
                        var $$ = window.epmLive;
                        var console;

                        var firstLoad = true;

                        try {
                            console = window.console;
                        } catch (e) {
                            if (!window.console) console = { log: function () { } };
                        }

                        try {
                            var oldNotificationsLoaded = false;

                            var n = window.epmLiveNotifications;

                            n.messageTypeImageCollection = {
                                0: 'system',
                                1: 'system',
                                3: 'comment',
                                4: 'assigned-to',
                                5: 'pending-project-update'
                            };

                            n.queryInterval = 30000;

                            n.init();

                            ko.applyBindings(n, document.getElementById('EPMLiveNotificationsWrap'));
                            ko.applyBindings(n, document.getElementById('EPMLiveNotificationCounter'));
                            ko.applyBindings(n, document.getElementById('EPMLiveNotificationCount'));

                            function updateNotifications(result) {
                                if (!result) return;

                                var notifications;

                                if (!result.length) {
                                    notifications = [result];
                                } else {
                                    notifications = result;
                                }

                                for (var i = 0; i < notifications.length; i++) {
                                    var nf = notifications[i];

                                    var notification = {};

                                    for (var no in nf) {
                                        if (nf.hasOwnProperty(no)) {
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
                                        }
                                    }

                                    n.registerNotification(notification);
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
                                                    updateNotifications(responseJson.Result.Notifications.Notification);

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

                                //                                if (status === 'NEW' || status === 'ALL') {
                                //                                    setTimeout(function () {
                                //                                        getNotifications('NEW');
                                //                                    }, n.queryInterval);
                                //                                }
                            }

                            function configureScrollbar(type) {
                                $("#EPMLiveNotificationGeneral").endlessScroll({
                                    callback: function () {
                                        n.retrieveMoreNotifications(type, 'OLD');
                                    }
                                });
                            }

                            n.retrieveMoreNotifications = function (type, status) {
                                if (!n.getMoreNotifications(type, status)) {
                                    getNotifications(status, n.notificationQueryLimit(), n.notificationFirstPage(), n.notificationLastPage());
                                    if (n.getMoreNotifications(type, status)) {
                                        n.notificationFirstPage(n.notificationLastPage() + 1);

                                        configureScrollbar(type);
                                    }
                                } else {
                                    configureScrollbar(type);
                                }
                            };

                            getNotifications('ALL');
                        } catch (e) {
                            $$.log(e);
                        }
                    } ());
                }, true);
            }, true);
        }, true);
    }, true);
}

ExecuteOrDelayUntilScriptLoaded(initializeEPMLiveNotifications, 'EPMLive.js');