function RPEditor(thisID, params) {
    RPEditor.prototype.OnLoad = function (event) {
        try {
            Grids.OnValueChanged = GridsOnValueChangedDelegate;
            Grids.OnAfterValueChanged = GridsOnAfterValueChangedDelegate;
            Grids.OnAfterSave = GridsOnAfterSaveDelegate;
            Grids.OnFocus = GridsOnFocusDelegate;
            Grids.OnReady = GridsOnReadyDelegate;
            Grids.OnRenderFinish = GridsOnRenderFinishDelegate;
            Grids.OnScroll = GridsOnScrollDelegate;
            Grids.OnSectionResize = GridsOnSectionResizeDelegate;
            Grids.OnAfterColResize = GridsOnAfterColResizeDelegate;
            Grids.OnStartDrag = GridsOnStartDragDelegate;
            Grids.OnStartDragCell = GridsOnStartDragCellDelegate;
            Grids.OnMoveDragCell = GridsOnMoveDragCellDelegate;
            Grids.OnEndDragCell = GridsOnEndDragCellDelegate;
            Grids.OnCanDrop = GridsOnCanDropDelegate;
            Grids.OnEndDrag = GridsOnEndDragDelegate;
            Grids.OnStartEdit = GridsOnStartEditDelegate;
            Grids.OnGetInputValue = GridsOnGetInputValueDelegate;
            Grids.OnSetInputValue = GridsOnSetInputValueDelegate;
            Grids.OnMouseDown = GridsOnMouseDownDelegate;
            Grids.OnDblClick = GridsOnDblClickDelegate;
            Grids.OnTip = GridsOnTipDelegate;
            Grids.OnClickCell = GridsOnClickCellDelegate;
            Grids.OnDataSend = GridsOnDataSendDelegate;
            Grids.OnAfterColumnsChanged = GridsOnAfterColumnsChangedDelegate;
            Grids.OnFilter = GridsOnFilterDelegate;
            Grids.OnRowFilter = GridsOnRowFilterDelegate;
            Grids.OnFilterFinish = GridsOnFilterFinishDelegate;
            //Grids.OnGroup = GridsOnGroupDelegate;
            //Grids.OnGroupFinish = GridsOnGroupFinishDelegate;

            if ((this.params.TicketVal == "" && this.params.WEPID == "")) {
                var sbDataxml = new StringBuilder();
                sbDataxml.append('<Execute Function="GetPIList">');
                sbDataxml.append('</Execute>');
                this.ExecuteJSON(sbDataxml.toString());
            }
            else {
                var sbDataxml = new StringBuilder();
                sbDataxml.append('<Execute Function="GetMetaData">');
                sbDataxml.append('<Wepid>' + this.params.WEPID + '</Wepid>');
                sbDataxml.append('<TicketVal>' + this.params.TicketVal + '</TicketVal>');
                sbDataxml.append('<IsResource>' + this.params.IsResource + '</IsResource>');
                sbDataxml.append('</Execute>');
                this.ExecuteJSON(sbDataxml.toString());
            }
        }
        catch (e) {
            this.HandleException("OnLoad", e);
        }
    };
    RPEditor.prototype.SelectPIsOK = function () {
        var arrPIs = this.arrPIs;
        var spis = "";
        for (var i = 0; i < arrPIs.length; i++) {
            var pi = document.getElementById("idPIListItem_" + i);
            if (pi.checked == true) {
                if (spis == "")
                    spis = this.arrPIs[i].wepid;
                else
                    spis += "," + this.arrPIs[i].wepid;
            }
        }
        if (spis == "") {
            alert("Please select one or more Portfolio Items to continue");
            return;
        }
        var sb = new StringBuilder();
        sb.append('<Execute Function="CreateTicket" Context="ResourcePlanner">');
        sb.append('<Data>' + spis + '</Data>');
        sb.append('</Execute>');
        this.ExecuteJSON(sb.toString(), "GeneralFunctions");
    };
    RPEditor.prototype.GridsOnDataSend = function (grid, source, data, Func) {
        if (grid.id != "g_RPE")
            return null;

        if (source.Name == "Upload") {
            return '<Execute Function="SaveResourcePlan">' + data + '</Execute>';
        }
        return null;
    };
    RPEditor.prototype.ShowHidePeriods = function (grid) {
        var start = 0;
        if (this.startPeriod != null) start = this.startPeriod;
        var finish = 99999;
        if (this.finishPeriod != null) finish = this.finishPeriod;
        var length = grid.ColNames[2].length;
        var hide = [];
        var show = [];
        for (var c = 0; c < length; c++) {
            var col = grid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var periodid = parseInt(col.substring(1));
                if (periodid < start || periodid > finish)
                    hide.push(col);
                else
                    show.push(col);
            }
        }
        grid.ChangeColsVisibility(show, hide, 0);
    };
    RPEditor.prototype.ExecuteJSON = function (Dataxml, serverFunction) {
        if (typeof serverFunction != "string") serverFunction = "ResourcePlans";
        WorkEnginePPM.RPEditor.set_path(this.params.Webservice);
        WorkEnginePPM.RPEditor.ExecuteJSON(serverFunction, Dataxml, ExecuteCompleteDelegate);
    };
    RPEditor.prototype.ExecuteComplete = function (jsonString) {
        try {
            var json = JSON_ConvertString(jsonString);
            var result = json.Result;
            if (result.Message != null && result.Message != "")
                alert(result.Message);
            switch (parseInt(result.Status)) {
                case 50: /* rsSecurityAccessDenied */
                    window.setTimeout("parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');", 100);
                    return;
                case 51: /* rsSecurityNoProjects */
                    window.setTimeout("parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');", 100);
                    return;
                case 52: /* rsSecurityNoResources */
                    window.setTimeout("parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');", 100);
                    return;
            }
            var error = result.Error;
            if (error != null) {
                alert(error.Value);
                window.setTimeout("parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');", 100);
                return;
            }
            var func = result.Function;
            switch (func) {
                case "GetPIList":
                    var pis = result.PIs;
                    var idPIListDiv = document.getElementById('idPIListDiv');
                    var shtml = "";
                    this.arrPIs = pis.PI;
                    for (var i = 0; i < this.arrPIs.length; i++) {
                        shtml += '<input id="idPIListItem_' + i + '" type="checkbox" />' + this.arrPIs[i].name + '<br />';
                    }
                    idPIListDiv.innerHTML = shtml;
                    this.DisplayDialog(20, 30, 260, 220, "Select Portfolio Item(s)", "winSelectPIsDlg", "idSelectPIsDlgDiv", true, false);
                    break;
                case "GetMetaData":
                    this.NegotiationMode = (result.NegotiationMode != 0);
                    this.costCategoryRoles = result.CostCategoryRoles;
                    var views = result.Views;
                    this.Views = JSON_GetArray(views, "View");
                    this.InitializeLayout();
                    break;
                case "SaveResourcePlanView":
                    var view = result.View;
                    var bFound = false;
                    var select = document.getElementById("idViewTab_SelView");
                    if (select.options.length == 1 && select.options[0].value == "-1") {
                        select.options[0] = null;
                    } else {
                        for (var i = 0; i < select.options.length; i++) {
                            if (select.options[i].value == view.ViewGUID) {
                                select.options[i].text = view.Name;
                                bFound = true;
                                this.Views[i] = view;
                                break;
                            }
                        }
                    }
                    if (bFound == false) {
                        select.options[select.options.length] = new Option(view.Name, view.ViewGUID, true, true);
                        this.Views.push(view);
                    }
                    if (view.Default == true) {
                        for (var i = 0; i < this.Views.length; i++) {
                            if (this.Views[i].ViewGUID != view.ViewGUID)
                                this.Views[i].Default = false;
                        }
                    }
                    this.externalEvent('SaveView_Cancel');
                    break;
                case "PostCostValues":
                    break;
                case "DeleteResourcePlanView":
                    if (result.View != null) {
                        var viewGUID = result.View.ViewGUID;
                        var select = document.getElementById("idViewTab_SelView");
                        for (var i = 0; i < select.options.length; i++) {
                            if (select.options[i].value == viewGUID) {
                                select.options[i] = null;
                                if (select.options.length == 0) {
                                    select.options[select.options.length] = new Option("--No Views--", "-1", false, false);
                                }
                                this.viewTab.refreshSelect("idViewTab_SelView");
                                for (var i = 0; i < this.Views.length; i++) {
                                    var view = this.Views[i];
                                    if (view != null && view.ViewGUID == viewGUID) {
                                        delete this.Views[i];

                                        break;
                                    }
                                }
                                this.externalEvent('DeleteView_Cancel');
                                this.externalEvent('ViewTab_SelView_Changed');
                                break;
                            }
                        }
                    }
                    else
                        alert("No View Found");
                    break;
                case "AddNote":
                    this.RefreshNotesDialog(null);
                    break;
                case "GetRowNote":
                    var planrowGuid = result.guid;
                    var planrow = this.FindPlanRow(planrowGuid);
                    if (result.RowNote == null) {
                        var oNote = this.NoteInitialize(planrow, "CreateRowNote", "");
                        this.DisplayRowNoteDialog(oNote);
                    }
                    else {
                        var html = result.RowNote.HTML;
                        var oNote = this.NoteInitialize(planrow, "EditRowNote", html);
                        this.DisplayRowNoteDialog(oNote);
                    }
                    break;
                case "GetRowEvents":
                    var planrowGuid = result.guid;
                    var planrow = this.FindPlanRow(planrowGuid);
                    var html = result.HTML;
                    this.DisplayNotificationDialog(planrow, html);
                    break;
                case "SaveRowNote":
                    break;
                case "SynchronizeTeam":
                    break;
                case "GetImportWorkHours":
                    this.ImportResourceWork(result.Resources);
                    break;
                case "ReadCalendarCosttypeCombinations":
                    this.DisplayImportCostsDialog(result.Costtypes);
                    break;
                case "GetImportCostPlanHours":
                    this.ApplyCostValues(result.CostValues);
                    break;
                case "CreateTicket":
                    switch (result.Context) {
                        case "ResourceAnalyzer":
                            var docurl = document.location.pathname.replace("rpeditor", "rpanalyzer");
                            var weburl = docurl + "?dataid=" + result.Ticket + "&IsDlg=1&rpemode=1";
                            var options = { url: weburl, width: 800, height: 600, showClose: true, dialogReturnValueCallback: dialogCallbackDelegate };
                            parent.SP.UI.ModalDialog.showModalDialog(options);
                            break;
                        case "ResourcePlanner":
                            this.dhxWins_CloseDialog("winSelectPIsDlg");
                            this.params.TicketVal = result.Ticket;
                            var sbDataxml = new StringBuilder();
                            sbDataxml.append('<Execute Function="GetMetaData">');
                            sbDataxml.append('<Wepid>' + this.params.WEPID + '</Wepid>');
                            sbDataxml.append('<TicketVal>' + this.params.TicketVal + '</TicketVal>');
                            sbDataxml.append('<IsResource>' + this.params.IsResource + '</IsResource>');
                            sbDataxml.append('</Execute>');
                            this.ExecuteJSON(sbDataxml.toString());
                            break;
                    }
                    break;
                default:
                    alert("ExecuteComplete unknown reply - " + jsonString);
                    break;
            }
        }
        catch (e) {
            this.HandleException("ExecuteComplete", e);
        }
    };
    RPEditor.prototype.DisplayImportCostsDialog = function (costtypes) {
        if (costtypes != null) {
            var cts = JSON_GetArray(costtypes, "Costtype");

            var select = document.getElementById("idSelCTCols");
            select.options.length = 0;
            if (cts.length == 0) {
                alert("There are no cost values available for import");
                return;
            }
            for (var i = 0; i < cts.length; i++) {
                select.options[select.options.length] = new Option(cts[i].ctName, cts[i].ctId + "," + cts[i].cbId);
            }
            select.selectedIndex = 0;
            this.DisplayDialog(20, 30, 280, 220, "Import Cost Values", "winSelectCostValuesDlg", "idSelectCostValuesDlg", true, false);
        }
    };
    RPEditor.prototype.ImportCostValues = function () {
        var select = document.getElementById("idSelCTCols");
        if (select.selectedIndex < 0)
            alert("");
        else {
            var sArr = select.options[select.selectedIndex].value.split(",");
            var ctId = sArr[0];
            var cbId = sArr[1];
            var sbd = new StringBuilder();
            sbd.append('<Execute Function="GetImportCostPlanHours">');
            var projectuid = this.plangrid.GetAttribute(this.planrow, null, "Project_UID");
            sbd.append('<ProjectID>' + projectuid.toString() + '</ProjectID>');
            sbd.append('<ctId>' + ctId.toString() + '</ctId>');
            sbd.append('<cbId>' + cbId.toString() + '</cbId>');
            sbd.append('</Execute>');

            this.ExecuteJSON(sbd.toString());
        }
    };
    RPEditor.prototype.CopyRowAttribute = function (grid, from, to, attr) {
        grid.SetAttribute(to, null, attr, grid.GetAttribute(from, null, attr), 0, 0);
    };
    RPEditor.prototype.ApplyCostValues = function (costValues) {
        var tempmode;
        try {
            if (costValues == null) {
                alert("No cost values found");
                return;
            }
            else {
                var cvs = JSON_GetArray(costValues, "CostValue");
                var plangrid = this.plangrid;
                var projectRow = this.planrow;
                tempmode = this.displayMode;
                this.displayMode = 0;
                for (var i = 0; i < cvs.length; i++) {
                    var cv = cvs[i];
                    var planrow = plangrid.AddRow(projectRow, null, true);
                    planrow.NoColorState = 1;
                    plangrid.SetAttribute(planrow, null, "UserCanEdit", 1, 0, 0);

                    var projectid = plangrid.GetAttribute(projectRow, null, "Project_UID");
                    var projectname = plangrid.GetAttribute(projectRow, null, "Project_Name");
                    plangrid.SetAttribute(planrow, null, "Project_UID", projectid, 0, 0);
                    plangrid.SetValue(planrow, "Project_Name", projectname, 1);
                    var guid = new Guid();
                    plangrid.SetAttribute(planrow, null, "Group", guid.newGuid(), 0, 0);
                    plangrid.SetAttribute(planrow, null, "GUID", guid.newGuid(), 0, 0);
                    plangrid.SetAttribute(planrow, null, "Status", const_Commitment, 0, 0);
                    plangrid.SetAttribute(planrow, null, "Private", 1, 0, 0);
                    var parentctId = 0;
                    var roleUid = 0;
                    var roleName = "";
                    var ccroleName = "";
                    var ccroleParentName = "";
                    if (this.ccrolesArray != null) {
                        var ccrole = this.ccrolesArray[cv.bcUid];
                        if (ccrole != null) {
                            parentctId = ccrole.ParentID;
                            roleUid = ccrole.RoleUID;
                            roleName = ccrole.Name;
                            ccroleName = ccrole.ParentName + "." + ccrole.Name;
                            ccroleParentName = ccrole.ParentName;
                        }
                    }
                    plangrid.SetAttribute(planrow, null, "CCRole_UID", cv.bcUid, 0, 0);
                    plangrid.SetAttribute(planrow, null, "CCRoleParent_UID", parentctId, 0, 0);
                    plangrid.SetAttribute(planrow, null, "Role_UID", roleUid, 0, 0);
                    plangrid.SetAttribute(planrow, null, "Dept_UID", 0, 0, 0);
                    plangrid.SetAttribute(planrow, null, "ActiveCommitment", 0, 0, 0);

                    plangrid.SetValue(planrow, "CCRole_Name", ccroleName, 1);
                    plangrid.SetValue(planrow, "CCRoleParent_Name", ccroleParentName, 1);
                    plangrid.SetValue(planrow, "Role_Name", roleName, 1);
                    plangrid.SetValue(planrow, "Dept_Name", "", 1);
                    this.SetResNamesColumn(plangrid, planrow, const_Commitment);
                    plangrid.SetValue(planrow, "ItemName", "***Add Resource***", 1);
                    var colhours = [];
                    var periods = cv.periods.split(',');
                    var hours = cv.hours.split(',');
                    for (var j = 0; j < periods.length; j++) {
                        var col = "Q" + periods[j].toString();
                        colhours[col] = hours[j];
                    }
                    var length = plangrid.ColNames[2].length;
                    for (var c = 0; c < length; c++) {
                        var col = plangrid.ColNames[2][c];
                        var newhours = colhours[col];
                        if (newhours == null) newhours = 0;
                        this.SetPeriodValue(plangrid, planrow, col, newhours);
                    }
                    this.RefreshPlanRowPeriods(plangrid, planrow, true);
                    plangrid.RefreshRow(planrow);
                }
                if (tempmode != null) {
                    this.displayMode = tempmode;
                }
            }
            this.UpdateButtonsAsync();
        }
        catch (e) {
            this.HandleException("ApplyCostValues", e);
        }
    };
    RPEditor.prototype.PopulatePeriodDropdown = function (elementid, selectMode) {
        //selectMode 0=none; 1=first;2=last; 3=firstvisible; 4=lastvisible
        var from = document.getElementById(elementid);
        from.options.length = 0;
        from.options.selectedIndex = -1;
        var grid = this.plangrid;
        var periodIndex = -1;
        for (var c = 0; c < grid.ColNames[2].length; c++) {
            var col = grid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var isVisible = grid.GetAttribute(null, col, "Visible");
                var sPeriod = grid.GetCaption(col);
                var periodid = parseInt(col.substring(1));
                from.options[from.options.length] = new Option(sPeriod, periodid);
                if (selectMode == 1 && periodIndex == -1)
                    periodIndex = from.options.length - 1;
                if (isVisible != 0) {
                    if (selectMode == 3 && periodIndex == -1)
                        periodIndex = from.options.length - 1;
                }
                if (selectMode == 2)
                    periodIndex = from.options.length - 1;
                if (selectMode == 4 && isVisible != 0)
                    periodIndex = from.options.length - 1;
            }
        }
        from.options.selectedIndex = periodIndex;
    };
    RPEditor.prototype.ImportResourceWork = function (resources) {
        var tempmode = null;
        var bChanges = false;
        var changedplanrows = [];
        var plangrid = this.plangrid;
        var projectID = plangrid.GetAttribute(this.planrow, null, "Project_UID");
        var projectRow = this.FindProjectRow(projectID);
        try {
            if (resources == null) {
                alert("No work found for " + this.importWorkProjectName);
                return;
            }
            else {
                this.importWorkResources = JSON_GetArray(resources, "Resource");
                var idWorkStatusDiv = document.getElementById('idWorkStatusDiv');
                var shtml = "";
                for (var i = 0; i < this.importWorkResources.length; i++) {
                    var resource = this.importWorkResources[i];
                    var WResID = resource.WResID;
                    var nCount = this.CountResourcePlanRows(projectRow, resource.WResID);
                    var option = document.createElement("option");
                    var resrow = this.FindResourceRow(WResID);
                    if (resrow != null) {
                        var resName = this.resgrid.GetAttribute(resrow, null, "Res_Name");
                        switch (nCount) {
                            case 0:
                                shtml += '<label id="idWorkItemLabel_' + i + '"><input id="idWorkItem_' + i + '" type="checkbox" checked="checked" />' + resName + ' will be added to a new plan row' + '<br /></label>';
                                break;
                            case 1:
                                shtml += '<label id="idWorkItemLabel_' + i + '"><input id="idWorkItem_' + i + '" type="checkbox" checked="checked" />' + resName + ' plan row will be updated' + '<br /></label>';
                                break;
                            default:
                                shtml += '<label id="idWorkItemLabel_' + i + '"><input id="idWorkItem_' + i + '" type="checkbox"  />' + 'WARNING: ' + resName + ' found on ' + nCount + ' plan rows only first found will be updated' + '<br /></label>';
                                break;
                        }
                    }
                    else {
                    }
                }
                idWorkStatusDiv.innerHTML = shtml;
                //selectMode 0=none; 1=first;2=last; 3=firstvisible; 4=lastvisible
                this.PopulatePeriodDropdown("idWorkStart", 3);
                this.PopulatePeriodDropdown("idWorkFinish", 4);
                this.DisplayDialog(20, 30, 450, 280, "Import Work for " + this.importWorkProjectName, "winImportWorkDlg", "idImportWorkDlg", true, true);
            }
        }
        catch (e) {
            this.HandleException("ApplyResourceWork", e);
        }
    };
    RPEditor.prototype.ApplyResourceWork = function () {
        if (this.importWorkResources != null) {
            var tempmode = null;
            var bChanges = false;
            var changedplanrows = [];
            var plangrid = this.plangrid;
            tempmode = this.displayMode;
            this.displayMode = 0;
            var i = 0;
            var cblabel = document.getElementById('idWorkItemLabel_' + i);
            var cb = document.getElementById('idWorkItem_' + i);
            var projectID = plangrid.GetAttribute(this.planrow, null, "Project_UID");
            var projectRow = this.FindProjectRow(projectID);
            while (cb != null) {
                if (cb.checked == true && cblabel.style.display != "none") {
                    var resource = this.importWorkResources[i];
                    var WResID = resource.WResID;
                    var planrow = this.FindChildPlanRow(projectRow, resource.WResID);
                    if (planrow == null) {
                        var projectName = plangrid.GetAttribute(projectRow, null, "Project_Name");
                        var resrows = [];
                        resrows[0] = this.FindResourceRow(WResID);
                        planrow = this.AddRowsToPlan(projectRow, resrows, projectID, projectName, false);
                        bChanges = true;
                    }
                    var colhours = [];
                    var periods = resource.Periods.split(',');
                    var hours = resource.Hours.split(',');
                    for (var j = 0; j < periods.length; j++) {
                        var col = "Q" + periods[j].toString();
                        colhours[col] = hours[j];
                    }
                    var length = plangrid.ColNames[2].length;
                    var from = document.getElementById("idWorkStart");
                    var to = document.getElementById("idWorkFinish");

                    var fromPeriod = parseInt(from.options[from.options.selectedIndex].value);
                    var toPeriod = parseInt(to.options[to.options.selectedIndex].value);
                    for (var c = 0; c < length; c++) {
                        var col = plangrid.ColNames[2][c];
                        var periodid = parseInt(col.substring(1));
                        if (periodid >= fromPeriod && periodid <= toPeriod) {
                            var newhours = colhours[col];
                            var oldhours = this.GetPeriodValue(plangrid, planrow, col);
                            if (newhours != oldhours) {
                                bChanges = true;
                                if (newhours == null) newhours = 0;
                                this.SetPeriodValue(plangrid, planrow, col, newhours);
                                changedplanrows[changedplanrows.length] = planrow;
                            }
                        }
                    }
                    cblabel.style.display = "none";
                }
                i++;
                cblabel = document.getElementById('idWorkItemLabel_' + i);
                cb = document.getElementById('idWorkItem_' + i);
            }
            if (tempmode != null) {
                this.displayMode = tempmode;
            }
            if (bChanges == true) {
                var length = changedplanrows.length;
                for (var i = 0; i < length; i++) {
                    this.RefreshPlanRowPeriods(plangrid, changedplanrows[i], true);
                    plangrid.RefreshRow(changedplanrows[i]);
                }
                alert("Import values have been applied for selected rows and period range.");
            }
            else
                alert("Import did not change any values");
            this.UpdateButtonsAsync();

        }
    };
    RPEditor.prototype.CountResourcePlanRows = function (planprojectrow, res_uid) {
        var nCount = 0;
        try {
            if (planprojectrow.firstChild != null) {
                if (res_uid != null) {
                    var plangrid = this.plangrid;
                    if (plangrid.RowCount > 0) {
                        var planrow = planprojectrow.firstChild;
                        while (planrow != null) {
                            var wresId = plangrid.GetAttribute(planrow, null, "Res_UID");
                            if (res_uid == wresId) {
                                nCount++;
                            }
                            else {
                                wresId = plangrid.GetAttribute(planrow, null, "PendingRes_UID");
                                if (res_uid == wresId) {
                                    nCount++;
                                }
                            }
                            planrow = plangrid.GetNextSibling(planrow);
                        }
                    }
                }
            }
        }
        catch (e) {
            this.HandleException("CountResourcePlanRows", e);
        }
        return nCount;
    };
    RPEditor.prototype.FindChildPlanRow = function (planprojectrow, res_uid) {
        try {
            if (planprojectrow.firstChild != null) {
                if (res_uid != null) {
                    var plangrid = this.plangrid;
                    if (plangrid.RowCount > 0) {
                        var planrow = planprojectrow.firstChild;
                        while (planrow != null) {
                            var wresId = plangrid.GetAttribute(planrow, null, "Res_UID");
                            if (res_uid == wresId) {
                                return planrow;
                            }
                            else {
                                wresId = plangrid.GetAttribute(planrow, null, "PendingRes_UID");
                                if (res_uid == wresId) {
                                    return planrow;
                                }
                            }
                            planrow = plangrid.GetNextSibling(planrow);
                        }
                    }
                }
            }
        }
        catch (e) {
            this.HandleException("FindChildPlanRow", e);
        }
        return null;
    };
    RPEditor.prototype.GetFTEConv = function (ccruid, periodId, grid, row) {
        try {
            var key = ccruid + "P" + periodId.toString();
            var ftetohours = this.ccrFTEArray[key];

            if (isNaN(ftetohours))
                ftetohours = 100;

            var resrow;
            switch (grid.id) {
                case "g_RPE":
                    var resuid = this.plangrid.GetAttribute(row, null, "Res_UID");
                    resrow = this.resgrid.GetRowById(resuid);
                    break;
                case "g_Res":
                    resrow = row;
                    break;
            }

            var fOff = 0;
            if (resrow) {
                var off = this.resgrid.GetAttribute(resrow, null, "O" + periodId);
                var fO = parseInt(off);
                if (isNaN(fO) == false)
                    fOff = fO;
            }

            if (isNaN(fOff))
                fOff = 0;

            return ftetohours - fOff;
        }
        catch (e) {
            return 100;
        }
    };
    RPEditor.prototype.GetSelectedView = function () {
        try {
            var selectView = document.getElementById("idViewTab_SelView");
            if (selectView.selectedIndex >= 0) {
                var selectedItem = selectView.options[selectView.selectedIndex];
                if (selectedItem.value != null && selectedItem.value != "-1") {
                    if (this.Views != null) {
                        for (var i = 0; i < this.Views.length; i++) {
                            var view = this.Views[i];
                            if (view != null) {
                                if (view.ViewGUID == selectedItem.value) {
                                    return view;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (e) {
            this.HandleException("GetSelectedView", e);
        }
        return null;
    };
    RPEditor.prototype.ApplyGridView = function (gridId, view, bRender) {
        try {
            if (gridId == "g_Notes")
                return;
            this.bInColResize = true;

            var grid = Grids[gridId];
            var gridView = view[gridId];
            var allCols = new Array();

            if (gridView.LeftCols !== null) {
                var leftCols = gridView.LeftCols.split(',');
                leftCols.reverse();
                for (var c in leftCols) {
                    var cv = leftCols[c].split(':');
                    var col = cv[0];

                    Array.add(allCols, col);

                    try {
                        var width = cv[1] - grid.Cols[col].Width;

                        if (width !== 0) {
                            grid.SetWidth(col, width);
                        }
                    } catch (e) { }
                }
            }
            if (gridView.RightCols !== null) {
                var max = 45;
                var rightCols = gridView.RightCols.split(',');
                for (var c = rightCols.length - 1; c >= 0; c--) {
                    var cv = rightCols[c].split(':');
                    var width = parseInt(cv[1]);
                    if (width > max)
                        max = width;
                }
                this.SetPeriodColsWidth(grid, max, true);
            }

            if (gridView.Cols !== null) {
                var cols = gridView.Cols.split(',');
                cols.reverse();
                for (var c in cols) {
                    var cv = cols[c].split(':');
                    var col = cv[0];

                    Array.add(allCols, col);

                    try {
                        var width = cv[1] - grid.Cols[col].Width;
                        if (width !== 0) {
                            grid.SetWidth(col, width);
                        }
                    } catch (e) { }

                    if (col != "P1" && col != "P2")
                        grid.MoveCol(col, 1, 0, 1);
                }
            }

            var groupCols = grid.Group.split(',');

            //try { grid.DoGrouping(null); } catch (e) { };

            for (var i = 0; i < groupCols.length; i++) {
                grid.HideCol(groupCols[i]);
            }

            var vCols = grid.GetCols('Visible');
            vCols = vCols.concat(groupCols);

            var mainCols = [];

            for (var i = 0; i < vCols.length; i++) {
                var canHide = grid.GetAttribute(null, vCols[i], "CanHide");
                if (canHide != 0) {
                    var found = false;
                    for (var j = 0; j < allCols.length; j++) {
                        if (allCols[j] === vCols[i]) {
                            found = true;
                        }
                    }

                    if (!found) {
                        mainCols.push(vCols[i]);
                    }
                }
            }

            grid.ChangeColsVisibility(allCols, mainCols, 0);

            if (gridView['Filters'] === '') {
                grid.ChangeFilter('', '', '', 0, 0, null);
            } else {
                var filters = gridView['Filters'].split('|');

                if (filters[0] === '1') {
                    this.showFilters(grid);
                } else {
                    this.hideFilters(grid);
                }

                filters[1] = filters[1].replace(",", ":");

                var filter = filters[1].split(':');

                var colvals = new Array();
                var valvals = new Array();
                var opvals = new Array();

                if (filter.length > 2) {
                    var xi = 0;

                    for (var xj = 0; xj < filter.length; xj++) {
                        ++xi;
                        if (xi == 1)
                            colvals[colvals.length] = filter[xj];

                        else if (xi == 2)
                            valvals[valvals.length] = filter[xj];

                        else {
                            opvals[opvals.length] = filter[xj];
                            xi = 0;
                        }
                    }
                }

                try { grid.ChangeFilter(colvals, valvals, opvals, 0, 0, null); } catch (e) { };
            }

            //grid.ChangeSort(gridView['Sorting']);

            if (gridView['Grouping'] === '') {
                //try { grid.DoGrouping(null); } catch (e) { };
            } else {
                var grouping = gridView['Grouping'].split('|');

                if (grouping[0] === '1') {
                    this.showGrouping(grid);
                } else {
                    this.hideGrouping(grid);
                }
                grid.Group = grouping[1];
                //try { grid.DoGrouping(grouping[1]); } catch (e) { };
            }
            if (view.Settings != null) {
                var displayMode = parseInt(view.Settings.displayMode);
                if (displayMode != null && displayMode != this.displayMode) {
                    this.displayMode = displayMode;
                    this.viewTab.selectByValue("idViewTab_DisplayedValues", this.displayMode);
                }
                var resourceDisplayMode = view.Settings.ResourceDisplayMode;
                if (resourceDisplayMode != null && resourceDisplayMode != this.ResourceDisplayMode) {
                    this.ResourceDisplayMode = resourceDisplayMode;
                    this.resourcesTab.selectByValue("idResourcesTab_ShowMe", this.ResourceDisplayMode);
                }
                var resourcesSelectMode = parseInt(view.Settings.ResourcesSelectMode);
                if (resourcesSelectMode != null && resourcesSelectMode != 4) {
                    this.ResourcesSelectMode = resourcesSelectMode;
                    this.resourcesTab.selectByValue("idResourcesTab_Select", this.ResourcesSelectMode);
                }
                if (view.Settings.UseCurrentPeriod != null) {
                    var UseCurrentPeriod = parseInt(view.Settings.UseCurrentPeriod);
                    if (UseCurrentPeriod == 1) {
                        this.startPeriod = this.currentPeriod;
                        var from = document.getElementById('idViewTab_FromPeriod');
                        from.options.selectedIndex = 0;
                    }
                }
            }

            if (bRender)
                grid.Render();
        } catch (e) {
            this.HandleException("ApplyGridView", e);
        }
        this.bInColResize = false;
    };
    RPEditor.prototype.HandleException = function (name, e) {
        alert("Exception thrown in function " + name + "\n\n" + e.toString());
    };
    RPEditor.prototype.HandleServerError = function (error) {
        alert("Server returned error id : " + error.ID + "\n\n" + error.Value);
    };
    RPEditor.prototype.showFilters = function (grid) {
        grid.ShowRow(grid.GetRowById("Filter"));
        switch (grid.id) {
            case "g_RPE":
                this.viewTab.setButtonStateOn("idViewTab_ShowFilters");
                break;
            case "g_Res":
                this.resourcesTab.setButtonStateOn("idResourcesTab_ShowFilters");
                break;
        }
    };
    RPEditor.prototype.hideFilters = function (grid) {
        grid.HideRow(grid.GetRowById("Filter"));
        switch (grid.id) {
            case "g_RPE":
                this.viewTab.setButtonStateOff("idViewTab_ShowFilters");
                break;
            case "g_Res":
                this.resourcesTab.setButtonStateOff("idResourcesTab_ShowFilters");
                break;
        }
    };
    RPEditor.prototype.showGrouping = function (grid) {
        var groupRow = this.getGroupRow(grid);
        if (groupRow != null) {
            groupRow.Visible = 1;
        }
        switch (grid.id) {
            case "g_RPE":
                break;
            case "g_Res":
                this.resourcesTab.setButtonStateOn("idResourcesTab_ShowGrouping");
                break;
        }
    };
    RPEditor.prototype.getGroupRow = function (grid) {
        var solid = grid.Solid;
        var childrow = solid.firstChild;
        while (childrow != null) {
            if (childrow.Kind === 'Group') {
                return childrow;
            }
            childrow = childrow.nextSibling;
        }
        return null;
    };
    RPEditor.prototype.hideGrouping = function (grid) {
        var groupRow = this.getGroupRow(grid);
        if (groupRow != null) {
            groupRow.Visible = 0;
        }
        switch (grid.id) {
            case "g_RPE":
                break;
            case "g_Res":
                this.resourcesTab.setButtonStateOff("idResourcesTab_ShowGrouping");
                break;
        }
    };
    RPEditor.prototype.InitializeLayout = function () {
        try {

            this.ccrolesArray = [];
            this.ccrFTEArray = [];

            var ccroles = this.costCategoryRoles;
            if (ccroles != null && ccroles.CostCategoryRole != null) {
                for (var i = 0; i < ccroles.CostCategoryRole.length; i++) {
                    var ccr = ccroles.CostCategoryRole[i];
                    var ccruid = ccr.ID.toString();
                    this.ccrolesArray[ccruid] = ccr;
                    if (ccr.Periods != null) {
                        var periods = ccr.Periods.split(',');
                        var ftetohours = ccr.FTEToHours.split(',');
                        for (var j = 0; j < periods.length; j++) {
                            var key = ccruid + "P" + periods[j].toString();
                            this.ccrFTEArray[key] = ftetohours[j];
                        }
                    }
                }
            } else {
                alert("No Cost Category Roles have been configured.\n\nPlease contact your System Administrator for more information.");
                window.setTimeout("parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');", 100);
                return;
            }

            var bIsCloseDisabled = true;
            if (this.params.IsDlg == "1")
                bIsCloseDisabled = false;
            var editorTabData = {
                parent: "idEditorTabDiv",
                style: "display:none;",
                showstate: "true",
                initialstate: "expanded",
                onstatechange: "dialogEvent('PlanRibbon_Toggle');",
                imagePath: this.imagePath,
                sections: [
                    {
                        name: "Plan Actions",
                        tooltip: "Plan Actions",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", id: "SavePlanBtn", name: "Save", img: "save32x32.png", tooltip: "Save", onclick: "dialogEvent('EditorTab_SavePlan');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "CloseBtn", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('EditorTab_Close');", disabled: bIsCloseDisabled }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Item Actions",
                        tooltip: "Item Actions",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", id: "AcceptBtn", name: "Accept", img: "epmlive-master.png", style: "top: -109px; left: -405px;position:relative;z-index:5;", tooltip: "Accept Commitment", onclick: "dialogEvent('EditorTab_Accept');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "RejectBtn", name: "Reject", img: "epmlive-master.png", style: "top: -109px; left: -457px;position:relative;z-index:5;", tooltip: "Reject Commitment", onclick: "dialogEvent('EditorTab_Reject');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "RowNoteBtn", name: "Note", img: "Note32.png", tooltip: "Note", onclick: "dialogEvent('EditorTab_RowNote');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "RowHistoryBtn", name: "History", img: "epmlive-master.png", style: "top: -109px; left: -159px;", tooltip: "History", onclick: "dialogEvent('EditorTab_RowHistory');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "PublicBtn", name: "Make Public", img: "epmlive-master.png", style: "top: -116px; left: -216px;position:relative;z-index:5;", tooltip: "Make Private Row Public", onclick: "dialogEvent('EditorTab_Public');", disabled: true },
                                    { type: "smallbutton", id: "CancelBtn", name: "Cancel", img: "epmlive-master.png", style: "top: -116px; left: -116px;position:relative;z-index:5;", tooltip: "Cancel Commitment", onclick: "dialogEvent('EditorTab_Cancel');", disabled: true },
                                    { type: "smallbutton", id: "DeleteBtn", name: "Delete", img: "delete16.png", tooltip: "Delete", onclick: "dialogEvent('EditorTab_Delete');", disabled: true }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Tools",
                        tooltip: "Tools",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", id: "SpreadBtn", name: "Allocate Values", img: "allocate.png", tooltip: "Allocate Values", onclick: "dialogEvent('EditorTab_Spread');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "ImportWorkBtn", name: "Import Work", img: "import.png", tooltip: "Import Scheduled Work", onclick: "dialogEvent('EditorTab_ImportWork');", disabled: true },
                                    { type: "smallbutton", id: "ImportCostPlanBtn", name: "Import Cost Plan", img: "import.png", tooltip: "Import Cost Plan", onclick: "dialogEvent('EditorTab_ImportCostPlan');", disabled: true }
                                //                                    { type: "smallbutton", id: "NotesBtn", name: "Notes", img: "notemail.gif", tooltip: "Plan row notes", onclick: "dialogEvent('EditorTab_Notes');", disabled: true }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Options",
                        tooltip: "Options",
                        columns: [
                            {
                                items: [
                                    { type: "text", name: "Show Me:" },
                                    { type: "select", id: "idViewTab_DisplayedValues", onchange: "dialogEvent('ViewTab_DisplayedValues_Changed');", width: "100px" }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Share",
                        tooltip: "Share",
                        columns: [
                           {
                               items: [
                                    { type: "bigbutton", id: "idExportExcelTop", name: "Export to<br/> Excel", img: "export-excel32.png", tooltip: "Export Details to Excel", onclick: "dialogEvent('EditorTab_Export');" }
                               ]
                           },
                           {
                               items: [
                                    { type: "bigbutton", id: "idPrintTop", name: "Print", img: "print32.png", tooltip: "Print", onclick: "dialogEvent('PrintTopBtn');" }
                               ]
                           }
                        ]
                    }
                ]
            };

            var viewTabData = {
                parent: "idViewTabDiv",
                style: "display:none;",
                showstate: "true",
                initialstate: "expanded",
                onstatechange: "dialogEvent('PlanRibbon_Toggle');",
                imagePath: this.imagePath,
                sections: [
                    {
                        name: "Plan Actions",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", id: "SavePlanBtn2", name: "Save", img: "save32x32.png", tooltip: "Save", onclick: "dialogEvent('EditorTab_SavePlan');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "CloseBtn2", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('EditorTab_Close');", disabled: bIsCloseDisabled }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Views",
                        columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "SaveViewBtn", name: "Save View", img: "createview.gif", tooltip: "Save View", onclick: "dialogEvent('ViewTab_SaveView');" },
                                    { type: "smallbutton", id: "RenameViewBtn", name: "Rename View", img: "editview.gif", tooltip: "Rename View", onclick: "dialogEvent('ViewTab_RenameView');" },
                                    { type: "smallbutton", id: "DeleteViewBtn", name: "Delete View", img: "deleteview.gif", tooltip: "Delete View", onclick: "dialogEvent('ViewTab_DeleteView');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "text", name: "Current View:" },
                                    { type: "select", id: "idViewTab_SelView", onchange: "dialogEvent('ViewTab_SelView_Changed');", width: "100px" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "SelectColumnsBtn", name: "Select Columns", img: "selectcolumn.gif", tooltip: "Select Columns", onclick: "dialogEvent('ViewTab_SelectColumns');" },
                                    { type: "smallbutton", id: "idViewTab_RemoveSorting", name: "Clear Sorting", img: "clearsort.gif", tooltip: "Remove Sorting", onclick: "dialogEvent('ViewTab_RemoveSorting_Click');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "idViewTab_ShowFilters", name: "Show Filters", img: "showhidefilters-16.png", tooltip: "Show Filters", onclick: "dialogEvent('ViewTab_ShowFilters_Click');" }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Periods",
                        columns: [
                            {
                                items: [
                                    { type: "text", name: "From Period:" },
                                    { type: "select", id: "idViewTab_FromPeriod", onchange: "dialogEvent('ViewTab_FromPeriod_Changed');", width: "100px" }
                                ]
                            },
                                {
                                    items: [
                                    { type: "text", name: " ", width: "10px" }
                                    ]
                                },
                                {
                                    items: [
                                    { type: "text", name: "To Period:" },
                                    { type: "select", id: "idViewTab_ToPeriod", onchange: "dialogEvent('ViewTab_ToPeriod_Changed');", width: "100px" }
                                    ]
                                }
                        ]
                    }
                ]
            };


            var resourcesTabData = {
                parent: "idResourcesTabDiv",
                style: "display:none;",
                showstate: "true",
                initialstate: "expanded",
                onstatechange: "dialogEvent('ResRibbon_Toggle');",
                imagePath: this.imagePath,
                sections: [
                    {
                        name: "Actions",
                        tooltip: "Actions",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", id: "MatchBtn", name: "Match", img: "match.png", tooltip: "Match", onclick: "dialogEvent('ResourcesTab_Match');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "ResAddBtn", name: "Add", img: "add.png", tooltip: "Add Resource", onclick: "dialogEvent('ResourcesTab_Add');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "ResAnalyzeBtn", name: "Analyze", img: "analyze32.png", tooltip: "Ananlyze", onclick: "dialogEvent('ResourcesTab_Analyze');", disabled: true }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Find Resources",
                        tooltip: "Find Resourcess",
                        columns: [
                            {
                                items: [
                                    { type: "select", id: "idResourcesTab_Select", onchange: "dialogEvent('ResourcesTab_Select_Changed');", options: "<option value='0'>Show All Resources</option><option value='1'>Show Generic Resources</option><option value='2'>Show Plan Resources</option><option value='3'>Show Team Resources</option><option value='4'>Match</option>", width: "125px" }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Resources View",
                        tooltip: "Resources View",
                        columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "SelectResColumnsBtn", name: "Select Columns", img: "selectcolumn.gif", tooltip: "Select Columns", onclick: "dialogEvent('ResourcesTab_SelectColumns');" },
                                    { type: "smallbutton", id: "idResourcesTab_RemoveSorting", name: "Clear Sorting", img: "clearsort.gif", tooltip: "Remove Sorting", onclick: "dialogEvent('ResourcesTab_RemoveSorting_Click');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "idResourcesTab_ShowFilters", name: "Show Filters", img: "showhidefilters-16.png", tooltip: "Show Filters", onclick: "dialogEvent('ResourcesTab_ShowFilters_Click');" },
                                    { type: "smallbutton", id: "idResourcesTab_ShowGrouping", name: "Show Grouping", img: "grouping.gif", tooltip: "Show Grouping", onclick: "dialogEvent('ResourcesTab_ShowGrouping_Click');" }
                                ]
                            }
                        ]
                    },
                    {
                        columns: [
                            {
                                items: [
                                    { type: "text", name: "Show Me:" },
                                    { type: "select", id: "idResourcesTab_ShowMe", onchange: "dialogEvent('ResourcesTab_ShowMe_Changed');", width: "75px" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "idResourcesTab_ShowHeatmap", name: "Heat Map", img: "heatmap.png", tooltip: "Show Heat Map", onclick: "dialogEvent('ResourcesTab_ShowHeatmap_Click');" },
                                    { type: "smallbutton", id: "idResourcesTab_IncludePending", name: "Include Pending", img: "showhidefilters-16.png", tooltip: "Include Pending", onclick: "dialogEvent('ResourcesTab_IncludePending_Click');" }
                                ]
                            }
                        ]
                    }
                ]
            };

            this.layout = new dhtmlXLayoutObject(this.params.ClientID + "layoutDiv", "2E", "dhx_skyblue");
            this.layout.cells(const_PlanCell).setText("Plan Area");
            this.layout.cells(const_ResourcesCell).setText("Resource Area");
            this.layout.cells(const_PlanCell).hideHeader();
            this.layout.cells(const_ResourcesCell).hideHeader();

            this.layout_plan = this.layout.cells(const_PlanCell).attachLayout("2E", "dhx_skyblue");
            this.layout_plan._minHeight = 18;
            this.layout_plan.cells(const_PlanRibbonCell).setText("Plan Ribbon Area");
            this.layout_plan.cells(const_PlanRibbonCell).hideHeader();
            this.layout_plan.cells(const_PlanRibbonCell).setHeight(120);
            this.layout_plan.cells(const_PlanRibbonCell).fixSize(false, true);
            this.layout_plan.cells(const_PlanGridCell).setText("Plan Grid Area");
            this.layout_plan.cells(const_PlanGridCell).hideHeader();
            this.layout.setAutoSize("a;b", "a");

            this.editorTab = new Ribbon(editorTabData);
            this.editorTab.Render();

            this.viewTab = new Ribbon(viewTabData);
            this.viewTab.Render();
            this.resourcesTab = new Ribbon(resourcesTabData);
            this.resourcesTab.Render();
            // comment next line to show the Include Pending button
            this.resourcesTab.hideItem('idResourcesTab_IncludePending');
            this.resourcesTab.setButtonStateOn("idResourcesTab_IncludePending");

            if (this.NegotiationMode != true) {
                this.editorTab.hideItem('CancelBtn');
                this.editorTab.hideItem('AcceptBtn');
                this.editorTab.hideItem('RejectBtn');
                this.editorTab.hideItem('RowHistoryBtn');
            }
            // comment this out to show heatmap button in ribbon
            //this.resourcesTab.hideItem('idResourcesTab_ShowHeatmap');

            this.planTabbar = this.layout_plan.cells(const_PlanRibbonCell).attachTabbar();
            this.planTabbar.attachEvent("onSelect", function (id) { tabbarOnSelectDelegate(id, arguments); return true; });

            this.planTabbar.setImagePath("/_layouts/epmlive/dhtml/xtab/imgs/");
            this.planTabbar.enableAutoReSize();
            this.planTabbar.addTab("tab_Editor", "Editor", 70);
            this.planTabbar.setContent("tab_Editor", this.editorTab.getRibbonDiv());
            this.planTabbar.addTab("tab_View", "View", 70);
            this.planTabbar.setContent("tab_View", this.viewTab.getRibbonDiv());

            this.layout_res = this.layout.cells(const_ResourcesCell).attachLayout("2E", "dhx_skyblue");
            this.layout_res._minHeight = 18;
            this.layout_res.cells(const_ResourceRibbonCell).setText("Resource Ribbon Area");
            this.layout_res.cells(const_ResourceRibbonCell).hideHeader();
            this.layout_res.cells(const_ResourceRibbonCell).setHeight(68);
            this.layout_res.cells(const_ResourceRibbonCell).fixSize(false, true);
            this.layout_res.cells(const_ResourceGridCell).setText("Resource Grid Area");
            this.layout_res.cells(const_ResourceGridCell).hideHeader();

            this.layout_res.cells(const_ResourceRibbonCell).attachObject(document.getElementById(this.resourcesTab.getRibbonDiv()));

            var select = document.getElementById("idResourcesTab_ShowMe");
            select.options.length = 0;
            select.options[select.options.length] = new Option("Remaining", "Remaining", false, false);
            select.options[select.options.length] = new Option("Committed", "Committed", false, false);
            select.options[select.options.length] = new Option("Available", "Available", false, false);
            this.resourcesTab.refreshSelect("idResourcesTab_ShowMe");

            this.planTabbar.setTabActive("tab_Editor");

            this.layout_plan.cells(const_PlanGridCell).attachObject("gridDiv_RPE");


            var grid = Grids["g_RPE"];
            if (grid == null) {
                var sbDataxml = new StringBuilder();
                sbDataxml.append('<![CDATA[');
                sbDataxml.append('<Execute Function="GetResourcePlan">');
                sbDataxml.append('<Wepid>' + this.params.WEPID + '</Wepid>');
                sbDataxml.append('<TicketVal>' + this.params.TicketVal + '</TicketVal>');
                sbDataxml.append('<IsResource>' + this.params.IsResource + '</IsResource>');
                sbDataxml.append('</Execute>');
                sbDataxml.append(']]>');

                var sb = new StringBuilder();
                sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
                sb.append(" Export_Url='ModelExportExcel.aspx'");
                sb.append(" data_url='" + this.params.Webservice + "'");
                sb.append(" data_method='Soap'");
                sb.append(" data_function='Execute'");
                sb.append(" data_namespace='PortfolioEngine'");
                sb.append(" data_param_Function='ResourcePlans'");
                sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
                sb.append(" upload_url='" + this.params.Webservice + "'");
                sb.append(" upload_type='Body'");
                sb.append(" upload_method='Soap'");
                sb.append(" upload_function='Execute'");
                sb.append(" upload_namespace='PortfolioEngine'");
                sb.append(" upload_param_Function='ResourcePlans'");
                sb.append(" upload_data = 'Dataxml'");
                sb.append(" >");
                sb.append("</treegrid>");

                this.plangrid = TreeGrid(sb.toString(), "gridDiv_RPE", "g_RPE");

                this.OnResize();
                this.ShowWorkingPopup("divLoading");
            }
            else {
                this.UpdateButtonsAsync();
            }
        }
        catch (e) {
            this.HandleException("InitializeLayout", e);
        }
    };
    RPEditor.prototype.ShowWorkingPopup = function (divid) {
        //        var veil = document.getElementById("veil");
        //        veil.style.display = "block";
        var div = $('#' + divid);
        var win = $(window);
        div.css('top', (win.height() - div.height()) / 2);
        div.css('left', (win.width() - div.width()) / 2);
        div.show();
        var veil = $('#veil');
        veil.show();
    };
    RPEditor.prototype.HideWorkingPopup = function (divid) {
        var div = $('#' + divid);
        div.hide();
        var veil = $('#veil');
        veil.hide();
    };
    RPEditor.prototype.tabbarOnSelect = function (id, data) {
        if (this.editorTab.isCollapsed() == true) {
            this.layout_plan.cells(const_PlanRibbonCell).fixSize(false, false);
            this.layout_plan.cells(const_PlanRibbonCell).setHeight(120);
            this.layout_plan.cells(const_PlanRibbonCell).fixSize(false, true);
            this.editorTab.expand();
            this.viewTab.expand();
        }
    };
    RPEditor.prototype.GetPlanResourceArray = function () {
        var grid = Grids["g_RPE"];
        var resarr = [];
        if (grid != null) {
            var row = grid.GetFirst(null, 0);
            while (row != null) {
                var sWResID = grid.GetAttribute(row, null, "Res_UID");
                resarr[sWResID] = row;
                sWResID = grid.GetAttribute(row, null, "PendingRes_UID");
                resarr[sWResID] = row;
                row = grid.GetNext(row);
            }
        }
        return resarr;
    };
    RPEditor.prototype.GridsOnClickCell = function (grid, row, col) {
        if (grid.id == "g_RPE") {
            if (row != null && col != null) {
                switch (col) {
                    case "RowEvent":
                        var lastRowEvent = grid.GetAttribute(row, null, "LastRowEvent");
                        if (lastRowEvent != 0) {
                            this.GetRowEvents(row);
                        }
                        break;
                }
            }
        } else if (grid.id == "g_Notes") {
            this.NotesDialogEvent("OnClickCell", row);
        }
        this.UpdateButtonsAsync();
    };
    RPEditor.prototype.SetCurrentRow = function (grid, row) {
        if (grid.id == this.plangrid.id) {
            if (row != null && row.Kind == "Data") {
                this.planrow = row;
                this.spreadDlg_LoadData(this.plangrid, row, false);
            }
        }
    };
    RPEditor.prototype.GridsOnMouseDown = function (grid, row, col, x, y, event) {
        if (grid.id == "g_Res") {
            if (row != null) {
                if (event.ctrlKey == false) {
                    var resuid = grid.GetAttribute(row, null, "Res_UID");
                    var rows = grid.GetSelRows();
                    for (var i = 0; i < rows.length; i++) {
                        if (grid.GetAttribute(rows[i], null, "Res_UID") == resuid) {
                            return;
                        }
                    }
                    grid.SelectAllRows(0);
                    grid.SelectRow(row, 1);
                }
            }
        }
    };
    RPEditor.prototype.GridsOnDblClick = function (grid, row, col, x, y, event) {
        if (grid.id == "g_RPE") {
            if (row != null && col != null) {
                switch (col) {
                    case "Note":
                        var status = grid.GetAttribute(row, null, "Status");
                        if (status != 0) {
                            this.GetRowNote(row);
                        }
                        break;
                    case "RowPMStatus":
                        if (this.ChangePMStatus(grid, row, null) == true)
                            this.UpdateButtonsAsync();
                        break;
                    case "RowRMStatus":
                        if (this.ChangeRMStatus(grid, row, null) == true)
                            this.UpdateButtonsAsync();
                        break;
                    case "RowStatus":
                        var status = grid.GetAttribute(row, null, "Status");
                        if (status != 0) {
                            var group = grid.GetAttribute(row, null, "Group");
                            if (this.CanMakePublic(grid, row) == true) {
                                this.MakePublicOrPrivate(grid, group, true);
                            } else {
                                if (grid.GetAttribute(row, null, "PrivateChanged") == 1) {
                                    this.MakePublicOrPrivate(grid, group, false);
                                }
                            }
                        }

                        break;
                }
            }
        }
    };
    RPEditor.prototype.GridsOnFocus = function (grid, row, col, orow, ocol, pagepos) {
        this.SetCurrentRow(grid, row);
    };
    RPEditor.prototype.GridsOnReady = function (grid, start) {
        try {
            if (grid.id == "g_RPE") {
                this.InitialisePlanGrid();
                var selectedView = this.GetSelectedView();
                if (selectedView != null)
                    this.ApplyGridView(grid.id, selectedView, false);
                this.ShowHidePeriods(grid);
                this.RefreshPlanPeriods(false);
                if (this.initialized == false) {
                    this.layout_res.cells(const_ResourceGridCell).attachObject("gridDiv_Res");
                    if (this.resgrid == null) {
                        var sbd = new StringBuilder();
                        sbd.append('<![CDATA[');
                        sbd.append('<Execute Function="GetPlanResources">');
                        sbd.append('<Wepid>' + this.params.WEPID + '</Wepid>');
                        sbd.append('<TicketVal>' + this.params.TicketVal + '</TicketVal>');
                        sbd.append('<IsResource>' + this.params.IsResource + '</IsResource>');
                        // leave blank for now to get all valid resources
                        //sbd.append('<WResIDs>' + this.GetPlanResourceList() + '</WResIDs>');
                        sbd.append('</Execute>');
                        sbd.append(']]>');

                        var sb = new StringBuilder();
                        sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
                        sb.append(" data_url='" + this.params.Webservice + "'");
                        sb.append(" data_method='Soap'");
                        sb.append(" data_function='Execute'");
                        sb.append(" data_namespace='PortfolioEngine'");
                        sb.append(" data_param_Function='ResourcePlans'");
                        sb.append(" data_param_Dataxml='" + sbd.toString() + "'");
                        sb.append(" >");
                        sb.append("</treegrid>");

                        this.resgrid = TreeGrid(sb.toString(), "gridDiv_Res", "g_Res");

                        this.OnResize();

                    }
                    this.SetPlanRowsEditStatus();
                }
            }
            else if (grid.id == "g_Res") {
                if (grid.IO != null && grid.IO.Result != null && grid.IO.Result == '0') {
                    parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                    return;
                }
                grid.ActionFilterOff();
                grid.ActionGroupOff();
                //grid.ActionSortOff();
                this.InitialiseResourceGrid();
                var selectedView = this.GetSelectedView();
                if (selectedView != null)
                    this.ApplyGridView(grid.id, selectedView, false);
                this.ShowHidePeriods(grid);
                this.ShowSelectedResourceGroup();
                this.RefreshResourcePeriods(true);
                this.viewTab.refreshSelect("idViewTab_FromPeriod");
                window.setTimeout(thisID + ".HandleAction('OnStart')", 100);
                window.setTimeout(function () { var gridRPE = Grids["g_RPE"]; gridRPE.Focus(gridRPE.GetFirst(null, 0), "ItemName"); }, 10);
            }
            //grid.SortRows();
        }
        catch (e) {
            this.HandleException("GridsOnReady", e);
        }
    };
    RPEditor.prototype.GridsOnRenderFinish = function (grid) {
        if (this.initialized != true) {
            if (grid.id == "g_RPE") {
                //this.SetPlanRowsEditStatus();
                grid.SortRows();
            }
            else if (grid.id == "g_Res") {
                this.SetPaddingWidth();
                this.GridsOnSectionResize(this.plangrid, 2, 0);
                this.initialized = true;
                this.UpdateButtonsAsync();
                this.CheckPlanResDeptsAsync();
                this.HideWorkingPopup("divLoading");
                grid.ActionFilterOn();
                grid.ActionGroupOn();
                //grid.ActionSortOn();
            }
        }
    };
    RPEditor.prototype.GridsOnScroll = function (grid, hpos1, vpos, oldhpos1, oldvpos, hpos0, oldhpos0, hpos2, oldhpos2) {
        var timeNow = new Date().getTime();
        if (this.ScrollMasterUntil != null && this.ScrollMasterUntil <= timeNow) {
            this.ScrollMasterGridId = null;
            this.ScrollMasterUntil = null;
        }
        if (this.ScrollMasterGridId == null) {
            this.ScrollMasterGridId = grid.id;
        }
        this.ScrollMasterUntil = timeNow + 1000;
        if (grid.id != this.ScrollMasterGridId)
            return;

        var gridRes = Grids["g_Res"];
        var gridRPE = Grids["g_RPE"];
        if (this.initialized == true) {
            if (grid.id == "g_RPE") {
                if (gridRes != null) {
                    gridRes.SetScrollLeft(grid.GetScrollLeft(2), 2);
                }
            }
            else if (grid.id == "g_Res") {
                if (gridRPE != null) {
                    gridRPE.SetScrollLeft(grid.GetScrollLeft(2), 2);
                }
            }
        }
    };
    RPEditor.prototype.GridsOnSectionResize = function (grid, section, widthchange) {
        var plandelta = 0;
        if (this.plangrid.GetBodyHeight() != this.plangrid.GetBodyScrollHeight()) plandelta = 18;
        var lPlanWidth = Grids["g_RPE"].RightWidth + plandelta;
        var resdelta = 0;
        if (this.resgrid.GetBodyHeight() != this.resgrid.GetBodyScrollHeight()) resdelta = 18;
        var lResWidth = Grids["g_Res"].RightWidth + resdelta;

        if (grid.id == "g_RPE" && section == 2) {
            Grids["g_Res"].RightWidth = lPlanWidth - resdelta;
            Grids["g_Res"].Update();
        }
        else if (grid.id == "g_Res" && section == 2) {
            Grids["g_RPE"].RightWidth = lResWidth - plandelta;
            Grids["g_RPE"].Update();
        }
    };
    RPEditor.prototype.GridsOnStartDragCell = function (grid, row, col, html) {
        if (row.Kind != "Data")
            return true;
        if (grid.id == "g_RPE") {
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                return "Moving Period values...";
            }
        }
        else if (grid.id == "g_Res") {
            return "Copying Resource...";
        }
        return true;
    };
    RPEditor.prototype.GridsOnMoveDragCell = function (grid, row, col, togrid, torow, tocol, X, Y) {
        //document.body.style.cursor = 'no-drop';
        return;
    };
    RPEditor.prototype.GridsOnAfterColumnsChanged = function (grid) {
        if (this.initialized == true) {
            this.SetPaddingWidth();
            this.GridsOnSectionResize(grid, 2, 0);
        }
        return;
    };
    RPEditor.prototype.MovePlanPeriodData = function (planrow, shift) {
        var plangrid = this.plangrid;
        var length = plangrid.ColNames[2].length;
        if (shift > 0) {
            for (var c = length - 1; c >= 0; c--) {
                var tocol = plangrid.ColNames[2][c];
                var val = null;
                if (c >= shift) {
                    var fromcol = plangrid.ColNames[2][c - shift];
                    val = this.GetPeriodValue(plangrid, planrow, fromcol);
                }
                var origval = this.GetPeriodValue(plangrid, planrow, tocol);
                if (origval != null && val == null) val = 0;
                this.SetPeriodValue(plangrid, planrow, tocol, val);
            }
        }
        else {
            for (var c = 0; c < length; c++) {
                var tocol = plangrid.ColNames[2][c];
                var val = null;
                if (c < length + shift - 1) {
                    var fromcol = plangrid.ColNames[2][c - shift];
                    val = this.GetPeriodValue(plangrid, planrow, fromcol);
                }
                var origval = this.GetPeriodValue(plangrid, planrow, tocol);
                if (origval != val) {
                    if (origval != null && val == null) val = 0;
                    this.SetPeriodValue(plangrid, planrow, tocol, val);
                }
            }
        }
        this.RefreshPlanRowPeriods(plangrid, planrow, true);
        this.SetStatusAfterValueChanged(plangrid, planrow, false);
        plangrid.RefreshRow(planrow);
        var reqrow = this.GetParentRequirement(planrow);
        if (reqrow != null) {
            this.UpdatePlanRowCalculatedValues(reqrow, 0);
            this.RefreshPlanRowPeriods(plangrid, reqrow, true);
            plangrid.SetAttribute(reqrow, null, "Changed", 1, 0, 0);
        }
        var resuid = plangrid.GetAttribute(planrow, null, "PendingRes_UID");
        if (resuid == null) resuid = plangrid.GetAttribute(planrow, null, "Res_UID");
        var resrow = this.FindResourceRow(resuid);
        this.CalculateResourceRowCommitted(resuid, resrow);
    };
    RPEditor.prototype.GridsOnEndDragCell = function (grid, row, col, togrid, torow, tocol, X, Y) {
        if (togrid == null || torow == null || tocol == null) return;
        if (grid.id == togrid.id && togrid.id == "g_RPE" && row.id == torow.id && col != tocol) {
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var nid = parseInt(col.substring(1));
                var ntoid = parseInt(tocol.substring(1));
                var shift = ntoid - nid;
                var status = grid.GetAttribute(row, null, "Status");
                if (status != const_Project) {
                    this.MovePlanPeriodData(row, shift);
                }
                var childrow = row.firstChild;
                while (childrow != null) {
                    this.MovePlanPeriodData(childrow, shift);
                    childrow = childrow.nextSibling;
                }

                this.UpdateButtonsAsync();
            }
        }
        return;
    };
    RPEditor.prototype.GridsOnStartDrag = function (grid, row, col, more, copy) {
        return false;
    };
    RPEditor.prototype.GridsOnCanDrop = function (grid, row, togrid, torow, type, copy) {
        // types : 0 - cannot drop; 1 - above; 2 append as child of torow; 3 - add below torow
        if (grid == null || togrid == null || row == null)
            return 0;
        if (grid.id == togrid.id)
            return 0;

        // only allow item to be dropped on an existing row - there should always be a project row available
        if (togrid.id == "g_RPE" && type != 2)
            return 2;

        switch (grid.id) {
            case "g_RPE":
                if (togrid.id == "g_Res")
                    return 0;
                if (type != 2)
                    return 0;
                break;
        }

        if (torow == null)
            return 0;
        else
            return type;
    };
    RPEditor.prototype.GridsOnEndDrag = function (grid, row, togrid, torow, type, X, Y, copy) {
        // togrid is unreliable if not over existing row
        var activeGrid = Grids.Active;
        var newtype = this.GridsOnCanDrop(grid, row, activeGrid, torow, type, copy);
        if (newtype == 0)
            return 0;
        if (grid.id == "g_Res") {
            if (activeGrid.id == "g_RPE") {
                if (torow != null) {
                    var resrows = grid.GetSelRows();
                    var rows = [];
                    for (var i = resrows.length - 1; i >= 0; i--) {
                        var resrow = resrows[i];
                        if (resrow.Kind === 'Data')
                            rows[rows.length++] = resrow;
                    }
                    if (rows.length > 0) {
                        window.setTimeout(function () { var gridRPE = Grids["g_RPE"]; gridRPE.Focus(torow, "ItemName"); }, 10);
                        this.HandleAddSplitOrReplace(rows, torow, false);
                    }
                }
            }
        }
        return 0;
    };
    RPEditor.prototype.GridsOnStartEdit = function (grid, row, col) {
    };
    RPEditor.prototype.GridsOnGetInputValue = function (grid, row, col, val) {
        if (grid.id == "g_RPE") {
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var bFulfillmentMode = false;
                if (grid.GetAttribute(row, null, "Status") == const_Requirement && row.firstChild != null)
                    bFulfillmentMode = true;
                this.originalval = val;
                val = this.GetFormattedPeriodCell(grid, row, col, bFulfillmentMode, true);
                this.newval = val;
            }
        }
        return val;
    };
    RPEditor.prototype.GridsOnSetInputValue = function (grid, row, col, val) {
        this.valChanged = false;
        if (grid.id == "g_RPE") {
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                if (val == this.newval)
                    val = this.originalval;
                else
                    this.valChanged = true;
            }
        }
        return val;
    };
    RPEditor.prototype.GridsOnAfterValueChanged = function (grid, row, col, val) {
        if (grid.id == "g_RPE") {
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var status = grid.GetAttribute(row, null, "Status");
                if (status == const_Requirement) {
                    var s = this.GetFormattedPeriodCell(grid, row, col, true, false);
                    grid.SetAttribute(row, null, col, s, 1, 0);
                }
                else if (status == const_Commitment) {
                    var resuid = grid.GetAttribute(row, null, "PendingRes_UID");
                    if (resuid == null) resuid = grid.GetAttribute(row, null, "Res_UID");
                    var resrow = this.FindResourceRow(resuid);
                    var periodid = col.substring(1);
                    this.CalculateResourceRowPeriodCommitted(resuid, resrow, periodid, true, row);
                    var reqrow = this.GetParentRequirement(row);
                    if (reqrow != null) {
                        this.CalculateRequirementCellValue(reqrow, periodid, 0);
                        var s = this.GetFormattedPeriodCell(grid, reqrow, col, true, false);
                        grid.SetAttribute(reqrow, null, col, s, 1, 0);
                        grid.SetAttribute(reqrow, null, "Changed", 1, 0, 0);
                    }

                    this.SetStatusAfterValueChanged(grid, row, false);
                }
            }
        }

        this.UpdateButtonsAsync();
    };
    RPEditor.prototype.SetStatusAfterValueChanged = function (grid, row, bNewRow) {
        var rowPrivate = grid.GetAttribute(row, null, "Private");
        if (rowPrivate != 1) {
            if (this.NegotiationMode != false) {
                var UserIsPM = grid.GetAttribute(row, null, "UserIsPM");
                var UserIsRM = grid.GetAttribute(row, null, "UserIsRM");
                var PMStatus = grid.GetAttribute(row, null, "PMStatus");
                var RMStatus = grid.GetAttribute(row, null, "RMStatus");
                var priorEvent = grid.GetAttribute(row, null, "RowEventId");
                if (UserIsPM == 1) {
                    if (PMStatus != 1 || RMStatus == 1) {
                        grid.SetAttribute(row, null, "PMStatus", 1, 1, 0);
                        this.SetPMStatusColumn(grid, row, 1);
                        grid.SetAttribute(row, null, "RMStatus", 0, 1, 0);
                        this.SetRMStatusColumn(grid, row, 1);
                        if (bNewRow == true)
                            this.HandleRowEvent(row, "PMNewRow");
                        else if (priorEvent == null)
                            this.HandleRowEvent(row, "PMChange");
                    }
                } else if (UserIsRM == 1) {
                    if (RMStatus != 1 || PMStatus == 1) {
                        grid.SetAttribute(row, null, "RMStatus", 1, 1, 0);
                        this.SetRMStatusColumn(grid, row, 1);
                        grid.SetAttribute(row, null, "PMStatus", 0, 1, 0);
                        this.SetPMStatusColumn(grid, row, 1);
                        if (bNewRow == true)
                            this.HandleRowEvent(row, "RMNewRow");
                        else if (priorEvent == null)
                            this.HandleRowEvent(row, "RMChange");
                    }
                }
                this.SetStatusColumn(grid, row, null, null, 1);
            }
        }
    };
    RPEditor.prototype.GetNamePrefix = function (name) {
        // ids in form of g_1
        var s = name.split("_");
        return s[0];
    };
    RPEditor.prototype.GetPeriodValue = function (grid, row, col) {
        var value = null;
        switch (this.displayMode) {
            case 0: /* Hours */
                value = this.GetPeriodHours(grid, row, col);
                break;
            case 1: /* FTE */
            case 2: /* FTE %*/
                value = this.GetPeriodFTE(grid, row, col);
                break;
        }
        return value;
    };
    RPEditor.prototype.GetPeriodHours = function (grid, row, col) {
        var sId = col.substring(1);
        var value = grid.GetAttribute(row, "h" + sId);
        if (value == null) {
            value = grid.GetAttribute(row, "H" + sId);
        }
        return value;
    };
    RPEditor.prototype.GetPeriodFTE = function (grid, row, col) {
        var sId = col.substring(1);
        var value = grid.GetAttribute(row, "f" + sId);
        if (value == null) {
            value = grid.GetAttribute(row, "F" + sId);
        }
        return value;
    };
    RPEditor.prototype.SetZeroIfNull = function (value) {
        if (value == null)
            return 0;
        return value;
    };
    RPEditor.prototype.ValidatePlanRowPeriodConversion = function (grid, row) {
        for (var c = 0; c < grid.ColNames[2].length; c++) {
            var col = grid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                if (this.ValidatePeriodConversion(grid, row, col) != true)
                    return false;
            }
        }
        return true;
    }

    RPEditor.prototype.CheckValuesEqual = function (v1, v2, diff) {
        var z = v1 - v2;
        if (z < -diff || z > diff)
            return false;
        return true;
    }
    RPEditor.prototype.ValidatePeriodConversion = function (grid, row, col) {
        var sId = col.substring(1);
        var ccruid = grid.GetAttribute(row, null, "CCRole_UID");
        var fteconv = this.GetFTEConv(ccruid, sId, grid, row);
        if (fteconv == null) { alert("ValidatePeriodConversion : null fte conversion"); return false; }
        var valueH = grid.GetAttribute(row, "H" + sId);
        var valueF = grid.GetAttribute(row, "F" + sId);
        if (valueH == null || valueF == null) {
            if (valueH != valueF) {
                //alert("ValidatePeriodConversion : null H or F value conversion");
                return false;
            }
        }
        else {
            if (this.CheckValuesEqual(parseInt(valueF) * fteconv, parseInt(valueH) * 10000, 20000) == false) {
                //alert("ValidatePeriodConversion : value H does not convert to value F");
                return false;
            }
        }
        var valueh = grid.GetAttribute(row, "h" + sId);
        var valuef = grid.GetAttribute(row, "f" + sId);
        if (valueh == null || valuef == null) {
            if (valueh != valuef) {
                //alert("ValidatePeriodConversion : null H or F value conversion");
                return false;
            }
        }
        else {
            if (this.CheckValuesEqual(parseInt(valuef) * fteconv, parseInt(valueh) * 10000, 20000) == false) {
                //alert("ValidatePeriodConversion : value h does not convert to value f");
                return false;
            }
        }
        return true
    };
    RPEditor.prototype.SetPeriodValue = function (grid, row, col, dbl) {
        var sId = col.substring(1);
        var value = this.GetPeriodValue(grid, row, col);
        if (value == dbl) return;
        var ccruid = grid.GetAttribute(row, null, "CCRole_UID");
        var status = grid.GetAttribute(row, null, "Status");
        var h = "h";
        var f = "f";
        if (status == const_Requirement) {
            h = "t";
            f = "u";
        }
        var origvalue = value;
        var fteconv = this.GetFTEConv(ccruid, sId, grid, row);
        if (fteconv > 0) {
            switch (this.displayMode) {
                case 0: /* Hours mode - so calc FTE */
                    grid.SetAttribute(row, null, h + sId, dbl, 0, 0);
                    grid.SetAttribute(row, null, h + sId + "Changed", 1, 0, 0);
                    if (dbl == null) value = null; else value = parseInt((dbl * 10000) / fteconv);
                    grid.SetAttribute(row, null, f + sId, value, 0, 0);
                    grid.SetAttribute(row, null, "m" + sId, 0, 0, 0);
                    break;
                case 1: /* FTE mode - so calc Hours */
                case 2: /* FTE %*/
                    origvalue = (value * fteconv) / 10000;
                    grid.SetAttribute(row, null, f + sId, dbl, 0, 0);
                    grid.SetAttribute(row, null, f + sId + "Changed", 1, 0, 0);
                    if (dbl == null) value = null; else value = parseInt((dbl * fteconv) / 10000);
                    grid.SetAttribute(row, null, h + sId, value, 0, 0);
                    grid.SetAttribute(row, null, "m" + sId, 1, 0, 0);
                    break;
            }
        }
        var origH = grid.GetAttribute(row, null, "H" + sId + "Orig");
        if (origH == null) {
            grid.SetAttribute(row, null, "H" + sId + "Orig", this.SetZeroIfNull(origvalue), 0, 0);
        }
        grid.SetAttribute(row, null, "Changed", 1, 0, 0);
        if (status == const_Requirement)
            this.CalculateRequirementCellValue(row, sId, 0);
    };
    RPEditor.prototype.FormatHours = function (grid, row, col, bFulfillmentMode, bEditMode) {
        var sId = col.substring(1);
        var sValue = "";
        var sTotal = "";
        if (bFulfillmentMode == true) {
            var total = this.GetIntValue(grid.GetAttribute(row, "t" + sId), null);
            if (total != null)
                sTotal = NumberToString(total / 100, const_HoursFormat);
            if (bEditMode == true)
                return (total != null) ? sTotal : "0";
        }
        var lHours = 0;
        var Hours = grid.GetAttribute(row, "H" + sId);
        if (Hours != null) lHours = parseInt(Hours) / 100;
        var hours = grid.GetAttribute(row, "h" + sId);
        if (hours == null) {
            if (Hours != null && lHours != 0) {
                sValue = NumberToString(lHours, const_HoursFormat);
            }
        }
        else {
            var lhours = parseInt(hours) / 100;
            sValue = NumberToString(lhours, const_HoursFormat);
            if (bEditMode != true && hours != null && lhours != lHours && bFulfillmentMode != true) {
                var activeCommitment = grid.GetAttribute(row, null, "ActiveCommitment");
                if (activeCommitment != 0)
                    sValue += "(" + NumberToString(lHours, const_HoursFormat) + ")";
            }
        }
        if (sTotal != "") {
            if (sValue == "")
                sValue = sTotal;
            else
                sValue = sTotal + " | " + sValue;
        }
        return sValue;
    };
    RPEditor.prototype.FormatFTE = function (grid, row, col, bFulfillmentMode, bEditMode) {
        var sId = col.substring(1);
        var sValue = "";
        var sTotal = "";
        if (bFulfillmentMode == true) {
            var total = this.GetIntValue(grid.GetAttribute(row, "u" + sId), null);
            if (total != null)
                sTotal = NumberToString(total / 10000, const_FTEFormat);
            if (bEditMode == true)
                return (total != null) ? sTotal : "0";
        }
        var lFte = 0;
        var Fte = grid.GetAttribute(row, "F" + sId);
        if (Fte != null) lFte = parseInt(Fte) / 10000;
        var fte = grid.GetAttribute(row, "f" + sId);
        if (fte == null) {
            if (Fte != null && lFte != 0) {
                sValue = NumberToString(lFte, const_FTEFormat);
            }
        }
        else {
            var lfte = parseInt(fte) / 10000;
            sValue = NumberToString(lfte, const_FTEFormat);
            if (bEditMode != true && fte != null && lfte != lFte && bFulfillmentMode != true) {
                var activeCommitment = grid.GetAttribute(row, null, "ActiveCommitment");
                if (activeCommitment != 0)
                    sValue += "(" + NumberToString(lFte, const_FTEFormat) + ")";
            }
        }
        if (sTotal != "") {
            if (sValue == "")
                sValue = sTotal;
            else
                sValue = sTotal + " | " + sValue;
        }
        return sValue;
    };
    RPEditor.prototype.FormatFTEPct = function (grid, row, col, bFulfillmentMode, bEditMode) {
        var sId = col.substring(1);
        var sValue = "";
        var sTotal = "";
        if (bFulfillmentMode == true) {
            var total = this.GetIntValue(grid.GetAttribute(row, "u" + sId), null);
            if (total != null)
                sTotal = NumberToString(total / 10000, const_FTEPctFormat);
            if (bEditMode == true)
                return (total != null) ? sTotal : "0";
        }
        var lFte = 0;
        var Fte = grid.GetAttribute(row, "F" + sId);
        if (Fte != null) lFte = parseInt(Fte) / 10000;
        var fte = grid.GetAttribute(row, "f" + sId);
        if (fte == null) {
            if (Fte != null && lFte != 0) {
                sValue = NumberToString(lFte, const_FTEPctFormat);
            }
        }
        else {
            var lfte = parseInt(fte) / 10000;
            sValue = NumberToString(lfte, const_FTEPctFormat);
            if (bEditMode != true && fte != null && lfte != lFte && bFulfillmentMode != true) {
                var activeCommitment = grid.GetAttribute(row, null, "ActiveCommitment");
                if (activeCommitment != 0)
                    sValue += "(" + NumberToString(lFte, const_FTEPctFormat) + ")";
            }
        }
        if (sTotal != "") {
            if (sValue == "")
                sValue = sTotal;
            else
                sValue = sTotal + " | " + sValue;
        }
        return sValue;
    };
    RPEditor.prototype.FormatFTEConv = function (grid, row, col) {
        var sId = col.substring(1);
        var sValue = "";
        var ccruid = grid.GetAttribute(row, "CCRole_UID");
        var fteconv = this.GetFTEConv(ccruid, sId, grid, row);
        var dblfteDiv = fteconv / 100;
        if (dblfteDiv != null) {
            sValue = dblfteDiv.toString();
        }
        return sValue;
    };
    RPEditor.prototype.GetFormattedPeriodCell = function (grid, row, col, bFulfillmentMode, bEditMode) {
        var sValue = "";
        var sType = col.substring(0, 1);
        if (sType == "Q") {
            var status = grid.GetAttribute(row, null, "Status");
            if (status != const_Project) {
                switch (this.displayMode) {
                    case 0: // Hours
                        sValue = this.FormatHours(grid, row, col, bFulfillmentMode, bEditMode);
                        break;
                    case 1: // FTE 
                        sValue = this.FormatFTE(grid, row, col, bFulfillmentMode, bEditMode);
                        break;
                    case 2: // FTE %
                        sValue = this.FormatFTEPct(grid, row, col, bFulfillmentMode, bEditMode);
                        break;
                    case 3: // FTE conversion
                        sValue = this.FormatFTEConv(grid, row, col);
                        break;
                }
            }
        }
        return sValue;
    };
    RPEditor.prototype.GridsOnValueChanged = function (grid, row, col, val) {
        var snewVal = val;
        if (grid.id == "g_RPE") {
            if (grid.Cols[col] != null) {
                if (grid.Cols[col].Sec == 1) {
                    var sAttr = "";
                    switch (col) {
                        case "CCRole_Name":
                        case "Dept_Name":
                        case "Res_Name":
                        case "NamedRate_Name":
                            sAttr = this.GetNamePrefix(col) + "_UID";
                            break;
                        default:
                            if (col.charAt(0) === "X") {
                                sAttr = this.GetNamePrefix(col) + "_UID";
                            }
                    }
                    if (sAttr == "") return val;
                    var s = val.toString();
                    var i = s.indexOf("_");
                    if (i > -1) {
                        var sNewId = s.substr(0, i);
                        snewVal = s.substr(i + 1);
                        grid.SetAttribute(row, null, sAttr, sNewId, 0, 0);
                        grid.SetAttribute(row, null, sAttr + "Changed", 1, 0, 0);
                    }
                }
                else if (grid.Cols[col].Sec == 2) {
                    if (this.valChanged == true) {
                        this.valChanged = false;
                        var jValue = null;
                        var mpy = 100;
                        switch (this.displayMode) {
                            case 0: /* Hours */
                                jValue = ValidateStringAsNumber(val, 10, 2, false, "");
                                break;
                            case 1: /* FTE */
                                jValue = ValidateStringAsNumber(val, 5, 2, false, "");
                                mpy = 10000;
                                break;
                            case 2: /* FTE %*/
                                jValue = ValidateStringAsNumber(val, 7, 0, true, "");
                                break;
                        }
                        if (jValue != null && jValue.error == null) {
                            if (jValue.value == "") {
                                jValue.value = "0";
                            }
                            var thisval = parseFloat(jValue.value);
                            var dblValue = parseFloat(thisval.toFixed(2));
                            dblValue = parseInt(this.round(dblValue * mpy, 0));
                            this.SetPeriodValue(grid, row, col, dblValue);
                            snewVal = this.GetFormattedPeriodCell(grid, row, col, false, false);
                        }
                    }
                }
            }
        }
        return snewVal;
    };
    RPEditor.prototype.round = function (number, precision) {
        precision = Math.abs(parseInt(precision)) || 0;
        var coefficient = Math.pow(10, precision);
        return Math.round(number * coefficient) / coefficient;
    };
    RPEditor.prototype.SaveRowNote = function (planrow, html) {
        var sbn = new StringBuilder();
        var timestamp = new Date().getTime();
        var plangrid = this.plangrid;
        var planrowGuid = plangrid.GetAttribute(planrow, null, "GUID");
        var projectID = plangrid.GetAttribute(planrow, null, "Project_UID");
        sbn.append('<Note Planrow_GUID="' + XMLValue(planrowGuid) + '"');
        sbn.append(' Project_UID="' + projectID.toString() + '"');
        sbn.append(" >");
        sbn.append('<Timestamp>' + BuildDateTimeString(timestamp) + '</Timestamp>');
        if (html == "<P>&nbsp;</P>") html = "";
        sbn.append('<HTML><![CDATA[' + html + ']]></HTML>');
        sbn.append('</Note>');

        var sb = new StringBuilder();
        sb.append('<Execute Function="SaveRowNote">');
        sb.append(sbn.toString());
        sb.append('</Execute>');
        this.ExecuteJSON(sb.toString());
        return html;
    };
    RPEditor.prototype.GridsOnAfterSave = function (grid, result, autoupdate) {
        this.HideWorkingPopup("divSaving");
        this.savingPlan = false;
        if (result == 0) {
            var planrow = grid.GetFirst(null, 0);
            while (planrow != null) {
                // need to clear some changed flags
                grid.SetAttribute(planrow, null, "CCRole_NameChanged", null, 0, 0);
                grid.SetAttribute(planrow, null, "CCRoleParent_NameChanged", null, 0, 0);
                grid.SetAttribute(planrow, null, "GroupChanged", null, 0, 0);
                grid.SetAttribute(planrow, null, "PrivateChanged", null, 0, 0);
                grid.SetAttribute(planrow, null, "Project_NameChanged", null, 0, 0);
                grid.SetAttribute(planrow, null, "Res_NameChanged", null, 0, 0);
                var eventId = grid.GetAttribute(planrow, null, "RowEventId");
                if (eventId != null) {
                    grid.SetAttribute(planrow, null, "RowEventId", null, 0, 0);
                    grid.SetAttribute(planrow, null, "RowEventTitle", null, 0, 0);
                    grid.SetAttribute(planrow, null, "RowEventHtml", null, 0, 0);
                }
                grid.SetAttribute(planrow, null, "TimestampOrig", null, 0, 0);
                planrow = grid.GetNext(planrow);
            }

            var sbn = new StringBuilder();
            sbn.append('<SynchronizeTeam');
            sbn.append(' Project_UIDs="' + this.projectuids + '"');
            sbn.append(' >');
            sbn.append('</SynchronizeTeam>');

            var sb = new StringBuilder();
            sb.append('<Execute Function="SynchronizeTeam">');
            sb.append(sbn.toString());
            sb.append('</Execute>');
            this.ExecuteJSON(sb.toString(), "GeneralFunctions");

            this.SetPlanRowsEditStatus();
            this.RefreshResourcePeriods(true);
        }
        this.UpdateButtonsAsync();
    };
    RPEditor.prototype.AddRowsToProject = function (resrows, planrow, buttonPress) {
        var projectID = this.plangrid.GetAttribute(planrow, null, "Project_UID");
        var projectName = this.plangrid.GetAttribute(planrow, null, "Project_Name");
        this.AddRowsToPlan(planrow, resrows, projectID, projectName, buttonPress);
        this.plangrid.DoGrouping(this.plangrid.Group);
    };
    RPEditor.prototype.FullFillRequirement = function (resrows, planrow, buttonPress) {
        var projectID = this.plangrid.GetAttribute(planrow, null, "Project_UID");
        var projectName = this.plangrid.GetAttribute(planrow, null, "Project_Name");
        this.AddRowsToPlan(planrow, resrows, projectID, projectName, buttonPress);
        this.plangrid.DoGrouping(this.plangrid.Group);
    };
    RPEditor.prototype.ReplaceRequirement = function (resrows, planrow) {
        return this.SplitPlanRow(resrows, planrow, true);
    };
    RPEditor.prototype.SplitPlanRow = function (resrows, planrow, bReplace) {
        if (planrow != null) {
            var plangrid = this.plangrid;
            var resgrid = this.resgrid;

            var origwresId = plangrid.GetAttribute(planrow, null, "Res_UID");
            var origpendingwresId = plangrid.GetAttribute(planrow, null, "PendingRes_UID");

            var status = plangrid.GetAttribute(planrow, null, "Status");

            var div = resrows.length;
            if (bReplace == false) {
                div += 1;
                plangrid.SetAttribute(planrow, null, "AddParent", 2, 0, 0);
            }
            var parentplanrow = planrow;
            var parentprivate = plangrid.GetAttribute(parentplanrow, null, "Private");
            var thisguid;
            for (var i = resrows.length - 1; i >= 0; i--) {
                var resrow = resrows[i];
                if (this.CanAddResourceToLevel2(planrow, resrow) != true)
                    return false;

                var childplanrow;
                var bNewRow = true;
                if (bReplace == true && i == 0) {
                    childplanrow = planrow;
                    thisguid = plangrid.GetAttribute(planrow, null, "GUID");
                    bNewRow = false;
                }
                else {
                    childplanrow = plangrid.AddRow(planrow, null, true);
                    childplanrow.NoColorState = 1;
                    plangrid.SetAttribute(childplanrow, null, "UserCanEdit", 1, 0, 0);

                    var guid = new Guid();
                    thisguid = guid.newGuid();
                    plangrid.SetAttribute(childplanrow, null, "Private", plangrid.GetAttribute(planrow, null, "Private"), 0, 0);
                    var activeCommitment = plangrid.GetAttribute(planrow, null, "ActiveCommitment");
                    plangrid.SetAttribute(childplanrow, null, "ActiveCommitment", activeCommitment, 0, 0);
                    var userIsPM = plangrid.GetAttribute(parentplanrow, null, "UserIsPM");
                    if (userIsPM != null)
                        plangrid.SetAttribute(childplanrow, null, "UserIsPM", userIsPM, 0, 0);
                    var userIsRM = plangrid.GetAttribute(parentplanrow, null, "UserIsRM");
                    if (userIsRM != null)
                        plangrid.SetAttribute(childplanrow, null, "UserIsRM", userIsRM, 0, 0);
                }
                var group = plangrid.GetAttribute(planrow, null, "Group");
                var projectID = plangrid.GetAttribute(planrow, null, "Project_UID");
                var projectName = plangrid.GetAttribute(planrow, null, "Project_Name");
                var ccroleUid = plangrid.GetAttribute(planrow, null, "CCRole_UID");
                var ccroleParentUid = plangrid.GetAttribute(planrow, null, "CCRoleParent_UID");
                var ccroleName = plangrid.GetAttribute(planrow, null, "CCRole_Name");
                var ccroleParentName = plangrid.GetAttribute(planrow, null, "CCRoleParent_Name");
                if (ccroleUid == null || ccroleUid == 0) {
                    ccroleUid = resgrid.GetAttribute(resrow, null, "CCRole_UID");
                    ccroleParentUid = resgrid.GetAttribute(resrow, null, "CCRoleParent_UID");
                    plangrid.SetAttribute(childplanrow, null, "CCRoleParent_UIDChanged", 1, 0, 0);
                    ccroleName = resgrid.GetAttribute(resrow, null, "CCRole_Name");
                    ccroleParentName = resgrid.GetAttribute(resrow, null, "CCRoleParent_Name");
                }
                var roleUid = plangrid.GetAttribute(planrow, null, "Role_UID");
                var roleName = plangrid.GetAttribute(planrow, null, "Role_Name");
                if (roleUid == null || roleUid == 0) {
                    roleUid = resgrid.GetAttribute(resrow, null, "Role_UID");
                    roleName = resgrid.GetAttribute(resrow, null, "Role_Name");
                }
                // backlog 657 - take the dept of the resource being added
                var deptUid = 0;
                var deptName = "";
                if (deptUid == null || deptUid == 0) {
                    deptUid = resgrid.GetAttribute(resrow, null, "Dept_UID");
                    deptName = resgrid.GetAttribute(resrow, null, "Dept_Name");
                }
                var wresId = resgrid.GetAttribute(resrow, null, "Res_UID");
                var resName = resgrid.GetAttribute(resrow, null, "Res_Name");
                plangrid.SetAttribute(childplanrow, null, "Group", group, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "Project_UID", projectID, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "GUID", thisguid, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "Status", const_Commitment, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "Private", parentprivate, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "CCRole_UID", ccroleUid, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "CCRoleParent_UID", ccroleParentUid, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "Role_UID", roleUid, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "Dept_UID", deptUid, 0, 0);
                plangrid.SetAttribute(childplanrow, "PendingRes_UID", null, wresId, 0, 0);
                plangrid.SetAttribute(childplanrow, "PendingRes_Name", null, resName, 0, 0);

                plangrid.SetValue(childplanrow, "Project_Name", projectName, 1);
                plangrid.SetValue(childplanrow, "CCRole_Name", ccroleName, 1);
                plangrid.SetValue(childplanrow, "CCRoleParent_Name", ccroleParentName, 1);
                plangrid.SetValue(childplanrow, "Role_Name", roleName, 1);
                plangrid.SetValue(childplanrow, "Dept_Name", deptName, 1);
                this.SetResNamesColumn(plangrid, childplanrow, status);
                plangrid.SetValue(childplanrow, "ItemName", resName, 1);
                for (var c = 0; c < plangrid.ColNames[2].length; c++) {
                    var col = plangrid.ColNames[2][c];
                    var sType = col.substring(0, 1);
                    if (sType == "Q") {
                        var val = this.GetPeriodValue(plangrid, parentplanrow, col);
                        if (typeof val == "number") val = val / div;
                        this.SetPeriodValue(plangrid, childplanrow, col, val);
                    }
                }
                this.SetStatusAfterValueChanged(plangrid, childplanrow, bNewRow);

                this.RefreshPlanRowPeriods(plangrid, childplanrow, true);
                this.SetPlanRowEditStatus(childplanrow);
                plangrid.RefreshRow(childplanrow);
                this.CalculateResourceRowCommitted(wresId, resrow);
                this.SetStatusColumn(plangrid, childplanrow, null, null, 1);
            }

            if (bReplace != true) {
                for (var c = 0; c < plangrid.ColNames[2].length; c++) {
                    var col = plangrid.ColNames[2][c];
                    var sType = col.substring(0, 1);
                    if (sType == "Q") {
                        var val = this.GetPeriodValue(plangrid, parentplanrow, col);
                        if (typeof val == "number") val = val / div;
                        this.SetPeriodValue(plangrid, parentplanrow, col, val);
                    }
                }
                this.SetStatusAfterValueChanged(plangrid, parentplanrow, false);
                this.RefreshPlanRowPeriods(plangrid, parentplanrow, true);
                this.SetPlanRowEditStatus(parentplanrow);
                plangrid.RefreshRow(parentplanrow);
                var wresId = plangrid.GetAttribute(parentplanrow, null, "Res_UID");
                var resrow = this.FindResourceRow(wresId);
                this.CalculateResourceRowCommitted(wresId, resrow);
                this.SetStatusColumn(plangrid, parentplanrow, null, null, 1);
            }

            if (origwresId > 0) {
                var resrow = this.FindResourceRow(origwresId);
                this.CalculateResourceRowCommitted(origwresId, resrow);
            }
            if (origpendingwresId > 0) {
                var resrow = this.FindResourceRow(origpendingwresId);
                this.CalculateResourceRowCommitted(origpendingwresId, resrow);
            }

            this.UpdateButtonsAsync();
            return true;
        }
        return false;
    };
    RPEditor.prototype.ReplacePlanResource = function (resrows, planrow) {
        for (var i = 0; i < resrows.length; i++) {
            var resrow = resrows[i];
            var plangrid = this.plangrid;
            var resgrid = this.resgrid;
            var status = plangrid.GetAttribute(planrow, null, "Status");

            var deptUid = resgrid.GetAttribute(resrow, null, "Dept_UID");
            var deptName = resgrid.GetAttribute(resrow, null, "Dept_Name");
            var wresId = resgrid.GetAttribute(resrow, null, "Res_UID");
            var resName = resgrid.GetAttribute(resrow, null, "Res_Name");
            //var isGeneric = resgrid.GetAttribute(resrow, null, "IsGeneric");
            if (status == const_Commitment) {
                plangrid.SetAttribute(planrow, null, "Dept_UID", deptUid, 0, 0);
                plangrid.SetValue(planrow, "Dept_Name", deptName, 1);
            }
            plangrid.SetAttribute(planrow, null, "PendingRes_UID", wresId, 0, 0);
            plangrid.SetAttribute(planrow, null, "PendingRes_Name", resName, 0, 0);
            this.SetResNamesColumn(plangrid, planrow, status);
            plangrid.SetValue(planrow, "ItemName", resName, 1);
            plangrid.RefreshRow(planrow);
        }
        this.UpdateButtonsAsync();
    };
    RPEditor.prototype.GridsOnAfterColResize = function (grid, col) {
        if (this.bInColResize == false) {
            this.bInColResize = true;
            if (grid.Cols[col].Sec == 2) {
                var sType = col.substring(0, 1);
                if (sType == "Q") {
                    var lWidth = grid.GetAttribute(null, col, "Width");
                    this.SetPeriodColsWidth(grid, lWidth, false);
                }
            }
            else {
                this.SetPaddingWidth();
            }
            this.bInColResize = false;
        }
    };
    RPEditor.prototype.SetPeriodColsWidth = function (grid, lWidth, bThisGridOnly) {
        if (lWidth > 0) {
            var thisGrid;
            for (var i = 0; i < 2; i++) {
                if (bThisGridOnly == true) {
                    thisGrid = grid;
                    if (i > 0)
                        return;
                }
                else
                    if (i == 1) thisGrid = Grids["g_RPE"]; else thisGrid = Grids["g_Res"];
                thisGrid.Rendering = true;
                for (var c = 0; c < thisGrid.ColNames[2].length; c++) {
                    var cCol = thisGrid.ColNames[2][c];
                    var visible = thisGrid.GetAttribute(null, cCol, "Visible");
                    if (visible != 0) {
                        var cWidth = thisGrid.GetAttribute(null, cCol, "Width");
                        if (cWidth > 0) {
                            var cType = cCol.substring(0, 1);
                            if (cType == "Q") {
                                var dx = lWidth - cWidth;
                                if (dx != 0) {
                                    try { thisGrid.SetWidth(cCol, dx); } catch (e) { }
                                }
                            }
                        }
                    }
                }
                thisGrid.Rendering = false;
                thisGrid.Update();
            }
        }
    };
    RPEditor.prototype.OnBeforeUnload = function (event) {
        if (this.HasChanges() && this.ExitConfirmed == false)
            event.returnValue = "You have unsaved changes.\n\nAre you sure you want to exit without saving?";
        this.ExitConfirmed = false;
    };
    RPEditor.prototype.OnUnload = function (event) {
    };
    RPEditor.prototype.SetPaddingWidth = function () {
        var rpeGrid = Grids["g_RPE"];
        var resGrid = Grids["g_Res"];
        var rpePad = rpeGrid.GetAttribute(null, "P1", "Width");
        var rpeSecLeft = rpeGrid.GetBodyWidth(0);
        var rpeSecMid = rpeGrid.GetBodyScrollWidth(1);
        var resPad = resGrid.GetAttribute(null, "P2", "Width");
        var resSecLeft = resGrid.GetBodyWidth(0);
        var resSecMid = resGrid.GetBodyScrollWidth(1);
        var rpeWidth = rpeSecLeft + rpeSecMid - rpePad;
        var resWidth = resSecLeft + resSecMid - resPad;
        var pad = 25;
        if (rpeWidth > resWidth) {
            var p1 = pad;
            var p2 = rpeWidth - resWidth + pad;
            var dx1 = p1 - rpePad;
            if (dx1 != 0)
                rpeGrid.SetWidth("P1", dx1);
            var dx2 = p2 - resPad;
            if (dx2 != 0)
                resGrid.SetWidth("P2", dx2);
        }
        else if (rpeWidth < resWidth) {
            var p1 = resWidth - rpeWidth + pad;
            var p2 = pad;
            var dx1 = p1 - rpePad;
            if (dx1 != 0)
                rpeGrid.SetWidth("P1", dx1);
            var dx2 = p2 - resPad;
            if (dx2 != 0)
                resGrid.SetWidth("P2", dx2);
        }
    };
    RPEditor.prototype.HandleAction = function (sAction) {
        switch (sAction) {
            case "OnStart":
                {
                    this.layout_plan.cells(const_PlanRibbonCell).hideHeader();
                    break;
                }
        }
    };
    RPEditor.prototype.GetResourceViewCommitments = function (WResID, sId) {
        var grid = Grids["g_RPE"];
        var row = grid.GetFirst(null, 0);
        var fColValue = 0.0;
        var col = "Q" + sId;
        while (row != null) {
            var rowWResID = grid.GetAttribute(row, null, "Res_UID");
            if (rowWResID == WResID) {
                var vValue = grid.GetAttribute(row, col, "Q" + sId);
                var fValue = parseFloat(vValue);
                if (isNaN(fValue) == false)
                    fColValue += fValue;
            }
            row = grid.GetNext(row);
        }
        return fColValue;
    };
    RPEditor.prototype.RefreshGrid = function (grid) {
        var row = grid.GetFirst(null, 0);
        while (row != null) {
            grid.RefreshRow(row);
            row = grid.GetNext(row);
        }
    };
    RPEditor.prototype.OnResizeInternal = function (event) {
        try {
            var divLayout = document.getElementById(this.params.ClientID + "layoutDiv");
            var xy = jsf_findAbsolutePosition(divLayout);
            var body = document.body;
            if (this.params.IsDlg == "1") {
                this.Width = body.offsetWidth - xy[0];
                this.Height = body.offsetHeight - xy[1] - 5;
            } else {
                this.Width = body.offsetWidth - xy[0] - 20;
                this.Height = body.offsetHeight - xy[1] - 20;
            }
            this.OnResize();
            if (this.initialized == true)
                this.GridsOnSectionResize(this.plangrid, 2, 0);
        }
        catch (e) {
            this.HandleException("OnResizeInternal", e);
        }
    };
    RPEditor.prototype.OnResize = function (event) {
        try {
            var lHeight = this.Height;
            var divLayout = document.getElementById(this.params.ClientID + "layoutDiv");
            if (lHeight > 300) {
                divLayout.style.height = lHeight + "px";
            }
            var lWidth = this.Width;
            if (lWidth > 300) {
                divLayout.style.width = lWidth + "px";
            }

            if (this.layout != null) {
                this.layout.cont.obj._offsetTop = 0;
                this.layout.cont.obj._offsetHeight = 0;
                this.layout.cont.obj._offsetLeft = 0;
                this.layout.cont.obj._offsetWidth = 0;
                this.layout.setSizes();
            }
        }
        catch (e) {
            this.HandleException("OnResize", e);
        }
    };
    RPEditor.prototype.SavePlan = function (bChangePrivateToPublic) {
        //document.body.style.cursor = 'wait';
        var plangrid = this.plangrid;
        if (plangrid != null) {
            if (this.HasChanges() == true) {
                plangrid.EndEdit(true);
                var planrow = plangrid.GetLast(null, 0);
                this.projectuids = "";
                var timestampNow = BuildDateTimeString(new Date().getTime());
                // NB iterating through list in reverse order so req rows can be updated correctly
                while (planrow != null) {
                    if (bChangePrivateToPublic == true) {
                        var isPrivate = plangrid.GetAttribute(planrow, null, "Private");
                        if (isPrivate == 1) {
                            plangrid.SetAttribute(planrow, "Private", null, 0, 1, 0);
                            this.SetStatusColumn(plangrid, planrow, null, null, 1);
                            this.HandleRowEvent(planrow, "PMMadePublic");
                            if (this.HasPending(plangrid, planrow, 0)) {
                                this.plangrid.SetAttribute(planrow, "PMStatus", null, 1, 1, 0);
                                this.SetPMStatusColumn(plangrid, planrow, 1);
                            }
                        }
                    }
                    var bChanged = plangrid.GetAttribute(planrow, null, "Changed");
                    if (bChanged != null && bChanged != 0) {
                        var timestamp = plangrid.GetAttribute(planrow, null, "Timestamp");
                        if (timestamp != null)
                            plangrid.SetAttribute(planrow, null, "TimestampOrig", timestamp);
                        plangrid.SetAttribute(planrow, null, "Timestamp", timestampNow, 0, 0);
                        this.projectuids = AddItemToList(this.projectuids, plangrid.GetAttribute(planrow, null, "Project_UID").toString());
                        var status = plangrid.GetAttribute(planrow, null, "Status");
                        var pmstatus = plangrid.GetAttribute(planrow, null, "PMStatus");
                        var rmstatus = plangrid.GetAttribute(planrow, null, "RMStatus");
                        var rowPrivate = plangrid.GetAttribute(planrow, null, "Private");
                        var activeCommitment = plangrid.GetAttribute(planrow, null, "ActiveCommitment");
                        if (pmstatus == 2 && rmstatus == 2 && activeCommitment == 1) {
                            this.RevertPlanRow(plangrid, planrow, status, timestampNow);
                        } else if ((pmstatus == 1 && rmstatus == 1 && rowPrivate != 1) || (this.NegotiationMode == false) || (status == const_Requirement)) {
                            this.CommitPlanRow(plangrid, planrow, status, timestampNow);
                        }
                    }
                    planrow = plangrid.GetPrev(planrow);
                }
                this.ShowWorkingPopup("divSaving");
                this.savingPlan = true;
                plangrid.Save();
            }
        }
    };
    RPEditor.prototype.RevertPlanRow = function (plangrid, planrow, status, timestampNow) {
        try {
            var resuid = plangrid.GetAttribute(planrow, null, "Res_UID");
            var resgrid = this.resgrid;
            var resrow = resgrid.GetRowById(resuid);
            var pendingresuid = plangrid.GetAttribute(planrow, null, "PendingRes_UID");
            var pendingresrow = resgrid.GetRowById(pendingresuid);
            for (var c = 0; c < plangrid.ColNames[2].length; c++) {
                var col = plangrid.ColNames[2][c];
                var sType = col.substring(0, 1);
                if (sType == "Q") {
                    var sId = col.substring(1);
                    plangrid.SetAttribute(planrow, null, "m" + sId, null, 0, 0);
                    plangrid.SetAttribute(planrow, null, "h" + sId, null, 0, 0);
                    plangrid.SetAttribute(planrow, null, "f" + sId, null, 0, 0);
                }
            }
            plangrid.SetAttribute(planrow, null, "PendingRes_UID", null, 0, 0);
            this.SetResNamesColumn(plangrid, planrow, status);
            plangrid.SetAttribute(planrow, null, "PMStatus", 0, 0, 0);
            plangrid.SetAttribute(planrow, null, "RMStatus", 0, 0, 0);
            plangrid.SetAttribute(planrow, null, "ActiveCommitment", 1, 0, 0);
            this.SetStatusColumn(plangrid, planrow, status, true, 1);
            this.SetPMStatusColumn(plangrid, planrow, 1);
            this.SetRMStatusColumn(plangrid, planrow, 1);
            this.RefreshPlanRowPeriods(plangrid, planrow, true);
            if (resrow != null) this.RefreshResourceRowPeriods(resgrid, resrow, true);
            if (pendingresrow != null) this.RefreshResourceRowPeriods(resgrid, pendingresrow, true);
            plangrid.RefreshRow(planrow);
            var reqrow = this.GetParentRequirement(planrow);
            if (reqrow != null) {
                this.UpdatePlanRowCalculatedValues(reqrow, 0);
                this.RefreshPlanRowPeriods(plangrid, reqrow, true);
                plangrid.SetAttribute(reqrow, null, "Changed", 1, 0, 0);
            }
        }
        catch (e) {
            this.HandleException("RevertPlanRow - " + event, e);
        }
    };
    RPEditor.prototype.CommitPlanRow = function (plangrid, planrow, status, timestampNow) {
        try {
            var resuid = plangrid.GetAttribute(planrow, null, "Res_UID");
            var resgrid = this.resgrid;
            var resrow = resgrid.GetRowById(resuid);
            var pendingresuid = plangrid.GetAttribute(planrow, null, "PendingRes_UID");
            var pendingresrow = resgrid.GetRowById(pendingresuid);
            var pendingresname = resgrid.GetAttribute(pendingresrow, null, "Res_Name");
            if (resrow == null) resrow = pendingresrow;
            if (pendingresrow == null) pendingresrow = resrow;
            for (var c = 0; c < plangrid.ColNames[2].length; c++) {
                var col = plangrid.ColNames[2][c];
                var sType = col.substring(0, 1);
                if (sType == "Q") {
                    var deltaHours = 0;
                    var sId = col.substring(1);
                    var mode = plangrid.GetAttribute(planrow, "m" + sId);
                    if (mode != null) {
                        plangrid.SetAttribute(planrow, null, "M" + sId, mode, 0, 0);
                        plangrid.SetAttribute(planrow, null, "m" + sId, null, 0, 0);
                    }
                    var hours = plangrid.GetAttribute(planrow, "h" + sId);
                    if (hours != null) {
                        var Hours = plangrid.GetAttribute(planrow, "H" + sId);
                        if (Hours == null)
                            Hours = 0;
                        deltaHours = hours - Hours;
                        if (hours == 0) hours = null;
                        plangrid.SetAttribute(planrow, null, "H" + sId, hours, 0, 0);
                        plangrid.SetAttribute(planrow, null, "h" + sId, null, 0, 0);
                    }
                    var fte = plangrid.GetAttribute(planrow, "f" + sId);
                    if (fte != null) {
                        if (fte == 0) fte = null;
                        plangrid.SetAttribute(planrow, null, "F" + sId, fte, 0, 0);
                        plangrid.SetAttribute(planrow, null, "f" + sId, null, 0, 0);
                    }
                    var origH = plangrid.GetAttribute(planrow, null, "H" + sId + "Orig");
                    if (origH != null) {
                        plangrid.SetAttribute(planrow, null, "H" + sId + "Orig", null, 0, 0);
                    }
                    if (deltaHours != 0) {
                        if (pendingresrow != null) {
                            this.CommitResourceRowPeriodValue(resgrid, pendingresrow, sId, deltaHours);
                        }
                        else if (resrow != null) {
                            this.CommitResourceRowPeriodValue(resgrid, resrow, sId, deltaHours);
                        }

                    }
                }
            }
            if (pendingresuid != null) {
                plangrid.SetAttribute(planrow, null, "Res_UID", pendingresuid, 0, 0);
                plangrid.SetAttribute(planrow, null, "PendingRes_UID", null, 0, 0);
                plangrid.SetAttribute(planrow, null, "Res_Name", pendingresname, 0, 0);
                plangrid.SetAttribute(planrow, null, "PendingRes_Name", "", 0, 0);
                this.SetResNamesColumn(plangrid, planrow, status);
            }
            plangrid.SetAttribute(planrow, null, "PMStatus", 0, 0, 0);
            plangrid.SetAttribute(planrow, null, "RMStatus", 0, 0, 0);
            plangrid.SetAttribute(planrow, null, "ActiveCommitment", 1, 0, 0);
            // recalc committed values

            this.SetStatusColumn(plangrid, planrow, status, true, 1);
            this.SetPMStatusColumn(plangrid, planrow, 1);
            this.SetRMStatusColumn(plangrid, planrow, 1);
            this.RefreshPlanRowPeriods(plangrid, planrow, true);
            if (pendingresrow != null) {
                this.RefreshResourceRowPeriods(resgrid, pendingresrow, true);
            }
            else if (resrow != null) {
                this.RefreshResourceRowPeriods(resgrid, resrow, true);
            }
            plangrid.RefreshRow(planrow);
        }
        catch (e) {
            this.HandleException("CommitPlanRow - " + event, e);
        }
    };
    RPEditor.prototype.dialogCallback = function (dialogResult, returnValue) {
        //        if (dialogResult) {
        //            window.location.href = window.location.href;
        //        }
    };
    RPEditor.prototype.externalEvent = function (event) {
        try {
            switch (event) {
                case "SelectPIs_OK":
                    this.SelectPIsOK();
                    break;
                case "PlanRibbon_Toggle":
                    if (this.editorTab.isCollapsed() == true) {
                        this.layout_plan.cells(const_PlanRibbonCell).fixSize(false, false);
                        this.layout_plan.cells(const_PlanRibbonCell).setHeight(120);
                        this.layout_plan.cells(const_PlanRibbonCell).fixSize(false, true);
                        this.editorTab.expand();
                        this.viewTab.expand();
                    } else {
                        this.layout_plan.cells(const_PlanRibbonCell).fixSize(false, false);
                        this.layout_plan.cells(const_PlanRibbonCell).setHeight(50);
                        this.layout_plan.cells(const_PlanRibbonCell).fixSize(false, true);
                        this.editorTab.collapse();
                        this.viewTab.collapse();
                    }
                    break;
                case "ResRibbon_Toggle":
                    if (this.resourcesTab.isCollapsed() == true) {
                        this.layout_res.cells(const_ResourceRibbonCell).fixSize(false, false);
                        this.layout_res.cells(const_ResourceRibbonCell).setHeight(68);
                        this.layout_res.cells(const_ResourceRibbonCell).fixSize(false, true);
                        this.resourcesTab.expand();
                    } else {
                        this.layout_res.cells(const_ResourceRibbonCell).fixSize(false, false);
                        this.layout_res.cells(const_ResourceRibbonCell).setHeight(22);
                        this.layout_res.cells(const_ResourceRibbonCell).fixSize(false, true);
                        this.resourcesTab.collapse();
                    }
                    break;
                case "EditorTab_SavePlan":
                    if (this.editorTab.isItemDisabled("SavePlanBtn") == true)
                        alert("There are no changes to save");
                    else {
                        if (this.CheckPlanOKToSave() == true) {
                            this.SavePlan(false);
                        }
                        break;
                    }
                    break;
                case "EditorTab_RowNote":
                    if (this.editorTab.isItemDisabled("RowNoteBtn") == true)
                        alert("Select a valid plan row to enable this button");
                    else {
                        this.GetRowNote(this.planrow);
                    }
                    break;
                case "EditorTab_RowHistory":
                    if (this.editorTab.isItemDisabled("RowHistoryBtn") == true)
                        alert("Select a valid plan row to enable this button");
                    else {
                        var lastRowEvent = this.plangrid.GetAttribute(this.planrow, null, "LastRowEvent");
                        if (lastRowEvent != 0) {
                            this.GetRowEvents(this.planrow);
                        }
                    }
                    break;
                case "EditorTab_Close":
                    {
                        if (this.editorTab.isItemDisabled("CloseBtn") != true || this.editorTab.isItemDisabled("CloseBtn2") != true) {
                            var b = true;
                            this.ExitConfirmed = false;
                            if (this.HasChanges() == true) {
                                b = window.confirm("You have unsaved changes.\n\nAre you sure you want to exit without saving?");
                            }
                            if (b) {
                                this.ExitConfirmed = true;
                                if (parent.SP.UI.DialogResult)
                                    parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                                else
                                    parent.SP.UI.ModalDialog.commonModalDialogClose(1, '');
                            }
                        }
                        break;
                    }
                case "EditorTab_Delete":
                    if (this.editorTab.isItemDisabled("DeleteBtn") == true)
                        alert("Select a plan row which can be deleted");
                    else {
                        var plangrid = Grids["g_RPE"];
                        if (plangrid != null && this.planrow != null) {
                            var planrow = this.planrow;
                            var status = plangrid.GetAttribute(planrow, null, "Status");
                            switch (status) {
                                case const_Project:
                                    var b = window.confirm("This action will delete all the rows in the plan.\n\nAre you sure?\n\nAny row values will be deleted on save.");
                                    if (b) {
                                        var row = planrow.firstChild;
                                        while (row != null) {
                                            plangrid.DeleteRow(row, 2); // 1=okmsg+del; 2=del; 3=undel
                                            row = row.nextSibling;
                                        }
                                    }
                                    break;
                                case const_Requirement:
                                case const_CommitmentCancelled:
                                case const_Commitment:
                                    var b = window.confirm("Are you sure?\n\nAny row values will be deleted on save.");
                                    if (b) {
                                        var row = plangrid.FRow;
                                        var reqrow = this.GetParentRequirement(row);
                                        plangrid.DeleteRow(row, 2); // 1=okmsg+del; 2=del; 3=undel
                                        if (reqrow != null) {
                                            this.UpdatePlanRowCalculatedValues(reqrow, 0);
                                            this.RefreshPlanRowPeriods(plangrid, reqrow, true);
                                            plangrid.SetAttribute(reqrow, null, "Changed", 1, 0, 0);
                                        }
                                        var wresId = plangrid.GetAttribute(row, null, "Res_UID");
                                        var resrow = this.FindResourceRow(wresId);
                                        if (wresId != null && resrow != null) {
                                            this.CalculateResourceRowCommitted(wresId, resrow);
                                        }
                                        wresId = plangrid.GetAttribute(row, null, "PendingRes_UID");
                                        resrow = this.FindResourceRow(wresId);
                                        if (wresId != null && resrow != null) {
                                            this.CalculateResourceRowCommitted(wresId, resrow);
                                        }
                                    }
                                    break;
                            }
                            this.UpdateButtonsAsync();
                        }
                        break;
                    }
                    break;
                case "EditorTab_Post":
                    if (this.editorTab.isItemDisabled("PostResourcePlanBtn") == true)
                        alert("A plan row must be selected");
                    else {
                        document.getElementById("idPostCheck").checked = true;
                        this.DisplayDialog(20, 30, 250, 150, "Post Cost Values", "winPostDlg", "idPostDlg", true, false);
                    }
                    break;
                case "EditorTab_Spread":
                    if (this.editorTab.isItemDisabled("SpreadBtn") == true)
                        alert("Select an editable plan row");
                    else {
                        if (this.plangrid != null && this.planrow != null) {
                            var dlg = this.wins.window("winSpreadDlg");
                            if (dlg == null) {
                                this.DisplayDialog(20, 30, 275, 265, "Allocate Hours", "winSpreadDlg", "idSpreadDlgObj", false, false);
                                this.spreadDlg_LoadData(this.plangrid, this.planrow, true);
                                document.getElementById("idSpreadAmount").select();
                            }
                            else {
                                this.spreadDlg_LoadData(this.plangrid, this.planrow, false);
                                dlg.show();
                                document.getElementById("idSpreadAmount").select();
                            }
                        }
                        break;
                    }
                    break;
                case "EditorTab_ImportWork":
                    if (this.editorTab.isItemDisabled("ImportWorkBtn") == true)
                        alert("A row must be selected to import work");
                    else {
                        var sbd = new StringBuilder();
                        sbd.append('<Execute Function="GetImportWorkHours">');
                        var projectuid = this.plangrid.GetAttribute(this.planrow, null, "Project_UID");
                        this.importWorkProjectName = this.plangrid.GetAttribute(this.planrow, null, "Project_Name");
                        sbd.append('<ProjectID>' + projectuid.toString() + '</ProjectID>');
                        sbd.append('</Execute>');

                        this.ExecuteJSON(sbd.toString());
                    }
                    break;
                case "EditorTab_ImportCostPlan":
                    if (this.editorTab.isItemDisabled("ImportCostPlanBtn") == true)
                        alert("A project row must be selected to import cost plan");
                    else {
                        var sbd = new StringBuilder();
                        sbd.append('<Execute Function="ReadCalendarCosttypeCombinations">');

                        var projectuid = this.plangrid.GetAttribute(this.planrow, null, "Project_UID");
                        sbd.append('<ProjectID>' + projectuid.toString() + '</ProjectID>');
                        sbd.append('</Execute>');

                        this.ExecuteJSON(sbd.toString());
                    }
                    break;
                case "EditorTab_Public":
                    if (this.editorTab.isItemDisabled("PublicBtn") == true)
                        alert("A private plan row must be selected");
                    else {
                        if (this.CanMakePublic(this.plangrid, this.planrow) == true) {
                            var group = this.plangrid.GetAttribute(this.planrow, null, "Group");
                            this.MakePublicOrPrivate(this.plangrid, group, true);
                        }
                    }
                    break;
                case "EditorTab_Accept":
                    if (this.CanAccept(this.plangrid, this.planrow) == true) {
                        this.ChangePMStatus(this.plangrid, this.planrow, 1);
                        this.ChangeRMStatus(this.plangrid, this.planrow, 1);
                        this.UpdateButtonsAsync();
                    }
                    break;
                case "EditorTab_Reject":
                    if (this.CanReject(this.plangrid, this.planrow) == true) {
                        this.ChangePMStatus(this.plangrid, this.planrow, 2);
                        this.ChangeRMStatus(this.plangrid, this.planrow, 2);
                        this.UpdateButtonsAsync();
                    }
                    break;
                case "EditorTab_Cancel":
                    if (this.CanCancel(this.plangrid, this.planrow, true) == true) {
                        this.Cancel(this.plangrid, this.planrow);
                    }
                    break;
                case "EditorTab_Export":
                    var plangrid = Grids["g_RPE"];
                    plangrid.Source.Export.Type = "xls";
                    plangrid.ActionExport();
                    break;
                case "PrintTopBtn":
                    var plangrid = Grids["g_RPE"];
                    plangrid.ActionPrint();
                    break;
                case "ViewTab_SelView_Changed":
                    var selectedView = this.GetSelectedView();
                    if (selectedView != null) {
                        var periods = selectedView.g_RPE.RightCols.split(",");
                        var spVal = periods[0];
                        var fpVal = periods[periods.length - 1];
                        var sp = spVal.split(":")[0].replace("Q", "");
                        var fp = fpVal.split(":")[0].replace("Q", "");
                        this.startPeriod = sp;
                        this.finishPeriod = fp;
                        this.viewTab.selectByValue("idViewTab_FromPeriod", this.startPeriod);
                        this.viewTab.selectByValue("idViewTab_ToPeriod", this.finishPeriod);
                        this.ApplyGridView("g_RPE", selectedView, true);
                        this.ApplyGridView("g_Res", selectedView, true);
                        this.ShowSelectedResourceGroup();
                        //this.UpdatePlanCalculatedValues();
                        this.RefreshPlanPeriods(false);
                        var grid = Grids["g_RPE"];
                        this.RefreshGrid(grid);
                        this.InitialiseResourceGrid();
                        this.RefreshResourcePeriods(false);
                        this.spreadDlg_LoadData(this.plangrid, this.planrow, false);
                        this.ShowHidePeriods(this.plangrid);
                        this.ShowHidePeriods(this.resgrid);
                        this.UpdateButtonsAsync();
                    }
                    break;
                case "ViewTab_SaveView":
                    this.DisplaySaveViewDialog("Save View", "save");
                    break;
                case "ViewTab_RenameView":
                    this.DisplaySaveViewDialog("Rename View", "rename");
                    break;
                case "ViewTab_DeleteView":
                    document.getElementById("id_DeleteView_Name").value = "";
                    var selectView = document.getElementById("idViewTab_SelView");
                    if (selectView != null && selectView.selectedIndex >= 0) {
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        if (selectedItem.value == '-1') {
                            alert('There is no view to delete');
                            break;
                        }
                        document.getElementById("id_DeleteView_Name").value = selectedItem.text;
                    }
                        //Changes for Issue EPML-1811
                    else if (selectView.selectedIndex == -1) {
                        var select = document.getElementById("idViewTab_SelView");
                        select.options.length = 0;
                        select.options[select.options.length] = new Option("--No Views--", "-1", false, false);
                        this.viewTab.refreshSelect("idViewTab_SelView");
                        alert('There is no view to delete');
                        break;
                    }
                    //Changes Done
                    this.DisplayDialog(20, 30, 280, 150, "Delete View", "winDeleteViewDlg", "idDeleteViewDlg", true, false);
                    break;
                case "ViewTab_SelectColumns":
                    var grid = Grids["g_RPE"];
                    grid.ActionShowColumns('Selectable');
                    break;
                case "ViewTab_RemoveSorting_Click":
                    Grids["g_RPE"].ChangeSort('');
                    break;
                case "ViewTab_ShowFilters_Click":
                    var stateOn = this.viewTab.getButtonState("idViewTab_ShowFilters");
                    var grid = Grids["g_RPE"];
                    if (stateOn == false) {
                        this.viewTab.setButtonStateOn("idViewTab_ShowFilters");
                        this.showFilters(grid);
                    } else {
                        this.viewTab.setButtonStateOff("idViewTab_ShowFilters");
                        this.hideFilters(grid);
                    }
                    break;
                case "ViewTab_DisplayedValues_Changed":
                    var modeSelection = document.getElementById("idViewTab_DisplayedValues");
                    if (modeSelection != null && modeSelection.selectedIndex >= 0) {
                        var selectedItem = modeSelection.options[modeSelection.selectedIndex];
                        if (selectedItem.value != null) {
                            this.displayMode = parseInt(selectedItem.value.toString());
                        }
                    }
                    this.UpdatePlanCalculatedValues();
                    this.RefreshPlanPeriods(false);
                    var grid = Grids["g_RPE"];
                    this.RefreshGrid(grid);
                    this.InitialiseResourceGrid();
                    this.RefreshResourcePeriods(false);
                    this.spreadDlg_LoadData(this.plangrid, this.planrow, false);
                    this.UpdateButtonsAsync();
                    break;
                case "SaveView_OK":
                    this.DisplaySaveViewDialogOK();
                    break;
                case "SaveView_Cancel":
                    this.dhxWins_CloseDialog("winViewDlg");
                    break;
                case "DeleteView_OK":
                    var selectView = document.getElementById("idViewTab_SelView");
                    if (selectView.selectedIndex >= 0) {
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        var deleteViewGuid = selectedItem.value;
                        var sbd = new StringBuilder();
                        sbd.append('<Execute Function="DeleteResourcePlanView">');
                        sbd.append('<View ViewGUID="' + XMLValue(deleteViewGuid) + '" />');
                        sbd.append('</Execute>');

                        this.ExecuteJSON(sbd.toString());
                    }
                    break;
                case "DeleteView_Cancel":
                    this.dhxWins_CloseDialog("winDeleteViewDlg");
                    break;
                case "ResourcesTab_Add":
                    if (this.resourcesTab.isItemDisabled("ResAddBtn") == true) {
                        var resrows = this.GetSelDataRows(this.resgrid);
                        if (this.planrow == null)
                            alert("Add button disabled - a plan row must be selected");
                        else if (resrows == null || resrows.length == 0)
                            alert("Add button disabled - one or more candidate rows must be selected");
                    } else {
                        var rows = this.GetSelDataRows(this.resgrid);
                        this.HandleAddSplitOrReplace(rows, this.planrow, true);
                    }
                    break;
                case "ResourcesTab_Analyze":
                    if (this.resourcesTab.isItemDisabled("ResAnalyzeBtn") == true) {
                        var resrows = this.GetSelDataRows(this.resgrid);
                        if (resrows == null || resrows.length == 0)
                            alert("One or more candidate rows must be selected");
                    } else {
                        var resuids = this.GetSelectedCandidateUids(this.resgrid);
                        var sb = new StringBuilder();
                        sb.append('<Execute Function="CreateTicket" Context="ResourceAnalyzer">');
                        sb.append('<Data>' + resuids + '</Data>');
                        sb.append('</Execute>');
                        this.ExecuteJSON(sb.toString(), "GeneralFunctions");
                    }
                    break;
                case "ResourcesTab_Match":
                    var resgrid = Grids["g_Res"];
                    //resgrid.Rendering = true;
                    this.HandleMatch();
                    //resgrid.Rendering = false;
                    resgrid.RenderBody();
                    break;
                case "ResourcesTab_Select_Changed":
                    var select = document.getElementById("idResourcesTab_Select");
                    var selectedItem = select.options[select.selectedIndex];
                    this.ResourcesSelectMode = parseInt(selectedItem.value);
                    this.ShowSelectedResourceGroup();
                    break;
                case "ResourcesTab_SelectColumns":
                    var grid = Grids["g_Res"];
                    grid.ActionShowColumns('Selectable');
                    break;
                case "ResourcesTab_ShowFilters_Click":
                    var stateOn = this.resourcesTab.getButtonState("idResourcesTab_ShowFilters");
                    var grid = Grids["g_Res"];
                    if (stateOn == false) {
                        this.resourcesTab.setButtonStateOn("idResourcesTab_ShowFilters");
                        this.showFilters(grid);
                    } else {
                        this.resourcesTab.setButtonStateOff("idResourcesTab_ShowFilters");
                        this.hideFilters(grid);
                    }
                    break;
                case "ResourcesTab_IncludePending_Click":
                    var stateOn = this.resourcesTab.getButtonState("idResourcesTab_IncludePending");
                    var grid = Grids["g_Res"];
                    if (stateOn == false) {
                        this.resourcesTab.setButtonStateOn("idResourcesTab_IncludePending");
                        this.includePending = true;
                    } else {
                        this.resourcesTab.setButtonStateOff("idResourcesTab_IncludePending");
                        this.includePending = false;
                    }
                    this.RefreshResourcePeriods(true);
                    this.UpdateButtonsAsync();
                    break;
                case "ResourcesTab_ShowMe_Changed":
                    var selectShowMe = document.getElementById("idResourcesTab_ShowMe");
                    var selectedItem = selectShowMe.options[selectShowMe.selectedIndex];
                    this.ResourceDisplayMode = selectedItem.value;
                    this.RefreshResourcePeriods(false);
                    this.UpdateButtonsAsync();
                    break;
                case "ResourcesTab_ShowGrouping_Click":
                    var stateOn = this.resourcesTab.getButtonState("idResourcesTab_ShowGrouping");
                    var grid = Grids["g_Res"];
                    if (stateOn == false) {
                        this.resourcesTab.setButtonStateOn("idResourcesTab_ShowGrouping");
                        this.showGrouping(grid);
                    } else {
                        this.resourcesTab.setButtonStateOff("idResourcesTab_ShowGrouping");
                        this.hideGrouping(grid);
                    }
                    grid.Render();
                    break;
                case "ResourcesTab_ShowHeatmap_Click":
                    var stateOn = this.resourcesTab.getButtonState("idResourcesTab_ShowHeatmap");
                    if (stateOn == false) {
                        this.resourcesTab.setButtonStateOn("idResourcesTab_ShowHeatmap");
                        this.showHeatmap = true;
                    } else {
                        this.resourcesTab.setButtonStateOff("idResourcesTab_ShowHeatmap");
                        this.showHeatmap = false;
                    }
                    this.InitialiseResourceGrid();
                    this.RefreshResourcePeriods(false);
                    this.UpdateButtonsAsync();
                    break;
                case "ResourcesTab_RemoveSorting_Click":
                    Grids["g_Res"].ChangeSort('');
                    break;
                case "spreadDlg_Close":
                    this.wins.window("winSpreadDlg").hide();
                    break;
                case "spreadDlg_Apply":
                    this.spreadDlg_Apply();
                    break;
                case "splitDlg_Split":
                    this.SplitPlanRow(this.resrows, this.planrow, false);
                    this.dhxWins_CloseDialog("winSplitDlg");
                    break;
                case "splitDlg_Replace":
                    this.SplitPlanRow(this.resrows, this.planrow, true);
                    this.dhxWins_CloseDialog("winSplitDlg");
                    break;
                case "splitDlg_Cancel":
                    this.dhxWins_CloseDialog("winSplitDlg");
                    break;
                case "fulfillDlg_Fulfill":
                    var projectID = this.plangrid.GetAttribute(this.planrow, null, "Project_UID");
                    var projectName = this.plangrid.GetAttribute(this.planrow, null, "Project_Name");
                    this.AddRowsToPlan(this.planrow, this.resrows, projectID, projectName, false);
                    this.plangrid.DoGrouping(this.plangrid.Group);
                    this.dhxWins_CloseDialog("winFulfillDlg");
                    break;
                case "fulfillDlg_Replace":
                    this.SplitPlanRow(this.resrows, this.planrow, true);
                    this.dhxWins_CloseDialog("winFulfillDlg");
                    break;
                case "fulfillDlg_Cancel":
                    this.dhxWins_CloseDialog("winFulfillDlg");
                    break;
                case "postDlg_OK":
                    var sbd = new StringBuilder();
                    sbd.append('<Execute Function="PostCostValues">');

                    var projectuid = this.plangrid.GetAttribute(this.planrow, null, "Project_UID");
                    sbd.append('<ProjectID>' + projectuid.toString() + '</ProjectID>');
                    if (document.getElementById("idPostCheck").checked == true)
                        sbd.append('<Publish>1</Publish>');
                    if (document.getElementById("idPostBaselineCheck").checked == true)
                        sbd.append('<PublishBaseline>1</PublishBaseline>');
                    sbd.append('</Execute>');

                    this.ExecuteJSON(sbd.toString());
                    this.dhxWins_CloseDialog("winPostDlg");
                    break;
                case "postDlg_Cancel":
                    this.dhxWins_CloseDialog("winPostDlg");
                    break;
                case "invalidResDeptsDlg_Forward":
                    var idSelect = document.getElementById("idSelectPlanResources");
                    var options = idSelect.options;
                    for (var i = 0; i < options.length; i++) {
                        var option = options[i];
                        if (option != null && option.selected == true) {
                            var planrow = this.FindPlanRow(option.value);
                            var resuid = this.plangrid.GetAttribute(planrow, null, "Res_UID");
                            var resrow = this.FindResourceRow(resuid);
                            if (resrow != null) {
                                var deptUid = this.resgrid.GetAttribute(resrow, null, "Dept_UID");
                                var deptName = this.resgrid.GetAttribute(resrow, null, "Dept_Name");
                                this.plangrid.SetValue(planrow, "Dept_UID", deptUid, 1);
                                this.plangrid.SetValue(planrow, "Dept_Name", deptName, 1);
                            }
                        }
                    }
                    this.UpdateButtonsAsync();
                    this.dhxWins_CloseDialog("winInvalidResDeptsDlg");
                    break;
                case "invalidResDeptsDlg_Cancel":
                    this.dhxWins_CloseDialog("winInvalidResDeptsDlg");
                    break;
                case "Costtype_Import":
                    this.ImportCostValues();
                    this.dhxWins_CloseDialog("winSelectCostValuesDlg");
                    break;
                case "Costtype_Cancel":
                    this.dhxWins_CloseDialog("winSelectCostValuesDlg");
                    break;
                case "ViewTab_FromPeriod_Changed":
                case "ViewTab_ToPeriod_Changed":
                    var from = document.getElementById('idViewTab_FromPeriod');
                    var sp = parseInt(from.options[from.selectedIndex].value);
                    if (sp == 0 && this.currentPeriod != null)
                        sp = this.currentPeriod;
                    var to = document.getElementById('idViewTab_ToPeriod');
                    var fp = parseInt(to.options[to.selectedIndex].value);

                    if (sp > fp) {
                        alert("The 'From' period cannot be after the 'To' Period");
                        this.viewTab.selectByValue("idViewTab_FromPeriod", this.startPeriod);
                        this.viewTab.selectByValue("idViewTab_ToPeriod", this.finishPeriod);
                    }
                    else {
                        this.startPeriod = sp;
                        this.finishPeriod = fp;
                        this.ShowHidePeriods(this.plangrid);
                        this.ShowHidePeriods(this.resgrid);
                    }
                    break;
                case "privateRowsDlg_Yes":

                    this.dhxWins_CloseDialog("winPrivateRowsDlg");
                    this.SavePlan(true);
                    break;
                case "privateRowsDlg_No":
                    this.SavePlan(false);
                    this.dhxWins_CloseDialog("winPrivateRowsDlg");
                    break;
                case "privateRowsDlg_Cancel":
                    this.dhxWins_CloseDialog("winPrivateRowsDlg");
                    break;
                case "notificationRowDlg_Close":
                    this.dhxWins_CloseDialog("winNotificationDlg");
                    break;
                case "ImportWork_Apply":
                    this.ApplyResourceWork();
                    break;
                case "ImportWork_Cancel":
                    this.dhxWins_CloseDialog("winImportWorkDlg");
                    break;
                default:
                    alert("unhandled external event - " + event);
                    break;
            }
        }
        catch (e) {
            this.HandleException("externalEvent - " + event, e);
        }
    };
    RPEditor.prototype.ShowSelectedResourceGroup = function () {
        var resgrid = this.resgrid;
        var sort = resgrid.Sort;
        if (this.ResourcesSelectMode == 4) {
            resgrid.ShowCol("Match");
            if (sort != "-Match")
                resgrid.ChangeSort("-Match");
        }
        else {
            resgrid.HideCol("Match");
            if (sort == "Match" || sort == "-Match")
                resgrid.ChangeSort("");
        }
        var row = resgrid.GetFirst(null, 0);
        while (row != null) {
            var show = this.FilterResourceRow(resgrid, row);
            row.Visible = show;
            row = resgrid.GetNext(row);
        }
        row = resgrid.GetFirst(null, 0);
        if (this.initialized == true) {
            //resgrid.DoFilter();
            if (resgrid.Group != "")
                resgrid.DoGrouping(resgrid.Group);
            else
                resgrid.RenderBody();
        }
        this.SetPaddingWidth();
        this.HideUnusedGroupRowsAsync();
    };
    RPEditor.prototype.GridsOnRowFilter = function (grid, row, show) {
        if (grid.id == "g_RPE") {
            var plangrid = grid;
            var planrow = row;
            var status = plangrid.GetAttribute(planrow, null, "Status");
            //            switch (status) {
            //                case const_Project:
            //                    return true;
            //                case const_Requirement:
            //                    return true;
            //            }
            return show;
        }
        if (grid.id != "g_Res")
            return show;
        if (show == false)
            return show;
        return this.FilterResourceRow(grid, row);
    }
    RPEditor.prototype.FilterResourceRow = function (grid, row) {
        var show = true;
        var resgrid = grid;
        switch (this.ResourcesSelectMode) {
            case 0: // show all
                break;
            case 1: // show generic
                if (resgrid.GetAttribute(row, null, "IsGeneric") != 1)
                    return false;
                break;
            case 2: // show plan
                var resarr = this.GetPlanResourceArray();
                var resuid = resgrid.GetAttribute(row, null, "Res_UID");
                if (resarr[resuid] == null)
                    return false;
                break;
            case 3: // show team
                var resarr = this.GetPlanResourceArray();
                var resuid = resgrid.GetAttribute(row, null, "Res_UID");
                if (resgrid.GetAttribute(row, null, "InTeam") == null && resarr[resuid] == null)
                    return false;
                break;
            case 4: // match
                var match = resgrid.GetAttribute(row, null, "Match");
                if (match == null || match <= 0)
                    return false;
                break;
            case 5: // none
                return false;
            default:
                //alert("unknown resource select mode - '" + this.ResourcesSelectMode + "'");
                break;
        }
        return show;
    };
    //    RPEditor.prototype.GridsOnGroup = function (grid, Group) {
    //        if (grid.id != "g_Res")
    //            return;
    //    };
    //    RPEditor.prototype.GridsOnGroupFinish = function (grid) {
    //        if (grid.id != "g_Res")
    //            return;
    //    };
    RPEditor.prototype.GridsOnFilter = function (grid, type) {
        if (grid.id != "g_Res")
            return false;
        if (type == 0 && grid.Group != "" && grid.Grouping == 1) {
            grid.DoGrouping(grid.Group);
            return true;
        }
        return false;
    };
    RPEditor.prototype.GridsOnFilterFinish = function (grid, type) {
        if (grid.id != "g_Res")
            return;
        if (type == 2 && grid.Group != "" && grid.Grouping == 1)
            this.HideUnusedGroupRowsAsync();
    };
    RPEditor.prototype.HideUnusedGroupRowsAsync = function () {
        //window.setTimeout(function () { var grid = Grids["g_Res"]; var row = grid.GetFirst(null, 0); HideUnusedGroupRows(grid, row); }, 100);
        var grid = Grids["g_Res"];
        var row = grid.GetFirst(null, 0);
        HideUnusedGroupRows(grid, row, 0);
    };
    RPEditor.prototype.DisplaySaveViewDialog = function (title, action) {
        document.getElementById("id_SaveView_Name").value = "New View";
        document.getElementById("id_SaveView_Guid").value = "";
        document.getElementById("id_SaveView_Action").value = action;
        var objDefault = document.getElementById("id_SaveView_Default");
        objDefault.checked = false;
        if (action == "rename") objDefault.disabled = true; else objDefault.disabled = false;
        document.getElementById("id_SaveView_Personal").checked = false;
        var selectView = document.getElementById("idViewTab_SelView");
        if (selectView != null && selectView.selectedIndex >= 0) {
            var view = this.GetSelectedView();
            if (view != null) {
                var selectedItem = selectView.options[selectView.selectedIndex];
                document.getElementById("id_SaveView_Name").value = selectedItem.text;
                document.getElementById("id_SaveView_Guid").value = selectedItem.value;
                var bDefault = false;
                if (view.Default != 0)
                    bDefault = true;
                objDefault.checked = bDefault;
                var bPersonal = false;
                if (view.Personal != 0)
                    bPersonal = true;
                document.getElementById("id_SaveView_Personal").checked = bPersonal;
            }
        }
        this.DisplayDialog(20, 30, 280, 165, title, "winViewDlg", "idSaveViewDlg", true, false);
    };
    RPEditor.prototype.DisplaySaveViewDialogOK = function () {
        var bDefault = document.getElementById("id_SaveView_Default").checked;
        var bPersonal = document.getElementById("id_SaveView_Personal").checked;
        var saveViewName = document.getElementById("id_SaveView_Name").value;

        // To check entered value is blank or with only space.
        var val = saveViewName.replace(/^\s+|\s+$/, '');
        if (val.length == 0) {
            alert("Please enter a view name");
            return;
        }

        var action = document.getElementById("id_SaveView_Action").value;
        //var bCanSave = true;

        var bNameChanged = false;
        var selectedView = this.GetSelectedView();
        if (selectedView != null) {
            if (selectedView.Name != saveViewName) {
                var selectView = document.getElementById("idViewTab_SelView");
                for (var i = 0; i < selectView.options.length; i++) {
                    if (selectView.options[i].text == saveViewName) {
                        alert("View name already exists");
                        return;
                    }
                }
                bNameChanged = true;
            }
        }
        var guid = new Guid();
        guid.value = document.getElementById("id_SaveView_Guid").value;
        switch (action) {
            case "save":
                // if view name changed then 1. check name valid; 2. do saveas; else do save;
                if (guid.isGuid() != true || bNameChanged)
                    guid.newGuid();
                break;
            case "rename":
                if (bNameChanged == false) {
                    alert("View name hasn't changed");
                    return;
                }
                break;
        }

        if (guid.isGuid() != true)
            guid.newGuid();

        var s = this.BuildViewInf(guid.value, saveViewName, bDefault, bPersonal);
        var sbd = new StringBuilder();
        sbd.append('<Execute Function="SaveResourcePlanView">');
        sbd.append(s);
        sbd.append('</Execute>');

        this.ExecuteJSON(sbd.toString());
    };
    RPEditor.prototype.GetRowNote = function (planrow) {
        try {
            var status = this.plangrid.GetAttribute(planrow, null, "Status");
            if (status != null && status != const_Project) {
                var sbd = new StringBuilder();
                sbd.append('<Execute Function="GetRowNote">');
                sbd.append('<guid>' + this.plangrid.GetAttribute(planrow, null, "GUID") + '</guid>');
                sbd.append('</Execute>');
                this.ExecuteJSON(sbd.toString());
            }
        }
        catch (e) {
            this.HandleException("GetRowNote", e);
        }
    };
    RPEditor.prototype.GetRowEvents = function (planrow) {
        try {
            var status = this.plangrid.GetAttribute(planrow, null, "Status");
            if (status != null && status != const_Project) {
                var sbd = new StringBuilder();
                sbd.append('<Execute Function="GetRowEvents">');
                sbd.append('<guid>' + this.plangrid.GetAttribute(planrow, null, "GUID") + '</guid>');
                sbd.append('</Execute>');
                this.ExecuteJSON(sbd.toString());
            }
        }
        catch (e) {
            this.HandleException("GetRowEvents", e);
        }
    };
    RPEditor.prototype.FindPendingNotification = function (planrow) {
        var planrowGuid = this.plangrid.GetAttribute(planrow, null, "GUID");
        return this.pendingNotification[planrowGuid];
    };
    RPEditor.prototype.NoteInitialize = function (planrow, mode, html) {
        var plangrid = this.plangrid;
        var oNote = {};
        oNote.planrow = planrow;
        oNote.timestamp = new Date().getTime();
        oNote.HTML = html;
        var projectName = plangrid.GetAttribute(planrow, null, "Project_Name");
        var resname = plangrid.GetAttribute(planrow, null, "Res_Name");
        switch (mode) {
            case "CreateRowNote":
                oNote.dialogTitle = "Create Note for row " + resname + " on project " + projectName;
                break;
            case "EditRowNote":
                oNote.dialogTitle = "Edit Note for row " + resname + " on project " + projectName;
                break;
        }
        return oNote;
    };
    RPEditor.prototype.DisplayRowNoteDialog = function (oNote) {
        try {
            if (oNote != null) {
                dhtmlx.image_path = "/_layouts/epmlive/dhtml/xeditor/imgs/";
                var dlg = this.DisplayDialog(20, 30, 500, 420, oNote.dialogTitle, "winRowNoteDlg", "idRowNoteDlg", true, true);

                this.noteEditor = new dhtmlXEditor("idRowNoteEditor");
                this.noteEditor.setContent(oNote.HTML);
                this.noteEditor.init();

                dlg.show();
            }
        }
        catch (e) {
            this.HandleException("DisplayRowNoteDialog", e);
        }
    };
    RPEditor.prototype.HandleRowEvent = function (row, action) {
        try {
            if (this.NegotiationMode != true) return;
            var grid = this.plangrid;
            var status = grid.GetAttribute(row, null, "Status");
            if (status != const_Commitment) return;
            var activeCommitment = grid.GetAttribute(row, null, "ActiveCommitment");
            var rowEvent = null;
            var rowEventTitle = null;
            var rowEventHtml = null;
            var resName = grid.GetAttribute(row, null, "Res_Name");
            if (resName == null)
                resName = grid.GetAttribute(row, null, "PendingRes_Name");
            if (activeCommitment != 1) {
                switch (action) {
                    case "PMMadePrivate": //
                    case "PMStatusNone": //
                    case "RMStatusNone": //
                        break;
                    case "PMMadePublic": //
                        rowEvent = 11;
                        rowEventTitle = resName + ": Proposed";
                        break;
                    case "RMStatusAccepted": //
                        var PMStatus = grid.GetAttribute(row, null, "PMStatus");
                        if (PMStatus == 1) {
                            rowEvent = 12;
                            rowEventTitle = resName + ": Commitment Agreed";
                        } else {
                            rowEvent = 13;
                            rowEventTitle = resName + ": Offered";
                        }
                        break;
                    case "RMStatusRejected": //
                        rowEvent = 14;
                        rowEventTitle = resName + ": Proposal Rejected";
                        break;
                    case "PMStatusAccepted": //
                        var RMStatus = grid.GetAttribute(row, null, "RMStatus");
                        if (RMStatus == 1) {
                            rowEvent = 15;
                            rowEventTitle = resName + ": Commitment Agreed";
                        } else {
                            rowEvent = 16;
                            rowEventTitle = resName + ": Proposed";
                        }
                        break;
                    case "PMStatusRejected": //
                        rowEvent = 17;
                        rowEventTitle = resName + ": Offer Rejected";
                        break;
                    case "PMCancel":
                        rowEvent = 41;
                        rowEventTitle = resName + ": Proposal Cancelled";
                        break;
                    case "PMNewRow":
                        rowEvent = 16;
                        rowEventTitle = resName + ": Proposed";
                        break;
                    case "PMChange":
                        rowEvent = 16;
                        rowEventTitle = resName + ": Proposal Changed";
                        break;
                    case "RMNewRow":
                        rowEvent = 13;
                        rowEventTitle = resName + ": Proposed";
                        break;
                    case "RMChange":
                        rowEvent = 13;
                        rowEventTitle = resName + ": Proposal Changed";
                        break;
                    case "RMCancel":
                        break;
                    default:
                        alert("HandleRowEvent - Unknown Action : " + action);
                        break;
                }
            } else {
                switch (action) {
                    case "PMMadePrivate":
                    case "PMMadePublic":
                    case "PMStatusNone":
                    case "RMStatusNone":
                        break;
                    case "PMNewRow":
                        rowEvent = 21;
                        rowEventTitle = resName + ": Proposed";
                        break;
                    case "PMChange":
                        rowEvent = 21;
                        rowEventTitle = resName + ": Renegotiated";
                        break;
                    case "RMStatusAccepted":
                        var PMStatus = grid.GetAttribute(row, null, "PMStatus");
                        if (PMStatus == 1) {
                            rowEvent = 22;
                            rowEventTitle = resName + ": Commitment Agreed";
                        } else {
                            rowEvent = 23;
                            rowEventTitle = resName + ": Commitment Changes Offered";
                        }
                        break;
                    case "RMStatusRejected":
                        rowEvent = 24;
                        rowEventTitle = resName + ": Renegotiation Rejected";
                        break;
                    case "RMNewRow":
                        rowEvent = 31;
                        rowEventTitle = resName + ": Proposed";
                        break;
                    case "RMChange":
                        rowEvent = 31;
                        rowEventTitle = resName + ": Renegotiated";
                        break;
                    case "PMStatusAccepted":
                        var RMStatus = grid.GetAttribute(row, null, "RMStatus");
                        if (RMStatus == 1) {
                            rowEvent = 32;
                            rowEventTitle = resName + ": Commitment Agreed";
                        } else {
                            rowEvent = 33;
                            rowEventTitle = resName + ": Proposal Changed";
                        }
                        break;
                    case "PMStatusRejected":
                        rowEvent = 34;
                        rowEventTitle = resName + ": Renegotiation Rejected";
                        break;
                    case "PMCancel":
                        rowEvent = 42;
                        rowEventTitle = resName + ": Proposal Cancelled";
                        break;
                    case "RMCancel":
                        rowEvent = 43;
                        rowEventTitle = resName + ": Offer Cancelled";
                        break;
                    default:
                        alert("HandleRowEvent - Unknown Renegotiation Action : " + action);
                        break;
                }
            }
            this.CreatePendingRowEvent(grid, row, rowEvent, rowEventTitle, rowEventHtml);
        }
        catch (e) {
            this.HandleException("HandleRowEvent", e);
        }
    };
    RPEditor.prototype.CreatePendingRowEvent = function (grid, row, event, title, html) {
        try {
            if (event != null) {
                grid.SetAttribute(row, null, "RowEventId", event, 0, 0);
                grid.SetAttribute(row, null, "RowEventTitle", title, 0, 0);
                grid.SetAttribute(row, null, "RowEventHtml", html, 0, 0);
                this.SetRowEventColumn(grid, row, event, 1);
            }
        } catch (e) {
            this.HandleException("CreatePendingRowEvent", e);
        }
    };
    RPEditor.prototype.ClearPendingRowEvent = function (grid, row) {
        try {
            grid.SetAttribute(row, null, "RowEventId", null, 0, 0);
            grid.SetAttribute(row, null, "RowEventTitle", null, 0, 0);
            grid.SetAttribute(row, null, "RowEventHtml", null, 0, 0);
            this.SetRowEventColumn(grid, row, null, 1);
        } catch (e) {
            this.HandleException("ClearPendingRowEvent", e);
        }
    };
    RPEditor.prototype.DisplayNotificationDialog = function (planrow, html) {
        try {
            if (planrow == null) planrow = this.planrow;

            dhtmlx.image_path = "/_layouts/epmlive/dhtml/xeditor/imgs/";
            var rowName = this.plangrid.GetAttribute(planrow, null, "Res_Name");
            if (rowName == null || rowName == "") rowName = this.plangrid.GetAttribute(planrow, null, "PendingRes_Name");
            var dlgtitle = "Notification Events for plan row " + rowName;
            var dlg = this.DisplayDialog(20, 30, 500, 460, dlgtitle, "winNotificationDlg", "idRowNotificationDlg", true, true);

            //var dhxLayout = new dhtmlXLayoutObject("idRowNotificationLayout", "2E", "dhx_skyblue");
            var dhxLayout = new dhtmlXLayoutObject("idRowNotificationLayout", "1C", "dhx_skyblue");
            dhxLayout.cells("a").hideHeader();
            //dhxLayout.cells("a").setHeight(200);
            //dhxLayout.cells("a").setText("Row Notification History");
            //dhxLayout.cells("a").fixSize(false, true);
            //dhxLayout.cells("a").collapse();
            //dhxLayout.cells("a").attachHTMLString(html);
            var el = document.getElementById('idDivRowEventsHtml');
            if (html == null) html = "";
            el.innerHTML = html;
            dhxLayout.cells("a").attachObject(el);
            //            var title = this.plangrid.GetAttribute(planrow, null, "RowEventTitle");
            //            if (title == null)
            //                dhxLayout.cells("b").setText("Type below to add a comment");
            //            else
            //                dhxLayout.cells("b").setText("Pending Notification : " + title);
            //            this.noteEditor = dhxLayout.cells("b").attachEditor();
            //            var html = this.plangrid.GetAttribute(planrow, null, "RowEventHtml");
            //            if (html == null) html = "";
            //            this.noteEditor.setContent(html);
            //            this.noteEditor.init();
            dlg.show();
            //window.setTimeout("var el=document.getElementById('idDivRowEventsHtml'); el.scrollTop = el.scrollHeight;", 200);
        }
        catch (e) {
            this.HandleException("DisplayNotificationDialog", e);
        }
    };
    RPEditor.prototype.DisplayNotesDialog = function () {
        try {
            var planrow = this.planrow;
            dhtmlx.image_path = "/_layouts/epmlive/dhtml/xeditor/imgs/";
            var itemName = this.plangrid.GetAttribute(planrow, null, "ItemName");
            var dlg = this.DisplayDialog(20, 30, 500, 420, "Notes for " + itemName, "winNotesDlg", null, true, true);
            var dhxLayout = dlg.attachLayout("2E");
            dhxLayout.cells("a").hideHeader();

            dhxLayout.cells("a").attachObject(document.getElementById("gridDiv_Notes"));

            dhxLayout.cells("b").hideHeader();
            dhxLayout.cells("b").setHeight(60);
            dhxLayout.cells("b").fixSize(false, true);
            dhxLayout.cells("b").attachObject(document.getElementById("idNotesButtonsDiv"));
            this.RefreshNotesDialog(dlg);
        }
        catch (e) {
            this.HandleException("DisplayNotesDialog", e);
        }
    };
    RPEditor.prototype.RefreshNotesDialog = function (dlg) {
        try {
            if (dlg == null)
                dlg = this.wins.window("winNotesDlg");

            if (dlg == null)
                return;

            var planrow = this.planrow;
            var sbd = new StringBuilder();
            sbd.append('<![CDATA[');
            sbd.append('<Execute Function="GetPlanRowNotes">');
            sbd.append('<guid>' + this.plangrid.GetAttribute(planrow, null, "GUID") + '</guid>');
            sbd.append('</Execute>');
            sbd.append(']]>');

            var sb = new StringBuilder();
            sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
            sb.append(" data_url='" + this.params.Webservice + "'");
            sb.append(" data_method='Soap'");
            sb.append(" data_function='Execute'");
            sb.append(" data_namespace='PortfolioEngine'");
            sb.append(" data_param_Function='ResourcePlans'");
            sb.append(" data_param_Dataxml='" + sbd.toString() + "'");
            sb.append(" >");
            sb.append("</treegrid>");

            if (this.notesgrid != null)
                this.notesgrid.Dispose();

            this.notesgrid = TreeGrid(sb.toString(), "gridDiv_Notes", "g_Notes");
            dlg.show();
        }
        catch (e) {
            this.HandleException("RefreshNotesDialog", e);
        }
    };
    RPEditor.prototype.NotesDialogEvent = function (event, param) {
        try {
            var planrow = this.planrow;
            var obj;
            switch (event) {
                case "ChangeNoteRecipients":
                    break;
                case "OnClickCell":
                    var row = param;
                    if (row != null) {
                        obj = document.getElementById("idNotesDialog_View");
                        obj.disabled = false;
                    } else {
                        obj = document.getElementById("idNotesDialog_View");
                        obj.disabled = true;
                    }
                    break;
                case "SaveRowNote":
                    if (planrow != null && this.noteEditor != null) {
                        var html = this.noteEditor.getContent();
                        html = this.SaveRowNote(planrow, html);
                        var val = 0;
                        if (html != "") val = 1;
                        this.plangrid.SetAttribute(planrow, null, "RowNote", val, 0, 0);
                        this.SetRowNoteColumn(this.plangrid, planrow, 1);
                    }
                    this.dhxWins_CloseDialog("winRowNoteDlg");
                    break;
                case "CancelRowNote":
                    this.dhxWins_CloseDialog("winRowNoteDlg");
                    break;
                case "CloseRowNotificationDialog":
                    this.dhxWins_CloseDialog("winNotificationDlg");
                    this.UpdateButtonsAsync();
                    break;
                default:
                    alert("unhandled NotesDialogEvent - " + event);
                    break;
            }
        }
        catch (e) {
            this.HandleException("NotesDialogEvent", e);
        }
    };
    RPEditor.prototype.BuildNoteInf = function (action, planrow) {
        var guid = new Guid();
        var noteGuid = guid.newGuid();

        var timeNow = new Date().getTime();
        var projectID = this.plangrid.GetAttribute(planrow, null, "Project_UID");

        var sb = new StringBuilder();
        sb.append('<Note NoteGUID="' + XMLValue(noteGuid) + '"');
        sb.append(' Project_UID="' + projectID.toString() + '"');
        sb.append(" >");
        sb.append('<Timestamp>' + BuildDateTimeString(timeNow) + '</Timestamp>');
        sb.append('<Title><![CDATA[' + 'Note Title' + ']]></Title>');
        sb.append('<HTML><![CDATA[' + this.noteEditor.getContent() + ']]></HTML>');
        sb.append('</Note>');

        return sb.toString();
    };
    RPEditor.prototype.spreadDlg_Apply = function () {
        var amount = document.getElementById("idSpreadAmount").value;
        if (isNaN(amount)) {
            alert("Amount : '" + amount + "' is not a number");
            return;
        }
        var copy = document.getElementById("idSpreadCopy").checked;
        var select = document.getElementById("idSpreadStartPeriod");
        var startPeriod = select.options[select.selectedIndex].value;
        select = document.getElementById("idSpreadFinishPeriod");
        var finishPeriod = select.options[select.selectedIndex].value;
        var clearPeriods = document.getElementById("idSpreadClearPeriods").checked;
        var grid = this.plangrid;
        var row = this.planrow;
        this.spreadDlg_LoadData(grid, row, false);

        var val = amount;
        if (row != null) {
            var status = grid.GetAttribute(row, null, "Status");
            if (status == const_Project) {
                alert("Values cannot be allocated to a project row");
                return;
            }

            var jValue = null;
            var mpy = 100;
            switch (this.displayMode) {
                case 0: /* Hours */
                    jValue = ValidateStringAsNumber(val, 10, 2, false, "");
                    break;
                case 1: /* FTE */
                    jValue = ValidateStringAsNumber(val, 5, 2, false, "");
                    mpy = 10000;
                    break;
                case 2: /* FTE %*/
                    jValue = ValidateStringAsNumber(val, 7, 0, true, "");
                    break;
            }
            if (jValue == null || jValue.error != null)
                return;

            var lStartPeriod = parseInt(startPeriod.substring(1));
            var lFinishPeriod = parseInt(finishPeriod.substring(1));

            if (lStartPeriod >= lFinishPeriod) {
                alert("StartPeriod value should be less then FinishPeriod value");
                return;
            }

            if (copy == 0) {
                if (jValue.value != "") {
                    jValue.value = jValue.value / (lFinishPeriod - lStartPeriod + 1);
                }
            }
            for (var c = 0; c < grid.ColNames[2].length; c++) {
                var col = grid.ColNames[2][c];
                var sType = col.substring(0, 1);
                if (sType == "Q") {
                    var nId = parseInt(col.substring(1));
                    if (nId < lStartPeriod || nId > lFinishPeriod) {
                        if (clearPeriods != 0) {
                            this.SetPeriodValue(grid, row, col, 0);
                            grid.SetAttribute(row, col, null, "", 0, 0);
                        }
                    }
                    else if (jValue != null && jValue.error == null && jValue.value != "") {
                        var dblValue = parseFloat(jValue.value) * mpy;
                        this.SetPeriodValue(grid, row, col, dblValue);
                        var sValue = this.GetFormattedPeriodCell(grid, row, col, false, false);
                        this.GridsOnAfterValueChanged(grid, row, col, sValue);
                        grid.SetAttribute(row, col, null, sValue, 0, 0);
                    }
                }
            }

            grid.RefreshRow(row);
            var reqrow = this.GetParentRequirement(row);
            if (reqrow != null) {
                this.UpdatePlanRowCalculatedValues(reqrow, 0);
                this.RefreshPlanRowPeriods(grid, reqrow, true);
                grid.SetAttribute(reqrow, null, "Changed", 1, 0, 0);
            }
            this.UpdateButtonsAsync();
        }
    };
    RPEditor.prototype.spreadDlg_LoadData = function (grid, row, init) {

        var sUnits = "";
        var sValue = "";
        switch (this.displayMode) {
            case 0: /* Hours */
                sUnits = "Hours";
                sValue = "100";
                break;
            case 1: /* FTE */
                sUnits = "FTE";
                sValue = "1";
                break;
            case 2: /* FTE %*/
                sUnits = "FTE%";
                sValue = "100";
                break;
        }

        var dlg = this.wins.window("winSpreadDlg");
        if (dlg != null) {
            if (row != null) {
                var itemName = grid.GetAttribute(row, null, "ItemName");
                dlg.setText("Allocate " + sUnits + " to " + itemName);
            }
            else
                dlg.setText("Allocate " + sUnits + " - no row selected");
        }

        var units = document.getElementById('idSpreadUnits');
        units.innerHTML = sUnits;
        if (init == true) {
            var from = document.getElementById('idSpreadStartPeriod');
            from.options.length = 0;
            from.options.selectedIndex = -1;
            var to = document.getElementById('idSpreadFinishPeriod');
            to.options.length = 0;
            to.options.selectedIndex = -1;
            var n = 0;
            for (var c = 0; c < grid.ColNames[2].length; c++) {
                var col = grid.ColNames[2][c];
                var sType = col.substring(0, 1);
                if (sType == "Q") {
                    var sPeriod = grid.GetCaption(col);
                    var id = parseInt(col.substring(1));
                    from.options[n] = new Option(sPeriod, col);
                    if (id == this.startPeriod) from.options.selectedIndex = n;
                    to.options[n] = new Option(sPeriod, col);
                    if (id == this.finishPeriod) to.options.selectedIndex = n;
                }
                n++;
            }
            dlg.show();
            document.getElementById("idSpreadAmount").value = sValue;
        }
    };
    RPEditor.prototype.BuildViewInf = function (viewGUID, viewName, isViewDefault, isViewPersonal) {
        if (isViewDefault == true) isViewDefault = 1; else if (isViewDefault == false) isViewDefault = 0;
        if (isViewPersonal == true) isViewPersonal = 1; else if (isViewPersonal == false) isViewPersonal = 0;
        var sSettings = this.BuildPlanSettings();
        var bFilter = this.viewTab.getButtonState("idViewTab_ShowFilters");
        //var bGrouping = this.resourcesTab.getButtonState("idResourcesTab_ShowGrouping");
        var sPlanGrid = this.BuildGridInf("g_RPE", bFilter, false);
        bFilter = this.resourcesTab.getButtonState("idResourcesTab_ShowFilters");
        var bGrouping = this.resourcesTab.getButtonState("idResourcesTab_ShowGrouping");



        var sResGrid = this.BuildGridInf("g_Res", bFilter, bGrouping);

        var dataXml = '<View ViewGUID="' + XMLValue(viewGUID) + '" Name="' + XMLValue(viewName) + '" Default="'
                + isViewDefault + '" Personal="' + isViewPersonal + '">'
                + sPlanGrid
                + sResGrid
                + sSettings
                + '</View>';
        return dataXml;
    };
    RPEditor.prototype.BuildPlanSettings = function () {
        var sb = new StringBuilder();
        sb.append("<Settings ");
        sb.append(" displayMode='" + this.displayMode.toString() + "'");
        sb.append(" ResourceDisplayMode='" + this.ResourceDisplayMode + "'");
        sb.append(" ResourcesSelectMode='" + this.ResourcesSelectMode.toString() + "'");
        var from = document.getElementById('idViewTab_FromPeriod');
        if (from.options.selectedIndex == 0)
            sb.append(" UseCurrentPeriod='1'");
        sb.append(" >");
        sb.append("</Settings>");
        return sb.toString();
    };
    RPEditor.prototype.BuildGridInf = function (gridId, showFilter, showGrouping) {
        if (showFilter == true) showFilter = 1; else if (showFilter == false) showFilter = 0;
        if (showGrouping == true) showGrouping = 1; else if (showGrouping == false) showGrouping = 0;
        var grid = Grids[gridId];
        var leftCols = '';
        var cols = '';
        var rightCols = '';

        var visibleCols = grid.GetCols("Visible");
        for (var i = 0; i < visibleCols.length; i++) {
            var colName = visibleCols[i];
            var c = grid.Cols[colName];

            if (c.Sec === 0) {
                leftCols += ',' + colName + ':' + c.Width;
            } else if (c.Sec === 1) {
                cols += ',' + colName + ':' + c.Width;
            } else if (c.Sec === 2) {
                rightCols += ',' + colName + ':' + c.Width;
            }
        }

        try {
            leftCols = leftCols.substr(1);
        } catch (e) {
        }

        try {
            cols = cols.substr(1);
        } catch (e) {
        }

        try {
            rightCols = rightCols.substr(1);
        } catch (e) {
        }

        var filterRow = grid.GetRowById('Filter');
        var filters = '';
        if (filterRow !== null) {
            for (var col in grid.Cols) {
                var cell = filterRow[col + 'Filter'];

                if (cell !== undefined) {
                    if (cell !== 0) {
                        filters += ',' + col + ':' + filterRow[col] + ':' + cell;
                    }
                }
            }
        }

        if (filters.length > 0) {
            filters = filters.substr(1);
        }

        filters = showFilter + '|' + filters;

        var grouping = showGrouping + '|' + grid.Group;

        var sorting = grid.Sort;

        var dataXml = '<' + XMLValue(gridId) + ' LeftCols="' + XMLValue(leftCols) + '" Cols="' + XMLValue(cols) + '" RightCols="'
                    + XMLValue(rightCols) + '" Filters="' + XMLValue(filters) + '" Grouping="' + grouping + '" Sorting="' + sorting + '"/>';
        return dataXml;
    };
    RPEditor.prototype.addResourcesDlg_OnClose = function () {
        this.addResourcesDlg.window("winAddResourcesDlg").detachObject();
        this.addResourcesDlg = null;
    };
    RPEditor.prototype.addResourcesDlg_DialogEvent = function (event) {
        if (this.addResourcesDlg != null) {
            this.addResourcesDlg.window("winAddResourcesDlg").setModal(false);
            this.addResourcesDlg.window("winAddResourcesDlg").hide();
            this.addResourcesDlg.window("winAddResourcesDlg").detachObject();
            this.addResourcesDlg = null;
        }
    };
    RPEditor.prototype.UpdateButtonsAsync = function () {
        window.setTimeout(thisID + ".HandleButtons()", 100);
    };
    RPEditor.prototype.CheckPlanResDeptsAsync = function () {
        window.setTimeout(thisID + ".CheckPlanResDepts()", 100);
    };
    RPEditor.prototype.CheckPlanOKToSave = function () {
        var plangrid = Grids["g_RPE"];
        var planrow = plangrid.GetFirst(null, 0);
        var bPrivateRows = false;
        while (planrow != null) {
            var status = plangrid.GetAttribute(planrow, null, "Status");
            var deleted = plangrid.GetAttribute(planrow, null, "Deleted");
            if (status != const_Project && deleted != 1) {
                var resuid = plangrid.GetAttribute(planrow, null, "Res_UID");
                var pendingresuid = plangrid.GetAttribute(planrow, null, "PendingRes_UID");
                if ((resuid == null || resuid == 0) && (pendingresuid == null || pendingresuid == 0)) {
                    window.setTimeout(function () { var gridRPE = Grids["g_RPE"]; gridRPE.Focus(planrow, "ItemName"); alert("Plan cannot be saved.\n\nPlan row must have a valid resource"); }, 10);
                    return false;
                }
                var plandeptUid = plangrid.GetAttribute(planrow, null, "Dept_UID");
                if (plandeptUid == null || plandeptUid == 0) {
                    window.setTimeout(function () { var gridRPE = Grids["g_RPE"]; gridRPE.Focus(planrow, "ItemName"); alert("Plan cannot be saved.\n\nPlan row must have a valid department"); }, 10);
                    return false;
                }
            }
            if (plangrid.GetAttribute(planrow, null, "Private") == 1 && deleted != 1) {
                bPrivateRows = true;
            }
            planrow = plangrid.GetNext(planrow);
        }
        if (bPrivateRows == true) {
            this.DisplayDialog(20, 30, 340, 150, "Make Private Rows Public?", "winPrivateRowsDlg", "idPrivateRowsDlg", true, false);
            return false;
        }
        return true;
    };
    RPEditor.prototype.CheckPlanResDepts = function () {
        this.CheckPlanFTEConversions();
        var plangrid = Grids["g_RPE"];
        var planrow = plangrid.GetFirst(null, 0);
        var idSelect = document.getElementById("idSelectPlanResources");
        while (planrow != null) {
            var resuid = plangrid.GetAttribute(planrow, null, "Res_UID");
            var plandeptUid = plangrid.GetAttribute(planrow, null, "Dept_UID");
            var resrow;
            if (resuid > 0) {
                resrow = this.FindResourceRow(resuid);
                if (resrow != null) {
                    var resName = this.resgrid.GetAttribute(resrow, null, "Res_Name");
                    var resdeptUid = this.resgrid.GetAttribute(resrow, null, "Dept_UID");
                    if (plandeptUid != resdeptUid) {
                        var plandept = plangrid.GetAttribute(planrow, null, "Dept_Name");
                        var resdept = this.resgrid.GetAttribute(resrow, null, "Dept_Name");

                        var option = document.createElement("option");
                        option.text = resName + " is in department '" + resdept + "' not '" + plandept + "'";
                        option.selected = true;
                        option.value = plangrid.GetAttribute(planrow, null, "GUID");
                        idSelect.add(option, null);

                    }
                }
            }
            planrow = plangrid.GetNext(planrow);
        }
        if (idSelect.options.length > 0)
            this.DisplayDialog(20, 30, 430, 315, "Invalid Resources", "winInvalidResDeptsDlg", "idInvalidResDeptsDlg", true, true);
    };
    RPEditor.prototype.CheckPlanFTEConversions = function () {
        var plangrid = Grids["g_RPE"];
        var planrow = plangrid.GetFirst(null, 0);
        var idSelect = document.getElementById("idSelectPlanResources");
        while (planrow != null) {
            if (plangrid.GetAttribute(planrow, null, "Status") != const_Requirement) {
                if (this.ValidatePlanRowPeriodConversion(plangrid, planrow) == false) {
                    alert("Invalid Hours or FTE.\n\nAt least one period value does not match the current FTE Conversion Factor.\n\nPlease report this problem to your System Administrator.");
                    return;
                }
            }
            planrow = plangrid.GetNext(planrow);
        }

    };
    RPEditor.prototype.HasChanges = function () {
        var grid = Grids["g_RPE"];
        if (grid == null)
            return false;
        var hasChanges = grid.HasChanges();
        if ((hasChanges & (1 << 0)) != 0)
            return true;
        else
            return false;
    };
    RPEditor.prototype.GetSelDataRows = function (grid) {
        var rows = grid.GetSelRows();
        if (rows == null || rows.length == 0)
            return rows;
        var selrows = [];
        for (var r = 0; r < rows.length; r++) {
            var row = rows[r];
            if (row.Kind == "Data")
                selrows[selrows.length] = row;
        }
        return selrows;
    };
    RPEditor.prototype.GetSelectedCandidateUids = function (resgrid) {
        var s = "";
        var rows = resgrid.GetSelRows();
        if (rows == null || rows.length == 0)
            return s;
        for (var r = 0; r < rows.length; r++) {
            var resrow = rows[r];
            if (resrow.Kind == "Data") {
                if (s != "") s += ",";
                s += resgrid.GetAttribute(resrow, null, "Res_UID");
            }
        }
        return s;
    };
    RPEditor.prototype.CanDelete = function (grid, row) {
        if (this.NegotiationMode != true) return true;
        if (grid.GetAttribute(row, null, "Private") == 1) return true;
        if (grid.GetAttribute(row, null, "Status") == const_CommitmentCancelled) return true;
        if (grid.GetAttribute(row, null, "Status") == const_Requirement && row.firstChild == null) return true;
        if (grid.GetAttribute(row, null, "Added") == 1) return true;
        var PMStatus = grid.GetAttribute(row, null, "PMStatus");
        if (PMStatus != 2) return false;
        var RMStatus = grid.GetAttribute(row, null, "RMStatus");
        if (RMStatus != 2) return false;
        var activeCommitment = grid.GetAttribute(row, null, "ActiveCommitment");
        if (activeCommitment != 0) return false;
        return true;
    };
    RPEditor.prototype.CanCancel = function (grid, row, bAlert) {
        if (this.NegotiationMode != true) {
            if (bAlert == true)
                alert("Cancel is only valid in Negotiation Mode");
            return false;
        }
        if (grid.GetAttribute(row, null, "Status") != const_Commitment) {
            if (bAlert == true)
                alert("Cancel is only valid on Active Commitment Rows");
            return false;
        }
        if (grid.GetAttribute(row, null, "ActiveCommitment") != 1) {
            if (bAlert == true)
                alert("Cancel is only valid on Active Commitment Rows");
            return false;
        }
        return true;
    };
    RPEditor.prototype.Cancel = function (grid, row) {
        grid.SetAttribute(row, "Status", null, const_CommitmentCancelled, 0, 0);
        this.SetStatusColumn(grid, row, null, null, 1);
        this.SetPMStatusColumn(grid, row, 1);
        this.SetRMStatusColumn(grid, row, 1);
        this.HandleRowEvent(row, "PMCancel");
        this.UpdateButtonsAsync();
        return true;
    };
    RPEditor.prototype.CanAccept = function (grid, row, bAlert) {
        if (this.NegotiationMode != true) return false;
        if (grid.GetAttribute(row, null, "Private") == 1) return false;
        if (grid.GetAttribute(row, null, "Status") != const_Commitment) return false;
        if (this.HasPending(grid, row, 1) == false) return false;
        if (grid.GetAttribute(row, null, "UserIsPM") != 1 && grid.GetAttribute(row, null, "UserIsRM") != 1) return false;
        return true;
    };
    RPEditor.prototype.CanReject = function (grid, row, bAlert) {
        if (this.NegotiationMode != true) return false;
        if (grid.GetAttribute(row, null, "Private") == 1) return false;
        if (grid.GetAttribute(row, null, "Status") != const_Commitment) return false;
        if (this.HasPending(grid, row, 1) == false) return false;
        if (grid.GetAttribute(row, null, "UserIsPM") != 1 && grid.GetAttribute(row, null, "UserIsRM") != 1) return false;
        return true;
    };
    RPEditor.prototype.CanMakePublic = function (grid, row, bAlert) {
        if (grid.GetAttribute(row, null, "Private") != 1) return false;
        var status = grid.GetAttribute(row, null, "Status");
        switch (status) {
            case const_Project:
                return false;
            case const_Requirement:
                return true;
            case const_Commitment:
                if (this.GetParentRequirement(row) != null)
                    return false;
        }
        return true;
    };
    RPEditor.prototype.MakePublicOrPrivate = function (grid, group, bPublic) {
        var rowprivate = 1;
        var sRowEvent = "PMMadePrivate";
        if (bPublic == true) {
            sRowEvent = "PMMadePublic";
            rowprivate = 0;
        }
        var row = grid.GetFirst(null, 0);
        while (row != null) {
            if (group == grid.GetAttribute(row, null, "Group")) {
                grid.SetAttribute(row, "Private", null, rowprivate, 0, 0);
                this.SetStatusColumn(grid, row, null, null, 1);
                this.HandleRowEvent(row, sRowEvent);
                if (grid.GetAttribute(row, null, "Status") == const_Commitment && this.HasPending(grid, row, 0)) {
                    grid.SetAttribute(row, "PMStatus", null, 1, 1, 0);
                    this.SetPMStatusColumn(grid, row, 1);
                }
            }
            row = this.plangrid.GetNext(row);
        }
        this.UpdateButtonsAsync();
    };
    RPEditor.prototype.HandleButtons = function () {
        if (this.initialized != true)
            return;
        var status = 0;
        var canEdit = 0;
        var projectid = 0;
        if (this.planrow != null) {
            status = this.plangrid.GetAttribute(this.planrow, null, "Status");
            this.editorTab.enableItem("PostResourcePlanBtn");
            var canEdit = this.plangrid.GetAttribute(this.planrow, null, "UserCanEdit");
            if (canEdit != 1) canEdit = 0;
            if (this.CanMakePublic(this.plangrid, this.planrow, false) == true)
                this.editorTab.enableItem("PublicBtn");
            else
                this.editorTab.disableItem("PublicBtn");
            projectid = this.plangrid.GetAttribute(this.planrow, null, "Project_UID");
        } else {
            this.editorTab.disableItem("PostResourcePlanBtn");
        }
        if (this.HasChanges() == true) {
            this.editorTab.enableItem("SavePlanBtn");
            this.viewTab.enableItem("SavePlanBtn2");
            this.dirty = true;
        } else {
            this.editorTab.disableItem("SavePlanBtn");
            this.viewTab.disableItem("SavePlanBtn2");
            this.dirty = false;
        }

        if (this.params.HideCloseBtn != null && this.params.HideCloseBtn.toString().toLowerCase() == "true") {
            this.editorTab.disableItem("CloseBtn");
            this.viewTab.disableItem("CloseBtn2");
        }

        var grid = Grids["g_RPE"];
        if (grid.FRow != null && canEdit == 1) {
            if (this.CanDelete(grid, grid.FRow) == true)
                this.editorTab.enableItem("DeleteBtn");
            else
                this.editorTab.disableItem("DeleteBtn");
            if (this.CanCancel(grid, grid.FRow, false) == true)
                this.editorTab.enableItem("CancelBtn");
            else
                this.editorTab.disableItem("CancelBtn");
            if (this.CanAccept(grid, grid.FRow) == true)
                this.editorTab.enableItem("AcceptBtn");
            else
                this.editorTab.disableItem("AcceptBtn");
            if (this.CanReject(grid, grid.FRow) == true)
                this.editorTab.enableItem("RejectBtn");
            else
                this.editorTab.disableItem("RejectBtn");
        }
        else {
            this.editorTab.disableItem("DeleteBtn");
            this.editorTab.disableItem("CancelBtn");
            this.editorTab.disableItem("AcceptBtn");
            this.editorTab.disableItem("RejectBtn");
        }

        if (projectid > 0) {
            this.editorTab.enableItem("ImportWorkBtn");
            //this.editorTab.enableItem("ImportCostPlanBtn");
        }
        else {
            this.editorTab.disableItem("ImportWorkBtn");
            //this.editorTab.disableItem("ImportCostPlanBtn");
        }

        if (status == const_Project) {
            this.editorTab.disableItem("SpreadBtn");
            //this.editorTab.disableItem("NotesBtn");
            this.editorTab.disableItem("RowNoteBtn");
            this.editorTab.disableItem("RowHistoryBtn");
            if (this.planrow != null && canEdit == 1) {
                //this.editorTab.enableItem("ImportWorkBtn");
                this.editorTab.enableItem("ImportCostPlanBtn");
            } else {
                //this.editorTab.disableItem("ImportWorkBtn");
                this.editorTab.disableItem("ImportCostPlanBtn");
            }
            this.resourcesTab.disableItem("MatchBtn");
        }
        else {
            //this.editorTab.disableItem("ImportWorkBtn");
            this.editorTab.disableItem("ImportCostPlanBtn");
            if (this.planrow != null) {
                this.editorTab.enableItem("RowNoteBtn");
                this.editorTab.enableItem("RowHistoryBtn");
            }
            else {
                this.editorTab.disableItem("RowNoteBtn");
                this.editorTab.disableItem("RowHistoryBtn");
            }
            if (this.planrow != null && canEdit == 1) {
                this.editorTab.enableItem("SpreadBtn");
                this.resourcesTab.enableItem("MatchBtn");
            }
            else {
                this.editorTab.disableItem("SpreadBtn");
                this.resourcesTab.disableItem("MatchBtn");
            }
        }
        var resrows = this.GetSelDataRows(this.resgrid);
        if (this.planrow != null && resrows != null && resrows.length > 0 && canEdit == 1) {
            this.resourcesTab.enableItem("ResAddBtn");
        }
        else {
            this.resourcesTab.disableItem("ResAddBtn");
        }
        if (resrows != null && resrows.length > 0) {
            this.resourcesTab.enableItem("ResAnalyzeBtn");
        }
        else {
            this.resourcesTab.disableItem("ResAnalyzeBtn");
        }
    };
    RPEditor.prototype.InitialisePlanGrid = function () {
        var grid = Grids["g_RPE"];
        var row = grid.GetFirst(null, 0);
        this.startPeriod = 999999;
        this.finishPeriod = -1;
        while (row != null) {
            var status = grid.GetAttribute(row, null, "Status");
            if (status == 0) {
                var sp = grid.GetAttribute(row, null, "StartPeriod");
                if (sp != null && sp < this.startPeriod)
                    this.startPeriod = parseInt(sp);
                var fp = grid.GetAttribute(row, null, "FinishPeriod");
                if (fp != null && fp > this.finishPeriod)
                    this.finishPeriod = parseInt(fp);
            }
            var activeCommitment = grid.GetAttribute(row, null, "ActiveCommitment");
            this.SetStatusColumn(grid, row, status, activeCommitment, 0);
            this.SetResNamesColumn(grid, row, status);

            this.SetRowNoteColumn(grid, row, 0);
            this.SetPMStatusColumn(grid, row, 0);
            this.SetRMStatusColumn(grid, row, 0);
            this.SetRowEventColumn(grid, row, null, 0);
            this.UpdatePlanRowCalculatedValues(row, 1);
            row = grid.GetNext(row);
        }
        if (this.startPeriod == 999999)
            this.startPeriod = null;
        if (this.finishPeriod == -1)
            this.finishPeriod = null;

        var select = document.getElementById("idViewTab_SelView");
        select.options.length = 0;
        if (this.Views.length == 0) {
            select.options[select.options.length] = new Option("--No Views--", "-1", false, false);
        } else {
            for (var i = 0; i < this.Views.length; i++) {
                var view = this.Views[i];
                select.options[select.options.length] = new Option(view.Name, view.ViewGUID, false, false);
            }
        }
        this.viewTab.refreshSelect("idViewTab_SelView");

        var from = document.getElementById('idViewTab_FromPeriod');
        from.options.length = 0;
        from.options.selectedIndex = -1;
        from.options[from.options.length] = new Option("Current", 0);
        var to = document.getElementById('idViewTab_ToPeriod');
        to.options.length = 0;
        to.options.selectedIndex = -1;
        for (var c = 0; c < grid.ColNames[2].length; c++) {
            var col = grid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var sPeriod = grid.GetCaption(col);
                var periodid = parseInt(col.substring(1));
                if (grid.GetAttribute(null, col, "Current") == true)
                    this.currentPeriod = periodid;
                from.options[from.options.length] = new Option(sPeriod, periodid);
                if (this.startPeriod == null) {
                    this.startPeriod = periodid;
                    from.options.selectedIndex = from.options.length - 1;
                }
                else if (periodid == this.startPeriod)
                    from.options.selectedIndex = from.options.length - 1;

                to.options[to.options.length] = new Option(sPeriod, periodid);
                if (this.finishPeriod == null && c == grid.ColNames[2].length - 1) {
                    this.finishPeriod = periodid;
                    to.options.selectedIndex = to.options.length - 1;
                }
                else if (periodid == this.finishPeriod)
                    to.options.selectedIndex = to.options.length - 1;
            }
        }
        if (from.options.selectedIndex == -1) from.options.selectedIndex = 0;
        if (to.options.selectedIndex == -1) to.options.selectedIndex = to.options.length - 1;
        this.viewTab.refreshSelect("idViewTab_FromPeriod");
        this.viewTab.refreshSelect("idViewTab_ToPeriod");

        select = document.getElementById("idViewTab_DisplayedValues");
        select.options.length = 0;
        select.options[select.options.length] = new Option("Hours", 0, true, false);
        select.options[select.options.length] = new Option("FTE", 1, false, false);
        select.options[select.options.length] = new Option("FTE Percent", 2, false, false);
        //select.options[select.options.length] = new Option("FTE Conversion", 3, false, false);
        this.viewTab.refreshSelect("idViewTab_DisplayedValues");

        try { grid.CalcWidth("Res_Names", 0); } catch (e) { }
    };
    RPEditor.prototype.InitialiseResourceGrid = function () {
        var sValue = "";
        switch (this.displayMode) {
            case 0: /* Hours */
                if (this.showHeatmap != true) {
                    sValue = "0.##;<span style='color:red;'>-0.##</span>;0";
                } else {
                    sValue = "0.##;<div style='background-color:red;height:inherit;vertical-align:middle;padding:1px !important;'>-0.##</div>;0";
                }
                break;
            case 1: /* FTE */
                if (this.showHeatmap != true) {
                    sValue = "0.####;<span style='color:red;'>-0.####</span>;0";
                } else {
                    sValue = "0.####;<div style='background-color:red;height:inherit;vertical-align:middle;padding::1px !important;'>-0.####</div>;0";
                }
                break;
            case 2: /* FTE% */
                if (this.showHeatmap != true) {
                    sValue = "0\\%;<span style='color:red;'>-0\\%</span>;0";
                } else {
                    sValue = "0\\%;<div style='background-color:red;height:inherit;vertical-align:middle;padding::1px !important;'>-0\\%</div>;no value";
                }
                break;
            case 3: /* FTE Conv */
                sValue = "0;<span style='color:red;'>-0</span>;no value";
                break;
        }
        var grid = this.resgrid;
        for (var c = 0; c < grid.ColNames[2].length; c++) {
            var col = grid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                grid.SetAttribute(null, col, "Format", sValue, 0, 0);
            }
        }
    };
    RPEditor.prototype.SetResNamesColumn = function (grid, row, status) {
        if (status == const_Project) {
            var projectName = grid.GetAttribute(row, null, "Project_Name");
            grid.SetAttribute(row, null, "ItemName", projectName, 0, 0);
        }
        else {
            var resName = grid.GetAttribute(row, null, "Res_Name");
            var pendingresName = grid.GetAttribute(row, null, "PendingRes_Name");
            if (pendingresName == null) pendingresName = "";
            if (resName == null) resName = "";

            var sValue;
            if (pendingresName == "")
                sValue = resName;
            else if (resName == "")
                sValue = pendingresName;
            else
                sValue = pendingresName + "(" + resName + ")";

            grid.SetAttribute(row, null, "Res_Names", sValue, 0, 0);
            if (sValue != "")
                grid.SetAttribute(row, null, "ItemName", sValue, 0, 0);
            else {
                var sDept = grid.GetAttribute(row, null, "Dept_Name");
                if (sDept == null || sDept == "")
                    grid.SetAttribute(row, null, "ItemName", "(Unknown)", 0, 0);
                else
                    grid.SetAttribute(row, null, "ItemName", "(" + sDept + ")", 0, 0);
            }
        }
    };
    RPEditor.prototype.ChangePMStatus = function (grid, row, PMStatus) {
        if (this.HasPending(grid, row, 1) != true) return false;
        if (grid.GetAttribute(row, null, "Private") == 1) return false;
        if (grid.GetAttribute(row, null, "UserIsPM") != 1) return false;
        if (PMStatus == null) {
            PMStatus = grid.GetAttribute(row, null, "PMStatus");
            if (PMStatus == null) PMStatus = 0;
            PMStatus++;
            if (PMStatus > 1) PMStatus = 0;
        }
        grid.SetAttribute(row, "PMStatus", null, PMStatus, 1, 0);
        this.SetPMStatusColumn(grid, row, 1);
        switch (PMStatus) {
            case 0:
                this.HandleRowEvent(row, "PMStatusNone");
                break;
            case 1:
                this.HandleRowEvent(row, "PMStatusAccepted");
                break;
            case 2:
                this.HandleRowEvent(row, "PMStatusRejected");
                break;
        }
        return true;
    };
    RPEditor.prototype.SetPMStatusColumn = function (grid, row, changed0Or1) {
        var status = grid.GetAttribute(row, null, "PMStatus");
        var sClass = "";
        var sTip = "";
        switch (status) {
            case null:
            case 0:
                sClass = "rp-pm-nostatus";
                sTip = "";
                if (grid.GetAttribute(row, null, "Private") == 1) break;
                if (grid.GetAttribute(row, null, "Status") != const_Commitment) break;
                if (grid.GetAttribute(row, null, "ActiveCommitment") != 1) break;
                if (this.HasPending(grid, row, 1)) break;

                sClass = "rp-pm-accepted";
                sTip = "Active Commitment";
                break;
            case 1:
                sClass = "rp-pm-accepted";
                sTip = "Accepted";
                break;
            case 2:
                sClass = "rp-pm-rejected";
                sTip = "Rejected";
                break;
        }
        grid.SetAttribute(row, "RowPMStatus", "Class", sClass, changed0Or1, 0);
        grid.SetAttribute(row, null, "RowPMStatusTip", sTip, changed0Or1, 0);
    };
    RPEditor.prototype.ChangeRMStatus = function (grid, row, RMStatus) {
        if (this.HasPending(grid, row, 1) != true) return false;
        if (grid.GetAttribute(row, null, "Private") == 1) return false;
        if (grid.GetAttribute(row, null, "UserIsRM") != 1) return false;
        if (RMStatus == null) {
            RMStatus = grid.GetAttribute(row, null, "RMStatus");
            if (RMStatus == null) RMStatus = 0;
            RMStatus++;
            if (RMStatus > 1) RMStatus = 0;
        }
        grid.SetAttribute(row, "RMStatus", null, RMStatus, 1, 0);
        this.SetRMStatusColumn(grid, row, 1);
        switch (RMStatus) {
            case 0:
                this.HandleRowEvent(row, "RMStatusNone");
                break;
            case 1:
                this.HandleRowEvent(row, "RMStatusAccepted");
                break;
            case 2:
                this.HandleRowEvent(row, "RMStatusRejected");
                break;
        }
        return true;
    };
    RPEditor.prototype.SetRMStatusColumn = function (grid, row, changed0Or1) {
        var status = grid.GetAttribute(row, null, "RMStatus");
        var sClass = "";
        var sTip = "";
        switch (status) {
            case null:
            case 0:
                sClass = "rp-rm-nostatus";
                sTip = "";
                if (grid.GetAttribute(row, null, "Private") == 1) break;
                if (grid.GetAttribute(row, null, "Status") != const_Commitment) break;
                if (grid.GetAttribute(row, null, "ActiveCommitment") != 1) break;
                if (this.HasPending(grid, row, 1)) break;
                sClass = "rp-rm-accepted";
                sTip = "Active Commitment";
                break;
            case 1:
                sClass = "rp-rm-accepted";
                sTip = "Accepted";
                break;
            case 2:
                sClass = "rp-rm-rejected";
                sTip = "Rejected";
                break;
        }
        grid.SetAttribute(row, "RowRMStatus", "Class", sClass, changed0Or1, 0);
        grid.SetAttribute(row, null, "RowRMStatusTip", sTip, changed0Or1, 0);
    };
    RPEditor.prototype.SetRowNoteColumn = function (grid, row, changed0Or1) {
        var rowNote = grid.GetAttribute(row, null, "RowNote");
        var sClass;
        var sTip;
        if (rowNote != 1) {
            sClass = "rp-nonote";
            sTip = "";
        } else {
            sClass = "rp-note";
            sTip = "Note";
        }
        grid.SetAttribute(row, "Note", "Class", sClass, changed0Or1, 0);
        grid.SetAttribute(row, null, "NoteTip", sTip, changed0Or1, 0);
    };
    RPEditor.prototype.SetStatusColumn = function (grid, row, status, activeCommitment, changed0Or1) {
        var sClass = "";
        var sTip = "";
        if (status == null)
            status = grid.GetAttribute(row, null, "Status");
        var rowPrivate = grid.GetAttribute(row, null, "Private");
        if (rowPrivate == 1) {
            sClass = "rp-pm-private";
            sTip = "Private";
        } else {
            switch (status) {
                case const_Requirement:
                    sClass = "rp-requirement";
                    break;
                case const_Commitment:
                    if (activeCommitment == null)
                        activeCommitment = grid.GetAttribute(row, null, "ActiveCommitment");

                    if (activeCommitment != 0) {
                        if (this.HasPending(grid, row, 1)) {
                            sClass = "rp-renegotiate";
                            sTip = "Renegotiate";
                        } else {
                            sClass = "rp-commitment";
                            sTip = "Active Commitment";
                        }
                    } else {
                        sClass = "rp-negotiate";
                        sTip = "Negotiate";
                    }
                    break;
                case const_CommitmentCancelled:
                    sClass = "rp-cancelled";
                    sTip = "Cancelled";
                    break;
            }
        }
        if (sClass != "") {
            grid.SetAttribute(row, "RowStatus", "Class", sClass, changed0Or1, 0);
            grid.SetAttribute(row, null, "RowStatusTip", sTip, changed0Or1, 0);
        }
    };
    RPEditor.prototype.SetRowEventColumn = function (grid, row, event, changed0Or1) {
        if (event == null)
            event = grid.GetAttribute(row, null, "LastRowEvent");
        var sClass = "rp-rownoevent";
        if (event != null)
            sClass = "rp-rowevent" + event.toString();
        grid.SetAttribute(row, "RowEvent", "Class", sClass, changed0Or1, 0);
        grid.SetAttribute(row, null, "RowEvent", event, changed0Or1, 0);
    };
    RPEditor.prototype.HasPending = function (grid, row, includeRes) {
        if (includeRes == 1) {
            var pendingresuid = grid.GetAttribute(row, null, "PendingRes_UID");
            if (pendingresuid != null && pendingresuid > 0)
                return true;
        }
        for (var c = 0; c < grid.ColNames[2].length; c++) {
            var col = grid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var sId = col.substring(1);
                var pendingHours = grid.GetAttribute(row, null, "h" + sId);
                if (pendingHours != null)
                    return true;
            }
        }
        return false;
    };
    RPEditor.prototype.GridsOnTip = function (grid, row, col, tip, clientX, clientY, X, Y) {
        if (col == "RowStatus") {
            return grid.GetAttribute(row, null, "RowStatusTip");
        }
        return tip;
    };
    RPEditor.prototype.RefreshPlanPeriods = function (bRefresh) {
        var grid = Grids["g_RPE"];
        var row = grid.GetFirst(null, 0);
        while (row != null) {
            this.RefreshPlanRowPeriods(grid, row, bRefresh);
            row = grid.GetNext(row);
        }
    };
    RPEditor.prototype.RefreshPlanRowPeriods = function (grid, row, bRefresh) {
        var bFulfillmentMode = false;
        if (grid.GetAttribute(row, null, "Status") == const_Requirement && row.firstChild != null)
            bFulfillmentMode = true;

        for (var c = 0; c < grid.ColNames[2].length; c++) {
            var col = grid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var sValue = this.GetFormattedPeriodCell(grid, row, col, bFulfillmentMode, false);
                grid.SetAttribute(row, null, col, sValue, 0, 0);
            }
        }
        if (bRefresh) grid.RefreshRow(row);
    };
    RPEditor.prototype.FindResourceRow = function (resUID) {
        var grid = Grids["g_Res"];
        //var row = grid.GetFirst(null, 0);
        //while (row != null) {
        //    if (resUID == grid.GetAttribute(row, null, "Res_UID"))
        //        return row;
        //    row = grid.GetNext(row);
        //}
        //return null;
        return grid.GetRowById(resUID)
    };
    RPEditor.prototype.FindPlannerRow = function (resUID) {
        var grid = Grids["g_RPE"];
        var row = grid.GetFirst(null, 0);
        while (row != null) {
            var planresuid = grid.GetAttribute(row, null, "PendingRes_UID");
            if (planresuid == null) planresuid = grid.GetAttribute(row, null, "Res_UID");
            if (resUID == planresuid) {
                return row;
            }
            row = grid.GetNext(row);
        }
    };
    RPEditor.prototype.FindProjectRow = function (projectUID) {
        var grid = Grids["g_RPE"];
        var row = grid.GetFirst(null, 0);
        while (row != null) {
            if (projectUID == grid.GetAttribute(row, null, "Project_UID"))
                return row;
            row = grid.GetNext(row);
        }
        return null;
    };
    RPEditor.prototype.FindPlanRow = function (planrowGUID) {
        var grid = Grids["g_RPE"];
        var row = grid.GetFirst(null, 0);
        while (row != null) {
            if (planrowGUID == grid.GetAttribute(row, null, "GUID"))
                return row;
            row = grid.GetNext(row);
        }
        return null;
    };
    RPEditor.prototype.RefreshResourcePeriods = function (bCalculate) {
        var resgrid = Grids["g_Res"];
        //var row = resgrid.GetFirst(null, 0);
        //while (row != null) {
        //    if (bCalculate == true) {
        //        this.CalculateResourceRowCommitted(null, row);
        //    } else {
        //        this.RefreshResourceRowPeriods(resgrid, row, false);
        //    }
        //    row = resgrid.GetNext(row);
        //}
        if (this.initialized == true)
            resgrid.RenderBody();
        resgrid.Calculate(1, 0);
    };
    RPEditor.prototype.CalculateResourceRowCommitted = function (resuid, resrow) {
        if (resuid == null)
            resuid = Grids["g_Res"].GetAttribute(resrow, null, "Res_UID");
        var plangrid = this.plangrid;
        var plannerRow = this.FindPlannerRow(resuid);
        var colNames = plangrid.ColNames[2];
        var colLength = colNames.length;
        for (var c = 0; c < colLength; c++) {
            var col = colNames[c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var periodid = col.substring(1);
                this.CalculateResourceRowPeriodCommitted(resuid, resrow, periodid, false, plannerRow);
            }
        }
        this.RefreshResourceRowPeriods(this.resgrid, resrow, true);
    };
    RPEditor.prototype.CalculateResourceRowPeriodCommitted = function (resuid, resrow, periodid, bRefreshCell, plannerRow) {
        var plangrid = this.plangrid;
        // "C" + periodid represents all the committed hours for a resource on all projects (including this one)
        // deltaC is the difference between the committed hours when the plan was opened vs the committed hours now and, optionally, can include pending on this project
        var deltaC = 0;
        if (plannerRow != null) {
            var lHours = this.GetIntValue(plangrid.GetAttribute(plannerRow, null, "H" + periodid), 0);
            var deleted = plangrid.GetAttribute(plannerRow, null, "Deleted");
            if (deleted == 1) {
                if (lHours == 0)
                    deltaC -= this.GetIntValue(this.GetPeriodHoursSpecial(plangrid, plannerRow, "H" + periodid), 0);
                else
                    deltaC -= lHours;
            }
            else {
                deltaC += this.GetIntValue(this.GetPeriodHoursSpecial(plangrid, plannerRow, "H" + periodid), 0) - lHours;
            }
        }
        this.resgrid.SetAttribute(resrow, null, "D" + periodid, deltaC, 0, 0);
        if (bRefreshCell) {
            this.RefreshResourceRowPeriod(this.resgrid, resrow, periodid, bRefreshCell);
        }
    };
    RPEditor.prototype.CommitResourceRowPeriodValue = function (resuid, resrow, periodid, deltaHours) {
        if (deltaHours != 0) {
            var grid = this.resgrid;
            var committed = grid.GetAttribute(resrow, null, "C" + periodid);
            if (committed == null)
                committed = deltaHours;
            else
                committed += deltaHours;

            var deltaC = grid.GetAttribute(resrow, null, "D" + periodid);
            if (deltaC == null)
                deltaC = -deltaHours;
            else
                deltaC -= deltaHours;

            this.resgrid.SetAttribute(resrow, null, "C" + periodid, committed, 0, 0);
            this.resgrid.SetAttribute(resrow, null, "D" + periodid, deltaC, 0, 0);
        }
    };
    RPEditor.prototype.GetPeriodHoursSpecial = function (grid, row, col) {
        var sId = col.substring(1);
        var value = null;
        if (this.includePending == true) {
            value = grid.GetAttribute(row, "h" + sId);
        }
        if (value == null) {
            value = grid.GetAttribute(row, "H" + sId);
        }
        return value;
    };
    RPEditor.prototype.RefreshResourceRowPeriod = function (grid, row, periodid, bRefreshCell) {
        var ccruid = grid.GetAttribute(row, null, "CCRole_UID");
        // do not display any period values for generic resources
        var IsGeneric = grid.GetAttribute(row, null, "IsGeneric");
        if (IsGeneric != 0) {
            grid.SetAttribute(row, null, "Q" + periodid, "", bRefreshCell, 0);
            return;
        }

        var available = grid.GetAttribute(row, null, "A" + periodid);
        var fAvailable = 0;
        var fA = parseInt(available);
        if (isNaN(fA) == false)
            fAvailable = fA;

        var committed = grid.GetAttribute(row, null, "C" + periodid);
        var fCommitted = 0;
        var fC = parseInt(committed);
        if (isNaN(fC) == false)
            fCommitted = fC;

        var deltaC = grid.GetAttribute(row, null, "D" + periodid);
        var fDeltaC = 0;
        var fD = parseInt(deltaC);
        if (isNaN(fD) == false)
            fDeltaC = fD;

        var nonwork = grid.GetAttribute(row, null, "N" + periodid);
        var fNonwork = 0.0;
        var fN = parseFloat(nonwork);
        if (isNaN(fN) == false)
            fNonwork = fN;

        var fteconv = this.GetFTEConv(ccruid, periodid, grid, row);

        var fFTEConv = 10000;
        var fF = parseInt(fteconv);
        if (isNaN(fF) == false)
            fFTEConv = fF;

        var fHours = 0;
        switch (this.ResourceDisplayMode) {
            case "Available":
                fHours = fAvailable;
                break;
            case "Committed":
                fHours = fCommitted + fNonwork + fDeltaC;
                break;
            case "Remaining":
                fHours = fAvailable - fCommitted - fNonwork - fDeltaC;
                break;
            case "Remaining2":
                fHours = fAvailable - fCommitted - fNonwork - fDeltaC;
                break;
        }

        var fValue = 0;
        switch (this.displayMode) {
            case 0: /* Hours */
                fValue = (fHours / 100);
                break;
            case 1: /* FTE */
                fValue = (fHours / fFTEConv);
                break;
            case 2: /* FTE % */
                fValue = ((fHours * 100) / fFTEConv);
                break;
            case 3: /* FTE conversion*/
                fValue = (fFTEConv / 100);
                break;
        }

        if (isNaN(fValue))
            fValue = 0;

        if (fValue == 0 && fAvailable == 0)
            fValue = "";
        grid.SetAttribute(row, null, "Q" + periodid, fValue, bRefreshCell, 0);
    };
    RPEditor.prototype.RefreshResourceRowPeriods = function (grid, row, bRefresh) {
        for (var c = 0; c < grid.ColNames[2].length; c++) {
            var col = grid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var periodid = col.substring(1);
                this.RefreshResourceRowPeriod(grid, row, periodid, false);
            }
        }
        if (bRefresh == true) grid.RefreshRow(row);
    };
    RPEditor.prototype.HandleAddSplitOrReplace = function (resrows, planrow, buttonPress) {
        if (resrows == null || resrows.length == 0) {
            return;
        }

        var resuid = this.plangrid.GetAttribute(planrow, null, "Res_UID");
        if (resuid == null) resuid = this.plangrid.GetAttribute(planrow, null, "PendingRes_UID");
        var parentresrow = this.FindResourceRow(resuid);
        var parentIsGeneric = this.resgrid.GetAttribute(parentresrow, null, "IsGeneric");
        if (this.CanAddRowsToPlan(planrow, parentIsGeneric, resrows) == true) {
            var status = this.plangrid.GetAttribute(planrow, null, "Status");
            switch (status) {
                case const_Project:
                    this.AddRowsToProject(resrows, planrow, buttonPress);
                    break;
                case const_Requirement:
                    this.FullFillRequirement(resrows, planrow, buttonPress);
                    break;
                case const_Commitment:
                    this.resrows = resrows;
                    var grandParentRequirement = this.GetParentRequirement(planrow);
                    if (parentIsGeneric == null || parentIsGeneric == false || grandParentRequirement != null) {
                        this.DisplayDialog(20, 30, 340, 160, "Split Row?", "winSplitDlg", "idSplitDlg", true, false);
                    } else {
                        this.DisplayDialog(20, 30, 340, 160, "Fulfill Requirement?", "winFulfillDlg", "idFulfillDlg", true, false);
                    }
                    break;
            }
        }
    };
    RPEditor.prototype.CanAddRowsToPlan = function (parentplanrow, parentIsGeneric, resrows) {
        var resgrid = this.resgrid;
        var plangrid = this.plangrid;
        var parentstatus = plangrid.GetAttribute(parentplanrow, null, "Status");
        var plandeptUid = plangrid.GetAttribute(parentplanrow, null, "Dept_UID");
        for (var i = 0; i < resrows.length; i++) {
            var resrow = resrows[i];
            var canEdit = plangrid.GetAttribute(parentplanrow, null, "UserCanEdit");
            if (canEdit != 1) return false;
            if (this.CanAddResourceToLevel(parentplanrow, resrow) == false) return false;
            if (parentstatus != const_Project) {
                var isPrivate = plangrid.GetAttribute(parentplanrow, null, "Private");
                // if commitment row still private then don't worry about dept match
                if (isPrivate != 1 || parentstatus != const_Commitment || parentIsGeneric == true) {
                    var resdeptUid = resgrid.GetAttribute(resrow, null, "Dept_UID");
                    if (plandeptUid != resdeptUid) {
                        alert("Departments must match");
                        return false;
                    }
                }
            }
        }
        return true;
    };
    RPEditor.prototype.CanAddResourceToLevel = function (parentplanrow, resrow) {
        //var resgrid = this.resgrid;
        //var plangrid = this.plangrid;
        ////var planrow = plangrid.GetFirst(parentplanrow);
        //var planrow = parentplanrow.firstChild;
        //var wresId = resgrid.GetAttribute(resrow, null, "Res_UID");
        //var resName = resgrid.GetAttribute(resrow, null, "Res_Name");
        //var projectID = plangrid.GetAttribute(parentplanrow, null, "Project_UID");
        //while (planrow != null) {
        //    if (projectID == plangrid.GetAttribute(planrow, null, "Project_UID")) {
        //        var deleted = plangrid.GetAttribute(planrow, null, "Deleted");
        //        if (deleted != 1) {
        //            //if (planrow.Level == parentplanrow.Level + 1) {
        //                var planwresId = plangrid.GetAttribute(planrow, null, "PendingRes_UID");
        //                if (planwresId == null)
        //                    planwresId = plangrid.GetAttribute(planrow, null, "Res_UID");
        //                if (wresId == planwresId) {
        //                    alert(resName + " already exists at this plan level");
        //                    return false;
        //                }
        //            //}
        //        }
        //    }
        //    //planrow = plangrid.GetNext(planrow);
        //    planrow = planrow.nextSibling;
        //}
        return true;
    };
    RPEditor.prototype.CanAddResourceToLevel2 = function (siblingplanrow, resrow) {
        var resgrid = this.resgrid;
        var plangrid = this.plangrid;

        var planrow = siblingplanrow;
        var firstsiblingplanrow = null;
        while (planrow != null) {
            firstsiblingplanrow = planrow;
            planrow = planrow.previousSibling;
        }
        //if (firstsiblingplanrow == null)
        //    return true;

        //planrow = firstsiblingplanrow;
        //var wresId = resgrid.GetAttribute(resrow, null, "Res_UID");
        //var resName = resgrid.GetAttribute(resrow, null, "Res_Name");
        //while (planrow != null) {
        //    var deleted = plangrid.GetAttribute(planrow, null, "Deleted");
        //    if (deleted != 1) {
        //        var planwresId = plangrid.GetAttribute(planrow, null, "PendingRes_UID");
        //        if (planwresId == null)
        //            planwresId = plangrid.GetAttribute(planrow, null, "Res_UID");
        //        if (wresId == planwresId) {
        //            alert(resName + " already exists at this plan level");
        //            return false;
        //        }
        //    }
        //    planrow = planrow.nextSibling;
        //}
        return true;
    };
    RPEditor.prototype.AddRowsToPlan = function (parentplanrow, resrows, projectID, projectName, buttonPress) {
        var grid = this.resgrid;
        var plangrid = this.plangrid;
        var parentstatus = plangrid.GetAttribute(parentplanrow, null, "Status");
        var rowprivate = 1;
        if (parentplanrow != null && parentstatus != const_Project)
            rowprivate = plangrid.GetAttribute(parentplanrow, null, "Private");
        var div = resrows.length;
        if (div < 1) div = 1;
        var childplanrow = null;

        var calcMode = 0;
        if (parentstatus == const_Commitment) {
            plangrid.SetAttribute(parentplanrow, null, "Status", const_Requirement, 0, 0);
            parentstatus = const_Requirement;
            this.SetStatusColumn(plangrid, parentplanrow, parentstatus, false, 1);
            plangrid.SetAttribute(parentplanrow, null, "Changed", 1, 0, 0);
            this.ClearPendingRowEvent(plangrid, parentplanrow);
            calcMode = 2;
        }
        var firstaddedrow = null;
        for (var i = 0; i < resrows.length; i++) {
            var resrow = resrows[i];
            childplanrow = plangrid.AddRow(parentplanrow, null, true);
            if (childplanrow != null) {
                childplanrow.NoColorState = 1;
                plangrid.SetAttribute(childplanrow, null, "UserCanEdit", 1, 0, 0);
                if (firstaddedrow == null) firstaddedrow = childplanrow;
                var guid = new Guid();
                var newGuid = guid.newGuid();

                var ccroleUid, ccroleParentUid, roleUid, ccroleName, ccroleParentName, roleName, deptUid, deptName, childStatus, group, userIsRM;

                if (parentstatus == const_Requirement) {
                    group = plangrid.GetAttribute(parentplanrow, null, "Group");
                    childStatus = const_Commitment;
                    var parentccroleUid = grid.GetAttribute(parentplanrow, null, "CCRole_UID");
                    if (parentccroleUid != null && parentccroleUid != 0) {
                        ccroleUid = grid.GetAttribute(parentplanrow, null, "CCRole_UID");
                        ccroleParentUid = grid.GetAttribute(parentplanrow, null, "CCRoleParent_UID");
                        ccroleName = grid.GetAttribute(parentplanrow, null, "CCRole_Name");
                        ccroleParentName = grid.GetAttribute(parentplanrow, null, "CCRoleParent_Name");
                        roleUid = grid.GetAttribute(parentplanrow, null, "Role_UID");
                        roleName = grid.GetAttribute(parentplanrow, null, "Role_Name");
                    }
                    else {
                        ccroleUid = grid.GetAttribute(resrow, null, "CCRole_UID");
                        ccroleParentUid = grid.GetAttribute(resrow, null, "CCRoleParent_UID");
                        ccroleName = grid.GetAttribute(resrow, null, "CCRole_Name");
                        ccroleParentName = grid.GetAttribute(resrow, null, "CCRoleParent_Name");
                        roleUid = grid.GetAttribute(resrow, null, "Role_UID");
                        roleName = grid.GetAttribute(resrow, null, "Role_Name");

                        plangrid.SetAttribute(parentplanrow, null, "CCRole_UID", ccroleUid, 0, 0);
                        plangrid.SetAttribute(parentplanrow, null, "CCRoleParent_UID", ccroleParentUid, 0, 0);
                        plangrid.SetAttribute(parentplanrow, null, "Role_UID", roleUid, 0, 0);
                        plangrid.SetValue(parentplanrow, "CCRole_Name", ccroleName, 1);
                        plangrid.SetValue(parentplanrow, "CCRoleParent_Name", ccroleParentName, 1);
                        plangrid.SetValue(parentplanrow, "Role_Name", roleName, 1);
                    }
                    var reqdeptUid = grid.GetAttribute(parentplanrow, null, "Dept_UID");
                    if (reqdeptUid != null && reqdeptUid != 0) {
                        deptUid = grid.GetAttribute(parentplanrow, null, "Dept_UID");
                        deptName = grid.GetAttribute(parentplanrow, null, "Dept_Name");
                    }
                    else {
                        deptUid = grid.GetAttribute(resrow, null, "Dept_UID");
                        deptName = grid.GetAttribute(resrow, null, "Dept_Name");
                        plangrid.SetValue(parentplanrow, "Dept_UID", deptUid, 1);
                        plangrid.SetValue(parentplanrow, "Dept_Name", deptName, 1);
                    }
                }
                else {
                    // generics are first added as commitments and changed to Requirement when child added
                    childStatus = const_Commitment;
                    ccroleUid = grid.GetAttribute(resrow, null, "CCRole_UID");
                    ccroleParentUid = grid.GetAttribute(resrow, null, "CCRoleParent_UID");
                    ccroleName = grid.GetAttribute(resrow, null, "CCRole_Name");
                    ccroleParentName = grid.GetAttribute(resrow, null, "CCRoleParent_Name");
                    roleUid = grid.GetAttribute(resrow, null, "Role_UID");
                    roleName = grid.GetAttribute(resrow, null, "Role_Name");
                    deptUid = grid.GetAttribute(resrow, null, "Dept_UID");
                    deptName = grid.GetAttribute(resrow, null, "Dept_Name");
                    group = newGuid;
                }

                var wresId = grid.GetAttribute(resrow, null, "Res_UID");
                var resName = grid.GetAttribute(resrow, null, "Res_Name");

                plangrid.SetAttribute(childplanrow, null, "Project_UID", projectID, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "GUID", newGuid, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "Status", childStatus, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "Private", rowprivate, 0, 0);

                var userIsPM = plangrid.GetAttribute(parentplanrow, null, "UserIsPM");
                if (userIsPM != null)
                    plangrid.SetAttribute(childplanrow, null, "UserIsPM", userIsPM, 0, 0);
                var userIsRM = grid.GetAttribute(resrow, null, "UserIsRM");
                if (userIsRM != null)
                    plangrid.SetAttribute(childplanrow, null, "UserIsRM", userIsRM, 0, 0);

                plangrid.SetAttribute(childplanrow, null, "CCRole_UID", ccroleUid, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "CCRoleParent_UID", ccroleParentUid, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "Role_UID", roleUid, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "Dept_UID", deptUid, 0, 0);
                var activeCommitment = 0;
                plangrid.SetAttribute(childplanrow, null, "PendingRes_UID", wresId, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "ActiveCommitment", activeCommitment, 0, 0);

                plangrid.SetValue(childplanrow, "Project_Name", projectName, 1);
                plangrid.SetValue(childplanrow, "CCRoleParent_Name", ccroleParentName, 1);
                plangrid.SetValue(childplanrow, "CCRole_Name", ccroleName, 1);
                plangrid.SetValue(childplanrow, "Role_Name", roleName, 1);
                plangrid.SetValue(childplanrow, "Dept_Name", deptName, 1);
                plangrid.SetValue(childplanrow, "Res_Name", resName, 1);
                this.SetResNamesColumn(plangrid, childplanrow, childStatus);
                plangrid.SetValue(childplanrow, "ItemName", resName, 1);
                plangrid.SetValue(childplanrow, "Group", group, 1);

                plangrid.SetAttribute(childplanrow, null, "PMStatus", 0, 0, 0);
                plangrid.SetAttribute(childplanrow, null, "RMStatus", 0, 0, 0);

                this.SetStatusColumn(plangrid, childplanrow, childStatus, activeCommitment, 1);
                this.SetPMStatusColumn(plangrid, childplanrow, 1);
                this.SetRMStatusColumn(plangrid, childplanrow, 1);

                for (var c = 0; c < plangrid.ColNames[2].length; c++) {
                    var col = plangrid.ColNames[2][c];
                    var sType = col.substring(0, 1);
                    if (sType == "Q") {
                        switch (this.displayMode) {
                            case 0: /* Hours */
                                var split = this.GetIntValue(this.GetPeriodHours(plangrid, parentplanrow, col), null);
                                if (split != null && split > 0) {
                                    this.SetPeriodValue(plangrid, childplanrow, col, split / div);
                                }
                                break;
                            case 1: /* FTE */
                            case 2: /* FTE %*/
                                split = this.GetIntValue(this.GetPeriodFTE(plangrid, parentplanrow, col), null);
                                if (split != null && split > 0) {
                                    this.SetPeriodValue(plangrid, childplanrow, col, split / div);
                                }
                                break;
                        }
                    }
                }
                this.RefreshPlanRowPeriods(plangrid, childplanrow, false);
                plangrid.RefreshRow(childplanrow);
                this.CalculateResourceRowCommitted(wresId, resrow);
                this.SetPlanRowEditStatus(childplanrow);
                this.SetStatusAfterValueChanged(plangrid, childplanrow, true);
            }
            plangrid.SortRows();
        }
        if (childplanrow != null) {
            var reqrow = this.GetParentRequirement(childplanrow);
            if (reqrow != null) {
                this.UpdatePlanRowCalculatedValues(reqrow, calcMode);
                this.RefreshPlanRowPeriods(plangrid, reqrow, true);
                plangrid.SetAttribute(reqrow, null, "Changed", 1, 0, 0);
            }
        }
        if (firstaddedrow != null && buttonPress == false) {
            window.setTimeout(function () { var gridRPE = Grids["g_RPE"]; gridRPE.Focus(firstaddedrow, "ItemName"); }, 10);
        }
        else {
            window.setTimeout(function () { var gridRPE = Grids["g_RPE"]; gridRPE.Focus(parentplanrow, "ItemName"); }, 10);
        }
        this.UpdateButtonsAsync();
        return firstaddedrow;
    };
    RPEditor.prototype.GetParentRequirement = function (childrow) {
        var plangrid = this.plangrid;
        var childGroup = plangrid.GetAttribute(childrow, null, "Group");
        var row = plangrid.GetPrev(childrow);
        while (row != null) {
            if (childGroup != plangrid.GetAttribute(row, null, "Group"))
                return null;
            if (plangrid.GetAttribute(row, null, "Status") == const_Requirement)
                return row;
            row = plangrid.GetPrev(row);
        }
        return null;
    };
    RPEditor.prototype.UpdatePlanRowCalculatedValues = function (planrow, calcMode) {
        var plangrid = this.plangrid;
        if (plangrid.GetAttribute(planrow, null, "Status") == const_Requirement) {
            for (var c = 0; c < plangrid.ColNames[2].length; c++) {
                var col = plangrid.ColNames[2][c];
                var sType = col.substring(0, 1);
                if (sType == "Q") {
                    var sId = col.substring(1);
                    this.CalculateRequirementCellValue(planrow, sId, calcMode);
                }
            }
        }
    };
    RPEditor.prototype.UpdatePlanCalculatedValues = function () {
        var plangrid = this.plangrid;
        var row = plangrid.GetFirst(null, 0);
        while (row != null) {
            this.UpdatePlanRowCalculatedValues(row, 0);
            row = plangrid.GetNext(row);
        }
    };
    RPEditor.prototype.CalculateRequirementCellValue = function (reqrow, sId, calcMode) {
        var plangrid = this.plangrid;
        var row = reqrow.firstChild;
        var tH = null; var tF = null;
        var th = null; var tf = null;
        while (row != null) {
            var deleted = plangrid.GetAttribute(row, null, "Deleted");
            if (deleted != 1) {
                var Value; var value;
                Value = this.GetIntValue(plangrid.GetAttribute(row, null, "H" + sId), null);
                if (Value != null) { if (tH == null) tH = Value; else tH += Value; }
                value = this.GetIntValue(plangrid.GetAttribute(row, null, "h" + sId), null);
                if (value == null) value = Value;
                if (value != null) { if (th == null) th = value; else th += value; }

                Value = this.GetIntValue(plangrid.GetAttribute(row, null, "F" + sId), null);
                if (Value != null) { if (tF == null) tF = Value; else tF += Value; }
                value = this.GetIntValue(plangrid.GetAttribute(row, null, "f" + sId), null);
                if (value == null) value = Value;
                if (value != null) { if (tf == null) tf = value; else tf += value; }
            }
            row = row.nextSibling;
        }
        var H; var h;
        var F; var f;
        switch (calcMode) {
            case 1: // Initial - calculate the totals. NB there is only one set of totals
                h = this.GetIntValue(plangrid.GetAttribute(reqrow, null, "h" + sId), null);
                if (h == null)
                    h = this.GetIntValue(plangrid.GetAttribute(reqrow, null, "H" + sId), null);
                var totalHours = h;
                if (th != null) totalHours += th;
                plangrid.SetAttribute(reqrow, null, "t" + sId, totalHours, 0, 0);
                f = this.GetIntValue(plangrid.GetAttribute(reqrow, null, "f" + sId), null);
                if (f == null)
                    f = this.GetIntValue(plangrid.GetAttribute(reqrow, null, "F" + sId), null);
                var totalFTE = f;
                if (tf != null) totalFTE += tf;
                plangrid.SetAttribute(reqrow, null, "u" + sId, totalFTE, 0, 0);
                break;
            case 2: // Convert commitment to Fulfillment
                h = plangrid.GetAttribute(reqrow, null, "h" + sId);
                if (h == null)
                    h = plangrid.GetAttribute(reqrow, null, "H" + sId);
                else
                    plangrid.SetAttribute(reqrow, null, "h" + sId, null, 0, 0);
                var totalHours = this.GetIntValue(h, null);
                plangrid.SetAttribute(reqrow, null, "t" + sId, totalHours, 0, 0);
                f = plangrid.GetAttribute(reqrow, null, "f" + sId);
                if (f == null)
                    f = plangrid.GetAttribute(reqrow, null, "F" + sId);
                else
                    plangrid.SetAttribute(reqrow, null, "f" + sId, null, 0, 0);
                var totalFTE = this.GetIntValue(f, null);
                plangrid.SetAttribute(reqrow, null, "u" + sId, totalFTE, 0, 0);
            default: // normal
                H = plangrid.GetAttribute(reqrow, null, "H" + sId);
                h = plangrid.GetAttribute(reqrow, null, "h" + sId);
                var reqHours = this.GetIntValue(plangrid.GetAttribute(reqrow, null, "t" + sId), null);
                var remHours = reqHours;
                if (tH != null) remHours -= tH;
                var remhours = reqHours;
                if (th != null) remhours -= th;
                plangrid.SetAttribute(reqrow, null, "H" + sId, remHours, 0, 0);
                plangrid.SetAttribute(reqrow, null, "h" + sId, remhours, 0, 0);

                F = plangrid.GetAttribute(reqrow, null, "F" + sId);
                f = plangrid.GetAttribute(reqrow, null, "f" + sId);
                var reqFte = this.GetIntValue(plangrid.GetAttribute(reqrow, null, "u" + sId), null);
                var remFte = reqFte;
                if (tF != null) remFte -= tF;
                var remfte = reqFte;
                if (tf != null) remfte -= tf;
                plangrid.SetAttribute(reqrow, null, "F" + sId, remFte, 0, 0);
                plangrid.SetAttribute(reqrow, null, "f" + sId, remfte, 0, 0);

                //if (H != remHours || (h != null && h != remhours) || F != remFte || (f != null && f != remfte)) {
                //    plangrid.SetAttribute(reqrow, null, "Changed", 1, 0, 0);
                //}
                break;
        }
    };
    RPEditor.prototype.GetIntValue = function (value, defaultvalue) {
        if (isNaN(value))
            return defaultvalue;
        if (typeof value == "number") {
            return value - 0;
        }
        if (typeof value == "string") {
            return parseInt(value) - 0;
        }
        return defaultvalue;
    };
    RPEditor.prototype.HandleMatch = function () {
        if (this.planrow == null) {
            alert("Match function requires a selected plan row with a role and a department");
            return;
        }

        var plangrid = this.plangrid;
        var resgrid = this.resgrid;
        var planrow = this.planrow;
        var roleUid = plangrid.GetAttribute(planrow, null, "Role_UID");
        var deptUid = plangrid.GetAttribute(planrow, null, "Dept_UID");
        if (roleUid == null || deptUid == null) {
            alert("Match function requires a role and a department");
            return;
        }

        var lUsedPeriods = 0;
        for (var c = 0; c < plangrid.ColNames[2].length; c++) {
            var col = plangrid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var sId = col.substring(1);
                var hours = plangrid.GetAttribute(planrow, null, "H" + sId);
                var pendinghours = plangrid.GetAttribute(planrow, null, "h" + sId);
                if (hours != null || pendinghours != null) lUsedPeriods++;
            }
        }

        var planrowresuid = plangrid.GetAttribute(planrow, null, "Res_UID");
        var resrow = resgrid.GetFirst(null, 0);
        while (resrow != null) {
            resgrid.SetAttribute(resrow, "Match", null, null, 0, 0);
            if (this.CanMatchResourceToPlanRow(planrow, resrow, false, false) != false) {
                var match = 0;
                var planroleUid = plangrid.GetAttribute(planrow, null, "Role_UID");
                var resroleUid = resgrid.GetAttribute(resrow, null, "Role_UID");
                if (resroleUid == planroleUid)
                    match += 25;
                var plandeptUid = plangrid.GetAttribute(planrow, null, "Dept_UID");
                var resdeptUid = resgrid.GetAttribute(resrow, null, "Dept_UID");
                if (resdeptUid == plandeptUid)
                    match += 25;
                if (lUsedPeriods > 0 && match > 0) {
                    var hourssatisfied = 0.0;
                    var hourstotal = 0.0;
                    for (var c = 0; c < plangrid.ColNames[2].length; c++) {
                        var col = plangrid.ColNames[2][c];
                        var sType = col.substring(0, 1);
                        if (sType == "Q") {
                            var sId = col.substring(1);
                            var hours = plangrid.GetAttribute(planrow, null, "H" + sId);
                            var pendinghours = plangrid.GetAttribute(planrow, null, "h" + sId);
                            if (hours != null || pendinghours != null) {
                                var available = resgrid.GetAttribute(resrow, null, "A" + sId);
                                var fAvailable = 0.0;
                                var fA = parseFloat(available);
                                if (isNaN(fA) == false)
                                    fAvailable = fA;
                                var committed = resgrid.GetAttribute(resrow, null, "C" + sId);
                                var fCommitted = 0.0;
                                var fC = parseFloat(committed);
                                if (isNaN(fC) == false)
                                    fCommitted = fC;

                                var nonwork = resgrid.GetAttribute(resrow, null, "N" + sId);
                                var fNonwork = 0.0;
                                var fN = parseFloat(nonwork);
                                if (isNaN(fN) == false)
                                    fNonwork = fN;

                                var remaininghours = fAvailable - fCommitted - fNonwork;

                                if (hours > 0 || pendinghours > 0) {
                                    var requiredhours;
                                    if (pendinghours != null && pendinghours > 0) {
                                        requiredhours = parseFloat(pendinghours);
                                    }
                                    else {
                                        if (planrowresuid == resgrid.GetAttribute(resrow, null, "Res_UID")) {
                                            remaininghours += parseFloat(hours);
                                        }
                                        requiredhours = parseFloat(hours);
                                    }

                                    if (remaininghours > 0) {
                                        if (remaininghours >= requiredhours) {
                                            hourssatisfied += requiredhours;
                                        }
                                        else {
                                            if (remaininghours > 0)
                                                hourssatisfied += remaininghours;
                                        }
                                    }
                                    hourstotal += requiredhours;
                                }
                            }
                        }
                    }
                    if (hourstotal > 0)
                        match += ((50.0 * hourssatisfied) / hourstotal);
                    else
                        match += 50.0;
                }
                if (match > 0) {
                    resgrid.SetAttribute(resrow, "Match", null, match, 1, 0);
                }
            }
            resrow = resgrid.GetNext(resrow);
        }

        var select = document.getElementById("idResourcesTab_Select");
        this.ResourcesSelectMode = 4;
        select.selectedIndex = this.ResourcesSelectMode; // = match view
        this.ShowSelectedResourceGroup();
        this.resourcesTab.refreshSelect("idResourcesTab_Select");
    };
    RPEditor.prototype.CanMatchResourceToPlanRow = function (planrow, resrow, bAllowGeneric, balert) {
        var resgrid = this.resgrid;
        var plangrid = this.plangrid;
        var isGeneric = resgrid.GetAttribute(resrow, null, "IsGeneric");
        if (isGeneric != 0 && bAllowGeneric == false) {
            if (balert) {
                alert("Generic resource not allowed");
            }
            return false;
        }
        // Resource must have a cost category role
        var ccroleUid = resgrid.GetAttribute(resrow, null, "CCRole_UID");
        var planccroleUid = plangrid.GetAttribute(planrow, null, "CCRole_UID");
        if (ccroleUid == null || ccroleUid == 0) {
            if (balert) {
                alert("The selected resource does not have a valid cost category role");
            }
            return false;
        }
        // Resource must have a role
        var roleUid = resgrid.GetAttribute(resrow, null, "Role_UID");
        if (roleUid == null || roleUid == 0) {
            if (balert) {
                alert("The selected resource does not have a valid role");
            }
            return false;
        }
        var planccroleParentUid = plangrid.GetAttribute(planrow, null, "CCRoleParent_UID");
        if (planccroleParentUid > 0) {
            // check if Cost category role of resource different from the detail plan row
            if (ccroleUid != planccroleUid) {
                // if not a direct match then parent cost categories must match
                // only allow resources with the same cost category parent
                if (this.ccrolesArray != null) {
                    var ccrole = this.ccrolesArray[ccroleUid];
                    if (ccrole != null) {
                        if (ccrole.ParentUID != planccroleParentUid) {
                            ccrole = this.ccrolesArray[planccroleUid];
                            // Now only provide warning message V5.1 31JAN08
                            if (balert) {
                                alert("Warning: the selected resource does not match the requested Cost Category of " + ccrole.ParentName);
                            }
                        }
                    }
                }
            }
        }
        return true;
    };
    RPEditor.prototype.DisplayDialog = function (left, top, width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var wins = this.wins;
        if (wins != null) {
            var dlg = wins.createWindow(idWindow, left, top, width, height);
            if (dlg != null) {
                dlg.clearIcon();
                dlg.button("minmax1").hide();
                if (bResize == false) {
                    dlg.denyResize();
                } else {
                    dlg.allowResize();
                    //dlg.button("minmax1").show();
                }
                dlg.button("park").hide();
                dlg.button("close").hide();
                dlg.setModal(bModal);
                dlg.center();
                dlg.setText(title);
                dlg.attachEvent("onClose", function (win) { dlg_OnCloseDelegate(idWindow); return true; });
                if (idAttachObj != null)
                    dlg.attachObject(idAttachObj);
                dlg.allowMove();

            }
            return dlg;
        }
        return null;
    };
    RPEditor.prototype.dhxWins_CloseDialog = function (idWindow) {
        var dlg = this.wins.window(idWindow);
        if (dlg != null) {
            dlg.setModal(false);
            dlg.hide();
            dlg.detachObject();
        }
    };
    RPEditor.prototype.dlg_OnClose = function (idWindow) {
        this.dhxWins_CloseDialog(idWindow);
    };
    RPEditor.prototype.SetPlanRowsEditStatus = function () {
        var plangrid = this.plangrid;
        //if (plangrid.RowCount > 0) {
        if (plangrid.GetFirst(null, 0) != null) {
            var row = plangrid.GetFirst(null, 0);
            while (row != null) {
                this.SetPlanRowEditStatus(row);
                row = plangrid.GetNext(row);
            }
        }
    };
    RPEditor.prototype.SetPlanRowEditStatus = function (row) {
        var plangrid = this.plangrid;
        var planrow = row;
        var canEdit = plangrid.GetAttribute(planrow, null, "UserCanEdit");
        if (canEdit != 1) canEdit = 0;
        var status = plangrid.GetAttribute(planrow, null, "Status");
        switch (status) {
            case const_Project:
                plangrid.SetAttribute(planrow, "Dept_Name", "CanEdit", "0", 0, 0);
                plangrid.SetAttribute(planrow, "Dept_Name", "Button", "", 0, 0);
                plangrid.SetAttribute(row, "NamedRate_Name", "CanEdit", "0", 0, 0);
                plangrid.SetAttribute(row, "NamedRate_Name", "Button", "", 0, 0);
                return;
            case const_Requirement:
                plangrid.SetAttribute(planrow, "Dept_Name", "CanEdit", "0", 0, 0);
                plangrid.SetAttribute(planrow, "Dept_Name", "Button", "", 0, 0);
                break;
            case const_Commitment:
                plangrid.SetAttribute(planrow, "Dept_Name", "CanEdit", "0", 0, 0);
                plangrid.SetAttribute(planrow, "Dept_Name", "Button", "", 0, 0);
                plangrid.SetAttribute(row, "NamedRate_Name", "CanEdit", "2", 0, 0);
                plangrid.SetAttribute(row, "NamedRate_Name", "Button", "Defaults", 0, 0);
                break;
        }
        for (var c = 0; c < plangrid.ColNames[2].length; c++) {
            var col = plangrid.ColNames[2][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                plangrid.SetAttribute(planrow, col, "CanEdit", canEdit, 0, 0);
            }
            else {
                plangrid.SetAttribute(planrow, col, "CanEdit", 0, 0, 0);
            }
        }
        plangrid.RefreshRow(planrow);
    };
    try {
        this.thisID = thisID;
        this.params = params;
        var const_PlanCell = "a";
        var const_ResourcesCell = "b";
        var const_PlanRibbonCell = "a";
        var const_PlanGridCell = "b";
        var const_ResourceRibbonCell = "a";
        var const_ResourceGridCell = "b";
        this.imagePath = "/_layouts/ppm/images/";
        this.Width = 0;
        this.Height = 0;
        this.planTabbar = null;
        this.resTabbar = null;
        this.layout = null;
        this.layout_res = null;
        this.layout_reswork = null;
        this.bInColResize = false;
        this.ResourceDisplayMode = "Remaining";
        this.ResourcesSelectMode = 0;
        this.initialized = false;
        this.ribbonDataInitialized = false;
        this.dirty = false;
        this.isLoaded = false;
        this.isClosed = false;
        this.ScrollMasterGridId = null;
        this.ScrollMasterUntil = null;
        this.Views = null;
        this.editorTab = null;
        this.viewTab = null;
        this.resourcesTab = null;
        this.ExitConfirmed = false;
        this.displayMode = 0;
        this.costCategoryRoles = null;
        this.ccrFTEArray = null;
        this.ccrolesArray = null;
        this.plangrid = null;
        this.resgrid = null;
        this.resworkgrid = null;
        this.notesgrid = null;
        this.planrow = null;
        this.resrows = null;
        this.originalval = null;
        this.newval = null;
        this.valChanged = false;
        this.NegotiationMode = false;
        this.noteEditor = null;
        this.pendingNotification = [];
        this.wins = new dhtmlXWindows();
        this.wins.enableAutoViewport(false);
        this.wins.attachViewportTo(this.params.ClientID + "layoutDiv");
        this.wins.setImagePath("../epmlive/dhtml/windows/imgs/");
        this.wins.setSkin("dhx_web");
        this.startPeriod = null;
        this.finishPeriod = null;
        this.currentPeriod = null;
        this.projectuids = "";
        this.showHeatmap = false;
        this.savingPlan = false;
        this.arrPIs = null;
        this.importWorkResources = null;
        this.importWorkProjectName = "";
        this.includePending = true;

        var const_HoursFormat = "0.##";
        var const_FTEFormat = "0.####";
        var const_FTEPctFormat = "0.##%";
        var const_Project = 0;
        var const_Requirement = 1;
        //var const_RequestUnsubmitted = 2;
        //var const_Request = 4;
        //var const_OfferUnsubmitted = 16;
        //var const_Offer = 32;
        var const_Commitment = 256;
        var const_CommitmentCancelled = 512;

        var loadDelegate = MakeDelegate(this, this.OnLoad);
        var resizeDelegate = MakeDelegate(this, this.OnResizeInternal);
        var beforeUnloadDelegate = MakeDelegate(this, this.OnBeforeUnload);
        var unloadDelegate = MakeDelegate(this, this.OnUnload);
        var ExecuteCompleteDelegate = MakeDelegate(this, this.ExecuteComplete);
        var dialogCallbackDelegate = MakeDelegate(this, this.dialogCallback);

        var GridsOnValueChangedDelegate = MakeDelegate(this, this.GridsOnValueChanged);
        var GridsOnFocusDelegate = MakeDelegate(this, this.GridsOnFocus);
        var GridsOnReadyDelegate = MakeDelegate(this, this.GridsOnReady);
        var GridsOnRenderFinishDelegate = MakeDelegate(this, this.GridsOnRenderFinish);
        var GridsOnScrollDelegate = MakeDelegate(this, this.GridsOnScroll);
        var GridsOnSectionResizeDelegate = MakeDelegate(this, this.GridsOnSectionResize);
        var GridsOnAfterColResizeDelegate = MakeDelegate(this, this.GridsOnAfterColResize);

        var GridsOnStartDragCellDelegate = MakeDelegate(this, this.GridsOnStartDragCell);
        var GridsOnMoveDragCellDelegate = MakeDelegate(this, this.GridsOnMoveDragCell);
        var GridsOnEndDragCellDelegate = MakeDelegate(this, this.GridsOnEndDragCell);

        var GridsOnStartDragDelegate = MakeDelegate(this, this.GridsOnStartDrag);
        var GridsOnCanDropDelegate = MakeDelegate(this, this.GridsOnCanDrop);
        var GridsOnEndDragDelegate = MakeDelegate(this, this.GridsOnEndDrag);
        var GridsOnStartEditDelegate = MakeDelegate(this, this.GridsOnStartEdit);
        var GridsOnGetInputValueDelegate = MakeDelegate(this, this.GridsOnGetInputValue);
        var GridsOnSetInputValueDelegate = MakeDelegate(this, this.GridsOnSetInputValue);
        var GridsOnAfterValueChangedDelegate = MakeDelegate(this, this.GridsOnAfterValueChanged);
        var GridsOnAfterSaveDelegate = MakeDelegate(this, this.GridsOnAfterSave);
        var GridsOnClickCellDelegate = MakeDelegate(this, this.GridsOnClickCell);
        var GridsOnMouseDownDelegate = MakeDelegate(this, this.GridsOnMouseDown);
        var GridsOnDblClickDelegate = MakeDelegate(this, this.GridsOnDblClick);
        var GridsOnTipDelegate = MakeDelegate(this, this.GridsOnTip);
        var GridsOnDataSendDelegate = MakeDelegate(this, this.GridsOnDataSend);
        var GridsOnAfterColumnsChangedDelegate = MakeDelegate(this, this.GridsOnAfterColumnsChanged);
        //var GridsOnGroupFinishDelegate = MakeDelegate(this, this.GridsOnGroupFinish);
        //var GridsOnGroupDelegate = MakeDelegate(this, this.GridsOnGroup);
        var GridsOnFilterDelegate = MakeDelegate(this, this.GridsOnFilter);
        var GridsOnRowFilterDelegate = MakeDelegate(this, this.GridsOnRowFilter);
        var GridsOnFilterFinishDelegate = MakeDelegate(this, this.GridsOnFilterFinish);

        var dlg_OnCloseDelegate = MakeDelegate(this, this.dlg_OnClose);

        var tabbarOnSelectDelegate = MakeDelegate(this, this.tabbarOnSelect);

        if (document.addEventListener != null) { // e.g. Firefox
            window.addEventListener("load", loadDelegate, true);
            window.addEventListener("beforeunload", beforeUnloadDelegate, true);
            window.addEventListener("unload", unloadDelegate, true);
            window.addEventListener("resize", resizeDelegate, true);
        }
        else { // e.g. IE
            window.attachEvent("onload", loadDelegate);
            window.attachEvent("onbeforeunload", beforeUnloadDelegate);
            window.attachEvent("onunload", unloadDelegate);
            window.attachEvent("onresize", resizeDelegate);
        }
    }
    catch (e) {
        this.HandleException("RPEditor Initialization", e);
    }
}

function HideUnusedGroupRows(grid, row, level) {
    var childrenvisible = false;
    while (row != null) {
        //if (row.Visible == 1) {
        var stype = row.id.toString();
        if (stype.substr(0, 2) === "GR") {
            var childrow = row.firstChild;
            if (HideUnusedGroupRows(grid, childrow, level + 1) == false) {
                grid.HideRow(row);
                row.Visible = 0;
                //var itemName = grid.GetAttribute(row, null, "ItemName");
                //alert("hiding '" + itemName + "'");
            }
            else {
                childrenvisible = true;
                if (row.Visible == 0) {
                    grid.ShowRow(row);
                    row.Visible = 1;
                }
            }
        }
        else if (row.Visible == 1)
            childrenvisible = true;
        //}
        row = row.nextSibling;
    }
    return childrenvisible;
};

