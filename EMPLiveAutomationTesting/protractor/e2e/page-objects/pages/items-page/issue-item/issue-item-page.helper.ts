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
import {ChangeItemPage} from '../change-item/change-item.po';

export class IssueItemPageHelper {

    static async clickCreateNewIssue() {
        StepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);
    }

    static async newIconFromLeftSideMenu() {
        StepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

    }

    static async clickIssueLink() {
        StepLogger.step('Click on "Issue" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.issue);
    }

    static async clickProject(projectName: string, labels: string) {
        await PageHelper.click(IssueItemPage.inputs.project);
        StepLogger.verification('Required values entered/selected in Project Field');
        await expect(await PageHelper.isElementDisplayed(ChangeItemPage.getSelectedProject(projectName))).toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels, projectName));
        StepLogger.stepId(4);
    }

    static async enterIssueTitle(titleValue: string) {
        StepLogger.step('Title *: Random New Issue Item');
        await TextboxHelper.sendKeys(IssueItemPage.inputs.title, titleValue);

    }

    static async createIssueAndValidateIt() {
        StepLogger.stepId(1);
        await this.clickCreateNewIssue();

        StepLogger.step('Various Create New options are displayed');
        await CommonPageHelper.labelDisplayedValidation
        (CreateNewPage.navigation.listApps.issue, CreateNewPageConstants.navigationLabels.listApps.issue);

        StepLogger.stepId(2);
        await this.newIconFromLeftSideMenu();

        StepLogger.step('Various Create New options are displayed');
        await CommonPageHelper.labelDisplayedValidation
        (CreateNewPage.navigation.listApps.issue, CreateNewPageConstants.navigationLabels.listApps.issue);

        StepLogger.stepId(3);
        await this.clickIssueLink();

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "Issues - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = IssueItemPageConstants.inputLabels;

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        StepLogger.step('Title *: Random New Issue Item');
        const titleValue = `${labels.title} ${uniqueId}`;
        await this.enterIssueTitle(titleValue);

        StepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(IssueItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        StepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        await PageHelper.click(CommonPage.projectShowAllButton);

        await WaitHelper.waitForElementToBeDisplayed(IssueItemPage.inputs.project);
        const projectName = await IssueItemPage.inputs.project.getText();

        await this.clickProject(projectName, labels.project);

        StepLogger.stepId(4);
        StepLogger.step('Click on "Save" button in "Issues - New Item" window');
        await PageHelper.clickAndWaitForElementToHide(CommonPage.formButtons.save);

        await PageHelper.switchToDefaultContent();

        StepLogger.verification('Notification about New Issues created [Ex: New Issue Item 1] displayed on the Home Page');
        await CommonPageHelper.notificationDisplayedValidation
        (CommonPageHelper.getNotificationByText(titleValue), IssueItemPageConstants.pageName);

        StepLogger.stepId(5);
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,

            titleValue,
            IssueItemPageConstants.columnNames.title);

        StepLogger.verification('Newly created Issue [Ex: New Issue Item 1] displayed in "Issues" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(titleValue), titleValue);
        return titleValue;
    }

    static async editItemAndValidateIt(titleValue: string) {
        titleValue = titleValue + 'Edited';

        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
        );

        await CommonPageHelper.editOptionViaRibbon();

        await TextboxHelper.sendKeys(IssueItemPage.inputs.title, titleValue);

        await PageHelper.click(CommonPage.formButtons.save);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,

            titleValue,
            IssueItemPageConstants.columnNames.title);
        return titleValue;
    }

    static async deleteItemAndValidateIt(titleValue: string) {
        await RiskItemPageHelper.deleteOptionViaRibbon();

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,

            titleValue,
            IssueItemPageConstants.columnNames.title);

        StepLogger.step('Validating deleted Risk  is not  Present');
        await CommonPageHelper.fieldDisplayedValidation(ProjectItemPage.noProjecrMsg, ProjectItemPageConstants.noDataFound);
    }

    static async validateContentOfItemTab() {
        StepLogger.step('Validate Edit Cost Is Present');
        await CommonPageHelper.fieldDisplayedValidation(CommonPage.ribbonItems.editCost, CommonPageConstants.ribbonLabels.editCost);

        StepLogger.step('Validate viewItem Is Present');
        await CommonPageHelper.fieldDisplayedValidation(CommonPage.ribbonItems.viewItem, CommonPageConstants.ribbonLabels.viewItem);

        StepLogger.step('Validate editItem Is Present');
        await CommonPageHelper.fieldDisplayedValidation(CommonPage.ribbonItems.editItem, CommonPageConstants.ribbonLabels.editItem);

        StepLogger.step('Validate editResource Is Present');
        await CommonPageHelper.fieldDisplayedValidation(CommonPage.ribbonItems.editResource, CommonPageConstants.ribbonLabels.editResource);
    }

    static async validateContentOfItemTabIsDisabled() {
        StepLogger.step('Validate Edit Cost Is Disabled ');
        await CommonPageHelper.verifyItemDisabled(CommonPage.ribbonItems.editCost);

        StepLogger.step('Validate viewItem Is Disabled ');
        await CommonPageHelper.verifyItemDisabled(CommonPage.ribbonItems.viewItem);

        StepLogger.step('Validate editItem Is Disabled ');
        await CommonPageHelper.verifyItemDisabled(CommonPage.ribbonItems.editItem);

        StepLogger.step('Validate editResource Is Disabled ');
        await CommonPageHelper.verifyItemDisabled(CommonPage.ribbonItems.editResource);
    }
}
