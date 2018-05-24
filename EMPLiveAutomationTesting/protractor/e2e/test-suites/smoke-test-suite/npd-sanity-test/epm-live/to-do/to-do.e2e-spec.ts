import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {ToDoPageHelper} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ToDoPageConstants} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.constants';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {ToDoPage} from '../../../../../page-objects/pages/my-workplace/to-do/to-do.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Navigate to To Do page - [785576]', async () => {
        const stepLogger = new StepLogger(785576);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);
    });

    it('Add a To Do item - [785580]', async () => {
        const stepLogger = new StepLogger(785580);
        stepLogger.step('PRECONDITION: navigate to To Do page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click on "+ new link" link displayed on top of "Discussions" page');
        await PageHelper.click(CommonPage.addNewLink);
        stepLogger.verification('"To Do - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.pageName));

        stepLogger.stepId(2);
        stepLogger.step(`Enter/Select below details in 'New To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.notStarted;
        const description = `${labels.description} ${uniqueId}`;
        // step#3 is inside this function
        await ToDoPageHelper.fillFormAndSave(title, status, description, stepLogger);

        stepLogger.stepId(4);
        stepLogger.step(`click on Close button`);
        await PageHelper.click(ToDoPage.closeButton.first());
        stepLogger.verification(`To Do page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.toDo))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
    });

    it('Edit To Do from Workplace - [785584]', async () => {
        const stepLogger = new StepLogger(785584);
        stepLogger.step('PRECONDITION: Navigate to To Page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);

        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.actionTakenViaContextMenu(stepLogger, CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.editItem);
        stepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.editPageName));

        stepLogger.stepId(3);
        stepLogger.step(`Enter/Select below details in 'Edit To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.inProgress;
        const description = `${labels.description} ${uniqueId}`;
        await ToDoPageHelper.fillFormAndSave(title, status, description, stepLogger);
        stepLogger.verification(`'Edit To Do' page is closed`);
        await expect(await ToDoPage.inputs.title.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ToDoPageConstants.editPageName));
        stepLogger.verification(`To Do page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.toDo))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
    });

    it('Attach File - [852049]', async () => {

    });
});
