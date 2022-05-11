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
				String message = receiveMessage(bytes);
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
	private String receiveMessage(byte[] bytes) throws SocketException, IOException {
		String output = "";		

		is = clientSocket.getInputStream();
		is.read(bytes);
		in = new Scanner(new InputStreamReader(new ByteArrayInputStream(bytes)));
		output = in.nextLine();	

		return output;
	}
	
	/**
	 * 자원 해제 메소드
	 */
	private void close() {
		try {
			is.close();
			in.close();
			out.close();
			clientSocket.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
}
