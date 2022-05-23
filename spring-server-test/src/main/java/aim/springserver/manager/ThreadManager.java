package aim.springserver.manager;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;
import java.net.SocketException;
import java.nio.ByteBuffer;
import java.util.Iterator;
import java.util.concurrent.ConcurrentHashMap;

import aim.springserver.domain.Room;
import aim.springserver.domain.User;

public class ThreadManager implements Runnable{

	private final int HEADER_BYTE_COUNTS = 4;	// 헤더 바이트 수
	
	private User user;
	private InputStream in;
	private OutputStream out;
	private String userIP;
	private Socket userSocket;
	
	private Room room;
	
	/**
	 * EchoServerThread 생성자
	 * @param clientSocket	통신할 clientSocket
	 */
	public ThreadManager(User user, Room room) {
		this.user = user;
		this.room = room;
		this.userSocket = user.getSocket();
	}
	
	/**
	 * 클라이언트와 통신하는 메소드
	 */
	@Override
	public void run() {
		try {
			userIP = userSocket.getInetAddress().toString();
			System.out.printf("[클라이언트 접속] IP: %s\n", userIP);	
			in = userSocket.getInputStream();	// 언제 초기화하는게 좋을까

			while(true) {
				int messageByteCounts = readMessageByteCounts();
				byte[] inputBytes = receiveByteArray(messageByteCounts);
				String message = new String(inputBytes);
				System.out.println("[메시지 수신] " + userIP + ": " + message);
				sendToGroup(inputBytes, messageByteCounts);
			}
		} catch (SocketException e) {
			System.out.println("[클라이언트 퇴장] " + userIP);
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			close();
		}
	}
	
	/**
	 * header안에 적힌 body 길이를 읽는 메소드
	 */
	private int readMessageByteCounts() throws SocketException, IOException {
		byte[] headerBytes = new byte[HEADER_BYTE_COUNTS];
		in.read(headerBytes);
		return byteArrayToInt(headerBytes);
	}
	
	/**
	 * byte[] 형식의 메시지를 받는 메소드
	 * @param messageByteCounts		메시지 byte의 길이
	 * @return 						byte[] 형식의 메시지
	 */
	private byte[] receiveByteArray(int messageByteCounts) throws SocketException, IOException {
		byte[] messageBytes = new byte[messageByteCounts];
		in.read(messageBytes);
		return messageBytes;
	}

	/**
	 * 클라이언트가 속한 그룹에 메시지를 보내는 메소드
	 * @param bodyBytes
	 * @param messageByteCounts
	 */
	private void sendToGroup(byte[] bodyBytes, int messageByteCounts) throws SocketException, IOException {
        ByteBuffer buff = ByteBuffer.allocate(HEADER_BYTE_COUNTS + messageByteCounts);
        buff.putInt(messageByteCounts);
        buff.put(bodyBytes);
        		
        ConcurrentHashMap<Integer, User> userMap = room.getUserMap();
        Iterator<Integer> iterator = userMap.keySet().iterator();
		
		while(iterator.hasNext()) {
			out = userMap.get(iterator.next()).getSocket().getOutputStream();
			out.write(buff.array(), 0, HEADER_BYTE_COUNTS + messageByteCounts);
			out.flush();
		}
	}
	
	/**
	 * byte[]를 int형으로 바꾸는 메소드
	 */
	private int byteArrayToInt(byte[] bytes) {
		return (bytes[3] & 0xFF << 24) + ((bytes[2] & 0xFF) << 16) + ((bytes[1] & 0xFF) << 8) + (bytes[0] & 0xFF);
	}
	
	/**
	 * 자원 해제 메소드
	 */
	private void close() {
		try {
			in.close();
			userSocket.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
