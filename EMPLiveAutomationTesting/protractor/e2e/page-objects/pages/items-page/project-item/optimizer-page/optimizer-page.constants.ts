export class OptimizerPageConstants {
    static readonly newViewName = 'New View';

    static get viewManagementOptions() {
        return {
            saveView: 'SaveViewBtn',
            renameView: 'RenameViewBtn',
            deleteView: 'DeleteViewBtn',
            clearSorting:'idViewTab_RemoveSorting',
            selectColumns:'SelectColumnsBtn',
            currentView:'idAnalyzerTab_SelView_textbox'
        };
    }

    static get saveViewPopup(){
        return{
            viewName:'id_SaveView_Name',
            defaultView:'id_SaveView_Default',
            personalView:'id_SaveView_Personal',
            ok:'OK',
            cancel:'Cancel'
        };
    }

    static get selectColumnsPopup(){
        return{
            ok:'OK',
            hideAll:'Hide all',
            cancel:'Cancel'
        };
    }

}

