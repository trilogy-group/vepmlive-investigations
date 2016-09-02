<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditCosts.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.EditCostsControl" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:ScriptManagerProxy ID="sm1" runat="server">
    <Services>
    </Services>
</asp:ScriptManagerProxy>

<link rel="stylesheet" type="text/css" href="Styles/DialogNew.css" />

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/skins/dhtmlxlayout_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcontainer.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.css"/>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtoolbar/skins/dhtmlxtoolbar_dhx_web.css" />
<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxtoolbar.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.css" />
<%--<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_epm.css" />--%>
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_admin.css" />
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcontainer.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.js" type="text/javascript"></script>

<script src="/_layouts/epmlive/TreeGrid/GridE.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/EditCosts.ascx.css" />
<script src="/_layouts/ppm/editcosts.ascx.js?ver=<%=FileVersion%>" type="text/javascript"></script>
<script src="/_layouts/ppm/general.js" type="text/javascript"></script>
<script src="/_layouts/ppm/tools/jsfunctions.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ribbon/ribbon2.css" />
<script src="/_layouts/ppm/ribbon/ribbon2.js" type="text/javascript"></script>

<style type="text/css">
    /*IFRAME.dhtmlx_wins_ie6_cover_fix { height: 0px !important; }*/

    .GMColorDefault { background-color:#E7EAF0 !important;}
    .GMClassAdded { font-weight:normal !important; }

    .dhx_tabbar_row { background-color:#eeeeee !important;}
    .modalContent {
        margin-top: 0px !important;
    }
</style>

<!--[if IE 8]>
<style type="text/css">
/* CRL Sep 2012 Edit Costs Performance problem in IE8 if these line commented out */
/* .GMColorHovered { background-color:#F1F5FA; } */
.GMColorHoveredCell { background-color:#F1F5FA; }
.GMColorHoveredCellReadOnly { background-color:#F1F5FA; } /* CRL Sep 2012 Edit Costs Performance problem if this line commented out */
.GMHoverRowBackground { opacity:0.1; filter:alpha(opacity=10); background:#00F; } /* CRL */
.GMHoverRowBorder { z-index:1; border-top:1px solid #BBF; border-bottom:1px solid #BBF; cursor:default; }  /* CRL */
.GMHoverCellBorder { z-index:3; padding:1px; border:1px solid #A0A0F0; background:white; }  /* CRL */
.GMFocusRowBackground { opacity:0.1; filter:alpha(opacity=10); background:#0000; }  /* CRL */
.GMFocusRowBorder { z-index:2; border:0px solid black; }   /* CRL */
.GMFocusCellBorder,.GMEditCellBorder { z-index:4; border:0px solid #6666FF; }  /* CRL */
.GMFocusCellSpaceBorder,.GMEditCellSpaceBorder { z-index:4; }
.GMColorSelected { background-color:#A5E1FF; }
.GMColorFocused { background-color:#A5E1FF; }
.GMColorFocusedCell { background-color:#91CDF2; }
.GMColorFocusedCellSafari { background-color:#A5E1FF; }
.GMColorEditedCell { background-color:#A5E1FF; }
.GMColorViewedCell { background-color:#A5E1FF; }
.GMFocusCellBorder,.GMEditCellBorder { z-index:4; border:0px solid #6666FF !important; background: #CCEBFF !important; }
/*.GMColorDefault { background-color:#E7EAF0; } */
</style>
<![endif]-->

<div id="idEditorTabDiv"></div>

<div class="modalContent" id="idPIAndViewDlgObj" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
        Portfolio Items:<br />
        <select id="idPIList" size="8" style="width:246px;"></select><br />
        Views:<br />
        <select id="idViewList" style="width:246px;"></select>
	    <div style="float:right;">
		    <div class="button-container" >
			    <input type="button" class="epmliveButton" value="OK" onclick="SelectPIDlg_OKOnClick();"/>
		    </div>
	    </div>
    </div>
</div>
<div class="modalContent" id="idCategoriesDlgObj" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
 		<div id="idDivCategoriesMessage" style="display:relative;vertical-align:middle;padding-bottom:3px;"></div>
         <div>
            <div id="idDivCategories"></div>
        </div>
		<div style="width:200px;position:absolute;bottom:5px;right:0px;">
			<div class="button-container">
        			<a onclick="javascript:categoriesDlg_DialogEvent('Add');" class="button-new green" style="width:75px;">Add</a>
        			<a onclick="javascript:categoriesDlg_DialogEvent('Cancel');" class="button-new silver" style="width:75px;">Cancel</a>
			</div>
		</div>
   </div>
</div>
<div class="modalContent" id="idDetailDlgObj" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
        <div>
            <div>Warning:</div>
            <div>Adding detail data here will cause the loss of any current category row values as they will then become calculated from the detail data lines</div>
            <div></div>
            <div>Select the required action:</div>
        </div>
		<div style="width:300px;position:absolute;bottom:5px;right:0px;">
			<div class="button-container-3">
        			<a onclick="javascript:detailDlg_DialogEvent('Copy');" class="button-new silver" style="width:75px;">Copy</a>
        			<a onclick="javascript:detailDlg_DialogEvent('Add');" class="button-new silver" style="width:75px;">Add</a>
        			<a onclick="javascript:detailDlg_DialogEvent('Cancel');" class="button-new silver" style="width:75px;">Cancel</a>
			</div>
		</div>
   </div>
</div>
<div class="modalContent" id="idToolsDlgObj" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
        <div>
            <table>
                <tr>
                <td>Amount&nbsp;:</td>
                <td class="datacol">
                <table>
                <tr>
                <td><input id="idAmount" type="text" value="100" style="width:2.5em; text-align:right;" />%</td>
                </tr>
                </table>
                </td>
                </tr>
                <tr>
                <td valign="top">Action&nbsp;:&nbsp;</td>
                <td class="datacol">
                <table class="picklist">
                <tr><td><input id="idMoveLater" type="radio" name="xaction" checked="checked" class="actionRadio" /><label  for="idMoveLater">Move Later</label></td></tr>
                <tr><td><input id="idMoveEarlier" type="radio" name="xaction" class="actionRadio" /><label for="idMoveEarlier">Move Earlier</label></td></tr>
                <tr><td><input id="idGrow" type="radio" name="xaction" class="actionRadio"  /><label for="idGrow">Grow</label></td></tr>
                <tr><td><input id="idShrink" type="radio" name="xaction" class="actionRadio" /><label for="idShrink">Shrink</label></td></tr>
                </table>
                </td>
                </tr>
                <tr>
                <td valign="top">Apply&nbsp;to&nbsp;:&nbsp;</td>
                <td class="datacol">
                <table class="picklist">
                <tr><td><input id="idAllRows" type="radio" name="applyto" class="actionRadio" checked="checked" /><label for="idAllRows">All Rows</label></td></tr>
                <tr><td><input id="idSelectedRows" type="radio" name="applyto" class="actionRadio" /><label for="idSelectedRows">Selected Rows</label></td></tr>
                </table>
                </td>
                </tr>
                <tr align="left">
                    <td valign="top">Periods&nbsp;:&nbsp;</td>
                    <td class="datacol">
                        <select id="idSelPeriodFrom" name="D1"></select>
                        &nbsp;to&nbsp;
                        <select id="idSelPeriodTo" name="D1"></select>
                    </td>
                </tr>
            </table>
        </div>
	    <div style="float:right;">
		    <div class="button-container" >
			    <input type="button" class="epmliveButton" value="Apply" onclick="javascript: toolsDlg_ApplyOnClick();"/>
        		<input type="button" class="epmliveButton" value="Close" onclick="javascript: toolsDlg_CloseOnClick();"/>
		    </div>
	    </div>
   </div>
</div>
<div id="divLoading" style="z-index:999; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; white-space: nowrap; position: absolute; background-color:transparent;">
    <img style="margin: 30px 10px; vertical-align: middle;width:50px;" title="Loading..." alt="" src="./images/loader-epmlive.GIF" />
</div>
<div id="divSaving" style="z-index:998; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; white-space: nowrap; position: absolute; background-color: transparent;">
    <img style="margin: 30px 10px; vertical-align: middle;width:50px;" title="Saving..." alt="" src="./images/loader-epmlive.GIF"/>
</div>
<div id="<%=ClientID%>mainDiv">
    <div id="veil" style="display:none;"></div>
    <div id="<%=ClientID%>layoutDiv" style="position: relative; width: 100%; height: 650px; top: 0px; left: 0px; display:block"></div>
</div>
<script type="text/javascript">
    function SelectPIDlg_OKOnClick() { editcosts.SelectPIDlg_OKOnClick(); }
    function categoriesDlg_DialogEvent(action) { editcosts.categoriesDlg_DialogEvent(action); }
    function detailDlg_DialogEvent(action) { editcosts.detailDlg_DialogEvent(action); }
    function toolsDlg_ApplyOnClick() { editcosts.toolsDlg_ApplyOnClick(); }
    function toolsDlg_CloseOnClick() { editcosts.toolsDlg_CloseOnClick(); }  
    function ribbonEvent(event) { editcosts.toolbarOnClick(event, ""); }
    var params = {};
    params.ClientID = '<%=ClientID%>';
    params.ProjectID = '<%=ProjectID%>';
    params.WEPID = '<%=WEPID%>';
    params.ViewUID = '<%=ViewUID%>';
    params.URL = '<%=URL%>';
    params.Webservice = '<%=Webservice%>';
    params.IsDlg = "<%=IsDlg%>";
    params.DecimalSeparator = "<%=DecimalSeparator%>";
    params.GroupSeparator = "<%=GroupSeparator%>";
    params.Loadallcostcategories = "<%=Convert.ToString(Loadallcostcategories).ToLower()%>";
    editcosts = new EditCosts('editcosts', params);
</script>
