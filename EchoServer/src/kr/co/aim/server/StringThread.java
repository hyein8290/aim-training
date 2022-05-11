package kr.co.aim.server;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;

public class StringThread extends Thread {
	
	private Socket clientSocket;
	private BufferedReader in;
	private PrintWriter out;
	
	private String clientIP;
	
	/**
	 * EchoServerThread 생성자
	 * @param clientSocket	통신할 clientSocket
	 */
	public StringThread(Socket clientSocket) {
		this.clientSocket = clientSocket;
		setStream();
	}
	
	/**
	 * stream 설정을 위한 메소드
	 */
	private void setStream() {
		try {
			in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
			out = new PrintWriter(new OutputStreamWriter(clientSocket.getOutputStream()));	
		} catch (IOException e) {
			e.printStackTrace();
		}	
	}
	
	/**
	 * 클라이언트와 통신하는 메소드
	 */
	@Override
	public void run() {
		clientIP = clientSocket.getInetAddress().toString();
		System.out.println("[클라이언트 접속] " + clientIP);
		
		String receiveData = "";
		
		try {
			while((receiveData = in.readLine()) != null) {
				System.out.println("[메시지 수신] " + clientIP + ": " + receiveData);
				out.println(receiveData);
				out.flush();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		close();
		System.out.println("[클라이언트 퇴장] " + clientIP);
	}
	
	/**
	 * 자원 해제 메소드
	 */
	private void close() {
		try {
			in.close();
			out.close();
			clientSocket.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
}
