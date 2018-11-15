import {By, element} from 'protractor';
import {CommonPageHelper} from '../../common/common-page.helper';
import {LinkPageConstants} from './link-page.constants';

export class LinkPage {
    static get inputs() {
        const labels = LinkPageConstants.inputLabels;
        return {
            title: CommonPageHelper.getTextBoxesByLabel(labels.url),
            notes: CommonPageHelper.getTextAreaByLabel(labels.notes)
        };
    }

    static get newLink() {
        return element(By.id('idHomePageNewLink'));
    }

    static get nextButton() {
        return element(By.css('a[title="Next"]'));
    }
}
