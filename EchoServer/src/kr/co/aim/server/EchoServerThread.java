package kr.co.aim.server;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;

public class EchoServerThread extends Thread {
	
	private Socket clientSocket;
	private BufferedReader in;
	private PrintWriter out;
	
	private String clientIP;
	
	public EchoServerThread(Socket clientSocket) {
		this.clientSocket = clientSocket;
		setThread();
	}
	
	private void setThread() {
		try {
			in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
			out = new PrintWriter(new OutputStreamWriter(clientSocket.getOutputStream()));
			
			clientIP = clientSocket.getInetAddress().toString();
			System.out.println("[클라이언트 접속] " + clientIP);	//TODO clientIP 맞나 확인
			
		} catch (IOException e) {
			e.printStackTrace();
		}	
	}
	
	@Override
	public void run() {
		
		String receiveData = ""; //초기화 하는 게 낫나?
		
		try {
			while((receiveData = in.readLine()) != null) {
				System.out.println("[메시지 수신] " + clientIP + ": " + receiveData);
				out.println(receiveData);
				out.flush();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
}
