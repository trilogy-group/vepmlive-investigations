import {HomePageConstants} from '../homepage/home-page.constants';
import {MyWorkplaceConstants} from '../my-workplace/my-workplace.constants';
import {CreateNewPageConstants} from '../items-page/create-new-page.constants';

export class CommonPageConstants {
    static readonly pageName = 'Create New';
    static filesDirectoryName = 'files';
    static readonly currentDir = __dirname;
    static readonly tabPanel = 'Tab Panel';
    static readonly title = 'Title';

    static get imageFile() {
        return {
            fileType: '.jpg',
            jpegFileName: 'jpeg-image',
            filePath: () => {
                return `${this.currentDir}\\${this.filesDirectoryName}\\${this.imageFile.jpegFileName}${this.imageFile.fileType}`;
            }
        };
    }

    static get documentFile() {
        return {
            fileType: '.pdf',
            documentFileName: 'pdf-file',
            filePath: () => {
                return `${this.currentDir}\\${this.filesDirectoryName}\\${this.documentFile.documentFileName}${this.documentFile.fileType}`;
            }
        };
    }

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

    static get ribbonLabels() {
        return {
            save: 'Save',
            cancel: 'Cancel',
            viewItem: 'ViewItem',
            editItem: 'EditItem',
            editTeam: 'Edit Team',
            saveAndClose: 'Save &',
            close: 'Close',
            saveAndClose: 'Save &Close',
            assignmentPlanner: 'Assignment Planner'
        };
    }

    static get formLabels() {
        return {
            save: 'Save',
            cancel: 'Cancel',
            ok: 'OK',
            add:  '< Add',
            remove: 'Remove >'
        };
    }

    static get ribbonMenuTitles() {
        return {
            hide: `Hide`,
            items: `Items`,
            list: `List`
        };
    }

    static get pageHeaders() {
        return {
            projects: HomePageConstants.navigationLabels.projects,
            myWorkplace: MyWorkplaceConstants.navigationLabels,
            createNew: CreateNewPageConstants.navigationLabels
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
            comments: 'Comments',
            editTeam: 'Edit Team'
        };
    }

    static get menuContainerIds() {
        return {
            navigation: 'EPMLiveNav',
            createNew: 'epm-nav-sub-new',
            myWorkplace: 'epm-nav-sub-workplace-static-links'
        };
    }

    static get statuses() {
        return {
            notStarted: 'Not Started',
            inProgress: 'In Progress',
            completed: 'Completed',
            deferred: 'Deferred',
            waitingOnSomeoneElse: 'Waiting on someone else'
        };
    }

    static get priorities() {
        return {
            high: '(1) High',
            normal: '(2) Normal',
            low: '(3) Low',
        };
    }

    static get portfolioTypes() {
        return {
            other: 'Other',
            customer: 'Customer',
            development: 'Development',
            enhancement: 'Enhancement',
            support: 'Support',
            program: 'Program',
            marketing: 'Marketing'
        };
    }

    static get portfolioGoals() {
        return {
            customerSatisfaction: 'Customer Satisfaction',
            growBusiness: 'Grow Business',
            runBusiness: 'Run Business',
            transformation: 'Transformation'
        };
    }

    static get states() {
        return {
            proposed: '(1) Proposed',
            active: '(2) Active',
            closed: '(3) Closed',
        };
    }

    static get projectUpdate() {
        return {
            manual: 'Manual',
            scheduleDriven: 'Schedule Driven'
        };
    }

    static get overallHealth() {
        return {
            onTrack: '(1) On Track',
            atRisk: '(2) At Risk',
            offTrack: '(3) Off Track',
        };
    }

    static get teamId() {
        return {
            currentTeam: 'TeamGrid',
            resourcePool: 'ResourceGrid'
        };
    }
}
