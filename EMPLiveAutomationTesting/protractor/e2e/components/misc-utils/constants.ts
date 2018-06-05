import {ConstantsFactory} from '@aurea/protractor-automation-helper';

export class Constants extends ConstantsFactory {
    static readonly MAX_RETRY_ATTEMPTS = 3;
    static readonly EMPTY_STRING = '';
    static readonly MONTH_NAMES = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'June', 'July', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec'];

    static get separators() {
        return {
            comma: ',',
            semiColon: ';',
            apostrophe: '\'',
            pipe: '|'
        };
    }
}
