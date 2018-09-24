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
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Navigate to Edit Resource Plan- [966351]', async () => {
        StepLogger.caseId = 966351;
        // Step #1 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        await CommonPageHelper.clickEditResourcePlanViaRibbon();
        StepLogger.verification('"Edit Project" page is displayed');
        await CommonPageHelper.pageDisplayedValidation(ProjectItemPageConstants.pagePrefix);

        StepLogger.stepId(1);
        await WaitHelper.waitForElementToBeDisplayed(ResourcePlannerPage.delete);
        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        StepLogger.stepId(2);
        StepLogger.verification('\t\n' +
            'Check options displayed in \'Resource Planner - Project Mode\' window top section');
        await ResourcePlannerPageHelper.validateTopSection();

        StepLogger.stepId(3);
        StepLogger.verification('Check the columns displayed in top grid');
        await ResourcePlannerPageHelper.validateTopGrid();

        StepLogger.stepId(4);
        StepLogger.verification('Check options displayed in \'Resource Planner - Project Mode\' window bottom section');
        await ResourcePlannerPageHelper.validateButtonSection();

        StepLogger.stepId(5);
        StepLogger.verification('Check the columns displayed in bottom grid');
        await ResourcePlannerPageHelper.validateButtonSection();

        await PageHelper.click(CommonPage.ribbonItems.close);

        StepLogger.verification(`${CommonPageConstants.pageHeaders.projects.projectCenter} page is displayed`);
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.pageHeaders.projects.projectsCenter, CommonPageConstants.pageHeaders.projects.projectCenter);

    });

    it('Check Admin user has permissions to create Public fragments - [966249]', async () => {
        StepLogger.caseId = 966249;
        StepLogger.preCondition('Select "Navigation" icon  from left side menu');
        StepLogger.preCondition('Select Projects -> Projects from the options displayed');
        StepLogger.preCondition('Select any project from project center');
        await PageHelper.click(CommonPage.project);
        StepLogger.preCondition('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);
        StepLogger.preCondition('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);

        StepLogger.stepId(1);
        StepLogger.step('Click on Project tab');
        await PageHelper.click(CommonPage.projectTab);

        StepLogger.step('Click on Fragments icon from the button menu');
        await PageHelper.click(ProjectItemPage.fragmentIcon);

        StepLogger.verification('Below options displayed' +
            '- Insert Fragment' +
            '- Save Fragment' +
            '- Manage Fragments');
        await ProjectItemPageHelper.verifyFragmentDropDownLabel();

        StepLogger.stepId(2);
        StepLogger.step('Click on Save Fragment from the options displayed)');
        await PageHelper.click(ProjectItemPage.fragmentDropDownLabels.save);

        StepLogger.verification('Save Fragment pop up is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.savePopupBox)).toBe(true,
            ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.fragmentLabels.save));

        StepLogger.stepId(3);
        StepLogger.step('Un-Check the Private: check box');
        await CommonPageHelper.switchToContentFrame();
        await CheckboxHelper.markCheckbox(ProjectItemPage.privateCheckBox, false);

        StepLogger.verification('User is able to Un-check Private: check box');
        // Unable to verify that CheckBOx is checked or not because nothing is changing in dom.

        StepLogger.stepId(4);
        StepLogger.step('Check the Private: check box');
        await CheckboxHelper.markCheckbox(ProjectItemPage.privateCheckBox, false);

        StepLogger.verification('User is able to Check Private: check box');
        // Unable to verify that CheckBOx is checked or not because nothing is changing in dom.

        StepLogger.stepId(5);
        StepLogger.step('Click Close button in Save Fragment pop up');
        await PageHelper.click(ProjectItemPage.closeFragmentButton);

        StepLogger.verification('Save Fragment pop up is closed');
        await expect(await CommonPage.savePopupBox.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(ProjectItemPageConstants.fragmentLabels.save));

        StepLogger.verification('Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));
    });

    it('Insert Fragment - [966282]', async () => {
        StepLogger.caseId = 966282;
        StepLogger.preCondition('Select "Navigation" icon  from left side menu');
        StepLogger.preCondition('Select Projects -> Projects from the options displayed');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(1);
        StepLogger.step('Mouse over the item created as per pre requisites that need to be viewed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.project);
        await ElementHelper.actionHoverOver(CommonPage.project);

        StepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        StepLogger.step('Select "Edit Plan" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editPlan);
        StepLogger.preCondition('Select any project from project center');

        StepLogger.verification('The Select Planner pop-up should display');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.selectPlanner));

        StepLogger.stepId(2);
        StepLogger.step('Click in Project Planner ' +
            'Select a template');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);

        StepLogger.verification('User should be navigated to Project Planner page');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.stepId(3);
        StepLogger.step('Click on Project tab');
        await PageHelper.click(CommonPage.projectTab);

        StepLogger.verification('Project tab opened');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.fragmentIcon))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.fragmentLabels.fragment));

        StepLogger.stepId(4);
        StepLogger.step('Click on Fragments button');
        await PageHelper.click(ProjectItemPage.fragmentIcon);
        StepLogger.step('Click on Insert Fragment button.');
        await PageHelper.click(ProjectItemPage.fragmentDropDownLabels.insert);

        StepLogger.verification('Fragment list should be visible with Cancel and Insert button.');
        await CommonPageHelper.switchToContentFrame();
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.closeFragmentButton))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.ribbonLabels.close));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.insertFragmentButton))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.ribbonLabels.insert));

        StepLogger.stepId(5);
        StepLogger.step('Select a Fragment' +
            'Click on Insert button');
        await PageHelper.click(ProjectItemPage.firstFragment);
        await PageHelper.click(ProjectItemPage.insertFragmentButton);

        StepLogger.verification('Fragment should be saved and published successfully.');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.fragmentUploadMessage))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.messageText.uploadSuccessfully));

        StepLogger.stepId(6);
        StepLogger.step('Select a Fragment' +
            'Click on Insert button');
        await ElementHelper.clickUsingJs(ProjectItemPage.save);
        // wait required to let it save
        await browser.sleep(PageHelper.timeout.s);
        await ElementHelper.clickUsingJs(ProjectItemPage.publishButtton);

        StepLogger.step('Wait till the Publishing is completed [Publish Status will show the status]');
        // Wait required to let it publish
        await browser.sleep(PageHelper.timeout.s);
        await expect(await PageHelper.isElementPresent(ProjectItemPage.publishstatus)).toBe(true,
            ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.itemOptions.publish));
        // not change done on UI so not able to verify inserted fragment

    });
});
