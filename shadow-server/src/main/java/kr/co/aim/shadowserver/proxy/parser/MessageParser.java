package kr.co.aim.shadowserver.proxy.parser;

public interface MessageParser {
	byte[] objectToByteArray(Object obj);

	Object byteArrayToObject(byte[] arr);
}
