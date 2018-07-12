export class ResourcePlannerConstants {
    static readonly department = 'Test department 1';
    static readonly  title = 'Resource Planner - Project Mode';
    static readonly user = 'Ajay Suwalka';
    static readonly greenCheckImg = 'Mark should turn to a green check'
    static readonly  privateCheckImg = 'Private Image is Displayed'

    static get topSection() {
        return {
            save: 'SavePlanBtn',
            close: 'CloseBtn',
            note: 'RowNoteBtn',
            makePublic: 'PublicBtn',
            delete: 'DeleteBtn',
            allocateValue: 'SpreadBtn',
            importWork: 'ImportWorkBtn',
            importCostPlan: 'ImportCostPlanBtn',
            exportToExcel: 'idExportExcelTop',
            print: 'idPrintTop',

        };
    }
    static get topGrid() {
        return {
            itemName: 'Item Name',
            department: 'Department',
            role: 'Role',
            comment: 'Comment',
               };
    }
    static get buttonSection() {
        return {
            matchButton: 'MatchBtn',
            addButton: 'ResAddBtn',
            analyzeButton: 'ResAnalyzeBtn',
            selectResColumnsBtn: 'SelectResColumnsBtn',
            clearSorting: 'idResourcesTab_RemoveSorting',
            showFilter: 'idResourcesTab_ShowFilters',
            showGrouping: 'idResourcesTab_ShowGrouping',
            heatMap: 'idResourcesTab_ShowHeatmap',

        };
    }
}
