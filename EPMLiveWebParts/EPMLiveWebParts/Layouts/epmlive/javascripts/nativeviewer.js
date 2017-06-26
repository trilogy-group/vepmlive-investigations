var linkBuilder = "";

$(window).resize(function () {
    var topUpper = $('#upper').height() + 5;
    $('#ReportFrame').css({ top: topUpper, left: 0, right: 0, bottom: 0, position: 'absolute' });
    $('#ReportFrame').height($(window).outerHeight() - (topUpper + 10));
});

$(document).ready(function () {
    var qString = "?" + window.location.href.split("?")[1];
    $.ajax({
        type: "POST",
        url: "SSRSNativeReportViewer.aspx/GetRegs" + qString,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: 'json',

        success: function (data) {
            var objdata = $.parseJSON(data.d);

            if (objdata != null) {
                var addresses = objdata.toString().split("|");
                $("#ReportFrame").attr('src', addresses[0]);
                linkBuilder = addresses[1];
            }
            else {
                alert('Error! Could not load report link.');
            }
        }
    });
});

function OpenEditor() {
    window.open(linkBuilder, "_parent");
}

function OpenSubscriptions() {
    $("#upper").hide();
    $("#ReportFrame").hide();
}