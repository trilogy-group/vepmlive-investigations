(function() {
    'use strict';

    window.toggleSearch = function() {
        var $sbox = $('#search-box-container');
        var $sicon = $('#search-container a');
        var $sinput = $($sbox.find('input').get(0));

        $sinput.focus();

        if ($sbox.is(':visible')) {
            $sicon.css('color', '#00668E');
        } else {
            $sicon.css('color', '#FFFFFF');
        }

        $sbox.toggle('fast');
    };

    window.updateProfilePic = function() {
        OpenPopUpPageWithTitle(window.epmLive.currentSiteUrl + '/_layouts/15/epmlive/UploadProfilePicture.aspx', profilePicUpdated, null, null, 'Update Profile Photo');
    };

    window.profilePicUpdated = function(status, picUrl) {
        if (status === 1) {
            $('#EPMLiveProfilePic').attr('src', picUrl);
        }
    };

    window.walkme_ready = function() {
        var $supportLink = $('#epm-support-link');
        $supportLink.attr('href', '#');
        $supportLink.removeAttr('target');

        $supportLink.click(function () {
            $('.walkme-menu-click-close').after('<a id="support-link" style="display: none; right: 31px !important; top:  8px !important; width: 220px !important; height: 25px !important; z-index: 2147483647 !important; position: absolute !important; font-size: 14px; color: #1F80C8" href="http://support.epmlive.com" target="_blank">Visit our Support Community</a>');
            window.WalkMePlayerAPI.toggleMenu();
        });
    };

    window.walkme_player_event = function (eventData) {
        if (eventData.Type === "AfterMenuOpen") {
            $('#epm-support-link').css('color', '#FFFFFF');
        }

        if (eventData.Type === "BeforeMenuClose") {
            $('#epm-support-link').css('color', '#00668E');
        }
    };

    var epmLiveTweaks = function() {
        $(document).click(function(e) {
            if ($('#search-box-container').is(':visible')) {
                if ($(e.target).parents('#search-box-container').length === 0 && $(e.target).parents('#search-container').length === 0) {
                    toggleSearch();
                }
            }
        });

        var addUpdateProfilePicLink = function() {
            var $menuitems = $('#welcomeMenuBox').find('ie\\:menuitem');

            if ($menuitems.length > 0) {
                $('<ie:menuitem menugroupid="100" description="Update your profile photo." text="Update Profile Photo" onmenuclick="javascript:window.updateProfilePic();" type="option" id="epm-update-profile-pic" enabled="true" checked="false" onmenuclick_original="javascript:window.updateProfilePic();" text_original="Update Profile Photo" description_original="Update your profile photo." valorig=""></ie:menuitem>').insertAfter('#' + $('#welcomeMenuBox').find('ie\\:menuitem').get(0).id);
            } else {
                window.setTimeout(function() {
                    addUpdateProfilePicLink();
                }, 1);
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

        configureSearchBox();
        addUpdateProfilePicLink();
    };

    ExecuteOrDelayUntilScriptLoaded(epmLiveTweaks, 'jquery.min.js');
})();