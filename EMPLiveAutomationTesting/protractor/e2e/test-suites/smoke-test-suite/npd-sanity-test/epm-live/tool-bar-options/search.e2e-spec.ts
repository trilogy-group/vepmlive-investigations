import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';

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

    /* #UNSTABLE
    it('Check Search feature - [1035924]', async () => {
        StepLogger.caseId = 1035924;
        StepLogger.stepId(1);
        StepLogger.verification('Navigate To Projects Page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(1);
        // step#3, step#4 are inside this function
        StepLogger.verification('Search item by Project Name');
        await WaitHelper.waitForElementToBePresent(CommonPage.itemsListing);
        const firstProjectName = await CommonPage.itemsListing.getText();
        await CommonPageHelper.searchItemByTitle(firstProjectName, ProjectItemPageConstants.columnNames.title, true);

        StepLogger.verification('searched projects should get displayed');
        await expect(await PageHelper.isElementPresent(CommonPageHelper.searchedItemList(firstProjectName)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(firstProjectName));

        StepLogger.stepId(5);
        StepLogger.step('Select column name as State');
        await PageHelper.sendKeysToInputField(CommonPage.searchControls.column, ProjectItemPageConstants.columnNames.state);
        StepLogger.step('Select search choice as "Closed"');
        await PageHelper.click(CommonPage.searchControls.textChoice);
        await PageHelper.click(CommonPage.searchChoiceOption.closed);
        StepLogger.step('Click on perform search button');

        StepLogger.stepId(6);
        await PageHelper.click(CommonPage.searchIcon);
        StepLogger.verification('"No data found" message should be shown');
        await expect(await PageHelper.isElementDisplayed(CommonPage.noDataFound))
            .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.messages.noDataFound));
    });
    */
});
