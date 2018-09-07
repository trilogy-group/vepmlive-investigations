import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {RiskItemPageHelper} from '../../../page-objects/pages/items-page/risk-item/risk-item-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Add, Edit and Delete Risk- [829719]', async () => {
        stepLogger.caseId = 829719;
        stepLogger.stepId(1);
        let titleValue = await RiskItemPageHelper.createRiskAndValidateIt(stepLogger);

        titleValue = await RiskItemPageHelper.editRiskAndValidateIt(stepLogger, titleValue);

        await RiskItemPageHelper.deleteRiskAndValidateIt(stepLogger, titleValue);
    });
});
