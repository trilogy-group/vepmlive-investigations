import {browser, By, element} from 'protractor';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPage} from '../../common/common.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {LinkPageConstants} from './link-page.constants';
import {LinkPage} from './link.po';
import {WaitHelper} from '../../../../components/html/wait-helper';

export class LinkPageHelper {

    static async fillNewLinkFormAndVerification() {

        StepLogger.stepId(4);
        StepLogger.step(`Enter/Select below details in 'New Link' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = LinkPageConstants.inputLabels;
        const url = `https://url_${uniqueId}.com`;
        const description = `${LinkPageConstants.inputLabels.url} ${uniqueId}`;
        const notes = `${LinkPageConstants.inputLabels.notes} ${uniqueId}`;

        StepLogger.step(`Url *: http://url_randomstring.com`);
        await TextboxHelper.sendKeys(LinkPage.inputs.title.get(0), url);

        StepLogger.step(`Description *: Random description`);
        await TextboxHelper.sendKeys(LinkPage.inputs.title.get(1), description);

        StepLogger.step(`Notes: Random notes`);
        await TextboxHelper.sendKeys(LinkPage.inputs.notes, notes);

        StepLogger.verification('Required values Entered/Selected in "Edit To Do" Page');
        StepLogger.verification('Verify - URL');
        await expect(await TextboxHelper.hasValue(LinkPage.inputs.title.get(0), url))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.url, url));

        StepLogger.verification('Verify - Description');
        await expect(await TextboxHelper.hasValue(LinkPage.inputs.title.get(1), description))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.url, description));

        StepLogger.verification('Verify - Description: Random value');
        await expect(await TextboxHelper.hasValue(LinkPage.inputs.notes, notes))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.notes, notes));

        StepLogger.stepId(5);
        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"New Link" page is closed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(LinkPageConstants.pageName));

        return {
            description, url
        };
    }

    static async verifyNewLinkAdded(details: { description: string; url: string; }) {
        StepLogger.verification('Newly added Link details are displayed in the list');
        const item = element(By.linkText(details.description));
        let pagingText = await CommonPage.paging.getText();
        while (!(await item.isPresent()) && await CommonPage.paginationControlsByTitle.next.isPresent()) {
            await PageHelper.click(CommonPage.paginationControlsByTitle.next);
            // Wait if page is not the next one, Ajax operation
            await browser.wait(async () => pagingText !== await CommonPage.paging.getText());
            pagingText = await CommonPage.paging.getText();
        }
        // Always Description appears whereas we want url to assert
        await expect(await PageHelper.isElementDisplayed(item))
            .toBe(true, ValidationsHelper.getDisplayedValidation(details.url));
    }

}
