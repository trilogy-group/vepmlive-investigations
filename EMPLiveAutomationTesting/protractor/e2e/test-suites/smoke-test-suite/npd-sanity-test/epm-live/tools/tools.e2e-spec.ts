import {browser} from 'protractor';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
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
import {ElementHelper} from '../../../../../components/html/element-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ResourcePlannerPageHelper} from '../../../../../page-objects/pages/resource-planner-page/resource-planner-page.helper';
import {ResourcePlannerPage} from '../../../../../page-objects/pages/resource-planner-page/resource-planner-page.po';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Navigate to Edit Resource Plan- [966351]', async () => {
        const stepLogger = new StepLogger(966351);
    // Step #1 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        await CommonPageHelper.clickEditResourcePlanViaRibbon(stepLogger);
        stepLogger.verification('"Edit Project" page is displayed');
        await CommonPageHelper.pageDisplayedValidation(ProjectItemPageConstants.pagePrefix);

        stepLogger.stepId(1);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourcePlannerPage.delete);
        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.stepId(2);
        stepLogger.verification('\t\n' +
            'Check options displayed in \'Resource Planner - Project Mode\' window top section');
        await ResourcePlannerPageHelper.validateTopSection(stepLogger);

        stepLogger.stepId(3);
        stepLogger.verification('Check the columns displayed in top grid');
        await ResourcePlannerPageHelper.validateTopGrid(stepLogger);

        stepLogger.stepId(4);
        stepLogger.verification('Check options displayed in \'Resource Planner - Project Mode\' window bottom section');
        await ResourcePlannerPageHelper.validateButtonSection(stepLogger);

        stepLogger.stepId(5);
        stepLogger.verification('Check the columns displayed in bottom grid');
        await ResourcePlannerPageHelper.validateButtonSection(stepLogger);

        await PageHelper.click(CommonPage.ribbonItems.close);

        stepLogger.verification(`${CommonPageConstants.pageHeaders.projects.projectCenter} page is displayed`);
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.pageHeaders.projects.projectsCenter, CommonPageConstants.pageHeaders.projects.projectCenter);

    });

  it('Check Admin user has permissions to create Public fragments - [966249]', async () => {
        const stepLogger = new StepLogger(966249);
        stepLogger.precondition('Select "Navigation" icon  from left side menu');
        stepLogger.precondition('Select Projects -> Projects from the options displayed');
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

    it('Insert Fragment - [966282]', async () => {
        const stepLogger = new StepLogger(966282);
        stepLogger.precondition('Select "Navigation" icon  from left side menu');
        stepLogger.precondition('Select Projects -> Projects from the options displayed');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Mouse over the item created as per pre requisites that need to be viewed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.project);
        await ElementHelper.actionHoverOver(CommonPage.project);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('Select "Edit Plan" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editPlan);
        stepLogger.precondition('Select any project from project center');

        stepLogger.verification('The Select Planner pop-up should display');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.selectPlanner));

        stepLogger.stepId(2);
        stepLogger.step('Click in Project Planner ' +
            'Select a template');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);

        stepLogger.verification('User should be navigated to Project Planner page');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.stepId(3);
        stepLogger.step('Click on Project tab');
        await PageHelper.click(CommonPage.projectTab);

        stepLogger.verification('Project tab opened');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.fragmentIcon))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.fragmentLabels.fragment));

        stepLogger.stepId(4);
        stepLogger.step('Click on Fragments button');
        await PageHelper.click(ProjectItemPage.fragmentIcon);
        stepLogger.step('Click on Insert Fragment button.');
        await PageHelper.click(ProjectItemPage.fragmentDropDownLabels.insert);

        stepLogger.verification('Fragment list should be visible with Cancel and Insert button.');
        await CommonPageHelper.switchToContentFrame(stepLogger);
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.closeFragmentButton))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.ribbonLabels.close));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.insertFragmentButton))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.ribbonLabels.insert));

        stepLogger.stepId(5);
        stepLogger.step('Select a Fragment' +
            'Click on Insert button');
        await PageHelper.click(ProjectItemPage.firstFragment);
        await PageHelper.click(ProjectItemPage.insertFragmentButton);

        stepLogger.verification('Fragment should be saved and published successfully.');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.fragmentUploadMessage))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.messageText.uploadSuccessfully));

        stepLogger.stepId(6);
        stepLogger.step('Select a Fragment' +
            'Click on Insert button');
        await ElementHelper.clickUsingJs(ProjectItemPage.save);
        // wait required to let it save
        await browser.sleep(PageHelper.timeout.s);
        await ElementHelper.clickUsingJs(ProjectItemPage.publishButtton);

        stepLogger.step('Wait till the Publishing is completed [Publish Status will show the status]');
        // Wait required to let it publish
        await browser.sleep(PageHelper.timeout.s);
        await expect(await PageHelper.isElementPresent(ProjectItemPage.publishstatus)).toBe(true,
            ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.itemOptions.publish));
        // not change done on UI so not able to verify inserted fragment

    });
});
