﻿var linkBuilder = "";
var initHTML = '';

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
                initHTML = $("#AddForm").html();
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

function ViewSubscription(id) {
    var subsIDFromField = $("#SubsID" + id).val();
    $("#CurrentSubsID").val(subsIDFromField);

    $.ajax({
        type: "POST",
        url: "SSRSNativeReportViewer.aspx/GetSubscription",
        data: JSON.stringify({ subsID: subsIDFromField }),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',

        success: function (data) {
            var objdata = $.parseJSON(data.d);

            if (objdata != null) {
                $("#Description").val(objdata.Description);
                $("#DeliveryMethodOptions").val(objdata.DeliverySettings.Extension);
                ChangeDeliveryMethod();

                if (objdata.DeliverySettings.Extension == 'Report Server FileShare') {
                    $.each(objdata.DeliverySettings.ParameterValues, function (index, value) {
                        switch (value.Name.toUpperCase()) {
                            case "FILENAME":
                                $("#FileName").val(value.Value);
                                break;
                            case "FILEEXTN":
                                $("#FileExtensionAdd").val(value.Value);
                                break;
                            case "PATH":
                                $("#Path").val(value.Value);
                                break;
                            case "RENDER_FORMAT":
                                $("#RenderFormat").val(value.Value);
                                break;
                            case "USERNAME":
                                $("#UserNameWindows").val(value.Value);
                                break;
                            case "PASSWORD":
                                $("#PasswordWindows").val(value.Value);
                                break;
                            case "WRITEMODE":
                                $('input[name="overwriteoptions"]:checked').val(value.Value);
                                break;
                        }
                    });
                }
                else if (objdata.DeliverySettings.Extension == 'Report Server Email') {
                    $.each(objdata.DeliverySettings.ParameterValues, function (index, value) {
                        switch (value.Name.toUpperCase()) {
                            case "TO":
                                $("#EmailTo").val(value.Value);
                                break;
                            case "CC":
                                $("#EmailCC").val(value.Value);
                                break;
                            case "BCC":
                                $("#EmailBcc").val(value.Value);
                                break;
                            case "REPLYTO":
                                $("#ReplyTo").val(value.Value);
                                break;
                            case "INCLUDEREPORT":
                                $("#EmailIncludeReport").prop("checked", value.Value.toUpperCase() == "TRUE");
                                break;
                            case "INCLUDELINK":
                                $("#EmailIncludeLink").prop("checked", value.Value.toUpperCase() == "TRUE");
                                break;
                            case "RENDERFORMAT":
                                $("#EmailRenderFormat").val(value.Value);
                                break;
                            case "PRIORITY":
                                $("#EmailPriority").val(value.Value);
                                break;
                            case "SUBJECT":
                                $("#EmailSubject").val(value.Value);
                                break;
                            case "COMMENT":
                                if (value.Value.toString() != 'undefined')
                                    $("#EmailComment").val(value.Value);
                                break;
                        }
                    });
                }

                var qtyParams = $("#QtyParams").val();
                var auxValue = '';
                $.each(objdata.ReportParams, function (index, value) {
                    auxValue = value.Value;
                    if (auxValue.toUpperCase() == "TRUE") auxValue = "true";
                    else if (auxValue.toUpperCase() == "FALSE") auxValue = "false";

                    for (var i = 0; i < qtyParams; i++) {
                        if ($("#ParamItemNameID" + i).val() == value.Name) {

                            if (document.getElementById("ValueFieldID" + i).nodeName == "SELECT") {
                                $("#ValueFieldID" + i + " option[value='" + auxValue + "']").prop("selected", true);
                            }
                            else if (document.getElementById("ValueFieldID" + i).nodeName == "INPUT") {
                                $("#ValueFieldID" + i).val(auxValue);
                            }
                            break;
                        }
                    }
                });

                var parser, xmlDoc;
                parser = new DOMParser();
                xmlDoc = parser.parseFromString(objdata.MatchData, "text/xml");

                if (!(xmlDoc.getElementsByTagName("MinuteRecurrence")[0] === undefined)) {
                    $('input[name=editschedule][value="hour"]').attr('checked', 'checked');
                    if (!(xmlDoc.getElementsByTagName("MinutesInterval")[0].childNodes[0].nodeValue === undefined)) {
                        var minutesTotal = parseInt(xmlDoc.getElementsByTagName("MinutesInterval")[0].childNodes[0].nodeValue);
                        $("#HourlyScheduleHour").val(Math.floor(minutesTotal / 60));
                        $("#HourlyScheduleMinutes").val(minutesTotal % 60);
                    }

                    TimeBasisChanged("HourlySchedule");
                }
                else if (!(xmlDoc.getElementsByTagName("WeeklyRecurrence")[0] === undefined)) {
                    $('input[name=editschedule][value="week"]').attr('checked', 'checked');
                    $("#RepeateNmbWeeks").val(xmlDoc.getElementsByTagName("WeeksInterval")[0].childNodes[0].nodeValue);

                    if (!(xmlDoc.getElementsByTagName("Sunday")[0] === undefined))
                        $("#WeeklyScheduleSun").prop("checked", xmlDoc.getElementsByTagName("Sunday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Monday")[0] === undefined))
                        $("#WeeklyScheduleMon").prop("checked", xmlDoc.getElementsByTagName("Monday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Tuesday")[0] === undefined))
                        $("#WeeklyScheduleTue").prop("checked", xmlDoc.getElementsByTagName("Tuesday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Wednesday")[0] === undefined))
                        $("#WeeklyScheduleWed").prop("checked", xmlDoc.getElementsByTagName("Wednesday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Thursday")[0] === undefined))
                        $("#WeeklyScheduleThu").prop("checked", xmlDoc.getElementsByTagName("Thursday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Friday")[0] === undefined))
                        $("#WeeklyScheduleFri").prop("checked", xmlDoc.getElementsByTagName("Friday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Saturday")[0] === undefined))
                        $("#WeeklyScheduleSat").prop("checked", xmlDoc.getElementsByTagName("Saturday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");

                    TimeBasisChanged("WeeklySchedule");
                }
                else if (!(xmlDoc.getElementsByTagName("DailyRecurrence")[0] === undefined)) {
                    $('input[name=editschedule][value="day"]').attr('checked', 'checked');
                    $('input[name="dailyoptions"]:checked').val(numbdays);
                    $('#RepeateNmbDays').val(xmlDoc.getElementsByTagName("DaysInterval")[0].childNodes[0].nodeValue);

                    TimeBasisChanged("DaylySchedule");
                }
                else if (!(xmlDoc.getElementsByTagName("MonthlyDOWRecurrence")[0] === undefined)) {
                    $('input[name=editschedule][value="month"]').attr('checked', 'checked');
                    $('input[name="monthlyoptions"]:checked').val("onweek");
                    $("#MonthlyOptionsWhichWeek").val(xmlDoc.getElementsByTagName("WhichWeek")[0].childNodes[0].nodeValue);

                    if (!(xmlDoc.getElementsByTagName("Sunday")[0] === undefined))
                        $("#MonthlyScheduleSun").prop("checked", xmlDoc.getElementsByTagName("Sunday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Monday")[0] === undefined))
                        $("#MonthlyScheduleMon").prop("checked", xmlDoc.getElementsByTagName("Monday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Tuesday")[0] === undefined))
                        $("#MonthlyScheduleTue").prop("checked", xmlDoc.getElementsByTagName("Tuesday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Wednesday")[0] === undefined))
                        $("#MonthlyScheduleWed").prop("checked", xmlDoc.getElementsByTagName("Wednesday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Thursday")[0] === undefined))
                        $("#MonthlyScheduleThu").prop("checked", xmlDoc.getElementsByTagName("Thursday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Friday")[0] === undefined))
                        $("#MonthlyScheduleFri").prop("checked", xmlDoc.getElementsByTagName("Friday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("Saturday")[0] === undefined))
                        $("#MonthlyScheduleSat").prop("checked", xmlDoc.getElementsByTagName("Saturday")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");

                    TimeBasisChanged("MonthlySchedule");
                }
                else if (!(xmlDoc.getElementsByTagName("MonthlyRecurrence")[0] === undefined)) {
                    $('input[name=editschedule][value="month"]').attr('checked', 'checked');
                    $('input[name="monthlyoptions"]:checked').val("oncalendardays");
                    $("#OnCalendarDays").val(xmlDoc.getElementsByTagName("Days")[0].childNodes[0].nodeValue);

                    TimeBasisChanged("MonthlySchedule");
                }

                if ((!(xmlDoc.getElementsByTagName("MonthlyDOWRecurrence")[0] === undefined)) || (!(xmlDoc.getElementsByTagName("MonthlyRecurrence")[0] === undefined))) {
                    if (!(xmlDoc.getElementsByTagName("January")[0] === undefined))
                        $("#MonthlyScheduleJan").prop("checked", xmlDoc.getElementsByTagName("January")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("February")[0] === undefined))
                        $("#MonthlyScheduleFeb").prop("checked", xmlDoc.getElementsByTagName("February")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("March")[0] === undefined))
                        $("#MonthlyScheduleMar").prop("checked", xmlDoc.getElementsByTagName("March")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("April")[0] === undefined))
                        $("#MonthlyScheduleApr").prop("checked", xmlDoc.getElementsByTagName("April")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("May")[0] === undefined))
                        $("#MonthlyScheduleMay").prop("checked", xmlDoc.getElementsByTagName("May")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("June")[0] === undefined))
                        $("#MonthlyScheduleJun").prop("checked", xmlDoc.getElementsByTagName("June")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("July")[0] === undefined))
                        $("#MonthlyScheduleJul").prop("checked", xmlDoc.getElementsByTagName("July")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("August")[0] === undefined))
                        $("#MonthlyScheduleAug").prop("checked", xmlDoc.getElementsByTagName("August")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("September")[0] === undefined))
                        $("#MonthlyScheduleSep").prop("checked", xmlDoc.getElementsByTagName("September")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("October")[0] === undefined))
                        $("#MonthlyScheduleOct").prop("checked", xmlDoc.getElementsByTagName("October")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("November")[0] === undefined))
                        $("#MonthlyScheduleNov").prop("checked", xmlDoc.getElementsByTagName("November")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                    if (!(xmlDoc.getElementsByTagName("December")[0] === undefined))
                        $("#MonthlyScheduleDec").prop("checked", xmlDoc.getElementsByTagName("December")[0].childNodes[0].nodeValue.toString().toUpperCase() == "TRUE");
                }

                var startDateTime = new Date(xmlDoc.getElementsByTagName("StartDateTime")[0].childNodes[0].nodeValue.toString());
                $("#StarTimeHour").val(startDateTime.getHours());
                $("#StarTimeMinutes").val(startDateTime.getMinutes());
                $("#StartDateSchedule").val(("0" + (startDateTime.getMonth())).slice(-2) + "-" + ("0" + startDateTime.getDate()).slice(-2) + "-" + startDateTime.getFullYear());
            }
            else {
                alert('Error! Could not find the subscription.');
            }
        }
    });
}

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
                $("#SubscribeManagerDiv").css("display", "block");
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
                                '<td><a href="javascript:RedirectAddSubscription(' + i + ', true)">View</a></td>' +
                                '</tr>');
                        }
                    }
                }

                $("#SubscribeManagerDiv").fadeIn();
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
        $("#AddSubscriptionForm").css("display", "none");
        $("#ViewerDiv").fadeIn();
    });
}

function BackToSubsManager() {
    $("#AddSubscriptionForm").fadeOut("slow", function () {
        $("#SubscribeManagerDiv").fadeIn();
    });
}

function RedirectAddSubscription(id, isOpen) {

    $("#AddForm").html(initHTML);
    $("#CurrentSubsID").val("");
    RestoreDateTimePicker();

    $("#SubscribeManagerDiv").fadeOut("slow", function () {

        $("#ReportParameters").empty();
        $("#QtyParamsDiv").empty();
        $("#DeliveryMethodOptions").empty();

        var currDate = new Date();

        $("#StarTimeHour").val(currDate.getHours());
        $("#StarTimeMinutes").val(currDate.getMinutes());
        $("#StartDateSchedule").val(("0" + (currDate.getMonth() + 1)).slice(-2) + "-" + ("0" + currDate.getDate()).slice(-2) + "-" + currDate.getFullYear());

        //ReportParameters
        var qString = "?" + window.location.href.split("?")[1];

        $.ajax({
            type: "POST",
            url: "SSRSNativeReportViewer.aspx/GetDeliveryExtensions" + qString,
            data: {},
            contentType: "application/json; charset=utf-8",
            dataType: 'json',

            success: function (data) {
                var objdata = $.parseJSON(data.d);
                $("#DeliveryMethodOptions").append(objdata);

                $.ajax({
                    type: "POST",
                    url: "SSRSNativeReportViewer.aspx/GetReportParameters" + qString,
                    data: {},
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',

                    success: function (data) {
                        var objdata = $.parseJSON(data.d);
                        $("#ReportParameters").append(objdata);

                        if (isOpen)
                            ViewSubscription(id);
                    },
                    error: function (XHR, errStatus, errorThrown) {
                        var err = JSON.parse(XHR.responseText);
                        alert("Error. " + err.Message);
                    }
                });
            },
            error: function (XHR, errStatus, errorThrown) {
                var err = JSON.parse(XHR.responseText);
                alert("Error. " + err.Message);
            }
        });


        $("#AddSubscriptionForm").css("display", "block");
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
    $("#WindowsFileDelMethod").css("display", "none");
    $("#EmailMethod").css("display", "none");

    switch (selValue) {
        case 'Report Server FileShare':
            $("#WindowsFileDelMethod").css("display", "block");
            break;
        case 'Report Server Email':
            $("#EmailMethod").css("display", "block");
            break;
    }
}

function GetMatchData() {
    var scheduleOption = $("input[name='editschedule']:checked").val();
    var xml = '<?xml version="1.0" encoding="utf-16" standalone="yes"?>';
    xml += '<ScheduleDefinition xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">';
    xml += '<StartDateTime xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/03/01/ReportServer">';
    var splitDateItems = $("#StartDateSchedule").val().split('-');
    xml += (new Date(splitDateItems[2], splitDateItems[0], splitDateItems[1], parseInt($("#StarTimeHour").val()), parseInt($("#StarTimeMinutes").val()), 0, 0)).toJSON();
    xml += '</StartDateTime>';
    if ($('#chkStopDateSchedule').is(':checked') && $("#StopDateSchedule").val() != null && $("#StopDateSchedule").val().toString().trim() != '') {
        splitDateItems = $("#StopDateSchedule").val().split('-');
        xml += '<EndDate xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/03/01/ReportServer">';
        xml += (new Date(splitDateItems[2], splitDateItems[0], splitDateItems[1], 0, 0, 0, 0)).toJSON();
        xml += '</EndDate>';
    }

    switch (scheduleOption) {
        case "hour":
            xml += '<MinuteRecurrence xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/03/01/ReportServer"><MinutesInterval>';
            xml += (parseInt($("#HourlyScheduleHour").val()) * 60 + parseInt($("#HourlyScheduleMinutes").val()));
            xml += '</MinutesInterval></MinuteRecurrence>';
            break;
        case "day":

            var dailOptSelcted = $('input[name="dailyoptions"]:checked').val();
            switch (dailOptSelcted) {
                case "followingdays":
                    xml += '<WeeklyRecurrence xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/03/01/ReportServer">';
                    xml += '<WeeksInterval>1</WeeksInterval>';
                    xml += '<DaysOfWeek>';
                    if ($('#DailyoptionsSun').is(':checked'))
                        xml += '<Sunday>true</Sunday>';
                    if ($('#DailyoptionsMon').is(':checked'))
                        xml += '<Monday>true</Monday>';
                    if ($('#DailyoptionsTue').is(':checked'))
                        xml += '<Tuesday>true</Tuesday>';
                    if ($('#DailyoptionsWed').is(':checked'))
                        xml += '<Wednesday>true</Wednesday>';
                    if ($('#DailyoptionsThu').is(':checked'))
                        xml += '<Thursday>true</Thursday>';
                    if ($('#DailyoptionsFri').is(':checked'))
                        xml += '<Friday>true</Friday>';
                    if ($('#DailyoptionsSat').is(':checked'))
                        xml += '<Saturday>true</Saturday>';
                    xml += '</DaysOfWeek>';
                    xml += '</WeeklyRecurrence>';
                    break;
                case "weekdays":
                    xml += '<WeeklyRecurrence xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/03/01/ReportServer">';
                    xml += '<WeeksInterval>1</WeeksInterval>';
                    xml += '<DaysOfWeek>';
                    xml += '<Monday>true</Monday>';
                    xml += '<Tuesday>true</Tuesday>';
                    xml += '<Wednesday>true</Wednesday>';
                    xml += '<Thursday>true</Thursday>';
                    xml += '<Friday>true</Friday>';
                    xml += '</DaysOfWeek>';
                    xml += '</WeeklyRecurrence>';
                    break;
                case "numbdays":
                    xml += '<DailyRecurrence xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/03/01/ReportServer">';
                    xml += '<DaysInterval>'
                    xml += $('#RepeateNmbDays').val();
                    xml += '</DaysInterval>';
                    xml += '</DailyRecurrence>';
                    break;
            }
            break;
        case "week":
            xml += '<WeeklyRecurrence xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/03/01/ReportServer">';
            xml += '<WeeksInterval>' + $("#RepeateNmbWeeks").val() + '</WeeksInterval>';
            xml += '<DaysOfWeek>';
            if ($('#WeeklyScheduleSun').is(':checked'))
                xml += '<Sunday>true</Sunday>';
            if ($('#WeeklyScheduleMon').is(':checked'))
                xml += '<Monday>true</Monday>';
            if ($('#WeeklyScheduleTue').is(':checked'))
                xml += '<Tuesday>true</Tuesday>';
            if ($('#WeeklyScheduleWed').is(':checked'))
                xml += '<Wednesday>true</Wednesday>';
            if ($('#WeeklyScheduleThu').is(':checked'))
                xml += '<Thursday>true</Thursday>';
            if ($('#WeeklyScheduleFri').is(':checked'))
                xml += '<Friday>true</Friday>';
            if ($('#WeeklyScheduleSat').is(':checked'))
                xml += '<Saturday>true</Saturday>';
            xml += '</DaysOfWeek>';
            xml += '</WeeklyRecurrence>';
            break;
        case "month":
            var monthOptSelected = $('input[name="monthlyoptions"]:checked').val();
            var monthTag = '';
            switch (monthOptSelected) {
                case "onweek":
                    monthTag = '</MonthlyDOWRecurrence>';
                    xml += '<MonthlyDOWRecurrence xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/03/01/ReportServer">';
                    xml += '<WhichWeek>';
                    xml += $("#MonthlyOptionsWhichWeek").val();
                    xml += '</WhichWeek>';
                    xml += '<DaysOfWeek>';
                    if ($('#WeeklyScheduleSun').is(':checked'))
                        xml += '<Sunday>true</Sunday>';
                    if ($('#MonthlyScheduleMon').is(':checked'))
                        xml += '<Monday>true</Monday>';
                    if ($('#MonthlyScheduleTue').is(':checked'))
                        xml += '<Tuesday>true</Tuesday>';
                    if ($('#MonthlyScheduleWed').is(':checked'))
                        xml += '<Wednesday>true</Wednesday>';
                    if ($('#MonthlyScheduleThu').is(':checked'))
                        xml += '<Thursday>true</Thursday>';
                    if ($('#MonthlyScheduleFri').is(':checked'))
                        xml += '<Friday>true</Friday>';
                    if ($('#MonthlyScheduleSat').is(':checked'))
                        xml += '<Saturday>true</Saturday>';
                    xml += '</DaysOfWeek>';
                    break;
                case "oncalendardays":
                    xml += '<MonthlyRecurrence xmlns="http://schemas.microsoft.com/sqlserver/reporting/2010/03/01/ReportServer">';
                    monthTag = '</MonthlyRecurrence>';
                    xml += '<Days>';
                    xml += $("#OnCalendarDays").val();
                    xml += '</Days>';
                    break;
            }

            xml += '<MonthsOfYear>';
            if ($('#MonthlyScheduleJan').is(':checked'))
                xml += '<January>true</January>';
            if ($('#MonthlyScheduleFeb').is(':checked'))
                xml += '<February>true</February>';
            if ($('#MonthlyScheduleMar').is(':checked'))
                xml += '<March>true</March>';
            if ($('#MonthlyScheduleApr').is(':checked'))
                xml += '<April>true</April>';
            if ($('#MonthlyScheduleMay').is(':checked'))
                xml += '<May>true</May>';
            if ($('#MonthlyScheduleJun').is(':checked'))
                xml += '<June>true</June>';
            if ($('#MonthlyScheduleJul').is(':checked'))
                xml += '<July>true</July>';
            if ($('#MonthlyScheduleAug').is(':checked'))
                xml += '<August>true</August>';
            if ($('#MonthlyScheduleSep').is(':checked'))
                xml += '<September>true</September>';
            if ($('#MonthlyScheduleOct').is(':checked'))
                xml += '<October>true</October>';
            if ($('#MonthlyScheduleNov').is(':checked'))
                xml += '<November>true</November>';
            if ($('#MonthlyScheduleDec').is(':checked'))
                xml += '<December>true</December>';
            xml += '</MonthsOfYear>';
            xml += monthTag;
            break;
        case "once":
            break;
    }

    xml += "</ScheduleDefinition>";

    return xml;
}

function ValidateFields() {
    var errors = '';

    if ($("#DeliveryMethodOptions").val() == '' || $("#DeliveryMethodOptions").val() == 'choose')
        errors += "- 'Delivery Extension' is not selected.\n";

    if ($("#DeliveryMethodOptions").val() == 'Report Server FileShare') {
        if ($("#FileName").val() == '')
            errors += "- 'File name' is empty.\n";
        if ($("#Path").val() == '')
            errors += "- 'File path' is empty.\n";
        if ($("#UserNameWindows").val() == '')
            errors += "- 'User name' is empty.\n";
        if ($("#PasswordWindows").val() == '')
            errors += "- 'Password' is empty.\n";
    }
    else if ($("#DeliveryMethodOptions").val() == 'Report Server Email') {
        if ($("#EmailTo").val() == '')
            errors += "- 'Email To' is empty.\n";
        if ($("#EmailSubject").val() == '')
            errors += "- 'Subject' is empty.\n";
    }

    var scheduleOption = $("input[name='editschedule']:checked").val();
    switch (scheduleOption) {
        case "hour":
            if ($("#HourlyScheduleHour").val() == '' || $("#HourlyScheduleMinutes").val() == '')
                errors += "- Hour or minute field is empty for the selected Hourly schedule type.\n";
            break;
        case "day":
            var dailOptSelcted = $('input[name="dailyoptions"]:checked').val();
            switch (dailOptSelcted) {
                case "followingdays":
                    if (!$('#DailyoptionsSun').is(':checked') && !$('#DailyoptionsMon').is(':checked')
                        && !$('#DailyoptionsTue').is(':checked') && !$('#DailyoptionsWed').is(':checked')
                        && !$('#DailyoptionsThu').is(':checked') && !$('#DailyoptionsFri').is(':checked')
                        && !$('#DailyoptionsSat').is(':checked'))
                        errors += "- No day(s) selected for the Daily schedule type.\n";
                    break;
                case "weekdays":
                    break;
                case "numbdays":
                    if ($('#RepeateNmbDays').val() == '')
                        errors += "- Number of Days is empty for the Daily schedule type.\n";
                    break;
            }
            break;
        case "week":
            if ($("#RepeateNmbWeeks").val() == '')
                errors += "- Number of weeks was not informed for the Weekly schedule.\n";
            if (!$('#WeeklyScheduleSun').is(':checked') && !$('#WeeklyScheduleMon').is(':checked')
                && !$('#WeeklyScheduleTue').is(':checked') && !$('#WeeklyScheduleWed').is(':checked')
                && !$('#WeeklyScheduleThu').is(':checked') && !$('#WeeklyScheduleFri').is(':checked')
                && !$('#WeeklyScheduleSat').is(':checked'))
                errors += "- No day(s) selected for the Weekly schedule type.\n";
            break;
        case "month":
            var monthOptSelected = $('input[name="monthlyoptions"]:checked').val();
            switch (monthOptSelected) {
                case "onweek":
                    if (!$('#MonthlyScheduleSun').is(':checked') && !$('#MonthlyScheduleMon').is(':checked')
                        && !$('#MonthlyScheduleTue').is(':checked') && !$('#MonthlyScheduleWed').is(':checked')
                        && !$('#MonthlyScheduleThu').is(':checked') && !$('#MonthlyScheduleFri').is(':checked')
                        && !$('#MonthlyScheduleSat').is(':checked'))
                        errors += "- No day(s) selected for the Monthly schedule type.\n";
                    break;
                case "oncalendardays":
                    if ($("#OnCalendarDays").val() == '')
                        errors += "- Calendar days field is empty for the Monthly schedule type.\n";
                    break;
            }

            if (!$('#MonthlyScheduleJan').is(':checked') && !$('#MonthlyScheduleFeb').is(':checked')
                && !$('#MonthlyScheduleMar').is(':checked') && !$('#MonthlyScheduleApr').is(':checked')
                && !$('#MonthlyScheduleMay').is(':checked') && !$('#MonthlyScheduleJun').is(':checked')
                && !$('#MonthlyScheduleJul').is(':checked') && !$('#MonthlyScheduleAug').is(':checked')
                && !$('#MonthlyScheduleSep').is(':checked') && !$('#MonthlyScheduleOct').is(':checked')
                && !$('#MonthlyScheduleNov').is(':checked') && !$('#MonthlyScheduleDec').is(':checked'))
                errors += "- No month(s) selected for the Monthly schedule type.\n";
            break;
        case "once":
            break;
    }

    if ($("#StarTimeHour").val() == '' || $("#StarTimeMinutes").val() == '')
        errors += "- Hour or Minutes fields for the 'Schedule Details' is empty.\n";
    if ($("#StartDateSchedule").val() == '')
        errors += "- Start Date for the 'Schedule Details' is empty.\n";
    if ($('#chkStopDateSchedule').is(':checked') && $("#StopDateSchedule").val() == '')
        errors += "- Stop Date for the 'Schedule Details' is empty.\n";

    if (errors == '')
        return true;
    else {
        alert('The following errors were found:\n\n' + errors);
        return false;
    }
}

function GetDeliveryMethodParams(deliveryMethod) {
    var params = '';

    switch (deliveryMethod) {
        case 'Report Server FileShare':
            params += 'FILENAME|' + $("#FileName").val() + '[/]';
            params += 'FILEEXTN|' + $("#FileExtensionAdd").val() + '[/]';
            params += 'PATH|' + $("#Path").val() + '[/]';
            params += 'RENDER_FORMAT|' + $("#RenderFormat").val() + '[/]';
            params += 'USERNAME|' + $("#UserNameWindows").val() + '[/]';
            params += 'PASSWORD|' + $("#PasswordWindows").val() + '[/]';
            params += 'WRITEMODE|' + $('input[name="overwriteoptions"]:checked').val();
            break;
        case 'Report Server Email':
            params += 'TO|' + $("#EmailTo").val() + '[/]';
            params += 'CC|' + $("#EmailCC").val() + '[/]';
            params += 'BCC|' + $("#EmailBcc").val() + '[/]';
            params += 'ReplyTo|' + $("#EmailReplyTo").val() + '[/]';
            if ($('#EmailIncludeReport').is(':checked'))
                params += 'IncludeReport|true[/]';
            else
                params += 'IncludeReport|false[/]';
            params += 'RenderFormat|' + $("#EmailRenderFormat").val() + '[/]';
            params += 'Priority|' + $("#EmailPriority").val() + '[/]';
            params += 'Subject|' + $("#EmailSubject").val() + '[/]';
            params += 'Comment|' + $("EmailComment").val() + '[/]';
            if ($('#EmailIncludeLink').is(':checked'))
                params += 'IncludeLink|true';
            else
                params += 'IncludeLink|false';
            break;
    }

    return params;
}

function SaveSubscription() {
    try {
        if (ValidateFields()) {
            $("#AddSubscriptionForm").fadeOut("slow", function () {

                $("#LoadingDivSave").fadeIn();
                var qString = "?" + window.location.href.split("?")[1];

                var desc = $("#Description").val();
                var delMethod = $("#DeliveryMethodOptions").val();
                var delParams = GetDeliveryMethodParams(delMethod);
                var qtyParams = $("#QtyParams").val();
                var mData = GetMatchData();

                var reportParamsList = "";
                if (qtyParams != null) {
                    var qtyParamsInt = parseInt(qtyParams);
                    for (i = 0; i < qtyParamsInt; i++) {

                        var paramItemName = "ParamItemNameID" + i;
                        var valueFieldID = "ValueFieldID" + i;

                        if (document.getElementById(valueFieldID).nodeName == "SELECT") {
                            $('#' + valueFieldID + ' :selected').each(function (i, selected) {
                                reportParamsList += $("#" + paramItemName).val() + "|";
                                reportParamsList += $(selected).text() + "[/]";
                            });
                        } else if (document.getElementById(valueFieldID).nodeName == "INPUT") {
                            reportParamsList += $("#" + paramItemName).val() + "|";
                            reportParamsList += $("#" + valueFieldID).val() + "[/]";
                        }
                    }
                }

                var currentSubsID = $("#CurrentSubsID").val();
                $.ajax({
                    type: "POST",
                    url: "SSRSNativeReportViewer.aspx/SaveSubscription" + qString,
                    data: JSON.stringify({
                        description: desc, deliveryMethod: delMethod, deliveryParams: delParams,
                        matchData: mData, reportParametersList: reportParamsList, subsID: currentSubsID
                    }),
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',

                    success: function (data) {
                        var addOrUpdate = '';
                        if (currentSubsID === undefined || currentSubsID == "")
                            addOrUpdate = "added";
                        else
                            addOrUpdate = "updated";
                        $("#LoadingDivSave").fadeOut();
                        alert('Subscription has been successfully ' + addOrUpdate + '.');
                        OpenSubscriptions();
                    },
                    error: function (XHR, errStatus, errorThrown) {
                        $("#LoadingDivSave").fadeOut();
                        var err = JSON.parse(XHR.responseText);
                        alert("Error. " + err.Message);
                        $("#AddSubscriptionForm").fadeIn();
                    }
                });
            });
        }
    }
    catch (err) {
        alert('Error. ' + err.message);
    }
}

var htmlShedule;
function EditSchedule() {
    htmlShedule = $("#EditScheduleFormContent").clone(false, false);

    $("#AddSubscriptionForm").fadeOut("slow", function () {

        $("#EditScheduleForm").css("display", "block");
        $("#EditScheduleForm").fadeIn();
    });
}

function BackToSubsAdd(shouldReset) {

    if (shouldReset) {
        $("#EditScheduleForm").empty();
        htmlShedule.appendTo("#EditScheduleForm");
        $("#StartDateSchedule").removeClass('hasDatepicker');
        $("#StopDateSchedule").removeClass('hasDatepicker');
        RestoreDateTimePicker();
    }

    $("#EditScheduleForm").fadeOut("slow", function () {

        $("#AddSubscriptionForm").css("display", "block");
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
                    $("#LoadingDiv").fadeOut();
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

function RestoreDateTimePicker() {
    $('#StartDateSchedule').datepicker({ dateFormat: 'mm-dd-yy' });
    $('#StopDateSchedule').datepicker({ dateFormat: 'mm-dd-yy' });
}