export class ReportsItemPageConstants {
    static readonly pagePrefix = 'Reporting';
    static readonly businessIntelligenceCenter = 'Business Intelligence Center';

    static get landingPageMenu() {
        return {
            epmLiveAnalytics: 'advanced',
            classicReporting: 'classic'
        };
    }

    static get reportListItems() {
        return {
            projects: {
                projects: 'Projects',
                projectHealth: 'Project Health'
            }
        };
    }
}
