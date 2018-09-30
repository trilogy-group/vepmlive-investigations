export class ReportingSettingsPageConstants {
    static readonly pageName = 'Mapped Lists';

    static get topMenus() {
        return {
            settings: {
                menuId: 'SettingsMenu',
                childMenuLabels: {
                    refreshSchedule: 'Refresh Schedule',
                    snapshotManagement: 'Snapshot Management'
                }
            },
            actions: {
                menuId: 'ActionsMenu',
                childMenuLabels: {
                    cleanupAll: 'Cleanup All',
                    snapshotAll: 'Snapshot All',
                    addList: 'Add List'
                }
            }
        };
    }
}
