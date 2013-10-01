module EPM {
    export module UI {
        export interface IElement {
            id: string;
            page?: boolean;
            height?: number;
            width?: number;
            bgColor?: string;
            duration?: number;
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
                    $("#" + element.id).css("visibility", "hidden");

                    var $el = $("#" + element.id);
                    var offset = $el.offset();

                    var height: number;
                    var width: number;

                    if (element.page) {
                        var $content = $("#s4-workspace");

                        height = $content.height();
                        width = $content.width();
                    } else {
                        height = element.height || $el.height();
                        width = element.width || $el.width();
                    }

                    var $loader = $("<div id=\"" + element.id + "_epm_loader\" class=\"epm-loader\">&nbsp;</div>");

                    if (element.bgColor) {
                        $loader.css("background", element.bgColor);
                    }

                    $loader.height(height);
                    $loader.width(width);
                    $loader.hide();
                    $loader.offset({ top: offset.top, left: offset.left });

                    $("body").append($loader.fadeIn(300));

                    var self = this;
                    setTimeout(function () {
                        self.showLoading(element);
                    }, element.duration || 2000);
                }
            }

            public stopLoading(elementId: string): void {
                var element: IElement = { id: elementId };

                if (this.elementIsRegistered(element)) {
                    var index = -1;

                    for (var i = 0; i < this._elements.length; i++) {
                        if (element.id === this._elements[i].id) {
                            index = i;
                            break;
                        }
                    }

                    if (index !== -1) {
                        $("#" + element.id + "_epm_loader").fadeOut(300).remove();
                        $("#" + element.id).css("visibility", "visible").hide().fadeIn(2000);
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
                    var $div = $("<div>Loading...</div>");
                    $div.offset({ top: ($("#" + element.id + "_epm_loader").height() - 20) / 2 });

                    $("#" + element.id + "_epm_loader").append($div);
                }
            }
        }

        SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs('EPM.UI');
    }
}