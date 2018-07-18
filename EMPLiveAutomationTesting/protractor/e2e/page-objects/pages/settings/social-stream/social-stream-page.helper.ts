import {By, element} from 'protractor';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {ProjectItemPageHelper} from '../../items-page/project-item/project-item-page.helper';
import {HomePage} from '../../homepage/home.po';
import {CommonPage} from '../../common/common.po';
import {ProjectItemPageConstants} from '../../items-page/project-item/project-item-page.constants';
import {ElementHelper} from '../../../../components/html/element-helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {WaitHelper} from '../../../../components/html/wait-helper';

export class SocialStreamPageHelper {

    static title(value: string) {
        return element(By.css(`[title="${value}"]`));
    }
    static async addStreamAndValidateIt(stepLogger: StepLogger) {
        const uniqueId = PageHelper.getUniqueId();
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;
        const projectDescription = `${labels.projectDescription} ${uniqueId}`;
        const benefits = `${labels.benefits} ${uniqueId}`;
        const overallHealthOnTrack = CommonPageConstants.overallHealth.onTrack;
        const projectUpdateManual = CommonPageConstants.projectUpdate.manual;

        await WaitHelper.getInstance().waitForElementToBeDisplayed(HomePage.whatAreYouWorkingOnTextBox);
        stepLogger.step('Click on "Project" Link on the top menu bar');

        await ElementHelper.click(HomePage.toolBarMenuItems.project);

        stepLogger.verification('Verify Project Center - New Item window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(ProjectItemPageConstants.pageName,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.pageName));

        await PageHelper.switchToFrame(CommonPage.contentFrame);
        stepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');

        await ProjectItemPageHelper.fillForm(
            projectNameValue,
            projectDescription,
            benefits,
            overallHealthOnTrack,
            projectUpdateManual,
            stepLogger);

        await PageHelper.switchToDefaultContent();
        stepLogger.verification('Newly created Project displayed in "Project" page');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(projectNameValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(projectNameValue));
    }
}
