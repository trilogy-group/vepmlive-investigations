import {By, element} from 'protractor';
import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ReportsItemPageConstants} from './reports-item-page.constants';

export class ReportsItemPage extends BasePage {

    static get reportsLandingMenu() {
        const landingPage = ReportsItemPageConstants.landingPageMenu;
        return {
            epmLiveAnalytics: element(By.id(landingPage.epmLiveAnalytics)),
            classicReporting: element(By.id(landingPage.classicReporting)),
        };
    }

    static get reportListItems() {
        const label = ReportsItemPageConstants.reportListItems.projects;
        return {
            project: {
                projectHealth: element(By.linkText(label.projectHealth))
            }
        };
    }

    static get businessIntelligenceCenter() {
        return CommonPageHelper.getElementUsingText(ReportsItemPageConstants.businessIntelligenceCenter, false);
    }

    static async expandReportListItem(itemName: string) {
        const xpathExpandProjectsList = `//div[normalize-space(.)="${itemName}"]//img[contains(@src,"plus")]`;
        return element(By.xpath(xpathExpandProjectsList));
    }

    static get closeButton() {
        return element(By.css('#dlgTitleBtns a[title="Close dialog"]'));
    }
}
