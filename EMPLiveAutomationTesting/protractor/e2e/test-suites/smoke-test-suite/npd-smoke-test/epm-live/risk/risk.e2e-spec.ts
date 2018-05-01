import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {CreateNewPage} from '../../../../../page-objects/pages/items-page/create-new.po';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/items-page/create-new-page.constants';
import {CommonItemPage} from '../../../../../page-objects/pages/items-page/common-item/common-item.po';
import {RiskItemPageConstants} from '../../../../../page-objects/pages/items-page/risk-item/risk-item-page.constants';
import {RiskItemPage} from '../../../../../page-objects/pages/items-page/risk-item/risk-item.po';
import {CommonItemPageHelper} from '../../../../../page-objects/pages/items-page/common-item/common-item-page.helper';
import {RiskItemPageHelper} from '../../../../../page-objects/pages/items-page/risk-item/risk-item-page.helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';

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
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
            stepLogger);

        await CommonPageHelper.searchItemByTitle(titleValue,
            RiskItemPageConstants.columnNames.title,
            stepLogger);

        stepLogger.verification('Newly created Risk [Ex: New Risk Item 1] displayed in "Risks" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextXPathInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    it('Edit Risks Functionality - [1124272]', async () => {
        const stepLogger = new StepLogger(1124272);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
            stepLogger);

        // Common functionality to edit any item
        await CommonPageHelper.editItemViaContextMenu(stepLogger);

        // Common functionality to edit risk
        await RiskItemPageHelper.editRisk(stepLogger);
    });

    it('Edit view in Risk - [1176329]', async () => {
        const stepLogger = new StepLogger(1176329);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
            stepLogger);

        await CommonItemPageHelper.editOptionViaRibbon(stepLogger);

        await RiskItemPageHelper.editRisk(stepLogger);
    });

    it('Search Risk - [1176333]', async () => {
        const stepLogger = new StepLogger(1176333);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
            stepLogger);

        const titleValue = await RiskItemPage.riskItems.first().getText();
        stepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(titleValue,
            RiskItemPageConstants.columnNames.title,
            stepLogger);

        stepLogger.verification('Click on searched record');
        await PageHelper.click(CommonPage.record);

        stepLogger.verification('Verify record by title');
        const firstTableColumns = [titleValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        stepLogger.verification('Verify that there should be only one record');
        await expect(await RiskItemPage.riskItems.count())
            .toBe(1,
                ValidationsHelper.getOnlyOneRecordShouldBeDisplayedInGrid(titleValue));

    });

    it('View Item in Risk - [1176338]', async () => {
        const stepLogger = new StepLogger(1176338);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
            stepLogger);

        const titleValue = await RiskItemPage.riskItems.first().getText();
        await CommonItemPageHelper.viewOptionViaRibbon(stepLogger);

        stepLogger.verification('Verify that item is available in View page mode');
        await expect(await CommonPage.contentTitleInViewMode.getText())
            .toBe(titleValue,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });
});
