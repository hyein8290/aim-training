package kr.co.aim.server;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.net.SocketException;
import java.util.Scanner;

public class EchoServerThread extends Thread {
	
	private final int MAX_BUFFER_SIZE = 1024;
	private final int HEADER_BYTE_NUM = 4;
	private Socket clientSocket;
	private InputStream is;
	private Scanner in;
	private OutputStream out;
	private String clientIP;
	
	/**
	 * EchoServerThread 생성자
	 * @param clientSocket	통신할 clientSocket
	 */
	public EchoServerThread(Socket clientSocket) {
		this.clientSocket = clientSocket;
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
				byte[] bytes = new byte[MAX_BUFFER_SIZE];
				int messageByteCounts = receiveMessageByteCounts(bytes);
				String message = receiveMessage(messageByteCounts);
				System.out.println("[메시지 수신] " + clientIP + ": " + message);
				sendMessage(bytes);
			}
		} catch (SocketException e) {
			System.out.println("[클라이언트 퇴장] " + clientIP);
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			close();
		}
	}

	private String receiveMessage(int messageByteCounts) throws SocketException, IOException {
		byte[] bytes = new byte[messageByteCounts];
		String output = "";		

		is = clientSocket.getInputStream();
		is.read(bytes);
		
		// 왜  header는 안 읽어올까? 이미 읽어서 그런가보다.
		in = new Scanner(new InputStreamReader(new ByteArrayInputStream(bytes, 0, messageByteCounts)));
		// in = new Scanner(new InputStreamReader(new ByteArrayInputStream(bytes, HEADER_BYTE_NUM, messageByteCounts)));
		
		output = in.nextLine();	

		in.close();

		return output;
	}

	/*
	 * 바이트어레이 형식의 메시지를 보내는 메소드
	 */
	private void sendMessage(byte[] bytes) throws SocketException, IOException {
		out = clientSocket.getOutputStream();
		out.write(bytes);
		out.flush();
	}
	
	/*
	 * byte[] 형식의 메시지를 받아서 String으로 반환하는 메소드
	 */
	private int receiveMessageByteCounts(byte[] bytes) throws SocketException, IOException {
		byte[] headerBytes = new byte[HEADER_BYTE_NUM];
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
