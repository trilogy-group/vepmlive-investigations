package com.ipm.lib;

public enum OperatingSystem {

	WINDOWS, LINUX, MAC, OTHER;

	public static OperatingSystem getCurrentOperatingSystem() {
		OperatingSystem type = OperatingSystem.OTHER;
		
		String name = System.getProperty("os.name");
		
		if (name != null) {
			name = name.toLowerCase();
			
			if (name.contains("mac")) {
				type = OperatingSystem.MAC;
			} else if (name.contains("windows")) {
				type = OperatingSystem.WINDOWS;
			} else if (name.contains("linux")) {
				type = OperatingSystem.LINUX;
			}
		} else {
			throw new IllegalStateException("It is not possible retrieve Operating System from current virtual machine!");
		}
		
		return type;
	}
	
	public static void run(final String command) {
		run(new String [] {command});
	}

	public static void run(final String[] command) {
		Thread t = new Thread(new Runnable() {
			
			@Override
			public void run() {
				try {
					Runtime r = Runtime.getRuntime();
					Process p = r.exec(command);
					p.waitFor();
				} catch (Exception e) {
					throw new ScumberException(e.getMessage(), e);
				}
			}
		});
		
		t.start();		
	}
	
	
}
