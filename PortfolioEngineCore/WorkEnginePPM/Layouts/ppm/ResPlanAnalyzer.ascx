<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResPlanAnalyzer.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.ResPlanAnalyzerControl" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
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
<script src="/_layouts/ppm/ribbon/ribbon2.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ResPlanAnalyzer.ascx.css" />
<script src="/_layouts/ppm/ResPlanAnalyzer.ascx.js?ver=<%=FileVersion%>" type="text/javascript"></script>
<script src="/_layouts/ppm/general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="Styles/bootstrap.min.css" />
<script src="/_layouts/ppm/tools/jsfunctions.js" type="text/javascript"></script>

<%--<script src="/_layouts/ppm/Kendo/kendo.dataviz.min.js" type="text/javascript"></script>
--%>
<style type="text/css">
    html, body {
        width: 100%;
        height: 100%;
        margin: 0px;
        overflow: hidden;
    }
    .modalContent {
        margin-top: 0px !important;
    }
</style>


<div id="idAnalyzerTabDiv"></div>    
<div id="idViewTabDiv"></div>
<div id="idBottomTabDiv"></div>
<div id="ribbonbarEditCapScenDiv"></div>
<div id="ribbonbarChartDiv"></div>
<div id="idEditGridDiv" ></div>
<div id="chart" style="overflow:auto"></div>
<div id="divLoading" style="z-index:999; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; white-space: nowrap; position: absolute; background-color:transparent;">
    <img style="margin: 30px 10px; vertical-align: middle" title="Loading..." alt="" src="./images/loader-epmlive.GIF"/>
</div>
<div id="divSaving" style="z-index:998; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; white-space: nowrap; position: absolute; background-color: transparent;">
    <img style="margin: 30px 10px; vertical-align: middle" title="Saving..." alt="" src="./images/loader-epmlive.GIF"/>
</div>
<div id="<%=ClientID%>mainDiv">
	<div id="veil" style="display:none;"></div>
	<div id="<%=ClientID%>layoutDiv" style="position: relative; width: 100%; height: 650px; top: 0px; left: 0px; display:block"></div>
</div>
<div class="modalContent" id="idFCandPerDlgObj" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
			<div style="display:inline;vertical-align:middle;padding-bottom:3px;">
				Choose a Fiscal Calendar:&nbsp;
			</div>
		<div style="display:inline;">
			<select id="idCalList" name="idCalList" onchange="dialogEvent('SelectCalendar_Change');" style="vertical-align:middle;padding:0px;margin:0px;"></select>
		</div>
		<div style="display:none;" >
			<div style="padding-top:10px;padding-bottom:13px;">Choose a period range:</div>
			<div style="padding-bottom:3px;display:inline;">From Period:&nbsp;</div>
				<select id="idPerFromList" name="idPerFromList" style="vertical-align:middle;padding:0px;margin:0px;"></select>
			<div style="padding-bottom:3px;display:inline;">&nbsp;&nbsp;&nbsp;&nbsp;To Period:&nbsp;</div>
				<select id="idPerToList" name="idPerToList" style="vertical-align:middle;padding:0px;margin:0px;"></select>
		</div>
		<div class="button-container">
                <input id="idDisplayPress" type="button" onclick="javascript: dialogEvent('Display_RPA');" class="epmliveButton" value="Display"/>
                <input type="button" onclick="javascript: dialogEvent('Cancel_RPA');" class="epmliveButton" value="Cancel"/>
		</div>
	</div>
</div>
<div class="modalContent" id="idSelectPIDiv" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
 		<div id="idSelPIDiv" style="border:2px solid #ccc; width:300px; height: 150px; overflow-y: scroll; overflow-x:hidden;">
		</div>         
		<div class="button-container">
            	<input id="A1" type="button" onclick="javascript: dialogEvent('Select_PI');" class="epmliveButton" value="Display"/>
            	<input type="button" onclick="javascript: dialogEvent('Dont_Select_PI');" class="epmliveButton" value="Cancel"/>
		</div>
	</div>
</div>
<div class="modalContent" id="idTotalsColsDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
			<div style="display:relative;vertical-align:middle;padding-bottom:13px;">
			1) Do you want to view Totals by Resources or Roles?
		</div>
		<div>
			<input type="radio" id="idTotalsByRole" onclick="dialogEvent('TotalByRole_Click');" style="padding:0px;margin:0px;" />&nbsp;<font style="vertical-align:bottom;padding:0px;margin:0px;">Totals by Role</font>
		</div>
		<div style="padding-bottom:13px;">
			<input id="idTotalsByRes" type="radio" onclick="dialogEvent('TotalByRes_Click');" style="padding:0px;margin:0px;" />&nbsp;<font style="vertical-align:bottom">Totals by Resource</font>
		</div>
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Show
		</div>
		<div style="padding-bottom:20px;">
			<select id="idSelRoleView" name="idSelRoleView" style="vertical-align:middle;padding:0px;margin:0px;" onchange="dialogEvent('SelectRole_Change');">
						<option value='1'>Cost Category Roles</option>
						<option value='2'>Roles Only</option>
					</select>
		</div>
		<div style="display:relative;vertical-align:middle;padding-bottom:13px;">
			2) Select which columns will be displayed
		</div>
		
		<div>
   
			<table cellspacing='0' cellpadding='0' style='width:100%; display: block;'>
				<tr>
					<td style="padding-bottom:3px;">Available Columns</td>
					<td> </td>
					<td style="padding-left:10px;padding-bottom:3px;">Selected Columns</td>
				</tr>
				<tr>
					<td style="width:160px;padding-right:10px;">
						<select style="width:200px;height:140px;padding:0px;margin:0px;border:1px solid #CCCCCC;" size="10" id="idSelTotAvailCols" name="idSelTotAvailCols" onchange="dialogEvent('TotalEnableAdd');" ondblclick="dialogEvent('TotalAddCol_Click');"/> 
					</td>
					 <td width='30px' align='center'>
						<table>
							<tr>
								<td>
									<div class="button-container">
                                        <input type="button" onclick="javascript: dialogEvent('TotalAddCol_Click');" id="idTotButtonAdd" class="epmliveButton" value="Add >"/>
									</div>
								</td>
							</tr>
							
						   <tr>
								<td>
									<div class="button-container">
                                        <input type="button" onclick="javascript: dialogEvent('TotalRemoveCol_Click');" id="idTotButtonRemove" class="epmliveButton" value="< Remove"/>
									</div>
								</td>
							</tr>
						</table>
					</td>
					<td style="width:160px;padding-left:10px;">
						<select style="width:200px;height:140px;padding:0px;margin:0px;border:1px solid #CCCCCC;" size="10" id="idSelSelectedCols" name="idSelSelectedCols" onchange="dialogEvent('TotalEnableRemove');"  ondblclick="dialogEvent('TotalRemoveCol_Click');"/> 
					</td>
					<td width='20px' align='center' style="padding-left:5px;">
						<table>
							<tr>
								 <td id="idSelectedColsMoveUp" class='bb_buttonframe' onclick="dialogEvent('TotalSelectMoveUp');" style='padding-top: 3px; padding-left: 2px;'>
								 <img style='cursor:pointer;' class='bb_buttonimage' src='/_layouts/ppm/images/Arrow Up Lg.gif' alt=''/>
								</td>
							</tr>
							
						   <tr>
								<td id="idSelectedColsMoveDown" class='bb_buttonframe' onclick="dialogEvent('TotalSelectMoveDown');" style='padding-top: 3px; padding-left: 2px;'>
								 <img style='cursor:pointer;' class='bb_buttonimage' src='/_layouts/ppm/images/Arrow Down Lg.gif' alt=''/>
								 </td>
							</tr>
						</table>
					</td>
 
			   </tr>
			</table>
			<br />
			<table cellspacing='0' cellpadding='0' style='width:100%; display: block;'>
			   <tr><td class='bb_buttonframe'><input type="checkbox" id="idEnableHeatMap" onclick="dialogEvent('TotalHeatMap_Click');" style="padding:0px;margin:0px;" />&nbsp;<font style="vertical-align:middle">Enable Heatmap</font></tr>
			   <tr><td><br></td></tr>
			   <tr>
				 <td>If Totals from the top grid are greater than </td>
				 <td style="padding-top:3px;">
				   <select id="idSelHeatmap" name="idSelHeatmap" style="vertical-align:middle;padding:0px;margin:0px 4px 0px 4px;"></select>
				 </td>
				 <td> display </td>
				 <td style="padding-top:3px;">
				   <select id="idSelHeatmapColour" name="idSelHeatmapColour" style="vertical-align:middle;padding:0px;margin:0px 4px 0px 4px;">
						  <option value="1">Red</option>
						  <option value="2">Green</option>
				   </select>
				</td>
			  </tr>
			 </table>
		

	 
   <div style="width:200px;float:right;margin-top:17px;">
	<div class="button-container">
        <input type="button" onclick="javascript: dialogEvent('TotalColOK_Click');" class="epmliveButton" value="OK"/>
        <input type="button" onclick="javascript: dialogEvent('TotalColCancel_Click');" class="epmliveButton" value="Cancel"/>
	</div>
   </div>
 </div>
 </div>
</div>
<div id="idCreateNewCapScen" class="modalContent" style="display:none;">
	<div class="modalText" style="margin-top:5px;padding-right:10px;">
        <div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Capacity Scenario Name:
		</div>
        <div><input id="idTxtCapScenName" type="text" value=" " style="width:210px;text-align:left;padding:0px;margin:0px;height:20px;" /></div>
        <br />
        <div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Department:
		</div>  
        <div>   
		    <select id="idNewCSDept" name="idNewCSDept" style="vertical-align:middle;padding:0px;margin:0px 4px 0px 4px;">
		    </select>
       </div>
      <div id="idRolebased" style="display:block;">
       <div>
       <br />
			<input id="chkRoleBased" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">By Role</font>
	   </div>
      </div>
      <div style="display:none;">
       <div>
			<input id="idNewCSPrivate" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Personal Scenario</font>
	   </div>
      </div>
        <div style="width:200px;float:right">
	        <div class="button-container">
                    <input type="button" onclick="javascript: dialogEvent('SaveCS_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('SaveCS_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idSaveAnalyzerDlg" style="display:none;">
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
					<input type="button" onclick="javascript:dialogEvent('SaveView_OK');" class="epmliveButton" value="OK"/>
					<input type="button" onclick="javascript:dialogEvent('SaveView_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idRenameAnalyzerDlg" style="display:none;">
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
<div class="modalContent" id="idDeleteAnalyzerDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Are you sure you want to delete this view?
		</div>
		<div>
			<input id="id_DeleteView_Name" type="text" value="view 1" style="width:10em; text-align:left;" />
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
					<input type="button" onclick="javascript: dialogEvent('DeleteView_OK');" class="epmliveButton" value="Delete"/>
                    <input type="button" onclick="javascript: dialogEvent('DeleteView_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idCapScenDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
        <table><tr><td>
			<select size="10" id="idSelectCapScen" name="idSelectCapScen" onchange="dialogEvent('CapScenSel');" style="padding:0px;margin-right:20px;width:185px;height:175px;border:1px solid #CCCCCC;"></select>
            </td>
            <td>
               <div class="button-container">
               <table>
                   <tr><td><input type="button" onclick="javascript: dialogEvent('CapScenNew_Click');" id="idCapScenNew" class="epmliveButton" value="New"/></td></tr>
			       <tr><td><input type="button" onclick="javascript: dialogEvent('CapScenCopy_Click');" id="idCapScenCopy" class="epmliveButton" value="Copy"/></td></tr>
			        <tr><td><input type="button" onclick="javascript: dialogEvent('CapScenEdit_Click');" id="idCapScenEdit" class="epmliveButton" value="Edit"/></td></tr>
			        <tr><td><input type="button" onclick="javascript: dialogEvent('CapScenRemove_Click');" id="idCapScenDel" class="epmliveButton" value="Delete"/></td></tr>
		     </table>
                   </div>
             </td></tr></table>
	</div>
	<div style="width:200px;float:right;">
		<div class="button-container">
				<input type="button" onclick="javascript: dialogEvent('CapScenDone_Click');" class="epmliveButton" value="OK"/>
                <input type="button" onclick="javascript: dialogEvent('CapScenDone_Click');" class="epmliveButton" value="Cancel"/>
		</div>
	</div>
</div>
<div class="modalContent" id="idSaveScenDlg" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Scenario Name:
		</div>
		<div>
			<input id="idSaveScenText" type="text" value="" style="width:10em; text-align:left;" />
		</div>
		<br/>
		<div style="display:inline;float:left;">
			<select size="10" id="idSaveScenSel" name="idSaveScenSel" onchange="dialogEvent('SaveScenSel');" style="padding:0px;margin-right:20px;width:185px;height:145px;border:1px solid #CCCCCC;"></select>
		</div>
		<div style="float:right;">
			<div class="button-container">
					<input type="button" onclick="javascript: dialogEvent('SaveScenOK_Click');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('SaveScenCan_Click');" class="epmliveButton" value="Cancel"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idSpreadDlgObj" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div>
			<div>
				<table>
					<tr>
					<td>Amount&nbsp;:</td>
					<td class="datacol">
					<table>
					<tr>
					<td><input id="idSpreadAmount" type="text" value="100" style="width:2.5em; text-align:right;" /><label for="idSpreadAmount" id="idSpreadUnits">Hours</label></td>
					</tr>
					</table>
					</td>
					</tr>
					<tr>
					<td valign="top">Action&nbsp;:&nbsp;</td>
					<td class="datacol">
					<table>
					<tr><td><input id="idSpreadCopy" type="radio" name="xaction" checked="checked" class="actionRadio" /><label  for="idSpreadCopy">Copy</label></td></tr>
					<tr><td><input id="idSpreadSpread" type="radio" name="xaction" class="actionRadio" /><label for="idSpreadSpread">Spread</label></td></tr>
					</table>
					</td>
					</tr>
				</table>
			</div>
			<div>
				<table width="100%">
				<tr>
				<td>Start Period:<br /><select id="idSpreadStartPeriod" name="D1"></select></td>
				<td>Finish Period:<br /><select id="idSpreadFinishPeriod" name="D1"></select></td>
				</tr>
				<tr>
					<td colspan="2"><input type='checkbox' id="idSpreadClearPeriods" /> Clear other Periods</td>
				</tr>
				</table>
			</div>
		</div>
	</div>
	<div style="width:200px;float:right;">
		<div class="button-container">
            <input type="button" onclick="javascript: dialogEvent('spreadDlg_Apply');" class="epmliveButton" value="Apply"/>
            <input type="button" onclick="javascript: dialogEvent('spreadDlg_Close');" class="epmliveButton" value="Close"/>
		</div>
	</div>
</div>
<div class="modalContent" id="idTargetLegendDlgObj" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div id="idTarLegDiv"></div>
		<div style="float:right;padding-right:5px;margin-top:15px;">
			<div>
		        <input type="button" onclick="javascript: dialogEvent('TargetLegend_OKOnClick');" class="epmliveButton" value="OK"/>
			</div>
		</div>
	</div>
</div>
<div id="idEditCapScenDlg" style="display:none;">
   <div id="idEditCS" style="position: relative; width: 100%; height: 350px; top: 0px; left: 0px;"></div>    
</div>
<div id="idChartDlg" style="display:none;">
   <div id="idChart" style="position: relative; width: 100%; height: 350px; top: 0px; left: 0px;"></div>    
</div>
<div id="idGridExplainDlgObj" style="display:none;">
	<div class="modalText" style="margin-top:10px;padding-right:10px;">
		<div style="font-size: 15px;color: blue">
			<u>Columns and Data</u>
		</div>
		<div>
			<br/>
			The Resource Analyzer Grid is very dynamic but is currently configured where the Totals column is a summary of the following values:
			<br/>
			<br/>
		</div>
		<div id="iddivgewrk">
		</div>
		<div id="iddivgeExtraColsSection"> 
			<div>
				<br/>
				In addition to the Totals column, which is always visible as a column in the grid, the following columns have been configured to be displayed:
				<br/>
				<br/>
			</div>
			<div id="iddivgecols">
			</div>
		</div>
		<div>
			<br/>
 Tip:  Column configuration can be accomplished by clicking the “Total Column” button in the lower grid.<br/>
			<br/>
		</div>
	   <div id="iddivgeColourSection"> 
		   <div style="font-size: 15px;color: blue">
				<br/>
				<u>Colors</u>
		   </div>
		   <div id="iddivgecolors">
	 Currently, Totals are being compared to @1.  For each row, if the Totals column values are greater than the @1 column values, @2 is displayed.  
		   </div>
	  </div>
	  <div >
	  <br/>
 Tip:  To change these settings, click the “Total Column” button in the lower grid ribbon.
	   </div>
		<div style="float:right;padding-right:5px;margin-top:15px;">
			<div>
                    <input type="button" onclick="javascript: dialogEvent('GridExplain_OKOnClick');" class="epmliveButton" value="Close"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idOptDlg" style="display:none;"></div>
<div id="gridDiv_1" style="width:100%;height:100%;overflow:auto;"></div>
<div id="gridDiv_Totals" style="width:100%;overflow:auto;"></div>
<div id="toolbarDataObjectDiv">
</div>
<script type="text/javascript">
    function dialogEvent(action) { resplana.externalEvent(action); }
    function deferCallbackAction(deferaction) { resplana.deferExternalEvent(deferaction); }

    var params = {};
    params.ClientID = '<%=ClientID%>';
	params.URL = '<%=URL%>';
    params.TicketVal = '<%=TicketVal%>';
    params.Webservice = '<%=Webservice%>';
    params.RPEMode = '<%=RPEMode%>';
    params.MaxPeriodLimit = '<%=MaxPeriodLimit%>';
    resplana = new ResPlanAnalyzer('resplananalyzer', params);

</script>
