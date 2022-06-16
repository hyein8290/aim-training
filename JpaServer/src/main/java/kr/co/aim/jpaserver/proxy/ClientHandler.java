package kr.co.aim.jpaserver.proxy;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;

import com.google.common.primitives.Ints;

import kr.co.aim.jpaserver.data.ChattingData;
import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.data.Packet;
import kr.co.aim.jpaserver.data.Room;
import kr.co.aim.jpaserver.manager.ChattingDataManager;
import kr.co.aim.jpaserver.manager.RoomManager;
import kr.co.aim.jpaserver.proxy.parser.MessageParser;


public class ClientHandler implements Runnable {

	@Autowired
	private ChattingDataManager chattingDataManager;
	
	@Autowired
	private RoomManager roomManager;
	
	private final Socket clientSock;
	private final MessageParser messageParser;
	private final MessageCallBack callBack;

	private final DataInputStream memberInput;
	private final DataOutputStream memberOutput;

	private Member member;

	public ClientHandler(final Socket clientSock, final MessageParser messageParser, final MessageCallBack callBack) throws IOException {
		this.clientSock = clientSock;
		this.messageParser = messageParser;
		this.callBack = callBack;

		memberInput = new DataInputStream(this.clientSock.getInputStream());
		memberOutput = new DataOutputStream(this.clientSock.getOutputStream());
	}

	// 5. 클라이언트가 보낸 메시지 받기
	/*
	 * 5.1 헤더 읽기
	 * 5.2 읽어온 int형 만큼 body배열 만들고
	 * 5.3 body 읽어오기
	 * 5.4 body를 String으로 변환
	 * 5.5 ChattingData에 뭘 넣어줘야겠어
	 * 		-> 누가 보냈는지, 어떤 방에서 보냈는지, 몇시에 보냈는지, 보낸 내용은 뭔지
	 * 		-> member, room, sendTime, content
	 * 
	 */
	@Override
	public void run() {

		try {
			while (true) {
				receive();
			}
		} catch (Exception ioe) {

			// TODO Logout event
			System.out.println("disconnection from " + clientSock.getRemoteSocketAddress());
		}
	}
	
	public void receive() throws Exception{
		Packet receivePacket = new Packet(this.memberInput);
		System.out.println("hi");
		receivePacket.read();
		int type = this.messageParser.byteArrayToInt(receivePacket.getTypeBytes());
		
		// TODO 코드 정리
		if(Packet.Type.ROOM_LIST.equals(type)) {
			List<Room> rooms = roomManager.findAllRoom();
			
			Packet sendPacket = new Packet(1, rooms.size(), null);
			
			// TODO 추출
			memberOutput.write(sendPacket.toByteArray());
			memberOutput.flush();
			
			for(Room room : rooms) {
				// sendPacket = new Packet(Packet.Type.ROOM_LIST, room.getId(), null);
				sendPacket = new Packet(1, room.getId(), null);
				memberOutput.write(sendPacket.toByteArray());
				memberOutput.flush();
			}
		} else if(Packet.Type.MAKE_ROOM.equals(type)) {
			Room room = roomManager.createRoom();
			Packet sendPacket = new Packet(2, room.getId(), null);
			memberOutput.write(sendPacket.toByteArray());
			memberOutput.flush();
		} else if(Packet.Type.ENTER_ROOM.equals(type)) {
			int roomId = this.messageParser.byteArrayToInt(receivePacket.getRoomIdBytes());
			// TODO 메시지 불러오기
		} else if(Packet.Type.SET_NAME.equals(type)) {
			// TODO 이름 설정하기
		} else if(Packet.Type.SEND_MESSAGE.equals(type)) {
			// TODO 메소드 추출하기
			int roomId = this.messageParser.byteArrayToInt(receivePacket.getRoomIdBytes());
			Room room = roomManager.getRoom(roomId);
			
			byte[] bodyBytes = receivePacket.getBodyBytes();
			
			String message = (String) this.messageParser.byteArrayToObject(bodyBytes);
			System.out.printf("%s: %s\n", this.member.getName(), message);
			
			ChattingData chattingData = chattingDataManager.create(this.member, room, message);
			
			this.callBack.onMessage(chattingData);
		}
	}
	
//	public void receive(Object object) throws IOException{
//		int type = memberInput.readInt();
//		byte[] bodyArray;
//		
//		// switch로 바꾸고 싶음,,
//		if(Packet.Type.ROOM_LIST.equals(type)) {
//			
//		} else if(Packet.Type.MAKE_ROOM.equals(type)) {
//			
//		} else if(Packet.Type.ENTER_ROOM.equals(type)) {
//			
//		} else if(Packet.Type.SET_NAME.equals(type)) {
//			
//		} else if(Packet.Type.SEND_MESSAGE.equals(type)) {
//			// TODO 메소드 추출하기
//			int roomId = memberInput.readInt();
//			Room room = roomManager.getRoom(roomId);
//			
//			int payload = memberInput.readInt();
//			bodyArray = new byte[payload];
//			memberInput.readFully(bodyArray);
//			
//			String message = (String) this.messageParser.byteArrayToObject(bodyArray);
//			System.out.printf("%s: %s\n", this.member.getName(), message);
//			
//			ChattingData chattingData = chattingDataManager.create(this.member, room, message);
//			
//			this.callBack.onMessage(chattingData);
//		}
//	}

	public void send(Object object) throws IOException {
		byte[] bodyArray = this.messageParser.objectToByteArray(object);
		byte[] headerArray = Ints.toByteArray(bodyArray.length);
		byte[] packetArray = new byte[headerArray.length + bodyArray.length];
		
		System.arraycopy(headerArray, 0, packetArray, 0, headerArray.length);
		System.arraycopy(bodyArray, 0, packetArray, headerArray.length, bodyArray.length);

		this.memberOutput.write(packetArray);
		this.memberOutput.flush();
	}

	public Member getMember() {
		return member;
	}

	public void setMember(Member member) {
		this.member = member;
	}
}
