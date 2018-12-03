import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {Constants} from '../../../../../components/misc-utils/constants';
import {CreateNewPage} from '../../../../../page-objects/pages/items-page/create-new.po';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/items-page/create-new-page.constants';
import {PortfolioItemPageConstants} from '../../../../../page-objects/pages/items-page/portfolio-item/portfolio-item-page.constants';
import {PortfolioItemPage} from '../../../../../page-objects/pages/items-page/portfolio-item/portfolio-item.po';
import {PortfolioItemPageHelper} from '../../../../../page-objects/pages/items-page/portfolio-item/portfolio-item-page.helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
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

    it('Create New Portfolio - [1125567]', async () => {
        StepLogger.caseId = 1125567;

        StepLogger.stepId(1);

        StepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

        StepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.portfolio))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.portfolio));

        StepLogger.stepId(2);
        StepLogger.step('Click on "Portfolio" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.portfolio);

        StepLogger.verification('"Portfolios - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(PortfolioItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(PortfolioItemPageConstants.pageName));

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        StepLogger.stepId(3);
        StepLogger.step('Enter/Select required details in "Portfolios - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = PortfolioItemPageConstants.inputLabels;
        const portfolioNameValue = `${labels.portfolioName} ${uniqueId}`;
        const portfolioDescriptionValue = `${labels.portfolioDescription} ${uniqueId}`;
        const portfolioTypeValue = CommonPageConstants.portfolioTypes.development;
        const stateValue = CommonPageConstants.states.active;
        await PortfolioItemPageHelper.fillForm(portfolioNameValue,
            portfolioDescriptionValue,
            portfolioTypeValue,
            stateValue,
        );

        await PageHelper.switchToDefaultContent();

        StepLogger.verification('Notification about New Portfolios created [Ex: New Portfolio Item 1] displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getNotificationByText(portfolioNameValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(PortfolioItemPageConstants.pageName));

        StepLogger.stepId(5);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.portfolios,
            CommonPage.pageHeaders.projects.projectPortfolios,
            CommonPageConstants.pageHeaders.projects.projectPortfolios,
        );

        await CommonPageHelper.searchItemByTitle(portfolioNameValue,
            PortfolioItemPageConstants.columnNames.title,
        );

        StepLogger.verification('Newly created Portfolio [Ex: New Portfolio Item 1] displayed in "Portfolios" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(portfolioNameValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(portfolioNameValue));
    });

    it('Edit Portfolios Functionality - [1125568]', async () => {
        StepLogger.caseId = 1125568;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.portfolios,
            CommonPage.pageHeaders.projects.projectPortfolios,
            CommonPageConstants.pageHeaders.projects.projectPortfolios,
        );
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.record, CommonPage.contextMenuOptions.editItem);

        StepLogger.verification('"Edit Portfolio" page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(PortfolioItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        StepLogger.verification('Values selected/entered while creating the Portfolio are pre populated in respective fields');
        await expect(await TextboxHelper.hasValue(PortfolioItemPage.inputs.portfolioName, Constants.EMPTY_STRING))
            .toBe(false,
                ValidationsHelper.getFieldShouldNotHaveValueValidation(PortfolioItemPageConstants.inputLabels.portfolioName,
                    Constants.EMPTY_STRING));

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "Edit Portfolio" page as described below');

        const uniqueId = PageHelper.getUniqueId();
        const labels = PortfolioItemPageConstants.inputLabels;
        const portfolioNameValue = `${labels.portfolioName} ${uniqueId}`;
        const portfolioDescriptionValue = `${labels.portfolioDescription} ${uniqueId}`;
        const portfolioTypeValue = CommonPageConstants.portfolioTypes.development;
        const stateValue = CommonPageConstants.states.proposed;
        await PortfolioItemPageHelper.fillForm(portfolioNameValue,
            portfolioDescriptionValue,
            portfolioTypeValue,
            stateValue,
        );

        StepLogger.verification('"Portfolios" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPortfolios))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPortfolios));

        StepLogger.verification('"Edit Portfolio" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(PortfolioItemPageConstants.editPageName));

        StepLogger.verification('Updated Portfolio details (Title, Status, Priority) displayed in "Portfolios" page');
        StepLogger.verification('Search item by portfolioName');
        await CommonPageHelper.searchItemByTitle(
            portfolioNameValue,
            PortfolioItemPageConstants.columnNames.title,
        );

        StepLogger.verification('Show columns whatever is required');
        await CommonPageHelper.showColumns([
            PortfolioItemPageConstants.columnNames.budgetStatus,
            PortfolioItemPageConstants.columnNames.portfolioType,
            PortfolioItemPageConstants.columnNames.workStatus,
            PortfolioItemPageConstants.columnNames.portfolioGoals]);

        StepLogger.verification('Click on searched record');
        await PageHelper.click(CommonPage.record);

        StepLogger.verification('Verify record by portfolioName');
        const firstTableColumns = [portfolioNameValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        StepLogger.verification('Verify by other properties');
        const secondTableColumns = [portfolioTypeValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    });
});
