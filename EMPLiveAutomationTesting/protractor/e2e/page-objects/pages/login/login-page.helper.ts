import {LoginPageConstants} from './login-page.constants';
import {PageHelper} from '../../../components/html/page-helper';
import {LoginPage} from './login.po';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {browser, By, element} from 'protractor';

export class LoginPageHelper {
    static get adminEmailId(): string {
        return browser.params.login.admin.user;
    }

    static get adminPassword(): string {
        return browser.params.login.admin.password;
    }

    static get teamMemberEmailId(): string {
        return browser.params.login.teamMember.user;
    }

    static get teamMemberPassword(): string {
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
}
