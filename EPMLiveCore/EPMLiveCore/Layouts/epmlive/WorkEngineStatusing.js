var _WEStatus_PercentComplete
var _WEStatus_Complete
var _WEStatus_Status

var _WEStatus_Control_PercentComplete;
var _WEStatus_Control_Complete;
var _WEStatus_Control_Status;

function ProcessStatus() {



    if (_WEStatus_Status == "Not Started") {
        _WEStatus_PercentComplete = 0;
        _WEStatus_Complete = false;
    }
    else if (_WEStatus_Status == "Completed") {
        _WEStatus_PercentComplete = 100;
        _WEStatus_Complete = true;
    }
    else if (_WEStatus_Status == "In Progress") {
        if (_WEStatus_PercentComplete == 0 || _WEStatus_PercentComplete == 100 || _WEStatus_PercentComplete == null)
            _WEStatus_PercentComplete = 50;

        _WEStatus_Complete = false;
    }
    else {
        if (_WEStatus_PercentComplete == 100)
            _WEStatus_PercentComplete = 50;

        _WEStatus_Complete = false;
    }
}

function ProcessComplete() {

    if (_WEStatus_Complete != null) {
        if (_WEStatus_Complete) {
            _WEStatus_PercentComplete = 100;
            _WEStatus_Status = "Completed";
        }
        else {
            _WEStatus_PercentComplete = 0;
            _WEStatus_Status = "Not Started";
        }
    }
}

function ProcessPercentComplete() {
    if (_WEStatus_PercentComplete == 0 || _WEStatus_PercentComplete == null) {
        _WEStatus_Status = "Not Started";
        _WEStatus_Complete = false;
    }
    else if (_WEStatus_PercentComplete == 100) {
        _WEStatus_Status = "Completed";
        _WEStatus_Complete = true;
    }
    else {
        if (_WEStatus_Status == "Not Started" || _WEStatus_Status == "Completed" || _WEStatus_Status == "")
            _WEStatus_Status = "In Progress";

        _WEStatus_Complete = false;
    }
}

function ProcessEditFormControls() {

    if (_WEStatus_Control_PercentComplete != null && _WEStatus_PercentComplete != undefined)
        _WEStatus_Control_PercentComplete.value = _WEStatus_PercentComplete;

    if (_WEStatus_Control_Complete != null)
        _WEStatus_Control_Complete.checked = _WEStatus_Complete;

    if (_WEStatus_Control_Status != null) {
        for (var i = 0; i < _WEStatus_Control_Status.options.length; i++) {
            if (_WEStatus_Control_Status.options[i].value == _WEStatus_Status) {
                _WEStatus_Control_Status.options[i].selected = true;
                break;
            }
        }
    }
}

function ProcessCompleteForm() {
    if (_WEStatus_Control_Complete != null) {
        _WEStatus_Complete = _WEStatus_Control_Complete.checked;
        ProcessComplete();
        ProcessEditFormControls();
    }
}

function ProcessStatusForm() {

    if (_WEStatus_Control_Status != null) {
        for (var i = 0; i < _WEStatus_Control_Status.options.length; i++) {
            if (_WEStatus_Control_Status.options[i].selected) {
                _WEStatus_Status = _WEStatus_Control_Status.options[i].value;
                break;
            }
        }

        ProcessStatus();
        ProcessEditFormControls();
    }
}

function ProcessPercentCompleteForm() {
    if (_WEStatus_Control_PercentComplete != null) {
        if (_WEStatus_Control_PercentComplete.value != "")
            _WEStatus_PercentComplete = parseFloat(_WEStatus_Control_PercentComplete.value);
        else
            _WEStatus_PercentComplete = 0;

        ProcessPercentComplete();
        ProcessEditFormControls();
    }
}

function InitStatusingControls(_comp, _pct, _status) {
    setTimeout("InitStatusing('" + _comp + "','" + _pct + "','" + _status + "')", 1000);
}

function InitStatusing(_comp, _pct, _status) {
    try {
        _WEStatus_Control_PercentComplete = document.getElementById(_pct);
        _WEStatus_Complete = _WEStatus_Control_PercentComplete.checked;
    } catch (e) { }
    try {
        _WEStatus_Control_Complete = document.getElementById(_comp);
        _WEStatus_PercentComplete = _WEStatus_Control_PercentComplete.value;
    } catch (e) { }
    try {
        _WEStatus_Control_Status = document.getElementById(_status);
        for (var i = 0; i < _WEStatus_Control_Status.options.length; i++) {
            if (_WEStatus_Control_Status.options[i].selected) {
                _WEStatus_Status = _WEStatus_Control_Status.options[i].value;
                break;
            }
        }
    } catch (e) { }
    AddFormEvents();
}


    function AddFormEvents() {
        if (_WEStatus_Control_Complete != null)
            _WEStatus_Control_Complete.onclick = function () { ProcessCompleteForm(); };

        if (_WEStatus_Control_Status != null)
            _WEStatus_Control_Status.onchange = function () { ProcessStatusForm(); };

        if (_WEStatus_Control_PercentComplete != null)
            _WEStatus_Control_PercentComplete.onchange = function () { ProcessPercentCompleteForm(); };
    }