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
import {RiskItemPageConstants} from '../risk-item/risk-item-page.constants';
import {RiskItemPageHelper} from '../risk-item/risk-item-page.helper';
import {ProjectItemPageConstants} from '../project-item/project-item-page.constants';
import {ProjectItemPage} from '../project-item/project-item.po';

export class IssueItemPageHelper {

    static  async createIssueAndValidateIt(stepLogger: StepLogger ) {
        stepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);
        stepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.issue))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.issue));
        stepLogger.stepId(2);
        stepLogger.step('Click on "Issue" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.issue);
        stepLogger.verification('"Issues - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(IssueItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(IssueItemPageConstants.pageName));
        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Issues - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = IssueItemPageConstants.inputLabels;
        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        stepLogger.step('Title *: Random New Issue Item');
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(IssueItemPage.inputs.title, titleValue);
        stepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(IssueItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));
        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        await PageHelper.click(CommonPage.projectShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(IssueItemPage.inputs.project);
        const projectName = await IssueItemPage.inputs.project.getText();
        await PageHelper.click(IssueItemPage.inputs.project);
        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.project, projectName));
        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Issues - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);
        stepLogger.verification('"Issues - New Item" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(IssueItemPageConstants.pageName));
        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Issues created [Ex: New Issue Item 1] displayed on the Home Page');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(IssueItemPageConstants.pageName));
        stepLogger.stepId(5);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
            stepLogger);
        await CommonPageHelper.searchItemByTitle(titleValue,
            IssueItemPageConstants.columnNames.title,
            stepLogger);
        stepLogger.verification('Newly created Issue [Ex: New Issue Item 1] displayed in "Issues" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
        return titleValue;
    }
    static async editItemAndValidateIt(stepLogger: StepLogger, titleValue: string ) {
        titleValue = titleValue + 'Edited';
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
            stepLogger);
        await CommonPageHelper.editOptionViaRibbon(stepLogger);
        await TextboxHelper.sendKeys(IssueItemPage.inputs.title, titleValue);
        await PageHelper.click(CommonPage.formButtons.save);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
            stepLogger);
        await CommonPageHelper.searchItemByTitle(titleValue,
            RiskItemPageConstants.columnNames.title,
            stepLogger);
    }
    static async deleteItemAndValidateIt(stepLogger: StepLogger, titleValue: string ) {
        await RiskItemPageHelper.deleteOptionViaRibbon(stepLogger);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
            stepLogger);
        await CommonPageHelper.searchItemByTitle(titleValue,
            RiskItemPageConstants.columnNames.title,
            stepLogger);
        stepLogger.step('Validating deleted Risk  is not  Present');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.noProjecrMsg))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.noDataFound));
    }
}
