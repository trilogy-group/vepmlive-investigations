import {BasePage} from '../base-page';
import {LoginPageConstants} from './login-page.constants';
import {LoginPageHelper} from './login-page.helper';
import { browser } from '../../../../node_modules/protractor';

export class LoginPage extends BasePage {
    url = '/epm';
    logout = '/epm/_layouts/15/SignOut.aspx';

    static get usernameTextBox() {
        return LoginPageHelper.getFormControlById(LoginPageConstants.signInFormIDs.userName);
    }

    static get passwordTextBox() {
        return LoginPageHelper.getFormControlById(LoginPageConstants.signInFormIDs.password);
    }

    static get loginButton() {
        return LoginPageHelper.getFormControlById(LoginPageConstants.signInFormIDs.login);
    }

    async goToAndLogin(username = LoginPageHelper.adminEmailId, password = LoginPageHelper.adminPassword) {
        await this.goTo();
        await LoginPageHelper.login(username, password);
    }
    async goToAndLoginAsTeamMember(username = LoginPageHelper.teamMemberEmailId, password = LoginPageHelper.teamMemberPassword) {
        await this.goTo();
        await LoginPageHelper.login(username, password);
    }

    async logOutPage() {
        await this.logOut();
        await browser.manage().deleteAllCookies();
    }
}
