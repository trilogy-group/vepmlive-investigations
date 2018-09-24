import {StepLogger} from '../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../helpers/suite-names';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {ProjectItemPageConstants} from '../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {ProjectItemPage} from '../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ElementHelper} from '../../../../components/html/element-helper';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';

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

    it('Launch "Assignment Planner" - [743177]', async () => {
        StepLogger.caseId = 743177;
        StepLogger.stepId(1);
        StepLogger.step('Select "Navigation" icon  from left side menu');
        StepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(3);
        StepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        StepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        StepLogger.stepId(4);
        StepLogger.step('Select few resources from "Current Team" using check boxes');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await PageHelper.click(ProjectItemPage.teamRecords.currentTeam.get(0));
        await PageHelper.click(ProjectItemPage.teamRecords.currentTeam.get(1));

        StepLogger.step('Click on "Assignment Planner" displayed on top of "Edit Team" window');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.assignmentPlanner);
        await PageHelper.click(CommonPage.ribbonItems.assignmentPlanner);

        // Assignment planner takes around 10 seconds to Loading view and Randering data
        await WaitHelper.staticWait(10000);

        StepLogger.step('switch to default context');
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"Assignment Planner" is displayed in new window');
        // It needs 2nd element from list of webElements else it always picking up Edit team as title and assertion is getting failed
        await expect(await CommonPage.dialogTitles.get(1).getText())
            .toBe(CommonPageConstants.ribbonLabels.assignmentPlanner,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.assignmentPlanner));

        StepLogger.step('Switch to Assignment Planner frame');
        await PageHelper.switchToFrame(ProjectItemPage.assignmentPlannerFrame);

        StepLogger.stepId(5);
        StepLogger.step('Click "Close" button in "Assignment Planner" window');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.close);
        await PageHelper.click(CommonPage.ribbonItems.close);

        StepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"Assignment Planner" window is closed');
        // It needs 2nd element from list of webElements else it always picking up Edit team as title and assertion is getting failed
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitles.get(1)))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.assignmentPlanner));

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame();
        StepLogger.stepId(6);
        StepLogger.step('Click "Close" button in "Edit Team" window');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.close);
        await PageHelper.click(CommonPage.ribbonItems.close);

        StepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        StepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
    });

    it('View the options under "Reports" drop-down" - [743178]', async () => {
        StepLogger.caseId = 743178;
        StepLogger.stepId(1);
        StepLogger.step('Select "Navigation" icon  from left side menu');
        StepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(3);
        StepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        StepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        StepLogger.stepId(4);
        StepLogger.step('Select few resources from "Current Team" using check boxes');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await PageHelper.click(ProjectItemPage.teamRecords.currentTeam.get(0));
        await PageHelper.click(ProjectItemPage.teamRecords.currentTeam.get(1));

        StepLogger.step('Click on "view Reports" drop down displayed on top of "Edit Team" window');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.viewReports);
        await PageHelper.click(CommonPage.ribbonItems.viewReports);

        StepLogger.verification('Following options are displayed');
        StepLogger.verification('Resource Available vs. Planned by Dept');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceAvailableVsPlannedByDept))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceAvailableVsPlannedByDept));

        StepLogger.verification('Resource Capacity Heat Map');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceCapacityHeatMap))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceCapacityHeatMap));

        StepLogger.verification('Resource Commitments');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceCommitments))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceCommitments));

        StepLogger.verification('Resource Requirements');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceRequirements))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceRequirements));

        StepLogger.verification('Resource Work vs. Capacity');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceWorkVsCapacity))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.resourceWorkVsCapacity));

        StepLogger.stepId(5);
        StepLogger.step('Click "Close" button in "Edit Team" window');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.viewReports);
        await ElementHelper.actionClick(CommonPage.ribbonItems.viewReports);

        // view Reports dropdown takes 2-3 seconds time to close and after that only close button is accessible else it thows exception
        await WaitHelper.staticWait(PageHelper.timeout.s);

        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.close);
        await PageHelper.click(CommonPage.ribbonItems.close);

        StepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        StepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
    });

});
