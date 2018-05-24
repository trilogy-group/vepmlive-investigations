import {SettingsPageConstants} from './settings-page.constants';
import {By, element} from 'protractor';

export class SettingsPage {
    static get pagination() {
        return {
            next: element(By.linkText(SettingsPageConstants.pagination.next)),
            previous: element(By.linkText(SettingsPageConstants.pagination.next))
        };
    }

    static get permissionsAndManagement() {
        const labels = SettingsPageConstants.permissionsAndManagement;
        return {
            deleteThisList: element(By.linkText(labels.deleteThisList)),
            saveListAsTemplate: element(By.linkText(labels.saveListAsTemplate)),
            permissionsForThisList: element(By.linkText(labels.permissionsForThisList)),
            workflowSettings: element(By.linkText(labels.workflowSettings)),
            viewPermissionSettings: element(By.linkText(labels.viewPermissionSettings))
        };
    }

    static get communications() {
        const communications = SettingsPageConstants.communications;
        return {
            rssSettings: element(By.linkText(communications.rssSettings))
        };
    }

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
