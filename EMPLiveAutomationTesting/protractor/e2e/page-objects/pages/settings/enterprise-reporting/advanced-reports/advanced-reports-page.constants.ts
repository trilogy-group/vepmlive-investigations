export class AdvancedReportsPageConstants {
    static get topMenus() {
        return {
            settings: {
                menuId: 'SettingsMenu',
                childLabels: {
                    refreshSchedule: 'Refresh Schedule',
                    snapshotManagement: 'Snapshot Management'
                }
            },
            actions: {
                menuId: 'ActionsMenu',
                childLabels: {
                    cleanupAll: 'Cleanup All',
                    snapshotAll: 'Snapshot All',
                    addList: 'Add List'
                }
            }
        };
    }
}