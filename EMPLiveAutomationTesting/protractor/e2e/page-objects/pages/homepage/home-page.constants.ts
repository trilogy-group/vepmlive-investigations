export class HomePageConstants {
    static readonly pageName = 'Home page';
    static readonly navigation = 'Navigation';
    static readonly homePage = 'Home';
    static readonly documentPage = 'Project Documents - My Documents';
    static readonly comment = 'This is a test comment';

    static get navigationLabels() {
        return {
            projects: {
                requests: 'Requests',
                portfolios: 'Portfolios',
                durations: 'Duration',
                projectPortfolios: 'Project Portfolios',
                projects: 'Projects',
                projectCenter: 'Project Center',
                tasks: 'Tasks',
                taskCenter: 'Task Center',
                selectPlanner: 'Select Planner',
                risks: 'Risks',
                workHours: 'Work Hours',
                projectNodeCollapsed: 'Project Node Collapsed',
                issues: 'Issues',
                changes: 'Changes',
                documents: 'Documents',
                resources: 'Resources',
                reports: 'Reports',
                reporting: 'Reporting',
                projectPlanner: 'Project Planner',
                projectDetails: 'Project Name',
                optimizer: 'Optimizer',
                optimizerConfiguration: 'Optimizer Configuration'
            }
        };
    }

    static get addADocumentWindow() {
        return{
            addADocumentTitle: 'Add a document',
            chooseFiles: 'Choose Files',
            overwriteExistingFilesLabel: 'Overwrite existing files',
            addADocumentPropertyTitle: 'Add A Document Property Title',
        };
    }
}
