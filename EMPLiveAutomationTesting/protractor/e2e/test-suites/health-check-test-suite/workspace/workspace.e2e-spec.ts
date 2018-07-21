import {PageHelper} from '../../../components/html/page-helper';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {WorkspacePageHelper} from '../../../page-objects/pages/workspaces/workspace-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Create and Remove Workspace - [829751]', async () => {
        const stepLogger = new StepLogger(829751);
        const title = await WorkspacePageHelper.createWorkspace(stepLogger);
        await WorkspacePageHelper. validateLatestNotification(stepLogger , title );
    });
});
