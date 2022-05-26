package kr.co.aim.chatserver.proxy;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;
import java.nio.ByteBuffer;
import java.time.LocalDateTime;

import kr.co.aim.chatserver.data.Member;
import kr.co.aim.chatserver.data.ChattingData;

public class ClientHandler implements Runnable{
	
	private final int HEADER_LENGTH = 4;
	
	private final Socket clientSocket;
	
	private final DataInputStream memberInput;
	private final OutputStream memberOutput;
	
	private Member member;
	
	public ClientHandler(final Socket clientSocket) throws IOException {
		this.clientSocket = clientSocket;
		
		// try-catch로 묶으면 final에 값 할당 안 돼서 에러
		// 에러 던져주자
		memberInput =  new DataInputStream(this.clientSocket.getInputStream());
		memberOutput = this.clientSocket.getOutputStream();
	}
	
	@Override
	public void run() {
		while(true) {
			try {
				// DataInputStream.readInt(): 앞에 4바이트만 읽어서 int로 바꿔줌
				int bodyLength = memberInput.readInt();
				byte[] bodyArray = new byte[bodyLength];
				memberInput.readFully(bodyArray);
				
				String message = new String(bodyArray);
				System.out.printf("[메시지 수신]%s: %s\n", this.member.getName(), message);
				
				ChattingData chattingData = new ChattingData();
				// TODO 멤버의 현재 채팅방 아이디 가져오기!!!
				chattingData.setMemberId(this.member.getId());
				chattingData.setSendTime(LocalDateTime.now());
				chattingData.setContent(message);
								
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}
	
	private void send(String message) throws IOException {
		byte[] bodyArray = message.getBytes();
		byte[] headerArray = ByteBuffer.allocate(HEADER_LENGTH).putInt(bodyArray.length).array();
		byte[] packetArray = new byte[headerArray.length + bodyArray.length];
		
		System.arraycopy(headerArray, 0, packetArray, 0, headerArray.length);
		System.arraycopy(bodyArray, 0, packetArray, headerArray.length, bodyArray.length);
		
		this.memberOutput.write(packetArray);
		this.memberOutput.flush();
	}

}
