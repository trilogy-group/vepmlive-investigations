export class WorkspacesConstants {
    static readonly newWorkspace = 'New Workspace';
    static readonly windowTitle = 'Create Workspace';
    static readonly notification = 'Your workspace is being created';

    static get inputLabels() {
        return {
            title: 'Title *',
            description: 'Description *',
        };
    }
}
