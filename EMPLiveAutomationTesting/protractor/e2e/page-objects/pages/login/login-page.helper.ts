import {LoginPageConstants} from './login-page.constants';
import {PageHelper} from '../../../components/html/page-helper';
import {LoginPage} from './login.po';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';

export class LoginPageHelper{

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
}
