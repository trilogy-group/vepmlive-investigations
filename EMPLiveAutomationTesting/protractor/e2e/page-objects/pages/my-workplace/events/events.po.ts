import {CommonPageHelper} from '../../common/common-page.helper';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import {EventsPageConstants} from './events-page.constants';
import {CommonPageConstants} from '../../common/common-page.constants';
import {element, By} from 'protractor';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';

export class EventsPage {

    static get eventsTab() {
        return CommonPageHelper.getSpanByTextInsideUnorderedListByRole(HtmlHelper.tags.tabList, EventsPageConstants.events);
    }

    static get newEvent() {
        return CommonPageHelper.getElementContainsId(EventsPageConstants.newEventItem);
    }

    static get currentView() {
        return element(By.xpath('.//*[@id="Ribbon.Calendar.Calendar.CustomViews.DisplayView"]'));
    }

    static get titleTextField() {
         return CommonPageHelper.getElementByTitle(EventsPageConstants.inputFields.title);
    }

    static get categoryField() {
        return CommonPageHelper.getElementByTitle(EventsPageConstants.inputFields.category);
    }

    static get defaultCheckbox() {
        return element(By.id('onetidIOCheckDefaultView'));
    }

    static get categoryOption() {
        return element(By.xpath(`//option[${ComponentHelpers.getXPathFunctionForText(EventsPageConstants.categoryOption.meeting)}]`));
    }

    static get calenderBlock() {
        return CommonPageHelper.getElementContainsTitle(CommonPageConstants.title);
    }

    static get calenderTab() {
        return element(By.xpath('.//*[@id="Ribbon.Calendar.Calendar-title"]'));
    }

    static getelement(val: string) {
        return element(By.xpath('.//*[text()="' + val + '"]'));
    }

    static get rollOver() {
        return element(By.css('#WPQ2_ListTitleViewSelectorMenu_Container_overflow'));
    }

    static get standardViewType () {
        return element(By.xpath('.//*[contains(@href,"ViewID=1") and @id="onetCategoryHTML"]'));
    }

    static get viewName () {
        return element(By.css('#ViewName'));
    }

    static get okButton () {
        return element(By.css('#onetidSaveItemtop'));
    }

    static get createView () {
        return element(By.xpath('.//*[@id="Ribbon.Calendar.Calendar.CustomViews.CreateView-Medium"]'));
    }
}
