package kr.co.aim.shadowserver.proxy;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

import com.google.common.primitives.Ints;

import kr.co.aim.shadowserver.data.ChattingData;
import kr.co.aim.shadowserver.data.User;
import kr.co.aim.shadowserver.proxy.parser.MessageParser;

public class ClientHandler implements Runnable {

	private final Socket clientSock;
	private final MessageParser messageParser;
	private final MessageCallBack callBack;

	private final DataInputStream userInput;
	private final DataOutputStream userOutput;

	private User user;

	public ClientHandler(final Socket clientSock, final MessageParser messageParser, final MessageCallBack callBack) throws IOException {
		this.clientSock = clientSock;
		this.messageParser = messageParser;
		this.callBack = callBack;

		userInput = new DataInputStream(this.clientSock.getInputStream());
		userOutput = new DataOutputStream(this.clientSock.getOutputStream());
	}

	@Override
	public void run() {

		try {
			while (true) {
				
				int payload = userInput.readInt();
				byte[] bodyArray = new byte[payload];
				userInput.readFully(bodyArray);

				String message = (String) this.messageParser.byteArrayToObject(bodyArray);
				System.out.println(String.format("%s %s", this.user.getId(), message));

				ChattingData chattingData = new ChattingData();
				chattingData.setClientId(this.user.getId());
				chattingData.setRoomId(this.user.getRoomId());
				// chattingData.setMessageName("CHATTING");
				chattingData.setMessageContent(message);

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

		this.userOutput.write(packetArray);
		this.userOutput.flush();
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}
}
