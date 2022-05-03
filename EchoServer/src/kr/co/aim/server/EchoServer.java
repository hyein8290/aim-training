package kr.co.aim.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.InputMismatchException;
import java.util.List;
import java.util.Scanner;

public class EchoServer {

	private ServerSocket serverSocket;
	private Socket clientSocket;
	private Scanner scanner;
//	private List<Thread> list;
	
	private int port;
	
	/**
	 * EchoServer 생성자
	 * serverSocket을 생성
	 */
	public EchoServer() {
		createServerSocket();
	}

	/**
	 * 서버를 실행하는 메소드
	 * thread를 사용하여 클라이언트 다중 접속이 가능하도록 한다.
	 */
	public void run() {		
		try {
			System.out.println("[서버 시작] 클라이언트 대기중..");
			
			while(true) {
				clientSocket = serverSocket.accept();
				EchoServerThread thread = new EchoServerThread(clientSocket);
				thread.start();
			}
			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	/**
	 * port번호를 입력받고 serverSocket을 생성하는 메소드
	 */
	private void createServerSocket() {
		try {
			System.out.println("================서버================");

			scanner = new Scanner(System.in);
			
			System.out.print("Open할 Port번호를 입력해주세요: ");
			port = scanner.nextInt();

			serverSocket = new ServerSocket(port);
			
		} catch (InputMismatchException e) {
			System.out.println("숫자만 입력");
		} catch (IllegalArgumentException e) {
			System.out.println("0~65535 사이의 값을 입력해주세요.");
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}