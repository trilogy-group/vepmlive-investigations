module EPM {
    export module UI {
        export interface IElement {
            id: string;
            page?: boolean;
            coverRibbon?: boolean;
            height?: number;
            width?: number;
            bgColor?: string;
            duration?: number;
            loader?: JQuery;
            el?: JQuery;
        }

        export class Loader {
            private static _instance: Loader;
            private _elements: IElement[];

            constructor() {
                if (!Loader._instance) {
                    this._elements = [];
                    Loader._instance = this;
                } else {
                    throw new Error("Error: Instantiation failed: Use EPM.UI.Loader.current() instead of new.");
                }
            }

            public static current(): Loader {
                if (!Loader._instance) {
                    Loader._instance = new Loader();
                }

                return Loader._instance;
            }

            public startLoading(element: IElement): void {
                if (!this.elementIsRegistered(element)) {
                    this._elements.push(element);

                    var $content = $(document.getElementById("s4-workspace"));
                    var $el = $("#" + element.id);

                    $el.css("visibility", "hidden");

                    var offset = $el.offset();

                    var leftOffset = 50;

                    if ($('#epm-nav-sub').is(':visible')) {
                        leftOffset = 230;
                    }

                    var height: number;
                    var width: number;

                    if (element.page) {
                        height = $content.height();
                        width = $content.width();

                        if (element.coverRibbon) {
                            offset = { top: 50, left: leftOffset };
                        }
                    } else {
                        height = element.height || $el.height();
                        width = element.width || $el.width();
                    }

                    var $loader = $("<table id=\"" + element.id + "_epm_loader\" class=\"epm-loader\"><tr><td></td></tr></table>");

                    if (element.bgColor) {
                        $loader.css("background", element.bgColor);
                    }

                    if (!element.coverRibbon) {
                        $loader.height(height);
                        $loader.width(width);
                    } else {
                        $loader.css("height", $(window).height() - 50);
                        $loader.css("width", $(window).width() - leftOffset);
                    }

                    $loader.hide();
                    $loader.offset({ top: offset.top, left: offset.left });

                    $("body").append($loader.show());

                    element.loader = $loader;
                    element.el = $el;

                    if ($.browser.msie) {
                        if (element.coverRibbon) {
                            $(document.getElementById("s4-ribbonrow")).css("visibility", "hidden");
                            $content.css("visibility", "hidden");
                        } else {
                            $el.css("visibility", "hidden");
                        }
                    } else {
                        $el.css("visibility", "visible");
                    }

                    setTimeout(() => {
                        this.showLoading(element);
                    }, 1500);
                }
            }

            public stopLoading(elementId: string): void {
                var element: IElement = { id: elementId };

                if (this.elementIsRegistered(element)) {
                    var index = -1;

                    for (var i = 0; i < this._elements.length; i++) {
                        var el = this._elements[i];

                        if (element.id === el.id) {
                            index = i;
                            element.loader = el.loader;
                            element.el = el.el;
                            element.coverRibbon = el.coverRibbon;

                            break;
                        }
                    }

                    if (index !== -1) {
                        if (element.coverRibbon) {
                            var $ribbon = $(document.getElementById("s4-ribbonrow"));
                            var $content = $(document.getElementById("s4-workspace"));

                            $ribbon.hide();
                            $content.hide();
                            element.loader.fadeOut(300).remove();

                            if ($.browser.msie) {
                                $ribbon.css("visibility", "visible").hide();
                                $content.css("visibility", "visible").hide();
                                element.el.css("visibility", "visible").hide();
                            }

                            $ribbon.fadeIn(500);
                            $content.fadeIn(500);
                            element.el.fadeIn(500);
                        } else {
                            element.el.hide();
                            element.loader.fadeOut(300).remove();

                            if ($.browser.msie) {
                                element.el.css("visibility", "visible").hide();
                            }

                            element.el.fadeIn(500);
                        }
                        this._elements.splice(index, 1);
                    }
                }
            }

            private elementIsRegistered(element: IElement): boolean {
                var found = false;

                this._elements = this._elements || [];

                for (var i = 0; i < this._elements.length; i++) {
                    if (element.id === this._elements[i].id) {
                        found = true;
                        break;
                    }
                }

                return found;
            }

            private showLoading(element: IElement): void {
                if (this.elementIsRegistered(element)) {
                    var offset = element.loader.height() / -4;
                    element.loader.find('td').append($('<div style="position:relative;top:' + offset + 'px">Loading<span class="ellipsis-wrapper"><span class="ellipsis">...</span></span></div>'));
                }
            }
        }

        (function () {
            var browser = $.browser;

            if (browser.msie && parseInt(browser.version) < 9) {
                $.fn.fadeIn = function (duration, callback) {
                    if (!callback) {
                        if (typeof (duration) === "function") {
                            callback = duration;
                        }
                    }

                    if (callback) {
                        setTimeout(function () {
                            callback();
                        }, 5);
                    }

                    return $.fn.show.apply(this);
                };

                $.fn.fadeOut = function (duration, callback) {
                    if (!callback) {
                        if (typeof (duration) === "function") {
                            callback = duration;
                        }
                    }

                    if (callback) {
                        setTimeout(function () {
                            callback();
                        }, 5);
                    }

                    return $.fn.hide.apply(this);
                };
            }
        })();

        SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs('EPM.UI');
    }
}