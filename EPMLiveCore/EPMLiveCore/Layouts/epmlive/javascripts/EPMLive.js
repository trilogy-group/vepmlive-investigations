(function ($$, $, k, undefined) {
    var scrollbarWidth = 0;

    $$.currentSiteId = null;
    $$.currentSiteUrl = null;
    $$.currentWebId = null;
    $$.currentWebUrl = null;
    $$.currentWebFullUrl = null;

    $$.ui = {
        statusbar: {
            collection: k.observableArray(),

            add: function (title, message, icon, align) {
                var theStatusbar = {
                    collection: k.observableArray(),
                    color: k.observable()
                };

                theStatusbar.cssClass = k.dependentObservable(function () {
                    return 'ms-status-' + this.color();
                }, theStatusbar);

                theStatusbar.append = function (title, message, icon, align) {
                    var status = {
                        title: k.observable(title),
                        message: k.observable(message),
                        icon: k.observable(icon),
                        align: k.observable(align || 'left')
                    };

                    this.collection.push(status);
                };

                theStatusbar.append(title, message, icon, align);

                theStatusbar.remove = function () {
                    $$.ui.statusbar.collection.remove(this);
                };

                this.collection.push(theStatusbar);
                return theStatusbar;
            }
        }
    };

    $$.utils = {
        isInt: function (value) {
            return /^\d+$/.test(value);
        },

        base64: {
            _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",

            encode: function (input) {
                var base64 = $$.utils.base64;

                var output = "";
                var chr1, chr2, chr3, enc1, enc2, enc3, enc4;
                var i = 0;

                input = base64._utf8_encode(input);

                while (i < input.length) {

                    chr1 = input.charCodeAt(i++);
                    chr2 = input.charCodeAt(i++);
                    chr3 = input.charCodeAt(i++);

                    enc1 = chr1 >> 2;
                    enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
                    enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
                    enc4 = chr3 & 63;

                    if (isNaN(chr2)) {
                        enc3 = enc4 = 64;
                    } else if (isNaN(chr3)) {
                        enc4 = 64;
                    }

                    output = output +
                        this._keyStr.charAt(enc1) + this._keyStr.charAt(enc2) +
                            this._keyStr.charAt(enc3) + this._keyStr.charAt(enc4);

                }

                return output;
            },

            decode: function (input) {
                var base64 = $$.utils.base64;

                var output = "";
                var chr1, chr2, chr3;
                var enc1, enc2, enc3, enc4;
                var i = 0;

                input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

                while (i < input.length) {

                    enc1 = this._keyStr.indexOf(input.charAt(i++));
                    enc2 = this._keyStr.indexOf(input.charAt(i++));
                    enc3 = this._keyStr.indexOf(input.charAt(i++));
                    enc4 = this._keyStr.indexOf(input.charAt(i++));

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

                }

                output = base64._utf8_decode(output);

                return output;

            },

            _utf8_encode: function (string) {
                string = string.replace(/\r\n/g, "\n");
                var utftext = "";

                for (var n = 0; n < string.length; n++) {

                    var c = string.charCodeAt(n);

                    if (c < 128) {
                        utftext += String.fromCharCode(c);
                    } else if ((c > 127) && (c < 2048)) {
                        utftext += String.fromCharCode((c >> 6) | 192);
                        utftext += String.fromCharCode((c & 63) | 128);
                    } else {
                        utftext += String.fromCharCode((c >> 12) | 224);
                        utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                        utftext += String.fromCharCode((c & 63) | 128);
                    }

                }

                return utftext;
            },

            _utf8_decode: function (utftext) {
                var string = "";
                var i = 0;
                var c = c1 = c2 = 0;

                while (i < utftext.length) {

                    c = utftext.charCodeAt(i);

                    if (c < 128) {
                        string += String.fromCharCode(c);
                        i++;
                    } else if ((c > 191) && (c < 224)) {
                        c2 = utftext.charCodeAt(i + 1);
                        string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
                        i += 2;
                    } else {
                        c2 = utftext.charCodeAt(i + 1);
                        c3 = utftext.charCodeAt(i + 2);
                        string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
                        i += 3;
                    }

                }

                return string;
            }
        },

        fireEvent: function (element, event) {
            if (document.createEventObject) {
                // dispatch for IE
                return element.fireEvent('on' + event, document.createEventObject());
            } else {
                // dispatch for firefox + others
                var evt = document.createEvent("HTMLEvents");
                evt.initEvent(event, true, true); // event type,bubbling,cancelable
                return !element.dispatchEvent(evt);
            }
        }
    };

    $$.getFormattedTime = function (dateTime) {
        var hours = dateTime.getHours();
        var minutes = dateTime.getMinutes();
        var ampm = null;

        if (minutes < 10) {
            minutes = '0' + minutes;
        }

        ampm = (hours < 12) ? 'AM' : 'PM';

        if (hours != 0) {
            hours = ((hours + 11) % 12) + 1;
        } else {
            hours = 12;
        }

        return hours + ':' + minutes + ' ' + ampm;
    };

    $$.getFriendlyDateTime = function (dateTime, dateTimeString) {
        var today = new Date();
        today.setHours(0, 0, 0, 0);

        var lastWeek = new Date();
        lastWeek.setHours(0, 0, 0, 0);
        lastWeek.setDate(today.getDate() - 7);

        function isDateTimeToday() {
            return today.getDate() === dateTime.getDate() && today.getMonth() === dateTime.getMonth() && today.getFullYear() === dateTime.getFullYear();
        }

        function getDateDayDiff(dt1, dt2) {
            var ndt1 = new Date(dt1.getFullYear(), dt1.getMonth(), dt1.getDate());
            var ndt2 = new Date(dt2.getFullYear(), dt2.getMonth(), dt2.getDate());

            return parseInt((ndt1.getTime() - ndt2.getTime()) / (1000 * 3600 * 24));
        }

        function isDateTimeYesterday() {
            if (today.getTime() - dateTime.getTime() > 0) {
                return getDateDayDiff(today, dateTime) === 1;
            }

            return false;
        }

        function isDateTimeWithinLastWeek() {
            if (today.getTime() - dateTime.getTime() > 0) {
                var dayDiff = getDateDayDiff(today, dateTime);

                return (dayDiff >= 0) && (dayDiff <= 7);
            }

            return false;
        }

        function getWeekDay(date) {
            var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];

            return days[date.getDay()];
        }

        function calcTime(baseDateTime, offset) {
            var utc = baseDateTime.getTime() + (baseDateTime.getTimezoneOffset() * 60000);

            return new Date(utc + (3600000 * offset));
        }

        function getLocalTimezone() {
            var d = new Date();
            return -d.getTimezoneOffset() / 60;
        }

        if (isDateTimeToday()) {
            return $.timeago(calcTime(dateTime, getLocalTimezone())) + ' at ' + $$.getFormattedTime(dateTime);
        } else if (isDateTimeYesterday()) {
            return 'Yesterday at ' + $$.getFormattedTime(dateTime);
        } else if (isDateTimeWithinLastWeek()) {
            return 'Last ' + getWeekDay(dateTime) + ' (' + dateTimeString + ') at ' + $$.getFormattedTime(dateTime);
        }
        else {
            return $.datepicker.formatDate('M d, yy', dateTime) + ' at ' + $$.getFormattedTime(dateTime);
        }
    };

    $$.isGuid = function (guid) {
        return /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/.test(guid);
    };

    $$.getScrollbarWidth = function () {
        if (!scrollbarWidth) {
            if ($.browser.msie) {
                var $textarea1 = $('<textarea cols="10" rows="2"></textarea>')
                    .css({ position: 'absolute', top: -1000, left: -1000 }).appendTo('body'),
                    $textarea2 = $('<textarea cols="10" rows="2" style="overflow: hidden;"></textarea>')
                        .css({ position: 'absolute', top: -1000, left: -1000 }).appendTo('body');
                scrollbarWidth = $textarea1.width() - $textarea2.width();
                $textarea1.add($textarea2).remove();
            } else {
                var $div = $('<div />')
                    .css({ width: 100, height: 100, overflow: 'auto', position: 'absolute', top: -1000, left: -1000 })
                    .prependTo('body').append('<div />').find('div')
                    .css({ width: '100%', height: 200 });
                scrollbarWidth = 100 - $div.width();
                $div.parent().remove();
            }
        }
        return scrollbarWidth;
    };

    $$.getUrlParamByName = function (name) {
        name = name.replace(/[\[]/, '\\\[').replace(/[\]]/, '\\\]');
        var regexS = '[\\?&]' + name + '=([^&#]*)';
        var regex = new RegExp(regexS);
        var results = regex.exec(window.location.href);
        if (results == null) {
            return '';
        } else {
            return decodeURIComponent(results[1].replace(/\+/g, ' '));
        }
    };

    $$.log = function (message) {
        if ($$.getUrlParamByName('epmdebug') == 'true') {
            console.log('[EPMLive] ' + message);
        }
    };

    $$.parseJson = function (xml) {
        return eval('(' + window.xml2json($.parseXML(xml), "") + ')');
    };

    $$.responseIsSuccess = function (result) {
        return result['@Status'] == 0;
    };

    $$.logFailure = function (result) {
        $$.log('ERROR: ' + result.Error['@ID'] + '. ' + result.Error['#text']);
    };

    $$.md5 = function (data) {
        return window.MD5(data).toUpperCase();
    };

    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined' ? args[number] : match;
        });
    };

    k.bindingHandlers.slideUpDown = {
        update: function (element, valueAccessor, allBindingsAccessor) {
            var value = valueAccessor(), allBindings = allBindingsAccessor();
            var valueUnwrapped = k.utils.unwrapObservable(value);
            var duration = allBindings.slideDuration || 600;

            if (valueUnwrapped) {
                $(element).slideDown(duration);
            } else {
                $(element).slideUp(duration);
            }
        }
    };

    k.bindingHandlers.src = {
        update: function (element, valueAccessor, allBindingsAccessor) {
            var ele = $(element);
            $(ele).hide();

            var value = valueAccessor(), allBindings = allBindingsAccessor();
            var valueUnwrapped = k.utils.unwrapObservable(value);
            var alignmiddle = allBindings.alignmiddle || false;
            var maxDimension = allBindings.maxDimension || 45;

            if (alignmiddle) {
                ele.load(function () {
                    var originalHeight = this.height;
                    var originalWidth = this.width;

                    $(this).parent().height(maxDimension);
                    $(this).parent().width(maxDimension);

                    var newWidth = maxDimension;
                    var newHeight = (originalHeight * newWidth) / originalWidth;

                    if (maxDimension < newHeight) {
                        newHeight = maxDimension;
                        newWidth = (newHeight * originalWidth) / originalHeight;
                    }

                    $(this).width(newWidth);
                    $(this).height(newHeight);

                    $(this).css('top', (maxDimension - newHeight) / 2);
                    $(this).css('left', (maxDimension - newWidth) / 2);

                    $(this).show();
                });
            }

            ele.attr('src', valueUnwrapped);

            if (!alignmiddle) {
                $(ele).show();
            }
        }
    };

    k.applyBindings($$.ui.statusbar, document.getElementById('EPMLiveStatusbar'));
}(window.epmLive = window.epmLive || {}, jQuery, ko));

function CreateEPMLiveWorkspace(listid, itemid) {
    if (listid)
        var layoutsUrl = SP.Utilities.Utility.getLayoutsPageUrl('EPMLive/QueueCreateWorkspace.aspx?listid=' + listid + '&itemid=' + itemid);
    else
        var layoutsUrl = SP.Utilities.Utility.getLayoutsPageUrl('EPMLive/QueueCreateWorkspace.aspx');

    var urlBuilder = new SP.Utilities.UrlBuilder(layoutsUrl);
    var tUrl = urlBuilder.get_url();

    var options = {
        url: tUrl,
        title: 'Create',
        width: 880,
        height: 500,
        dialogReturnValueCallback: function (dialogResult, returnValue) {
            if (dialogResult === 1) {
                //SP.UI.Notify.addNotification('Your workspace is being created - we will notify you when it is ready.', false);
                $.pnotify({
                    title: 'Workspace Status',
                    text: 'Your workspace is being created - we will notify you when it is ready.',
                    type: 'success'
                });
            }
            else if (dialogResult === -1) {
                $.pnotify({
                    title: 'Workspace Status',
                    text: 'Something went wrong. Workspace is not being created. Error: ' + returnValue,
                    type: 'error'
                });
            }
        }

    };

    SP.UI.ModalDialog.showModalDialog(options);
}
