import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ReportsItemPageConstants} from './reports-item-page.constants';
import {By, element} from 'protractor';

export class ReportsItemPage extends BasePage {

    static get reportsLandingPage() {
        const landingPage = ReportsItemPageConstants.reportsLandingPage;
        return {
            businessIntelligenceCenter: CommonPageHelper.getElementUsingText(landingPage.businessIntelligenceCenter, false),
            reportsHeader: CommonPageHelper.getElementUsingText(ReportsItemPageConstants.reportsHeader, false),
            epmLiveAnalytics: element(By.id(landingPage.epmLiveAnalytics)),
            classicReporting: element(By.id(landingPage.classicReporting)),
        };
    }

    static get classicReporting() {
        const label = ReportsItemPageConstants.classicReportingPage;
        const xpathExpandProjectsList = '//div[normalize-space(.)="' +
            label.projectsTitleForExpandSign + '"]//img[contains(@src,"plus")]';
        return {
            expandProjectsList: element(By.xpath(xpathExpandProjectsList)),
            projectHealthOption: element(By.linkText(label.projectHealth)),
            projectHealthHeader: CommonPageHelper.getElementByTitle(label.projectHealth),
            closeButton: element(By.className(label.closeButton))
        };
    }
}
