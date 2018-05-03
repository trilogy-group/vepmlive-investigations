import {BasePage} from '../base-page';
import {CommonPageHelper} from '../common/common-page.helper';
import {HomePageConstants} from './home-page.constants';
import {By, element} from 'protractor';

export class HomePage extends BasePage {
    url = '/sites/devtestautomation';

    static get navigation() {
        const labels = HomePageConstants.navigationLabels.projects;
        return {
            projects: {
                requests: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.requests),
                portfolios: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.portfolios),
                projects: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.projects),
                tasks: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.tasks),
                risks: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.risks),
                issues: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.issues),
                changes: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.changes),
                documents: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.documents),
                resources: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.resources),
                reports: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.reports)
            }
        };
    }

    static get mySharedDocumentsSection() {
        const pageSection = HomePageConstants.mySharedDocuments;
        const window = HomePageConstants.addADocumentWindow;
        const xpathUsingAriaLabel = `//input[@aria-label='${window.chooseFileButtonAriaLabel}']`;
        return {
            addDocument: {
                addNewDocumentButton: element(By.id(pageSection.newButtonID)),
                addADocumentHeader: element(By.id(window.addADocumentTitle)),
                chooseFileButton: element(By.xpath(xpathUsingAriaLabel)),
                okButton: element(By.id(window.okButtonID)),
                cancelButton: element(By.id(window.cancelButtonID))
            }
        };
    }

    static async uploadedFile(filename: string) {
        const xpathForUploadedFile = `//td[@role='gridcell']//a[contains(@href,'${filename}')]`;
        return element(By.xpath(xpathForUploadedFile));
    }
}
