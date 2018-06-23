import {BasePage} from '../base-page';
import {CommonPageHelper} from '../common/common-page.helper';
import {HomePageConstants} from '../homepage/home-page.constants';

export class DocumentPage extends BasePage {

    static get documentTitle() {
        return CommonPageHelper.getElementUsingText(HomePageConstants.addADocumentWindow.addADocumentTitle, false);
    }
}