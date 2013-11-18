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
    <script src="javascripts/kanban/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="javascripts/kanban/jquery-ui.js" type="text/javascript"></script>
    <script src="javascripts/kanban/ui.dropdownchecklist-1.4-min.js" type="text/javascript"></script>
    <style type="text/css">
        .itemContainer,
        .stageContainer {
            width: 100%;
            min-height: 625px;
            float: left;
        }

        #section1 {
            width: auto;
            height: 75px;
            margin: 5px;
            border: 1px solid black;
        }

        #section2 {
            margin: 5px;
        }

        #mainContainer {
        }

            #mainContainer table {
                border: 1px solid black;
            }

                #mainContainer table td {
                    text-align: left;
                    vertical-align: top;
                    border-right: 1px dashed black;
                    width: 20%;
                    min-width: 20%;
                    max-width: 20%;
                }

        #loadingDiv {
            width: 100%;
            height: 100%;
            left: 0;
            top: 0;
            position: absolute;
            text-align: center;
            vertical-align: middle;
            background: white;
            padding-top: 300px;
            -moz-opacity: 0.75;
            opacity: 0.75;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha"(Opacity=75);
        }

        /*.itemContainer {
            width: 300px;
            height: 625px;
            float: left;
            overflow: auto;
        }*/

        #splitter {
            float: left;
            color: #0092CA;
            font-size: 12px;
            padding: 5px;
            font-weight: bold;
            cursor: pointer;
        }

        .clear {
            clear: both;
        }

        /*.itemContainerTitle {
            color: black;
            font-size: 12px;
            padding: 5px;
            font-weight: bold;
            border-bottom: 1px solid black;
            text-align: center;
        }



        .itemContainer .sortable-list {
            margin: 0;
            float: left;
            max-width: 1000px;
            height: 20px;
            display: table;
            border-collapse: separate;
            border-spacing: 2px;
        }

        .itemContainer .sortable-item-header {
            background: #D6ECF2;
            border: 1px solid #000;
            cursor: pointer;
            display: block;
            color: black;
            font-size: 12px;
            font-weight: bold;
            margin: 1px;
            padding: 1px;
            text-align: left;
            display: table-row;
        }

        .itemContainer .sortable-item {
            background: #D6ECF2;
            border: 1px solid #000;
            cursor: pointer;
            display: block;
            color: black;
            font-size: 12px;
            margin: 1px;
            padding: 1px;
            text-align: left;
            display: table-row;
        }

        .itemContainer .sortable-item-header div {
            display: table-cell;
            padding: 2px;
        }


        .itemContainer .sortable-item div {
            display: table-cell;
            padding: 2px;
        }*/

        .itemContainerTitle,
        .stageContainerTitle {
            color: black;
            font-size: 12px;
            padding: 5px;
            font-weight: bold;
            border-bottom: 1px solid black;
            text-align: center;
        }

        .itemContainer .sortable-list,
        .stageContainer .sortable-list {
            margin: 0;
            float: left;
            width: 100%;
            min-height: 625px;
        }

        .itemContainer .sortable-item,
        .stageContainer .sortable-item {
            background-color: #D6ECF2; /*0092CA*/
            border-left: 5px solid #009CCC;
            cursor: pointer;
            display: block;
            color: black;
            font-size: 12px;
            margin: 2px;
            padding: 2px;
            text-align: left;
            max-width: 115px;
            min-width: 115px;
            min-height: 48px;
            float: left;
            -webkit-border-radius: 0px 10px 0px 0px;
            -moz-border-radius: 0px 10px 0px 0px;
            border-radius: 0px 10px 0px 0px;
            -webkit-box-shadow: #B3B3B3 2px 2px 2px;
            -moz-box-shadow: #B3B3B3 2px 2px 2px;
            box-shadow: #B3B3B3 2px 2px 2px;
        }

            .itemContainer .sortable-item div:nth-child(2),
            .stageContainer .sortable-item div:nth-child(2) {
                font-weight: bold;
            }

        .placeholder {
            background-color: #e6e6e6; /*0092CA*/
            border-left: 5px solid #009CCC;
            border-top: 1px dashed #000;
            border-right: 1px dashed #000;
            border-bottom: 1px dashed #000;
            cursor: pointer;
            display: block;
            color: black;
            font-size: 12px;
            margin: 2px;
            padding: 2px;
            text-align: left;
            max-width: 115px;
            min-width: 115px;
            min-height: 48px;
            float: left;
            -webkit-border-radius: 0px 10px 0px 0px;
            -moz-border-radius: 0px 10px 0px 0px;
            border-radius: 0px 10px 0px 0px;
            -webkit-box-shadow: #B3B3B3 2px 2px 2px;
            -moz-box-shadow: #B3B3B3 2px 2px 2px;
            box-shadow: #B3B3B3 2px 2px 2px;
        }

        .ui-state-default, .ui-widget-content .ui-state-default, .ui-widget-header .ui-state-default {
            background: none !important;
            color: none !important;
        }

        .associateditemscontextmenu {
            list-style: none;
            cursor: pointer;
            position: absolute;
        }

        /*#saveprogress {
            width: 25px;
            height: 25px;
            display: none;
            float: right;
        }*/
    </style>
    <script type="text/javascript">

        $(function () {

            resetControls(false);

            loadKanBanPlanners();

            $("#ddlKanBanPlanners").change(function () {
                loadKanBanFilter1(this.value);
            });

            //$("#btnApply").click(function () {
            //    var kanBanBoardName = $("#ddlKanBanPlanners").val();
            //    var kanBanFilter1 = "";
            //    $("#ddlKanBanFilter1 option:selected").each(function () {
            //        if (kanBanFilter1 != "") kanBanFilter1 += ",";
            //        kanBanFilter1 += $(this).val().toString().replace("\\", "\\\\");
            //    });
            //    loadKanBanBoard(kanBanBoardName, kanBanFilter1);
            //});

        });


        function showHideLoading(show, message) {
            if (show) {
                $("#loadingDiv").show();
                $("#loadingDiv div").html(message);
            }
            else {
                $("#loadingDiv").hide();
                $("#loadingDiv div").html('');
            }
        }

        function resetControls(reset) {
            if (reset) {
                //$("#btnApply").show();
                $("#lblFilert1").show();
                $("#ddlKanBanFilter1").show();
                //$("#mainContainer").show();
                $("#mainContainer").html('');
            }
            else {
                //$("#btnApply").hide();
                $("#lblFilert1").hide();
                $("#ddlKanBanFilter1").hide();
                //$("#mainContainer").hide();
                $("#mainContainer").html('');
            }
        }

        function loadKanBanPlanners() {
            showHideLoading(true, 'Loading Kanban Planners');
            $.ajax({
                type: "POST",
                url: "/_vti_bin/WorkPlanner.asmx/Execute",
                data: "{Functionname : 'GetKanBanPlanners' , Dataxml : '<DataXML><SiteUrl><%=SPContext.Current.Site.Url%></SiteUrl><SiteID><%=SPContext.Current.Site.ID%></SiteID><WebID><%=SPContext.Current.Web.ID%></WebID></DataXML>'}",
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
                    $("#ddlKanBanPlanners").children('option').remove();
                    $.each(obj.kanbanplanners, function (key, value) {
                        $("#ddlKanBanPlanners").append($("<option></option>").val(value.id).html(value.text));
                    });

                    if ($("#ddlKanBanPlanners option[value='<%=strPlanner%>']").length > 0) {
                        $("#ddlKanBanPlanners").val('<%=strPlanner%>');
                    }
                    else {
                        $("#ddlKanBanPlanners").val($("#ddlKanBanPlanners option:last-child").val());
                    }
                    loadKanBanFilter1($("#ddlKanBanPlanners").val());
                }
            });
        };

        function loadKanBanFilter1(kanBanBoardName) {
            if (kanBanBoardName == "0") {
                resetControls(false);
                $("span[id^='ddcl-']").remove();
                $("div[id^='ddcl-']").remove();
            }
            else {
                resetControls(true);
                showHideLoading(true, 'Loading Kanban Filters');
                $.ajax({
                    type: "POST",
                    url: "/_vti_bin/WorkPlanner.asmx/Execute",
                    data: "{Functionname : 'GetKanBanFilter1' , Dataxml : '<DataXML><SiteUrl><%=SPContext.Current.Site.Url%></SiteUrl><SiteID><%=SPContext.Current.Site.ID%></SiteID><WebID><%=SPContext.Current.Web.ID%></WebID><KanBanBoardName>" + kanBanBoardName + "</KanBanBoardName><ProjectID><%=strProjectId%></ProjectID></DataXML>'}",
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
                            $("#lblFilert1").text(obj.kanbanfilter1name);

                            $("#ddlKanBanFilter1").children('option').remove();
                            $.each(obj.kanbanfilter1, function (key, value) {
                                $("#ddlKanBanFilter1").append($("<option></option>").val(value.id).html(value.text));
                            });

                            $("#ddlKanBanFilter1").dropdownchecklist({
                                width: 200,
                                forceMultiple: true,
                                firstItemChecksAll: true,
                                explicitClose: "...Close",
                                onComplete: function (selector) {
                                    //var kanBanFilter1 = "";
                                    //for (i = 0; i < selector.options.length; i++) {
                                    //    if (selector.options[i].selected && (selector.options[i].value != "")) {
                                    //        if (kanBanFilter1 != "") kanBanFilter1 += ",";
                                    //        kanBanFilter1 += selector.options[i].value.toString().replace("\\", "\\\\");
                                    //    }
                                    //}
                                    //loadKanBanBoard($("#ddlKanBanPlanners").val(), kanBanFilter1);

                                    loadKanBanBoard();
                                }
                            });
                        }
                    }
                });
            }
        };

        //function loadKanBanBoard(kanBanBoardName, kanBanFilter1) {
        function loadKanBanBoard() {

            var kanBanBoardName = $("#ddlKanBanPlanners").val();
            var kanBanFilter1 = "";

            $("#ddlKanBanFilter1 option:selected").each(function () {
                if (kanBanFilter1 != "") kanBanFilter1 += ",";
                kanBanFilter1 += $(this).val().toString().replace("\\", "\\\\");
            });

            if (kanBanFilter1 == "") {
                return;
            }

            showHideLoading(true, 'Loading Kanban Board');
            $.ajax({
                type: "POST",
                url: "/_vti_bin/WorkPlanner.asmx/Execute",
                data: "{Functionname : 'GetKanBanBoard' , Dataxml : '<DataXML><SiteUrl><%=SPContext.Current.Site.Url%></SiteUrl><SiteID><%=SPContext.Current.Site.ID%></SiteID><WebID><%=SPContext.Current.Web.ID%></WebID><KanBanBoardName>" + kanBanBoardName + "</KanBanBoardName><KanBanFilter1>" + kanBanFilter1 + "</KanBanFilter1><ProjectID><%=strProjectId%></ProjectID></DataXML>'}",
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
                                //showHideLoading(true, 'Saving item...');
                                var parentId = ui.item.parent().attr("id");
                                var childId = ui.item.attr("id");
                                var indexOfItem = $("#" + parentId + " > div").index($("#" + childId));

                                //$("#" + childId + " > div[id^='saveprogress']").show();
                                $("#" + childId).fadeTo(10, 0.25);

                                var data = '<DataXml><data-siteid>' + ui.item.attr("data-siteid") + '</data-siteid><data-webid>' + ui.item.attr("data-webid") + '</data-webid><data-listid>' + ui.item.attr("data-listid") + '</data-listid><data-itemid>' + ui.item.attr("data-itemid") + '</data-itemid><data-userid>' + ui.item.attr("data-userid") + '</data-userid><data-itemtitle>' + ui.item.attr("data-itemtitle") + '</data-itemtitle><data-icon>' + ui.item.attr("data-icon") + '</data-icon><data-type>' + ui.item.attr("data-type") + '</data-type><data-fstring>' + ui.item.attr("data-fstring") + '</data-fstring><data-fdate>' + ui.item.attr("data-fdate") + '</data-fdate><data-fint>' + ui.item.attr("data-fint") + '</data-fint><data-dragged-status>' + ui.item.parent().attr("data-dragged-status") + '</data-dragged-status><data-index-of-item>' + indexOfItem + '</data-index-of-item></DataXml>';
                                $.ajax({
                                    type: "POST",
                                    url: "/_vti_bin/WorkPlanner.asmx/Execute",
                                    data: "{Functionname : 'ReOrderAndSaveItem' , Dataxml : '" + data + "'}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    error: function (xhr, status, error) {
                                        //showHideLoading(false, '');
                                        var err = eval("(" + xhr.responseText + ")");
                                        alert(err.Message);
                                    },
                                    success: function (response) {
                                        //$("#btnApply").click();
                                        //showHideLoading(false, '');
                                        //loadKanBanBoard();

                                        //$("#" + childId + " > div[id^='saveprogress']").hide();
                                        $("#" + childId).fadeTo(10, 1);
                                        if ($("#" + parentId).attr("data-dragged-status") == $(".itemContainer div:nth-child(2)").attr("data-dragged-status")) {
                                            $("#" + childId + " > div[id^='key']").html('&nbsp;');
                                        } else {
                                            if ($("#" + parentId).attr("data-dragged-status").length > 15) {
                                                $("#" + childId + " > div[id^='key']").html($("#" + parentId).attr("data-dragged-status").substr(0, 15) + '...');
                                                $("#" + childId + " > div[id^='key']").attr("title", $("#" + parentId).attr("data-dragged-status").substr(0, 15) + '...');
                                            }
                                            else {
                                                $("#" + childId + " > div[id^='key']").html($("#" + parentId).attr("data-dragged-status"));
                                                $("#" + childId + " > div[id^='key']").attr("title", $("#" + parentId).attr("data-dragged-status"));
                                            }
                                        }
                                    }
                                });
                            }
                        }
                    });

                    $(".associateditemscontextmenu").each(function () {
                        window.epmLiveNavigation.addContextualMenu($(this));
                    });
                }
            });
        };

    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div id="section1">
        <div style="float: left; padding: 5px;">
            <table>
                <tr>
                    <td><b>Select Kanban Board :</b></td>
                    <td>
                        <select id="ddlKanBanPlanners">
                        </select>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <b><span id="lblFilert1"></span></b>
                    </td>
                    <td>
                        <select id="ddlKanBanFilter1" multiple="multiple">
                        </select>
                    </td>
                    <td>
                        <%--<input id="btnApply" type="button" value="Apply" />--%>
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
