package kr.co.aim.chatserver.proxy.parser;

public interface MessageParser {
	byte[] objectToByteArray(Object obj);

	Object byteArrayToObject(byte[] arr);
}
