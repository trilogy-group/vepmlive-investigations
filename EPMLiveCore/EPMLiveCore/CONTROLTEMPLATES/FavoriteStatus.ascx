<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FavoriteStatus.ascx.cs" Inherits="EPMLiveCore.CONTROLTEMPLATES.FavoriteStatus" %>

<div id="EPMLiveFavoriteStatus" style="width: 100px; width: 30px; display: inline-block; vertical-align: middle;">
    
    <style>
        body {
            background-color: #F3F3F3;
        }

        .icon-star-disabled {
            /*font-size: 1.2em;*/
            color: #D1D1D1;
            text-shadow: 0px 1px white;
            cursor: pointer;
        }

        .icon-star-active {
            color: #0072C6 !important;
            cursor: pointer;
        }
    </style>

    <span style="display: none;color:#D1D1D1;" class="icon-star icon-star-disabled" id="favoritesStar" ></span>

   <%-- <script>
        var favoritesData =
            "<Data>" +
                "<Param key=\"SiteId\">" + epmLive.currentSiteId + "</Param>" +
                "<Param key=\"WebId\">" + epmLive.currentWebId + "</Param>" +
                "<Param key=\"ListId\">" + epmLive.currentListId + "</Param>" +
                "<Param key=\"ListIconClass\">" + epmLive.currentListIcon + "</Param>" +
                "<Param key=\"ItemId\">" + epmLive.currentItemID + "</Param>" +
                "<Param key=\"FString\">" + epmLive.currentUrl + "</Param>" +
                "<Param key=\"Type\">1</Param>" +
                "<Param key=\"UserId\">" + epmLive.currentUserId + "</Param>" +
                "<Param key=\"Title\">" + $('#favTitle').text() + "</Param>" +
                "</Data>";
        
        $("#favoritesStar").click(function () {
            //$(this).toggleClass('icon-star-active');

            if ($(this).hasClass('icon-star-disabled')) {
                var options = {
                    url: epmLive.currentWebUrl + '/_layouts/epmlive/AddFavorite.aspx?listid=' + epmLive.currentListId + '&itemid=' + epmLive.currentItemID + '&currentUrl=' + epmLive.currentUrl,
                    height: 150,
                    width: 400,
                    allowMaximize: false,
                    autoResize: false,
                    dialogReturnValueCallback: function (result, returnVal) {
                        if (result == 1) {

                        }
                    }
                };

                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
            } else {

                if (confirm('Unfavorite?')) {
                    $.ajax({
                        type: 'POST',
                        url: epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                        data: "{ Function: 'AddFavorites', Dataxml: '" + favoritesData + "' }",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            if (response.d) {
                                var resp = epmLive.parseJson(response.d);
                                var result = resp.Result;

                                if (epmLive.responseIsSuccess(result)) {
                                    //onSuccess(result);
                                } else {
                                    //onError(response);
                                }
                            } else {
                                //onError(response);
                            }
                        },
                        error: function (response) {
                            //onError(response);
                        }
                    });
                }
            }

        });

    </script>--%>
</div>
