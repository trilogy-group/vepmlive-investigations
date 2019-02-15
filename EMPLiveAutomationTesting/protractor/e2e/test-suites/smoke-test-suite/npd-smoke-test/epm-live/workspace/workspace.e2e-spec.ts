import {browser} from 'protractor';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {WorkspacePageHelper} from '../../../../../page-objects/pages/workspaces/workspace-page.helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';

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

    it('Create Workspace Functionality - [1124282]', async () => {
        StepLogger.caseId = 1124282;
        await WorkspacePageHelper.createWorkspace();
    });

    it('To Verify User is able to view notification after Creating Workspace Using a Project Template - [1175091]', async () => {
        StepLogger.caseId = 1175091;
        const title = await WorkspacePageHelper.createWorkspace();

        StepLogger.stepId(5);
        await browser.sleep(PageHelper.timeout.s);
        StepLogger.step(`Click on 'Person' button displayed on left side of user name on top right side of page`);
        await PageHelper.click(CommonPage.personIcon);

        StepLogger.verification(`Notification 'Your Workspace <Name of Workspace entered in step# 3> is now ready!'
        displayed in the pop down`);
        const bool = await WorkspacePageHelper.verifyWorkSpaceCreated(title.replace('* ', ''));
        expect(bool).toBe(true, ValidationsHelper.getLabelDisplayedValidation(title));
    });

});
