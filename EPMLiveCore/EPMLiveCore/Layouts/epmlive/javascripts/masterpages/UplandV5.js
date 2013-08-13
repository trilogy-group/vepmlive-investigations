(function() {
    'use strict';

    window.toggleSearch = function () {
        var $sbox = $('#search-box-container');
        var $sicon = $('#search-container');
        var $sinput = $('#ctl00_PlaceHolderSearchArea_SmallSearchInputBox1_csr_sbox');

        if ($sbox.is(':visible')) {
            $sicon.css('color', '#00668E');
        } else {
            $sicon.css('color', '#FFFFFF');
        }

        $sbox.toggle('fast', function () {
            $sinput.focus();
        });
    };

    window.updateProfilePic = function() {
        OpenPopUpPageWithTitle(window.epmLive.currentSiteUrl + '/_layouts/15/epmlive/UploadProfilePicture.aspx', profilePicUpdated, null, null, 'Update Profile Picture');
    };

    window.profilePicUpdated = function(status, picUrl) {
        if (status === 1) {
            $('#EPMLiveProfilePic').attr('src', picUrl);
        }
    };

    function epmLiveTweaks() {
        var hideSearchIfRequired = function() {
            var $sbtn = $('#search-container');
            var $sbox = $('#search-box-container');

            if ($sbtn.length === 0 || $sbox.length === 0) {
                window.setTimeout(function() {
                    hideSearchIfRequired();
                }, 1);
            } else {
                if ($sbox.find('input').length !== 1) {
                    $sbtn.hide();
                    $sbox.hide();
                }
            }
        };

        hideSearchIfRequired();

        $(document).click(function (e) {
            if ($('#search-box-container').is(':visible')) {
                if ($(e.target).parents('#search-box-container').length === 0 && $(e.target).parents('#search-container').length === 0) {
                    toggleSearch();
                }
            }
        });

        var addUpdateProfilePicLink = function() {
            var $menuitems = $('#welcomeMenuBox').find('ie\\:menuitem');
            
            if ($menuitems.length > 0) {
                $('<ie:menuitem menugroupid="100" description="Update your profile picture." text="Update Profile Picture" onmenuclick="javascript:window.updateProfilePic();" type="option" id="epm-update-profile-pic" enabled="true" checked="false" onmenuclick_original="javascript:window.updateProfilePic();" text_original="Update Profile Picture" description_original="Update your profile picture." valorig=""></ie:menuitem>').insertAfter('#' + $('#welcomeMenuBox').find('ie\\:menuitem').get(0).id);
            } else {
                window.setTimeout(function() {
                    addUpdateProfilePicLink();
                }, 1);
            }
        };

        addUpdateProfilePicLink();
    }

    ExecuteOrDelayUntilScriptLoaded(epmLiveTweaks, 'jquery.min.js');
})();