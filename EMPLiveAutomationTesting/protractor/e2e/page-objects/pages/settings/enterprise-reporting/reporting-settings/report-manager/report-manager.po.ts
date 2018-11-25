import {By, element} from 'protractor';
import {ReportManagerPageConstants} from './report-manager-page.constants';

export class ReportManagerPage {
    static get formControls() {
        const labelsIdPostFix = ReportManagerPageConstants.labelsIdPostFix;
        return {
            lastRun: element(By.css(`[id*=${labelsIdPostFix.lastRun}]`)),
            runNow: element(By.css(`[id*=${labelsIdPostFix.runNow}]`)),
            messages: element(By.css(`[id*=${labelsIdPostFix.messages}]`)),
            viewLog: element(By.linkText(labelsIdPostFix.viewLog))
        };
    }

}
