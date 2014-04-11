<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KanBanPlanner.aspx.cs" Inherits="EPMLiveWorkPlanner.KanBanPlanner" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

    <meta name="viewport" content="width=device-width; maximum-scale=1; minimum-scale=1;" />

    <script type="text/javascript">

        $(function () {
            KanbanClient.resetControls(false);
            $(window).resize(function () {
                KanbanClient.resizeKanbanBoard();
            });
            ExecuteOrDelayUntilScriptLoaded(KanbanClient.loadKanBanPlanners, 'EPMLive.js');
        });


        var KanbanClient = (function () {

            var selectedKanbanPlanner;
            var selectedKanbanFilter1;
            var kanbanItemName;
            var kanbanItemNewFromUrl;
            var kanbanPlanners;
            var kanbanFilter1;
            var kanbanFilter1Name;

            var reGenerateToolBar = function () {

                $("#kanbanToolbar").html("");

                var newItemButtonCfg = '';
                var kanbanPlannersDropdownCfg = '';
                var kanbanPlannersDropdownOptionsCfg = '';
                var kanbanFilter1MultiselectCfg = '';
                var kanbanFilter1OptionsCfg = '';

                if (kanbanItemName) {
                    // new item button
                    var newItemButtonCfg = '"controlId": "btnNewItem", "controlType": "button", "iconClass": "icon-plus-2", "value": "New ' + kanbanItemName + '", "events": [{ "eventName": "click", "function": function () { showNewForm(\'' + kanbanItemNewFromUrl + '\'); }  }] ';
                }

                // kanban planners dropdown
                if (kanbanPlanners) {
                    var selectedKanbanPlannerText;
                    $.each(kanbanPlanners, function (key, value) {
                        if (value.id == selectedKanbanPlanner) {
                            selectedKanbanPlannerText = value.text;
                        }
                        kanbanPlannersDropdownOptionsCfg = kanbanPlannersDropdownOptionsCfg + '{ "iconClass": "", "value" : "' + value.id + '" ,"text": "' + value.text + '", "events": [{ "eventName": "click", "function": function () { loadKanBanFilter1(\'' + value.id + '\') } }] },';
                    });
                    if (kanbanPlannersDropdownOptionsCfg.length > 1)
                        kanbanPlannersDropdownOptionsCfg = kanbanPlannersDropdownOptionsCfg.substring(0, kanbanPlannersDropdownOptionsCfg.length - 1);
                    kanbanPlannersDropdownCfg = '"controlId": "ddlKanbanPlanners", "controlType": "dropdown", "title": "Board:", "value": "' + selectedKanbanPlannerText + '", "iconClass": "none", "sections": [{ "heading": "none", "divider": "no", "options": [' + kanbanPlannersDropdownOptionsCfg + '] }]';
                }

                // kanban filter1 multiselect
                if (kanbanFilter1) {
                    $.each(kanbanFilter1, function (key, value) {
                        kanbanFilter1OptionsCfg = kanbanFilter1OptionsCfg + '"' + value.id + '": { "value": "' + value.text + '", "checked": true },';
                    });
                    if (kanbanFilter1OptionsCfg.length > 1)
                        kanbanFilter1OptionsCfg = kanbanFilter1OptionsCfg.substring(0, kanbanFilter1OptionsCfg.length - 1);
                    kanbanFilter1MultiselectCfg = '"controlId": "msKanbanFilter1", "controlType": "multiselect", "title": "' + kanbanFilter1Name + '", "value": "", "iconClass": "icon-insert-template", "sections": [ {"heading": "none", "divider": "no", "options": { ' + kanbanFilter1OptionsCfg + ' }  } ],"applyButtonConfig": { "text": "Apply", "function": function (data) { loadKanBanBoard(data); } }';
                }

                //placement left content
                var placementLeftContentCfg = '{ "placement": "left", "content": [{' + newItemButtonCfg + '}]' + '}';

                //placement right content
                var placementRightContentCfg = '{ "placement": "right", "content": [{' + kanbanFilter1MultiselectCfg + '},{' + kanbanPlannersDropdownCfg + '}]' + '}';

                //main toolbar content
                var cfg = "[" + placementLeftContentCfg + "," + placementRightContentCfg + "]";

                epmLiveGenericToolBar.generateToolBar('kanbanToolbar', eval(cfg));
            };

            var showHideLoading = function (show, message) {
                if (show) {
                    //$("#loadingDiv").show();
                    //$("#loadingDiv div").html(message);
                    EPM.UI.Loader.current().startLoading({ id: 'kanbanLoadingDiv' });
                }
                else {
                    //$("#loadingDiv").hide();
                    //$("#loadingDiv div").html('');
                    EPM.UI.Loader.current().stopLoading('kanbanLoadingDiv');
                }
            };

            var resetControls = function (reset) {
                if (reset) {
                    $("#mainContainer").html('');
                }
                else {
                    $("#mainContainer").html('');
                }
            };

            var raiseKanbanFilter1ApplyClick = function () {
                $('.grouping-apply a').click();
                $('#msKanbanFilter1_ul_menu').hide();
            }

            var showNewForm = function (weburl) {
                var options = { url: weburl, showMaximized: false, dialogReturnValueCallback: function (dialogResult) { if (dialogResult == 1) { KanbanClient.raiseKanbanFilter1ApplyClick(); } } };
                //var options = { url: weburl, showMaximized: false, dialogReturnValueCallback: function (dialogResult) { if (dialogResult == 1) { kanbanTileCreated(); } } };
                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
            }

            var kanbanTileCreated = function () {
                $.ajax({
                    type: "POST",
                    url: "<%=SPContext.Current.Web.ServerRelativeUrl%>/_vti_bin/WorkPlanner.asmx/Execute",
                    data: "{Functionname : 'GetKanBanNewItemAdded' , Dataxml : '<DataXML><KanBanBoardName>" + selectedKanbanPlanner + "</KanBanBoardName><KanBanFilter1>" + selectedKanbanFilter1 + "</KanBanFilter1><ProjectID><%=strProjectId%></ProjectID><IsForEdit>0</IsForEdit></DataXML>'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (xhr, status, error) {
                        var err = eval("(" + xhr.responseText + ")");
                        alert(err.Message);
                    },
                    success: function (response) {
                        var newItemDiv = $(response.d);
                        var divId = $(newItemDiv).attr('id');
                        var sortableList = $(newItemDiv).attr('data-plugid');

                        if ($('#' + sortableList)) {
                            $('#' + sortableList).append(response.d);
                        }
                        else {
                            $('#' + kanbanItemName).append(response.d);
                        }

                        setupKanbanTiles();
                    }
                });
            }

            var kanbanTileEdited = function (liid) {
                if (liid) {
                    $.ajax({
                        type: "POST",
                        url: "<%=SPContext.Current.Web.ServerRelativeUrl%>/_vti_bin/WorkPlanner.asmx/Execute",
                        data: "{Functionname : 'GetKanBanNewItemAdded' , Dataxml : '<DataXML><KanBanBoardName>" + selectedKanbanPlanner + "</KanBanBoardName><KanBanFilter1>" + selectedKanbanFilter1 + "</KanBanFilter1><ProjectID><%=strProjectId%></ProjectID><IsForEdit>1</IsForEdit></DataXML>'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        error: function (xhr, status, error) {
                            var err = eval("(" + xhr.responseText + ")");
                            alert(err.Message);
                        },
                        success: function (response) {
                            var oldItemDiv = $('#' + liid);
                            var oldDivId = $(oldItemDiv).attr('id');
                            var oldSortableList = $(oldItemDiv).attr('data-plugid');

                            var newItemDiv = $(response.d);
                            var newDivId = $(newItemDiv).attr('id');
                            var newSortableList = $(newItemDiv).attr('data-plugid');


                            if (oldSortableList == newSortableList) {
                                $(oldItemDiv).replaceWith(newItemDiv)
                            }
                            else {
                                $(oldItemDiv).remove();
                                if ($('#' + sortableList)) {
                                    $('#' + sortableList).append(response.d);
                                }
                                else {
                                    $('#' + kanbanItemName).append(response.d);
                                }
                            }

                            setupKanbanTiles();

                        }
                    });
                }
            }

            var kanbanTileDeleted = function (liid) {
                if (liid) {
                    var tileToRemove = $('#mainContainer .sortable-list').find('#' + liid);
                    if ($(tileToRemove)) {
                        $(tileToRemove).remove();
                    }
                }
            }

            var loadKanBanPlanners = function () {
                //showHideLoading(true, 'Loading Planners');
                $.ajax({
                    type: "POST",
                    url: "<%=SPContext.Current.Web.ServerRelativeUrl%>/_vti_bin/WorkPlanner.asmx/Execute",
                    data: "{Functionname : 'GetKanBanPlanners' , Dataxml : '<DataXML></DataXML>'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (xhr, status, error) {
                        //showHideLoading(false, '');
                        var err = eval("(" + xhr.responseText + ")");
                        alert(err.Message);
                    },
                    success: function (response) {
                        //showHideLoading(false, '');
                        var obj = jQuery.parseJSON(response.d);
                        $.each(obj.kanbanplanners, function (key, value) {
                            if (value.id == '<%=strPlanner%>') {
                                selectedKanbanPlanner = value.id;
                                return false;
                            }
                            else {
                                selectedKanbanPlanner = value.id;
                            }
                        });

                        kanbanPlanners = obj.kanbanplanners;

                        loadKanBanFilter1(selectedKanbanPlanner);
                    }
                });
            };

            var loadKanBanFilter1 = function (kanbanPlanner) {
                selectedKanbanPlanner = kanbanPlanner;
                if (selectedKanbanPlanner == "0") {
                    resetControls(false);
                    $("span[id^='ddcl-']").remove();
                    $("div[id^='ddcl-']").remove();
                }
                else {
                    resetControls(true);
                    //showHideLoading(true, 'Loading Filters');
                    $.ajax({
                        type: "POST",
                        url: "<%=SPContext.Current.Web.ServerRelativeUrl%>/_vti_bin/WorkPlanner.asmx/Execute",
                        data: "{Functionname : 'GetKanBanFilter1' , Dataxml : '<DataXML><KanBanBoardName>" + selectedKanbanPlanner + "</KanBanBoardName><ProjectID><%=strProjectId%></ProjectID></DataXML>'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        error: function (xhr, status, error) {
                            //showHideLoading(false, '');
                            var err = eval("(" + xhr.responseText + ")");
                            alert(err.Message);
                        },
                        success: function (response) {
                            //showHideLoading(false, '');
                            var obj = jQuery.parseJSON(response.d);

                            $("span[id^='ddcl-']").remove();
                            $("div[id^='ddcl-']").remove();

                            if (obj.kanbanerror != "") {
                                resetControls(false);
                                $("#mainContainer").html(obj.kanbanerror);
                            }
                            else {
                                resetControls(true);
                                $("#lblBacklogStatus").text(obj.kanbanstatuscolumn);
                                $("#ddlBacklogStatus").children('option').remove();
                                $.each(obj.kanbanstatusvalues, function (key, value) {
                                    $("#ddlBacklogStatus").append($("<option></option>").val(value.id).html(value.id));
                                });

                                kanbanItemName = obj.kanbanitemname;
                                kanbanItemNewFromUrl = obj.kanbannewitemurl;
                                kanbanFilter1 = obj.kanbanfilter1;
                                kanbanFilter1Name = obj.kanbanfilter1name;

                                reGenerateToolBar();

                                raiseKanbanFilter1ApplyClick();
                            }
                        }
                    });
                }
            };

            var loadKanBanBoard = function (kanBanFilter1Data) {

                selectedKanbanFilter1 = "";
                var selectedKeys = kanBanFilter1Data['selectedKeys'];
                if (selectedKeys.length != 0) {
                    for (var key in selectedKeys) {
                        if (selectedKanbanFilter1 != "") selectedKanbanFilter1 += ",";
                        selectedKanbanFilter1 += selectedKeys[key].toString().replace("\\", "\\\\");
                    }
                }
                else {
                    for (var i in kanBanFilter1Data['sections']) {
                        var section = kanBanFilter1Data['sections'][i];
                        var options = section['options'];
                        for (var key in options) {
                            if (selectedKanbanFilter1 != "") selectedKanbanFilter1 += ",";
                            selectedKanbanFilter1 += key.toString().replace("\\", "\\\\");;
                        }
                    }
                }

                showHideLoading(true, 'Loading Board');
                $.ajax({
                    type: "POST",
                    url: "<%=SPContext.Current.Web.ServerRelativeUrl%>/_vti_bin/WorkPlanner.asmx/Execute",
                    data: "{Functionname : 'GetKanBanBoard' , Dataxml : '<DataXML><KanBanBoardName>" + selectedKanbanPlanner + "</KanBanBoardName><KanBanFilter1>" + selectedKanbanFilter1 + "</KanBanFilter1><ProjectID><%=strProjectId%></ProjectID></DataXML>'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (xhr, status, error) {
                        showHideLoading(false, '');
                        var err = eval("(" + xhr.responseText + ")");
                        alert(err.Message);
                    },
                    success: function (response) {
                        showHideLoading(false, '');
                        $("#mainContainer").html('');
                        $("#mainContainer").html(response.d);

                        $("#splitter").click(function () {
                            if ($("#itemContainerTD").is(":visible")) {
                                $("#splitter").html(">>");
                            } else {
                                $("#splitter").html("<<");
                            }
                            $("#itemContainerTD").toggle("fast", function () { });
                        });

                        $("#mainContainer .sortable-list").sortable({
                            connectWith: '#mainContainer .sortable-list',
                            placeholder: 'placeholder',
                            items: '.sortable-item',
                            update: function (event, ui) {
                                if (ui.sender == null) {
                                    var parentId = ui.item.parent().attr("id");
                                    var childId = ui.item.attr("id");
                                    var indexOfItem = $("#" + parentId + " > div").index($("#" + childId));


                                    if ($("#" + parentId).attr("data-dragged-status") == $(".itemContainer .sortable-list").attr("data-dragged-status")) {
                                        if ($("#ddlBacklogStatus").children('option').length == 0) {
                                            saveKanbanTile(ui, parentId, childId, ui.item.parent().attr("data-dragged-status"), indexOfItem);
                                        }
                                        else if ($("#ddlBacklogStatus").children('option').length == 1) {
                                            saveKanbanTile(ui, parentId, childId, $("#ddlBacklogStatus option:last-child").val(), indexOfItem);
                                        }
                                        else {
                                            $("#dlgBacklogStatus").dialog({
                                                resizable: false,
                                                closeOnEscape: false,
                                                modal: true,
                                                open: function () {
                                                    $(this).dialog("widget").find(".ui-dialog-titlebar").hide();
                                                },
                                                buttons: {
                                                    "Update": function () {
                                                        $(this).dialog("close");
                                                        saveKanbanTile(ui, parentId, childId, $("#ddlBacklogStatus option:selected").val(), indexOfItem);
                                                    }
                                                }
                                            });
                                        }

                                    }
                                    else {
                                        saveKanbanTile(ui, parentId, childId, ui.item.parent().attr("data-dragged-status"), indexOfItem);
                                    }
                                }

                            }
                        });

                        var per = (100 / $("#mainTR td").length).toFixed(2);
                        $("#mainTR td").css("width", per + "%");
                        $("#mainTR td").css("min-width", per + "%");
                        $("#mainTR td").css("max-width", per + "%");

                        var cardWidth = $("#itemContainerTD").width();
                        var cardWidth = (cardWidth - 30);
                        $(".single").attr("style", "width:" + cardWidth + "px");
                        $(".itemContainer .sortable-item div:nth-child(2)").attr("style", "width:" + (cardWidth - 25) + "px");

                        $('.double').each(function (i, obj) {
                            if (obj.offsetHeight < obj.scrollHeight ||
                            obj.offsetWidth < obj.scrollWidth) {
                                $(obj).dotdotdot({
                                    wrap: 'word'
                                });
                            }
                        });

                        var addContextualMenu = function () {
                            $(".associateditemscontextmenu").each(function () {
                                window.epmLiveNavigation.addContextualMenu($(this), null, true, '-1', { "delete": "KanbanClient.kanbanTileDeleted" });
                            });
                        };

                        $('.sortable-item').hover(function () {
                            $(this).find('.associateditemscontextmenu').show();
                        }, function () {
                            $(this).find('.associateditemscontextmenu').hide();
                            $(this).find('.epm-nav-contextual-menu').hide();
                        });

                        $('#mainContainer .sortable-list').slimScroll({ width: '100%' });
                        $('#mainContainer .slimScrollDiv').css({ "overflow": "visible" });
                        resizeKanbanBoard();

                        $('#mainContainer .sortable-list').on('scroll', function () {
                            $('.associateditemscontextmenu').hide();
                            $('.epm-nav-contextual-menu').hide();
                        });

                        ExecuteOrDelayUntilScriptLoaded(addContextualMenu, 'EPMLive.Navigation.js');

                    }
                });
            };

            var resizeKanbanBoard = function () {
                if ($('#mainContainer .sortable-list')) {
                    var outer = document.getElementById("section2");
                    var height = GetPageHeight();
                    var top = GetItemTop(outer);
                    $('#mainContainer .slimScrollDiv').css({ 'height': (height - top - 75) + 'px' });
                    $('#mainContainer .sortable-list').css({ 'height': (height - top - 75) + 'px' });
                }
            };

            var setupKanbanTiles = function () {
                var cardWidth = $("#itemContainerTD").width();
                var cardWidth = (cardWidth - 30);
                $(".single").attr("style", "width:" + cardWidth + "px");
                $(".itemContainer .sortable-item div:nth-child(2)").attr("style", "width:" + (cardWidth - 25) + "px");

                $('.double').each(function (i, obj) {
                    if (obj.offsetHeight < obj.scrollHeight ||
                    obj.offsetWidth < obj.scrollWidth) {
                        $(obj).dotdotdot({
                            wrap: 'word'
                        });
                    }
                });

                var addContextualMenu = function () {
                    $(".associateditemscontextmenu").each(function () {
                        window.epmLiveNavigation.addContextualMenu($(this), null, true, '-1', { "edit": "KanbanClient.kanbanTileEdited", "delete": "KanbanClient.kanbanTileDeleted" });
                    });
                };

                $('.sortable-item').hover(function () {
                    $(this).find('.associateditemscontextmenu').show();
                }, function () {
                    $(this).find('.associateditemscontextmenu').hide();
                    $(this).find('.epm-nav-contextual-menu').hide();
                });

                $('#mainContainer .sortable-list').slimScroll({ width: '100%' });
                $('#mainContainer .slimScrollDiv').css({ "overflow": "visible" });
                resizeKanbanBoard();

                $('#mainContainer .sortable-list').on('scroll', function () {
                    $('.associateditemscontextmenu').hide();
                    $('.epm-nav-contextual-menu').hide();
                });

                ExecuteOrDelayUntilScriptLoaded(addContextualMenu, 'EPMLive.Navigation.js');
            }

            var GetItemTop = function (obj) {
                var posY = obj.offsetTop;

                while (obj.offsetParent) {
                    posY = posY + obj.offsetParent.offsetTop;
                    if (obj == document.getElementsByTagName('body')[0]) { break }
                    else { obj = obj.offsetParent; }
                }

                return posY;
            }

            var GetPageHeight = function () {
                var scnHei;
                if (self.innerHeight) // all except Explorer
                {
                    //scnWid = self.innerWidth;
                    scnHei = self.innerHeight;
                }
                else if (document.documentElement && document.documentElement.clientHeight) {
                    //scnWid = document.documentElement.clientWidth;
                    scnHei = document.documentElement.clientHeight;
                }
                else if (document.body) // other Explorers
                {
                    //scnWid = document.body.clientWidth;
                    scnHei = document.body.clientHeight;
                }
                return scnHei;
            }


            var saveKanbanTile = function (ui, parentId, childId, datadraggedstatus, indexOfItem) {
                if (ui.sender == null) {
                    $("#" + childId).fadeTo(10, 0.25);
                    var data = '<DataXml><data-siteid>' + ui.item.attr("data-siteid") + '</data-siteid><data-webid>' + ui.item.attr("data-webid") + '</data-webid><data-listid>' + ui.item.attr("data-listid") + '</data-listid><data-itemid>' + ui.item.attr("data-itemid") + '</data-itemid><data-userid>' + ui.item.attr("data-userid") + '</data-userid><data-itemtitle>' + ui.item.attr("data-itemtitle") + '</data-itemtitle><data-icon>' + ui.item.attr("data-icon") + '</data-icon><data-type>' + ui.item.attr("data-type") + '</data-type><data-fstring>' + ui.item.attr("data-fstring") + '</data-fstring><data-fdate>' + ui.item.attr("data-fdate") + '</data-fdate><data-fint>' + ui.item.attr("data-fint") + '</data-fint><data-dragged-status>' + datadraggedstatus + '</data-dragged-status><data-index-of-item>' + indexOfItem + '</data-index-of-item></DataXml>';
                    $.ajax({
                        type: "POST",
                        url: "<%=SPContext.Current.Web.ServerRelativeUrl%>/_vti_bin/WorkPlanner.asmx/Execute",
                        data: "{Functionname : 'ReOrderAndSaveItem' , Dataxml : '" + data + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        error: function (xhr, status, error) {
                            var err = eval("(" + xhr.responseText + ")");
                            alert(err.Message);
                        },
                        success: function (response) {
                            $("#" + childId).fadeTo(10, 1);
                            if (datadraggedstatus == "") {
                                $("#" + childId + " > div[id^='key']").html('&nbsp;');
                            }
                            else {
                                $("#" + childId + " > div[id^='key']").html(datadraggedstatus);
                                $("#" + childId + " > div[id^='key']").attr("title", datadraggedstatus);
                            }
                        },
                        error: function (response) {
                            alert("Problem in saving item.");
                            loadKanBanBoard(selectedKanbanFilter1);
                        }
                    });
                }
            };

            return {
                resetControls: resetControls,
                loadKanBanPlanners: loadKanBanPlanners,
                loadKanBanBoard: loadKanBanBoard,
                raiseKanbanFilter1ApplyClick: raiseKanbanFilter1ApplyClick,
                kanbanTileDeleted: kanbanTileDeleted,
                kanbanTileEdited: kanbanTileEdited,
                resizeKanbanBoard: resizeKanbanBoard
            };

        })();

    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div id="kanbanLoadingDiv">
        <div id="section1">
            <div id="kanbanToolbar" style="width: 100%">
            </div>
            <div id="dlgBacklogStatus">
                <table>
                    <tr>
                        <td>
                            <b>Change backlog item  <span id="lblBacklogStatus"></span></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <select id="ddlBacklogStatus">
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="section2">
            <div id="mainContainer">
            </div>
            <div class="clear"></div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    KanBan Planner
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    KanBan Planner
</asp:Content>
