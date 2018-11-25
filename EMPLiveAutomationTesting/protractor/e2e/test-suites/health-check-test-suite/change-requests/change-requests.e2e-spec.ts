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

    afterEach(async () => {
        await StepLogger.takeScreenShot();
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
