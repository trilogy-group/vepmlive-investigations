export class ResourceAnalyzerPageConstants {
    static  readonly display = 'DisplayButton';
    static  readonly cancel = 'CancelButton';
    static  readonly fiscalCalendarDropDown = 'Fiscal Calendar DropDown';
    static get topPannelAnalyzerTab() {
        return {
            publish: 'SaveBtn',
            editResource: 'idEditRes',
            saveScenario: 'idSaveScenario',
            undoButton: 'UndoBtn',
            changeCalendar: 'ChangePeriodBtn',
            showCommittedWork: 'chkCommit',
            showScheduledWork: 'chkMSP',
            showTimeSheetActual: 'chkActual',
            exportToExcel: 'idExportExcelTop',
            print: 'idPrintTop',
        };
    }
    static get topPannelViewTab() {
        return {
            publish: 'SaveBtn',
            editResource: 'idEditRes1',
            saveScenario: 'idSaveScenario1',
            undoButton: 'UndoBtn2',
            saveView: 'SaveViewBtn',
            renameViewBtn: 'RenameViewBtn',
            deleteViewBtn: 'DeleteViewBtn',
            showFilter: 'idAnalyzerShowFilters',
            showGrouping: 'idAnalyzerShowGrouping',
            clearSorting: 'idViewTab_RemoveSorting',
            showBars: 'idAnalyzerShowBars',
            hideDetails: 'idAnalyzerHideDetails',
            selectColumns: 'SelectColumnsBtn',
            expandAll: 'idAnalyzerExpandAll',
            collapseAll: 'idAnalyzerCollapsAll',
            fromPeriod: 'idAnalyzerTab_FromPeriodLabel',
            toPeriod: 'idAnalyzerTab_ToPeriodLabel',
        };
    }
    static get bottomPannel() {
        return {
            totalColumn: 'Total',
            capacityScenarios: 'Capacity',
            showGraph: 'idGraph',
            showDetails: 'idBTSDet',
            showFilter: 'idTotTab_ShowFilters',
            showGrouping: 'idTotTab_ShowGrouping',
            removeSorting: 'idTotTab_RemSort',
            selectColumn: 'idTotTab_SelCol',
            expandAll: 'idTotExpandAll',
            collapseAll: 'idTotCollapsAll',
            legend: 'TargetLegend',
            exportExcel: 'idExportExcelBot',
            print: 'idPrintBot',
            comparisonData: 'Comparison',
        };
    }
}
