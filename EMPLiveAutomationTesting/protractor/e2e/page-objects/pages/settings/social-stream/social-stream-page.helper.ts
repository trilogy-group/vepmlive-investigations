import {By, element} from 'protractor';

export class SocialStreamPageHelper {

    static title(value: string) {
        return element(By.css(`[title="${value}"]`));
    }

}
