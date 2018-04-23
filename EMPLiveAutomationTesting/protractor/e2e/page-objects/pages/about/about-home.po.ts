import {BasePage} from '../base-page';
import {By, element} from 'protractor';

export class AboutPage extends BasePage {
    url = '/wfe/jsp/capp/About.jsp';

    static get productVersion() {
        return element.all(By.css('#cappContent .infoText')).first();
    }

    static get pageActiveLink() {
        return element(By.css('#menu-about.menuItemCurrent'));
    }
}
