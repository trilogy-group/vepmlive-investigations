import {By, element} from 'protractor';

export class PicturePage {
    static get uploadButton() {
        return element(By.css('.js-listview-qcbUploadButton'));
    }

    static get browseButton() {
        return element(By.css('.ms-fileinput'));
    }
}
