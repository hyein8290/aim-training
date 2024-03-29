package kr.co.aim.jpaserver.proxy.parser;

import java.nio.ByteBuffer;
import java.nio.charset.StandardCharsets;

public class DefaultMessageParser implements MessageParser {

	@Override
	public byte[] objectToByteArray(Object obj) {

		if (obj instanceof Integer) {
			return ByteBuffer.allocate(4).putInt((Integer) obj).array();
		}
		
		if (obj instanceof String) {
			return ((String) obj).getBytes();
		}

		return null;
	}

	@Override
	public Object byteArrayToObject(byte[] arr) {

		return new String(arr, StandardCharsets.UTF_8);

	}
	
	@Override
	public int byteArrayToInt(byte[] arr) {
		return ByteBuffer.wrap(arr).getInt();
	}

}
