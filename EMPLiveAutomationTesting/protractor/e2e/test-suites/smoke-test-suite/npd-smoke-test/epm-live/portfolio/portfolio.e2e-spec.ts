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
import {Constants} from '../../../../../components/misc-utils/constants';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CreateNewPage} from '../../../../../page-objects/pages/items-page/create-new.po';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/items-page/create-new-page.constants';
import {CommonItemPage} from '../../../../../page-objects/pages/items-page/common-item/common-item.po';
import {CommonItemPageHelper} from '../../../../../page-objects/pages/items-page/common-item/common-item-page.helper';
import {PortfolioItemPageConstants} from '../../../../../page-objects/pages/items-page/portfolio-item/portfolio-item-page.constants';
import {PortfolioItemPage} from '../../../../../page-objects/pages/items-page/portfolio-item/portfolio-item.po';
import {PortfolioItemPageHelper} from '../../../../../page-objects/pages/items-page/portfolio-item/portfolio-item-page.helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('Create New Portfolio - [1125567]', async () => {
        const stepLogger = new StepLogger(1125567);

        stepLogger.stepId(1);

        stepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

        stepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.portfolio))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.portfolio));

        stepLogger.stepId(2);
        stepLogger.step('Click on "Portfolio" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.portfolio);

        stepLogger.verification('"Portfolios - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.dialogTitles.first());

        await expect(await CommonItemPage.dialogTitles.first().getText())
            .toBe(PortfolioItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(PortfolioItemPageConstants.pageName));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Portfolios - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = PortfolioItemPageConstants.inputLabels;
        const portfolioNameValue = `${labels.portfolioName} ${uniqueId}`;
        const portfolioDescriptionValue = `${labels.portfolioDescription} ${uniqueId}`;
        const portfolioTypeValue = PortfolioItemPageConstants.portfolioTypes.development;
        const stateValue = PortfolioItemPageConstants.states.active;
        await PortfolioItemPageHelper.fillForm(portfolioNameValue,
            portfolioDescriptionValue,
            portfolioTypeValue,
            stateValue,
            stepLogger);

        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Portfolios created [Ex: New Portfolio Item 1] displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonItemPageHelper.getNotificationByText(portfolioNameValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(PortfolioItemPageConstants.pageName));

        stepLogger.stepId(5);
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.portfolios,
            CommonViewPage.pageHeaders.projects.projectPortfolios,
            CommonViewPageConstants.pageHeaders.projects.projectPortfolios,
            stepLogger);

        await CommonViewPageHelper.searchItemByTitle(portfolioNameValue,
            PortfolioItemPageConstants.columnNames.title,
            stepLogger);

        stepLogger.verification('Newly created Portfolio [Ex: New Portfolio Item 1] displayed in "Portfolios" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextXPathInsideGrid(portfolioNameValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(portfolioNameValue));
    });

    it('Edit Portfolios Functionality - [1125568]', async () => {
        const stepLogger = new StepLogger(1125568);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.portfolios,
            CommonViewPage.pageHeaders.projects.projectPortfolios,
            CommonViewPageConstants.pageHeaders.projects.projectPortfolios,
            stepLogger);
        await CommonPageHelper.editItemViaContextMenu(stepLogger);

        stepLogger.verification('"Edit Portfolio" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.title);
        await expect(await CommonItemPage.title.getText())
            .toBe(PortfolioItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.verification('Values selected/entered while creating the Portfolio are pre populated in respective fields');
        await expect(await TextboxHelper.hasValue(PortfolioItemPage.inputs.portfolioName, Constants.EMPTY_STRING))
            .toBe(false,
                ValidationsHelper.getFieldShouldNotHaveValueValidation(PortfolioItemPageConstants.inputLabels.portfolioName,
                    Constants.EMPTY_STRING));

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Edit Portfolio" page as described below');

        const uniqueId = PageHelper.getUniqueId();
        const labels = PortfolioItemPageConstants.inputLabels;
        const portfolioNameValue = `${labels.portfolioName} ${uniqueId}`;
        const portfolioDescriptionValue = `${labels.portfolioDescription} ${uniqueId}`;
        const portfolioTypeValue = PortfolioItemPageConstants.portfolioTypes.development;
        const stateValue = PortfolioItemPageConstants.states.proposed;
        await PortfolioItemPageHelper.fillForm(portfolioNameValue,
            portfolioDescriptionValue,
            portfolioTypeValue,
            stateValue,
            stepLogger);

        stepLogger.verification('"Portfolios" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonViewPage.pageHeaders.projects.projectPortfolios))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonViewPageConstants.pageHeaders.projects.projectPortfolios));

        stepLogger.verification('"Edit Portfolio" page is closed');
        await expect(await CommonItemPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(PortfolioItemPageConstants.editPageName));

        stepLogger.verification('Updated Portfolio details (Title, Status, Priority) displayed in "Portfolios" page');
        stepLogger.verification('Search item by portfolioName');
        await CommonViewPageHelper.searchItemByTitle(
            portfolioNameValue,
            PortfolioItemPageConstants.columnNames.title,
            stepLogger);

        stepLogger.verification('Show columns whatever is required');
        await CommonViewPageHelper.showColumns([
            PortfolioItemPageConstants.columnNames.title,
            PortfolioItemPageConstants.columnNames.portfolioType,
            PortfolioItemPageConstants.columnNames.notes,
            PortfolioItemPageConstants.columnNames.stateIcon]);

        stepLogger.verification('Click on searched record');
        await PageHelper.click(CommonViewPage.record);

        stepLogger.verification('Verify record by portfolioName');
        const firstTableColumns = [portfolioNameValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        stepLogger.verification('Verify by other properties');
        const secondTableColumns = [portfolioDescriptionValue, portfolioTypeValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    });
});
