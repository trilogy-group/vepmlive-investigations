import {BasePage} from '../base-page';
import {LoginPageConstants} from './login-page.constants';
import {LoginPageHelper} from './login-page.helper';

export class LoginPage extends BasePage {
    url = '/sites/test2518';

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
}
