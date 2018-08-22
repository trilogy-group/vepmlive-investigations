import {HomePageConstants} from '../homepage/home-page.constants';
import {MyWorkplaceConstants} from '../my-workplace/my-workplace.constants';
import {CreateNewPageConstants} from '../items-page/create-new-page.constants';
import * as path from 'path';

export class CommonPageConstants {
    static readonly pageName = 'Create New';
    static filesDirectoryName = 'files';
    static readonly currentDir = __dirname;
    static readonly tabPanel = 'Tab Panel';
    static readonly timeZone = 'Time Zone and Region';
    static readonly calendarContent = 'Calendar Content';
    static readonly createView = 'create View';
    static readonly title = 'Title';
    static readonly columnDescription = 'Column Desciption';
    static readonly viewType = 'View Type';
    static readonly createdView = 'created View';
    static readonly viewAll = 'View All';
    static readonly columnType = 'Column Type';
    static readonly columnName = 'Column Name';
    static readonly newItem = 'New Item';
    static readonly calendar = 'Calendar';
    static readonly attachFilePopupTitle = 'Attach File';
    static readonly last = 'Last';
    static readonly fileUpload = 'fileUpload';
    static readonly column = 'Column Popup';
    static readonly dropDown: string = 'dropdown-toggle';
    static readonly linkDisable = 'This control is currently disabled.';

    static get viewDropDownLabels() {
        return {
            createPublicView: 'Create View'
        };
    }

    static get imageFile() {
        return {
            fileType: '.jpg',
            jpegFileName: 'jpeg-image',
            filePath: () => {
                return path.join(this.currentDir, this.filesDirectoryName, this.imageFile.jpegFileName + this.imageFile.fileType);
            }
        };
    }

    static get documentFile() {
        return {
            fileType: '.pdf',
            documentFileName: 'pdf-file',
            filePath: () => {
                return path.join(this.currentDir, this.filesDirectoryName, this.documentFile.documentFileName + this.documentFile.fileType);
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
            editItem: ' - Edit Item',
            subject: ' - Subject',
            resourceAnalyzer: 'Resource Analyzer'
        };
    }

    static get ribbonLabels() {
        return {
            save: 'Save',
            cancel: 'Cancel',
            viewItem: 'ViewItem',
            editItem: 'EditItem',
            editCost: 'EPKCosts',
            addTask: 'AddTask-Large',
            add: 'Add',
            attachFile: 'AttachFile',
            delete: 'Ribbon.ListItem.Manage.Delete-Small',
            editTeam: 'Edit Team',
            buildTeam: 'Build Team',
            close: 'Close',
            insert: 'Insert',
            saveAndClose: 'Save &Close',
            assignmentPlanner: 'Assignment Planner',
            viewReports: 'View Reports',
            resourceAvailableVsPlannedByDept: 'Resource Available vs. Planned by Dept',
            resourceCapacityHeatMap: 'Resource Capacity Heat Map',
            resourceCommitments: 'Resource Commitments',
            resourceRequirements: 'Resource Requirements',
            resourceWorkVsCapacity: 'Resource Work vs. Capacity',
            editResource: 'Edit Resource',
            resourceAnalyzer: 'ResourceAnalyzer',
            apply: 'Apply',
            optimizer: 'Optimizer',
            modeler: 'Modeler'
        };
    }

    static get disabledribbonbuttonsId() {
        return {
            saveAndClose: 'SaveCloseButton'
        };
    }

    static get formLabels() {
        return {
            save: 'Save',
            cancel: 'Cancel',
            close: 'Close',
            ok: 'OK',
            okWithSmallK: 'Ok',
            add: '< Add',
            remove: 'Remove >',
            delete: 'Delete',
            topSave: 'onetidSaveItemtop'
        };
    }

    static get newPublicViewformLabels() {
        return {
            title: 'NewViewName',
            publicView: 'PersonalView1',
            scheduleStatus: 'ShouldDisplayScheduleStatus',
            exposure: 'ShouldDisplayExposure',
            due: 'ShouldDisplayDue'
        };
    }

    static get ribbonMenuTitles() {
        return {
            hide: `Hide`,
            manage: `Manage`,
            items: `Items`,
            list: `List`,
            page: `Page`,
        };
    }

    static get costData() {
        return {
            firstData: '120.00',
            budgetData: '120',
            actualCostData: '130',
            benefitsData: '140',
        };
    }

    static get documentUploadText() {
        return  'The document was uploaded successfully. Use this form to update the properties of the document.';
    }

    static get cell() {
        return {
            cell1: 'HideCol0C10',
            cell2: 'HideCol0C11',
            cell3: 'HideCol0C13',
            cell4:  'HideCol0C15',
            cell5: 'HideCol0C1',
            cell6: 'HideCol1C1',
            cell7: 'HideCol2C1'
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
            editTeam: 'Edit Team',
            costPlan: 'Cost Plan',
            editPlan: 'Edit Plan',
            editCosts: 'Edit Costs'
        };
    }

    static get menuContainerIds() {
        return {
            navigation: 'EPMLiveNav',
            createNew: 'epm-nav-sub-new',
            myWorkplace: 'epm-nav-sub-workplace-static-links'
        };
    }

    static get versionComment() {
        return {
            first: 'New Version of previously updated file',
            second: '0.2'
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

    static get resourceGrid() {
        return {
            resourceGridColumn: 'Resource Grid Column',
            resourceAddGridColumn: 'Resource Add Grid Column'
        };
    }

    static get overallHealth() {
        return {
            onTrack: '(1) On Track',
            atRisk: '(2) At Risk',
            offTrack: '(3) Off Track',
        };
    }

    static get costButtonLabel() {
        return {
            budget: 'Budget',
            actualCost: 'Actual Costs',
            benefits:   'Benefits'
        };
    }

    static get teamId() {
        return {
            currentTeam: 'TeamGrid',
            resourcePool: 'ResourceGrid'
        };
    }

    static get paginationTitle() {
        return {
            next: 'Next',
            previous: 'Previous'
        };
    }

    static get dropdownShowAllButton() {
        return {
            project: 'Project_ddlShowAll',
            timeOffType: 'TimeOffType_ddlShowAll',
            role: 'Role_ddlShowAll',
            holidaySchedule: 'HolidaySchedule_ddlShowAll',
            workHours: 'WorkHours_ddlShowAll',
            portfolio: 'Portfolio_ddlShowAll',
        };
    }

    static get searchControl() {
        return {
            searchComponentDropdown : 'Component dropdown',
            searchOperatorDropdown: 'Search Operator dropdown',
            searchField : 'Search Field',
        };
    }

    static get messages() {
        return {
            noDataFound : 'No data found',
        };
    }

    static get hours() {
        return {
            durationHours1 : '10.00',
            effortHours: '80',
            durationHours2 : '20.00',
            durationHours3 : '30.00',
            durationHours4 : '5.00',
            updatedEffortHours : '160.00'
        };
    }

    static get columnHeader() {
        return {
            status: 'Status'
        };
    }

    static get specificIds() {
        return {
            saveEventId: 'idIOSaveItem'
        };
    }

    static get buttonName() {
        return {
            edit: 'Edit',
            addButton: 'Add Link'
        };
    }

    static get classNames() {
        return {
            headerButtonClass: 'GMHeaderButton',
            headerTextClass: 'GMHeaderText',
            ascendingClass: 'GMSort4Right',
            descendingClass: 'GMSort1Right'
        };
    }

    static get sidebarMenuPanelHeader() {
        return {
            createNew: 'Create New',
            myWorkplace: 'My Workplace',
            favorites: 'Favorites',
            mostRecent: 'Recent Items',
            settings: 'Settings',
            workspaces: 'Workspaces',
            frequentApps: 'Frequent Apps',
        };
    }

    static get predecessorsData() {
        return {
            predecessors1: '1',
            predecessorsNull: ' ',
            predecessors2: '2',
        };
    }
}
