package com.ipm.lib;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class PropertiesLoader {

	private static PropertiesLoader INSTANCE;
	
	public static PropertiesLoader getInstance() {
		if (INSTANCE == null) {
			INSTANCE = new PropertiesLoader(new ClassLoaderResourceLocator());
		}
		
		return INSTANCE;
	}
	
	private ResourceLocator resourceLocator;
	
	private PropertiesLoader(ResourceLocator resourceLocator) {
		this.resourceLocator = resourceLocator;
	}
	
	public Properties load(final String propertyFile) {
		InputStream s = resourceLocator.getAsStream(propertyFile);
		
		Properties p = new Properties();
		try {
			p.load(s);
		} catch (IOException e) {
			throw new ScumberException(e.getMessage(), e);
		}
		
		return p;
	}
	
}
