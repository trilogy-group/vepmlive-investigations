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
    static async fillForm(titleValue: string, priority: string) {
        const labels = ChangeItemPageConstants.inputLabels;
        StepLogger.step('Title *: Random New Change Item');
        await TextboxHelper.sendKeys(ChangeItemPage.inputs.title, titleValue);

        StepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(ChangeItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        StepLogger.step('Click on projectShowAllButton');
        await PageHelper.click(CommonPage.projectShowAllButton);
        await WaitHelper.waitForElementToBeDisplayed(ChangeItemPage.inputs.project);
        StepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        const projectName = await ChangeItemPage.inputs.project.getText();
        await PageHelper.click(ChangeItemPage.inputs.project);

        StepLogger.verification('Required values entered/selected in Project Field');
        await expect(await PageHelper.isElementDisplayed(ChangeItemPage.getSelectedProject(projectName))).toBe(
            true, ValidationsHelper.getFieldShouldHaveValueValidation(labels.project, projectName));

        StepLogger.step(`Priority: Select the value "${priority}"`);
        await PageHelper.sendKeysToInputField(ChangeItemPage.inputs.priority, priority);
        await WaitHelper.staticWait(PageHelper.timeout.xs);
        StepLogger.verification(`Verify - Priority: Select the value  "${priority}"`);
        /* await expect(await ElementHelper.hasSelectedOption(ChangeItemPage.inputs.priority, priority))
             .toBe(true,
                 ValidationsHelper.getFieldShouldHaveValueValidation(labels.priority, priority));*/

        StepLogger.stepId(5);
        StepLogger.step('Click on "Save" button in "Changes - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);

        return projectName;
    }

    static async createNewChange() {
        await PageHelper.click(CommonPage.sidebarMenus.createNew);
        StepLogger.step('Various Create New options are displayed');

        await CommonPageHelper.labelDisplayedValidation
        (CreateNewPage.navigation.listApps.change, CreateNewPageConstants.navigationLabels.listApps.change);
    }

    static async createChangeLink() {
        StepLogger.step('Click on "Change" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.change);
    }

    static async createNewChangeAndValidateIt() {
        StepLogger.step('Select "Create New" icon  from left side menu');
        await this.createNewChange();

        StepLogger.stepId(2);
        StepLogger.step('Click on "Change" link from the options displayed');
        await this.createChangeLink();

        StepLogger.stepId(3);
        StepLogger.step('Enter/Select required details in "Changes - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ChangeItemPageConstants.inputLabels;
        const titleValue = `${labels.title} ${uniqueId}`;
        const priority = CommonPageConstants.priorities.high;

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        await ChangeItemPageHelper.fillForm(titleValue, priority);

        StepLogger.verification('"Changes - New Item" window is closed');
        //  await CommonPageHelper.windowShouldNotBeDisplayedValidation(ChangeItemPageConstants.pageName);

        StepLogger.verification('Notification about New Changes created [Ex: New Change Item 1]' +
            ' displayed on the Home Page');
        await CommonPageHelper.notificationDisplayedValidation
        (CommonPageHelper.getNotificationByText(titleValue), ChangeItemPageConstants.pageName);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,

            titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu);
        return titleValue;
    }

    static async editChangeAndValidateIt(titleValue: string) {
        await CommonPageHelper.editOptionViaRibbon();
        titleValue = titleValue + 'Edited';

        await TextboxHelper.sendKeys(ChangeItemPage.inputs.title, titleValue);

        await PageHelper.click(CommonPage.formButtons.save);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,

            titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu);
        StepLogger.verification('Newly created Change [Ex: New Change Item 1] displayed in "Changes" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(titleValue), titleValue);
        return titleValue;
    }

    static async deleteChangeAndValidateIt(titleValue: string) {
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,

            titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu);

        await RiskItemPageHelper.deleteOptionViaRibbon();

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,

            titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu);

        StepLogger.step('Validating deleted Risk  is not  Present');
        await CommonPageHelper.fieldDisplayedValidation(ProjectItemPage.noProjecrMsg, ProjectItemPageConstants.noDataFound);
    }
}
