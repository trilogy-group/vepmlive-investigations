import {ResourceplannerPage} from './resourceplanner-page.po';
import {CommonPage} from '../common/common.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {PageHelper} from '../../../components/html/page-helper';
import {WaitHelper} from '../../../components/html/wait-helper';
import {browser} from 'protractor';


export class ResourcePlannerPageHelper  {

    static async addingHours(stepLogger: StepLogger, hours: string) {
        // first deleting all the resources

        stepLogger.stepId(1);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceplannerPage.delete);
        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        stepLogger.step('deleting all the resources');
        await PageHelper.click(ResourceplannerPage.delete);
        await PageHelper.acceptAlert();
        stepLogger.stepId(2);
        stepLogger.step('Adding  the resources');
        await PageHelper.click(ResourceplannerPage.selectUser);
        await PageHelper.click(CommonPage.ribbonItems.add);
        await PageHelper.click(ResourceplannerPage.selectMonth);
        await PageHelper.sendKeysToInputField(ResourceplannerPage.inputHours, hours );
        await PageHelper.click(CommonPage.ribbonItems.save);
        if (PageHelper.isElementDisplayed(ResourceplannerPage.yesButton)) {
             await PageHelper.click(ResourceplannerPage.yesButton);
         }
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.ribbonItems.close);
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(CommonPage.ribbonItems.close);
        stepLogger.step('Adding  the resources');

    }
}
