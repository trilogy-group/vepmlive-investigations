import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import { WorkspacePageHelper } from '../../../../../page-objects/pages/workspaces/workspace-page.helper';
import { CommonPage } from '../../../../../page-objects/pages/common/common.po';
import { ValidationsHelper } from '../../../../../components/misc-utils/validation-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Create Workspace Functionality - [1124282]', async () => {
        const stepLogger = new StepLogger(1124282);
        await WorkspacePageHelper.createWorkspace(stepLogger);
    });

    it('To Verify User is able to view notification after Creating Workspace Using a Project Template - [1175091]', async () => {
        const stepLogger = new StepLogger(1175091);
        const title = await WorkspacePageHelper.createWorkspace(stepLogger);

        stepLogger.stepId(5);
        stepLogger.step(`Click on 'Person' button displayed on left side of user name on top right side of page`);
        await PageHelper.click(CommonPage.personIcon);

        stepLogger.verification(`Notification 'Your Workspace <Name of Workspace entered in step# 3> is now ready!' displayed in the pop down`)
        await expect(await CommonPage.latestNotification.getText())
        .toBe(title, ValidationsHelper.getLabelDisplayedValidation(title));

    });

});
