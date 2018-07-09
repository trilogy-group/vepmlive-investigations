import {MyWorkPageConstants} from './my-work-page.constants';
import {By, element} from 'protractor';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {CommonPageConstants} from '../../common/common-page.constants';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import {AnchorHelper} from '../../../../components/html/anchor-helper';

export class MyWorkPage {

    static get newItem() {
        return element(By.xpath(`//*[contains(@id,'${MyWorkPageConstants.title.newItem}')]
        //span[contains(@class,'ms-cui-ctl-largelabel')]`));
    }

    static get newItemMenu() {
        const labels = MyWorkPageConstants.title;
        return {
            changesItem: this.menuItem(labels.changesItem),
            issuesItem: this.menuItem(labels.issues),
            risksItem: this.menuItem(labels.risks),
            timeOffItem: this.menuItem(labels.timeOff),
            toDoItem: this.menuItem(labels.toDo),
        };
    }

    static get widowTitleName() {
        const labels = MyWorkPageConstants.pageName;
        return {
            changes: this.dialogWindowTitle(labels.changes),
            issues: this.dialogWindowTitle(labels.issues),
            risks: this.dialogWindowTitle(labels.risks),
            timeOff: this.dialogWindowTitle(labels.timeOff),
            toDo: this.dialogWindowTitle(labels.toDo),
        };
    }

    static get inputs() {
        const labels = MyWorkPageConstants.inputLabels;
        return {
            title: CommonPageHelper.getTextBoxByLabel(labels.title),
            project: CommonPageHelper.getFirstAutoCompleteByLabel(labels.project),
            assignedTo: this.getInputByTitle(labels.assignedTo),
            start: CommonPageHelper.getElementByTitle(labels.start),
            finish: CommonPageHelper.getElementByTitle(labels.finish),
            timeOffType: CommonPageHelper.getFirstAutoCompleteByLabel(labels.project),
            requestor: this.getInputByTitle(labels.requestor),
        };
    }

    static get dropdownAll() {
        const dropdownLabel = CommonPageConstants.dropdownShowAllButton;
        return {
            project: element(By.id(dropdownLabel.project)),
            timeOffType: element(By.id(dropdownLabel.timeOffType)),
            timeOffInput: this.selectDropdownOption(MyWorkPageConstants.inputDropdownValues.Holiday),
        };
    }

    static menuItem(option: string) {
        return element(By.css(`[id*='${option}']`));
    }

    static dialogWindowTitle(title: string) {
        return CommonPageHelper.getElementByTitle(`${title}`);
    }

    static getInputByTitle(text: string) {
        return element(By.css(`input[title*='${text}']`));
    }

    static selectValueFromSuggestions(text: string) {
        return element(By.xpath(`//div[${ComponentHelpers.getXPathFunctionForText(text)}]`));
    }

    static selectDropdownOption(option: string) {
        return element(By.xpath(`//div[${ComponentHelpers.getXPathFunctionForText(option)}]`));
    }

    static get editPageDropdown() {
        const idXpath = `//*[contains(@id,'${MyWorkPageConstants.edit}')]`;
        const anchorXpath = `//a[contains(@class,'${HtmlHelper.attributeValue.dropdown}')]`;
        const xpath = `${idXpath}${anchorXpath}`;
        return element(By.xpath(xpath));
    }

    static get disabledStopEditingOption() {
        const stopEditingXpath = `//a[contains(@id,'${MyWorkPageConstants.editPageActions.stopEditing}') and @aria-disabled="true"]`;
        return element(By.xpath(stopEditingXpath));
    }

    static get editPageMenuOption() {
        return AnchorHelper.getAnchorById(MyWorkPageConstants.editPageActions.editPage, true);
    }

    static get editPage() {
        return element(By.css('#DeltaPlaceHolderMain'));
    }

    static get selectedPageTab() {
        return element(By.xpath(`.//*[@aria-selected="true" and @title='${CommonPageConstants.ribbonMenuTitles.page}']`));
    }
}
