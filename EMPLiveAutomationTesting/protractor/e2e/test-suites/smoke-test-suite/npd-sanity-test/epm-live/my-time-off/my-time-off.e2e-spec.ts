import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import {MyTimeOffPageHelper} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {MyTimeOffPage} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLoginAsTeamMember();
    });

    it('Navigate to My Time off page - [785492]', async () => {
        stepLogger.caseId = 785492;
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            CommonPageConstants.pageHeaders.myWorkplace.timeOff,
            stepLogger);
    });

    it('Add a Time off request - [785495]', async () => {
        stepLogger.caseId = 785495;
        stepLogger.step('preCondition: navigate to Time Off page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            CommonPageConstants.pageHeaders.myWorkplace.timeOff,
            stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click on "+ new link" link displayed on top of "Time Off" page');
        await PageHelper.click(CommonPage.addNewLink);
        stepLogger.verification('"Time Off - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);

        stepLogger.stepId(2);
        // step#3 and step#4 are inside this function
        stepLogger.step(`Enter/Select below details in 'My Time Off' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyTimeOffPageConstants.inputLabels;
        const input = MyTimeOffPageConstants.inputValues;
        const title = `${labels.title} ${uniqueId}`;
        const timeOffType = MyTimeOffPageConstants.timeOffTypes.holiday;
        const requestor = input.requestorValue;
        const startDate = input.startDate;
        const finishDate = input.finishDate;
        await MyTimeOffPageHelper.fillFormAndVerify(title, timeOffType, requestor, startDate, finishDate, stepLogger);

        stepLogger.stepId(5);
        stepLogger.verification('Newly created TimeOff [Ex: Title 1] displayed in "My TimeOff" page');
        await CommonPageHelper.searchItemByTitle(title, MyTimeOffPageConstants.columnNames.title, stepLogger, true);
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(title)))
                .toBe(true, ValidationsHelper.getLabelDisplayedValidation(title));
    });

    it('View Time Off - [785496]', async () => {
        stepLogger.caseId = 785496;
        stepLogger.step('preCondition: Navigate Time Off Page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            CommonPageConstants.pageHeaders.myWorkplace.timeOff,
            stepLogger);

        stepLogger.stepId(1);
        // step#2 is inside this function
        const timeOffTitle = await CommonPage.recordWithoutGreenTicket.getText();
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.viewItem, stepLogger);
        stepLogger.verification('"View TimeOff" page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.timeOff))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.timeOff));
        await expect(await MyTimeOffPage.timeOffTitleInViewWindow.getText()).toBe(timeOffTitle.trim());
    });
});
