/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" />
function GridGanttInit() {
    (function (g, $, undefined) {
        function PreDeleteCheck(e, ctrlId) {
            if (!$('#' + ctrlId).is(':checked')) {
                var postData = { action: "deletecheck", listid: listid };
                $.post(reportActionUrl, postData, function (data) {
                    data = data.replace(/\r\n/g, '');
                    var result = data.split(',');
                    if (result[0] == 'true') {
                        $('#' + ctrlId).prop('checked', false);
                    }
                    else {
                        var slists = result[1];
                        alert('You need to disable these lists first: ' + slists);
                        $('#' + ctrlId).prop('checked', true);
                        e.stopPropagation();
                    }
                });
            }
        }

        // onload logic
        $(function () {
            if ($('#' + cbEnableReport).length > 0) {
                $('#' + cbEnableReport).click(function (e) {
                    PreDeleteCheck(e, $(this).attr('id'));
                });
            }

            if (!$('#' + cbEnableWSCreation).is(':checked')) {
                $('#' + cbAutoCreateId).attr('disabled', 'disabled');
                $('#' + ddlAutoCreateTemplateId).attr('disabled', 'disabled');
            }
            else if ($('#' + cbEnableWSCreation).is(':checked')) {
                $('#' + cbAutoCreateId).removeAttr('disabled');
                if ($('#' + cbAutoCreateId).is(':checked')) {
                    $('#' + ddlAutoCreateTemplateId).removeAttr('disabled');
                }
            }

            $('#' + cbEnableWSCreation).click(function () {
                if ($(this).is(':checked')) {
                    $('#' + cbAutoCreateId).removeAttr('disabled');
                }
                else {
                    $('#' + cbAutoCreateId).attr('checked', false);
                    $('#' + cbAutoCreateId).attr('disabled', 'disabled');
                    $('#' + ddlAutoCreateTemplateId).val(-1);
                    $('#' + ddlAutoCreateTemplateId).attr('disabled', 'disabled');
                }
            });

            $('#' + cbAutoCreateId).click(function () {
                if ($(this).is(':checked')) {
                    $('#' + ddlAutoCreateTemplateId).removeAttr('disabled');
                }
                else {
                    $('#' + ddlAutoCreateTemplateId).val(-1);
                    $('#' + ddlAutoCreateTemplateId).attr('disabled', 'disabled');
                }
            });

        });
    }(window.gridganttsettings = window.gridganttsettings || {}, jQuery));
}
ExecuteOrDelayUntilScriptLoaded(GridGanttInit, "EPMLive.js");