import {CommonPageConstants} from '../../common/common-page.constants';

export class EventsPageConstants {
    static readonly events = 'Events';
    static readonly newEvent = 'New Event';
    static readonly pagePrefix = 'Events';
    static readonly pageName = `${EventsPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly newEventItem= 'Events.New.NewListItem';
    static readonly editPageName = `${EventsPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;
    static readonly titleInput= 'Title Required Field';
    static readonly startTimeField= 'Start Time Required Field';
    static readonly categoryField= 'Category: Choice Drop Down';

    static get inputLabels() {
        return {
            title: 'Title *',
        };
    }

    static get categoryOption() {
        return {
            meeting: 'Meeting',
        };
    }
}
