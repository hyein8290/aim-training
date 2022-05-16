package kr.co.aim.server;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.net.SocketException;
import java.util.Iterator;
import java.util.Scanner;
import java.util.concurrent.ConcurrentHashMap;

// TODO 인터페이스로 구현
public class EchoServerThread extends Thread {
	
	private final int MAX_BUFFER_SIZE = 1024;
	private final int HEADER_BYTE_COUNTS = 4;
	
	private Socket clientSocket;
	private InputStream is;
	private Scanner in;
	private OutputStream out;
	private String clientIP;
	
	// 동기화 문제 생각해보기
	// ConcurrentMap<K,V> 속도, 동기화 문제 둘 다 해결
	// HashTable
	private ConcurrentHashMap<Long, User> myGroup;
	
	
	/**
	 * EchoServerThread 생성자
	 * @param clientSocket	통신할 clientSocket
	 */
	public EchoServerThread(Socket clientSocket, ConcurrentHashMap<Long, User> group) {
		this.clientSocket = clientSocket;
		this.myGroup = group;
	}
	
	/**
	 * 클라이언트와 통신하는 메소드
	 */
	@Override
	public void run() {
		try {
			clientIP = clientSocket.getInetAddress().toString();
			System.out.printf("[클라이언트 접속] IP: %s\n",clientIP);

			while(true) {
				int messageByteCounts = readMessageByteCounts();
				byte[] inputBytes = receiveByteArray(messageByteCounts);
				String message = in.nextLine();
				System.out.println("[메시지 수신] " + clientIP + ": " + message);
				sendToGroup(inputBytes, messageByteCounts);
			}
		} catch (SocketException e) {
			System.out.println("[클라이언트 퇴장] " + clientIP);
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			close();
		}
	}
	
	private byte[] receiveByteArray(int messageByteCounts) throws SocketException, IOException {
		byte[] messageBytes = new byte[messageByteCounts];
		is = clientSocket.getInputStream();
		is.read(messageBytes);
		in = new Scanner(new InputStreamReader(new ByteArrayInputStream(messageBytes, 0, messageByteCounts)));
		return messageBytes;
	}

	// 여기서는 sync 해봤자.. 자료구조를 바꿔주자
	private void sendToGroup(byte[] bodyBytes, int messageByteCounts) throws SocketException, IOException {
		byte[] messageBytes = new byte[HEADER_BYTE_COUNTS + messageByteCounts];
		
		Iterator<Long> iterator = myGroup.keySet().iterator();
		
		while(iterator.hasNext()) {
			out = myGroup.get(iterator.next()).getSocket().getOutputStream();
			
			// TODO 아직 메시지만, 클라이언트에서 헤더 구분 하는 거 안함
			out.write(bodyBytes, 0, messageByteCounts);
			out.flush();
		}
	}
	
	/**
	 * byte[] 형식의 메시지를 받아서 String으로 반환하는 메소드
	 */
	private int readMessageByteCounts() throws SocketException, IOException {
		byte[] headerBytes = new byte[HEADER_BYTE_COUNTS];
		is = clientSocket.getInputStream();
		is.read(headerBytes);
		return byteArrayToInt(headerBytes);
	}
	
	private int byteArrayToInt(byte[] bytes) {
		return (bytes[3] & 0xFF << 24) + ((bytes[2] & 0xFF) << 16) + ((bytes[1] & 0xFF) << 8) + (bytes[0] & 0xFF);
	}
	
	/**
	 * 자원 해제 메소드
	 */
	private void close() {
		try {
			is.close();
			clientSocket.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
}
