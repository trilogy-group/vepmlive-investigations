<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FancyDisplayForm.ascx.cs" Inherits="EPMLiveWebParts.FancyDisplayForm" %>

<style type="text/css">
    #attach-wrapper {
    }

        #attach-wrapper .paperclip {
            color: #999999;
            display: inline-block;
            font-size: 14px;
            vertical-align: top;
            position: relative;
        }

        #attach-wrapper .attach-text {
            color: #555555;
            padding: 4px 4px 0px 4px;
            line-height: 12px;
        }

        #attach-wrapper #attach-text-wrapper {
            display: inline-block;
            width: 95%;
        }

        #attach-wrapper .attach-text .file {
            padding-right: 5px;
            color: #bbbbbb;
        }

        #attach-wrapper .attach-text .delete {
            padding-left: 5px;
            color: #cccccc;
            display: none;
        }

            #attach-wrapper .attach-text .delete:hover {
                cursor: pointer;
                color: #0090ca;
            }

        #attach-wrapper .attach-text a {
            text-decoration: none;
            color: #0090ca;
        }

        #attach-wrapper .attach-text a:hover {
            color: #0090ca;
            cursor: pointer;
            text-decoration:underline;
        }

        #attach-wrapper .upload-attach {
           color: #aaaaaa;
           font-size:12px;
           padding-left:5px;
        }
        
        #attach-wrapper .upload-attach:hover {
           color: #555555; 
        }
        
</style>

<script type="text/javascript">
    function openDialog() {
        var options =
        {
            url: $("#<%= hiddenWebUrl.ClientID %>").val() + "/_layouts/AttachFile.aspx?ListId=" + $("#<%= hiddenListId.ClientID %>").val() + "&ItemId=" + $("#<%= hiddenItemId.ClientID %>").val() + "&isdlg=1&Source=" + $("#<%= hiddenSourceUrl.ClientID %>").val(),
            width: 325,
            height: 155,
            title: "Attach File",
            dialogReturnValueCallback: function (dialogResult) { if (dialogResult == 1) { FancyDispFormClient.FillAttachmentSection(); } }
        };
        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }

    $(function () {

        FancyDispFormClient.LoadAssociatedItems();
        FancyDispFormClient.LoadItemAttachments();

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

        $(".attach-text").mouseover(function () {
            $(this).find('.delete').css("display", "inline");
        }).mouseout(function () {
            $(this).find('.delete').css("display", "none");
        });
    });

    FancyDispFormClient = {

        DeleteItemAttachment: function (deleteItemUrl) {

            if (confirm('Are you sure you want to send the item to the Recycle Bin?')) {

                $.ajax({
                    type: "POST",
                    url: deleteItemUrl,
                    success: function (ticket) {
                        if (ticket.indexOf("General Error") != 0) {
                            var listInfo = ticket.split('|');
                            var viewSiteContentUrl = $("#<%= hiddenWebUrl.ClientID %>").val() + "/_layouts/epmlive/gridaction.aspx?action=deleteitemattachment&listid=" + listInfo[0] + "&itemid=" + listInfo[1] + "&fname=" + listInfo[2] + "&Source=" + document.location.href;
                            FancyDispFormClient.LoadItemAttachments();
                        }
                        else {
                            alert(ticket);
                        }
                        $(".attach-text").mouseover(function () {
                            $(this).find('.delete').css("display", "inline");
                        }).mouseout(function () {
                            $(this).find('.delete').css("display", "none");
                        });
                    }
                });
            }

        },

        showItemUrl: function (weburl) {
            $.ajax({
                type: "POST",
                url: weburl,
                success: function (ticket) {
                    if (ticket.indexOf("General Error") != 0) {
                        var listInfo = ticket.split('|');

                        var viewSiteContentUrl = listInfo[0] + "/_layouts/epmlive/gridaction.aspx?action=FancyDispForm&list=" + listInfo[3] + "&field=" + listInfo[1] + "&LookupFieldList=" + listInfo[2] + "&Source=" + document.location.href;
                        //var options = { url: viewSiteContentUrl, showMaximized: true };
                        //SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
                        FancyDispFormClient.FillAssociatedItemSection();
                    }
                    else {
                        alert(ticket);
                    }
                }
            });
        },

        showNewForm: function (weburl) {
            var options = { url: weburl, showMaximized: true, dialogReturnValueCallback: function (dialogResult) { if (dialogResult == 1) { FancyDispFormClient.FillAssociatedItemSection(); } } };
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

        FillAttachmentSection: function () {
            window.setTimeout('FancyDispFormClient.LoadItemAttachments()', 1000);
        },

        LoadItemAttachments: function () {
            $.ajax({
                type: "POST",
                url: "<%=SPContext.Current.Web.Url%>/_vti_bin/WorkEngine.asmx/Execute",
                data: "{Function : 'GetFancyFormAssociatedItemAttachments' , Dataxml: '<FancyFormAssociatedItemAttachments><FancyFormListID><%=SPContext.Current.ListId%></FancyFormListID><FancyFormItemID><%=SPContext.Current.ItemId%></FancyFormItemID></FancyFormAssociatedItemAttachments>'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    $("#<%=divAttachmentDetailsContent.ClientID%>").html("");
                    $("#<%=divAttachmentDetailsContent.ClientID%>").html(response.d.toString().replace("<Result Status=\"0\">", "").replace("</Result>", ""));

                    $(".attach-text").mouseover(function () {
                        $(this).find('.delete').css("display", "inline");
                    }).mouseout(function () {
                        $(this).find('.delete').css("display", "none");
                    });

                    var applyFancybox = function () {
                        if ($.fancybox) {
                            $("a[href$='.jpg'][class='fancybox'],a[href$='.png'][class='fancybox'],a[href$='.gif'][class='fancybox']").fancybox();
                        } else {
                            window.setTimeout(function () { applyFancybox(); }, 10);
                        }
                    }
                    $(document).ready(function () {
                        applyFancybox();
                    });
                }
            });
        },

        FillAssociatedItemSection: function () {
            window.setTimeout('FancyDispFormClient.LoadAssociatedItems()', 2000);
        },

        LoadAssociatedItems: function () {
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
                            window.epmLiveNavigation.addContextualMenu($(this), null, true, '-1', { "delete": "FancyDispFormClient.FillAssociatedItemSection" });
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
                <tr>
                    <td id="divAttachmentDetailsParent" runat="server">
                        <div id="divAttachmentDetails" runat="server" class="fancy-display-header">
                        </div>
                        <div class="dispFormContent" id="divAttachmentDetailsContent" runat="server">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="vertical-align: top; display: inline;">
            <table border="0" style="display:-webkit-box;">
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
    <div class="fancyDisplayForm dispFormContent" id="divItemDetailParent" runat="server" style="float: right; width: 100%; padding-top:10px;">
    </div>
    <div style="text-align: right; float: right;">
        <asp:Button ID="btnCancel2" runat="server" Text="Close" OnClick="btnCancel_Click" />
    </div>
</div>
<input id="hiddenListId" type="hidden" runat="server" />
<input id="hiddenItemId" type="hidden" runat="server" />
<input id="hiddenSourceUrl" type="hidden" runat="server" />
<input id="hiddenWebUrl" type="hidden" runat="server" />