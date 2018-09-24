import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ResourcesPageHelper} from '../../../../page-objects/pages/navigation/resources/resources-page.helper';
import {DepartmentsPageHelper} from '../../../../page-objects/pages/settings/user-management/departments/departments-page.helper';

describe(SuiteNames.regressionTestSuite, () => {

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
    });

    it('Create a new department - [15438965]', async () => {
        StepLogger.caseId = 15438965;
        StepLogger.stepId(1);
        await DepartmentsPageHelper.navigateToDepartments();
        await DepartmentsPageHelper.verifyDepartmentsPageDisplayed();

        StepLogger.stepId(2);
        await DepartmentsPageHelper.clickAddNewItem();
        await DepartmentsPageHelper.verifyAddPageDisplayed();

        StepLogger.stepId(3);
        const title = await DepartmentsPageHelper.enterNewTitle();
        await DepartmentsPageHelper.verifyTitleEntered(title,);

        StepLogger.stepId(4);
        const selectedManagerUser = await DepartmentsPageHelper.selectManagersField();
        await DepartmentsPageHelper.verifySelectedManagersField(selectedManagerUser,);

        StepLogger.stepId(5);
        const selectedExecutivesUser = await DepartmentsPageHelper.selectExecutivesField();
        await DepartmentsPageHelper.verifySelectedExecutivesField(selectedExecutivesUser,);

        StepLogger.stepId(6);
        await DepartmentsPageHelper.clickSave();
        await DepartmentsPageHelper.verifyDepartmentCreated(title,);
    });

    it('Create an enabled resource and a disabled resource - [15438973]', async () => {
        StepLogger.caseId = 15438973;
        // Step 1 is in precondition
        StepLogger.stepId(2);
        await ResourcesPageHelper.navigateToResourcesPage();
        await ResourcesPageHelper.verifyResourcesPageDisplayed();

        StepLogger.stepId(3);
        await ResourcesPageHelper.clickNewInviteLink();
        await ResourcesPageHelper.verifyCreateUserPageDisplayed();

        StepLogger.stepId(4);
        const displayName = await ResourcesPageHelper.fillCreateUserForm();

        StepLogger.stepId(5);
        await ResourcesPageHelper.clickSave();
        await ResourcesPageHelper.verifyResourceSaved(displayName,);
    });
});
