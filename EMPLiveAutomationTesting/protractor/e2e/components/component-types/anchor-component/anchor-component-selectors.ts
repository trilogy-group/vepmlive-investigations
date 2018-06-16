import {ModelComponentSelectors} from '../modal-component/model-component-selectors';
import {ComponentHelpers} from '../../devfactory/component-helpers/component-helpers';
import {HtmlHelper} from '../../misc-utils/html-helper';

export class AnchorComponentSelectors {
    public static getAnchorForTextXpath(
        text: string,
        textIsContains = false,
        insidePopup = false
    ) {
        return `${ModelComponentSelectors.getModelPopupXpath(insidePopup)}` +
            `${ComponentHelpers.getElementByTagXpath(
                HtmlHelper.tags.a,
                text,
                textIsContains,
            )}`;
    }
}
