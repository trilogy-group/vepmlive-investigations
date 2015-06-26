(function ($$, $, k, undefined) {
    var scrollbarWidth = 0;

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
        title: 'Create Workspace',
        dialogReturnValueCallback: function (dialogResult, returnValue) {
            if (dialogResult === 1) {

                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "positionClass": "toast-top-right",
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };

                toastr.info("Your workspace is being created - we will notify you when it is ready.");
            }
            else if (dialogResult === -1) {

                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "positionClass": "toast-top-right",
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };

                toastr.error('Something went wrong. Workspace is not being created. Error: ' + returnValue);
            }
        }

    };

    SP.UI.ModalDialog.showModalDialog(options);
}

function OpenIntegrationPage(controlFull, listid, itemid) {

    var t = controlFull.indexOf(".");
    var control = controlFull.substr(0, t);
    var windowtype = controlFull.substr(t + 1);

    var layoutsUrl = SP.Utilities.Utility.getLayoutsPageUrl('EPMLive/integration/gotoremote.aspx?control=' + control + '&listid=' + listid + '&itemid=' + itemid);

    var urlBuilder = new SP.Utilities.UrlBuilder(layoutsUrl);
    var tUrl = urlBuilder.get_url();


    if (windowtype == 1) {
        window.open(tUrl, '', config = 'width=' + screen.width + ',height=' + screen.height + ',top=0,left=0,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, directories=no, status=yes');
    }
    else if (windowtype == 2) {
        var options = {
            url: tUrl,
            showMaximized: true,
            title: '',

            dialogReturnValueCallback: function (dialogResult, returnValue) {

            }
        };

        SP.UI.ModalDialog.showModalDialog(options);
    }
    else if (windowtype == 3) {
        var options = {
            url: tUrl,
            title: '',
            width: 600,
            dialogReturnValueCallback: function (dialogResult, returnValue) {

            }
        };

        SP.UI.ModalDialog.showModalDialog(options);
    }
    else if (windowtype == 4) {
        var layoutsUrl = SP.Utilities.Utility.getLayoutsPageUrl('EPMLive/integration/gotoremoteframe.aspx?control=' + control + '&listid=' + listid + '&itemid=' + itemid);

        var urlBuilder = new SP.Utilities.UrlBuilder(layoutsUrl);
        var tUrl = urlBuilder.get_url();

        location.href = tUrl;
    }


}

(function (epmToolBar, $) {
    epmToolBar.generateToolBar = function (tagId, cfgs) {

        if ($('#contentRow').length > 0) {
            $('#contentRow').css('padding-top', '0');
        }

        $(document).click(function (e) {
            //if (e.target.parentElement.id != "toolbar-search-icon") {
            // $('.toolbar-search').css("margin-left", "0px");
            // }

            if (clickedOutsideElementClass('dropdown-menu', e) && clickedOutsideElementClass('dropdown', e)) {
                $('.dropdown-menu').css('display', 'none');
            }
        });

        //set properties
        var ulIds = {};
        var multiSelectStorage = {};
        var anchorTagId = tagId;
        var mainActionBar = $(document.createElement('div'));
        var mainBarId = cfgs[0]['id'];

        mainActionBar.attr('id', mainBarId);
        mainActionBar.addClass('epmliveToolBar');
        mainActionBar.attr('border-bottom', "1px solid #eeeeee");

        for (var index in cfgs) {

            var blockContents = cfgs[index];
            if (blockContents["placement"] == "left") {
                buildLeftBlockHTML(mainActionBar, blockContents);
            }
            else if (blockContents["placement"] == "right") {
                buildRightBlockHTML(mainActionBar, blockContents);
            }
        }

        $('#' + anchorTagId).append(mainActionBar);

        $('.epmliveToolBar a[data-toggle=tooltip]').tooltip();

        function buildLeftBlockHTML(mainActionBar, blockContents) {
            var mainActionBar_LeftUl = $(document.createElement('ul'));
            mainActionBar_LeftUl.addClass('nav navbar-nav');
            var contents = blockContents["content"];
            for (var i in contents) {

                var cfg = contents[i];
                var cType = cfg['controlType'];

                switch (cType) {
                    case "button":
                        createButton(cfg, mainActionBar_LeftUl);
                        break;
                    case "dropdown":
                        createDropDown(cfg, mainActionBar_LeftUl);
                        break;
                    default:
                        break;
                }
            }
            mainActionBar.append(mainActionBar_LeftUl);
        }

        function buildRightBlockHTML(mainActionBar, blockContents) {
            var mainActionBar_RightUl = $(document.createElement('ul'));
            mainActionBar_RightUl.addClass('nav navbar-nav navbar-right');
            var contents = blockContents["content"];

            for (var i in contents) {

                var cfg = contents[i];
                var cType = cfg['controlType'];

                switch (cType) {
                    case "button":
                        createButton(cfg, mainActionBar_RightUl);
                        break;
                    case "dropdown":
                        createDropDown(cfg, mainActionBar_RightUl);
                        break;
                    case "multiselect":
                        createMultiSelect(cfg, mainActionBar_RightUl);
                        break;
                    case "groupByFields":
                        createGroupBy(cfg, mainActionBar_RightUl);
                        break;
                    case "search":
                        createSearch(cfg, mainActionBar_RightUl);
                    default:
                        break;
                }
            }

            mainActionBar.append(mainActionBar_RightUl);
        }

        function createButton(cfg, ul) {
            // get props
            var iconClass = cfg['iconClass'];
            var title = cfg['title'];
            var value = cfg['value'];
            var toolTip = cfg['toolTip'];
            var events = cfg['events'];

            var li = $(document.createElement('li'));

            if (toolTip) {
                li.attr('title', toolTip);
            }
            else if (title) {
                li.attr('title', title);
            }

            var aContainer = $(document.createElement('a'));
            aContainer.attr('class', 'dropdown-toggle');
            if ((title == undefined || title.toLowerCase() == 'none') &&
                (value == undefined)) {
                aContainer.addClass('nav-icon');
            }
            else {
                aContainer.addClass('nav-icon-title');
            }
            aContainer.attr('href', 'javascript:void(0)');

            if (toolTip) {
                aContainer.attr('data-toggle', 'tooltip');
                aContainer.attr('data-placement', 'top');
                aContainer.attr('data-delay', '200');
                aContainer.attr('data-container', 'body');
                aContainer.attr('title', toolTip);
            }

            if (iconClass &&
                (iconClass != 'none')) {
                var spnImg = $(document.createElement('span'));
                spnImg.attr('class', iconClass);
                aContainer.append(spnImg);
            }

            if (title &&
                (title.toLowerCase() != 'none')) {
                var spnLbl = $(document.createElement('span'));
                spnLbl.addClass('dropdown-label');
                spnLbl.text(title);
                aContainer.append(spnLbl);
            }

            if (value &&
                (value != 'none')) {
                var spnLbl = $(document.createElement('span'));
                spnLbl.text(value);
                aContainer.append(spnLbl);
            }

            li.append(aContainer);

            if (events) {
                attachEvents(aContainer, cfg['events']);
            }

            ul.append(li);
        }

        function createDropDown(cfg, ul) {
            //get properties
            var controlId = cfg['controlId'];
            var title = cfg['title'];
            var iconClass = cfg['iconClass'];
            var toolTip = cfg['toolTip'];
            var value = cfg['value'];


            var li = $(document.createElement('li'));
            if (toolTip) {
                li.attr('title', toolTip);
            }
            else if (title) {
                li.attr('title', title);
            }
            //create anchor
            var aContainer = $(document.createElement('a'));
            aContainer.attr('class', 'dropdown-toggle');
            aContainer.attr('href', 'javascript:void(0)');
            aContainer.attr('controlId', controlId);

            if (toolTip) {
                aContainer.attr('data-toggle', 'tooltip');
                aContainer.attr('data-placement', 'top');
                aContainer.attr('data-container', 'body');
                aContainer.attr('data-delay', '200');
                aContainer.attr('title', toolTip);
            }

            //create span image
            if (iconClass &&
                (iconClass != 'none')) {
                var spnImg = $(document.createElement('span'));
                spnImg.attr('class', iconClass);
                aContainer.append(spnImg);
                aContainer.addClass('nav-icon-title');
            }
            //create span label for text
            if (title &&
                (title.toLowerCase() != 'none')) {
                var spnTitle = $(document.createElement('span'));
                spnTitle.text(title);
                spnTitle.addClass('dropdown-label');
                aContainer.append(spnTitle);
            }
            //create span lable for value
            if (value &&
                (value != 'none')) {
                var spnValue = $(document.createElement('span'));
                spnValue.text(value);
                aContainer.append(spnValue);
            }

            //create caret
            if ((iconClass && (iconClass != 'none')) ||
                (title && (title.toLowerCase() != 'none')) ||
                (value && (value != 'none'))) {

                var spnCaret = $(document.createElement('b'));
                spnCaret.attr('class', 'caret');
                aContainer.append(spnCaret);
            }

            //bind anchor click event to open menu
            aContainer.bind('click', function () {
                $('.dropdown-menu').css('display', 'none');
                $('#' + getUlId($(this).attr('controlId'))).toggle();
            });

            li.append(aContainer);

            var genericUl = $(document.createElement('ul'));
            genericUl.attr('id', getUlId(controlId));
            genericUl.addClass('dropdown-menu');

            for (var i in cfg['sections']) {
                var sect = cfg['sections'][i];
                //add section heading
                var sHeading = sect['heading'];
                if (sHeading &&
                    (sHeading.toLowerCase() != 'none')) {
                    var liHeading = $(document.createElement('li'));
                    liHeading.attr('class', 'dropdown-header');
                    liHeading.text(sHeading);
                    genericUl.append(liHeading);
                }
                //add section divider
                var sDivider = sect['divider'];
                if (sDivider &&
                    sDivider.toLowerCase() != 'no' &&
                    sDivider.toLowerCase() != 'none') {
                    var liDivider = $(document.createElement('li'));
                    liDivider.attr('class', 'divider');
                    genericUl.append(liDivider);
                }
                //add each section
                for (var j in sect['options']) {
                    var option = sect['options'][j];
                    var liOpt = $(document.createElement('li'));
                    var aContainer = $(document.createElement('a'));
                    aContainer.attr('href', 'javascript:void(0)');
                    var optIconClass = option['iconClass'];
                    var optText = option['text'];
                    var optEvt = option['events'];
                    var optProps = option['properties'];

                    if (optIconClass) {
                        var spnImg = $(document.createElement('span'));
                        spnImg.attr('class', option['iconClass']);
                        aContainer.append(spnImg);
                    }

                    if (optText) {
                        var spnLbl = $(document.createElement('span'));
                        spnLbl.text(option['text']);
                        aContainer.append(spnLbl);
                    }

                    if (optEvt) {
                        attachEvents(aContainer, option['events']);
                    }

                    if (optProps) {
                        attachProps(aContainer, option['properties']);
                    }

                    liOpt.append(aContainer);
                    genericUl.append(liOpt);
                }
            }

            li.append(genericUl);
            ul.append(li);
        }

        //START RIGHT SIDE TOOL BAR METHODS
        function createSearch(cfg, ul) {

            var toolTip = cfg['toolTip'];
            var li = $(document.createElement('li'));
            li.attr('title', 'Search');
            var isCustom = (cfg['custom'].toLowerCase() == 'yes');

            if (isCustom) {
                var customCtrlId = cfg['controlId'];
                li.append($('#' + customCtrlId));
            }
            else {

                var input = $(document.createElement('input'));
                input.attr('class', 'toolbar-search');
                input.attr('type', 'text');
                input.attr('placeholder', 'Search');
                input.attr('style', 'margin-left: 0px;');
                input.attr('id', 'toolBarResGridSelector');
                attachEvents(input, cfg['events']);

                input.autocomplete({
                    source: function (request, response) {
                        var results = $.ui.autocomplete.filter(window.epmLiveResourceGrid.actions.myResourcesOn ? window.epmLiveResourceGrid.myResources : window.epmLiveResourceGrid.resources, request.term);

                        response(results);
                    },

                    select: function (event, ui) {
                        var grid = window.Grids[window.epmLive.resourceGridId];
                        var rowId = window.epmLiveResourceGrid.resourceDictionary[ui.item.value];
                        if (rowId) {
                            var theRow = grid.Rows[rowId];

                            grid.ExpandParents(theRow);

                            grid.ActionClearSelection();
                            grid.SelectRow(theRow, true);
                            grid.SetScrollTop(grid.GetRowTop(theRow));
                        }

                        window.epmLiveResourceGrid.actions.toggleEasyScroll();

                        window.setTimeout(function () { window.RefreshCommandUI(); }, 100);
                    }
                });
                li.append(input);

                var aContainer = $(document.createElement('a'));
                aContainer.attr('id', 'toolbar-search-icon');
                aContainer.attr('class', 'nav-icon');
                aContainer.attr('style', 'font-size:.9em;');
                aContainer.attr('href', 'javascript:void(0)');

                if (toolTip) {
                    aContainer.attr('data-toggle', 'tooltip');
                    aContainer.attr('data-placement', 'top');
                    aContainer.attr('data-container', 'body');
                    aContainer.attr('data-delay', '200');
                    aContainer.attr('title', toolTip);
                }

                aContainer.click(function () {
                    if ($(".toolbar-search").css("margin-left") == "0px") {
                        $(".toolbar-search").css("margin-left", "-160px");
                        $(".toolbar-search").focus();
                        $(".toolbar-search").val('');
                    }
                    else {
                        $(".toolbar-search").css("margin-left", "0px");
                        $(".toolbar-search").val('');
                    }
                });
                var spnImg = $(document.createElement('span'));
                spnImg.attr('class', 'icon-search-3');
                aContainer.append(spnImg);
                li.append(aContainer);
            }
            ul.append(li);
        }

        function createGroupBy(cfg, ul) {
            var toolTip = cfg['toolTip'];
            var li = $(document.createElement('li'));
            li.attr('class', 'dropdown');
            li.attr('title', 'Group by');

            var aContainer = $(document.createElement('a'));
            aContainer.attr('id', 'group-dropdown');
            aContainer.attr('class', 'dropdown-toggle nav-icon');
            aContainer.attr('href', 'javascript:void(0)');
            if (toolTip) {
                aContainer.attr('data-toggle', 'tooltip');
                aContainer.attr('data-placement', 'top');
                aContainer.attr('data-container', 'body');
                aContainer.attr('data-delay', '200');
                aContainer.attr('title', toolTip);
            }
            var spnImg = $(document.createElement('span'));
            spnImg.attr('class', 'icon-list-3');
            aContainer.append(spnImg);
            aContainer.bind('click', function () {
                $('.dropdown-menu').css('display', 'none');
                divContainer.toggle();
                //EPML-5286 -- Here, when page load then fetch selected value and hide from other ddl
                var keyVals = [];
                keyVals = ddlselectedoption();
                if (keyVals.length > 0) {
                    HideOptionValue(keyVals);
                }
                // //-----
            });

            li.append(aContainer);

            var divContainer = $(document.createElement('div'));
            divContainer.attr('class', 'dropdown-menu no-close grouping-dropdown-menu');
            var groupbyUl = $(document.createElement('ul'));
            var groupbyLiHeader = $(document.createElement('li'));
            groupbyLiHeader.attr('class', 'dropdown-header');
            groupbyLiHeader.text('Group By');
            var groupbyLiDivider = $(document.createElement('li'));
            groupbyLiDivider.attr('class', 'divider');
            groupbyUl.append(groupbyLiHeader);
            groupbyUl.append(groupbyLiDivider);
            divContainer.append(groupbyUl);

            var divGroupingWrapper = $(document.createElement('div'));
            divGroupingWrapper.attr('class', 'grouping-wrapper');

            var divGroupingWrapperEmptyText = $(document.createElement('div'));
            divGroupingWrapperEmptyText.attr('class', 'no-text');
            divGroupingWrapperEmptyText.text('No grouping specified');
            divGroupingWrapper.append(divGroupingWrapperEmptyText);

            var sAvailableGrps = cfg['availableGroups'];
            var availableGrps = new Array();
            if (sAvailableGrps) {
                availableGrps = sAvailableGrps.split(',');
            }

            if (availableGrps.length == 0) {
                alert('no choice fields');
                return;
            }

            // foreach grouping field we need to render
            var groups = cfg['groups'];
            if (groups != null && groups.length > 0) {
                divGroupingWrapperEmptyText.text('');
            }
            for (var i in groups) {


                var group = groups[i];

                var divGroupingRow = $(document.createElement('div'));
                divGroupingRow.attr('class', 'grouping-row');

                var divGroupingNumber = $(document.createElement('div'));
                divGroupingNumber.attr('class', 'grouping-number');
                divGroupingNumber.text(parseInt(i) + 1);

                var divGroupingSelect = $(document.createElement('div'));
                divGroupingSelect.attr('class', 'grouping-select');
                var select = $(document.createElement('select'));
                select.addClass('form-control');
                for (var j in availableGrps) {
                    if (availableGrps.hasOwnProperty(j)) {
                        var txt = availableGrps[j].split('|')[0];
                        var val = availableGrps[j].split('|')[1];
                        select.append('<option value="' + val + '">' + txt + '</option>');
                    }
                }
                select.val(group['internalName']);
                divGroupingSelect.append(select);

                var divGroupingDelete = $(document.createElement('div'));
                divGroupingDelete.attr('class', 'grouping-delete');
                var aGroupingDelete = $(document.createElement('a'));
                var spanGroupingDelete = $(document.createElement('span'));
                spanGroupingDelete.attr('class', 'fui-cross icon-dropdown');
                aGroupingDelete.append(spanGroupingDelete);
                aGroupingDelete.bind('click', function () {
                    //EPML-5286 - Here, fetch deleted ddl selected option so that we can add into other ddl
                    var val = $(this).closest('.grouping-row').find('.grouping-select').find('select option:selected').val();
                    //---
                    $(this).closest('.grouping-row').remove();
                    var num = 1;
                    $('.grouping-wrapper').children('.grouping-row').each(function () {
                        $(this).find('.grouping-number').first().text(num++);
                    });
                    var numRows = $('.grouping-wrapper').children('.grouping-row').length;
                    if (numRows == 0) {
                        divGroupingWrapperEmptyText.text('No Grouping Added');
                        $('#aGroupBySave').attr('class', 'disabledLink');
                    }
                    else if (numRows > 0 && numRows < 5) {
                        $('#aGroupBySave').removeAttr('class');
                        $('#aAddGrouping').removeAttr('class');
                    }
                    else if (numRows > 0 && numRows == 4) {
                        $('#aGroupBySave').removeAttr('class');
                        $('#aAddGrouping').attr('class', 'disabledLink');
                    }
                    //EPML-5286 - show above selected value into rest of ddl
                    $('.grouping-wrapper').children('.grouping-row').each(function () {
                        $('.grouping-select select').not(this).children('option[value=' + val + ']').show();
                    });
                    //--
                });
                divGroupingDelete.append(aGroupingDelete);

                divGroupingRow.append(divGroupingNumber);
                divGroupingRow.append(divGroupingSelect);
                divGroupingRow.append(divGroupingDelete);
                divGroupingWrapper.append(divGroupingRow);
            }
            divContainer.append(divGroupingWrapper);

            var divGroupingFooter = $(document.createElement('div'));
            divGroupingFooter.attr('class', 'grouping-footer');
            var ulFooterHeading = $(document.createElement('ul'));
            var liFooterDivider = $(document.createElement('li'));
            liFooterDivider.addClass('divider');
            ulFooterHeading.append(liFooterDivider);
            divGroupingFooter.append(ulFooterHeading);

            var divFooterAdd = $(document.createElement('div'));
            divFooterAdd.addClass('grouping-add');
            var aFooterAdd = $(document.createElement('a'));
            aFooterAdd.attr('id', 'aAddGrouping');
            aFooterAdd.attr('href', 'javascript:void(0)');
            aFooterAdd.text('Add Grouping');
            aFooterAdd.bind('click', function () {
                divGroupingWrapperEmptyText.text('');
                var numRows = $('.grouping-wrapper').children('.grouping-row').length;
                if (numRows < 4) {

                    if (numRows == 3) {
                        $(this).attr('class', 'disabledLink');
                    }

                    var divGroupingWrapper = $('.grouping-wrapper');

                    var divGroupingRow = $(document.createElement('div'));
                    divGroupingRow.attr('class', 'grouping-row');

                    var divGroupingNumber = $(document.createElement('div'));
                    divGroupingNumber.attr('class', 'grouping-number');
                    divGroupingNumber.text(numRows + 1);

                    var divGroupingSelect = $(document.createElement('div'));
                    divGroupingSelect.attr('class', 'grouping-select');
                    var select = $(document.createElement('select'));
                    select.addClass('form-control');
                    for (var j in availableGrps) {
                        if (availableGrps.hasOwnProperty(j)) {
                            var txt = availableGrps[j].split('|')[0];
                            var val = availableGrps[j].split('|')[1];
                            select.append('<option value="' + val + '">' + txt + '</option>');
                        }
                    }
                    //EPML-5286 -- here, hide option value, which is already selected in other ddl, in newly created ddl
                    var keyVals = [];
                    keyVals = ddlselectedoption();
                    if (keyVals.length > 0) {
                        for (k = 0; k < keyVals.length; k++) {
                            select.children('option[value=' + keyVals[k].value + ']').hide();
                        }
                        jQuery(select).find('option').each(function () {
                            if ($(this).css('display') != 'none') {
                                $(this).prop("selected", true);
                                return false;
                            }
                        });
                    }
                    else {
                        select.prop('selectedIndex', 0);
                    }
                    //-------
                    divGroupingSelect.append(select);

                    var divGroupingDelete = $(document.createElement('div'));
                    divGroupingDelete.attr('class', 'grouping-delete');
                    var aGroupingDelete = $(document.createElement('a'));
                    var spanGroupingDelete = $(document.createElement('span'));
                    spanGroupingDelete.attr('class', 'fui-cross icon-dropdown');
                    aGroupingDelete.append(spanGroupingDelete);
                    aGroupingDelete.bind('click', function () {
                        //EPML-5286 - Here, fetch deleted ddl selected option so that we can add into other ddl
                        var val = $(this).closest('.grouping-row').find('.grouping-select').find('select option:selected').val();
                        //----
                        $(this).closest('.grouping-row').remove();
                        var num = 1;
                        $('.grouping-wrapper').children('.grouping-row').each(function () {
                            $(this).find('.grouping-number').first().text(num++);
                        });
                        var numRows = $('.grouping-wrapper').children('.grouping-row').length;
                        if (numRows == 0) {
                            divGroupingWrapperEmptyText.text('No Grouping Added');
                            $('#aGroupBySave').attr('class', 'disabledLink');
                        }
                        else if (numRows > 0 && numRows < 5) {
                            $('#aGroupBySave').removeAttr('class');
                            $('#aAddGrouping').removeAttr('class');
                        }
                        else if (numRows > 0 && numRows == 4) {
                            $('#aGroupBySave').removeAttr('class');
                            $('#aAddGrouping').attr('class', 'disabledLink');
                        }

                        //EPML-5286 - show above selected value into rest of ddl
                        $('.grouping-wrapper').children('.grouping-row').each(function () {
                            $('.grouping-select select').not(this).children('option[value=' + val + ']').show();
                        });
                        //----

                        var keyVals = [];
                        $('.grouping-wrapper').children('.grouping-row').each(function () {
                            //var txt = $(this).find('.grouping-select').find('select option:selected').text();
                            var val = $(this).find('.grouping-select').find('select option:selected').val();
                            //var objTemp = { 'key': txt, 'value': val };
                            keyVals.push(val);
                        });

                        var sCols = keyVals.join(',');
                        var grid = window.Grids[window.epmLive.resourceGridId];
                        grid.DoGrouping(sCols);
                    });

                    divGroupingDelete.append(aGroupingDelete);

                    divGroupingRow.append(divGroupingNumber);
                    divGroupingRow.append(divGroupingSelect);
                    divGroupingRow.append(divGroupingDelete);
                    divGroupingWrapper.append(divGroupingRow);

                    $('#aGroupBySave').removeAttr('class');
                }
                //EPML-5286 -- here, default selected option in newly created ddl must be invisible in reset of ddl 
                var keyVals = [];
                keyVals = ddlselectedoption();
                if (keyVals.length > 0) {
                    HideOptionValue(keyVals);
                }
                //---
            });
            divFooterAdd.append(aFooterAdd);
            divGroupingFooter.append(divFooterAdd);

            var divFooterSave = $(document.createElement('div'));
            divFooterSave.addClass('grouping-save');
            var aFooterSave = $(document.createElement('a'));
            aFooterSave.attr('id', 'aGroupBySave');
            aFooterSave.attr('href', 'javascript:void(0)');

            aFooterSave.text('Apply');
            aFooterSave.bind('click', function () {
                var numGroups = $('.grouping-wrapper').children('.grouping-row').length;
                if (numGroups > 0) {
                    var keyVals = [];
                    $('.grouping-wrapper').children('.grouping-row').each(function () {
                        var txt = $(this).find('.grouping-select').find('select option:selected').text();
                        var val = $(this).find('.grouping-select').find('select option:selected').val();
                        var objTemp = { 'key': txt, 'value': val };
                        keyVals.push(objTemp);
                    });
                    cfg['saveFunction'](keyVals);
                }

                //$(this).parent('.grouping-dropdown-menu').toggle();
                $(".grouping-dropdown-menu").toggle();
            });
            divFooterSave.append(aFooterSave);
            divGroupingFooter.append(divFooterSave);

            divContainer.append(divGroupingFooter);
            //EPML-5286 - When change value in ddl 
            changeddl();
            //----
            li.append(divContainer);
            ul.append(li);
        }

        function changeddl() {
            $('.grouping-select select').live("change", function () {
                $('option:hidden', $('.grouping-select select')).each(function () {
                    var self = this,
						toShow = true;
                    $('.grouping-select select').not($(this).parent()).each(function () {
                        if (self.value == this.value) {
                            toShow = false;
                        }
                    })
                    if (toShow) {
                        $(this).show();
                    }
                });
                $('.grouping-select select').not(this).children('option[value=' + this.value + ']').hide();
            });
        }

        function ddlselectedoption() {
            var selectedoptions = [];
            $('.grouping-wrapper').children('.grouping-row').each(function () {
                var txt = $(this).find('.grouping-select').find('select option:selected').text();
                var val = $(this).find('.grouping-select').find('select option:selected').val();
                var objTemp1 = { 'key': txt, 'value': val };
                selectedoptions.push(objTemp1);
            });
            return (selectedoptions);
        }

        function HideOptionValue(arr_keyvalue) {
            for (j = 0; j < arr_keyvalue.length; j++) {
                $('option:hidden', $('.grouping-select select')).each(function () {
                    var self = this,
                    toShow = true;
                    $('.grouping-select select').not($(this).parent()).each(function () {
                        if (self.value == this.value) {
                            toShow = false;
                        }
                    })
                    if (toShow) {
                        $(this).show();
                    }
                });
                $('.grouping-select select').not(this).children('option[value=' + arr_keyvalue[j].value + ']').hide();
            }
        }

        function createMultiSelect(cfg, ul) {
            var controlId = cfg['controlId'];
            var iconClass = cfg['iconClass'];
            var title = cfg['title'];
            var value = cfg['value'];
            var toolTip = cfg['toolTip'];

            var li = $(document.createElement('li'));
            li.attr('class', 'dropdown');

            if (toolTip) {
                li.attr('title', toolTip);
            }
            else if (title) {
                li.attr('title', title);
            }

            var aContainer = $(document.createElement('a'));
            aContainer.attr('class', 'dropdown-toggle nav-icon');
            aContainer.attr('href', 'javascript:void(0)');
            aContainer.attr('controlId', controlId);

            if (toolTip) {
                aContainer.attr('data-toggle', 'tooltip');
                aContainer.attr('data-placement', 'top');
                aContainer.attr('data-container', 'body');
                aContainer.attr('data-delay', '200');
                aContainer.attr('title', toolTip);
            }

            if (iconClass &&
                (iconClass != 'none')) {
                var spnImg = $(document.createElement('span'));
                spnImg.attr('class', iconClass);
                aContainer.append(spnImg);
            }

            if (title &&
                (title.toLowerCase() != 'none')) {
                var spnLbl = $(document.createElement('span'));
                spnLbl.addClass('dropdown-label');
                spnLbl.text(title);
                aContainer.append(spnLbl);
            }

            if (value &&
                (value != 'none')) {
                var spnLbl = $(document.createElement('span'));
                spnLbl.text(value);
                aContainer.append(spnLbl);
            }

            aContainer.bind('click', function () {
                $('.dropdown-menu').css('display', 'none');
                $('#' + getUlId($(this).attr('controlId'))).toggle();
            });

            li.append(aContainer);

            var ulColumns = $(document.createElement('ul'));
            ulColumns.attr('id', getUlId(controlId));
            ulColumns.attr('class', 'multiselect-container dropdown-menu');
            ulColumns.attr('style', 'max-height: 400px;overflow-y: auto;overflow-x: hidden;');

            var liSelectAll = $(document.createElement('li'));
            var aSelectAllChxBx = $(document.createElement('a'));
            aSelectAllChxBx.attr('href', 'javascript:void(0)');
            aSelectAllChxBx.addClass('multiselect-all');
            var lblSelectAllChxBx = $(document.createElement('label'));
            lblSelectAllChxBx.attr('class', 'checkbox');
            var inputChxBx = $(document.createElement('input'));
            inputChxBx.attr('id', 'cbSelectAll');
            inputChxBx.attr('type', 'checkbox');
            inputChxBx.attr('value', 'multiselect-all');
            inputChxBx.bind('change', function () {
                if ($(this).is(':checked')) {
                    $(this).closest('li').siblings().each(function () {
                        $(this).find('input:checkbox').prop('checked', true);
                    });
                }
                else {
                    $(this).closest('li').siblings().each(function () {
                        $(this).find('input:checkbox').prop('checked', false);
                    });
                }

                if (cfg['onchangeFunction']) {
                    var data = {};
                    var selectedKeys = [];
                    if ($(this).is(':checked')) {
                        selectedKeys.push($(this).val());
                    }
                    $(this).closest('li').siblings().find(':checked').each(function () {
                        if ($(this).parent().text().toLowerCase() == 'select all') {
                            return;
                        }
                        selectedKeys.push($(this).val());
                    });
                    data['selectedKeys'] = selectedKeys;
                    var ctrlId = $(this).closest('ul').siblings('a').attr('controlId');
                    data['sections'] = getUlChoices(ctrlId);
                    cfg['onchangeFunction'](data);
                }
            });
            lblSelectAllChxBx.append(inputChxBx);
            lblSelectAllChxBx.append('Select all');
            aSelectAllChxBx.append(lblSelectAllChxBx);
            liSelectAll.append(aSelectAllChxBx);
            ulColumns.append(liSelectAll);

            var divChoicesContainer = $(document.createElement('div'));
            //foreach column we add an element, ulColumns.apend(...)
            var sections = cfg['sections'];
            setUlChoices(controlId, sections);
            for (var i in sections) {

                var section = sections[i];

                //add section heading
                var sHeading = section['heading'];
                if (sHeading &&
                    (sHeading.toLowerCase() != 'none')) {
                    var liHeading = $(document.createElement('li'));
                    liHeading.attr('class', 'dropdown-header');
                    liHeading.text(sHeading);
                    divChoicesContainer.append(liHeading);
                }
                //add section divider
                var sDivider = section['divider'];
                if (sDivider &&
                    sDivider.toLowerCase() != 'no' &&
                    sDivider.toLowerCase() != 'none') {
                    var liDivider = $(document.createElement('li'));
                    liDivider.attr('class', 'divider');
                    divChoicesContainer.append(liDivider);
                }

                for (var sIndex in section['options']) {
                    var option = section['options'][sIndex];
                    //get choice value
                    var text = option['value'];
                    var value = sIndex;
                    var checked = option['checked'];
                    //create rows
                    var liChoice = $(document.createElement('li'));
                    var a = $(document.createElement('a'));
                    a.attr('href', 'javascript:void(0)');
                    var lbl = $(document.createElement('label'));
                    lbl.attr('class', 'checkbox');
                    var input = $(document.createElement('input'));
                    input.attr('type', 'checkbox');
                    input.attr('class', 'cbColumn');
                    input.attr('value', value);
                    input.prop('checked', checked);

                    input.bind('change', function () {
                        if ($(this).prop('checked') == false) {
                            $('#cbSelectAll').prop('checked', false);
                        }
                        else {
                            if ($('.cbColumn:not(:checked)').length == 0) {
                                $('#cbSelectAll').prop('checked', true);
                            }
                        }

                        if (cfg['onchangeFunction']) {
                            var data = {};
                            var selectedKeys = [];
                            if ($(this).is(':checked')) {
                                selectedKeys.push($(this).val());
                            }
                            $(this).closest('li').siblings('li').find(':checked').each(function () {
                                selectedKeys.push($(this).val());
                            });
                            data['selectedKeys'] = selectedKeys;
                            var ctrlId = $(this).closest('ul').siblings('a').attr('controlId');
                            data['sections'] = getUlChoices(ctrlId);
                            cfg['onchangeFunction'](data);
                        }
                    });

                    lbl.append(input);
                    lbl.append(text);
                    a.append(lbl);
                    liChoice.append(a)
                    divChoicesContainer.append(liChoice);
                }
            }

            ulColumns.append(divChoicesContainer);

            var liDivider = $(document.createElement('li'));
            liDivider.addClass('divider');
            ulColumns.append(liDivider);

            var divFooterApply = $(document.createElement('div'));
            divFooterApply.addClass('grouping-apply');
            var aFooterApply = $(document.createElement('a'));
            aFooterApply.attr('href', 'javascript:void(0)');
            aFooterApply.text(cfg['applyButtonConfig']['text']);

            if (cfg['applyButtonConfig']['function']) {
                aFooterApply.bind('click', function () {
                    var data = {};
                    var selectedKeys = [];

                    $(this).parent().siblings('div').first().children('li').find(':checked').each(function () {
                        selectedKeys.push($(this).val());
                    });
                    data['selectedKeys'] = selectedKeys;
                    var ctrlId = $(this).closest('ul').siblings('a').attr('controlId');
                    data['sections'] = getUlChoices(ctrlId);
                    cfg['applyButtonConfig']['function'](data);

                    $('#' + ctrlId + "_ul_menu").toggle();
                });
            }

            divFooterApply.append(aFooterApply);
            ulColumns.append(divFooterApply);

            li.append(ulColumns);
            ul.append(li);

        }
        //END RIGHT SIDE TOOL BAR METHODS

        //START HELPER
        function attachEvents(element, aEvents) {
            for (var i in aEvents) {

                var evt = aEvents[i];
                element.bind(evt['eventName'], evt['function']);
            }
        }

        function attachProps(element, aProps) {
            for (var p in aProps) {

                var propVal = aProps[p];
                element.attr(p, propVal);
            }
        }

        function clickedOutsideElement(elemId, event) {
            var theElem = (window.event) ? getEventTarget(window.event) : event.target;
            while (theElem != null) {
                if (theElem.id == elemId) {
                    return false;
                }
                else {
                    theElem = theElem.parentNode;
                }
            }
            return true;
        }

        function clickedOutsideElementClass(sClass, event) {
            var theElem = (window.event) ? getEventTarget(window.event) : event.target;
            while (theElem != null) {
                if ($(theElem).attr('class') != null && $(theElem).attr('class').indexOf(sClass) != -1) {
                    return false;
                }
                else {
                    theElem = theElem.parentNode;
                }
            }
            return true;
        }

        function getEventTarget(evt) {
            var targ = (evt.target) ? evt.target : evt.srcElement;
            if (targ != null) {
                if (targ.nodeType == 3)
                    targ = targ.parentNode;
            }
            return targ;
        }

        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
                       .toString(16)
                       .substring(1);
        };

        function guid() {
            return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
                   s4() + '-' + s4() + s4() + s4();
        }

        function getSafeTitle(title) {
            var ret = '';
            if (title)
                ret = title.replace(/ /g, '');

            return ret;
        }

        function getUlId(id) {
            // get one from storage
            var ret = '';
            var oldVal = ulIds[id];
            if (!oldVal) {
                // can't find it, so we create one
                ulIds[id] = id + '_ul_menu';
                ret = ulIds[id];
            }
            else {
                ret = oldVal;
            }
            return ret;
        }

        function setUlChoices(id, objSections) {
            multiSelectStorage[id] = objSections;
        }

        function getUlChoices(id) {
            return multiSelectStorage[id];
        }
        //END HELPER
    };

    window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs('EPMLiveToolbar.js');
})(window.epmLiveGenericToolBar = window.epmLiveGenericToolBar || {}, window.jQuery);