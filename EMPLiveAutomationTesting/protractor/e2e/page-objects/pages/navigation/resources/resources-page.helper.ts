import {StepLogger} from '../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../components/html/page-helper';
import {ResourcesPage} from './resources.po';
import {CommonPage} from '../../common/common.po';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ResourcesPageConstants} from './resources-page.constants';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';

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
    static async clickNewInviteLink(stepLogger: StepLogger) {
        stepLogger.step('Click on "+ Invite" link displayed on top of "Resources" page');
        await WaitHelper.staticWait(PageHelper.timeout.s);
        await CommonPageHelper.buttonDisplayedValidation(ResourcesPage.newInviteLink, ResourcesPageConstants.inviteLink );

        await PageHelper.click(ResourcesPage.newInviteLink);

    }
    static async selectGenericBox(stepLogger: StepLogger) {
        stepLogger.step(`Check 'Generic' check box`);
        await PageHelper.click(ResourcesPage.inputs.generic);
    }
    static async clickSearchIcon(stepLogger: StepLogger) {
        stepLogger.step('Click on search');
        await PageHelper.click(ResourcesPage.searchIcon);
    }
    static async addResourceAndValidateIt(stepLogger: StepLogger) {
        const uniqueId = PageHelper.getUniqueId();
        const displayName = `${ResourcesPageConstants.inputLabels.displayName} ${uniqueId}`;

        stepLogger.step('Click on "+ Invite" link displayed on top of "Resources" page');
        await this.clickNewInviteLink(stepLogger);

        stepLogger.stepId(2);
        await this.selectGenericBox(stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Provide values in required fields');
        await this.fillFormAndSave(displayName, stepLogger);

        await WaitHelper.staticWait(PageHelper.timeout.s);
        stepLogger.stepId(4);
        await this.clickSearchIcon(stepLogger);

        await WaitHelper.staticWait(PageHelper.timeout.s);
        stepLogger.step('Enter newly created resource name');
        await TextboxHelper.sendKeys(ResourcesPage.searchTextbox, displayName, true);

        stepLogger.verification('Newly created Resource [Ex: Display Name 1] displayed in "Resources" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(displayName), displayName );

    }
}
