$(function () {
    ImportResourceStatusClient.waitForKo();
});

var ImportResourceStatusClient = (function () {

    var filterLogByStatus = function (status) {
        $("#importdetailslog tbody tr").hide();
        if (status == "All") {
            $("#importdetailslog tbody tr").show();
        } else {
            $("#importdetailslog tbody tr").each(function () {
                if ($(this).find("td:eq(1)").text().indexOf(status) >= 0) {
                    $(this).show();
                }
            });
        }
    };

    var initialize = function () {
        var k = window.ko;

        var status = {
            TotalRecords: k.observable(0),
            PercentComplete: k.observable(0),
            ProcessedRecords: k.observable(0),
            SuccessRecords: k.observable(0),
            FailedRecords: k.observable(0),
            CurrentProcess: k.observable("Initializing..."),
            infoCount: k.observable(0),
            warningCount: k.observable(0),
            errorCount: k.observable(0),
            log: ko.observableArray([])
        };

        k.applyBindings(status, document.getElementById('epmcontainer'));

        var getStatus = function () {
            if (window.epmLive.currentWebFullUrl) {
                if (status.PercentComplete() != 100) {
                    $.ajax({
                        url: window.epmLive.currentWebFullUrl + '/_layouts/epmlive/importresourcestatus.aspx?jobid=' + window.epmLive.jobId + '&format=json&token=' + new Date().getTime(),
                        type: 'GET',
                        success: function (data) {
                            try {
                                if (!data.warmingUp) {
                                    if (!data.error) {
                                        status.TotalRecords(data.TotalRecords);
                                        status.PercentComplete(data.PercentComplete);
                                        status.ProcessedRecords(data.ProcessedRecords);
                                        status.SuccessRecords(data.SuccessRecords);
                                        status.FailedRecords(data.FailedRecords);
                                        status.CurrentProcess(data.CurrentProcess);
                                        status.infoCount(data.Log.InfoCount);
                                        status.warningCount(data.Log.WarningCount);
                                        status.errorCount(data.Log.ErrorCount);
                                        status.log(data.Log.Messages);

                                        if (status.log().length > 0) {
                                            $("#lnkall").show();
                                            $("#lnkall").text("All (" + status.log().length + ")");
                                        }
                                        if (status.infoCount() > 0) {
                                            $("#lnkinfo").show();
                                            $("#lnkinfo").text("Info (" + status.infoCount() + ")");
                                        }
                                        if (status.warningCount() > 0) {
                                            $("#lnkwarning").show();
                                            $("#lnkwarning").text("Warning (" + status.warningCount() + ")");
                                        }
                                        if (status.errorCount() > 0) {
                                            $("#lnkerror").show();
                                            $("#lnkerror").text("Error (" + status.errorCount() + ")");
                                        }
                                    }
                                    else {
                                        status.PercentComplete(100);
                                    }
                                }
                            } catch (e) {
                                console.log(e);
                            }

                            window.setTimeout(getStatus, 500);
                        },
                        error: function (data) {
                            window.setTimeout(getStatus, 500);
                            //location.reload();
                        }
                    });
                }
                else {
                    $("#CancelImport").attr("disabled", true);
                }
            }

        };

        window.setTimeout(getStatus, 500);
    };

    var waitForKo = function () {
        if (window.ko) {
            initialize();
        } else {
            window.setTimeout(waitForKo, 500);
        }
    };

    return {
        waitForKo: waitForKo,
        filterLogByStatus: filterLogByStatus
    };

})();

var cancelImportResourceJob = function () {
    var result = confirm("Are you sure you want to cancel import resources task?");
    if (Boolean(result)) {
        $.ajax({
            url: window.epmLive.currentWebFullUrl + '/_layouts/epmlive/importresourcestatus.aspx?jobid=' + window.epmLive.jobId + '&isCancelImportResourceJob=true',
            type: 'GET'
        });
        $("#CancelImport").attr("disabled", true);
    }
}

