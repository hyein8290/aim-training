package kr.co.aim.jpaserver.proxy.parser;

public interface MessageParser {
	byte[] objectToByteArray(Object obj);

	Object byteArrayToObject(byte[] arr);
}
