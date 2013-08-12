(function() {
    'use strict';

    function epmLiveTweaks() {
        window.toggleSearch = function () {
            var $sbox = $('#search-box-container');
            var $sicon = $('#search-container');
            var $sinput = $('#ctl00_PlaceHolderSearchArea_SmallSearchInputBox1_csr_sbox');
            
            if ($sbox.is(':visible')) {
                $sicon.css('color', '#00668E');
            } else {
                $sicon.css('color', '#FFFFFF');
            }

            $sbox.toggle('fast', function() {
                $sinput.focus();
            });
        };

        $(document).click(function (e) {
            if ($('#search-box-container').is(':visible')) {
                if ($(e.target).parents('#search-box-container').length === 0 && $(e.target).parents('#search-container').length === 0) {
                    toggleSearch();
                }
            }
        });
    }

    ExecuteOrDelayUntilScriptLoaded(epmLiveTweaks, 'jquery.min.js');
})();