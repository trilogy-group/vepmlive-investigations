import {SettingsPageConstants} from './settings-page.constants';
import {By, element} from 'protractor';

export class SettingsPage {
    static get menuItems() {
        const menuTitlesAndIds = SettingsPageConstants.menuTitlesAndIds;
        return {
            collaborationSettings: {
                rootId: element(By.id(menuTitlesAndIds.collaborationSettings.rootId)),
                childLabels: {
                    notificationSettings: element(By.linkText(menuTitlesAndIds.collaborationSettings.childLabels.notificationSettings)),
                    userAlerts: element(By.linkText(menuTitlesAndIds.collaborationSettings.childLabels.userAlerts)),
                    workSettings: element(By.linkText(menuTitlesAndIds.collaborationSettings.childLabels.workSettings))
                }
            },
            configurationSettings: {
                rootId: element(By.id(menuTitlesAndIds.configurationSettings.rootId)),
                childLabels: {
                    listSynchronization: element(By.linkText(menuTitlesAndIds.configurationSettings.childLabels.listSynchronization)),
                    manageApps: element(By.linkText(menuTitlesAndIds.configurationSettings.childLabels.manageApps)),
                    manageCommunities: element(By.linkText(menuTitlesAndIds.configurationSettings.childLabels.manageCommunities)),
                    portfolioFields: element(By.linkText(menuTitlesAndIds.configurationSettings.childLabels.portfolioFields)),
                    portfolioLookups: element(By.linkText(menuTitlesAndIds.configurationSettings.childLabels.portfolioLookups)),
                    portfolioPermissions: element(By.linkText(menuTitlesAndIds.configurationSettings.childLabels.portfolioPermissions)),
                    setupWizard: element(By.linkText(menuTitlesAndIds.configurationSettings.childLabels.setupWizard)),
                    siteLibrariesAndLists: element(By.linkText(menuTitlesAndIds.configurationSettings.childLabels.siteLibrariesAndLists)),
                    workspaceTemplates: element(By.linkText(menuTitlesAndIds.configurationSettings.childLabels.workspaceTemplates))
                }
            },
            costManagement: {
                rootId: element(By.id(menuTitlesAndIds.costManagement.rootId)),
                childLabels: {
                    calendarsPeriods: element(By.linkText(menuTitlesAndIds.costManagement.childLabels.calendarsPeriods)),
                    costCategories: element(By.linkText(menuTitlesAndIds.costManagement.childLabels.costCategories)),
                    costModels: element(By.linkText(menuTitlesAndIds.costManagement.childLabels.costModels)),
                    costTypeFields: element(By.linkText(menuTitlesAndIds.costManagement.childLabels.costTypeFields)),
                    costTypes: element(By.linkText(menuTitlesAndIds.costManagement.childLabels.costTypes)),
                    costViews: element(By.linkText(menuTitlesAndIds.costManagement.childLabels.costViews)),
                    portfolioCostViews: element(By.linkText(menuTitlesAndIds.costManagement.childLabels.portfolioCostViews)),
                    rates: element(By.linkText(menuTitlesAndIds.costManagement.childLabels.rates))
                }
            },
            enterpriseReporting: {
                rootId: element(By.id(menuTitlesAndIds.enterpriseReporting.rootId)),
                childLabels: {
                    advancedReports: element(By.linkText(menuTitlesAndIds.enterpriseReporting.childLabels.advancedReports)),
                    classicReports: element(By.linkText(menuTitlesAndIds.enterpriseReporting.childLabels.classicReports)),
                    reportingSettings: element(By.linkText(menuTitlesAndIds.enterpriseReporting.childLabels.reportingSettings))
                }
            },
            lookAndFeel: {
                rootId: element(By.id(menuTitlesAndIds.lookAndFeel.rootId)),
                childLabels: {
                    regionalSettings: element(By.linkText(menuTitlesAndIds.lookAndFeel.childLabels.regionalSettings)),
                    titleAndLogo: element(By.linkText(menuTitlesAndIds.lookAndFeel.childLabels.titleAndLogo))
                }
            },
            plannerSettings: {
                rootId: element(By.id(menuTitlesAndIds.plannerSettings.rootId)),
                childLabels: {
                    plannerTemplates: element(By.linkText(menuTitlesAndIds.plannerSettings.childLabels.plannerTemplates)),
                    planners: element(By.linkText(menuTitlesAndIds.plannerSettings.childLabels.planners))
                }
            },
            resourceManagement: {
                rootId: element(By.id(menuTitlesAndIds.resourceManagement.rootId)),
                childLabels: {
                    calendarsPeriods: element(By.linkText(menuTitlesAndIds.resourceManagement.childLabels.calendarsPeriods)),
                    fieldMapping: element(By.linkText(menuTitlesAndIds.resourceManagement.childLabels.fieldMapping)),
                    fields: element(By.linkText(menuTitlesAndIds.resourceManagement.childLabels.fields)),
                    plannerAdmin: element(By.linkText(menuTitlesAndIds.resourceManagement.childLabels.plannerAdmin))
                }
            },
            systemSettings: {
                rootId: element(By.id(menuTitlesAndIds.systemSettings.rootId)),
                childLabels: {
                    generalSettings: element(By.linkText(menuTitlesAndIds.systemSettings.childLabels.generalSettings)),
                    timerSettings: element(By.linkText(menuTitlesAndIds.systemSettings.childLabels.timerSettings)),
                    workspaceSettings: element(By.linkText(menuTitlesAndIds.systemSettings.childLabels.workspaceSettings))
                }
            },
            timeSheetSettings: {
                rootId: element(By.id(menuTitlesAndIds.timeSheetSettings.rootId)),
                childLabels: {
                    timeSheetSettings: element(By.linkText(menuTitlesAndIds.timeSheetSettings.childLabels.timeSheetSettings)),
                }
            },
            userManagement: {
                rootId: element(By.id(menuTitlesAndIds.userManagement.rootId)),
                childLabels: {
                    departments: element(By.linkText(menuTitlesAndIds.userManagement.childLabels.departments)),
                    holidaySchedules: element(By.linkText(menuTitlesAndIds.userManagement.childLabels.holidaySchedules)),
                    nonWork: element(By.linkText(menuTitlesAndIds.userManagement.childLabels.nonWork)),
                    resourcePool: element(By.linkText(menuTitlesAndIds.userManagement.childLabels.resourcePool)),
                    roles: element(By.linkText(menuTitlesAndIds.userManagement.childLabels.roles)),
                    workHours: element(By.linkText(menuTitlesAndIds.userManagement.childLabels.workHours))
                }
            },
            utilities: {
                rootId: element(By.id(menuTitlesAndIds.utilities.rootId)),
                childLabels: {
                    portfolioDBAdmin: element(By.linkText(menuTitlesAndIds.utilities.childLabels.portfolioDBAdmin)),
                    portfolioQueue: element(By.linkText(menuTitlesAndIds.utilities.childLabels.portfolioQueue)),
                    recycleBin: element(By.linkText(menuTitlesAndIds.utilities.childLabels.recycleBin)),
                    timeSheetCosts: element(By.linkText(menuTitlesAndIds.utilities.childLabels.timeSheetCosts)),
                    workQueue: element(By.linkText(menuTitlesAndIds.utilities.childLabels.workQueue))
                }
            }
        };
    }
}
