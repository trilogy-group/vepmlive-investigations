export class PlannerSettingsPageConstants {
    static readonly plannerPage = 'Planner Settings';
    static readonly administration = 'Planner Administration';

    static get leftMenus() {
        return {
            planners: 'Planners'
        };
    }

    static get validation() {
        return {
            project: 'Project',
            settings: 'Settings',
            planName: 'Plan Name',
            sourceList: 'Source List',
            checkBox: 'CheckBox',
            taskList: 'Task List',
            addANewPlanner: '+ Add New Planner',
            backToSetting: 'Back To Setting',
        };
    }

    static get menuTitles() {
        return {
            plannerAdministration: {
                planName: 'Plan Name',
                sourceList: 'Source List',
                taskList: 'Task List',
                editPLanner: 'idHomePageNewItem',
                backToSetting: 'Back To Settings',
            },
        };
    }

    static get newPlannerDetails() {
        return {
            name: 'Smoke Test Planner 1',
            discription: 'New Planner created as part of smoke test',
        };
    }

    static get buttonLabbles() {
        return {
           //
        };
    }
}
