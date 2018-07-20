import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ResourceCommitments} from './resource-commitments.po';
import {ResourceCommitmentsConstansts} from './resource-commitments.constansts';
import {CommonPageHelper} from '../../../../common/common-page.helper';

export class ResourceCommitmentsHelper {
    static async selectResourceAndApply(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);

        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        stepLogger.verification('Specific Parameter Values is displayed ');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceCommitments.specifyParameterValues, ResourceCommitmentsConstansts.specifyParameterValues );

        await  PageHelper.click(ResourceCommitments.resource);

        await this.selectResource(stepLogger);

        await CommonPageHelper.clickApplyButton(stepLogger);
    }
    static async selectResource(stepLogger: StepLogger) {
        await  PageHelper.click(ResourceCommitments.resource);
        stepLogger.step('Select Resource ');

        await DropDownHelper.selectOptionByVal(ResourceCommitments.resource, '10001' );
        await CommonPageHelper.waitForApplyButtontoDisplayed();
    }
}
