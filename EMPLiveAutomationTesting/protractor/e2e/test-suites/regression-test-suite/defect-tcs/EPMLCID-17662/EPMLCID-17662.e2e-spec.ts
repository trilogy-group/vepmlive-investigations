import {SuiteNames} from '../../../helpers/suite-names';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../components/html/page-helper';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {ResourcesPageHelper} from '../../../../page-objects/pages/navigation/resources/resources-page.helper';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {ResourcePlannerPageHelper} from '../../../../page-objects/pages/resource-planner-page/resource-planner-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let stepLogger: StepLogger;
    let displayName: string;

    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
    });

    fit('Part-1 Disable one resource - [15377923]', async () => {
        stepLogger.caseId = 15377923;
        stepLogger.stepId(1);
        await ResourcesPageHelper.navigateToResourcesPage(stepLogger);
        await ResourcesPageHelper.hoverOnResource(stepLogger);
        await ResourcesPageHelper.verifyEllipsisDisplayed(stepLogger);

        stepLogger.stepId(2);
        await ResourcesPageHelper.clickOnEllipsis(stepLogger);
        await ResourcesPageHelper.verifyMenuItemDisplayed(stepLogger);

        stepLogger.stepId(3);
        await ResourcesPageHelper.clickOnEditItem(stepLogger);
        await ResourcesPageHelper.editResourcePageDisplayed(stepLogger);

        stepLogger.stepId(4);
        displayName = await ResourcesPageHelper.getDisplayNameInEditResourcePage(stepLogger);
        await ResourcesPageHelper.selectDisabled(stepLogger);
        await ResourcesPageHelper.verifyDisabledChecked(stepLogger);

        stepLogger.stepId(5);
        await ResourcesPageHelper.clickSave(stepLogger);
        await ResourcesPageHelper.verifyResourceSaved(displayName, stepLogger);
    });

    fit('Part-2 Check disabled resource in resource Planner - [15377921]', async () => {
        stepLogger.caseId = 15377921;
        // precondition
        await CommonPageHelper.navigateToProjectCenter(stepLogger);

        // Step 1 and 2 are inside below function
        stepLogger.stepId(1);
        stepLogger.stepId(2);
        await CommonPageHelper.selectProjectAndClickEllipsisButton(stepLogger);
        await CommonPageHelper.verifyContextMenuDisplayed(stepLogger);

        stepLogger.stepId(3);
        await CommonPageHelper.clickEditResourcePlan(stepLogger);
        await ResourcePlannerPageHelper.verifyResourcePlanDisplayed(stepLogger);

        stepLogger.stepId(4);
        await ResourcePlannerPageHelper.verifyDisabledResourceNotDisplayed(displayName, stepLogger);
    });
});
