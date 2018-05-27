import {By, element} from 'protractor';

export class ReportingSettingsPageHelper {
    static getTopMenus(name: string) {
        return element(By.css(`li[text_original="${name}"]`));
    }
}