import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {ChangeItemPageHelper} from '../../../page-objects/pages/items-page/change-item/change-item-page.helper';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {LoginPageHelper} from '../../../page-objects/pages/login/login-page.helper';
import {ProjectItemSubPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.subhelper';
import {Constants} from '../../../components/misc-utils/constants';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;
    let projectName = '';

    beforeAll(async () => {
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
        const uniqueId = PageHelper.getUniqueId();
        projectName = await ProjectItemSubPageHelper.createProjectIfNoProjectCreated(uniqueId);
        await LoginPageHelper.logout();
    });

    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
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

    it('Add, Edit and Delete Change - [829742]', async () => {
        StepLogger.caseId = 829742;
        StepLogger.stepId(1);
        let titleValue = await ChangeItemPageHelper.createNewChangeAndValidateIt();

        StepLogger.stepId(2);
        titleValue = await ChangeItemPageHelper.editChangeAndValidateIt(titleValue);

        StepLogger.stepId(3);
        await ChangeItemPageHelper.deleteChangeAndValidateIt(titleValue);

    });
});
