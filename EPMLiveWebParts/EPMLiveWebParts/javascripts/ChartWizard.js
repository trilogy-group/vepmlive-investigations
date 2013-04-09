var reloadScriptTimeoutId = '';

function OnPageLoad() {
    $(function () {
        $.getScript('/_layouts/epmlive/javascripts/libraries/slimScroll.js', function () {
            $('.chartThumbWrapper').slimScroll({ height: '250px', size: '10px' });
        }, true);

        $('#thumbTable tr').hover(function () {
            $(this).addClass('thumbRowHover');
        }, function () {
            $(this).removeClass('thumbRowHover');
        });

        $(".thumbRow").click(function () {
            $(".thumbRow").removeClass("thumbRowSelected");
            $(".thumbLabel").css("color", "#444444");
            $(this).addClass('thumbRowSelected');
            $(this).find(".thumbLabel").css("color", "#ffffff");
            $("#chartImage").attr("src", $(this).find(".imagedropshadow").attr("src"));

            var gType = $(this).attr('graphType');
            $('#' + tbChartTypeClientId).val(gType);
            ManageUI();
        });

        $('#trColumn').trigger('click');
        // set all checkbox ddl width
        $('#' + ddlYNumMultiClientId + ' table').css('width', '170px');
        $('#' + ddlYNonNumMultiClientId + ' table').css('width', '170px');

        $('#' + ddlYNonNumSingleClientId).css('display', 'none');
        $('#' + ddlYNumMultiClientId).css('display', 'none');
        $('#' + ddlYNonNumMultiClientId).css('display', 'none');

        $('#' + pnlZFieldClientId).css('display', 'none');
        $('#' + pnlYDdlClientId).css('display', 'none');

        if ($('#' + tbSelectedListAndViewClientId).val()) {
            LightNextBtn();
        }
        else {
            DimNextBtn();
        }
    });
}
ExecuteOrDelayUntilScriptLoaded(OnPageLoad, 'EPMLive.js');

function reloadScript() {
    reloadScriptTimeoutId = setInterval(function () { reloadUILogic(); }, 1000);
}

function reloadUILogic() {
    if ($('.chartThumbWrapper').parent().attr('class') != 'slimScrollDiv') {
        $('.chartThumbWrapper').slimScroll({ height: '250px', size: '10px' });
    }

    $('#thumbTable tr').hover(function () {
        $(this).addClass('thumbRowHover');
    }, function () {
        $(this).removeClass('thumbRowHover');
    });

    $(".thumbRow").click(function () {
        $(".thumbRow").removeClass("thumbRowSelected");
        $(".thumbLabel").css("color", "#444444");
        $(this).addClass('thumbRowSelected');
        $(this).find(".thumbLabel").css("color", "#ffffff");
        $("#chartImage").attr("src", $(this).find(".imagedropshadow").attr("src"));

        var gType = $(this).attr('graphType');
        $('#' + tbChartTypeClientId).val(gType);
        ManageUI();
    });

    $('#trColumn').trigger('click');
    // set all checkbox ddl width
    $('#' + ddlYNumMultiClientId + ' table').css('width', '170px');
    $('#' + ddlYNonNumMultiClientId + ' table').css('width', '170px');

    $('#' + ddlYNonNumSingleClientId).css('display', 'none');
    $('#' + ddlYNumMultiClientId).css('display', 'none');
    $('#' + ddlYNonNumMultiClientId).css('display', 'none');

    $('#' + pnlZFieldClientId).css('display', 'none');
    $('#' + pnlYDdlClientId).css('display', 'none');

    if ($('#' + tbSelectedListAndViewClientId).val()) {
        LightNextBtn();
    }
    else {
        DimNextBtn();
    }

    clearTimeout(reloadScriptTimeoutId);

}

function AutosizeDialog() {
    //resize dialog if we are in one    
    
    var dlg = parent.SP.UI.ModalDialog.get_childDialog();
    if (dlg != null) {
        try {
            dlg.autoSize();
            var dlgWin = $(".ms-dlgContent", window.parent.document);
            dlgWin.css({
                top: ($(window.top).height() / 2 - dlgWin.height() / 2) + "px",
                left: $(window.top).width() / 2 - dlgWin.width() / 2
            });
        }
        catch (e) {
        }
    }
}

function OpenDataSourceGrid() {
    var options = {
        url: gridurl,
        width: 400,
        height: 515,
        allowMaximize: false,
        showClose: false,
        dialogReturnValueCallback: SetDataSource
    };
    parent.SP.UI.ModalDialog.showModalDialog(options);
}

function SetDataSource(result, value) {
    if (result == 1) {

        $('#' + tbSelectedListAndViewClientId).val(value);

        __doPostBack(updatePnlClientId, '');
        reloadScript();

        if ($('#' + tbSelectedListAndViewClientId).val()) {
            LightNextBtn();
        }
        else {
            DimNextBtn();
        }
    }
}

function LightNextBtn() {
    $('#btnNext').removeClass();
    $('#btnNext').addClass('epmliveButton');
    $('#btnNext').addClass('epmliveButton-emphasize');
}

function DimNextBtn() {
    $('#btnNext').removeClass();
    $('#btnNext').addClass('epmliveButtonDisabled');
}

function Back() {
    if ($('#btnBack').hasClass('epmliveButtonDisabled')) {
        return;
    }
    var selectedDiv = $('.StepContainer:visible');
    var containerId = selectedDiv.attr('id');
    switch (containerId) {
        case "pgStep1":
            break;
        case "pgStep2":
            DisplayPage(1);
            AutosizeDialog();
            ManageButtons(1);
            break;
        case "pgStep3":
            DisplayPage(2);
            AutosizeDialog();
            ManageButtons(2);
            break;
        default:
            break;
    }
}

function Next() {
    if ($('#btnNext').hasClass('epmliveButtonDisabled')) {
        return;
    }
    var selectedDiv = $('.StepContainer:visible');
    var containerId = selectedDiv.attr('id');
    switch (containerId) {
        case "pgStep1":
            if (!IsDataSourceSet()) {
                return;
            }
            DisplayPage(2);
            AutosizeDialog();
            ManageButtons(2);
            break;
        case "pgStep2":
            DisplayPage(3);
            AutosizeDialog();
            ManageButtons(3);
            break;
        case "pgStep3":
            break;
        default:
            break;
    }
}

function DisplayPage(number) {
    switch (number) {
        case 1:
            $('#pgStep1').css('display', '');
            $('#pgStep2').css('display', 'none');
            $('#pgStep3').css('display', 'none');
            break;
        case 2:
            $('#pgStep1').css('display', 'none');
            $('#pgStep2').css('display', '');
            $('#pgStep3').css('display', 'none');
            break;
        case 3:
            $('#pgStep1').css('display', 'none');
            $('#pgStep2').css('display', 'none');
            $('#pgStep3').css('display', '');
            break;
        default:
            break;
    }
}

function ManageButtons(page) {
    $('#btnBack').removeClass();
    $('#btnNext').removeClass();
    $('#btnCancel').removeClass();
    $('#btnSave').removeClass();
    
    switch (page) {
        case 1:
            $('#btnBack').addClass('epmliveButtonDisabled');
            $('#btnNext').css('display', '');
            $('#btnCancel').addClass('epmliveButton');
            $('#btnSave').css('display', 'none');
            if ($('#' + tbSelectedListAndViewClientId).val()) {
                LightNextBtn();
            }
            else {
                DimNextBtn();
            }
            break;
        case 2:
            $('#btnBack').addClass('epmliveButton');
            $('#btnNext').css('display', '');
            $('#btnCancel').addClass('epmliveButton');
            $('#btnSave').css('display', 'none');
            if (ValidatePage2()) {
                LightNextBtn();
            }
            else {
                DimNextBtn();
            }
            break;
        case 3:
            $('#btnBack').addClass('epmliveButton');
            $('#btnNext').css('display', 'none');
            $('#btnCancel').addClass('epmliveButton');
            $('#btnSave').css('display', '');
            $('#btnSave').addClass('epmliveButton');
            $('#btnSave').addClass('epmliveButton-emphasize');
            break;
        default:
            break;

    }
}

function IsDataSourceSet() {
    var sDataSource = '';
    try {
        sDataSource = $('#' + tbSelectedListAndViewClientId).val();
    }
    catch (e) { }

    if (sDataSource == '' || sDataSource == undefined) {
        alert('You must choose a data source first.');
        return false;
    }
    else {
        return true;
    }
}

function ManageUI() {
    ManageDataEntryFields();
    if (ValidatePage2()) {
        LightNextBtn();
    }
    else {
        DimNextBtn();
    }
}

function ManageDataEntryFields() {
    var ddlAgg = $('#' + ddlAggClientId);
    var aggType = ddlAgg.val();
    var chartType = $('#' + tbChartTypeClientId).val();

    // display agg drop down conditionally
    if (chartType == 'Bubble') {
        $('#' + pnlAggClientId).css('display', 'none');
        $('#' + pnlZFieldClientId).css('display', '');
    } else {
        $('#' + pnlAggClientId).css('display', '');
        $('#' + pnlZFieldClientId).css('display', 'none');
    }

    // CONFIGURE UI BASED ON CHART TYPE AND AGGREGATION 
    if (chartType == "Area" || chartType == "Bar" || chartType == "Column" || chartType == "Line") {
        if (aggType == "Count") {
            // NO Y VALUE
            try {
                $('#' + pnlYDdlClientId).css('display', 'none');
                //                $('#spnYVal').css('display', 'none');
                //                $('#' + ddlYNumSingleClientId).css('display', 'none');
                //                $('#' + ddlYNumMultiClientId).css('display', 'none');
                //                $('#' + ddlYNonNumSingleClientId).css('display', 'none');
                //                $('#' + ddlYNonNumMultiClientId).css('display', 'none');

                $('#' + ddlYAxisFormatClientId).css('display', 'none');
            } catch (e) { }
        } else if (aggType == "Sum" || aggType == "Avg") {
            // 1 Y VALUE (NUMERICAL)
            try {
                $('#' + pnlYDdlClientId).css('display', '');
                $('#spnYVal').text('Y Value');
                $('#spnYVal').css('display', '');
                $('#' + ddlYNumSingleClientId).css('display', '');
                $('#' + ddlYNumMultiClientId).css('display', 'none');
                $('#' + ddlYNonNumSingleClientId).css('display', 'none');
                $('#' + ddlYNonNumMultiClientId).css('display', 'none');

                $('#' + ddlYAxisFormatClientId).css('display', '');
            } catch (e) { }
        }
    } else if (chartType.indexOf("_Clustered") != -1 || chartType.indexOf("_Stacked") != -1 || chartType.indexOf("_100Percent") != -1) {
        if (aggType == "Count") {
            // 1 Y VALUE (NON NUMERICAL)
            try {
                $('#' + pnlYDdlClientId).css('display', '');
                $('#spnYVal').text('Y Value');
                $('#spnYVal').css('display', '');
                $('#' + ddlYNumSingleClientId).css('display', 'none');
                $('#' + ddlYNumMultiClientId).css('display', 'none');
                $('#' + ddlYNonNumSingleClientId).css('display', '');
                $('#' + ddlYNonNumMultiClientId).css('display', 'none');

                $('#' + ddlYAxisFormatClientId).css('display', '');
            } catch (e) { }
        } else if (aggType == "Sum" || aggType == "Avg") {
            // MORE THAN 1 Y VALUE (Numerical)
            try {
                $('#' + pnlYDdlClientId).css('display', '');
                $('#spnYVal').text('Y Value(series)');
                $('#spnYVal').css('display', '');
                $('#' + ddlYNumSingleClientId).css('display', 'none');
                $('#' + ddlYNumMultiClientId).css('display', '');
                $('#' + ddlYNonNumSingleClientId).css('display', 'none');
                $('#' + ddlYNonNumMultiClientId).css('display', 'none');

                $('#' + ddlYAxisFormatClientId).css('display', '');
            } catch (e) { }
        }
    } else if (chartType == "Pie" || chartType == "Donut") {
        if (aggType == "Count") {
            // NO Y VALUE
            try {
                $('#' + pnlYDdlClientId).css('display', 'none');
                //                $('#spnYVal').css('display', 'none');
                //                $('#' + ddlYNumSingleClientId).css('display', 'none');
                //                $('#' + ddlYNumMultiClientId).css('display', 'none');
                //                $('#' + ddlYNonNumSingleClientId).css('display', 'none');
                //                $('#' + ddlYNonNumMultiClientId).css('display', 'none');
                //                $('#' + ddlYAxisFormatClientId).css('display', 'none');
            } catch (e) { }
        } else if (aggType == "Sum" || aggType == "Avg") {
            // 1 Y VALUE (Numerical)
            try {
                $('#' + pnlYDdlClientId).css('display', '');
                $('#spnYVal').text('Y Value');
                $('#spnYVal').css('display', '');
                $('#' + ddlYNumSingleClientId).css('display', '');
                $('#' + ddlYNumMultiClientId).css('display', 'none');
                $('#' + ddlYNonNumSingleClientId).css('display', 'none');
                $('#' + ddlYNonNumMultiClientId).css('display', 'none');
                $('#' + ddlYAxisFormatClientId).css('display', '');
            } catch (e) { }
        }
    } else if (chartType == "Bubble") {
        // 1 Y VALUE (NUMERICAL)
        try {
            $('#' + pnlYDdlClientId).css('display', '');
            $('#spnYVal').text('Y Value');
            $('#spnYVal').css('display', '');
            $('#' + ddlYNumSingleClientId).css('display', '');
            $('#' + ddlYNumMultiClientId).css('display', 'none');
            $('#' + ddlYNonNumSingleClientId).css('display', 'none');
            $('#' + ddlYNonNumMultiClientId).css('display', 'none');
            $('#' + ddlYAxisFormatClientId).css('display', '');
        } catch (e) { }
    }
}

function CancelWizard() {
    parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
}

function SaveChartProps() {
    if ($('#btnSave').hasClass('epmliveButtonDisabled')) {
        return;
    }

    $('#pgStep1').css('display', 'none');
    $('#pgStep2').css('display', 'none');
    $('#pgStep3').css('display', 'none');
    $('#divButtons').css('display', 'none');
    $('#divLoading').css('display', '');
    AutosizeDialog();
    $.ajax({
        url: 'UpdateWebPart.aspx',
        data: BuildChartPropObj(),
        success: function () {
            parent.SP.UI.ModalDialog.commonModalDialogClose(1, '');
        },
        error: function () {
            alert('Oops, there was an error!');
            parent.SP.UI.ModalDialog.commonModalDialogClose(-1, '');
        }
    });
}

function BuildChartPropObj() {
    var ChartProps = {
        sChartTitle: "",
        sChartType: "",
        sPropChartSelectedPaletteName: "",
        sPropChartSelectedListTitle: "",
        sPropChartSelectedViewTitle: "",
        sPropChartXaxisField: "",
        sPropChartXaxisFieldLabel: "",
        sPropChartYaxisField: "",
        sPropChartYaxisFieldLabel: "",
        sPropYaxisFormat: "",
        sPropLegendPosition: "",
        sPropChartZaxisField: "",
        sPropChartZaxisFieldLabel: "",
        sPropBubbleChartGroupBy: "",
        sPropChartShowSeriesLabels: "",
        sPropChartShowLegend: "",
        sPropChartShowGridlines: "",
        sPropChartAggregationType: "",
        sWpId: "",
        sWpPagePath: ""
    };

    ChartProps.sChartTitle = $('#' + tbChartTitleClientId).val();
    ChartProps.sChartType = $('#' + tbChartTypeClientId).val();
    ChartProps.sPropChartAggregationType = $('#' + ddlAggClientId).val();
    ChartProps.sPropChartSelectedPaletteName = $('#' + ddlPaletteClientId).val();
    ChartProps.sPropChartSelectedListTitle = $('#' + tbListTitleClientId).val();
    ChartProps.sPropChartSelectedViewTitle = $('#' + tbViewTitleClientId).val();
    ChartProps.sPropChartXaxisField = $find(ddlXFieldClientId)._value;
    ChartProps.sPropChartYaxisField = GetYValue();
    ChartProps.sPropYaxisFormat = $('#' + ddlYAxisFormatClientId).val();
    ChartProps.sPropLegendPosition = $('#' + ddlLegendPositionClientId).val();
    ChartProps.sPropChartZaxisField = GetZValue();
    ChartProps.sPropBubbleChartGroupBy = $('#' + ddlGroupByClientId).val();
    ChartProps.sPropChartShowSeriesLabels = $('#' + cbShowXAxisLabelsClientId).is(":checked");
    ChartProps.sPropChartShowGridlines = $('#' + cbShowGridLinesClientId).is(":checked");
    ChartProps.sPropChartShowLegend = $('#' + cbShowLegendClientId).is(":checked");
    var args = parent.SP.UI.ModalDialog.get_childDialog().get_args();
    ChartProps.sWpPagePath = args.wpPagePath;
    ChartProps.sWpId = args.wpId;
    return ChartProps;
}

function GetYValue() {
    var aggType = $('#' + ddlAggClientId).val();
    var chartType = $('#' + tbChartTypeClientId).val();
    var yVal = '';
    // CONFIGURE UI BASED ON CHART TYPE AND AGGREGATION 
    if (chartType == "Area" || chartType == "Bar" || chartType == "Column" || chartType == "Line") {
        if (aggType == "Count") {
            // NO Y VALUE

        } else if (aggType == "Sum" || aggType == "Avg") {
            // 1 Y VALUE (NUMERICAL)
            try {
                // telerik syntax, don't change
                yVal = $find(ddlYNumSingleClientId)._value;
            } catch (e) { }
        }
    } else if (chartType.indexOf("_Clustered") != -1 || chartType.indexOf("_Stacked") != -1 || chartType.indexOf("_100Percent") != -1) {
        if (aggType == "Count") {
            // 1 Y VALUE (NON NUMERICAL)
            try {
                // telerik syntax, don't change
                yVal = $find(ddlYNonNumSingleClientId)._value;
            } catch (e) { }
        } else if (aggType == "Sum" || aggType == "Avg") {
            // MORE THAN 1 Y VALUE (Numerical)
            try {
                var sTempYVal = ''
                var checkedItems = $find(ddlYNumMultiClientId).get_checkedItems();
                if (checkedItems.length > 0) {
                    for (var i = 0; i < checkedItems.length; i++) {
                        sTempYVal += (checkedItems[i]._properties._data.value + '|');
                    }
                }
                yVal = sTempYVal;
            } catch (e) { }
        }
    } else if (chartType == "Pie" || chartType == "Donut") {
        if (aggType == "Count") {
            // NO Y VALUE
        } else if (aggType == "Sum" || aggType == "Avg") {
            // 1 Y VALUE (Numerical)
            try {
                // telerik syntax, don't change
                yVal = $find(ddlYNumSingleClientId)._value;
            } catch (e) { }
        }
    } else if (chartType == "Bubble") {
        // 1 Y VALUE (NUMERICAL)
        try {
            // telerik syntax
            yVal = $find(ddlYNumSingleClientId)._value;
        } catch (e) { }
    }

    return yVal;
}

function GetZValue() {
    var zField = '';
    var chartType = $('#' + tbChartTypeClientId).val();
    if (chartType == 'Bubble') {
        try {
            // telerik syntax
            zField = $find(ddlZFieldClientId)._value;
        } catch (e) { }
    }

    return zField;
}

function ValidatePage2() {
    var isValid = false;
    var aggType = $('#' + ddlAggClientId).val();
    var chartType = $('#' + tbChartTypeClientId).val();

    if (chartType == "Area" || chartType == "Bar" || chartType == "Column" || chartType == "Line") {
        if (aggType == "Count") {
            // NEED 1 X VALUE, NO Y VALUE
            var xVal = $find(ddlXFieldClientId)._value;
            if (xVal != "None") {
                isValid = true;
            }

        } else if (aggType == "Sum" || aggType == "Avg") {
            // NEED 1 X, 1 OR MORE Y VALUE
            var xVal = $find(ddlXFieldClientId)._value;
            var yVal = $find(ddlYNumSingleClientId)._value;
            if (xVal != "None" && yVal != "None") {
                isValid = true;
            }
        }
    } else if (chartType.indexOf("_Clustered") != -1 || chartType.indexOf("_Stacked") != -1 || chartType.indexOf("_100Percent") != -1) {
        if (aggType == "Count") {
            // NEED 1 X VALUE AND 1 Y VALUE (NON NUMERICAL)
            var xVal = $find(ddlXFieldClientId)._value;
            var yVal = $find(ddlYNonNumSingleClientId)._value;
            if (xVal != "None" && yVal != "None") {
                isValid = true;
            }
        } else if (aggType == "Sum" || aggType == "Avg") {
            // NEED 1 X, 1 OR MORE Y VALUE (NUMERICAL)
            var xVal = $find(ddlXFieldClientId)._value;
            var checkedItems = $find(ddlYNumMultiClientId).get_checkedItems();
            if (xVal != "None" && checkedItems.length > 0) {
                isValid = true;
            }
        }
    } else if (chartType == "Pie" || chartType == "Donut") {
        if (aggType == "Count") {
            // NEED 1 X VALUE, NO Y VALUE
            var xVal = $find(ddlXFieldClientId)._value;
            if (xVal != "None") {
                isValid = true;
            }
        } else if (aggType == "Sum" || aggType == "Avg") {
            // NEED 1 X, 1 OR MORE Y VALUE (NUMERICAL)
            var xVal = $find(ddlXFieldClientId)._value;
            var checkedItems = $find(ddlYNumMultiClientId).get_checkedItems();
            if (xVal != "None" && checkedItems.length > 0) {
                isValid = true;
            }
        }
    } else if (chartType == "Bubble") {
        // 1 X, 1 Y, AND 1 Z (ALL NUMERICAL)
        var xVal = $find(ddlXFieldClientId)._value;
        var yVal = $find(ddlYNumSingleClientId)._value;
        var zVal = $find(ddlZFieldClientId)._value;
        if (xVal != "None" && yVal != "None" && zVal != "None") {
            isValid = true;
        }
    }

    return isValid;
}