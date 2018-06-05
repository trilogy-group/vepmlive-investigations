import {BasePage} from '../base-page';
import {LoginPageConstants} from './login-page.constants';
import {LoginPageHelper} from './login-page.helper';

export class LoginPage extends BasePage {
    url = '/sites/devtestautomation';

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
        this.goTo();
        await LoginPageHelper.login(username, password);
    }

    async goToAndLoginAsTeamMember(username = LoginPageHelper.teamMemberEmailId, password = LoginPageHelper.teamMemberPassword) {
        this.goTo();
        await LoginPageHelper.login(username, password);
    }

    async goToAndLoginAsProjectManager(username = LoginPageHelper.projectManagerEmailId, password = LoginPageHelper.projectManagerPassword) {
        this.goTo();
        await LoginPageHelper.login(username, password);
    }
}
