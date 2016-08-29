/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" />
function TopNavInit() {
    $(document).ready(function () {
        if ($('#' + btnNewNavId)) {
            $('#' + btnNewNavId).attr('href', '#')
                            .removeAttr('target')
                            .click(function () {
                                var options = {
                                    url: webUrl + '/_layouts/epmlive/customnewnav.aspx?nodetype=topnav&appid=' + appId,
                                    title: 'New Navigation Link',
                                    allowMaximize: false,
                                    showClose: false,
                                    dialogReturnValueCallback: TopNavCallBackMethod
                                };

                                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
                                return false;
                            });
        }

        if ($('#' + btnNewCatId)) {
            $('#' + btnNewCatId).attr('href', '#')
                            .removeAttr('target')
                            .click(function () {
                                var options = {
                                    url: webUrl + '/_layouts/epmlive/customnewnav.aspx?parentid=1002&nodetype=topnav&isheading=true&appid=' + appId,
                                    title: 'New Heading',
                                    allowMaximize: false,
                                    showClose: false,
                                    dialogReturnValueCallback: TopNavCallBackMethod
                                };

                                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
                                return false;
                            });
        }

        if ($('#' + btnReorderId)) {
            $('#' + btnReorderId).attr('href', '#')
                            .removeAttr('target')
                            .click(function () {
                                var options = {
                                    url: webUrl + '/_layouts/epmlive/customtnreord.aspx?nodetype=topnav&appid=' + appId,
                                    title: 'Change Order',
                                    allowMaximize: false,
                                    showClose: false,
                                    dialogReturnValueCallback: TopNavCallBackMethod
                                };

                                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
                                return false;
                            });
        }

    });

    window.TopNavCallBackMethod = function(result, value) {
        switch (result) {
            case '1':
                window.location.reload();
                break;
            case '0':
                break;
        }
    }


    window.TNOpenUrlWithModal = function(url, title) {
        var options = { url: webUrl + url,
            title: title,
            allowMaximize: false,
            showClose: false,
            dialogReturnValueCallback: TopNavCallBackMethod
        };

        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        return false;
    }
}
ExecuteOrDelayUntilScriptLoaded(TopNavInit, "EPMLive.js");