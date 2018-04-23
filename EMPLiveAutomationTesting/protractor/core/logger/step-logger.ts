import * as log4js from 'log4js';
import {Logger} from 'log4js';

declare var allure: any;

export class StepLogger {
    readonly logger: Logger;
    stepIdVar = '';

    constructor(private caseId: number, private debug = process.env.DEBUG || true) {
        this.logger = log4js.getLogger(`C${caseId}`);
    }

    stepId(id: number) {
        this.stepIdVar = `#${id}`;
        const message = `*Step Id* #${id}`;
        if (this.debug) {
            console.log(`${this.caseId}${message}`);
        }
        this.logger.debug(message);
    }

    step(stepName: string) {
        this.commonLogger('Step', stepName);
    }

    commonLogger(operation: string, step: string) {
        const message = `${this.stepIdVar} - ${operation} - ${step}`;
        if (this.debug) {
            console.log(`${this.caseId}${message}`);
        }
        if (!process.env.NO_ALLURE) {
            // tslint:disable-next-line:no-empty
            allure.createStep(message, () => {
            })();
        }
        this.logger.debug(message);
    }

    verification(verificationDescription: string) {
        this.commonLogger('Verification', verificationDescription);
    }
}
