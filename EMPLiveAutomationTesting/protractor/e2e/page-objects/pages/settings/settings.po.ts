import {By, element} from 'protractor';
import {SettingsPageConstants} from './settings-page.constants';

export class SettingsPage {
    static get menuItems() {
        const menuTitlesAndIds = SettingsPageConstants.menuTitlesAndIds;
        return {
            collaborationSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.collaborationSettings.rootId)),
                childMenus: {
                    notificationSettings: element(By.linkText(menuTitlesAndIds.collaborationSettings.childMenuLabels.notificationSettings)),
                    userAlerts: element(By.linkText(menuTitlesAndIds.collaborationSettings.childMenuLabels.userAlerts)),
                    workSettings: element(By.linkText(menuTitlesAndIds.collaborationSettings.childMenuLabels.workSettings))
                }
            },
            configurationSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.configurationSettings.rootId)),
                childMenus: {
                    listSynchronization: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenuLabels.listSynchronization)),
                    manageApps: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenuLabels.manageApps)),
                    manageCommunities: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenuLabels.manageCommunities)),
                    portfolioFields: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenuLabels.portfolioFields)),
                    portfolioLookups: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenuLabels.portfolioLookups)),
                    portfolioPermissions: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenuLabels.portfolioPermissions)),
                    setupWizard: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenuLabels.setupWizard)),
                    siteLibrariesAndLists: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenuLabels.siteLibrariesAndLists)),
                    workspaceTemplates: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenuLabels.workspaceTemplates))
                }
            },
            costManagement: {
                rootMenu: element(By.id(menuTitlesAndIds.costManagement.rootId)),
                childMenus: {
                    calendarsPeriods: element(By.linkText(menuTitlesAndIds.costManagement.childMenuLabels.calendarsPeriods)),
                    costCategories: element(By.linkText(menuTitlesAndIds.costManagement.childMenuLabels.costCategories)),
                    costModels: element(By.linkText(menuTitlesAndIds.costManagement.childMenuLabels.costModels)),
                    costTypeFields: element(By.linkText(menuTitlesAndIds.costManagement.childMenuLabels.costTypeFields)),
                    costTypes: element(By.linkText(menuTitlesAndIds.costManagement.childMenuLabels.costTypes)),
                    costViews: element(By.linkText(menuTitlesAndIds.costManagement.childMenuLabels.costViews)),
                    portfolioCostViews: element(By.linkText(menuTitlesAndIds.costManagement.childMenuLabels.portfolioCostViews)),
                    rates: element(By.linkText(menuTitlesAndIds.costManagement.childMenuLabels.rates))
                }
            },
            enterpriseReporting: {
                rootMenu: element(By.id(menuTitlesAndIds.enterpriseReporting.rootId)),
                childMenus: {
                    ReportingSettings: element(By.linkText(menuTitlesAndIds.enterpriseReporting.childMenuLabels.ReportingSettings)),
                    classicReports: element(By.linkText(menuTitlesAndIds.enterpriseReporting.childMenuLabels.classicReports)),
                    reportingSettings: element(By.linkText(menuTitlesAndIds.enterpriseReporting.childMenuLabels.reportingSettings))
                }
            },
            lookAndFeel: {
                rootMenu: element(By.id(menuTitlesAndIds.lookAndFeel.rootId)),
                childMenus: {
                    regionalSettings: element(By.linkText(menuTitlesAndIds.lookAndFeel.childMenuLabels.regionalSettings)),
                    titleAndLogo: element(By.linkText(menuTitlesAndIds.lookAndFeel.childMenuLabels.titleAndLogo))
                }
            },
            plannerSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.plannerSettings.rootId)),
                childMenus: {
                    plannerTemplates: element(By.linkText(menuTitlesAndIds.plannerSettings.childMenuLabels.plannerTemplates)),
                    planners: element(By.linkText(menuTitlesAndIds.plannerSettings.childMenuLabels.planners))
                }
            },
            resourceManagement: {
                rootMenu: element(By.id(menuTitlesAndIds.resourceManagement.rootId)),
                childMenus: {
                    calendarsPeriods: element(By.linkText(menuTitlesAndIds.resourceManagement.childMenuLabels.calendarsPeriods)),
                    fieldMapping: element(By.linkText(menuTitlesAndIds.resourceManagement.childMenuLabels.fieldMapping)),
                    fields: element(By.linkText(menuTitlesAndIds.resourceManagement.childMenuLabels.fields)),
                    plannerAdmin: element(By.linkText(menuTitlesAndIds.resourceManagement.childMenuLabels.plannerAdmin))
                }
            },
            systemSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.systemSettings.rootId)),
                childMenus: {
                    generalSettings: element(By.linkText(menuTitlesAndIds.systemSettings.childMenuLabels.generalSettings)),
                    timerSettings: element(By.linkText(menuTitlesAndIds.systemSettings.childMenuLabels.timerSettings)),
                    workspaceSettings: element(By.linkText(menuTitlesAndIds.systemSettings.childMenuLabels.workspaceSettings))
                }
            },
            timeSheetSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.timeSheetSettings.rootId)),
                childMenus: {
                    timeSheetSettings: element(By.linkText(menuTitlesAndIds.timeSheetSettings.childMenuLabels.timeSheetSettings)),
                }
            },
            userManagement: {
                rootMenu: element(By.id(menuTitlesAndIds.userManagement.rootId)),
                childMenus: {
                    departments: element(By.linkText(menuTitlesAndIds.userManagement.childMenuLabels.departments)),
                    holidaySchedules: element(By.linkText(menuTitlesAndIds.userManagement.childMenuLabels.holidaySchedules)),
                    nonWork: element(By.linkText(menuTitlesAndIds.userManagement.childMenuLabels.nonWork)),
                    resourcePool: element(By.linkText(menuTitlesAndIds.userManagement.childMenuLabels.resourcePool)),
                    roles: element(By.linkText(menuTitlesAndIds.userManagement.childMenuLabels.roles)),
                    workHours: element(By.linkText(menuTitlesAndIds.userManagement.childMenuLabels.workHours))
                }
            },
            utilities: {
                rootMenu: element(By.id(menuTitlesAndIds.utilities.rootId)),
                childMenus: {
                    portfolioDBAdmin: element(By.linkText(menuTitlesAndIds.utilities.childMenuLabels.portfolioDBAdmin)),
                    portfolioQueue: element(By.linkText(menuTitlesAndIds.utilities.childMenuLabels.portfolioQueue)),
                    recycleBin: element(By.linkText(menuTitlesAndIds.utilities.childMenuLabels.recycleBin)),
                    timeSheetCosts: element(By.linkText(menuTitlesAndIds.utilities.childMenuLabels.timeSheetCosts)),
                    workQueue: element(By.linkText(menuTitlesAndIds.utilities.childMenuLabels.workQueue))
                }
            }
        };
    }
}
