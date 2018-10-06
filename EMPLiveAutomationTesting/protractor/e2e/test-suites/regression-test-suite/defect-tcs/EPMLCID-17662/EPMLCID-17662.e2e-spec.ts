import {SuiteNames} from '../../../helpers/suite-names';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../components/html/page-helper';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {ResourcesPageHelper} from '../../../../page-objects/pages/navigation/resources/resources-page.helper';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {ResourcePlannerPageHelper} from '../../../../page-objects/pages/resource-planner-page/resource-planner-page.helper';

describe(SuiteNames.regressionTestSuite, () => {

    let displayName: string;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
    });

    it('Part-1 Disable one resource - [15377923]', async () => {
        StepLogger.caseId = 15377923;
        StepLogger.stepId(1);
        await ResourcesPageHelper.navigateToResourcesPage();
        await ResourcesPageHelper.hoverOnResource();
        await ResourcesPageHelper.verifyEllipsisDisplayed();

        StepLogger.stepId(2);
        await ResourcesPageHelper.clickOnEllipsis();
        await ResourcesPageHelper.verifyMenuItemDisplayed();

        StepLogger.stepId(3);
        await ResourcesPageHelper.clickOnEditItem();
        await ResourcesPageHelper.editResourcePageDisplayed();

        StepLogger.stepId(4);
        displayName = await ResourcesPageHelper.getDisplayNameInEditResourcePage();
        await ResourcesPageHelper.selectDisabled();
        await ResourcesPageHelper.verifyDisabledChecked();

        StepLogger.stepId(5);
        await ResourcesPageHelper.clickSave();
        await ResourcesPageHelper.verifyResourceSaved(displayName);
    });

    it('Part-2 Check disabled resource in resource Planner - [15377921]', async () => {
        StepLogger.caseId = 15377921;
        // precondition
        await CommonPageHelper.navigateToProjectCenter();

        // Step 1 and 2 are inside below function
        StepLogger.stepId(1);
        StepLogger.stepId(2);
        await CommonPageHelper.selectProjectAndClickEllipsisButton();
        await CommonPageHelper.verifyContextMenuDisplayed();

        StepLogger.stepId(3);
        await CommonPageHelper.clickEditResourcePlan();
        await ResourcePlannerPageHelper.verifyResourcePlanDisplayed();

        StepLogger.stepId(4);
        await ResourcePlannerPageHelper.verifyDisabledResourceNotDisplayed(displayName);
    });
});
