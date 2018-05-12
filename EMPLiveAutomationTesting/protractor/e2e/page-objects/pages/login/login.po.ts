import {BasePage} from '../base-page';
import { LoginPageConstants } from './login-page.constants';
import {By, element} from 'protractor';

export class LoginPage extends BasePage {
    url = 'EPMLiveForms/DefaultCust.aspx';

    static get usernameTextBox() {
        return element(By.className(`${LoginPageConstants.usernameTextBoxClass}`));
    }

    static get passwordTextBox() {
        return element(By.id(`${LoginPageConstants.passwordTextBoxID}`));
    }

    static get loginButton() {
        return element(By.className(LoginPageConstants.signInButtonClass));
    }
}
