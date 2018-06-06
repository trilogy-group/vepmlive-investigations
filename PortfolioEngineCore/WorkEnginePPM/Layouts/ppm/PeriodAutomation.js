PeriodAutomation = function () {
    var onStateChangeEvent = null;
    var cutPeriodsStartDateInputId = "cutPeriodsStartDateInput";
    var cutPeriodsEndDateInputId = "cutPeriodsEndDateInput";
    var automateNewPeriodCreationRadioNoId = "automateNewPeriodCreationRadioNo";
    var automateNewPeriodCreationRadioYesId = "automateNewPeriodCreationRadioYes";
    var createPeriodsActionRowId = "createPeriodsActionRow";
    var createPeriodsButtonId = "createPeriodsButton";
    var cutPeriodsStartDateRowId = "cutPeriodsStartDateRow";
    var cutPeriodsEndDateRowId = "cutPeriodsEndDateRow";
    var cutPeriodsMonthlyDayInputId = "cutPeriodsMonthlyDayInput";
    var cutPeriodsMonthlyDayRowId = "cutPeriodsMonthlyDayRow";
    var cutPeriodsMonthlyEndOfDayCheckBoxId = "cutPeriodsMonthlyEndOfDayCheckBox";
    var cutPeriodsMonthlyPeriodicityInputId = "cutPeriodsMonthlyPeriodicityInput";
    var cutPeriodsMonthlyPeriodicityRowId = "cutPeriodsMonthlyPeriodicityRow";
    var cutPeriodsMonthlyRadioNoId = "cutPeriodsMonthlyRadioNo";
    var cutPeriodsMonthlyRadioYesId = "cutPeriodsMonthlyRadioYes";
    var cutPeriodsMonthlyRowId = "cutPeriodsMonthlyRow";
    var cutPeriodsWeeklyDayInputId = "cutPeriodsWeeklyDayInput";
    var cutPeriodsWeeklyDayRowId = "cutPeriodsWeeklyDayRow";
    var cutPeriodsWeeklyPeriodicityInputId = "cutPeriodsWeeklyPeriodicityInput";
    var cutPeriodsWeeklyPeriodicityRowId = "cutPeriodsWeeklyPeriodicityRow";
    var cutPeriodsWeeklyRadioNoId = "cutPeriodsWeeklyRadioNo";
    var cutPeriodsWeeklyRadioYesId = "cutPeriodsWeeklyRadioYes";
    var cutPeriodsWeeklyRowId = "cutPeriodsWeeklyRow";
    var cutPeriodsSummaryRowId = "cutPeriodsSummaryRow";
    var cutPeriodsSummaryTextId = "cutPeriodsSummaryText";

    var summaryMode = false;
    var minStartDate = null;

    var defaults = {
        cutWeeklyPeriodicity: 1,
        cutWeeklyDay: 0,
        cutMonthlyPeriodicity: 1,
        cutMonthlyDay: 15
    }

    var readValues = function() {
        var enabled = document.getElementById(automateNewPeriodCreationRadioYesId).checked;
        var cutWeekly = enabled && document.getElementById(cutPeriodsWeeklyRadioYesId).checked;
        var cutMonthly = enabled && document.getElementById(cutPeriodsMonthlyRadioYesId).checked;

        var cutWeeklyPeriodicity = (cutWeekly === true)
            ? parseInt(document.getElementById(cutPeriodsWeeklyPeriodicityInputId).value)
            : defaults.cutWeeklyPeriodicity;
        var cutWeeklyDay = (cutWeekly === true)
            ? parseInt(document.getElementById(cutPeriodsWeeklyDayInputId).value)
            : defaults.cutWeeklyDay;

        var cutMonthlyEndOfDay = document.getElementById(cutPeriodsMonthlyEndOfDayCheckBoxId).checked;
        var cutMonthlyPeriodicity = (cutMonthly === true)
            ? parseInt(document.getElementById(cutPeriodsMonthlyPeriodicityInputId).value)
            : defaults.cutMonthlyPeriodicity;
        var cutMonthlyDay = (cutMonthly === true)
            ? ((cutMonthlyEndOfDay === false) ? parseInt(document.getElementById(cutPeriodsMonthlyDayInputId).value) : 31)
            : defaults.cutMonthlyDay;

        var startDate = DateHelper.convertToUtcDate(document.getElementById(cutPeriodsStartDateInputId).value);
        var endDate = DateHelper.convertToUtcDate(document.getElementById(cutPeriodsEndDateInputId).value);

        return {
            enabled: enabled,
            cutWeekly: cutWeekly,
            cutWeeklyPeriodicity: cutWeeklyPeriodicity,
            cutWeeklyDay: cutWeeklyDay,
            cutMonthly: cutMonthly,
            cutMonthlyPeriodicity: cutMonthlyPeriodicity,
            cutMonthlyDay: cutMonthlyDay,
            cutMonthlyEndOfDay: cutMonthlyEndOfDay,
            startDate: startDate,
            endDate: endDate
        }
    }

    var validateForm = function (values) {
        if (!values) {
            values = readValues();
        };

        if (values.enabled) {
            var errorMessage = null;

            if (!values.cutWeekly && !values.cutMonthly) {
                errorMessage = "Please choose 'Cut Periods Weekly' or 'Cut Periods Monthly' or both";
            }

            if (values.cutWeekly) {
                if (isNaN(values.cutWeeklyPeriodicity)) {
                    errorMessage = "'Cut every how many weeks' input value is not a valid number";
                } else if (values.cutWeeklyPeriodicity <= 0) {
                    errorMessage = "'Cut every how many weeks' input value '" + values.cutWeeklyPeriodicity + "' is invalid";
                } else if (isNaN(values.cutWeeklyDay)) {
                    errorMessage = "'Cut on what day of the week' input value is invalid";
                } else if (values.cutWeeklyDay < 0 || values.cutWeeklyDay > 7) {
                    errorMessage = "'Cut on what day of the week' input value '" + values.cutWeeklyDay + "' is invalid";
                }
            }

            if (values.cutMonthly) {
                if (isNaN(values.cutMonthlyPeriodicity)) {
                    errorMessage = "'Cut every how many months' input value is not a valid number";
                } else if (values.cutMonthlyPeriodicity <= 0) {
                    errorMessage = "'Cut every how many months' input value '" + values.cutMonthlyPeriodicity + "' is invalid";
                } else if (isNaN(values.cutMonthlyDay)) {
                    errorMessage = "'Cut on what day of the month' input value is invalid";
                } else if (values.cutMonthlyDay <= 0) {
                    errorMessage = "'Cut on what day of the month' input value '" + values.cutMonthlyDay + "' is invalid";
                }
            }

            if (values.startDate == undefined || isNaN(values.startDate.getTime())) {
                errorMessage = "'Start On' date is invalid.";
            } else if (values.endDate == undefined || isNaN(values.endDate.getTime())) {
                errorMessage = "'End By' date is invalid.";
            } else if (values.startDate.getTime() >= values.endDate.getTime()) {
                errorMessage = "'Start On' is greater than or equal to 'End By', please check the dates";
            } else if (values.endDate.getFullYear() - values.startDate.getFullYear() > (values.cutMonthly ? 15 : 10)) {
                // to many periods ( > 10 years for weekly or > 15 for monthly )
                var years = values.endDate.getFullYear() - values.startDate.getFullYear();
                errorMessage = "'Start On' - 'End By' time period is to large (" +
                    years +
                    "y), please use smaller date range";
            } else if (minStartDate !== null && values.startDate.getTime() < minStartDate.getTime()) {
                errorMessage = "'Start On' is less than or equal to the latest existing period end (" +
                    DateHelper.formatUtcDate(minStartDate) +
                    "), please check the dates";
            }

            if (errorMessage !== null) {
                alert(errorMessage);
                return false;
            }
        }

        return true;
    }

    var getPeriods = function() {
        var values = readValues();

        if (!validateForm(values) || !values.enabled) {
            return null;
        }

        var periods = [];
        var start = values.startDate;
        var finish = values.endDate;
        var initialWeeklyCut = values.cutWeekly ? DateHelper.addDays(DateHelper.getNextDayOfWeek(start, values.cutWeeklyDay), (values.cutWeeklyPeriodicity - 1) * 7) : finish;
        var initialMonthlyCut = values.cutMonthly ? DateHelper.addMonths(start, values.cutMonthlyPeriodicity - 1, values.cutMonthlyDay) : finish;
        var currentCut;
        var weeklyIndex = 0;
        var monthlyIndex = 0;
        var nextWeeklyCut = initialWeeklyCut;
        var nextMonthlyCut = initialMonthlyCut;
        var id = 1;
        var calculateNextWeeklyCut = function () {
            weeklyIndex++;
            nextWeeklyCut = DateHelper.addDays(initialWeeklyCut, weeklyIndex * values.cutWeeklyPeriodicity * 7);
        }
        var calculateNextMonthlyCut = function () {
            monthlyIndex++;
            nextMonthlyCut = DateHelper.addMonths(initialMonthlyCut, monthlyIndex * values.cutMonthlyPeriodicity, values.cutMonthlyDay);
        }

        while (start < finish) {
            if (nextWeeklyCut <= nextMonthlyCut && nextWeeklyCut < finish) {
                // next weekly cut is valid and enabled, use weekly cut
                currentCut = nextWeeklyCut;
                calculateNextWeeklyCut();
                // skip next monthly cut if it is on same date as next weekly
                if (values.cutMonthly && nextWeeklyCut.getTime() === nextMonthlyCut.getTime()) {
                    calculateNextMonthlyCut();
                }
            } else if (nextMonthlyCut < finish) {
                // next monthly cut is valid and enabled, use monthly cut
                currentCut = nextMonthlyCut;
                calculateNextMonthlyCut();
                // skip next weekly cut if it is on same date as monthly
                if (values.cutWeekly === true && nextWeeklyCut.getTime() === nextMonthlyCut.getTime()) {
                    calculateNextWeeklyCut();
                }
            } else {
                // when weekly and monthly cuts are outside start / end dates - add last period with end date
                currentCut = finish;
            }

            var periodName = DateHelper.formatUtcDate(start, "short") + "-" + DateHelper.formatUtcDate(currentCut, "short");
            periods.push({ id: id, name: periodName, start: start, finish: currentCut });
            start = DateHelper.addDays(currentCut, 1);
            id++;
        }

        var summary = "Periods from " + DateHelper.formatUtcDate(values.startDate) + " to " + DateHelper.formatUtcDate(values.endDate) + "<br/>";
        if (values.cutWeekly) {
            var weekDays = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
            summary += ("Cut weekly every " + values.cutWeeklyPeriodicity + " week(s) on " + weekDays[values.cutWeeklyDay] + "<br/>");
        }

        if (values.cutMonthly) {
            summary += ("Cut monthly every " + values.cutMonthlyPeriodicity + " month(s) on " + (values.cutMonthlyEndOfDay
                ? "the last day of month"
                : ("day " + values.cutMonthlyDay) + "<br/>"));
        }

        return {
            periods: periods,
            summary: summary
        }
    }

    var initializeForm = function (onStateChange) {
        // register state on change event
        onStateChangeEvent = onStateChange;

        // initialize date pickers
        if (window.jQuery) {
            jQuery("#" + cutPeriodsStartDateInputId).datepicker({ dateFormat: 'mm/dd/yy' });
            jQuery("#" + cutPeriodsEndDateInputId).datepicker({ dateFormat: 'mm/dd/yy' });
        }
    }
    
    var setMinDate = function(value) {
        minStartDate = value;
    }

    var updateFormValues = function (automatePeriods, cutWeekly, cutMonthly, isSummaryMode, resetOptionsToDefaults) {

        document.getElementById(automateNewPeriodCreationRadioYesId).checked = automatePeriods;
        document.getElementById(automateNewPeriodCreationRadioNoId).checked = !automatePeriods;
        document.getElementById(cutPeriodsWeeklyRadioYesId).checked = cutWeekly;
        document.getElementById(cutPeriodsWeeklyRadioNoId).checked = !cutWeekly;
        document.getElementById(cutPeriodsMonthlyRadioYesId).checked = cutMonthly;
        document.getElementById(cutPeriodsMonthlyRadioNoId).checked = !cutMonthly;
        summaryMode = isSummaryMode;

        if (resetOptionsToDefaults) {
            document.getElementById(cutPeriodsWeeklyPeriodicityInputId).value = defaults.cutWeeklyPeriodicity;
            document.getElementById(cutPeriodsWeeklyDayInputId).value = defaults.cutWeeklyDay;
            document.getElementById(cutPeriodsMonthlyPeriodicityInputId).value = defaults.cutMonthlyPeriodicity;
            document.getElementById(cutPeriodsMonthlyDayInputId).value = "";
            document.getElementById(cutPeriodsMonthlyEndOfDayCheckBoxId).checked = true;

            var today = DateHelper.convertToUtcDate(new Date());
            var start = minStartDate !== null
                ? minStartDate
                : today;
            var end = (today.getTime() > start.getTime()) ? today : start;

            document.getElementById(cutPeriodsStartDateInputId).value = DateHelper.formatUtcDate(start);
            document.getElementById(cutPeriodsEndDateInputId).value = DateHelper.formatUtcDate(end);
        }

        PeriodAutomation.stateOnChange();
    }

    var automateNewPeriodCreationRadioOnClick = function () {
        PeriodAutomation.stateOnChange("enabled");
    }

    var cutPeriodsWeeklyRadioOnClick = function() {
        PeriodAutomation.stateOnChange("cutWeekly");
    }

    var cutPeriodsMonthlyRadioOnClick = function() {
        PeriodAutomation.stateOnChange("cutMonthly");
    }

    var cutPeriodsMonthlyEndOfDayCheckBoxOnClick = function() {
        PeriodAutomation.stateOnChange("cutMonthlyEndOfDay");
        var checked = document.getElementById(cutPeriodsMonthlyEndOfDayCheckBoxId).checked;
        document.getElementById(cutPeriodsMonthlyDayInputId).value = checked ? "" : defaults.cutMonthlyDay;
    }

    var displaySummary = function(summary) {
        summaryMode = true;
        document.getElementById(cutPeriodsSummaryTextId).innerHTML = summary;
        PeriodAutomation.stateOnChange();
    }

    var stateOnChange = function(scope) {
        var enabled = document.getElementById(automateNewPeriodCreationRadioYesId).checked && !summaryMode;
        var cutWeekly = document.getElementById(cutPeriodsWeeklyRadioYesId).checked;
        var cutMonthly = document.getElementById(cutPeriodsMonthlyRadioYesId).checked;
        var cutMonthlyEndOfDay = document.getElementById(cutPeriodsMonthlyEndOfDayCheckBoxId).checked;

        if (scope === undefined || scope === "enabled") {
            document.getElementById(cutPeriodsWeeklyRadioYesId).disabled = !enabled ? true : false;
            document.getElementById(cutPeriodsMonthlyRadioYesId).disabled = !enabled ? true : false;
            document.getElementById(cutPeriodsWeeklyRadioNoId).disabled = !enabled ? true : false;
            document.getElementById(cutPeriodsMonthlyRadioNoId).disabled = !enabled ? true : false;
            document.getElementById(cutPeriodsStartDateInputId).disabled = !enabled ? true : false;
            document.getElementById(cutPeriodsEndDateInputId).disabled = !enabled ? true : false;
            document.getElementById(createPeriodsButtonId).disabled = !enabled ? true : false;

            document.getElementById(cutPeriodsWeeklyRowId).style.display = !enabled ? "none" : "table-row";
            document.getElementById(cutPeriodsWeeklyPeriodicityRowId).style.display = !enabled ? "none" : "table-row";
            document.getElementById(cutPeriodsWeeklyDayRowId).style.display = !enabled ? "none" : "table-row";
            document.getElementById(cutPeriodsMonthlyRowId).style.display = !enabled ? "none" : "table-row";
            document.getElementById(cutPeriodsMonthlyPeriodicityRowId).style.display = !enabled ? "none" : "table-row";
            document.getElementById(cutPeriodsMonthlyDayRowId).style.display = !enabled ? "none" : "table-row";
            document.getElementById(cutPeriodsStartDateRowId).style.display = !enabled ? "none" : "table-row";
            document.getElementById(cutPeriodsEndDateRowId).style.display = !enabled ? "none" : "table-row";
            document.getElementById(createPeriodsActionRowId).style.display = !enabled ? "none" : "table-row";

            document.getElementById(automateNewPeriodCreationRadioYesId).disabled = summaryMode;
            document.getElementById(automateNewPeriodCreationRadioNoId).disabled = summaryMode;
            document.getElementById(cutPeriodsSummaryRowId).style.display = !summaryMode ? "none" : "table-row";
        }

        if (scope === undefined || scope === "cutWeekly") {
            document.getElementById(cutPeriodsWeeklyPeriodicityInputId).disabled = !cutWeekly ? true : false;
            document.getElementById(cutPeriodsWeeklyDayInputId).disabled = !cutWeekly ? true : false;
        }

        if (scope === undefined || scope === "cutMonthly") {
            document.getElementById(cutPeriodsMonthlyPeriodicityInputId).disabled = !cutMonthly ? true : false;
            document.getElementById(cutPeriodsMonthlyEndOfDayCheckBoxId).disabled = !cutMonthly ? true : false;
        }

        if (scope === undefined || scope === "cutMonthly" || scope === "cutMonthlyEndOfDay") {
            document.getElementById(cutPeriodsMonthlyDayInputId).disabled =
                (!cutMonthly || cutMonthlyEndOfDay) ? true : false;
        }

        if (onStateChangeEvent !== null) {
            onStateChangeEvent({
                enabled: enabled,
                cutPeriodsWeekly: cutWeekly,
                cutPeriodsMonthly: cutMonthly
            });
        }
    };

    return {
        initializeForm: initializeForm,
        updateFormValues: updateFormValues,
        setMinDate: setMinDate,
        stateOnChange: stateOnChange,
        validateForm: validateForm,
        getPeriods: getPeriods,
        displaySummary: displaySummary,
        automateNewPeriodCreationRadioOnClick: automateNewPeriodCreationRadioOnClick,
        cutPeriodsWeeklyRadioOnClick: cutPeriodsWeeklyRadioOnClick,
        cutPeriodsMonthlyRadioOnClick: cutPeriodsMonthlyRadioOnClick,
        cutPeriodsMonthlyEndOfDayCheckBoxOnClick: cutPeriodsMonthlyEndOfDayCheckBoxOnClick
    };
}();