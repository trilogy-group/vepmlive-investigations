import {HomePageConstants} from '../homepage/home-page.constants';
import {MyWorkplaceConstants} from '../my-workplace/my-workplace.constants';

export class CommonPageConstants {
    static get dataConstants() {
        return {
            dev: 'dev'
        };
    }

    static get and() {
        return ' and ';
    }

    static get pagePostFix() {
        return {
            newItem: ' - New Item',
            editItem: ' - Edit Item'
        };
    }

    static get pageHeaders() {
        return {
            projects: HomePageConstants.navigationLabels.projects,
            myWorkplace: MyWorkplaceConstants.navigationLabels
        };
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
