import {BasePage} from '../../base-page';
import {PortfolioItemPageConstants} from './portfolio-item-page.constants';
import {CommonPageHelper} from '../../common/common-page.helper';

export class PortfolioItemPage extends BasePage {
    static get inputs() {
        const labels = PortfolioItemPageConstants.inputLabels;
        return {
            portfolioName: CommonPageHelper.getTextBoxByLabel(labels.portfolioName),
            portfolioDescription: CommonPageHelper.getTextAreaByLabel(labels.portfolioDescription),
            portfolioType: CommonPageHelper.getSelectByLabel(labels.portfolioType),
            portfolioGoals: CommonPageHelper.getSelectByLabel(labels.portfolioGoals),
            state: CommonPageHelper.getSelectByLabel(labels.state),
            budget: CommonPageHelper.getTextBoxByLabel(labels.budget),
            plannedBenefit: CommonPageHelper.getTextBoxByLabel(labels.plannedBenefit)
        };
    }

}
