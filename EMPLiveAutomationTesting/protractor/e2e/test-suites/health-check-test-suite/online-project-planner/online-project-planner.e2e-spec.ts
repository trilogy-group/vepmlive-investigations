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
    it('Add, Edit and Delete Project - [829527]', async () => {
        const stepLogger = new StepLogger(829527);
        stepLogger.stepId(1);
        // Step #1 Inside this function
        const uniqueId = PageHelper.getUniqueId();

        let projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId, stepLogger);

        projectNameValue = await ProjectItemPageHelper.editProjectAndValidateIt(stepLogger, projectNameValue);

        await ProjectItemPageHelper.deleteProjectAndValidateIt(stepLogger, projectNameValue);
    });
});
