import {MyWorkPageConstants} from './my-work-page.constants';
import {By, element} from 'protractor';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {CommonPageConstants} from '../../common/common-page.constants';
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

    static get fileUploadControl() {
        return element(By.id('onetidIOFile'));
    }

    static get lastButton() {
        return AnchorHelper.getAnchorByText(MyWorkPageConstants.last);
    }

    static get selectedTitle() {
        return element(By.css('.GMClassSelected .EPMLiveMyWorkTitle div'));
    }

    static get searchTextBox() {
        return element(By.id('MWG_Search'));
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
}
