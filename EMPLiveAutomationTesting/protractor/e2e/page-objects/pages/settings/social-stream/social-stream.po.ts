import {browser} from 'protractor';
import {SocialStreamPageConstants} from './social-stream-page.constants';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {SocialStreamPageHelper} from './social-stream-page.helper';

export class SocialStreamPage {

    static get settingItems() {
        const menuTitlesAndIds = SocialStreamPageConstants.settingItems;
        return {
            editPage: CommonPageHelper.getElementByText(menuTitlesAndIds.editPage),
            page: CommonPageHelper.getElementByText(menuTitlesAndIds.page),
            epmLive:  SocialStreamPageHelper.title(menuTitlesAndIds.epmLive),
            socialStream:  SocialStreamPageHelper.title(menuTitlesAndIds.socialStream),
            gridGantt:  SocialStreamPageHelper.title(menuTitlesAndIds.gridGantt),
            delete: CommonPageHelper.getElementByText(menuTitlesAndIds.delete),
        };
    }

    static async deleteSocialStream() {
        if (await SocialStreamPageHelper.menueLink.first().isPresent() === true) {
            await PageHelper.click(SocialStreamPageHelper.menueLink.first());
            await PageHelper.click(SocialStreamPageHelper.delete);
            await browser.switchTo().alert().accept();
            // After save It need static wait(5 sec) and no element found which get change after save.
            await browser.sleep(PageHelper.timeout.m);

            if (await SocialStreamPageHelper.menueLink.first().isPresent() === true) {
                await this.deleteSocialStream();
            }
        }
    }
}
