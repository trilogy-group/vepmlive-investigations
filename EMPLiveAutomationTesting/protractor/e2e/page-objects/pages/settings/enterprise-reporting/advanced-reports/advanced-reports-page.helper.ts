import {By, element} from 'protractor';

export class AdvancedReportsPageHelper {
    static getTopMenus(name: string) {
        return element(By.css(`[text_original="${name}"]`));
    }
}