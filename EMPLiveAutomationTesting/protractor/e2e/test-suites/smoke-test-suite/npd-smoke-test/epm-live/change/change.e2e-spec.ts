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

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('Add Changes Functionality - [1124277]', async () => {
        const stepLogger = new StepLogger(1124277);

        stepLogger.stepId(1);

        stepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

        stepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.change))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.change));

        stepLogger.stepId(2);
        stepLogger.step('Click on "Change" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.change);

        stepLogger.verification('"Changes - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());
        await expect(await CommonPage.dialogTitles.first().getText())
            .toBe(ChangeItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(ChangeItemPageConstants.pageName));

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
        await expect(await CommonPage.dialogTitles.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ChangeItemPageConstants.pageName));

        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Changes created [Ex: New Change Item 1]' +
                ' displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(ChangeItemPageConstants.pageName));

        stepLogger.stepId(5);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
            stepLogger);

        await CommonPageHelper.searchItemByTitle(titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu,
            stepLogger);

        stepLogger.verification('Newly created Change [Ex: New Change Item 1] displayed in "Changes" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextXPathInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    it('Edit Changes Functionality - [1124278]', async () => {
        const stepLogger = new StepLogger(1124275);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
            stepLogger);

        // Step #3
        await CommonPageHelper.editItemViaContextMenu(stepLogger);

        stepLogger.verification('"Edit Change" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ChangeItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Changes - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ChangeItemPageConstants.inputLabels;
        const titleValue = `${labels.title} ${uniqueId}`;
        const priority = CommonPageConstants.priorities.low;
        const projectName = await ChangeItemPageHelper.fillForm(titleValue, priority, stepLogger);

        stepLogger.verification('"Change" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.changes))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.changes));

        stepLogger.verification('"Edit Issue" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(IssueItemPageConstants.editPageName));

        stepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(titleValue, ChangeItemPageConstants.columnNames.linkTitleNoMenu, stepLogger);

        stepLogger.verification('Show columns whatever is required');
        await CommonPageHelper.showColumns([
            ChangeItemPageConstants.columnNames.linkTitleNoMenu,
            ChangeItemPageConstants.columnNames.project,
            ChangeItemPageConstants.columnNames.priority]);

        stepLogger.verification('Click on searched record');
        await PageHelper.click(CommonPage.record);

        stepLogger.verification('Verify record by title');
        const firstTableColumns = [titleValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        stepLogger.verification('Verify by other properties');
        const secondTableColumns = [priority, projectName];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    });
});
