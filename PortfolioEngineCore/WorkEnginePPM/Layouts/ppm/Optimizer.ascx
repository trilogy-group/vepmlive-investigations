<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Optimizer.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.OptimizerControl" %>

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

<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtoolbar/dhtmlxtoolbar.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.css" />
<%--<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_epm.css" />--%>
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_admin.css" />

<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcontainer.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.js" type="text/javascript"></script>


<script src="/_layouts/epmlive/TreeGrid/GridE.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ribbon/ribbon2.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/ppm/styles/jqueryui.css" />

<script src="/_layouts/ppm/tools/jsfunctions.js" type="text/javascript"></script>
<script src="/_layouts/ppm/general.js" type="text/javascript"></script>
<script src="/_layouts/ppm/ribbon/ribbon2.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/Optimizer.ascx.css" />
<script src="/_layouts/ppm/Optimizer.ascx.js?ver=<%=FileVersion%>" type="text/javascript"></script>
<script src="/_layouts/ppm/Optimizer.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="Styles/bootstrap.min.css" />
<div id="idViewTabDiv"></div>
<div id="idOptimizerTabDiv"></div>
<div id="<%=ClientID%>mainDiv">
	<div id="veil" style="display:none;"></div>
	<div id="<%=ClientID%>layoutDiv" style="position: relative; width: 100%; height: 650px; top: 0px; left: 0px; display:block"></div>
</div>
<div class="modalContent" id="idSaveViewDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			View Name:
		</div>
		<div>
			<input id="id_SaveView_Name" type="text" value="view 1" style="width:10em; text-align:left;margin-bottom:13px;" />
		</div>
		<div>
			<input id="id_SaveView_Default" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Default View</font>
		</div>
		<div>
			<input id="id_SaveView_Personal" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Personal View</font>
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
                    <input type="button" onclick="javascript: dialogEvent('SaveView_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('SaveView_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idRenameViewDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			View Name:
		</div>
		<div>
			<input id="id_RenameView_Name" type="text" value="view 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
                                    <input type="button" onclick="javascript: dialogEvent('RenameView_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('RenameView_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idDeleteViewDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Are you sure you want to delete this view?
		</div>
		<div>
			<input id="id_DeleteView_Name" type="text" value="view 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
                                    <input type="button" onclick="javascript: dialogEvent('DeleteView_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('DeleteView_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idSaveStrat" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Strategy Name:
		</div>
		<div>
			<input id="idSaveStratName" type="text" value="Strategy 1" style="width:10em; text-align:left;margin-bottom:13px;" />
		</div>
		<div  style="display:none;">
			<input id="idStratDefault" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Default Strategy</font>
		</div>
		<div>
			<input id="idStratPer" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Personal Strategy</font>
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
                                    <input type="button" onclick="javascript: OptimizerEvent('SaveStratagy_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: OptimizerEvent('SaveStratagy_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idRenameStratDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Strategy Name:
		</div>
		<div>
			<input id="idRenameStrat" type="text" value="Strategy 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
                                    <input type="button" onclick="javascript: OptimizerEvent('RenameStratagy_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: OptimizerEvent('RenameStratagy_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idEditRangeDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div>
			<input id="idFromRange" type="text"  onkeyup='extractNumber(this,2,true, null);' onkeypress='return blockNonNumbers(this, event, true, true);' value="" style="width:10em; text-align:left;" /> : <input id="idToRange" type="text"  onkeyup='extractNumber(this,2,true, null);' onkeypress='return blockNonNumbers(this, event, true, true);' value="" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
                                    <input type="button" onclick="javascript: OptimizerEvent('EditRange_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: OptimizerEvent('EditRange_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idDeleteStratagy" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Are you sure you want to delete this Strategy?
		</div>
		<div>
			<input id="idDelStrat" type="text" value="view 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
                                    <input type="button" onclick="javascript: OptimizerEvent('DeleteStratagy_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: OptimizerEvent('DeleteStratagy_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idOptDlg" style="display:none;"></div>
<div id="gridDiv_1" style="width:100%;height:100%;overflow:auto;"></div>
<div id="gridDiv_Totals" style="width:100%;overflow:auto;"></div>
<div id="toolbarDataObjectDiv">
</div>
<div id="divLoading" style="z-index:999; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; white-space: nowrap; position: absolute; background-color:transparent;">
    <img style="margin: 30px 10px; vertical-align: middle;width:50px;" title="Loading..." alt="" src="./images/loader-epmlive.GIF" />
</div>
<div id="divSaving" style="z-index:998; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; white-space: nowrap; position: absolute; background-color: transparent;">
    <img style="margin: 30px 10px; vertical-align: middle;width:50px;" title="Saving..." alt="" src="./images/loader-epmlive.GIF"/>
</div>
<script type="text/javascript">
    function dialogEvent(action) { optimizerco.externalEvent(action); }
    function deferCallbackAction(deferaction) { optimizerco.deferExternalEvent(deferaction); }
    function OptimizerEvent(action) { optimizerco.OptimizerEvent(action); }
	
	var params = {};
	params.ClientID = '<%=ClientID%>';
	params.URL = '<%=URL%>';
	params.TicketVal = '<%=TicketVal%>';
	params.ListIdVal = '<%=ListIdVal%>';
	params.ViewID = '<%=ViewIDVal%>';
	params.Webservice = '<%=Webservice%>';
	optimizerco = new Optimizer('optimizerwp', params);

</script>
