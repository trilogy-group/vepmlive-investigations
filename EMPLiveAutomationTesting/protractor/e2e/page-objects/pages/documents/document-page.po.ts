import { By, element } from 'protractor';

import { BasePage } from '../base-page';
import { CommonPageHelper } from '../common/common-page.helper';
import { HomePageConstants } from '../homepage/home-page.constants';
import { DocumentPageConstants } from './document-page.constants';

export class DocumentPage extends BasePage {

    static get documentTitle() {
        return CommonPageHelper.getElementUsingText(HomePageConstants.addADocumentWindow.addADocumentTitle, false);
    }

    static get modifiedHeaderLink() {
        return element(By.cssContainingText('a.ms-headerSortTitleLink', HomePageConstants.addADocumentWindow.modified));
    }

    static selectDeselectCheckBox(fileName: string) {
        return element(By.xpath(`//div[contains(@aria-label,'${fileName}')]//parent::td`));
    }

    static get moreButton() {
        return element(By.xpath(`//button[@title='${DocumentPageConstants.moreButtonTitle}']`));
    }

    static get deleteButton() {
        return element(By.css(`a[title=${DocumentPageConstants.delete}]`));
    }
}