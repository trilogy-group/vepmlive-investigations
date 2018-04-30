import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonViewPage} from '../../../../../page-objects/pages/homepage/common-view-page/common-view.po';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {CommonViewPageHelper} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.helper';
import {CommonViewPageConstants} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.constants';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CreateNewPage} from '../../../../../page-objects/pages/items-page/create-new.po';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/items-page/create-new-page.constants';
import {CommonItemPage} from '../../../../../page-objects/pages/items-page/common-item/common-item.po';
import {IssueItemPageConstants} from '../../../../../page-objects/pages/items-page/issue-item/issue-item-page.constants';
import {IssueItemPage} from '../../../../../page-objects/pages/items-page/issue-item/issue-item.po';
import {CommonItemPageHelper} from '../../../../../page-objects/pages/items-page/common-item/common-item-page.helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('Add Issues Functionality - [1124274]', async () => {
        const stepLogger = new StepLogger(1124274);

        stepLogger.stepId(1);

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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.dialogTitles.first());

        await expect(await CommonItemPage.dialogTitles.first().getText())
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

        await PageHelper.click(IssueItemPage.projectShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(IssueItemPage.inputs.project);
        const projectName = await IssueItemPage.inputs.project.getText();
        await PageHelper.click(IssueItemPage.inputs.project);

        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.project, projectName));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Issues - New Item" window');
        await PageHelper.click(CommonItemPage.formButtons.save);

        stepLogger.verification('"Issues - New Item" window is closed');
        await expect(await CommonItemPage.dialogTitles.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(IssueItemPageConstants.pageName));

        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Issues created [Ex: New Issue Item 1] displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonItemPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(IssueItemPageConstants.pageName));

        stepLogger.stepId(5);
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.issues,
            CommonViewPage.pageHeaders.projects.issues,
            CommonViewPageConstants.pageHeaders.projects.issues,
            stepLogger);

        await CommonViewPageHelper.searchItemByTitle(titleValue,
            IssueItemPageConstants.columnNames.title,
            stepLogger,
            true);

        stepLogger.verification('Newly created Issue [Ex: New Issue Item 1] displayed in "Issues" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextXPathInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    it('Edit Issues Functionality - [1124275]', async () => {
        const stepLogger = new StepLogger(1124275);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.issues,
            CommonViewPage.pageHeaders.projects.issues,
            CommonViewPageConstants.pageHeaders.projects.issues,
            stepLogger);

        await CommonPageHelper.editItemViaContextMenu(stepLogger);

        stepLogger.verification('"Edit Issue" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.titles.first());
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.title);
        await expect(await CommonItemPage.title.getText())
            .toBe(IssueItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.verification('Values selected/entered while creating the Issue are pre populated in respective fields');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.title);
        await expect(await CommonItemPage.title.getText())
            .toBe(IssueItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Edit Issue" page as described below');

        const labels = IssueItemPageConstants.inputLabels;
        stepLogger.step('Title *: Random New Issue Item');
        const uniqueId = PageHelper.getUniqueId();
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(IssueItemPage.inputs.title, titleValue);

        stepLogger.step('Status: Select the value "In Progress"');
        const status = IssueItemPageConstants.statuses.inProgress;
        await PageHelper.sendKeysToInputField(IssueItemPage.inputs.status, status);

        const priority = IssueItemPageConstants.priorities.high;
        stepLogger.step('Priority: Select the value "(1) High"');
        await PageHelper.sendKeysToInputField(IssueItemPage.inputs.priority, priority);

        stepLogger.verification('Required values Entered/Selected in "Edit Issue" Page');
        stepLogger.verification('Verify - Title *: Random New Issue Item');
        await expect(await TextboxHelper.hasValue(IssueItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        stepLogger.verification('Verify - Status: Select the value "In Progress"');
        await expect(await ElementHelper.hasSelectedOption(IssueItemPage.inputs.status, status))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.status, status));

        stepLogger.verification('Verify - Priority: Select the value "(1) High"');
        await expect(await ElementHelper.hasOption(IssueItemPage.inputs.priority, priority))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.priority, priority));

        stepLogger.stepId(5);
        stepLogger.step('Click "Save" button in "Edit Issue" page');
        await PageHelper.click(CommonItemPage.formButtons.save);

        stepLogger.verification('"Issues" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonViewPage.pageHeaders.projects.issues))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonViewPageConstants.pageHeaders.projects.issues));

        stepLogger.verification('"Edit Issue" page is closed');
        await expect(await CommonItemPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(IssueItemPageConstants.editPageName));

        stepLogger.verification('Updated Issue details (Title, Status, Priority) displayed in "Issues" page');
        stepLogger.verification('Show columns whatever is required');
        await CommonViewPageHelper.showColumns([
            IssueItemPageConstants.columnNames.title,
            IssueItemPageConstants.columnNames.status,
            IssueItemPageConstants.columnNames.priority]);

        stepLogger.verification('Search item by title');
        await CommonViewPageHelper.searchItemByTitle(titleValue, IssueItemPageConstants.columnNames.title, stepLogger);

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
    });

});
