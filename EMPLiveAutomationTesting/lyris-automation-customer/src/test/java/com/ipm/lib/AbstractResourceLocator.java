package com.ipm.lib;

import java.io.File;
import java.net.URISyntaxException;
import java.net.URL;

public abstract class AbstractResourceLocator implements ResourceLocator {

	protected String prefix;

	public AbstractResourceLocator(final String prefix) {
		if (prefix == null) {
			throw new IllegalArgumentException("Prefix is null");
		}
		this.prefix = prefix;
	}

	public AbstractResourceLocator() {
		this("");
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * com.aurea.test.scumber.common.utils.ResourceLocator#getResourceName(java
	 * .lang.String)
	 */
	@Override
	public String getResourceName(final String name) {
		String value = null;
		if ("".equals(prefix)) {
			value = name;
		} else {
			value = String.format("%s/%s", prefix, name);
		}
		return value;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * com.aurea.test.scumber.common.utils.ResourceLocator#getAsFile(java.lang
	 * .String)
	 */
	@Override
	public File getAsFile(final String resource) throws URISyntaxException {
		URL u = getAsUrl(resource);
		
		if(u == null) {
			throw new IllegalArgumentException(String.format("The resource %s does not exist", resource));
		}
		
		File file = new File(u.toURI());
		
		if(!file.exists()) {
			throw new IllegalStateException(String.format("The resource %s does not exist", resource));
		}
		
		return file;
	}

	/*
	 * (non-Javadoc)
	 * @see com.aurea.test.scumber.common.utils.ResourceLocator#getFullPathResourceName(java.lang.String)
	 */
	@Override
	public String getFullPathResourceName(String resource) throws URISyntaxException {
		File file = getAsFile(resource);
		return file.getAbsolutePath();
	}

	/*
	 * (non-Javadoc)
	 * @see com.aurea.test.scumber.common.utils.ResourceLocator#getBaseFolder()
	 */
	@Override
	public String getBaseFolder() {
		String path = null;
		
		try {
			path = getFullPathResourceName(".");
		} catch (Exception e) {
			throw new RuntimeException(e.getMessage(), e);
		}
		
		return path;
	}
	
	

}
