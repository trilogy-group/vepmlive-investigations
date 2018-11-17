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
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {ProjectItemPageHelper} from '../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {EditTeamPageHelper} from '../../../../page-objects/pages/items-page/project-item/edit-team-page/edit-team-page.helper';
import {ExpectationHelper} from '../../../../components/misc-utils/expectation-helper';

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

    /* #UNSTABLE
    it('Launch Build Team from Project Center - [743139]', async () => {
        StepLogger.caseId = 743139;
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
        await ElementHelper.actionHoverOver(CommonPage.getNthRecord());
        await PageHelper.click(CommonPage.getNthRecord());

        StepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeamButton);
        await PageHelper.click(CommonPage.ribbonItems.editTeamButton);

        StepLogger.verification('"Edit Team" window is displayed');
        await ProjectItemPageHelper.waitForBuildTeamPageToOpenAndSwitchToPage();

        // If we able to access Close button under Build Team tab that means Build tab is selected
        StepLogger.verification('"Build Team" tab is selected by default');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.close))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.close));

        StepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        StepLogger.stepId(4);
        StepLogger.step('Click "Close" button in "Edit Team" window');
        await EditTeamPageHelper.closeEditTeamPopUpAndSwitchToDefaultContent();

        StepLogger.verification('"Edit Team" window is closed');
        await ExpectationHelper.verifyNotDisplayedStatus(
            CommonPage.dialogTitle, CommonPageConstants.ribbonLabels.editTeam);

        StepLogger.verification('"Project Center" page is displayed');
        await ExpectationHelper.verifyDisplayedStatus(
            CommonPage.pageHeaders.projects.projectsCenter, CommonPageConstants.pageHeaders.projects.projectCenter);

        StepLogger.verification('All previously created Projects are displayed');
        await ExpectationHelper.verifyDisplayedStatus(
            CommonPage.record, ProjectItemPageConstants.inputLabels.projectName);
    });
    */

    it('Launch Build Team from Project Center - Ellipsis icon - [743140]', async () => {
        StepLogger.caseId = 743139;
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
        StepLogger.step('Mouse over on any Project created as per pre requisites');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        StepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);
        StepLogger.step('select "Edit Team" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await ProjectItemPageHelper.waitForBuildTeamPageToOpenAndSwitchToPage();

        // If we able to access Close button under Build Team tab that means Build tab is selected
        StepLogger.verification('"Build Team" tab is selected by default');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.close))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.close));

        StepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam));

        StepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        StepLogger.stepId(4);
        StepLogger.step('Click "Close" button in "Edit Team" window');
        await EditTeamPageHelper.closeEditTeamPopUpAndSwitchToDefaultContent();

        StepLogger.verification('"Edit Team" window is closed');
        await ExpectationHelper.verifyNotDisplayedStatus(
            CommonPage.dialogTitle, CommonPageConstants.ribbonLabels.editTeam);

        StepLogger.verification('"Project Center" page is displayed');
        await ExpectationHelper.verifyDisplayedStatus(
            CommonPage.pageHeaders.projects.projectsCenter, CommonPageConstants.pageHeaders.projects.projectCenter);

        StepLogger.verification('All previously created Projects are displayed');
        await ExpectationHelper.verifyDisplayedStatus(
            CommonPage.record, ProjectItemPageConstants.inputLabels.projectName);
    });

    it('Navigate to Edit Costs page - [966345]', async () => {
        StepLogger.caseId = 966345;
        const uniqueId = PageHelper.getUniqueId();
        const toolButtons = ProjectItemPage.toolButtons;
        const periodButtons = ProjectItemPage.periodButtons;

        StepLogger.step('Create a new project and navigate to Item page');
        await ProjectItemPageHelper.createProject(uniqueId);

        StepLogger.verification('Verify Resource Pool is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.itemOptions.editCourse))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.itemOptions.editCourse));

        StepLogger.stepId(1);
        StepLogger.step('Click on Edit Costs icon from the button menu');
        await PageHelper.click(ProjectItemPage.itemOptions.editCourse);

        StepLogger.stepId(2);
        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('Check options displayed in Cost Planner window in Plan Actions - Close button');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.planActionButtons.close))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.planActionButtons.close));

        StepLogger.verification('Check options displayed in Cost Planner window in Plan Actions - Save button');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.planActionButtons.save))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.planActionButtons.save));

        StepLogger.verification('Check options displayed in Cost Planner window in Tools - categories button');
        await expect(await PageHelper.isElementDisplayed(toolButtons.categories))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.toolButtons.categories));

        StepLogger.verification('Check options displayed in Cost Planner window in Tools - delete button');
        await expect(await PageHelper.isElementDisplayed(toolButtons.delete))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.toolButtons.delete));

        StepLogger.verification('Check options displayed in Cost Planner window in Tools - details button');
        await expect(await PageHelper.isElementDisplayed(toolButtons.detail))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.toolButtons.detail));

        StepLogger.verification('Check options displayed in Cost Planner window in Tools - show reference button');
        await expect(await PageHelper.isElementDisplayed(toolButtons.showReference))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.toolButtons.showReference));

        StepLogger.verification('Check options displayed in Cost Planner window in Periods - from period button');
        await expect(await PageHelper.isElementDisplayed(periodButtons.fromPeriod))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.periodfields.fromPeriod));

        StepLogger.verification('Check options displayed in Cost Planner window in Periods - to period button');
        await expect(await PageHelper.isElementDisplayed(periodButtons.toPeriod))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.periodfields.toPeriod));
    });
});
