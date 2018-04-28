import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ProjectItemPage} from './project-item.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {ProjectItemPageConstants} from './project-item-page.constants';
import {CommonItemPage} from '../common-item/common-item.po';
import {ElementHelper} from '../../../../../components/html/element-helper';

export class ProjectItemPageHelper {
    static async fillForm(projectNameValue: string,
                          projectDescription: string,
                          benefits: string,
                          overallHealthOnTrack: string,
                          projectUpdateManual: string,
                          stepLogger: StepLogger) {
        const labels = ProjectItemPageConstants.inputLabels;
        const inputs = ProjectItemPage.inputs;

        // Add project name
        stepLogger.step('Title *: Random New Issue Item');
        await TextboxHelper.sendKeys(inputs.projectName, projectNameValue);

        stepLogger.verification('Required values entered/selected in name Field');
        await expect(await TextboxHelper.hasValue(inputs.projectName, projectNameValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectName, projectNameValue));

        // Add portfolio name
        /*stepLogger.step('Select any Portfolio from the drop down [Ex: Test Portfolio1]');
            await PageHelper.click(ProjectItemPage.portfolioShowAllButton);
            await WaitHelper.getInstance().waitForElementToBeDisplayed(inputs.portfolio);
            const portfolioName = await inputs.portfolio.getText();
            await PageHelper.click(inputs.portfolio);

            stepLogger.verification('Required values selected in Portfolio Field');
            await expect(await CommonPageHelper.getAutoCompleteItemByDescription(portfolioName).isPresent())
                .toBe(true,
                    ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolio, portfolioName));
            */

        // Add Project Description
        stepLogger.step('Enter some text [Ex: Description for Smoke Test Project 1]');
        await TextboxHelper.sendKeys(inputs.projectDescription, projectDescription);

        stepLogger.verification('Required values entered in Description Field');
        await expect(await TextboxHelper.hasValue(inputs.projectDescription, projectDescription))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectDescription, projectDescription));

        // Add Benefits
        stepLogger.step('Benefits: Test Smoke');
        await TextboxHelper.sendKeys(inputs.benefits, benefits);

        stepLogger.verification('Required values entered in "Benefits" Field');
        await expect(await TextboxHelper.hasValue(inputs.benefits, benefits))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.benefits, benefits));

        // Add State
        stepLogger.step('State: Select the value \'(2) Active\'');
        await PageHelper.sendKeysToInputField(inputs.state, ProjectItemPageConstants.states.active);

        stepLogger.verification('Required values selected in "State" Field');
        await expect(await TextboxHelper.hasValue(inputs.benefits, benefits))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.benefits, benefits));

        // Add Overall Health
        stepLogger.step('Overall Health: Select the value "(1) On Track"');
        await PageHelper.sendKeysToInputField(inputs.overallHealth, overallHealthOnTrack);

        stepLogger.verification('Verify - Overall Health: Select the value "(1) On Track"');
        await expect(await ElementHelper.hasSelectedOption(inputs.overallHealth, overallHealthOnTrack))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.overallHealth, overallHealthOnTrack));

        // Add Project Update
        stepLogger.step('Project Update: Select the value "Manual"');
        await PageHelper.sendKeysToInputField(inputs.projectUpdate, projectUpdateManual);

        stepLogger.verification('Verify - Project Update : Select the value "Manual"');
        await expect(await ElementHelper.hasSelectedOption(inputs.projectUpdate, projectUpdateManual))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectUpdate, projectUpdateManual));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Project - New Item" window');
        await PageHelper.click(CommonItemPage.formButtons.save);

        stepLogger.verification('"Project - New Item" window is closed');
        await expect(await CommonItemPage.dialogTitles.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.pageName));
    }

}
