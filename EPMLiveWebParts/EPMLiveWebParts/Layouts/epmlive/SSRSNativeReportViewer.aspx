<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSRSNativeReportViewer.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.SSRSNativeReportViewer" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:content id="PageHead" contentplaceholderid="PlaceHolderAdditionalPageHead" runat="server">

</asp:content>

<asp:content id="Main" contentplaceholderid="PlaceHolderMain" runat="server">
    <%--<link href="styles/NativeReportViewer/nativeviewer.css" rel="stylesheet" />--%>
    <style>
        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #333;
        }

        li {
            float: left;
        }

        li a, .dropbtn {
            display: inline-block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

        li a:visited {
            color: white;
        }

        .dropdown-content a:visited {
            color: black;
        }

        li a:hover, .dropdown:hover .dropbtn {
            background-color: #4CAF50;
        }

        li.dropdown {
            display: inline-block;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            background-color: #f9f9f9;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

        .dropdown-content a {
            color: black;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
            text-align: left;
        }

        .dropdown-content a:hover {
            background-color: #f1f1f1;
        }

        .dropdown:hover .dropdown-content {
            display: block;
        }

        #SubscriptionsTable {
            /*font-family: arial, sans-serif;*/
            border-collapse: collapse;
            width: 100%;
        }

        #SubscriptionsTable td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        #SubscriptionsTable tr:nth-child(even) {
            background-color: #dddddd;
        }

        table span {
            font-size: 11px;
            color: darkgray;
        }

        .disabled {
            pointer-events: none;
            opacity: 0.2;
            cursor: not-allowed;
        }
    </style>
    
    <script src="javascripts/jquery-ui.min.js"></script>
    <%--<script src="javascripts/nativeviewer.js"></script>--%>
    <script>
        var linkBuilder = "";
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

            $("#AddForm").html(initHTML);
            
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
                case 'NULL':
                    $("#WindowsFileDelMethod").css("visibility", "collapse");
                    break;
                case 'Report Server FileShare':
                    $("#WindowsFileDelMethod").css("visibility", "visible");
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
                    xml += '<WeeksInterval>'+ $("#RepeateNmbWeeks").val() +'</WeeksInterval>';
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
            else
            {
                alert('The following errors were found:\n\n' + errors);
                return false;
            }
        }

        function GetDeliveryMethodParams(deliveryMethod) {
            var params = '';

            switch (deliveryMethod) {
                case 'Report Server FileShare':
                    params += 'FILENAME|' + $("#FileName").val() + '||';
                    params += 'FILEEXTN|' + $("#FileExtensionAdd").val() + '||';
                    params += 'PATH|' + $("#Path").val() + '||';
                    params += 'RENDER_FORMAT|' + $("#RenderFormat").val() + '||';
                    params += 'USERNAME|' + $("#UserNameWindows").val() + '||';
                    params += 'PASSWORD|' + $("#PasswordWindows").val() + '||';
                    params += 'WRITEMODE|' + $('input[name="overwriteoptions"]:checked').val();
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
                                        reportParamsList += $(selected).text() + "||";
                                    });
                                } else if (document.getElementById(valueFieldID).nodeName == "INPUT") {
                                    reportParamsList += $("#" + paramItemName).val() + "|";
                                    reportParamsList += $("#" + valueFieldID).val() + "||";
                                }
                            }
                        }

                        $.ajax({
                            type: "POST",
                            url: "SSRSNativeReportViewer.aspx/SaveSubscription" + qString,
                            data: JSON.stringify({
                                description: desc, deliveryMethod: delMethod, deliveryParams: delParams,
                                matchData: mData, reportParametersList: reportParamsList
                            }),
                            contentType: "application/json; charset=utf-8",
                            dataType: 'json',

                            success: function (data) {
                                $("#LoadingDivSave").fadeOut();
                                alert('Subscription has been successfully added.');
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

        $(function () {
            if ($('#StartDateSchedule')[0].type != 'date') $('#StartDateSchedule').datepicker({ dateFormat: 'mm-dd-yy' });
            if ($('#StopDateSchedule')[0].type != 'date') $('#StopDateSchedule').datepicker({ dateFormat: 'mm-dd-yy' });
        });
    </script>

    <div id="ViewerDiv">
        <div id="upper">
	        <ul>
                <li class="dropdown">
                <a href="javascript:void(0)" class="dropbtn">Actions</a>
                <div class="dropdown-content">
                  <a href="javascript:OpenEditor()">Open with Report Builder</a>
                  <a href="javascript:OpenSubscriptions()">Subscriptions</a>
                </div>
              </li>
            </ul>
        </div>
        <iframe id="ReportFrame" width="100%" height="100%" src=""></iframe>
    </div>
    <div id="SubscribeManagerDiv" style="visibility:hidden">    
        <div id="upperSubscriptionManager">
	        <ul>
                <li><a href="javascript:RedirectAddSubscription()">Add Subscription</a></li>
                <%--<li><a href="javascript:void(0)">Add Data-Driven Subscription</a></li>--%>
                <li><a href="javascript:EnableDisableSubscription(true)" class="disabled" id="chkEnableSub">Enable</a></li>
                <li><a href="javascript:EnableDisableSubscription(false)" class="disabled" id="chkDisableSub">Disable</a></li>
                <li><a href="javascript:DeleteSubscription()" class="disabled" id="chkDeleteSub">Delete</a></li>
                <li style="float:right;background-color:#4CAF50"><a href="javascript:BackToViewer()">Back</a></li>
            </ul>
        </div>
        <div id="LoadingDiv">Please wait...</div>
        <table id="SubscriptionsTable">
            <tr>
                <th><input type="checkbox" id="chkCheckAll" onclick="CheckAll()"></th>
                <th>Type</th>
                <th>Delivery Extension</th>
                <th>Description</th>
                <th>Status</th>
                <th>Last Run</th>
            </tr>
        </table>
    </div>
    <div id="AddForm">
    <div id="AddSubscriptionForm" style="visibility:hidden">
        <div id="upperAddSubscription">
	        <ul>
                <li><a href="javascript:SaveSubscription()">Save</a></li>
                <li><a href="javascript:BackToSubsManager()">Cancel</a></li>
                <li style="float:right;background-color:#4CAF50"><a href="javascript:BackToSubsManager()">Back</a></li>
            </ul>
        </div>
        <div id="LoadingDivSave" style="visibility:hidden">Please wait...</div>
        <table id="AddSubscriptionTable" style="width:100%;>
            <tr><td colspan="2"><p>Use this page to edit the delivery options for a subscription.</p></td></tr>
            <tr>
                <td><p>Description<br /><span>Specify a description for this subscription.</span></p></td>
                <td><input type="text" id="Description" name="Description"></td>
            </tr>
            <tr>
                <td><p>Delivery Extension *</p></td>
                <td>
                    <select id="DeliveryMethodOptions" onchange="ChangeDeliveryMethod()">
                      
                    </select>
                </td>
            </tr>
            <tr>
                <td><p>Schedule</p><span>Deliver the report on the following schedule.</span></td>
                <td><a id="btnEditSchedule" href="javascript:EditSchedule()">Edit schedule</a></td>
            </tr>
        </table>
        <table id="WindowsFileDelMethod" style="visibility:collapse">
            <tr>
                <td><p>File Name *</p></td>
                <td><input type="text" id="FileName" name="FileName" required></td>
            </tr>
            <tr>
                <td><p>Path *</p></td>
                <td><input type="text" id="Path" name="Path" required></td>
            </tr>
            <tr>
                <td><p>User Name *</p></td>
                <td><input type="text" id="UserNameWindows" name="UserNameWindows"></td>
            </tr>
            <tr>
                <td><p>Password *</p></td>
                <td><input type="password" id="PasswordWindows" name="PasswordWindows"></td>
            </tr>
            <tr>
                <td><p>Render Format *</p></td>
                <td>
                    <select id="RenderFormat">
                        <option value="PDF">PDF</option>
                        <option value="WORD">Word</option>
                        <option value="EXCEL">Excel</option>
                        <option value="POWERPOINT">PowerPoint</option>
                        <option value="TIFF">TIFF file</option>
                        <option value="MHTML">MHTML (web archive)</option>
                        <option value="CSV">CSV (comma delimited)</option>
                        <option value="DATAFEED">Data Feed</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                   <p>File Extension<br /><span>Add a file extension when the file is created.</span></p>
                </td>
                <td>
                    <select id="FileExtensionAdd">
                        <option value="true">YES</option>
                        <option value="false">NO</option>                        
                    </select>
                </td>
            </tr>
            <tr>
                <td><p>Overwrite options *</p></td>
                <td>
                    <input type="radio" name="overwriteoptions" value="Overwrite" checked>Overwrite an existing file with a newer version<br/>
                    <input type="radio" name="overwriteoptions" value="None">Do not overwrite the file if a previous version exists<br/>
                    <input type="radio" name="overwriteoptions" value="AutoIncrement">Increment file names as newer versions are added
                </td>
            </tr>   
        </table>
        <br />
        <div id="ReportParameters"></div>
    </div>  
    <div id="EditScheduleForm" style="visibility:collapse">
        <div id="upperEditSchedule">
	        <ul>
                <li><a href="javascript:BackToSubsAdd()">Apply</a></li>
                <li style="float:right;background-color:#4CAF50"><a href="javascript:BackToSubsAdd()">Back</a></li>
            </ul>
        </div>
        <h1>Schedule details</h1>
        <p>Choose whether to run the report on an hourly, daily, weekly, monthly, or one time basis.</p><br />
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('HourlySchedule')" value="hour" checked>Hour
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('DaylySchedule')" value="day">Day
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('WeeklySchedule')" value="week">Week
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('MonthlySchedule')" value="month">Month
        <input type="radio" name="editschedule" onchange="TimeBasisChanged('OneTimeSchedule')" value="once">Once
        <br /><br />
        <div id="HourlySchedule">
            <h3>Hourly schedule</h3><br />
            Run the schedule every: <input type="text" id="HourlyScheduleHour" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/ value="2"> hours 
            <input type="text" id="HourlyScheduleMinutes" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/ value="0"> minutes
        </div>
        <div id="DaylySchedule" style="display:none">
            <h3>Daily schedule</h3><br />
            <input type="radio" name="dailyoptions" value="followingdays" checked>On the following days: 
            <input type="checkbox" value="Sun" id="DailyoptionsSun"/>Sun
            <input type="checkbox" value="Mon" id="DailyoptionsMon"/>Mon
            <input type="checkbox" value="Tue" id="DailyoptionsTue"/>Tue
            <input type="checkbox" value="Wed" id="DailyoptionsWed"/>Wed
            <input type="checkbox" value="Thu" id="DailyoptionsThu"/>Thu
            <input type="checkbox" value="Fri" id="DailyoptionsFri"/>Fri
            <input type="checkbox" value="Sat" id="DailyoptionsSat"/>Sat<br />
            <input type="radio" name="dailyoptions" value="weekdays">Every weekday <br />
            <input type="radio" name="dailyoptions" value="numbdays">Repeat after this number of days: <input type="text" id="RepeateNmbDays" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>
        </div>
        <div id="WeeklySchedule" style="display:none">
            <h3>Weekly schedule</h3><br />
            Repeat after this number of weeks: <input type="text" id="RepeateNmbWeeks" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/><br />
            On day(s):  
            <input type="checkbox" value="Sun" id="WeeklyScheduleSun"/>Sun
            <input type="checkbox" value="Mon" id="WeeklyScheduleMon"/>Mon
            <input type="checkbox" value="Tue" id="WeeklyScheduleTue"/>Tue
            <input type="checkbox" value="Wed" id="WeeklyScheduleWed"/>Wed
            <input type="checkbox" value="Thu" id="WeeklyScheduleThu"/>Thu
            <input type="checkbox" value="Fri" id="WeeklyScheduleFri"/>Fri
            <input type="checkbox" value="Sat" id="WeeklyScheduleSat"/>Sat<br />
        </div>
        <div id="MonthlySchedule" style="display:none">
            <h3>Monthly schedule</h3><br />
            Months: <br />
            <input type="checkbox" value="Jan" id="MonthlyScheduleJan"/>Jan
            <input type="checkbox" value="Feb" id="MonthlyScheduleFeb"/>Feb
            <input type="checkbox" value="Mar" id="MonthlyScheduleMar"/>Mar
            <input type="checkbox" value="Apr" id="MonthlyScheduleApr"/>Apr
            <input type="checkbox" value="May" id="MonthlyScheduleMay"/>May
            <input type="checkbox" value="Jun" id="MonthlyScheduleJun"/>Jun<br />
            <input type="checkbox" value="Jul" id="MonthlyScheduleJul"/>Jul
            <input type="checkbox" value="Aug" id="MonthlyScheduleAug"/>Aug
            <input type="checkbox" value="Sep" id="MonthlyScheduleSep"/>Sep
            <input type="checkbox" value="Oct" id="MonthlyScheduleOct"/>Oct
            <input type="checkbox" value="Nov" id="MonthlyScheduleNov"/>Nov
            <input type="checkbox" value="Dec" id="MonthlyScheduleDec"/>Dec<br />
            
            <input type="radio" name="monthlyoptions" value="onweek" checked>On week of month:
            <select id="MonthlyOptionsWhichWeek">
                <option value="FirstWeek">1st</option>
                <option value="SecondWeek">2nd</option>
                <option value="ThirdWeek">3rd</option>
                <option value="FourthWeek">4th</option>
                <option value="LastWeek">Last</option>
            </select><br />
            &nbsp&nbsp&nbsp On day of week: 
            <input type="checkbox" value="Sun" id="MonthlyScheduleSun"/>Sun
            <input type="checkbox" value="Mon" id="MonthlyScheduleMon"/>Mon
            <input type="checkbox" value="Tue" id="MonthlyScheduleTue"/>Tue
            <input type="checkbox" value="Wed" id="MonthlyScheduleWed"/>Wed
            <input type="checkbox" value="Thu" id="MonthlyScheduleThu"/>Thu
            <input type="checkbox" value="Fri" id="MonthlyScheduleFri"/>Fri
            <input type="checkbox" value="Sat" id="MonthlyScheduleSat"/>Sat<br />
            <input type="radio" name="monthlyoptions" value="oncalendardays">On calendar day(s): <input type="text" id="OnCalendarDays" 
                style="width:40px" onkeypress='return (event.charCode >= 48 && event.charCode <= 57) || event.charCode == 44 || event.charCode == 45'/>
        </div>
        <div id="OneTimeSchedule" style="display:none">
            <h3>One-time schedule</h3><br />
            Schedule runs only once.<br />
        </div>
        <br /><br />
        Start Time: <input type="text" id="StarTimeHour" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>: 
        <input type="text" id="StarTimeMinutes" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/> (24h format)<br />
        Begin running this schedule on: <input type="date" name="StartDateSchedule" id="StartDateSchedule" style="width:110px"/><br />
        <input type="checkbox" id="chkStopDateSchedule" name="chkStopDateSchedule" onclick="javascript: $('#StopDateSchedule').prop('disabled', !$('#chkStopDateSchedule').is(':checked'));"/>
        Stop this schedule on: <input type="date" name="StopDateSchedule" id="StopDateSchedule" style="width:110px" disabled/>
    </div>
        </div>
</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
Application Page
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
My Application Page
</asp:content>
