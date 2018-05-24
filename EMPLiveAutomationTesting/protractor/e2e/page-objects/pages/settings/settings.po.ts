import {SettingsPageConstants} from './settings-page.constants';
import {By, element} from 'protractor';

export class SettingsPage {
    static get generalSettings() {
        const generalSettings = SettingsPageConstants.generalSettings;
        return {
            listName: element(By.linkText(generalSettings.listName)),
            versionSettings: element(By.linkText(generalSettings.versionSettings)),
            advancedSettings: element(By.linkText(generalSettings.advancedSettings)),
            validationSettings: element(By.linkText(generalSettings.validationSettings)),
            audienceTargetingSettings: element(By.linkText(generalSettings.audienceTargetingSettings)),
            manageEditableFields: element(By.linkText(generalSettings.manageEditableFields)),
            portfolioEngineSettings: element(By.linkText(generalSettings.portfolioEngineSettings)),
            totalFieldSettings: element(By.linkText(generalSettings.totalFieldSettings)),
            generalSettings: element(By.linkText(generalSettings.generalSettings)),
            lookupSettings: element(By.linkText(generalSettings.lookupSettings)),
            integration: element(By.linkText(generalSettings.integration)),
            createDashboard: element(By.linkText(generalSettings.createDashboard)),
        };
    }
}