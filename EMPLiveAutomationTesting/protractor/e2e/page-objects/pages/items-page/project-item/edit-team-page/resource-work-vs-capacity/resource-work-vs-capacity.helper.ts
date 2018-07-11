import {PageHelper} from '../../../../../../components/html/page-helper';
import {ResourceCommitmentsConstansts} from '../resource-commitments-page/resource-commitments.constansts';
import {ValidationsHelper} from '../../../../../../components/misc-utils/validation-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ResourceCommitments} from '../resource-commitments-page/resource-commitments.po';
import {ElementHelper} from '../../../../../../components/html/element-helper';

export class ResourceWorkVsCapacityHelper {
     static async selectResourceAndApply(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceCommitments.applyButton);
        stepLogger.verification('Specific Paramenter Values is displayed ');
        await expect(await PageHelper.isElementDisplayed(ResourceCommitments.specifyParameterValues))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceCommitmentsConstansts.specifyParameterValues));
        await  PageHelper.click(ResourceCommitments.resource);
        stepLogger.step('Select Resource ');
        await DropDownHelper.selectOptionByVal(ResourceCommitments.resource, '10001' );
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCommitments.applyButton);
        stepLogger.step('Click on Apply Button ');
        await ElementHelper.actionMouseMove(ResourceCommitments.applyButton);
        await PageHelper.click(ResourceCommitments.applyButton);
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceCommitments.resourceCommitmentsMessage);
    }
}
