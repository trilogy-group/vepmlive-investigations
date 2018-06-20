import {By, element, browser} from 'protractor';
import {SocialStreamPageConstants} from './social-stream-page.constants';

export class SocialStreamPageHelper {

    static get addAWebpart() {
        return element(By.css(`[class*='WPAddButton']`));
    }

    static get settingMenu() {
        return element(By.id(`epm-nav-sub-settings`));
    }

    static get webPartAdderUpdatePanel() {
        return element(By.css(`[id="WebPartAdderUpdatePanelContainer"]`));
    }

    static get pageRibbon() {
        return element(By.id(`Ribbon.WebPartPage`));
    }

    static title(value: string) {
        return element(By.css(`[title="${value}"]`));
    }

    static get socialTab() {
        return `.//span[contains(@title,'Social')]//parent::div`;
    }

    static get menueLink() {
        return element.all(By.xpath(`${this.socialTab}//*[contains(@class,'menuLink')]`));
    }

    static get socialStreamPage() {
        return element(By.id(`epm-social-stream`));
    }

    static get socialStreamColumn() {
        return element(By.css(`[class*="wpname"]`));
    }

    static get delete() {
        return element(By.css('[title= "Delete"]'));
    }

    static get statusBox() {
        return `[id*="update"]`;
    }

    static get commentBox() {
        return `.//*[@id='epm-se-threads']/li[1]`;
    }

    static get updateBox() {
        return element.all(By.css(`${this.statusBox}>div`));
    }

    static get commentTextBox() {
        return element.all(By.xpath(`${this.commentBox}//*[contains(@class,"input")]`));
    }

    static get commentPost() {
        return element.all(By.xpath(`${this.commentBox}//*[contains(@id,"post")]`));
    }

    static get postButton() {
        return element.all(By.css(`${this.statusBox}>button`));
    }

    static async logout() {
        await browser.get(SocialStreamPageConstants.logoutURL);
    }

    static get nextButton() {
        return element(By.css(`[alt="Next"]`));
    }

    static get addButton() {
        return element(By.xpath(`.//*[contains(@class,'buttonArea')]/button[1]`));
    }

    static get stopEditing  () {
        return element(By.css(`[id*="SelectedItem"]`));
    }

}
