<%@ Assembly Name="WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<%@ Page Language="C#"
    DynamicMasterPageFile="~masterurl/default.master"
    AutoEventWireup="true"
    Inherits="WorkEnginePPM.Layouts.ppm.PFEFileImportStatus"
    CodeBehind="PFEFileImportStatus.aspx.cs" %>


<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/_layouts/epmlive/stylesheets/libraries/bootstrap/css/bootstrap.min.css" />
    <script src="/_layouts/epmlive/javascripts/libraries/jquery.min.js" type="text/javascript"></script>
    <script src="/_layouts/epmlive/javascripts/libraries/bootstrap.min.js" type="text/javascript"></script>

    <style type="text/css">
        .allLog {
            font-weight: bold;
            color: #000000;
            padding-right: 5px;
        }

        .infoLog {
            font-weight: bold;
            color: #3399FF;
            padding-right: 5px;
        }

        .warningLog {
            font-weight: bold;
            color: #FF9900;
            padding-right: 5px;
        }

        .errorLog {
            font-weight: bold;
            color: #FF0000;
            padding-right: 5px;
        }

        .hero-unit {
            padding: 30px;
            line-height: 1em;
        }

            .hero-unit > p {
                margin: 0;
            }

        textarea[readonly] {
            height: 285px;
            cursor: text;
        }

        #importdetailstable-wrap {
            height: 285px;
            overflow: auto;
        }

        #importdetailslog-wrap {
            height: 250px;
            overflow: auto;
        }

        div, p, th, td {
            font-family: 'Segoe UI', 'Segoe', Tahoma, Helvetica, Arial, sans-serif;
        }

        .container-wrap {
            height: 565px;
        }

        .accordion-inner {
            height: 285px !important;
        }

        .ms-core-overlay {
            overflow: hidden !important;
        }
    </style>


    <script type="text/javascript">
        window.epmLive = window.epmLive || {};
        window.epmLive.jobId = '<%= JobId %>';

        $(function () {
            PFEFileImportStatusClient.waitForKo();
        });

        var PFEFileImportStatusClient = (function () {

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
                                url: window.epmLive.currentWebFullUrl + '/_layouts/15/ppm/pfefileimportstatus.aspx?jobid=' + window.epmLive.jobId + '&format=json&token=' + new Date().getTime(),
                                type: 'GET',
                                success: function (data) {
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
                                            status.percentage(100);
                                        }
                                    }
                                    window.setTimeout(getStatus, 500);
                                },
                                error: function (data) {
                                    window.setTimeout(getStatus, 500);
                                }
                            });
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
    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Panel ID="statusPanel" runat="server" CssClass="container-wrap">
        <asp:Label ID="lblError" runat="server" EnableViewState="false" ForeColor="Red"></asp:Label>
        <div id="epmcontainer" class="container">
            <div class="hero-unit">
                <div class="row-fluid">
                    <div class="span11">
                        <div class="progress progress-striped" data-bind="css: { active: PercentComplete() < 100 }">
                            <div class="bar" data-bind="style: { width: PercentComplete() + '%' }"></div>
                        </div>
                    </div>
                    <div class="span1" data-bind="text: PercentComplete() + '%'" />
                </div>
            </div>
            <div class="row-fluid">
                <p data-bind="text: CurrentProcess()" />
            </div>
        </div>
        <div class="accordion" id="status">
            <div class="accordion-group">
                <div class="accordion-heading">
                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#status" href="#details">Import Details
                    </a>
                </div>
                <div id="details" class="accordion-body collapse in">
                    <div class="accordion-inner">
                        <div class="row-fluid" id="importdetailstable-wrap">
                            <table class="table table-bordered" id="importdetailstable">
                                <tr>
                                    <td>Total Records</td>
                                    <td data-bind="text: TotalRecords"></td>
                                </tr>
                                <tr>
                                    <td>Processed Records</td>
                                    <td data-bind="text: ProcessedRecords"></td>
                                </tr>
                                <tr>
                                    <td>Success Records</td>
                                    <td data-bind="text: SuccessRecords"></td>
                                </tr>
                                <tr>
                                    <td>Failed Records</td>
                                    <td data-bind="text: FailedRecords"></td>
                                </tr>
                                <tr>
                                    <td>Log Count</td>
                                    <td data-bind="text: log().length"></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="accordion-group">
                <div class="accordion-heading">
                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#status" href="#log">Import Log</a>
                </div>
                <div id="log" class="accordion-body collapse">
                    <div class="accordion-inner">
                        <div class="row-fluid">
                            <div>
                                <a id="lnkall" style="display: none;" class="allLog" onclick="javascript:PFEFileImportStatusClient.filterLogByStatus('All');">All</a>
                                <a id="lnkinfo" style="display: none;" class="infoLog" onclick="javascript:PFEFileImportStatusClient.filterLogByStatus('Info');">Info</a>
                                <a id="lnkwarning" style="display: none;" class="warningLog" onclick="javascript:PFEFileImportStatusClient.filterLogByStatus('Warning');">Warning</a>
                                <a id="lnkerror" style="display: none;" class="errorLog" onclick="javascript:PFEFileImportStatusClient.filterLogByStatus('Error');">Error</a>
                            </div>
                            <br />
                            <div class="row-fluid" id="importdetailslog-wrap">

                                <table class="table table-bordered" id="importdetailslog">
                                    <thead>
                                        <tr>
                                            <th width="10">#</th>
                                            <th width="10">Status</th>
                                            <th width="270">Description</th>
                                        </tr>
                                    </thead>
                                    <tbody data-bind="foreach: log ">
                                        <tr>
                                            <td data-bind="text: $index() + 1"></td>
                                            <td data-bind="attr: { 'class': Kind == '0' ? 'infoLog' : Kind == '1' ? 'warningLog' : 'errorLog' }">
                                                <!-- ko if: Kind == '0' -->
                                                Info
                                                <!-- /ko -->
                                                <!-- ko if: Kind == '1' -->
                                                Warning
                                                <!-- /ko -->
                                                <!-- ko if: Kind == '2' -->
                                                Error
                                                <!-- /ko -->
                                            </td>
                                            <td>
                                                <div data-bind="html: Message"></div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input type="button" value="Close" onclick="parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK); return false;" style="float: right; position: relative; top: -5px;">
    </asp:Panel>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    PFE Cost Planner Import Status
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" runat="server" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea">
    PFE Cost Planner Import Status
</asp:Content>
