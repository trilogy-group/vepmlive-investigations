import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {SettingsPage} from '../../../../../page-objects/pages/settings/settings.po';
import {PlannerSettingsPageHelper} from '../../../../../page-objects/pages/settings/planner-setting/planner-settings-page.helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {PlannerSettingsPageConstants} from '../../../../../page-objects/pages/settings/planner-setting/planner-settings-page.constants';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {CheckboxHelper} from '../../../../../components/html/checkbox-helper';
import {browser} from 'protractor';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add new planner - [1032747]', async () => {
        const stepLogger = new StepLogger(1032747);
        stepLogger.stepId(1);
        const uniqueId = PageHelper.getUniqueId();
        stepLogger.step('Click on "Main Gear Settings" icon  displayed in left bottom corner');
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        const plannerReportingMenus = SettingsPage.menuItems.plannerSettings;

        stepLogger.verification('Various Settings Options displayed');
        await expect(await PageHelper.isElementDisplayed(plannerReportingMenus.rootMenu))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.settings));

        stepLogger.stepId(2);
        stepLogger.step('Expand "Planner Settings" node');
        await PlannerSettingsPageHelper.expandPlannerSettingsNode();

        stepLogger.step('Click on "Planners" sub node');
        await PageHelper.click(ElementHelper.getElementByText(PlannerSettingsPageConstants.leftMenus.planners));

        stepLogger.verification('Various Settings Options displayed');
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.planName))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.planName));
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.souceList))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.sourceList));
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.taskList))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.taskList));
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.backToSetting))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.backToSetting));
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.editPLanner))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.addANewPlanner));

        stepLogger.stepId(3);
        stepLogger.step('Click on + Add New Planner button link');
        await PageHelper.click(PlannerSettingsPageHelper.menu.menuTitles.editPLanner);

        stepLogger.verification('Planner Settings page is displayed');
        await expect(browser.getTitle()).toBe(PlannerSettingsPageConstants.plannerPage,
            ValidationsHelper.getPageDisplayedValidation(PlannerSettingsPageConstants.plannerPage));

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select below value in Planner Settings page "General Settings"');
        stepLogger.step('Planner Name: Enter a Name for Planner [Ex: Smoke Test Planner 1]');
        await TextboxHelper.sendKeys(PlannerSettingsPageHelper.planNameField, uniqueId);

        stepLogger.step('Planner Description: Enter Description for Planner [Ex: New Planner created as part of smoke test]');
        await TextboxHelper.sendKeys(PlannerSettingsPageHelper.planDiscriptionField,
            PlannerSettingsPageConstants.newPlannerDetails.discription);

        stepLogger.step('Scroll down till the section Additional Settings is displayed');
        await ElementHelper.scrollToElement(PlannerSettingsPageHelper.startSoonCheckBox);

        stepLogger.step('Enforce Start as Soon as Possible: Check/Select the check box Enable Start as Soon as Possible');
        await CheckboxHelper.markCheckbox(PlannerSettingsPageHelper.startSoonCheckBox, true);

        // To Verify "Required values Entered/Selected in 'Planner Settings' page" is not posible
        stepLogger.stepId(5);
        stepLogger.step('Scroll down to end of page');
        await ElementHelper.scrollToBottomOfPage();

        stepLogger.step('Click on Save Settings button');
        await PageHelper.click(PlannerSettingsPageHelper.saveButton);

        stepLogger.verification('"Planner Settings" page is closed');
        await expect(browser.getTitle()).not.toBe(PlannerSettingsPageConstants.plannerPage,
            ValidationsHelper.getPageDisplayedValidation(PlannerSettingsPageConstants.plannerPage));

        stepLogger.verification('Planner Administration page is displayed');
        await expect(browser.getTitle()).toBe(PlannerSettingsPageConstants.administration,
            ValidationsHelper.getPageDisplayedValidation(PlannerSettingsPageConstants.administration));

        stepLogger.verification('Newly created Planner [Ex: Smoke Test Planner 1] is displayed in the list');
        await expect(PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId)))
            .toBe(true, ValidationsHelper.getRecordCreatedValidation(uniqueId));

        stepLogger.stepId(6);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');

        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.verification('Project Center page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(7);
        stepLogger.step('Select the project created as per pre requisites [Ex: Smoke Test Project 2]');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.project);
        const projectName = await CommonPage.project.getText();
        await PageHelper.click(CommonPage.project);

        stepLogger.step('Click on the ITEMS tab above the grid\n' +
            'From the ITEMS ribbon menu, click on Edit Plan');
        await PageHelper.click(CommonPage.editPlan);

        stepLogger.verification('Select Planner pop-up displays with different planner options to select');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(CommonPage.dialogTitle.isDisplayed()).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.selectPlanner));

        stepLogger.verification('Newly created Planner [Ex: Smoke Test Planner 1] is displayed in the list');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await expect(PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId)))
            .toBe(true, ValidationsHelper.getRecordCreatedValidation(uniqueId));
        await PageHelper.switchToDefaultContent();

        stepLogger.stepId(8);
        stepLogger.step('Select the newly added planner [Ex: Smoke Test Planner 1] in Select Planner pop up');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ElementHelper.getElementByText
        (uniqueId));

        stepLogger.verification('Selected Project is opened using the Newly created Planner [Ex: Smoke Test Planner 1]');
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);
        await expect(browser.getTitle()).toContain(projectName,
            ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.project));
        await expect(browser.getTitle()).toContain(uniqueId,
            ValidationsHelper.getDisplayedValidation(uniqueId));

        stepLogger.stepId(9);
        stepLogger.step('Click Close button in Project Planner window [Ex: Smoke Test Planner 1]');
        await PageHelper.click(ProjectItemPage.close);

        stepLogger.stepId(10);
        stepLogger.step('Click on Leave button in the confirmation dialog');
        await browser.switchTo().alert().accept();

        stepLogger.verification('Project Planner window [Ex: Smoke Test Planner 1] is closed');
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.editPlan);
        await expect(CommonPage.pageHeaders.projects.projectPlanner.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.verification('Project Center page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
    });
});
