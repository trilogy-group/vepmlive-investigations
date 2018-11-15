import { By, element } from 'protractor';

import { BasePage } from '../base-page';
import { CommonPageHelper } from '../common/common-page.helper';
import { HomePageConstants } from '../homepage/home-page.constants';

export class DocumentPage extends BasePage {

    static get documentTitle() {
        return CommonPageHelper.getElementUsingText(HomePageConstants.addADocumentWindow.addADocumentTitle, false);
    }

    static get modifiedHeaderLink() {
        return element(By.cssContainingText('a.ms-headerSortTitleLink', HomePageConstants.addADocumentWindow.modified));
    }
}
