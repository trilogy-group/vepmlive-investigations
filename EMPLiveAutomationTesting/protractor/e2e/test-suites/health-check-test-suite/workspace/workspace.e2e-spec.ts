import {PageHelper} from '../../../components/html/page-helper';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {WorkspacePageHelper} from '../../../page-objects/pages/workspaces/workspace-page.helper';
import {browser} from 'protractor';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';

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
        stepLogger.step('Refresh the page and wait till the notification about completion of workspace ');
        await PageHelper.click(CommonPage.personIcon);
        let maxAttempts = 0;
        while (!((await CommonPage.latestNotification.getText()).includes(title.replace('* ', ''))) && maxAttempts < 10) {
            maxAttempts++;
            browser.refresh();
            await PageHelper.click(CommonPage.personIcon);
            await browser.sleep(PageHelper.timeout.xs);
        }
        stepLogger.verification(`Notification 'Your Workspace <Name of Workspace entered in step# 3> is now ready!'
        displayed in the pop down`);
        await expect(await CommonPage.latestNotification.getText())
            .toContain(title.replace('* ', ''), ValidationsHelper.getLabelDisplayedValidation(title));

    });

});
