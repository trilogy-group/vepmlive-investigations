package com.epm.lib;

import java.util.HashSet;
import java.util.Set;

import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.epm.data.Browser;

@Configuration

public class BrowserConfiguration {



    private static final String NO_BROWSER_ERROR = "No whitelisted browsers were defined, ";

    @Bean(name = "whitelistedBrowsers")

    public Set<Browser> whitelistedBrowsers() {

        String browsers = System.getProperty("browsers");

        Set<Browser> whitelistedBrowsers = new HashSet<Browser>();

        if (StringUtils.isNotBlank(browsers)) {

            // if a whitelist is defined in the system properties, it overrides our default behavior.

            String[] browserArray = browsers.split(",");

            for (String browserString : browserArray) {

                whitelistedBrowsers.add(Browser.valueOf(browserString));

            }

        } else  {

            whitelistedBrowsers.add(Browser.RemoteChrome);

            whitelistedBrowsers.add(Browser.LocalFirefox);
            whitelistedBrowsers.add(Browser.RemoteFirefox);




        }



        // throw an exception if no whitelisted browsers could be found.

        if (whitelistedBrowsers.isEmpty()) {

            throw new UnsupportedOperationException(NO_BROWSER_ERROR);

        }



        return whitelistedBrowsers;

    }

}