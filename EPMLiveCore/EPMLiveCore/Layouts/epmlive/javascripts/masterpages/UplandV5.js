(function() {
    'use strict';

    function epmLiveTweaks() {
        $.getScript("/_layouts/epmlive/javascripts/libraries/tooltip.js", function() {
            $("[rel=tooltipbottom]").tooltip({ 'placement': 'bottom', 'delay': 100 });
            $("[rel=tooltiptop]").tooltip({ 'placement': 'top', 'delay': 400 });
        });

        $(document).mouseup(function(e) {
            try {
                var source = e.target.src;
                if (source === 'undefined' || source.indexOf('epmlive-header.png') === -1) {
                    var container = $("#DeltaPlaceHolderSearchArea");
                    if (container.has(e.target).length === 0) {
                        container.hide();
                    }
                }
            } catch(e) {
            }
        });

        try {
            //swapping out the OOB settings page for ours
            $("#ctl00_PlaceHolderMain_diidSiteSettings").attr("href", "./epmlive/settings.aspx");

            //adjusting the line height of search input
            $("#ctl00_PlaceHolderSearchArea_SmallSearchInputBox1_csr_sboxdiv").css("line-height", "17px");
            $('#fA0Main').find('img').css("margin-top", "-8px");

            if ($("#ctl00_PlaceHolderSearchArea_SmallSearchInputBox1_csr_sbox").length == 0) {
                $("#ms-helpSearch").hide();
            }

            //hide Change the look link from Site Settings menu
            $('#zz5_MenuItem_ChangeTheLook').remove();
        } catch(ex) {
        }
    }

    ExecuteOrDelayUntilScriptLoaded(epmLiveTweaks, 'jquery.min.js');

    window.walkme_ready = function() {
        try {
            var supportLink = $('#ctl00_TopHelpLinkSupport');
            supportLink.removeAttr('onclick');
            supportLink.attr('href', '#');
            supportLink.removeAttr('target');

            supportLink.click(function() {
                $("[rel=tooltipbottom]").tooltip('hide');
                $('.walkme-menu-click-close').after('<a id="support-link" style="display: none; right: 31px !important; top:  8px !important; width: 220px !important; height: 25px !important; z-index: 2147483647 !important; position: absolute !important; font-size: 14px; color: #1F80C8" href="http://support.epmlive.com" target="_blank">Visit our Support Community</a>');
                WalkMePlayerAPI.toggleMenu();

            });
        } catch(e) {
        }
    };

    window.walkme_player_event = function(eventData) {
        try {
            if (eventData.Type === "AfterMenuOpen") {
                $('#support-link').fadeIn("slow");
            }

            if (eventData.Type === "BeforeMenuClose") {
                $('#support-link').fadeOut("fast");
            }
        } catch(e) {
        }
    };

    (function () {
        var uv = document.createElement('script');
        uv.type = 'text/javascript';
        uv.async = true;
        uv.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'widget.uservoice.com/yEDMyjE4NNMKmmRoDiWQ.js';
        var s = document.getElementsByTagName('script')[0];
        s.parentNode.insertBefore(uv, s);
    })();
})();