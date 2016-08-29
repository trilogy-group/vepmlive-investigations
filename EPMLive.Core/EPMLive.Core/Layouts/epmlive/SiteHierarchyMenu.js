
function PopupWorkspaceListWP() {

    var tag = document.getElementsByTagName('object');
    for (var i = tag.length - 1; i >= 0; i--) {
        tag[i].style.display = 'none';
    }

    var options = {
        url: currentWebUrl + '/_layouts/epmlive/WorkspaceListWPCanvas.aspx',
        title: 'Workspaces you have access to',
        allowMaximize: false,
        showClose: true,
        width: 400,
        height: 320,
        dialogReturnValueCallback: WorkspaceListCallBack
    };

    SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
}

function WorkspaceListCallBack(dialogResult, returnVal) {
    var tag = document.getElementsByTagName('object');
    for (var i = tag.length - 1; i >= 0; i--) {
        tag[i].style.display = '';
    }

}