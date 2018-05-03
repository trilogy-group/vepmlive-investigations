export class ReportsItemPageConstants {
    static readonly pagePrefix = 'Reporting';
    static readonly reportsHeader = 'Reports';

    static get reportsLandingPage() {
        return {
            businessIntelligenceCenter: 'Business Intelligence Center',
            epmLiveAnalytics: 'advanced',
            classicReporting: 'classic'
        };
    }

    static get classicReportingPage() {
        return {
            plusSign : 'plus.gif',
            projectsTitleForExpandSign : 'Projects',
            projectHealth : 'Project Health',
            closeButton : 'ms-dlgCloseBtn'
        };
    }
}
