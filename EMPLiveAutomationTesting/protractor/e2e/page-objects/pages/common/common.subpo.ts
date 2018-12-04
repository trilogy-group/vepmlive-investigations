import { By, element } from 'protractor';
import { BasePage } from '../base-page';
import { CommonPage } from './common.po';

export class CommonSubPage extends BasePage {

    static get getAllRecord() {
        return element.all(By.xpath(`(${CommonPage.selectorForRecordsWithoutGreenTick})//td[contains(@class,'GMCellPanel')]`));
    }

    static projectItemCheckBox(project: string) {
        return element(By.xpath(`//a[text()='${project}']//ancestor::tr[contains(@class,'GMDataRow')]//td[contains(@class,'GMCellPanel')]`));
    }
}
