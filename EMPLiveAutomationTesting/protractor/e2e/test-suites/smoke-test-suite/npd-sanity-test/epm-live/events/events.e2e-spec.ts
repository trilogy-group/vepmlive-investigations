import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {browser} from 'protractor';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {EventsPageHelper} from '../../../../../page-objects/pages/my-workplace/events/events-page.helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {EventsPage} from '../../../../../page-objects/pages/my-workplace/events/events.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {CheckboxHelper} from '../../../../../components/html/checkbox-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Navigate to Event Page - [785879]', async () => {
        const stepLogger = new StepLogger(785879);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
            stepLogger);
    });

    it('Add an Event- [786942]', async () => {
        await EventsPageHelper.createNewEvent();
    });

    fit('Create View- [855383]', async () => {
        const stepLogger = new StepLogger(855383);
        const uniqueId = PageHelper.getUniqueId();
        stepLogger.precondition('User is in Event page ');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
            stepLogger);

        // Step #1 to #5 Inside this function
        await EventsPageHelper.createView(stepLogger, uniqueId, false);

        stepLogger.verification('User should be navigated to event page and created view should be displayed');
        await PageHelper.click(EventsPage.rollOverEventList);
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId)))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createdView));

        stepLogger.stepId(6);
        stepLogger.step('Click on CALENDAR tab');
        await PageHelper.click(CommonPageHelper.getbuttons.calender);
        await PageHelper.click(EventsPage.calenderTab);

        stepLogger.verification('Contents of the CALENDAR tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.calendearView))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.calendarContent));

        stepLogger.stepId(7);
        stepLogger.step('Expand Current View drop down');
        await PageHelper.click(EventsPage.currentView);

        stepLogger.verification('Created view should be displayed in the list');
        WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByText(uniqueId));
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId)))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createdView));

    });

    fit('Create Default View - [855387]', async () => {
        const stepLogger = new StepLogger(855387);
        const uniqueId = PageHelper.getUniqueId();
        stepLogger.precondition('User is in Event page ');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
            stepLogger);

        // Step #1 and #5 Inside this function
        await EventsPageHelper.createView(stepLogger, uniqueId, true);

        stepLogger.verification('View should be created and user should be navigated to event page');
        await PageHelper.click(EventsPage.rollOverEventList);
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId)))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createdView));

        stepLogger.stepId(6);
        stepLogger.step('Navigate to any other page and come back to Event page and from the CALENDAR tab, select' +
            ' any the Standard View which was created from the Current View drop-down');
        await PageHelper.click(CommonPageHelper.getbuttons.calender);
        await PageHelper.click(EventsPage.calenderTab);
        await PageHelper.click(EventsPage.currentView);
        await ElementHelper.clickUsingJs(ElementHelper.getElementByText(uniqueId));

        stepLogger.verification('Created view should be displayed in the list');
        WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByText(uniqueId));
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId)))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createdView));
    });

    fit('Create Column - [855530]', async () => {
        const stepLogger = new StepLogger(855530);
        stepLogger.precondition('User is in Event page ');
        const uniqueId = PageHelper.getUniqueId();
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
            stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click on CALENDAR tab');
        await PageHelper.click(EventsPage.calenderTab);

        stepLogger.verification('Details of the Calendar tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.calendearView))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.calendarContent));

        stepLogger.stepId(2);
        stepLogger.step('Click on Create Column from ribbon panel');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(EventsPage.createColumn);

        stepLogger.verification('Create Column popup should be displayed');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await expect(await PageHelper.isElementDisplayed(EventsPage.columnNameField))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.column));

        stepLogger.stepId(3);
        stepLogger.step('Select any of the column type');
        await CheckboxHelper.markCheckbox(EventsPage.choiceCheckbox, true);

        stepLogger.verification('the respective column type should get selected');
        await browser.sleep(PageHelper.timeout.s);
        await expect(EventsPage.choiceCheckbox.isEnabled()).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.columnType));

        stepLogger.stepId(4);
        stepLogger.step('Provide column name and other required details');
        await TextboxHelper.sendKeys(EventsPage.columnNameField, uniqueId, true);
        await TextboxHelper.sendKeys(EventsPage.descriptionField, CommonPageConstants.menuContainerIds.navigation);

        stepLogger.verification('the respective details should get populated');

        await CheckboxHelper.markCheckbox(EventsPage.choiceCheckbox, true);
        await expect(await TextboxHelper.hasValue(EventsPage.columnNameField, uniqueId))
            .toBe(true, ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.columnName));
        await expect(await TextboxHelper.hasValue(EventsPage.descriptionField, CommonPageConstants.menuContainerIds.navigation))
            .toBe(true, ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.columnDescription));

        stepLogger.stepId(5);
        stepLogger.step('Click on Ok button');
        await ElementHelper.scrollToElement(CommonPage.okButton);
        await PageHelper.click(CommonPage.okButton);

        stepLogger.verification('Newly added column should be displayed in events page while user select ' +
            'standard view from current view drop down ');
        await browser.sleep(PageHelper.timeout.m);
        await ElementHelper.clickUsingJs(EventsPage.createView);
        await PageHelper.click(EventsPage.standardViewType);
        await ElementHelper.scrollToElement(ElementHelper.getElementByText(uniqueId));
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId))).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.column));

    });
});
