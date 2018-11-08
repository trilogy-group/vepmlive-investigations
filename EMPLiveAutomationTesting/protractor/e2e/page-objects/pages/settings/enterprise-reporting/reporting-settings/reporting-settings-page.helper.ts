import {browser, By, element} from 'protractor';
import {CommonPage} from '../../../common/common.po';
import {SettingsPage} from '../../settings.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ReportingSettingsPageConstants} from './reporting-settings-page.constants';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ReportManagerPageValidation} from './report-manager/report-manager-page.validation';
import {Constants} from '../../../../../components/misc-utils/constants';
import {ReportingSettingsPage} from './reporting-settings.po';
import {ReportManagerPageConstants} from './report-manager/report-manager-page.constants';
import {ReportManagerPage} from './report-manager/report-manager.po';
import {CommonPageHelper} from '../../../common/common-page.helper';

export class ReportingSettingsPageHelper {
    static getTopMenus(name: string) {
        return element(By.css(`li[text_original="${name}"]`));
    }

    static async navigateTo() {
        StepLogger.stepId(1);
        StepLogger.step('Click on "Main Gear Settings" icon  displayed in left bottom corner');
        await PageHelper.click(CommonPage.sidebarMenus.settings);
        const enterpriseReportingMenus = SettingsPage.menuItems.enterpriseReporting;
        StepLogger.verification('Various Settings Options displayed');
        await expect(await PageHelper.isElementDisplayed(enterpriseReportingMenus.rootMenu))
            .toBe(true, '');
        StepLogger.stepId(2);
        StepLogger.step('Expand "Enterprise Reporting" node');
        await PageHelper.click(enterpriseReportingMenus.rootMenu);
        StepLogger.verification('"Enterprise Reporting" node is expanded and sub options displayed below the node');
        StepLogger.step('Click on "Reporting Settings" sub node displayed under "Enterprise Reporting" node');
        await PageHelper.click(SettingsPage.menuItems.enterpriseReporting.childMenus.reportingSettings);
        StepLogger.verification('"Mapped Lists" page is displayed');
        await CommonPageHelper.pageDisplayedValidation(ReportingSettingsPageConstants.pageName);

    }

    static async clickSettingLink() {
        StepLogger.step(`Click on 'Settings' link displayed on top of the page`);
        await PageHelper.click(ReportingSettingsPage.topMenus.settings.menu);
    }

    static async clickRefreshSchedule() {
        StepLogger.step(`Select 'Refresh Schedule' from the options displayed`);
        await PageHelper.click(ReportingSettingsPage.topMenus.settings.childMenu.refreshSchedule);
    }

    static async clickRunButton() {
        StepLogger.step('Click on "Run Now" button');
        await PageHelper.click(ReportManagerPage.formControls.runNow);
    }

    static async refreshBrowserTileLastRunPresent() {
        StepLogger.step('Refresh the page using browser Refresh button');
        const lastRunLabel = ReportManagerPage.formControls.lastRun;
        let maxAttempts = 0;
        while (!((await lastRunLabel.getText()).trim() !== Constants.EMPTY_STRING) && maxAttempts++ < 20) {
            await browser.refresh();
            await browser.sleep(PageHelper.timeout.s);
        }
    }

    static async runSchedule() {
        StepLogger.stepId(1);
        await this.clickSettingLink();

        await this.clickRefreshSchedule();

        StepLogger.verification('"Report Manager" Page is displayed');
        await CommonPageHelper.pageDisplayedValidation(ReportManagerPageConstants.pageName);

        StepLogger.stepId(2);
        await this.clickRunButton();

        StepLogger.verification('Last Result - commonly "No Errors" displayed ]');
        await expect(await PageHelper.getText(ReportManagerPage.formControls.messages))
            .toBe(ReportManagerPageConstants.queued,
                ReportManagerPageValidation.lastResultValidation);
    }
}
