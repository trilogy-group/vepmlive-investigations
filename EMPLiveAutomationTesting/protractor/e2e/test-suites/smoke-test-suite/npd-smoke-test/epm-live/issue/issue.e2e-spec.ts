import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {CreateNewPage} from '../../../../../page-objects/pages/items-page/create-new.po';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/items-page/create-new-page.constants';
import {IssueItemPageConstants} from '../../../../../page-objects/pages/items-page/issue-item/issue-item-page.constants';
import {IssueItemPage} from '../../../../../page-objects/pages/items-page/issue-item/issue-item.po';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import { ExpectationHelper } from '../../../../../components/misc-utils/expectation-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    fit('Add Issues Functionality - [1124274]', async () => {
        StepLogger.caseId = 1124274;

        StepLogger.stepId(1);

        StepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

        StepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.issue))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.issue));

        StepLogger.stepId(2);
        StepLogger.step('Click on "Issue" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.issue);

        StepLogger.verification('"Issues - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(IssueItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(IssueItemPageConstants.pageName));

        StepLogger.stepId(3);
        StepLogger.step('Enter/Select required details in "Issues - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = IssueItemPageConstants.inputLabels;

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        StepLogger.step('Title *: Random New Issue Item');
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(IssueItemPage.inputs.title, titleValue);

        StepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(IssueItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        StepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');

        await PageHelper.click(CommonPage.projectShowAllButton);
        await WaitHelper.waitForElementToBeDisplayed(IssueItemPage.inputs.project);
        const projectName = await IssueItemPage.inputs.project.getText();
        await PageHelper.click(IssueItemPage.inputs.project);

        StepLogger.verification('Required values entered/selected in Project Field');
        await ExpectationHelper.verifyPresentStatus(CommonPageHelper.getAutoCompleteItemByDescription(projectName), projectName);
        /* await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.project, projectName)); */

        StepLogger.stepId(4);
        StepLogger.step('Click on "Save" button in "Issues - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"Issues - New Item" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(IssueItemPageConstants.pageName));

        await PageHelper.switchToDefaultContent();

        StepLogger.verification('Notification about New Issues created [Ex: New Issue Item 1] displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(IssueItemPageConstants.pageName));

        StepLogger.stepId(5);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
        );

        await CommonPageHelper.searchItemByTitle(titleValue,
            IssueItemPageConstants.columnNames.title,
        );

        StepLogger.verification('Newly created Issue [Ex: New Issue Item 1] displayed in "Issues" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    it('Edit Issues Functionality - [1124275]', async () => {
        StepLogger.caseId = 1124275;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.issues,
            CommonPage.pageHeaders.projects.issues,
            CommonPageConstants.pageHeaders.projects.issues,
        );

        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.record, CommonPage.contextMenuOptions.editItem);

        StepLogger.verification('"Edit Issue" page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(IssueItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        StepLogger.verification('Values selected/entered while creating the Issue are pre populated in respective fields');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(IssueItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "Edit Issue" page as described below');

        const labels = IssueItemPageConstants.inputLabels;
        StepLogger.step('Title *: Random New Issue Item');
        const uniqueId = PageHelper.getUniqueId();
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(IssueItemPage.inputs.title, titleValue);

        StepLogger.step('Status: Select the value "In Progress"');
        const status = CommonPageConstants.statuses.inProgress;
        await PageHelper.sendKeysToInputField(IssueItemPage.inputs.status, status);

        const priority = CommonPageConstants.priorities.high;
        StepLogger.step('Priority: Select the value "(1) High"');
        await PageHelper.sendKeysToInputField(IssueItemPage.inputs.priority, priority);

        StepLogger.verification('Required values Entered/Selected in "Edit Issue" Page');
        StepLogger.verification('Verify - Title *: Random New Issue Item');
        await expect(await TextboxHelper.hasValue(IssueItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        StepLogger.verification('Verify - Status: Select the value "In Progress"');
        await expect(await ElementHelper.hasSelectedOption(IssueItemPage.inputs.status, status))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.status, status));

        StepLogger.verification('Verify - Priority: Select the value "(1) High"');
        await expect(await ElementHelper.hasSelectedOption(IssueItemPage.inputs.priority, priority))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.priority, priority));

        StepLogger.stepId(5);
        StepLogger.step('Click "Save" button in "Edit Issue" page');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"Issues" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.issues))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.issues));

        StepLogger.verification('"Edit Issue" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(IssueItemPageConstants.editPageName));

        StepLogger.verification('Updated Issue details (Title, Status, Priority) displayed in "Issues" page');
        StepLogger.verification('Show columns whatever is required');
        await CommonPageHelper.showColumns([
            IssueItemPageConstants.columnNames.title,
            IssueItemPageConstants.columnNames.scheduleStatus,
            IssueItemPageConstants.columnNames.priority]);

        StepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(titleValue, IssueItemPageConstants.columnNames.title);

        StepLogger.verification('Click on searched record');
        await PageHelper.click(CommonPage.record);

        StepLogger.verification('Verify record by title');
        const firstTableColumns = [titleValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        StepLogger.verification('Verify by other properties');
        const secondTableColumns = [priority];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    });

});
