import {BasePage} from '../base-page';
import {LoginPageConstants} from './login-page.constants';
import {LoginPageHelper} from './login-page.helper';

export class LoginPage extends BasePage {
    url = 'EPMLiveForms/DefaultCust.aspx';

    static get usernameTextBox() {
        return LoginPageHelper.getFormControlById(LoginPageConstants.signInFormIDs.userName);
    }

    static get passwordTextBox() {
        return LoginPageHelper.getFormControlById(LoginPageConstants.signInFormIDs.password);
    }

    static get loginButton() {
        return LoginPageHelper.getFormControlById(LoginPageConstants.signInFormIDs.login);
    }
}
