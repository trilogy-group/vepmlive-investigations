import {PageHelper} from '../../../components/html/page-helper';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {RiskItemPageHelper} from '../../../page-objects/pages/items-page/risk-item/risk-item-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Add, Edit and Delete Risk- [829719]', async () => {
        const stepLogger = new StepLogger(829719);
        stepLogger.stepId(1);
        let titleValue = await RiskItemPageHelper.createRiskAndValidateIt(stepLogger);

        stepLogger.step('Edit Risk');
        titleValue = await RiskItemPageHelper.editRiskAndValidateIt(stepLogger, titleValue );

        stepLogger.step('Select a Risk and Click on "ITEMS" >> Delete Item');

        await RiskItemPageHelper.deleteRiskAndValidateIt(stepLogger, titleValue );
    });
});
