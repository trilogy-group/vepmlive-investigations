import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {RiskItemPageHelper} from '../../../page-objects/pages/items-page/risk-item/risk-item-page.helper';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {LoginPageHelper} from '../../../page-objects/pages/login/login-page.helper';
import {ProjectItemSubPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.subhelper';
import {Constants} from '../../../components/misc-utils/constants';

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
        if (projectName !== Constants.EMPTY_STRING) {
            loginPage = new LoginPage();
            await loginPage.goToAndLogin();
            await ProjectItemSubPageHelper.navigateToProjectPage();
            await ProjectItemPageHelper.deleteProjectAndValidateIt(projectName);
            await LoginPageHelper.logout();
        }
    });

    it('Add, Edit and Delete Risk- [829719]', async () => {
        StepLogger.caseId = 829719;
        StepLogger.stepId(1);
        let titleValue = await RiskItemPageHelper.createRiskAndValidateIt();

        titleValue = await RiskItemPageHelper.editRiskAndValidateIt(titleValue);

        await RiskItemPageHelper.deleteRiskAndValidateIt(titleValue);
    });
});
