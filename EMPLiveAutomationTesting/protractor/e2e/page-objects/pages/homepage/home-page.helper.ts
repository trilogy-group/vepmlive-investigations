import {By, element} from 'protractor';
import {CommonPageHelper} from '../common/common-page.helper';
import {HomePageConstants} from './home-page.constants';

export class HomePageHelper {

    static get navigateMenu() {
        // ql locator is alone on that page.
        return element(By.css('[data-id*="ql"]'));
    }

    static get navigateToHome() {
        return element(By.css('.epm-nav-home a'));
    }

    static get chooseAfile() {
        return element(By.css('.ms-fileinput'));
    }

    static get navigationMenu() {
        return element(By.css('#epm-nav-sub'));
    }

    static get commentField() {
        return CommonPageHelper.getElementUsingText(HomePageConstants.comment, false);
    }

    static get moreButton() {
        return element.all(By.css('.epm-se-show-more')).first();
    }

}
