<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.1.220.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartWizard.aspx.cs" Inherits="EPMLiveWebParts.Layouts.epmlive.ChartWizard"
    DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <%--external css and scripts--%>
    <link rel="stylesheet" type="text/css" href="stylesheets/libraries/bootstrap/css/bootstrap.min.css" />
    <script type="text/javascript" src="javascripts/libraries/bootstrap.min.js"></script>
    <script type="text/javascript">
        var gridurl = '<%=_GridUrl%>';
        var tbSelectedListAndViewClientId = '<%=tbSelectedListAndView.ClientID%>';
    </script>
    <script type="text/javascript" src="/_layouts/epmlive/javascripts/ChartWizard.js"></script>
    <link href="/_layouts/epmlive/styles/ChartWizard/ChartWizardStyle.css" rel="Stylesheet"
        type="text/css" />
    <%--Pages that contains the three steps--%>
    <asp:UpdatePanel runat="server" ID="upMain">
        <ContentTemplate>
            <div id="MainContainer">
                <%--1st step--%>
                <div id="pgStep1" class="StepContainer">
                    <%--content--%>
                    <div class="wizardLabel">
                        Select a Data Source
                    </div>
                    <div>
                        <div style="vertical-align: middle">
                            <asp:TextBox ID="tbSelectedListAndView" runat="server" Width="365px" CssClass="floatLeft"></asp:TextBox>
                            <input id="Button1" type="button" class="epmliveButton" style="margin-left: 5px;float:right;height:30px"
                                onclick="OpenDataSourceGrid();return false;" value="..." />
                            <%-- <a class="epmliveButton" style="width: 100px; height: 50px; margin-left: 0px;" onclick="OpenDataSourceGrid();return false;">
                                <span>...</span>
                            </a>--%>
                        </div>
                        <asp:TextBox ID="tbListTitle" runat="server" Style="display: none" />
                        <asp:TextBox ID="tbViewTitle" runat="server" Style="display: none" />
                    </div>
                </div>
                <%--2nd step--%>
                <div id="pgStep2" class="StepContainer" style="display: none; width: 800px; overflow: hidden;">
                    <%--content--%>
                    <div class="wizardLabel">
                        Configure Chart
                    </div>
                    <div>
                        <div id="step2LeftCol">
                            <div class="chartThumbWrapper">
                                <table cellpadding="0" cellspacing="0" style="width: 100%" id="thumbTable">
                                    <tr class="thumbRow" graphtype="Area">
                                        <td class="thumbLabel">
                                            Area
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/Area.png" class="imagedropshadow"
                                                style="height: 40px;" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Area_Clustered">
                                        <td class="thumbLabel">
                                            Area Clustered
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/AreaClustered.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Bar">
                                        <td class="thumbLabel">
                                            Bar
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/Bar.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Bar_Clustered">
                                        <td class="thumbLabel">
                                            Bar Clustered
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/BarClustered.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Bar_Stacked">
                                        <td class="thumbLabel">
                                            Bar Stacked
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/BarStacked.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Bar_100Percent">
                                        <td class="thumbLabel">
                                            Bar Stacked 100%
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/Bar100.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Bubble">
                                        <td class="thumbLabel">
                                            Bubble
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/Bubble.png" class="imagedropshadow"
                                                style="height: 40px;" />
                                        </td>
                                    </tr>
                                    <tr id="trColumn" class="thumbRow" graphtype="Column">
                                        <td class="thumbLabel">
                                            Column
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/Column.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Column_Clustered">
                                        <td class="thumbLabel">
                                            Column Clustered
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/ColumnClustered.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Column_Stacked">
                                        <td class="thumbLabel">
                                            Column Stacked
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/ColumnStacked.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Column_100Percent">
                                        <td class="thumbLabel">
                                            Column Stacked 100%
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/Column100.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Donut">
                                        <td class="thumbLabel">
                                            Donut
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/donut.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Line">
                                        <td class="thumbLabel">
                                            Line
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/line.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Line_Clustered">
                                        <td class="thumbLabel">
                                            Line Clustered
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/lineclustered.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                    <tr class="thumbRow" graphtype="Pie">
                                        <td class="thumbLabel">
                                            Pie
                                        </td>
                                        <td class="thumbImg">
                                            <img src="http://dl.dropbox.com/u/47201778/ChartIcons/pie.png" style="height: 40px;"
                                                class="imagedropshadow" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:TextBox ID="tbChartType" runat="server" Style="display: none" ReadOnly="true" />
                        </div>
                        <div id="step2MidCol">
                            <%--image --%>
                            <div style="width: 360px; text-align: right;">
                                <div class="rotate" id="dynamicY">
                                    Y Values</div>
                                <img src="http://dl.dropbox.com/u/47201778/ChartIcons/AreaClustered.png" id="chartImage" />
                            </div>
                        </div>
                        <div id="step2RightCol">
                            <%--aggregate column--%>
                            <asp:Panel runat="server" ID="pnlAggDdl" class="topDdl">
                                <span style="padding-left: 0px;">Aggregation Type</span>
                                <telerik:RadComboBox ID="rcbAgg" runat="server" MaxHeight="180" Width="170" Skin="Metro" />
                            </asp:Panel>
                            <%--x column--%>
                            <asp:Panel runat="server" ID="pnlXDdl" class="topDdl">
                                <span style="padding-left: 0px;">X Value (Category)</span>
                                <telerik:RadComboBox ID="rcbXField" runat="server" MaxHeight="180" Width="170" Skin="Metro" />
                            </asp:Panel>
                            <%--y columns--%>
                            <asp:Panel runat="server" ID="pnlYDdl" class="topDdl" Style="height: 100px; width: 170px">
                                <span id="spnYVal" style="padding-left: 0px;">Y Value (Series)</span>
                                <telerik:RadComboBox ID="rcbYNumSingle" runat="server" MaxHeight="180" Width="170" Skin="Metro" />
                                <%--Checkbox DDL--%>
                                <telerik:RadComboBox ID="rcbYNumMulti" runat="server" MaxHeight="180" Width="170" CheckBoxes="true"
                                    DropDownAutoWidth="Enabled" Skin="Metro" />
                                <telerik:RadComboBox ID="rcbYNonNumSingle" runat="server" MaxHeight="180" Width="170"
                                    Skin="Metro" />
                                <%--Checkbox DDL--%>
                                <telerik:RadComboBox ID="rcbYNonNumMulti" runat="server" MaxHeight="180" Width="170"
                                    CheckBoxes="true" DropDownAutoWidth="Enabled" Skin="Metro" />
                                <span style="padding-left: 0px;">Y Value Format</span>
                                <telerik:RadComboBox ID="rcbYAxisFormat" runat="server" MaxHeight="180" Width="170"
                                    Skin="Metro" />
                            </asp:Panel>
                            <%--z column--%>
                            <asp:Panel runat="server" ID="pnlZDdl" class="topDdl" Style="height: 100px; width: 170px;">
                                <span style="padding-left: 0px;">Z Value (Size Value)</span>
                                <telerik:RadComboBox ID="rcbZField" runat="server" MaxHeight="180" Width="170" Skin="Metro" />
                                <span style="padding-left: 0px;">Group By</span>
                                <telerik:RadComboBox ID="rcbGroupBy" runat="server" MaxHeight="180" Width="170" Skin="Metro" />
                            </asp:Panel>
                        </div>
                    </div>
                </div>
                <%--3rd step--%>
                <div id="pgStep3" class="StepContainer" style="display: none;">
                    <div class="wizardLabel">
                        Additional Properties
                    </div>
                    <div>
                        <table style="text-align: left">
                            <%--chart title--%>
                            <tr>
                                <td style="width: 120px">
                                    <asp:Label ID="Label5" runat="server" Text="Chart Title"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tbChartTitle" runat="server" Width="230px"></asp:TextBox>
                                </td>
                            </tr>
                            <%--palette--%>
                            <tr>
                                <td style="width: 120px">
                                    <asp:Label ID="Label1" runat="server" Text="Palette"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPalette" runat="server" Width="245px">
                                        <asp:ListItem Text="Color 1" Value="Color1" />
                                        <asp:ListItem Text="Color 2" Value="Color2" />
                                        <asp:ListItem Text="Blue" Value="Blue" />
                                        <asp:ListItem Text="Red" Value="Red" />
                                        <asp:ListItem Text="Yellow" Value="Yellow" />
                                        <asp:ListItem Text="Green" Value="Green" />
                                        <asp:ListItem Text="Gray" Value="Gray" />
                                        <asp:ListItem Text="Violet" Value="Violet" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <%--Legend Position--%>
                            <tr>
                                <td style="width: 120px">
                                    <asp:Label ID="Label6" runat="server" Text="Legend Position"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLegendPosition" runat="server" Width="245px">
                                        <asp:ListItem Text="Left" Value="Left" />
                                        <asp:ListItem Text="Top" Value="Top" />
                                        <asp:ListItem Text="Right" Value="Right" />     
                                        <asp:ListItem Text="Bottom" Value="Bottom" />                                               
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear: both">
                    </div>
                    <%--show grid lines--%>
                    <div>
                        <asp:CheckBox ID="cbShowGridLines" runat="server" />
                        <asp:Label ID="Label2" runat="server" Text="Show Grid Lines"></asp:Label>
                    </div>
                    <div style="clear: both">
                    </div>
                    <%--show x axis labels--%>
                    <div>
                        <asp:CheckBox ID="cbShowXAxisLabels" runat="server" />
                        <asp:Label ID="Label3" runat="server" Text="Show X Axis Labels"></asp:Label>
                    </div>
                    <div style="clear: both">
                    </div>
                    <%--show legend--%>
                    <div>
                        <asp:CheckBox ID="cbShowLegend" runat="server" />
                        <asp:Label ID="Label4" runat="server" Text="Show Legend"></asp:Label>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                <%--loading div--%>
                <div id="divLoading" style="width: 100%; text-align: center; display: none">
                    <img src="/_layouts/images/gears_anv4.gif" style="vertical-align: middle" />
                    <span id="spanMainLoading" class="loadingText">Updating chart properties...</span>
                </div>
                <%--divider--%>
                <div style="clear: both">
                </div>
                <%--pagination control section--%>
                <div id="divButtons" style="text-align: right;margin-top:15px; padding-right:10px;">
                    <input id="btnBack" type="button" class="epmliveButtonDisabled" style="margin-left: 0px;"
                        onclick="Back();return false;" value="&larr; Back" />
                    <%-- <a href="#" id="btnBack" class="epmliveButton" style="width: 100px; height: 50px; margin-left: 0px; display:none;" onclick="Previous();return false;">
                        &larr; <span>Back</span> </a>--%>
                    <input id="btnNext" type="button" class="epmliveButtonDisabled" style="margin-left: 5px;"
                        onclick="Next();return false;" value="Next &rarr;" />
                    <%-- <a href="#" id="btnNext" class="epmliveButton" style="width: 100px; height: 50px; margin-right: 0px;" onclick="Next();return false;">
                        <span>Next</span> &rarr;</a>--%>
                    <input id="btnSave" type="button" class="epmliveButtonDisabled" style="margin-left: 5px; display:none"
                        onclick="SaveChartProps();return false;" value="Save" />
                    <%-- <a href="#" id="btnSave" class="epmliveButton" style="width: 100px; height: 50px; display: none;" onclick="SaveChartProps();return false;">
                                <span>Save</span></a> --%>
                    <input id="btnCancel" type="button" class="epmliveButton" style="margin-left: 5px;"
                        onclick="CancelWizard();return false;" value="Cancel" />
                    <%--<a href="#" id="btnCancel" class="epmliveButton" style="width: 100px; height: 50px" onclick="CancelWizard();return false;">
                            <span>Cancel</span> </a>--%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
    Chart Wizard
</asp:Content>
<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea"
    runat="server">
</asp:Content>
