export class ValidationsHelper {
    static get types() {
        return {
            field: 'Field',
            page: 'Page',
            button: 'Button',
            label: 'Label',
            image: 'Image',
            window: 'Window',
            notification: 'Notification',
            grid: 'Grid',
            menu: 'Menu',
        };
    }

    static getFieldShouldHaveValueValidation(fieldLabel: string, value: string) {
        return this.getFieldValueValidation(fieldLabel, value);
    }

    static getFieldShouldNotHaveValueValidation(fieldLabel: string, value: string) {
        return this.getFieldValueValidation(fieldLabel, value, 'not');
    }

    static getFieldValueValidation(fieldLabel: string, value: string, status = '') {
        return `${this.types.field} ${fieldLabel} should ${status} have value as ${value}`;
    }

    static getPageDisplayedValidation(name: string) {
        return `${this.types.page} ${this.getDisplayedValidation(name)}`;
    }

    static getFieldDisplayedValidation(name: string) {
        return `${this.types.field} ${this.getDisplayedValidation(name)}`;
    }

    static getButtonDisplayedValidation(name: string) {
        return `${this.types.button} ${this.getDisplayedValidation(name)}`;
    }

    static getMenuDisplayedValidation(name: string) {
        return `${this.types.menu} ${this.getDisplayedValidation(name)}`;
    }

    static getLabelDisplayedValidation(name: string) {
        return `${this.types.label} '${this.getDisplayedValidation(name)}'`;
    }

    static getImageDisplayedValidation(name: string) {
        return `${this.types.image} '${this.getDisplayedValidation(name)}'`;
    }

    static getGridDisplayedValidation(name: string) {
        return `${this.types.grid} ${this.getDisplayedValidation(name)}`;
    }

    static getDeletionConfirmationDisplayedValidation(recordText: string) {
        return `Confirmation box for deletion of record which contains ${this.getDisplayedValidation(recordText)}`;
    }

    static getRecordCreatedValidation(recordText: string) {
        return this.getRecordContainsMessage(this.getDisplayedValidation(recordText));
    }

    static getRecordDeletedValidation(recordText: string) {
        return this.getRecordContainsMessage(`${recordText} has been deleted`);
    }

    static getRecordContainsMessage(message: string) {
        return `Record which contains ${message}`;
    }

    static getDisplayedValidation(name: string) {
        return `${name} should be displayed`;
    }

    static getErrorDisplayedValidation(error: string) {
        return `Error ${this.getDisplayedValidation(error)}`;
    }

    static getWindowShouldNotBeDisplayedValidation(name: string) {
        return `${this.types.window} ${this.getNotDisplayedValidation(name)}`;
    }

    static getWindowShouldBeDisplayedValidation(name: string) {
        return `${this.types.window} ${this.getDisplayedValidation(name)}`;
    }
    static getNotificationDisplayedValidation(name: string) {
        return `${this.types.notification} ${this.getDisplayedValidation(name)}`;
    }

    static getNotDisplayedValidation(name: string) {
        return `${name} should not be displayed`;
    }

    static getOnlyOneRecordShouldBeDisplayedInGrid(name: string) {
        return `There should only be 1 record displayed in grid with title ${name}`;
    }

    static getDisabledValidation(name: string) {
        return `${name} should be disabled`;
    }

    static getEnabledValidation(name: string) {
        return `${name} should be enabled`;
    }

    static getButtonDisabledValidation(name: string) {
        return `${this.types.button} ${this.getDisabledValidation(name)}`;
    }

    static getButtonEnabledValidation(name: string) {
        return `${this.types.button} ${this.getEnabledValidation(name)}`;
    }

    static getItemsUnderTabShouldBeDisplayed(name: string) {
        return `Contents of the ${this.getDisplayedValidation(name + 'tab ')}`;
    }

    static getNewViewCloumnShouldDisplayed(columnName: string) {
        return `Newly created public view ${columnName} should be selected`;
    }
}
