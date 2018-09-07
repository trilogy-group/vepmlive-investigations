import {CommonPageConstants} from '../../common/common-page.constants';

export class EventsPageConstants {
    static readonly events = 'Events';
    static readonly newEvent = 'New Event';
    static readonly pagePrefix = 'Events';
    static readonly pageName = `${EventsPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly newEventItem = 'Events.New.NewListItem';
    static readonly editPageName = `${EventsPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;
    static readonly addEvent = 'Add';

    static get inputLabels() {
        return {
            title: 'Title *',
            location: 'Location',
            startTime: 'Start Time *',
            endTime: 'End Time *',
            description: 'Description',
            category: 'Category',
        };
    }

    static get categoryOption() {
        return {
            meeting: 'Meeting',
            workHours: 'Work hours',
            business: 'Business',
            holiday: 'Holiday',
            getTogether: 'Get-together',
            gifts: 'Gifts',
            birthday: 'Birthday',
            anniversary: 'Anniversary'
        };
    }

    static get inputFields() {
        return {
            title: 'Title Required Field',
            category: 'Category: Choice Drop Down',
            startTime: 'Start Time Required Field',
        };
    }
}
