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
            ExecuteOrDelayUntilScriptLoaded(KanbanClient.loadKanBanPlanners(), 'EPMLive.js');
        });


        var KanbanClient = (function () {

            var selectedKanbanPlanner;
            var selectedKanbanFilter1;
            var kanbanPlanners;
            var kanbanFilter1;

            var reGenerateToolBar = function (btnNewItemText, btnNewItemDataNewFormUrl) {

                $("#kanbanToolbar").html("");

                var newItemButtonCfg = '';
                var kanbanPlannersDropdownCfg = '';
                var kanbanPlannersDropdownOptionsCfg = '';
                var kanbanFilter1MultiselectCfg = '';
                var kanbanFilter1OptionsCfg = '';

                if (btnNewItemText) {
                    // new item button
                    var newItemButtonCfg = '"controlId": "btnNewItem", "controlType": "button", "iconClass": "fui-plus", "value": "' + btnNewItemText + '", "events": [{ "eventName": "click", "function": function () { showNewForm(\'' + btnNewItemDataNewFormUrl + '\'); }  }] ';
                }

                // kanban planners dropdown
                if (kanbanPlanners) {
                    $.each(kanbanPlanners, function (key, value) {
                        kanbanPlannersDropdownOptionsCfg = kanbanPlannersDropdownOptionsCfg + '{ "iconClass": "", "value" : "' + value.id + '" ,"text": "' + value.text + '", "events": [{ "eventName": "click", "function": function () { loadKanBanFilter1(\'' + value.id + '\') } }] },';
                    });
                    if (kanbanPlannersDropdownOptionsCfg.length > 1)
                        kanbanPlannersDropdownOptionsCfg = kanbanPlannersDropdownOptionsCfg.substring(0, kanbanPlannersDropdownOptionsCfg.length - 1);
                    kanbanPlannersDropdownCfg = '"controlId": "ddlKanbanPlanners", "controlType": "dropdown", "title": "Board:", "value": "' + selectedKanbanPlanner + '", "iconClass": "none", "sections": [{ "heading": "none", "divider": "no", "options": [' + kanbanPlannersDropdownOptionsCfg + '] }]';
                }

                // kanban filter1 multiselect
                if (kanbanFilter1) {
                    $.each(kanbanFilter1, function (key, value) {
                        kanbanFilter1OptionsCfg = kanbanFilter1OptionsCfg + '"' + value.id + '": { "value": "' + value.text + '", "checked": true },';
                    });
                    if (kanbanFilter1OptionsCfg.length > 1)
                        kanbanFilter1OptionsCfg = kanbanFilter1OptionsCfg.substring(0, kanbanFilter1OptionsCfg.length - 1);
                    kanbanFilter1MultiselectCfg = '"controlId": "msKanbanFilter1", "controlType": "multiselect", "title": "", "value": "", "iconClass": "icon-insert-template", "sections": [ {"heading": "none", "divider": "no", "options": { ' + kanbanFilter1OptionsCfg + ' }  } ],"applyButtonConfig": { "text": "Apply", "function": function (data) { loadKanBanBoard(data); } }';
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
                    $("#loadingDiv").show();
                    $("#loadingDiv div").html(message);
                }
                else {
                    $("#loadingDiv").hide();
                    $("#loadingDiv div").html('');
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
                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
            };

            var loadKanBanPlanners = function () {
                showHideLoading(true, 'Loading Planners');
                $.ajax({
                    type: "POST",
                    url: "<%=SPContext.Current.Web.ServerRelativeUrl%>/_vti_bin/WorkPlanner.asmx/Execute",
                    data: "{Functionname : 'GetKanBanPlanners' , Dataxml : '<DataXML></DataXML>'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (xhr, status, error) {
                        showHideLoading(false, '');
                        var err = eval("(" + xhr.responseText + ")");
                        alert(err.Message);
                    },
                    success: function (response) {
                        showHideLoading(false, '');
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
                    showHideLoading(true, 'Loading Filters');
                    $.ajax({
                        type: "POST",
                        url: "<%=SPContext.Current.Web.ServerRelativeUrl%>/_vti_bin/WorkPlanner.asmx/Execute",
                        data: "{Functionname : 'GetKanBanFilter1' , Dataxml : '<DataXML><KanBanBoardName>" + selectedKanbanPlanner + "</KanBanBoardName><ProjectID><%=strProjectId%></ProjectID></DataXML>'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        error: function (xhr, status, error) {
                            showHideLoading(false, '');
                            var err = eval("(" + xhr.responseText + ")");
                            alert(err.Message);
                        },
                        success: function (response) {
                            showHideLoading(false, '');
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

                                kanbanFilter1 = obj.kanbanfilter1;

                                reGenerateToolBar('New ' + obj.kanbanitemname, obj.kanbannewitemurl);

                                raiseKanbanFilter1ApplyClick();
                            }
                        }
                    });
                }
            };

            var loadKanBanBoard = function (kanBanFilter1Data) {

                selectedKanbanFilter1 = "";
                for (var i in kanBanFilter1Data['sections']) {
                    var section = kanBanFilter1Data['sections'][i];
                    var options = section['options'];
                    for (var key in options) {
                        if (selectedKanbanFilter1 != "") selectedKanbanFilter1 += ",";
                        selectedKanbanFilter1 += key.toString().replace("\\", "\\\\");;
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
                                window.epmLiveNavigation.addContextualMenu($(this), null, true, '-1');
                            });
                        };

                        $('.sortable-item').hover(function () {
                            $(this).find('.associateditemscontextmenu').show();
                        }, function () {
                            $(this).find('.associateditemscontextmenu').hide();
                            $(this).find('.epm-nav-contextual-menu').hide();
                        });

                        $('#mainContainer .sortable-list').slimScroll({ height: '650px', width: '100%' });

                        ExecuteOrDelayUntilScriptLoaded(addContextualMenu, 'EPMLive.Navigation.js');
                    }
                });
            };


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
                raiseKanbanFilter1ApplyClick: raiseKanbanFilter1ApplyClick
            };

        })();

    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
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

    <div id="loadingDiv" style="display: none">
        <div>Loading</div>
        <img alt="Loading" src="../images/gears_an.gif" />
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    KanBan Planner
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    KanBan Planner
</asp:Content>
