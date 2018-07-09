import {browser, By, element} from 'protractor';
import {CommonPage} from '../../../common/common.po';
import {SettingsPage} from '../../settings.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ReportingSettingsPageConstants} from './reporting-settings-page.constants';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ReportManagerPageValidation} from './report-manager/report-manager-page.validation';
import {Constants} from '../../../../../components/misc-utils/constants';
import {ReportingSettingsPage} from './reporting-settings.po';
import {ReportManagerPageConstants} from './report-manager/report-manager-page.constants';
import {ReportManagerPage} from './report-manager/report-manager.po';

export class ReportingSettingsPageHelper {
    static getTopMenus(name: string) {
        return element(By.css(`li[text_original="${name}"]`));
    }
   static async navigateTo(stepLogger: StepLogger) {
       stepLogger.stepId(1);
       stepLogger.step('Click on "Main Gear Settings" icon  displayed in left bottom corner');
       await PageHelper.click(CommonPage.sidebarMenus.settings);
       const enterpriseReportingMenus = SettingsPage.menuItems.enterpriseReporting;
       stepLogger.verification('Various Settings Options displayed');
       await expect(await PageHelper.isElementDisplayed(enterpriseReportingMenus.rootMenu))
       .toBe(true,   '');
       stepLogger.stepId(2);
       stepLogger.step('Expand "Enterprise Reporting" node');
       await PageHelper.click(enterpriseReportingMenus.rootMenu);
       stepLogger.verification('"Enterprise Reporting" node is expanded and sub options displayed below the node');
       stepLogger.step('Click on "Reporting Settings" sub node displayed under "Enterprise Reporting" node');
       await PageHelper.click(SettingsPage.menuItems.enterpriseReporting.childMenus.reportingSettings);
       stepLogger.verification('"Mapped Lists" page is displayed');
       await expect((await CommonPage.title.getText()).trim())
      .toBe(ReportingSettingsPageConstants.pageName,
       ValidationsHelper.getPageDisplayedValidation(ReportingSettingsPageConstants.pageName));
   }
   static async  runSchedule(stepLogger: StepLogger) {
       stepLogger.stepId(1);
       stepLogger.step(`Click on 'Settings' link displayed on top of the page`);
       await WaitHelper.getInstance().waitForElementToBeDisplayed(ReportingSettingsPage.topMenus.settings.menu);
       await PageHelper.click(ReportingSettingsPage.topMenus.settings.menu);
       stepLogger.step(`Select 'Refresh Schedule' from the options displayed`);
       await PageHelper.click(ReportingSettingsPage.topMenus.settings.childMenu.refreshSchedule);
       stepLogger.verification('"Report Manager" Page is displayed');
       await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
       await expect((await CommonPage.title.getText()).trim())
           .toBe(ReportManagerPageConstants.pageName,
               ValidationsHelper.getPageDisplayedValidation(ReportManagerPageConstants.pageName));
       stepLogger.stepId(2);
       stepLogger.step('Click on "Run Now" button');
       await PageHelper.click(ReportManagerPage.formControls.runNow);
       stepLogger.step('Refresh the page using browser Refresh button');
       const lastRunLabel = ReportManagerPage.formControls.lastRun;
       await browser.sleep(PageHelper.timeout.s);
       let maxAttempts = 0;
       while (!((await lastRunLabel.getText()).trim() !== Constants.EMPTY_STRING) && maxAttempts < 10) {
           await browser.sleep(PageHelper.timeout.s);
           maxAttempts++;
           browser.refresh();
           await browser.sleep(PageHelper.timeout.s);
       }
       stepLogger.verification('Last Result - commonly "No Errors" displayed (Note: Can display other results]');
       await expect((await ReportManagerPage.formControls.messages.getText()).trim())
           .toBe(ReportManagerPageConstants.noErrorMessage,
               ReportManagerPageValidation.lastResultValidation);
       stepLogger.verification(`Log - 'View Log' link displayed`);
       }
}
