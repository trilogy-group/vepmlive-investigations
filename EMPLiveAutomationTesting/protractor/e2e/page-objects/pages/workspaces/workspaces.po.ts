import {BasePage} from '../base-page';
import {WorkspacesConstants} from './workspaces.constants';
import {element, By} from 'protractor';
import {ComponentHelpers} from '../../../components/devfactory/component-helpers/component-helpers';
import {CommonPageHelper} from '../common/common-page.helper';
import {TextComponentSelectors} from '../../../components/component-types/text-component/text-component-selectors';
import {HtmlHelper} from '../../../components/misc-utils/html-helper';
import {AnchorHelper} from '../../../components/html/anchor-helper';

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

    static get allWorkspaceListing(){
        const divXpath = `//div[@id='${HtmlHelper.attributeValue.subWorkspaces}']`;
        const liXpath = `//li[contains(@class,'${HtmlHelper.attributeValue.navTrans}')]`;
        const xpath = `${divXpath}${liXpath}`;
        return element(By.xpath(xpath));
    }

    static get workspaceEllipsis(){
        return element(By.css('#epm-nav-sub-workspaces .icon-ellipsis-horizontal'));
    }

    static get contextMenu(){
        const option = WorkspacesConstants.contextMenu;
        return {
            editTeam: AnchorHelper.getAnchorByText(option.editTeam),
            remove: AnchorHelper.getAnchorByText(option.remove)
        };
    }

    static get editTeamPopupHeading(){
        return CommonPageHelper.getElementByTitle(WorkspacesConstants.editTeam);
    }
}
