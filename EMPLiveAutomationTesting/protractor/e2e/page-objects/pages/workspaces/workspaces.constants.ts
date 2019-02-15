export class WorkspacesConstants {
    static readonly newWorkspace = 'New Workspace';
    static readonly windowTitle = 'Create Workspace';
    static readonly notification = 'Your workspace is being created';
    static readonly projectTemplate = 'Project';
    static readonly workspaceListing = 'Workspace Listing';
    static readonly editTeam = 'Edit Team';

    static get inputLabels() {
        return {
            title: 'Title *',
            description: 'Description *',
        };
    }

    static get workspacesMenuOptions() {
        return {
            newWorkspace: 'New Workspace',
            favoriteWorkspaces: 'Favorite Workspaces',
            allWorkspaces: 'All Workspaces',
        };
    }

    static get contextMenu() {
        return {
            editTeam: 'Edit team',
            remove: 'Remove',
        };
    }
}
