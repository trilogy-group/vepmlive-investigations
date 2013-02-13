$(function () {

    var initialize = function () {
        var k = window.ko;

        var importResourceStatus = {
            percentage: k.observable(0),
            currentProcess: k.observable('Initializing . . .'),
            log: k.observable(null),
            resources: k.observableArray([])
        };

        k.applyBindings(importResourceStatus, document.getElementById('epmcontainer'));

        var getStatus = function () {
            if (window.epmLive.currentWebFullUrl) {
                if (importResourceStatus.percentage() != 100) {
                    $.ajax({
                        url: window.epmLive.currentWebFullUrl + '/_layouts/epmlive/importresourcestatus.aspx?jobid=' + window.epmLive.jobId + '&format=json&token=' + new Date().getTime(),
                        type: 'GET',
                        success: function(data) {
                            if (!data.warmingUp) {
                                if (!data.error) {
                                    importResourceStatus.percentage(data.ProgressPercentage);
                                    importResourceStatus.currentProcess(data.CurrentProcess);
                                    importResourceStatus.log(data.Log);
                                    importResourceStatus.resources(data.Resources);
                                } else {
                                    importResourceStatus.percentage(100);
                                    importResourceStatus.currentProcess(data.error);
                                }

                                var log = $('#talog');
                                log.scrollTop(log[0].scrollHeight - log.height());

                                $('#resourcetable-wrap').animate({ scrollTop: $('#resourcetable').height() }, 495);
                            }

                            window.setTimeout(getStatus, 500);
                        },

                        error: function(data) {
                            window.setTimeout(getStatus, 500);
                        }
                    });
                }
            } else {
                window.setTimeout(getStatus, 500);
            }
        };

        getStatus();
    };

    var waitForKo = function () {
        if (window.ko) {
            initialize();
        } else {
            window.setTimeout(waitForKo, 10);
        }
    };

    waitForKo();
});