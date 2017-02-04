package com.epm.lib;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;
import lombok.ToString;

@Getter
@Setter
@AllArgsConstructor
@ToString(includeFieldNames=true)
public class TestProperty<T> {
private String key;
	private T value;
}
