<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartWizardDataGrid.aspx.cs"
    Inherits="EPMLiveWebParts.Layouts.epmlive.ChartWizardDataGrid" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <%--<link rel="stylesheet" type="text/css" href="stylesheets/libraries/bootstrap/css/bootstrap.min.css" />--%>
    <%--<script src="javascripts/libraries/bootstrap.min.js" type="text/javascript"></script>--%>
    <%--style--%>
    <style>
        .ms-bodyareacell, .s4-ba
        {
            padding-bottom: 0px !important;
        }        
        
    </style>
    <link href="<%=_CSSUrl %>" rel="Stylesheet" type="text/css" />
    <div style="overflow:hidden;width:335px;height:470px;" >
        <div id="dataGrid" >
            <div id="ListsAndViewsGrid" style="display:none;overflow:hidden;">
                 <script type="text/javascript">
                     var loadListsAndViewsGrid = function () {
                         $(function () {
                             var grid = window.TreeGrid('<treegrid Data_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Data_Timeout="0" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Function="GetListsAndViewsGridData" Data_Param_Dataxml="<%= DataXml %>" Layout_Url="<%= WebUrl %>/_vti_bin/WorkEngine.asmx" Layout_Timeout="0" Layout_Method="Soap" Layout_Function="Execute" Layout_Namespace="workengine.com" Layout_Param_Function="GetListAndViewsGridLayout" Layout_Param_Dataxml="<%= LayoutXml %>" SuppressMessage="3" Debug="" ></treegrid>', 'ListsAndViewsGrid');
                         });
                    };
                    ExecuteOrDelayUntilScriptLoaded(loadListsAndViewsGrid, 'EPMLive.js');

                    Grids.OnRenderFinish = function (grid) {
                        $.getScript('/_layouts/epmlive/javascripts/libraries/slimScroll.js', function () {
                            $('#dataGrid').slimScroll({ height: '415px', width: '330px', size: '10px' });
                        }, true);

                        $('#ListsAndViewsGrid').css('display', '');
                        $('#divButtons').css('display', '');
                        $('#divLoading').css('display', 'none');
                        $('.GSText').css('cursor', 'pointer');
                        $('.GSNC').css('cursor', 'default');
                        $('#contentBox').css('margin-left', '0px !important');
                    }

                    Grids.OnClick = function (grid, row, col, x, y, evt) {
                        grid.ActionClearSelection();
                        var status = grid.SelectRow(row, !row.Selected);
                        if (row.Expanded == 1) {
                            grid.Collapse(row);
                        }
                        else {
                            grid.Expand(row);
                        }
                    }

                    function ReturnSelectedView() {
                        var selectedListAndView = "";
                        if (Grids['cwdatagrid'].GetSelRows().length > 0) {
                            selectedListAndView = Grids['cwdatagrid'].GetSelRows()[0]['ParentListTitle'] + ' > ' + Grids['cwdatagrid'].GetSelRows()[0]['Title'];
                        }
                        parent.SP.UI.ModalDialog.commonModalDialogClose(1, selectedListAndView);
                    }

                    function CancelDataSelect() {
                        parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
                    }

                    

                </script>
            </div>
        </div>

        <div id="divLoading" style="width: 100%; text-align: center; margin-top:250px">
            <img src="/_layouts/15/images/gears_anv4.gif" style="vertical-align: middle" />
            <span id="spanMainLoading" class="loadingText">Loading...</span>
        </div>
        <div style="clear: both">
        </div>
        <div id="divButtons" style="text-align: right; padding-right: 10px;margin-top:15px;display:none">
            <input type="button" class="epmliveButton" onclick="ReturnSelectedView(); return false;"
                value="OK" />
            <input type="button" class="epmliveButton" style="margin-left: 5px" onclick="CancelDataSelect(); return false;"
                value="Cancel" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Select Data Source
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
</asp:Content>
