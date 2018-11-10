import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {CreateNewPage} from '../../../../../page-objects/pages/items-page/create-new.po';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/items-page/create-new-page.constants';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {ChangeItemPageConstants} from '../../../../../page-objects/pages/items-page/change-item/change-item-page.constants';
import {ChangeItemPageHelper} from '../../../../../page-objects/pages/items-page/change-item/change-item-page.helper';
import {IssueItemPageConstants} from '../../../../../page-objects/pages/items-page/issue-item/issue-item-page.constants';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';

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

    it('Add Changes Functionality - [1124277]', async () => {
        StepLogger.caseId = 1124277;

        StepLogger.stepId(1);

        StepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

        StepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.change))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.change));

        StepLogger.stepId(2);
        StepLogger.step('Click on "Change" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.change);

        StepLogger.verification('"Changes - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(ChangeItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(ChangeItemPageConstants.pageName));

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
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ChangeItemPageConstants.pageName));

        await PageHelper.switchToDefaultContent();

        StepLogger.verification('Notification about New Changes created [Ex: New Change Item 1]' +
            ' displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(ChangeItemPageConstants.pageName));

        StepLogger.stepId(5);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
        );

        await CommonPageHelper.searchItemByTitle(titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu,
        );

        StepLogger.verification('Newly created Change [Ex: New Change Item 1] displayed in "Changes" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    it('Edit Changes Functionality - [1124278]', async () => {
        StepLogger.caseId = 1124275;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
        );

        // Step #3
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.record, CommonPage.contextMenuOptions.editItem);

        StepLogger.verification('"Edit Change" page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ChangeItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "Changes - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ChangeItemPageConstants.inputLabels;
        const titleValue = `${labels.title} ${uniqueId}`;
        const priority = CommonPageConstants.priorities.low;
        const projectName = await ChangeItemPageHelper.fillForm(titleValue, priority);

        StepLogger.verification('"Change" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.changes))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.changes));

        StepLogger.verification('"Edit Issue" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(IssueItemPageConstants.editPageName));

        StepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(titleValue, ChangeItemPageConstants.columnNames.linkTitleNoMenu);

        StepLogger.verification('Show columns whatever is required');
        await CommonPageHelper.showColumns([
            ChangeItemPageConstants.columnNames.linkTitleNoMenu,
            ChangeItemPageConstants.columnNames.category,
            ChangeItemPageConstants.columnNames.priority]);

        StepLogger.verification('Click on searched record');
        await PageHelper.click(CommonPage.record);

        StepLogger.verification('Verify record by title');
        const firstTableColumns = [titleValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        StepLogger.verification('Verify by other properties');
        const secondTableColumns = [projectName];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    });
});
