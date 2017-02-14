package com.epm.data;


import java.util.Map;

import org.apache.commons.lang3.StringUtils;
import org.openqa.selenium.remote.BrowserType;
import org.openqa.selenium.remote.CapabilityType;
import org.openqa.selenium.remote.DesiredCapabilities;

import com.google.common.collect.ImmutableMap;

/**
 * Browser enum contains all the possible types of browsers we can run in our automation testing.
 */
public enum Browser {
    // Local firefox driver for easy testing.
    LocalFirefox(WebDriverType.FireFoxDriver,
                 DesiredCapabilities.firefox(),
                 ImmutableMap.of(CapabilityType.PROXY, CapabilityTypeConstants.SELENIUM_DIRECT_PROXY)),

 
    RemoteFirefox(WebDriverType.RemoteWebDriver,
                 DesiredCapabilities.firefox(),
                 ImmutableMap.of(CapabilityType.PROXY, CapabilityTypeConstants.SELENIUM_DIRECT_PROXY)),

    RemoteChrome(WebDriverType.RemoteWebDriver,
                 DesiredCapabilities.chrome(),
                 ImmutableMap.of(CapabilityType.PROXY, CapabilityTypeConstants.SELENIUM_DIRECT_PROXY));

    private WebDriverType webDriverType;
    private DesiredCapabilities desiredCapabilities;
    private String customUserAgent;

    Browser(final WebDriverType webDriverType,
            final DesiredCapabilities defaultCapabilities,
            final Map<String, ?> extraCapabilities,
            final String customUserAgent) {
        this(webDriverType, defaultCapabilities, extraCapabilities);
        this.customUserAgent = customUserAgent;
    }

    Browser(final WebDriverType webDriverType,
            final DesiredCapabilities defaultCapabilities,
            final Map<String, ?> extraCapabilities) {
        this.webDriverType = webDriverType;
        this.desiredCapabilities = new DesiredCapabilities(defaultCapabilities);
        this.desiredCapabilities.merge(new DesiredCapabilities(extraCapabilities));

        // we always want the ability to take screenshots unless its headless
        if (!StringUtils.containsIgnoreCase(this.name(), "headless")) {
            this.desiredCapabilities.setCapability(CapabilityType.TAKES_SCREENSHOT, true);
        }
    }

    /**
     * Capabilities of the browser that are required.
     * 
     * @return
     */
    public DesiredCapabilities getDesiredCapabilities() {
        return desiredCapabilities;
    }

    /**
     * Custom user agent for the browser, if required, returns null if no customization of user agent is required.
     * 
     * @return
     */
    public String getCustomUserAgent() {
        return customUserAgent;
    }

    /**
     * The type of webdriver to use to initialize the browser.
     * 
     * @return
     */
    public WebDriverType getWebDriverType() {
        return webDriverType;
    }
}
