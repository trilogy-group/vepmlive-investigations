function OpenViewInModal(title, url, rowId, cellIndex) {
    if (title && url) {
        if (url.indexOf('.aspx') >= 0) {
            options = {
                url: url + "?InitialTabId=Ribbon.List",
                title: title,
                showMaximized: true
            };
            if (url.indexOf('ReportServer/RSViewerPage.aspx') < 0)
                SP.UI.ModalDialog.showModalDialog(options);
            else
                window.open(url,null,"config='toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes");
        }
        else {
//            if (document.all && document.querySelector && !document.getElementsByClassName) {
//                alert('IE8');
//            }

            //checkVersion();
            var dispExArgs = '';
            dispExArgs += "this,"; // ele
            dispExArgs += "event,"; // objEvent
            dispExArgs += "'TRUE',"; // fTransformServiceOn
            dispExArgs += "'FALSE',"; // fShouldTransformExtension
            dispExArgs += "'FALSE',"; // fTransformHandleUrl
            dispExArgs += "'SharePoint.OpenDocuments.3',"; // strHtmlTrProgId
            dispExArgs += "'1',"; // iDefaultItemOpen
            dispExArgs += "'SharePoint.OpenDocuments',"; // strProgId
            dispExArgs += "'',"; // strHtmlType
            dispExArgs += "'',"; // strServerFileRedirect
            dispExArgs += "'',"; // strCheckoutUser
            dispExArgs += "'1',"; // strCurrentUser [current user ID]
            dispExArgs += "'0',"; // strRequireCheckout
            dispExArgs += "'0',"; // strCheckedoutTolocal 
            dispExArgs += "'0x7fffffffffffffff',"; // strPermmask [full permissions mask]
            dispExArgs += "'',";
            dispExArgs += "''";

            var linkHtml = '<a onclick="return DispEx(' + dispExArgs + ');" href="' + url + '">' + '' + '</a>';
            var link = $(linkHtml);
            $('body').append(link);
            link.get(0).click();
            link.remove();
        }

    }
}

function getInternetExplorerVersion()
// Returns the version of Internet Explorer or a -1
// (indicating the use of another browser).
{
    var rv = -1; // Return value assumes failure.
    if (navigator.appName == 'Microsoft Internet Explorer') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }
    return rv;
}
function checkVersion() {
    var msg = "You're not using Internet Explorer.";
    var ver = getInternetExplorerVersion();

    if (ver > -1) {
        if (ver >= 8.0)
            msg = "You're using a recent copy of Internet Explorer."
        else
            msg = "You should upgrade your copy of Internet Explorer.";
    }
    alert(msg);
}
