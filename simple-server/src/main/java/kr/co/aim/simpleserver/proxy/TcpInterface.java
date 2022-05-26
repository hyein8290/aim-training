package kr.co.aim.simpleserver.proxy;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.concurrent.ConcurrentHashMap;

import kr.co.aim.simpleserver.data.Member;

public class TcpInterface {

	private ServerSocket listenSocket;
	private final int PORT = 9000;
	
	public void run() {
		try {			
			while(true) {
				Socket clientSocket = this.listenSocket.accept();				
			}
		}catch (Exception e) {
			// TODO: handle exception
		}
	}
	
	public void open() {
		try {
			listenSocket = new ServerSocket(PORT);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
