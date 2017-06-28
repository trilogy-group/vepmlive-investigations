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
    <%--<script src="javascripts/nativeviewer.js"></script>--%>
    <script>
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

                    reportParamsList += $("#" + labelID).text();
                    reportParamsList += "|";
                    if (document.getElementById(valueFieldID).nodeName == "SELECT") {
                        $('#' + valueFieldID + ' :selected').each(function (i, selected) {
                            reportParamsList += $(selected).text() + ',';
                        });
                    } else if (document.getElementById(valueFieldID).nodeName == "INPUT") {
                        reportParamsList += $("#" + valueFieldID).val();
                    }

                    reportParamsList += "||";
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
                        data: JSON.stringify({ subsIdList: subsIds , enable: isEnabled }),
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
                <%--<li><a href="javascript:RedirectAddSubscription()">Add Subscription</a></li>
                <li><a href="javascript:void(0)">Add Data-Driven Subscription</a></li>--%>
                <li><a href="javascript:EnableDisableSubscription(true)" class="disabled" id="chkEnableSub">Enable</a></li>
                <li><a href="javascript:EnableDisableSubscription(false)" class="disabled" id="chkDisableSub">Disable</a></li>
                <li><a href="javascript:DeleteSubscription()" class="disabled" id="chkDeleteSub">Delete</a></li>
                <li style="float:right;background-color:#4CAF50"><a href="javascript:BackToViewer()">Back</a></li>
            </ul>
        </div>
        <div id="LoadingDiv">Loading Subscriptions...</div>
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
    <div id="AddSubscriptionForm" style="visibility:hidden">
        <div id="upperAddSubscription">
	        <ul>
                <li><a href="javascript:SaveSubscription()">Save</a></li>
                <li><a href="javascript:BackToSubsManager()">Cancel</a></li>
                <li style="float:right;background-color:#4CAF50"><a href="javascript:BackToSubsManager()">Back</a></li>
            </ul>
        </div>
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
                        <option value="yes">YES</option>
                        <option value="no">NO</option>                        
                    </select>
                </td>
            </tr>
            <tr>
                <td><p>Overwrite options *</p></td>
                <td>
                    <input type="radio" name="overwriteoptions" value="Overwrite" checked>Overwrite an existing file with a newer version<br/>
                    <input type="radio" name="overwriteoptions" value="Donotoverwrite">Do not overwrite the file if a previous version exists<br/>
                    <input type="radio" name="overwriteoptions" value="Increment">Increment file names as newer versions are added
                </td>
            </tr>   
        </table>
        <br />
        <div id="ReportParameters"></div>
    </div>  
    <div id="EditScheduleForm" style="visibility:collapse">
        <div id="upperEditSchedule">
	        <ul>
                <li><a href="javascript:BackToSubsAdd()">Save</a></li>
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
            Run the schedule every: <input type="text" id="HourlyScheduleHour" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/> hours 
            <input type="text" id="HourlyScheduleMinutes" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/> minutes
        </div>
        <div id="DaylySchedule" style="display:none">
            <h3>Daily schedule</h3><br />
            <input type="radio" name="dailyoptions" value="followingdays" checked>On the following days: 
            <input type="checkbox" value="Sun"/>Sun
            <input type="checkbox" value="Mon"/>Mon
            <input type="checkbox" value="Tue"/>Tue
            <input type="checkbox" value="Wed"/>Wed
            <input type="checkbox" value="Thu"/>Thu
            <input type="checkbox" value="Fri"/>Fri
            <input type="checkbox" value="Sat"/>Sat<br />
            <input type="radio" name="dailyoptions" value="weekdays">Every weekday <br />
            <input type="radio" name="dailyoptions" value="numbdays">Repeat after this number of days: <input type="text" id="RepeateNmbDays" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>
        </div>
        <div id="WeeklySchedule" style="display:none">
            <h3>Weekly schedule</h3><br />
            Repeat after this number of weeks: <input type="text" id="RepeateNmbWeeks" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/><br />
            On day(s):  
            <input type="checkbox" value="Sun"/>Sun
            <input type="checkbox" value="Mon"/>Mon
            <input type="checkbox" value="Tue"/>Tue
            <input type="checkbox" value="Wed"/>Wed
            <input type="checkbox" value="Thu"/>Thu
            <input type="checkbox" value="Fri"/>Fri
            <input type="checkbox" value="Sat"/>Sat<br />
        </div>
        <div id="MonthlySchedule" style="display:none">
            <h3>Monthly schedule</h3><br />
            Months: <br />
            <input type="checkbox" value="Sun"/>Jan
            <input type="checkbox" value="Mon"/>Feb
            <input type="checkbox" value="Tue"/>Mar
            <input type="checkbox" value="Wed"/>Apr
            <input type="checkbox" value="Thu"/>May
            <input type="checkbox" value="Fri"/>Jun<br />
            <input type="checkbox" value="Sat"/>Jul
            <input type="checkbox" value="Sat"/>Aug
            <input type="checkbox" value="Sat"/>Sep
            <input type="checkbox" value="Sat"/>Oct
            <input type="checkbox" value="Sat"/>Nov
            <input type="checkbox" value="Sat"/>Dec<br />
            
            <input type="radio" name="monthlyoptions" value="onweek" checked>On week of month:
            <select>
                <option value="1st">1st</option>
                <option value="2nd">2nd</option>
                <option value="3rd">3rd</option>
                <option value="4th">4th</option>
                <option value="last">Last</option>
            </select><br />
            &nbsp&nbsp&nbsp On day of week: <input type="checkbox" value="Sun"/>Sun
            <input type="checkbox" value="Mon"/>Mon
            <input type="checkbox" value="Tue"/>Tue
            <input type="checkbox" value="Wed"/>Wed
            <input type="checkbox" value="Thu"/>Thu
            <input type="checkbox" value="Fri"/>Fri
            <input type="checkbox" value="Sat"/>Sat<br />
            <input type="radio" name="monthlyoptions" value="onweek">On calendar day(s): <input type="text" id="OnCalendarDays" 
                style="width:40px" onkeypress='return (event.charCode >= 48 && event.charCode <= 57) || event.charCode == 44 || event.charCode == 45'/>
        </div>
        <div id="OneTimeSchedule" style="display:none">
            <h3>One-time schedule</h3><br />
            Schedule runs only once.<br />
        </div>
        <br /><br />
        Start Time: <input type="text" id="StarTimeHour" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/>: 
            <input type="text" id="StarTimeMinutes" style="width:20px" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/> minutes
        <input type="radio" name="starttimeampm" value="am" checked>AM
        <input type="radio" name="starttimeampm" value="pm">PM
    </div>

</asp:content>

<asp:content id="PageTitle" contentplaceholderid="PlaceHolderPageTitle" runat="server">
Application Page
</asp:content>

<asp:content id="PageTitleInTitleArea" contentplaceholderid="PlaceHolderPageTitleInTitleArea" runat="server">
My Application Page
</asp:content>
