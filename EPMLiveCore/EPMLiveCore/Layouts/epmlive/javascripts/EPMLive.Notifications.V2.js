(function () {
    function executeEpmLiveNotifications() {
        (function (epmLiveNotifications, $$, $, k, undefined) {
            var notificationsTimeout = null;

            epmLiveNotifications.notifications = k.observableArray();
            epmLiveNotifications.invisibleNotifications = k.observableArray();
            epmLiveNotifications.totalNewNotifications = k.observable(0);
            epmLiveNotifications.activeNotification = k.observable(null);
            epmLiveNotifications.updatedNotifications = [];
            epmLiveNotifications.activeView = k.observable('notification');
            epmLiveNotifications.showNotifications = k.observable(false);

            epmLiveNotifications.firstTimeLoad = true;
            epmLiveNotifications.lastTimestamp = 0;
            epmLiveNotifications.notificationDisplayLimit = 3;
            epmLiveNotifications.notificationQueryLimit = k.dependentObservable(function () {
                return epmLiveNotifications.notificationDisplayLimit * 5;
            }, epmLiveNotifications);

            epmLiveNotifications.notificationFirstPage = k.observable(0);
            epmLiveNotifications.notificationLastPage = k.dependentObservable(function () {
                return epmLiveNotifications.notificationFirstPage() + epmLiveNotifications.notificationQueryLimit();
            }, epmLiveNotifications);

            function getNotifications(notificationType, notificationStatus) {
                var notificationCollection = [];

                var read = notificationStatus === 'old';

                for (var i = 0; i < epmLiveNotifications.notifications().length; i++) {
                    var notification = epmLiveNotifications.notifications()[i];

                    if (notification.notificationread() === read) {
                        if (notificationType === 'system') {
                            if (notification.type() === 0 || notification.type() === 1) {
                                notificationCollection.push(notification);
                            }
                        } else {
                            if (notification.type() > 1) {
                                notificationCollection.push(notification);
                            }
                        }
                    }
                }

                return notificationCollection;
            }

            function getNotificationById(notificationId) {
                for (var i = 0; i < epmLiveNotifications.notifications().length; i++) {
                    var notification = epmLiveNotifications.notifications()[i];

                    if (notification.id() === notificationId) {
                        return notification;
                    }
                }
                return null;
            }

            function getInvisibleNotifications(notificationType, notificationStatus) {
                var notificationCollection = [];

                var read = notificationStatus === 'old';

                for (var i = 0; i < epmLiveNotifications.invisibleNotifications().length; i++) {
                    var notification = epmLiveNotifications.invisibleNotifications()[i];

                    if (notification.notificationread() === read) {
                        if (notificationType === 'system') {
                            if (notification.type() === 0 || notification.type() === 1) {
                                notificationCollection.push(notification);
                            }
                        } else {
                            if (notification.type() > 1) {
                                notificationCollection.push(notification);
                            }
                        }
                    }
                }

                return notificationCollection;
            };

            function notificationsAreVisible() {
                return epmLiveNotifications.showNotifications();
            };

            function doFlash() {
                var counter = $("#EPMLiveNotificationCounter");
                $(counter).fadeTo(400, 0.25, function () {
                    $(counter).fadeTo(400, 1);
                });
            };

            function configureScrollbar() {
                $("#EPMLiveNotificationsWrap").height(0);

                var slimScrollDiv = $("#EPMLiveNotificationGeneral").parent()[0];
                if (slimScrollDiv.className !== 'slimScrollDiv') {
                    $("#EPMLiveNotificationGeneral").slimScroll({ height: epmLiveNotifications.generalNotificationHeight() });
                } else {
                    $(slimScrollDiv).height(epmLiveNotifications.generalNotificationHeight());
                    $("#EPMLiveNotificationGeneral").height(epmLiveNotifications.generalNotificationHeight());
                }

                $("#EPMLiveNotificationsWrap").css("height", "auto");

                $("#EPMLiveNotificationGeneral").endlessScroll({
                    callback: function () {
                        epmLiveNotifications.retrieveMoreNotifications('GENERAL', 'OLD');
                    }
                });
            }

            epmLiveNotifications.postNotificationMessageDisplay = function (elements) {
                var height = 500;
                var offset = 3;

                if ($.browser.msie) {
                    offset = 2;
                }

                var element = elements[offset];

                if (element) {
                    if ($(element).height() >= height) {
                        var slimScrollDiv = $(element).parent()[0];

                        if (slimScrollDiv.className !== 'slimScrollDiv') {
                            $(element).slimScroll({ height: height });
                        } else {
                            $(slimScrollDiv).height(height);
                            $(element).height(height);
                        }
                    }
                }
            },

            epmLiveNotifications.newSystemNotifications = k.dependentObservable(function () {
                return getNotifications('system', 'new');
            }, epmLiveNotifications);

            epmLiveNotifications.oldSystemNotifications = k.dependentObservable(function () {
                return getNotifications('system', 'old');
            }, epmLiveNotifications);

            epmLiveNotifications.newGeneralNotifications = k.dependentObservable(function () {
                return getNotifications('general', 'new');
            }, epmLiveNotifications);

            epmLiveNotifications.oldGeneralNotifications = k.dependentObservable(function () {
                return getNotifications('general', 'old');
            }, epmLiveNotifications);

            epmLiveNotifications.totalSystemNotifications = k.dependentObservable(function () {
                return epmLiveNotifications.newSystemNotifications().length + epmLiveNotifications.oldSystemNotifications().length;
            }, epmLiveNotifications);

            epmLiveNotifications.totalGeneralNotifications = k.dependentObservable(function () {
                return epmLiveNotifications.newGeneralNotifications().length + epmLiveNotifications.oldGeneralNotifications().length;
            }, epmLiveNotifications);

            epmLiveNotifications.notificationCounterColor = k.dependentObservable(function () {
                if (!notificationsAreVisible()) {
                    if (this.newSystemNotifications().length > 0) {
                        return '#89CE00';
                    } else if (this.newGeneralNotifications().length > 0) {
                        return '#26C6F4';
                    } else {
                        return '#666666';
                    }
                }

                return '#D0D0D0';
            }, epmLiveNotifications);

            epmLiveNotifications.notificationCounterFontWeight = k.dependentObservable(function () {
                if (this.totalNewNotifications() > 0) {
                    return 'bold';
                } else {
                    return '';
                }
            }, epmLiveNotifications);

            epmLiveNotifications.generalNotificationHeight = k.dependentObservable(function () {
                var height = 600;
                var headerHeight = 60;

                var totalGeneralNotifications = epmLiveNotifications.totalGeneralNotifications();
                var totalSystemNotifications = epmLiveNotifications.totalSystemNotifications();

                if (totalSystemNotifications > 0) {
                    height = height - headerHeight - (totalSystemNotifications * 55);
                }

                height = height - headerHeight;

                var generalNotificationHeight = totalGeneralNotifications * 55;
                return (generalNotificationHeight < height ? generalNotificationHeight : height) + 'px';
            }, epmLiveNotifications);

            epmLiveNotifications.getMoreNotifications = function (type, status) {
                type = type.toLowerCase();
                status = status.toLowerCase();

                var notifications = getInvisibleNotifications(type, status);

                for (var i = 0; i < epmLiveNotifications.notificationDisplayLimit; i++) {
                    var notification = notifications[i];

                    if (notification) {
                        epmLiveNotifications.notifications.push(notification);
                        epmLiveNotifications.invisibleNotifications.remove(notification);
                    }
                }

                if (getInvisibleNotifications(type, status).length >= epmLiveNotifications.notificationDisplayLimit) {
                    return true;
                }

                return false;
            };

            epmLiveNotifications.notifications.exists = function (notification) {
                for (var i = 0; i < this().length; i++) {
                    if (this()[i].id() === notification.id()) {
                        return true;
                    }
                }

                return false;
            };

            epmLiveNotifications.invisibleNotifications.exists = function (notification) {
                for (var i = 0; i < this().length; i++) {
                    if (this()[i].id() === notification.id()) {
                        return true;
                    }
                }

                return false;
            };

            epmLiveNotifications.registerNotification = function (notification) {
                var visible = false;

                if (!notification.notificationread()) {
                    visible = true;
                } else {
                    if (notification.type() > 1) {
                        visible = false;
                    } else {
                        visible = true;
                    }
                }

                if (!epmLiveNotifications.notifications.exists(notification) && !epmLiveNotifications.invisibleNotifications.exists(notification)) {
                    if (visible) {
                        epmLiveNotifications.notifications.unshift(notification);
                        if (!notification.notificationread()) {
                            epmLiveNotifications.totalNewNotifications(parseInt(epmLiveNotifications.totalNewNotifications()) + 1);
                            if (!epmLiveNotifications.firstTimeLoad) {
                                doFlash();
                            }
                            
                            if (notification.type() === 6) {
                                window.epmLiveNavigation.registerLink({ kind: 3 });
                            }
                        }
                    } else {
                        epmLiveNotifications.invisibleNotifications.unshift(notification);
                    }
                }
            };

            epmLiveNotifications.messageTypeImage = function (messageType) {
                var messageTypeImage = epmLiveNotifications.messageTypeImageCollection[messageType];

                if (messageTypeImage) {
                    return 'url(\'' + $$.currentWebFullUrl + '/_layouts/epmlive/images/notification-icons/' + messageTypeImage + '.png' + '\') no-repeat scroll center center';
                }

                return null;
            };

            epmLiveNotifications.postMessageInfoRender = function (elements) {
                $(elements[3]).click(function (event) {
                    event.stopPropagation();
                });
            };

            epmLiveNotifications.updateNotifications = function () {
                if (epmLiveNotifications.updatedNotifications.length > 0) {
                    for (var j = 0; j < epmLiveNotifications.updatedNotifications.length; j++) {
                        getNotificationById(epmLiveNotifications.updatedNotifications[j]).notificationread(true);
                    }

                    epmLiveNotifications.updatedNotifications = [];
                }

                epmLiveNotifications.totalNewNotifications(0);
            };

            epmLiveNotifications.markMessagesAsRead = function () {
                var dataXml = '<Notifications MarkAllRead="true"><Notification ID="" Type="0"><Flag Type="READ" Value="true"/></Notification>';

                var i, notification, updatedNotifications = [];

                var newSystemNotifications = epmLiveNotifications.newSystemNotifications();
                for (i = 0; i < newSystemNotifications.length; i++) {
                    notification = newSystemNotifications[i];
                    dataXml += '<Notification ID="' + notification.id() + '" Type="' + notification.type() + '"><Flag Type="READ" Value="true"/></Notification>';

                    updatedNotifications.push(notification.id());
                }

                var newGeneralNotifications = epmLiveNotifications.newGeneralNotifications();
                for (i = 0; i < newGeneralNotifications.length; i++) {
                    notification = newGeneralNotifications[i];
                    dataXml += '<Notification ID="' + notification.id() + '" Type="' + notification.type() + '"><Flag Type="READ" Value="true"/></Notification>';

                    updatedNotifications.push(notification.id());
                }

                dataXml += '</Notifications>';

                $.ajax({
                    type: 'POST',
                    url: $$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'SetNotificationFlags', Dataxml: '" + dataXml + "' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$.parseJson(response.d);

                            if ($$.responseIsSuccess(responseJson.Result)) {
                                epmLiveNotifications.updatedNotifications = updatedNotifications;
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
            };

            epmLiveNotifications.viewMessage = function (notificationId) {
                for (var i = 0; i < epmLiveNotifications.notifications().length; i++) {
                    var notification = epmLiveNotifications.notifications()[i];

                    if (notification.id() === notificationId) {
                        epmLiveNotifications.activeNotification(notification);
                        epmLiveNotifications.activeView('message');

                        configureScrollbar();
                        break;
                    }
                }
            };

            epmLiveNotifications.viewNotifications = function () {
                epmLiveNotifications.activeView('notification');
                configureScrollbar();
            };

            function hideNotifications(counter) {
                if (notificationsAreVisible()) {
                    var notificationCounter = counter || $("#EPMLiveNotificationCounter");

                    epmLiveNotifications.showNotifications(false);
                    epmLiveNotifications.updateNotifications();
                    epmLiveNotifications.activeView('notification');

                    notificationCounter.css("background", "#666666");
                    notificationCounter.css("color", "#fff");
                    notificationCounter.css("font-weight", epmLiveNotifications.notificationCounterFontWeight());
                }
            }

            function initializeNotifications() {
                var notifications = $("#EPMLiveNotificationsWrap");

                if (notifications) {
                    clearInterval(notificationsTimeout);

                    notifications.remove();
                    $("body").append(notifications);

                    notifications.css("right", $$.getScrollbarWidth() + 5);

                    $("html").click(function () {
                        hideNotifications();
                    });

                    $("#EPMLiveNotificationsWrap").click(function (event) {
                        event.stopPropagation();
                    });

                    $("#EPMLiveNotificationCounter").click(function (event) {
                        event.stopPropagation();
                    });

                    $("#EPMLiveNotificationCounterProfilePic").click(function (event) {
                        event.stopPropagation();
                    });
                } else {
                    notificationsTimeout = setTimeout(initializeNotifications, 1);
                }
            }

            function renderNotificationCounter() {
                var notificationCounter = $("#EPMLiveNotificationCounter");

                var toggleNotifications = function () {
                    if (!notificationsAreVisible()) {
                        notificationCounter.css("background", "#D0D0D0");
                        notificationCounter.css("color", "#000");
                        notificationCounter.css("font-weight", "");

                        epmLiveNotifications.showNotifications(true);

                        configureScrollbar();

                        if (epmLiveNotifications.totalNewNotifications() > 0) {
                            epmLiveNotifications.markMessagesAsRead();
                        }

                        window.setTimeout(function () { $("#EPMLiveNotificationsWrap").show(); }, 1);
                    } else {
                        hideNotifications(notificationCounter);
                    }
                };

                notificationCounter.click(function () {
                    toggleNotifications();
                });

                $('#EPMLiveNotificationCounterProfilePic').click(function () {
                    toggleNotifications();
                });

                notificationsTimeout = setTimeout(initializeNotifications, 1);
            }

            epmLiveNotifications.init = function () {
                renderNotificationCounter();
            };
        }(window.epmLiveNotifications = window.epmLiveNotifications || {}, epmLive, window.jQuery, ko));
    }

    ExecuteOrDelayUntilScriptLoaded(executeEpmLiveNotifications, 'EPMLive.js');
})();