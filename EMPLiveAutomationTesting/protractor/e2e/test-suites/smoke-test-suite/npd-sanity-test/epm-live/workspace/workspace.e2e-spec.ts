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
import { ElementHelper } from '../../../../../components/html/element-helper';

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

    it('Navigate to Associated Items page - [966382] [BUG: SKYVERA-1597]', async () => {
        StepLogger.caseId = 966382;
        StepLogger.preCondition('Select "Navigation" icon  from left side menu');
        StepLogger.preCondition('Select Projects -> Projects from the options displayed');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        StepLogger.preCondition('Select any project from project center');
        await PageHelper.click(CommonPage.project);
        StepLogger.preCondition('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);
        StepLogger.preCondition('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        // Planner takes time to get open so sleep required
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);

        StepLogger.stepId(1);
        StepLogger.step('Click on Project tab');
        await ElementHelper.actionHoverOver(CommonPage.projectTab);
        await PageHelper.click(CommonPage.projectTab);

        StepLogger.step('Click on "Associated Items" icon from the button menu');
        await PageHelper.click(ProjectItemPage.associatedItemsDropDown);

        StepLogger.verification('Below Options displayed\n' +
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

        StepLogger.stepId(2);
        StepLogger.step('Click on Changes from the options displayed');
        await PageHelper.click(ProjectItemPage.associatedItems.changes);

        StepLogger.verification('Changes - Benefits View window is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.changeWindow))
            .toBe(true, ValidationsHelper.getWindowShouldBeDisplayedValidation(ProjectItemPageConstants.changeWindow));

        StepLogger.stepId(3);
        StepLogger.step('Click X in Changes - Benefits View window');
        await ProjectItemPageHelper.closeResourcePage();

        StepLogger.verification('Changes - Benefits View window is displayed');
        await expect(await ProjectItemPage.changeWindow.isPresent())
            .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.changeWindow));

        StepLogger.verification('Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner)).toBe(true,
            ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.stepId(4);
        StepLogger.step('Click on "Associated Items" icon from the button menu');
        await PageHelper.click(ProjectItemPage.associatedItemsDropDown);

        StepLogger.step('Click on Issues from the options displayed');
        await PageHelper.click(ProjectItemPage.associatedItems.issues);

        StepLogger.verification('Changes - Benefits View window is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.issueWindow))
            .toBe(true, ValidationsHelper.getWindowShouldBeDisplayedValidation(ProjectItemPageConstants.issueWindow));

        StepLogger.stepId(5);
        StepLogger.step('Click X in Changes - Benefits View window');
        await ProjectItemPageHelper.closeResourcePage();

        StepLogger.verification('Changes - Benefits View window is displayed');
        await expect(await ProjectItemPage.issueWindow.isPresent())
            .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.issueWindow));

        StepLogger.verification('Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner)).toBe(true,
            ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));
    });
});
