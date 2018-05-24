export class SettingsPageConstants {
    static readonly epmLive = `(EPM Live)`;
    static get generalSettings() {
        return {
            listName: `List name, description and navigation`,
            versionSettings: `Versioning settings`,
            advancedSettings: `Advanced settings`,
            validationSettings: `Validation settings`,
            audienceTargetingSettings: `Audience targeting settings`,
            manageEditableFields: `Manage Editable Fields ${this.epmLive}`,
            portfolioEngineSettings: `PortfolioEngine Settings ${this.epmLive}`,
            totalFieldSettings: `Total Field Settings ${this.epmLive}`,
            generalSettings: `General Settings ${this.epmLive}`,
            lookupSettings: `Lookup Settings ${this.epmLive}`,
            integration: `Integration ${this.epmLive}`,
            createDashboard: `Create Dashboard ${this.epmLive}`
        };
    }

    static get permissionsAndManagement() {
        return {
            deleteThisList: 'Delete this list',
            saveListAsTemplate: 'Save list as template',
            permissionsForThisList: 'Permissions for this list',
            workflowSettings: 'Workflow Settings',
            viewPermissionSettings: `View Permission Settings ${this.epmLive}`
        };
    }

    static get communications() {
        return {
            rssSettings: 'RSS settings'
        };
    }
}
