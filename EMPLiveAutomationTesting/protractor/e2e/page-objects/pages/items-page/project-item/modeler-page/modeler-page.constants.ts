export class ModelerPageConstants {
    static readonly selectModel = 'Modeler popup';
    static readonly modeler = 'Modeler page';
    static readonly findNext = 'Find Next Button';
    static readonly ok= 'OK Button';
    static readonly cancel= 'Cancel Button';
    static readonly selectModelDropdown = 'Select Model Dropdown';
    static readonly selectVersions = 'Select versions selection box';
    static readonly activeTab = 'Active Tab';
    static readonly viewTab = 'View Tab';
    static readonly settingsSearch = 'Search for label';
    static readonly settingsWhere = 'Where dropdown';
    static readonly settingsIn = 'In dropdown';
    static readonly settingsDetails = 'Details radio button';
    static readonly settingsTotals = 'Totals radio button';
    static readonly disabled = 'disabled';

    static get selectModelAndVersionsPopup() {
        return {
            title: 'Select Model and Versions',
            titleClass: 'dhtmlx_wins_title',
            selectModelDropdown: 'idModelList',
            versionsSelectionBox: 'idVersionList',
            ok: 'OK',
            cancel: 'Cancel',
        };
    }

    static get tabNames(){
        return {
            display: 'Display',
            view: 'View'
        };
    }

    static get displayTabOptions() {
        return {
            close: 'close',
            totalDetails: 'DetailsBtn',
            searchSettings: 'tSearchBtn',
            findNext: 'FindBtn',
            saveVersion: 'SaveVers',
            copyVersion: 'CopyVers',
        };
    }

    static get searchSettingsPopup() {
        return {
            searchFor: 'idtxtsearch',
            where: 'idSearchHow',
            in: 'idSearchWhere',
            details: 'rbSearchDet',
            totals: 'rbSearchTot',
            ok: 'OK',
            cancel: 'Cancel'
        };
    }
}
