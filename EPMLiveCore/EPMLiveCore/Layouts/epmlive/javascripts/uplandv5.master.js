///#source 1 1 /Layouts/epmlive/javascripts/libraries/tooltip.js
/* ========================================================================
 * Bootstrap: tooltip.js v3.1.1
 * http://getbootstrap.com/javascript/#tooltip
 * Inspired by the original jQuery.tipsy by Jason Frame
 * ========================================================================
 * Copyright 2011-2014 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($) {
    'use strict';

    // TOOLTIP PUBLIC CLASS DEFINITION
    // ===============================

    var Tooltip = function (element, options) {
        this.type =
        this.options =
        this.enabled =
        this.timeout =
        this.hoverState =
        this.$element = null

        this.init('tooltip', element, options)
    }

    Tooltip.DEFAULTS = {
        animation: true,
        placement: 'top',
        selector: false,
        template: '<div class="tooltip"><div class="tooltip-arrow"></div><div class="tooltip-inner"></div></div>',
        trigger: 'hover focus',
        title: '',
        delay: 0,
        html: false,
        container: false
    }

    Tooltip.prototype.init = function (type, element, options) {
        this.enabled = true
        this.type = type
        this.$element = $(element)
        this.options = this.getOptions(options)

        var triggers = this.options.trigger.split(' ')

        for (var i = triggers.length; i--;) {
            var trigger = triggers[i]

            if (trigger == 'click') {
                this.$element.on('click.' + this.type, this.options.selector, $.proxy(this.toggle, this))
            } else if (trigger != 'manual') {
                var eventIn = trigger == 'hover' ? 'mouseenter' : 'focusin'
                var eventOut = trigger == 'hover' ? 'mouseleave' : 'focusout'

                this.$element.on(eventIn + '.' + this.type, this.options.selector, $.proxy(this.enter, this))
                this.$element.on(eventOut + '.' + this.type, this.options.selector, $.proxy(this.leave, this))
            }
        }

        this.options.selector ?
          (this._options = $.extend({}, this.options, { trigger: 'manual', selector: '' })) :
          this.fixTitle()
    }

    Tooltip.prototype.getDefaults = function () {
        return Tooltip.DEFAULTS
    }

    Tooltip.prototype.getOptions = function (options) {
        options = $.extend({}, this.getDefaults(), this.$element.data(), options)

        if (options.delay && typeof options.delay == 'number') {
            options.delay = {
                show: options.delay,
                hide: options.delay
            }
        }

        return options
    }

    Tooltip.prototype.getDelegateOptions = function () {
        var options = {}
        var defaults = this.getDefaults()

        this._options && $.each(this._options, function (key, value) {
            if (defaults[key] != value) options[key] = value
        })

        return options
    }

    Tooltip.prototype.enter = function (obj) {
        var self = obj instanceof this.constructor ?
            obj : $(obj.currentTarget)[this.type](this.getDelegateOptions()).data('bs.' + this.type)

        clearTimeout(self.timeout)

        self.hoverState = 'in'

        if (!self.options.delay || !self.options.delay.show) return self.show()

        self.timeout = setTimeout(function () {
            if (self.hoverState == 'in') self.show()
        }, self.options.delay.show)
    }

    Tooltip.prototype.leave = function (obj) {
        var self = obj instanceof this.constructor ?
            obj : $(obj.currentTarget)[this.type](this.getDelegateOptions()).data('bs.' + this.type)

        clearTimeout(self.timeout)

        self.hoverState = 'out'

        if (!self.options.delay || !self.options.delay.hide) return self.hide()

        self.timeout = setTimeout(function () {
            if (self.hoverState == 'out') self.hide()
        }, self.options.delay.hide)
    }

    Tooltip.prototype.show = function () {
        var e = $.Event('show.bs.' + this.type)

        if (this.hasContent() && this.enabled) {
            this.$element.trigger(e)

            if (e.isDefaultPrevented()) return
            var that = this;

            var $tip = this.tip()

            this.setContent()

            if (this.options.animation) $tip.addClass('fade')

            var placement = typeof this.options.placement == 'function' ?
              this.options.placement.call(this, $tip[0], this.$element[0]) :
              this.options.placement

            var autoToken = /\s?auto?\s?/i
            var autoPlace = autoToken.test(placement)
            if (autoPlace) placement = placement.replace(autoToken, '') || 'top'

            $tip
              .detach()
              .css({ top: 0, left: 0, display: 'block' })
              .addClass(placement)

            this.options.container ? $tip.appendTo(this.options.container) : $tip.insertAfter(this.$element)

            var pos = this.getPosition()
            var actualWidth = $tip[0].offsetWidth
            var actualHeight = $tip[0].offsetHeight

            if (autoPlace) {
                var $parent = this.$element.parent()

                var orgPlacement = placement
                var docScroll = document.documentElement.scrollTop || document.body.scrollTop
                var parentWidth = this.options.container == 'body' ? window.innerWidth : $parent.outerWidth()
                var parentHeight = this.options.container == 'body' ? window.innerHeight : $parent.outerHeight()
                var parentLeft = this.options.container == 'body' ? 0 : $parent.offset().left

                placement = placement == 'bottom' && pos.top + pos.height + actualHeight - docScroll > parentHeight ? 'top' :
                            placement == 'top' && pos.top - docScroll - actualHeight < 0 ? 'bottom' :
                            placement == 'right' && pos.right + actualWidth > parentWidth ? 'left' :
                            placement == 'left' && pos.left - actualWidth < parentLeft ? 'right' :
                            placement

                $tip
                  .removeClass(orgPlacement)
                  .addClass(placement)
            }

            var calculatedOffset = this.getCalculatedOffset(placement, pos, actualWidth, actualHeight)

            this.applyPlacement(calculatedOffset, placement)
            this.hoverState = null

            var complete = function () {
                that.$element.trigger('shown.bs.' + that.type)
            }

            $.support.transition && this.$tip.hasClass('fade') ?
              $tip
                .one($.support.transition.end, complete)
                .emulateTransitionEnd(150) :
              complete()
        }
    }

    Tooltip.prototype.applyPlacement = function (offset, placement) {
        var replace
        var $tip = this.tip()
        var width = $tip[0].offsetWidth
        var height = $tip[0].offsetHeight

        // manually read margins because getBoundingClientRect includes difference
        var marginTop = parseInt($tip.css('margin-top'), 10)
        var marginLeft = parseInt($tip.css('margin-left'), 10)

        // we must check for NaN for ie 8/9
        if (isNaN(marginTop)) marginTop = 0
        if (isNaN(marginLeft)) marginLeft = 0

        offset.top = offset.top + marginTop
        offset.left = offset.left + marginLeft

        // $.fn.offset doesn't round pixel values
        // so we use setOffset directly with our own function B-0
        $.offset.setOffset($tip[0], $.extend({
            using: function (props) {
                $tip.css({
                    top: Math.round(props.top),
                    left: Math.round(props.left)
                })
            }
        }, offset), 0)

        $tip.addClass('in')

        // check to see if placing tip in new offset caused the tip to resize itself
        var actualWidth = $tip[0].offsetWidth
        var actualHeight = $tip[0].offsetHeight

        if (placement == 'top' && actualHeight != height) {
            replace = true
            offset.top = offset.top + height - actualHeight
        }

        if (/bottom|top/.test(placement)) {
            var delta = 0

            if (offset.left < 0) {
                delta = offset.left * -2
                offset.left = 0

                $tip.offset(offset)

                actualWidth = $tip[0].offsetWidth
                actualHeight = $tip[0].offsetHeight
            }

            this.replaceArrow(delta - width + actualWidth, actualWidth, 'left')
        } else {
            this.replaceArrow(actualHeight - height, actualHeight, 'top')
        }

        if (replace) $tip.offset(offset)
    }

    Tooltip.prototype.replaceArrow = function (delta, dimension, position) {
        this.arrow().css(position, delta ? (50 * (1 - delta / dimension) + '%') : '')
    }

    Tooltip.prototype.setContent = function () {
        var $tip = this.tip()
        var title = this.getTitle()

        $tip.find('.tooltip-inner')[this.options.html ? 'html' : 'text'](title)
        $tip.removeClass('fade in top bottom left right')
    }

    Tooltip.prototype.hide = function () {
        var that = this
        var $tip = this.tip()
        var e = $.Event('hide.bs.' + this.type)

        function complete() {
            if (that.hoverState != 'in') $tip.detach()
            that.$element.trigger('hidden.bs.' + that.type)
        }

        this.$element.trigger(e)

        if (e.isDefaultPrevented()) return

        $tip.removeClass('in')

        $.support.transition && this.$tip.hasClass('fade') ?
          $tip
            .one($.support.transition.end, complete)
            .emulateTransitionEnd(150) :
          complete()

        this.hoverState = null

        return this
    }

    Tooltip.prototype.fixTitle = function () {
        var $e = this.$element
        if ($e.attr('title') || typeof ($e.attr('data-original-title')) != 'string') {
            $e.attr('data-original-title', $e.attr('title') || '').attr('title', '')
        }
    }

    Tooltip.prototype.hasContent = function () {
        return this.getTitle()
    }

    Tooltip.prototype.getPosition = function () {
        var el = this.$element[0]
        return $.extend({}, (typeof el.getBoundingClientRect == 'function') ? el.getBoundingClientRect() : {
            width: el.offsetWidth,
            height: el.offsetHeight
        }, this.$element.offset())
    }

    Tooltip.prototype.getCalculatedOffset = function (placement, pos, actualWidth, actualHeight) {
        return placement == 'bottom' ? { top: pos.top + pos.height, left: pos.left + pos.width / 2 - actualWidth / 2 } :
               placement == 'top' ? { top: pos.top - actualHeight, left: pos.left + pos.width / 2 - actualWidth / 2 } :
               placement == 'left' ? { top: pos.top + pos.height / 2 - actualHeight / 2, left: pos.left - actualWidth } :
            /* placement == 'right' */ { top: pos.top + pos.height / 2 - actualHeight / 2, left: pos.left + pos.width }
    }

    Tooltip.prototype.getTitle = function () {
        var title
        var $e = this.$element
        var o = this.options

        title = $e.attr('data-original-title')
          || (typeof o.title == 'function' ? o.title.call($e[0]) : o.title)

        return title
    }

    Tooltip.prototype.tip = function () {
        return this.$tip = this.$tip || $(this.options.template)
    }

    Tooltip.prototype.arrow = function () {
        return this.$arrow = this.$arrow || this.tip().find('.tooltip-arrow')
    }

    Tooltip.prototype.validate = function () {
        if (!this.$element[0].parentNode) {
            this.hide()
            this.$element = null
            this.options = null
        }
    }

    Tooltip.prototype.enable = function () {
        this.enabled = true
    }

    Tooltip.prototype.disable = function () {
        this.enabled = false
    }

    Tooltip.prototype.toggleEnabled = function () {
        this.enabled = !this.enabled
    }

    Tooltip.prototype.toggle = function (e) {
        var self = e ? $(e.currentTarget)[this.type](this.getDelegateOptions()).data('bs.' + this.type) : this
        self.tip().hasClass('in') ? self.leave(self) : self.enter(self)
    }

    Tooltip.prototype.destroy = function () {
        clearTimeout(this.timeout)
        this.hide().$element.off('.' + this.type).removeData('bs.' + this.type)
    }


    // TOOLTIP PLUGIN DEFINITION
    // =========================

    var old = $.fn.tooltip

    $.fn.tooltip = function (option) {
        return this.each(function () {
            var $this = $(this)
            var data = $this.data('bs.tooltip')
            var options = typeof option == 'object' && option

            if (!data && option == 'destroy') return
            if (!data) $this.data('bs.tooltip', (data = new Tooltip(this, options)))
            if (typeof option == 'string') data[option]()
        })
    }

    $.fn.tooltip.Constructor = Tooltip


    // TOOLTIP NO CONFLICT
    // ===================

    $.fn.tooltip.noConflict = function () {
        $.fn.tooltip = old
        return this
    }

}(jQuery);

///#source 1 1 /Layouts/epmlive/javascripts/masterpages/UplandV5.js
var uvOptions = {};

(function() {
    'use strict';

    function loadUserVoice() {
        var uv = document.createElement('script');
        uv.type = 'text/javascript';
        uv.async = true;
        uv.src = '//widget.uservoice.com/uFW21LPmYTawwUX9btPog.js';
        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(uv, s);
    }

    window.showUserVoicePopup = function() {
        if (window.isIE8 && window.userVoiceIgnored) {
            alert('User Voice is not supported on this page in IE 8.');
        } else {
            window.UserVoice.showPopupWidget();
        }
    };

    if (window.isIE8) {
        window.ie8StringContains = function(str1, str2) {
            var arr = str1.split(str2);
            if (arr.length > 1) return true;
            return false;
        };

        var currentUrl = (window.location + '').toLowerCase();

        var ignore = false;
        var ignoredUrls = ['EditableFields.aspx', 'ViewEdit.aspx'];
        for (var i = 0; i < ignoredUrls.length; i++) {
            if (window.ie8StringContains(currentUrl, ignoredUrls[i].toLowerCase())) {
                ignore = true;
                break;
            }
        }

        if (!ignore) {
            loadUserVoice();
        }

        window.userVoiceIgnored = ignore;
    } else {
        loadUserVoice();
    }

    window.toggleSearch = function() {
        var $sbox = $('#search-box-container');
        var $sicon = $('#search-container a');
        var $sinput = $($sbox.find('input').get(0));

        if ($sbox.is(':visible')) {
            $sicon.css('color', '#00668E');
        } else {
            $sicon.css('color', '#FFFFFF');
        }

        $sbox.toggle('fast',function() {
            $sinput.focus();
        });
    };

    window.updateProfilePic = function() {
        OpenPopUpPageWithTitle(window.epmLive.currentSiteUrl + '/_layouts/15/epmlive/UploadProfilePicture.aspx', profilePicUpdated, null, null, 'Update Profile Photo');
    };

    window.profilePicUpdated = function(status, picUrl) {
        if (status === 1) {
            $('#EPMLiveProfilePic').attr('src', picUrl + '?v' + new Date().getTime()).show();
        }
    };

    window.walkme_ready = function() {
        var $supportLink = $('#epm-support-link');
        $supportLink.attr('href', '#');
        $supportLink.removeAttr('target');

        $supportLink.click(function(event) {
            $('.walkme-menu-click-close').after('<a id="support-link" style="right: 31px !important; top:  8px !important; width: 220px !important; height: 25px !important; z-index: 2147483647 !important; position: absolute !important; font-size: 14px; color: #1F80C8" href="http://support.epmlive.com" target="_blank">Visit our Support Community</a>');
            window.WalkMePlayerAPI.toggleMenu();

            event.stopPropagation();
        });

        $('body').click(function () {
            if ($('#walkme-menu-open').is(':visible')) {
                window.WalkMePlayerAPI.toggleMenu();
            }
        });
    };

    window.walkme_player_event = function(eventData) {
        if (eventData.Type === "AfterMenuOpen") {
            $('#epm-support-link').css('color', '#FFFFFF');
        }

        if (eventData.Type === "BeforeMenuClose") {
            $('#epm-support-link').css('color', '#00668E');
        }
    };

    var epmLiveTweaks = function () {
        $(function() {
            var $siteTitle = $('#site-title');
            var $pageTitle = $('#DeltaPlaceHolderPageTitleInTitleArea');

            if ($siteTitle.text().trim() === $pageTitle.text().trim()) {
                $siteTitle.addClass('epm-no-page-title');
                $pageTitle.hide();
            }
        });
        
        $(document).click(function(e) {
            if ($('#search-box-container').is(':visible')) {
                if ($(e.target).parents('#search-box-container').length === 0 && $(e.target).parents('#search-container').length === 0) {
                    toggleSearch();
                }
            }
        });

        var addUpdateProfilePicLink = function () {
            if (window.isIE8) {

                var insertAfter = function(referenceNode, newNode) {
                    referenceNode.parentNode.insertBefore(newNode, referenceNode.nextSibling.nextSibling);
                };

                var $menuBox = $('#welcomeMenuBox');
                
                if ($menuBox.length > 0) {
                    var $menuItems = $($('#welcomeMenuBox').get(0).getElementsByTagName('ie:menuitem'));
                    if ($menuItems.length > 0) {
                        insertAfter($menuItems.get(0), $('<ie:menuitem menugroupid="100" description="Update your profile photo." text="Update Profile Photo" onmenuclick="javascript:window.updateProfilePic();" type="option" id="epm-update-profile-pic" enabled="true" checked="false" onmenuclick_original="javascript:window.updateProfilePic();" text_original="Update Profile Photo" description_original="Update your profile photo." valorig=""></ie:menuitem>').get(0));
                    } else {
                        window.setTimeout(function() {
                            addUpdateProfilePicLink();
                        }, 1);
                    }
                } else {
                    window.setTimeout(function () {
                        addUpdateProfilePicLink();
                    }, 1);
                }
            } else {
                var $menuitems = $('#welcomeMenuBox').find('ie\\:menuitem');

                if ($menuitems.length > 0) {
                    $('<ie:menuitem menugroupid="100" description="Update your profile photo." text="Update Profile Photo" onmenuclick="javascript:window.updateProfilePic();" type="option" id="epm-update-profile-pic" enabled="true" checked="false" onmenuclick_original="javascript:window.updateProfilePic();" text_original="Update Profile Photo" description_original="Update your profile photo." valorig=""></ie:menuitem>').insertAfter('#' + $menuitems.get(0).id);
                } else {
                    window.setTimeout(function () {
                        addUpdateProfilePicLink();
                    }, 1);
                }
            }
        };

        var configureSearchBox = function() {
            var $sbtn = $('#search-container');
            var $sbox = $('#search-box-container');
            var $sinput = $($sbox.find('input').get(0));

            if ($sbtn.length === 0 || $sbox.length === 0) {
                window.setTimeout(function() {
                    configureSearchBox();
                }, 1);
            } else {
                if ($sbox.find('input').length !== 1) {
                    $sbtn.hide();
                    $sbox.hide();
                } else {
                    $sinput.attr('placeholder', 'Search...');
                }
            }
        };

        var configureTooltips = function() {
            if ($.isFunction($.fn.tooltip)) {
                var $el = $('[data-toggle="tooltip"]');
                if ($el.length > 0) {
                    window.setTimeout(function() {
                        $el.tooltip();
                        $el.hover(function() {
                            $(this).tooltip('show');
                        }, function() {
                            $(this).tooltip('hide');
                        });
                    }, 1000);
                } else {
                    window.setTimeout(function () {
                        configureTooltips();
                    }, 100);
                }
            } else {
                window.setTimeout(function() {
                    configureTooltips();
                }, 100);
            }
        };

        var monitorGridMessages = function() {
            try {
                Grids.OnDebug = function (grid, level, message) {
                    if (message[1].indexOf('from different TreeGrid version, it can cause problems or errors. Always use (or modify)') !== -1) {
                        var clearLog = function () {
                            var debugWindow = document.getElementById('_TreeGridDebug');

                            if (debugWindow) {
                                debugWindow.innerHTML = '';
                                debugWindow.style.display = 'none';

                                document.getElementById('_TreeGridDebugButtons').style.display = 'none';
                                Grids.DebugHidden = 1;

                                console.log(message[1]);
                            } else {
                                window.setTimeout(function () {
                                    clearLog();
                                }, 1);
                            }
                        };

                        clearLog();
                    }
                };
            } catch (e) {
            }
        };

        window.fixGridMenus = function() {
            window.setTimeout(function() {
                $('.js-callout-mainElement').each(function() {
                    var $menu = $(this);
                    
                    if ($menu.is(':visible')) {
                        var menuOffset = $menu.offset();
                        var leftOffset = $('#s4-workspace').offset().left;
                        
                        if (menuOffset.left < leftOffset) {
                            $menu.offset({ top: menuOffset.top, left: leftOffset + 12 });
                        }
                    }
                });
            }, 0);
        };

        configureSearchBox();
        addUpdateProfilePicLink();
        configureTooltips();

        window.setTimeout(function() {
            monitorGridMessages();
        }, 2000);
    };

    ExecuteOrDelayUntilScriptLoaded(epmLiveTweaks, 'jquery.min.js');
})();

/*
 * Toastr
 * Version 2.0.1
 * Copyright 2012 John Papa and Hans Fjällemark.  
 * All Rights Reserved.  
 * Use, reproduction, distribution, and modification of this code is subject to the terms and 
 * conditions of the MIT license, available at http://www.opensource.org/licenses/mit-license.php
 *
 * Author: John Papa and Hans Fjällemark
 * Project: https://github.com/CodeSeven/toastr
 */
; (function (define) {
    define(['jquery'], function ($) {
        return (function () {
            var version = '2.0.1';
            var $container;
            var listener;
            var toastId = 0;
            var toastType = {
                error: 'error',
                info: 'info',
                success: 'success',
                warning: 'warning'
            };

            var toastr = {
                clear: clear,
                error: error,
                getContainer: getContainer,
                info: info,
                options: {},
                subscribe: subscribe,
                success: success,
                version: version,
                warning: warning
            };

            return toastr;

            //#region Accessible Methods
            function error(message, title, optionsOverride) {
                return notify({
                    type: toastType.error,
                    iconClass: getOptions().iconClasses.error,
                    message: message,
                    optionsOverride: optionsOverride,
                    title: title
                });
            }

            function info(message, title, optionsOverride) {
                return notify({
                    type: toastType.info,
                    iconClass: getOptions().iconClasses.info,
                    message: message,
                    optionsOverride: optionsOverride,
                    title: title
                });
            }

            function subscribe(callback) {
                listener = callback;
            }

            function success(message, title, optionsOverride) {
                return notify({
                    type: toastType.success,
                    iconClass: getOptions().iconClasses.success,
                    message: message,
                    optionsOverride: optionsOverride,
                    title: title
                });
            }

            function warning(message, title, optionsOverride) {
                return notify({
                    type: toastType.warning,
                    iconClass: getOptions().iconClasses.warning,
                    message: message,
                    optionsOverride: optionsOverride,
                    title: title
                });
            }

            function clear($toastElement) {
                var options = getOptions();
                if (!$container) { getContainer(options); }
                if ($toastElement && $(':focus', $toastElement).length === 0) {
                    $toastElement[options.hideMethod]({
                        duration: options.hideDuration,
                        easing: options.hideEasing,
                        complete: function () { removeToast($toastElement); }
                    });
                    return;
                }
                if ($container.children().length) {
                    $container[options.hideMethod]({
                        duration: options.hideDuration,
                        easing: options.hideEasing,
                        complete: function () { $container.remove(); }
                    });
                }
            }
            //#endregion

            //#region Internal Methods

            function getDefaults() {
                return {
                    tapToDismiss: true,
                    toastClass: 'toast',
                    containerId: 'toast-container',
                    debug: false,

                    showMethod: 'fadeIn', //fadeIn, slideDown, and show are built into jQuery
                    showDuration: 300,
                    showEasing: 'swing', //swing and linear are built into jQuery
                    onShown: undefined,
                    hideMethod: 'fadeOut',
                    hideDuration: 1000,
                    hideEasing: 'swing',
                    onHidden: undefined,

                    extendedTimeOut: 1000,
                    iconClasses: {
                        error: 'toast-error',
                        info: 'toast-info',
                        success: 'toast-success',
                        warning: 'toast-warning'
                    },
                    iconClass: 'toast-info',
                    positionClass: 'toast-top-right',
                    timeOut: 5000, // Set timeOut and extendedTimeout to 0 to make it sticky
                    titleClass: 'toast-title',
                    messageClass: 'toast-message',
                    target: 'body',
                    closeHtml: '<button>&times;</button>',
                    newestOnTop: true
                };
            }

            function publish(args) {
                if (!listener) {
                    return;
                }
                listener(args);
            }

            function notify(map) {
                var
                    options = getOptions(),
                    iconClass = map.iconClass || options.iconClass;

                if (typeof (map.optionsOverride) !== 'undefined') {
                    options = $.extend(options, map.optionsOverride);
                    iconClass = map.optionsOverride.iconClass || iconClass;
                }

                toastId++;

                $container = getContainer(options);
                var
                    intervalId = null,
                    $toastElement = $('<div/>'),
                    $titleElement = $('<div/>'),
                    $messageElement = $('<div/>'),
                    $closeElement = $(options.closeHtml),
                    response = {
                        toastId: toastId,
                        state: 'visible',
                        startTime: new Date(),
                        options: options,
                        map: map
                    };

                if (map.iconClass) {
                    $toastElement.addClass(options.toastClass).addClass(iconClass);
                }

                if (map.title) {
                    $titleElement.append(map.title).addClass(options.titleClass);
                    $toastElement.append($titleElement);
                }

                if (map.message) {
                    $messageElement.append(map.message).addClass(options.messageClass);
                    $toastElement.append($messageElement);
                }

                if (options.closeButton) {
                    $closeElement.addClass('toast-close-button');
                    $toastElement.prepend($closeElement);
                }

                $toastElement.hide();
                if (options.newestOnTop) {
                    $container.prepend($toastElement);
                } else {
                    $container.append($toastElement);
                }


                $toastElement[options.showMethod](
                    { duration: options.showDuration, easing: options.showEasing, complete: options.onShown }
                );
                if (options.timeOut > 0) {
                    intervalId = setTimeout(hideToast, options.timeOut);
                }

                $toastElement.hover(stickAround, delayedhideToast);
                if (!options.onclick && options.tapToDismiss) {
                    $toastElement.click(hideToast);
                }
                if (options.closeButton && $closeElement) {
                    $closeElement.click(function (event) {
                        event.stopPropagation();
                        hideToast(true);
                    });
                }

                if (options.onclick) {
                    $toastElement.click(function () {
                        options.onclick();
                        hideToast();
                    });
                }

                publish(response);

                if (options.debug && console) {
                    console.log(response);
                }

                return $toastElement;

                function hideToast(override) {
                    if ($(':focus', $toastElement).length && !override) {
                        return;
                    }
                    return $toastElement[options.hideMethod]({
                        duration: options.hideDuration,
                        easing: options.hideEasing,
                        complete: function () {
                            removeToast($toastElement);
                            if (options.onHidden) {
                                options.onHidden();
                            }
                            response.state = 'hidden';
                            response.endTime = new Date(),
                            publish(response);
                        }
                    });
                }

                function delayedhideToast() {
                    if (options.timeOut > 0 || options.extendedTimeOut > 0) {
                        intervalId = setTimeout(hideToast, options.extendedTimeOut);
                    }
                }

                function stickAround() {
                    clearTimeout(intervalId);
                    $toastElement.stop(true, true)[options.showMethod](
                        { duration: options.showDuration, easing: options.showEasing }
                    );
                }
            }
            function getContainer(options) {
                if (!options) { options = getOptions(); }
                $container = $('#' + options.containerId);
                if ($container.length) {
                    return $container;
                }
                $container = $('<div/>')
                    .attr('id', options.containerId)
                    .addClass(options.positionClass);
                $container.appendTo($(options.target));
                return $container;
            }

            function getOptions() {
                return $.extend({}, getDefaults(), toastr.options);
            }

            function removeToast($toastElement) {
                if (!$container) { $container = getContainer(); }
                if ($toastElement.is(':visible')) {
                    return;
                }
                $toastElement.remove();
                $toastElement = null;
                if ($container.children().length === 0) {
                    $container.remove();
                }
            }
            //#endregion

        })();
    });
}(typeof define === 'function' && define.amd ? define : function (deps, factory) {
    if (typeof module !== 'undefined' && module.exports) { //Node
        module.exports = factory(require(deps[0]));
    } else {
        window['toastr'] = factory(window['jQuery']);
    }
}));
