import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPage} from '../../common/common.po';
import {CommonPageConstants} from '../../common/common-page.constants';
import {EventsPageConstants} from './events-page.constants';
import {EventsPage} from './events.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';

export class EventsPageHelper {

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
}
