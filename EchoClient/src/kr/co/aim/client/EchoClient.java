package kr.co.aim.client;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;

public class EchoClient {

	private Socket clientSocket;
	private BufferedReader in; 
	private PrintWriter out; 
	private Scanner scanner;

	private String ip;
	private int port;

	public EchoClient() {
		init();
	}
	
	public void run() {
		chat();
		close();
	}

	public void init() {
		try {
			connectServer();
			setStream();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

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

	//여기 좀 찝찝.. 메소드 이름도 찝찝
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

	private void setStream() throws IOException {
		in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
		out = new PrintWriter(clientSocket.getOutputStream());
	}

	//ip입력, port입력, socket 생성 다 같은 메소드에서???
	private void connectServer() {
		scanner = new Scanner(System.in);
		
		System.out.println("=============클라이언트===========");
		
		System.out.print("IP주소를 입력해주세요: ");
		ip = scanner.next();

		System.out.print("Port번호를 입력해주세요: ");
		port = scanner.nextInt();
		
		//TODO 숫자가 맞는지 먼저 유효성 검사하자, nextInt에서 오류나겠네,, try catch로 묶어야 하나
		if (port < 0 || port > 65535) {
			System.out.println();
			System.out.println("0~65535 사이의 값을 입력해주세요.");
			System.out.println("시스템을 종료합니다.");
			System.exit(0);
		}

		try {
			clientSocket = new Socket(ip, port);
			System.out.println("서버와 연결되었습니다.");
		} catch (UnknownHostException e) {
			System.out.println("Host를 찾을 수 없습니다.");
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}

	}

}
