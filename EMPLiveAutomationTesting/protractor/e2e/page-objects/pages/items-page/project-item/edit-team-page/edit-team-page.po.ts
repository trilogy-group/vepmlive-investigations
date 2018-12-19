import {BasePage} from '../../../base-page';
import {By, element} from 'protractor';

export class EditTeamPage extends BasePage {
    static get viewReportMenus() {
        return {
            resourceCapacityHeatMap: element(By.xpath('//span[text() ="Resource Capacity Heat Map"]//parent::a')),
            resourceCommitments: element(By.xpath('//span[text() ="Resource Commitments"]//parent::a')),
            resourceAvailableVsPlannedByDept: element(By.xpath('//span[text() ="Resource Available vs. Planned by Dept"]//parent::a')),
            resourceWorkVsCapacity: element(By.xpath('//span[text() ="Resource Work vs. Capacity"]//parent::a'))
        };
    }

    static get viewReport() {
        return element(By.id('Ribbon.BuildTeam.ToolsGroup.Reports-Medium'));
    }
}
