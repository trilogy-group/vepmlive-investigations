import {PageHelper} from '../../../components/html/page-helper';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {ElementHelper} from '../../../components/html/element-helper';
import {WaitHelper} from '../../../components/html/wait-helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {MyTimeOffPageConstants} from '../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {MyTimeOffPageHelper} from '../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.helper';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add Time Off - [891123]', async () => {
        StepLogger.caseId = 891123;

        StepLogger.step('Click on "More" Link on the top menu bar');
        await ElementHelper.click(HomePage.toolBarMenuItems.more);

        StepLogger.step('Click on "Time Off" Link on the top menu bar');
        await ElementHelper.click(HomePage.toolBarMenuItems.timeOff);

        StepLogger.verification('"Time Off - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(MyTimeOffPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(MyTimeOffPageConstants.pageName));

        await CommonPageHelper.switchToContentFrame();

        StepLogger.step(`Enter/Select below details in 'My Time Off' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyTimeOffPageConstants.inputLabels;
        const input = MyTimeOffPageConstants.inputValues;
        const title = `${labels.title} ${uniqueId}`;
        const timeOffType = MyTimeOffPageConstants.timeOffTypes.holiday;
        const requestor = input.requestorValue;
        const startDate = input.startDate;
        const finishDate = input.finishDate;
        await MyTimeOffPageHelper.fillFormAndVerify(title, timeOffType, requestor, startDate, finishDate, false);

        StepLogger.verification('Newly created Time off displayed in Home page');
        await WaitHelper.waitForElementToBeDisplayed(ElementHelper.getElementByText(title));
        await expect(await PageHelper.isElementPresent(ElementHelper.getElementByText(title)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(title));
    });

});
