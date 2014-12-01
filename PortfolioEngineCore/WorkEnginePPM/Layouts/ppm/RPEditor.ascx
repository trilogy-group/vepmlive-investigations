<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RPEditor.ascx.cs" Inherits="WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:ScriptManagerProxy ID="sm1" runat="server">
    <Services>
    </Services>
</asp:ScriptManagerProxy>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xlayout/skins/dhtmlxlayout_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxlayout.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xlayout/dhtmlxcontainer.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.css"/>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xtab/dhtmlxtabbar.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_admin.css" />
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcontainer.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xeditor/dhtmlxeditor.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/xeditor/skins/dhtmlxeditor_dhx_skyblue.css" />
<script src="/_layouts/epmlive/dhtml/xeditor/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xeditor/dhtmlxeditor.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/xeditor/ext/dhtmlxeditor_ext.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/RPEditor.ascx.css" />
<script src="/_layouts/epmlive/TreeGrid/GridE.js" type="text/javascript"></script>

<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ribbon/ribbon2.css" />
<script src="/_layouts/ppm/ribbon/ribbon2.js" type="text/javascript"></script>
<script src="/_layouts/ppm/rpeditor.ascx.js?ver=<%=FileVersion%>" type="text/javascript"></script>
<script src="/_layouts/ppm/general.js" type="text/javascript"></script>
<script src="/_layouts/ppm/tools/jsfunctions.js" type="text/javascript"></script>

<div id="idEditorTabDiv"></div>
<div id="idViewTabDiv"></div>
<div id="idResourcesTabDiv"></div>
<div id="idResourcesWorkTabDiv" style="display:none;"></div>
<div id="idNoteTabDiv" style="display:none;"></div>

<div class="modalContent" id="idSelectPIsDlgDiv" style="display:none;">
	<div style="margin-top:20px">
 	    <div id="idPIListDiv" style="border:1px solid #ccc; width:226px; height:100px; overflow-y:scroll; overflow-x:hidden;"></div>         
	    <div style="float:right;">
		    <div class="button-container" >
			    <input type="button" class="epmliveButton" value="OK" onclick="dialogEvent('SelectPIs_OK');"/>
		    </div>
	    </div>
    </div>
</div>
<div class="modalContent" id="idImportWorkDlg" style="display:none;">
	<div style="margin-top:20px;padding-right:5px;">
 	    <div id="idWorkStatusDiv" style="border:1px solid #ccc; width:100%; height:100px; overflow:auto"></div>         
		<div style="padding-bottom:3px;">
            <table cellspacing="0">
                <tr>
                    <td class="descriptioncell">Start Period</td>
                    <td class="controlcell"><select id="idWorkStart" name="WorkP"></select></td>
                </tr>
                <tr>
                    <td class="descriptioncell">Finish Period</td>
                    <td class="controlcell"><select id="idWorkFinish" name="WorkP"></select></td>
                </tr>
            </table>
	    </div>
        <div style="float:right;">
		    <div class="button-container" >
			    <input type="button" class="epmliveButton" value="Apply" onclick="javascript:dialogEvent('ImportWork_Apply');"/>
			    <input type="button" class="epmliveButton" value="Close" onclick="javascript:dialogEvent('ImportWork_Cancel');"/>
		    </div>
	    </div>
    </div>
</div>
<div class="modalContent" id="idNoteButtonsDiv" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
		<div style="width:300px;float:right;">
			<div class="button-container">
			    <input id="idNoteDialog_Save" type="button" class="epmliveButton" value="Save" onclick="javascript: NotesDialogEvent('SaveNewNote');"/>
        		<input id="idNoteDialog_Cancel" type="button" class="epmliveButton" value="Cancel" onclick="javascript: NotesDialogEvent('CancelNote');"/>
        		<input id="idNoteDialog_Close" type="button" class="epmliveButton" value="Close" onclick="javascript: NotesDialogEvent('CloseNote');"/>
			</div>
		</div>
	</div>
</div>

<div class="modalContent" id="idRowNoteDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
		<div id="idRowNoteEditor" style="width: 100%; height: 300px; border: #909090 1px solid;"></div>
		<div style="width:200px;float:right;">
			<div class="button-container">
			    <input id="idRowNoteDialog_Save" type="button" class="epmliveButton" value="Save" onclick="javascript: NotesDialogEvent('SaveRowNote');"/>
        		<input type="button" class="epmliveButton" value="Cancel" onclick="javascript: NotesDialogEvent('CancelRowNote');"/>
			</div>
		</div>
	</div>
</div>

<div class="modalContent" id="idRowNotificationDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
		<div id="idRowNotificationLayout" style="position: relative; top: 0px; left: 0px; width:100%; height: 350px;"></div>
		<div style="width:100px;float:right;">
			<div class="button-container" >
        		<input type="button" class="epmliveButton" value="Close" onclick="javascript:NotesDialogEvent('CloseRowNotificationDialog');"/>
			</div>
		</div>
	</div>
</div>
<div id='idDivRowEventsHtml' style='width:100%;height:100%;overflow:scroll;display:none;'></div>
<div id="gridDiv_Notes" style="width:100%;height:100%;overflow:auto;display:none;"></div>
<div class="modalContent" id="idSaveViewDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
	    <div style="display:none;">
        <input id="id_SaveView_Guid" type="hidden" />
        <input id="id_SaveView_Action" type="hidden" />
        </div>
	    <div>
		    View Name:<br />
		    <input id="id_SaveView_Name" type="text" value="view 1" style="width:10em; text-align:left;margin-bottom:13px;" />
	    </div>
	    <div>
		    <input id="id_SaveView_Default" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Default View</font>
	    </div>
	    <div style="display: none;">
		    <input id="id_SaveView_Personal" type="checkbox" />&nbsp;&nbsp;<font style="vertical-align:middle">Personal View</font>
	    </div>
	    <div style="float:right;">
		    <div class="button-container" >
			    <input type="button" class="epmliveButton" value="OK" onclick="javascript: dialogEvent('SaveView_OK');"/>
        	    <input type="button" class="epmliveButton" value="Cancel" onclick="javascript:dialogEvent('SaveView_Cancel');"/>
		    </div>
	    </div>
    </div>
</div>

<div class="modalContent" id="idDeleteViewDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Are you sure you want to delete this view?
		</div>
		<div>
			<input id="id_DeleteView_Name" type="text" value="view 1" readonly="true" style="width:10em; text-align:left;" />
		</div>
	    <div style="float:right;">
		    <div class="button-container" >
			    <input type="button" class="epmliveButton" value="Delete" onclick="javascript: dialogEvent('DeleteView_OK');"/>
        		<input type="button" class="epmliveButton" value="Cancel" onclick="javascript: dialogEvent('DeleteView_Cancel');"/>
			</div>
		</div>
	</div>
</div>

<div class="modalContent" id="idSelectCostValuesDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Select the cost values to be imported:
		</div>
		<div>
            <select style="width:256px;height:100px;padding:0px;margin:0px;border:1px solid #CCCCCC;" size="10" id="idSelCTCols" name="idSelCTCols" >
            </select>
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container" >
        		<input type="button" class="epmliveButton" value="Import" onclick="javascript: dialogEvent('Costtype_Import');"/>
        		<input type="button" class="epmliveButton" value="Cancel" onclick="javascript: dialogEvent('Costtype_Cancel');"/>
			</div>
		</div>
	</div>
</div>

<div class="modalContent" id="idSpreadDlgObj" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
	    <div>
            <div>
                <table>
                    <tr>
                    <td>Amount&nbsp;:</td>
                    <td class="datacol">
                    <table>
                    <tr>
                    <td><input id="idSpreadAmount" type="text" value="100" style="width:2.5em; text-align:right;" style="margin:0px;padding:0px;" />&nbsp;<label for="idSpreadAmount" id="idSpreadUnits">Hours</label></td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                    <tr>
                    <td valign="top">Action&nbsp;:&nbsp;</td>
                    <td class="datacol">
                    <table>
                    <tr><td><input id="idSpreadCopy" type="radio" name="xaction" checked="checked" class="actionRadio" style="margin:0px;padding:0px;" /><label  for="idSpreadCopy">Copy</label></td></tr>
                    <tr><td><input id="idSpreadSpread" type="radio" name="xaction" class="actionRadio" style="margin:0px;padding:0px;" /><label for="idSpreadSpread">Spread</label></td></tr>
                    </table>
                    </td>
                    </tr>
                </table>
            </div>
            <div>
                <table width="100%" style="margin-top:10px;">
                <tr>
                <td>Start Period:<br /><select id="idSpreadStartPeriod" name="D1" style="margin:3px 0px 0px 0px;padding:0px;"></select></td>
                <td>Finish Period:<br /><select id="idSpreadFinishPeriod" name="D1" style="margin:3px 0px 0px 0px;padding:0px;"></select></td>
                </tr>
                <tr style="margin-top:10px;">
                    <td colspan="2"><input type="checkbox" style="margin:10px 8px 0px 0px;padding:0px;" id="idSpreadClearPeriods"><span style="vertical-align:bottom;">Clear other Periods</span></td>
                </tr>
                </table>
            </div>
        </div>
	    <div style="float:right;">
		    <div class="button-container" >
			    <input type="button" class="epmliveButton" value="Apply" onclick="javascript: dialogEvent('spreadDlg_Apply');"/>
        		<input type="button" class="epmliveButton" value="Close" onclick="javascript: dialogEvent('spreadDlg_Close');"/>
		    </div>
	    </div>
    </div>
</div>
<div class="modalContent" id="idSplitDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
 		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
            <div>Do you want to split the selected plan row or replace the existing resource?</div>
            <div style="padding-top:15px;">Please select the required action:</div>
		</div>
    </div>
	<div class="button-container">
		<input type="button" class="epmliveButton" value="Split" onclick="javascript: dialogEvent('splitDlg_Split');"/>
        <input type="button" class="epmliveButton" value="Replace" onclick="javascript: dialogEvent('splitDlg_Replace');"/>
        <input type="button" class="epmliveButton" value="Cancel" onclick="javascript: dialogEvent('splitDlg_Cancel');"/>
	</div>
</div>
<div class="modalContent" id="idPrivateRowsDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
 		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
            <div>Some plan rows are marked as private.</div>
            <div style="padding-top:15px;">Would you like to make them public?</div>
		</div>
    </div>
	<div class="button-container" style="margin-left:3px;">
		<input type="button" class="epmliveButton" value="Yes" onclick="javascript: dialogEvent('privateRowsDlg_Yes');"/>
        <input type="button" class="epmliveButton" value="No" onclick="javascript: dialogEvent('privateRowsDlg_No');"/>
        <input type="button" class="epmliveButton" value="Cancel" onclick="javascript: dialogEvent('privateRowsDlg_Cancel');"/>
	</div>
</div>
<div class="modalContent" id="idFulfillDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
 		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
            <div>Do you want to fulfill the plan requirement row or replace with the selected resources?</div>
            <div style="padding-top:15px;">Please select the required action:</div>
		</div>
		<div style="width:300px;float:right;">
			<div class="button-container">
			    <input type="button" class="epmliveButton" value="Fulfill" onclick="javascript: dialogEvent('fulfillDlg_Fulfill');"/>
        		<input type="button" class="epmliveButton" value="Replace" onclick="javascript: dialogEvent('fulfillDlg_Replace');"/>
        		<input type="button" class="epmliveButton" value="Cancel" onclick="javascript: dialogEvent('fulfillDlg_Cancel');"/>
			</div>
		</div>
    </div>
</div>
<div class="modalContent" id="idPostDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
			Select required options:
		</div>
		<div>
            <input id="idPostCheck" type="checkbox" />&nbsp;Post
 		</div>
		<div>
           <input id="idPostBaselineCheck" type="checkbox" />&nbsp;Post Baseline
		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
			    <input type="button" class="epmliveButton" value="OK" onclick="javascript: dialogEvent('postDlg_OK');"/>
        		<input type="button" class="epmliveButton" value="Cancel" onclick="javascript: dialogEvent('postDlg_Cancel');"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idInvalidResDeptsDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
 		<div style="display:relative;vertical-align:middle;padding-bottom:3px;">
            The following resources are not in the same department as the plan rows to which they are allocated. The plan rows for these resources should be assigned new resources. Alternatively, the plan rows for resources selected below can be transfered to the resource's current department.
		</div>
		<div>
            <select id="idSelectPlanResources" style="width:100%;" size="10" multiple></select>
 		</div>
		<div style="width:200px;float:right;">
			<div class="button-container">
			    <input type="button" class="epmliveButton" value="Forward" onclick="javascript: dialogEvent('invalidResDeptsDlg_Forward');"/>
        		<input type="button" class="epmliveButton" value="Close" onclick="javascript: dialogEvent('invalidResDeptsDlg_Cancel');"/>
			</div>
		</div>
    </div>
</div>
<div id="gridDiv_RPE" style="width:100%;height:100%;overflow:auto;display:none;"></div>

<div id="gridDiv_Res" style="width:100%;overflow:auto;display:none;"></div>

<div id="gridDiv_ResWork" style="width:100%;overflow:auto;display:none;"></div>
<div id="divLoading" style="z-index:99; display:none; padding-right: 20px; padding-left: 20px; vertical-align: middle; border: 1px solid #ebeef2; white-space: nowrap; position: absolute; background-color: rgb(255, 255, 255);">
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
<script type="text/javascript">
    function addResourcesDlg_DialogEvent(action) { rpeditor.addResourcesDlg_DialogEvent(action); }
    function dialogEvent(action) { rpeditor.externalEvent(action); }
    function NotesDialogEvent(action) { rpeditor.NotesDialogEvent(action); }
    amountCheck('idSpreadAmount');
    var params = {};
    try {
        params.ClientID = '<%=ClientID%>';
        params.WEPID = "<%=WEPID%>";
        params.TicketVal = "<%=TicketVal%>";
        params.IsResource = "<%=IsResource%>";
        params.IsDlg = "<%=IsDlg%>";
        params.URL = '<%=URL%>';
        params.Webservice = '<%=Webservice%>';
        params.HideCloseBtn = '<%=HideCloseBtn%>';
        params.MaxPeriodLimit = '<%=MaxPeriodLimit%>';
        rpeditor = new RPEditor('rpeditor', params);
    }
    catch (e) {
        alert("RPEditor ascx Initialization : " + e.toString());
    }

    function amountCheck(txtID) {
        $("[id='" + txtID + "']").keypress(function (event) {
            var charCode = (event.which) ? event.which : event.keyCode;
            if (event.which == 0)//common keys
                return true;
            var value = $(this).val();
            if (charCode == 46 && value.indexOf('.') != -1)
                return false;
            else if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        });
        $("[id='" + txtID + "']").keyup(function (event) {
            var value = $(this).val();
            if (value < 0 && value.indexOf('.') == -1) {
                $(this).val('');
            }
        });
        $("[id='" + txtID + "']").change(function (event) {
            var value = $(this).val();
            if (value.indexOf('.') == 0) {
                value = '0' + value;
                $(this).val(value);
            }
        });
    }

</script>
