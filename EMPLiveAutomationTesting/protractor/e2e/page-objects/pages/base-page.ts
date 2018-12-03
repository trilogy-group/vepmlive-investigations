import {browser} from 'protractor';
import {Page} from '../contracts/page';
import {PageHelper} from '../../components/html/page-helper';

export class BasePage implements Page {
    titleText: string;
    url: string;
    logout: string;

    async goTo() {
        await browser.waitForAngularEnabled(false);
        await this.get(this.url);
    }

    async get(url: string) {
        await browser.get(url, PageHelper.DEFAULT_TIMEOUT);
    }

    async verifyExistence() {
        const currentUrl = await browser.getCurrentUrl();
        return currentUrl.indexOf(this.url) > -1;
    }

    async logOut() {
        await this.get(this.logout);
    }
}
