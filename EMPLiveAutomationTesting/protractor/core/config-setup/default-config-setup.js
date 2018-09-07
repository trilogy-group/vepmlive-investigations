const browserList = require('./browser-list.js');
const testrail = require("testrail-api");
const setupUtilities = require('./setup-utilities');
const browserStackBrowser = browserList[setupUtilities.getParam("chrome", "--params.browserstack.browser", false)];
const maxBrowserInstances = process.env.MAX_INSTANCES || setupUtilities.getParam(5, "--params.maxInstances", false);
const useHeadlessBrowser = process.env.HEADLESS_BROWSER || setupUtilities.toBoolean(setupUtilities.getParam(false, "--params.headlessBrowser", false));
const chromeHeadlessArgs = ['--headless', '--disable-gpu', '--window-size=1280x800', '--disable-dev-shm-usage', '--no-sandbox', '--disable-blink-features=BlockCredentialedSubresources',
    '--disable-web-security'];
/*  ABOUT --disable-dev-shm-usage:
    By default, Docker runs a container with a /dev/shm shared memory space 64MB.
    This is typically too small for Chrome and will cause Chrome to crash when rendering large pages.
    To fix, run the container with docker run --shm-size=1gb to increase the size of /dev/shm.
    Since Chrome 65, this is no longer necessary. Instead, launch the browser with the --disable-dev-shm-usage flag
    sources:
        - https://github.com/GoogleChrome/puppeteer/blob/master/docs/troubleshooting.md#tips
        - https://developers.google.com/web/tools/puppeteer/troubleshooting
*/
const chromeOptions = {
    args: useHeadlessBrowser ? chromeHeadlessArgs : ['--disable-xss-auditor','--disable-blink-features=BlockCredentialedSubresources','--disable-web-security'],
    // Set download path and avoid prompting for download even though
    // this is already the default on Chrome but for completeness
    prefs: {
        'download': {
            'prompt_for_download': false,
            'directory_upgrade': true,
            'default_directory': 'Downloads'
        }
    }
};
const configSetup = {
    restartBrowserBetweenTests: true,
    SELENIUM_PROMISE_MANAGER: false,
    multiCapabilities: [{
        browserName: 'chrome',
        'chromeOptions': chromeOptions,
        shardTestFiles: 'true',
        maxInstances: maxBrowserInstances
    }],
    allScriptsTimeout: 300000,
    suites: {
        health_tests: './e2e/test-suites/health-check-test-suite/**/*.e2e-spec.ts',
        api_tests: './e2e/test-suites/api-test-suite/**/*.e2e-spec.ts',
        smoke_tests: 'e2e/test-suites/smoke-test-suite/**/*.e2e-spec.ts',
        regression_tests: './e2e/test-suites/regression-test-suite/**/*.e2e-spec.ts',
        end_to_end_tests: './e2e/test-suites/end-to-end-scenarios/**/*.e2e-spec.ts'
    },
    capabilities: {
        "browserName": "chrome",
        'chromeOptions': chromeOptions
    },
    bsMultiCapabilities: [{
        name: `${browserStackBrowser.os} ${browserStackBrowser.os_version}-${browserStackBrowser.browserName} v ${browserStackBrowser.browser_version || 'Latest'}`,
        'browserName': browserStackBrowser.browserName,
        'browser_version': browserStackBrowser.browser_version,
        'os': browserStackBrowser.os,
        'os_version': browserStackBrowser.os_version,
        'resolution': browserStackBrowser.resolution,
        'browserstack.user': process.env.BROWSERSTACK_USERNAME || setupUtilities.getParam("", "--params.browserstack.user", false),
        'browserstack.key': process.env.BROWSERSTACK_ACCESS_KEY || setupUtilities.getParam("", "--params.browserstack.key", false),
        'browserstack.local': process.env.BROWSERSTACK_LOCAL || setupUtilities.getParam(true, "--params.browserstack.local", false),
        'browserstack.localIdentifier': process.env.BROWSERSTACK_LOCAL_IDENTIFIER,
        'build': process.env.BROWSERSTACK_BUILD || setupUtilities.getParam('Local Build - ' + new Date().toISOString(), "--params.browserstack.build", false),
        'browserstack.debug': 'true',
        'acceptSslCerts': 'true',
        'trustAllSSLCertificates': 'true',
        'browserstack.timezone': 'UTC',
        'browserstack.safari.allowAllCookies': 'true',
        shardTestFiles: true,
        maxInstances: maxBrowserInstances
    }],
    params: {
        maxInstances: 5,
        maxSessions: 5,
        testrail: {
            projectId: process.env.TESTRAIL_PROJECT_ID || setupUtilities.getParam(345, "--params.testrail.projectId", false),
            milestoneName: process.env.TESTRAIL_MILESTONE_NAME || setupUtilities.getParam("Automation milestone week", "--params.testrail.milestoneName", false),
            versionName: process.env.VERSION || setupUtilities.getParam("Default version name", "--params.testrail.versionName", false),
            host: process.env.TESTRAIL_HOST || setupUtilities.getParam("https://testrail.devfactory.com/", '--params.testrail.host', false),
            user: process.env.TESTRAIL_USER || setupUtilities.getParam('testrail.automation@aurea.com', "--params.testrail.user", false),
            password: process.env.TESTRAIL_PASSWORD || setupUtilities.getParam('Dav8B6Mgcoa7Fcb1DqJK-qvEoZ0400eKfqw82Bh.F', '--params.testrail.password', false)
        },
        version: process.env.VERSION || setupUtilities.getParam('7.5.0', "--params.testrail.versionName", false),
        selenium: {
            hub: process.env.SELENIUM_URL || setupUtilities.getParam('http://10.69.8.112:4444/wd/hub', "--params.selenium.hub", false)
        },
        browserstack: {
            user: '', //Don't specify anything here it's just for a reference purpose that it can be a param
            key: '',//Don't specify anything here it's just for a reference purpose that it can be a param
            local: '',//Don't specify anything here it's just for a reference purpose that it can be a param
            localIdentifier: '',//Don't specify anything here it's just for a reference purpose that it can be a param
            build: '',//Don't specify anything here it's just for a reference purpose that it can be a param
        },
        login: {
            admin: {
                user: "AdminT01",
                password: "Pass@word1"
            },
            projectManager: {
                user: "project.manager",
                password: "Pass@word1"
            },
            teamMember: {
                user: "User01T01",
                password: "Pass@word1"
            },
            portfolioManager: {
                user: "portfolio.manager",
                password: "Pass@word1"
            },
            reportViewer: {
                user: "report.viewer",
                password: "Pass@word1"
            },
            reportWriter: {
                user: "report.writer",
                password: "Pass@word1"
            },
            resourceManager: {
                user: "resource.manager",
                password: "Pass@word1"
            },
            executiveUser: {
                user: "executive.user",
                password: "Pass@word1"
            }
        }
    },
    baseUrl: 'http://tenant01.social.com',
    framework: 'jasmine',
    jasmineNodeOpts: {
        showColors: true,
        defaultTimeoutInterval: 300000,
        print: function () {
        }
    }
};
module.exports = configSetup;
