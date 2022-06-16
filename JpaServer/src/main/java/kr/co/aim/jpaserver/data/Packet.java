package kr.co.aim.jpaserver.data;

import java.io.DataInputStream;
import java.io.IOException;

import kr.co.aim.jpaserver.proxy.parser.DefaultMessageParser;
import kr.co.aim.jpaserver.proxy.parser.MessageParser;
import lombok.Getter;
import lombok.Setter;

// 롬복이 안 먹힘;
@Getter @Setter
public class Packet {
    
	public enum Type {
		ROOM_LIST,
		MAKE_ROOM,
		ENTER_ROOM,
		SET_NAME,
		SEND_MESSAGE;
	}
	
	private final int HEADER_LENGTH = 4;
	
	private final MessageParser messageParser = new DefaultMessageParser();

	private DataInputStream input;
    
	// 생성자에서 생성 vs 필드에서 바로 생성
	private byte[] typeBytes = new byte[HEADER_LENGTH];
    private byte[] roomIdBytes = new byte[HEADER_LENGTH];
    private byte[] lengthBytes = new byte[HEADER_LENGTH];
    private byte[] bodyBytes;
    
    public Packet(DataInputStream input) {
    	this.input = input;
	}
    
    // body가 null인 경우??
    public Packet(int type, int roomId, String body) {
    	typeBytes = this.messageParser.objectToByteArray(type);
    	roomIdBytes = this.messageParser.objectToByteArray(roomId);
    	bodyBytes = this.messageParser.objectToByteArray(body);
    	lengthBytes = this.messageParser.objectToByteArray(bodyBytes.length);
	}
    
    public byte[] toByteArray() {
    	byte[] tempBytes = new byte[HEADER_LENGTH * 3 + bodyBytes.length];
    	
		System.arraycopy(typeBytes, 0, tempBytes, 0, typeBytes.length);
		System.arraycopy(roomIdBytes, 0, tempBytes, HEADER_LENGTH, HEADER_LENGTH);
		System.arraycopy(lengthBytes, 0, tempBytes, HEADER_LENGTH * 2, HEADER_LENGTH);
		System.arraycopy(bodyBytes, 0, tempBytes, HEADER_LENGTH * 3, bodyBytes.length);
		
    	return tempBytes;
    }
    
    // 읽는 건 패킷에서 읽고, 보내는 건 밖에서 보내? 이상한디 
    public void read() {
    	try {
        	input.read(typeBytes);
        	input.read(roomIdBytes);
        	
        	// lengthBytes로 읽은 다음에 int로 변환할까?
        	int length = input.readInt();
        	bodyBytes = new byte[length];
        	input.readFully(bodyBytes);
		} catch (IOException e) {
			e.printStackTrace();
		}
    }
    
	public DataInputStream getInput() {
		return input;
	}
	
	public void setInput(DataInputStream input) {
		this.input = input;
	}
	
	public byte[] getTypeBytes() {
		return typeBytes;
	}
	
	public void setTypeBytes(byte[] typeBytes) {
		this.typeBytes = typeBytes;
	}
	
	public byte[] getRoomIdBytes() {
		return roomIdBytes;
	}
	
	public void setRoomIdBytes(byte[] roomIdBytes) {
		this.roomIdBytes = roomIdBytes;
	}
	
	public byte[] getLengthBytes() {
		return lengthBytes;
	}
	
	public void setLengthBytes(byte[] lengthBytes) {
		this.lengthBytes = lengthBytes;
	}
	
	public byte[] getBodyBytes() {
		return bodyBytes;
	}
	
	public void setBodyBytes(byte[] bodyBytes) {
		this.bodyBytes = bodyBytes;
	}
	
}
