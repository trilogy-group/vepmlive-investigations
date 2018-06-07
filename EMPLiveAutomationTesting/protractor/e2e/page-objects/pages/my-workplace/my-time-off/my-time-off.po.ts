import {CommonPageHelper} from '../../common/common-page.helper';
import {MyTimeOffPageConstants} from './my-time-off-page.constants';
import {By, element} from 'protractor';
import {MyTimeOffPageHelper} from './my-time-off-page.helper';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';

export class MyTimeOffPage {
    static get inputs() {
        const labels = MyTimeOffPageConstants.inputLabels;
        return {
            title: CommonPageHelper.getTextBoxByLabel(labels.title),
            timeOffType: CommonPageHelper.getFirstAutoCompleteByLabel(labels.timeOffType),
            requestor: this.getInputByLabel(labels.requestor),
            start: CommonPageHelper.getTextBoxByLabel(labels.start),
            finish: CommonPageHelper.getTextBoxByLabel(labels.finish),
        };
    }

    static get dateEditBox() {
        return element(By.xpath('//*[@id="Grid6FocusCursors"]/div[1]/div/input'));
    }
    static get dateFeild() {
        return element(By.xpath('//*[@id="WorkPlannerGrid"]/tbody/tr[3]/td[2]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[4]'));
    }
    static get timeOffTypeShowAllButton() {
        return element(By.id('TimeOffType_ddlShowAll'));
    }

    static getInputByLabel(title: string) {
        return element(By.xpath(MyTimeOffPageHelper.getXpathForInputByLabel(HtmlHelper.tags.input, title)));
    }

    static get timeOffTitleInViewWindow() {
        return element(By.css(`span[id*='ItemTitle']`));
    }

    static get closeButton() {
        return MyTimeOffPageHelper.getElementByType(HtmlHelper.tags.submit);
    }

}
