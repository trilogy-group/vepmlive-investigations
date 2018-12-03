import { ProjectItemPage } from './project-item.po';
import { StepLogger } from '../../../../../core/logger/step-logger';
import { PageHelper } from '../../../../components/html/page-helper';
import { CommonPageHelper } from '../../common/common-page.helper';
import { CommonPage } from '../../common/common.po';
import { CommonPageConstants } from '../../common/common-page.constants';
import { HomePage } from '../../homepage/home.po';
import { ProjectItemPageHelper } from './project-item-page.helper';

export class ProjectItemSubPageHelper {

    static async navigateToProjectPage() {
        StepLogger.subVerification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
    }

    static async createProjectIfNoProjectCreated(projectName: string) {
        await this.navigateToProjectPage();
        // its better to wait for 5 sec rather than 75 sec in next steps
        await PageHelper.sleepForXSec(PageHelper.timeout.s);
        const noRecordPresent = await PageHelper.isElementDisplayed(ProjectItemPage.noProjecrMsg, false);
        let projectValue = '';
        if (noRecordPresent) {
            projectValue = await ProjectItemPageHelper.createNewProject(projectName);
        }
        return projectValue;
    }
}
