export class DepartmentsPageConstants {
    static readonly pageTitle = 'Departments page';
    static readonly addNewItemPageLabel = 'Add New Item page';
    static readonly newTitleLabel = 'New';
    static readonly titleLabel = 'Title';
    static readonly managerSelectedLabel = 'Manager Selected Dropdown';
    static readonly executivesSelectedLabel = 'Executives Selected Dropdown';

    static get addNewItemOptions() {
        return {
            title: 'Title Required Field',
            parentDepartment: 'Parent Department',
            managerPossibleValue: 'Managers possible values',
            add: 'Add >',
            remove: '< Remove',
            managerSelectedValue: 'Managers selected values',
            executivesPossibleValue: 'Executives possible values',
            executivesSelectedValue: 'Executives selected values',
            save: 'Ribbon.ListForm.Edit.Commit.Publish-Large',
            cancel: 'Cancel'
        };
    }
}
