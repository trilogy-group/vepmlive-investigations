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

function HandleCheckClick(lineID) {
    var rowCount = $('#SubscriptionsTable tr').length;
    var hasItemChecked = false;
    for (i = 0; i < rowCount - 1; i++) {
        hasItemChecked = hasItemChecked || $('#ckSubsListItemID' + i).is(':checked');
    }

    if (hasItemChecked) {
        $("#chkEnableSub").removeClass("disabled");
        $("#chkDisableSub").removeClass("disabled");
        $("#chkDeleteSub").removeClass("disabled");
    }
    else {
        $("#chkEnableSub").addClass("disabled");
        $("#chkDisableSub").addClass("disabled");
        $("#chkDeleteSub").addClass("disabled");
    }
}

var subscriptionsList;

function OpenSubscriptions() {
    $("#ViewerDiv").fadeOut("slow", function () {
        $("#LoadingDiv").fadeIn();
        var qString = "?" + window.location.href.split("?")[1];

        $.ajax({
            type: "POST",
            url: "SSRSNativeReportViewer.aspx/GetSubscriptions" + qString,
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: 'json',

            success: function (data) {

                $("#SubscriptionsTable").find("tr:gt(0)").remove();
                $("#SubscribeManagerDiv").css("visibility", "visible");
                $("#SubscribeManagerDiv").fadeIn();
                $("#SubscriptionsTable").show();
                $("#LoadingDiv").fadeOut();

                HandleCheckClick(0);
                $('#chkCheckAll').prop('checked', false);

                var objdata = $.parseJSON(data.d);
                subscriptionsList = objdata.Table;

                if (objdata != null) {
                    for (i = 0; i < objdata.Table.length; i++) {
                        if (objdata.Table[i] != null) {
                            $("#SubscriptionsTable").append('<tr>' +
                                '<td><input type="checkbox" onclick="HandleCheckClick(' + i + ')" id="ckSubsListItemID' + i + '"/>' +
                                '<input type="hidden" id="SubsID' + i + '" value="' + objdata.Table[i][5] + '"/></td>' +
                                '<td>' + objdata.Table[i][0] + '</td>' +
                                '<td>' + objdata.Table[i][1] + '</td>' +
                                '<td>' + objdata.Table[i][2] + '</td>' +
                                '<td>' + objdata.Table[i][3] + '</td>' +
                                '<td>' + objdata.Table[i][4] + '</td>' +
                                '</tr>');
                        }
                    }
                }
            },
            error: function (XHR, errStatus, errorThrown) {
                $("#LoadingDiv").fadeOut();
                var err = JSON.parse(XHR.responseText);
                alert("Error. " + err.Message);
            }
        });
    });
}

function BackToViewer() {
    $("#SubscribeManagerDiv").fadeOut("slow", function () {
        $("#AddSubscriptionForm").css("visibility", "hidden");
        $("#ViewerDiv").fadeIn();
    });
}

function BackToSubsManager() {
    $("#AddSubscriptionForm").fadeOut("slow", function () {
        $("#SubscribeManagerDiv").fadeIn();
    });
}


function RedirectAddSubscription() {
    $("#SubscribeManagerDiv").fadeOut("slow", function () {

        $("#ReportParameters").empty();
        $("#QtyParamsDiv").empty();

        //ReportParameters
        var qString = "?" + window.location.href.split("?")[1];

        $.ajax({
            type: "POST",
            url: "SSRSNativeReportViewer.aspx/GetReportParameters" + qString,
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: 'json',

            success: function (data) {
                var objdata = $.parseJSON(data.d);
                $("#ReportParameters").append(objdata);
            },
            error: function (XHR, errStatus, errorThrown) {
                var err = JSON.parse(XHR.responseText);
                alert("Error. " + err.Message);
            }
        });

        $.ajax({
            type: "POST",
            url: "SSRSNativeReportViewer.aspx/GetDeliveryExtensions" + qString,
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: 'json',

            success: function (data) {
                var objdata = $.parseJSON(data.d);
                $("#DeliveryMethodOptions").append(objdata);
            },
            error: function (XHR, errStatus, errorThrown) {
                var err = JSON.parse(XHR.responseText);
                alert("Error. " + err.Message);
            }
        });


        $("#AddSubscriptionForm").css("visibility", "visible");
        $("#AddSubscriptionForm").fadeIn();
    });
}

function EnterFieldChange(fieldID) {

    var valueFieldName = "ValueFieldID" + fieldID;
    var enterFieldName = "EnterFieldID" + fieldID;

    var enterValue = document.getElementById(enterFieldName).value;
    if (enterValue == "enter")
        $("#" + valueFieldName).prop('disabled', false);
    else {
        $("#" + valueFieldName).prop('disabled', true);
        if (document.getElementById(valueFieldName).nodeName == "INPUT")
            document.getElementById(valueFieldName).defaultValue = document.getElementById(valueFieldName).getAttribute("defaultValue");
        else if (document.getElementById(valueFieldName).nodeName == "SELECT") {
            var selectElement = document.getElementById(valueFieldName);
            for (i = 0; i < selectElement.length; i++) {
                if (selectElement.options[i].defaultSelected)
                    selectElement.options[i].selected = 'selected';
            }
        }
    }
}

function ChangeDeliveryMethod() {
    var selValue = $("#DeliveryMethodOptions").val();
    switch (selValue) {
        case 'choose':
        case 'Null Delivery Provider':
            $("#WindowsFileDelMethod").css("visibility", "collapse");
            break;
        case 'Windows File Share':
            $("#WindowsFileDelMethod").css("visibility", "visible");
            break;
    }
}

function GetMatchData() {
    var scheduleOption = $("input[name='editschedule']:checked").val();
    var xml = "<ScheduleDefinition>";

    switch (scheduleOption) {
        case "hour":
            break;
        case "day":
            break;
        case "week":
            xml += "<WeeklyRecurrence>";

            xml += "</WeeklyRecurrence>";
            break;
        case "month":
            break;
        case "once":
            break;
    }

    xml += "</ScheduleDefinition>";
}

function SaveSubscription() {
    //ReportParameters
    var qString = "?" + window.location.href.split("?")[1];

    var description = $("#Description").val();
    var deliveryMethod = $("#DeliveryMethodOptions").val();
    var renderFormat = $("#RenderFormat").val();
    var fileName = $("#FileName").val();
    var fileExtensionAdd = $("#FileExtensionAdd").val();
    var path = $("#Path").val();
    var overwrite = $("input[name='overwriteoptions']:checked").val();
    var username = $("#UserNameWindows").val();
    var password = $("#PasswordWindows").val();
    var renderFormat = $("#RenderFormat").val();
    var qtyParams = $("#QtyParams").val();

    var reportParamsList = "";
    if (qtyParams != null) {
        var qtyParamsInt = parseInt(qtyParams);
        for (i = 0; i < qtyParamsInt; i++) {

            var labelID = "FieldLabelID" + i;
            var valueFieldID = "ValueFieldID" + i;

            if (document.getElementById(valueFieldID).nodeName == "SELECT") {
                $('#' + valueFieldID + ' :selected').each(function (i, selected) {
                    reportParamsList += $("#" + labelID).text() + "|";
                    reportParamsList += $(selected).text() + "||";
                });
            } else if (document.getElementById(valueFieldID).nodeName == "INPUT") {
                reportParamsList += $("#" + labelID).text() + "|";
                reportParamsList += $("#" + valueFieldID).val() + "||";
            }
        }
    }

    $.ajax({
        type: "POST",
        url: "SSRSNativeReportViewer.aspx/SaveSubscription" + qString,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: 'json',

        success: function (data) {
            var objdata = $.parseJSON(data.d);
            $("#ReportParameters").append(objdata);
        },
        error: function (XHR, errStatus, errorThrown) {
            var err = JSON.parse(XHR.responseText);
            alert("Error. " + err.Message);
        }
    });
}

function EditSchedule() {
    $("#AddSubscriptionForm").fadeOut("slow", function () {

        $("#EditScheduleForm").css("visibility", "visible");
        $("#EditScheduleForm").fadeIn();
    });
}

function BackToSubsAdd() {
    $("#EditScheduleForm").fadeOut("slow", function () {

        $("#AddSubscriptionForm").css("visibility", "visible");
        $("#AddSubscriptionForm").fadeIn();
    });
}

function TimeBasisChanged(optionChecked) {

    $("#HourlySchedule").css("display", "none");
    $("#DaylySchedule").css("display", "none");
    $("#WeeklySchedule").css("display", "none");
    $("#MonthlySchedule").css("display", "none");
    $("#OneTimeSchedule").css("display", "none");

    $("#" + optionChecked).css("display", "inline");
}

function CheckAll() {
    var rowCount = $('#SubscriptionsTable tr').length;
    var checkAllState = $('#chkCheckAll').is(':checked');

    for (i = 0; i < rowCount - 1; i++) {
        $('#ckSubsListItemID' + i).prop('checked', checkAllState);
    }

    HandleCheckClick(0);
}

function EnableDisableSubscription(isEnabled) {
    var stringEnabeldDisabled = "";
    if (isEnabled) stringEnabeldDisabled = "enable";
    else stringEnabeldDisabled = "disable";

    if (CanPerformSubsAction() && confirm('You\'re about to ' + stringEnabeldDisabled + ' the subscription(s) selected. Please press OK to confirm.')) {

        $("#SubscribeManagerDiv").fadeOut("slow", function () {
            $("#LoadingDiv").fadeIn();
            var rowCount = $('#SubscriptionsTable tr').length;
            var subsIds = "";
            for (i = 0; i < rowCount - 1; i++) {
                if ($('#ckSubsListItemID' + i).is(':checked')) {
                    subsIds += $("#SubsID" + i).val() + "|";
                }
            }

            $.ajax({
                type: "POST",
                url: "SSRSNativeReportViewer.aspx/EnableDisableSubscription",
                data: JSON.stringify({ subsIdList: subsIds, enable: isEnabled }),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',

                success: function (data) {
                    alert('Subscription(s) has been successfully ' + stringEnabeldDisabled + 'd.');
                    OpenSubscriptions();
                },
                error: function (XHR, errStatus, errorThrown) {
                    var err = JSON.parse(XHR.responseText);
                    alert("Error. " + err.Message);
                    $("#LoadingDiv").fadeOut();
                    $("#SubscribeManagerDiv").fadeIn();
                }
            });
        });
    }
}

function DeleteSubscription() {
    if (CanPerformSubsAction() && confirm("You're about to delete the subscription(s) selected. Please press OK to confirm.")) {
        $("#SubscribeManagerDiv").fadeOut("slow", function () {
            $("#LoadingDiv").fadeIn();

            var rowCount = $('#SubscriptionsTable tr').length;
            var subsIds = "";
            for (i = 0; i < rowCount - 1; i++) {
                if ($('#ckSubsListItemID' + i).is(':checked')) {
                    subsIds += $("#SubsID" + i).val() + "|";
                }
            }

            $.ajax({
                type: "POST",
                url: "SSRSNativeReportViewer.aspx/DeleteSubscription",
                data: JSON.stringify({ subsIdList: subsIds }),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',

                success: function (data) {
                    alert('Subscription(s) has been successfully deleted.');
                    OpenSubscriptions();
                },
                error: function (XHR, errStatus, errorThrown) {
                    var err = JSON.parse(XHR.responseText);
                    alert("Error. " + err.Message);
                    $("#LoadingDiv").fadeOut();
                    $("#SubscribeManagerDiv").fadeIn();
                }
            });
        });
    }
}

function CanPerformSubsAction() {
    if (!$("#chkEnableSub").hasClass("disabled"))
        return true;

    alert("Invalid operation. Please select at least one subscription.");
    return false;
}