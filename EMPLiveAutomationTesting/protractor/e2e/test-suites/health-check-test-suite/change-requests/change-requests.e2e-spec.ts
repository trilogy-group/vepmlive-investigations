import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {ChangeItemPageHelper} from '../../../page-objects/pages/items-page/change-item/change-item-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add, Edit and Delete Change - [829742]', async () => {
        const stepLogger = new StepLogger(829742);
        stepLogger.stepId(1);
        let titleValue = await ChangeItemPageHelper.createNewChangeAndValidateIt(stepLogger);

        stepLogger.stepId(2);
        titleValue = await ChangeItemPageHelper.editChangeAndValidateIt(stepLogger, titleValue);

        stepLogger.stepId(3);
        await ChangeItemPageHelper.deleteChangeAndValidateIt(stepLogger, titleValue);

    });
});
