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

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLoginAsTeamMember();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Navigate to My Time off page - [785492]', async () => {
        StepLogger.caseId = 785492;
        StepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            CommonPageConstants.pageHeaders.myWorkplace.timeOff,
        );
    });

    it('Add a Time off request - [785495]', async () => {
        StepLogger.caseId = 785495;
        StepLogger.step('preCondition: navigate to Time Off page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            CommonPageConstants.pageHeaders.myWorkplace.timeOff,
        );

        StepLogger.stepId(1);
        StepLogger.step('Click on "+ new link" link displayed on top of "Time Off" page');
        await PageHelper.click(CommonPage.addNewLink);
        StepLogger.verification('"Time Off - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);

        StepLogger.stepId(2);
        // step#3 and step#4 are inside this function
        StepLogger.step(`Enter/Select below details in 'My Time Off' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyTimeOffPageConstants.inputLabels;
        const input = MyTimeOffPageConstants.inputValues;
        const title = `${labels.title} ${uniqueId}`;
        const timeOffType = MyTimeOffPageConstants.timeOffTypes.holiday;
        const requestor = input.requestorValue;
        const startDate = input.startDate;
        const finishDate = input.finishDate;
        await MyTimeOffPageHelper.fillFormAndVerify(title, timeOffType, requestor, startDate, finishDate);

        StepLogger.stepId(5);
        StepLogger.verification('Newly created TimeOff [Ex: Title 1] displayed in "My TimeOff" page');
        await CommonPageHelper.searchItemByTitle(title, MyTimeOffPageConstants.columnNames.title, true);
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(title)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(title));
    });

    it('View Time Off - [785496]', async () => {
        StepLogger.caseId = 785496;
        StepLogger.step('preCondition: Navigate Time Off Page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            CommonPageConstants.pageHeaders.myWorkplace.timeOff,
        );

        StepLogger.stepId(1);
        // step#2 is inside this function
        const timeOffTitle = await CommonPage.recordWithoutGreenTicket.getText();
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.viewItem);
        StepLogger.verification('"View TimeOff" page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.timeOff))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.timeOff));
        await expect(await MyTimeOffPage.timeOffTitleInViewWindow.getText()).toBe(timeOffTitle.trim());
    });
});
