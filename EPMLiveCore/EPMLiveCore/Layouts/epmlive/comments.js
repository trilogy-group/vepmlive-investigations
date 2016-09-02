/// <reference name="MicrosoftAjax.js" />
/// <reference path="file://C:/Program Files/Common Files/Microsoft Shared/Web Server Extensions/14/TEMPLATE/LAYOUTS/SP.core.debug.js" />
/// <reference path="file://C:/Program Files/Common Files/Microsoft Shared/Web Server Extensions/14/TEMPLATE/LAYOUTS/SP.debug.js" />

function OpenCommentsDialog() {
    var options = {
        url: GetCommentsUrl(),
        title: 'Comments',
        allowMaximize: true,
        width: 650,
        height: 500
    };

    SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
}

function GetCommentsUrl() {
    var layoutsUrl = SP.Utilities.Utility.getLayoutsPageUrl('EPMLive/Comments.aspx');
    var urlBuilder = new SP.Utilities.UrlBuilder(layoutsUrl);
    var listId = new SP.Guid(SP.ListOperation.Selection.getSelectedList());
    var itemId = GetSelectedItemId();
    
    urlBuilder.addKeyValueQueryString('itemid', itemId);
    urlBuilder.addKeyValueQueryString('listid', listId.toString('B'));

    return urlBuilder.get_url();
}

function GetSelectedItemId(){
    var itemId = '';
    var items = SP.ListOperation.Selection.getSelectedItems();
    return items[0].id;
}

