import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPage} from '../../common/common.po';
import {CommonPageConstants} from '../../common/common-page.constants';
import {EventsPageConstants} from './events-page.constants';
import {EventsPage} from './events.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {MyWorkplacePage} from '../my-workplace.po';
import {WaitHelper} from '../../../../components/html/wait-helper';

export class EventsPageHelper {

    static async fillNewEventForm(title: string, stepLogger: StepLogger) {

        stepLogger.step(`Title *: New Event 1`);
        await TextboxHelper.sendKeys(EventsPage.titleTextField, title);

        stepLogger.step(`Select Category *: New Event 1`);
        await PageHelper.click(EventsPage.categoryField);
        await PageHelper.click(EventsPage.categoryOption);

        stepLogger.stepId(4);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

    }

    static async verifyNewEventCreated(stepLogger: StepLogger) {

        await PageHelper.switchToDefaultContent();
        stepLogger.verification('"New Event" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(EventsPageConstants.editPageName));

        stepLogger.verification('verify "New Event" get created');
        await expect(await PageHelper.isElementDisplayed(EventsPage.calenderBlock, true))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.title));
    }

    static async fillNewEventsFormAndVerifyEventCreated(title: string, stepLogger: StepLogger) {
        stepLogger.step(`Title *: New Event 1`);
        await TextboxHelper.sendKeys(EventsPage.titleTextField, title);

        stepLogger.step(`Select Category *: New Event 1`);
        await PageHelper.click(EventsPage.categoryField);
        await PageHelper.click(EventsPage.categoryOption);

        stepLogger.stepId(4);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"New Event" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(EventsPageConstants.editPageName));

        stepLogger.verification('verify "New Event" get created');
        await expect(await PageHelper.isElementDisplayed(EventsPage.calenderBlock, true))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.title));
    }

    static async createNewEvent() {
        const stepLogger = new StepLogger(786942);

        stepLogger.step('PRECONDITION: navigate to Events page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
            stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click on "Events" tab displayed on top of "Events" page');
        await PageHelper.click(EventsPage.eventsTab);
        stepLogger.verification('Tab Panel of the Events should get displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.tabPanel, true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.tabPanel));

        stepLogger.stepId(2);
        stepLogger.step('Click on "New Event" option from Events tab panel');
        await PageHelper.click(EventsPage.newEvent);
        stepLogger.verification('"Events - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());
        await expect(await CommonPage.dialogTitles.first().getText())
            .toBe(EventsPageConstants.pageName, ValidationsHelper.getPageDisplayedValidation(EventsPageConstants.pageName));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Events - New Item" window');
        const labels = EventsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const title = `${labels.title} ${uniqueId}`;
        await EventsPageHelper.fillNewEventForm(title, stepLogger);
        await EventsPageHelper.verifyNewEventCreated(stepLogger);
        return title;
    }
}
