import {browser, By, element} from 'protractor';
import {SocialStreamPageConstants} from './social-stream-page.constants';
import {ElementHelper} from '../../../../components/html/element-helper';
import {PageHelper} from '../../../../components/html/page-helper';

export class SocialStreamPage {

    static get settingMenu() {
        return element(By.id(`epm-nav-sub-settings`));
    }

    static get webPartAdderUpdatePanel() {
        return element(By.css(`[id="WebPartAdderUpdatePanelContainer"]`));
    }

    static get addAWebpart() {
        return element(By.css(`[class*='WPAddButton']`));
    }

    static get pageRibbon() {
        return element(By.id(`Ribbon.WebPartPage`));
    }

    static get addButton() {
        return element(By.xpath(`.//*[contains(@class,'buttonArea')]/button[1]`));
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

    static get nextButton() {
        return element(By.css(`[alt="Next"]`));
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

    static get stopEditing  () {
        return element(By.css(`[id*="SelectedItem"]`));
    }

    static get settingItems() {
        const menuTitlesAndIds = SocialStreamPageConstants.settingItems;
        return {
            editPage: ElementHelper.getElementByText(menuTitlesAndIds.editPage),
            page: ElementHelper.getElementByText(menuTitlesAndIds.page),
            epmLive:  this.title(menuTitlesAndIds.epmLive),
            socialStream:  this.title(menuTitlesAndIds.socialStream),
            gridGantt:  this.title(menuTitlesAndIds.gridGantt),
            delete: ElementHelper.getElementByText(menuTitlesAndIds.delete),
        };
    }

    static async deleteSocialStream() {
        if (await this.menueLink.first().isPresent() === true) {
            await PageHelper.click(this.menueLink.first());
            await PageHelper.click(this.delete);
            await browser.switchTo().alert().accept();
            // After save It need static wait(5 sec) and no element found which get change after save.
            await browser.sleep(PageHelper.timeout.m);

            if (await this.menueLink.first().isPresent() === true) {
                await this.deleteSocialStream();
            }
        }
    }
}
