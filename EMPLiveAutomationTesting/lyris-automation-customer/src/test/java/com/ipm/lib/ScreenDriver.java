package com.ipm.lib;



public interface ScreenDriver<T> {

	public abstract void initializeDriver() throws ScumberException;

	public abstract void checkSanity() throws ScumberException;

	public abstract void open() throws ScumberException;

	public abstract void close() throws ScumberException;

	public abstract void wait(int time);

	public abstract T getDriver();

}