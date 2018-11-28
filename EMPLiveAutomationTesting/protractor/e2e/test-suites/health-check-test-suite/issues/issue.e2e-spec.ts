import {PageHelper} from '../../../components/html/page-helper';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {IssueItemPageHelper} from '../../../page-objects/pages/items-page/issue-item/issue-item-page.helper';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {LoginPageHelper} from '../../../page-objects/pages/login/login-page.helper';
import {ProjectItemSubPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.subhelper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;
    let projectName = '';

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    beforeAll(async () => {
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
        const uniqueId = PageHelper.getUniqueId();
        projectName = await ProjectItemSubPageHelper.createProjectIfNoProjectCreated(uniqueId);
        await LoginPageHelper.logout();
    });

    afterAll(async () => {
        if (projectName !== '') {
            loginPage = new LoginPage();
            await loginPage.goToAndLogin();
            await ProjectItemSubPageHelper.navigateToProjectPage();
            await ProjectItemPageHelper.deleteProjectAndValidateIt(projectName);
            await LoginPageHelper.logout();
        }
    });

    it('Add, Edit and Delete Issue - [829740]', async () => {
        StepLogger.caseId = 829740;
        StepLogger.stepId(1);
        let titleValue = await IssueItemPageHelper.createIssueAndValidateIt();

        StepLogger.stepId(2);
        titleValue = await IssueItemPageHelper.editItemAndValidateIt(titleValue);

        StepLogger.stepId(3);
        await IssueItemPageHelper.deleteItemAndValidateIt(titleValue);
    });

});
