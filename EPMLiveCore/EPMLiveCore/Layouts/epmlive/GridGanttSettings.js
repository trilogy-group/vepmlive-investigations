/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" />
function GridGanttInit() {
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

    $(function () {
        if ($('#' + cbEnableReport).length > 0) {
            $('#' + cbEnableReport).click(function (e) {
                PreDeleteCheck(e, $(this).attr('id'));
            });
        }
    });

}
ExecuteOrDelayUntilScriptLoaded(GridGanttInit, "EPMLive.js");