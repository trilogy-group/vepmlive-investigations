import {By, element} from 'protractor';
import {CommonPageHelper} from '../../common/common-page.helper';
import {MyTimeOffPageConstants} from './my-time-off-page.constants';
import {MyTimeOffPageHelper} from './my-time-off-page.helper';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';

export class MyTimeOffPage {
    static get inputs() {
        const labels = MyTimeOffPageConstants.inputLabels;
        return {
            title: CommonPageHelper.getTextBoxByLabel(labels.title),
            requestor: this.getInputByLabel(labels.requestor),
            start: CommonPageHelper.getTextBoxByLabel(labels.start),
            finish: CommonPageHelper.getTextBoxByLabel(labels.finish),
        };
    }

    static timeOffTypeValues(value: string) {
        return element(By.xpath(`//div[text()='${value}']`));
    }

    static get dateEditBox() {
        return element(By.css('[class*= "GSEditInput" ]'));
    }

    static get timeOffTypeShowAllButton() {
        return element(By.id('TimeOffType_ddlShowAll'));
    }

    static get timeOffTitleInViewWindow() {
        return element(By.css(`span[id*='ItemTitle']`));
    }

    static get closeButton() {
        return MyTimeOffPageHelper.getElementByType(HtmlHelper.tags.submit);
    }

    static getInputByLabel(title: string) {
        return element(By.xpath(MyTimeOffPageHelper.getXpathForInputByLabel(HtmlHelper.tags.input, title)));
    }

}