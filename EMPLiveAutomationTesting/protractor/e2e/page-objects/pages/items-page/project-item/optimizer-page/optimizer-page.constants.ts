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
    static readonly collapsed = 'Collapsed Ribbon';
    static readonly optimizer = 'Optimizer Window';
    static readonly deleteView = 'Delete view popup';
    static readonly currentView= 'Current View';
    static readonly configure= 'Configure window';
    static readonly selectColumns= 'Select Columns Window';
    static readonly saveStrategy = 'Save strategy popup';

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
            column: '.GMColumnsMenuItemText',
            header: 'Select columns to display',
            showAll: 'Show all'
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
            heading: 'Optimizer Configuration',
            enterValueLabel: '1) Which field will be totaled and used to compare to the manually entered value?',
            titleComparisonLabel: '2) Enter a title for the comparison field.',
            thirdQuestion: '3) Which fields will be used as filters?',
            availableFields: 'Available Fields',
            selectedFilelds: 'Selected Fields',
            add: 'idOptConfAdd',
            remove: 'idOptConfRemove',
            availableFieldsSelect: 'idOptConfAvailfields',
            selectedFieldsSelect: 'idOptConfAvailfields',
            upArrow: 'idOptConfSelectedColsMoveUp',
            downArrow: 'idOptConfSelectedColsMoveDown',
            ok: 'OK',
            cancel: 'Cancel',
            message: 'Selecting more fields that can fit in to the space available in the filter section on the ' +
                'ribbon bar, will cause the filter section to not appear. If this occurs, then reduce the number of fields' +
                ' selected until it does appear.'
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

    static get optimizerRibbon() {
        return{
            collapseView: 'idOptimizerTabDiv_ulCollapsed',
                expandView: 'idOptimizerTabDiv_ul',
        };
    }

    static get deleteViewPopup(){
        return {
            deleteViewPopup: 'idDeleteViewDlg',
            deleteViewMessage: 'Are you sure you want to delete this view?',
            viewName: 'id_DeleteView_Name',
            ok: 'OK',
            cancel: 'Cancel'
        };
    }
}
