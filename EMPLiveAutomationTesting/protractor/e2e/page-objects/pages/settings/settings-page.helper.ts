import {By, element} from 'protractor';
import {SettingsPage} from './settings.po';
import {HtmlHelper} from '../../../components/misc-utils/html-helper';
import {PageHelper} from '../../../components/html/page-helper';
import {ComponentHelpers} from '../../../components/devfactory/component-helpers/component-helpers';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {CommonPage} from '../common/common.po';

export class SettingsPageHelper {

    static getConfigureEditableFieldXPath(sectionHeader: string,
                                          subHeader: string,
                                          sectionHeaderIsContains = false,
                                          subHeaderIsContains = false,
                                          tag = HtmlHelper.tags.select) {
        return `//*[contains(@class,'ms-sectionheader') and
        ${ComponentHelpers.getXPathFunctionForDot(sectionHeader, sectionHeaderIsContains)}]
        //following-sibling::td//td[${ComponentHelpers.getXPathFunctionForDot(subHeader, subHeaderIsContains)}]
        //following-sibling::td//${tag}`;
    }

    static async configureEditableField(sectionHeader: string,
                                        subHeader: string,
                                        value: string,
                                        sectionHeaderIsContains = false,
                                        subHeaderIsContains = false,
                                        tag = HtmlHelper.tags.select) {

        const selector = this.getConfigureEditableFieldXPath(sectionHeader,
            subHeader,
            sectionHeaderIsContains,
            subHeaderIsContains,
            tag);
        const checkbox = element(By.xpath(selector));

        while (!(await checkbox.isPresent())
        && (await SettingsPage.pagination.next.isPresent())
        && (await SettingsPage.pagination.next.isEnabled())) {
            await PageHelper.click(SettingsPage.pagination.next);
        }

        await expect(await checkbox.isPresent())
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(subHeader));
        await PageHelper.sendKeysToInputField(checkbox, value);

        while (!(await CommonPage.formButtons.ok.isPresent())
        && (await SettingsPage.pagination.next.isPresent())
        && (await SettingsPage.pagination.next.isEnabled())) {
            await PageHelper.click(SettingsPage.pagination.next);
        }
        await PageHelper.click(CommonPage.formButtons.okOutsideTable.get(2));

    }
}
