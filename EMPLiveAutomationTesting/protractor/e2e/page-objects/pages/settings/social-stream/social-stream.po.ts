import {browser, By, element} from 'protractor';
import {SocialStreamPageConstants} from './social-stream-page.constants';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {SocialStreamPageHelper} from './social-stream-page.helper';
import {ElementHelper} from '../../../../components/html/element-helper';

export class SocialStreamPage {

    static get settingItems() {
        const menuTitlesAndIds = SocialStreamPageConstants.settingItems;
        return {
            editPage: ElementHelper.getElementByText(menuTitlesAndIds.editPage),
            page: ElementHelper.getElementByText(menuTitlesAndIds.page),
            epmLive: SocialStreamPageHelper.title(menuTitlesAndIds.epmLive),
            socialStream: SocialStreamPageHelper.title(menuTitlesAndIds.socialStream),
            gridGantt: SocialStreamPageHelper.title(menuTitlesAndIds.gridGantt),
            delete: ElementHelper.getElementByText(menuTitlesAndIds.delete),
        };
    }

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

    static get socialTab() {
        // move to parent div is not posible in CSS.
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
        return CommonPageHelper.getElementByTitle(SocialStreamPageConstants.settingItems.delete);
    }

    static get statusBox() {
        return `[id*="update"]`;
    }

    static get commentBox() {
        return `[id='epm-se-threads'] > li:first-child`;
    }

    static get updateBox() {
        return element.all(By.css(`${this.statusBox} [class*="comment-input"]`));
    }

    static get commentTextBox() {
        return element.all(By.css(`${this.commentBox} [class*='input']`));
    }

    static get commentPost() {
        return element.all(By.css(`${this.commentBox} [id*="post"]`));
    }

    static get postButton() {
        return element.all(By.css(`${this.statusBox}>button`));
    }

    static get nextButton() {
        return element(By.css(`[alt="Next"]`));
    }

    static get addButton() {
        return element(By.css(`[class*='buttonArea'] > button:first-child`));
    }

    static get stopEditing() {
        return element(By.css(`[id*="SelectedItem"]`));
    }

    static async deleteSocialStream() {
        if (await SocialStreamPage.menueLink.first().isPresent() === true) {
            await PageHelper.click(SocialStreamPage.menueLink.first());
            await PageHelper.click(SocialStreamPage.delete);
            await browser.switchTo().alert().accept();
            // After save It need static wait(5 sec) and no element found which get change after save.
            await browser.sleep(PageHelper.timeout.m);

            if (await SocialStreamPage.menueLink.first().isPresent() === true) {
                await this.deleteSocialStream();
            }
        }
    }

    static async logout() {
        await browser.get(SocialStreamPageConstants.logoutURL);
    }

}
