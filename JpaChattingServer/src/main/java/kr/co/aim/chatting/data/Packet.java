package kr.co.aim.chatting.data;

import java.io.DataInputStream;
import java.io.IOException;
import java.nio.ByteBuffer;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import kr.co.aim.chatting.parser.MessageParser;
import lombok.Getter;
import lombok.Setter;

@Component
@Getter @Setter
public class Packet {
	
	private MessageParser messageParser;
	
	private DataInputStream input;
	
	private final int HEADER_LENGTH = 4;
	
	private byte[] typeBytes;
    private byte[] roomIdBytes;
    private byte[] lengthBytes;
    private byte[] bodyBytes;
    
    public Packet() {
    	this.typeBytes = new byte[HEADER_LENGTH];
        this.roomIdBytes = new byte[HEADER_LENGTH];
        this.lengthBytes = new byte[HEADER_LENGTH];
    }
    
    // 읽을 패킷 생성자
    public Packet(DataInputStream input) {
    	this.input = input;
    	this.typeBytes = new byte[HEADER_LENGTH];
        this.roomIdBytes = new byte[HEADER_LENGTH];
        this.lengthBytes = new byte[HEADER_LENGTH];
    }
    
    // 보낼 패킷 생성자
    /*
     * 1. type을 byte array로 변환 후 typeBytes에 저장
     * 2. roomId를 byte array로 변환 후 roomIdBytes에 저장
     * 3. body를  byte array로 변환 bodyBytes에 저장
     * 4. bodyBytes 길이를 byte array로 변환 후 lengthBytes에 저장
     */
    // TODO MessageParser 의존성 주입 문제 생각하기
    // TODO body null일때 에러잡기
    // body가 null이면 bodyBytes.length가 에러
    public Packet(MessageParser messageParser, int type, int roomId, String body) {
    	this.messageParser = messageParser;
    	typeBytes = this.messageParser.objectToByteArray(type);
    	roomIdBytes = this.messageParser.objectToByteArray(roomId);
    	
    	if(body != null) {
    		bodyBytes = this.messageParser.objectToByteArray(body);    		
    	} else {
    		bodyBytes = new byte[0];
    	}
    	
    	lengthBytes = this.messageParser.objectToByteArray(bodyBytes.length);    		

    }
    
    // 패킷 읽어오기
    public void read() {
    	try {
			input.read(typeBytes);
			input.read(roomIdBytes);

			int length = input.readInt();
//			input.read(lengthBytes);
//			int length = this.messageParser.byteArrayToInt(lengthBytes);
			
			bodyBytes = new byte[length];
			input.readFully(bodyBytes);
		} catch (IOException e) {
			e.printStackTrace();
		}
    }
    
    // 패킷 합치기
    public byte[] toByteArray() {
    	byte[] tempBytes = new byte[HEADER_LENGTH * 3 + bodyBytes.length];
    	
		System.arraycopy(typeBytes, 0, tempBytes, 0, typeBytes.length);
		System.arraycopy(roomIdBytes, 0, tempBytes, HEADER_LENGTH, HEADER_LENGTH);
		System.arraycopy(lengthBytes, 0, tempBytes, HEADER_LENGTH * 2, HEADER_LENGTH);
		System.arraycopy(bodyBytes, 0, tempBytes, HEADER_LENGTH * 3, bodyBytes.length);
		
    	return tempBytes;
    }
    
    public int getType() {
    	return messageParser.byteArrayToInt(this.typeBytes);
    }

}
