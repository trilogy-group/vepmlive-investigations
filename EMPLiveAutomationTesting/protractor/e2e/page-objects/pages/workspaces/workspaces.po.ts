import {BasePage} from '../base-page';
import {WorkspacesConstants} from './workspaces.constants';
import {element, By} from 'protractor';
import {ComponentHelpers} from '../../../components/devfactory/component-helpers/component-helpers';
import {CommonPageHelper} from '../common/common-page.helper';
import {TextComponentSelectors} from '../../../components/component-types/text-component/text-component-selectors';

export class WorkSpacesPage extends BasePage {

    static get titleInputField(){
        return element(By.id('tbWsName'));
    }

    static get descInputField(){
        return element(By.id('tbWsDescription'));
    }

    static get createWorkSpaceButton(){
        return element(By.xpath(`//button[${ComponentHelpers.getXPathFunctionForText(WorkspacesConstants.windowTitle)}]`));
    }

    static get newWorkSpaceButton(){
        return CommonPageHelper.getElementByText(WorkspacesConstants.newWorkspace);
    }

    static get openPermission(){
        return element(By.id('permsOpen'));
    }

    static get projectTemplate(){
        return element(By.xpath(`//div/span[text() = '${WorkspacesConstants.projectTemplate}']`));
    }

    static get workspacesMenuOptions() {
        const label = WorkspacesConstants.workspacesMenuOptions;
        return {
            newWorkspace: CommonPageHelper.getSpanByText(label.newWorkspace),
            favoriteWorkspaces: TextComponentSelectors.getListByText(label.favoriteWorkspaces),
            allWorkspaces: TextComponentSelectors.getListByText(label.allWorkspaces),
        };
    }
}
