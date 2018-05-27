import {By, element} from 'protractor';
import {AdvancedReportsPageConstants} from './advanced-reports-page.constants';
import {AdvancedReportsPageHelper} from './advanced-reports-page.helper';

export class AdvancedReportsPage {
    static get topMenus() {
        const topMenus = AdvancedReportsPageConstants.topMenus;
        return {
            settings: {
                menu: element(By.id(topMenus.settings.menu)),
                childMenu: {
                    refreshSchedule: AdvancedReportsPageHelper.getTopMenus(topMenus.settings.childMenu.refreshSchedule),
                    snapshotManagement: AdvancedReportsPageHelper.getTopMenus(topMenus.settings.childMenu.snapshotManagement)
                }
            },
            actions: {
                menu: element(By.id(topMenus.actions.menu)),
                childMenu: {
                    cleanupAll: AdvancedReportsPageHelper.getTopMenus(topMenus.actions.childMenu.cleanupAll),
                    snapshotAll: AdvancedReportsPageHelper.getTopMenus(topMenus.actions.childMenu.snapshotAll),
                    addList: AdvancedReportsPageHelper.getTopMenus(topMenus.actions.childMenu.addList)
                }
            }
        };
    }
}
