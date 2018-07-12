const {_} = require("underscore");
const browserstack = require("browserstack-local");
const defaultConfigSetup = require('./core/config-setup/default-config-setup.js');
const reportersSetup = require('./core/config-setup/reporters-setup');
const setupUtilities = require('./core/config-setup/setup-utilities');

exports.config = {
    restartBrowserBetweenTests: defaultConfigSetup.restartBrowserBetweenTests,
    SELENIUM_PROMISE_MANAGER: defaultConfigSetup.SELENIUM_PROMISE_MANAGER,
    allScriptsTimeout: defaultConfigSetup.allScriptsTimeout,
    suites: defaultConfigSetup.suites,
    params: defaultConfigSetup.params,
    baseUrl: defaultConfigSetup.baseUrl,
    framework: defaultConfigSetup.framework,
    jasmineNodeOpts: defaultConfigSetup.jasmineNodeOpts,
    seleniumAddress: "http://hub-cloud.browserstack.com/wd/hub",
    maxSessions: process.env.MAX_SESSIONS || setupUtilities.getParam(5, "--params.maxSessions", false), // unlimited, change to desired number based on parallel count for BS account
    multiCapabilities: defaultConfigSetup.bsMultiCapabilities,
    onPrepare: function () {
        reportersSetup.configureAllReporters();
    },
    onComplete: reportersSetup.testRailSetupOnComplete,
    // Code to start browserstack local before start of test
    beforeLaunch() {
        console.log('Connecting local');
        return new Promise(function (resolve, reject) {
            exports.bs_local = new browserstack.Local();
            exports.bs_local.start({'key': defaultConfigSetup.bsMultiCapabilities.key}, function (error) {
                if (error) return reject(error);
                console.log('Connected. Now testing...');

                resolve();
            });
        });
    },

    // Code to stop browserstack local after end of test
    afterLaunch() {
        return new Promise(function (resolve, reject) {
            exports.bs_local.stop(resolve);
        });
    }
};
