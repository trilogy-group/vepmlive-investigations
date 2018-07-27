import {SuiteNames} from "../../../../../helpers/suite-names";
import {LoginPage} from "../../../../../../page-objects/pages/login/login.po";
import {PageHelper} from "../../../../../../components/html/page-helper";
import {StepLogger} from "../../../../../../../core/logger/step-logger";
import {CommonPageHelper} from "../../../../../../page-objects/pages/common/common-page.helper";
import {CommonPageConstants} from "../../../../../../page-objects/pages/common/common-page.constants";
import {OptimizerPage} from '../../../../../../page-objects/pages/items-page/project-item/optimizer-page/optimizer.po';
import {OptimizerPageHelper} from '../../../../../../page-objects/pages/items-page/project-item/optimizer-page/optimizer-page.helper';
import {OptimizerPageConstants} from "../../../../../../page-objects/pages/items-page/project-item/optimizer-page/optimizer-page.constants";
import {browser} from "protractor";
import {WaitHelper} from "../../../../../../components/html/wait-helper";
import {HomePage} from "../../../../../../page-objects/pages/homepage/home.po";
import {CommonPage} from "../../../../../../page-objects/pages/common/common.po";
import {ValidationsHelper} from "../../../../../../components/misc-utils/validation-helper";

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Save View  - [785307]', async () => {
        const stepLogger = new StepLogger(785307);
        //Preconditions -Navigation Panel> Projects> Select project(s)> Click on 'Optimizer'
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.verification('Project Center opened and project selected');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
        await CommonPageHelper.selectRecordFromGrid(stepLogger);
        //optimizer option
        await PageHelper.click(CommonPageHelper.getRibbonButtonByText(CommonPageConstants.ribbonLabels.optimizer));
        stepLogger.verification('"Optimizer" page is displayed');

        await browser.sleep(PageHelper.timeout.m);
        CommonPageHelper.switchToFirstContentFrame();
        stepLogger.stepId(1);
        stepLogger.step('Click on "View" tab');
        // browser.executeScript("arguments[0].click();",OptimizerPage.getTabOptions.viewTab);
        await PageHelper.click(OptimizerPage.getTabOptions.viewTab);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(OptimizerPage.viewManagementOptions.saveView,PageHelper.timeout.s);
        expect(OptimizerPage.viewManagementOptions.saveView.isPresent()).toBe(true);
        stepLogger.verification('View tab details displayed');

        stepLogger.stepId(2);
        stepLogger.step('Click on "Select columns"');
        await PageHelper.click(OptimizerPage.viewManagementOptions.selectColumns);

        //Step #3 is inside this function
        await OptimizerPageHelper.selectColumns(stepLogger);
        stepLogger.stepId(4);
        stepLogger.step('Click on "OK" button');
        await PageHelper.click(OptimizerPage.okButton);
        await browser.sleep(PageHelper.timeout.s);
        await  OptimizerPageHelper.verifyColumnNamesInGrid(stepLogger);
        stepLogger.stepId(5);
        stepLogger.step('Click on "Save View" from ribbon panel');
        await PageHelper.click(OptimizerPage.viewManagementOptions.saveView);
        expect(OptimizerPage.saveViewPopup.viewName.isPresent()).toBe(true);
        stepLogger.verification('Save view popup displayed');

        stepLogger.stepId(6);
        stepLogger.step('Provide "View Name" and check "Personal View" checkbox');
        const uniqueId = PageHelper.getUniqueId();
        const viewName = `${OptimizerPageConstants.newViewName}${uniqueId}`;
        const label= OptimizerPage.saveViewPopup;
        await WaitHelper.getInstance().waitForElementToBeDisplayed(label.viewName,PageHelper.timeout.s);
        await label.viewName.clear();
        await PageHelper.sendKeysToInputField(label.viewName,viewName);
        if(!(label.personalView.isSelected())){
            await PageHelper.click(label.personalView);
        }

        stepLogger.stepId(7);
        stepLogger.step('Click on "Ok" button');
        await PageHelper.click(label.ok);
        await WaitHelper.getInstance().waitForTextToBePresent(OptimizerPage.viewManagementOptions.currentViewDropdown,viewName);
        //Taking time to reflect
        expect(OptimizerPage.viewManagementOptions.currentViewDropdown.getText()).toEqual(viewName);
        stepLogger.verification("View saved and displayed under 'Current View'")

        stepLogger.stepId(8);
        stepLogger.step('Click on "Close"');
        await PageHelper.click(OptimizerPage.getTabOptions.optimizerTab);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(OptimizerPage.getCloseOptimizerWindow,PageHelper.timeout.s);
        await PageHelper.click(OptimizerPage.getCloseOptimizerWindow);
        expect(CommonPageHelper.getRibbonButtonByText(CommonPageConstants.ribbonLabels.optimizer).isPresent()).toBe(true);
        stepLogger.verification("Optimizer window has been closed");

        stepLogger.stepId(9);
        stepLogger.step('From project center page select same projects and click on "Optimizer" button');
        await PageHelper.click(CommonPageHelper.getRibbonButtonByText(CommonPageConstants.ribbonLabels.optimizer));
        stepLogger.verification('"Optimizer" page has been displayed');
        await browser.sleep(PageHelper.timeout.m);
        CommonPageHelper.switchToFirstContentFrame();
        stepLogger.stepId(10);
        stepLogger.step('Go to "View" Tab and Expand "Current View" drop down');
        await PageHelper.click(OptimizerPage.getTabOptions.viewTab);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(OptimizerPage.viewManagementOptions.saveView,PageHelper.timeout.s);
        await OptimizerPageHelper.selectPreviouslySavedView(viewName);

        stepLogger.verification("Previously Saved view has been displayed in the drop down")
        stepLogger.stepId(11);
        stepLogger.step('Select that view');
        //Takes time update the table
        await browser.sleep(PageHelper.timeout.s);
        await OptimizerPageHelper.verifyColumnNamesInGrid(stepLogger);
    });
});