import {browser, By, element} from 'protractor';
import {PageHelper} from '../../../../components/html/page-helper';
import {PlannerSettingsPageConstants} from './planner-settings-page.constants';
import {ElementHelper} from '../../../../components/html/element-helper';
import {CommonPage} from '../../common/common.po';
import {CheckboxHelper} from '../../../../components/html/checkbox-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ProjectItemPageHelper} from '../../items-page/project-item/project-item-page.helper';
import {HomePage} from '../../homepage/home.po';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ProjectItemPage} from '../../items-page/project-item/project-item.po';
import {PlannerSettingPage} from './planner-setting.po';

export class PlannerSettingsPageHelper {
    static async expandPlannerSettingsNode() {
        if (await PlannerSettingPage.collapsedMode.isPresent()) {
            await PageHelper.click(PlannerSettingPage.collapsedMode);
        }
    }

    static get menu() {
        const menuTitles = PlannerSettingsPageConstants.menuTitles;
        const leftMenus = PlannerSettingsPageConstants.leftMenus;
        return {
            menuTitles: {
                planName: ElementHelper.getElementByText(menuTitles.plannerAdministration.planName),
                souceList: ElementHelper.getElementByText(menuTitles.plannerAdministration.sourceList),
                taskList: ElementHelper.getElementByText(menuTitles.plannerAdministration.taskList),
                editPlanner: ElementHelper.getElementByText(menuTitles.plannerAdministration.editPlanner),
                deletePlanner: ElementHelper.getElementByText(menuTitles.plannerAdministration.deletePlanner),
                newPlanner: element(By.id(menuTitles.plannerAdministration.newPlanner)),
                backToSetting: ElementHelper.getElementByText(menuTitles.plannerAdministration.backToSetting),

            },
            buttonLabel: {
                planner: ElementHelper.getElementByText(leftMenus.planners),
            }
        };
    }

    static get visibleLabels() {
        const labels = PlannerSettingsPageConstants.labels;
        return {
            dropDown: {
                projectRequest: ElementHelper.getElementByText(labels.projectRequest)
            }
        };
    }

    static selectedSourceList(value: String) {
        return element(By.xpath(`.//*[@selected='selected' and text()='${value}']`));
    }

    static async createPlanner(name: string) {

        await PageHelper.click(CommonPage.sidebarMenus.settings);
        await PlannerSettingsPageHelper.expandPlannerSettingsNode();
        await PageHelper.click(PlannerSettingsPageHelper.menu.buttonLabel.planner);
        await PageHelper.click(PlannerSettingsPageHelper.menu.menuTitles.newPlanner);
        await TextboxHelper.sendKeys(PlannerSettingPage.planNameField, name);
        await TextboxHelper.sendKeys(PlannerSettingPage.planDiscriptionField,
            PlannerSettingsPageConstants.newPlannerDetails.description);
        await ElementHelper.scrollToElement(PlannerSettingPage.startSoonCheckBox);
        await CheckboxHelper.markCheckbox(PlannerSettingPage.startSoonCheckBox, true);
        await ElementHelper.scrollToBottomOfPage();
        await PageHelper.click(PlannerSettingPage.saveButton);
    }

    static async saveAndVerifyCreatePlanner(name: string, stepLogger: StepLogger, navigatedTOCreatedPlanner: Boolean ) {

        stepLogger.stepId(5);
        stepLogger.step('Scroll down to end of page');
        await ElementHelper.scrollToBottomOfPage();

        stepLogger.step('Click on Save Settings button');
        await PageHelper.click(PlannerSettingPage.saveButton);

        stepLogger.verification('"Planner Settings" page is closed');
        await expect(await browser.getTitle()).not.toBe(PlannerSettingsPageConstants.plannerPage,
            ValidationsHelper.getNotDisplayedValidation(PlannerSettingsPageConstants.plannerPage));

        stepLogger.verification('Planner Administration page is displayed');
        await expect(await browser.getTitle()).toBe(PlannerSettingsPageConstants.administration,
            ValidationsHelper.getPageDisplayedValidation(PlannerSettingsPageConstants.administration));

        stepLogger.verification('Newly created Planner [Ex: Smoke Test Planner 1] is displayed in the list');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(name)))
            .toBe(true, ValidationsHelper.getRecordCreatedValidation(name));

        stepLogger.stepId(6);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');

        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.verification('Project Center page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(7);
        stepLogger.step('Select the project created as per pre requisites [Ex: Smoke Test Project 2]');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.project);
        const projectName = await ElementHelper.getText(CommonPage.project);
        await PageHelper.click(CommonPage.project);

        stepLogger.step('Click on the ITEMS tab above the grid\n' +
            'From the ITEMS ribbon menu, click on Edit Plan');
        await PageHelper.click(CommonPage.editPlan);

        stepLogger.verification('Select Planner pop-up displays with different planner options to select');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.selectPlanner));

        stepLogger.verification('Newly created Planner [Ex: Smoke Test Planner 1] is displayed in the list');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(name)))
            .toBe(true, ValidationsHelper.getRecordCreatedValidation(name));
        await PageHelper.switchToDefaultContent();

        if (navigatedTOCreatedPlanner === true) {
            await this.navigatedTOCreatedPlanner(name, stepLogger, projectName );
        }
    }

    static async navigatedTOCreatedPlanner(name: string, stepLogger: StepLogger, projectName: string) {

        stepLogger.stepId(8);
        stepLogger.step('Select the newly added planner [Ex: Smoke Test Planner 1] in Select Planner pop up');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ElementHelper.getElementByText(name));

        stepLogger.verification('Selected Project is opened using the Newly created Planner [Ex: Smoke Test Planner 1]');
        // After select project Planner wait required, not element found which can use with waitHelper.
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await expect(await browser.getTitle()).toContain(projectName,
            ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.project));
        await expect(await browser.getTitle()).toContain(name,
            ValidationsHelper.getDisplayedValidation(name));

        stepLogger.stepId(9);
        stepLogger.step('Click Close button in Project Planner window [Ex: Smoke Test Planner 1]');
        await PageHelper.click(ProjectItemPage.close);

        stepLogger.stepId(10);
        stepLogger.step('Click on Leave button in the confirmation dialog');
        await browser.switchTo().alert().accept();

        stepLogger.verification('Project Planner window [Ex: Smoke Test Planner 1] is closed');
        await WaitHelper.waitForElementToBeClickable(CommonPage.editPlan);
        await expect(await CommonPage.pageHeaders.projects.projectPlanner.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.verification('Project Center page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
    }
}
