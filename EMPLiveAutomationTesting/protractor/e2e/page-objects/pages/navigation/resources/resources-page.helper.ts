import {StepLogger} from '../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../components/html/page-helper';
import {ResourcesPage} from './resources.po';
import {CommonPage} from '../../common/common.po';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ResourcesPageConstants} from './resources-page.constants';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';

export class ResourcesPageHelper {

    static async fillFormAndSave(displayName: string, stepLogger: StepLogger) {

        const labels = ResourcesPage.inputs;
        stepLogger.step(`Display Name *: New Resources 1`);
        await TextboxHelper.sendKeys(labels.displayName, displayName);

        stepLogger.step(`Select value for Role *: New Resources 1`);
        await PageHelper.click(labels.role);
        await PageHelper.click(labels.roleInput);

        stepLogger.step(`Select value for Holiday Schedule *: New Resources 1`);
        await PageHelper.click(labels.holidaySchedule);
        await PageHelper.click(labels.holidayScheduleInput);

        stepLogger.step(`Select value for Working Hours *: New Resources 1`);
        await PageHelper.click(labels.workingHours);
        await PageHelper.click(labels.workingHoursInput);

        stepLogger.stepId(4);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"New Resource" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ResourcesPageConstants.editPageName));
    }
}
