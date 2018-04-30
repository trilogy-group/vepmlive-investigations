import {ProjectItemPageConstants} from '../project-item/project-item-page.constants';
import {CommonViewPageHelper} from '../../homepage/common-view-page/common-view-page.helper';
import {RiskItemPageConstants} from './risk-item-page.constants';
import {CommonViewPage} from '../../homepage/common-view-page/common-view.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {CommonItemPage} from '../common-item/common-item.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {CommonViewPageConstants} from '../../homepage/common-view-page/common-view-page.constants';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {RiskItemPage} from './risk-item.po';

export class RiskItemPageHelper {

    static async editRisk(stepLogger: StepLogger) {
        stepLogger.verification('"Edit Risk" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.title);
        await expect(await CommonItemPage.title.getText())
            .toBe(RiskItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.verification('Values selected/entered while creating the Risk are pre populated in respective fields');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.title);
        await expect(await CommonItemPage.title.getText())
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
        const status = RiskItemPageConstants.statuses.notStarted;
        await PageHelper.sendKeysToInputField(RiskItemPage.inputs.status, status);

        const priority = RiskItemPageConstants.priorities.low;
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
        await expect(await ElementHelper.hasOption(RiskItemPage.inputs.priority, priority))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.priority, priority));

        stepLogger.stepId(5);
        stepLogger.step('Click "Save" button in "Edit Risk" page');
        await PageHelper.click(CommonItemPage.formButtons.save);

        stepLogger.verification('"Risks" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonViewPage.pageHeaders.projects.risks))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonViewPageConstants.pageHeaders.projects.risks));

        stepLogger.verification('"Edit Risk" page is closed');
        await expect(await CommonItemPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(RiskItemPageConstants.editPageName));

        stepLogger.verification('Updated Risk details (Title, Status, Priority) displayed in "Risks" page');

        stepLogger.verification('Search item by title');
        await CommonViewPageHelper.searchItemByTitle(titleValue, RiskItemPageConstants.columnNames.title, stepLogger);

        stepLogger.verification('Show columns whatever is required');
        await CommonViewPageHelper.showColumns([
            RiskItemPageConstants.columnNames.title,
            RiskItemPageConstants.columnNames.status,
            RiskItemPageConstants.columnNames.priority]);

        stepLogger.verification('Click on searched record');
        await PageHelper.click(CommonViewPage.record);

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
