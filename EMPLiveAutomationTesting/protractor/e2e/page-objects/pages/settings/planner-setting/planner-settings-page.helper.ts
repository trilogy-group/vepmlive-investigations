import {By, element} from 'protractor';
import {PageHelper} from '../../../../components/html/page-helper';
import {PlannerSettingsPageConstants} from './planner-settings-page.constants';
import {ElementHelper} from '../../../../components/html/element-helper';

export class PlannerSettingsPageHelper {
    static async expandPlannerSettingsNode() {
        if (await this.collapsedMode.isPresent()) {
            await PageHelper.click(this.collapsedMode);
        }
    }

    static get menu() {
        const menuTitles = PlannerSettingsPageConstants.menuTitles;
        return {
            menuTitles: {
                planName: ElementHelper.getElementByText(menuTitles.plannerAdministration.planName),
                souceList: ElementHelper.getElementByText(menuTitles.plannerAdministration.sourceList),
                taskList: ElementHelper.getElementByText(menuTitles.plannerAdministration.taskList),
                editPLanner: element(By.id(menuTitles.plannerAdministration.editPLanner)),
                backToSetting: ElementHelper.getElementByText(menuTitles.plannerAdministration.backToSetting),

            },
            buttonLabel: {
                planner: ElementHelper.getElementByText(PlannerSettingsPageConstants.leftMenus.planners),

            }
        };
    }

    static get planNameField() {
        return element(By.css('[id*="PlannerName"]'));
    }

    static get collapsedMode() {
        return element(By.css('[id*="planner-settings"] [class*="collapsed"]'));
    }

    static get planDiscriptionField() {
        return element(By.css('[id*="txtDescription"]'));
    }

    static get startSoonCheckBox() {
        return element(By.css('[id*="StartSoon"]'));
    }

    static get saveButton() {
        return element(By.css('[value*="Save Settings"]'));
    }
}
