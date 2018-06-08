export class CreateNewPageConstants {
    static readonly pageName = 'Create New';

    static get navigationLabels() {
        return {
            listApps: {
                change: 'Change',
                discussion: 'Discussion',
                event: 'Event',
                issue: 'Issue',
                link: 'Link',
                project: 'Project',
                more: 'More',
                portfolio: 'Portfolio',
                projectRequest: 'Project Request',
                risk: 'Risk',
                timeOff: 'Time Off',
                toDo: 'To Do'
            },
            libraryApps: {
                pictures: 'Pictures',
                projectDocument: 'Project Document',
                sharedDocument: 'SharedDocument',
                sitePages: 'SitePages'
            }
        };
    }

}
