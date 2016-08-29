function InitAddFavorite() {
    (function(f, $$, $) {
        var favoritesData =
            "<Data>" +
                "<Param key=\"SiteId\">" + $$.currentSiteId + "</Param>" +
                "<Param key=\"WebId\">" + $$.currentWebId + "</Param>" +
                "<Param key=\"ListId\">" + f.ListId + "</Param>" +
                "<Param key=\"ListIconClass\">" + $$.currentListIcon + "</Param>" +
                "<Param key=\"ItemId\">" + f.ItemId + "</Param>" +
                "<Param key=\"FString\">" + f.FString + "</Param>" +
                "<Param key=\"Type\">1</Param>" +
                "<Param key=\"UserId\">" + $$.currentUserId + "</Param>" +
                "<Param key=\"Title\">" + $('#favTitle').text() + "</Param>" +
                "</Data>";

        function cancel() {
            parent.SP.UI.ModalDialog.commonModalDialogClose('', '');
        }

        function add() {
            $.ajax({
                type: 'POST',
                url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'AddFavorites', Dataxml: '" + favoritesData + "' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function(response) {
                    if (response.d) {
                        var resp = $$.parseJson(response.d);
                        var result = resp.Result;

                        if ($$.responseIsSuccess(result)) {
                            //onSuccess(result);
                            parent.SP.UI.ModalDialog.commonModalDialogClose(1, '');
                        } else {
                            //onError(response);
                        }
                    } else {
                        //onError(response);
                    }
                },
                error: function(response) {
                    //onError(response);
                }
            });
        }
        
      
    })(window.AddFavorite = window.AddFavorite || {}, window.epmLive, window.jQuery);
}
ExecuteOrDelayUntilScriptLoaded(InitAddFavorite, 'EPMLive.js');