import {browser} from 'protractor';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Navigate to Associated Items page - [966382]', async () => {
        const stepLogger = new StepLogger(966382);
        stepLogger.precondition('Select "Navigation" icon  from left side menu');
        stepLogger.precondition('Select Projects -> Projects from the options displayed');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        stepLogger.precondition('Select any project from project center');
        await PageHelper.click(CommonPage.project);
        stepLogger.precondition('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);
        stepLogger.precondition('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        // Planner takes time to get open so sleep required
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);

        stepLogger.stepId(1);
        stepLogger.step('Click on Project tab');
        await PageHelper.click(CommonPage.projectTab);

        stepLogger.step('Click on "Associated Items" icon from the button menu');
        await PageHelper.click(ProjectItemPage.associatedItemsDropDown);

        stepLogger.verification('Below Options displayed\n' +
            '- Lists\n' +
            '- Changes\n' +
            '- Issues\n' +
            '- Project Status Reports\n' +
            '- Risks\n' +
            '- Document Libraries');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.associatedItems.lists))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.associatedItems.lists));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.associatedItems.changes))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.associatedItems.changes));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.associatedItems.issues))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.associatedItems.issues));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.associatedItems.risks))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.associatedItems.risks));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.associatedItems.documentLibraries))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.associatedItems.documentLibraries));

        stepLogger.stepId(2);
        stepLogger.step('Click on Changes from the options displayed');
        await PageHelper.click(ProjectItemPage.associatedItems.changes);

        stepLogger.verification('Changes - Benefits View window is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.changeWindow))
            .toBe(true, ValidationsHelper.getWindowShouldBeDisplayedValidation(ProjectItemPageConstants.changeWindow));

        stepLogger.stepId(3);
        stepLogger.step('Click X in Changes - Benefits View window');
        await ProjectItemPageHelper.closeResourcePage();

        stepLogger.verification('Changes - Benefits View window is displayed');
        await expect(await ProjectItemPage.changeWindow.isPresent())
            .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.changeWindow));

        stepLogger.verification('Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner)).toBe(true,
            ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Associated Items" icon from the button menu');
        await PageHelper.click(ProjectItemPage.associatedItemsDropDown);

        stepLogger.step('Click on Issues from the options displayed');
        await PageHelper.click(ProjectItemPage.associatedItems.issues);

        stepLogger.verification('Changes - Benefits View window is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.issueWindow))
            .toBe(true, ValidationsHelper.getWindowShouldBeDisplayedValidation(ProjectItemPageConstants.issueWindow));

        stepLogger.stepId(5);
        stepLogger.step('Click X in Changes - Benefits View window');
        await ProjectItemPageHelper.closeResourcePage();

        stepLogger.verification('Changes - Benefits View window is displayed');
        await expect(await ProjectItemPage.issueWindow.isPresent())
            .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.issueWindow));

        stepLogger.verification('Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner)).toBe(true,
            ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));
    });
});
