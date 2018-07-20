import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {ChangeItemPage} from './change-item.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {ChangeItemPageConstants} from './change-item-page.constants';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {CommonPage} from '../../common/common.po';
import {HomePage} from '../../homepage/home.po';
import {CreateNewPageConstants} from '../create-new-page.constants';
import {CreateNewPage} from '../create-new.po';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {RiskItemPageHelper} from '../risk-item/risk-item-page.helper';
import {ProjectItemPageConstants} from '../project-item/project-item-page.constants';
import {ProjectItemPage} from '../project-item/project-item.po';

export class ChangeItemPageHelper {
    static async fillForm(titleValue: string, priority: string, stepLogger: StepLogger) {
        const labels = ChangeItemPageConstants.inputLabels;
        stepLogger.step('Title *: Random New Change Item');
        await TextboxHelper.sendKeys(ChangeItemPage.inputs.title, titleValue);

        stepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(ChangeItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        stepLogger.step('Click on projectShowAllButton');
        await PageHelper.click(CommonPage.projectShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ChangeItemPage.inputs.project);
        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        const projectName = await ChangeItemPage.inputs.project.getText();
        await PageHelper.click(ChangeItemPage.inputs.project);

        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.project, projectName));

        stepLogger.step(`Priority: Select the value "${priority}"`);
        await PageHelper.sendKeysToInputField(ChangeItemPage.inputs.priority, priority);
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.xs);
        stepLogger.verification(`Verify - Priority: Select the value  "${priority}"`);
       /* await expect(await ElementHelper.hasSelectedOption(ChangeItemPage.inputs.priority, priority))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.priority, priority));*/

        stepLogger.stepId(5);
        stepLogger.step('Click on "Save" button in "Changes - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);

        return projectName;
    }

    static async createNewChange(stepLogger: StepLogger) {
        await PageHelper.click(CommonPage.sidebarMenus.createNew);
        stepLogger.step('Various Create New options are displayed');

        await CommonPageHelper.labelDisplayedValidation
        (CreateNewPage.navigation.listApps.change , CreateNewPageConstants.navigationLabels.listApps.change );
    }
    static async createChangeLink(stepLogger: StepLogger) {
        stepLogger.step('Click on "Change" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.change);
       }
    static async createNewChangeAndValidateIt(stepLogger: StepLogger) {
        stepLogger.step('Select "Create New" icon  from left side menu');
        await this.createNewChange(stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Click on "Change" link from the options displayed');
        await this.createChangeLink(stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Changes - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ChangeItemPageConstants.inputLabels;
        const titleValue = `${labels.title} ${uniqueId}`;
        const priority = CommonPageConstants.priorities.high;

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        await ChangeItemPageHelper.fillForm(titleValue, priority, stepLogger);

        stepLogger.verification('"Changes - New Item" window is closed');
        await CommonPageHelper.windowShouldNotBeDisplayedValidation(ChangeItemPageConstants.pageName);

        stepLogger
            .verification('Notification about New Changes created [Ex: New Change Item 1]' +
                ' displayed on the Home Page');
        await CommonPageHelper.notificationDisplayedValidation
        (CommonPageHelper.getNotificationByText(titleValue) , ChangeItemPageConstants.pageName );

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
            stepLogger,
            titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu);
        return titleValue;
    }
    static async editChangeAndValidateIt(stepLogger: StepLogger, titleValue: string) {
        await CommonPageHelper.editOptionViaRibbon(stepLogger);
        titleValue = titleValue + 'Edited';

        await TextboxHelper.sendKeys(ChangeItemPage.inputs.title, titleValue);

        await PageHelper.click(CommonPage.formButtons.save);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
            stepLogger,
            titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu);
        stepLogger.verification('Newly created Change [Ex: New Change Item 1] displayed in "Changes" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(titleValue) , titleValue );
        return titleValue;
      }
    static async deleteChangeAndValidateIt(stepLogger: StepLogger, titleValue: string) {
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
            stepLogger,
            titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu);

        await RiskItemPageHelper.deleteOptionViaRibbon(stepLogger);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
            stepLogger,
            titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu);

        stepLogger.step('Validating deleted Risk  is not  Present');
        await CommonPageHelper.fieldDisplayedValidation(ProjectItemPage.noProjecrMsg , ProjectItemPageConstants.noDataFound );
    }
}
