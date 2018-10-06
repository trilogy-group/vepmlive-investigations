import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {RiskItemPageHelper} from '../../../page-objects/pages/items-page/risk-item/risk-item-page.helper';

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

    it('Add, Edit and Delete Risk- [829719]', async () => {
        StepLogger.caseId = 829719;
        StepLogger.stepId(1);
        let titleValue = await RiskItemPageHelper.createRiskAndValidateIt();

        titleValue = await RiskItemPageHelper.editRiskAndValidateIt(titleValue);

        await RiskItemPageHelper.deleteRiskAndValidateIt(titleValue);
    });
});
