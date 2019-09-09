export class SettingsPageConstants {
    static get menuTitlesAndIds() {
        return {
            collaborationSettings: {
                rootId: 'epm-nav-sub-settings-collaboration-settings',
                childMenuLabels: {
                    notificationSettings: 'Notification Settings',
                    userAlerts: 'User Alerts',
                    workSettings: 'Work Settings'
                }
            },
            configurationSettings: {
                rootId: 'epm-nav-sub-settings-configuration',
                childMenuLabels: {
                    listSynchronization: 'List Synchronization',
                    manageApps: 'Manage Apps',
                    manageCommunities: 'Manage Communities',
                    portfolioFields: 'Portfolio Fields',
                    portfolioLookups: 'Portfolio Lookups',
                    portfolioPermissions: 'Portfolio Permissions',
                    setupWizard: 'Setup Wizard',
                    siteLibrariesAndLists: 'Site Libraries and Lists',
                    workspaceTemplates: 'Workspace Templates'
                }
            },
            costManagement: {
                rootId: 'epm-nav-sub-settings-cost-management',
                childMenuLabels: {
                    calendarsPeriods: 'Calendars & Periods',
                    costCategories: 'Cost Categories',
                    costModels: 'Cost Models',
                    costTypeFields: 'Cost Type Fields',
                    costTypes: 'Cost Types',
                    costViews: 'Cost Views',
                    portfolioCostViews: 'Portfolio Cost Views',
                    rates: 'rates'
                }
            },
            enterpriseReporting: {
                rootId: 'epm-nav-sub-settings-enterprise-reporting',
                childMenuLabels: {
                    ReportingSettings: 'Advanced Reports',
                    classicReports: 'Classic Reports',
                    reportingSettings: 'Reporting Settings'
                }
            },
            lookAndFeel: {
                rootId: 'epm-nav-sub-settings-look-feel',
                childMenuLabels: {
                    regionalSettings: 'Regional Settings',
                    titleAndLogo: 'Title and Logo'
                }
            },
            plannerSettings: {
                rootId: 'epm-nav-sub-settings-planner-settings',
                childMenuLabels: {
                    plannerTemplates: 'Planner Templates',
                    planners: 'Planners'
                }
            },
            resourceManagement: {
                rootId: 'epm-nav-sub-settings-resource-management',
                childMenuLabels: {
                    calendarsPeriods: 'Calendars & Periods',
                    fieldMapping: 'Field Mapping',
                    fields: 'Fields',
                    plannerAdmin: 'Planner Admin'
                }
            },
            systemSettings: {
                rootId: 'epm-nav-sub-settings-system-settings',
                childMenuLabels: {
                    generalSettings: 'General Settings',
                    timerSettings: 'Timer Settings',
                    workspaceSettings: 'Workspace Settings'
                }
            },
            timeSheetSettings: {
                rootId: 'epm-nav-sub-settings-timesheet-settings',
                childMenuLabels: {
                    timeSheetSettings: 'Timesheet Settings',
                }
            },
            userManagement: {
                rootId: 'epm-nav-sub-settings-user-management',
                childMenuLabels: {
                    departments: 'Departments',
                    holidaySchedules: 'Holiday Schedules',
                    nonWork: 'Non Work',
                    resourcePool: 'Resource Pool',
                    roles: 'Roles',
                    workHours: 'Work Hours'
                }
            },
            utilities: {
                rootId: 'epm-nav-sub-settings-utilities',
                childMenuLabels: {
                    portfolioDBAdmin: 'Portfolio DB Admin',
                    portfolioQueue: 'Portfolio Queue',
                    recycleBin: 'Recycle Bin',
                    timeSheetCosts: 'Timesheet Costs',
                    workQueue: 'Work Queue'
                }
            }
        };
    }
}