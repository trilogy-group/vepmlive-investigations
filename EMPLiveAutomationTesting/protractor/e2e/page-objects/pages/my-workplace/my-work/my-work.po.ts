import { MyWorkPageConstants } from './my-work-page.constants';
import {element, By} from 'protractor';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';

export class MyWorkPage {

    static get newItem() {
        return element(By.xpath(`//*[@id='${MyWorkPageConstants.newItemMenu.newItem}']//span[@class='ms-cui-ctl-largelabel']`));
    }

    static get newItemMenu() {
        const labels = MyWorkPageConstants.newItemMenu;
        return {
            changesItem: this.menuItem(labels.changesItem),
            issuesItem: this.menuItem(labels.issuesItem),
            risksItem: this.menuItem(labels.risksItem),
            timeOffItem: this.menuItem(labels.timeOffItem),
            toDoItem: this.menuItem(labels.toDoItem),
        };
    }

    static menuItem (option: string) {
        return element(By.xpath(`//*[@id="${option}"]`));
    }

    static dialogWindowTitle (title: string) {
        return CommonPageHelper.getElementByTitle(`${title}`);
    }

    static get inputs() {
        const labels = MyWorkPageConstants.inputLabels;
        return {
            title: CommonPageHelper.getTextBoxByLabel(labels.title),
            project: CommonPageHelper.getFirstAutoCompleteByLabel(labels.project),
            assignedTo: this.inputValue(labels.assignedTo),
            start: CommonPageHelper.getElementByTitle(labels.start),
            finish: CommonPageHelper.getElementByTitle(labels.finish),
            timeOffType: CommonPageHelper.getFirstAutoCompleteByLabel(labels.project),
            requestor: this.inputValue(labels.requestor),
        };
    }

    static inputValue (text: string) {
        return element(By.xpath(`//input[@title='${text}']`));
    }

    static selectInputValue (text: string) {
        return element(By.xpath(`//div[.='${text}']`));
    }

    static get dropdownAll() {
        const dropdownLabel = MyWorkPageConstants.inputShowAllDropdown;
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
