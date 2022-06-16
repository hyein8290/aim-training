package kr.co.aim.chatting.parser;

import java.nio.ByteBuffer;
import java.nio.charset.StandardCharsets;

import org.springframework.stereotype.Component;

@Component
public class MessageParser {
	
    // else if문으로 바꾸는 게 나은가?
	public byte[] objectToByteArray(Object obj) {
		if (obj instanceof Integer) {
			return ByteBuffer.allocate(4).putInt((Integer) obj).array();
		}
		
		if (obj instanceof String) {
			return ((String) obj).getBytes();
		}

		return null;
	}
	
	public byte[] intToByteArray(int obj) {
		return ByteBuffer.allocate(4).putInt(obj).array();
	}
    
	public String byteArrayToString(byte[] arr) {
		return new String(arr, StandardCharsets.UTF_8);
	}

	public int byteArrayToInt(byte[] arr) {
		return ByteBuffer.wrap(arr).getInt();
	}
}
