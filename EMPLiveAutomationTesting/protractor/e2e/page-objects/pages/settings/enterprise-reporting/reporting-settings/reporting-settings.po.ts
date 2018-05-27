import {By, element} from 'protractor';
import {ReportingSettingsPageConstants} from './reporting-settings-page.constants';
import {ReportingSettingsPageHelper} from './reporting-settings-page.helper';

export class ReportingSettingsPage {
    static get topMenus() {
        const topMenus = ReportingSettingsPageConstants.topMenus;
        return {
            settings: {
                menu: element(By.id(topMenus.settings.menuId)),
                childMenu: {
                    refreshSchedule: ReportingSettingsPageHelper.getTopMenus(topMenus.settings.childMenuLabels.refreshSchedule),
                    snapshotManagement: ReportingSettingsPageHelper.getTopMenus(topMenus.settings.childMenuLabels.snapshotManagement)
                }
            },
            actions: {
                menu: element(By.id(topMenus.actions.menuId)),
                childMenu: {
                    cleanupAll: ReportingSettingsPageHelper.getTopMenus(topMenus.actions.childMenuLabels.cleanupAll),
                    snapshotAll: ReportingSettingsPageHelper.getTopMenus(topMenus.actions.childMenuLabels.snapshotAll),
                    addList: ReportingSettingsPageHelper.getTopMenus(topMenus.actions.childMenuLabels.addList)
                }
            }
        };
    }
}
