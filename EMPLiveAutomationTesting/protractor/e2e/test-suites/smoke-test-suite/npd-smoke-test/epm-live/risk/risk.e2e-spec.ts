// tslint:disable-next-line:max-line-length
import {RiskItemPageConstants} from '../../../../../page-objects/pages/create-new-page/new-item/risk-item/risk-item-page.constants';
// tslint:disable-next-line:max-line-length
import {CommonItemPageHelper} from '../../../../../page-objects/pages/create-new-page/new-item/common-item/common-item-page.helper';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CreateNewPage} from '../../../../../page-objects/pages/create-new-page/create-new.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/create-new-page/create-new-page.constants';
import {CommonItemPage} from '../../../../../page-objects/pages/create-new-page/new-item/common-item/common-item.po';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {RiskItemPage} from '../../../../../page-objects/pages/create-new-page/new-item/risk-item/risk-item.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonViewPage} from '../../../../../page-objects/pages/homepage/common-view-page/common-view.po';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {CommonViewPageHelper} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.helper';
import {CommonViewPageConstants} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.constants';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {Constants} from '../../../../../components/misc-utils/constants';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('Add Risks Functionality - [1124271]', async () => {
        const stepLogger = new StepLogger(1124271);

        stepLogger.stepId(1);

        stepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

        stepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.risk))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.risk));

        stepLogger.stepId(2);
        stepLogger.step('Click on "Risk" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.risk);

        stepLogger.verification('"Risks - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.dialogTitles.first());

        await expect(await CommonItemPage.dialogTitles.first().getText())
            .toBe(RiskItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(RiskItemPageConstants.pageName));

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Risks - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = RiskItemPageConstants.inputLabels;

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        stepLogger.step('Title *: Random New Risk Item');
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(RiskItemPage.inputs.title, titleValue);

        stepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(RiskItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');

        await PageHelper.click(RiskItemPage.projectShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(RiskItemPage.inputs.project);
        const projectName = await RiskItemPage.inputs.project.getText();
        await PageHelper.click(RiskItemPage.inputs.project);

        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.project, projectName));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Risks - New Item" window');
        await PageHelper.click(CommonItemPage.formButtons.save);

        stepLogger.verification('"Risks - New Item" window is closed');
        await expect(await CommonItemPage.dialogTitles.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(RiskItemPageConstants.pageName));

        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Risks created [Ex: New Risk Item 1] displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonItemPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(RiskItemPageConstants.pageName));

        stepLogger.stepId(5);
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.risks,
            CommonViewPage.pageHeaders.projects.risks,
            CommonViewPageConstants.pageHeaders.projects.risks,
            stepLogger);

        await CommonViewPageHelper.searchItemByTitle(titleValue, RiskItemPageConstants.columnNames.title, stepLogger);

        stepLogger.verification('Newly created Risk [Ex: New Risk Item 1] displayed in "Risks" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByExactTextXPath(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    fit('Edit Risks Functionality - [1124272]', async () => {
        const stepLogger = new StepLogger(1124272);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.risks,
            CommonViewPage.pageHeaders.projects.risks,
            CommonViewPageConstants.pageHeaders.projects.risks,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Mouse over the Risk created as per pre requisites that need to be edited');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonViewPage.record);
        await ElementHelper.actionHoverOver(CommonViewPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonViewPage.ellipse);

        stepLogger.step('Select "Edit Item" from the options displayed');
        await PageHelper.click(CommonViewPage.contextMenuOptions.editItem);

        stepLogger.verification('"Edit Risk" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.titles.first());
        await expect(await CommonItemPage.titles.first().getText())
            .not.toBe(Constants.EMPTY_STRING,
                ValidationsHelper.getPageDisplayedValidation(RiskItemPageConstants.editPageName));

        stepLogger.verification('Values selected/entered while creating the Risk are pre populated in respective fields');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.titles.first());
        await expect(await TextboxHelper.hasValue(RiskItemPage.inputs.title, Constants.EMPTY_STRING))
            .toBe(false,
                ValidationsHelper.getFieldShouldNotHaveValueValidation(RiskItemPageConstants.inputLabels.title,
                    Constants.EMPTY_STRING));

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
    });

});
