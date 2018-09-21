import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ResourcesPageHelper} from '../../../../page-objects/pages/navigation/resources/resources-page.helper';
import {DepartmentsPageHelper} from '../../../../page-objects/pages/settings/user-management/departments/departments-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
    });

    it('Create a new department - [15438965]', async () => {
        stepLogger.caseId = 15438965;
        stepLogger.stepId(1);
        await DepartmentsPageHelper.navigateToDepartments(stepLogger);
        await DepartmentsPageHelper.verifyDepartmentsPageDisplayed(stepLogger);

        stepLogger.stepId(2);
        await DepartmentsPageHelper.clickAddNewItem(stepLogger);
        await DepartmentsPageHelper.verifyAddPageDisplayed(stepLogger);

        stepLogger.stepId(3);
        const title = await DepartmentsPageHelper.enterNewTitle(stepLogger);
        await DepartmentsPageHelper.verifyTitleEntered(title, stepLogger);

        stepLogger.stepId(4);
        const selectedManagerUser = await DepartmentsPageHelper.selectManagersField(stepLogger);
        await DepartmentsPageHelper.verifySelectedManagersField(selectedManagerUser, stepLogger);

        stepLogger.stepId(5);
        const selectedExecutivesUser = await DepartmentsPageHelper.selectExecutivesField(stepLogger);
        await DepartmentsPageHelper.verifySelectedExecutivesField(selectedExecutivesUser, stepLogger);

        stepLogger.stepId(6);
        await DepartmentsPageHelper.clickSave(stepLogger);
        await DepartmentsPageHelper.verifyDepartmentCreated(title, stepLogger);
    });

    it('Create an enabled resource and a disabled resource - [15438973]', async () => {
        stepLogger.caseId = 15438973;
        // Step 1 is in precondition
        stepLogger.stepId(2);
        await ResourcesPageHelper.navigateToResourcesPage(stepLogger);
        await ResourcesPageHelper.verifyResourcesPageDisplayed(stepLogger);

        stepLogger.stepId(3);
        await ResourcesPageHelper.clickNewInviteLink(stepLogger);
        await ResourcesPageHelper.verifyCreateUserPageDisplayed(stepLogger);

        stepLogger.stepId(4);
        const displayName = await ResourcesPageHelper.fillCreateUserForm(stepLogger);

        stepLogger.stepId(5);
        await ResourcesPageHelper.clickSave(stepLogger);
        await ResourcesPageHelper.verifyResourceSaved(displayName, stepLogger);
    });
});
