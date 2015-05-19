function openModalDialog() {
    var options = {
        width: 680,
        height: 250,
        allowMaximize: false,
        url: L_Menu_BaseUrl + '/_layouts/EPMLive/ChangePassword.aspx',
        dialogReturnValueCallback: Function.createDelegate(
                        null, modalDialogClosedCallback)
    }

    SP.UI.ModalDialog.showModalDialog(options);
}

function modalDialogClosedCallback(result, value) {
    if (result == '1' && value == 'success') {
        this.statusId = SP.UI
            .Status
            .addStatus("Password Changed",
               "Your password has been successfully changed.",
                true);
        SP.UI.Status.setStatusPriColor(this.statusId, "Green");
    }

    if (result == '1' && value == 'fail') {
        this.statusId = SP.UI
            .Status
            .addStatus("Password Change Failed",
                "Your password has <b>not</b> changed. Please try again.",
                true);
        SP.UI.Status.setStatusPriColor(this.statusId, "Green");
    }

    if (result = '1' && value == 'cancel') {
        
    }

    setTimeout(RemoveStatus, 6000);
}

function RemoveStatus() {
    SP.UI.Status.removeStatus(this.statusId);
}
