import { StepLogger } from '../../../../../core/logger/step-logger';
import { PageHelper } from '../../../../components/html/page-helper';
import { CommonPageHelper } from '../../../../page-objects/pages/common/common-page.helper';
import { HomePage } from '../../../../page-objects/pages/homepage/home.po';
import { SuiteNames } from '../../../helpers/suite-names';
import { CommonPage } from '../../../../page-objects/pages/common/common.po';
import { CommonPageConstants } from '../../../../page-objects/pages/common/common-page.constants';
import { WaitHelper } from '../../../../components/html/wait-helper';
import { ProjectItemPageConstants } from '../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import { ValidationsHelper } from '../../../../components/misc-utils/validation-helper';
import { ProjectItemPage } from '../../../../page-objects/pages/items-page/project-item/project-item.po';
import { browser, by } from 'protractor';
import { ElementHelper } from '../../../../components/html/element-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
        await browser.findElement(by.id('ctl00_PlaceHolderMain_signInControl_UserName')).sendKeys('admin.user');
        await browser.findElement(by.id('ctl00_PlaceHolderMain_signInControl_password')).sendKeys('Pass@word1');
        await browser.findElement(by.id('ctl00_PlaceHolderMain_signInControl_login')).click();
    });

    /*it('Launch "Assignment Planner" - [743177]', async () => {
        const stepLogger = new StepLogger(743177);
        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        stepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        stepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        stepLogger.stepId(4);
        stepLogger.step('Select few resources from "Current Team" using check boxes');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await PageHelper.click(ProjectItemPage.teamRecords.currentTeam.get(0));
        await PageHelper.click(ProjectItemPage.teamRecords.currentTeam.get(1));

        stepLogger.step('Click on "Assignment Planner" displayed on top of "Edit Team" window');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.assignmentPlanner);
        await PageHelper.click(CommonPage.ribbonItems.assignmentPlanner);

        // Assignment planner takes around 10 seconds to Loading view and Randering data
        await WaitHelper.getInstance().staticWait(10000);

        stepLogger.step('switch to default context');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Assignment Planner" is displayed in new window');
        // It needs 2nd element from list of webElements else it always picking up Edit team as title and assertion is getting failed
        await expect(await CommonPage.dialogTitles.get(1).getText())
            .toBe(CommonPageConstants.ribbonLabels.assignmentPlanner,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.assignmentPlanner));

        stepLogger.step('Switch to Assignment Planner frame');
        await PageHelper.switchToFrame(ProjectItemPage.assignmentPlannerFrame);

        stepLogger.stepId(5);
        stepLogger.step('Click "Close" button in "Assignment Planner" window');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.close);
        await PageHelper.click(CommonPage.ribbonItems.close);

        stepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Assignment Planner" window is closed');
        // It needs 2nd element from list of webElements else it always picking up Edit team as title and assertion is getting failed.
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitles.get(1)))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.assignmentPlanner));

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.stepId(6);
        stepLogger.step('Click "Close" button in "Edit Team" window');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.close);
        await PageHelper.click(CommonPage.ribbonItems.close);

        stepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
    });*/

    it('Launch "Assignment Planner" - [743177]', async () => {
        const stepLogger = new StepLogger(743177);
        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        stepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        stepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        stepLogger.stepId(4);
        stepLogger.step('Select few resources from "Current Team" using check boxes');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await PageHelper.click(ProjectItemPage.teamRecords.currentTeam.get(0));
        await PageHelper.click(ProjectItemPage.teamRecords.currentTeam.get(1));

        stepLogger.step('Click on "view Reports" drop down displayed on top of "Edit Team" window');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.viewReports);
        await PageHelper.click(CommonPage.ribbonItems.viewReports);

        stepLogger.verification('Following options are displayed');
        stepLogger.verification('Resource Available vs. Planned by Dept');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceAvailableVsPlannedByDept))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceAvailableVsPlannedByDept));

        stepLogger.verification('Resource Capacity Heat Map');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceCapacityHeatMap))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceCapacityHeatMap));

        stepLogger.verification('Resource Commitments');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceCommitments))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceCommitments));

        stepLogger.verification('Resource Requirements');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceRequirements))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceRequirements));

        stepLogger.verification('Resource Work vs. Capacity');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceWorkVsCapacity))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceWorkVsCapacity));

        stepLogger.stepId(5);
        stepLogger.step('Click "Close" button in "Edit Team" window');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.viewReports);
        await ElementHelper.actionClick(CommonPage.ribbonItems.viewReports);

        // view Reports dropdown takes 2-3 seconds time to close and after that only close button is accessible else it thows exception
        WaitHelper.getInstance().staticWait(3000);

        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.close);
        await PageHelper.click(CommonPage.ribbonItems.close);

        stepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
    });
});
