package kr.co.aim.shadowserver.proxy.parser;

import java.nio.charset.StandardCharsets;

public class DefaultMessageParser implements MessageParser {

	@Override
	public byte[] objectToByteArray(Object obj) {

		if (obj instanceof String) {
			return ((String) obj).getBytes();
		}

		return null;
	}

	@Override
	public Object byteArrayToObject(byte[] arr) {

		return new String(arr, StandardCharsets.UTF_8);

	}

}
