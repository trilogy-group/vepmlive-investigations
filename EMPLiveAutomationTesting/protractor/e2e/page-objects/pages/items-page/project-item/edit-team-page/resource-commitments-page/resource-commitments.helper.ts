import {PageHelper} from '../../../../../../components/html/page-helper';
import {ValidationsHelper} from '../../../../../../components/misc-utils/validation-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {ResourceCommitments} from './resource-commitments.po';
import {ResourceCommitmentsConstansts} from './resource-commitments.constansts';
import {ResourceCapacityHeatMapPage} from '../resource-capacity-heatMap-page/resource-capacity-heatMap-page.po';

export class ResourceCommitmentsHelper {
    static async selectResourceAndApply(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(
            ResourceCommitments.applyButton);

        stepLogger.verification('Specific Parameter Values is displayed ');
        await expect(await PageHelper.isElementDisplayed(ResourceCommitments.specifyParameterValues))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceCommitmentsConstansts.specifyParameterValues));

        await  PageHelper.click(ResourceCommitments.resource);

        await this.selectResource(stepLogger);

        await this.clickApplyButton(stepLogger);

    }
    static async selectResource(stepLogger: StepLogger) {
        await  PageHelper.click(ResourceCommitments.resource);
        stepLogger.step('Select Resource ');
        // 1001 is hard coded not able to select value need help
        await DropDownHelper.selectOptionByVal(ResourceCommitments.resource, '10001' );
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCommitments.applyButton);
    }
    static async clickApplyButton(stepLogger: StepLogger) {
        stepLogger.step('Click on Apply Button ');
        await ElementHelper.actionMouseMove(ResourceCommitments.applyButton);
        await PageHelper.click(ResourceCommitments.applyButton);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCapacityHeatMapPage.applyButton);
        }

}
