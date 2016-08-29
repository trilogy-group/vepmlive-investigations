(function() {
    'use strict';

    window.epmLiveUpgradeEnabled = false;

    window.allowEpmLiveUpgrade = function() {
        if (document.getElementById('chkTerms').checked == true) {
            window.epmLiveUpgradeEnabled = true;
            document.getElementById('btnUpgrade').className = 'button button-green';
        } else {
            window.epmLiveUpgradeEnabled = false;
            document.getElementById('btnUpgrade').className = 'button button-green-disabled';
        }
    };

    window.upgradeEpmLive = function (version) {
        if (window.epmLive && window.epmLive.currentWebUrl !== null) {
            if (window.epmLiveUpgradeEnabled) {
                var options = { url: window.epmLive.currentWebUrl + '/_layouts/15/epmlive/PerformUpgrade.aspx?V=' + version, width: 500, height: 250, showClose: true };
                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
            }
        } else {
            window.setTimeout(function() {
                window.upgradeEpmLive(version);
            }, 1);
        }
    };
})();