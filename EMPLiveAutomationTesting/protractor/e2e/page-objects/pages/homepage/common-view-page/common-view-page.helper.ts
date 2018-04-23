import {By, element} from 'protractor';

export class CommonViewPageHelper {
    static getPageHeaderByTitle(title: string) {
        return element(By.css(`a[title="${title}"]`));
    }

    static getActionMenuIcons(title: string) {
        return element(By.css(`#actionmenu2Main li[title="${title}"]`));
    }
}
