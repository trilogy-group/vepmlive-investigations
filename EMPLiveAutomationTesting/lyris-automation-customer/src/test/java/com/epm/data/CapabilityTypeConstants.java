package com.epm.data;

import org.openqa.selenium.Proxy;
import org.openqa.selenium.Proxy.ProxyType;

public final class CapabilityTypeConstants {
	private CapabilityTypeConstants(){};
	
public static final Proxy SELENIUM_DIRECT_PROXY=new Proxy();
static{
	 SELENIUM_DIRECT_PROXY.setProxyType(ProxyType.DIRECT);
}
}
