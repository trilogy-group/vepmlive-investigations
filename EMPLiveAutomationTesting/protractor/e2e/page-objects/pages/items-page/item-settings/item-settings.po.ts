import {By, element} from 'protractor';
import {ItemSettingsPageConstants} from './item-settings-page.constants';

export class ItemSettingsPage {
    static get pagination() {
        return {
            next: element(By.linkText(ItemSettingsPageConstants.pagination.next)),
            previous: element(By.linkText(ItemSettingsPageConstants.pagination.next))
        };
    }

    static get permissionsAndManagement() {
        const labels = ItemSettingsPageConstants.permissionsAndManagement;
        return {
            deleteThisList: element(By.linkText(labels.deleteThisList)),
            saveListAsTemplate: element(By.linkText(labels.saveListAsTemplate)),
            permissionsForThisList: element(By.linkText(labels.permissionsForThisList)),
            workflowSettings: element(By.linkText(labels.workflowSettings)),
            viewPermissionSettings: element(By.linkText(labels.viewPermissionSettings))
        };
    }

    static get communications() {
        const communications = ItemSettingsPageConstants.communications;
        return {
            rssSettings: element(By.linkText(communications.rssSettings))
        };
    }

    static get generalSettings() {
        const generalSettings = ItemSettingsPageConstants.generalSettings;
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
