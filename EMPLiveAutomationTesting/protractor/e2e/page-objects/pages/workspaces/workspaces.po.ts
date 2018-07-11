import { element, By } from 'protractor';
import {BasePage} from '../base-page';
import { WorkspacesConstants } from './workspaces.constants';
import { ComponentHelpers } from '../../../components/devfactory/component-helpers/component-helpers';
import {ElementHelper} from '../../../components/html/element-helper';

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
        return ElementHelper.getElementByText(WorkspacesConstants.newWorkspace);
    }

    static get openPermission(){
        return element(By.id('permsOpen'));
    }

    static get projectTemplate(){
        return element(By.xpath(`//div/span[text() = '${WorkspacesConstants.projectTemplate}']`));
    }
}
