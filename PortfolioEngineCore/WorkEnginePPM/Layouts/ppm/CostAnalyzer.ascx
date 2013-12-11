<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CostAnalyzer.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.CostAnalyzerControl" %>

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
<script src="/_layouts/ppm/tools/jsfunctions.js" type="text/javascript"></script>

<script src="/_layouts/epmlive/TreeGrid/GridE.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ribbon/ribbon2.css" />
<script src="/_layouts/ppm/ribbon/ribbon2.js" type="text/javascript"></script>

<script src="/_layouts/ppm/CostAnalyzer.ascx.js?ver=<%=FileVersion%>" type="text/javascript"></script>
<script src="/_layouts/ppm/general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="Styles/bootstrap.min.css" />


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
<div id="divLoading" style="z-index:998; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; border: 1px solid #ebeef2; white-space: nowrap; position: absolute; background-color: rgb(255, 255, 255);">
    <img style="margin: 30px 10px; vertical-align: middle" title="Loading..." alt="Loading..." src="../images/PROGRESS-CIRCLE-24.GIF"/>
    <span style="text-align: center; margin: 30px 10px; white-space: nowrap; color: black; vertical-align: middle; overflow: hidden; font-family:Verdana; font-size:12px; color:#686868;">Loading...</span>
</div>
<div id="divSaving" style="z-index:998; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; border: 1px solid #ebeef2; white-space: nowrap; position: absolute; background-color: rgb(255, 255, 255);">
    <img style="margin: 30px 10px; vertical-align: middle" title="Saving..." alt="Saving..." src="../images/PROGRESS-CIRCLE-24.GIF"/>
    <span style="text-align: center; margin: 30px 10px; white-space: nowrap; color: black; vertical-align: middle; overflow: hidden; font-family:Verdana; font-size:12px; color:#686868;">Saving...</span>
</div>
<div id="<%=ClientID%>mainDiv">
   <div id="veil" style="display:none;"></div>
   <div id="<%=ClientID%>layoutDiv" style="position: relative; width: 100%; height: 650px; top: 0px; left: 0px; display:block"></div>
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
<div id="idCreateNewCapScen" class="modalContent" style="display:none;">
    <div class="modalText" style="margin-top:5px;padding-right:10px;">
    		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Capacity Scenario Name:
		</div>
		<div><input id="idTxtCapScenName" type="text" value=" " style="width:210px;text-align:left;padding:0px;margin:0px;height:20px;" /></div>
		<div style="width:200px;margin-left:10px;margin-top:3px;">
			<div style="padding-top:10px;">
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
                     <input type="button" onclick="javascript: dialogEvent('SaveView_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('SaveView_Cancel');" class="epmliveButton" value="Cancel"/>
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
                    <input type="button" onclick="javascript: dialogEvent('DeleteView_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('DeleteView_Cancel');" class="epmliveButton" value="Cancel"/>
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
   <div id="ribbonbarEditCapScenDiv"></div>
   <div id="idEditGridDiv" ></div>
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
<div id="idTotalsDlgObj" class="modalContent" style="display:none;">
    <table id="TotalsGridTable" width="100%"  cellspacing="0">
          <tr >
            <td>
                <br/>1) Select the fields to be aggregated and displayed in the bottom grid<br/>
            </td>
        </tr>
        <tr >
            <td>
                <br/>
            </td>
        </tr>   
        <tr >
            <td>
               <input type="checkbox" id="toption1" value="Portfolio Item"> Portfolio Item
            </td>
        </tr>   
        <tr >
            <td>
               <input type="checkbox" id="toption2" value="Cost Types"> Cost Types
            </td>
        </tr>   
        <tr >
            <td>
               <input type="checkbox" id="toption3" value="Cost Categories"> Cost Categories
            </td>
        </tr>   
        <tr >
            <td>
               <input type="checkbox" id="toption4" value="Category"> Category
            </td>
        </tr>   
        <tr >
            <td>
               <input type="checkbox" id="toption5" value="Role"> Role
            </td>
        </tr>   
     </table>
     <br/>
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
                                    <div class="button-containerVert">
                                        <input type="button" onclick="javascript: dialogEvent('TotalAddCol_Click');" class="epmliveButton" value="Add >"/>
				                    </div>
                                </td>
                            </tr>
                            
                           <tr>
                                <td>
				                    <div class="button-containerVert">
                                        <input type="button" onclick="javascript: dialogEvent('TotalRemoveCol_Click');" class="epmliveButton" value="< Remove"/>
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
     </div>
     <div class="button-container">
                    <input type="button" onclick="javascript: dialogEvent('SelectTotals_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('SelectTotals_Cancel');" class="epmliveButton" value="Cancel"/>
     </div>
</div>
<div id="idEditTargetDlgObj" class="modalContent" style="display:none;">
    <br />
    <table id="EditTarTable" width="100%"  cellspacing="0">
         <tr>
             <td  >
                <select id="idSelEditTarget">
                </select>
           </td>
        </tr>
     </table>
     <div class="button-container">
                    <input type="button" onclick="javascript: dialogEvent('SelectEditTarget_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('SelectEditTarget_Cancel');" class="epmliveButton" value="Cancel"/>
     </div>
</div>
<div id="idDeleteTargetDlgObj" class="modalContent" style="display:none;">
<br />
        <table id="DelTarTable" width="100%"  cellspacing="0">
         <tr>
             <td  >
                <select id="idSelDelTarget">
                </select>
           </td>
        </tr>
     </table>
     <div class="button-container">
                    <input type="button" onclick="javascript: dialogEvent('SelectDeleteTarget_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('SelectDeleteTarget_Cancel');" class="epmliveButton" value="Cancel"/>
     </div>
</div>
<div id="idCopyTargetDlgObj" class="modalContent" style="display:none;">
 <br />
       <table id="CopyTarTable" width="100%"  cellspacing="0">
         <tr>
             <td  >
                <select id="idSelCopyTarget">
                </select>
           </td>
        </tr>
     </table>
     <div class="button-container">
                    <input type="button" onclick="javascript: dialogEvent('SelectCopyTarget_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: dialogEvent('SelectCopyTarget_Cancel');" class="epmliveButton" value="Cancel"/>
     </div>
</div>
<div id="idEditTargetDlg" class="modalContent" style="display:none;">
   <div id="ribbonbarEdiTarDiv"></div>
   <div id="idEditTargetGridDiv"></div>
</div>
<div id="idSaveTargetDlg" class="modalContent" style="display:none;">
    <div class="modalText" style="margin-top:5px;padding-right:10px;">
    		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Cost Target Name:
		</div>
		<div><input id="txtCostTargetName" type="text" value=" " style="width:210px;text-align:left;padding:0px;margin:0px;height:20px;" /></div>
		<div style="width:200px;margin-left:10px;margin-top:3px;">
			<div style="padding-top:10px;">
                    <input type="button" onclick="javascript: editTargetEvent('etSaveAs_OK');" class="epmliveButton" value="OK"/>
                    <input type="button" onclick="javascript: editTargetEvent('etSaveAs_Cancel');" class="epmliveButton" value="Cancel"/>
			</div>
   		</div>
    </div>
</div>
<div id="gridDiv_1" style="width:100%;height:100%;overflow:auto;"></div>
<div id="gridDiv_Totals" style="width:100%;overflow:auto;"></div>
<div id="toolbarDataObjectDiv"></div>

<script type="text/javascript">
    function dialogEvent(action) { costtypeanalyzer.externalEvent(action); }
    function editTargetEvent(action) { costtypeanalyzer.edittTargetEvent(action); }
    function deferCallbackAction(deferaction) { costtypeanalyzer.deferExternalEvent(deferaction); }
    
    var params = {};
    params.ClientID = '<%=ClientID%>';
    params.URL = '<%=URL%>';
    params.TicketVal = '<%=TicketVal%>';
    params.Webservice = '<%=Webservice%>';
    params.ViewID = '<%=ViewIDVal%>';
    costtypeanalyzer = new CostAnalyzer('costanalyzer', params);

</script>
