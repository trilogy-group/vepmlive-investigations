export class HomePageConstants {
    static readonly pageName = 'Home page';

    static get navigationLabels() {
        return {
            projects: {
                requests: 'Requests',
                portfolios: 'Portfolios',
                projectPortfolios: 'Project Portfolios',
                projects: 'Projects',
                projectCenter: 'Project Center',
                tasks: 'Tasks',
                risks: 'Risks',
                issues: 'Issues',
                changes: 'Changes',
                documents: 'Documents',
                resources: 'Resources',
                reports: 'Reports',
                reporting: 'Reporting'
            }
        };
    }
    static get mySharedDocuments() {
        return{
            newButtonID: 'QCB1_Button1',
            progressBarClass: 'ms-progress-meter-inner',
            progressBarCompletedWidthValue: '100%'
        };
    }

    static get addADocumentWindow() {
        return{
            iFrameAddADocument: 'DlgFrame8f53d70c-bb67-4436-a016-8a686ebdc5a0',
            iFrameClassAddADocument: 'ms-dlgFrame',
            addADocumentTitle: 'Add a document',
            closeButton: 'ms-dlgCloseBtn',
            chooseFileButtonAriaLabel: 'Enter or browse for uploading file path',
            overwriteExistingFilesLabel: 'Overwrite existing files',
            okButtonID: 'ctl00_PlaceHolderMain_ctl01_RptControls_btnOK',
            cancelButtonID: 'ctl00_PlaceHolderMain_ctl01_BtnCancel',
            okButton: 'OK',
            cancelButton: 'Cancel'
        };
    }
}
