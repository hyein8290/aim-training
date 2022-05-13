package kr.co.aim.server;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.net.SocketException;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Scanner;

// TODO 인터페이스로 구현
public class EchoServerThread extends Thread {
	
	private final int MAX_BUFFER_SIZE = 1024;
	private final int HEADER_BYTE_COUNTS = 4;
	byte[] bytes = new byte[MAX_BUFFER_SIZE];
	
	private Socket clientSocket;
	private InputStream is;
	private Scanner in;
	private OutputStream out;
	private String clientIP;
	
	// 동기화 문제 생각해보기
	// ConcurrentMap<K,V> 속도, 동기화 문제 둘 다 해결
	// HashTable
	private HashMap<Long, User> myGroup;
	
	
	/**
	 * EchoServerThread 생성자
	 * @param clientSocket	통신할 clientSocket
	 */
	public EchoServerThread(Socket clientSocket, HashMap<Long, User> group) {
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
			System.out.println("[클라이언트 접속] " + clientIP);

			while(true) {
				int messageByteCounts = readMessageByteCounts();
				//String message = receiveMessage(messageByteCounts);
				bytes = receiveByteArray(messageByteCounts);
				String message = in.nextLine();
				System.out.println("[메시지 수신] " + clientIP + ": " + message);
				//sendMessage(bytes, messageByteCounts);
				sendToGroup(messageByteCounts);
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

	private String receiveMessage(int messageByteCounts) throws SocketException, IOException {
		byte[] messageBytes = new byte[messageByteCounts];

		is = clientSocket.getInputStream();
		is.read(messageBytes);
		
		// 왜  header는 안 읽어올까? 이미 읽어서 그런가보다.
		in = new Scanner(new InputStreamReader(new ByteArrayInputStream(messageBytes, 0, messageByteCounts)));
		// in = new Scanner(new InputStreamReader(new ByteArrayInputStream(bytes, HEADER_BYTE_NUM, messageByteCounts)));
		
		String output = in.nextLine();	
		//in.close();
		return output;
	}

	/**
	 * byte[] 형식의 메시지를 보내는 메소드
	 */
	private void sendMessage(byte[] bytes ,int messageByteCounts) throws SocketException, IOException {
		out = clientSocket.getOutputStream();
		out.write(bytes, 0, messageByteCounts);
		out.flush();
	}
	
	
	// 여기서는 sync 해봤자.. 자료구조를 바꿔주자
	private void sendToGroup(int messageByteCounts) throws SocketException, IOException {
		Iterator iterator = myGroup.keySet().iterator();
		
		while(iterator.hasNext()) {
			out = myGroup.get(iterator.next()).getSocket().getOutputStream();
			
			// TODO 아직 메시지만, 클라이언트에서 헤더 구분 하는 거 안함
			out.write(bytes, 0, messageByteCounts);
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
