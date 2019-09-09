import {browser, By, element} from 'protractor';
import {LoginPageConstants} from './login-page.constants';
import {PageHelper} from '../../../components/html/page-helper';
import {LoginPage} from './login.po';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {HomePage} from '../homepage/home.po';

export class LoginPageHelper {
    static get adminEmailId(): string {
        // Reason: not a typed object
        // noinspection Annotator
        return browser.params.login.admin.user;
    }

    static get adminPassword(): string {
        // Reason: not a typed object
        // noinspection Annotator
        return browser.params.login.admin.password;
    }

    static get teamMemberEmailId(): string {
        // Reason: not a typed object
        // noinspection Annotator
        return browser.params.login.teamMember.user;
    }

    static get teamMemberPassword(): string {
        // Reason: not a typed object
        // noinspection Annotator
        return browser.params.login.teamMember.password;
    }

    static async verifyLoginPageDisplayed() {
        await expect(await PageHelper.isElementDisplayed(LoginPage.loginButton, true))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(
                LoginPageConstants.loginWindowID));
    }

    static async login(username: string, password: string) {
        await TextboxHelper.sendKeys(LoginPage.usernameTextBox, username);
        await TextboxHelper.sendKeys(LoginPage.passwordTextBox, password);
        await PageHelper.click(LoginPage.loginButton);
    }

    static getFormControlById(partialId: string) {
        return element(By.css(`[id*='signInControl_${partialId}']`));
    }

    static async logout() {
        await PageHelper.sleepForXSec(PageHelper.timeout.xs);
        await PageHelper.click(HomePage.userMenu.menu);
        await PageHelper.click(HomePage.userMenu.signOutLink);
        await PageHelper.deleteCookies();
    }
}