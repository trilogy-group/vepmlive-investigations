package com.ipm.lib;

import java.io.InputStream;
import java.net.URL;

public class ClassLoaderResourceLocator extends AbstractResourceLocator {

	public ClassLoaderResourceLocator() {
		super();
	}

	public ClassLoaderResourceLocator(String prefix) {
		super(prefix);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * com.aurea.test.scumber.common.utils.ResourceLocator#getAsUrl(java.lang
	 * .String)
	 */
	@Override
	public URL getAsUrl(final String resource) {
		URL url = Thread.currentThread().getContextClassLoader().getResource(getResourceName(resource));
		return url;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * com.aurea.test.scumber.common.utils.ResourceLocator#getAsStream(java.
	 * lang.String)
	 */
	@Override
	public InputStream getAsStream(final String resource) {
		String resourceName = getResourceName(resource);
		InputStream stream = Thread.currentThread().getContextClassLoader().getResourceAsStream(resourceName);
		return stream;
	}

}
