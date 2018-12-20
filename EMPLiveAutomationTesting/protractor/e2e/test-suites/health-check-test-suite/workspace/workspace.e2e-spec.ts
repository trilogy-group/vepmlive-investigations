import {PageHelper} from '../../../components/html/page-helper';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {WorkspacePageHelper} from '../../../page-objects/pages/workspaces/workspace-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('To Verify User is Able to Create Workspace - [2488594]', async () => {
        StepLogger.caseId = 2488594;
        await WorkspacePageHelper.createWorkspace();
    });
});
