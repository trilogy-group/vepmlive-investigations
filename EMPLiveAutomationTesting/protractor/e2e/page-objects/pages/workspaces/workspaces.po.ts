import {BasePage} from '../base-page';
import { CommonPageHelper } from '../common/common-page.helper';
import { HtmlHelper } from '../../../components/misc-utils/html-helper';
import { WorkspacesConstants } from './workspaces.constants';
import { element, By } from 'protractor';
import { ElementHelper } from '../../../components/html/element-helper';
import { ComponentHelpers } from '../../../components/devfactory/component-helpers/component-helpers';


export class workspacesPage extends BasePage {

    static get titleInputField(){
        return CommonPageHelper.getAllElementsByType(HtmlHelper.tags.textBox).first();
    }  

    static get descInputField(){
        return CommonPageHelper.getAllElementsByType(HtmlHelper.tags.textBox).last();
    }  

    static get createWSButton(){
        return element(By.xpath(`//button[${ComponentHelpers.getXPathFunctionForText(WorkspacesConstants.windowTitle)}]`));

    }  

    static get newWSButton(){
        return ElementHelper.getElementByText(WorkspacesConstants.newWorkspace);
    } 
    
    static get openPermission(){
        return element(By.id('permsOpen'));
    } 
    
    static get projectTemplate(){
        return element.all(By.className('template-meta')).last();
    } 
}
