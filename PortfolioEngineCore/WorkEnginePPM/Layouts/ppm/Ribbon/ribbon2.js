$(window).load(function () {
    (function ($) {

        var EPMSliderClass = function (el, opts) {
            var element = $(el);
            var options = opts;
            var isMouseDown = false;
            var currentVal = 0;
            var currentMaxVal = 0;
            var currentMinVal = 0;

            var maxVal = options.maxValue;
            var minVal = options.minValue;
            var rangemaxVal = options.rangemaxValue;
            var rangeminVal = options.rangeminValue;

            var posmaxVal = options.posmaxValue;
            var posminVal = options.posminValue;

            if (minVal == undefined || maxVal == undefined) {
                minVal = 0;
                maxVal = 10;

            }

            if (rangeminVal == undefined || rangemaxVal == undefined) {
                rangeminVal = minVal;
                rangemaxVal = maxVal;

            }

            if (posmaxVal == undefined || posminVal == undefined) {
                posmaxVal = 100;
                posminVal = 0;

            }

            var slidestep = options.step;
            if (slidestep == undefined)
                slidestep = 1;

            var changedfunction = options.onchange;
            if (changedfunction == undefined)
                changedfunction = null;

            if (slidestep <= 0)
                slidestep = 2;

            var stepclicks = Math.round((maxVal - minVal) / slidestep);
            var dispVal = 0;
            var cnt = 0;
            var isMinButton = false;

            var container = $(el).parent();

            container.addClass('epm-slider');

            container.append('<span class="epm-slider-scale"><div class="epm-slider-scalemiddle"/><div class="epm-slider-buttonmin">   <div class="epm-slider-buttonmax"/><div class="epm-slider-tooltip"/></div><div class="epm-slider-minval"/><div class="epm-slider-maxval"/></span>');


            if (typeof (options) != 'undefined' && typeof (options.hideTooltip) != 'undefined' && options.hideTooltip == true) {
                container.find('.epm-slider-tooltip').hide();
            }

            if (typeof (options.width) != 'undefined') {
                container.css('width', (options.width + 'px'));
            }

            currentMinVal = 0;
            currentMaxVal = (container.find('.epm-slider-scale').width() - container.find('.epm-slider-buttonmax').width());
            container.find('.epm-slider-buttonmax').css('left', currentMaxVal);
            container.find('.epm-slider-buttonmin').css('left', '0px');
            container.find('.epm-slider-scalemiddle').width(currentMaxVal);
            container.find('.epm-slider-scalemiddle').css('left', '0px');
            container.find('.epm-slider-minval').html(rangeminVal);
            container.find('.epm-slider-maxval').html(rangemaxVal);



            //            if (rangeminVal > minVal) {
            //                lnewPos = Math.round((rangeminVal / lupperBound) * 100, 0);
            //                currentMinVal = lnewPos;
            //                currentMaxVal = currentMaxVal - (lnewPos);

            //                container.find('.epm-slider-buttonmin').css("left", locationnewPos);
            //                container.find('.epm-slider-buttonmax').css("left", currentMaxVal);
            //            }


            if (posmaxVal == undefined || posminVal == undefined) {

                // could calculate from rangemin and rangemax
                posmaxVal = 100;
                posminVal = 0;

            }

            container.find('.epm-slider-buttonmin').css("left", posminVal);
            container.find('.epm-slider-buttonmax').css("left", posmaxVal);


            var startSlide = function (e) {

                isMouseDown = true;

                currentMinVal = parseInt(container.find('.epm-slider-buttonmin').css("left"));
                currentMaxVal = parseInt(container.find('.epm-slider-buttonmax').css("left"));

                isMinButton = (e.currentTarget.className == "epm-slider-buttonmin");
                var pos = getMousePosition(e);
                startMouseX = pos.x;

                lastElemLeft = ($(this).offset().left - $(this).parent().offset().left);
                updatePosition(e);

                return false;
            };

            var getMousePosition = function (e) {
                //container.animate({ scrollTop: rowHeight }, options.scrollSpeed, 'linear', ScrollComplete());
                var posx = 0;
                var posy = 0;

                if (!e) var e = window.event;

                if (e.pageX || e.pageY) {
                    posx = e.pageX;
                    posy = e.pageY;
                }
                else if (e.clientX || e.clientY) {
                    posx = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft;
                    posy = e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
                }

                return { 'x': posx, 'y': posy };
            };

            var updatePosition = function (e) {

                //		cnt = cnt + 1;

                //		if (cnt == 10)
                //			cnt = 0;

                var pos = getMousePosition(e);

                var spanX = (pos.x - startMouseX);

                var newPos = (lastElemLeft + spanX);
                var upperBound = (container.find('.epm-slider-scale').width() - container.find('.epm-slider-buttonmin').width());

                var entryMin = container.find('.epm-slider-minval').html();
                var entryMax = container.find('.epm-slider-maxval').html();

                if (isMinButton) {

                    var useupperBound = currentMaxVal + currentMinVal;
                    newPos = Math.max(0, newPos);
                    newPos = Math.min(newPos, useupperBound);
                    currentVal = Math.round((newPos / upperBound) * 100, 0);

                    dispVal = Math.round((stepclicks * currentVal) / 100);
                    dispVal = (dispVal * slidestep) + minVal;

                    if (dispVal >= maxVal)
                        dispVal = maxVal;

                    if (dispVal <= minVal)
                        dispVal = minVal;


                    currentMaxVal = currentMaxVal - (newPos - currentMinVal);

                    currentMinVal = newPos
                    container.find('.epm-slider-buttonmin').css("left", newPos);
                    container.find('.epm-slider-buttonmax').css("left", currentMaxVal);

                    container.find('.epm-slider-scalemiddle').width(currentMaxVal);
                    container.find('.epm-slider-scalemiddle').css('left', newPos);

                    container.find('.epm-slider-tooltip').html(dispVal);
                    container.find('.epm-slider-minval').html(dispVal);
                    container.find('.epm-slider-tooltip').css('left', 0);
                }
                else {
                    newPos = Math.max(0, newPos);
                    newPos = Math.min(newPos, upperBound - currentMinVal);
                    currentVal = Math.round(((newPos + currentMinVal) / upperBound) * 100, 0);

                    dispVal = Math.round((stepclicks * currentVal) / 100);
                    dispVal = (dispVal * slidestep) + minVal;

                    if (dispVal >= maxVal)
                        dispVal = maxVal;

                    if (dispVal <= minVal)
                        dispVal = minVal;

                    currentMaxVal = newPos;

                    container.find('.epm-slider-buttonmax').css("left", newPos);
                    container.find('.epm-slider-tooltip').html(dispVal);
                    container.find('.epm-slider-maxval').html(dispVal);
                    container.find('.epm-slider-tooltip').css('left', newPos);
                    container.find('.epm-slider-scalemiddle').width(newPos);
                }

                try {
                    if ((entryMin != container.find('.epm-slider-minval').html()) || (entryMax != container.find('.epm-slider-maxval').html())) {
                        if (changedfunction != null)
                            eval(changedfunction)();
                    }
                }
                catch (e) { }
            };

            var moving = function (e) {
                if (isMouseDown) {
                    updatePosition(e);
                    return false;
                }
            };

            var dropCallback = function (e) {
                isMouseDown = false;
                element.val(currentVal);
                if (typeof element.options != 'undefined' && typeof element.options.onChanged == 'function') {
                    element.options.onChanged.call(this, null);
                }

            };

            container.find('.epm-slider-buttonmin').bind('mousedown', startSlide);
            container.find('.epm-slider-buttonmax').bind('mousedown', startSlide);

            $(document).mousemove(function (e) { moving(e); });
            $(document).mouseup(function (e) { dropCallback(e); });

        };

        /*******************************************************************************************************/

        $.fn.EPMSlider = function (options) {
            var opts = $.extend({}, $.fn.EPMSlider.defaults, options);

            return this.each(function () {
                new EPMSliderClass($(this), opts);
            });
        }

        $.fn.EPMSlider.defaults = {
            width: 100
        };


    })(jQuery);
});

(function ($, undefined) {

    var uuid = 0,
	runiqueId = /^ui-id-\d+$/;

    // prevent duplicate loading
    // this is only a problem because we proxy existing functions
    // and we don't want to double proxy them
    $.ui = $.ui || {};
    if ($.ui.version) {
        return;
    }

    $.extend($.ui, {
        version: "1.10.1",

        keyCode: {
            BACKSPACE: 8,
            COMMA: 188,
            DELETE: 46,
            DOWN: 40,
            END: 35,
            ENTER: 13,
            ESCAPE: 27,
            HOME: 36,
            LEFT: 37,
            NUMPAD_ADD: 107,
            NUMPAD_DECIMAL: 110,
            NUMPAD_DIVIDE: 111,
            NUMPAD_ENTER: 108,
            NUMPAD_MULTIPLY: 106,
            NUMPAD_SUBTRACT: 109,
            PAGE_DOWN: 34,
            PAGE_UP: 33,
            PERIOD: 190,
            RIGHT: 39,
            SPACE: 32,
            TAB: 9,
            UP: 38
        }
    });

    // plugins
    $.fn.extend({
        _focus: $.fn.focus,
        focus: function (delay, fn) {
            return typeof delay === "number" ?
			this.each(function () {
			    var elem = this;
			    setTimeout(function () {
			        $(elem).focus();
			        if (fn) {
			            fn.call(elem);
			        }
			    }, delay);
			}) :
			this._focus.apply(this, arguments);
        },

        scrollParent: function () {
            var scrollParent;
            if (($.ui.ie && (/(static|relative)/).test(this.css("position"))) || (/absolute/).test(this.css("position"))) {
                scrollParent = this.parents().filter(function () {
                    return (/(relative|absolute|fixed)/).test($.css(this, "position")) && (/(auto|scroll)/).test($.css(this, "overflow") + $.css(this, "overflow-y") + $.css(this, "overflow-x"));
                }).eq(0);
            } else {
                scrollParent = this.parents().filter(function () {
                    return (/(auto|scroll)/).test($.css(this, "overflow") + $.css(this, "overflow-y") + $.css(this, "overflow-x"));
                }).eq(0);
            }

            return (/fixed/).test(this.css("position")) || !scrollParent.length ? $(document) : scrollParent;
        },

        zIndex: function (zIndex) {
            if (zIndex !== undefined) {
                return this.css("zIndex", zIndex);
            }

            if (this.length) {
                var elem = $(this[0]), position, value;
                while (elem.length && elem[0] !== document) {
                    // Ignore z-index if position is set to a value where z-index is ignored by the browser
                    // This makes behavior of this function consistent across browsers
                    // WebKit always returns auto if the element is positioned
                    position = elem.css("position");
                    if (position === "absolute" || position === "relative" || position === "fixed") {
                        // IE returns 0 when zIndex is not specified
                        // other browsers return a string
                        // we ignore the case of nested elements with an explicit value of 0
                        // <div style="z-index: -10;"><div style="z-index: 0;"></div></div>
                        value = parseInt(elem.css("zIndex"), 10);
                        if (!isNaN(value) && value !== 0) {
                            return value;
                        }
                    }
                    elem = elem.parent();
                }
            }

            return 0;
        },

        uniqueId: function () {
            return this.each(function () {
                if (!this.id) {
                    this.id = "ui-id-" + (++uuid);
                }
            });
        },

        removeUniqueId: function () {
            return this.each(function () {
                if (runiqueId.test(this.id)) {
                    $(this).removeAttr("id");
                }
            });
        }
    });

    // selectors
    function focusable(element, isTabIndexNotNaN) {
        var map, mapName, img,
		nodeName = element.nodeName.toLowerCase();
        if ("area" === nodeName) {
            map = element.parentNode;
            mapName = map.name;
            if (!element.href || !mapName || map.nodeName.toLowerCase() !== "map") {
                return false;
            }
            img = $("img[usemap=#" + mapName + "]")[0];
            return !!img && visible(img);
        }
        return (/input|select|textarea|button|object/.test(nodeName) ?
		!element.disabled :
		"a" === nodeName ?
			element.href || isTabIndexNotNaN :
			isTabIndexNotNaN) &&
        // the element and all of its ancestors must be visible
		visible(element);
    }

    function visible(element) {
        return $.expr.filters.visible(element) &&
		!$(element).parents().addBack().filter(function () {
		    return $.css(this, "visibility") === "hidden";
		}).length;
    }

    $.extend($.expr[":"], {
        data: $.expr.createPseudo ?
		$.expr.createPseudo(function (dataName) {
		    return function (elem) {
		        return !!$.data(elem, dataName);
		    };
		}) :
        // support: jQuery <1.8
		function (elem, i, match) {
		    return !!$.data(elem, match[3]);
		},

        focusable: function (element) {
            return focusable(element, !isNaN($.attr(element, "tabindex")));
        },

        tabbable: function (element) {
            var tabIndex = $.attr(element, "tabindex"),
			isTabIndexNaN = isNaN(tabIndex);
            return (isTabIndexNaN || tabIndex >= 0) && focusable(element, !isTabIndexNaN);
        }
    });

    // support: jQuery <1.8
    if (!$("<a>").outerWidth(1).jquery) {
        $.each(["Width", "Height"], function (i, name) {
            var side = name === "Width" ? ["Left", "Right"] : ["Top", "Bottom"],
			type = name.toLowerCase(),
			orig = {
			    innerWidth: $.fn.innerWidth,
			    innerHeight: $.fn.innerHeight,
			    outerWidth: $.fn.outerWidth,
			    outerHeight: $.fn.outerHeight
			};

            function reduce(elem, size, border, margin) {
                $.each(side, function () {
                    size -= parseFloat($.css(elem, "padding" + this)) || 0;
                    if (border) {
                        size -= parseFloat($.css(elem, "border" + this + "Width")) || 0;
                    }
                    if (margin) {
                        size -= parseFloat($.css(elem, "margin" + this)) || 0;
                    }
                });
                return size;
            }

            $.fn["inner" + name] = function (size) {
                if (size === undefined) {
                    return orig["inner" + name].call(this);
                }

                return this.each(function () {
                    $(this).css(type, reduce(this, size) + "px");
                });
            };

            $.fn["outer" + name] = function (size, margin) {
                if (typeof size !== "number") {
                    return orig["outer" + name].call(this, size);
                }

                return this.each(function () {
                    $(this).css(type, reduce(this, size, true, margin) + "px");
                });
            };
        });
    }

    // support: jQuery <1.8
    if (!$.fn.addBack) {
        $.fn.addBack = function (selector) {
            return this.add(selector == null ?
			this.prevObject : this.prevObject.filter(selector)
		);
        };
    }

    // support: jQuery 1.6.1, 1.6.2 (http://bugs.jquery.com/ticket/9413)
    if ($("<a>").data("a-b", "a").removeData("a-b").data("a-b")) {
        $.fn.removeData = (function (removeData) {
            return function (key) {
                if (arguments.length) {
                    return removeData.call(this, $.camelCase(key));
                } else {
                    return removeData.call(this);
                }
            };
        })($.fn.removeData);
    }





    // deprecated
    $.ui.ie = !!/msie [\w.]+/.exec(navigator.userAgent.toLowerCase());

    $.support.selectstart = "onselectstart" in document.createElement("div");
    $.fn.extend({
        disableSelection: function () {
            return this.bind(($.support.selectstart ? "selectstart" : "mousedown") +
			".ui-disableSelection", function (event) {
			    event.preventDefault();
			});
        },

        enableSelection: function () {
            return this.unbind(".ui-disableSelection");
        }
    });

    $.extend($.ui, {
        // $.ui.plugin is deprecated.  Use the proxy pattern instead.
        plugin: {
            add: function (module, option, set) {
                var i,
				proto = $.ui[module].prototype;
                for (i in set) {
                    proto.plugins[i] = proto.plugins[i] || [];
                    proto.plugins[i].push([option, set[i]]);
                }
            },
            call: function (instance, name, args) {
                var i,
				set = instance.plugins[name];
                if (!set || !instance.element[0].parentNode || instance.element[0].parentNode.nodeType === 11) {
                    return;
                }

                for (i = 0; i < set.length; i++) {
                    if (instance.options[set[i][0]]) {
                        set[i][1].apply(instance.element, args);
                    }
                }
            }
        },

        // only used by resizable
        hasScroll: function (el, a) {

            //If overflow is hidden, the element might have extra content, but the user wants to hide it
            if ($(el).css("overflow") === "hidden") {
                return false;
            }

            var scroll = (a && a === "left") ? "scrollLeft" : "scrollTop",
			has = false;

            if (el[scroll] > 0) {
                return true;
            }

            // TODO: determine which cases actually cause this to happen
            // if the element doesn't have the scroll set, see if it's possible to
            // set the scroll
            el[scroll] = 1;
            has = (el[scroll] > 0);
            el[scroll] = 0;
            return has;
        }
    });

})(jQuery);
(function ($, undefined) {

    var uuid = 0,
	slice = Array.prototype.slice,
	_cleanData = $.cleanData;
    $.cleanData = function (elems) {
        for (var i = 0, elem; (elem = elems[i]) != null; i++) {
            try {
                $(elem).triggerHandler("remove");
                // http://bugs.jquery.com/ticket/8235
            } catch (e) { }
        }
        _cleanData(elems);
    };

    $.widget = function (name, base, prototype) {
        var fullName, existingConstructor, constructor, basePrototype,
        // proxiedPrototype allows the provided prototype to remain unmodified
        // so that it can be used as a mixin for multiple widgets (#8876)
		proxiedPrototype = {},
		namespace = name.split(".")[0];

        name = name.split(".")[1];
        fullName = namespace + "-" + name;

        if (!prototype) {
            prototype = base;
            base = $.Widget;
        }

        // create selector for plugin
        $.expr[":"][fullName.toLowerCase()] = function (elem) {
            return !!$.data(elem, fullName);
        };

        $[namespace] = $[namespace] || {};
        existingConstructor = $[namespace][name];
        constructor = $[namespace][name] = function (options, element) {
            // allow instantiation without "new" keyword
            if (!this._createWidget) {
                return new constructor(options, element);
            }

            // allow instantiation without initializing for simple inheritance
            // must use "new" keyword (the code above always passes args)
            if (arguments.length) {
                this._createWidget(options, element);
            }
        };
        // extend with the existing constructor to carry over any static properties
        $.extend(constructor, existingConstructor, {
            version: prototype.version,
            // copy the object used to create the prototype in case we need to
            // redefine the widget later
            _proto: $.extend({}, prototype),
            // track widgets that inherit from this widget in case this widget is
            // redefined after a widget inherits from it
            _childConstructors: []
        });

        basePrototype = new base();
        // we need to make the options hash a property directly on the new instance
        // otherwise we'll modify the options hash on the prototype that we're
        // inheriting from
        basePrototype.options = $.widget.extend({}, basePrototype.options);
        $.each(prototype, function (prop, value) {
            if (!$.isFunction(value)) {
                proxiedPrototype[prop] = value;
                return;
            }
            proxiedPrototype[prop] = (function () {
                var _super = function () {
                    return base.prototype[prop].apply(this, arguments);
                },
				_superApply = function (args) {
				    return base.prototype[prop].apply(this, args);
				};
                return function () {
                    var __super = this._super,
					__superApply = this._superApply,
					returnValue;

                    this._super = _super;
                    this._superApply = _superApply;

                    returnValue = value.apply(this, arguments);

                    this._super = __super;
                    this._superApply = __superApply;

                    return returnValue;
                };
            })();
        });
        constructor.prototype = $.widget.extend(basePrototype, {
            // TODO: remove support for widgetEventPrefix
            // always use the name + a colon as the prefix, e.g., draggable:start
            // don't prefix for widgets that aren't DOM-based
            widgetEventPrefix: existingConstructor ? basePrototype.widgetEventPrefix : name
        }, proxiedPrototype, {
            constructor: constructor,
            namespace: namespace,
            widgetName: name,
            widgetFullName: fullName
        });

        // If this widget is being redefined then we need to find all widgets that
        // are inheriting from it and redefine all of them so that they inherit from
        // the new version of this widget. We're essentially trying to replace one
        // level in the prototype chain.
        if (existingConstructor) {
            $.each(existingConstructor._childConstructors, function (i, child) {
                var childPrototype = child.prototype;

                // redefine the child widget using the same prototype that was
                // originally used, but inherit from the new version of the base
                $.widget(childPrototype.namespace + "." + childPrototype.widgetName, constructor, child._proto);
            });
            // remove the list of existing child constructors from the old constructor
            // so the old child constructors can be garbage collected
            delete existingConstructor._childConstructors;
        } else {
            base._childConstructors.push(constructor);
        }

        $.widget.bridge(name, constructor);
    };

    $.widget.extend = function (target) {
        var input = slice.call(arguments, 1),
		inputIndex = 0,
		inputLength = input.length,
		key,
		value;
        for (; inputIndex < inputLength; inputIndex++) {
            for (key in input[inputIndex]) {
                value = input[inputIndex][key];
                if (input[inputIndex].hasOwnProperty(key) && value !== undefined) {
                    // Clone objects
                    if ($.isPlainObject(value)) {
                        target[key] = $.isPlainObject(target[key]) ?
						$.widget.extend({}, target[key], value) :
                        // Don't extend strings, arrays, etc. with objects
						$.widget.extend({}, value);
                        // Copy everything else by reference
                    } else {
                        target[key] = value;
                    }
                }
            }
        }
        return target;
    };

    $.widget.bridge = function (name, object) {
        var fullName = object.prototype.widgetFullName || name;
        $.fn[name] = function (options) {
            var isMethodCall = typeof options === "string",
			args = slice.call(arguments, 1),
			returnValue = this;

            // allow multiple hashes to be passed on init
            options = !isMethodCall && args.length ?
			$.widget.extend.apply(null, [options].concat(args)) :
			options;

            if (isMethodCall) {
                this.each(function () {
                    var methodValue,
					instance = $.data(this, fullName);
                    if (!instance) {
                        return $.error("cannot call methods on " + name + " prior to initialization; " +
						"attempted to call method '" + options + "'");
                    }
                    if (!$.isFunction(instance[options]) || options.charAt(0) === "_") {
                        return $.error("no such method '" + options + "' for " + name + " widget instance");
                    }
                    methodValue = instance[options].apply(instance, args);
                    if (methodValue !== instance && methodValue !== undefined) {
                        returnValue = methodValue && methodValue.jquery ?
						returnValue.pushStack(methodValue.get()) :
						methodValue;
                        return false;
                    }
                });
            } else {
                this.each(function () {
                    var instance = $.data(this, fullName);
                    if (instance) {
                        instance.option(options || {})._init();
                    } else {
                        $.data(this, fullName, new object(options, this));
                    }
                });
            }

            return returnValue;
        };
    };

    $.Widget = function ( /* options, element */) { };
    $.Widget._childConstructors = [];

    $.Widget.prototype = {
        widgetName: "widget",
        widgetEventPrefix: "",
        defaultElement: "<div>",
        options: {
            disabled: false,

            // callbacks
            create: null
        },
        _createWidget: function (options, element) {
            element = $(element || this.defaultElement || this)[0];
            this.element = $(element);
            this.uuid = uuid++;
            this.eventNamespace = "." + this.widgetName + this.uuid;
            this.options = $.widget.extend({},
			this.options,
			this._getCreateOptions(),
			options);

            this.bindings = $();
            this.hoverable = $();
            this.focusable = $();

            if (element !== this) {
                $.data(element, this.widgetFullName, this);
                this._on(true, this.element, {
                    remove: function (event) {
                        if (event.target === element) {
                            this.destroy();
                        }
                    }
                });
                this.document = $(element.style ?
                // element within the document
				element.ownerDocument :
                // element is window or document
				element.document || element);
                this.window = $(this.document[0].defaultView || this.document[0].parentWindow);
            }

            this._create();
            this._trigger("create", null, this._getCreateEventData());
            this._init();
        },
        _getCreateOptions: $.noop,
        _getCreateEventData: $.noop,
        _create: $.noop,
        _init: $.noop,

        destroy: function () {
            this._destroy();
            // we can probably remove the unbind calls in 2.0
            // all event bindings should go through this._on()
            this.element
			.unbind(this.eventNamespace)
            // 1.9 BC for #7810
            // TODO remove dual storage
			.removeData(this.widgetName)
			.removeData(this.widgetFullName)
            // support: jquery <1.6.3
            // http://bugs.jquery.com/ticket/9413
			.removeData($.camelCase(this.widgetFullName));
            this.widget()
			.unbind(this.eventNamespace)
			.removeAttr("aria-disabled")
			.removeClass(
				this.widgetFullName + "-disabled " +
				"ui-state-disabled");

            // clean up events and states
            this.bindings.unbind(this.eventNamespace);
            this.hoverable.removeClass("ui-state-hover");
            this.focusable.removeClass("ui-state-focus");
        },
        _destroy: $.noop,

        widget: function () {
            return this.element;
        },

        option: function (key, value) {
            var options = key,
			parts,
			curOption,
			i;

            if (arguments.length === 0) {
                // don't return a reference to the internal hash
                return $.widget.extend({}, this.options);
            }

            if (typeof key === "string") {
                // handle nested keys, e.g., "foo.bar" => { foo: { bar: ___ } }
                options = {};
                parts = key.split(".");
                key = parts.shift();
                if (parts.length) {
                    curOption = options[key] = $.widget.extend({}, this.options[key]);
                    for (i = 0; i < parts.length - 1; i++) {
                        curOption[parts[i]] = curOption[parts[i]] || {};
                        curOption = curOption[parts[i]];
                    }
                    key = parts.pop();
                    if (value === undefined) {
                        return curOption[key] === undefined ? null : curOption[key];
                    }
                    curOption[key] = value;
                } else {
                    if (value === undefined) {
                        return this.options[key] === undefined ? null : this.options[key];
                    }
                    options[key] = value;
                }
            }

            this._setOptions(options);

            return this;
        },
        _setOptions: function (options) {
            var key;

            for (key in options) {
                this._setOption(key, options[key]);
            }

            return this;
        },
        _setOption: function (key, value) {
            this.options[key] = value;

            if (key === "disabled") {
                this.widget()
				.toggleClass(this.widgetFullName + "-disabled ui-state-disabled", !!value)
				.attr("aria-disabled", value);
                this.hoverable.removeClass("ui-state-hover");
                this.focusable.removeClass("ui-state-focus");
            }

            return this;
        },

        enable: function () {
            return this._setOption("disabled", false);
        },
        disable: function () {
            return this._setOption("disabled", true);
        },

        _on: function (suppressDisabledCheck, element, handlers) {
            var delegateElement,
			instance = this;

            // no suppressDisabledCheck flag, shuffle arguments
            if (typeof suppressDisabledCheck !== "boolean") {
                handlers = element;
                element = suppressDisabledCheck;
                suppressDisabledCheck = false;
            }

            // no element argument, shuffle and use this.element
            if (!handlers) {
                handlers = element;
                element = this.element;
                delegateElement = this.widget();
            } else {
                // accept selectors, DOM elements
                element = delegateElement = $(element);
                this.bindings = this.bindings.add(element);
            }

            $.each(handlers, function (event, handler) {
                function handlerProxy() {
                    // allow widgets to customize the disabled handling
                    // - disabled as an array instead of boolean
                    // - disabled class as method for disabling individual parts
                    if (!suppressDisabledCheck &&
						(instance.options.disabled === true ||
							$(this).hasClass("ui-state-disabled"))) {
                        return;
                    }
                    return (typeof handler === "string" ? instance[handler] : handler)
					.apply(instance, arguments);
                }

                // copy the guid so direct unbinding works
                if (typeof handler !== "string") {
                    handlerProxy.guid = handler.guid =
					handler.guid || handlerProxy.guid || $.guid++;
                }

                var match = event.match(/^(\w+)\s*(.*)$/),
				eventName = match[1] + instance.eventNamespace,
				selector = match[2];
                if (selector) {
                    delegateElement.delegate(selector, eventName, handlerProxy);
                } else {
                    element.bind(eventName, handlerProxy);
                }
            });
        },

        _off: function (element, eventName) {
            eventName = (eventName || "").split(" ").join(this.eventNamespace + " ") + this.eventNamespace;
            element.unbind(eventName).undelegate(eventName);
        },

        _delay: function (handler, delay) {
            function handlerProxy() {
                return (typeof handler === "string" ? instance[handler] : handler)
				.apply(instance, arguments);
            }
            var instance = this;
            return setTimeout(handlerProxy, delay || 0);
        },

        _hoverable: function (element) {
            this.hoverable = this.hoverable.add(element);
            this._on(element, {
                mouseenter: function (event) {
                    $(event.currentTarget).addClass("ui-state-hover");
                },
                mouseleave: function (event) {
                    $(event.currentTarget).removeClass("ui-state-hover");
                }
            });
        },

        _focusable: function (element) {
            this.focusable = this.focusable.add(element);
            this._on(element, {
                focusin: function (event) {
                    $(event.currentTarget).addClass("ui-state-focus");
                },
                focusout: function (event) {
                    $(event.currentTarget).removeClass("ui-state-focus");
                }
            });
        },

        _trigger: function (type, event, data) {
            var prop, orig,
			callback = this.options[type];

            data = data || {};
            event = $.Event(event);
            event.type = (type === this.widgetEventPrefix ?
			type :
			this.widgetEventPrefix + type).toLowerCase();
            // the original event may come from any element
            // so we need to reset the target on the new event
            event.target = this.element[0];

            // copy original event properties over to the new event
            orig = event.originalEvent;
            if (orig) {
                for (prop in orig) {
                    if (!(prop in event)) {
                        event[prop] = orig[prop];
                    }
                }
            }

            this.element.trigger(event, data);
            return !($.isFunction(callback) &&
			callback.apply(this.element[0], [event].concat(data)) === false ||
			event.isDefaultPrevented());
        }
    };

    $.each({ show: "fadeIn", hide: "fadeOut" }, function (method, defaultEffect) {
        $.Widget.prototype["_" + method] = function (element, options, callback) {
            if (typeof options === "string") {
                options = { effect: options };
            }
            var hasOptions,
			effectName = !options ?
				method :
				options === true || typeof options === "number" ?
					defaultEffect :
					options.effect || defaultEffect;
            options = options || {};
            if (typeof options === "number") {
                options = { duration: options };
            }
            hasOptions = !$.isEmptyObject(options);
            options.complete = callback;
            if (options.delay) {
                element.delay(options.delay);
            }
            if (hasOptions && $.effects && $.effects.effect[effectName]) {
                element[method](options);
            } else if (effectName !== method && element[effectName]) {
                element[effectName](options.duration, options.easing, callback);
            } else {
                element.queue(function (next) {
                    $(this)[method]();
                    if (callback) {
                        callback.call(element[0]);
                    }
                    next();
                });
            }
        };
    });

})(jQuery);


(function ($, undefined) {

    var multiselectID = 0;

    $.widget("ech.multiselect", {

        // default options
        options: {
            header: true,
            height: 175,
            minWidth: 120,
            classes: '',
            checkAllText: 'Check all',
            uncheckAllText: 'Uncheck all',
            noneSelectedText: '# of # selected',
            selectedText: '# of # selected',
            selectedList: 0,
            show: null,
            hide: null,
            autoOpen: false,
            multiple: true,
            position: {}
        },

        _create: function () {
            var el = this.element.hide(),
			o = this.options;

            this.speed = $.fx.speeds._default; // default speed for effects
            this._isOpen = false; // assume no

            var 
			button = (this.button = $('<button type="button"><span class="ui-icon ui-icon-triangle-2-n-s"></span></button>'))
				.addClass('ui-multiselect ui-widget ui-state-default ui-corner-all')
				.addClass(o.classes)
				.attr({ 'title': el.attr('title'), 'aria-haspopup': true, 'tabIndex': el.attr('tabIndex') })
				.insertAfter(el),

			buttonlabel = (this.buttonlabel = $('<span />'))
				.html(o.noneSelectedText)
				.appendTo(button),

			menu = (this.menu = $('<div />'))
				.addClass('ui-multiselect-menu ui-widget ui-widget-content ui-corner-all')
				.addClass(o.classes)
				.appendTo(document.body),

			header = (this.header = $('<div />'))
				.addClass('ui-widget-header ui-corner-all ui-multiselect-header ui-helper-clearfix')
				.appendTo(menu),

			headerLinkContainer = (this.headerLinkContainer = $('<ul />'))
				.addClass('ui-helper-reset')
				.html(function () {
				    if (o.header === true) {
				        return '<li><a class="ui-multiselect-all" href="#"><span class="ui-icon ui-icon-check"></span><span>' + o.checkAllText + '</span></a></li><li><a class="ui-multiselect-none" href="#"><span class="ui-icon ui-icon-closethick"></span><span>' + o.uncheckAllText + '</span></a></li>';
				    } else if (typeof o.header === "string") {
				        return '<li>' + o.header + '</li>';
				    } else {
				        return '';
				    }
				})
				.append('<li class="ui-multiselect-close"><a href="#" class="ui-multiselect-close"><span class="ui-icon ui-icon-circle-close"></span></a></li>')
				.appendTo(header),

			checkboxContainer = (this.checkboxContainer = $('<ul />'))
				.addClass('ui-multiselect-checkboxes ui-helper-reset')
				.appendTo(menu);

            // perform event bindings
            this._bindEvents();

            // build menu
            this.refresh(true);

            // some addl. logic for single selects
            if (!o.multiple) {
                menu.addClass('ui-multiselect-single');
            }
        },

        _init: function () {
            if (this.options.header === false) {
                this.header.hide();
            }
            if (!this.options.multiple) {
                this.headerLinkContainer.find('.ui-multiselect-all, .ui-multiselect-none').hide();
            }
            if (this.options.autoOpen) {
                this.open();
            }
            if (this.element.is(':disabled')) {
                this.disable();
            }
        },

        refresh: function (init) {
            var el = this.element,
			o = this.options,
			menu = this.menu,
			checkboxContainer = this.checkboxContainer,
			optgroups = [],
			html = "",
			id = el.attr('id') || multiselectID++; // unique ID for the label & option tags

            // build items
            el.find('option').each(function (i) {
                var $this = $(this),
				parent = this.parentNode,
				title = this.innerHTML,
				description = this.title,
				value = this.value,
				inputID = 'ui-multiselect-' + (this.id || id + '-option-' + i),
				isDisabled = this.disabled,
				isSelected = this.selected,
				labelClasses = ['ui-corner-all'],
				liClasses = (isDisabled ? 'ui-multiselect-disabled ' : ' ') + this.className,
				optLabel;

                // is this an optgroup?
                if (parent.tagName === 'OPTGROUP') {
                    optLabel = parent.getAttribute('label');

                    // has this optgroup been added already?
                    if ($.inArray(optLabel, optgroups) === -1) {
                        html += '<li class="ui-multiselect-optgroup-label ' + parent.className + '"><a href="#">' + optLabel + '</a></li>';
                        optgroups.push(optLabel);
                    }
                }

                if (isDisabled) {
                    labelClasses.push('ui-state-disabled');
                }

                // browsers automatically select the first option
                // by default with single selects
                if (isSelected && !o.multiple) {
                    labelClasses.push('ui-state-active');
                }

                html += '<li class="' + liClasses + '">';

                // create the label
                html += '<label for="' + inputID + '" title="' + description + '" class="' + labelClasses.join(' ') + '">';
                html += '<input id="' + inputID + '" name="multiselect_' + id + '" type="' + (o.multiple ? "checkbox" : "radio") + '" value="' + value + '" title="' + title + '"';

                // pre-selected?
                if (isSelected) {
                    html += ' checked="checked"';
                    html += ' aria-selected="true"';
                }

                // disabled?
                if (isDisabled) {
                    html += ' disabled="disabled"';
                    html += ' aria-disabled="true"';
                }

                // add the title and close everything off
                html += ' /><span>' + title + '</span></label></li>';
            });

            // insert into the DOM
            checkboxContainer.html(html);

            // cache some moar useful elements
            this.labels = menu.find('label');
            this.inputs = this.labels.children('input');

            // set widths
            this._setButtonWidth();
            this._setMenuWidth();

            // remember default value
            this.button[0].defaultValue = this.update();

            // broadcast refresh event; useful for widgets
            if (!init) {
                this._trigger('refresh');
            }
        },

        // updates the button text. call refresh() to rebuild
        update: function () {
            var o = this.options,
			$inputs = this.inputs,
			$checked = $inputs.filter(':checked'),
			numChecked = $checked.length,
			value;

            if (numChecked === 0) {
                value = o.noneSelectedText;
            } else {
                if ($.isFunction(o.selectedText)) {
                    value = o.selectedText.call(this, numChecked, $inputs.length, $checked.get());
                } else if (/\d/.test(o.selectedList) && o.selectedList > 0 && numChecked <= o.selectedList) {
                    value = $checked.map(function () { return $(this).next().html(); }).get().join(', ');
                } else {
                    value = o.selectedText.replace('#', numChecked).replace('#', $inputs.length);
                }
            }

            this.buttonlabel.html(value);
            return value;
        },

        // binds events
        _bindEvents: function () {
            var self = this, button = this.button;

            function clickHandler() {
                self[self._isOpen ? 'close' : 'open']();
                return false;
            }

            // webkit doesn't like it when you click on the span :(
            button
			.find('span')
			.bind('click.multiselect', clickHandler);

            // button events
            button.bind({
                click: clickHandler,
                keypress: function (e) {
                    switch (e.which) {
                        case 27: // esc
                        case 38: // up
                        case 37: // left
                            self.close();
                            break;
                        case 39: // right
                        case 40: // down
                            self.open();
                            break;
                    }
                },
                mouseenter: function () {
                    if (!button.hasClass('ui-state-disabled')) {
                        $(this).addClass('ui-state-hover');
                    }
                },
                mouseleave: function () {
                    $(this).removeClass('ui-state-hover');
                },
                focus: function () {
                    if (!button.hasClass('ui-state-disabled')) {
                        $(this).addClass('ui-state-focus');
                    }
                },
                blur: function () {
                    $(this).removeClass('ui-state-focus');
                }
            });

            // header links
            this.header
			.delegate('a', 'click.multiselect', function (e) {
			    // close link
			    if ($(this).hasClass('ui-multiselect-close')) {
			        self.close();

			        // check all / uncheck all
			    } else {
			        self[$(this).hasClass('ui-multiselect-all') ? 'checkAll' : 'uncheckAll']();
			    }

			    e.preventDefault();
			});

            // optgroup label toggle support
            this.menu
			.delegate('li.ui-multiselect-optgroup-label a', 'click.multiselect', function (e) {
			    e.preventDefault();

			    var $this = $(this),
					$inputs = $this.parent().nextUntil('li.ui-multiselect-optgroup-label').find('input:visible:not(:disabled)'),
					nodes = $inputs.get(),
					label = $this.parent().text();

			    // trigger event and bail if the return is false
			    if (self._trigger('beforeoptgrouptoggle', e, { inputs: nodes, label: label }) === false) {
			        return;
			    }

			    // toggle inputs
			    self._toggleChecked(
					$inputs.filter(':checked').length !== $inputs.length,
					$inputs
				);

			    self._trigger('optgrouptoggle', e, {
			        inputs: nodes,
			        label: label,
			        checked: nodes[0].checked
			    });
			})
			.delegate('label', 'mouseenter.multiselect', function () {
			    if (!$(this).hasClass('ui-state-disabled')) {
			        self.labels.removeClass('ui-state-hover');
			        $(this).addClass('ui-state-hover').find('input').focus();
			    }
			})
			.delegate('label', 'keydown.multiselect', function (e) {
			    e.preventDefault();

			    switch (e.which) {
			        case 9: // tab
			        case 27: // esc
			            self.close();
			            break;
			        case 38: // up
			        case 40: // down
			        case 37: // left
			        case 39: // right
			            self._traverse(e.which, this);
			            break;
			        case 13: // enter
			            $(this).find('input')[0].click();
			            break;
			    }
			})
			.delegate('input[type="checkbox"], input[type="radio"]', 'click.multiselect', function (e) {
			    var $this = $(this),
					val = this.value,
					checked = this.checked,
					tags = self.element.find('option');

			    // bail if this input is disabled or the event is cancelled
			    if (this.disabled || self._trigger('click', e, { value: val, text: this.title, checked: checked }) === false) {
			        e.preventDefault();
			        return;
			    }

			    // make sure the input has focus. otherwise, the esc key
			    // won't close the menu after clicking an item.
			    $this.focus();

			    // toggle aria state
			    $this.attr('aria-selected', checked);

			    // change state on the original option tags
			    tags.each(function () {
			        if (this.value === val) {
			            this.selected = checked;
			        } else if (!self.options.multiple) {
			            this.selected = false;
			        }
			    });

			    // some additional single select-specific logic
			    if (!self.options.multiple) {
			        self.labels.removeClass('ui-state-active');
			        $this.closest('label').toggleClass('ui-state-active', checked);

			        // close menu
			        self.close();
			    }

			    // fire change on the select box
			    self.element.trigger("change");

			    // setTimeout is to fix multiselect issue #14 and #47. caused by jQuery issue #3827
			    // http://bugs.jquery.com/ticket/3827
			    setTimeout($.proxy(self.update, self), 10);
			});

            // close each widget when clicking on any other element/anywhere else on the page
            $(document).bind('mousedown.multiselect', function (e) {
                if (self._isOpen && !$.contains(self.menu[0], e.target) && !$.contains(self.button[0], e.target) && e.target !== self.button[0]) {
                    self.close();
                }
            });

            // deal with form resets.  the problem here is that buttons aren't
            // restored to their defaultValue prop on form reset, and the reset
            // handler fires before the form is actually reset.  delaying it a bit
            // gives the form inputs time to clear.
            $(this.element[0].form).bind('reset.multiselect', function () {
                setTimeout($.proxy(self.refresh, self), 10);
            });
        },

        // set button width
        _setButtonWidth: function () {
            var width = this.element.outerWidth(),
			o = this.options;

            if (/\d/.test(o.minWidth) && width < o.minWidth) {
                width = o.minWidth;
            }

            // set widths
            this.button.width(width);
        },

        // set menu width
        _setMenuWidth: function () {
            var m = this.menu,
			width = this.button.outerWidth() -
				parseInt(m.css('padding-left'), 10) -
				parseInt(m.css('padding-right'), 10) -
				parseInt(m.css('border-right-width'), 10) -
				parseInt(m.css('border-left-width'), 10);

            m.width(width || this.button.outerWidth());
        },

        // move up or down within the menu
        _traverse: function (which, start) {
            var $start = $(start),
			moveToLast = which === 38 || which === 37,

            // select the first li that isn't an optgroup label / disabled
			$next = $start.parent()[moveToLast ? 'prevAll' : 'nextAll']('li:not(.ui-multiselect-disabled, .ui-multiselect-optgroup-label)')[moveToLast ? 'last' : 'first']();

            // if at the first/last element
            if (!$next.length) {
                var $container = this.menu.find('ul').last();

                // move to the first/last
                this.menu.find('label')[moveToLast ? 'last' : 'first']().trigger('mouseover');

                // set scroll position
                $container.scrollTop(moveToLast ? $container.height() : 0);

            } else {
                $next.find('label').trigger('mouseover');
            }
        },

        // This is an internal function to toggle the checked property and
        // other related attributes of a checkbox.
        //
        // The context of this function should be a checkbox; do not proxy it.
        _toggleState: function (prop, flag) {
            return function () {
                if (!this.disabled) {
                    this[prop] = flag;
                }

                if (flag) {
                    this.setAttribute('aria-selected', true);
                } else {
                    this.removeAttribute('aria-selected');
                }
            };
        },

        _toggleChecked: function (flag, group) {
            var $inputs = (group && group.length) ? group : this.inputs,
			self = this;

            // toggle state on inputs
            $inputs.each(this._toggleState('checked', flag));

            // give the first input focus
            $inputs.eq(0).focus();

            // update button text
            this.update();

            // gather an array of the values that actually changed
            var values = $inputs.map(function () {
                return this.value;
            }).get();

            // toggle state on original option tags
            this.element
			.find('option')
			.each(function () {
			    if (!this.disabled && $.inArray(this.value, values) > -1) {
			        self._toggleState('selected', flag).call(this);
			    }
			});

            // trigger the change event on the select
            if ($inputs.length) {
                this.element.trigger("change");
            }
        },

        _toggleDisabled: function (flag) {
            this.button
			.attr({ 'disabled': flag, 'aria-disabled': flag })[flag ? 'addClass' : 'removeClass']('ui-state-disabled');

            var inputs = this.menu.find('input');
            var key = "ech-multiselect-disabled";

            if (flag) {
                // remember which elements this widget disabled (not pre-disabled)
                // elements, so that they can be restored if the widget is re-enabled.
                inputs = inputs.filter(':enabled')
				.data(key, true)
            } else {
                inputs = inputs.filter(function () {
                    return $.data(this, key) === true;
                }).removeData(key);
            }

            inputs
			.attr({ 'disabled': flag, 'arial-disabled': flag })
			.parent()[flag ? 'addClass' : 'removeClass']('ui-state-disabled');

            this.element
			.attr({ 'disabled': flag, 'aria-disabled': flag });
        },

        // open the menu
        open: function (e) {
            var self = this,
			button = this.button,
			menu = this.menu,
			speed = this.speed,
			o = this.options,
			args = [];

            // bail if the multiselectopen event returns false, this widget is disabled, or is already open
            if (this._trigger('beforeopen') === false || button.hasClass('ui-state-disabled') || this._isOpen) {
                return;
            }

            var $container = menu.find('ul').last(),
			effect = o.show,
			pos = button.offset();

            // figure out opening effects/speeds
            if ($.isArray(o.show)) {
                effect = o.show[0];
                speed = o.show[1] || self.speed;
            }

            // if there's an effect, assume jQuery UI is in use
            // build the arguments to pass to show()
            if (effect) {
                args = [effect, speed];
            }

            // set the scroll of the checkbox container
            $container.scrollTop(0).height(o.height);

            // position and show menu
            if ($.ui.position && !$.isEmptyObject(o.position)) {
                o.position.of = o.position.of || button;

                menu
				.show()
				.position(o.position)
				.hide();

                // if position utility is not available...
            } else {
                menu.css({
                    top: pos.top + button.outerHeight(),
                    left: pos.left
                });
            }

            // show the menu, maybe with a speed/effect combo
            $.fn.show.apply(menu, args);

            // select the first option
            // triggering both mouseover and mouseover because 1.4.2+ has a bug where triggering mouseover
            // will actually trigger mouseenter.  the mouseenter trigger is there for when it's eventually fixed
            this.labels.eq(0).trigger('mouseover').trigger('mouseenter').find('input').trigger('focus');

            button.addClass('ui-state-active');
            this._isOpen = true;
            this._trigger('open');
        },

        // close the menu
        close: function () {
            if (this._trigger('beforeclose') === false) {
                return;
            }

            var o = this.options,
		    effect = o.hide,
		    speed = this.speed,
		    args = [];

            // figure out opening effects/speeds
            if ($.isArray(o.hide)) {
                effect = o.hide[0];
                speed = o.hide[1] || this.speed;
            }

            if (effect) {
                args = [effect, speed];
            }

            $.fn.hide.apply(this.menu, args);
            this.button.removeClass('ui-state-active').trigger('blur').trigger('mouseleave');
            this._isOpen = false;
            this._trigger('close');
        },

        enable: function () {
            this._toggleDisabled(false);
        },

        disable: function () {
            this._toggleDisabled(true);
        },

        checkAll: function (e) {
            this._toggleChecked(true);
            this._trigger('checkAll');
        },

        uncheckAll: function () {
            this._toggleChecked(false);
            this._trigger('uncheckAll');
        },

        getChecked: function () {
            return this.menu.find('input').filter(':checked');
        },

        destroy: function () {
            // remove classes + data
            $.Widget.prototype.destroy.call(this);

            this.button.remove();
            this.menu.remove();
            this.element.show();

            return this;
        },

        isOpen: function () {
            return this._isOpen;
        },

        widget: function () {
            return this.menu;
        },

        getButton: function () {
            return this.button;
        },

        // react to option changes after initialization
        _setOption: function (key, value) {
            var menu = this.menu;

            switch (key) {
                case 'header':
                    menu.find('div.ui-multiselect-header')[value ? 'show' : 'hide']();
                    break;
                case 'checkAllText':
                    menu.find('a.ui-multiselect-all span').eq(-1).text(value);
                    break;
                case 'uncheckAllText':
                    menu.find('a.ui-multiselect-none span').eq(-1).text(value);
                    break;
                case 'height':
                    menu.find('ul').last().height(parseInt(value, 10));
                    break;
                case 'minWidth':
                    this.options[key] = parseInt(value, 10);
                    this._setButtonWidth();
                    this._setMenuWidth();
                    break;
                case 'selectedText':
                case 'selectedList':
                case 'noneSelectedText':
                    this.options[key] = value; // these all needs to update immediately for the update() call
                    this.update();
                    break;
                case 'classes':
                    menu.add(this.button).removeClass(this.options.classes).addClass(value);
                    break;
                case 'multiple':
                    menu.toggleClass('ui-multiselect-single', !value);
                    this.options.multiple = value;
                    this.element[0].multiple = value;
                    this.refresh();
            }

            $.Widget.prototype._setOption.apply(this, arguments);
        }
    });

})(jQuery);



function extractNumber(obj, decimalPlaces, allowNegative, updatenumberto) {
    var temp = obj.value;

    // avoid changing things if already formatted correctly
    var reg0Str = '[0-9]*';
    if (decimalPlaces > 0) {
        reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
    } else if (decimalPlaces < 0) {
        reg0Str += '\\.?[0-9]*';
    }
    reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
    reg0Str = reg0Str + '$';
    var reg0 = new RegExp(reg0Str);
    if (reg0.test(temp)) {
        if (updatenumberto != null) {
            if (updatenumberto != "")
                document.getElementById(updatenumberto).value = temp;
        }
        return true;
    }

    // first replace all non numbers
    var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
    var reg1 = new RegExp(reg1Str, 'g');
    temp = temp.replace(reg1, '');

    if (allowNegative) {
        // replace extra negative
        var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
        var reg2 = /-/g;
        temp = temp.replace(reg2, '');
        if (hasNegative) temp = '-' + temp;
    }

    if (decimalPlaces != 0) {
        var reg3 = /\./g;
        var reg3Array = reg3.exec(temp);
        if (reg3Array != null) {
            // keep only first occurrence of .
            //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
            var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
            reg3Right = reg3Right.replace(reg3, '');
            reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
            temp = temp.substring(0, reg3Array.index) + '.' + reg3Right;
        }
    }

    obj.value = temp;

    if (updatenumberto != null) {
        if (updatenumberto != "")
            document.getElementById(updatenumberto).value = temp;
    }
}

function blockNonNumbers(obj, e, allowDecimal, allowNegative) {
    var key;
    var isCtrl = false;
    var keychar;
    var reg;

    if (window.event) {
        key = e.keyCode;
        isCtrl = window.event.ctrlKey
    }
    else if (e.which) {
        key = e.which;
        isCtrl = e.ctrlKey;
    }

    if (isNaN(key)) return true;

    keychar = String.fromCharCode(key);

    // check for backspace or delete, or if Ctrl was pressed
    if (key == 8 || isCtrl) {
        return true;
    }

    reg = /\d/;
    var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
    var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;

    return isFirstN || isFirstD || reg.test(keychar);
}

function replaceNumberWith(obj, from) {

    try {

        obj.value = document.getElementById(from).value;
    }
    catch (e) {
      //  alert(from)
     }
}

function replaceWithPretty(obj, from, sprefix, spostfix) {

    obj.value = toPrettyString(document.getElementById(from).value, sprefix, spostfix);
}


function popupInput(sRoot, mode) {
    if (mode == 0) {
        document.getElementById(sRoot + "inputldiv").style.display = "none";
        document.getElementById(sRoot + "displdiv").style.display = "block";
        document.getElementById(sRoot + "inputrdiv").style.display = "none";
        document.getElementById(sRoot + "disprdiv").style.display = "block";



    }
    else if (mode == 1) {
        document.getElementById(sRoot + "inputldiv").style.display = "block";
        //      document.getElementById(sRoot + "displdiv").style.display = "none";
        document.getElementById(sRoot + "inputrdiv").style.display = "none";
        document.getElementById(sRoot + "disprdiv").style.display = "block";
   //     window.setTimeout('document.getElementById(sRoot + "inputldiv").focus();', 100);
        window.setTimeout('document.getElementById("' + sRoot + 'inputl").focus();', 100);
         
        // $("#" + sRoot + "inputldiv").focus();
    } 
    else if (mode == 2) {
        document.getElementById(sRoot + "inputldiv").style.display = "none";
        document.getElementById(sRoot + "displdiv").style.display = "block";
        document.getElementById(sRoot + "inputrdiv").style.display = "none";
        document.getElementById(sRoot + "disprdiv").style.display = "block";

    } 
    else if (mode == 3) {
        document.getElementById(sRoot + "inputldiv").style.display = "none";
        document.getElementById(sRoot + "displdiv").style.display = "block";
        document.getElementById(sRoot + "inputrdiv").style.display = "block";

        window.setTimeout('document.getElementById("' + sRoot + 'inputr").focus();', 100);
        //       document.getElementById(sRoot + "disprdiv").style.display = "none";

  //      $("#" + sRoot + "inputrdiv").focus();

        
    }

}

function toPrettyString(A, sprefix, spostfix) {


    var a = new Number(A);
    var sign = "";

    if (sprefix == undefined)
        sprefix = "";

    if (spostfix == undefined)
        spostfix = "";
    
    if (a < 0) {
        a = -a;
        sign = "-";

    }
    var b = a.toFixed(2); //get 12345678.90
    a = parseInt(a); // get 12345678
    b = (b-a).toPrecision(2); //get 0.90
    b = parseFloat(b).toFixed(2); //in case we get 0.0, we pad it out to 0.00
    a = a.toLocaleString();//put in commas - IE also puts in .00, so we'll get 12,345,678.00
    //if IE (our number ends in .00)
    if(a.lastIndexOf('.00') == (a.length - 3))
    {
        a=a.substr(0, a.length-3); //delete the .00
    }

    var xret = sign + sprefix + a + b.substr(1);

    if (xret.lastIndexOf('00') == (xret.length - 2))
        xret = xret.substr(0, xret.length - 3); //delete the .00
    
    return  xret + spostfix; 
}



function Ribbon(ribbonData) {
    // NB Constructor code at end of function

    Ribbon.prototype.updateRibbonData = function (ribbonData) {
        this.ribbonData = ribbonData;
    };
    
    Ribbon.prototype.getRibbonDiv = function () {
        return this.ribbonData.parent + "_ribbon";
    };
    Ribbon.prototype.isCollapsed = function () {
        if (this.ribbonData.collapsed == "true") {
            return true;
        }
        return false;
    };
    Ribbon.prototype.refreshSelect = function (id) {
        //window.setTimeout('Ribbon_set_select("' + id + '")', 100);
        Ribbon_set_select(id);
    };
    Ribbon.prototype.selectByValue = function (id, itemValue) {
        var select = document.getElementById(id);
        if (select != null) {
            for (var i = 0; i < select.options.length; i++) {
                if (select.options[i].value == itemValue) {
                    select.selectedIndex = i;
                    break;
                }
            }
            Ribbon_set_select(id);
        }
    };
    Ribbon.prototype.collapse = function () {
        this.ribbonData.collapsed = "true";
        var id = this.ribbonData.parent + "_ul";
        document.getElementById(id).style.display = "none";
        id = this.ribbonData.parent + "_ulCollapsed";
        document.getElementById(id).style.display = "block";
    };
    Ribbon.prototype.expand = function () {
        this.ribbonData.collapsed = "false";
        var id = this.ribbonData.parent + "_ulCollapsed";
        document.getElementById(id).style.display = "none";
        id = this.ribbonData.parent + "_ul";
        document.getElementById(id).style.display = "block";
    };
    Ribbon.prototype.isItemDisabled = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            return item.disabled;
        }
        return true;
    };
    Ribbon.prototype.disableItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = true;
            if (document.getElementById) {
                if (item.type == "checkbox" || item.type == "select")
                    document.getElementById(id).disabled = true;

                document.getElementById(id).className = item.className + " ms-cui-disabled";
            }
        }
    };
    Ribbon.prototype.enableItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = false;
            if (document.getElementById) {
                if (item.type == "checkbox" || item.type == "select")
                    document.getElementById(id).disabled = false;

                document.getElementById(id).className = item.className;
            }
        }
    };
    Ribbon.prototype.SetItemName = function (id, newname) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.name = newname;
         }
        return;
    };  
    
    Ribbon.prototype.getButtonState = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            if (item.stateOn == null) item.stateOn = false;
            return item.stateOn;
        }
        return false;
    };
    Ribbon.prototype.setButtonStateOn = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.stateOn = true;
            if (document.getElementById) {
                document.getElementById(id).className = item.className + " ms-cui-ctl-on";
            }
        }
    };
    Ribbon.prototype.setButtonStateOff = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.stateOn = false;
            if (document.getElementById) {
                document.getElementById(id).className = item.className;
            }
        }
    };
    Ribbon.prototype.hideItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = true;
            if (document.getElementById)
                document.getElementById(id).style.display = "none";
        }
    };
    Ribbon.prototype.showItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = false;
            if (document.getElementById)
                document.getElementById(id).style.display = "block";

        }
    };
    Ribbon.prototype.FindItemById = function (id) {
        var sections = this.ribbonData.sections;
        if (sections.length > 0) {
            for (var i = 0; i < sections.length; i++) {
                var columns = sections[i].columns;
                if (columns.length > 0) {
                    for (var j = 0; j < columns.length; j++) {
                        var items = columns[j].items;
                        if (items.length > 0) {
                            for (var k = 0; k < items.length; k++) {
                                if (items[k].id == id)
                                    return items[k];
                            }
                        }
                    }
                }
            }
        }
        return null;
    };

    Ribbon.prototype.GetTargetInput = function (id) {

        try {
            var item = this.FindItemById(id);

            if (item != null) {
                return document.getElementById(id + "inputhidden").value;
            }
        }
        catch (e) { }

        return "";

    }

    Ribbon.prototype.SetTargetInput = function (id, sValue) {

        try {
            var item = this.FindItemById(id);

            if (item != null) {

                var sprefix = "";

                if (item.targetPrefix != null)
                    sprefix = item.targetPrefix;


                var spostfix = "";

                if (item.targetPostfix != null)
                    spostfix = item.targetPostfix;
                
                document.getElementById(id + "inputhidden").value = sValue;
                document.getElementById(id + "input").value = toPrettyString(sValue, sprefix, spostfix);
            }
        }
        catch (e) { }

    }

    Ribbon.prototype.applyProgress = function (elid, total, progress, gored, sprefix, spostfix) {
        var pTot = total;
        var bred = gored;
        var labelEl = $(elid + ' .epm-label');
        var progEl = $(elid + ' .epm-progress');

//        if (progress <= 0)
//            $(progEl).hide();
//        else
//            $(progEl).show();

        if (bred)
            $(progEl).css({ backgroundColor: '#FF0033' });
        else
            $(progEl).css({ backgroundColor: '#74d04c' });

        $(progEl).width(progress + '%');
        pTot = Math.ceil(pTot)

        labelEl.html(toPrettyString(pTot, sprefix, spostfix));
    }

    Ribbon.prototype.SetTargetRemaining = function (id, sRemValue, sTotValue, iprogress, bOverloaded) {

        try {
            var item = this.FindItemById(id);

            if (item != null) {

                var sprefix = "";

                if (item.targetPrefix != null)
                    sprefix = item.targetPrefix;


                var spostfix = "";

                if (item.targetPostfix != null)
                    spostfix = item.targetPostfix;
                
                var progid = '#' + id + 'prog';
                document.getElementById(id + "rem").innerHTML = toPrettyString(sRemValue, sprefix, spostfix);
                this.applyProgress(progid, sTotValue, iprogress, bOverloaded, sprefix, spostfix);
            }
        }
        catch (e) { }

    }

    Ribbon.prototype.ReRender = function () {

        var divr = document.getElementById(this.ribbonData.parent + "_ribbon");
        divr.innerHTML = "<div></div>";
        var divt = document.getElementById(this.ribbonData.parent);
        divt.innerHTML =  "<div></div>";
        this.Render();
    }

    Ribbon.prototype.DeferredMultiSelect = function () {

        if (this.hadmultiselect == true) {

            for (var i = 0; i < this.ribbonmulti.length; i++) {

                var smxx = "#" + this.ribbonmulti[i].multiName;

                $(smxx).multiselect({
                    header: true,
                    selectedText: '# of # selected'
                });

                if (this.ribbonmulti[i].multionclick != "") {

                    var sfn = this.ribbonmulti[i].multionclick;

                    $(smxx).bind("multiselectclick",
                                        function () {
                                            try {
                                                eval(sfn)();
                                            }

                                            catch (e) { }
                                        });

                   $(smxx).bind("multiselectcheckall",
                                        function () {
                                            try {
                                                eval(sfn)();
                                            }

                                            catch (e) { }
                                        });
                   $(smxx).bind("multiselectuncheckall",
                                        function () {
                                            try {
                                                eval(sfn)();
                                            }

                                            catch (e) { }
                                        });
                }
            }

            this.hadmultiselect == false;
        }
    }

    Ribbon.prototype.GetCheckedSelection = function (id) {

        try {
            var item = this.FindItemById(id);

            if (item != null) {
                var selid = '#' + id;

                return $(selid).multiselect("getChecked");

            }
        }
        catch (e) { }


    }

    Ribbon.prototype.Render = function () {
        try {

            this.hadmultiselect = false;
            this.ribbonSliders = new Array();
            this.ribbonmulti = new Array();
            var sb = new StringBuilder();
            var onclick = "";
            //            if (this.ribbonData.showstate == "true") {
            //                if (this.ribbonData.onstatechange != null)
            //                    onclick = " onclick=\"" + this.ribbonData.onstatechange + "\"";

            //                sb.append("<div id='" + this.ribbonData.parent + "_ribbondiv' style='float:right;display:block;' >");
            //                if (this.ribbonData.initialstate == "collapsed") {
            //                    this.ribbonData.collapsed = "true";
            //                    sb.append("<img id='" + this.ribbonData.parent + "_ribbonimg'" + onclick + " src=\"ribbon/images/expand.gif\" alt=''/>");
            //                } else {
            //                    this.ribbonData.collapsed = "false";
            //                    sb.append("<img id='" + this.ribbonData.parent + "_ribbonimg'" + onclick + " src=\"ribbon/images/collapse.gif\" alt=''/>");
            //                }
            //                sb.append("</div>");
            //            }
            this.ribbonData.collapsed = "false";
            sb.append("<div id='" + this.ribbonData.parent + "_ribbon'  class='ms-cui-tabContainer ms-cui-tabContainer-lb'>");
            var sections = this.ribbonData.sections;
            if (sections.length > 0) {
                if (this.ribbonData.miniribbon == "true")
                    sb.append("<ul id='" + this.ribbonData.parent + "_ul'  class='ms-cui-tabBodyLower ms-cui-tabBody-lb'>");
                else
                    sb.append("<ul id='" + this.ribbonData.parent + "_ul'  class='ms-cui-tabBody ms-cui-tabBody-lb'>");
                for (var i = 0; i < sections.length; i++) {
                    sb.append(this.BuildSectionHtml(sections[i]));
                }
                if (this.ribbonData.showstate != "false") {
                    sb.append("<span style='float:right;height:20px;'>");
                    if (this.ribbonData.onstatechange != null)
                        onclick = " onclick=\"" + this.ribbonData.onstatechange + "\"";
                    sb.append("<img alt='' src='ribbon/images/collapse.png' " + onclick + "/>");
                    sb.append("</span>");
                    sb.append("</ul>");
                    if (this.ribbonData.miniribbon == "true")
                        sb.append("<ul id='" + this.ribbonData.parent + "_ulCollapsed'  class='ms-cui-tabBodyLower ms-cui-tabBody-lb' style='display:none'>");
                    else
                        sb.append("<ul id='" + this.ribbonData.parent + "_ulCollapsed'  class='ms-cui-tabBody ms-cui-tabBody-lb' style='display:none'>");
                    sb.append("<span style='float:right;height:20px;'>");
                    sb.append("<img alt='' src='ribbon/images/expand.png' " + onclick + "/>");
                    sb.append("</span>");
                }
            }

            sb.append("</div>");

            sb.append("<div id='" + this.ribbonData.parent + "_popups'>");

            // NB tabindex required for firefox focus
            var tabindex;
            if (document.all) tabindex = ""; else tabindex = " tabindex='1' ";
            sections = this.ribbonData.sections;
            if (sections.length > 0) {
                for (var i = 0; i < sections.length; i++) {
                    var columns = sections[i].columns;
                    if (columns.length > 0) {
                        for (var j = 0; j < columns.length; j++) {
                            var items = columns[j].items;
                            if (items.length > 0) {
                                for (var k = 0; k < items.length; k++) {
                                    if (items[k].type == "select") {
                                        sb.append("<div id='" + items[k].id + "_popup'" + tabindex + "style='display:none;'></div>");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sb.append("</div>");

            var s = sb.toString();
            var div = document.getElementById(this.ribbonData.parent);
            div.innerHTML = s;

            for (var i = 0; i < this.ribbonSliders.length; i++) {

                var sxxx = "#" + this.ribbonSliders[i].sliderName;
                $(sxxx).EPMSlider(this.ribbonSliders[i].sliderOptions);
            }

            try {

                if (this.hadmultiselect == true) {

                    for (var i = 0; i < this.ribbonmulti.length; i++) {

                        var smxx = "#" + this.ribbonmulti[i].multiName;

                        $(smxx).multiselect({
                            header: true,
                            selectedText: '# of # selected'
                        });

                        if (this.ribbonmulti[i].multionclick != "") {

                            var sfn = this.ribbonmulti[i].multionclick;

                            $(smxx).bind("multiselectclick",
                                    function () {
                                        try {
                                            eval(sfn)();
                                        }

                                        catch (e) { }
                                    });

                                    $(smxx).bind("multiselectcheckall",
                                        function () {
                                            try {
                                                eval(sfn)();
                                            }

                                            catch (e) { }
                                        });
                                    $(smxx).bind("multiselectuncheckall",
                                        function () {
                                            try {
                                                eval(sfn)();
                                            }

                                            catch (e) { }
                                        });
                        }
                    }

                    this.hadmultiselect == false;
                }
            }
            catch (e) { }


        }
        catch (e) {
            Ribbon_HandleException("Render", e);
        }
    };
    Ribbon.prototype.BuildSectionHtml = function (section) {
        var s = "";
        try {
            var sb = new StringBuilder();
            if (this.ribbonData.miniribbon == "true") {
                sb.append("<li class='ms-cui-groupLower'>");
                sb.append("<span class='ms-cui-groupContainerLower'>");
                sb.append("<span class='ms-cui-groupBodyLower'>");
            } else {
                sb.append("<li class='ms-cui-group'>");
                sb.append("<span class='ms-cui-groupContainer'>");
                sb.append("<span class='ms-cui-groupBody'>");
            }
            sb.append("<span class='ms-cui-layout'>");
            var columns = section.columns;
            if (columns.length > 0) {

                for (var i = 0; i < columns.length; i++) {
                    sb.append(this.BuildColumnHtml(columns[i]));
                }
            }

            var tooltip = "";
            if (section.tooltip != null) tooltip = section.tooltip;


            sb.append("</span>");
            sb.append("</span>");
            sb.append("<span class='ms-cui-groupTitle' title='" + tooltip + "'>" + section.name + "</span>");
            sb.append("</span>");

            if (this.ribbonData.miniribbon == "true") {
                sb.append("<span class='ms-cui-groupSeparatorLower'></span>");
            } else {
                sb.append("<span class='ms-cui-groupSeparator'></span>");
            }
            sb.append("</li>");
            s = sb.toString();
        }
        catch (e) {
            Ribbon_HandleException("BuildSectionHtml", e);
        }
        return s;
    };
    Ribbon.prototype.BuildColumnHtml = function (column) {
        var s = "";
        try {
            var sb = new StringBuilder();
            sb.append("<span class='ms-cui-section'>");
            var items = column.items;
            if (items.length > 0) {
                for (var i = 0; i < items.length; i++) {
                    sb.append(this.BuildItemHtml(items[i]));
                }
            }
            sb.append("</span>");
            s = sb.toString();
        }
        catch (e) {
            Ribbon_HandleException("BuildColumnHtml", e);
        }
        return s;
    };
    Ribbon.prototype.BuildItemHtml = function (item) {
        var s = "";
        try {
            var sb = new StringBuilder();

            var rawid = "";
            if (item.id != null)
                rawid = item.id;

            var id = "";
            if (item.id != null)
                id = " id=\"" + item.id + "\"";

            var onclick = "";
            if (item.onclick != null)
                onclick = " onclick=\"" + item.onclick + "\"";
            //            var tooltip = "";
            //            if (item.tooltip != null)
            //                tooltip = " tooltip=\"" + item.tooltip + "\"";
            var itemname = "";
            if (item.name != null)
                itemname = item.name.replace(/ /g, "&nbsp;");
            var classdisabled = "";
            if (item.disabled == true)
                classdisabled = " ms-cui-disabled";
            var classname;

            var itemstyle = "";
            if (item.style != null)
                itemstyle = " style='" + item.style + "' ";

            var onchange = "";
            if (item.onchange != null)
                onchange = " onclick=\"" + item.onchange + "\"";

            switch (item.type) {
                case "bigbutton":
                    item.className = "ms-cui-ctl-large";
                    classname = item.className + classdisabled;
                    sb.append("<span class='ms-cui-row-onerow'>");
                    sb.append("<a" + id + " class='" + classname + "' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-largeIconContainer' >");
                    sb.append("<span class='ms-cui-img-32by32 ms-cui-img-cont-float'>");
                    sb.append("<img alt='' src='" + this.ribbonData.imagePath + item.img + "' " + itemstyle + "/>");
                    sb.append("</span>");
                    sb.append("</span>");
                    sb.append("<span class='ms-cui-ctl-largelabel'>" + itemname + "</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    break;
                case "mediumbutton":
                    item.className = "ms-cui-ctl-lowerlarge";
                    classname = item.className + classdisabled;
                    sb.append("<span class='ms-cui-row-onerow'>");
                    sb.append("<a" + id + " class='" + classname + "' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-MediumIconContainer' >");
                    sb.append("<span class='ms-cui-img-20by20 ms-cui-img-cont-float'>");
                    sb.append("<img alt='' src='" + this.ribbonData.imagePath + item.img + "' " + itemstyle + "/>");
                    sb.append("</span>");
                    sb.append("</span>");
                    sb.append("<span class='ms-cui-ctl-lowerlargelabel'>" + itemname + "</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    break;
                case "smallbutton":
                    item.className = "ms-cui-ctl-medium";
                    classname = item.className + classdisabled;
                    sb.append("<span class='ms-cui-row'>");
                    sb.append("<a" + id + " class='" + classname + "' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-iconContainer' >");
                    sb.append("<span class='ms-cui-img-16by16 ms-cui-img-cont-float'>");
                    sb.append("<img alt='' src='" + this.ribbonData.imagePath + item.img + "' " + itemstyle + "/>");
                    sb.append("</span>");
                    sb.append("</span>");
                    sb.append("<span class='ms-cui-ctl-mediumlabel'>" + itemname + "</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    break;
                case "mediumtext":
                    item.className = "ms-cui-ctl-medium";
                    classname = item.className + classdisabled;
                    sb.append("<span class='ms-cui-row'>");
                    sb.append("<a" + id + " class='" + classname + "' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-mediumlabel'>" + itemname + "</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    break;
                case "text":
                    item.className = "ms-cui-ctl-small";
                    sb.append("<span class='ms-cui-row'>");
                    sb.append("<span " + id + " class='ms-cui-ctl-small ms-cui-fslb ms-cui-disabled' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-mediumlabel'>" + itemname + "</span>");
                    sb.append("</span>");
                    sb.append("</span>");
                    break;
                case "slider":

                    var idinputl = " id=\"" + rawid + "inputl\"";
                    var inputl = "\"" + rawid + "inputl\"";
                    var displ = "\"" + rawid + "displ\"";
                    var inputldiv = "\"" + rawid + "inputldiv\"";
                    var displdiv = "\"" + rawid + "displdiv\"";
                    var iddispl = " id=\"" + rawid + "displ\"";

                    var idinputr = " id=\"" + rawid + "inputr\"";
                    //                   var idinputhiddenr = " id=\"" + rawid + "inputhidr\"";
                    //                   var inputhiddenr = "\"" + rawid + "inputhidr\"";
                    var iddispr = " id=\"" + rawid + "dispr\"";
                    var inputrdiv = "\"" + rawid + "inputrdiv\"";
                    var disprdiv = "\"" + rawid + "disprdiv\"";

                    var rawidq = "\"" + rawid + "\"";


                    var oninput = "";
                    if (item.oninput != null)
                        oninput = " " + item.oninput + ";";

                    var onpreinput = "";

                    if (item.onpreinput != null)
                        onpreinput = " " + item.onpreinput + ";";


                    onchange = "";
                    if (item.onchange != null)
                        onchange = " " + item.onchange + ";";


                    var sprefix = "";

                    if (item.sliderPrefix != null)
                        sprefix = item.sliderPrefix;


                    var spostfix = "";

                    if (item.sliderPostfix != null)
                        spostfix = item.sliderPostfix;

                    var blurprefix = "\"" + sprefix + "\"";
                    var blurpostfix = "\"" + spostfix + "\"";

                    sb.append("<span style='width:150px' >");
                    sb.append("<table cellspacing='0' cellpadding='1' style='width:100%'><tr><td>");
                    sb.append("<span class='epm-slidetitle' >" + itemname + "</span>");
                    sb.append("</td><td style='width:10px'><span class='epm-slidetitle'>" + ' ' + "</span>");
                    sb.append("</td></tr>");
                    sb.append("<tr><td>");
                    sb.append("<table>");
                    sb.append("<tr><td>");
                    sb.append("<div style='display:none' id=" + inputldiv + " >");
                    sb.append("<input" + idinputl + " type='text' value='" + item.minValue + "' class='optRangeInput' ");
                    sb.append(" onblur='popupInput(" + rawidq + ",0); extractNumber(this,2,true, null); " + oninput + "'");
                    sb.append(" onkeyup='extractNumber(this,2,true, null);'");
                    sb.append(" onkeypress='return blockNonNumbers(this, event, true, true);'");
                    sb.append("  />");
                    sb.append("</div>");
                    sb.append("<div style='display:block' id=" + displdiv + " >");
                    sb.append("<span " + iddispl + " class='epm-slidetitle' ");
                    sb.append(" onclick='" + onpreinput + "popupInput(" + rawidq + ",1);'");
                    sb.append(">" + toPrettyString(item.minValue, sprefix, spostfix) + "</span>");
                    sb.append("</div>");
                    sb.append("</td><td>");


                    sb.append("<span class='epm-slidetitle' > : </span>");
                    sb.append("</td><td>");


                    sb.append("<div style='display:none' id=" + inputrdiv + " >");
                    sb.append("<input" + idinputr + " type='text' value='" + item.maxValue + "' class='optRangeInput' ");
                    sb.append(" onblur='popupInput(" + rawidq + ",2); extractNumber(this,2,true, null); " + oninput + "'");
                    sb.append(" onkeyup='extractNumber(this,2,true, null);'");
                    sb.append(" onkeypress='return blockNonNumbers(this, event, true, true);'");
                    sb.append("  />");
                    sb.append("</div>");
                    sb.append("<div style='display:block' id=" + disprdiv + " >");
                    sb.append("<span " + iddispr + " class='epm-slidetitle' ");
                    sb.append(" onclick='" + onpreinput + "popupInput(" + rawidq + ",3);'");

                    sb.append(">" + toPrettyString(item.maxValue, sprefix, spostfix) + "</span>");
                    sb.append("</div>");



                    sb.append("</td></tr>");
                    sb.append("</table>");
                    sb.append("</td></tr>");
                    sb.append("<tr><td>");
                    sb.append("<table width:110px; height:1px><tr><td> </td></tr></table>");
                    sb.append("</td></tr>");
                    sb.append("</table><table>");
                    sb.append("<tr><td>");
                    sb.append("<input type='hidden' " + id + " />");
                    sb.append("</td><td style='width:10px'><span class='epm-slidetitle'>" + ' ' + "</span>");
                    sb.append("</td></tr>");
                    sb.append("</table>");
                    sb.append("</span>");

                    var oPar = new Object();
                    oPar.sliderItem = item;
                    oPar.sliderName = item.id;
                    oPar.sliderOptions = new Object;
                    oPar.sliderOptions.onchange = item.onchange;
                    oPar.sliderOptions.oninput = item.oninput;
                    oPar.sliderOptions.minValue = item.minValue;
                    oPar.sliderOptions.maxValue = item.maxValue;
                    oPar.sliderOptions.rangeminValue = item.rangeminValue;
                    oPar.sliderOptions.rangemaxValue = item.rangemaxValue;
                    oPar.sliderOptions.posminValue = item.posminValue;
                    oPar.sliderOptions.posmaxValue = item.posmaxValue;
                    oPar.sliderOptions.step = item.step;
                    oPar.sliderOptions.width = 100;
                    oPar.sliderOptions.hideTooltip = true;
                    oPar.sliderPrefix = item.sliderPrefix;
                    oPar.sliderPostfix = item.sliderPostfix;

                    this.ribbonSliders[this.ribbonSliders.length] = oPar;
                    break;

                case "optirp":
                    var idinput = " id=\"" + rawid + "input\"";
                    var idinputhidden = " id=\"" + rawid + "inputhidden\"";
                    var inputhidden = "\"" + rawid + "inputhidden\"";
                    var idremaining = " id=\"" + rawid + "rem\"";
                    var idprogress = " id=\"" + rawid + "prog\"";

                    var tartit = "";
                    if (item.title != null)
                        tartit = item.title;

                    var tarrem = "";
                    if (item.remval != null)
                        tarrem = item.remval;


                    var tarval = "";
                    if (item.targetValue != null)
                        tarval = item.targetValue;

                    onchange = "";
                    if (item.onchange != null)
                        onchange = " " + item.onchange + ";";

                    var sprefix = "";

                    if (item.targetPrefix != null)
                        sprefix = item.targetPrefix;


                    var spostfix = "";

                    if (item.targetPostfix != null)
                        spostfix = item.targetPostfix;

                    var blurprefix = "\"" + sprefix + "\"";
                    var blurpostfix = "\"" + spostfix + "\"";


                    sb.append("<span>");
                    sb.append("<a>");
                    sb.append("<table  cellspacing='0' cellpadding='0' style='width:100%'><tr><td>");
                    sb.append("<table  cellspacing='0' cellpadding='1' style='width:100%'><tr><td class='epm-ribbontitletextlj'>");
                    sb.append("<a align=left class='epm-ribbontitletextlj' style='font-size:8pt;'>" + tartit + "</a>");
                    sb.append("</td><td style='width:85px;' class='epm-ribbontitletextrj'>");
                    sb.append("<a class='epm-ribbontitletextrj' style='font-size:8pt;'>  Remaining  </a>");
                    sb.append("</td></tr>");
                    sb.append("<tr><td>");
                    sb.append("<input" + idinput + " type='text' value='" + toPrettyString(tarval, sprefix, spostfix) + "' class='optInput' ");
                    sb.append(" onfocus='replaceNumberWith(this," + inputhidden + ");' ");
                    sb.append(" onblur='extractNumber(this,2,true," + inputhidden + "); replaceWithPretty(this, " + inputhidden + "," + blurprefix + "," + blurpostfix + ");" + onchange + "'");
                    //sb.append(" onblur='replaceWithPretty(this, " + inputhidden + "," + blurprefix + "," + blurprefixblurprefix + ");alert(1);'");
                    sb.append(" onkeyup='extractNumber(this,2,true," + inputhidden + ");" + onchange + "'");
                    sb.append(" onkeypress='return blockNonNumbers(this, event, true, true);'");
                    sb.append("  />");

                    sb.append("<input" + idinputhidden + " type='hidden' value='" + tarval + "' />");
                    sb.append("</td>");
                    sb.append("<td class='epm-ribbontitletextrj'>");
                    sb.append("<a class='epm-ribbontitletextrj' " + idremaining + " >" + toPrettyString(tarrem, sprefix, spostfix) + "</a>");
                    sb.append("</td>");
                    sb.append("</tr>");
                    sb.append("</table>");
                    sb.append("</td>");
                    sb.append("</tr>");
                    sb.append("<tr><td>");
                    //                   sb.append("<a " + idprogress + " class='epm-ribbontitletextlj'>put jquere progress/status here </a>");
                    sb.append('<div class="epm-progressbar">');
                    sb.append("<div " + idprogress + " style='width: 150px; height: 15px;' class='epm-progress-bar'>");
                    sb.append("<div class='epm-progress' style='width: 0px; height: 15px;' >");
                    sb.append("</div>");
                    sb.append('<div class="epm-label" >0</div>');
                    sb.append("</div>");
                    sb.append("</div>");
                    sb.append("</td></tr>");
                    sb.append("</table>");


                    sb.append("</a>");
                    sb.append("</span>");


                    break;



                case "select":
                    var sWidth = "";
                    if (item.width != null)
                        sWidth = "width: " + item.width + ";";
                    var sStyle = "";
                    if (sWidth != "")
                        sStyle = " style='" + sWidth + "'";
                    var sOptions = "";
                    if (item.options != null)
                        sOptions = item.options;
                    var onchange = "";
                    if (item.onchange != null)
                        onchange = " onchange=\"" + item.onchange + "\"";
                    var aid = "";
                    if (item.id != null)
                        aid = " id=\"" + item.id + "_textbox\"";
                    var bid = "";
                    if (item.id != null)
                        bid = " id=\"" + item.id + "_button\"";
                    item.className = "ms-cui-dd-text";
                    sb.append("<div style='display:none;'>");
                    sb.append("<select " + id + " " + onchange + ">" + sOptions + "</select>");
                    sb.append("</div>");
                    sb.append("<span class='ms-cui-row'>");
                    sb.append("<span" + bid + " class='ms-cui-dd-text'" + sStyle + " onclick='Ribbon_showPopup(\"" + item.id + "_popup\",\"" + item.id + "\",\"" + this.ribbonData.parent + "\");'>");
                    sb.append("<a" + aid + "></a>");
                    sb.append("</span>");
                    sb.append("<a class='ms-cui-dd-arrow-button' onclick='Ribbon_showPopup(\"" + item.id + "_popup\",\"" + item.id + "\",\"" + this.ribbonData.parent + "\");'>");
                    sb.append("<span class='ms-cui-img-5by3 ms-cui-img-cont-float'>");
                    sb.append("<img alt='' src='./images/formatmap16x16.png' style='top: -24px; left: -48px;position:relative;z-index:5;' />");
                    sb.append("</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    window.setTimeout('Ribbon_set_select("' + item.id + '")', 100);
                    break;
                case "checkbox":
                    item.className = "ms-cui-ctl-medium";
                    sb.append("<span class='ms-cui-row'>");
                    //sb.append("<input type='checkbox' " + id + " " + sOptions + " " + onclick + "/>" + itemname);
                    sb.append("<input type='checkbox' " + id + " " + onclick + "/>" + itemname);
                    sb.append("</span>");
                    break;
                case "multicombo":

                    this.hadmultiselect = true;

                    sb.append("<span>");
                    sb.append("<a>");
                    sb.append("<table  cellspacing='0' cellpadding='1' ><tr><td>");
                    sb.append("<span class='epm-slidetitle'>" + itemname + "</span>");
                    sb.append("</td><td style='width:5px'><span class='epm-slidetitle'>" + ' ' + "</span>");
                    sb.append("</td></tr>");
                    //                  sb.append("<tr><td>");
                    //                   sb.append("<a style='font-size:1px;'>" + ' <br>' + "</a>");
                    //                   sb.append("</td></tr>");
                    sb.append("<tr><td>");
                    sb.append('<select "' + id + '" title="' + itemname + '" multiple="multiple" size="5">');
                    sb.append(item.options);
                    sb.append('</select>');

                    sb.append("</td></tr>");
                    sb.append("</table>");
                    sb.append("</a>");
                    sb.append("</span>");

                    var oPar = new Object();
                    oPar.multiName = rawid;
                    oPar.multiText = itemname;
                    oPar.multionclick = "";

                    if (onclick != "")
                        oPar.multionclick = item.onclick;

                    this.ribbonmulti[this.ribbonmulti.length] = oPar;
                    break;

                default:
                    break;
            }
            s = sb.toString();
        }
        catch (e) {
            Ribbon_HandleException("BuildItemHtml", e);
        }
        return s;
    };
    Ribbon_showPopup = function (idPopup, idSelect, idParent) {
        var popup = document.getElementById(idPopup);
        var tbselect = document.getElementById(idSelect + "_textbox");
        var parent = document.getElementById(idParent);
        var offsetParent = parent.offsetParent;
        var xy = Ribbon_findAbsolutePosition(tbselect, parent);
        if (popup.style.display == "block") {
            if (popup.style.top == (xy[1] + 17).toString() + "px" && popup.style.left == (xy[0] - 8).toString() + "px") {
                popup.style.display = "none";
                return;
            }
        }
        var maxheight = 75;
        if (offsetParent != null) {
            var l = offsetParent.offsetHeight - xy[1] - 50;
            if (l > maxheight)
                maxheight = l;
        }
        var vid = "";
        if (idSelect != null)
            vid = " id=\"" + idSelect + "_view\"";
        var vinternalid = "";
        if (idSelect != null)
            vinternalid = " id=\"" + idSelect + "_viewinternal\"";
        var sb = new StringBuilder();
        sb.append("<div class='ms-cui-smenu-inner'>");
        sb.append("<div class=''>");
        sb.append("<div class='ms-cui-menusection'>");
        //sb.append("<div class='ms-cui-menusection-title'>Current View</div>");
        sb.append("<ul class='ms-cui-menusection-items'>");
        sb.append("<li " + vinternalid + " class='ms-cui-menusection-items'>");
        var select = document.getElementById(idSelect);
        for (var i = 0; i < select.options.length; i++) {
            var oItem = select.options[i];
            sb.append("<a onclick='Ribbon_selectItem_click(\"" + idPopup + "\",\"" + idSelect + "\",\"" + i.toString() + "\");' class=\"ms-cui-ctl-menu\" title='" + oItem.text + "'\">");
            sb.append("<span class='ms-cui-ctl-iconContainer'>");
            sb.append("<span class='ms-cui-img-16by16 ms-cui-img-cont-float'></span>");
            sb.append("</span>");
            sb.append("<span class='ms-cui-ctl-mediumlabel'>" + oItem.text + "</span>");
            sb.append("<span class='ms-cui-glass-ff'></span>");
            sb.append("</a>");
        }
        sb.append("</li>");
        sb.append("</ul>");
        sb.append("</div>");
        sb.append("</div>");
        var s = sb.toString();
        popup.className = "ms-cui-menu";
        popup.style.cssText = "direction: ltr; visibility: visible; position: absolute; top: " + (xy[1] + 17).toString() + "px; left: " + (xy[0] - 8).toString() + "px; z-index: 1001; min-width: " + (tbselect.parentNode.offsetWidth - 1).toString() + "px; max-height:" + maxheight + "px;overflow:auto; display:none;";
        popup.innerHTML = s;
        popup.style.display = "block";
        popup.focus();
        //popup.onblur = function () { Ribbon_hide_popup(idPopup); };
        popup.onblur = function () { window.setTimeout('document.getElementById("' + idPopup + '").style.display = "none";', 200); };

    };
    Ribbon_selectItem_click = function (idPopup, item, index) {
        //alert(item.toString() + index);
        var select = document.getElementById(item);
        select.selectedIndex = index;
        Ribbon_set_select(item);
        window.setTimeout('document.getElementById("' + item + '").onchange();', 200);
        document.activeElement.blur();
        //document.getElementById(idPopup).style.display = "none";
        //Ribbon_hide_popup(idPopup);
    }; //Ribbon_hide_popup = function (idPopup) {
        //window.setTimeout('document.getElementById("' + idPopup + '").style.display = "none";', 200);
    //}

    Ribbon_set_select = function (idSelect) {
        var select = document.getElementById(idSelect);
        var s = "";
        if (select != null && select.selectedIndex >= 0)
            s = select.options[select.selectedIndex].text;
        var selectText = document.getElementById(idSelect + "_textbox");

        if (selectText != null) {
            if (document.all) selectText.innerText = s; else selectText.textContent = s;
        }
    };
    Ribbon_findAbsolutePosition = function (obj, objParent) {
        var pcurleftx = 0;
        var pcurtopy = 0;
        if (objParent.offsetParent) {
            do {
                pcurleftx += objParent.offsetLeft;
                pcurtopy += objParent.offsetTop;
            } while (objParent = objParent.offsetParent);
        }
        var curleftx = 0;
        var curtopy = 0;
        if (obj.offsetParent) {
            do {
                curleftx += obj.offsetLeft;
                curtopy += obj.offsetTop;
            } while (obj = obj.offsetParent);
        }
        return [curleftx - pcurleftx, curtopy - pcurtopy];
    };
    Ribbon_HandleException = function (name, e) {
        alert("Exception thrown in function " + name + "\n\n" + e.toString());
    };
    try {
        this.hadmultiselect = false;
        this.ribbonSliders = new Array();
        this.ribbonmulti = new Array();
        this.ribbonData = ribbonData;
        this.ribbonclass = "epm_ribbon";
        if (this.ribbonData.ribbonclass != null && this.ribbonData.ribbonclass != "")
            this.ribbonclass = this.ribbonData.ribbonclass;
    }
    catch (e) {
        Ribbon_HandleException("Ribbon Initialization", e);
    }
}


    
