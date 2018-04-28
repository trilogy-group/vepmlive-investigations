// tslint:disable-next-line:max-line-length
// tslint:disable-next-line:max-line-length
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/create-new-page/new-item/project-item/project-item-page.constants';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {CommonItemPage} from '../../../../../page-objects/pages/create-new-page/new-item/common-item/common-item.po';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {CommonViewPage} from '../../../../../page-objects/pages/homepage/common-view-page/common-view.po';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {CommonViewPageHelper} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.helper';
import {CommonViewPageConstants} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.constants';
import {ProjectItemPage} from '../../../../../page-objects/pages/create-new-page/new-item/project-item/project-item.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {browser} from 'protractor';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('Add Project Functionality - [1124170]', async () => {
        const stepLogger = new StepLogger(1124170);

        stepLogger.stepId(1);

        // Step #1 Inside this function
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.projects,
            CommonViewPage.pageHeaders.projects.projectsCenter,
            CommonViewPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Click on "+ New item" link displayed on top of "Project Center" Page');
        await PageHelper.click(CommonPage.addNewLink);

        // Note - little mismatch, It doesn't open a popup window
        stepLogger.verification('"Project Center - New Item" window is displayed');
        await expect(await CommonItemPage.titles.first().getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.pageName));

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ProjectItemPageConstants.inputLabels;
        const inputs = ProjectItemPage.inputs;

        // Add project name
        stepLogger.step('Title *: Random New Issue Item');
        const projectNameValue = `${labels.projectName} ${uniqueId}`;
        await TextboxHelper.sendKeys(inputs.projectName, projectNameValue);

        stepLogger.verification('Required values entered/selected in name Field');
        await expect(await TextboxHelper.hasValue(inputs.projectName, projectNameValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectName, projectNameValue));

        // Add portfolio name
        /*stepLogger.step('Select any Portfolio from the drop down [Ex: Test Portfolio1]');
        await PageHelper.click(ProjectItemPage.portfolioShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(inputs.portfolio);
        const portfolioName = await inputs.portfolio.getText();
        await PageHelper.click(inputs.portfolio);

        stepLogger.verification('Required values selected in Portfolio Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(portfolioName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolio, portfolioName));
        */

        // Add Project Description
        stepLogger.step('Enter some text [Ex: Description for Smoke Test Project 1]');
        const projectDescription = `${labels.projectDescription} ${uniqueId}`;
        await TextboxHelper.sendKeys(inputs.projectDescription, projectDescription);

        stepLogger.verification('Required values entered in Description Field');
        await expect(await TextboxHelper.hasValue(inputs.projectDescription, projectDescription))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectDescription, projectDescription));

        // Add Benefits
        stepLogger.step('Benefits: Test Smoke');
        const benefits = `${labels.benefits} ${uniqueId}`;
        await TextboxHelper.sendKeys(inputs.benefits, benefits);

        stepLogger.verification('Required values entered in "Benefits" Field');
        await expect(await TextboxHelper.hasValue(inputs.benefits, benefits))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.benefits, benefits));

        // Add State
        stepLogger.step('State: Select the value \'(2) Active\'');
        await PageHelper.sendKeysToInputField(inputs.state, ProjectItemPageConstants.states.active);

        stepLogger.verification('Required values selected in "State" Field');
        await expect(await TextboxHelper.hasValue(inputs.benefits, benefits))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.benefits, benefits));

        // Add Overall Health
        stepLogger.step('Overall Health: Select the value "(1) On Track"');
        const overallHealthOnTrack = ProjectItemPageConstants.overallHealth.onTrack;
        await PageHelper.sendKeysToInputField(inputs.overallHealth, overallHealthOnTrack);

        stepLogger.verification('Verify - Overall Health: Select the value "(1) On Track"');
        await expect(await ElementHelper.hasSelectedOption(inputs.overallHealth, overallHealthOnTrack))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.overallHealth, overallHealthOnTrack));

        // Add Project Update
        stepLogger.step('Project Update: Select the value "Manual"');
        const projectUpdateManual = ProjectItemPageConstants.projectUpdate.manual;
        await PageHelper.sendKeysToInputField(inputs.projectUpdate, projectUpdateManual);

        stepLogger.verification('Verify - Project Update : Select the value "Manual"');
        await expect(await ElementHelper.hasSelectedOption(inputs.projectUpdate, projectUpdateManual))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectUpdate, projectUpdateManual));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Project - New Item" window');
        await PageHelper.click(CommonItemPage.formButtons.save);

        stepLogger.verification('"Project - New Item" window is closed');
        await expect(await CommonItemPage.dialogTitles.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.pageName));

        stepLogger.stepId(5);
        stepLogger.verification('Navigate to page');
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.projects,
            CommonViewPage.pageHeaders.projects.projectsCenter,
            CommonViewPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        await CommonViewPageHelper.searchItemByTitle(projectNameValue, ProjectItemPageConstants.columnNames.title, stepLogger);

        stepLogger.verification('Newly created Project [Ex: Project 1] displayed in "Project" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByExactTextXPath(projectNameValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(projectNameValue));

        browser.sleep(90000);
    });
});
