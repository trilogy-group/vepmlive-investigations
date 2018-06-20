export class PlannerSettingsPageConstants {
    static readonly plannerPage = 'Planner Settings';
    static readonly administration = 'Planner Administration';

    static get leftMenus() {
        return {
            planners: 'Planners',
        };
    }

    static get labels() {
        return {
            projectRequest: 'Project Requests',
        };
    }

    static get validation() {
        return {
            project: 'Project',
            settings: 'Settings',
            planName: 'Plan Name',
            sourceList: 'Source List',
            editPlanner: 'Edit Planner',
            deletePlanner: 'Delete Planner',
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
                editPlanner: 'Edit Planner',
                deletePlanner: 'Delete Planner',
                taskList: 'Task List',
                newPlanner: 'idHomePageNewItem',
                backToSetting: 'Back To Settings',
            },
        };
    }

    static get newPlannerDetails() {
        return {
            name: 'Smoke Test Planner ',
            updatedName: 'Updated Smoke Test Planner ',
            description: 'New Planner created as part of smoke test ',
            updatedDescription: 'Updated New Planner created as part of smoke test ',
        };
    }
}
