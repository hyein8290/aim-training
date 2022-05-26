package kr.co.aim.chatserver.proxy;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

import kr.co.aim.chatserver.manager.MemberManager;

public class TcpInterface implements Runnable{
	
	private final MemberManager memberManager;
	
	private ServerSocket listenSocket;
	
	public TcpInterface(int port, MemberManager memberManager) {
		this.memberManager = memberManager;
		
		try {
			this.listenSocket = new ServerSocket(port);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public void run() {
		
		while(true) {
			try {
				Socket clientSocket = this.listenSocket.accept();
				
				System.out.println("[클라이언트 접속] " + clientSocket.getRemoteSocketAddress());
			} catch (IOException e) {
				e.printStackTrace();
			}
			
		}
		
	}

}
