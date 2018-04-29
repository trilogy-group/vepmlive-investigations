import {HomePageConstants} from '../home-page.constants';

export class CommonViewPageConstants {
    static get pageHeaders() {
        return HomePageConstants.navigationLabels;
    }

    static get actionMenuIconTitles() {
        return {
            search: 'search',
            toggleFilters: 'toggle filters',
            defaultSort: 'default sort',
            groupBy: 'Group by',
            selectColumns: 'select columns',
            view: 'View: ',
            settings: 'settings'
        };
    }

    static get contextMenuOptions() {
        return {
            viewItem: 'View Item',
            editItem: 'Edit Item',
            workFlows: 'Workflows',
            permissions: 'Permissions',
            deleteItem: 'Delete Item',
            comments: 'Comments'
        };
    }

}
