package kr.co.aim.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.List;
import java.util.Scanner;

public class EchoServer {

	private ServerSocket serverSocket;
	private Socket clientSocket;
	private Scanner scanner;
//	private List<Thread> list;
	
	private int port;

	public static void main(String[] args) {
		new EchoServer();
	}

	public EchoServer() {
		init();
	}

	public void init() {
		System.out.println("================서버================");
		
		setServerPort();
		createServerSocket();

		System.out.println("[서버 시작] 클라이언트 대기중..");
		
		try {
			while(true) {
				clientSocket = serverSocket.accept();
				EchoServerThread thread = new EchoServerThread(clientSocket);
				thread.start();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	private void createServerSocket() {
		try {
			serverSocket = new ServerSocket(port);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	private void setServerPort() {
		System.out.print("Open할 Port번호를 입력해주세요: ");

		scanner = new Scanner(System.in);
		port = scanner.nextInt();

		if (port < 0 || port > 65535) {
			System.out.println("0~65535 사이의 값을 입력해주세요.");
			System.out.println("시스템을 종료합니다.");
			System.exit(0);
		}
	}
}