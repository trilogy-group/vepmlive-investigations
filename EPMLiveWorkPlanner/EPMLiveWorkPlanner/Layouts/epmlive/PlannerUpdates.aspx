<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlannerUpdates.aspx.cs" Inherits="EPMLiveWorkPlanner.Layouts.epmlive.PlannerUpdates" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <script src="TreeGrid/GridE.js"> </script>
    <link href="TreeGrid/Styles/Examples.css" rel="stylesheet" type="text/css" />
    <link href="WorkPlanner.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="modal/modal.css" type="text/css" /> 
    <script type="text/javascript" src="modal/modal.js"></script>

    <script language="javascript">
        var divDetail;

        function ProcessUpdates() {

            sm("dlgProcessing", 130, 50);

            var grid = parent.Grids.WorkPlannerGrid;

            var ugrid = Grids.UpdateGrid;

            ugrid.EndEdit(true);

            var acceptString = "";

            grid.ActionCalcOff();

            for (var R in ugrid.Rows) {
                var oRow = ugrid.GetRowById(R);

                var aNotes = "";

                if (oRow.ApprovalNotes != null)
                    aNotes = oRow.ApprovalNotes;

                if (oRow.Accept == "1")
                {

                    var oToRow = grid.GetRowById(R);
                    if (oToRow == null) {
                        oToRow = grid.GetRowById(oRow.SPID, "SPID");
                        if (oToRow == null) {
                            var newId = grid.GenerateId();
                            if (parent.bAgile) {
                                oToRow = grid.AddRow(grid.GetRowById("BacklogRow"), null, true, newId, "Task");
                                grid.HideRow(oToRow);
                                grid.SetValue(oToRow, "Title", oRow.Title, 1, 0);
                            }
                            else {
                                oToRow = grid.AddRow(grid.GetRowById("0"), null, true, newId, "Task");
                                grid.SetValue(oToRow, "Title", oRow.Title, 1, 0);
                            }
                        }
                    }

                    acceptString += "<Task ItemID='" + oRow.SPID + "' Status='1' taskuid='" + oToRow.id + "'><![CDATA[" + aNotes + "]]></Task>";

                    processRow(grid, ugrid, oToRow, oRow);
                }
                else if (oRow.Reject == "1")
                {
                    acceptString += "<Task ItemID='" + oRow.SPID + "' Status='2'><![CDATA[" + aNotes + "]]></Task>";
                }
            }
            
            parent.setWBSAndTaskID(grid.GetRowById('0'));

            grid.ActionCalcOn();

            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, acceptString);

            hm("dlgProcessing");
        }

        function processRow(grid, ugrid, oToRow, oRow) {
            

            for (var C in ugrid.Cols) {
                if (validColumn(C)) {
                    try {
                        if ((C == "StartDate" || C == "DueDate") && ugrid.GetValue(oRow, C) == "") {
                        }
                        else {
                            parent.SetPlannerFieldValue(oToRow, C, ugrid.GetValue(oRow, C), true);
                        }
                    } catch (e) { }
                }
                parent.RollupSummaryField(C);
                if (C == "DueDate" && oToRow.Def.Name == "Assignment")
                    parent.Grids.WorkPlannerGrid.CorrectDependencies(oToRow.parentNode, "G");
            }

            parent.ApplyDefaults(grid, oToRow, false);
        }

        Grids.OnAfterValueChanged = function (grid, row, col, val) {
            if (col == "Accept" && grid.GetValue(row, col) == "1") {
                grid.SetValue(row, "Reject", 0, 1);
            }
            if (col == "Reject" && grid.GetValue(row, col) == "1") {
                grid.SetValue(row, "Accept", 0, 1);
            }
        }

        function validColumn(col) {
            switch (col) {
                case "Editor":
                case "Accept":
                case "Reject":
                case "Title":
                case "ApprovalNotes":
                case "IsAssignment":
                case "TaskHierarchy":
                case "Milestone":
                case "Timesheet":
                case "Panel":
                    return false;
            }
            return true;
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

        Grids.OnGetHtmlValue = function (grid, row, col, val) {
            if (parent.oChoiceFields[col] != null && row.Def.Name != "Header" && row.Def.Name != "Fixed") {
                if (parent.oChoiceFields[col]["Type"] == "1") {
                    return val;
                }
                if (parent.oChoiceFields[col]["Type"] == "2" || parent.oChoiceFields[col]["Type"] == "4") {
                    return parent.getChoiceVal(col, val);
                }
                if (parent.oChoiceFields[col]["Type"] == "3") {
                    return parent.getResourceVal(val);
                }
            }
        }

        Grids.OnRenderFinish = function (grid) {

            if (grid.id == "UpdateGrid") {
                for (var r in grid.Rows) {
                    var uRow = grid.GetRowById(r);
                    if (uRow.Kind == "Data") {
                        for (var c in grid.Cols) {
                            try {
                                var val = grid.GetValue(uRow, c);
                                var oFromRow = parent.Grids.WorkPlannerGrid.GetRowById(uRow.id);

                                grid.SetAttribute(uRow, c, "Type", parent.Grids.WorkPlannerGrid.Cols[c].Type);
                                if (c == "Title") {
                                    if (oFromRow) {
                                        if(oFromRow.Def.Name == "Assignment")
                                            grid.SetValue(uRow, c, val + "(" + oFromRow.Title + ")", 1, 0);
                                    }
                                }
                                if (parent.Grids.WorkPlannerGrid.Cols[c].Type == "Date" && val != "") {
                                    if (oFromRow) {
                                        var dtTo = new Date(val);

                                        if (parent.Grids.WorkPlannerGrid.GetValue(oFromRow, c) != "") {
                                            var dtFrom = new Date(parent.Grids.WorkPlannerGrid.GetValue(oFromRow, c));

                                        }
                                        else {
                                            if (parent.oRollUp[c] && parent.oRollUp[c].toLowerCase() == "max") {
                                                var dtFrom = new Date(parent.Grids.WorkPlannerGrid.RoundGanttDate(new Date(val).valueOf(), 2, null, null, null));
                                            }
                                            else {
                                                var dtFrom = new Date(parent.Grids.WorkPlannerGrid.RoundGanttDate(new Date(val).valueOf(), 8, null, null, null));
                                            }
                                        }

                                        dtTo.setHours(dtFrom.getHours());
                                        val = dtTo.valueOf();
                                    }
                                    else {
                                        if (c == "DueDate")
                                            var dtFrom = new Date(parent.Grids.WorkPlannerGrid.RoundGanttDate(parent.Grids.WorkPlannerGrid.RoundGanttDate(new Date(val).valueOf(), 2, null, null, null), 4));
                                        else if (c == "StartDate")
                                            var dtFrom = new Date(parent.Grids.WorkPlannerGrid.RoundGanttDate(new Date(val).valueOf(), 8, null, null, null));
                                        else {
                                            if (parent.oRollUp[c] && parent.oRollUp[c].toLowerCase() == "max") {
                                                var dtFrom = new Date(parent.Grids.WorkPlannerGrid.RoundGanttDate(parent.Grids.WorkPlannerGrid.RoundGanttDate(new Date(val).valueOf(), 2, null, null, null), 4));
                                            }
                                            else {
                                                var dtFrom = new Date(parent.Grids.WorkPlannerGrid.RoundGanttDate(new Date(val).valueOf(), 8, null, null, null));
                                            }
                                        }
                                        var dtTo = new Date(val);
                                        dtTo.setHours(dtFrom.getHours());
                                        val = dtTo.valueOf();
                                    }
                                    grid.SetValue(uRow, c, val, 1, 0);
                                }

                                try {
                                    grid.SetAttribute(uRow, c, "Format", parent.Grids.WorkPlannerGrid.Cols[c].Format);
                                } catch (e) { }

                                if (parent.Grids.WorkPlannerGrid.Cols[c].Type == "Enum") {
                                    grid.SetAttribute(uRow, c, "Enum", parent.Grids.WorkPlannerGrid.Cols[c].Enum);
                                    if (parent.Grids.WorkPlannerGrid.Cols[c].Range == "1") {
                                        grid.SetAttribute(uRow, c, "Range", parent.Grids.WorkPlannerGrid.Cols[c].Range);
                                        grid.SetAttribute(uRow, c, "EnumKeys", parent.Grids.WorkPlannerGrid.Cols[c].EnumKeys);
                                    }
                                }

                                try {

                                    if (oFromRow) {
                                        var oVal = parent.Grids.WorkPlannerGrid.GetValue(oFromRow, c);

                                        if (grid.GetValue(uRow, c) != oVal && c != "Title") {
                                            grid.SetAttribute(uRow, c, "Background", "#FFFC00 !important");
                                            grid.SetAttribute(uRow, c, "Color", "#FFFC00 !important");
                                        }
                                    }
                                } catch (e) { }

                            } catch (e) { }
                        }
                        grid.ColorRow(uRow);
                        grid.RefreshRow(uRow);
                    }
                }
            }
        }

        Grids.OnDblClick = function (grid, row, col, x, y, event) {

            if (grid.id == "UpdateGrid") {
                divDetail.style.display = "";

                if (row.id.toString().indexOf("NT") == 0) {
                    Grids.UpdateDetail.HideCol("O");
                }
                else {
                    Grids.UpdateDetail.ShowCol("O");
                }

                for (var c in grid.Cols) {
                    try {
                        var uRow = Grids.UpdateDetail.GetRowById(c);

                        Grids.UpdateDetail.SetAttribute(uRow, "O", "Type", parent.Grids.WorkPlannerGrid.Cols[c].Type);
                        Grids.UpdateDetail.SetAttribute(uRow, "V", "Type", parent.Grids.WorkPlannerGrid.Cols[c].Type);

                        try {
                            Grids.UpdateDetail.SetAttribute(uRow, "O", "Format", parent.Grids.WorkPlannerGrid.Cols[c].Format);
                            Grids.UpdateDetail.SetAttribute(uRow, "V", "Format", parent.Grids.WorkPlannerGrid.Cols[c].Format);
                        } catch (e) { }

                        if (parent.Grids.WorkPlannerGrid.Cols[c].Type == "Enum") {
                            Grids.UpdateDetail.SetAttribute(uRow, "O", "Enum", parent.Grids.WorkPlannerGrid.Cols[c].Enum);
                            Grids.UpdateDetail.SetAttribute(uRow, "V", "Enum", parent.Grids.WorkPlannerGrid.Cols[c].Enum);

                            if (parent.Grids.WorkPlannerGrid.Cols[c].Range == "1") {
                                grid.SetAttribute(uRow, "O", "Range", parent.Grids.WorkPlannerGrid.Cols[c].Range);
                                grid.SetAttribute(uRow, "O", "EnumKeys", parent.Grids.WorkPlannerGrid.Cols[c].EnumKeys);

                                grid.SetAttribute(uRow, "V", "Range", parent.Grids.WorkPlannerGrid.Cols[c].Range);
                                grid.SetAttribute(uRow, "V", "EnumKeys", parent.Grids.WorkPlannerGrid.Cols[c].EnumKeys);
                            }
                        }
                        Grids.UpdateDetail.SetValue(uRow, "V", grid.GetValue(row, c), 1, 0);

                        var oRow = parent.Grids.WorkPlannerGrid.GetRowById(row.id);
                        if (oRow) {
                            Grids.UpdateDetail.SetValue(uRow, "O", parent.Grids.WorkPlannerGrid.GetValue(oRow, c), 1, 0);

                            if (Grids.UpdateDetail.GetValue(uRow, "O") != Grids.UpdateDetail.GetValue(uRow, "V") && c != "Title") {
                                uRow.Background = "#FFFC00 !important ";
                                uRow.Color = "#FFFC00 !important ";
                                Grids.UpdateDetail.ColorRow(uRow);
                            }
                        }
                        Grids.UpdateDetail.RefreshRow(uRow);
                    } catch (e) { }
                }
                var options = { html: divDetail, width: 500, height: 300, title: "Task Details", dialogReturnValueCallback: temp };

                parent.SP.UI.ModalDialog.showModalDialog(options);

                Grids.UpdateDetail.Rerender();
            }
        }

        function temp() {
            Grids.UpdateGrid.Rerender();
        }

        _spBodyOnLoadFunctionNames.push("setHeight");

        if (window.addEventListener)
            window.addEventListener('resize', setHeight, false);
        else if (window.attachEvent)
            window.attachEvent('onresize', setHeight);            

        function setHeight() {
            var h = getHeight();
            document.getElementById("divMain").style.height = (h - 40) + "px";
            document.getElementById("divTree").style.height = (h - 90) + "px";

            if(!divDetail)
                divDetail = document.getElementById("divDetail");

            divDetail.style.display = "none";
        }

        function CancelBubbling(obj, evt) {
            var e = (evt) ? evt : window.event;
            if (window.event) {
                e.cancelBubble = true;
            }
            else {
                e.stopPropagation();
            }
        }


        function SelectAllAccept(chk) {
            doChecks(chk, "Reject", "Accept");
        }

        function doChecks(chk, col1, col2) {
            var grid = Grids.UpdateGrid;
            var rows = grid.Rows;

            if (chk.checked) {
                for (var R in rows) {
                    var row = rows[R];

                    if (row.Kind == "Data") {
                        grid.SetValue(row, col1, 0, 1);
                        grid.SetValue(row, col2, 1, 1);
                    }
                }
            }
            else {
                for (var R in rows) {
                    var row = rows[R];

                    if (row.Kind == "Data") {
                        grid.SetValue(row, col2, 0, 1);
                    }
                }
            }
        }

        function SelectAllReject(chk) {
            doChecks(chk, "Accept", "Reject");
        }

    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    
    <div id="divMain" style="width:100%; height:400px">
        <div id="div1" style="width:100%; height:20px">
            Double click to view task details.<br />
        </div>
        <div id="divTree" style="width:100%; height:400px">
            <treegrid Data_Url="../../_vti_bin/WorkPlanner.asmx" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Functionname="GetUpdates" Data_Param_Dataxml="<%=sParam %>"></treegrid>
        </div>
        <div style="width:100%; height: 30px; vertical-align:bottom;">
            <p style="float:left">
                <a href="#" onclick="Javascript:Grids.UpdateGrid.ActionShowColumns(); return false;">[Add/Remove Columns]</a>
            </p>
            <p style="float:right">
                <input type="button" value="Process" onclick="javascript:ProcessUpdates();"/> 
                <input type="button" value="Cancel" onclick="parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.cancel, 'Cancel clicked'); return false;" /> 
            </p>
            <div style="clear: both;"></div>
        </div>
        
    </div>
    <div id="divDetail" style="width:100%;height:100%">
        <treegrid Data_Url="../../_vti_bin/WorkPlanner.asmx" Data_Method="Soap" Data_Function="Execute" Data_Namespace="workengine.com" Data_Param_Functionname="GetUpdateDetailLayout" Data_Param_Dataxml="<%=sParam %>"></treegrid>
    </div>
    <div id="dlgProcessing" class="dialog">
        <table width="100%">
            <tr>
                <td align="center" class="ms-sectionheader">
                    <img src="../images/GEARS_ANv4.GIF" style="vertical-align: middle;"/><br />
                    <H3 class="ms-standardheader">Processing Updates...</h3>
                </td>
            </tr>
                    
        </table>
    </div> 
    
    <script>
        initmb();
    </script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Process Updates
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Process Updates
</asp:Content>
