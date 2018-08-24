import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../common/common-page.helper';
import {IssueItemPage} from './issue-item.po';
import {CreateNewPageConstants} from '../create-new-page.constants';
import {CommonPageConstants} from '../../common/common-page.constants';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {IssueItemPageConstants} from './issue-item-page.constants';
import {HomePage} from '../../homepage/home.po';
import {CommonPage} from '../../common/common.po';
import {CreateNewPage} from '../create-new.po';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {RiskItemPageHelper} from '../risk-item/risk-item-page.helper';
import {ProjectItemPageConstants} from '../project-item/project-item-page.constants';
import {ProjectItemPage} from '../project-item/project-item.po';

export class IssueItemPageHelper {

    static async clickCreateNewIssue(stepLogger: StepLogger) {
        stepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);
    }

    static async newIconFromLeftSideMenu(stepLogger: StepLogger) {
        stepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

    }

    static async clickIssueLink(stepLogger: StepLogger) {
        stepLogger.step('Click on "Issue" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.issue);
    }

    static async clickProject(stepLogger: StepLogger, projectName: string, labels: string) {
        await PageHelper.click(IssueItemPage.inputs.project);
        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels, projectName));
        stepLogger.stepId(4);

    }

    static async enterIssueTitle(stepLogger: StepLogger, titleValue: string) {
        stepLogger.step('Title *: Random New Issue Item');
        await TextboxHelper.sendKeys(IssueItemPage.inputs.title, titleValue);

    }

    static async createIssueAndValidateIt(stepLogger: StepLogger) {
        stepLogger.stepId(1);
        await this.clickCreateNewIssue(stepLogger);

        stepLogger.step('Various Create New options are displayed');
        await CommonPageHelper.labelDisplayedValidation
        (CreateNewPage.navigation.listApps.issue, CreateNewPageConstants.navigationLabels.listApps.issue);

        stepLogger.stepId(2);
        await this.newIconFromLeftSideMenu(stepLogger);

        stepLogger.step('Various Create New options are displayed');
        await CommonPageHelper.labelDisplayedValidation
        (CreateNewPage.navigation.listApps.issue, CreateNewPageConstants.navigationLabels.listApps.issue);

        stepLogger.stepId(3);
        await this.clickIssueLink(stepLogger);

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Issues - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = IssueItemPageConstants.inputLabels;

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.step('Title *: Random New Issue Item');
        const titleValue = `${labels.title} ${uniqueId}`;
        await this.enterIssueTitle(stepLogger, titleValue);

        stepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(IssueItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        await PageHelper.click(CommonPage.projectShowAllButton);

        await WaitHelper.waitForElementToBeDisplayed(IssueItemPage.inputs.project);
        const projectName = await IssueItemPage.inputs.project.getText();

        await this.clickProject(stepLogger, projectName, labels.project);

        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Issues - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);

        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Issues created [Ex: New Issue Item 1] displayed on the Home Page');
        await CommonPageHelper.notificationDisplayedValidation
        (CommonPageHelper.getNotificationByText(titleValue), IssueItemPageConstants.pageName);

        stepLogger.stepId(5);
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
            stepLogger,
            titleValue,
            IssueItemPageConstants.columnNames.title);

        stepLogger.verification('Newly created Issue [Ex: New Issue Item 1] displayed in "Issues" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(titleValue), titleValue);
        return titleValue;
    }

    static async editItemAndValidateIt(stepLogger: StepLogger, titleValue: string) {
        titleValue = titleValue + 'Edited';

        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
            stepLogger);

        await CommonPageHelper.editOptionViaRibbon(stepLogger);

        await TextboxHelper.sendKeys(IssueItemPage.inputs.title, titleValue);

        await PageHelper.click(CommonPage.formButtons.save);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
            stepLogger,
            titleValue,
            IssueItemPageConstants.columnNames.title);
        return titleValue;
    }

    static async deleteItemAndValidateIt(stepLogger: StepLogger, titleValue: string) {
        await RiskItemPageHelper.deleteOptionViaRibbon(stepLogger);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
            stepLogger,
            titleValue,
            IssueItemPageConstants.columnNames.title);

        stepLogger.step('Validating deleted Risk  is not  Present');
        await CommonPageHelper.fieldDisplayedValidation(ProjectItemPage.noProjecrMsg, ProjectItemPageConstants.noDataFound);
    }

    static  async validateContentOfItemTab(stepLogger: StepLogger) {
        stepLogger.step('Validate Edit Cost Is Present');
        await CommonPageHelper.fieldDisplayedValidation(CommonPage.ribbonItems.editCost, CommonPageConstants.ribbonLabels.editCost);

        stepLogger.step('Validate viewItem Is Present');
        await CommonPageHelper.fieldDisplayedValidation(CommonPage.ribbonItems.viewItem, CommonPageConstants.ribbonLabels.viewItem);

        stepLogger.step('Validate editItem Is Present');
        await CommonPageHelper.fieldDisplayedValidation(CommonPage.ribbonItems.editItem, CommonPageConstants.ribbonLabels.editItem);

        stepLogger.step('Validate editResource Is Present');
        await CommonPageHelper.fieldDisplayedValidation(CommonPage.ribbonItems.editResource, CommonPageConstants.ribbonLabels.editResource);
    }
    static  async validateContentOfItemTabIsDisabled(stepLogger: StepLogger) {
        stepLogger.step('Validate Edit Cost Is Disabled ');
        await CommonPageHelper.verifyItemDisabled(CommonPage.ribbonItems.editCost, stepLogger);

        stepLogger.step('Validate viewItem Is Disabled ');
        await CommonPageHelper.verifyItemDisabled(CommonPage.ribbonItems.viewItem, stepLogger);

        stepLogger.step('Validate editItem Is Disabled ');
        await CommonPageHelper.verifyItemDisabled(CommonPage.ribbonItems.editItem, stepLogger);

        stepLogger.step('Validate editResource Is Disabled ');
        await CommonPageHelper.verifyItemDisabled(CommonPage.ribbonItems.editResource, stepLogger);
    }
}
