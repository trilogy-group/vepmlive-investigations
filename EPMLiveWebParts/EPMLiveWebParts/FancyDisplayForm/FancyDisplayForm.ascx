<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FancyDisplayForm.ascx.cs" Inherits="EPMLiveWebParts.FancyDisplayForm" %>

<style type="text/css">
    .fancy-display-form-wrapper {
        font-family: Open Sans Light !important;
        color: #555555;
        width: 100%;
        height: 100%;
        /*width: 900px;*/
        /*min-width: 900px;*/
    }

    .fancyDisplayForm {
        background-color: #ffffff;
        vertical-align: middle;
        outline: none;
        resize: none;
        display: inline-block;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        width: 100%;
    }

        .fancyDisplayForm #first-table {
            vertical-align: top;
            float: left;
            margin-right: 20px;
            width: 63.5%;
        }

    .fancy-display-header {
        border-bottom: 1px solid #EEEEEE;
        cursor: auto;
        font-size: 1.4em;
        padding-bottom: 5px;
        padding-top: 5px;
        font-family: Open Sans Regular !important;
    }

        .fancy-display-header span {
            color: #555555;
        }

    .fancy-col-table {
    }

        .fancy-col-table tr td:first-child {
            width: 175px;
            font-family: Open Sans Regular !important;
            vertical-align: middle;
        }

        .fancy-col-table tr td {
            font-size: 1em;
            padding-bottom: 5px;
            width: 150px;
        }

    .fancyDisplayForm .dispFormContent {
        display: block;
        width: 100%;
        padding-top: 5px;
    }

    .fancy-display-form-wrapper .dispFormExpandHeader {
        cursor: pointer;
        display: inline-block;
        padding-bottom: 5px;
        color: #0090CA;
        vertical-align: top;
    }

        .fancy-display-form-wrapper .dispFormExpandHeader span:first-child {
            color: #0090CA;
            padding-right: 5px;
            position: relative;
            top: 1px;
            font-size: .9em;
        }

    .fancy-display-form-wrapper .dispFormFancyTitle {
        display: inline-block;
        padding-bottom: 5px;
    }

        .fancy-display-form-wrapper .dispFormFancyTitle span {
            font-size: 2em;
        }

    .fancy-display-form-wrapper .dispFormUserImage {
        fit-position: slice;
        height: 22px;
        text-align: center;
        border-radius: 50%;
        vertical-align: bottom;
    }

    .fancy-display-form-wrapper .dispFormExpandMore {
        cursor: pointer;
        display: inline-block;
        color: #0090CA;
        font-size: 12px;
        padding-top: 7px;
    }

    .badge {
        display: inline-block;
        min-width: 14px;
        padding: 2px 8px;
        font-size: 12px;
        font-family: "Open Sans Semi Bold" !important;
        color: #fff;
        line-height: 13px;
        vertical-align: baseline;
        white-space: nowrap;
        text-align: center;
        background-color: #999;
        border-radius: 10px;
    }

        .badge:hover {
            background-color: #0090CA;
        }


    /* Small devices */
    @media (max-width: 768px) {
        .fancyDisplayForm #first-table {
            float: none;
        }

        .fancyDisplayForm #first-table {
            width: 100%;
        }
    }

    .fancy-display-form-wrapper .slidingDiv {
        width: 100%;
        padding: 20px;
        border: 1px thin black;
        -webkit-box-shadow: 0px 3px 20px rgba(50, 50, 50, 0.8);
        -moz-box-shadow: 0px 3px 20px rgba(50, 50, 50, 0.8);
        box-shadow: 0px 3px 20px rgba(50, 50, 50, 0.8);
        position: absolute;
        width: 200px;
        background-color: white;
        text-align: left;
        z-index: 100;
    }

    .fancy-display-form-wrapper .slidingDivClose {
        float: right;
        font-size: large;
    }

    .fancy-display-form-wrapper .slidingDivHeader {
        border-bottom: 1px solid #EEEEEE;
        cursor: auto;
        font-size: 1.4em;
        padding-bottom: 5px;
        padding-top: 5px;
        font-family: Open Sans Regular !important;
        color: #555555;
    }

    .fancy-display-form-wrapper .slidingDivAdd {
        float: right;
        left: 190px;
        position: inherit;
        top: 25px;
    }

    .fancy-display-form-wrapper .listMainDiv {
        float: left;
        margin-right: 5px;
    }

    .fancyDisplayFormAssociatedItemsContextMenu {
        list-style: none;
        cursor: pointer;
        position: absolute;
    }
</style>

<script type="text/javascript">

    $(function () {

        FancyDispFormClient.fillWebPartData();

        $(".fancy-display-form-wrapper .dispFormExpandHeader").click(function () {
            $header = $(this);
            $content = $header.next();
            $content.slideToggle(100, function () {
            });
            if ($(this).find("span:first").hasClass("icon-plus-circle-2")) {
                $(this).find("span:first").removeClass("icon-plus-circle-2").addClass("icon-minus-circle-2");
                $(this).find("span:last").text("hide");
            }
            else {
                $(this).find("span:first").removeClass("icon-minus-circle-2").addClass("icon-plus-circle-2");
                $(this).find("span:last").text("show");
            }
        });

        $(".dispFormExpandMore").click(function () {
            $header = $(this);
            $header.closest('tr').next('.ShowMoreRow').toggle();
        });
    });

    FancyDispFormClient = {

        showItemUrl: function (weburl) {
            $.ajax({
                type: "POST",
                url: weburl,
                success: function (ticket) {
                    if (ticket.indexOf("General Error") != 0) {
                        var listInfo = ticket.split('|');

                        var viewSiteContentUrl = listInfo[0] + "/_layouts/epmlive/gridaction.aspx?action=FancyDispForm&list=" + listInfo[3] + "&field=" + listInfo[1] + "&LookupFieldList=" + listInfo[2] + "&Source=" + document.location.href;
                        var options = { url: viewSiteContentUrl, showMaximized: true };
                        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
                    }
                    else {
                        alert(ticket);
                    }
                }
            });
        },

        showNewForm: function (weburl) {
            var options = { url: weburl, showMaximized: false, dialogReturnValueCallback: function (dialogResult) { if (dialogResult == 1) { FancyDispFormClient.reFillWebPartData(); } } };
            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        },

        showItemPopup: function (siteurl, webid, listid, itemid) {
            showSharePointPopup(siteurl + '/_layouts/epmlive/gridaction.aspx?action=getcontextmenus&webid=' + webid +
                '&listid=' + listid + '&ID=' + itemid, null, false, true, null, {
                    gridId: "myDiv",
                    rowId: "myDiv",
                    col: "myDiv"
                }, 300, 400);
        },

        emptyFunction: function () {
        },

        showSharePointPopup: function (url, title, allowMaximize, showClose, func, funcParams, width, height) {
            if (allowMaximize == null) allowMaximize = true;
            if (showClose == null) showClose = true;
            if (func == null) func = emptyFunction;

            var options;

            if (width !== undefined && height !== undefined) {
                options = {
                    title: title,
                    allowMaximize: allowMaximize,
                    showClose: showClose,
                    url: url,
                    dialogReturnValueCallback: Function.createCallback(Function.createDelegate(null, func), funcParams),
                    width: width,
                    height: height
                };
            } else {
                options = { title: title, allowMaximize: allowMaximize, showClose: showClose, url: url, dialogReturnValueCallback: Function.createCallback(Function.createDelegate(null, func), funcParams) };
            }

            SP.UI.ModalDialog.showModalDialog(options);
        },

        reFillWebPartData: function () {
            window.setTimeout('FancyDispFormClient.fillWebPartData()', 2000);
        },

        fillWebPartData: function () {
            $.ajax({
                type: "POST",
                url: "<%=SPContext.Current.Web.Url%>/_vti_bin/WorkEngine.asmx/Execute",
                data: "{Function : 'GetFancyFormAssociatedItems' , Dataxml: '<FancyFormAssociatedItems><FancyFormListID><%=SPContext.Current.ListId%></FancyFormListID><FancyFormItemID><%=SPContext.Current.ItemId%></FancyFormItemID></FancyFormAssociatedItems>'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    $("#<%=divFancyDispFormAssociatedItemsContent.ClientID%>").html("");
                    $("#<%=divFancyDispFormAssociatedItemsContent.ClientID%>").html(response.d.toString().replace("<Result Status=\"0\">", "").replace("</Result>", ""));

                    $(".slidingDiv").hide();

                    var mouseX, mouseY, windowWidth, windowHeight;
                    var popupLeft, popupTop;
                    $(document).mousemove(function (e) {
                        mouseX = e.pageX;
                        mouseY = e.pageY;
                        //To Get the relative position
                        if (this.offsetLeft != undefined)
                            mouseX = e.pageX - this.offsetLeft;
                        if (this.offsetTop != undefined)
                            mouseY = e.pageY; -this.offsetTop;

                        if (mouseX < 0)
                            mouseX = 0;
                        if (mouseY < 0)
                            mouseY = 0;

                        windowWidth = $(window).width() + $(window).scrollLeft();
                        windowHeight = $(window).height() + $(window).scrollTop();
                    });

                    $(document).click(function (e) {
                        var classAttr = $(e.target).attr('class');
                        if (classAttr != 'fancyDisplayFormAssociatedItemsContextMenu' && classAttr != 'epm-menu-btn' && classAttr != 'icon-ellipsis-horizontal') {
                            $(".slidingDiv").hide();
                        }
                    });

                    $('#first-table').mouseenter(
                        function () {
                            $(".slidingDiv").hide();
                        }
                    );

                    $('.listMainDiv .badge').mouseenter(
                        function () {
                            $(".slidingDiv").hide();

                            var currentSlidingDiv = $(this).parent().parent().find(".slidingDiv");
                            currentSlidingDiv.show();

                            var popupWidth = currentSlidingDiv.outerWidth();
                            var popupHeight = currentSlidingDiv.outerHeight();

                            if (mouseX + popupWidth > windowWidth)
                                popupLeft = mouseX - popupWidth;
                            else
                                popupLeft = mouseX;

                            if (mouseY + popupHeight > windowHeight)
                                popupTop = mouseY - popupHeight;
                            else
                                popupTop = mouseY;

                            if (popupLeft < $(window).scrollLeft()) {
                                popupLeft = $(window).scrollLeft();
                            }

                            if (popupTop < $(window).scrollTop()) {
                                popupTop = $(window).scrollTop();
                            }

                            if (popupLeft < 0 || popupLeft == undefined)
                                popupLeft = 0;
                            if (popupTop < 0 || popupTop == undefined)
                                popupTop = 0;

                            currentSlidingDiv.offset({ top: popupTop, left: popupLeft });
                        }
                    );

                    var addContextualMenu = function () {
                        $(".fancyDisplayFormAssociatedItemsContextMenu").each(function () {
                            window.epmLiveNavigation.addContextualMenu($(this), null, true, '-1', { "delete": "FancyDispFormClient.reFillWebPartData" });
                        });
                    };

                    window.ExecuteOrDelayUntilScriptLoaded(addContextualMenu, 'EPMLive.Navigation.js');
                }
            });
        }
    }
</script>

<div class="fancy-display-form-wrapper" id="divFancyDisplayForm" runat="server" style="width: 100%">

    <div style="text-align: right; float: right;">
        <asp:Button ID="btnCancel1" runat="server" Text="Close" OnClick="btnCancel_Click" />
    </div>

    <div class="dispFormFancyTitle">
        <asp:Label ID="lblItemTitle" runat="server" CssClass="dispFormFancyTitle" Text=""></asp:Label>
    </div>

    <div class="fancyDisplayForm" style="width: 100%; vertical-align: top;">

        <div id="first-table">
            <table border="0" style="width: 100%">
                <tr>
                    <td id="divQuickDetailsParent" runat="server">
                        <div id="divQuickDetailsHeader" class="fancy-display-header">
                            <span>Quick Details</span>
                        </div>
                        <div id="divQuickDetailsContent" runat="server" class="dispFormContent">
                        </div>
                        <div style="width: 100%">
                            <table border="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <div class="dispFormExpandHeader" id="divShowQuickDetailsHeader" runat="server">
                                            <span class="icon-plus-circle-2"></span><span>show</span>
                                        </div>
                                        <div class="dispFormContent" id="divShowQuickDetailsContent" runat="server" style="display: none">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td id="divNarrativeDetailsParent" runat="server">
                        <div id="divNarrativeDetails" runat="server" class="fancy-display-header">
                            <span>Narrative Details</span>
                        </div>
                        <div class="dispFormContent" id="divNarrativeDetailsContent" runat="server">
                        </div>
                        <div>
                            <table border="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <div class="dispFormExpandHeader" id="divShowNarrativeDetailsHeader" runat="server">
                                            <span class="icon-plus-circle-2"></span><span>show</span>
                                        </div>
                                        <div class="dispFormContent" id="divShowNarrativeDetailsContent" runat="server" style="display: none">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="vertical-align: top; display: inline;">
            <table border="0">
                <tr>
                    <td id="divPeopleDetailsParent" runat="server">

                        <div id="divPeopleDetails" runat="server" class="fancy-display-header">
                            <span>People</span>
                        </div>
                        <div class="dispFormContent" id="divPeopleContent" runat="server">
                        </div>
                        <div>
                            <table border="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <div class="dispFormExpandHeader" id="divPeopleShowAllHeader" runat="server">
                                            <span class="icon-plus-circle-2"></span><span>show</span>
                                        </div>
                                        <div class="dispFormContent" id="divPeopleShowAllContent" runat="server" style="display: none">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td id="divDateDetailsParent" runat="server">

                        <div id="divDateDetails" runat="server" class="fancy-display-header">
                            <span>Dates</span>
                        </div>
                        <div class="dispFormContent" id="divDatesContent" runat="server">
                        </div>
                        <div class="dispFormContent" id="divShowAllDateDetails" runat="server">
                            <table border="0" style="width: 100%">
                                <tr>
                                    <td>
                                        <div class="dispFormExpandHeader" id="divDatesShowAllHeader" runat="server">
                                            <span class="icon-plus-circle-2"></span><span>show</span>
                                        </div>
                                        <div class="dispFormContent" id="divDatesShowAllContent" runat="server" style="display: none">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td id="divFancyDispFormParent" runat="server">
                        <div id="divFancyDispForm" class="fancy-display-header">
                            <span>Associated Items</span>
                        </div>
                        <div class="dispFormContent" id="divFancyDispFormAssociatedItemsContent" runat="server" style="color: #555555;">
                        </div>
                    </td>
                </tr>
            </table>
        </div>

    </div>

    <div class="fancyDisplayForm dispFormContent" id="divItemDetailParent" runat="server" style="float: right; width: 100%;">
    </div>

    <div style="text-align: right; float: right;">
        <asp:Button ID="btnCancel2" runat="server" Text="Close" OnClick="btnCancel_Click" />
    </div>

</div>
