/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" />
function QuikLnchInit() {
    $(document).ready(function () {

        if ($('#' + btnNewNavId)) {
            $('#' + btnNewNavId).attr('href', '#')
                            .removeAttr('target')
                            .click(function () {
                                var options = {
                                    url: webUrl + '/_layouts/epmlive/customnewnav.aspx?nodetype=quiklnch&appid=' + appId,
                                    title: 'New Navigation Link',
                                    allowMaximize: false,
                                    showClose: true,
                                    dialogReturnValueCallback: QuickLaunchCallBackMethod
                                };

                                SP.UI.ModalDialog.showModalDialog(options);
                                return false;
                            });
        }

        if ($('#' + btnNewCatId)) {
            $('#' + btnNewCatId).attr('href', '#')
                            .removeAttr('target')
                            .click(function () {
                                var options = {
                                    url: webUrl + '/_layouts/epmlive/customnewnav.aspx?parentid=1025&nodetype=quiklnch&isheading=true&appid=' + appId,
                                    title: 'New Heading',
                                    allowMaximize: false,
                                    showClose: true,
                                    dialogReturnValueCallback: QuickLaunchCallBackMethod
                                };

                                SP.UI.ModalDialog.showModalDialog(options);
                                return false;
                            });
        }

        if ($('#' + btnReorderId)) {
            $('#' + btnReorderId).attr('href', '#')
                            .removeAttr('target')
                            .click(function () {
                                var options = {
                                    url: webUrl + '/_layouts/epmlive/customqlreord.aspx?nodetype=quiklnch&appid=' + appId,
                                    title: 'Change Order',
                                    allowMaximize: false,
                                    showClose: true,
                                    dialogReturnValueCallback: QuickLaunchCallBackMethod
                                };

                                SP.UI.ModalDialog.showModalDialog(options);
                                return false;
                            });
        }

    });

    window.QuickLaunchCallBackMethod = function (result, value) {
        switch (result) {
            case 'ok':
                SP.UI.ModalDialog.RefreshPage(SP.UI.DialogResult.OK);
                break;
            case 'cancel':
                break;
        }
    }


    window.QLOpenUrlWithModal = function (url, title) {
        var options = { url: webUrl + url,
            title: title,
            allowMaximize: false,
            showClose: false,
            dialogReturnValueCallback: QuickLaunchCallBackMethod
        };

        SP.UI.ModalDialog.showModalDialog(options);
        return false;
    }

}
ExecuteOrDelayUntilScriptLoaded(QuikLnchInit, "EPMLive.js");
