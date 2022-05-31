package kr.co.aim.jpaserver.proxy;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

import com.google.common.primitives.Ints;

import kr.co.aim.jpaserver.data.ChattingData;
import kr.co.aim.jpaserver.data.Member;
import kr.co.aim.jpaserver.proxy.parser.MessageParser;

public class ClientHandler implements Runnable {

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

	@Override
	public void run() {

		try {
			while (true) {
				
				int payload = memberInput.readInt();
				byte[] bodyArray = new byte[payload];
				memberInput.readFully(bodyArray);

				String message = (String) this.messageParser.byteArrayToObject(bodyArray);
				System.out.println(String.format("%s %s", this.member.getId(), message));

				ChattingData chattingData = new ChattingData();
				chattingData.setClientId(this.member.getId());
				chattingData.setRoomId(this.member.getRoomId());
				// chattingData.setMessageName("CHATTING");
				chattingData.setContent(message);

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
