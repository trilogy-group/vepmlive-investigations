export class SocialStreamPageConstants {

    static get validations() {
        return {
            settingMenu: 'Setting Menu',
            homePage: 'Home Page',
        };
    }

    static get logoutURL() {
        return `http://qaepmlive6/sites/devtestautomation/_layouts/15/SignOut.aspx`;
    }

    static get settingItems() {
        return {
            editPage: 'Edit Page',
            socialStreamTextBox: 'Social Stream Text Box',
            page: 'Page',
            delete: 'Delete',
            epmLive: 'EPM Live',
            gridGantt: 'Grid/Gantt',
            socialStream: 'Social Stream',
        };
    }

    static get message() {
        return {
            socialStreamCreateBox: 'What are you working on?',
            testStatus: 'Test Status',
            testComment: 'Test Comment',
        };
    }
}
