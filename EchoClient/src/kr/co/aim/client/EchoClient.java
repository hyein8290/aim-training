package kr.co.aim.client;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.InputMismatchException;
import java.util.Scanner;

/**
 *	Server와 통신하기 위한 client 클래스
 */
public class EchoClient {

	private Socket clientSocket;
	private BufferedReader in; 
	private PrintWriter out; 
	private Scanner scanner;

	private String ip;
	private int port;

	/**
	 * EchoClient 생성자 메소드
	 * init으로 client소켓을 생성하고 stream 초기화
	 */
	public EchoClient() {
		init();
	}
	
	/**
	 * connectServer()와 setStream() 호출
	 */
	public void init() {
		setSocket();
		setStream();
	}
	
	/**
	 * chat() 실행 후 close() 실행
	 */
	public void run() {
		chat();
		close();
	}

	/**
	 * 서버와 통신하기 위한 socket을 설정하고 서버에 연결하는 메소드
	 */
	private void setSocket() {		
		try {
			scanner = new Scanner(System.in);
			
			System.out.println("=============클라이언트============");
			
			System.out.print("IP주소를 입력해주세요: ");
			ip = scanner.nextLine();
			
			System.out.print("Port번호를 입력해주세요: ");
			port = scanner.nextInt();

			clientSocket = new Socket(ip, port);
			System.out.println("서버와 연결되었습니다.");
			
		} catch (IllegalArgumentException e) {
			System.out.println("0~65535 사이의 값을 입력해주세요.");
			System.out.println("시스템을 종료합니다.");
			System.exit(0);
		} catch (UnknownHostException e) {
			System.out.println("IP주소를 확인할 수 없습니다.");
		} catch (IOException e) {
			e.printStackTrace();
		} 	
	}
	
	/**
	 * 데이터를 주고 받기 위한 stream을 설정하는 메소드
	 */
	private void setStream() {
		try {
			in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
			out = new PrintWriter(clientSocket.getOutputStream());
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * 서버에 메시지를 보내고 서버에서 echo 받는 메소드
	 */
	private void chat() {
		try {
			String inputData = "";
			
			while (!inputData.equals("exit")) {
				System.out.print("보낼 메시지: ");
				inputData = scanner.next();
				out.println(inputData);
				out.flush();
				System.out.println("Echo: " + in.readLine());
			}
			
			System.out.println("접속을 종료합니다.");
			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	/**
	 * 자원 해제를 위한 메소드
	 */
	private void close(){		
		try {
			scanner.close();
			in.close();
			out.close();
			clientSocket.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
