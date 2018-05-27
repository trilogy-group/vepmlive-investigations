import {By, element} from 'protractor';
import {SettingsPageConstants} from './settings-page.constants';

export class SettingsPage {
    static get menuItems() {
        const menuTitlesAndIds = SettingsPageConstants.menuTitlesAndIds;
        return {
            collaborationSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.collaborationSettings.rootId)),
                childMenus: {
                    notificationSettings: element(By.linkText(menuTitlesAndIds.collaborationSettings.childMenu.notificationSettings)),
                    userAlerts: element(By.linkText(menuTitlesAndIds.collaborationSettings.childMenu.userAlerts)),
                    workSettings: element(By.linkText(menuTitlesAndIds.collaborationSettings.childMenu.workSettings))
                }
            },
            configurationSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.configurationSettings.rootId)),
                childMenus: {
                    listSynchronization: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenu.listSynchronization)),
                    manageApps: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenu.manageApps)),
                    manageCommunities: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenu.manageCommunities)),
                    portfolioFields: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenu.portfolioFields)),
                    portfolioLookups: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenu.portfolioLookups)),
                    portfolioPermissions: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenu.portfolioPermissions)),
                    setupWizard: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenu.setupWizard)),
                    siteLibrariesAndLists: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenu.siteLibrariesAndLists)),
                    workspaceTemplates: element(By.linkText(menuTitlesAndIds.configurationSettings.childMenu.workspaceTemplates))
                }
            },
            costManagement: {
                rootMenu: element(By.id(menuTitlesAndIds.costManagement.rootId)),
                childMenus: {
                    calendarsPeriods: element(By.linkText(menuTitlesAndIds.costManagement.childMenu.calendarsPeriods)),
                    costCategories: element(By.linkText(menuTitlesAndIds.costManagement.childMenu.costCategories)),
                    costModels: element(By.linkText(menuTitlesAndIds.costManagement.childMenu.costModels)),
                    costTypeFields: element(By.linkText(menuTitlesAndIds.costManagement.childMenu.costTypeFields)),
                    costTypes: element(By.linkText(menuTitlesAndIds.costManagement.childMenu.costTypes)),
                    costViews: element(By.linkText(menuTitlesAndIds.costManagement.childMenu.costViews)),
                    portfolioCostViews: element(By.linkText(menuTitlesAndIds.costManagement.childMenu.portfolioCostViews)),
                    rates: element(By.linkText(menuTitlesAndIds.costManagement.childMenu.rates))
                }
            },
            enterpriseReporting: {
                rootMenu: element(By.id(menuTitlesAndIds.enterpriseReporting.rootId)),
                childMenus: {
                    advancedReports: element(By.linkText(menuTitlesAndIds.enterpriseReporting.childMenu.advancedReports)),
                    classicReports: element(By.linkText(menuTitlesAndIds.enterpriseReporting.childMenu.classicReports)),
                    reportingSettings: element(By.linkText(menuTitlesAndIds.enterpriseReporting.childMenu.reportingSettings))
                }
            },
            lookAndFeel: {
                rootMenu: element(By.id(menuTitlesAndIds.lookAndFeel.rootId)),
                childMenus: {
                    regionalSettings: element(By.linkText(menuTitlesAndIds.lookAndFeel.childMenu.regionalSettings)),
                    titleAndLogo: element(By.linkText(menuTitlesAndIds.lookAndFeel.childMenu.titleAndLogo))
                }
            },
            plannerSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.plannerSettings.rootId)),
                childMenus: {
                    plannerTemplates: element(By.linkText(menuTitlesAndIds.plannerSettings.childMenu.plannerTemplates)),
                    planners: element(By.linkText(menuTitlesAndIds.plannerSettings.childMenu.planners))
                }
            },
            resourceManagement: {
                rootMenu: element(By.id(menuTitlesAndIds.resourceManagement.rootId)),
                childMenus: {
                    calendarsPeriods: element(By.linkText(menuTitlesAndIds.resourceManagement.childMenu.calendarsPeriods)),
                    fieldMapping: element(By.linkText(menuTitlesAndIds.resourceManagement.childMenu.fieldMapping)),
                    fields: element(By.linkText(menuTitlesAndIds.resourceManagement.childMenu.fields)),
                    plannerAdmin: element(By.linkText(menuTitlesAndIds.resourceManagement.childMenu.plannerAdmin))
                }
            },
            systemSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.systemSettings.rootId)),
                childMenus: {
                    generalSettings: element(By.linkText(menuTitlesAndIds.systemSettings.childMenu.generalSettings)),
                    timerSettings: element(By.linkText(menuTitlesAndIds.systemSettings.childMenu.timerSettings)),
                    workspaceSettings: element(By.linkText(menuTitlesAndIds.systemSettings.childMenu.workspaceSettings))
                }
            },
            timeSheetSettings: {
                rootMenu: element(By.id(menuTitlesAndIds.timeSheetSettings.rootId)),
                childMenus: {
                    timeSheetSettings: element(By.linkText(menuTitlesAndIds.timeSheetSettings.childMenu.timeSheetSettings)),
                }
            },
            userManagement: {
                rootMenu: element(By.id(menuTitlesAndIds.userManagement.rootId)),
                childMenus: {
                    departments: element(By.linkText(menuTitlesAndIds.userManagement.childMenu.departments)),
                    holidaySchedules: element(By.linkText(menuTitlesAndIds.userManagement.childMenu.holidaySchedules)),
                    nonWork: element(By.linkText(menuTitlesAndIds.userManagement.childMenu.nonWork)),
                    resourcePool: element(By.linkText(menuTitlesAndIds.userManagement.childMenu.resourcePool)),
                    roles: element(By.linkText(menuTitlesAndIds.userManagement.childMenu.roles)),
                    workHours: element(By.linkText(menuTitlesAndIds.userManagement.childMenu.workHours))
                }
            },
            utilities: {
                rootMenu: element(By.id(menuTitlesAndIds.utilities.rootId)),
                childMenus: {
                    portfolioDBAdmin: element(By.linkText(menuTitlesAndIds.utilities.childMenu.portfolioDBAdmin)),
                    portfolioQueue: element(By.linkText(menuTitlesAndIds.utilities.childMenu.portfolioQueue)),
                    recycleBin: element(By.linkText(menuTitlesAndIds.utilities.childMenu.recycleBin)),
                    timeSheetCosts: element(By.linkText(menuTitlesAndIds.utilities.childMenu.timeSheetCosts)),
                    workQueue: element(By.linkText(menuTitlesAndIds.utilities.childMenu.workQueue))
                }
            }
        };
    }
}
