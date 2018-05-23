export class SettingsPageConstants {
    static get generalSettings() {
        const epmLive = `(EPM Live)`;
        return {
            listName: `List name, description and navigation`,
            versionSettings: `Versioning settings`,
            advancedSettings: `Advanced settings`,
            validationSettings: `Validation settings`,
            audienceTargetingSettings: `Audience targeting settings`,
            manageEditableFields: `Manage Editable Fields ${epmLive}`,
            portfolioEngineSettings: `PortfolioEngine Settings ${epmLive}`,
            totalFieldSettings: `Total Field Settings ${epmLive}`,
            generalSettings: `General Settings ${epmLive}`,
            lookupSettings: `Lookup Settings ${epmLive}`,
            integration: `Integration ${epmLive}`,
            createDashboard: `Create Dashboard ${epmLive}`,
        };
    }
}
