import {By, element} from 'protractor';
import {CommonPageHelper} from '../../common/common-page.helper';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import {EventsPageConstants} from './events-page.constants';
import {CommonPageConstants} from '../../common/common-page.constants';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';

const moment = require('moment');

export class EventsPage {

    static get eventsTab() {
        return CommonPageHelper.getSpanByTextInsideUnorderedListByRole(HtmlHelper.tags.tabList, EventsPageConstants.events);
    }

    static get newEvent() {
        return CommonPageHelper.getElementContainsId(EventsPageConstants.newEventItem);
    }

    static get titleTextField() {
        return CommonPageHelper.getElementByTitle(EventsPageConstants.inputFields.title);
    }

    static get categoryField() {
        return CommonPageHelper.getElementByTitle(EventsPageConstants.inputFields.category);
    }

    static get categoryOption() {
        return element(By.xpath(`//option[${ComponentHelpers.getXPathFunctionForText(EventsPageConstants.categoryOption.meeting)}]`));
    }

    static get calenderBlock() {
        return CommonPageHelper.getElementContainsTitle(CommonPageConstants.title);
    }

    static get calenderTomorrow() {
        const currentDate = Date.now();
        let tomorrow = moment(currentDate).add(1, 'days');
        tomorrow = moment(tomorrow).format('M/DD/YYYY');
        return element(By.css(`td[date='${tomorrow}']`));
    }

    static get closeEventButton() {
        return element(By.css('[value = "Close"]'));
    }

    static get defaultCheckbox() {
        return element(By.id('onetidIOCheckDefaultView'));
    }

    static get viewName() {
        return element(By.id('ViewName'));
    }

    static get choiceCheckbox() {
        return element(By.id('onetidTypeChoice'));
    }

    static get numberCheckbox() {
        return element(By.id('onetidTypeNumber'));
    }

    static get descriptionField() {
        return element(By.id('idDesc'));
    }

    static get calenderTab() {
        return element(By.css('[id*="Calendar-title"]'));
    }

    static get standardViewType() {
        // Only id will not work
        return element(By.xpath('.//*[contains(@href,"ViewID=1") and @id="onetCategoryHTML"]'));
    }

    static get rollOverEventList() {
        return element(By.css(`[id*="overflow"]`));
    }

    static get currentView() {
        return element(By.css('a[id*="DisplayView"]'));
    }

    static get createViews() {
        return element(By.css(`[id*="CustomViews.CreateView"]`));
    }

    static get columnNameField() {
        return element(By.id('idColName'));
    }

    static get createColumn() {
        return element(By.css(`[id*="CreateColumn"]`));
    }

    static get selectColumn() {
        return element(By.css(`[id*="SelectColumns"]`));
    }

    static getNewEventAdded(titleNewEvent: string, isContains = false) {
        return element(By.xpath(`//a[${ComponentHelpers.getXPathFunctionForDot(titleNewEvent, isContains)}]`));
    }

    static addNewEvent(title: string) {
        return element(By.css(`a[title='${title}']`));
    }

    static getElementByLinkText(text: string) {
        return element(By.linkText(text));
    }

    static eventPageByTitle(title: string) {
        return CommonPageHelper.getElementUsingTextContent(title, true);
    }

    static get endDate() {
        return element(By.xpath(`//input[@title='${EventsPageConstants.endTimeField}']`));
    }

    static get editItem() {
        return element(By.id('Ribbon.ListForm.Display.Manage.EditItem2-Large'));
    }

    static get getTomorrowDate() {
        const currentDate = Date.now();
        const tomorrow = moment(currentDate).add(1, 'days');
        return  moment(tomorrow).format('MM/DD/YYYY');
    }

    static get dialog() {
        return element(By.css('.ms-dlgTitle'));
    }

    static get seeMoreLinks() {
        return element.all(By.css('a.ms-cal-nav'));
    }
}
