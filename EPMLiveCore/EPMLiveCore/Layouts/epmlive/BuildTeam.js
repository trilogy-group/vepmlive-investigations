
var isDirty = false;

function Assignments() {
    var sResources = "";
    var tGrid = Grids.TeamGrid;
    var rGrid = Grids.ResourceGrid;
    var sRows = rGrid.GetSelRows();

    for (var r in sRows) {
        var oSRow = sRows[r];
        sResources += "," + oSRow.id;
    }
    sRows = tGrid.GetSelRows();
    for (var r in sRows) {
        var oSRow = sRows[r];
        sResources += "," + oSRow.id;
    }

    if (sResources != "") {
        sResources = sResources.substr(1);

        var layoutsUrl = SP.Utilities.Utility.getLayoutsPageUrl('epmlive/AssignmentPlanner.aspx');
        var urlBuilder = new SP.Utilities.UrlBuilder(layoutsUrl);
        var surl = urlBuilder.get_url() + "?resources=" + sResources;

        var options = { url: surl, showMaximized: true, title: "Assignment Planner" };
        SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    }
    //_layouts/epmlive/AssignmentPlanner.aspx?resources=7,5,19,6&IsDlg=1

}

function RemoveResources() {
    var tGrid = Grids.TeamGrid;
    var rGrid = Grids.ResourceGrid;
    for (var Row in tGrid.Rows) {
        try {
            var oRow = rGrid.GetRowById(Row);
            if (oRow != null) {
                if (oRow.Kind == "Data") {
                    oRow.CanFilter = 0;
                    rGrid.HideRow(oRow);
                }
            }
        } catch (e) { }
    }
}

function AddResource() {
    var tGrid = Grids.TeamGrid;
    var rGrid = Grids.ResourceGrid;
    var sRows = rGrid.GetSelRows();
    isDirty = true;

    for (var r in sRows) {
        var oSRow = sRows[r];
        var oTRow = tGrid.AddRow(null, null, true, oSRow.id, null);

        oTRow.NoColorState = 1;

        tGrid.SetValue(oTRow, "Generic", rGrid.GetValue(oSRow, "Generic"), 1, 0);

        for (var c in rGrid.Cols) {
            if (c != "Title")
                tGrid.SetValue(oTRow, c, rGrid.GetValue(oSRow, c), 1, 0);
        }

        var validPerms = tGrid.Cols["Permissions"].EnumKeys.split(tGrid.Cols["Permissions"].EnumKeys[0])
        var perms = new Array();

        var cGroups = rGrid.GetValue(oSRow, "Groups").toString().split(';');

        for (var cGroup in cGroups) {
            for (var validPerm in validPerms) {
                if (validPerms[validPerm] == cGroups[cGroup]) {
                    perms.push(cGroups[cGroup]);
                }
            }
        }

        if (sDefaultGroup != "") {
            var found = false;
            for (var perm in perms) {
                if (perms[perm] == sDefaultGroup) {
                    found = true;
                    break;
                }
            }
            if (!found)
                perms.push(sDefaultGroup);
        }


        if (tGrid.GetValue(oTRow, "Generic") != "1" && tGrid.GetValue(oTRow, "Generic") != "Yes")
            tGrid.SetValue(oTRow, "Permissions", perms.join(';'), 1, 0);

        tGrid.SetValue(oTRow, "Title", rGrid.GetValue(oSRow, "Title"), 1, 0);

        tGrid.RefreshCell(oTRow, "Permissions");
        oSRow.CanFilter = 0;
        rGrid.HideRow(oSRow);
    }
    RefreshCommandUI();
    tGrid.UpdateHeights(1);
}

function RemoveResource() {
    var tGrid = Grids.TeamGrid;
    var rGrid = Grids.ResourceGrid;
    var sRows = tGrid.GetSelRows();
    isDirty = true;
    for (var r in sRows) {
        var oSRow = sRows[r];
        var oRrow = rGrid.GetRowById(oSRow.id);
        oRrow.CanFilter = 1
        rGrid.ShowRow(oRrow);
        tGrid.RemoveRow(oSRow);
    }
    RefreshCommandUI();
    tGrid.UpdateHeights(1);

    if (Grids.TeamGrid.LoadedCount > 0) {
        return true;
    }
    else {
        isDirty = false;
        EnableDisableSaveButton();
        gridsloaded();
        //alert("The team cannot be saved if empty. Please select at least one team member from the list on the right.");
        return false;
    }
}

function AddResourcePool() {
    var options = { url: newResUrl, width: 600, height: 600, title: "Add Resource", dialogReturnValueCallback: onAddResourcePool };
    SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
}

function onAddResourcePool(dialogResult, returnValue) {
    ShowTDialog("Refreshing...");
    setTimeout("reloadres()", 2000);
}

function reloadres() {
    HideTDialog();
    Grids.ResourceGrid.Reload();
}

function AddResColumns() {
    Grids.ResourceGrid.ActionShowColumns();
}

function AddTeamColumns() {
    Grids.TeamGrid.ActionShowColumns();
}

function TeamFilters(o) {
    var grid = Grids.TeamGrid;
    var row = grid.GetRowById("Filter");
    try {
        if (row.Visible) {
            grid.HideRow(row);
            $(o).find("span").css("color", "#777777");
        }
        else {
            grid.ShowRow(row);
            $(o).find("span").css("color", "#000000");
        }

    } catch (e) { }
}

function TeamGroups(o) {
    var grid = Grids.TeamGrid;
    var row = grid.GetRowById("GroupRow");
    if (row.Visible) {
        grid.HideRow(row);
        $(o).find("span").css("color", "#777777");
    }
    else {
        grid.ShowRow(row);
        $(o).find("span").css("color", "#000000");
    }
}

function ResFilters(o) {
    var grid = Grids.ResourceGrid;
    var row = grid.GetRowById("Filter");
    try {
        if (row.Visible) {
            grid.HideRow(row);
            $(o).find("span").css("color", "#777777");
        }
        else {
            grid.ShowRow(row);
            $(o).find("span").css("color", "#000000");
        }
    } catch (e) { }
}

function ResGroups(o) {
    var grid = Grids.ResourceGrid;
    var row = grid.GetRowById("GroupRow");
    if (row.Visible) {
        grid.HideRow(row);
        $(o).find("span").css("color", "#777777");
    }
    else {
        grid.ShowRow(row);
        $(o).find("span").css("color", "#000000");
    }
}

function CanViewResPool() {
    try {
        return (Grids.ResourceGrid != null);
    } catch (e) { }
}

function CanAddResource() {
    return canAddResource;
}

function ShowPool() {
    RefreshCommandUI();
}

function ShowUserPopup(spaccount) {
    var layoutsUrl = SP.Utilities.Utility.getLayoutsPageUrl('listform.aspx');
    var urlBuilder = new SP.Utilities.UrlBuilder(layoutsUrl);
    var url = urlBuilder.get_url() + "?PageType=4&ListId=" + sUserInfoList + "&ID=" + spaccount.split(';')[0];

    var options = { url: url, width: 650, height: 600, title: "User Information" };

    SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);

}

function EnableDisableSaveButton() {
    if (bCanEditTeam && isDirty)
        return true;
    return false;
}

function CheckAddRemoveButtons() {
    var tGrid = Grids.TeamGrid;
    var rGrid = Grids.ResourceGrid;
    try {
        if (tGrid.GetSelRows().length == 0)
            document.getElementById("btnRemove").disabled = true;
        else
            document.getElementById("btnRemove").disabled = false;

        if (rGrid.GetSelRows().length == 0)
            document.getElementById("btnAdd").disabled = true;
        else
            document.getElementById("btnAdd").disabled = false;
    } catch (e) { }
}

function getHeight() {
    var scnHei;
    if (self.innerHeight) // all except Explorer
    {
        //scnWid = self.innerWidth;
        scnHei = self.innerHeight;
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        //scnWid = document.documentElement.clientWidth;
        scnHei = document.documentElement.clientHeight;
    }
    else if (document.body) // other Explorers
    {
        //scnWid = document.body.clientWidth;
        scnHei = document.body.clientHeight;
    }
    return scnHei;
}

function setHeight() {
    var tbl = document.getElementById("parentId");
    try {
        var h = (getHeight() - getTop(tbl) - 60) + "px";
        var h2 = (getHeight() - getTop(tbl) - 120) + "px";
        tbl.style.height = h;
        document.getElementById("divTeam").style.height = h2;
        document.getElementById("divResPool").style.height = h2;
    } catch (e) { }



    var hWidth = (getWidth() - 50) / 2;

    tbl.style.width = getWidth() + "px";

    var res = document.getElementById("tdRes");
    if (res) {
        res.style.width = hWidth + "px";

        var team = document.getElementById("tdTeam");
        team.style.width = hWidth + "px";

    }
    else {
        var team = document.getElementById("tdTeam");
        team.style.width = tbl.style.width;
    }
    document.getElementById("divTeam").style.width = team.style.width;
}

function SaveAndClose() {
    if (ValidateTeam()) {
        ShowTDialog("Saving Team...");

        var x = Grids.TeamGrid.GetXmlData("Body", "Permissions");

        if (sListId != "")
            dhtmlxAjax.post("SaveTeam.aspx", "team=" + x + "&HasResAccess=" + bCanAccessResourcePool + "&ListId=" + sListId + "&ItemId=" + sItemId, SaveTeamCloseClose);
        else
            dhtmlxAjax.post("SaveTeam.aspx", "team=" + x + "&HasResAccess=" + bCanAccessResourcePool, SaveTeamCloseClose);
    }
}

function SaveTeamCloseClose(loader) {
    HideTDialog();
    if (loader.xmlDoc.responseText != null) {
        var data = loader.xmlDoc.responseText.trim();
        if (data != "Success") {
            alert(data);
        }
        else
            Close();
    }
}

function SaveTeam() {
    if (ValidateTeam()) {
        ShowTDialog("Saving Team...");

        var x = Grids.TeamGrid.GetXmlData("Body", "Permissions");

        if (sListId != "")
            dhtmlxAjax.post("SaveTeam.aspx", "team=" + x + "&HasResAccess=" + bCanAccessResourcePool + "&ListId=" + sListId + "&ItemId=" + sItemId, SaveTeamClose);
        else
            dhtmlxAjax.post("SaveTeam.aspx", "team=" + x + "&HasResAccess=" + bCanAccessResourcePool, SaveTeamClose);
    }
}

function SaveTeamClose(loader) {
    HideTDialog();
    if (loader.xmlDoc.responseText != null) {
        var data = loader.xmlDoc.responseText.trim();
        if (data != "Success") {
            alert(data);
        }
    }
}

function ValidateTeam() {
    if (Grids.TeamGrid.LoadedCount > 0) {
        return true;
    }
    else {
        isDirty = false;
        EnableDisableSaveButton();
        gridsloaded();
        //alert("The team cannot be saved if empty. Please select at least one team member from the list on the right.");
        return false;
    }
}

function ShowTDialog(text) {

    sm("dlgNormal", 150, 50);
    //document.getElementById("dlgNormalText").innerText = text;
}

function HideTDialog() {
    hm("dlgNormal");
}