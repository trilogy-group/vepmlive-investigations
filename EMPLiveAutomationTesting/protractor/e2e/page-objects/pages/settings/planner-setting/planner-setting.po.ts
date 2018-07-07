import {By, element} from 'protractor';

export class PlannerSettingPage {

    static get planNameField() {
        return element(By.css('[id*="PlannerName"]'));
    }

    static get collapsedMode() {
        return element(By.css('[id*="planner-settings"] .epm-nav-node-collapsed'));
    }

    static get planDiscriptionField() {
        return element(By.css('[id*="txtDescription"]'));
    }

    static get startSoonCheckBox() {
        return element(By.css('[id*="StartSoon"]'));
    }

    static get sourceListDropDown() {
        return element(By.css('[id*="ProjectCenter"]'));
    }

    static get saveButton() {
        return element(By.css('[value*="Save Settings"]'));
    }
}
