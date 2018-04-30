import {BasePage} from '../base-page';
import {By, element} from 'protractor';

export class CommonPage extends BasePage {

    static get sidebarMenus() {
        const idPrefix = 'epm-nav-top-';
        return {
            navigation: element(By.id(`${idPrefix}ql`)),
            createNew: element(By.id(`${idPrefix}new`)),
            myWorkplace: element(By.id(`${idPrefix}workplace`)),
            favorites: element(By.id(`${idPrefix}favorites`)),
            mostRecent: element(By.id(`${idPrefix}recent`)),
            workspaces: element(By.id(`${idPrefix}workspaces`))
        };
    }

    static get addNewLink() {
        return element(By.css('[title="New Item"] a'));
    }

    static get contentTitleInViewMode() {
        return element(By.css('span.dispFormFancyTitle'));
    }
}
