package kr.co.aim.jpaserver.proxy;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.google.common.primitives.Ints;

import kr.co.aim.jpaserver.data.ChattingData;
import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.manager.ChattingDataManager;
import kr.co.aim.jpaserver.proxy.parser.MessageParser;

@Component
public class ClientHandler implements Runnable {

	@Autowired
	private ChattingDataManager chattingDataManager;
	
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
				
				int payload = memberInput.readInt();
				byte[] bodyArray = new byte[payload];
				memberInput.readFully(bodyArray);

				String message = (String) this.messageParser.byteArrayToObject(bodyArray);
				System.out.println(String.format("%s %s", this.member.getId(), message));

				ChattingData chattingData = chattingDataManager.create(this.member, null, message);

				this.callBack.onMessage(chattingData);
			}
		} catch (Exception ioe) {

			// TODO Logout event
			System.out.println("disconnection from " + clientSock.getRemoteSocketAddress());
		}
	}

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
