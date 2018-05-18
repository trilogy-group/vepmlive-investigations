import {MyWorkPageConstants} from './my-work-page.constants';
import {element, By} from 'protractor';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {CommonPageConstants} from '../../common/common-page.constants';

export class MyWorkPage {

    static get newItem() {
        return element(By.xpath(`//*[contains(@id,'${MyWorkPageConstants.title.newItem}')]//span[@class='ms-cui-ctl-largelabel']`));
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

    static menuItem (option: string) {
        return element(By.xpath(`//*[contains(@id,'${option}')]`));
    }

    static dialogWindowTitle (title: string) {
        return CommonPageHelper.getElementByTitle(`${title}`);
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

    static getInputByTitle (text: string) {
        return element(By.xpath(`//input[@title='${text}']`));
    }

    static selectValueFromSuggestions (text: string) {
        return element(By.xpath(`//div[.='${text}']`));
    }

     static get dropdownAll() {
        const dropdownLabel = CommonPageConstants.dropdownShowAllButton;
        return {
            project: this.getDropdownValue(dropdownLabel.project),
            timeOffType: this.getDropdownValue(dropdownLabel.timeOffType),
            timeOffInput: this.selectDropdownOption(MyWorkPageConstants.inputDropdownValues.Holiday),
        };
    }

    static getDropdownValue(id: string) {
        return element(By.id(`${id}`));
    }

    static selectDropdownOption(option: string) {
        return element(By.xpath(`//div[${ComponentHelpers.getXPathFunctionForText(option)}]`));
    }

}
