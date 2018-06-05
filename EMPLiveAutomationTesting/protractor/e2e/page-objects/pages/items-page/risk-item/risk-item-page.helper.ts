import {ProjectItemPageConstants} from '../project-item/project-item-page.constants';
import {RiskItemPageConstants} from './risk-item-page.constants';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {RiskItemPage} from './risk-item.po';
import {CommonPage} from '../../common/common.po';
import {CommonPageConstants} from '../../common/common-page.constants';

export class RiskItemPageHelper {

    static async editRisk(stepLogger: StepLogger) {
        stepLogger.verification('"Edit Risk" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(RiskItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.verification('Values selected/entered while creating the Risk are pre populated in respective fields');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(RiskItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Edit Risk" page as described below');

        const labels = RiskItemPageConstants.inputLabels;
        stepLogger.step('Title *: Random New Risk Item');
        const uniqueId = PageHelper.getUniqueId();
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(RiskItemPage.inputs.title, titleValue);

        stepLogger.step('Status: Select the value "In Progress"');
        const status = CommonPageConstants.statuses.notStarted;
        await PageHelper.sendKeysToInputField(RiskItemPage.inputs.status, status);

        const priority = CommonPageConstants.priorities.low;
        stepLogger.step('Priority: Select the value "(1) High"');
        await PageHelper.sendKeysToInputField(RiskItemPage.inputs.priority, priority);

        stepLogger.verification('Required values Entered/Selected in "Edit Risk" Page');
        stepLogger.verification('Verify - Title *: Random New Risk Item');
        await expect(await TextboxHelper.hasValue(RiskItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        stepLogger.verification('Verify - Status: Select the value "In Progress"');
        await expect(await ElementHelper.hasSelectedOption(RiskItemPage.inputs.status, status))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.status, status));

        stepLogger.verification('Verify - Priority: Select the value "(1) High"');
        await expect(await ElementHelper.hasSelectedOption(RiskItemPage.inputs.priority, priority))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.priority, priority));

        stepLogger.stepId(5);
        stepLogger.step('Click "Save" button in "Edit Risk" page');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"Risks" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.risks))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.risks));

        stepLogger.verification('"Edit Risk" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(RiskItemPageConstants.editPageName));

        stepLogger.verification('Updated Risk details (Title, Status, Priority) displayed in "Risks" page');

        stepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(titleValue, RiskItemPageConstants.columnNames.title, stepLogger);

        stepLogger.verification('Show columns whatever is required');
        await CommonPageHelper.showColumns([
            RiskItemPageConstants.columnNames.title,
            RiskItemPageConstants.columnNames.status,
            RiskItemPageConstants.columnNames.priority]);

        stepLogger.verification('Click on searched record');
        await PageHelper.click(CommonPage.record);

        stepLogger.verification('Verify record by title');
        const firstTableColumns = [titleValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        stepLogger.verification('Verify by other properties');
        const secondTableColumns = [status, priority];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    }
}
