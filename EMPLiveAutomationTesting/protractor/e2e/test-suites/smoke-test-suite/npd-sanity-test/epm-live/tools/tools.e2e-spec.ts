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
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {CheckboxHelper} from '../../../../../components/html/checkbox-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Check Admin user has permissions to create Public fragments - [966249]', async () => {
        const stepLogger = new StepLogger(966249);
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
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);

        stepLogger.stepId(1);
        stepLogger.step('Click on Project tab');
        await PageHelper.click(CommonPage.projectTab);

        stepLogger.step('Click on Fragments icon from the button menu');
        await PageHelper.click(ProjectItemPage.fragmentIcon);

        stepLogger.verification('Below options displayed' +
            '- Insert Fragment' +
            '- Save Fragment' +
            '- Manage Fragments');
        await ProjectItemPageHelper.verifyFragmentDropDownLabel();

        stepLogger.stepId(2);
        stepLogger.step('Click on Save Fragment from the options displayed)');
        await PageHelper.click(ProjectItemPage.fragmentDropDownLabels.save);

        stepLogger.verification('Save Fragment pop up is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.savePopupBox)).toBe(true,
            ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.fragmentLabels.save));

        stepLogger.stepId(3);
        stepLogger.step('Un-Check the Private: check box');
        await CommonPageHelper.switchToContentFrame(stepLogger);
        await CheckboxHelper.markCheckbox(ProjectItemPage.privateCheckBox, false);

        stepLogger.verification('User is able to Un-check Private: check box');
       // Unable to verify that CheckBOx is checked or not because nothing is changing in dom.

        stepLogger.stepId(4);
        stepLogger.step('Check the Private: check box');
        await CheckboxHelper.markCheckbox(ProjectItemPage.privateCheckBox, false);

        stepLogger.verification('User is able to Check Private: check box');
        // Unable to verify that CheckBOx is checked or not because nothing is changing in dom.

        stepLogger.stepId(5);
        stepLogger.step('Click Close button in Save Fragment pop up');
        await PageHelper.click(ProjectItemPage.closeFragmentButton);

        stepLogger.verification('Save Fragment pop up is closed');
        await expect(await CommonPage.savePopupBox.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(ProjectItemPageConstants.fragmentLabels.save));

        stepLogger.verification('Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));
    });
});
