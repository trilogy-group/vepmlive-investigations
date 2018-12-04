import {PageHelper} from '../../../components/html/page-helper';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {SuiteNames} from '../../helpers/suite-names';
import {StepLogger} from '../../../../core/logger/step-logger';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';

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

    it('cleanup - [1]', async () => {
        StepLogger.caseId = 829527;
        StepLogger.stepId(1);
        // Step #1 Inside this function
        await ProjectItemPageHelper.deleteOptionViaRibbon();
    });
});
