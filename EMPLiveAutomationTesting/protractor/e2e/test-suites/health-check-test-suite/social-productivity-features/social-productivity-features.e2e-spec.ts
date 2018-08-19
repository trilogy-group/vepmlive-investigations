import {StepLogger} from '../../../../core/logger/step-logger';
import {PageHelper} from '../../../components/html/page-helper';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {SocialStreamPageHelper} from '../../../page-objects/pages/settings/social-stream/social-stream-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Add an item from Social Stream - [829790]', async () => {
        const stepLogger = new StepLogger(829790);
        await SocialStreamPageHelper.addStreamAndValidateIt(stepLogger);
    });

});
