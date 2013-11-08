﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KanBanPlanner.aspx.cs" Inherits="EPMLiveWorkPlanner.KanBanPlanner" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script src="javascripts/kanban/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="javascripts/kanban/jquery-ui.js.js" type="text/javascript"></script>
    <style type="text/css">
        #section1 {
            width: auto;
            height: 75px;
            margin: 5px;
            border: 1px solid black;
        }

        #section2 {
            width: auto;
            height: 625px;
            margin: 5px;
            border: 1px solid black;
            overflow: auto;
        }

        #mainContainer {
            width: 2500px;
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
            -moz-opacity: 0.25;
            opacity: 0.25;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha"(Opacity=25);
        }

        .itemContainer {
            width: 300px;
            height: 600px;
            float: left;
            overflow: auto;
        }

        .stageContainer {
            width: 250px;
            height: 625px;
            float: left;
            border-left: 1px dashed black;
        }

        #splitter {
            float: left;
            color: #0092CA;
            font-size: 12px;
            padding: 5px;
            font-weight: bold;
            border-bottom: 1px solid black;
            cursor: pointer;
        }

        .clear {
            clear: both;
        }

        .itemContainerTitle {
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
        }

            .itemContainer .sortable-item div span {
                display: none;
            }

        .stageContainerTitle {
            color: black;
            font-size: 12px;
            padding: 5px;
            font-weight: bold;
            border-bottom: 1px solid black;
            text-align: center;
        }

        .stageContainer .sortable-list {
            margin: 0;
            float: left;
            width: 100%;
            min-height: 625px;
        }

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
            /*width: 98px;
            height: 48px;*/
            float: left;
            -webkit-border-radius: 0px 10px 0px 0px;
            -moz-border-radius: 0px 10px 0px 0px;
            border-radius: 0px 10px 0px 0px;
            -webkit-box-shadow: #B3B3B3 2px 2px 2px;
            -moz-box-shadow: #B3B3B3 2px 2px 2px;
            box-shadow: #B3B3B3 2px 2px 2px;
        }

            .stageContainer .sortable-item div span {
                display: block;
                font-weight: bold;
                float: left;
            }

        .placeholder {
            /*background-color: #BFB;
            border: 1px dashed #666;
            height: 50px;
            width: 50px;
            margin: 5px;
            padding: 5px;*/
            float: left;
        }
    </style>
    <script type="text/javascript">

        $(function () {

            resetControls(false);

            loadKanBanPlanners();

            $("#ddlKanBanPlanners").change(function () {
                loadKanBanFilter1(this.value);
            });

            $("#btnApply").click(function () {
                loadKanBanBoard($("#ddlKanBanPlanners").val(), $("#ddlKanBanFilter1").val());
            });

        });


        function showHideLoading(show) {
            if (show) {
                $("#loadingDiv").show();
            }
            else {
                $("#loadingDiv").hide();
            }
        }

        function resetControls(reset) {
            if (reset) {
                $("#btnApply").show();
                $("#lblFilert1").show();
                $("#ddlKanBanFilter1").show();
                $("#mainContainer").show();
                $("#mainContainer").html('');
            }
            else {
                $("#btnApply").hide();
                $("#lblFilert1").hide();
                $("#ddlKanBanFilter1").hide();
                $("#mainContainer").hide();
                $("#mainContainer").html('');
            }
        }

        function loadKanBanPlanners() {
            showHideLoading(true);
            $.ajax({
                type: "POST",
                url: "/_vti_bin/WorkPlanner.asmx/Execute",
                data: "{Functionname : 'GetKanBanPlanners' , Dataxml : '<DataXML><SiteUrl><%=SPContext.Current.Site.Url%></SiteUrl><SiteID><%=SPContext.Current.Site.ID%></SiteID><WebID><%=SPContext.Current.Web.ID%></WebID></DataXML>'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                error: function (xhr, status, error) {
                    showHideLoading(false);
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                },
                success: function (response) {
                    showHideLoading(false);
                    var obj = jQuery.parseJSON(response.d);
                    $("#ddlKanBanPlanners").children('option').remove();
                    $.each(obj.kanbanplanners, function (key, value) {
                        $("#ddlKanBanPlanners").append($("<option></option>").val(value.id).html(value.text));
                    });
                    loadKanBanFilter1($("#ddlKanBanPlanners").val());
                }
            });
        };

        function loadKanBanFilter1(kanBanBoardName) {
            if (kanBanBoardName == "0") {
                resetControls(false);
            }
            else {
                resetControls(true);
                showHideLoading(true);
                $.ajax({
                    type: "POST",
                    url: "/_vti_bin/WorkPlanner.asmx/Execute",
                    data: "{Functionname : 'GetKanBanFilter1' , Dataxml : '<DataXML><SiteUrl><%=SPContext.Current.Site.Url%></SiteUrl><SiteID><%=SPContext.Current.Site.ID%></SiteID><WebID><%=SPContext.Current.Web.ID%></WebID><KanBanBoardName>" + kanBanBoardName + "</KanBanBoardName></DataXML>'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    error: function (xhr, status, error) {
                        showHideLoading(false);
                        var err = eval("(" + xhr.responseText + ")");
                        alert(err.Message);
                    },
                    success: function (response) {
                        showHideLoading(false);
                        var obj = jQuery.parseJSON(response.d);

                        $("#lblFilert1").text(obj.kanbanfilter1name);

                        $("#ddlKanBanFilter1").children('option').remove();
                        $.each(obj.kanbanfilter1, function (key, value) {
                            $("#ddlKanBanFilter1").append($("<option></option>").val(value.id).html(value.text));
                        });
                    }
                });
            }
        };

        function loadKanBanBoard(kanBanBoardName, kanBanFilter1) {
            showHideLoading(true);
            $.ajax({
                type: "POST",
                url: "/_vti_bin/WorkPlanner.asmx/Execute",
                data: "{Functionname : 'GetKanBanBoard' , Dataxml : '<DataXML><SiteUrl><%=SPContext.Current.Site.Url%></SiteUrl><SiteID><%=SPContext.Current.Site.ID%></SiteID><WebID><%=SPContext.Current.Web.ID%></WebID><KanBanBoardName>" + kanBanBoardName + "</KanBanBoardName><KanBanFilter1>" + kanBanFilter1 + "</KanBanFilter1></DataXML>'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                error: function (xhr, status, error) {
                    showHideLoading(false);
                    var err = eval("(" + xhr.responseText + ")");
                    alert(err.Message);
                },
                success: function (response) {
                    showHideLoading(false);
                    $("#mainContainer").html('');
                    $("#mainContainer").html(response.d);

                    $("#splitter").click(function () {
                        if ($(".itemContainer").is(":visible")) {
                            $("#splitter").html(">>");
                        } else {
                            $("#splitter").html("<<");
                        }
                        $(".itemContainer").toggle("fast", function () {

                        });
                    });

                    $("#mainContainer .sortable-list").sortable({
                        connectWith: '#mainContainer .sortable-list',
                        placeholder: 'placeholder',
                        items: '.sortable-item',
                        update: function (event, ui) {
                            //alert("make ajax call to save [" + ui.item.attr("id") + "]  in [" + ui.item.parent().attr("id") + "]");
                        }
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
                        <select id="ddlKanBanFilter1">
                        </select>
                    </td>
                    <td>
                        <input id="btnApply" type="button" value="Apply" />
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
        <img alt="Loading" src="../images/gears_an.gif" />
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    KanBan Planner
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server">
    KanBan Planner
</asp:Content>
