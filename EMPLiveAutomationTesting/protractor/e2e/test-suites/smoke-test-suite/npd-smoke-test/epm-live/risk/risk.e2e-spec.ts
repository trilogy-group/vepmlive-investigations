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
import {RiskItemPageConstants} from '../../../../../page-objects/pages/items-page/risk-item/risk-item-page.constants';
import {RiskItemPage} from '../../../../../page-objects/pages/items-page/risk-item/risk-item.po';
import {RiskItemPageHelper} from '../../../../../page-objects/pages/items-page/risk-item/risk-item-page.helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {ElementHelper} from '../../../../../components/html/element-helper';
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

    it('Add Risks Functionality - [1124271]', async () => {
        StepLogger.caseId = 1124271;
        StepLogger.stepId(1);
        StepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

        StepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.risk))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.risk));

        StepLogger.stepId(2);
        StepLogger.step('Click on "Risk" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.risk);

        StepLogger.verification('"Risks - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(RiskItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(RiskItemPageConstants.pageName));

        StepLogger.stepId(3);
        StepLogger.step('Enter/Select required details in "Risks - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = RiskItemPageConstants.inputLabels;

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        StepLogger.step('Title *: Random New Risk Item');
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(RiskItemPage.inputs.title, titleValue);

        StepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(RiskItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        StepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');

        await PageHelper.click(CommonPage.projectShowAllButton);
        await WaitHelper.waitForElementToBeDisplayed(RiskItemPage.inputs.project);
        const projectName = await RiskItemPage.inputs.project.getText();
        await PageHelper.click(RiskItemPage.inputs.project);

        StepLogger.verification('Required values entered/selected in Project Field');
        await ExpectationHelper.verifyPresentStatus(CommonPageHelper.getAutoCompleteItemByDescription(projectName), projectName);

        StepLogger.stepId(4);
        StepLogger.step('Click on "Save" button in "Risks - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"Risks - New Item" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(RiskItemPageConstants.pageName));

        StepLogger.verification('Notification about New Risks created [Ex: New Risk Item 1] displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(RiskItemPageConstants.pageName));

        StepLogger.stepId(5);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
        );

        await CommonPageHelper.searchItemByTitle(titleValue,
            RiskItemPageConstants.columnNames.title,
        );

        StepLogger.verification('Newly created Risk [Ex: New Risk Item 1] displayed in "Risks" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    it('Edit Risks Functionality - [1124272]', async () => {
        StepLogger.caseId = 1124272;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
        );

        // Common functionality to edit any item
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.dataRows.get(1), CommonPage.contextMenuOptions.editItem);

        // Common functionality to edit risk
        await RiskItemPageHelper.editRisk();
    });

    /* #UNSTABLE
    it('Edit view in Risk - [1176329]', async () => {
        StepLogger.caseId = 1176329;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
        );

        await CommonPageHelper.editViaItems();

        await RiskItemPageHelper.editRisk();
    });
    */

    it('Search Risk - [1176333]', async () => {
        StepLogger.caseId = 1176333;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
        );

        await WaitHelper.waitForElement(RiskItemPage.riskItem);

        const titleValue = await RiskItemPage.riskItem.getText();
        StepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(titleValue,
            RiskItemPageConstants.columnNames.title,
        );

        StepLogger.verification('title of the Risk displayed in the list in "Risks" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));

        StepLogger.verification('Verify that there should be only one record');
        await expect(await RiskItemPage.riskItems.count())
            .toBe(1,
                ValidationsHelper.getOnlyOneRecordShouldBeDisplayedInGrid(titleValue));

    });

    it('View Item in Risk - [1176338]', async () => {
        StepLogger.caseId = 1176338;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
        );

        await WaitHelper.waitForElementToBeDisplayed(RiskItemPage.riskItem);

        const titleValue = await RiskItemPage.riskItem.getText();
        await CommonPageHelper.viewViaItems();

        StepLogger.verification('Verify that item is available in View page mode');
        await ExpectationHelper.verifyTextContains(CommonPage.contentTitleInViewMode, titleValue, titleValue);
    });

    it('Add attachment in Risk - [1176340]', async () => {
        StepLogger.caseId = 1176340;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
        );

        // Common functionality to edit any item
        await CommonPageHelper.viewViaItems();

        // Common functionality to attach file
        const newFile = await CommonPageHelper.attachFile(RiskItemPage.attachmentButton, CommonPage.fileUploadControl);

        StepLogger.verification('Verify newly uploaded file is displayed under My shared documents section');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFile.newFileName)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.newFileName));
    });

    it('Add new Public view in Risk - [1176327]', async () => {
        StepLogger.caseId = 1176327;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
        );

        StepLogger.stepId(2);
        StepLogger.step('Click on public view drop down');
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewPageActions.defaultDropDownViewByText))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(RiskItemPageConstants.defaultViewName));
        await PageHelper.click(CommonPage.viewPageActions.defaultDropDownViewByText);

        StepLogger.stepId(3);
        StepLogger.step('Click on create public view');
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewPageActions.createNewPublicView))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(CommonPageConstants.viewDropDownLabels.createPublicView));
        await PageHelper.click(CommonPage.viewPageActions.createNewPublicView);

        StepLogger.stepId(4);
        StepLogger.step('Fill view name');
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewNewPageActions.fillCreatePublicViewPageTitle))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(CommonPageConstants.newPublicViewformLabels.title));
        const uniqueId = PageHelper.getUniqueId();
        const titleNewView = `NewAutomatedPublicView${uniqueId}`;
        await TextboxHelper.sendKeys(CommonPage.viewNewPageActions.fillCreatePublicViewPageTitle, titleNewView);

        StepLogger.step('Click "Create a Public View" radio button');
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewNewPageActions.publicViewRadioButton))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(CommonPageConstants.newPublicViewformLabels.publicView));
        await PageHelper.click(CommonPage.viewNewPageActions.publicViewRadioButton);

        StepLogger.step('Deselect non required columns');
        await RiskItemPageHelper.unCheckColumns();

        StepLogger.stepId(5);
        StepLogger.step('Submit new view by clicking ok available at top');
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewNewPageActions.submitCreatePublicViewPage))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(CommonPageConstants.formLabels.topSave));
        await PageHelper.click(CommonPage.viewNewPageActions.submitCreatePublicViewPage);

        StepLogger.stepId(6);
        await RiskItemPageHelper.verifyRiskViewAdd(titleNewView);
    });

    it('Select Columns in Risk - [1176336]', async () => {
        StepLogger.caseId = 1176336;
        StepLogger.stepId(1);
        StepLogger.stepId(2);
        // Step #1 and #2 Inside this function
        StepLogger.step('Select "Navigation" icon  from left side menu and click on Risks');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
        );

        StepLogger.stepId(3);
        StepLogger.step('Click on any column header e.g; title');
        await WaitHelper.waitForElementToBeDisplayed(RiskItemPage.titleHeaderColumn.first());
        await ElementHelper.actionHoverOver(RiskItemPage.titleHeaderColumn.first());
        await ElementHelper.clickUsingJsNoWait(RiskItemPage.titleHeaderColumn.first());

        StepLogger.verification('The up arrow will appear against Title' +
            ' and the data in table appears sort by Title ascending from a-z');
        await expect(await PageHelper.isElementDisplayed(RiskItemPage.columnSortingItems.title.descending))
        .toBe(true, ValidationsHelper.getDisplayedValidation(RiskItemPageConstants.sortingOrder.descending));

        StepLogger.stepId(4);
        StepLogger.step('Click on same column header again');
        await ElementHelper.actionHoverOver(RiskItemPage.titleHeaderColumn.first());
        await ElementHelper.clickUsingJsNoWait(RiskItemPage.titleHeaderColumn.first());

        StepLogger.verification('The down arrow will appear against Title' +
            ' and the data in table appears sort by Title ascending from z-a');
        await expect(await PageHelper.isElementDisplayed(RiskItemPage.columnSortingItems.title.ascending))
        .toBe(true, ValidationsHelper.getDisplayedValidation(RiskItemPageConstants.sortingOrder.ascending));
    });
});
