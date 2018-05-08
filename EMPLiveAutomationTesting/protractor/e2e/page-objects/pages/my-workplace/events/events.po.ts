import {CommonPageHelper} from '../../common/common-page.helper';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import {EventsPageConstants} from './events-page.constants';
import {CommonPageConstants} from '../../common/common-page.constants';

export class EventsPage {

    static get eventsTab() {
        return CommonPageHelper.getSpanByTextInsideUnorderedListByRole(HtmlHelper.tags.tabList, EventsPageConstants.events);
    }

    static get newEvent() {
        return CommonPageHelper.getSpanContainsId(EventsPageConstants.newEventItem);
    }

    static get titleTextField() {
         return CommonPageHelper.getElementByTitle(EventsPageConstants.titleInput);
    }

    static get categoryField() {
        return CommonPageHelper.getElementByTitle(EventsPageConstants.categoryField);
    }

    static get categoryOption() {
        return CommonPageHelper.getOptionByText(EventsPageConstants.categoryOption.meeting);
    }

    static get calenderBlock() {
        return CommonPageHelper.getDivContainsTitle(CommonPageConstants.title);
    }
}
