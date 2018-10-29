var AutoAdjustPeriodsDefaults = {
    enabled: false,
    startPeriodDelta: 6,
    finishPeriodDelta: 6
};

function AutoAdjustPeriods(enabled, start, finish) {
    var $this = this;
    this.enabled = enabled;
    this.startPeriodDelta = start;
    this.finishPeriodDelta = finish;

    AutoAdjustPeriods.prototype.TryLoadFromConfig = function(view) {
        try {
            if (view !== undefined && view !== null) {
                $this.enabled = parseInt(view.AutoAdjustPeriods) === 1;
                $this.startPeriodDelta = parseInt(view.StartPeriodDelta);
                $this.finishPeriodDelta = parseInt(view.FinishPeriodDelta);
            } else {
                $this.enabled = AutoAdjustPeriodsDefaults.enabled;
                $this.startPeriodDelta = AutoAdjustPeriodsDefaults.startPeriodDelta;
                $this.finishPeriodDelta = AutoAdjustPeriodsDefaults.finishPeriodDelta;
            }

            $this.EnsureValidValues();
        } catch (e) {
            $this.enabled = false;
            $this.startPeriodDelta = AutoAdjustPeriodsDefaults.startPeriodDelta;
            $this.finishPeriodDelta = AutoAdjustPeriodsDefaults.finishPeriodDelta;
            window.console && window.console.log(e);
        }
    };

    AutoAdjustPeriods.prototype.EnsureValidValues = function() {
        if (isNaN($this.enabled)) {
            $this.enabled = AutoAdjustPeriodsDefaults.enabled;
        }

        if (isNaN($this.startPeriodDelta)) {
            $this.startPeriodDelta = AutoAdjustPeriodsDefaults.startPeriodDelta;
        }

        if (isNaN($this.finishPeriodDelta)) {
            $this.finishPeriodDelta = AutoAdjustPeriodsDefaults.finishPeriodDelta;
        }
    };

    AutoAdjustPeriods.prototype.UpdateDialogValues = function (document, autoAdjustPeriodsCheckBoxId, startPeriodDeltaInputId, finishPeriodDeltaInputId) {
        var autoAdjustPeriodsCheckBox = document.getElementById(autoAdjustPeriodsCheckBoxId === undefined
            ? "autoAdjustPeriodsCheckBox"
            : autoAdjustPeriodsCheckBoxId);
        var startPeriodDeltaInput = document.getElementById(startPeriodDeltaInputId === undefined
            ? "startPeriodDeltaInput"
            : startPeriodDeltaInputId);
        var finishPeriodDeltaInput = document.getElementById(finishPeriodDeltaInputId === undefined
            ? "finishPeriodDeltaInput"
            : finishPeriodDeltaInputId);

        autoAdjustPeriodsCheckBox.checked = $this.enabled;
        startPeriodDeltaInput.value = $this.startPeriodDelta;
        finishPeriodDeltaInput.value = $this.finishPeriodDelta;

        AutoAdjustPeriods.DocumentAutoAdjustPeriodsCheckBoxOnClick(document,
            autoAdjustPeriodsCheckBoxId,
            startPeriodDeltaInputId,
            finishPeriodDeltaInputId);
    };

    AutoAdjustPeriods.prototype.GetAutoAdjustPeriods = function (currentPeriod, allPeriods, firstIndex) {
        if (firstIndex === undefined) {
            firstIndex = 1;
        }

        var lastIndex = allPeriods.length - 1;
        if (lastIndex < firstIndex) {
            // cannot calculate because specified first index does not exist in allPeriods array, returns empty result
            return {};
        }

        var currentIndex = -1;
        var currentPeriodId = parseInt(currentPeriod);

        // find the current period index in allPeriods array
        for (var i = 0; i < allPeriods.length; i++) {
            var periodId = parseInt(allPeriods[i].PeriodID);
            
            if (currentPeriodId === periodId) {
                currentIndex = i;
                break;
            }
        }

        if (currentIndex === -1) {
            // cannot calculate because specified current period not found in allPeriods array, 
            // returns result when start period is first element and finish period is last element in periods array 
            // with respect to specified first and last index value.
            return {
                startPeriodIndex: firstIndex,
                finishPeriodIndex: lastIndex,
                startPeriod: allPeriods[firstIndex].PeriodID,
                finishPeriod: allPeriods[lastIndex].PeriodID
            };
        }

        var startPeriodIndex = currentIndex - $this.startPeriodDelta;
        var finishPeriodIndex = currentIndex + $this.finishPeriodDelta;

        if (startPeriodIndex < firstIndex) {
            startPeriodIndex = firstIndex;
        }

        if (finishPeriodIndex < startPeriodIndex) {
            finishPeriodIndex = startPeriodIndex;
        } else if (finishPeriodIndex > lastIndex) {
            finishPeriodIndex = lastIndex;
        }

        return {
            startPeriodIndex: startPeriodIndex,
            finishPeriodIndex: finishPeriodIndex,
            startPeriod: allPeriods[startPeriodIndex].PeriodID,
            finishPeriod: allPeriods[finishPeriodIndex].PeriodID
        };
    };
}

AutoAdjustPeriods.CreateDefault = function() {
    return new AutoAdjustPeriods(AutoAdjustPeriodsDefaults.enabled,
        AutoAdjustPeriodsDefaults.startPeriodDelta,
        AutoAdjustPeriodsDefaults.finishPeriodDelta);
};

AutoAdjustPeriods.EnsureValidInstance = function(item) {
    if (item === null || item === undefined) {
        return AutoAdjustPeriods.CreateDefault();
    } else {
        item.EnsureValidValues();
        return item;
    }
}

AutoAdjustPeriods.TryCreateFromConfig = function(view) {
    var result = AutoAdjustPeriods.CreateDefault();
    result.TryLoadFromConfig(view);
    return result;
};

AutoAdjustPeriods.CreateFromDocument = function(document, autoAdjustPeriodsCheckBoxId, startPeriodDeltaInputId, finishPeriodDeltaInputId) {
    var autoAdjustPeriods = document.getElementById(autoAdjustPeriodsCheckBoxId === undefined
        ? "autoAdjustPeriodsCheckBox"
        : autoAdjustPeriodsCheckBoxId).checked;
    var startPeriodDelta = parseInt(document.getElementById(startPeriodDeltaInputId === undefined
        ? "startPeriodDeltaInput"
        : startPeriodDeltaInputId).value);
    var finishPeriodDelta = parseInt(document.getElementById(finishPeriodDeltaInputId === undefined
        ? "finishPeriodDeltaInput"
        : finishPeriodDeltaInputId).value);

    // validate auto adjust period values
    if (autoAdjustPeriods) {
        if (isNaN(startPeriodDelta) || startPeriodDelta < 0) {
            alert("Adjust from period value " + startPeriodDelta + " is invalid.");
            return null;
        }

        if (isNaN(finishPeriodDelta) || finishPeriodDelta < 0) {
            alert("Adjust to period value " + finishPeriodDelta + " is invalid.");
            return null;
        }
    }

    return new AutoAdjustPeriods(autoAdjustPeriods, startPeriodDelta, finishPeriodDelta);
};

AutoAdjustPeriods.DocumentAutoAdjustPeriodsCheckBoxOnClick = function (document, autoAdjustPeriodsCheckBoxId, startPeriodDeltaInputId, finishPeriodDeltaInputId) {
    var autoAdjustPeriodsValue = document.getElementById(autoAdjustPeriodsCheckBoxId === undefined
        ? "autoAdjustPeriodsCheckBox"
        : autoAdjustPeriodsCheckBoxId).checked;
    var startPeriodDeltaInput = document.getElementById(startPeriodDeltaInputId === undefined
        ? "startPeriodDeltaInput"
        : startPeriodDeltaInputId);
    var finishPeriodDeltaInput = document.getElementById(finishPeriodDeltaInputId === undefined
        ? "finishPeriodDeltaInput"
        : finishPeriodDeltaInputId);

    startPeriodDeltaInput.disabled = !autoAdjustPeriodsValue;
    finishPeriodDeltaInput.disabled = !autoAdjustPeriodsValue;
};