<%@ Assembly Name="EPMLiveWebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5"%><%@ Page Language="C#" Inherits="EPMLiveWebParts.ribbonjs"  ContentType="application/x-javascript"%><%@ OutputCache Location="None" VaryByParam="None" %>

Type.registerNamespace('ContextualTabWebPart');

function viewProps(lid, vid, vps){
this.listId = lid;
this.viewId = vid;
this.viewParameters = vps;
}

var _webPartPageComponentId;

ContextualTabWebPart.CustomPageComponent = function ContextualTabWebPart_CustomPageComponent(webPartPcId, grid, dproc, wurl, rurl) {
    this._webPartPageComponentId = webPartPcId;
    this.$Grid = grid;
    this.$DataProc = dproc;
    this.$curWebUrl = wurl;
    this.$curUrl = rurl;
    ContextualTabWebPart.CustomPageComponent.initializeBase(this);
}

ContextualTabWebPart.CustomPageComponent.prototype = {

    $Grid: null,
    $22_3: false,
    $1Q_3: null,
    $3X_3: null,
    $27_3: 0,
    $1O_3: null,
    $11_3: null,
    $1N_3: false,
    $curWebUrl: null,
    $curUrl: null,
    $W_1:null,

    $4U_1: function($p0, $p1) {
        var $v_1 = this.$Grid._listid;
        var $v_0 = this.$Grid.getCheckedItems();
        var $v_2 = this.$Grid.getCheckedIds();
        
        if (!SP.Ribbon.SU.$0($v_1) && $p1) {
            $v_1 = $v_1.replace('{', '%7B');
            $v_1 = $v_1.replace('-', '%2D');
            $v_1 = $v_1.replace('}', '%7D');
        }

        $p0 = $p0.replace(new RegExp('{SelectedListId}', 'g'), $v_1);
        $p0 = $p0.replace(new RegExp('{SelectedItemId}', 'g'), $v_0);
        $p0 = $p0.replace(new RegExp('{SelectedItemIds}', 'g'), $v_2);
        $p0 = $p0.replace(new RegExp('{SiteUrl}', 'g'), this.$Grid._siteurl);
        return $p0;
    },

    $45_1: function($p0, $p1, $p2) {
        var $v_0 = $p0.CommandAction;
        var $v_1 = $p0.Command;
        var $v_2 = $p0.WebPartId;

        if ($v_0.toLowerCase().startsWith('javascript:')) {
            window.g_CUIcommandProperties = $p2;
            window.g_CUIcommandId = $p1;
            eval(this.$4U_1($v_0, false));
            window.g_CUIcommandProperties = null;
            window.g_CUIcommandId = null;
        }
        else {
            STSNavigate(this.$4U_1($v_0, true));
        }
        return true;
    },

    $3Z_1: function($p0) {
        if (SP.Ribbon.SU.$0(this.$W_1)) {
            this.$W_1 = [];
        }
        var $v_0 = $p0.children;
        if (SP.ScriptUtility.isNullOrUndefined($v_0)) {
            return;
        }
        var $v_1 = $v_0.length;
        for (var $v_2 = 0; $v_2 < $v_1; $v_2++) {
            this.$W_1[this.$W_1.length] = $v_0[$v_2].attrs;
        }
    },
    init: function ContextualTabWebPart_CustomPageComponent$init()
    {
        this.$3Z_1(window.g_commandUIHandlers);
    },
    getFocusedCommands: function ContextualTabWebPart_CustomPageComponent$getFocusedCommands() {
        var $arr = [];
        $arr = this.$Grid.addFocusedCommands($arr);

        Array.add($arr, 'ListItemTab');
        Array.add($arr, 'ListItemNewGroup'); 
        Array.add($arr, 'NewFolder');
        Array.add($arr, 'ViewProperties');
        Array.add($arr, 'ListItemManageGroup');
        Array.add($arr, 'EditProperties'); 
        Array.add($arr, 'EditPropertiesEPKOpen'); 
        Array.add($arr, 'EPKSingleAction'); 
        Array.add($arr, 'EPKMultiAction');
        Array.add($arr, 'EPKPrioritize');
        Array.add($arr, 'EPKCostView');
        Array.add($arr, 'EPMLiveAnalyzeGroup');
        Array.add($arr, 'ViewVersions');
        Array.add($arr, 'ManagePermissions');
        Array.add($arr, 'Delete');
        Array.add($arr, 'AttachFile');
        Array.add($arr, 'ChangeLinkOrder');
        Array.add($arr, 'ShareGroup');
        Array.add($arr, 'Subscribe');
        Array.add($arr, 'ViewWorkflows');
        Array.add($arr, 'ListItemWorkflowGroup');
        Array.add($arr, 'Moderate');
        Array.add($arr, 'ListTab');
        Array.add($arr, 'NewItemCT');
        Array.add($arr, 'NewItemRollup');
        Array.add($arr, 'NewItemApp');
        Array.add($arr, 'NewItemApp2');
        Array.add($arr, 'ViewFormatGroup');
        Array.add($arr, 'DisplayStandardView');
        Array.add($arr, 'DisplayGanttView');
        Array.add($arr, 'DisplayDatasheetView');
        Array.add($arr, 'CustomViewsGroup');
        Array.add($arr, 'CreateView');
        Array.add($arr, 'NewItem');
        Array.add($arr, 'ModifyThisView');
        Array.add($arr, 'ModifyView');
        Array.add($arr, 'ModifyViewInDesigner');
        Array.add($arr, 'CreateColumn');
        Array.add($arr, 'DisplayView');
        Array.add($arr, 'EmailLibraryLink');
        Array.add($arr, 'AlertMe');
        Array.add($arr, 'ViewRSSFeed');
        Array.add($arr, 'EditDefaultForms');
        Array.add($arr, 'SettingsGroup');
        Array.add($arr, 'EditDefaultForm');
        Array.add($arr, 'EditList');
        Array.add($arr, 'AddButton');
        Array.add($arr, 'SettingsGroup');
        Array.add($arr, 'ListSettings');
        Array.add($arr, 'LibraryPermissions');
        Array.add($arr, 'ManageWorkflows');
        Array.add($arr, 'EditWorkflowSettings');
        Array.add($arr, 'AssociateWorkflows');
        Array.add($arr, 'CreateWorkflowInDesigner');
        Array.add($arr, 'CreateReusableWorkflowInDesigner');
        Array.add($arr, 'DatasheetNewRow');
        Array.add($arr, 'PrintGrid');
        Array.add($arr, 'PrintGantt');
        Array.add($arr, 'DatasheetGroup');
        Array.add($arr, 'DatasheetSave');
        
        Array.add($arr, 'ListItemEPMLiveGroup');

        Array.add($arr, 'EditInProject');
        Array.add($arr, 'EditInMicrosoftProject');
        Array.add($arr, 'PlannerAgile');
        Array.add($arr, 'PlannerWP');
        Array.add($arr, 'GoToWorkspace');
        Array.add($arr, 'CreateWorkspace');
        
        Array.add($arr, 'ListEPMLiveGroup');
        Array.add($arr, 'ListEPMLiveEditInProject');
        Array.add($arr, 'ListEPMLiveEditWP');
        Array.add($arr, 'ListEPMLiveEditAgile');
        Array.add($arr, 'LEditInProject');
        Array.add($arr, 'LPlannerAgile');
        Array.add($arr, 'LPlannerWP');

        Array.add($arr, 'ActionsGroup');
        Array.add($arr, 'ExportToSpreadsheet');

        Array.add($arr, 'EPMLiveGanttViewGroup');
        Array.add($arr, 'ZoomIn');
        Array.add($arr, 'ZoomOut');
        Array.add($arr, 'ScrollTask');

        Array.add($arr, 'RefreshItems');
        Array.add($arr, 'PFEImportCostsData');
        Array.add($arr, 'ExportToExcel');

        Array.add($arr, 'ConnectToClient');

        Array.add($arr, 'EditInPSProject');
        Array.add($arr, 'ListEditInPSProject');
        Array.add($arr, 'LEditInPSProject');
        Array.add($arr, 'PlannerPSWebApp');
        Array.add($arr, 'LPlannerPSWebApp');
        Array.add($arr, 'ListEPMLiveEditPSWebApp');

        Array.add($arr, 'ShowFilters');

        Array.add($arr, 'LPlannerPE');
        Array.add($arr, 'ListEPMLiveEditPE');

        Array.add($arr, 'ListEPMLivePlanner');
        Array.add($arr, 'EPMLivePlanner');
        Array.add($arr, 'TaskPlanner');

        Array.add($arr, 'EditComments');

        Array.add($arr, 'LinkedItems');
        Array.add($arr, 'LinkedItemsButton');

        Array.add($arr, 'LinkedItemsRollup');
        Array.add($arr, 'LinkedItemsButtonRollup');

        Array.add($arr, 'BuildTeam');
        
        return $arr;
    },

    getGlobalCommands: function ContextualTabWebPart_CustomPageComponent$getGlobalCommands() {
        var $arr = [];
        $arr = this.$Grid.getGlobalCommands($arr);
        Array.add($arr, 'PopulateNewListItemMenu');
        Array.add($arr, 'NewDefaultListItem');
        Array.add($arr, 'NewListItemMenuOpen');
        Array.add($arr, 'QueryDisplayStandardView');
        Array.add($arr, 'QueryDisplayDatasheetView');
        Array.add($arr, 'QueryDisplayGanttView');
        Array.add($arr, 'QueryEPKCostView');
        Array.add($arr, 'PopulateModifyViewMenu');
        Array.add($arr, 'QueryDisplayView');
        Array.add($arr, 'PopulateViewDropDown');
        Array.add($arr, 'PopulateDefaultFormsForList');
        Array.add($arr, 'PopulateManageWorkFlowsMenu');
        Array.add($arr, 'ListEPMLivePlannerPopulate');
        for (var $v_0 = 0; $v_0 < this.$W_1.length; $v_0++) {
            var $v_1 = this.$W_1[$v_0];
            Array.add($arr, $v_1.Command);
        }

        return $arr;
    },

    isFocusable: function ContextualTabWebPart_CustomPageComponent$isFocusable() {
        return true;
    },

    canHandleCommand: function ContextualTabWebPart_CustomPageComponent$canHandleCommand(commandId) {

        switch(commandId)
        {
            case "NewFolder":
                return this.$Grid._newfolder;
            case "ViewProperties":
                return this.buttonEnabled(0);
            case "TaskPlanner":
                var $cnt = 0;
                var ids = "";
                ids = this.$Grid.getCheckedIds().split(',');
                if(ids == "")
                {
                    return false;
                }
                else if (ids.length > 0)
                {
                    for (var $v1 = 0; $v1 < ids.length; $v1++) 
                    {
                        var $v2 = ids[$v1];
                        if ($v2 == "undefined" || $v2 == "undefined.undefined" || $v2 == "undefined.undefined.undefined")
                        {
                           $cnt =  (parseInt($cnt)+parseInt(1));
                        }
                    }
                    if ($cnt == 1 || ids.length == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            case "EPKMultiAction":
                //if(this.buttonEnabled(1))
                {
                    var ids = this.$Grid.getCheckedIds();
                    if(ids != "")
                    {
                        return true;
                    }
                }
                return false;
            case "EditComments":
            case "EditProperties":
            case "EditPropertiesEPKOpen":
            case "EPKSingleAction":
            case "PlannerPSWebApp":
            case "EditInPSProject":
            case "ListEPMLivePlanner":
            case "EPMLivePlanner":
            case "ListEPMLivePlannerPopulate":
            case "BuildTeam":
            case "EditInMicrosoftProject":
                return this.buttonEnabled(1);
            case "ViewVersions":
                return this.buttonEnabled(4);
            case "ManagePermissions":
                return this.buttonEnabled(2);
            case "Delete":
                return this.buttonEnabled(3);
            case "AttachFile":
                return this.buttonEnabled(12);
            case "ViewWorkflows":
                return this.buttonEnabled(7);
            case "Moderate":
                return this.buttonEnabled(6);
            case "EditInProject":
                return this.buttonEnabled(13);
            case "PlannerAgile":
                return this.buttonEnabled(11);
            case "PlannerWP":
                return this.buttonEnabled(10);
            case "ChangeLinkOrder":
                return false;
            case "NewItem":
            case "NewDefaultListItem":
                return this.$Grid._shownewmenu;
            case "DisplayDatasheetView":
                return this.$Grid._allowedit;
            case "CreateWorkspace":
                var rowId = this.$Grid.getSelectedRowId();
                if(!rowId)
                    return false;
            	var wsurl = this.$Grid.getUserData(rowId,"wsurl");
                if(wsurl && wsurl.trim() != "")
                {
                    return false;
                }
                return true;
            case "ConnectToClient":
                return (this.$Grid._outlookexport != "");
            case "ModifyThisView":
            case "ModifyView":
            case "ModifyViewInDesigner":
            case "CreateView":
            case "CreateColumn":
            case "EditDefaultForms":
            case "EditList":
            case "AddButton":
            case "ListSettings":
            case "ManageWorkflows":
            case "EditWorkflowSettings":
            case "AssociateWorkflows":
            case "CreateWorkflowInDesigner":
            case "CreateReusableWorkflowInDesigner":
                return this.$Grid._modifylist;
            case "LibraryPermissions":
                return this.$Grid._listperms;
            case "DatasheetGroup":
            case "DatasheetSave":
                return (this.$Grid._gridMode == 'datasheet');
            case "DatasheetNewRow":
                if(this.$Grid._gridMode == 'datasheet')
                    return this.$Grid._newrow;
                else
                    return false;
            case "GoToWorkspace":
                var rowId = this.$Grid.getSelectedRowId();
                if(!rowId)
                    return false;
            	var wsurl = this.$Grid.getUserData(rowId,"wsurl");
                if(wsurl && wsurl.trim() != "")
                {
                    return true;
                }
                else
                {
                    var webid = this.$Grid.getUserData(rowId,"webid").trim();
                    if(webid == "")
                        return false;
                    if(webid.toLowerCase() != this.$Grid._webid.toLowerCase())
                        return true;
                    else
                        return false;
                }
            case "LinkedItems":
            case "LinkedItemsButton":
                var ids = this.$Grid.getCheckedIds();
                if(ids != "")
                {
                    return true;
                }
                return false;

            case "LinkedItemsRollup":
            case "LinkedItemsButtonRollup":
                var ids = this.$Grid.getCheckedItems();
                if(ids != "" && ids.indexOf(',') == -1)
                {
                    return true;
                }
                return false;

            case "PrintGrid":
            case "PrintGantt":
            case "PopulateNewListItemMenu":
            case "NewListItemMenuOpen":
            case "ListItemManageGroup":
            case "NewItemCT":
            case "NewItemApp2":
            case "NewItemApp":
            case "ListItemTab":
            case "ListItemNewGroup":
            case "ListTab":
            case "ManageAlerts":
            case "Subscribe":
            case "ShareGroup":
            case "ListItemWorkflowGroup":
            case "NewItemRollup":
            case "ViewFormatGroup":
            case "ListTab":
            case "DisplayStandardView":
            case "DisplayGanttView":
            case "QueryDisplayStandardView":
            case "QueryDisplayDatasheetView":
            case "QueryDisplayGanttView":
            case "QueryEPKCostView":
            case "CustomViewsGroup":
            case "PopulateModifyViewMenu":
            case "DisplayView":
            case "QueryDisplayView":
            case "PopulateViewDropDown":
            case "CurrentView":
            case "EmailLibraryLink":
            case "AlertMe":
            case "ViewRSSFeed":
            case "SettingsGroup":
            case "EditDefaultForm":
            case "PopulateDefaultFormsForList":
            case "SettingsGroup":
            case "PopulateManageWorkFlowsMenu":
            case "ListItemEPMLiveGroup":
            case "ExportToSpreadsheet":
            case "ActionsGroup":
            case "LEditInProject":
            case "LEditInPSProject":
            case "LPlannerAgile":
            case "LPlannerWP":
            case "ListEPMLiveGroup":
            case "ListEPMLiveEditInProject":
            case "ListEditInPSProject":
            case "ListEPMLiveEditWP":
            case "ListEPMLiveEditAgile":
            case "LPlannerPSWebApp":
            case "ListEPMLiveEditPSWebApp":
            case "EPKCostView":
            case "EPMLiveGanttViewGroup":
            case "ZoomIn":
            case "ZoomOut":
            case "ScrollTask":
            case "ShowFilters":
            case "RefreshItems":
            case "PFEImportCostsData":
            case "ExportToExcel":
            case "EPMLiveAnalyzeGroup":
            case "LPlannerPE":
            case "ListEPMLiveEditPE":
            
            case "EPKPrioritize":
                return true;
            default:
                if(this.canHandleCommandGlobal(commandId))
                    return true;
                return this.$Grid.canHandleCommand(this.$Grid, commandId);
        }
       
    },

    canHandleCommandGlobal: function(p0) 
    {
        for (var $v_0 = 0; $v_0 < this.$W_1.length; $v_0++) 
        {
            var $v_1 = this.$W_1[$v_0];
            if($v_1.Command == p0)
                return true;
        }

        return false;
    },

    getCommandValues: function(p0) 
    {
        for (var $v_0 = 0; $v_0 < this.$W_1.length; $v_0++) 
        {
            var $v_1 = this.$W_1[$v_0];
            if($v_1.Command == p0)
                return $v_1;
        }

        return false;
    },

    handleCommand: function ContextualTabWebPart_CustomPageComponent$handleCommand(commandId, properties, sequence) {
        
        try
		{			
			$("a[id*='ExportToSpreadsheet']").hide();
		}		
		catch(err){}

        if(commandId == 'CreateView')
        {
            location.href = this.$curWebUrl + '/_layouts/ViewNew.aspx?List=' + this.$Grid._listid + '&Source=' + this.$curUrl;
        }
        else if(commandId === 'LinkedItemsButton')
        {
            sm("dlgPosting", 150, 50);
            
            var lookups = "";
            
            //var listInfo = properties['CommandValueId'].split('.');
            
            var listInfo = properties.SourceControlId.split('.');

            var lookups = this.$Grid.getTitles();

            dhtmlxAjax.post(this.$curWebUrl + "/_layouts/epmlive/gridaction.aspx?action=linkeditemspost", "listid=" + this.$Grid._listid + "&lookups=" + escape(lookups) + "&field=" + listInfo[5] + "&LookupFieldList=" + listInfo[4], this.LinkedItemsButtonPost);
            
        }
        else if(commandId === 'EditComments')
        {
            var rowId = this.$Grid.getSelectedRowId();
            var siteurl = this.$Grid.getUserData(rowId,"SiteUrl");
        	var listid = this.$Grid.getUserData(rowId,"listid");
        	var itemid = this.$Grid.getUserData(rowId,"itemid");
        	var webid = this.$Grid.getUserData(rowId,"webid");
            
            curGrid = this.$Grid;
            curRow = rowId;

            if (this.$Grid._useparent) {
                var parentid = this.$Grid.getUserData(rowId, "parentitemid");
                if (parentid && parentid != "") {
                    var newids = parentid.toString().split(".");
                    webid = newids[0];
                    listid = newids[1];
                    itemid = newids[2];
                }
            }
            CurrentGrid = Grids["GanttGrid" + this.$Grid._gridid];
            CurrentRow = CurrentGrid.GetRowById(rowId);

            var weburl = this.$curWebUrl + "/_layouts/epmlive/gridaction.aspx?action=comments&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + escape(document.location.href);
            var options = { url: weburl, width: 600, height: 500, dialogReturnValueCallback: this.gridactioncallback };
            SP.UI.ModalDialog.showModalDialog(options);
        }
        else if(commandId === 'TaskPlanner')
        {
            try
            {
                var rowId = this.$Grid.getSelectedRowId();
                if(rowId)
                {
                    var siteurl = this.$Grid.getUserData(rowId,"SiteUrl");
        	        var listid = this.$Grid.getUserData(rowId,"listid");
        	        var itemid = this.$Grid.getUserData(rowId,"itemid");
        	        var webid = this.$Grid.getUserData(rowId,"webid");

        	        //var weburl = siteurl + "/_layouts/epmlive/workplanner.aspx?Planner=" + this.$Grid._curPlanner + "&Source=" + this.$curUrl;
                    var weburl = siteurl + "/_layouts/epmlive/gridaction.aspx?action=GoToTaskPlanner&webid=" + webid + "&listid=" + listid + "&id=" + itemid + "&Source=" + this.$curUrl;
                }
                else
                {
                    var weburl = this.$curWebUrl + "/_layouts/epmlive/workplanner.aspx?tc=" + this.$Grid._listname + "&Source=" + this.$curUrl;
                }
                location.href = weburl;
            }catch(e){}
        }
        else if(commandId === 'EPMLivePlanner')
        {
            
            try
            {
                var rowId = this.$Grid.getSelectedRowId();
                var siteurl = this.$Grid.getUserData(rowId,"SiteUrl");
        	    var listid = this.$Grid.getUserData(rowId,"listid");
        	    var itemid = this.$Grid.getUserData(rowId,"itemid");
        	    var webid = this.$Grid.getUserData(rowId,"webid");

                if (this.$Grid._useparent) {
                    var parentid = this.$Grid.getUserData(rowId, "parentitemid");
                    if (parentid && parentid != "") {
                        var newids = parentid.toString().split(".");
                        webid = newids[0];
                        listid = newids[1];
                        itemid = newids[2];
                    }
                }

        	    var weburl = siteurl + "/_layouts/epmlive/gridaction.aspx?action=GoToPlanner&webid=" + webid + "&listid=" + listid + "&id=" + itemid + "&Source=" + this.$curUrl;

                location.href = weburl;
            }catch(e){}
        }
        else if(commandId === 'ListEPMLivePlanner')
        {
            
            try
            {
                var rowId = this.$Grid.getSelectedRowId();
                var siteurl = this.$Grid.getUserData(rowId,"SiteUrl");
        	    var listid = this.$Grid.getUserData(rowId,"listid");
        	    var itemid = this.$Grid.getUserData(rowId,"itemid");
        	    var webid = this.$Grid.getUserData(rowId,"webid");

        	    var weburl = siteurl + "/_layouts/epmlive/gridaction.aspx?action=GoToPlanner&Planner=" + properties['CommandValueId'] + "&webid=" + webid + "&id=" + itemid + "&Source=" + this.$curUrl;

                location.href = weburl;
            }catch(e){}
        }
        else if(commandId === 'ListEPMLivePlannerPopulate')
        {

            var rowId = this.$Grid.getSelectedRowId();
            var siteurl = this.$Grid.getUserData(rowId,"SiteUrl");
        	var listid = this.$Grid.getUserData(rowId,"listid");
        	var itemid = this.$Grid.getUserData(rowId,"itemid");
        	var webid = this.$Grid.getUserData(rowId,"webid");

        	var weburl = siteurl + "/_layouts/epmlive/gridaction.aspx?action=getribbonplanners&webid=" + webid + "&listid=" + listid + "&itemid=" + itemid;

            var data = dhtmlxAjax.getSync(weburl);
            
            var sData = data.xmlDoc.responseText.trim();

            var sb = new Sys.StringBuilder();

            if(sData != "")
            {

                sb.append('<Menu Id=\'Ribbon.List.EPMLive.Planner.Menu\'>');
                sb.append('<MenuSection DisplayMode=\'Menu16\' Id=\'Ribbon.List.EPMLive.Planner.Menu.Default\'>');
                sb.append('<Controls Id=\'Ribbon.List.EPMLive.Planner.Menu.Default.Controls\'>');

                if(sData.indexOf("Error:") == 0)
                {
                    alert(sData);
                }
                else
                {
                    var planners = sData.split('^');
                    for(var i = 0;i<planners.length;i++)
                    {
                        var planner = planners[i].split('|');

                        sb.append("<Button Id=\"Ribbon.List.EPMLive.Planner." + planner[0] + "\" ");
                        sb.append("Sequence=\"10\" Command=\"" + planner[3] + "\" CommandValueId=\"" + planner[0] + "\" ");
                        sb.append("LabelText=\"" + planner[1] + "\" TemplateAlias=\"o1\" ToolTipTitle=\"" + planner[1] + "\" ");
                        sb.append("ToolTipDescription=\"" + planner[2] + "\" Image16by16=\"" + planner[4] + "\"/>");
                    }
                }
                sb.append('</Controls>');
                sb.append('</MenuSection>');

                sb.append('</Menu>');
            }

            properties.PopulationXML = sb.toString();

            return true;
        }
        else if(commandId === 'ConnectToClient')
        {
            SP.Ribbon.NativeUtility.executeClickScriptSimple(this.$Grid._outlookexport);
        }
        else if(commandId === 'ExportToSpreadsheet')
        {
            if(this.$Grid._rolluplists != "")
            {
                EnsureSSImporter();
                location.href= this.$curWebUrl + '/_layouts/epmlive/rollupexport.aspx?List=' + this.$Grid._listid + '&View=' + this.$Grid._viewid + "&Lists=" + this.$Grid._rolluplists;
            }
            else
            {
                EnsureSSImporter();
                ExportList(this.$Grid._excell);
            }
        }
        else if(commandId === 'EditInProject' || commandId === 'EditInMicrosoftProject')
        {
            var rowId = this.$Grid.getSelectedRowId();
        	var listid = this.$Grid.getUserData(rowId,"listid");
        	var itemid = this.$Grid.getUserData(rowId,"itemid");
            var webid = this.$Grid.getUserData(rowId,"webid");

            weburl = this.$curWebUrl + "/_layouts/epmlive/gridaction.aspx?action=getproject&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + document.location.href;

            window.open(weburl,'', config='height=100,width=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no');
        }
        else if(commandId === 'PlannerPSWebApp')
        {
            var rowId = this.$Grid.getSelectedRowId();
        	var listid = this.$Grid.getUserData(rowId,"listid");
        	var itemid = this.$Grid.getUserData(rowId,"itemid");
            var webid = this.$Grid.getUserData(rowId,"webid");

            weburl = this.$curWebUrl + "/_layouts/epmlive/gridaction.aspx?action=getpswebapp&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + document.location.href;

            window.open(weburl);
        }
        else if(commandId === 'LPlannerPSWebApp')
        {
            var cmdData = properties['CommandValueId'].split(".");

            weburl = this.$curWebUrl + "/_layouts/epmlive/getpswebapp.aspx?listID=" + cmdData[0] + "&ID=" + cmdData[1];

            window.open(weburl);
        }
        else if(commandId === 'LEditInPSProject')
        {
            var cmdData = properties['CommandValueId'].split(".");

            weburl = this.$curWebUrl + "/_layouts/epmlive/getpsproject.aspx?listID=" + cmdData[0] + "&ID=" + cmdData[1];
            
            function NewItemCallback2(dialogResult, returnValue){}

        	var options = { url: weburl, width: 300, dialogReturnValueCallback:NewItemCallback2 };

        	SP.UI.ModalDialog.showModalDialog(options);
        }
        else if(commandId === 'EditInPSProject')
        {
            var rowId = this.$Grid.getSelectedRowId();
        	var listid = this.$Grid.getUserData(rowId,"listid");
        	var itemid = this.$Grid.getUserData(rowId,"itemid");
            var webid = this.$Grid.getUserData(rowId,"webid");

            weburl = this.$curWebUrl + "/_layouts/epmlive/gridaction.aspx?action=getpsproject&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + document.location.href;

            function NewItemCallback3(dialogResult, returnValue){}

        	var options = { url: weburl, width: 300, dialogReturnValueCallback:NewItemCallback3 };

        	SP.UI.ModalDialog.showModalDialog(options);
        }
        else if(commandId === 'LPlannerWP')
        {
            weburl = this.$curWebUrl + "/_layouts/epmlive/tasks.aspx?ID=" + properties['CommandValueId'] + "&Source=" + document.location.href;
            //location.href=weburl;
            window.open(weburl + "&IsDlg=1",'',config='toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');
        }
        else if(commandId === 'LPlannerAgile')
        {
            weburl = this.$curWebUrl + "/_layouts/epmlive/agile/tasks.aspx?ID=" + properties['CommandValueId'] + "&Source=" + document.location.href;
            window.open(weburl + "&IsDlg=1",'',config='toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');
        }
        else if(commandId === 'LEditInProject')
        {
            var cmdData = properties['CommandValueId'].split(".");
            weburl = this.$curWebUrl + "/_layouts/epmlive/getproject.aspx?listID=" + cmdData[0] + "&ID=" + cmdData[1] + "&Source=" + document.location.href;
            window.open(weburl,'', config='height=100,width=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, directories=no, status=no');
        }
        else if(commandId === 'PlannerWP')
        {
            this.epmlive_gridaction("workplan", 650, this.$Grid.getSelectedRowId());
        }
        else if(commandId === 'PlannerAgile')
        {
            this.epmlive_gridaction("agile", 650, this.$Grid.getSelectedRowId());
        }
        else if(commandId === 'DisplayStandardView')
        {
            if(this.$Grid._gridMode != 'grid')
            {
                var turl = this.$curUrl + '?webpartid=' + this.$Grid._webpartid + '&gridmode=grid';

                if(this.$Grid._lookupfield != "")
                    turl = turl + "&lookupfield=" + this.$Grid._lookupfield

                if(this.$Grid._lookupfieldlist != "")
                    turl = turl + "&lookupfieldlist=" + this.$Grid._lookupfieldlist

                location.href = turl;
            }
        }
        else if(commandId === 'DisplayDatasheetView')
        {
            if(this.$Grid._gridMode != 'datasheet')
            {
                var turl = this.$curUrl + '?webpartid=' + this.$Grid._webpartid + '&gridmode=datasheet';

                if(this.$Grid._lookupfield != "")
                    turl = turl + "&lookupfield=" + this.$Grid._lookupfield

                if(this.$Grid._lookupfieldlist != "")
                    turl = turl + "&lookupfieldlist=" + this.$Grid._lookupfieldlist

                location.href = turl;
            }
        }
        else if(commandId === 'DisplayGanttView')
        {
            if(this.$Grid._gridMode != 'gantt')
            {
                var turl = this.$curUrl + '?webpartid=' + this.$Grid._webpartid + '&gridmode=gantt';

                if(this.$Grid._lookupfield != "")
                    turl = turl + "&lookupfield=" + this.$Grid._lookupfield

                if(this.$Grid._lookupfieldlist != "")
                    turl = turl + "&lookupfieldlist=" + this.$Grid._lookupfieldlist

                location.href = turl;


            }
        }
        else if(commandId === 'QueryEPKCostView')
        {
            properties['On'] = (this.$Grid._gridMode == 'cost');
        }
        else if(commandId === 'QueryDisplayGanttView')
        {
            properties['On'] = (this.$Grid._gridMode == 'gantt');
        }
        else if(commandId === 'QueryDisplayStandardView')
        {
            properties['On'] = (this.$Grid._gridMode == 'grid');
        }
        else if(commandId === 'QueryDisplayDatasheetView')
        {
            properties['On'] = (this.$Grid._gridMode == 'datasheet');
        }
        else if (commandId === 'PopulateNewListItemMenu')
        {
            ExecuteOrDelayUntilScriptLoaded(Function.createDelegate(null, getDropdownItemsXml), 'SP.js');
            properties.PopulationXML = getDropdownItemsXml(this.$Grid._newmenu); 
        }
        else if(commandId === 'ViewProperties')
        {
            this.epmlive_gridaction("view", 600, this.$Grid.getSelectedRowId());
        }
        else if(commandId === 'EditProperties')
        {
            this.epmlive_gridaction("edit", 600, this.$Grid.getSelectedRowId());



        }
        else if(commandId === 'ViewVersions')
        {
            this.epmlive_gridaction("version", 500, this.$Grid.getSelectedRowId());
        }
        else if(commandId === 'ManagePermissions')
        {
            this.epmlive_gridaction("perms", 650, this.$Grid.getSelectedRowId());
        }
        else if(commandId === 'Delete')
        {
            epmlive_delete(this.$Grid, this.$Grid.getSelectedRowId());
        }
        else if(commandId === 'AttachFile')
        {
            this.epmlive_gridaction("attachfile", 600, this.$Grid.getSelectedRowId());
        }
        else if(commandId === 'Subscribe')
        {
            this.epmlive_gridaction("subscribe", 650, this.$Grid.getSelectedRowId());
        }
        else if(commandId === 'ManageAlerts')
        {
            var rowId = this.$Grid.getSelectedRowId();
            var weburl = this.$Grid.getUserData(rowId,"SiteUrl");
        	var listid = this.$Grid.getUserData(rowId,"listid");
        	var itemid = this.$Grid.getUserData(rowId,"itemid");
        	var webid = this.$Grid.getUserData(rowId,"webid");

        	if(weburl == "/")
        		weburl = "";

        	weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=alerts&webid=" + webid + "&Source=" + document.location.href;

        	document.location.href=weburl;
        }
        else if(commandId === 'GoToWorkspace')
        {
            var rowId = this.$Grid.getSelectedRowId();
            var weburl = this.$Grid.getUserData(rowId,"SiteUrl");
        	var webid = this.$Grid.getUserData(rowId,"webid");
            var wsurl = this.$Grid.getUserData(rowId, "wsurl");

            if(wsurl && wsurl != ""){
                document.location.href = wsurl.split(',')[0];
            }
            else
            {
        	    if(weburl == "/")
        		    weburl = "";

        	    weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=workspace&webid=" + webid + "&Source=" + document.location.href;

        	    document.location.href=weburl;
            }
        }
        else if(commandId === 'CreateWorkspace')
        {
            if(this.$Grid._hasTemplateList){
                var rowId = this.$Grid.getSelectedRowId();
                var itemid = this.$Grid.getUserData(rowId,"itemid");
                var listid = this.$Grid.getUserData(rowId,"listid");
                CreateEPMLiveWorkspace(listid, itemid);
            }
            else
            {
                var rowId = this.$Grid.getSelectedRowId();
                var weburl = this.$Grid.getUserData(rowId,"SiteUrl");
                var listid = this.$Grid.getUserData(rowId,"listid");
        	    var itemid = this.$Grid.getUserData(rowId,"itemid");
        	    var webid = this.$Grid.getUserData(rowId,"webid");

        	    if(weburl == "/")
        		    weburl = "";

        	    weburl = weburl + "/_layouts/epmlive/requestworkspace.aspx?id=" + itemid + "&list=" + listid + "&Source=" + document.location.href;

        	    document.location.href=weburl;
            }
        }
        else if(commandId === 'ViewWorkflows')
        {
            var rowId = this.$Grid.getSelectedRowId();

            var weburl = this.$Grid.getUserData(rowId,"SiteUrl");
        	var listid = this.$Grid.getUserData(rowId,"listid");
        	var itemid = this.$Grid.getUserData(rowId,"itemid");
        	var webid = this.$Grid.getUserData(rowId,"webid");

        	if(weburl == "/")
        		weburl = "";

            if (this.$Grid._useparent) {
                var parentid = this.$Grid.getUserData(rowId, "parentitemid");
                if (parentid && parentid != "") {
                    var newids = parentid.toString().split(".");
                    webid = newids[0];
                    listid = newids[1];
                    itemid = newids[2];
                }
            }
        	weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=workflows&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + document.location.href;

        	document.location.href=weburl;

        }
        else if(commandId === 'Moderate')
        {
            this.epmlive_gridaction("approve", 600, this.$Grid.getSelectedRowId());
        }
        else if(commandId === 'NewItemCT')
        {
            var selectedItem = properties.SourceControlId.toString();            
            var ct = selectedItem.substring(selectedItem.lastIndexOf('.') + 1);

            var wurl = this.$Grid._newitemurl;
            if(wurl.indexOf('?') > 0)
                wurl += "&";
            else
                wurl += "?";

            wurl += "ContentTypeId=" + ct;

            curGrid = this.$Grid;

            if(wurl.indexOf('?') > 0)
                wurl = wurl + "&GetLastID=true";
            else
                wurl = wurl + "?GetLastID=true";

        	var options = { url: wurl, width: 600, dialogReturnValueCallback:NewItemCallback };

        	SP.UI.ModalDialog.showModalDialog(options);
        }
        else if(commandId === 'NewDefaultListItem')
        {
            curGrid = this.$Grid;
            if(this.$Grid._newmenumode == '0')
            {
                var wurl = this.$Grid._newitemurl;
                

                if(this.$Grid._usepopup)
                {
                    if(wurl.indexOf('?') > 0)
                        wurl = wurl + "&GetLastID=true";
                    else
                        wurl = wurl + "?GetLastID=true";

            	    var options = { url: wurl, width: 600, dialogReturnValueCallback:NewItemCallback };

            	    SP.UI.ModalDialog.showModalDialog(options);
                }
                else
                    location.href = wurl;
            }
            else if(this.$Grid._newmenumode == '2')
            {

                var wurl = this.$Grid._newitemurl + "?List=" + this.$Grid._defaultct;

                location.href=wurl;
            }
            else if(this.$Grid._newmenumode == '3')
            {
                newAppPopup(this.$Grid._defaultct);

                //var wurl = this.$Grid._newitemurl + "?List=" + this.$Grid._defaultct;

                //location.href=wurl;
            }
        }
        else if(commandId === 'NewItem')
        {
            var wurl = this.$Grid._newitemurl;

            if(wurl.indexOf('?') > 0)
                wurl = wurl + "&GetLastID=true";
            else
                wurl = wurl + "?GetLastID=true";

            curGrid = this.$Grid;
            if(this.$Grid._usepopup)
            {

        	    var options = { url: wurl, width: 600, dialogReturnValueCallback:NewItemCallback };

        	    SP.UI.ModalDialog.showModalDialog(options);
            }
            else
            {
                location.href=wurl;
            }
        }
        else if(commandId === 'NewItemRollup')
        {
            var selectedItem = properties.SourceControlId.toString();            
            var ct = selectedItem.substring(selectedItem.lastIndexOf('.') + 1);

            var wurl = this.$Grid._newitemurl + "?List=" + ct + "&Source=" + location.href;

            location.href=wurl;
        }
        else if(commandId === 'NewItemApp')
        {
            var selectedItem = properties.SourceControlId.toString();            
            var ct = selectedItem.substring(selectedItem.lastIndexOf('.') + 1);

            var wurl = this.$Grid._newitemurl + "?List=" + ct;

            location.href=wurl;
        }
        else if(commandId === 'NewItemApp2')
        {
            var selectedItem = properties.SourceControlId.toString();
            var ct = selectedItem.substring(selectedItem.lastIndexOf('.') + 1);
            newAppPopup(ct);
        }
        else if(commandId === 'PopulateModifyViewMenu')
        {
            properties.PopulationXML = this.PopulateModifyViewMenu();
            return true;
        }
        else if(commandId === 'ModifyThisView' || commandId==='ModifyView')
        {
            location.href = this.$curWebUrl + '/_layouts/ViewEdit.aspx?List=' + this.$Grid._listid + '&View=%7B' + this.$Grid._viewid + '%7D&Source=' + this.$curUrl;
        }
        else if (commandId === 'ModifyViewInDesigner') {
            EditInSPD(document.URL, true);
        }
        else if (commandId === 'CreateColumn')
        {
            var wurl = this.$curWebUrl + "/_layouts/fldNew.aspx?List=" + this.$Grid._listid + "&Source=" + this.$curUrl;

            function myCallback(dialogResult, returnValue){}

        	var options = { url: wurl, width: 700, dialogReturnValueCallback:myCallback };

        	SP.UI.ModalDialog.showModalDialog(options);
        }
        else if(commandId === 'QueryDisplayView')
        {
            properties['Value'] = this.$Grid._viewname;
        }
        else if(commandId === 'PopulateViewDropDown')
        {
            if (SP.Ribbon.SU.$0(this.$1Q_3)) {
                this.getViewGroupInfo();
                var $v_B = (properties);
                $v_B.PollAgainInterval = 100;
                return true;
            }
            else {
                properties.PopulationJSON = this.$1Q_3;
                return true;
            }
        }
        else if(commandId === 'DisplayView')
        {
            SP.Ribbon.NativeUtility.executeClickScriptSimple(properties['CommandValueId'].replace("event","null"));
        }
        else if(commandId === 'EmailLibraryLink')
        {
            SP.Ribbon.EMailLink.openMailerWithUrl(this.$Grid._viewurl);
        }
        else if(commandId === 'AlertMe')
        {
            var wurl = this.$curWebUrl + "/_layouts/subnew.aspx?List=" + this.$Grid._listid + "&Source=" + this.$curUrl;

            function myCallback(dialogResult, returnValue){}

        	var options = { url: wurl, width: 700, dialogReturnValueCallback:myCallback };

        	SP.UI.ModalDialog.showModalDialog(options);
        }
        else if(commandId == 'ViewRSSFeed')
        {
            location.href = this.$curWebUrl + "/_layouts/listfeed.aspx?List=" + this.$Grid._listid + "&Source=" + this.$curUrl;
        }
        else if (commandId === 'PopulateDefaultFormsForList') 
        {
            ExecuteOrDelayUntilScriptLoaded(Function.createDelegate(null, getFormItemsXml), 'SP.js');
            properties.PopulationXML = getFormItemsXml(this.$Grid._formmenus); 
        }
        else if (commandId === 'EditDefaultForm') 
        {
            this.navigateToFormPageDesignMode(properties['CommandValueId']);
            //location.href = this.$curWebUrl + properties['CommandValueId'] + "?DisplayMode=Design&InitialTabId=Ribbon%2EWebPartPage&VisibilityContext=WSSWebPartPage&Source=" + this.$curUrl;
        }
        else if(commandId === 'EditList')
        {
            this.editIn('?Cmd=EditList', true);
        }
        else if(commandId === 'AddButton')
        {
            this.editIn('?Cmd=AddButton', true);
        }
        else if (commandId === 'LibraryPermissions') {
            var $v_C = new SP.Guid(this.$Grid._listid);
            var $v_D = this.$curWebUrl + '/_layouts/user.aspx' + '?obj=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_C.toString('B').toUpperCase());
            if (this.$Grid._basetype === '1' && this.$Grid._templatetype !== '113') {
                $v_D = $v_D + ',doclib';
            }
            else {
                $v_D = $v_D + ',list';
            }
            $v_D = $v_D + '&list=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_C.toString('B').toUpperCase());
            SP.Utilities.HttpUtility.navigateTo($v_D);
        }
        else if (commandId === 'PopulateManageWorkFlowsMenu') {
            properties.PopulationXML = this.$5k_3();
            return true;
        }
        else if (commandId === 'EditWorkflowSettings' || commandId === 'ManageWorkflows') {
            var $v_E = new SP.Guid(this.$Grid._listid);
            var $v_F = this.$curWebUrl + '/_layouts/wrksetng.aspx' + '?List=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_E.toString('B').toUpperCase());
            SP.Utilities.HttpUtility.navigateTo($v_F);
        }
        else if(commandId==='ListSettings')
        {
            var $v_E = new SP.Guid(this.$Grid._listid);
            var $v_F = this.$curWebUrl + '/_layouts/listedit.aspx' + '?List=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_E.toString('B').toUpperCase());
            SP.Utilities.HttpUtility.navigateTo($v_F);
        }
        else if (commandId === 'AssociateWorkflows') {
            var $v_G = new SP.Guid(this.$Grid._listid);
            var $v_H = this.$curWebUrl + '/_layouts/Addwrkfl.aspx' + '?List=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_G.toString('B').toUpperCase());
            SP.Utilities.HttpUtility.navigateTo($v_H);
        }
        else if (commandId === 'CreateWorkflowInDesigner') {
            this.editIn('?Cmd=NewWorkFlow', true);
        }
        else if (commandId === 'CreateReusableWorkflowInDesigner') {
            this.editIn('?Cmd=NewReusableWorkFlow', false);
        }
        else if (commandId === 'DatasheetSave')
        {
            this.$Grid.editStop();
            sm('dlgSaving' + this.$Grid._gridid,200,100);

            if(this.$DataProc.updatedRows.length > 0)
            {
                this.$DataProc.sendData();
            }
            else
                hm('dlgSaving' + this.$Grid._gridid);            
        }
        else if(commandId === 'DatasheetNewRow')
        {
            var xmlDoc; 
            var moz = (typeof document.implementation != 'undefined') && (typeof document.implementation.createDocument != 'undefined'); 
            var ie = (typeof window.ActiveXObject != 'undefined'); 

            if (moz) { 
                xmlDoc = document.implementation.createDocument("", "", null) 
                xmlDoc.onload = readXML; 
            } else if (ie) { 
                xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
                xmlDoc.async = false; 
                while(xmlDoc.readyState != 4) {}; 
            } 
            xmlDoc.loadXML(this.$Grid._defaults); 

            var newId = "_NEWROW_" + this.$Grid.getUID();
            var nRow = this.$Grid.addRow(newId,"<img src='/_layouts/images/newitem.gif'>");
            xmlDoc.firstChild.setAttribute("id",newId);

            this.setRowValue(xmlDoc.firstChild);

            this.$Grid.setUserData(newId,"isNewRow","1");
            this.$DataProc.setUpdated(newId,false);
        }
        else if(commandId === 'PrintGrid')
        {
            var temp = this.$Grid.hdr.rows[2];
            var parent = temp.parentNode;
            parent.removeChild(temp,true);
            this.$Grid.printView();
            parent.appendChild(temp);
        }
        else if(commandId === 'PrintGantt')
        {
            Grids["GanttGrid" + this.$Grid._gridid].ActionPrint();
        }
        else if(commandId === 'ZoomIn')
	    {
		    GanttZoomIn(this.$Grid._gridid);
	    }
	    else if(commandId === 'ZoomOut')
	    {
		    GanttZoomOut(this.$Grid._gridid);
	    }
	    else if(commandId === 'ScrollTask')
	    {
		    GanttScrollTo(this.$Grid._gridid);
	    }
        else if(commandId === 'RefreshItems')
        {
            var $v_G = new SP.Guid(this.$Grid._listid);
            var $v_H = this.$curWebUrl + '/_layouts/epmlive/refreshind.aspx?ListId=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_G.toString('B').toUpperCase()) + '&Source=' + document.location.href;
            SP.Utilities.HttpUtility.navigateTo($v_H);
        }
        else if(commandId === 'PFEImportCostsData')
        {
            var $v_G = new SP.Guid(this.$Grid._listid);
            var $v_H = this.$curWebUrl + '/_layouts/ppm/pfefileimport.aspx?listid=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_G.toString('B').toUpperCase()) + '&Source=' + document.location.href;
            var options = { url: $v_H, showMaximized: false, showClose: false };
            SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
        }
        else if(commandId === 'ExportToExcel')
        {              
			var newdiv = document.createElement('div');
			newdiv.setAttribute('id','exportOptionDiv');
			var sb = new Sys.StringBuilder();        
			sb.append('Choose below Options for Export <br /><br/>');
			sb.append('<input type=\'radio\' name=\'ExportOption\' id=\'rbdsp\' checked=\'true\'/> Export All the Items <br /><br />');
			sb.append('<input type=\'radio\' name=\'ExportOption\' id=\'rbdtg\'/> Export Current Items <br /><br />');        
			sb.append('<input type=\'button\' value=\'OK\' onclick=\'SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK,document.getElementById(\"rbdsp\").checked + \"|\" + document.getElementById(\"rbdtg\").checked); return false;\' class=\'ms-ButtonHeightWidth\' style=\'width:100px\' target=\'_self\' /> &nbsp;');
			sb.append('<input type=\'button\' value=\'Cancel\' onclick=\'SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel); return false;\' class=\'ms-ButtonHeightWidth\' style=\'width:100px\' target=\'_self\' /> ');
			newdiv.innerHTML = sb.toString();
            
			curGrid = this.$Grid;
            var options = { html:newdiv,width: 400, height: 150,title: "Export to Excel", showMaximized: false, showClose: true,dialogReturnValueCallback: this.onExportExcelClose};            
			SP.UI.ModalDialog.showModalDialog(options);
        }
        else if(commandId === 'EPKCostView')
        {
            if(this.$Grid._gridMode != 'cost')
            {
                location.href = this.$curUrl + '?webpartid=' + this.$Grid._webpartid + '&gridmode=cost';
            }
        }
        else if(commandId === 'EPKSingleAction')
        {
            curRow = this.$Grid.getSelectedRowId();
            curGrid = this.$Grid;

            var rowId = this.$Grid.getSelectedRowId();
            var weburl = this.$Grid.getUserData(rowId,"SiteUrl");
        	var listid = this.$Grid.getUserData(rowId,"listid");
        	var itemid = this.$Grid.getUserData(rowId,"itemid");
        	var webid = this.$Grid.getUserData(rowId,"webid");

            var FullId = webid + "." + listid + "." + itemid;
            var epkurl = this.$Grid._epkurl;
            var view = this.$Grid._epkcostview;
            var epkcontrol = "";

            if (this.$Grid._useparent) {
                var parentid = this.$Grid.getUserData(rowId, "parentitemid");
                if (parentid && parentid != "") {
                    FullId = parentid;
                    var newids = parentid.toString().split(".");
                    webid = newids[0];
                    //listid = newids[1];
                    itemid = newids[2];
                }
            }

            switch(properties.SourceControlId)
            {
                case "Ribbon.ListItem.Manage.EPKResourcePlanner":
                    epkcontrol = "rpeditor";
                    break;
                case "Ribbon.ListItem.Manage.EPKCosts":
                    epkcontrol = "costs";
                    break;
                case "Ribbon.ListItem.Manage.EPKWorkPlan":
                    epkcontrol = "workitems";
                    break;
                case "Ribbon.ListItem.Manage.EPKDetails":
                    epkcontrol = "details";
                    break;
            }

            CurrentGrid = Grids["GanttGrid" + this.$Grid._gridid];
            CurrentRow = CurrentGrid.GetRowById(rowId);

            weburl = this.$Grid._webrelurl + "/_layouts/ppm/" + epkcontrol + ".aspx?itemid=" + FullId + "&epkurl=" + epkurl + "&view=" + view + "&listid=" + listid;

            //function myCallback(dialogResult, returnValue){}

        	var options = { url: weburl, showMaximized: true, showClose: false, dialogReturnValueCallback:this.gridactioncallback };

        	SP.UI.ModalDialog.showModalDialog(options);
        }
        else if(commandId === 'EPKPrioritize')
        {

            weburl = this.$Grid._webrelurl + "/_layouts/ppm/prioritize.aspx?epkurl=" + epkurl;

        	var options = { url: weburl, width: 800, height: 600, showClose: false };

        	SP.UI.ModalDialog.showModalDialog(options);

        }
        else if(commandId === 'EPKMultiAction')
        {

            var ids = this.$Grid.getCheckedIds();
            
            if(ids != "" && ids[0] == ',')
            {
                ids = ids.substring(1);
            }

            if(ids != "")
            {
                var epkurl = this.$Grid._epkurl;
                var epkcontrol = "";

                switch(properties.SourceControlId)
                {
                    case "Ribbon.ListItem.Manage.EPKResourceAnalyzer":
                        epkcontrol = "rpanalyzer";
                        break;
                    case "Ribbon.ListItem.Manage.EPKResourcePlanner":
                        epkcontrol = "rpeditor";
                        break;
                    case "Ribbon.ListItem.Manage.EPKCostAnalyzer":
                        epkcontrol = "costanalyzer";
                        break;
                    case "Ribbon.ListItem.Manage.EPKModeler":
                        epkcontrol = "modeler";
                        break;
                    case "Ribbon.ListItem.Manage.EPKOptimizer":
                        epkcontrol = "optimizer";
                        break;
                }

                epkmulti(epkcontrol, this.$Grid._webrelurl, ids, this.$Grid._epkcostview, this.$Grid._listid);

                
            }
        }
        else if (commandId === 'ShowFilters')
        {
            //this.$Grid.switchFilter();
            this.$Grid.toggleSearch();
        }
        else if (commandId === 'LPlannerPE')
        {
            //var cmdData = properties['CommandValueId'].split(".");

            var weburl = this.$Grid.getUserData(rowId,"SiteUrl");

            var epkurl = this.$Grid._epkurl;

            weburl = this.$Grid._siteurl + "/_layouts/ppm/workitems.aspx?itemid=" + properties['CommandValueId'] + "&epkurl=" + epkurl;

            function myCallback(dialogResult, returnValue){}

        	var options = { url: weburl, width: 800, height: 600, showClose: false, dialogReturnValueCallback:myCallback };

        	SP.UI.ModalDialog.showModalDialog(options);
        }
        else if(commandId === 'BuildTeam')
        {
            var rowId = this.$Grid.getSelectedRowId();

            var weburl = this.$Grid.getUserData(rowId,"SiteUrl");
    	    var webid = this.$Grid.getUserData(rowId,"webid");
    	    var listid = this.$Grid.getUserData(rowId,"listid");
    	    var itemid = this.$Grid.getUserData(rowId,"itemid");

    	    if(weburl == "/")
    		    weburl = "";

    	    weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=BuildTeam&webid=" + webid + "&ListId=" + listid + "&id=" + itemid + "&Source=" + document.location.href;

            var options = { url: weburl, showMaximized: true, showClose: true };

        	SP.UI.ModalDialog.showModalDialog(options);

        }
        else
        {
            var $v_0 = this.getCommandValues(commandId);

            if($v_0 != null && $v_0 != false)
            {
                if(!this.$45_1($v_0, commandId, properties))
                    properties = this.$Grid.handleCommand(this.$Grid, commandId, properties);
            }
            else
                properties = this.$Grid.handleCommand(this.$Grid, commandId, properties);

		    commandId = null;
		    properties = null;
            try
            {
		    e = e||event;

		    if (e.stopPropagation)
			    e.stopPropagation();
		    else
			    e.cancelBubble = true;

            if (window.stop) {
                    window.stop();
                }

                window.stopImmediatePropagation();
            }catch(e){}
        }
    },

    onExportExcelClose: function (result,args){		
	if(result == SP.UI.DialogResult.OK) {
		var vals = args.split("|");
		if(vals[0] == "true"){		 
			if(curGrid._rolluplists != "")
            {
                EnsureSSImporter();
                location.href= this.$curWebUrl + '/_layouts/epmlive/rollupexport.aspx?List=' + curGrid._listid + '&View=' + curGrid._viewid + "&Lists=" + curGrid._rolluplists;
            }
            else
            {
                EnsureSSImporter();
                ExportList(curGrid._excell);
            }
		}
		else{
			Grids["GanttGrid" + curGrid._gridid].ActionExport(); 			
		    }		
	    }	
    },
    
    gridactioncallback: function(dialogResult, returnValue)
	{
        GridCommentsCallBack();
        return;
		//if(dialogResult == 1)
		{
			var weburl = curGrid.getUserData(curRow,"SiteUrl");
			var listid = curGrid.getUserData(curRow,"listid");
			var itemid = curGrid.getUserData(curRow,"itemid");
			var webid = curGrid.getUserData(curRow,"webid");
			var siteid = curGrid.getUserData(curRow,"siteid");

			getSingleItem(siteid,webid,listid,itemid,curRow);
		}
	},

    epmlive_gridaction: function(action, w, rowId)
    {
    	var weburl = this.$Grid.getUserData(rowId,"SiteUrl");
    	var webid = this.$Grid.getUserData(rowId,"webid");
    	var listid = this.$Grid.getUserData(rowId,"listid");
    	var itemid = this.$Grid.getUserData(rowId,"itemid");

        this.$Grid.editStop();

    	if(weburl == "/")
    		weburl = "";

        if (this.$Grid._useparent) {
            var parentid = this.$Grid.getUserData(rowId, "parentitemid");
            if (parentid && parentid != "") {
                var newids = parentid.toString().split(".");
                webid = newids[0];
                listid = newids[1];
                itemid = newids[2];
            }
        }

        if(this.$Grid._usepopup)
    	    weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=" + action + "&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid;
        else
            weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=" + action + "&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + escape(document.location.href);


        if(action == "workplan" || action == "agile")
        {
            window.open(weburl + "&IsDlg=1",'',config='toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');
        }
        else
        {
            if( (action != "edit" && action != "view") || this.$Grid._usepopup)
            {
        	    var options = { url: weburl, width: w, dialogReturnValueCallback:this.gridactioncallback };
                curGrid = this.$Grid;
                curRow = rowId;

                CurrentGrid = Grids["GanttGrid" + this.$Grid._gridid];
                CurrentRow = CurrentGrid.GetRowById(rowId);

        	    SP.UI.ModalDialog.showModalDialog(options);
            }
            else
            {
                location.href = weburl;
            }
        }
    },

    setRowValue: function(rowXml)
    {
    	var rowId = rowXml.getAttribute("id")
    	
    	var cellCounter = 0;

    	for(var i = 0;i<rowXml.childNodes.length;i++)
    	{
    		if(rowXml.childNodes[i].nodeName == "userdata")
    		{
    			if(rowXml.childNodes[i].firstChild != null)
    				this.$Grid.setUserData(rowId,rowXml.childNodes[i].getAttribute("name"),rowXml.childNodes[i].firstChild.nodeValue);
    		}
    		else if(rowXml.childNodes[i].nodeName == "cell")
    		{
    			var cellval = "";
    			var celltype = "";
    			try
    			{
    				celltype = rowXml.childNodes[i].getAttribute("type");
    			}catch(e){}
    			

    			if(rowXml.childNodes[i].childNodes.length > 0)
    			{
    				cellval = rowXml.childNodes[i].firstChild.nodeValue;
    			}

    			if(celltype == "combo")
    				this.$Grid.cells(rowId,cellCounter).setValue(rowXml.childNodes[i]);	
    			else
    				this.$Grid.cells(rowId,cellCounter).setValue(cellval);	
    			cellCounter++;
    		}
    	}
    	
    },

    LinkedItemsButtonPost: function(ret)
    {
         hm("dlgPosting");

         var ticket = ret.xmlDoc.responseText;

         if(ticket.indexOf("General Error") != 0)
         {
             var listInfo = ticket.split('|');

             var weburl = listInfo[0] + "/_layouts/epmlive/gridaction.aspx?action=linkeditems&list=" + listInfo[3] + "&field=" + listInfo[1] + "&LookupFieldList=" + listInfo[2] + "&Source=" + document.location.href;
             var options = { url: weburl, showMaximized: true };

             SP.UI.ModalDialog.showModalDialog(options);
         }
         else
         {
            alert(ticket);
         }
    },

    buttonEnabled: function(index)
    {
    	if(this.$Grid == null)
    		return false;



        if(this.$Grid.getUserData(this.$Grid.getSelectedRowId(),"itemid") == "")
            return false;

        var ids = this.$Grid.getCheckedIds().split(',');

        if(ids.length > 1 || (ids.length > 0 && ids[0] == ""))
            return false;


    	var viewMenus = this.$Grid.getUserData(this.$Grid.getSelectedRowId(),"viewMenus");

    	if(viewMenus==null)
            viewMenus = "1,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0";

    	var arrViewMenus = viewMenus.split(',');

    	if(arrViewMenus[index] == "1")
    		return true;
    	else
    		return false;
    },

    editIn: function($p0, $p1) {
        var $v_0 = new SP.Guid(this.$Grid._listid);
        var $v_1 = new Sys.StringBuilder();
        $v_1.append(SP.PageContextInfo.get_webServerRelativeUrl());
        if ($v_1.toString() !== '/') {
            $v_1.append('/');
        }
        $v_1.append($p0);
        if ($p1) {
            $v_1.append('&ListId=');
            $v_1.append($v_0.toString('B').toUpperCase());
        }
        EditInSPD($v_1.toString(), true);
    },

    navigateToFormPageDesignMode: function(formServerUrl) {ULSMg8:;
        var $v_0 = new SP.Utilities.UrlBuilder(formServerUrl);
        $v_0.addKeyValueQueryString('DisplayMode', 'Design');
        $v_0.addKeyValueQueryString('InitialTabId', 'Ribbon.WebPartPage');
        $v_0.addKeyValueQueryString('VisibilityContext', 'WSSWebPartPage');
        SP.Utilities.HttpUtility.appendSourceAndNavigateTo($v_0.get_url());
    },

    getViewGroupInfo: function() {ULSMg8:;
        if (this.$22_3) {
            return;
        }
        this.$22_3 = true;

        var options = new viewProps(this.$Grid._listid, this.$Grid._viewid, "");

        SP.Application.UI.ViewSelectorMenuBuilder.getViewInformation(this, options);
    },

    onViewInformationReturned: function(viewGroups) {ULSMg8:;            
		var viewControlResult  = viewURLs;		
		var newPublicViewArr = new Array();
		var newPersonalViewArr = new Array();
        var viewDefaultViewUrl = defaultViewUrl;
        var cntDefault=0;

        if(viewDefaultViewUrl != "")
        {            
            if(viewGroups.DefaultView.Id != null)
		    {	
			    var tmpDefault = viewGroups.DefaultView["NavigateUrl"];
			    for(var j=0;j<viewControlResult.length;j++)
			    {
				    if(tmpDefault == viewControlResult[j])				
					    cntDefault++;
			    }
			    if(cntDefault == 0)
				    delete viewGroups.DefaultView;
		    }
         }

        if(viewControlResult != "")
        {

		    if(viewGroups.PublicViews.length > 0)
		    {
			    for(var i=0;i<viewGroups.PublicViews.length;i++)
			    {			
				    for(var j=0;j<viewControlResult.length;j++)
				    {
					    if(viewControlResult[j] != "" && viewGroups.PublicViews[i].NavigateUrl == viewControlResult[j])
					    {
						    newPublicViewArr.push(viewGroups.PublicViews[i]);
					    }
				    }
			    }
			
			    viewGroups.PublicViews.splice(0,viewGroups.PublicViews.length);
			
			    for(var x=0;x<newPublicViewArr.length;x++)
			    {
				    viewGroups.PublicViews.push(newPublicViewArr[x]);
			    }
		    }
        }

		// for the Personal View
		
		<%--if(viewGroups.PersonalViews.length > 0)
		{
			for(var i=0;i<viewGroups.PersonalViews.length;i++)
			{			
				for(var j=0;j<viewControlResult.length;j++)
				{
					if(viewControlResult[j] != "" && viewGroups.PersonalViews[i].NavigateUrl == viewControlResult[j])
					{
						newPersonalViewArr.push(viewGroups.PersonalViews[i]);
					}
				}
			}
			
			viewGroups.PersonalViews.splice(0,viewGroups.PersonalViews.length);
			
			for(var x=0;x<newPersonalViewArr.length;x++)
			{
				viewGroups.PersonalViews.push(newPersonalViewArr[x]);
			}
		}--%>

        this.$3X_3 = viewGroups;
        this.$22_3 = false;
        this.$1Q_3 = this.buildViewMenu(this.$3X_3);
    },

    buildViewMenu: function($p0) {
        var $v_0 = new CUI.JsonXmlElement('Menu', { Id: this.get_viewDropDownIdPrefix() + '.Menu' });
        if ($p0.DefaultView) {
            var $v_1 = $v_0.appendChild('MenuSection', { Title: SP.Res.viewGroupDefault, Id: this.get_viewDropDownIdPrefix() + '.Menu.DefaultView' }).appendChild('Controls', { Id: this.get_viewDropDownIdPrefix() + '.Menu.DefaultView.Controls' });
            this.$29_3($p0.DefaultView.Text, this.get_viewDropDownIdPrefix() + '.Menu.DefaultView.DefaultView.' + $p0.DefaultView.Id.toString(), this.$2F_3($p0.DefaultView), $v_1);
        }
        if ($p0.PersonalViews.length > 0) {
            this.$1T_3(SP.Res.viewGroupPersonal, this.get_viewDropDownIdPrefix() + '.Menu.Personal', $p0.PersonalViews, $v_0);
        }
        if ($p0.PublicViews.length > 0) {
            this.$1T_3(SP.Res.viewGroupPublic, this.get_viewDropDownIdPrefix() + '.Menu.Public', $p0.PublicViews, $v_0);
        }
        if ($p0.ModeratedViews.length > 0) {
            this.$1T_3(SP.Res.viewGroupModerated, this.get_viewDropDownIdPrefix() + '.Menu.Moderated', $p0.ModeratedViews, $v_0);
        }
        if ($p0.OtherViews.length > 0) {
            this.$1T_3(SP.Res.viewGroupOther, this.get_viewDropDownIdPrefix() + '.Menu.Other', $p0.OtherViews, $v_0);
        }
        return $v_0;
    },

    $1T_3: function($p0, $p1, $p2, $p3) {
        var $v_0 = $p3.appendChild('MenuSection', { Id: $p1 });
        if (!SP.Ribbon.SU.$0($p0)) {
            $v_0.get_attributes()['Title'] = $p0;
        }
        var $v_1 = $v_0.appendChild('Controls', { Id: $p1 + '.Controls' });
        for (var $v_2 = 0; $v_2 < $p2.length; $v_2++) {
            if (SP.Application.UI.ViewSelectorSubMenu.isInstanceOfType($p2[$v_2])) {
                var $v_5 = $p2[$v_2];
                this.$4k_3($v_5, $p1, $v_1);
            }
            var $v_3 = $p2[$v_2];
            var $v_4 = this.$2F_3($v_3);
            this.$29_3($v_3.Text, $p1 + '.' + $v_3.Id.toString(), $v_4, $v_1);
        }
    },

    $29_3: function($p0, $p1, $p2, $p3) {
        var $v_0 = (!SP.Ribbon.SU.$2($p0)) ? $p0 : SP.Res.viewGroupDefault;
        $p3.appendChild('Button', { Id: $p1, MenuItemId: $p2, CommandValueId: $p2, CommandType: 'OptionSelection', Command: 'DisplayView', LabelText: $v_0 });
    },

    $4k_3: function($p0, $p1, $p2) {
        var $v_0 = $p1 + '.SubMenu';
        var $v_1 = $p0.Text;
        var $v_2 = SP.Ribbon.SU.$0($v_1);
        var $v_3 = '';
        if (!$v_2) {
            $v_3 = $v_1;
        }
        var $v_4 = $p2.appendChild('FlyoutAnchor', { Id: $v_0, Command: 'PopulateViewDropDown' });
        if (!$v_2) {
            $v_4.get_attributes()['Title'] = $v_3;
        }
        $v_0 += '.Menu';
        var $v_5 = $v_4.appendChild('Menu', { Id: $v_0 });
        $v_0 += '.SubMenu1';
        var $v_6 = $v_5.appendChild('MenuSection', { Id: $v_0 });
        if (!$v_2) {
            $v_6.get_attributes()['Title'] = $v_3;
        }
        var $v_7 = $v_6.appendChild('Controls', { Id: $v_0 + '.Controls' });
        for (var $v_8 = 0; $v_8 < $p0.SubMenuItems.length; $v_8++) {
            var $v_9 = $p0.SubMenuItems[$v_8];
            var $v_A = this.$2F_3($v_9);
            this.$29_3($v_9.Text, $v_0 + '.' + $v_9.Id.toString(), $v_A, $v_7);
        }
    },

    $2F_3: function($p0) {
        return $p0.ActionScriptText;
    },
    
    get_viewDropDownIdPrefix: function() {ULSMg8:;
        return 'Ribbon.List.CustomViews.DisplayView';
    },

    $5k_3: function() {ULSMg8:;
        var $v_0 = new Sys.StringBuilder();
        $v_0.append('<Menu Id=\'Ribbon.List.Settings.ManageWorkflows.Menu\'>');
        $v_0.append('<MenuSection DisplayMode=\'Menu\' Id=\'Ribbon.List.Settings.ManageWorkflows.Menu.Manage\'>');
        $v_0.append('<Controls Id=\'Ribbon.List.Settings.ManageWorkflows.Menu.Manage.Controls\'>');
        $v_0.append('<Button');
        $v_0.append(' Id=\'Ribbon.List.Settings.ManageWorkflows.Menu.Manage.EditSettings\'');
        $v_0.append(' Command=\'');
        $v_0.append('EditWorkflowSettings');
        $v_0.append('\'');
        $v_0.append(' MenuItemId=\'Ribbon.List.Settings.ManageWorkflows.Menu.Manage.WorkflowSettings.Menu\'');
        $v_0.append(' LabelText=\'');
        $v_0.append(SP.Utilities.HttpUtility.htmlEncode(SP.Res.workflowSettingsLabel));
        $v_0.append('\'');
        $v_0.append('/>');
        $v_0.append('<Button');
        $v_0.append(' Id=\'Ribbon.List.Settings.ManageWorkflows.Menu.Manage.Associate\'');
        $v_0.append(' Command=\'');
        $v_0.append('AssociateWorkflows');
        $v_0.append('\'');
        $v_0.append(' MenuItemId=\'Ribbon.List.Settings.ManageWorkflows.Menu.Manage.Associate.Menu\'');
        $v_0.append(' LabelText=\'');
        $v_0.append(SP.Utilities.HttpUtility.htmlEncode(SP.Res.associateWorkflowLabel));
        $v_0.append('\'');
        $v_0.append('/>');
        $v_0.append('</Controls>');
        $v_0.append('</MenuSection>');
        $v_0.append('<MenuSection DisplayMode=\'Menu\' Id=\'Ribbon.List.Settings.ManageWorkflows.Menu.CreateInSP\'>');
        $v_0.append('<Controls Id=\'Ribbon.List.Settings.ManageWorkflows.Menu.CreateInSP.Controls\'>');
        $v_0.append('<Button');
        $v_0.append(' Id=\'Ribbon.List.Settings.ManageWorkflows.Menu.CreateInSP.CreateWorkflowInDesigner\'');
        $v_0.append(' Command=\'');
        $v_0.append('CreateWorkflowInDesigner');
        $v_0.append('\'');
        $v_0.append(' LabelText=\'');
        $v_0.append(SP.Utilities.HttpUtility.htmlEncode(SP.Res.createWorkflowInDesignerLabel));
        $v_0.append('\'');
        $v_0.append('/>');
        $v_0.append('<Button');
        $v_0.append(' Id=\'Ribbon.List.Settings.ManageWorkflows.Menu.CreateInSP.CreateReusableWorkflowInDesigner\'');
        $v_0.append(' Command=\'');
        $v_0.append('CreateReusableWorkflowInDesigner');
        $v_0.append('\'');
        $v_0.append(' LabelText=\'');
        $v_0.append(SP.Utilities.HttpUtility.htmlEncode(SP.Res.createReUsableWorkflowInDesignerLabel));
        $v_0.append('\'');
        $v_0.append('/>');
        $v_0.append('</Controls>');
        $v_0.append('</MenuSection>');
        $v_0.append('</Menu>');
        return $v_0.toString();
    },

    getId: function ContextualTabWebPart_CustomPageComponent$getId() {
        return this._webPartPageComponentId;
    }
    ,

    PopulateModifyViewMenu: function() {
        ULSMg8:;
        var $v_0 = new Sys.StringBuilder();
        $v_0.append('<Menu Id=\'Ribbon.List.CustomViews.ModifyView.Menu\'>');
        $v_0.append('<MenuSection DisplayMode=\'Menu\' Id=\'Ribbon.List.CustomViews.ModifyView.Menu.Manage\'>');
        $v_0.append('<Controls Id=\'Ribbon.List.CustomViews.ModifyView.Menu.Manage.Controls\'>');
        $v_0.append('<Button');
        $v_0.append(' Id=\'Ribbon.List.CustomViews.ModifyView.Menu.Manage.ModifyView\'');
        $v_0.append(' Command=\'');
        $v_0.append('ModifyView');
        $v_0.append('\'');
        $v_0.append(' LabelText=\'');
        $v_0.append(SP.Utilities.HttpUtility.htmlEncode(SP.Res.modifyViewLabel));
        $v_0.append('\'');
        $v_0.append('/>');
        $v_0.append('<Button');
        $v_0.append(' Id=\'Ribbon.List.CustomViews.ModifyView.Menu.Manage.ModifyViewInDesigner\'');
        $v_0.append(' Command=\'');
        $v_0.append('ModifyViewInDesigner');
        $v_0.append('\'');
        $v_0.append(' LabelText=\'');
        $v_0.append(SP.Utilities.HttpUtility.htmlEncode(SP.Res.modifyInDesignerLabel));
        $v_0.append('\'');
        $v_0.append('/>');
        $v_0.append('</Controls>');
        $v_0.append('</MenuSection>');
        $v_0.append('</Menu>');
        return $v_0.toString();
    }
}

function getDropdownItemsXml(menus)
{
    var sb = new Sys.StringBuilder();    
    sb.append('<Menu Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu\'>');    
    sb.append('<MenuSection DisplayMode=\'Menu32\' Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage\'>');    
    sb.append('<Controls Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage.Controls\'>');
    sb.append(menus);
    sb.append('</Controls>');
    sb.append('</MenuSection>');    
    sb.append('</Menu>');    
    return sb.toString();
}

function getFormItemsXml(menus)
{
    var sb = new Sys.StringBuilder();    
    sb.append('<Menu Id=\'Ribbon.List.Settings.EditDefaultForms.Menu\'>');    
    sb.append('<MenuSection Id=\'Ribbon.List.Settings.EditDefaultForms.Menu.Default\' Scrollable=\'false\' DisplayMode=\'Menu16\'>');
    sb.append('<Controls Id=\'Ribbon.List.Settings.EditDefaultForms.Menu.Default.Controls\'>');
    sb.append(menus);
    sb.append('</Controls>');
    sb.append('</MenuSection>');    
    sb.append('</Menu>');    
    return sb.toString();
}


ContextualTabWebPart.CustomPageComponent.registerClass('ContextualTabWebPart.CustomPageComponent', CUI.Page.PageComponent);
SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("GridViewContextualTabPageComponent.js");