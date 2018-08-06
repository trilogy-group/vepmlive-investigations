export class OptimizerPageConstants {
    static readonly newViewName = 'New View';
    static readonly viewTab= 'View tab';
    static readonly saveView= 'Save view popup';
    static readonly oneItemConfigureAlertMsg= 'You cannot Optimize only one Item!';
    static readonly availableFieldsSection= 'Available Fields section';
    static readonly selectedFieldsSection= 'Selected Fields section';
    static readonly upArrow= 'Up Arrow';
    static readonly downArrow= 'Down Arrow';
    static readonly add= 'Add';
    static readonly remove= 'Remove';
    static readonly strategyName= 'Strategy';
    static readonly currentStrategy= 'Current Strategy';
    static readonly deleteStrategy = 'Delete strategy popup';
    static readonly ok= 'OK';
    static readonly cancel= 'Cancel';

    static get viewManagementOptions() {
        return {
            saveView: 'SaveViewBtn',
            renameView: 'RenameViewBtn',
            deleteView: 'DeleteViewBtn',
            clearSorting: 'idViewTab_RemoveSorting',
            selectColumns: 'SelectColumnsBtn',
            currentView: 'idAnalyzerTab_SelView_textbox'
        };
    }

    static get saveViewPopup() {
        return {
            viewName: 'id_SaveView_Name',
            defaultView: 'id_SaveView_Default',
            personalView: 'id_SaveView_Personal',
            ok: 'OK',
            cancel: 'Cancel'
        };
    }

    static get selectColumnsPopup() {
        return {
            ok: 'OK',
            hideAll: 'Hide all',
            cancel: 'Cancel',
            eachColumn: '.GMColumnsMenuItemText'
        };
    }

    static get tabOptions() {
        return {
            optimizer: 'Optimizer',
            view: 'View'
        };
    }

    static get optimizerConfiguration(){
        return{
            thirdQuestention: '3) Which fields will be used as filters?',
            availableFields: 'Available Fields',
            selectedFilelds: 'Selected Fields',
            add: 'idOptConfAdd',
            remove: 'idOptConfRemove',
            availableFieldsSelect: 'idOptConfAvailfields',
            selectedFieldsSelect: 'idOptConfAvailfields',
            upArrow: 'idOptConfSelectedColsMoveUp',
            downArrow: 'idOptConfSelectedColsMoveDown',
            ok: 'OK',
            cancel: 'Cancel'
        };
    }

    static get optimizerStrategyActions(){
        return{
            saveStrategy: 'idptSaveScen',
            renameStrategy: 'idrenamestrat',
            deleteStrategy: 'idptDelScen',
            commitStrategy: 'idptCmtScen',
            currentStrategyDropdown: 'idOptTab_SelView_textbox',
            currentStrategyDropdownSpan: 'idOptTab_SelView_button'
        };
    }

    static get optimierSaveStrategyPopup(){
        return{
            strategyName: 'idSaveStratName',
            personalStrategyCheckBox: 'idStratPer',
            ok: 'OK',
            cancel: 'Cancel'
        };
    }

    static get deleteStrategyPopup(){
        return{
            message: 'Are you sure you want to delete this Strategy?',
            ok: 'OK',
            cancel: 'Cancel'
        };
    }
}
