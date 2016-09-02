(function () {
    var register = function () {
        (function ($$$, $, undefined) {
            window.epmLiveWorkCenter = function () {
                var gridCollection = null;
                var activeGrid = null;

                function init(menuItemClass, menuItemSelectedClass, titleControl, grids) {
                    gridCollection = {};

                    for (var g in grids) {
                        if (grids.hasOwnProperty(g)) {
                            var grid = grids[g];

                            gridCollection[g] = grid.id;

                            if (grid.active) {
                                activeGrid = grid.id;
                            }
                        }
                    }

                    $(function () {
                        menuItemClass = '.' + menuItemClass;

                        $(menuItemClass).click(function () {
                            var element = $(this);

                            if (element.data('selected')) return;

                            $('.EPMLoader').hide();

                            $(menuItemClass).each(function () {
                                var ele = $(this);

                                ele.removeClass(menuItemSelectedClass);

                                if (ele.data('selected')) {
                                    $('#' + ele.data('control')).hide('slide', { direction: 'left' }, 'slow');
                                }

                                ele.data('selected', false);
                            });

                            element.addClass(menuItemSelectedClass);
                            element.data('selected', true);

                            var control = element.data('control');

                            $('#' + titleControl).text(element.text());
                            $('#' + control).show('slide', { direction: 'left' }, 'slow');

                            activeGrid = gridCollection[control];

                            for (var grd in gridCollection) {
                                if (gridCollection.hasOwnProperty(grd)) {
                                    window.Grids[gridCollection[grd]].Focus(null);
                                }
                            }

                            window.RefreshCommandUI();
                        });
                    });
                }

                function getActiveGrid() {
                    return activeGrid;
                }

                return {
                    initialize: init,
                    activeGrid: getActiveGrid
                };
            } ();

            window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("EPMLive.WorkCenter.js");
        } (window.epmLive, window.jQuery));
    };

    ExecuteOrDelayUntilScriptLoaded(register, 'EPMLive.js');
})();