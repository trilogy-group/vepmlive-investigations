import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ResourceCommitments} from './resource-commitments.po';
import {ResourceCommitmentsConstansts} from './resource-commitments.constansts';
import {CommonPageHelper} from '../../../../common/common-page.helper';
import {CommonPage} from '../../../../common/common.po';

export class ResourceCommitmentsHelper {
    static async selectResourceAndApply() {
        // this is work around without it not able to work on new tab
        await WaitHelper.staticWait(PageHelper.timeout.s);

        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        StepLogger.verification('Specific Parameter Values is displayed ');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceCommitments.specifyParameterValues, ResourceCommitmentsConstansts.specifyParameterValues);

        await PageHelper.click(CommonPage.getDropDownByParameterName(ResourceCommitmentsConstansts.resource, 1));

        await this.selectResource();

        await CommonPageHelper.clickApplyButton();
    }

    static async selectResource() {
        await PageHelper.click(ResourceCommitments.getDropDownByParameterName);
        StepLogger.step('Select Resource ');

        await DropDownHelper.selectOptionByVal
        (ResourceCommitments.getDropDownByParameterName, '10001');
        await CommonPageHelper.waitForApplyButtontoDisplayed();
    }
}
